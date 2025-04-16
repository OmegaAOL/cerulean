using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using WindowsFormsAero;
using Cerulean.Windows_Forms;

namespace Cerulean
{
    public partial class Menu_Main : Form
    {
        public Menu_Main()
        {
            InitializeComponent();

            handleLabel.Text = Global.handle;
            statusLabel.Text = Global.connectionStatus;

            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_Main_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = quickPostButton;
        }

        private void menuItemOptions_Click(object sender, EventArgs e)
        {
            var optionsmenu = new Menu_Settings();
            optionsmenu.Show();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            var aboutmenu = new Menu_About();
            aboutmenu.Show();
        }

        private void menuItemTweet_Click(object sender, EventArgs e)
        {
            var tweet = new Menu_Tweet();
            tweet.Show();
        }

        private void quickPostButton_Click(object sender, EventArgs ev)
        {
            quickPostButton.Enabled = false;
            SkyBridge.SkyWorker(
                 (s, evt) => SkyBridge.QuickTweet(quickPostBox.Text),
                 (s, evt) => quickPostButton.Enabled = true
                );

        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search Bluesky")
            {
                searchBox.ForeColor = Color.Black;
                searchBox.Text = String.Empty;
            }
        }

        private void searchBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SkyBridge.SkyWorker(
                 (s, evt) => MessageBox.Show("SEARCH:\n\n" + SkyBridge.Search(searchBox.Text)),
                 (s, evt) => { }
                );
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            searchBox.ForeColor = Color.DarkGray;
            searchBox.Text = "Search Bluesky";
        }

        private void menuItemRefreshToken_Click(object sender, EventArgs e)
        {
            SkyBridge.StartTokenRefresher(false);
        }

        private void menuItemDM_Click(object sender, EventArgs e)
        {

        }

        private void menuItemReload_Click(object sender, EventArgs e)
        {
            var feedmenu = new Menu_FeedSelector();
            feedmenu.Show();
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            Global.token = String.Empty;
            Global.refreshToken = String.Empty;
            RegKit.write("\\LoginData", "handle", String.Empty);
            RegKit.write("\\LoginData", "password", String.Empty);
            SkyBridge.EndTokenRefresher();
            //Global.skyWorker.CancelAsync();
            var loginmenu = new Menu_Login(); // switches 
            this.Hide();
            loginmenu.Show();
        }

        private void Menu_Main_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuItemGotoGitRepo_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/OmegaAOL/cerulean");
        }

        private void menuItemGotoCeruleanCom_Click(object sender, EventArgs e)
        {
            Process.Start("http://ceruleanweb.neocities.org/");
        }

        private void menuItemBugGitFile_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/OmegaAOL/cerulean/issues/new");
        }

    }
}
