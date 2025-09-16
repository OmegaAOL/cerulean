using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json.Linq;
using OmegaAOL.SkyBridge;
using System.Text.RegularExpressions;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;

namespace Cerulean
{
    public partial class Menu_Tweet : Form
    {
        /* ===== Constants ===== */
        private const string LABEL_CHARCOUNT_REMAINING = "{0} characters left";
        private const string LABEL_CHARCOUNT_ONECHAR = "1 character left";
        private const string WINTITLE_REPLYTO_PRE = "Reply to";
        private const string WINTITLE_QUOTE_PRE = "Quote";
        private const string TEXTBOX_QUOTE_PRE = "Quoting";

        JObject parent = null, root = null;
        private static Spelling content;
        Tweet.Type type = Tweet.Type.Normal;

        public Menu_Tweet(Tweet.Type typeTemp, JObject parentTemp = null, JObject rootTemp = null)
        {
            InitializeComponent();
            DictInit();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
            type = typeTemp;
            root = rootTemp;
            parent = parentTemp;

            if (type == Tweet.Type.Reply)
            {
                SetControlsReply(parent);
            }

            else if (type == Tweet.Type.Quote)
            {
                SetControlsQuote(parent);
            }

            if (RegKit.Read.Dword("UserSettings", "DSForComposer") == 1)
            {
                spellingCheckBox.Checked = true;
            }

            if (spellingCheckBox.Checked)
                tweetBox.TextChanged += tweetBoxActiveChecker;
        }

        private static void DictInit()
        {
            WordDictionary dict = new WordDictionary();
            dict.DictionaryFile = "en-US.dic";
            dict.Initialize();
            content = new Spelling();
            content.Dictionary = dict;
        }

        private void SetControlsReply(JObject parent)
        {
            this.Text = WINTITLE_REPLYTO_PRE + " " + parent["author"]["handle"].ToString();
        }

        private void SetControlsQuote(JObject parent)
        {
            this.Text = WINTITLE_QUOTE_PRE + " " + parent["author"]["handle"].ToString();
        }

        private void Menu_Tweet_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = tweetButton;
            tweetBox.MaxLength = 300;
            ccText.ForeColor = Color.Green;
            BackgroundImage = Global.bgImage;
        }


        private void tweetBoxActiveChecker(object sender, EventArgs e)
        {

            string[] words = Regex.Split(tweetBox.Text, @"[^A-Za-z'-]+");
            bool issue = false;
            foreach (string wordc in words)
            {
                if ((!content.TestWord(wordc)) && wordc.Length > 1 && (wordc.ToUpper() != wordc))
                    issue = true;
            }
            if (issue)
                tweetBox.ForeColor = Color.Firebrick;
            else
                tweetBox.ForeColor = Color.Black;




            progressBar1.Value = tweetBox.TextLength;
            if (tweetBox.TextLength != 299)
            {
                ccText.Text = (String.Format(LABEL_CHARCOUNT_REMAINING, (300 - tweetBox.TextLength).ToString()));
                if (tweetBox.TextLength > 290)
                {
                    ccText.ForeColor = Color.Red;
                }
                else if (tweetBox.TextLength > 250)
                {
                    ccText.ForeColor = Color.OrangeRed;
                }
                else
                {
                    ccText.ForeColor = Color.Green;
                }
            }
            else
            {
                ccText.Text = LABEL_CHARCOUNT_ONECHAR;
                ccText.ForeColor = Color.Red;
            }
        }

        public void tweetButton_Click(object sender, EventArgs ev)
        {
            string tweetContent = tweetBox.Text;
            tweetButton.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 15;
            if (spellingCheckBox.Checked && tweetBox.ForeColor == Color.Firebrick)
                content.SpellCheck(tweetContent);

            if (RegKit.Read.Dword("UserSettings", "DSForComposer") == 1) // digital signature
            {
                tweetContent += (" " + RegKit.Read.String("UserSettings", "DigitalSignature"));
            }

            Async.SkyWorker(
                (s, evt) =>
                {
                    switch (type)
                    {
                        case Tweet.Type.Normal:
                            evt.Result = Tweet.Create(tweetContent);
                            break;
                        case Tweet.Type.Reply:
                            evt.Result = Tweet.Reply(tweetContent, parent, root);
                            break;
                        case Tweet.Type.Quote:
                            evt.Result = Tweet.Quote(tweetContent, parent);
                            break;
                        case Tweet.Type.Repost:
                            evt.Result = Tweet.Repost.Add(parent);
                            break;
                    }
                },
                (s, evt) =>
                {
                    CeruleanBox.Display(evt.Result.ToString());
                    progressBar1.MarqueeAnimationSpeed = 0;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    tweetButton.Enabled = true;
                    Variables.BlobArray = null;
                }
            );
        }

        private void draftButton_Click(object sender, EventArgs e)
        {

        }

        private void mediaUploadButton_Click(object sender, EventArgs e)
        {

        }

        private void ccText_Click(object sender, EventArgs e)
        {

        }

        private void tweetBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    Image img = Clipboard.GetImage();
                    // Example: show in a PictureBox
                    new Menu_ImageSelector(img).Show();

                    e.SuppressKeyPress = true; // prevent pasting raw text fallback
                }
            }
        }

    }
}
