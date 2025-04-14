using System;
using System.Drawing;
using System.Windows.Forms;

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
            pdshostbox.Text = RegKit.read("\\API", "PDSHost");
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            RegKit.write("\\API", "PDSHost", pdshostbox.Text);
            settingsLabel.Text = "Custom PDS host saved";
            settingsLabel.ForeColor = Color.Green;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            RegKit.write("\\API", "PDSHost", Global.defaultPDSHost);
            settingsLabel.Text = "PDS host reset to default";
            pdshostbox.Text = RegKit.read("\\API", "PDSHost");
            settingsLabel.ForeColor = Color.Blue;
        }
    }
}
