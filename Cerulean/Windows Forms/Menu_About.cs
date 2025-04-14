using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cerulean
{
    public partial class Menu_About : Form
    {
        public Menu_About()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_About_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void followOmegaButton_Click(object sender, EventArgs e)
        {

        }

        private void postAbtCerulean_Click(object sender, EventArgs ev)
        {
            Global.skyWorker = new BackgroundWorker(); // initializes a BackgroundWorker to run the background method SkyBridge.tweet on new thread
            Global.skyWorker.DoWork += (s, e) => SkyBridge.Tweet("I use Cerulean, a Bluesky client for Windows 98 - 11. Try it at github.com/OmegaAOL/cerulean");
            Global.skyWorker.RunWorkerAsync();
            MessageBox.Show("Thank you!");
        }
    }
}
