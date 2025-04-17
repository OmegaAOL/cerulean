using System.Threading;
using System.ComponentModel;

namespace Cerulean
{
    public static class Global
    {
        public static string handle;
        public static string token;
        public static string refreshToken;
        public const string defaultPDSHost = "https://bsky.social";
        public static string connectionStatus;
        public const string cantConnect = "Cerulean seems to be unable to reach the PDS server.\n\n1) Check your internet connection." +
        "\n\n2: Check your PDS host settings. If you have set a custom PDS host, it may be temporarily or permanently offline.\n\n3) See if you can connect to bsky.social in a Web browser. If you cannot, despite " +
        "having internet access, Bluesky servers are down and there is nothing Cerulean can do about it.";
        public const string notImplemented = ("This feature does not exist in Cerulean. If you haven't, consider updating Cerulean to get this feature if available in the latest version.");
    }
}
