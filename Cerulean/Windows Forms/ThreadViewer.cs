using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cerulean.LangPacks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Cerulean
{
    public partial class ThreadViewer : Form
    {
        public ThreadViewer(JObject thread)
        {
            InitializeComponent();
            this.Height = Screen.GetWorkingArea(this).Height;
            CenterToScreen();
            this.Text = LangPack.TVIEW_WINTITLE_LOADING;
            File.WriteAllText("thread.txt", thread.ToString()); //debug

            string title = thread.SelectToken("thread.post.author.handle").ToString();
            if (String.IsNullOrEmpty(title)) { title = LangPack.GLOBAL_UNKNOWN; }
            this.Text = LangPack.TVIEW_WINTITLE + " " + title;

            JArray tweetArray = (JArray)thread["thread"]["replies"];
            DisplayThreadContent(tweetArray);
        }

        private void DisplayThreadContent(JArray tweetArray, int depth = 0)
        {
            byte count = 0;
            //bool nextPageMsgShown = false; // TODO pages
            bool postsExist = false;

            foreach (JObject tweetPackage in tweetArray)
            {
                JObject tweet = (JObject)tweetPackage["post"];
                TweetControl t = new TweetControl();
                t.LoadTweetContent(tweetPackage, depth);

                int factor = depth * 20;
                t.Margin = new Padding(factor, 0, 0, 0);
                t.Width = t.Width - (factor);

                tweetBoard.Controls.Add(t);

                if (tweetPackage.SelectToken("replies[0]") != null)
                {
                    DisplayThreadContent((JArray)(tweetPackage["replies"]), depth + 1);
                }

                count++;
                if (!postsExist)
                {
                    postsExist = true;
                }


                /*else if (!nextPageMsgShown)
                {
                    tweetBoard.Controls.Add(makeLabel("You have reached the limit of posts (50) that can be displayed in a window. Pages will be added in a future release."));
                    nextPageMsgShown = true;
                }*/
            }

            if (!postsExist)
            {
                tweetBoard.Controls.Add(makeLabel(LangPack.TVIEW_NOPOSTS));
            }
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

        private void ThreadViewer_Load(object sender, EventArgs e)
        {

        }

    }
}
