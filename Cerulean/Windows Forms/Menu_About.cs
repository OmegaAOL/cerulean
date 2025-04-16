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
            this.AcceptButton = postAbtCerulean;
        }

        private void followOmegaButton_Click(object sender, EventArgs e)
        {
            followOmegaButton.Enabled = false;
            MessageBox.Show("Not implemented");
        }

        private void postAbtCerulean_Click(object sender, EventArgs ev)
        {
            SkyBridge.SkyWorker(
                (s, evt) => SkyBridge.Tweet("I use Cerulean, a Bluesky client for Windows 98 - 11. Try it at github.com/OmegaAOL/cerulean"),
                (s, evt) =>
                {
                    postAbtCerulean.Enabled = true;
                    MessageBox.Show("Thank you!");
                }
            );

        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            donateButton.Enabled = false;
            MessageBox.Show("Not implemented");
        }
    }
}
