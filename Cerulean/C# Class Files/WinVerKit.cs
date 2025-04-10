using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Cerulean
{
    public static class WinVerKit // WinVerKit, OmegaAOL. Gets varying Windows version information, including if system is 2000+ or Legacy.
    {
        public static bool windowsNT5PlusChecker()
        {
            OperatingSystem os = Environment.OSVersion;
            return os.Platform == PlatformID.Win32NT && os.Version.Major >= 5;
        }

        public static string winVersion(byte infoType)
        {
            if (infoType == 1)
            {
                return Environment.OSVersion.Platform.ToString();
            }

            if (infoType == 2)
            {
                return Environment.OSVersion.Version.ToString();
            }

            if (infoType == 3)
            {
                return Environment.OSVersion.ServicePack.ToString();
            }

            if (infoType == 4)
            {
                return Environment.OSVersion.VersionString;
            }

            else
            {
                return null;
            }
        }
    }
}
