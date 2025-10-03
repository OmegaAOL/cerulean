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
            this.regInstallUpdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dsBox = new System.Windows.Forms.TextBox();
            this.okButton = new Cerulean.CeruleanButton();
            this.applyButton = new Cerulean.CeruleanButton();
            this.dsLabel = new System.Windows.Forms.Label();
            this.dsUseForQuickPost = new System.Windows.Forms.CheckBox();
            this.Settings = new System.Windows.Forms.TabControl();
            this.updatesPage = new System.Windows.Forms.TabPage();
            this.currentVersion = new System.Windows.Forms.Label();
            this.latestVersion = new System.Windows.Forms.Label();
            this.updateCheckButton = new System.Windows.Forms.Button();
            this.dsPage = new System.Windows.Forms.TabPage();
            this.themePage = new System.Windows.Forms.TabPage();
            this.ceruleanButton1 = new Cerulean.CeruleanButton();
            this.Settings.SuspendLayout();
            this.updatesPage.SuspendLayout();
            this.dsPage.SuspendLayout();
            this.SuspendLayout();
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
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unlike Bluesky, Cerulean allows you to set a digital signature.\r\n\r\n\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dsBox
            // 
            this.dsBox.Location = new System.Drawing.Point(9, 34);
            this.dsBox.Multiline = true;
            this.dsBox.Name = "dsBox";
            this.dsBox.Size = new System.Drawing.Size(291, 111);
            this.dsBox.TabIndex = 5;
            this.dsBox.TextChanged += new System.EventHandler(this.dsBox_TextChanged);
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(95, 345);
            this.okButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.dsResetButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.AutoSize = true;
            this.applyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyButton.BackColor = System.Drawing.Color.Transparent;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(257, 345);
            this.applyButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.applyButton.Name = "applyButton";
            this.applyButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.dsApplyButton_Click);
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
            this.dsUseForQuickPost.BackColor = System.Drawing.Color.Transparent;
            this.dsUseForQuickPost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dsUseForQuickPost.Location = new System.Drawing.Point(95, 151);
            this.dsUseForQuickPost.Name = "dsUseForQuickPost";
            this.dsUseForQuickPost.Size = new System.Drawing.Size(215, 18);
            this.dsUseForQuickPost.TabIndex = 10;
            this.dsUseForQuickPost.Text = "Enable Digital Signature for Quick Post";
            this.dsUseForQuickPost.UseVisualStyleBackColor = false;
            this.dsUseForQuickPost.CheckedChanged += new System.EventHandler(this.dsUseForQuickPost_CheckedChanged);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.updatesPage);
            this.Settings.Controls.Add(this.dsPage);
            this.Settings.Controls.Add(this.themePage);
            this.Settings.Location = new System.Drawing.Point(12, 12);
            this.Settings.Name = "Settings";
            this.Settings.SelectedIndex = 0;
            this.Settings.Size = new System.Drawing.Size(324, 327);
            this.Settings.TabIndex = 11;
            // 
            // updatesPage
            // 
            this.updatesPage.Controls.Add(this.currentVersion);
            this.updatesPage.Controls.Add(this.latestVersion);
            this.updatesPage.Controls.Add(this.updateCheckButton);
            this.updatesPage.Location = new System.Drawing.Point(4, 22);
            this.updatesPage.Name = "updatesPage";
            this.updatesPage.Padding = new System.Windows.Forms.Padding(3);
            this.updatesPage.Size = new System.Drawing.Size(316, 301);
            this.updatesPage.TabIndex = 0;
            this.updatesPage.Text = "Placeholder text";
            this.updatesPage.UseVisualStyleBackColor = true;
            this.updatesPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.Location = new System.Drawing.Point(18, 18);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(124, 13);
            this.currentVersion.TabIndex = 2;
            this.currentVersion.Text = "Placeholder text";
            // 
            // latestVersion
            // 
            this.latestVersion.AutoSize = true;
            this.latestVersion.Location = new System.Drawing.Point(18, 40);
            this.latestVersion.Name = "latestVersion";
            this.latestVersion.Size = new System.Drawing.Size(124, 13);
            this.latestVersion.TabIndex = 1;
            this.latestVersion.Text = "Placeholder text";
            // 
            // updateCheckButton
            // 
            this.updateCheckButton.AutoSize = true;
            this.updateCheckButton.Location = new System.Drawing.Point(21, 60);
            this.updateCheckButton.Name = "updateCheckButton";
            this.updateCheckButton.Size = new System.Drawing.Size(134, 23);
            this.updateCheckButton.TabIndex = 0;
            this.updateCheckButton.Text = "Placeholder text";
            this.updateCheckButton.UseVisualStyleBackColor = true;
            this.updateCheckButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dsPage
            // 
            this.dsPage.Controls.Add(this.dsUseForQuickPost);
            this.dsPage.Controls.Add(this.dsBox);
            this.dsPage.Controls.Add(this.label2);
            this.dsPage.Location = new System.Drawing.Point(4, 22);
            this.dsPage.Name = "dsPage";
            this.dsPage.Padding = new System.Windows.Forms.Padding(3);
            this.dsPage.Size = new System.Drawing.Size(316, 301);
            this.dsPage.TabIndex = 1;
            this.dsPage.Text = "Placeholder text";
            this.dsPage.UseVisualStyleBackColor = true;
            // 
            // themePage
            // 
            this.themePage.Location = new System.Drawing.Point(4, 22);
            this.themePage.Name = "themePage";
            this.themePage.Padding = new System.Windows.Forms.Padding(3);
            this.themePage.Size = new System.Drawing.Size(316, 301);
            this.themePage.TabIndex = 2;
            this.themePage.Text = "Placeholder text";
            this.themePage.UseVisualStyleBackColor = true;
            // 
            // ceruleanButton1
            // 
            this.ceruleanButton1.AutoSize = true;
            this.ceruleanButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ceruleanButton1.BackColor = System.Drawing.Color.Transparent;
            this.ceruleanButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ceruleanButton1.Location = new System.Drawing.Point(176, 345);
            this.ceruleanButton1.MinimumSize = new System.Drawing.Size(75, 23);
            this.ceruleanButton1.Name = "ceruleanButton1";
            this.ceruleanButton1.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.ceruleanButton1.Size = new System.Drawing.Size(75, 23);
            this.ceruleanButton1.TabIndex = 12;
            this.ceruleanButton1.Text = "Cancel";
            this.ceruleanButton1.UseVisualStyleBackColor = false;
            // 
            // Menu_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ThemeDefinitions.Background;
            this.ClientSize = new System.Drawing.Size(351, 380);
            this.Controls.Add(this.ceruleanButton1);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.dsLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.regInstallUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Settings";
            this.Text = "Placeholder text";
            this.Load += new System.EventHandler(this.Menu_Settings_Load);
            this.Settings.ResumeLayout(false);
            this.updatesPage.ResumeLayout(false);
            this.updatesPage.PerformLayout();
            this.dsPage.ResumeLayout(false);
            this.dsPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label regInstallUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dsBox;
        private Cerulean.CeruleanButton okButton;
        private Cerulean.CeruleanButton applyButton;
        private System.Windows.Forms.Label dsLabel;
        private System.Windows.Forms.CheckBox dsUseForQuickPost;
        private System.Windows.Forms.TabControl Settings;
        private System.Windows.Forms.TabPage updatesPage;
        private System.Windows.Forms.TabPage dsPage;
        private CeruleanButton ceruleanButton1;
        private System.Windows.Forms.TabPage themePage;
        private System.Windows.Forms.Button updateCheckButton;
        private System.Windows.Forms.Label currentVersion;
        private System.Windows.Forms.Label latestVersion;
    }
}