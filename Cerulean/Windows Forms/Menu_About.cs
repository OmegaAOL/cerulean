using System;
using System.Windows.Forms;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void followSNKButton_Click(object sender, EventArgs e)
        {

        }
    }
}
