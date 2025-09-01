using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            switch (infoType)
            {
                case 1:
                    return Environment.OSVersion.Platform.ToString();
                case 2:
                    return Environment.OSVersion.Version.ToString();
                case 3:
                    return Environment.OSVersion.ServicePack.ToString();
                case 4:
                    return Environment.OSVersion.VersionString;
                default:
                    return null;
            }
        }
    }

    public static class AeroChecker
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern bool DwmIsCompositionEnabled();

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int GetCurrentThemeName(
            [Out] System.Text.StringBuilder pszThemeFileName,
            int dwMaxNameChars,
            [Out] System.Text.StringBuilder pszColorBuff,
            int cchMaxColorChars,
            [Out] System.Text.StringBuilder pszSizeBuff,
            int cchMaxSizeChars);

        private static void NoAero()
        {
            CeruleanBox.Display("Your system does not have the Aero theme. Cerulean is Aero-first so it may not look as intended on your system.");
        }

        public static void IsAeroThemeActive()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                NoAero();
            }

            try
            {
                if (!DwmIsCompositionEnabled())
                {
                    NoAero();
                }

                var themeName = new System.Text.StringBuilder(260);
                var color = new System.Text.StringBuilder(260);
                var size = new System.Text.StringBuilder(260);
                GetCurrentThemeName(themeName, themeName.Capacity, color, color.Capacity, size, size.Capacity);

                if (!(themeName.ToString().ToLower().Contains("aero")))
                {
                    NoAero();
                }

            }
            catch
            {
                NoAero();
            }
        }
    }
}
