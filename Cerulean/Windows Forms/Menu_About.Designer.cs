namespace Cerulean
{
    partial class Menu_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_About));
            this.par1 = new System.Windows.Forms.Label();
            this.followOmegaButton = new System.Windows.Forms.Button();
            this.postAbtCerulean = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // par1
            // 
            this.par1.AutoSize = true;
            this.par1.Location = new System.Drawing.Point(12, 188);
            this.par1.Name = "par1";
            this.par1.Size = new System.Drawing.Size(705, 182);
            this.par1.TabIndex = 1;
            this.par1.Text = resources.GetString("par1.Text");
            // 
            // followOmegaButton
            // 
            this.followOmegaButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.followOmegaButton.Location = new System.Drawing.Point(469, 352);
            this.followOmegaButton.Name = "followOmegaButton";
            this.followOmegaButton.Size = new System.Drawing.Size(85, 23);
            this.followOmegaButton.TabIndex = 2;
            this.followOmegaButton.Text = "Follow me";
            this.followOmegaButton.UseVisualStyleBackColor = true;
            this.followOmegaButton.Click += new System.EventHandler(this.followOmegaButton_Click);
            // 
            // postAbtCerulean
            // 
            this.postAbtCerulean.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.postAbtCerulean.Location = new System.Drawing.Point(560, 352);
            this.postAbtCerulean.Name = "postAbtCerulean";
            this.postAbtCerulean.Size = new System.Drawing.Size(126, 23);
            this.postAbtCerulean.TabIndex = 3;
            this.postAbtCerulean.Text = "Post about Cerulean";
            this.postAbtCerulean.UseVisualStyleBackColor = true;
            this.postAbtCerulean.Click += new System.EventHandler(this.postAbtCerulean_Click);
            // 
            // donateButton
            // 
            this.donateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.donateButton.Location = new System.Drawing.Point(692, 352);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(85, 23);
            this.donateButton.TabIndex = 4;
            this.donateButton.Text = "Donate!";
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cerulean.CeruleanArt.banner_default_moretrans;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 178);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Menu_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(789, 387);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.postAbtCerulean);
            this.Controls.Add(this.followOmegaButton);
            this.Controls.Add(this.par1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_About";
            this.Text = "About Cerulean";
            this.Load += new System.EventHandler(this.Menu_About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label par1;
        private System.Windows.Forms.Button followOmegaButton;
        private System.Windows.Forms.Button postAbtCerulean;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}