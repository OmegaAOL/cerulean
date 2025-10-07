using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Cerulean.LangPacks;
using System.Diagnostics;
using OmegaAOL.SkyBridge;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cerulean
{
    public partial class Menu_CreateAccount : Form
    {
        private string barePds = Variables.PDSHost.Replace("https://", "").Replace("http://", "");
        public Menu_CreateAccount()
        {
            InitializeComponent();
            handleBox.Text = LangPack.GLOBAL_EXAMPLE + "." + barePds;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Menu_CreateAccount_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void viewTOSButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(WebResources.TERMS_BLUESKY);
        }

        private void tosBox_ToggleCheck(object sender, EventArgs e)
        {
            if (tosBox.Checked && !String.IsNullOrEmpty(handleBox.Text))
                createButton.Enabled = true;
            else
                createButton.Enabled = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createButton.Enabled = false;
            JObject response = new JObject();
            Async.SkyWorker(
                 delegate { response = Account.Create(handleBox.Text, emailBox.Text, passwordBox.Text, phoneBox.Text, usernameBox.Text, bioBox.Text, invoteCodeBox.Text); },
                 delegate 
                 {
                     createButton.Enabled = true;
                     if (response.ContainsKey("error"))
                     {
                         CeruleanBox.Display(response.SelectToken("message").ToString());
                     }
                     else
                     {
                         CeruleanBox.Display(LangPack.CREATEACCOUNT_SUCCESS + " " + barePds);
                     }
                 }
                );
        }
    }
}
