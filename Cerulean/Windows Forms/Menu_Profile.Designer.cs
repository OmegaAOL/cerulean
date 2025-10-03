namespace Cerulean
{
    partial class Menu_Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Profile));
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.handleLabel = new System.Windows.Forms.Label();
            this.verifiedLabel = new System.Windows.Forms.Label();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bioPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bioLabel = new System.Windows.Forms.Label();
            this.followersLabel = new System.Windows.Forms.Label();
            this.followingLabel = new System.Windows.Forms.Label();
            this.mutualsLabel = new System.Windows.Forms.Label();
            this.postsLabel = new System.Windows.Forms.Label();
            this.joinedLabel = new System.Windows.Forms.Label();
            this.blockedLabel = new System.Windows.Forms.Label();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.loadingText = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.followsYouLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.allowChatLabel = new System.Windows.Forms.Label();
            this.expandLabel = new Cerulean.LinkButton();
            this.chatButton = new Cerulean.CeruleanButton();
            this.blockButton = new Cerulean.CeruleanButton();
            this.followButton = new Cerulean.CeruleanButton();
            this.reportButton = new Cerulean.CeruleanButton();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            this.bioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoEllipsis = true;
            this.nicknameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nicknameLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.nicknameLabel.Location = new System.Drawing.Point(13, 14);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(222, 22);
            this.nicknameLabel.TabIndex = 0;
            this.nicknameLabel.Text = "Placeholder text";
            this.nicknameLabel.Visible = false;
            // 
            // handleLabel
            // 
            this.handleLabel.AutoEllipsis = true;
            this.handleLabel.BackColor = System.Drawing.Color.Transparent;
            this.handleLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.handleLabel.Location = new System.Drawing.Point(15, 38);
            this.handleLabel.Name = "handleLabel";
            this.handleLabel.Size = new System.Drawing.Size(220, 13);
            this.handleLabel.TabIndex = 1;
            this.handleLabel.Text = "handle unknown";
            this.handleLabel.Visible = false;
            // 
            // verifiedLabel
            // 
            this.verifiedLabel.BackColor = System.Drawing.Color.Transparent;
            this.verifiedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifiedLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.verifiedLabel.Location = new System.Drawing.Point(241, 115);
            this.verifiedLabel.Name = "verifiedLabel";
            this.verifiedLabel.Size = new System.Drawing.Size(89, 13);
            this.verifiedLabel.TabIndex = 2;
            this.verifiedLabel.Text = "Verified";
            this.verifiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.verifiedLabel.Visible = false;
            // 
            // avatarBox
            // 
            this.avatarBox.BackColor = System.Drawing.Color.Transparent;
            this.avatarBox.BackgroundImage = global::Cerulean.CeruleanArt.default_user;
            this.avatarBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.avatarBox.Image = global::Cerulean.CeruleanArt.user_small;
            this.avatarBox.Location = new System.Drawing.Point(241, 12);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(89, 89);
            this.avatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarBox.TabIndex = 3;
            this.avatarBox.TabStop = false;
            this.avatarBox.Visible = false;
            this.avatarBox.Click += new System.EventHandler(this.avatarBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label4.Location = new System.Drawing.Point(15, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Followers:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label5.Location = new System.Drawing.Point(15, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Following:";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label6.Location = new System.Drawing.Point(133, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Posts:";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label7.Location = new System.Drawing.Point(15, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Joined:";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label8.Location = new System.Drawing.Point(15, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Mutual followers:";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label9.Location = new System.Drawing.Point(133, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Blocks you:";
            this.label9.Visible = false;
            // 
            // bioPanel
            // 
            this.bioPanel.AutoScroll = true;
            this.bioPanel.AutoScrollMinSize = new System.Drawing.Size(1, 0);
            this.bioPanel.BackColor = System.Drawing.Color.Ivory;
            this.bioPanel.Controls.Add(this.bioLabel);
            this.bioPanel.Location = new System.Drawing.Point(12, 164);
            this.bioPanel.MaximumSize = new System.Drawing.Size(318, 9999999);
            this.bioPanel.MinimumSize = new System.Drawing.Size(318, 0);
            this.bioPanel.Name = "bioPanel";
            this.bioPanel.Size = new System.Drawing.Size(318, 91);
            this.bioPanel.TabIndex = 14;
            this.bioPanel.Visible = false;
            // 
            // bioLabel
            // 
            this.bioLabel.AutoSize = true;
            this.bioLabel.Location = new System.Drawing.Point(3, 0);
            this.bioLabel.MaximumSize = new System.Drawing.Size(295, 99999);
            this.bioLabel.Name = "bioLabel";
            this.bioLabel.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.bioLabel.Size = new System.Drawing.Size(6, 19);
            this.bioLabel.TabIndex = 0;
            this.bioLabel.Visible = false;
            // 
            // followersLabel
            // 
            this.followersLabel.AutoSize = true;
            this.followersLabel.BackColor = System.Drawing.Color.Transparent;
            this.followersLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.followersLabel.Location = new System.Drawing.Point(64, 60);
            this.followersLabel.Margin = new System.Windows.Forms.Padding(0);
            this.followersLabel.Name = "followersLabel";
            this.followersLabel.Size = new System.Drawing.Size(13, 13);
            this.followersLabel.TabIndex = 15;
            this.followersLabel.Text = "0";
            this.followersLabel.Visible = false;
            // 
            // followingLabel
            // 
            this.followingLabel.AutoSize = true;
            this.followingLabel.BackColor = System.Drawing.Color.Transparent;
            this.followingLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.followingLabel.Location = new System.Drawing.Point(64, 75);
            this.followingLabel.Margin = new System.Windows.Forms.Padding(0);
            this.followingLabel.Name = "followingLabel";
            this.followingLabel.Size = new System.Drawing.Size(13, 13);
            this.followingLabel.TabIndex = 16;
            this.followingLabel.Text = "0";
            this.followingLabel.Visible = false;
            // 
            // mutualsLabel
            // 
            this.mutualsLabel.AutoSize = true;
            this.mutualsLabel.BackColor = System.Drawing.Color.Transparent;
            this.mutualsLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.mutualsLabel.Location = new System.Drawing.Point(96, 90);
            this.mutualsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.mutualsLabel.Name = "mutualsLabel";
            this.mutualsLabel.Size = new System.Drawing.Size(13, 13);
            this.mutualsLabel.TabIndex = 17;
            this.mutualsLabel.Text = "0";
            this.mutualsLabel.Visible = false;
            // 
            // postsLabel
            // 
            this.postsLabel.AutoSize = true;
            this.postsLabel.BackColor = System.Drawing.Color.Transparent;
            this.postsLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.postsLabel.Location = new System.Drawing.Point(164, 60);
            this.postsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.postsLabel.Name = "postsLabel";
            this.postsLabel.Size = new System.Drawing.Size(13, 13);
            this.postsLabel.TabIndex = 18;
            this.postsLabel.Text = "0";
            this.postsLabel.Visible = false;
            // 
            // joinedLabel
            // 
            this.joinedLabel.AutoSize = true;
            this.joinedLabel.BackColor = System.Drawing.Color.Transparent;
            this.joinedLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.joinedLabel.Location = new System.Drawing.Point(52, 105);
            this.joinedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.joinedLabel.Name = "joinedLabel";
            this.joinedLabel.Size = new System.Drawing.Size(51, 13);
            this.joinedLabel.TabIndex = 19;
            this.joinedLabel.Text = "unknown";
            this.joinedLabel.Visible = false;
            // 
            // blockedLabel
            // 
            this.blockedLabel.AutoSize = true;
            this.blockedLabel.BackColor = System.Drawing.Color.Transparent;
            this.blockedLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.blockedLabel.Location = new System.Drawing.Point(191, 90);
            this.blockedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.blockedLabel.Name = "blockedLabel";
            this.blockedLabel.Size = new System.Drawing.Size(19, 13);
            this.blockedLabel.TabIndex = 20;
            this.blockedLabel.Text = "no";
            this.blockedLabel.Visible = false;
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(69, 104);
            this.loadingBar.MarqueeAnimationSpeed = 10;
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(204, 23);
            this.loadingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingBar.TabIndex = 21;
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.BackColor = System.Drawing.Color.Transparent;
            this.loadingText.Location = new System.Drawing.Point(102, 139);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(135, 13);
            this.loadingText.TabIndex = 22;
            this.loadingText.Text = "Fetching Profile Information";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label23.Location = new System.Drawing.Point(133, 105);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 23;
            this.label23.Text = "Follows you:";
            this.label23.Visible = false;
            // 
            // followsYouLabel
            // 
            this.followsYouLabel.AutoSize = true;
            this.followsYouLabel.BackColor = System.Drawing.Color.Transparent;
            this.followsYouLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.followsYouLabel.Location = new System.Drawing.Point(194, 105);
            this.followsYouLabel.Margin = new System.Windows.Forms.Padding(0);
            this.followsYouLabel.Name = "followsYouLabel";
            this.followsYouLabel.Size = new System.Drawing.Size(19, 13);
            this.followsYouLabel.TabIndex = 24;
            this.followsYouLabel.Text = "no";
            this.followsYouLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = ThemeDefinitions.TextHighContrast;
            this.label1.Location = new System.Drawing.Point(133, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Chats with:";
            this.label1.Visible = false;
            // 
            // allowChatLabel
            // 
            this.allowChatLabel.AutoSize = true;
            this.allowChatLabel.BackColor = System.Drawing.Color.Transparent;
            this.allowChatLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.allowChatLabel.Location = new System.Drawing.Point(188, 75);
            this.allowChatLabel.Margin = new System.Windows.Forms.Padding(0);
            this.allowChatLabel.Name = "allowChatLabel";
            this.allowChatLabel.Size = new System.Drawing.Size(31, 13);
            this.allowChatLabel.TabIndex = 26;
            this.allowChatLabel.Text = "none";
            this.allowChatLabel.Visible = false;
            // 
            // expandLabel
            // 
            this.expandLabel.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.expandLabel.BackColor = System.Drawing.Color.Transparent;
            this.expandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandLabel.ForeColor = ThemeDefinitions.TextAccented;
            this.expandLabel.LinkColor = ThemeDefinitions.TextAccented;
            this.expandLabel.Location = new System.Drawing.Point(241, 101);
            this.expandLabel.Name = "expandLabel";
            this.expandLabel.Size = new System.Drawing.Size(89, 13);
            this.expandLabel.TabIndex = 28;
            this.expandLabel.TabStop = true;
            this.expandLabel.Text = "expand image";
            this.expandLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.expandLabel.Visible = false;
            this.expandLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.expandLabel_LinkClicked);
            // 
            // chatButton
            // 
            this.chatButton.AutoSize = true;
            this.chatButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chatButton.Location = new System.Drawing.Point(94, 129);
            this.chatButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.chatButton.Name = "chatButton";
            this.chatButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.chatButton.Size = new System.Drawing.Size(75, 23);
            this.chatButton.TabIndex = 27;
            this.chatButton.Text = "Chat";
            this.chatButton.UseVisualStyleBackColor = true;
            this.chatButton.Visible = false;
            // 
            // blockButton
            // 
            this.blockButton.AutoSize = true;
            this.blockButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.blockButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.blockButton.Location = new System.Drawing.Point(175, 129);
            this.blockButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.blockButton.Name = "blockButton";
            this.blockButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.blockButton.Size = new System.Drawing.Size(75, 23);
            this.blockButton.TabIndex = 13;
            this.blockButton.Text = "Block";
            this.blockButton.UseVisualStyleBackColor = true;
            this.blockButton.Visible = false;
            // 
            // followButton
            // 
            this.followButton.AutoSize = true;
            this.followButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.followButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.followButton.Location = new System.Drawing.Point(13, 129);
            this.followButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.followButton.Name = "followButton";
            this.followButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.followButton.Size = new System.Drawing.Size(75, 23);
            this.followButton.TabIndex = 12;
            this.followButton.Text = "Follow";
            this.followButton.UseVisualStyleBackColor = true;
            this.followButton.Visible = false;
            this.followButton.Click += new System.EventHandler(this.followButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.AutoSize = true;
            this.reportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.reportButton.Location = new System.Drawing.Point(256, 129);
            this.reportButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.reportButton.Name = "reportButton";
            this.reportButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.reportButton.Size = new System.Drawing.Size(75, 23);
            this.reportButton.TabIndex = 11;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Visible = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // Menu_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ThemeDefinitions.Background;
            this.ClientSize = new System.Drawing.Size(342, 267);
            this.Controls.Add(this.expandLabel);
            this.Controls.Add(this.bioPanel);
            this.Controls.Add(this.allowChatLabel);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatButton);
            this.Controls.Add(this.followsYouLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.blockedLabel);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.joinedLabel);
            this.Controls.Add(this.postsLabel);
            this.Controls.Add(this.mutualsLabel);
            this.Controls.Add(this.followingLabel);
            this.Controls.Add(this.followersLabel);
            this.Controls.Add(this.blockButton);
            this.Controls.Add(this.followButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.avatarBox);
            this.Controls.Add(this.verifiedLabel);
            this.Controls.Add(this.handleLabel);
            this.Controls.Add(this.nicknameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Profile";
            this.Text = "Loading user profile";
            this.Load += new System.EventHandler(this.Menu_Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            this.bioPanel.ResumeLayout(false);
            this.bioPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Label handleLabel;
        private System.Windows.Forms.Label verifiedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox avatarBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Cerulean.CeruleanButton reportButton;
        private Cerulean.CeruleanButton followButton;
        private Cerulean.CeruleanButton blockButton;
        private System.Windows.Forms.FlowLayoutPanel bioPanel;
        private System.Windows.Forms.Label bioLabel;
        private System.Windows.Forms.Label followersLabel;
        private System.Windows.Forms.Label followingLabel;
        private System.Windows.Forms.Label mutualsLabel;
        private System.Windows.Forms.Label postsLabel;
        private System.Windows.Forms.Label joinedLabel;
        private System.Windows.Forms.Label blockedLabel;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label followsYouLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label allowChatLabel;
        private Cerulean.CeruleanButton chatButton;
        private LinkButton expandLabel;
    }
}