using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;

namespace Cerulean
{
    class IconExtractor
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(
            string lpszFile,
            int nIconIndex,
            IntPtr[] phiconLarge,
            IntPtr[] phiconSmall,
            int nIcons
        );

        private Icon ExtractShellIcon(string dllPath, int index, bool large)
        {
            IntPtr[] icons = new IntPtr[1];
            if (large)
                ExtractIconEx(dllPath, index, icons, null, 1);
            else
                ExtractIconEx(dllPath, index, null, icons, 1);

            if (icons[0] != IntPtr.Zero)
                return Icon.FromHandle(icons[0]);

            return null;
        }
    }
}
