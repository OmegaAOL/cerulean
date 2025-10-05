using System;
using System.Diagnostics;
using System.Drawing;
using System.IO; // for debug
using System.Windows.Forms;
using Cerulean.LangPacks;
using Newtonsoft.Json.Linq;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_Main : Form
    {
        public Menu_Main()
        {
            InitializeComponent();

            NotificationFetcher();
            _debounceTimer = new Timer();
            _debounceTimer.Interval = 300; // 600 ms debounce delay
            _debounceTimer.Tick += DebounceTimer_Tick;

            searchBox.TextChanged += searchBox_TextChanged;
        }



        private void LocalizeControls()
        {
            this.Text = LangPack.MAIN_WINTITLE;
            handleLabel.Text = Variables.Handle;
            connStatusLabel.Text = Global.connectionStatus;
            BackgroundImage = ThemeDefinitions.Background;
            newPostButton.Text = LangPack.MAIN_TBUTTON_NEW_POST;
            newDmButton.Text = LangPack.MAIN_TBUTTON_NEW_DM;
            feedSelectorButton.Text = LangPack.MAIN_TBUTTON_SELECT_FEED;
            reauthButton.Text = LangPack.MAIN_TBUTTON_REAUTH;
            logoutButton.Text = LangPack.MAIN_TBUTTON_LOGOUT;
            searchBox.Text = LangPack.MAIN_SEARCHBOX_PLACEHOLDER;
            quickPostBox.Text = LangPack.MAIN_QTBOX_PLACEHOLDER;
            quickPostButton.Text = LangPack.MAIN_BUTTON_POST;
            notificationsButton.Text = LangPack.MAIN_TBUTTON_NOTIFICATIONS;
            tbTabControl.TabPages[0].Text = LangPack.MAIN_TABS_NO_CONTENT;
        }

        public static TabPage newTabButton, closeTabButton;

        private void Menu_Main_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControls();
            predictionBox.Height = 0;
            tbTabControl.TabPages.Add("newTabButton", LangPack.MAIN_TAB_NEW);
            tbTabControl.TabPages.Add("closeTabButton", LangPack.MAIN_TAB_CLOSE);
            newTabButton = tbTabControl.TabPages["newTabButton"];
            closeTabButton = tbTabControl.TabPages["closeTabButton"];
            quickPostButton.Enabled = false;
            LastSelectedTab = tbTabControl.SelectedTab;
        }

        private void tweetBoardHandler(JObject response, BorderPanel board = null)
        {
            if (board == null)
            {
                board = tweetBoard;
            }

            if (WEH.ErrHandler(response)[2] != "true")
            {
                if (!response.ContainsKey("feed"))
                    return;

                JArray tweetArray = (JArray)response["feed"];
                bool postsExist = false;
                foreach (JObject tweetPackage in tweetArray)
                {
                    JObject tweet = (JObject)tweetPackage["post"];
                    TweetControl t = new TweetControl();
                    t.LoadTweetContent(tweetPackage);
                    board.Controls.Add(t);
                    if (!postsExist)
                    {
                        postsExist = true;
                    }
                }
                if (!postsExist)
                {
                    tweetBoard.Controls.Add(makeLabel(LangPack.MAIN_TVIEW_NOPOSTS));
                }
            }
        }

        private void quickPostButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quickPostBox.Text))
            {
                string tweetContent = quickPostBox.Text;
                quickPostButton.Enabled = false;
                BarGo();
                if (RegKit.Read.Dword("UserSettings", "DSForQuickPost") == 1) // digital signature
                {
                    tweetContent += (" " + RegKit.Read.String("UserSettings", "DigitalSignature"));
                }
                Async.SkyWorker(
                    delegate { Tweet.Create(tweetContent); },
                    delegate { BarStop(); quickPostBox.Clear(); this.ActiveControl = tweetBoard; quickPostButton.Enabled = true; }
                );
            }
        }

        private void quickPostBox_Enter(object sender, EventArgs e)
        {
            if (quickPostBox.Text == LangPack.MAIN_QTBOX_PLACEHOLDER)
            {
                quickPostBox.ForeColor = ThemeDefinitions.Foreground;
                quickPostBox.Text = String.Empty;
            }
        }

        private void quickPostBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(quickPostBox.Text))
            {
                quickPostBox.ForeColor = Color.DarkGray;
                quickPostBox.Text = LangPack.MAIN_QTBOX_PLACEHOLDER;
                quickPostButton.Enabled = false;
            }
        }

        private void quickPostBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quickPostBox.Text))
            {
                quickPostButton.Enabled = true;
                this.AcceptButton = quickPostButton;
            }
            else
            {
                quickPostButton.Enabled = false;
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;

            if (searchBox.Text == LangPack.MAIN_SEARCHBOX_PLACEHOLDER)
            {
                searchBox.ForeColor = ThemeDefinitions.Foreground;
                searchBox.Text = String.Empty;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            Point mousePos = predictionBox.Parent.PointToClient(Cursor.Position);

            // If mouse is outside predictionBox, hide it
            if (!predictionBox.Bounds.Contains(mousePos))
            {
                if (String.IsNullOrEmpty(searchBox.Text))
                {
                    searchBox.ForeColor = Color.DarkGray;
                    searchBox.Text = LangPack.MAIN_SEARCHBOX_PLACEHOLDER;
                    predictionBox.Height = 0;
                }
            }
        }

        private void menuItemReload_Click(object sender, EventArgs e)
        {
            FetchFeed();
        }

        private void BarGo()
        {
            proBar.MarqueeAnimationSpeed = 10;
        }

        private void BarStop()
        {
            proBar.MarqueeAnimationSpeed = 0;
            proBar.Invalidate();
        }

        private Label makeLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.ForeColor = System.Drawing.Color.Red;
            label.Location = new System.Drawing.Point(20, 20);
            return label;
        }

        public void FetchFeed(bool inNewTab = false)
        {
            Menu_FeedSelector fs = new Menu_FeedSelector();
            if (fs.ShowDialog() == DialogResult.OK)
            {
                if (!inNewTab) { tweetBoard.Controls.Clear(); }
                JObject response = new JObject();
                BarGo();

                Async.SkyWorker(
                delegate
                {
                    if (fs.SelectedTimeline) { response = Feeds.Load.Timeline(); }
                    else { response = Feeds.Load.Custom(fs.SelectedFeedUri); }
                },
                delegate
                {
                    if (inNewTab)
                    {
                        TabPage newTab = new TabPage(fs.SelectedFeedName);

                        BorderPanel newTweetBoard = new BorderPanel();
                        newTweetBoard.AutoScroll = true;
                        newTweetBoard.AutoScrollMargin = new System.Drawing.Size(0, 1);
                        newTweetBoard.AutoSize = true;
                        newTweetBoard.BackgroundImage = CeruleanArt.bdStripes;
                        newTweetBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
                        newTweetBoard.Dock = System.Windows.Forms.DockStyle.Fill;
                        newTweetBoard.Location = new System.Drawing.Point(3, 3);
                        newTweetBoard.Margin = new System.Windows.Forms.Padding(0);
                        newTweetBoard.Name = "newTweetBoard";
                        newTweetBoard.Size = new System.Drawing.Size(1033, 557);
                        newTweetBoard.TabIndex = 10;
                        newTweetBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);

                        newTab.Controls.Add(newTweetBoard);

                        int insertIndex = tbTabControl.TabPages.IndexOf(newTabButton);
                        tbTabControl.TabPages.Insert(insertIndex, newTab);

                        tbTabControl.SelectedTab = newTab;

                        tweetBoardHandler(response, newTweetBoard);
                    }
                    else
                    {
                        tbTabControl.TabPages[tbTabControl.SelectedIndex].Text = fs.SelectedFeedName;
                        tweetBoardHandler(response);
                    }

                    BarStop();
                }
       );
            }
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            Variables.Token = String.Empty;
            Variables.RefreshToken = String.Empty;
            RegKit.Write("\\LoginData", "handle", String.Empty);
            RegKit.Write("\\LoginData", "password", String.Empty);
            RegKit.Write("\\LoginData", "CredentialsEncrypted", 0);

            Auth.Refresher.End();

            Menu_Login loginmenu = new Menu_Login();
            this.Hide();
            loginmenu.Show();
        }

        private void menuItemOptions_Click(object sender, EventArgs e)
        {
            new Menu_Settings().ShowDialog();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new Menu_About().ShowDialog();
        }

        private void menuItemTweet_Click(object sender, EventArgs e)
        {
            new Menu_Tweet(Tweet.Type.Normal).ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemRefreshToken_Click(object sender, EventArgs e)
        {
            Auth.Refresher.Start(Auth.Refresher.Mode.Manual);
        }

        private void menuItemDM_Click(object sender, EventArgs e)
        {
            Global.featureAbsent(LangPack.MAIN_CBOX_ABSENT_DM);
        }

        private void menuItemGotoGitRepo_Click(object sender, EventArgs e)
        {
            Process.Start(WebResources.REPOSITORY);
        }

        private void menuItemGotoCeruleanCom_Click(object sender, EventArgs e)
        {
            Process.Start(WebResources.HOMEPAGE);
        }

        private void menuItemBugGitFile_Click(object sender, EventArgs e)
        {
            Process.Start((WebResources.REPOSITORY + WebResources.GIT_ERROR_PATH));
        }

        private void Menu_Main_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private Timer _debounceTimer;
        private string _lastInput;

        private void searchBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new Menu_Profile(predictionBox.Items[0].ToString()).Show();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text != String.Empty && searchBox.Text != LangPack.MAIN_SEARCHBOX_PLACEHOLDER)
            {
                // Reset the timer every time text changes
                _debounceTimer.Stop();
                _debounceTimer.Start();

                // Save the latest input
                _lastInput = searchBox.Text;
            }

            else
                predictionBox.Height = 0;

        }

        public static JObject predictionResponse;
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            _debounceTimer.Stop();

            // Only search if text hasn't changed since timer started
            if (searchBox.Text == _lastInput && !string.IsNullOrEmpty(_lastInput))
            {

                predictionBox.Items.Clear();
                predictionBox.Height = 15;
                predictionBox.Items.Add(LangPack.MAIN_SEARCHLIST_SEARCHING);
                predictionBox.Visible = true;

                Async.SkyWorker(
                    delegate { predictionResponse = Account.Search.Typeahead(_lastInput); },
                    delegate
                    {
                        if (predictionBox.Items.Count != 1)
                        {
                            predictionBox.Items.Clear();
                            predictionBox.Visible = false;
                        }

                        if (predictionResponse != null && WEH.ErrHandler(predictionResponse)[2] != "true")
                        {

                            try
                            {
                                predictionBox.Items.Clear();
                                if (predictionResponse["actors"].ToString() != "[]")
                                {
                                    foreach (JObject prediction in (JArray)(predictionResponse["actors"]))
                                    {
                                        predictionBox.Items.Add(prediction["handle"].ToString());
                                    }
                                    predictionBox.Height = (predictionBox.Items.Count * predictionBox.ItemHeight) + 2;
                                    predictionBox.Visible = true;
                                }
                                else
                                {
                                    predictionBox.Items.Add(LangPack.MAIN_SEARCHLIST_NORESULT);
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                        else
                        {
                            predictionBox.Items.Clear();
                            predictionBox.Items.Add(LangPack.MAIN_SEARCHLIST_FAILED);
                        }
                    }
                );
            }
        }

        private void Menu_Main_Shown(object sender, EventArgs e)
        {
            FetchFeed();
        }

        private void notificationsButton_Click(object sender, EventArgs e)
        {
            NotificationFetcher();
        }

        private void NotificationFetcher()
        {
            mainTree.Nodes.Clear();
            mainTree.Nodes.Add("Fetching information...");
            JArray notifications = new JArray();
            Async.SkyWorker(
                delegate { notifications = Notifications.Fetch(); },
                delegate
                {
                    if (notifications != null)
                    {
                        mainTree.Nodes.Clear();
                        TreeNode parent = mainTree.Nodes.Add("Notifications");
                        //parent.Nodes.Clear();
                        foreach (JObject notification in notifications)
                        {
                            string text = notification.SelectToken("reason").ToString() + " by " + notification.SelectToken("author.handle").ToString();
                            parent.Nodes.Add(text);
                        }
                        parent.ExpandAll();
                        
                    }
                    ChatListFetcher();
                }
            );
        }

        private void ChatListFetcher()
        {
            JArray chats = new JArray();
            Async.SkyWorker(
                delegate { chats = Chats.ListConversations(); },
                delegate
                {
                    if (chats != null)
                    {
                        TreeNode parent = mainTree.Nodes.Add("Chats");
                        //parent.Nodes.Clear();
                        foreach (JObject chat in chats)
                        {
                            string text = "with " + chat["members"][0]["handle"].ToString();
                            /*foreach (JObject member in (JArray)chat["members"])
                            {
                                text = text + member["handle"].ToString() + " with ";
                            }*/
                            parent.Nodes.Add(text);
                        }
                        parent.ExpandAll();
                    }
                    FollowerFetcher();
                }
            );
        }

        private void FollowerFetcher()
        {
            JArray followers = new JArray();
            Async.SkyWorker(

                delegate { followers = Account.FetchData.Followers(Variables.Handle); },
                delegate
                {
                    if (followers != null)
                    {
                        TreeNode parent = mainTree.Nodes.Add("Followers");
                        //parent.Nodes.Clear();

                        foreach (JObject follower in followers)
                        {
                            parent.Nodes.Add(follower["handle"].ToString());
                        }
                        parent.ExpandAll();

                        mainTree.SelectedNode = null;
                        if (mainTree.Nodes.Count > 0)
                        {
                            mainTree.TopNode = mainTree.Nodes[0];
                        }
                    }
                }
            );
        }

        private void predictionBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_Click(object sender, EventArgs e)
        {
            new Menu_Profile(predictionBox.SelectedItem.ToString()).Show();
        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void tb_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbc_Add(object sender, ControlEventArgs e)
        {
            //LastAlignNewTabButton();
        }

        private void tbc_Remove(object sender, ControlEventArgs e)
        {
            //LastAlignNewTabButton();
        }

        private void LastAlignNewTabButton()
        {
            bool locks = false;
            if (newTabButton != null && locks == false)
            {
                locks = true;
                tbTabControl.TabPages.Remove(newTabButton);
                tbTabControl.TabPages.Add(newTabButton);

            }
            locks = false;
        }

        private TabPage LastSelectedTab;

        private void tbTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "newTabButton":
                    e.Cancel = true;
                    FetchFeed(true);
                    break;
                case "closeTabButton":
                    e.Cancel = true;
                    if (LastSelectedTab != null &&
        tbTabControl.TabPages.Count > 3)
                    {
                        int index = tbTabControl.TabPages.IndexOf(LastSelectedTab);
                        tbTabControl.TabPages.Remove(LastSelectedTab);
                        LastSelectedTab.Dispose();
                        if (index > 0) { index--; }
                        tbTabControl.SelectedIndex = 0;
                    }
                    break;
                default:
                    LastSelectedTab = tbTabControl.SelectedTab;
                    break;
            }

        }

    }
}
