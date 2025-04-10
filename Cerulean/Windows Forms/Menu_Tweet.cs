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
        }

        public void tweetButton_Click(object sender, EventArgs ev)
        {
            byte enableDS = 0;

            if (enableDSCheckBox.Checked)
            {
                enableDS = 1;
            }
            
            Global.skyWorker = new BackgroundWorker(); // initializes a BackgroundWorker to run the background method SkyBridge.tweet on new thread
                Global.skyWorker.DoWork += (s, e) => e.Result = SkyBridge.Tweet(tweetBox.Text, enableDS);
                Global.skyWorker.RunWorkerCompleted += (s, e) =>
                    {
                        MessageBox.Show("You have posted: \"" + (string)e.Result + "\" to Bluesky.");
                    };
                Global.skyWorker.RunWorkerAsync();
        }

        private void tweetBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void draftButton_Click(object sender, EventArgs e)
        {

        }
    }
}
