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
        public static class Read // Reads the registry
        {
            private static object FetchData(string subdir, string entry)
            {
                using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Cerulean\" + subdir))
                {
                    return regkey.GetValue(entry);
                }
            }

            public static string String(string subdir, string entry)
            {
                object value = FetchData(subdir, entry);
                if (value != null && value is string)
                {
                    return (string)value;
                }
                else
                {
                    return ("Unknown");
                }
            }

            public static int Dword(string subdir, string entry)
            {
                object value = FetchData(subdir, entry);
                if (value != null && value is int)
                {
                    return (int)value;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static void Write(string subdir, string entry, object entryValue) // Writes to the registry
        {
            using (RegistryKey regkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Cerulean\" + subdir))
            {
                if (entryValue is int)
                {
                    regkey.SetValue(entry, entryValue, RegistryValueKind.DWord);
                }
                else
                {
                    regkey.SetValue(entry, entryValue.ToString(), RegistryValueKind.String);
                }
            }
        }

    }
}
