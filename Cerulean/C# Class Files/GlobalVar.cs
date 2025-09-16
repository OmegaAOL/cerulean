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
        public static Image bgImage = CeruleanArt.pinstripesblue;
        public static void featureAbsent(string feature)
        {
            CeruleanBox.Display("This feature hasn't been added to Cerulean yet. Check if it's available in the latest version.\n\nFeature: " + feature);
        }
    }

    public static class ResDef
    {
        public static readonly Color ForeDefault = Color.SteelBlue;
        public static readonly Color ForeAlternate = Color.DarkCyan;
        public static readonly Color ForeEsteemed = Color.DarkGoldenrod;
        public static readonly Color ForeError = Color.Firebrick;
        public static readonly Color TextHard = Color.Black;
        public static readonly Color TextSoft = Color.DimGray;
        public static readonly Color BgHard = Color.White;
        public static readonly Color BgSoft = Color.Gainsboro;
        public static readonly Color Border = Color.DarkGray;
        public static readonly Image BgImage = CeruleanArt.pinstripesblue;
    }
}
