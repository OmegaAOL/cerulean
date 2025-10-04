using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OmegaAOL.SkyBridge;
using Cerulean.LangPacks;

namespace Cerulean
{
    class WEH
    {
        public static void ErrThrower(bool localHandling, string title, string subtitle = "")
        {
            if (localHandling == false)
            {
                if (subtitle != String.Empty)
                {
                    title += String.Format("\n" + LangPack.ERR_DESC, subtitle);
                }

                CeruleanBox.Display(LangPack.ERR_PREFIX.ToUpper() + " " + title);

            }
        }

        public static string[] ErrHandler(JObject input, bool localHandling = false) // handles errors, returns true if error, returns false if no error
        {
            string title = String.Empty, subtitle = String.Empty;
            string[] errtrue = new string[] { null, null, "true" };
            string[] errfalse = new string[] { null, null, "false" };

            if (input.ContainsKey("error"))
            {
                switch ((string)input["error"])
                {
                    case "RateLimitExceeded":
                        title = LangPack.ERR_RATELIMIT_HEAD;
                        subtitle = LangPack.ERR_RATELIMIT_SUB;
                        break;
                    case "AccountTakedown":
                        title = LangPack.ERR_RATELIMIT_HEAD;
                        subtitle = LangPack.ERR_RATELIMIT_SUB;
                        break;
                    case "AuthenticationRequired":
                        title = LangPack.ERR_BADCRED_HEAD;
                        subtitle = LangPack.ERR_BADCRED_SUB;
                        break;
                    case "AuthFactorTokenRequired":
                        title = LangPack.ERR_TWOFA_HEAD;
                        subtitle = LangPack.ERR_TWOFA_SUB;
                        break;
                    case "ExpiredToken":
                        Auth.Refresher.Start(Auth.Refresher.Mode.Auto);
                        return errfalse;
                    case "InvalidToken":
                        title = LangPack.ERR_BADTWOFA_HEAD;
                        subtitle = LangPack.ERR_BADTWOFA_SUB;
                        break;
                    case "noResponse":
                        title = LangPack.ERR_NORESPONSE_HEAD;
                        subtitle = LangPack.ERR_NORESPONSE_SUB;
                        break;
                    case "CURLE_COULDNT_RESOLVE_HOST":
                        title = LangPack.ERR_CANTRESOLVEHOST_HEAD;
                        subtitle = LangPack.ERR_CANTRESOLVEHOST_SUB;
                        break;
                    case "SKY_UNEXPECTED":
                        title = LangPack.ERR_SKY_HEAD;
                        subtitle = LangPack.ERR_SKY_SUB;
                        break;
                    case "SKY_INVALID":
                        title = LangPack.ERR_SKY_INVALID_HEAD;
                        subtitle = LangPack.ERR_SKY_INVALID_SUB;
                        break;
                    default:
                        title = LangPack.ERR_PREFIX + " " + (string)input["error"];
                        if (input.ContainsKey("message"))
                        {
                            subtitle = (string)input["message"];
                        }
                        else
                        {
                            subtitle = LangPack.ERR_SERVER_SUB;
                        }
                        break;

                }

                ErrThrower(localHandling, title, subtitle);

                if (localHandling == true) { return new string[] { title, subtitle, null }; }
                else { return errtrue; }
            }

            else { return errfalse; }
        }
    }
}
