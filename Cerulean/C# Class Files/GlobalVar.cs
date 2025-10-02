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
