namespace Cerulean
{
    partial class TweetControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweetControl));
            this.postText = new System.Windows.Forms.LinkLabel();
            this.likeButton = new System.Windows.Forms.PictureBox();
            this.likeCountLabel = new System.Windows.Forms.Label();
            this.timeAgo = new System.Windows.Forms.Label();
            this.postImage = new System.Windows.Forms.PictureBox();
            this.actionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.replyClickCount = new Cerulean.LinkButton();
            this.repostClickCount = new Cerulean.LinkButton();
            this.quoteClickCount = new Cerulean.LinkButton();
            this.bookmarkClickCount = new Cerulean.LinkButton();
            this.viewThreadButton = new Cerulean.LinkButton();
            this.deleteLink = new Cerulean.LinkButton();
            this.muteButton = new Cerulean.LinkButton();
            this.copyTextButton = new Cerulean.LinkButton();
            this.shareButton = new Cerulean.LinkButton();
            this.permalinkButton = new Cerulean.LinkButton();
            this.openInBrowserButton = new Cerulean.LinkButton();
            this.reportButton = new Cerulean.LinkButton();
            this.collapseButton = new Cerulean.LinkButton();
            this.lessLink = new Cerulean.LinkButton();
            this.moreLink = new Cerulean.LinkButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.posterName = new Cerulean.LinkButton();
            this.posterHandle = new System.Windows.Forms.Label();
            this.replyLabel = new System.Windows.Forms.Label();
            this.expandImageButton = new Cerulean.LinkButton();
            ((System.ComponentModel.ISupportInitialize)(this.likeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postImage)).BeginInit();
            this.actionsPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // postText
            // 
            this.postText.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.postText.BackColor = System.Drawing.Color.Transparent;
            this.postText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postText.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.postText.LinkColor = System.Drawing.Color.SteelBlue;
            this.postText.Location = new System.Drawing.Point(80, 22);
            this.postText.MaximumSize = new System.Drawing.Size(815, 45);
            this.postText.MinimumSize = new System.Drawing.Size(815, 45);
            this.postText.Name = "postText";
            this.postText.Size = new System.Drawing.Size(815, 45);
            this.postText.TabIndex = 0;
            this.postText.Text = resources.GetString("postText.Text");
            this.postText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.postText_LinkClicked);
            // 
            // likeButton
            // 
            this.likeButton.BackColor = System.Drawing.Color.Transparent;
            this.likeButton.Image = global::Cerulean.CeruleanArt.upInactive;
            this.likeButton.Location = new System.Drawing.Point(12, 10);
            this.likeButton.Name = "likeButton";
            this.likeButton.Size = new System.Drawing.Size(62, 60);
            this.likeButton.TabIndex = 1;
            this.likeButton.TabStop = false;
            this.likeButton.Click += new System.EventHandler(this.likeButton_Click);
            // 
            // likeCountLabel
            // 
            this.likeCountLabel.AutoSize = true;
            this.likeCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.likeCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.likeCountLabel.Location = new System.Drawing.Point(11, 76);
            this.likeCountLabel.MinimumSize = new System.Drawing.Size(66, 13);
            this.likeCountLabel.Name = "likeCountLabel";
            this.likeCountLabel.Size = new System.Drawing.Size(66, 13);
            this.likeCountLabel.TabIndex = 2;
            this.likeCountLabel.Text = "0 likes";
            this.likeCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeAgo
            // 
            this.timeAgo.AutoSize = true;
            this.timeAgo.BackColor = System.Drawing.Color.Transparent;
            this.timeAgo.ForeColor = System.Drawing.Color.DimGray;
            this.timeAgo.Location = new System.Drawing.Point(176, 0);
            this.timeAgo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.timeAgo.Name = "timeAgo";
            this.timeAgo.Size = new System.Drawing.Size(63, 13);
            this.timeAgo.TabIndex = 15;
            this.timeAgo.Text = "8 hours ago";
            // 
            // postImage
            // 
            this.postImage.BackColor = System.Drawing.Color.Transparent;
            this.postImage.Location = new System.Drawing.Point(905, 10);
            this.postImage.Name = "postImage";
            this.postImage.Size = new System.Drawing.Size(100, 63);
            this.postImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.postImage.TabIndex = 17;
            this.postImage.TabStop = false;
            this.postImage.Visible = false;
            this.postImage.Click += new System.EventHandler(this.postImage_Click);
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.actionsPanel.Controls.Add(this.replyClickCount);
            this.actionsPanel.Controls.Add(this.repostClickCount);
            this.actionsPanel.Controls.Add(this.quoteClickCount);
            this.actionsPanel.Controls.Add(this.bookmarkClickCount);
            this.actionsPanel.Controls.Add(this.viewThreadButton);
            this.actionsPanel.Controls.Add(this.deleteLink);
            this.actionsPanel.Controls.Add(this.muteButton);
            this.actionsPanel.Controls.Add(this.copyTextButton);
            this.actionsPanel.Controls.Add(this.shareButton);
            this.actionsPanel.Controls.Add(this.permalinkButton);
            this.actionsPanel.Controls.Add(this.openInBrowserButton);
            this.actionsPanel.Controls.Add(this.reportButton);
            this.actionsPanel.Controls.Add(this.collapseButton);
            this.actionsPanel.Controls.Add(this.lessLink);
            this.actionsPanel.Controls.Add(this.moreLink);
            this.actionsPanel.Location = new System.Drawing.Point(80, 76);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(815, 19);
            this.actionsPanel.TabIndex = 19;
            // 
            // replyClickCount
            // 
            this.replyClickCount.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.replyClickCount.AutoSize = true;
            this.replyClickCount.BackColor = System.Drawing.Color.Transparent;
            this.replyClickCount.LinkColor = System.Drawing.Color.DimGray;
            this.replyClickCount.Location = new System.Drawing.Point(3, 0);
            this.replyClickCount.Name = "replyClickCount";
            this.replyClickCount.Size = new System.Drawing.Size(29, 13);
            this.replyClickCount.TabIndex = 4;
            this.replyClickCount.TabStop = true;
            this.replyClickCount.Text = "reply";
            this.replyClickCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.replyClickCount_LinkClicked);
            // 
            // repostClickCount
            // 
            this.repostClickCount.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.repostClickCount.AutoSize = true;
            this.repostClickCount.BackColor = System.Drawing.Color.Transparent;
            this.repostClickCount.LinkColor = System.Drawing.Color.DimGray;
            this.repostClickCount.Location = new System.Drawing.Point(38, 0);
            this.repostClickCount.Name = "repostClickCount";
            this.repostClickCount.Size = new System.Drawing.Size(36, 13);
            this.repostClickCount.TabIndex = 3;
            this.repostClickCount.TabStop = true;
            this.repostClickCount.Text = "repost";
            this.repostClickCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.repostClickCount_LinkClicked);
            // 
            // quoteClickCount
            // 
            this.quoteClickCount.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.quoteClickCount.AutoSize = true;
            this.quoteClickCount.BackColor = System.Drawing.Color.Transparent;
            this.quoteClickCount.LinkColor = System.Drawing.Color.DimGray;
            this.quoteClickCount.Location = new System.Drawing.Point(80, 0);
            this.quoteClickCount.Name = "quoteClickCount";
            this.quoteClickCount.Size = new System.Drawing.Size(34, 13);
            this.quoteClickCount.TabIndex = 5;
            this.quoteClickCount.TabStop = true;
            this.quoteClickCount.Text = "quote";
            this.quoteClickCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quoteClickCount_LinkClicked);
            // 
            // bookmarkClickCount
            // 
            this.bookmarkClickCount.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.bookmarkClickCount.AutoSize = true;
            this.bookmarkClickCount.BackColor = System.Drawing.Color.Transparent;
            this.bookmarkClickCount.LinkColor = System.Drawing.Color.DimGray;
            this.bookmarkClickCount.Location = new System.Drawing.Point(120, 0);
            this.bookmarkClickCount.Name = "bookmarkClickCount";
            this.bookmarkClickCount.Size = new System.Drawing.Size(54, 13);
            this.bookmarkClickCount.TabIndex = 21;
            this.bookmarkClickCount.TabStop = true;
            this.bookmarkClickCount.Text = "bookmark";
            // 
            // viewThreadButton
            // 
            this.viewThreadButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.viewThreadButton.AutoSize = true;
            this.viewThreadButton.BackColor = System.Drawing.Color.Transparent;
            this.viewThreadButton.LinkColor = System.Drawing.Color.DimGray;
            this.viewThreadButton.Location = new System.Drawing.Point(180, 0);
            this.viewThreadButton.Name = "viewThreadButton";
            this.viewThreadButton.Size = new System.Drawing.Size(62, 13);
            this.viewThreadButton.TabIndex = 16;
            this.viewThreadButton.TabStop = true;
            this.viewThreadButton.Text = "view thread";
            this.viewThreadButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.viewThreadButton_LinkClicked);
            // 
            // deleteLink
            // 
            this.deleteLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.deleteLink.AutoSize = true;
            this.deleteLink.BackColor = System.Drawing.Color.Transparent;
            this.deleteLink.LinkColor = System.Drawing.Color.Firebrick;
            this.deleteLink.Location = new System.Drawing.Point(248, 0);
            this.deleteLink.Name = "deleteLink";
            this.deleteLink.Size = new System.Drawing.Size(36, 13);
            this.deleteLink.TabIndex = 20;
            this.deleteLink.TabStop = true;
            this.deleteLink.Text = "delete";
            this.deleteLink.Visible = false;
            this.deleteLink.VisitedLinkColor = System.Drawing.Color.Firebrick;
            this.deleteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteLink_LinkClicked);
            // 
            // muteButton
            // 
            this.muteButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.muteButton.AutoSize = true;
            this.muteButton.BackColor = System.Drawing.Color.Transparent;
            this.muteButton.LinkColor = System.Drawing.Color.DimGray;
            this.muteButton.Location = new System.Drawing.Point(290, 0);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(63, 13);
            this.muteButton.TabIndex = 9;
            this.muteButton.TabStop = true;
            this.muteButton.Text = "mute thread";
            this.muteButton.Visible = false;
            this.muteButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.muteButton_LinkClicked);
            // 
            // copyTextButton
            // 
            this.copyTextButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.copyTextButton.AutoSize = true;
            this.copyTextButton.BackColor = System.Drawing.Color.Transparent;
            this.copyTextButton.LinkColor = System.Drawing.Color.DimGray;
            this.copyTextButton.Location = new System.Drawing.Point(359, 0);
            this.copyTextButton.Name = "copyTextButton";
            this.copyTextButton.Size = new System.Drawing.Size(50, 13);
            this.copyTextButton.TabIndex = 7;
            this.copyTextButton.TabStop = true;
            this.copyTextButton.Text = "copy text";
            this.copyTextButton.Visible = false;
            this.copyTextButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyTextButton_LinkClicked);
            // 
            // shareButton
            // 
            this.shareButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.shareButton.AutoSize = true;
            this.shareButton.BackColor = System.Drawing.Color.Transparent;
            this.shareButton.LinkColor = System.Drawing.Color.DimGray;
            this.shareButton.Location = new System.Drawing.Point(415, 0);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(33, 13);
            this.shareButton.TabIndex = 6;
            this.shareButton.TabStop = true;
            this.shareButton.Text = "share";
            this.shareButton.Visible = false;
            this.shareButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.shareButton_LinkClicked);
            // 
            // permalinkButton
            // 
            this.permalinkButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.permalinkButton.AutoSize = true;
            this.permalinkButton.BackColor = System.Drawing.Color.Transparent;
            this.permalinkButton.LinkColor = System.Drawing.Color.DimGray;
            this.permalinkButton.Location = new System.Drawing.Point(454, 0);
            this.permalinkButton.Name = "permalinkButton";
            this.permalinkButton.Size = new System.Drawing.Size(52, 13);
            this.permalinkButton.TabIndex = 8;
            this.permalinkButton.TabStop = true;
            this.permalinkButton.Text = "permalink";
            this.permalinkButton.Visible = false;
            this.permalinkButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.permalinkButton_LinkClicked);
            // 
            // openInBrowserButton
            // 
            this.openInBrowserButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.openInBrowserButton.AutoSize = true;
            this.openInBrowserButton.BackColor = System.Drawing.Color.Transparent;
            this.openInBrowserButton.LinkColor = System.Drawing.Color.DimGray;
            this.openInBrowserButton.Location = new System.Drawing.Point(512, 0);
            this.openInBrowserButton.Name = "openInBrowserButton";
            this.openInBrowserButton.Size = new System.Drawing.Size(82, 13);
            this.openInBrowserButton.TabIndex = 17;
            this.openInBrowserButton.TabStop = true;
            this.openInBrowserButton.Text = "open in browser";
            this.openInBrowserButton.Visible = false;
            this.openInBrowserButton.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.openInBrowserButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openInBrowserButton_LinkClicked);
            // 
            // reportButton
            // 
            this.reportButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.reportButton.AutoSize = true;
            this.reportButton.BackColor = System.Drawing.Color.Transparent;
            this.reportButton.LinkColor = System.Drawing.Color.DimGray;
            this.reportButton.Location = new System.Drawing.Point(600, 0);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(34, 13);
            this.reportButton.TabIndex = 10;
            this.reportButton.TabStop = true;
            this.reportButton.Text = "report";
            this.reportButton.Visible = false;
            this.reportButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reportButton_LinkClicked);
            // 
            // collapseButton
            // 
            this.collapseButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.collapseButton.AutoSize = true;
            this.collapseButton.BackColor = System.Drawing.Color.Transparent;
            this.collapseButton.LinkColor = System.Drawing.Color.DimGray;
            this.collapseButton.Location = new System.Drawing.Point(640, 0);
            this.collapseButton.Name = "collapseButton";
            this.collapseButton.Size = new System.Drawing.Size(69, 13);
            this.collapseButton.TabIndex = 13;
            this.collapseButton.TabStop = true;
            this.collapseButton.Text = "collapse post";
            this.collapseButton.Visible = false;
            this.collapseButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.collapseButton_LinkClicked);
            // 
            // lessLink
            // 
            this.lessLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.lessLink.AutoSize = true;
            this.lessLink.BackColor = System.Drawing.Color.Transparent;
            this.lessLink.LinkColor = System.Drawing.Color.DimGray;
            this.lessLink.Location = new System.Drawing.Point(715, 0);
            this.lessLink.Name = "lessLink";
            this.lessLink.Size = new System.Drawing.Size(25, 13);
            this.lessLink.TabIndex = 18;
            this.lessLink.TabStop = true;
            this.lessLink.Text = "less";
            this.lessLink.Visible = false;
            this.lessLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lessLink_LinkClicked);
            // 
            // moreLink
            // 
            this.moreLink.ActiveLinkColor = System.Drawing.Color.DarkCyan;
            this.moreLink.AutoSize = true;
            this.moreLink.BackColor = System.Drawing.Color.Transparent;
            this.moreLink.LinkColor = System.Drawing.Color.DimGray;
            this.moreLink.Location = new System.Drawing.Point(746, 0);
            this.moreLink.Name = "moreLink";
            this.moreLink.Size = new System.Drawing.Size(30, 13);
            this.moreLink.TabIndex = 19;
            this.moreLink.TabStop = true;
            this.moreLink.Text = "more";
            this.moreLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.moreLink_LinkClicked);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.posterName);
            this.flowLayoutPanel2.Controls.Add(this.posterHandle);
            this.flowLayoutPanel2.Controls.Add(this.timeAgo);
            this.flowLayoutPanel2.Controls.Add(this.replyLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(77, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(566, 16);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // posterName
            // 
            this.posterName.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.posterName.AutoSize = true;
            this.posterName.BackColor = System.Drawing.Color.Transparent;
            this.posterName.LinkColor = System.Drawing.Color.SteelBlue;
            this.posterName.Location = new System.Drawing.Point(3, 0);
            this.posterName.Name = "posterName";
            this.posterName.Size = new System.Drawing.Size(57, 13);
            this.posterName.TabIndex = 18;
            this.posterName.TabStop = true;
            this.posterName.Text = "FanTAStic";
            this.posterName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.posterName_LinkClicked);
            // 
            // posterHandle
            // 
            this.posterHandle.AutoSize = true;
            this.posterHandle.ForeColor = System.Drawing.Color.Black;
            this.posterHandle.Location = new System.Drawing.Point(63, 0);
            this.posterHandle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.posterHandle.Name = "posterHandle";
            this.posterHandle.Size = new System.Drawing.Size(110, 13);
            this.posterHandle.TabIndex = 20;
            this.posterHandle.Text = "@fantasia.bsky.social";
            // 
            // replyLabel
            // 
            this.replyLabel.AutoSize = true;
            this.replyLabel.Enabled = false;
            this.replyLabel.ForeColor = System.Drawing.Color.DimGray;
            this.replyLabel.Location = new System.Drawing.Point(245, 0);
            this.replyLabel.Name = "replyLabel";
            this.replyLabel.Size = new System.Drawing.Size(152, 13);
            this.replyLabel.TabIndex = 19;
            this.replyLabel.Text = "(replying to historia.bsky.social)";
            this.replyLabel.Visible = false;
            // 
            // expandImageButton
            // 
            this.expandImageButton.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            this.expandImageButton.BackColor = System.Drawing.Color.Transparent;
            this.expandImageButton.LinkColor = System.Drawing.Color.SteelBlue;
            this.expandImageButton.Location = new System.Drawing.Point(905, 76);
            this.expandImageButton.Name = "expandImageButton";
            this.expandImageButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.expandImageButton.Size = new System.Drawing.Size(100, 13);
            this.expandImageButton.TabIndex = 14;
            this.expandImageButton.TabStop = true;
            this.expandImageButton.Text = "expand";
            this.expandImageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.expandImageButton.Visible = false;
            this.expandImageButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.expandImageButton_LinkClicked);
            // 
            // TweetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cerulean.CeruleanArt.pinstripesblue;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.actionsPanel);
            this.Controls.Add(this.postImage);
            this.Controls.Add(this.expandImageButton);
            this.Controls.Add(this.likeCountLabel);
            this.Controls.Add(this.likeButton);
            this.Controls.Add(this.postText);
            this.Name = "TweetControl";
            this.Size = new System.Drawing.Size(1024, 98);
            this.Load += new System.EventHandler(this.TweetControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.likeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postImage)).EndInit();
            this.actionsPanel.ResumeLayout(false);
            this.actionsPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel postText;
        private System.Windows.Forms.PictureBox likeButton;
        private System.Windows.Forms.Label likeCountLabel;
        private Cerulean.LinkButton repostClickCount;
        private Cerulean.LinkButton replyClickCount;
        private Cerulean.LinkButton quoteClickCount;
        private Cerulean.LinkButton shareButton;
        private Cerulean.LinkButton copyTextButton;
        private Cerulean.LinkButton permalinkButton;
        private Cerulean.LinkButton muteButton;
        private Cerulean.LinkButton reportButton;
        private Cerulean.LinkButton collapseButton;
        private Cerulean.LinkButton expandImageButton;
        private System.Windows.Forms.Label timeAgo;
        private Cerulean.LinkButton viewThreadButton;
        private System.Windows.Forms.PictureBox postImage;
        private Cerulean.LinkButton posterName;
        private System.Windows.Forms.FlowLayoutPanel actionsPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Cerulean.LinkButton openInBrowserButton;
        private System.Windows.Forms.Label replyLabel;
        private System.Windows.Forms.Label posterHandle;
        private LinkButton lessLink;
        private LinkButton moreLink;
        private LinkButton deleteLink;
        private LinkButton bookmarkClickCount;
    }
}
