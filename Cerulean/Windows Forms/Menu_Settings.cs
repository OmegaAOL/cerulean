using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cerulean
{
    public partial class Menu_Settings : Form
    {
        /* ===== Constants ===== */
        private const string LABEL_DS_SAVED = "Digital Signature saved";
        private const string LABEL_DS_RESET = "Digital Signature reset to default";

        public Menu_Settings()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
            dsBox.Text = RegKit.Read("\\UserSettings", "DigitalSignature");
        }

        private void Menu_Settings_Load(object sender, EventArgs e)
        {
            CenterToParent();
            BackgroundImage = Global.bgImage;
        }

        private void regInstallButton_Click(object sender, EventArgs e) // rewrites all known registry values set by Cerulean
        {
            RegKit.Write("\\LoginData", "handle", String.Empty);
            RegKit.Write("\\LoginData", "password", String.Empty);
            RegKit.Write("\\API", "PDSHost", Global.defaultPDSHost);
            RegKit.Write("\\API", "FirstRun", "complete");
            RegKit.Write("\\UserSettings", "DigitalSignature", String.Empty);
            RegKit.Write("\\UserSettings", "DSForQuickPost", 0);
            RegKit.Write("\\UserSettings", "DSForComposer", 0);

            regInstallUpdate.Text = "Registry reset";
            regInstallUpdate.ForeColor = Color.Green;
        }


        private void dsApplyButton_Click(object sender, EventArgs e)
        {
            RegKit.Write("\\UserSettings", "DigitalSignature", dsBox.Text);
            RegKit.Write("\\UserSettings", "DSForQuickPost", 0);

            if (dsUseForQuickPost.Checked)
            {
                RegKit.Write("\\UserSettings", "DSForQuickPost", 1);
            }

            dsBox.Text = RegKit.Read("\\UserSettings", "DigitalSignature");
            dsLabel.Text = LABEL_DS_SAVED;
            dsLabel.ForeColor = Color.Green;
        }

        private void dsResetButton_Click(object sender, EventArgs e)
        {
            RegKit.Write("\\UserSettings", "DigitalSignature", String.Empty);
            RegKit.Write("\\UserSettings", "DSForQuickPost", 0);
            dsBox.Text = RegKit.Read("\\UserSettings", "DigitalSignature");
            dsLabel.Text = LABEL_DS_RESET;
            dsLabel.ForeColor = Color.Blue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
