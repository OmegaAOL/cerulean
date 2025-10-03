using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_FeedSelector : Form
    {
        public static Menu_FeedSelector Instance;

        public Menu_FeedSelector()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Menu_FeedSelector_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControls();
            timelineButton.Enabled = false;
            selectFeedButton.Enabled = false;
            this.AcceptButton = timelineButton;
            BackgroundImage = ThemeDefinitions.Background;

            InitFeedList();

            JObject response = new JObject();
            Async.SkyWorker(
                delegate { response = Feeds.GetRecommendations(); },
                delegate
                {
                    timelineButton.Enabled = true;
                    if (WEH.ErrHandler(response)[2] != "true")
                    {
                        selectFeedButton.Enabled = true;
                        JArray feedArray = (JArray)response["feeds"];
                        foreach (JObject feed in feedArray)
                        {
                            string name = feed["displayName"] != null ? feed["displayName"].ToString() : LangPack.FEEDSEL_LIST_NO_NAME;
                            string desc = feed["description"] != null ? feed["description"].ToString() : String.Empty;
                            string uri = feed["uri"] != null ? feed["uri"].ToString() : String.Empty;
                            AddFeedItem(name, desc, uri);
                        }

                        feedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        feedList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                        progressBar1.MarqueeAnimationSpeed = 0;
                        progressBar1.Invalidate();
                    }
                });
        }
        private void LocalizeControls()
        {
            this.Text = LangPack.FEEDSEL_WINTITLE;
            description.Text = LangPack.FEEDSEL_LABEL_DESCRIPTION;

        }

        private void buttonFollowingFeed_Click(object sender, EventArgs e)
        {
            Menu_Main.Instance.FetchFeed(true);
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Search logic
        }

        private void InitFeedList()
        {
            feedList.View = View.Details;
            feedList.FullRowSelect = true;
            feedList.GridLines = true;
            feedList.MultiSelect = false;
            feedList.Columns.Clear();

            feedList.Columns.Add(LangPack.FEEDSEL_LIST_FEED, 150);
            feedList.Columns.Add(LangPack.FEEDSEL_LIST_DESCRIPTION, 1000);

            feedList.Scrollable = true;
        }

        private void AddFeedItem(string feed, string description, string atUri)
        {
            ListViewItem item = new ListViewItem(feed != null ? feed : String.Empty);
            item.SubItems.Add(description != null ? description : String.Empty);
            item.Tag = atUri != null ? atUri : String.Empty;
            feedList.Items.Add(item);
        }

        private void FetchButton_Click(object sender, EventArgs e)
        {
            if (feedList.SelectedItems.Count <= 0)
            {
                CeruleanBox.Display(LangPack.FEEDSEL_CBOX_SELECTFEED);
                return;
            }

            this.Hide();

            ListViewItem selectedItem = feedList.SelectedItems[0];
            string atUri = selectedItem.Tag.ToString();

            Menu_Main.Instance.FetchFeed(false, atUri.Trim());
        }

        private void feedList_DoubleClick(object sender, EventArgs e)
        {
            FetchButton_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
