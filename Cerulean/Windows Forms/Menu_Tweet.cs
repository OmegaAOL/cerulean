using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cerulean
{
    public partial class Menu_Tweet : Form
    {
        public Menu_Tweet()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;

            if (byte.Parse(RegKit.read("\\UserSettings", "DSForComposer")) == 0)
            {
                enableDSCheckBox.Checked = false;
            }
            else if (byte.Parse(RegKit.read("\\UserSettings", "DSForComposer")) == 1)
            {
                enableDSCheckBox.Checked = true;
            }
        }

        private void Menu_Tweet_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = tweetButton;
        }

        public void tweetButton_Click(object sender, EventArgs ev)
        {
            tweetButton.Enabled = false;
            if (enableDSCheckBox.Checked)
            {
                RegKit.write("\\UserSettings", "DSForComposer", 1);
            }

            else
            {
                RegKit.write("\\UserSettings", "DSForComposer", 0);
            }

            SkyBridge.SkyWorker(
                (s, evt) =>
                {
                    SkyBridge.Tweet(tweetBox.Text);
                },
                (s, evt) =>
                {
                    tweetButton.Enabled = true;
                }
            );
        }

        private void draftButton_Click(object sender, EventArgs e)
        {

        }

        private void mediaUploadButton_Click(object sender, EventArgs e)
        {

        }

        private void tweetBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
