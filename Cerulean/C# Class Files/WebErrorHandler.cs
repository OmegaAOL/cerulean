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
            /*if (title == "Connection failed")
            {
                CeruleanBox.Display(Global.cantConnect);
            }*/

            if (localHandling == false)
            {



                if (subtitle != String.Empty)
                {
                    title += String.Format("\nDESCRIPTION: {0}", subtitle);
                }

                CeruleanBox.Display("ERROR: " + title);

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
                    case "AuthFactorTokenRequired":
                        title = "Email 2FA token required; use app password";
                        subtitle = "The server requires two-factor authentication. Cerulean does not support legacy 2FA, so use an app password instead.";
                        break;
                    case "RateLimitExceeded":
                        title = "Rate limit exceeded";
                        subtitle = "The PDS is rate limiting your account. Try again later, or contact your PDS administrator.";
                        break;
                    case "AuthenticationRequired":
                        title = "Invalid login details";
                        subtitle = "The login credentials you have provided are invalid. If you used your email to log in, use your handle instead.";
                        break;
                    case "ExpiredToken":
                        Auth.Refresher.Start(Auth.Refresher.Mode.Auto);
                        return errfalse;
                    case "InvalidToken":
                        title = "Invalid 2FA code";
                        subtitle = "You have entered an invalid, or expired, two-factor authentication code. Please log in again with a valid code.";
                        break;
                    case "noResponse":
                        title = "Empty response from server";
                        subtitle = "Blank response received from the server.";
                        break;
                    case "CURLE_COULDNT_RESOLVE_HOST":
                        title = "Couldn't connect to server";
                        subtitle = "Cerulean could not reach the server. Check your internet connection and PDS host settings.";
                        break;
                    default:
                        title = "Error: " + (string)input["error"];
                        if (input.ContainsKey("message"))
                        {
                            subtitle = (string)input["message"];
                        }
                        else
                        {
                            subtitle = "This error is unhandled by Cerulean (it's server-side). Report this on GitHub.";
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
