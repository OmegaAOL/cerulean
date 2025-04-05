using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cerulean
{
    public partial class Menu_Main : Form
    {
        public Menu_Main()
        {                                  
            InitializeComponent();
        }

        private void Menu_Main_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void menuItemOptions_Click(object sender, EventArgs e)
        {
            var optionsmenu = new Menu_Settings();
            optionsmenu.Show();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            var aboutmenu = new Menu_About();
            aboutmenu.Show();
        }


    }
}
