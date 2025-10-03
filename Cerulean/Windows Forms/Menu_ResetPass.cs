using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_ResetPass : Form
    {
        public Menu_ResetPass()
        {
            InitializeComponent();
        }

        private void Menu_ResetPass_Load(object sender, EventArgs e)
        {
            emailBox.Focus();
            CenterToParent();
            LocalizeControls();
            BackgroundImage = ThemeDefinitions.Background;
        }

        private void LocalizeControls()
        {
            this.Text = LangPack.RESETPW_WINTITLE;
            step1.Text = LangPack.RESETPW_LABEL_STEP1;
            step2.Text = LangPack.RESETPW_LABEL_STEP2;
            emailLabel.Text = LangPack.RESETPW_LABEL_EMAIL;
            sendEmButton.Text = LangPack.RESETPW_BUTTON_SEND_EMAIL;
            codeLabel.Text = LangPack.RESETPW_LABEL_RESET_CODE;
            passwordLabel.Text = LangPack.RESETPW_LABEL_NEW_PASSWORD;
            infoLabel.Text = LangPack.RESETPW_INFOLABEL_STRONG_PASSWORD;
            cancelButton.Text = LangPack.GLOBAL_BUTTON_CANCEL;
            applyButton.Text = LangPack.GLOBAL_BUTTON_APPLY;
        }

        private void sendEmButton_Click(object sender, EventArgs e)
        {
            if (!(emailBox.Text.Contains("@")))
            {
                infoLabel.ForeColor = ThemeDefinitions.TextError;
                infoLabel.Text = LangPack.RESETPW_INFOLABEL_EMAIL_INVALID;
            }

            else
            {
                infoLabel.ForeColor = ThemeDefinitions.TextAccented;
                infoLabel.Text = LangPack.RESETPW_INFOLABEL_STRONG_PASSWORD;
                sendEmButton.Enabled = false;
                Async.SkyWorker(
                    (s, evt) => evt.Result = Auth.Reset.RequestCode(emailBox.Text),
                    (s, evt) =>
                    {
                        codeBox.Focus();
                        sendEmButton.Enabled = true;
                        WEH.ErrHandler((JObject)evt.Result);
                    }
                );
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (codeBox.Text == String.Empty || passBox.Text == String.Empty)
            {
                infoLabel.ForeColor = ThemeDefinitions.TextError;
                infoLabel.Text = LangPack.GLOBAL_INFOLABEL_EMPTY_FIELDS;
            }

            else
            {
                infoLabel.ForeColor = ThemeDefinitions.TextAccented;
                infoLabel.Text = LangPack.RESETPW_INFOLABEL_STRONG_PASSWORD;
                applyButton.Enabled = false;
                Async.SkyWorker(
                    (s, evt) => evt.Result = Auth.Reset.Password(codeBox.Text, passBox.Text),
                    (s, evt) =>
                    {
                        applyButton.Enabled = true;
                        WEH.ErrHandler((JObject)evt.Result);
                        string reply = (string)evt.Result;
                        emailBox.Focus();
                    }
                );
            }
        }
    }
}
