using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cerulean
{
    public partial class Menu_Settings : Form
    {
        public Menu_Settings()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_Settings_Load(object sender, EventArgs e)
        {
            CenterToParent();
            dsBox.Text = RegKit.read("\\UserSettings", "DigitalSignature");
        }

        private void regInstallButton_Click(object sender, EventArgs e)
        {      
            RegKit.write("\\LoginData", "handle", "");
            RegKit.write("\\LoginData", "password", "");
            RegKit.write("\\API", "PDSHost", Global.defaultPDSHost);
            RegKit.write("\\API", "betaSetting_firstRun", "complete");
            RegKit.write("\\UserSettings", "DigitalSignature", "");
            RegKit.write("\\UserSettings", "DSForQuickPost", 0);

            regInstallUpdate.Text = "Registry reset";
            regInstallUpdate.ForeColor = Color.Green;
        }


        private void dsApplyButton_Click(object sender, EventArgs e)
        {
            RegKit.read("\\UserSettings", "DigitalSignature");
            RegKit.write("\\UserSettings", "DigitalSignature", dsBox.Text);
            RegKit.write("\\UserSettings", "DSForQuickPost", 0);

            if (dsUseForQuickPost.Checked)
            {
                RegKit.write("\\UserSettings", "DSForQuickPost", 1);
            }

            dsBox.Text = RegKit.read("\\UserSettings", "DigitalSignature");
            dsLabel.Text = "Digital Signature saved";
            dsLabel.ForeColor = Color.Green;    
        }

        private void dsResetButton_Click(object sender, EventArgs e)
        {
            RegKit.write("\\UserSettings", "DigitalSignature", "");
            RegKit.write("\\UserSettings", "DSForQuickPost", 0);
            dsBox.Text = RegKit.read("\\UserSettings", "DigitalSignature");
            dsLabel.Text = "Digital Signature settings reset";
            dsLabel.ForeColor = Color.Blue;
        }

    }
}
