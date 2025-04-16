namespace Cerulean.Windows_Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.plcBox = new System.Windows.Forms.TextBox();
            this.feedBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCustomFeed = new System.Windows.Forms.Button();
            this.buttonFollowingFeed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "You may choose a feed to view, or choose \"Following\"\r\nfor the default Bluesky Fol" +
                "lowing feed.";
            // 
            // plcBox
            // 
            this.plcBox.Location = new System.Drawing.Point(80, 62);
            this.plcBox.Name = "plcBox";
            this.plcBox.Size = new System.Drawing.Size(205, 20);
            this.plcBox.TabIndex = 1;
            // 
            // feedBox
            // 
            this.feedBox.Location = new System.Drawing.Point(80, 88);
            this.feedBox.Name = "feedBox";
            this.feedBox.Size = new System.Drawing.Size(205, 20);
            this.feedBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PLC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Feed Name";
            // 
            // buttonCustomFeed
            // 
            this.buttonCustomFeed.Location = new System.Drawing.Point(210, 126);
            this.buttonCustomFeed.Name = "buttonCustomFeed";
            this.buttonCustomFeed.Size = new System.Drawing.Size(75, 23);
            this.buttonCustomFeed.TabIndex = 5;
            this.buttonCustomFeed.Text = "OK";
            this.buttonCustomFeed.UseVisualStyleBackColor = true;
            this.buttonCustomFeed.Click += new System.EventHandler(this.buttonCustomFeed_Click);
            // 
            // buttonFollowingFeed
            // 
            this.buttonFollowingFeed.Location = new System.Drawing.Point(129, 126);
            this.buttonFollowingFeed.Name = "buttonFollowingFeed";
            this.buttonFollowingFeed.Size = new System.Drawing.Size(75, 23);
            this.buttonFollowingFeed.TabIndex = 6;
            this.buttonFollowingFeed.Text = "Following";
            this.buttonFollowingFeed.UseMnemonic = false;
            this.buttonFollowingFeed.UseVisualStyleBackColor = true;
            this.buttonFollowingFeed.Click += new System.EventHandler(this.buttonFollowingFeed_Click);
            // 
            // Menu_FeedSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(300, 161);
            this.Controls.Add(this.buttonFollowingFeed);
            this.Controls.Add(this.buttonCustomFeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.feedBox);
            this.Controls.Add(this.plcBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_FeedSelector";
            this.Text = "Feed Selector";
            this.Load += new System.EventHandler(this.Menu_FeedSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox plcBox;
        private System.Windows.Forms.TextBox feedBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCustomFeed;
        private System.Windows.Forms.Button buttonFollowingFeed;
    }
}