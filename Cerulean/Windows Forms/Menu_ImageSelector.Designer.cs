namespace Cerulean
{
    partial class Menu_ImageSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_ImageSelector));
            this.addPictureText = new System.Windows.Forms.Label();
            this.okButton = new Cerulean.CeruleanButton();
            this.cancelButton = new Cerulean.CeruleanButton();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.altTextBox = new System.Windows.Forms.TextBox();
            this.picBox = new Cerulean.BorderPicBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addPictureText
            // 
            this.addPictureText.AutoSize = true;
            this.addPictureText.BackColor = System.Drawing.Color.Transparent;
            this.addPictureText.Location = new System.Drawing.Point(12, 12);
            this.addPictureText.Margin = new System.Windows.Forms.Padding(0);
            this.addPictureText.Name = "addPictureText";
            this.addPictureText.Size = new System.Drawing.Size(124, 13);
            this.addPictureText.TabIndex = 0;
            this.addPictureText.Text = "Placeholder text";
            // 
            // okButton
            // 
            this.okButton.AutoEllipsis = true;
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(255, 279);
            this.okButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoEllipsis = true;
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(174, 279);
            this.cancelButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.BackColor = System.Drawing.Color.Transparent;
            this.detailsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.detailsLabel.Location = new System.Drawing.Point(12, 219);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(124, 13);
            this.detailsLabel.TabIndex = 4;
            this.detailsLabel.Text = "640x480 128.43KB PNG";
            // 
            // altTextBox
            // 
            this.altTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.altTextBox.Location = new System.Drawing.Point(12, 246);
            this.altTextBox.Name = "altTextBox";
            this.altTextBox.Size = new System.Drawing.Size(318, 20);
            this.altTextBox.TabIndex = 6;
            this.altTextBox.Text = "Placeholder text";
            this.altTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.altTextBox.Enter += new System.EventHandler(this.atbEnter);
            this.altTextBox.Leave += new System.EventHandler(this.atbLeave);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBox.Location = new System.Drawing.Point(12, 37);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(318, 179);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 3;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            this.picBox.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // Menu_ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 314);
            this.Controls.Add(this.altTextBox);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addPictureText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_ImageSelector";
            this.Text = "Placeholder text";
            this.Load += new System.EventHandler(this.Menu_ImageSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPictureText;
        private Cerulean.CeruleanButton okButton;
        private Cerulean.CeruleanButton cancelButton;
        private Cerulean.BorderPicBox picBox;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.TextBox altTextBox;
    }
}