using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using WindowsFormsAero;

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

            Global.skyWorker = new BackgroundWorker(); // initializes a BackgroundWorker to run the background method SkyBridge.tweet on thread skythread
            Global.skyWorker.DoWork += (s, e) => SkyBridge.QuickTweet(quickPostBox.Text);
            Global.skyWorker.RunWorkerAsync();

        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search Bluesky"){
                searchBox.ForeColor = Color.Black;
                searchBox.Text = String.Empty;
            }
        }

        private void searchBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Global.skyWorker = new BackgroundWorker(); // initializes a BackgroundWorker to run the background method SkyBridge.tweet on thread skythread
                Global.skyWorker.DoWork += (s, ev) => MessageBox.Show("SEARCH:\n\n" + SkyBridge.Search(searchBox.Text));
                Global.skyWorker.RunWorkerAsync(); 
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

        }

        private void menuItemLock_Click(object sender, EventArgs e)
        {

        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Main_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
