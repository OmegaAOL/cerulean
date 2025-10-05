using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_ChangePDS : Form // Updated to use RegKit.regReader
    {
        public Menu_ChangePDS()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_ChangePDS_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControlText();
            BackgroundImage = ThemeDefinitions.Background;
            this.AcceptButton = applyButton;
            pdshostbox.Text = RegKit.Read.String("API", "PDSHost");
        }

        private void LocalizeControlText()
        {
            this.Text = LangPack.PDS_WINTITLE;
            applyButton.Text = LangPack.GLOBAL_BUTTON_APPLY;
            resetButton.Text = LangPack.GLOBAL_BUTTON_RESET;
            chkStatus.Text = LangPack.GLOBAL_BUTTON_PING_SERVER;
            description.Text = LangPack.PDS_LABEL_DESCRIPTION;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string input = pdshostbox.Text; 
            char last = input[input.Length - 1];
            if (!(char.IsLetterOrDigit(last))) { CeruleanBox.Display(LangPack.PDS_CBOX_INVALID_CHAR); }
            else
            {
                RegKit.Write("\\API", "PDSHost", pdshostbox.Text);
                Variables.PDSHost = pdshostbox.Text;
                CeruleanBox.Display(LangPack.PDS_CBOX_URL_SAVED);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            RegKit.Write("\\API", "PDSHost", WebResources.PDS_BLUESKY);
            Variables.PDSHost = WebResources.PDS_BLUESKY;
            CeruleanBox.Display(String.Format(LangPack.PDS_CBOX_URL_RESET, WebResources.PDS_BLUESKY));
            pdshostbox.Text = RegKit.Read.String("API", "PDSHost");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkStatus_Click(object sender, EventArgs e)
        {
            chkStatus.Enabled = false;
            Async.SkyWorker(
                (s, evt) => evt.Result = PDS.GetVersion(),
                (s, evt) =>
                {
                    chkStatus.Enabled = true;
                    string message, result = String.Empty;
                    if ((string)evt.Result == "error")
                    {
                        message = LangPack.PDS_CBOX_PDS_PING_ERROR;
                        
                    }
                    else
                    {
                        message = LangPack.PDS_CBOX_PDS_PING_RESULT;
                        result = evt.Result.ToString();
                    }
                    CeruleanBox.Display(message + RegKit.Read.String("API", "PDSHost") + result);
                }
            );
        }
    }
}
