using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using Cerulean.LangPacks;

namespace Cerulean
{
    public partial class Menu_Settings : Form
    {
        private string latestVersionFetched = LangPack.GLOBAL_UNKNOWN;

        public Menu_Settings()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
            dsBox.Text = RegKit.Read.String("UserSettings", "DigitalSignature");
            updateCheckButton.Text = LangPack.SETTINGS_BUTTON_CHECK_UPDATES;
            this.Text = LangPack.SETTINGS_WINTITLE;
            currentVersion.Text = LangPack.SETTINGS_LABEL_VERSION_CURRENT + " " + Global.version;
            latestVersion.Text = LangPack.SETTINGS_LABEL_VERSION_LATEST + " " + latestVersionFetched;
            updatesPage.Text = LangPack.SETTINGS_PAGE_UPDATES;
            dsPage.Text = LangPack.SETTINGS_PAGE_DS;
            themePage.Text = LangPack.SETTINGS_PAGE_THEME;
        }

        private void Menu_Settings_Load(object sender, EventArgs e)
        {
            CenterToParent();
            BackgroundImage = Global.bgImage;
        }

        private void dsApplyButton_Click(object sender, EventArgs e)
        {
            RegKit.Write("\\UserSettings", "DigitalSignature", dsBox.Text);
            RegKit.Write("\\UserSettings", "DSForQuickPost", 0);

            if (dsUseForQuickPost.Checked)
            {
                RegKit.Write("\\UserSettings", "DSForQuickPost", 1);
            }

            dsBox.Text = RegKit.Read.String("UserSettings", "DigitalSignature");
            dsLabel.Text = LangPack.SETTINGS_LABEL_DS_SAVED;
            dsLabel.ForeColor = Color.Green;
        }

        private void dsResetButton_Click(object sender, EventArgs e)
        {
            RegKit.Write("\\UserSettings", "DigitalSignature", String.Empty);
            RegKit.Write("\\UserSettings", "DSForQuickPost", 0);
            dsBox.Text = RegKit.Read.String("UserSettings", "DigitalSignature");
            dsLabel.Text = LangPack.SETTINGS_LABEL_DS_RESET;
            dsLabel.ForeColor = Color.Blue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dsUseForQuickPost_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
