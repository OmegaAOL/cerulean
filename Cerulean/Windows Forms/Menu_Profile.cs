using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_Profile : Form
    {
        /* ===== Constants ===== */
        private const string LABEL_YES = "yes";
        private const string LABEL_OFFLINEUSER = "Offline User";
        private const string BUTTON_UNMUTE = "Unmute";
        private const string BUTTON_UNFOLLOW = "Unfollow";
        private const string BUTTON_FOLLOW = "Follow";
        private const string BUTTON_UNBLOCK = "Unblock";
        private const string LABEL_VERIFIER = "Trusted Verifier";

        private bool following = false;

        private JObject response;

        private string did_cw;
        public Menu_Profile(string did)
        {
            InitializeComponent();
            did_cw = did;
            GetProfileData(did);
        }

        private void Menu_Profile_Load(object sender, EventArgs e)
        {
            this.ActiveControl = followButton;
            CenterToParent();
        }

        private void GetProfileData(string did)
        {
            Async.SkyWorker(
                 delegate { response = Profile.Load(did); },
                 delegate { SetProfileData(); }
                );
        }

        private void SetProfileData()
        {
            if (WEH.ErrHandler(response)[2] != "true")
            {
                File.WriteAllText("profile.txt", response.ToString());
                foreach (Control item in this.Controls)
                {
                    item.Visible = true;
                }

                bioLabel.Visible = true;
                loadingBar.Visible = false;
                loadingText.Visible = false;
                verifiedLabel.Visible = false;
                chatButton.Enabled = false;

                this.Text = response["handle"].ToString();
                handleLabel.Text = "@" + this.Text;

                SetIfNotNull(nicknameLabel, response.SelectToken("displayName"));
                SetIfNotNull(bioLabel, response.SelectToken("description"));
                SetIfNotNull(followersLabel, response.SelectToken("followersCount"));
                SetIfNotNull(followingLabel, response.SelectToken("followsCount"));
                SetIfNotNull(postsLabel, response.SelectToken("postsCount"));
                SetIfNotNull(mutualsLabel, response.SelectToken("viewer.knownFollowers.count"));
                SetIfNotNull(allowChatLabel, response.SelectToken("associated.chat.allowIncoming"));

                bool followsYou = false;

                if (response["displayName"] == null)
                {
                    nicknameLabel.Text = this.Text;
                }

                if (response["viewer"]["followedBy"] != null)
                {
                    followsYouLabel.Text = LABEL_YES;
                    followsYou = true;
                }

                if (response["associated"]["chat"] != null)
                {
                    string chat = response["associated"]["chat"]["allowIncoming"].ToString();
                    if (chat == "all") { chatButton.Enabled = true; }
                    if (chat == "following") { if (followsYou) { chatButton.Enabled = true; } }
                }

                if (response["viewer"]["muted"].ToString() == "true")
                {
                    reportButton.Text = BUTTON_UNMUTE;
                }

                if (response["viewer"]["following"] != null)
                {
                    following = true;
                    followButton.Text = BUTTON_UNFOLLOW;
                }

                if (response["viewer"]["blocking"] != null)
                {
                    blockedLabel.Text = LABEL_YES;
                }

                JToken blockedBy = GetSafeToken(response, "viewer", "blockedBy");
                if (blockedBy != null && blockedBy.ToString() == "true")
                {
                    blockButton.Text = BUTTON_UNBLOCK;
                }

                JToken createdAt = GetSafeToken(response, "createdAt");
                if (createdAt != null)
                {
                    DateTime dt = DateTime.Parse(createdAt.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);
                    joinedLabel.Text = dt.ToString("MMM d, yyyy");
                }

                JToken verifiedStatus = GetSafeToken(response, "verification", "verifiedStatus");
                JToken tvStatus = GetSafeToken(response, "verification", "trustedVerifierStatus");

                if (verifiedStatus.ToString() == "valid")
                {
                    verifiedLabel.Visible = true;
                    nicknameLabel.ForeColor = Color.Goldenrod;


                }

                if (tvStatus.ToString() == "valid")
                {
                    verifiedLabel.Visible = true;
                    verifiedLabel.ForeColor = Color.Firebrick;
                    nicknameLabel.ForeColor = Color.Firebrick;
                    verifiedLabel.Text = LABEL_VERIFIER;
                }

                if (response["avatar"] != null)
                {
                    ImageFetcher.QueueImage(response["avatar"].ToString().Replace("avatar", "avatar_thumbnail"), avatarBox);
                }

                /*if (response["banner"] != null)
                {
                    ImageFetcher.QueueImage(response["banner"].ToString(), bannerBox);
                }*/
            }
        }

        private void SetIfNotNull(Label label, JToken token)
        {
            if (token != null && !String.IsNullOrEmpty(token.ToString()))
            {
                label.Text = token.ToString();
            }
        }

        private JToken GetSafeToken(JToken token, params string[] path)
        {
            foreach (string part in path)
            {
                if (token == null || token.Type == JTokenType.Null)
                    return null;
                token = token[part];
            }
            return token;
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            new Menu_Report(did_cw).ShowDialog();
        }

        private void avatarBox_Click(object sender, EventArgs e)
        {

        }

        private void expandLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Async.SkyWorker(
                delegate { new ImageViewer(Media.Image.Load(response["avatar"].ToString())).ShowDialog(); },
                delegate { }
            );
        }

        private void SetFollowText(bool following)
        {
            if (!following)
                followButton.Text = BUTTON_FOLLOW;
            else if (following)
                followButton.Text = BUTTON_UNFOLLOW;
        }


        private void followButton_Click(object sender, EventArgs e)
        {
            followButton.Enabled = false;
            Async.SkyWorker(
                delegate
                {
                    if (following)
                        Profile.Follow.Remove(response["viewer"]["following"].ToString());
                    else if (!following)
                        Profile.Follow.Add(response["did"].ToString());
                },
                delegate
                {
                    following = !following;
                    followButton.Enabled = true;
                    SetFollowText(following);
                }
            );

        }
    }
}
