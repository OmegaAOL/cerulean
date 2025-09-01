using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cerulean.LangPacks;

namespace Cerulean
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(Image pic)
        {
            InitializeComponent();

            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Start with Normal mode
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;

            Size finalSize = new Size();
            double ratio = (double)pic.Width / (double)pic.Height;
            // MessageBox.Show(ratio.ToString());

            if (pic.Width > maxWidth || pic.Height > maxHeight)
            {
                // CeruleanBox.Display("trigerred. max height = " + maxHeight + " max width = " + maxWidth + " pic width = " + pic.Width + " pic height = " + pic.Height);
                finalSize.Height = maxHeight;
                // finalSize.Width = (int)(((double)pic.Width) * ratio);
                finalSize.Width = (int)(((double)maxHeight) * ratio);
            }

            else
            {
                finalSize = pic.Size;
            }

            imageBox.Image = pic;

            // Explicitly set the form's client size to match PictureBox
            this.ClientSize = finalSize;

            // Optional: prevent resizing beyond screen
            this.MaximumSize = new Size(maxWidth, maxHeight);

            this.Text = LangPack.IMGVIEWER_WINTITLE;
        }




        private void ImageViewer_Load(object sender, EventArgs e)
        {
            CenterToParent();
            BackgroundImage = (Image)Global.bgImage.Clone();
        }
    }
}
