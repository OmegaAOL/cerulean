using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cerulean.LangPacks;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_About : Form
    {
        /* ===== Constants ===== */
        private const string CBOX_ABSENT_FOLLOW = "Follow users";
        private const string CBOX_THANKS = "Thank you!";
        private const string TXT_PROMO = "I use Cerulean, a Bluesky client for Windows 98 - 11. Try it at https://ceruleanweb.neocities.org";
        private const string CBOX_ABSENT_DONATIONS = "Donations";

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
            BackgroundImage = Global.bgImage;
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
                    // Hardcodes DIDs instead of handles. Do not change this behavior. Handles can change while a DID is permanent.
                    Profile.Follow.Add("did:plc:3eu7dl4zieh66ufh5374dsmw"); // @ceruleanweb.neocities.org (as of Sep 1, 2025)
                    Profile.Follow.Add("did:plc:lcjzu6ssrwr2ifdvpckvdwew"); // @gigggity.bsky.social (as of Sep 1, 2025)
                },
                delegate { CeruleanBox.Display(CBOX_THANKS); }
            );
        }

        private void postAbtCerulean_Click(object sender, EventArgs ev)
        {
            postAbtCerulean.Enabled = false;
            Async.SkyWorker(
                delegate { Tweet.Create(TXT_PROMO); },
                delegate
                {
                    postAbtCerulean.Enabled = true;
                    CeruleanBox.Display(CBOX_THANKS);
                }
            );
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            donateButton.Enabled = false;
            Global.featureAbsent(CBOX_ABSENT_DONATIONS);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
