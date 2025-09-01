using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Math;
using Newtonsoft.Json.Linq;

namespace OmegaAOL.OAuth
{
    public static class OAuthFlow
    {
        // --- PKCE Helper ---
        public static class PkceHelper
        {
            public static string GenerateCodeVerifier()
{
    return GenerateString(32);
}

public static string GenerateStateToken(int length = 32)
{
    return GenerateString(length);
}

            private static string GenerateString(int length)
            {
                byte[] bytes = new byte[length];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(bytes);
                return Base64UrlEncode(bytes);
            }

            public static string GenerateCodeChallenge(string codeVerifier)
            {
                byte[] hash;
                using (SHA256 sha = SHA256.Create())
                    hash = sha.ComputeHash(Encoding.ASCII.GetBytes(codeVerifier));
                return Base64UrlEncode(hash);
            }

            private static string Base64UrlEncode(byte[] input)
            {
                string base64 = Convert.ToBase64String(input);
                return base64.Replace("+", "-").Replace("/", "_").TrimEnd('=');
            }
        }

        // --- DPoP Helper ---
        public static class DpopHelper
        {
            public static AsymmetricCipherKeyPair GenerateKeyPair()
            {
                ECKeyPairGenerator gen = new ECKeyPairGenerator();
                var ecParam = Org.BouncyCastle.Asn1.Sec.SecNamedCurves.GetByName("secp256r1"); 
                ECDomainParameters domainParams = new ECDomainParameters(ecParam.Curve, ecParam.G, ecParam.N, ecParam.H);
                gen.Init(new ECKeyGenerationParameters(domainParams, new SecureRandom()));
                return gen.GenerateKeyPair();
            }

            private static long GetUnixTimeSeconds()
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return (long)(DateTime.UtcNow - epoch).TotalSeconds;
            }

            public static string CreateDpopJwt(string htm, string htu, string nonce, AsymmetricCipherKeyPair keyPair)
            {
                JObject jwk = ConvertToJwk((ECPrivateKeyParameters)keyPair.Private, (ECPublicKeyParameters)keyPair.Public);
                JObject header = new JObject();
                header["typ"] = "dpop+jwt";
                header["alg"] = "ES256";
                header["jwk"] = jwk;

                JObject payload = new JObject();
                payload["htu"] = htu;
                payload["htm"] = htm;
                payload["jti"] = Guid.NewGuid().ToString("N");
                payload["iat"] = GetUnixTimeSeconds();
                if (!string.IsNullOrEmpty(nonce))
                    payload["nonce"] = nonce;

                string headerBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(header.ToString()));
                string payloadBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(payload.ToString()));
                string unsignedToken = headerBase64 + "." + payloadBase64;

                string signature = Sign(unsignedToken, keyPair);
                return unsignedToken + "." + signature;
            }

            private static string Base64UrlEncode(byte[] input)
            {
                string base64 = Convert.ToBase64String(input);
                return base64.Replace("+", "-").Replace("/", "_").TrimEnd('=');
            }

            private static string Sign(string data, AsymmetricCipherKeyPair keyPair)
            {
                byte[] hash;
                using (SHA256 sha = SHA256.Create())
                    hash = sha.ComputeHash(Encoding.UTF8.GetBytes(data));

                ECDsaSigner signer = new ECDsaSigner();
                signer.Init(true, keyPair.Private);
                BigInteger[] sig = signer.GenerateSignature(hash);

                byte[] r = sig[0].ToByteArrayUnsigned();
                byte[] s = sig[1].ToByteArrayUnsigned();

                byte[] rPadded = new byte[32];
                byte[] sPadded = new byte[32];
                Array.Copy(r, 0, rPadded, 32 - r.Length, r.Length);
                Array.Copy(s, 0, sPadded, 32 - s.Length, s.Length);

                byte[] concatenated = new byte[64];
                Array.Copy(rPadded, 0, concatenated, 0, 32);
                Array.Copy(sPadded, 0, concatenated, 32, 32);

                return Base64UrlEncode(concatenated);
            }

            private static JObject ConvertToJwk(ECPrivateKeyParameters priv, ECPublicKeyParameters pub)
            {
                var q = pub.Q.Normalize();
                JObject result = new JObject();
                result["kty"] = "EC";
                result["crv"] = "P-256";
                result["x"] = Base64UrlEncode(q.AffineXCoord.GetEncoded());
                result["y"] = Base64UrlEncode(q.AffineYCoord.GetEncoded());
                return result;
            }
        }

        // --- OAuth Test Flow ---
        public static void Test()
        {
            string codeVerifier = PkceHelper.GenerateCodeVerifier();
            string codeChallenge = PkceHelper.GenerateCodeChallenge(codeVerifier);
            string state = PkceHelper.GenerateStateToken();
            AsymmetricCipherKeyPair dpopKey = DpopHelper.GenerateKeyPair();

            string clientId = "https://ceruleanweb.neocities.org/oauth/client-metadata.json";
            string redirectUri = "https://ceruleanweb.neocities.org/oauth/callback";
            string scope = "atproto transition:generic";

            // 1️⃣ Open authorization URL
            string authUrl = "https://bsky.social/oauth/authorize?" +
                             "client_id=" + Uri.EscapeDataString(clientId) +
                             "&redirect_uri=" + Uri.EscapeDataString(redirectUri) +
                             "&response_type=code" +
                             "&scope=" + Uri.EscapeDataString(scope) +
                             "&code_challenge=" + Uri.EscapeDataString(codeChallenge) +
                             "&code_challenge_method=S256" +
                             "&state=" + Uri.EscapeDataString(state);

            System.Diagnostics.Process.Start(authUrl);

            // 2️⃣ After user logs in and redirects back, you get the "code" from redirect URI
            string authorizationCode = "<paste_code_here>"; // you need to capture this from the callback

            // 3️⃣ Exchange code for access token with DPoP
            string tokenEndpoint = "https://bsky.social/xrpc/com.atproto.server.createSession";
            string dpopJwt = DpopHelper.CreateDpopJwt("POST", tokenEndpoint, null, dpopKey);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tokenEndpoint);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("DPoP", dpopJwt);

            JObject postData = new JObject();
            postData["grant_type"] = "authorization_code";
            postData["code"] = authorizationCode;
            postData["redirect_uri"] = redirectUri;
            postData["client_id"] = clientId;
            postData["code_verifier"] = codeVerifier;

            byte[] postBytes = Encoding.UTF8.GetBytes(postData.ToString());
            request.ContentLength = postBytes.Length;

            using (Stream reqStream = request.GetRequestStream())
                reqStream.Write(postBytes, 0, postBytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                Console.WriteLine("Token Response: " + responseText);
            }
        }
    }
}
