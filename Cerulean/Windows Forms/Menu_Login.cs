using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using SeasideResearch.LibCurlNet;


namespace Cerulean
{
    public partial class Menu_Login : Form
    {
        public Menu_Login()
        {
            //Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            MaximizeBox = false;            
        }

        private void Menu_Login_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            if (handleBox.Text == "" || passwordBox.Text == "") // Checks for empty handle/password field
            {
                header.Text = "Input Error";
                header.ForeColor = Color.Red;
                descriptor.Text = "Make sure that both the handle and password fields are filled.";
            }

            else
            {
                header.Text = "Connecting to PDS host";
                header.ForeColor = Color.Blue;
                descriptor.Text = "Cerulean is connecting to the specified PDS host. If authentication fails, check PDS settings and login details.";

                if (rememberMeBox.Checked)
                {
                     RegKit.write("\\LoginData", "handle", handleBox.Text);
                     RegKit.write("\\LoginData", "password", passwordBox.Text);                    
                }

                if (!rememberMeBox.Checked)
                {
                    RegKit.write("\\LoginData", "handle", "0");
                    RegKit.write("\\LoginData", "password", "0");     
                }
            }

        }

        private void setupTotpButton_Click(object sender, EventArgs e)
        {
            var mainmenu = new Menu_Main();
            mainmenu.Show();
                        
           /* MessageBox.Show("This feature will be added in a later version of Cerulean.\nNote that Bluesky does not support TOTP authentication, so " + 
                "until it does you can use Cerulean's own implenentation.\n\nRecommended TOTP programs are:\nKeePass 2, KeePassXC (Desktop)\nAuthy, Google Authenticator " +
                "(Mobile)\n\nTOTP authentication will only be available in the .NET Framework 4.6 build of Cerulean."); */
            
        }
        
       
        private void changePdsHostButton_Click(object sender, EventArgs e)
        {
            var pds = new Menu_ChangePDS();
            pds.Show();
            
        }

    }
}
