using Newtonsoft.Json.Linq;
using System.Drawing;
using Cerulean.LangPacks;

namespace Cerulean
{
    public static class Global
    {
        public const string version = "Crimson 0.3"; // this is the only string that should be hardcoded into the program binary!
        public static string connectionStatus;    
        public static string[] stringArray;
        public static Image bgImage = CeruleanArt.pinstripesblue;
        public static void featureAbsent(string feature)
        {
            CeruleanBox.Display(LangPack.MAIN_CBOX_FEATUREABSENT + " " + feature);
        }
    }

    public static class ThemeDefinitions
    {
        public static readonly Color TextLowContrast = Color.DimGray;
        public static readonly Color TextHighContrast = Color.DarkGray;
        public static readonly Color TextAccented = Color.SteelBlue;
        public static readonly Color TextVerified = Color.DarkGoldenrod;
        public static readonly Color TextSuperVerified = Color.Firebrick;
        public static readonly Color TextSuccess = Color.ForestGreen;
        public static readonly Color TextError = Color.Firebrick;
        public static readonly Color TextImportant = Color.Firebrick;
        public static readonly Color TextSemiImportant = Color.OrangeRed;

        public static readonly Color Foreground = Color.Black;
        public static readonly Color Border = Color.Gainsboro;
        public static readonly Image Background = CeruleanArt.pinstripesblue;
        public static readonly Color BackgroundColor = Color.LightGray;
        public static readonly Color BackgroundColorTransparent = Color.FromArgb(210, Color.White);
        public static readonly Color BackgroundPanel = Color.WhiteSmoke;
        public static readonly Color BackgroundBoxes = Color.White;

        public static readonly Color DepthIndicatorBase = ColorTranslator.FromHtml("#00a1e6");
        public static readonly Color TransparencySubstitute = Color.Magenta;
    }
}
