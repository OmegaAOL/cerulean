namespace Cerulean
{
    partial class Menu_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Report));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.okButton = new Cerulean.CeruleanButton();
            this.cancelButton = new Cerulean.CeruleanButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "You can report a user or post here. The report goes directly to your \r\nmoderation" +
                " service. For most users, this is Bluesky Moderation.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Report falls under category:";
            // 
            // comboBox
            // 
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(151, 51);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(198, 21);
            this.comboBox.TabIndex = 3;
            this.comboBox.Text = "Select a category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Details (max. 20000 ch):";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 108);
            this.textBox.MaxLength = 20000;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(337, 116);
            this.textBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.AutoEllipsis = true;
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(274, 234);
            this.okButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoEllipsis = true;
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(193, 234);
            this.cancelButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Menu_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cerulean.Properties.Resources.bluestripes;
            this.ClientSize = new System.Drawing.Size(361, 268);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu_Report";
            this.Text = "File a report";
            this.Load += new System.EventHandler(this.Menu_Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox;
        private Cerulean.CeruleanButton okButton;
        private Cerulean.CeruleanButton cancelButton;
    }
}