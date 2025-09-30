/**********************************************************************************
By continuing to edit this solution or program source code, you accept the Cerulean
Terms of Service (found at http://ceruleanweb.neocities.org/legal/terms.txt)
***********************************************************************************/

using System;
using System.Windows.Forms;
using System.Threading;
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
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException); // for global error catching/handling
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

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

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowError(e.Exception);
            MessageBox.Show("An unexpected error occurred: " + e.Exception.Message);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowError((Exception)e.ExceptionObject);
            MessageBox.Show("Fatal error: " + ((Exception)e.ExceptionObject).Message);
        }

        private static void ShowError(Exception ex) 
        {
            CeruleanBox.Display(LangPack.GLOBAL_ERROR_MESSAGE + "\n\n" + "(" + ex.ToString() + ")");
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // Clean up cURL ONCE, right before the application closes.
            Curl.GlobalCleanup();
        }
    }
}
