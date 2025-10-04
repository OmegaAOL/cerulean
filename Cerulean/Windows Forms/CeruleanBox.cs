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
    public partial class Form_CeruleanBox : Form
    {
        public Form_CeruleanBox(object text)
        {
            InitializeComponent();
            this.MinimizeBox = false;    // hide minimize button
            this.MaximizeBox = false;
            textContent.Text = text.ToString();
        }

        private void Form_CeruleanBox_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControls();
            BackgroundImage = (Image)Global.bgImage.Clone();
        }

        private void LocalizeControls()
        {
            this.Text = LangPack.CBOX_WINTITLE;
            OKButton.Text = LangPack.GLOBAL_BUTTON_OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
