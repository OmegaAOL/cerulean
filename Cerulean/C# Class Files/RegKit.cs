using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cerulean
{                              
    public static class RegKit // RegKit, OmegaAOL. Helper tool for when Registry.getValue and Registry.setValue are too input bloated. (Cerulean uses registry keys instead of a config.xml)
    {
        public static string read(string subdir, string entry) // Reads the registry
        {
            using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cerulean" + subdir))  
            {        
                string value = (string)regkey.GetValue(entry);
                return (value);              
            }
        }

        public static void write(string subdir, string entry, object entryValue) // Writes to the registry
        {
            using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cerulean" + subdir))  
            {
                regkey.SetValue(entry, entryValue);
            }
        }

    }
}
