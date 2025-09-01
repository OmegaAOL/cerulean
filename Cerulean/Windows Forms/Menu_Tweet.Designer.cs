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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tweetBox = new System.Windows.Forms.TextBox();
            this.spellingCheckBox = new System.Windows.Forms.CheckBox();
            this.ccText = new System.Windows.Forms.Label();
            this.mediaUploadButton = new Cerulean.CeruleanButton();
            this.draftButton = new Cerulean.CeruleanButton();
            this.tweetButton = new Cerulean.CeruleanButton();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 201);
            this.progressBar1.Maximum = 300;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(462, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // tweetBox
            // 
            this.tweetBox.BackColor = System.Drawing.SystemColors.Window;
            this.tweetBox.Location = new System.Drawing.Point(15, 14);
            this.tweetBox.Multiline = true;
            this.tweetBox.Name = "tweetBox";
            this.tweetBox.Size = new System.Drawing.Size(432, 127);
            this.tweetBox.TabIndex = 6;
            this.tweetBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tweetBox_KeyDown);
            // 
            // spellingCheckBox
            // 
            this.spellingCheckBox.AutoSize = true;
            this.spellingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.spellingCheckBox.Checked = true;
            this.spellingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spellingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.spellingCheckBox.Location = new System.Drawing.Point(361, 152);
            this.spellingCheckBox.Name = "spellingCheckBox";
            this.spellingCheckBox.Size = new System.Drawing.Size(101, 18);
            this.spellingCheckBox.TabIndex = 7;
            this.spellingCheckBox.Text = "Check spelling";
            this.spellingCheckBox.UseVisualStyleBackColor = false;
            // 
            // ccText
            // 
            this.ccText.AutoSize = true;
            this.ccText.BackColor = System.Drawing.Color.Transparent;
            this.ccText.Location = new System.Drawing.Point(15, 154);
            this.ccText.Name = "ccText";
            this.ccText.Size = new System.Drawing.Size(95, 13);
            this.ccText.TabIndex = 8;
            this.ccText.Text = "300 characters left";
            this.ccText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ccText.Click += new System.EventHandler(this.ccText_Click);
            // 
            // mediaUploadButton
            // 
            this.mediaUploadButton.AutoSize = true;
            this.mediaUploadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mediaUploadButton.BackColor = System.Drawing.Color.Transparent;
            this.mediaUploadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mediaUploadButton.Location = new System.Drawing.Point(15, 172);
            this.mediaUploadButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.mediaUploadButton.Name = "mediaUploadButton";
            this.mediaUploadButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.mediaUploadButton.Size = new System.Drawing.Size(97, 23);
            this.mediaUploadButton.TabIndex = 5;
            this.mediaUploadButton.Text = "Upload media";
            this.mediaUploadButton.UseVisualStyleBackColor = false;
            this.mediaUploadButton.Click += new System.EventHandler(this.mediaUploadButton_Click);
            // 
            // draftButton
            // 
            this.draftButton.AutoSize = true;
            this.draftButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draftButton.BackColor = System.Drawing.Color.Transparent;
            this.draftButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.draftButton.Location = new System.Drawing.Point(273, 172);
            this.draftButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.draftButton.Name = "draftButton";
            this.draftButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.draftButton.Size = new System.Drawing.Size(97, 23);
            this.draftButton.TabIndex = 4;
            this.draftButton.Text = "Save as Draft";
            this.draftButton.UseVisualStyleBackColor = false;
            this.draftButton.Click += new System.EventHandler(this.draftButton_Click);
            // 
            // tweetButton
            // 
            this.tweetButton.AutoSize = true;
            this.tweetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tweetButton.BackColor = System.Drawing.Color.Transparent;
            this.tweetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tweetButton.Location = new System.Drawing.Point(372, 172);
            this.tweetButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.tweetButton.Name = "tweetButton";
            this.tweetButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.tweetButton.Size = new System.Drawing.Size(75, 23);
            this.tweetButton.TabIndex = 3;
            this.tweetButton.Text = "Post";
            this.tweetButton.UseVisualStyleBackColor = false;
            this.tweetButton.Click += new System.EventHandler(this.tweetButton_Click);
            // 
            // Menu_Tweet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 217);
            this.Controls.Add(this.ccText);
            this.Controls.Add(this.spellingCheckBox);
            this.Controls.Add(this.tweetBox);
            this.Controls.Add(this.mediaUploadButton);
            this.Controls.Add(this.draftButton);
            this.Controls.Add(this.tweetButton);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Tweet";
            this.Text = "Compose new post";
            this.Load += new System.EventHandler(this.Menu_Tweet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private Cerulean.CeruleanButton tweetButton;
        private Cerulean.CeruleanButton draftButton;
        private Cerulean.CeruleanButton mediaUploadButton;
        private System.Windows.Forms.TextBox tweetBox;
        private System.Windows.Forms.CheckBox spellingCheckBox;
        private System.Windows.Forms.Label ccText;
    }
}