/**********************************************************************************
By continuing to edit this solution or program source code, you accept the Cerulean
Terms of Service (found at http://ceruleanweb.neocities.org/legal/terms.txt)
***********************************************************************************/

using System;
using System.Windows.Forms;
using SeasideResearch.LibCurlNet;
using Cerulean.LangPacks;

namespace Cerulean
{
    static class Program
    {
        static void windowsOldWarning(bool checkResult)
        {
            if (!checkResult)
            {
                CeruleanBox.Display(LangPack.MSG_WIN9XWARNING);
            }
        }

        [STAThread]
        static void betaSettings()
        {
            if ((RegKit.Read.Dword("UserSettings", "FirstRun")) != 1)
            {
                CeruleanBox.Display(LangPack.MSG_FIRSTRUN_TERMS);
                RegKit.Write("\\API", "PDSHost", Global.defaultPDSHost);
                RegKit.Write("\\UserSettings", "DigitalSignature", String.Empty);
                RegKit.Write("\\UserSettings", "FirstRun", 1);
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
