using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel; // for Win32Exception

namespace Cerulean
{
    public static class Encryptor
    {
        private static bool onWinNT;

        static Encryptor()
        {
            onWinNT = WinVerKit.windowsNT5PlusChecker();
        }

        public static string Encrypt(string plaintext)
        {
            if (onWinNT)
                return DpapiNative.ProtectString(plaintext);
            else
                return CeruleanCrypt.Crypt(plaintext);
        }

        public static string Decrypt(string plaintext)
        {
            if (onWinNT)
                return DpapiNative.UnprotectString(plaintext);
            else
                return CeruleanCrypt.Uncrypt(plaintext);
        }
    }

    public static class CeruleanCrypt
    {
        // 32-byte user-specific key for AES-256
        private static readonly byte[] Key = GenerateKey("0x0CeruleanCrypt");

        // 32-byte key for HMAC-SHA256
        private static readonly byte[] HmacKey = GenerateKey("CeruleanHMAC");

        // Magic header to verify successful decryption
        private const string header = "CERULEANCRYPTv1::";

        // Generate key from username + machine + salt
        public static byte[] GenerateKey(string salt)
        {
            string userData = Environment.UserName + salt + Environment.MachineName;
            byte[] bytes = Encoding.UTF8.GetBytes(userData);

            using (SHA256Managed sha = new SHA256Managed())
            {
                return sha.ComputeHash(bytes); // 32 bytes → AES-256
            }
        }

        // Encrypt plaintext with random IV, prepend header, append HMAC
        public static string Crypt(string plaintext)
        {
            // Prepend magic header
            string dataWithHeader = header + plaintext;
            byte[] data = Encoding.UTF8.GetBytes(dataWithHeader);

            using (RijndaelManaged rij = new RijndaelManaged())
            {
                rij.Key = Key;
                rij.Mode = CipherMode.CBC;
                rij.Padding = PaddingMode.PKCS7;
                rij.GenerateIV();
                byte[] iv = rij.IV;

                ICryptoTransform encryptor = rij.CreateEncryptor();
                byte[] ciphertext = encryptor.TransformFinalBlock(data, 0, data.Length);

                // Combine IV + ciphertext
                byte[] combined = new byte[iv.Length + ciphertext.Length];
                Array.Copy(iv, 0, combined, 0, iv.Length);
                Array.Copy(ciphertext, 0, combined, iv.Length, ciphertext.Length);

                // Compute HMAC
                using (HMACSHA256 hmac = new HMACSHA256(HmacKey))
                {
                    byte[] hmacBytes = hmac.ComputeHash(combined);

                    // Final result: IV + ciphertext + HMAC
                    byte[] finalResult = new byte[combined.Length + hmacBytes.Length];
                    Array.Copy(combined, 0, finalResult, 0, combined.Length);
                    Array.Copy(hmacBytes, 0, finalResult, combined.Length, hmacBytes.Length);

                    return Convert.ToBase64String(finalResult);
                }
            }
        }

        // Decrypt and verify HMAC + header
        public static string Uncrypt(string encryptedText)
        {
            try
            {
                byte[] fullData = Convert.FromBase64String(encryptedText);

                // Separate HMAC (last 32 bytes for SHA256)
                int hmacLength = 32;
                if (fullData.Length < hmacLength + 16) // minimum: IV + HMAC
                    throw new CryptographicException("Invalid encrypted data length");

                byte[] hmacStored = new byte[hmacLength];
                Array.Copy(fullData, fullData.Length - hmacLength, hmacStored, 0, hmacLength);

                byte[] combined = new byte[fullData.Length - hmacLength];
                Array.Copy(fullData, 0, combined, 0, combined.Length);

                // Verify HMAC
                using (HMACSHA256 hmac = new HMACSHA256(HmacKey))
                {
                    byte[] hmacComputed = hmac.ComputeHash(combined);
                    for (int i = 0; i < hmacLength; i++)
                    {
                        if (hmacStored[i] != hmacComputed[i])
                            throw new CryptographicException("Data has been tampered with or key mismatch!");
                    }
                }

                // Extract IV (first 16 bytes)
                byte[] iv = new byte[16];
                Array.Copy(combined, 0, iv, 0, iv.Length);

                // Extract ciphertext
                byte[] ciphertext = new byte[combined.Length - iv.Length];
                Array.Copy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

                using (RijndaelManaged rij = new RijndaelManaged())
                {
                    rij.Key = Key;
                    rij.IV = iv;
                    rij.Mode = CipherMode.CBC;
                    rij.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = rij.CreateDecryptor();
                    byte[] decrypted = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

                    string decryptedText = Encoding.UTF8.GetString(decrypted);

                    // Verify magic header
                    if (!decryptedText.StartsWith(header))
                        throw new CryptographicException("Decryption invalid: header mismatch");

                    // Return plaintext without header
                    return decryptedText.Substring(header.Length);
                }
            }

            catch
            {
                return "$CERULEAN_ENCRYPTOR_ERROR_DECRYPT";
            }
        }
    }

    public static class DpapiNative
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct DATA_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CryptProtectData(
            ref DATA_BLOB pDataIn,
            string szDataDescr,
            ref DATA_BLOB pOptionalEntropy,
            IntPtr pvReserved,
            IntPtr pPromptStruct,
            int dwFlags,
            out DATA_BLOB pDataOut);

        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CryptUnprotectData(
            ref DATA_BLOB pDataIn,
            StringBuilder ppszDataDescr,
            ref DATA_BLOB pOptionalEntropy,
            IntPtr pvReserved,
            IntPtr pPromptStruct,
            int dwFlags,
            out DATA_BLOB pDataOut);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LocalFree(IntPtr hMem);

        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;

        // Protect bytes -> returns encrypted bytes (use Convert.ToBase64String to store as text)
        public static byte[] Protect(byte[] plainBytes, byte[] optionalEntropy = null, bool machineScope = false)
        {
            if (plainBytes == null) throw new ArgumentNullException("plainBytes");

            DATA_BLOB inBlob = new DATA_BLOB();
            inBlob.cbData = plainBytes.Length;
            inBlob.pbData = Marshal.AllocHGlobal(plainBytes.Length);
            Marshal.Copy(plainBytes, 0, inBlob.pbData, plainBytes.Length);

            DATA_BLOB entropyBlob = new DATA_BLOB();
            if (optionalEntropy != null && optionalEntropy.Length > 0)
            {
                entropyBlob.cbData = optionalEntropy.Length;
                entropyBlob.pbData = Marshal.AllocHGlobal(optionalEntropy.Length);
                Marshal.Copy(optionalEntropy, 0, entropyBlob.pbData, optionalEntropy.Length);
            }
            else
            {
                entropyBlob.cbData = 0;
                entropyBlob.pbData = IntPtr.Zero;
            }

            DATA_BLOB outBlob;
            int flags = CRYPTPROTECT_UI_FORBIDDEN | (machineScope ? CRYPTPROTECT_LOCAL_MACHINE : 0);
            bool ok = CryptProtectData(ref inBlob, null, ref entropyBlob, IntPtr.Zero, IntPtr.Zero, flags, out outBlob);

            // free input buffers
            Marshal.FreeHGlobal(inBlob.pbData);
            if (entropyBlob.pbData != IntPtr.Zero) Marshal.FreeHGlobal(entropyBlob.pbData);

            if (!ok)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            byte[] encrypted = new byte[outBlob.cbData];
            Marshal.Copy(outBlob.pbData, encrypted, 0, outBlob.cbData);

            // free the blob memory allocated by the API
            LocalFree(outBlob.pbData);

            return encrypted;
        }


        // Unprotect bytes
        public static byte[] Unprotect(byte[] encryptedBytes, byte[] optionalEntropy = null, bool machineScope = false)
        {

            if (encryptedBytes == null) throw new ArgumentNullException("encryptedBytes");

            DATA_BLOB inBlob = new DATA_BLOB();
            inBlob.cbData = encryptedBytes.Length;
            inBlob.pbData = Marshal.AllocHGlobal(encryptedBytes.Length);
            Marshal.Copy(encryptedBytes, 0, inBlob.pbData, encryptedBytes.Length);

            DATA_BLOB entropyBlob = new DATA_BLOB();
            if (optionalEntropy != null && optionalEntropy.Length > 0)
            {
                entropyBlob.cbData = optionalEntropy.Length;
                entropyBlob.pbData = Marshal.AllocHGlobal(optionalEntropy.Length);
                Marshal.Copy(optionalEntropy, 0, entropyBlob.pbData, optionalEntropy.Length);
            }
            else
            {
                entropyBlob.cbData = 0;
                entropyBlob.pbData = IntPtr.Zero;
            }

            DATA_BLOB outBlob;
            int flags = CRYPTPROTECT_UI_FORBIDDEN | (machineScope ? CRYPTPROTECT_LOCAL_MACHINE : 0);
            bool ok = CryptUnprotectData(ref inBlob, null, ref entropyBlob, IntPtr.Zero, IntPtr.Zero, flags, out outBlob);

            // free input buffers
            Marshal.FreeHGlobal(inBlob.pbData);
            if (entropyBlob.pbData != IntPtr.Zero) Marshal.FreeHGlobal(entropyBlob.pbData);

            if (!ok)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            byte[] decrypted = new byte[outBlob.cbData];
            Marshal.Copy(outBlob.pbData, decrypted, 0, outBlob.cbData);

            LocalFree(outBlob.pbData);
            return decrypted;

        }

        // Convenience string helpers (returns/accepts Base64)
        public static string ProtectString(string plaintext, byte[] optionalEntropy = null, bool machineScope = false)
        {
            byte[] data = Encoding.UTF8.GetBytes(plaintext ?? "");
            byte[] enc = Protect(data, optionalEntropy, machineScope);
            return Convert.ToBase64String(enc);
        }

        public static string UnprotectString(string encryptedBase64, byte[] optionalEntropy = null, bool machineScope = false)
        {
            try
            {
                byte[] enc = Convert.FromBase64String(encryptedBase64);
                byte[] dec = Unprotect(enc, optionalEntropy, machineScope);
                return Encoding.UTF8.GetString(dec);
            }
            catch
            {
                return "$CERULEAN_ENCRYPTOR_ERROR_DECRYPT";
            }
        }
    }
}
