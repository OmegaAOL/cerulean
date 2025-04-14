using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using SeasideResearch.LibCurlNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Cerulean
{
    public static class SkyBridge // Packages convoluted libcurlnet commands into nice, little, preordained functions to call for Cerulean.
    {
        private static System.Threading.Timer refreshTimer;
              
        public static void StartTokenRefresher (bool automatic) // function to start the process of token refreshing
        {
            if (automatic) // uses the timer to refresh every 5 minutes
            {
                refreshTimer = new System.Threading.Timer(RefreshAccessToken, null, 300000, 300000);
            }

            else // instantly manually refreshes using skyWorker
            {
                Global.skyWorker = new BackgroundWorker();
                Global.skyWorker.DoWork += (s, e) => RefreshAccessToken(null);
                Global.skyWorker.RunWorkerCompleted += (s, e) => MessageBox.Show("Manual refresh complete");
                Global.skyWorker.RunWorkerAsync();
            }
        }

        private static void RefreshAccessToken(object state) // function that actually gers refresh
        {
            string endPoint = "com.atproto.server.refreshSession";
            string postFields = String.Empty;
            string header1 = "Authorization: Bearer " + Global.refreshToken;
            string header2 = "Accept: application/json";

            string serverRefreshResponse = Post(endPoint, postFields, header1, header2);
            MessageBox.Show("[DEBUG] REFRESH RESPONSE:\n\n" + serverRefreshResponse); // Refresh token obtained debug

            JObject obj = JObject.Parse(serverRefreshResponse);
            Global.token = (string)obj["accessJwt"];
            Global.refreshToken = (string)obj["refreshJwt"];
            //Global.reloadCount++; // Timer debug
            //MessageBox.Show("[DEBUG] RELOADED TIMES: " + Global.reloadCount);
        }        

        public static string DateToBsky() // Gets ISO 8601 + RFC 3339 compatible local date and time for certain Bluesky functions.
        {
            string BskyDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return BskyDate;
        }

        
        public static string Post(string endPoint, string postFields, string header1, string header2) // Handles all POST requests Cerulean makes to the API.
        {   
            string postResponse = String.Empty;
            string url = (RegKit.read("\\API", "PDSHost") + "/xrpc/" + endPoint);

            Curl.GlobalInit(3); // Curl.GlobalInit accepts multiple ints. 0 is no network-related stuff, 1 is SSL only, 2 is WinSock only and 3 is everything. ONLY USE 0 AND 3
            Easy easy = new Easy();

            Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData) // Downloads the server response
            {
                int realSize = size * nmemb;
                postResponse = System.Text.Encoding.UTF8.GetString(buf, 0, realSize);
                return realSize;
            };

            Slist header = new Slist(); // For headers
            header.Append(header1);
            header.Append(header2);

            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, header);
            easy.SetOpt(CURLoption.CURLOPT_URL, url); // Easy mode - setting options for upload
            easy.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);      
            easy.SetOpt(CURLoption.CURLOPT_POST, true);
            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, postFields);
                
            try
            {
                easy.Perform(); 
            }

            catch(Exception ex)
            {
                MessageBox.Show("Please wait some time before posting again. Rapid-fire posting is not supported currently as there is no post queue.\n\nException: " + ex.Message);
            }

            easy.Cleanup(); // Clean up residue
            Curl.GlobalCleanup();

            return postResponse;           
        }

        public static string Get(string endPoint, string getParam, string header1, string header2) // Handles all GET requests Cerulean makes to the API.
        {
            string getResponse = String.Empty;
            string url = (RegKit.read("\\API", "PDSHost") + "/xrpc/" + endPoint + "?" + getParam);

            Curl.GlobalInit(3); // Curl.GlobalInit accepts multiple ints. 0 is no network-related stuff, 1 is SSL only, 2 is WinSock only and 3 is everything. ONLY USE 0 AND 3
            Easy easy = new Easy();

            Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData) // Downloads the server response
            {
                int realSize = size * nmemb;
                getResponse = System.Text.Encoding.UTF8.GetString(buf, 0, realSize);
                return realSize;
            };

            Slist header = new Slist(); // For headers
            header.Append(header1);
            header.Append(header2);

            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, header);
            easy.SetOpt(CURLoption.CURLOPT_URL, url); // Easy mode - setting options for upload
            easy.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
            easy.SetOpt(CURLoption.CURLOPT_HTTPGET, true);

            try
            {
                easy.Perform();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }

            easy.Cleanup(); // Clean up residue
            Curl.GlobalCleanup();

            return getResponse;   
        }
        
        public static string Auth()
        {
            var postJson = new JObject();
            postJson["identifier"] = Global.handle;
            postJson["password"] = Global.password;
            
            string endPoint = "com.atproto.server.createSession";
            string postFields = postJson.ToString(Formatting.None);
            string header1 = "Content-Type: application/json";
            string header2 = String.Empty;

            string authResponse = Post(endPoint, postFields, header1, header2);

            StartTokenRefresher(true); // starts the 5-min-interval token refreshing method(s)
            return authResponse;

        }

        public static string Tweet(string tweetContent)
        {
            if (byte.Parse(RegKit.read("\\UserSettings", "DSForComposer")) == 1) // digital signature
            {
                tweetContent += (" " + RegKit.read("\\UserSettings", "DigitalSignature"));
            }
            
            var record = new JObject();
            record["text"] = tweetContent;
            record["createdAt"] = DateToBsky();

            var postJson = new JObject();
            postJson["repo"] = Global.handle;
            postJson["collection"] = "app.bsky.feed.post";
            postJson["record"] = record;
                        
            string endPoint = "com.atproto.repo.createRecord";
            string postFields = postJson.ToString(Formatting.None);
            string header1 = "Authorization: Bearer " + Global.token;
            string header2 = "Content-Type: application/json";

            Post(endPoint, postFields, header1, header2);

            return tweetContent;
        }

        public static string QuickTweet(string tweetContent)
        {
            if (byte.Parse(RegKit.read("\\UserSettings", "DSForQuickPost")) == 1) // digital signature
            {
                tweetContent += (" " + RegKit.read("\\UserSettings", "DigitalSignature"));
            }

            var record = new JObject();
            record["text"] = tweetContent;
            record["createdAt"] = DateToBsky();

            var postJson = new JObject();
            postJson["repo"] = Global.handle;
            postJson["collection"] = "app.bsky.feed.post";
            postJson["record"] = record;

            string endPoint = "com.atproto.repo.createRecord";
            string postFields = postJson.ToString(Formatting.None);
            string header1 = "Authorization: Bearer " + Global.token;
            string header2 = "Content-Type: application/json";

            Post(endPoint, postFields, header1, header2);

            return tweetContent;
        }

        public static string Search(string query)
        {
            query = query.Replace(" ", "%20");
            
            string endPoint = "app.bsky.feed.searchPosts";
            string getParam = "q=" + query;        
            string header1 = "Authorization: Bearer " + Global.token;
            string header2 = "Content-Type: application/json";

            return Get(endPoint, getParam, header1, header2);
        }
    }
}

