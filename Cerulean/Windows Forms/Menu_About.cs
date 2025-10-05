using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_About : Form
    {
        public Menu_About()
        {
            InitializeComponent();
            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_About_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = postAbtCerulean;
            BackgroundImage = ThemeDefinitions.Background;
            LocalizeControls();
        }

        private void LocalizeControls()
        {
            this.Text = LangPack.ABOUT_WINTITLE;
            description.Text = LangPack.ABOUT_LABEL_DESCRIPTION;
            followOmegaButton.Text = LangPack.ABOUT_BUTTON_FOLLOW_MAINTAINER;
            postAbtCerulean.Text = LangPack.ABOUT_BUTTON_POST_CERULEAN;
            donateButton.Text = LangPack.ABOUT_BUTTON_DONATE;
        }

        private void followOmegaButton_Click(object sender, EventArgs e)
        {
            Async.SkyWorker(
                delegate 
                {
                    Account.Follow.Add(WebResources.DID_CERULEAN); // @ceruleanweb.neocities.org (as of Sep 1, 2025)
                    Account.Follow.Add(WebResources.DID_MAINTAINER); // @gigggity.bsky.social (as of Sep 1, 2025)
                },
                delegate { CeruleanBox.Display(LangPack.ABOUT_CBOX_THANKS); }
            );
        }

        private void postAbtCerulean_Click(object sender, EventArgs ev)
        {
            postAbtCerulean.Enabled = false;
            Async.SkyWorker(
                delegate { Tweet.Create(LangPack.ABOUT_TXT_PROMO + " " + WebResources.HOMEPAGE); },
                delegate
                {
                    postAbtCerulean.Enabled = true;
                    CeruleanBox.Display(LangPack.ABOUT_CBOX_THANKS);
                }
            );
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            donateButton.Enabled = false;
            Global.featureAbsent(LangPack.ABOUT_CBOX_FEATUREABSENT_DONATIONS);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
