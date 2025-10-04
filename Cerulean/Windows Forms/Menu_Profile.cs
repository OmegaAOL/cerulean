using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_Profile : Form
    {
        private bool following = false;
        private Image _backgroundImg;

        private JObject response;

        private string did_cw;
        public Menu_Profile(string did)
        {
            InitializeComponent();
            did_cw = did;
            GetProfileData(did);
            this.Paint += MyForm_Paint;
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            if (_backgroundImg == null)
                return;

            float imgWidth = _backgroundImg.Width;
            float imgHeight = _backgroundImg.Height;
            float formWidth = this.ClientSize.Width;
            float formHeight = this.ClientSize.Height;

            // scale factor to fill vertically
            float scale = formHeight / imgHeight;

            float drawWidth = (imgWidth * scale);
            float drawHeight = (imgHeight * scale);

            // center horizontally
            int x = (int)((formWidth - drawWidth) / 2);
            int y = 0;

            e.Graphics.DrawImage(_backgroundImg, x, y, drawWidth, drawHeight);
        }


        private void Menu_Profile_Load(object sender, EventArgs e)
        {
            this.ActiveControl = followButton;
            CenterToParent();
            nicknameLabel.Text = LangPack.GLOBAL_DISPLAYNAME_EMPTY;
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
                    followsYouLabel.Text = LangPack.GLOBAL_YES.ToLower();
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
                    reportButton.Text = LangPack.PROFILE_BUTTON_UNMUTE;
                }

                if (response["viewer"]["following"] != null)
                {
                    following = true;
                    followButton.Text = LangPack.PROFILE_BUTTON_UNFOLLOW;
                }

                if (response["viewer"]["blocking"] != null)
                {
                    blockedLabel.Text = LangPack.GLOBAL_YES.ToLower();
                }

                JToken blockedBy = GetSafeToken(response, "viewer", "blockedBy");
                if (blockedBy != null && blockedBy.ToString() == "true")
                {
                    blockButton.Text = LangPack.PROFILE_BUTTON_UNBLOCK;
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
                    verifiedLabel.Text = LangPack.PROFILE_LABEL_VERIFIER;
                }

                if (response["avatar"] != null)
                {
                    ImageFetcher.QueueImage(response["avatar"].ToString().Replace("avatar", "avatar_thumbnail"), avatarBox);
                }
                else
                {
                    expandLabel.Visible = false;
                }

                if (response["banner"] != null)
                {
                    PictureBox bannerBoxTemp = new PictureBox();
                    bannerBoxTemp.BackgroundImageChanged += (s, e) =>
                    {
                        _backgroundImg = bannerBoxTemp.BackgroundImage;
                        panel1.BackColor = ThemeDefinitions.BackgroundColorTransparent;
                        panel1.Visible = true;
                        BackChangerLabels();
                        this.Invalidate();
                    };
                    ImageFetcher.QueueImage(response["banner"].ToString(), bannerBoxTemp, true);
                }

            }
        }

        private void BackChangerLabels()
        {
            nicknameLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            handleLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label1.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label23.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label4.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label5.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label6.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label7.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label8.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            label9.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            followingLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            followersLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            joinedLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            followsYouLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            expandLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            blockedLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            allowChatLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            bioLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            mutualsLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            nicknameLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            postsLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
            verifiedLabel.BackColor = ThemeDefinitions.BackgroundColorTransparent;
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
                    return String.Empty;
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
                delegate 
                { 
                    new ImageViewer(Media.Image.Load(response["avatar"].ToString())).ShowDialog(); 
                },
                delegate { }
            );
        }

        private void SetFollowText(bool following)
        {
            if (!following)
                followButton.Text = LangPack.PROFILE_BUTTON_FOLLOW;
            else if (following)
                followButton.Text = LangPack.PROFILE_BUTTON_UNFOLLOW;
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
