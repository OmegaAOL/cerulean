/**********************************************************************************
By continuing to edit this solution or program source code, you accept the Cerulean
Terms of Service (found at http://ceruleanweb.neocities.org/legal/terms.txt)
***********************************************************************************/

using System;
using System.Windows.Forms;
using SeasideResearch.LibCurlNet;

namespace Cerulean
{
    static class Program
    {
        static void windowsOldWarning(bool checkResult)
        {
            if (!checkResult)
            {
                CeruleanBox.Display("You are running a 'legacy kernel' version of Windows (9x/ME/NT4). This comes with a few caveats:\n\n" +
                "1: Fonts will probably not display properly as Microsoft Sans Serif is not installed by default on your system.\n\n2: The encryption used to save " +
                "your handle and password is the legacy CeruleanCrypt method, and not DPAPI. This is less secure.\n\n3: Generally expect some things to be broken.");
            }
        }

        [STAThread]
        static void betaSettings()
        {
            if ((RegKit.Read("\\UserSettings", "FirstRun")) != "complete")
            {
                CeruleanBox.Display("Further use of this program assumes that you have read and agree to the Cerulean Terms (https://ceruleanweb.neocities.org/legal/terms.html).");
                RegKit.Write("\\API", "PDSHost", Global.defaultPDSHost);
                RegKit.Write("\\UserSettings", "DigitalSignature", String.Empty);
                RegKit.Write("\\UserSettings", "FirstRun", "complete");
            }

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            betaSettings();
            AeroChecker.IsAeroThemeActive();
            windowsOldWarning(WinVerKit.windowsNT5PlusChecker());

            //try
            //{
            
            Application.Run(new Menu_Login());
            //}
            // catch (Exception ex)
            //{
            //    CeruleanBox.Display(ex.Message);
            //}
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // Clean up cURL ONCE, right before the application closes.
            Curl.GlobalCleanup();
        }
    }
}
