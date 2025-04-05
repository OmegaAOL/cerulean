using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cerulean
{
    public partial class Menu_Settings : Form
    {
        public Menu_Settings()
        {
            InitializeComponent();
        }

        private void Menu_Settings_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Cerulean\Menu_LoginData"))
            {
                key.SetValue("handle", "0");
                key.SetValue("password", "0");


            }

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Cerulean\API"))
            {
                key.SetValue("PDSHost", "https://bsky.social");
                key.SetValue("betaSetting_firstRun", "complete");

            }
            regInstallUpdate.Text = "Registry reset";
            regInstallUpdate.ForeColor = Color.Green;
        }
    }
}
