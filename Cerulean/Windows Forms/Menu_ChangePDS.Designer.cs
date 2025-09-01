namespace Cerulean
{
    partial class Menu_ChangePDS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_ChangePDS));
            this.pdshostbox = new System.Windows.Forms.TextBox();
            this.applyButton = new Cerulean.CeruleanButton();
            this.resetButton = new Cerulean.CeruleanButton();
            this.description = new System.Windows.Forms.Label();
            this.chkStatus = new Cerulean.CeruleanButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdshostbox
            // 
            this.pdshostbox.Location = new System.Drawing.Point(16, 125);
            this.pdshostbox.Name = "pdshostbox";
            this.pdshostbox.Size = new System.Drawing.Size(322, 20);
            this.pdshostbox.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.AutoEllipsis = true;
            this.applyButton.AutoSize = true;
            this.applyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyButton.BackColor = System.Drawing.Color.Transparent;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(0, 0);
            this.applyButton.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.applyButton.MaximumSize = new System.Drawing.Size(81, 23);
            this.applyButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.applyButton.Name = "applyButton";
            this.applyButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.applyButton.Size = new System.Drawing.Size(81, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Cerulean.Placeholder";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.AutoEllipsis = true;
            this.resetButton.AutoSize = true;
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.BackColor = System.Drawing.Color.Transparent;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetButton.Location = new System.Drawing.Point(87, 0);
            this.resetButton.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.resetButton.MaximumSize = new System.Drawing.Size(81, 23);
            this.resetButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.resetButton.Name = "resetButton";
            this.resetButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.resetButton.Size = new System.Drawing.Size(81, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Cerulean.Placeholder";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // description
            // 
            this.description.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Location = new System.Drawing.Point(16, 5);
            this.description.Name = "description";
            this.description.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.description.Size = new System.Drawing.Size(322, 115);
            this.description.TabIndex = 3;
            this.description.Text = "Cerulean.Placeholder";
            this.description.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoEllipsis = true;
            this.chkStatus.AutoSize = true;
            this.chkStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chkStatus.BackColor = System.Drawing.Color.Transparent;
            this.chkStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStatus.Location = new System.Drawing.Point(16, 0);
            this.chkStatus.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.chkStatus.MaximumSize = new System.Drawing.Size(149, 23);
            this.chkStatus.MinimumSize = new System.Drawing.Size(75, 23);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.chkStatus.Size = new System.Drawing.Size(149, 23);
            this.chkStatus.TabIndex = 5;
            this.chkStatus.Text = "Cerulean.Placeholder";
            this.chkStatus.UseVisualStyleBackColor = false;
            this.chkStatus.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.chkStatus);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 162);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 35);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.resetButton);
            this.flowLayoutPanel1.Controls.Add(this.applyButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(170, 162);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(184, 35);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // Menu_ChangePDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Cerulean.CeruleanArt.bdStripes;
            this.ClientSize = new System.Drawing.Size(354, 197);
            this.Controls.Add(this.pdshostbox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.description);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(2000, 235);
            this.MinimumSize = new System.Drawing.Size(16, 235);
            this.Name = "Menu_ChangePDS";
            this.Text = "Cerulean.Placeholder";
            this.Load += new System.EventHandler(this.Menu_ChangePDS_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pdshostbox;
        private Cerulean.CeruleanButton applyButton;
        private Cerulean.CeruleanButton resetButton;
        private System.Windows.Forms.Label description;
        private Cerulean.CeruleanButton chkStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}