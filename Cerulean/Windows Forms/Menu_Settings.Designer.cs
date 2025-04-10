namespace Cerulean
{
    partial class Menu_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.regInstallUpdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dsBox = new System.Windows.Forms.TextBox();
            this.dsResetButton = new System.Windows.Forms.Button();
            this.dsApplyButton = new System.Windows.Forms.Button();
            this.dsLabel = new System.Windows.Forms.Label();
            this.dsUseForQuickPost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(97, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reinstall Registry Keys";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.regInstallButton_Click);
            // 
            // regInstallUpdate
            // 
            this.regInstallUpdate.AutoSize = true;
            this.regInstallUpdate.Location = new System.Drawing.Point(15, 99);
            this.regInstallUpdate.Name = "regInstallUpdate";
            this.regInstallUpdate.Size = new System.Drawing.Size(0, 13);
            this.regInstallUpdate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unlike Bluesky, Cerulean allows you to set a digital signature.\r\n\r\n\r\n";
            // 
            // dsBox
            // 
            this.dsBox.Location = new System.Drawing.Point(15, 150);
            this.dsBox.Multiline = true;
            this.dsBox.Name = "dsBox";
            this.dsBox.Size = new System.Drawing.Size(317, 85);
            this.dsBox.TabIndex = 5;
            // 
            // dsResetButton
            // 
            this.dsResetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dsResetButton.Location = new System.Drawing.Point(256, 247);
            this.dsResetButton.Name = "dsResetButton";
            this.dsResetButton.Size = new System.Drawing.Size(75, 23);
            this.dsResetButton.TabIndex = 6;
            this.dsResetButton.Text = "Reset";
            this.dsResetButton.UseVisualStyleBackColor = true;
            this.dsResetButton.Click += new System.EventHandler(this.dsResetButton_Click);
            // 
            // dsApplyButton
            // 
            this.dsApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dsApplyButton.Location = new System.Drawing.Point(175, 247);
            this.dsApplyButton.Name = "dsApplyButton";
            this.dsApplyButton.Size = new System.Drawing.Size(75, 23);
            this.dsApplyButton.TabIndex = 7;
            this.dsApplyButton.Text = "Apply";
            this.dsApplyButton.UseVisualStyleBackColor = true;
            this.dsApplyButton.Click += new System.EventHandler(this.dsApplyButton_Click);
            // 
            // dsLabel
            // 
            this.dsLabel.AutoSize = true;
            this.dsLabel.Location = new System.Drawing.Point(15, 252);
            this.dsLabel.Name = "dsLabel";
            this.dsLabel.Size = new System.Drawing.Size(0, 13);
            this.dsLabel.TabIndex = 9;
            // 
            // dsUseForQuickPost
            // 
            this.dsUseForQuickPost.AutoSize = true;
            this.dsUseForQuickPost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dsUseForQuickPost.Location = new System.Drawing.Point(122, 276);
            this.dsUseForQuickPost.Name = "dsUseForQuickPost";
            this.dsUseForQuickPost.Size = new System.Drawing.Size(215, 18);
            this.dsUseForQuickPost.TabIndex = 10;
            this.dsUseForQuickPost.Text = "Enable Digital Signature for Quick Post";
            this.dsUseForQuickPost.UseVisualStyleBackColor = true;
            // 
            // Menu_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 301);
            this.Controls.Add(this.dsUseForQuickPost);
            this.Controls.Add(this.dsLabel);
            this.Controls.Add(this.dsApplyButton);
            this.Controls.Add(this.dsResetButton);
            this.Controls.Add(this.dsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regInstallUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Settings";
            this.Text = "Cerulean Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label regInstallUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dsBox;
        private System.Windows.Forms.Button dsResetButton;
        private System.Windows.Forms.Button dsApplyButton;
        private System.Windows.Forms.Label dsLabel;
        private System.Windows.Forms.CheckBox dsUseForQuickPost;
    }
}