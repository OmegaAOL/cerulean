using System.Threading;
using System.ComponentModel;

namespace Cerulean
{
    public static class Global
    {
        public static string serverAuthResponse;
        public static string handle;
        public static string password;
        public static string token;
        public static string refreshToken;
        public static string defaultPDSHost = "https://bsky.social";
        public static BackgroundWorker skyWorker;
        public static string connectionStatus;
    }
}
