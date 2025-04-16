namespace Cerulean
{
    partial class Menu_Tweet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Tweet));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tweetButton = new System.Windows.Forms.Button();
            this.draftButton = new System.Windows.Forms.Button();
            this.mediaUploadButton = new System.Windows.Forms.Button();
            this.tweetBox = new System.Windows.Forms.TextBox();
            this.enableDSCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(462, 16);
            this.progressBar1.TabIndex = 2;
            // 
            // tweetButton
            // 
            this.tweetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tweetButton.Location = new System.Drawing.Point(372, 225);
            this.tweetButton.Name = "tweetButton";
            this.tweetButton.Size = new System.Drawing.Size(75, 23);
            this.tweetButton.TabIndex = 3;
            this.tweetButton.Text = "Post";
            this.tweetButton.UseVisualStyleBackColor = true;
            this.tweetButton.Click += new System.EventHandler(this.tweetButton_Click);
            // 
            // draftButton
            // 
            this.draftButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.draftButton.Location = new System.Drawing.Point(273, 225);
            this.draftButton.Name = "draftButton";
            this.draftButton.Size = new System.Drawing.Size(93, 23);
            this.draftButton.TabIndex = 4;
            this.draftButton.Text = "Save as Draft";
            this.draftButton.UseVisualStyleBackColor = true;
            this.draftButton.Click += new System.EventHandler(this.draftButton_Click);
            // 
            // mediaUploadButton
            // 
            this.mediaUploadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mediaUploadButton.Location = new System.Drawing.Point(15, 225);
            this.mediaUploadButton.Name = "mediaUploadButton";
            this.mediaUploadButton.Size = new System.Drawing.Size(95, 23);
            this.mediaUploadButton.TabIndex = 5;
            this.mediaUploadButton.Text = "Upload media";
            this.mediaUploadButton.UseVisualStyleBackColor = true;
            this.mediaUploadButton.Click += new System.EventHandler(this.mediaUploadButton_Click);
            // 
            // tweetBox
            // 
            this.tweetBox.Location = new System.Drawing.Point(15, 67);
            this.tweetBox.Multiline = true;
            this.tweetBox.Name = "tweetBox";
            this.tweetBox.Size = new System.Drawing.Size(432, 127);
            this.tweetBox.TabIndex = 6;
            this.tweetBox.TextChanged += new System.EventHandler(this.tweetBox_TextChanged);
            // 
            // enableDSCheckBox
            // 
            this.enableDSCheckBox.AutoSize = true;
            this.enableDSCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableDSCheckBox.Location = new System.Drawing.Point(322, 202);
            this.enableDSCheckBox.Name = "enableDSCheckBox";
            this.enableDSCheckBox.Size = new System.Drawing.Size(131, 18);
            this.enableDSCheckBox.TabIndex = 7;
            this.enableDSCheckBox.Text = "Add Digital Signature";
            this.enableDSCheckBox.UseVisualStyleBackColor = true;
            // 
            // Menu_Tweet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(462, 270);
            this.Controls.Add(this.enableDSCheckBox);
            this.Controls.Add(this.tweetBox);
            this.Controls.Add(this.mediaUploadButton);
            this.Controls.Add(this.draftButton);
            this.Controls.Add(this.tweetButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Tweet";
            this.Text = "Compose new post";
            this.Load += new System.EventHandler(this.Menu_Tweet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button tweetButton;
        private System.Windows.Forms.Button draftButton;
        private System.Windows.Forms.Button mediaUploadButton;
        private System.Windows.Forms.TextBox tweetBox;
        private System.Windows.Forms.CheckBox enableDSCheckBox;
    }
}