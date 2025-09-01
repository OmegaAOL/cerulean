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
            this.description = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.postAbtCerulean = new Cerulean.CeruleanButton();
            this.donateButton = new Cerulean.CeruleanButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.followOmegaButton = new Cerulean.CeruleanButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoEllipsis = true;
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Location = new System.Drawing.Point(27, 15);
            this.description.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.description.MaximumSize = new System.Drawing.Size(500, 156);
            this.description.MinimumSize = new System.Drawing.Size(500, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(500, 13);
            this.description.TabIndex = 1;
            this.description.Text = "Cerulean.Placeholder";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Cerulean.CeruleanArt.about_beta;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // postAbtCerulean
            // 
            this.postAbtCerulean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.postAbtCerulean.AutoSize = true;
            this.postAbtCerulean.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.postAbtCerulean.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.postAbtCerulean.Location = new System.Drawing.Point(211, 0);
            this.postAbtCerulean.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.postAbtCerulean.MaximumSize = new System.Drawing.Size(155, 23);
            this.postAbtCerulean.MinimumSize = new System.Drawing.Size(75, 23);
            this.postAbtCerulean.Name = "postAbtCerulean";
            this.postAbtCerulean.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.postAbtCerulean.Size = new System.Drawing.Size(133, 23);
            this.postAbtCerulean.TabIndex = 3;
            this.postAbtCerulean.Text = "Cerulean.Placeholder";
            this.postAbtCerulean.UseVisualStyleBackColor = true;
            this.postAbtCerulean.Click += new System.EventHandler(this.postAbtCerulean_Click);
            // 
            // donateButton
            // 
            this.donateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.donateButton.AutoSize = true;
            this.donateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.donateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.donateButton.Location = new System.Drawing.Point(356, 0);
            this.donateButton.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.donateButton.MaximumSize = new System.Drawing.Size(155, 23);
            this.donateButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.donateButton.Name = "donateButton";
            this.donateButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.donateButton.Size = new System.Drawing.Size(133, 23);
            this.donateButton.TabIndex = 4;
            this.donateButton.Text = "Cerulean.Placeholder";
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.postAbtCerulean, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.donateButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.followOmegaButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 324);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 35);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // followOmegaButton
            // 
            this.followOmegaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.followOmegaButton.AutoSize = true;
            this.followOmegaButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.followOmegaButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.followOmegaButton.Location = new System.Drawing.Point(66, 0);
            this.followOmegaButton.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.followOmegaButton.MaximumSize = new System.Drawing.Size(155, 23);
            this.followOmegaButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.followOmegaButton.Name = "followOmegaButton";
            this.followOmegaButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.followOmegaButton.Size = new System.Drawing.Size(133, 23);
            this.followOmegaButton.TabIndex = 2;
            this.followOmegaButton.Text = "Cerulean.Placeholder";
            this.followOmegaButton.UseVisualStyleBackColor = true;
            this.followOmegaButton.Click += new System.EventHandler(this.followOmegaButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.description, 1, 0);
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 149);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(555, 2000);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(555, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(555, 167);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // Menu_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Cerulean.Properties.Resources.pinstripes;
            this.ClientSize = new System.Drawing.Size(555, 359);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(571, 3000);
            this.MinimumSize = new System.Drawing.Size(571, 38);
            this.Name = "Menu_About";
            this.Text = "Cerulean.Placeholder";
            this.Load += new System.EventHandler(this.Menu_About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CeruleanButton postAbtCerulean;
        private CeruleanButton donateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CeruleanButton followOmegaButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    }
}