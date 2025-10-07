/*==================================================================================
 
 =============================//LEGAL NOTICE\\====================================
By using or editing this API framework, you accept the Cerulean Terms of
Service (found at http://ceruleanweb.neocities.org/legal/terms.txt).
This framework ("SkyBridge by OmegaAOL") falls under the Cerulean software group.

 ============================//FOR DEVELOPERS\\===================================
There are a lot of redundant methods in here. This is intentional and for ease of use
and understanding of the library. Do not try to "simplify" it.
This library is currently a static one. This will be changed in the future.
 
===================================================================================*/

using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.ComponentModel;
using SeasideResearch.LibCurlNet;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OmegaAOL.OAuth;

namespace OmegaAOL.SkyBridge
{
    public static class EmbedType
    {
        private const string suffix = "#view";
        public const string Image = "app.bsky.embed.images" + suffix;
        public const string Video = "app.bsky.embed.video" + suffix;
        public const string Record = "app.bsky.embed.record" + suffix;
    }

    internal static class Variables
    {
        internal static string Token;
        internal static string RefreshToken;
        internal static string Handle;
        public static JArray BlobArray = null;
        public static string PDSHost { internal get; set; }
        public static string ChatAPI { internal get; set; }
    }

    internal static class Display
    {
        public static void Text(string text)
        {
            MessageBox.Show(text);
        }
    }

    internal static class Tools // local tools for Skybridge tasks
    {
        private static JObject KeyChecker(string key, JObject obj)
        {
            JObject keyError = new JObject();
            keyError["error"] = "keyNotPresent";
            if (obj.ContainsKey(key) || obj.ContainsKey("error"))
            {
                return obj;
            }

            else
            {
                return keyError;
            }
        }

        public static string GetBlueskyDateTime() // Gets ISO 8601 + RFC 3339 compatible local date and time for certain Bluesky functions.
        {
            return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }

    internal static class Error
    {
        public static void Throw(Easy easy, CURLcode code)
        {
            Display.Text(String.Format("cURL connection error: {0}\n\n[{1}]", easy.StrError(code), code.ToString()));
        }
    }

    internal static class Http
    {
        public enum Method { Post, Get, PostRaw };
        private static bool initDone;
        private static Share ConnectionDataPool;
        private static EasyPool CurlRequestPool;

        private static void Initalize()
        {
            Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_DEFAULT);
            CurlRequestPool = new EasyPool(10);
            ConnectionDataPool = new Share();
            ConnectionDataPool.SetOpt(CURLSHoption.CURLSHOPT_SHARE, CURLlockData.CURL_LOCK_DATA_CONNECT);
            ConnectionDataPool.SetOpt(CURLSHoption.CURLSHOPT_SHARE, CURLlockData.CURL_LOCK_DATA_COOKIE);
            ConnectionDataPool.SetOpt(CURLSHoption.CURLSHOPT_SHARE, CURLlockData.CURL_LOCK_DATA_DNS);
            initDone = true;
        }

        private class EasyPool
        {
            private readonly Queue<Easy> availableHandles;
            private readonly object lockObj = new object();
            private readonly int maxHandles;

            public EasyPool(int maxHandles)
            {
                this.maxHandles = maxHandles;
                availableHandles = new Queue<Easy>(maxHandles);
            }

            public Easy GetHandle()
            {
                lock (lockObj)
                {
                    if (availableHandles.Count > 0)
                    {
                        return availableHandles.Dequeue();
                    }
                }
                return new Easy(); // when no handles in queue
            }

            public void ReturnHandle(Easy handle)
            {
                if (handle == null) return;

                lock (lockObj)
                {
                    if (availableHandles.Count < maxHandles)
                    {
                        availableHandles.Enqueue(handle);
                    }
                    else
                    {
                        handle.Cleanup();
                    }
                }
            }
        }

        public class Request
        {
            public JObject Perform(string endPoint, object parameters, string[] headers, Method reqType, string alternateBase = null) // Handles all requests Cerulean makes to the API.
            {
                Easy CurlRequest = null;
                JObject response = new JObject();
                try
                {
                    if (!initDone)
                    {
                        Initalize();
                    }

                    CurlRequest = CurlRequestPool.GetHandle(); // fetch from pool                   
                    string url = (alternateBase ?? Variables.PDSHost) + "/xrpc/" + endPoint;

                    StringBuilder jsonBuilder = new StringBuilder(); // the stringbuilder is because large messages are downloaded in chunks
                    Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData) // downloads the server response
                    {
                        int realSize = size * nmemb;
                        jsonBuilder.Append(System.Text.Encoding.UTF8.GetString(buf, 0, realSize));
                        return realSize;
                    };

                    Slist headerList = new Slist();
                    foreach (string header in headers)
                    {
                        headerList.Append(header);
                    }

                    switch (reqType)
                    {
                        case Method.Get:
                            CurlRequest.SetOpt(CURLoption.CURLOPT_HTTPGET, true);
                            url = url + "?" + parameters;
                            break;
                        case Method.Post:
                            CurlRequest.SetOpt(CURLoption.CURLOPT_POST, true);
                            CurlRequest.SetOpt(CURLoption.CURLOPT_POSTFIELDS, parameters);

                            break;
                        case Method.PostRaw:
                            CurlRequest.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, new Easy.WriteFunction((data, size, nmemb, extraData) =>
                            {
                                string responsse = Encoding.UTF8.GetString(data, 0, size * nmemb);
                                Console.WriteLine(responsse);
                                return size * nmemb;
                            }));
                            break;
                    }

                    CurlRequest.SetOpt(CURLoption.CURLOPT_HTTPHEADER, headerList);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_URL, url);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");
                    CurlRequest.SetOpt(CURLoption.CURLOPT_TIMEOUT, 10);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_SHARE, ConnectionDataPool);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_FORBID_REUSE, false);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_FRESH_CONNECT, false);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                    //CurlRequest.SetOpt(CURLoption.CURLOPT_VERBOSE, true);
                    //CurlRequest.SetOpt(CURLoption.CURLOPT_DEBUGFUNCTION, new Easy.DebugFunction(OnDebug));


                    CURLcode code = CurlRequest.Perform();

                    if (code != CURLcode.CURLE_OK)
                    {
                        response["error"] = code.ToString();
                        response["message"] = code.ToString();
                    }

                    try
                    {
                        response = JObject.Parse(jsonBuilder.ToString());
                    }

                    catch
                    {
                        response["error"] = "SKY_INVALID";
                    }

                }

                catch
                {
                    response["error"] = "SKY_UNEXPECTED";
                }

                finally
                {
                    if (CurlRequest != null)
                    {
                        CurlRequestPool.ReturnHandle(CurlRequest);
                    }
                }

                return response;
            }

            public MemoryStream PerformDownload(string url, int redirectFollows = 1)
            {
                Easy CurlRequest = null;
                MemoryStream stream = new MemoryStream();
                try
                {
                    if (!initDone)
                    {
                        Initalize();
                    }

                    CurlRequest = CurlRequestPool.GetHandle(); // fetch from pool 

                    Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData)
                    {
                        int realSize = size * nmemb;
                        stream.Write(buf, 0, realSize);
                        return realSize;
                    };

                    CurlRequest.SetOpt(CURLoption.CURLOPT_FORBID_REUSE, false);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_FRESH_CONNECT, false);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_URL, url);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");
                    CurlRequest.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                    CurlRequest.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, 1L); // follow redirects

                    CURLcode result = CurlRequest.Perform();
                    if (result != CURLcode.CURLE_OK)
                    {
                        Error.Throw(CurlRequest, result);
                        return null;
                    }

                    stream.Position = 0;                
                }

                catch (Exception ex)
                {
                    Display.Text("Media download failed: " + ex.Message);
                    return null;
                }

                finally
                {
                    if (CurlRequest != null)
                    {
                        CurlRequestPool.ReturnHandle(CurlRequest);
                    }                    
                }
                return stream;  
            }
        }

        private static void OnDebug(CURLINFOTYPE infoType, string msg, object extraData)
        {
            // You can filter here if you don’t want everything
            switch (infoType)
            {
                case CURLINFOTYPE.CURLINFO_HEADER_IN:
                    Display.Text("<< " + msg.TrimEnd());
                    break;
                case CURLINFOTYPE.CURLINFO_HEADER_OUT:
                    Display.Text(">> " + msg.TrimEnd());
                    break;
                case CURLINFOTYPE.CURLINFO_DATA_IN:
                    Display.Text("Received Data: " + msg.Length + " bytes");
                    break;
                case CURLINFOTYPE.CURLINFO_DATA_OUT:
                    Display.Text("Sent Data: " + msg.Length + " bytes");
                    break;
                default:
                    Display.Text(infoType + ": " + msg.TrimEnd());
                    break;
            }
        }
    }

    public static class Async // Backgroundworkers to simulate async in .NET 2 - 4.5. Temporary
    {
        public static BackgroundWorker skyWorker = null;
        public static void SkyWorker(DoWorkEventHandler workHandler, RunWorkerCompletedEventHandler completedHandler)
        {

            // Dispose and null any existing worker
            if (skyWorker != null)
            {
                skyWorker.Dispose();
                skyWorker = null;
            }

            // Create and configure a new BackgroundWorker
            skyWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            skyWorker.DoWork += workHandler;
            skyWorker.RunWorkerCompleted += (s, evt) =>
            {
                completedHandler(s, evt);

                // Optional cleanup after the run
                skyWorker.Dispose();
                //skyWorker = null;
            };

            skyWorker.RunWorkerAsync();
        }

    }

    public static class OAuth
    {
        public static void Login(string handle, string password)
        {

        }

        public static void Test()
        {
            OmegaAOL.OAuth.OAuthFlow.Test();
        }
    }

    public static class Auth // Authentication, password reset and token refresh through the legacy (non-OAuth) authorization pipeline.
    {
        public static JObject Login(string handle, string password, string code = null) // Logs in, returns accessJwt and refreshJwt
        {
            Variables.Handle = handle;

            var postJson = new JObject();
            postJson["identifier"] = handle;
            postJson["password"] = password;
            if (code != null) { postJson["authFactorToken"] = code; }

            string endPoint = "com.atproto.server.createSession";
            string postFields = postJson.ToString(Formatting.None);
            string[] headers = new string[1] { "Content-Type: application/json" };

            JObject authResponse = new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
            Refresher.Start(Refresher.Mode.Auto); // starts the 5-min-interval token refreshing method(s)
            return authResponse;
        }

        public static JObject LoginWithRefreshToken(string refreshToken, bool silenceRefresher = false)
        {
            string endPoint = "com.atproto.server.refreshSession";
            string[] headers = new string[2] { "Authorization: Bearer " + refreshToken, "Accept: application/json" };

            JObject authResponse = new Http.Request().Perform(endPoint, String.Empty, headers, Http.Method.Post);
            if (!silenceRefresher)
            {
                Refresher.Start(Refresher.Mode.Auto);
            }
            return authResponse;
        }


        public static class Reset
        {
            public static JObject RequestCode(string email)
            {
                var postJson = new JObject();
                postJson["email"] = email;

                string endPoint = "com.atproto.server.requestPasswordReset";
                string postFields = postJson.ToString(Formatting.None);
                string[] headers = new string[1] { "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
            }

            public static JObject Password(string token, string newpass)
            {
                var postJson = new JObject();
                postJson["token"] = token;
                postJson["password"] = newpass;

                string endPoint = "com.atproto.server.resetPassword";
                string postFields = postJson.ToString(Formatting.None);
                string[] headers = new string[1] { "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
            }
        }

        public static class Refresher // Refreshes authorization token in background
        {
            public enum Mode { Auto, Manual };
            private static System.Threading.Timer refreshTimer;
            private static bool manualRefreshTriggered = false;

            public static void Start(Mode mode) // function to start the process of token refreshing
            {
                if (mode == Mode.Auto) // uses the timer to refresh every 5 minutes
                {
                    refreshTimer = new System.Threading.Timer(RefreshAccessToken, null, 300000, 300000);
                }

                else if (mode == Mode.Manual) // instantly manually refreshes using skyWorker
                {
                    manualRefreshTriggered = true;
                    Async.SkyWorker(
                    delegate { RefreshAccessToken(null); },
                    delegate { manualRefreshTriggered = false; }
                    );
                }
            }

            public static void End()
            {
                refreshTimer.Dispose();
            }


            private static void RefreshAccessToken(object state) // function that actually gets refresh
            {
                JObject refreshBody = LoginWithRefreshToken(Variables.RefreshToken, true);
                //WEH.ErrHandler(refreshBody);

                if (refreshBody.SelectToken("error") != null)
                {
                    switch (refreshBody["error"].ToString())
                    {
                        case "ExpiredToken":
                            Display.Text("Your session has expired. Please log in again");
                            break;
                        default:
                            Display.Text("There was an error refreshing your session. You may be offline. Message: \n\n" + refreshBody["message"]);
                            break;
                    }
                }
                else
                {
                    Variables.Token = (string)refreshBody["accessJwt"];
                    Variables.RefreshToken = (string)refreshBody["refreshJwt"];
                    if (manualRefreshTriggered == true)
                    {
                        Display.Text("Reauthenticated with Bluesky successfully.");
                    }
                }

                //Global.reloadCount++; // Timer debug
                //Display.Text("[DEBUG] RELOADED TIMES: " + Global.reloadCount);
            }
        }
    }

    public class Tweet // handles posts (skeets, tweets), reposts, replies, quote posts, etc
    {
        public enum Type { Normal, Image, Reply, Quote, Repost };

        public class Defs
        {
            private const string preDef = "app.bsky.feed.defs#";
            public const string NotFound = preDef + "notFoundPost";
            public const string Blocked = preDef + "blockedPost";
            public const string View = preDef + "postView";
        }

        public static class Search
        {
            public static JObject Full(string query) // Searches for posts
            {
                query = query.Replace(" ", "%20");

                string endPoint = "app.bsky.feed.searchPosts";
                string getParam = "q=" + query;
                string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
            }
        }

        public static JObject Create(string text)
        {
            return TweetRecCreate(text, Type.Normal);
        }

        public static void Delete(string uri)
        {
            string rkey = uri.Substring(uri.LastIndexOf('/') + 1);
            Record.Delete("app.bsky.feed.post", rkey);
        }

        public static JObject FetchThread(string uri, int depth = 6, int parentHeight = 80)
        {
            string endPoint = "app.bsky.feed.getPostThread";
            string getParam = "uri=" + uri + "&depth=" + depth.ToString() + "&parentHeight=" + parentHeight.ToString();
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
        }

        public static JObject Reply(string text, JObject parent, JObject root)
        {
            return TweetRecCreate(text, Type.Reply, Strip(parent), Strip(root));
        }

        public static JObject Quote(string text, JObject parent)
        {
            return TweetRecCreate(text, Type.Quote, Strip(parent));
        }

        public static class Repost
        {
            public static string Add(JObject parent)
            {
                JObject response = TweetRecCreate(String.Empty, Type.Repost, Strip(parent), null, "app.bsky.feed.repost");
                return response["uri"].ToString();
            }

            public static void Remove(string uri)
            {
                string rkey = uri.Substring(uri.LastIndexOf('/') + 1);
                Record.Delete("app.bsky.feed.repost", rkey);
            }
        }

        public static class Like
        {
            public static string Add(JObject parent)
            {
                JObject response = TweetRecCreate(String.Empty, Type.Repost, Strip(parent), null, "app.bsky.feed.like");
                return response["uri"].ToString();
            }

            public static void Remove(string uri)
            {
                string rkey = uri.Substring(uri.LastIndexOf('/') + 1);
                Record.Delete("app.bsky.feed.like", rkey);
            }
        }

        private static JObject Strip(JObject toStrip)
        {
            JObject stripped = new JObject();
            stripped["uri"] = toStrip["uri"];
            stripped["cid"] = toStrip["cid"];
            return stripped;
        }

        private static JObject TweetRecCreate(string text, Type type, JObject parent = null, JObject root = null, string collection = "app.bsky.feed.post") // Tweets with user-settable settings
        {
            JObject record = TweetRecordMaker(text, type, parent, root);
            return Record.Create(collection, record);
        }

        private static JObject TweetRecordMaker(string text, Type type, JObject parent = null, JObject root = null)
        {
            JObject record = new JObject();

            if (type == Type.Repost)
            {
                record["subject"] = parent;
                record["createdAt"] = Tools.GetBlueskyDateTime();
            }

            else
            {
                record["$type"] = "app.bsky.feed.post";
                record["text"] = text;
                record["createdAt"] = Tools.GetBlueskyDateTime();

                if (Variables.BlobArray != null)
                {
                    JObject embed = new JObject();
                    embed["$type"] = "app.bsky.embed.images";
                    embed["images"] = Variables.BlobArray;
                    record["embed"] = embed;
                }

                if (type == Type.Reply)
                {
                    JObject reply = new JObject();
                    reply["root"] = root;
                    reply["parent"] = parent;
                    record["reply"] = reply;
                }

                else if (type == Type.Quote)
                {
                    JObject embed = new JObject();
                    embed["$type"] = "app.bsky.embed.record";
                    embed["record"] = parent;
                    record["embed"] = embed;
                }

            }

            // Display.Text(record.ToString()); // DEBUG
            return record;
        }
    }

    internal static class Record
    {
        public static JObject Create(string collection, JObject record)
        {
            var postJson = new JObject();
            postJson["repo"] = Variables.Handle;
            postJson["collection"] = collection;
            postJson["record"] = record;

            string endPoint = "com.atproto.repo.createRecord";
            string postFields = postJson.ToString(Formatting.None);
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
        }

        public static JObject Delete(string collection, string rkey)
        {
            var deleteJson = new JObject();
            deleteJson["repo"] = Variables.Handle;
            deleteJson["collection"] = collection;
            deleteJson["rkey"] = rkey;

            string endPoint = "com.atproto.repo.deleteRecord";
            string postFields = deleteJson.ToString(Formatting.None);
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
        }
    }

    public static class Account
    {
        public enum Verification { None, Verified, TrustedVerifier };

        public static JObject Create(string handle, string email = null, string password = null, string phoneNum = null, string displayName = null, string description = null, string inviteCode = null, string authCode = null)
        {
            JObject postJson = new JObject();
            postJson["handle"] = handle;
            string[] valuesArray = new string[] { email, password, phoneNum, displayName, description, inviteCode, authCode };
            string[] fieldsArray = new string[] { "email", "password", "verificationPhone", "displayName", "description", "inviteCode", "verificationCode" };
            for (int i = 0; i < valuesArray.Length; i++)
            {
                if (!String.IsNullOrEmpty(valuesArray[i]))
                {
                    postJson[fieldsArray[i]] = valuesArray[i]; // this particular request has a TON of optional fields, so just adding this function/array pair here to simplify
                }
            }
            string endPoint = "com.atproto.server.createAccount";
            string postFields = postJson.ToString(Formatting.None);
            string[] headers = new string[1] { "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
        }

        public static JObject Load(string did)
        {
            string endPoint = "app.bsky.actor.getProfile";
            string getParam = "actor=" + did;
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
        }

        public static class FetchData
        {
            public static JArray Followers(string did)
            {
                string endPoint = "app.bsky.graph.getFollowers";
                string getParam = "actor=" + did;
                string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };
                return (JArray)((new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get))["followers"]);
            }
        }

        public static class Follow
        {
            public static void Add(string did)
            {
                JObject record = new JObject();
                record["subject"] = did;
                record["createdAt"] = Tools.GetBlueskyDateTime();
                Record.Create("app.bsky.graph.follow", record).ToString();
            }

            public static void Remove(string uri)
            {
                string rkey = uri.Substring(uri.LastIndexOf('/') + 1);
                Record.Delete("app.bsky.graph.follow", rkey).ToString();
            }
        }

        public static string GetDid(string handle)
        {
            return HandleDidFetcher("com.atproto.identity.resolveHandle", "did", handle, "handle");
        }

        public static string GetHandle(string did)
        {
            return HandleDidFetcher("com.atproto.identity.resolveDid", "handle", did, "did");
        }

        private static string HandleDidFetcher(string endPoint, string tokenName, string input, string ogTokenName)
        {
            string getParam = ogTokenName + "=" + input;
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            JToken result = new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
            return result.SelectToken(tokenName).ToString();

        }

        public static class Search
        {
            public static JObject Typeahead(string search)
            {
                int limit = 100;
                string endPoint = "app.bsky.actor.searchActorsTypeahead";
                string getParam = "q=" + Uri.EscapeDataString(search) + "&limit=" + limit.ToString();
                string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
            }
        }
    }

    public static class Notifications
    {
        public static JArray Fetch() // Gets notifications
        {
            int limit = 100;
            string endPoint = "app.bsky.notification.listNotifications";
            string getParam = "limit=" + limit.ToString();
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return (JArray)(new Http.Request().Perform(endPoint, String.Empty, headers, Http.Method.Get))["notifications"];
        }
    }

    public static class Chats
    {
        public static JArray ListConversations() // Gets chat convos
        {
            int limit = 100;
            string endPoint = "chat.bsky.convo.listConvos";
            string getParam = "limit=" + limit.ToString();
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };
            string alternateUrl = Variables.ChatAPI;

            return (JArray)(new Http.Request().Perform(endPoint, String.Empty, headers, Http.Method.Get, alternateUrl))["convos"];
        }
    }

    public static class Feeds
    {
        public static JObject GetRecommendations() // Searches for posts
        {
            string endPoint = "app.bsky.feed.getSuggestedFeeds";
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            return new Http.Request().Perform(endPoint, String.Empty, headers, Http.Method.Get);
        }

        public static class Load
        {
            public static JObject Timeline()
            {
                string endPoint = "app.bsky.feed.getTimeline";
                string getParam = "algorithm=reverse-chronological";
                string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
            }

            public static JObject Custom(string uri)
            {
                string endPoint = "app.bsky.feed.getFeed";
                string getParam = "feed=" + uri;
                string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

                return new Http.Request().Perform(endPoint, getParam, headers, Http.Method.Get);
            }
        }
    }

    public static class PDS
    {
        public static string GetVersion()
        {
            string endPoint = "_health";
            string postFields = String.Empty;
            string[] headers = new string[1] { "Content-Type: application/json" };

            JObject reply = new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Get);

            if (reply.ContainsKey("version"))
            {
                return ((string)reply["version"]);
            }
            else
            {
                return "error";
            }
        }
    }

    public static class Report
    {
        public class Reason
        {
            private const string preDef = "com.atproto.moderation.defs";
            public const string Spam = preDef + "spam";
            public const string Violation = preDef + "violation";
            public const string Sexual = preDef + "sexual";
            public const string Rude = preDef + "rude";
            public const string Other = preDef + "other";
            public const string Appeal = preDef + "appeal";
        }

        public enum Type { User, Tweet };

        public static JObject File(Type repType, string modDef, string text, string uriOrDid, string cid = null)
        {
            var subj = new JObject();

            if (repType == Type.Tweet)
            {
                subj["$type"] = "com.atproto.repo.strongRef";
                subj["uri"] = uriOrDid;
                subj["cid"] = cid;
            }

            else if (repType == Type.User)
            {
                subj["$type"] = "com.atproto.admin.defs.repoRef";
                subj["did"] = uriOrDid;
            }

            var postJson = new JObject();
            postJson["reasonType"] = modDef;
            postJson["reason"] = text;
            postJson["subject"] = subj;

            string endPoint = "com.atproto.moderation.createReport";
            string postFields = postJson.ToString(Formatting.None);
            string[] headers = new string[2] { "Authorization: Bearer " + Variables.Token, "Content-Type: application/json" };

            MessageBox.Show(postFields);

            return new Http.Request().Perform(endPoint, postFields, headers, Http.Method.Post);
        }
    }

    public static class Media
    {
        public static JObject UploadBlob(byte[] imageBytes, string mimeType = "image/png")
        {
            StringBuilder responseBuilder = new StringBuilder();

            Easy easy = new Easy();
            easy.SetOpt(CURLoption.CURLOPT_URL, Variables.PDSHost + "/xrpc/com.atproto.repo.uploadBlob");
            easy.SetOpt(CURLoption.CURLOPT_CAINFO, "cacert.pem");

            // POST with binary body
            easy.SetOpt(CURLoption.CURLOPT_POST, 1);
            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, imageBytes);
            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDSIZE, imageBytes.Length);

            // headers
            Slist headers = new Slist();
            headers.Append("Content-Type: " + mimeType);
            headers.Append("Authorization: Bearer " + Variables.Token);
            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, headers);

            // capture response
            Easy.WriteFunction wf = delegate(byte[] buf, int size, int nmemb, object extraData)
            {
                int realSize = size * nmemb;
                responseBuilder.Append(Encoding.UTF8.GetString(buf, 0, realSize));
                return realSize;
            };
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);

            // perform
            CURLcode res = easy.Perform();
            if (res != CURLcode.CURLE_OK)
                throw new Exception("cURL error: " + easy.StrError(res));

            return JObject.Parse(responseBuilder.ToString());
        }

        public static class Image
        {
            public static System.Drawing.Image Load(string url)
            {
                return System.Drawing.Image.FromStream(new Http.Request().PerformDownload(url));
            }
        }

    }
}

