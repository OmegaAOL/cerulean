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
    public partial class Menu_ChangePDS : Form // Updated to use RegKit.regReader
    {                                          
        

        public Menu_ChangePDS()
        {
            InitializeComponent();
        }

        private void Menu_ChangePDS_Load(object sender, EventArgs e)
        {
            CenterToParent();
            pdshostbox.Text = RegKit.read("\\API", "PDSHost");
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            RegKit.write("\\API", "PDSHost", pdshostbox.Text);
            settingsLabel.Text = "Custom PDS host saved";
            settingsLabel.ForeColor = Color.Green;           
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            RegKit.write("\\API", "PDSHost", "https://bsky.social");
            settingsLabel.Text = "PDS host reset to default";
            pdshostbox.Text = RegKit.read("\\API", "PDSHost");
            settingsLabel.ForeColor = Color.Blue;
        }              
    }
}
