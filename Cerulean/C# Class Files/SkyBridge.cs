using System;
using System.Threading;
using System.Windows.Forms;
using SeasideResearch.LibCurlNet;
using Newtonsoft.Json.Linq;

namespace Cerulean
{
    public static class SkyBridge // Packages convoluted libcurlnet commands into nice, little, preordained functions to call for Cerulean.
    {
        private static System.Threading.Timer refreshTimer;
        public static string postResponse;

        private static void StartTokenRefresher()
        {
            // Callback every 5 minutes (300000 ms)
            refreshTimer = new System.Threading.Timer(RefreshAccessToken, null, 300000, 300000);
        }

        private static void RefreshAccessToken(object state)
        {
            string endPoint = "server.refreshSession";
            string postFields = "";
            string header1 = "Authorization: Bearer " + Global.refreshToken;
            string header2 = "Accept: application/json";

            string serverRefreshResponse = Post(endPoint, postFields, header1, header2);

            JObject obj = JObject.Parse(serverRefreshResponse);
            Global.token = (string)obj["accessJwt"];
            Global.refreshToken = (string)obj["refreshJwt"];
        }        

        public static string DateToBsky() // Gets ISO 8601 + RFC 3339 compatible local date and time for certain Bluesky functions.
        {
            string BskyDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return BskyDate;
        }

        
        public static string Post(string endPoint, string postFields, string header1, string header2) // Handles all POST requests Cerulean makes to the API.
        {
            
            string url = RegKit.read("\\API", "PDSHost") + "/xrpc/com.atproto." + endPoint;
            
            
            Curl.GlobalInit(3); // Curl.GlobalInit accepts multiple ints. 0 is no network-related stuff, 1 is SSL only, 2 is WinSock only and 3 is everything. ONLY USE 0 AND 3
            Easy easy = new Easy();

            Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData) // Downloads the server response
            {
                int realSize = size * nmemb;
                postResponse = System.Text.Encoding.UTF8.GetString(buf, 0, realSize);
                return realSize;
            };

            easy.SetOpt(CURLoption.CURLOPT_URL, url);
            easy.SetOpt(CURLoption.CURLOPT_POST, true);
            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, postFields);
            easy.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);

            Slist header = new Slist(); // For headers
            header.Append(header1);
            header.Append(header2);
            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, header);

            easy.Perform();
            easy.Cleanup();
            Curl.GlobalCleanup();

            return postResponse;
            
        }
        
        public static void Auth()
        {
            string endPoint = "server.createSession";
            string postFields = string.Format("{{\"identifier\": \"{0}\", \"password\": \"{1}\"}}", Global.handle, Global.password);
            string header1 = "Content-Type: application/json";
            string header2 = "";
 
            Global.serverAuthResponse = Post(endPoint, postFields, header1, header2);
            StartTokenRefresher();
        }

        public static string Tweet(string tweetContent, byte enableDS)
        {
            string endPoint = "repo.createRecord";

            if (enableDS == 1 || int.Parse(RegKit.read("\\UserSettings", "DSForQuickPost")) == 1)
            {
                tweetContent += (" " + RegKit.read("\\UserSettings", "DigitalSignature"));
            }

            string postFields = string.Format("{{\"repo\": \"{0}\", \"collection\": \"app.bsky.feed.post\", \"record\": {{\"text\": \"{1}\", \"createdAt\": \"{2}\"}}}}", Global.handle, tweetContent, DateToBsky());
            string header1 = "Authorization: Bearer " + Global.token;
            string header2 = "Content-Type: application/json";

            Post(endPoint, postFields, header1, header2);

            return tweetContent;
        }
    }
}

