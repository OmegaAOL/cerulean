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
            dsBox.Text = RegKit.read("\\UserSettings", "DigitalSignature");
        }

        private void Menu_Settings_Load(object sender, EventArgs e)
        {
            CenterToParent();            
        }

        private void regInstallButton_Click(object sender, EventArgs e) // rewrites all known registry values set by Cerulean
        {      
            RegKit.write("\\LoginData", "handle", String.Empty);
            RegKit.write("\\LoginData", "password", String.Empty);
            RegKit.write("\\API", "PDSHost", Global.defaultPDSHost);
            RegKit.write("\\API", "betaSetting_firstRun", "complete");
            RegKit.write("\\UserSettings", "DigitalSignature", String.Empty);
            RegKit.write("\\UserSettings", "DSForQuickPost", 0);
            RegKit.write("\\UserSettings", "DSForComposer", 0);

            regInstallUpdate.Text = "Registry reset";
            regInstallUpdate.ForeColor = Color.Green;
        }


        private void dsApplyButton_Click(object sender, EventArgs e)
        {
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
            RegKit.write("\\UserSettings", "DigitalSignature", String.Empty);
            RegKit.write("\\UserSettings", "DSForQuickPost", 0);
            dsBox.Text = RegKit.read("\\UserSettings", "DigitalSignature");
            dsLabel.Text = "Digital Signature settings reset";
            dsLabel.ForeColor = Color.Blue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
