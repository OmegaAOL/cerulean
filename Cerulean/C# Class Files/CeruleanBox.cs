using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cerulean
{
    class CeruleanBox
    {
        public static void Display(string text)
        {
            try
            {
                //new Form_CeruleanBox(text).ShowDialog();
                MessageBox.Show(text);
            }

            catch
            {
                MessageBox.Show("Cerulean MessageBox failed to init. Using native messagebox as fallback.\n\n" + text);
            }
        }
    }
}
