using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Cerulean.LangPacks;
using System.Text;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class TweetControl : UserControl
    {
        private int likeCount;
        private int repostCount;
        private int replyCount;
        private int quoteCount;
        private string likeUri = null;
        private string repostUri = null;
        private string permalink = String.Empty;
        private string atUri = String.Empty;
        private string did = String.Empty;
        private string cid = String.Empty;
        private string embedURL = String.Empty;
        private JObject reply = null;
        private JObject tweet = null;

        public TweetControl()
        {
            InitializeComponent();
            typeof(Form).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null, this, new object[] { true });
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        public void LoadTweetContent(JObject tweetPackage) // load and set all content in TweetControl from tweetPackage
        {
            tweet = tweetPackage["post"] as JObject;  // this is a global variable because it needs to be accessed from outside this function
            reply = tweetPackage["reply"] as JObject; // this is a global variable because it needs to be accessed from outside this function

            string embedType = null;
            string embedThumbURL = null;
            string embedURL = null;

            likeCount = (int)tweet["likeCount"];
            replyCount = (int)tweet["replyCount"];
            repostCount = (int)tweet["repostCount"];
            quoteCount = (int)tweet["quoteCount"];

            string atUri = tweet["uri"].ToString();
            string cid = tweet["cid"].ToString();
            string did = tweet["author"]["did"].ToString();
            string creationTime = tweet["record"]["createdAt"].ToString();
            string displayName = tweet["author"]["displayName"].ToString();
            string handle = tweet["author"]["handle"].ToString();
            string text = tweet["record"]["text"].ToString();

            repostUri = tweet.SelectToken("viewer.repost") != null ? tweet["viewer"]["repost"].ToString() : null;
            likeUri = tweet.SelectToken("viewer.like") != null ? tweet["viewer"]["like"].ToString() : null;

            if (tweet.SelectToken("record.facets") != null) // checking if "facets" (website/hashtag link coordinates) exist
            {
                LinkSetter(tweet["record"]["facets"]); // sets LinkAreas of post text to the link areas specified in the coords
            }

            if (tweet.SelectToken("author.avatar") != null) // checking if avatar URL exists (this should always exist, afaik)
            {
                string posterAvatarURL = tweet["author"]["avatar"].ToString();
            }

            Profile.Verification verificationStatus = GetVerificationStatus(tweet);

            if (tweet.ContainsKey("embed"))
            {
                ParseEmbed(tweet, out embedType, out embedThumbURL, out embedURL);
                //CeruleanBox.Display(embedURL);
            }

            // Store values with null safety
            this.atUri = atUri != null ? atUri : String.Empty;
            this.cid = cid != null ? cid : String.Empty;
            this.did = did != null ? did : String.Empty;
            this.embedURL = embedURL != null ? embedURL : String.Empty;
            this.permalink = FormatWebUrlFromAtUri(this.atUri);

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = handle != null ? handle : String.Empty;
            }

            // Time formatting with safe parsing
            timeAgo.Text = SafeUtcToTimeAgo(creationTime);

            posterName.Text = displayName;
            posterHandle.Text = "@" + (handle != null ? handle : String.Empty);
            postText.Text = text != null ? text : String.Empty;

            // Verified color
            if (verificationStatus == Profile.Verification.Verified)
                posterName.LinkColor = Color.DarkGoldenrod;
            else if (verificationStatus == Profile.Verification.TrustedVerifier)
                posterName.LinkColor = Color.Firebrick;

            // Format counts
            LikeLabelSetter(likeUri != null);
            RepostLabelSetter(repostUri != null);
            numberStringFormatter(replyClickCount, "reply", replyCount);            
            numberStringFormatter(quoteClickCount, "quote", quoteCount);

            // Reply to
            if (reply != null)
            {
                    replyLabel.Visible = true;
                    replyLabel.Enabled = true;
                    string replyTo;
                    string tweetType = reply["parent"]["$type"].ToString();
                    
                    if (tweetType == Tweet.Defs.PostView) 
                    {
                        replyTo = reply["parent"]["author"]["handle"].ToString();      
                        
                    }

                    else if (tweetType == Tweet.Defs.NotFound)
                    {
                        replyTo = "[deleted post]";
                    }

                    else
                    {
                        replyTo = "[unable to get reply information]";
                    }

                    replyLabel.Text = String.Format("(replying to {0})", replyTo);                                       
            }

            // Embed
            if (!string.IsNullOrEmpty(embedType))
            {
                postImage.Visible = true;
                expandImageButton.Visible = true;

                if (!string.IsNullOrEmpty(embedThumbURL))
                {
                    ImageFetcher.QueueImage(embedThumbURL, postImage);
                }

                expandImageButton.Text = GetExpandButtonText(embedType);
            }
        }

        public void LinkSetter(JToken facetsToken)
        {
            JArray facets = new JArray();
            facets = (JArray)facetsToken;

            string text = postText.Text;

            foreach (JObject facet in facets)
            {
                int byteStart = (int)facet["index"]["byteStart"];
                int byteEnd = (int)facet["index"]["byteEnd"];

                // Convert byte positions to char positions
                int charStart = GetCharIndexFromByteIndex(text, byteStart);
                int charEnd = GetCharIndexFromByteIndex(text, byteEnd);

                // WinForms LinkArea uses (start, length)
                int length = charEnd - charStart;

                if (charStart >= 0 && length > 0 && charStart + length <= text.Length)
                {
                    try
                    {
                        postText.Links.Add(charStart, length);
                    }
                    catch (Exception ex) { CeruleanBox.Display(ex.Message); }
                }
            }

        }

        private int GetCharIndexFromByteIndex(string text, int byteIndex)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(text);

            if (byteIndex > utf8.Length) byteIndex = utf8.Length;

            string substring = Encoding.UTF8.GetString(utf8, 0, byteIndex);

            return substring.Length;
        }

        private Profile.Verification GetVerificationStatus(JObject tweet) // gets verification status for a tweet (none, verified, trusted)
        {
            Profile.Verification verified = Profile.Verification.None;

            if (tweet["author"] != null && tweet["author"]["verification"] != null)
            {
                JObject verification = (JObject)tweet["author"]["verification"];

                if (verification["verifiedStatus"] != null &&
                    verification["verifiedStatus"].ToString() == "valid")
                {
                    verified = Profile.Verification.Verified;
                    if (verification["trustedVerifierStatus"] != null &&
                    verification["trustedVerifierStatus"].ToString() == "valid")
                    {
                        verified = Profile.Verification.TrustedVerifier;
                    }
                }

            }

            return verified;
        }

        private void ParseEmbed(JObject tweet, out string type, out string thumb, out string url) // determines if embed is image, video, or other
        {
            type = null;
            thumb = null;
            url = null;

            JObject embed = (JObject)tweet["embed"];
            if (embed["$type"] != null)
            {
                string embedType = embed["$type"].ToString();

                if (embedType == EmbedType.Image)
                {
                    try
                    {
                        type = EmbedType.Image;
                        url = embed["images"][0]["fullsize"].ToString();
                        thumb = embed["images"][0]["thumb"].ToString();
                    }
                    catch (Exception ex) { CeruleanBox.Display(ex.Message); }
                }
                else if (embedType == EmbedType.Video)
                {
                    type = EmbedType.Video;
                    url = embed["playlist"].ToString();
                    thumb = embed["thumbnail"].ToString();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.Gainsboro))
            {
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private string GetExpandButtonText(string embedType)
        {
            if (embedType == EmbedType.Video)
                return "expand video";
            if (embedType == EmbedType.Image)
                return "expand image";
            return "expand";
        }

        private string FormatTimeAgoUnit(int value, string unit)
        {
            return value + " " + unit + (value == 1 ? " ago" : "s ago");
        }

        private string SafeUtcToTimeAgo(string createdTime)
        {
            DateTime createdUtc;
            if (!DateTime.TryParse(createdTime, null, System.Globalization.DateTimeStyles.AdjustToUniversal, out createdUtc))
            {
                return "(unknown time)";
            }

            TimeSpan span = DateTime.UtcNow - createdUtc;

            if (span.TotalSeconds < 60)
                return "just now";
            if (span.TotalMinutes < 60)
                return FormatTimeAgoUnit((int)span.TotalMinutes, "minute");
            if (span.TotalHours < 24)
                return FormatTimeAgoUnit((int)span.TotalHours, "hour");
            if (span.TotalDays < 7)
                return FormatTimeAgoUnit((int)span.TotalDays, "day");
            if (span.TotalDays < 30)
                return FormatTimeAgoUnit((int)(span.TotalDays / 7), "week");
            if (span.TotalDays < 365)
                return FormatTimeAgoUnit((int)(span.TotalDays / 30), "month");
            return FormatTimeAgoUnit((int)(span.TotalDays / 365), "year");
        }

        private string numFormat(int number)
        {
            if (number >= 1000000000)
                return (number / 1000000000D).ToString("0.#") + "B";
            if (number >= 1000000)
                return (number / 1000000D).ToString("0.#") + "M";
            if (number >= 1000)
                return (number / 1000D).ToString("0.#") + "k";
            return number.ToString();
        }

        private void numberStringFormatter(LinkLabel label, string text, int amount)
        {
            if (amount != 0)
                label.Text = text + " (" + numFormat(amount) + ")";
            else
                label.Text = text;
        }       

        private string FormatWebUrlFromAtUri(string atUri)
        {
            if (string.IsNullOrEmpty(atUri) || atUri.Length <= 5)
                return String.Empty;

            string[] sections = atUri.Substring(5).Split('/');
            if (sections.Length >= 3)
                return Global.bskyUrl + "/profile/" + sections[0] + "/post/" + sections[2];
            return String.Empty;
        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            likeCount = IncDecCount(likeUri == null, likeCount); // if URI is null (post not liked), feed "true" to function & viceversa
            LikeLabelSetter(likeUri == null);

            Async.SkyWorker(
                    delegate
                    {
                        if (likeUri == null) { likeUri = Tweet.Like.Add(tweet); }
                        else { Tweet.Like.Remove(likeUri); likeUri = null; }
                    },
                    delegate
                    {
                        
                    }
                );            
        }

        private int IncDecCount(bool increment, int count)
        {
            if (increment)
                count++;
            else if (!increment)
                count--;
            return count;
        }

        private void copyTextButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (postText != null && !string.IsNullOrEmpty(postText.Text))
            {
                Clipboard.SetText(postText.Text);
            }
        }

        private void permalinkButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(permalink))
            {
                Clipboard.SetText(permalink);
            }
        }

        private void openInBrowserButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(permalink))
            {
                System.Diagnostics.Process.Start(permalink);
            }
        }

        private void reportButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Menu_Report(atUri, cid).ShowDialog();
        }

        private void collapseButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void shareButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(permalink))
            {
                string subject = Uri.EscapeDataString("Check out this post on Bluesky!");
                string body = Uri.EscapeDataString(permalink + "\n\nAlso, I use Cerulean, a client for Bluesky. Try it out at https://ceruleanweb.neocities.org/");
                System.Diagnostics.Process.Start("mailto:?subject=" + subject + "&body=" + body);
            }
        }

        private void replyClickCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JObject root;

            if (reply != null)
            {
                root = (JObject)reply["root"]; // root post is actual root post
            }
            else
            {
                root = tweet; // root post is tweet
            }

            new Menu_Tweet(Tweet.Type.Reply, tweet, root).ShowDialog();
        }

        private void repostClickCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            repostCount = IncDecCount(repostUri == null, repostCount); // if URI is not null (reposted), feed "true" to function & viceversa
            RepostLabelSetter(repostUri == null);
            Async.SkyWorker(
                    delegate
                    {
                        if (repostUri == null) { repostUri = Tweet.Repost.Add(tweet); }
                        else { Tweet.Repost.Remove(repostUri); repostUri = null; }                                                         
                    },
                    delegate
                    {
                        
                    }
                );
        }

        private void RepostLabelSetter(bool reposted)
        {
            repostClickCount.LinkColor = (reposted ? Color.MediumSeaGreen : Color.SteelBlue); // set label color
            numberStringFormatter(repostClickCount, (reposted ? "reposted" : "repost"), repostCount); // set text
        }

        private void LikeLabelSetter(bool liked)
        {
            likeButton.Image = liked ? CeruleanArt.upActive : CeruleanArt.upInactive; // set like image (up-vote active, inactive)

            likeCountLabel.Text = numFormat(likeCount) + (likeCount == 1 ? " like" : " likes"); // set text
        }

        private void quoteClickCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Menu_Tweet(Tweet.Type.Quote, tweet).ShowDialog();
        }

        private void muteButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Global.featureAbsent("Threads");
        }

        private void viewThreadButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Global.featureAbsent("Threads");
        }

        private void posterName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Menu_Profile(did).ShowDialog();
        }

        private void moreLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Control control in actionsPanel.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    label.Visible = true;
                }
            }
            moreLink.Visible = false;
        }

        private void lessLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            moreLink.Visible = true;
            muteButton.Visible = false;
            copyTextButton.Visible = false;
            shareButton.Visible = false;
            permalinkButton.Visible = false;
            openInBrowserButton.Visible = false;
            reportButton.Visible = false;
            collapseButton.Visible = false;
            lessLink.Visible = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (postImage != null && postImage.Image != null)
                {
                    postImage.Image.Dispose();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void TweetControl_Load(object sender, EventArgs e)
        {

        }

        private void SetRoundedCorners(int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void expandImageButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Image img = null;
            Async.SkyWorker(
                delegate { /*CeruleanBox.Display(embedURL);*/ img = Media.Image.Load(embedURL); },
                delegate { new ImageViewer(img).ShowDialog(); });
        }

        private void postImage_Click(object sender, EventArgs e)
        {

        }

    }
}
