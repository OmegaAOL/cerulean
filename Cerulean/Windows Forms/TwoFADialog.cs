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
    public partial class TwoFADialog : Form
    {
        public string TwoFACode { get; private set; }

        public TwoFADialog()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void TwoFADialog_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControls();
            BackgroundImage = (Image)Global.bgImage.Clone();
        }

        private void LocalizeControls()
        {
            this.Text = LangPack.TWOFA_WINTITLE;
            textContent.Text = LangPack.TWOFA_LABEL_CONTENT;
            OKButton.Text = LangPack.GLOBAL_BUTTON_OK;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CodeBox.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK; 
                TwoFACode = CodeBox.Text;
                this.Dispose();
            }
            else
            {
                CeruleanBox.Display(LangPack.TWOFA_CBOX_NOCODE);
            }
        }
    }
}
