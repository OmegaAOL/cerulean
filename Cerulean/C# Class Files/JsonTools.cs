using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Cerulean.LangPacks;

namespace Cerulean
{
    class JsonTools
    {
        public static string GetString(JObject obj, string path, bool humanReadableError = false)
        {
            if (obj.SelectToken(path) != null)
            {
                return obj.SelectToken(path).ToString();
            }
            else if (humanReadableError) { return LangPack.GLOBAL_UNKNOWN; }
            else { return String.Empty; }
        }

        public static int GetInt(JObject obj, string path)
        {
            if (obj.SelectToken(path) != null)
            {
                return (int)(obj.SelectToken(path));
            }
            else return -1;
        }
    }
}
