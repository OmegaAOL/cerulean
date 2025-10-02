using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using Cerulean.LangPacks;
using System.Windows.Forms;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_ImageSelector : Form
    {
        private static byte[] picBlob;
        private static Image pic;
        private static int height, width;
        private static double size;
        private static string format;
        private static int byteSize;
        public Menu_ImageSelector(Image img)
        {
            InitializeComponent();
            pic = img;
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_ImageSelector_Load(object sender, EventArgs e)
        {
            BackgroundImage = Global.bgImage;
            picBox.Image = pic;
            CenterToParent();
            this.AcceptButton = okButton;
            height = pic.Height;
            width = pic.Width;
            size = SizeFinder(pic);
            format = FormatFinder(pic);
            detailsLabel.Text = String.Format("{0}x{1} {2}KB {3}", width, height, size, format);
            this.Text = LangPack.IMAGESEL_WINTITLE;
            addPictureText.Text = LangPack.IMAGESEL_LABEL_ADD_PICTURE;
            altTextBox.Text = LangPack.IMAGESEL_TEXTBOXHINT_DESC;
        }

        private double SizeFinder(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                picBlob = ms.ToArray();
                byteSize = (int)ms.Length;
                return Math.Round((ms.Length / 1024.00), 2);
            }
        }

        private string FormatFinder(Image img) 
        {
            ImageFormat format = img.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
                return "JPEG";
            else if (format.Equals(ImageFormat.Png))
                return "PNG";
            else if (format.Equals(ImageFormat.Gif))
                return "GIF";
            else if (format.Equals(ImageFormat.Bmp))
                return "BMP";
            else if (format.Equals(ImageFormat.Tiff))
                return "TIFF";
            else
                return "IMG";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {          
           okButton.Enabled = false;
           Async.SkyWorker(
                (s, evt) =>
                {
                    evt.Result = Media.UploadBlob(picBlob);
                },
                (s, evt) =>
                {
                    JObject response = (evt.Result as JObject);
                    MessageBox.Show(response.ToString());
                    if (WEH.ErrHandler(response)[2] == "false")
                    {
                        JObject imageObj = new JObject();
                        Variables.BlobArray = new JArray();
                        imageObj["alt"] = altTextBox.Text;
                        imageObj["image"] = (JObject)response["blob"];
                        Variables.BlobArray.Add(imageObj);
                    }
                    okButton.Enabled = true;
                }
            );
        }

        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            if (format == "IMG") { format = "file type unknown"; }
            CeruleanBox.Display(String.Format("Image ({0}), {1} pixels wide, {2} pixels tall, taking up {3} kilobytes of storage.", format, width, height, size));
        }

        private void picBox_Click(object sender, EventArgs e)
        {

        }

        private void atbFocusText(string text, string newText, Color newTextColor)
        {
            if (altTextBox.Text == text)
            {
                altTextBox.ForeColor = newTextColor;
                altTextBox.Text = newText;
            }
        }

        private void atbEnter(object sender, EventArgs e) { atbFocusText("Add a description?", String.Empty, Color.Black); }
        private void atbLeave(object sender, EventArgs e) { atbFocusText(String.Empty, "Add a description?", Color.DarkGray); }
        
    }
}
