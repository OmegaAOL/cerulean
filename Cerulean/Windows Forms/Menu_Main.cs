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
        public static Menu_Main Instance { get; private set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        public Menu_Main()
        {
            InitializeComponent();
            EnableDoubleBuffer(tweetBoard);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            Instance = this;
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
            BackgroundImage = Global.bgImage;
            newPostButton.Text = LangPack.MAIN_TBUTTON_NEW_POST;
            newDmButton.Text = LangPack.MAIN_TBUTTON_NEW_DM;
            feedSelectorButton.Text = LangPack.MAIN_TBUTTON_SELECT_FEED;
            reauthButton.Text = LangPack.MAIN_TBUTTON_REAUTH;
            logoutButton.Text = LangPack.MAIN_TBUTTON_LOGOUT;
            searchBox.Text = LangPack.MAIN_SEARCHBOX_PLACEHOLDER;
            quickPostBox.Text = LangPack.MAIN_QTBOX_PLACEHOLDER;
            quickPostButton.Text = LangPack.MAIN_BUTTON_POST;
            notificationsButton.Text = LangPack.MAIN_TBUTTON_NOTIFICATIONS;
        }

        private void Menu_Main_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControls();
            predictionBox.Height = 0;

            quickPostButton.Enabled = false;
            //NotificationFetcher();


            //mainTree.Nodes.


            /*JObject response = new JObject();
            BarGo();

            SkyBridge.SkyWorker(
                delegate { response = SkyBridge.Timeline(); },
                delegate
                {
                    tweetBoardHandler(response);
                    BarStop();
                    statusLabel.Text = "Connected";
                }
             * 
             * 
            );*/
        }

        private void tweetBoardHandler(JObject response)
        {
            //File.WriteAllText("feedDebug.txt", response.ToString()); // debug

            if (WEH.ErrHandler(response)[2] != "true")
            {
                if (!response.ContainsKey("feed"))
                    return;

                JArray tweetArray = (JArray)response["feed"];
                foreach (JObject tweetPackage in tweetArray)
                {
                    JObject tweet = (JObject)tweetPackage["post"];
                    TweetControl t = new TweetControl();
                    t.LoadTweetContent(tweetPackage);
                    tweetBoard.Controls.Add(t);
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
                quickPostBox.ForeColor = Color.Black;
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
                searchBox.ForeColor = Color.Black;
                searchBox.Text = String.Empty;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {

            searchBox.ForeColor = Color.DarkGray;
            searchBox.Text = LangPack.MAIN_SEARCHBOX_PLACEHOLDER;
        }



        private void menuItemReload_Click(object sender, EventArgs e)
        {
            new Menu_FeedSelector().ShowDialog();
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

        public void FetchFeed(bool timeline, string uri = null)
        {
            Menu_FeedSelector.Instance.Close();
            tweetBoard.Controls.Clear();
            JObject response = new JObject();
            BarGo();

            if (timeline)
            {
                Async.SkyWorker(
                delegate { response = Feeds.Load.Timeline(); },
                delegate
                {
                    tweetBoardHandler(response);
                    BarStop();
                }
            );
            }

            else
            {
                Async.SkyWorker(
                delegate { response = Feeds.Load.Custom(uri); },
                delegate
                {
                    tweetBoardHandler(response);
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
            Process.Start(LangPack.MAIN_URL_CERULEANGITREPO);
        }

        private void menuItemGotoCeruleanCom_Click(object sender, EventArgs e)
        {
            Process.Start(LangPack.MAIN_URL_CERULEANWEB);
        }

        private void menuItemBugGitFile_Click(object sender, EventArgs e)
        {
            Process.Start((LangPack.MAIN_URL_CERULEANGITREPO + LangPack.MAIN_URL_CERULEANGITERRPATH));
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
                if (predictionResponse != null && WEH.ErrHandler(predictionResponse)[2] != "true")
                {
                    try
                    {
                        if (predictionResponse["actors"].ToString() != "[]")
                        {
                            string did = predictionResponse["actors"][0]["did"].ToString();
                            new Menu_Profile(did).ShowDialog();

                        }
                    }
                    catch { MessageBox.Show(predictionResponse.ToString()); }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == String.Empty || searchBox.Text == LangPack.MAIN_SEARCHBOX_PLACEHOLDER) { predictionBox.Height = 0; }
            else
            {
                // Reset the timer every time text changes
                _debounceTimer.Stop();
                _debounceTimer.Start();

                // Save the latest input
                _lastInput = searchBox.Text;
            }
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
                    delegate { predictionResponse = Profile.Search.Typeahead(_lastInput); },
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
            new Menu_FeedSelector().ShowDialog();
        }

        private void notificationsButton_Click(object sender, EventArgs e)
        {
            NotificationFetcher();
            
        }

        private void NotificationFetcher()
        {
            JArray notifications = new JArray();
            Async.SkyWorker(
                delegate { notifications = Notifications.Fetch(); },
                delegate
                {
                    TreeNode parent = mainTree.Nodes.Add("Notifications");
                    //parent.Nodes.Clear();
                    foreach (JObject notification in notifications)
                    {
                        string text = notification.SelectToken("reason").ToString() + " by " + notification.SelectToken("author.handle").ToString();
                        parent.Nodes.Add(text);
                    }
                    parent.ExpandAll();
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
                    FollowerFetcher();
                }
            );
        }

        private void FollowerFetcher()
        {
            JArray followers = new JArray();
            MessageBox.Show(Profile.GetDid(Variables.Handle).ToString());
            Async.SkyWorker(

                delegate { followers = Profile.FetchData.Followers(Profile.GetDid(Variables.Handle)); },
                delegate
                {
                    TreeNode parent = mainTree.Nodes.Add("Followers");
                    //parent.Nodes.Clear();

                    foreach (JObject follower in followers)
                    {
                        parent.Nodes.Add(follower["handle"].ToString());
                    }
                    parent.ExpandAll();
                }
            );
        }

        public static void EnableDoubleBuffer(Control control)
        {
            control.GetType().InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

    }
}
