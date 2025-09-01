using Newtonsoft.Json.Linq;
using System.Drawing;

namespace Cerulean
{
    public static class Global
    {
        public const string defaultPDSHost = "https://bsky.social"; // PDS host for all AT-protocol and Bluesky API managed endpoints 
        public const string bskyUrl = "https://bsky.app"; // URL for non-API Bluesky requests (think images, videos, profile URLs)
        public const string tosUrl = "https://ceruleanweb.neocities.org/legal/terms";
        public const string bskyTosUrl = "https://bsky.social/about/support/tos";
        public static string connectionStatus;    
        public static string[] stringArray;
        public static Color BaseColor = Color.FromArgb(239, 244, 249);
        public static Color ForeBlueColor = Color.FromArgb(239, 244, 249);
        public static Image bgImage = CeruleanArt.pinstripesblue;
        public static void featureAbsent(string feature)
        {
            CeruleanBox.Display("This feature hasn't been added to Cerulean yet. Check if it's available in the latest version.\n\nFeature: " + feature);
        }
    }
}
