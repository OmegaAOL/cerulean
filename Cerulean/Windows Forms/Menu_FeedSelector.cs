using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cerulean.Windows_Forms
{
    public partial class Menu_FeedSelector : Form
    {
        public Menu_FeedSelector()
        {
            InitializeComponent();
        }

        private void Menu_FeedSelector_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = buttonFollowingFeed;
        }

        private void buttonFollowingFeed_Click(object sender, EventArgs e)
        {
            SkyBridge.SkyWorker(
                 (s, evt) => MessageBox.Show(SkyBridge.Timeline()),
                 (s, evt) => { }
                );
        }

        private void buttonCustomFeed_Click(object sender, EventArgs e)
        {
            string plc = plcBox.Text.Trim();
            string feed = feedBox.Text.Trim();
            SkyBridge.SkyWorker(
                 (s, evt) => MessageBox.Show(SkyBridge.Feed(plc, feed)),
                 (s, evt) => { }
                );
        }
    }
}
