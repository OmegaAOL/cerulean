namespace Cerulean
{
    partial class Menu_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Login));
            this.timeOutBar = new System.Windows.Forms.ProgressBar();
            this.header = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.descriptor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.handleBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.rememberMeBox = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.changePdsHostButton = new System.Windows.Forms.Button();
            this.setupTotpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timeOutBar
            // 
            this.timeOutBar.Location = new System.Drawing.Point(0, 132);
            this.timeOutBar.MarqueeAnimationSpeed = 0;
            this.timeOutBar.Name = "timeOutBar";
            this.timeOutBar.Size = new System.Drawing.Size(600, 12);
            this.timeOutBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.timeOutBar.TabIndex = 1;
            this.timeOutBar.Click += new System.EventHandler(this.timeOutBar_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.SystemColors.Highlight;
            this.header.Location = new System.Drawing.Point(16, 160);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(162, 18);
            this.header.TabIndex = 2;
            this.header.Text = "Welcome to Cerulean.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cerulean.CeruleanArt.banner_600wide;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // descriptor
            // 
            this.descriptor.AutoSize = true;
            this.descriptor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.descriptor.Location = new System.Drawing.Point(17, 180);
            this.descriptor.Name = "descriptor";
            this.descriptor.Size = new System.Drawing.Size(355, 13);
            this.descriptor.TabIndex = 6;
            this.descriptor.Text = "Please sign in with your Bluesky account. App password is recommended.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(40, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bluesky handle";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(66, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handleBox
            // 
            this.handleBox.Location = new System.Drawing.Point(125, 221);
            this.handleBox.Name = "handleBox";
            this.handleBox.Size = new System.Drawing.Size(416, 20);
            this.handleBox.TabIndex = 9;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(125, 247);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(416, 20);
            this.passwordBox.TabIndex = 10;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // rememberMeBox
            // 
            this.rememberMeBox.AutoSize = true;
            this.rememberMeBox.Checked = true;
            this.rememberMeBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rememberMeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rememberMeBox.Location = new System.Drawing.Point(500, 287);
            this.rememberMeBox.Name = "rememberMeBox";
            this.rememberMeBox.Size = new System.Drawing.Size(100, 18);
            this.rememberMeBox.TabIndex = 11;
            this.rememberMeBox.Text = "Remember me";
            this.rememberMeBox.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loginButton.Location = new System.Drawing.Point(513, 311);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // changePdsHostButton
            // 
            this.changePdsHostButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.changePdsHostButton.Location = new System.Drawing.Point(394, 311);
            this.changePdsHostButton.Name = "changePdsHostButton";
            this.changePdsHostButton.Size = new System.Drawing.Size(113, 23);
            this.changePdsHostButton.TabIndex = 4;
            this.changePdsHostButton.Text = "Change PDS Host";
            this.changePdsHostButton.UseVisualStyleBackColor = true;
            this.changePdsHostButton.Click += new System.EventHandler(this.changePdsHostButton_Click);
            // 
            // setupTotpButton
            // 
            this.setupTotpButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setupTotpButton.Location = new System.Drawing.Point(12, 311);
            this.setupTotpButton.Name = "setupTotpButton";
            this.setupTotpButton.Size = new System.Drawing.Size(173, 23);
            this.setupTotpButton.TabIndex = 5;
            this.setupTotpButton.Text = "Configure TOTP Authentication";
            this.setupTotpButton.UseVisualStyleBackColor = true;
            this.setupTotpButton.Click += new System.EventHandler(this.setupTotpButton_Click);
            // 
            // Menu_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 346);
            this.Controls.Add(this.rememberMeBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.handleBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descriptor);
            this.Controls.Add(this.setupTotpButton);
            this.Controls.Add(this.changePdsHostButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.header);
            this.Controls.Add(this.timeOutBar);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_Login";
            this.Text = "Cerulean Login";
            this.Load += new System.EventHandler(this.Menu_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar timeOutBar;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label descriptor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox handleBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.CheckBox rememberMeBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button changePdsHostButton;
        private System.Windows.Forms.Button setupTotpButton;
    }
}

