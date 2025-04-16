using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace Cerulean
{
    static class Program
    {
        static void windowsOldWarning(bool checkResult)
        {
            if (!checkResult)
            {
                MessageBox.Show("You are running a version of Windows that did not ship with the TrueType font Microsoft " +
                    "Sans Serif. The system will default to another font for some cases, most likely Tahoma, and certain " +
                    "text-related items will be misaligned and may not be usable.\n\nTo fix the issue, download and place 'micross.ttf' in the " +
                    "C:\\WINDOWS\\FONTS folder. You may still see some Tahoma, but it's not in the places where it was misaligned.\n\nWhen the Cerulean " +
                    "Installer is released, this will no longer be necessary.");
            }
        }

        [STAThread]
        static void betaSettings()
        {
            if ((RegKit.read("\\API", "betaSetting_firstRun")) != "complete")
            {
                RegKit.write("\\API", "PDSHost", Global.defaultPDSHost);
                RegKit.write("\\API", "betaSetting_firstRun", "complete");
            }

        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            betaSettings();
            AeroChecker.IsAeroThemeActive();
            windowsOldWarning(WinVerKit.windowsNT5PlusChecker());

            Application.Run(new Menu_Login());
        }
    }
}
