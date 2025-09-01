using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Cerulean
{
    public partial class Menu_CreateAccount : Form
    {
        public Menu_CreateAccount()
        {
            InitializeComponent();
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
            Process.Start(Global.bskyTosUrl);
        }
    }
}
