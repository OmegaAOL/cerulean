namespace Cerulean
{
    partial class Menu_FeedSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_FeedSelector));
            this.description = new System.Windows.Forms.Label();
            this.selectFeedButton = new Cerulean.CeruleanButton();
            this.timelineButton = new Cerulean.CeruleanButton();
            this.feedList = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new Cerulean.CeruleanButton();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Location = new System.Drawing.Point(13, 13);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(362, 13);
            this.description.TabIndex = 0;
            this.description.Text = "You may choose a feed to view, or choose \"Timeline\" to view your timeline.";
            // 
            // selectFeedButton
            // 
            this.selectFeedButton.AutoSize = true;
            this.selectFeedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectFeedButton.BackColor = System.Drawing.Color.Transparent;
            this.selectFeedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectFeedButton.Location = new System.Drawing.Point(535, 210);
            this.selectFeedButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.selectFeedButton.Name = "selectFeedButton";
            this.selectFeedButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.selectFeedButton.Size = new System.Drawing.Size(89, 23);
            this.selectFeedButton.TabIndex = 5;
            this.selectFeedButton.Text = "Select Feed";
            this.selectFeedButton.UseVisualStyleBackColor = false;
            this.selectFeedButton.Click += new System.EventHandler(this.FetchButton_Click);
            // 
            // timelineButton
            // 
            this.timelineButton.AutoSize = true;
            this.timelineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timelineButton.BackColor = System.Drawing.Color.Transparent;
            this.timelineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timelineButton.Location = new System.Drawing.Point(454, 210);
            this.timelineButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.timelineButton.Name = "timelineButton";
            this.timelineButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.timelineButton.Size = new System.Drawing.Size(75, 23);
            this.timelineButton.TabIndex = 6;
            this.timelineButton.Text = "Timeline";
            this.timelineButton.UseMnemonic = false;
            this.timelineButton.UseVisualStyleBackColor = false;
            this.timelineButton.Click += new System.EventHandler(this.buttonFollowingFeed_Click);
            // 
            // feedList
            // 
            this.feedList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.feedList.BackgroundImageTiled = true;
            this.feedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feedList.Location = new System.Drawing.Point(12, 40);
            this.feedList.Name = "feedList";
            this.feedList.Size = new System.Drawing.Size(612, 157);
            this.feedList.TabIndex = 9;
            this.feedList.UseCompatibleStateImageBehavior = false;
            this.feedList.View = System.Windows.Forms.View.Details;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-4, 244);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(645, 18);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(12, 210);
            this.button1.MinimumSize = new System.Drawing.Size(75, 23);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu_FeedSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.feedList);
            this.Controls.Add(this.timelineButton);
            this.Controls.Add(this.selectFeedButton);
            this.Controls.Add(this.description);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(652, 300);
            this.MinimumSize = new System.Drawing.Size(652, 300);
            this.Name = "Menu_FeedSelector";
            this.Text = "Cerulean.Placeholder";
            this.Load += new System.EventHandler(this.Menu_FeedSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label description;
        private Cerulean.CeruleanButton selectFeedButton;
        private Cerulean.CeruleanButton timelineButton;
        private System.Windows.Forms.ListView feedList;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Cerulean.CeruleanButton button1;
    }
}