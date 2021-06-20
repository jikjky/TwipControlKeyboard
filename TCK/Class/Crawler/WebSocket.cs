using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebSocketSharp;
using static TCK.Class.WebSocket;
using Quobject.Collections.Immutable;
using System.Diagnostics;
using System.Web;
using System.Threading;
using H.Socket.IO;

namespace TCK.Class
{
    public delegate void GetToonationObjectEvent(ToonationObject value);
    public delegate void GetTwipObjectEvent(TwipObject value);
    public class WebSocket
    {
        JsonSerializerSettings jsonSettings;
        WebSocketSharp.WebSocket webSocket;
        SocketIoClient client;
        public event GetToonationObjectEvent OnToonationObject;
        public event GetTwipObjectEvent OnTwipObject;
        string url = "";
        string title = "";
        bool bRealStop = false;
        string key = "";
        string version = "";
        string token = "";
        string payload = "";

        public EMessageKind eCurrentMessageKind { get; private set; }

        public enum EMessageKind
        {
            donate,
            roulette,
            cheer,
            follow,
            sub,
            hosting,
            redemption,
        }

        public WebSocket(string url_)
        {
            url = url_;
            GetPayload();
            if (title == "Toonation")
            {
                webSocket = new WebSocketSharp.WebSocket("wss://toon.at:8071/" + payload);
                webSocket.OnMessage += Ws_OnMessage;
                webSocket.OnClose += Ws_OnClose;
                webSocket.Connect();

            }
            else if (title == "Twip AlertBox")
            {
                string ioUrl = $"https://io.mytwip.net?alertbox_key={key}&version={version}&token={encodeURIComponent(token)}";

                var client = new SocketIoClient();
                client.Connected += (sender, args) => Debug.WriteLine($"Connected: {args.Namespace}");
                client.Disconnected += (sender, args) => Debug.WriteLine($"Disconnected. Reason: {args.Reason}, Status: {args.Status:G}");
                client.EventReceived += (sender, args) => Debug.WriteLine($"EventReceived: Namespace: {args.Namespace}, Value: {args.Value}, IsHandled: {args.IsHandled}");
                client.HandledEventReceived += (sender, args) => Debug.WriteLine($"HandledEventReceived: Namespace: {args.Namespace}, Value: {args.Value}");
                client.UnhandledEventReceived += (sender, args) => Debug.WriteLine($"UnhandledEventReceived: Namespace: {args.Namespace}, Value: {args.Value}");
                client.ErrorReceived += (sender, args) => Debug.WriteLine($"ErrorReceived: Namespace: {args.Namespace}, Value: {args.Value}");
                client.ExceptionOccurred += (sender, args) => Debug.WriteLine($"ExceptionOccurred: {args.Value}");
                client.On("new donate", message =>
                {
                    eCurrentMessageKind = EMessageKind.donate;
                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        if(obj.slotmachine_data != null)
                            eCurrentMessageKind = EMessageKind.roulette;
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.On("new cheer", message =>
                {
                    eCurrentMessageKind = EMessageKind.cheer;
                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.On("new follow", message =>
                {
                    eCurrentMessageKind = EMessageKind.follow;
                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.On("new sub", message =>
                {
                    eCurrentMessageKind = EMessageKind.sub;
                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.On("new hosting", message =>
                {
                    eCurrentMessageKind = EMessageKind.hosting;

                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.On("new redemption", message =>
                {
                    eCurrentMessageKind = EMessageKind.redemption;
                    Console.WriteLine(message);
                    var obj = JsonConvert.DeserializeObject<TwipObject>(message);
                    if (obj.effect != null)
                    {
                        OnTwipObject?.Invoke(obj);
                    }
                });
                client.ConnectAsync(new Uri(ioUrl)).Wait();

            }
            jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public string encodeURIComponent(string s)
        {
            var result = HttpUtility.UrlEncode(s,Encoding.UTF8);
            var resultData = result.Split('%');
            for (int i = 1; i < resultData.Length; i++)
            {
                var item1 = resultData[i][0].ToString().ToUpper();
                var item2 = resultData[i][1].ToString().ToUpper();

                resultData[i] = resultData[i].Remove(0, 2);
                resultData[i] = resultData[i].Insert(0, item2);
                resultData[i] = resultData[i].Insert(0, item1);
            }
            result = string.Join("%", resultData);
            return result;
        }

        public void GetPayload()
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string sitesource = client.DownloadString(url);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                doc.LoadHtml(sitesource);

                title = doc.DocumentNode.SelectSingleNode("//head/title").InnerText;


                payload = "";
                if (title == "Toonation")
                {
                    foreach (HtmlNode body in doc.DocumentNode.SelectNodes("//script"))
                    {
                        payload = body.OuterHtml;
                        if (payload.IndexOf("payload\":\"") != -1)
                        {
                            payload = payload.Remove(0, payload.IndexOf("payload\":\""));
                            payload = payload.Remove(payload.IndexOf("\",\""), payload.Length - payload.IndexOf("\",\""));
                            payload = payload.Remove(0, payload.IndexOf("\":\"") + 3);
                            break;
                        }
                    }
                }
                else if (title == "Twip AlertBox")
                {
                    foreach (HtmlNode body in doc.DocumentNode.SelectNodes("//script"))
                    {
                        payload = body.OuterHtml;
                        if (payload.IndexOf(" var AlertBox = {") != -1)
                        {
                            key = payload.Remove(0, payload.IndexOf("key:"));
                            key = key.Remove(0, key.IndexOf("'") + 1);
                            key = key.Remove(key.IndexOf("'"), key.Length - key.IndexOf("'"));

                            version = payload.Remove(0, payload.IndexOf("version:"));
                            version = version.Remove(0, version.IndexOf("'") + 1);
                            version = version.Remove(version.IndexOf("'"), version.Length - version.IndexOf("'"));
                        }
                        else if (payload.IndexOf("window.__TOKEN__ =") != -1)
                        {
                            token = payload.Remove(0, payload.IndexOf("window.__TOKEN__ ="));
                            token = token.Remove(0, token.IndexOf("'") + 1);
                            token = token.Remove(token.IndexOf("'"), token.Length - token.IndexOf("'"));
                        }
                    }
                }
            }
        }

        public void Close()
        {
            bRealStop = true;
            webSocket?.Close();
            client?.DisconnectAsync().Wait();
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            if (bRealStop == false)
                webSocket.Connect();
        }
        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            string requestMsg = Encoding.UTF8.GetString(e.RawData);
            var obj = JsonConvert.DeserializeObject<ToonationObject>(requestMsg);
            if (obj.content != null)
            {
                if (obj.code == 101)
                {
                    eCurrentMessageKind = EMessageKind.donate;
                    if(obj.code_ex == 700)
                        eCurrentMessageKind = EMessageKind.roulette;
                }
                else if (obj.code == 102)
                {
                    eCurrentMessageKind = EMessageKind.sub;
                }
                else if (obj.code == 103)
                {
                    eCurrentMessageKind = EMessageKind.follow;

                }
                else if (obj.code == 104)
                {
                    eCurrentMessageKind = EMessageKind.hosting;

                }
                else if (obj.code == 107)
                {
                    eCurrentMessageKind = EMessageKind.cheer;

                }
                else if (obj.code == 114)
                {
                    eCurrentMessageKind = EMessageKind.sub;

                }
                else if (obj.code == 115)
                {
                    eCurrentMessageKind = EMessageKind.sub;

                }
                OnToonationObject?.Invoke(obj);
            }
        }
        public class ToonationObject
        {
            public int test { get; set; }
            public int code { get; set; }
            public int code_ex { get; set; }
            public Content content { get; set; }
        }

        public class Content
        {
            public int amount { get; set; }
            public string uid { get; set; }
            public string account { get; set; }
            public string name { get; set; }
            public string image { get; set; }
            public int acctype { get; set; }
            public int test_noti { get; set; }
            public int level { get; set; }
            public string tts_locale { get; set; }
            public string tts_provider { get; set; }
            public string message { get; set; }
            public int conf_idx { get; set; }
            public string rec_link { get; set; }
            public object video_info { get; set; }
            public int video_begin { get; set; }
            public int video_length { get; set; }
            public string tts_link { get; set; }
        }



        public class TwipObject
        {
            public string _id { get; set; }
            public string nickname { get; set; }
            public int amount { get; set; }
            public int months { get; set; }
            public int viewers { get; set; }
            public string method { get; set; }
            public string comment { get; set; }
            public string watcher_id { get; set; }
            public bool subbed { get; set; }
            public bool repeat { get; set; }
            public string ttstype { get; set; }
            public object[] ttsurl { get; set; }
            public Slotmachine_Data slotmachine_data { get; set; }
            public Effect effect { get; set; }
        }

        public class Effect
        {
        }

        public class Slotmachine_Data
        {
            public string[] items { get; set; }
            public int gotcha { get; set; }
            public string reward_id { get; set; }
            public Config config { get; set; }
        }

        public class Config
        {
            public object[] sound { get; set; }
            public Dictionary<string,string> point { get; set; }
            public int duration { get; set; }
        }
    }
}
