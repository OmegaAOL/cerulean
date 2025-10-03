using System;
using System.Runtime.InteropServices;


namespace LibPurple {

    public static class Purple
    {
        // Initialize libpurple core
        [DllImport("libpurple.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void purple_core_init(string uiOps);

        // Quit libpurple
        [DllImport("libpurple.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void purple_core_quit();

        // Example: get libpurple version
        [DllImport("libpurple.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr purple_core_get_version();

        // Helper to convert IntPtr to string
        public static string GetVersion()
        {
            IntPtr ptr = purple_core_get_version();
            return Marshal.PtrToStringAnsi(ptr);
        }
    }

}
