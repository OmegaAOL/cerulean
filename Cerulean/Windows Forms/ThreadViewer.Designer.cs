namespace Cerulean
{
    partial class ThreadViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThreadViewer));
            this.tweetBoard = new Cerulean.BorderPanel();
            this.SuspendLayout();
            // 
            // tweetBoard
            // 
            this.tweetBoard.AutoScroll = true;
            this.tweetBoard.AutoScrollMargin = new System.Drawing.Size(0, 1);
            this.tweetBoard.BackColor = System.Drawing.Color.Transparent;
            this.tweetBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tweetBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tweetBoard.Location = new System.Drawing.Point(0, 0);
            this.tweetBoard.Margin = new System.Windows.Forms.Padding(0);
            this.tweetBoard.Name = "tweetBoard";
            this.tweetBoard.Size = new System.Drawing.Size(1047, 551);
            this.tweetBoard.TabIndex = 11;
            // 
            // ThreadViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cerulean.CeruleanArt.bdStripes;
            this.ClientSize = new System.Drawing.Size(1047, 551);
            this.Controls.Add(this.tweetBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThreadViewer";
            this.Text = "Placeholder text";
            this.Load += new System.EventHandler(this.ThreadViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BorderPanel tweetBoard;

    }
}