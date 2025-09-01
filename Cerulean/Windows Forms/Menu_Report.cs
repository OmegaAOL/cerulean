using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_Report : Form
    {
        /* ===== Constants ===== */
        private static readonly string[] COMBOBOX_REASONS_REPORT = new string[]
        {
            "Spam: frequent unwanted promotion, replies, mentions",
            "Violation: Direct violation of server rules, laws, terms of service",
            "Misleading: Misleading identity, affiliation, or content",
            "Sexual: Unwanted or mislabeled sexual content",
            "Rude: Harassing, explicit, or otherwise unwelcoming behavior",
            "Other: reports not falling under another report category",
            "Appeal: appeal a previously taken moderation action"
        };

        private string uriOrDid, cid;

        public Menu_Report(string uriordid_Func, string cid_Func = null)
        {
            InitializeComponent();

            uriOrDid = uriordid_Func;
            cid = cid_Func;
            foreach (string reason in COMBOBOX_REASONS_REPORT)
            {
                comboBox.Items.Add(reason);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string[] selectionSplit = comboBox.SelectedItem.ToString().Split(':');
            string modDef = "com.atproto.moderation.defs.reason" + selectionSplit[0];
            okButton.Enabled = false;
            JObject response = new JObject();
            Report.Type repType;

            if (cid != null)
            {
                repType = Report.Type.Tweet;
            }

            else
            {
                repType = Report.Type.User;
            }

            Async.SkyWorker(
             delegate { response = Report.File(repType, modDef, textBox.Text, uriOrDid, cid); },
             delegate
             {
                 if (WEH.ErrHandler(response)[2] != "true")
                 {
                     okButton.Enabled = true;
                     CeruleanBox.Display("Filed as Report #" + response["id"].ToString() + ".");
                 }
             }
            );
        }

        private void Menu_Report_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = okButton;
        }
    }
}
