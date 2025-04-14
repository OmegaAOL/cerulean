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

        public void tweetButton_Click(object sender, EventArgs ev)
        {
            if (enableDSCheckBox.Checked)
            {
                RegKit.write("\\UserSettings", "DSForComposer", 1);
            }

            else
            {
                RegKit.write("\\UserSettings", "DSForComposer", 0);
            }
                 
            Global.skyWorker = new BackgroundWorker(); // initializes a BackgroundWorker to run the background method SkyBridge.tweet on new thread
            Global.skyWorker.DoWork += (s, e) => e.Result = SkyBridge.Tweet(tweetBox.Text);
            Global.skyWorker.RunWorkerCompleted += (s, e) =>
            {
                MessageBox.Show("You have posted: \"" + (string)e.Result + "\" to Bluesky.");
            };
            Global.skyWorker.RunWorkerAsync();
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
