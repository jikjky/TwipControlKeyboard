using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TCK.Class.ProcessMain;
using static TCK.Class.WebSocket;

namespace TCK.Class.Crawler
{
    public delegate void NewState(TCK.Class.ProcessMain.TwipOrToonation eTot);
    public class Crawler
    {
        private string mUrl;
        public bool IsStarted { get; set; }
        public bool IsRoulette { get; set; }
        public static event NewState NewStateEvent;

        public int DelayTime { get; set; }

        private TwipOrToonation MyProperty { get; set; }

        public enum EState
        {
            Nomal,
            Getting,
        }

        public string IsUrl
        {
            get
            {
                return mUrl;
            }
            set
            {
                mUrl = value;
            }
        }
        public string IsNickName { get; set; }
        public int IsAmount { get; set; }
        public string IsComment { get; set; }

        WebSocket webSocket;

        public Crawler(TwipOrToonation eTot)
        {
            MyProperty = eTot;
            IsStarted = false;
        }

        public void Start()
        {
            if (!string.IsNullOrEmpty(IsUrl))
            {
                webSocket = new WebSocket(IsUrl);
                if (MyProperty == TwipOrToonation.Toonation)
                {
                    webSocket.OnToonationObject += On_ToonationObject;
                }
                else if (MyProperty == TwipOrToonation.Twip)
                {
                    webSocket.OnTwipObject += On_TwipObject;
                }
            }
            else
            {
                IsComment = "시작 실패";
                NewStateEvent?.Invoke(MyProperty);
                return;
            }
            IsStarted = true;
        }

        public void Stop()
        {
            if (webSocket != null)
            { 
                webSocket.Close();
                if (MyProperty == TwipOrToonation.Toonation)
                {
                    webSocket.OnToonationObject -= On_ToonationObject;
                }
                else if (MyProperty == TwipOrToonation.Twip)
                {
                    webSocket.OnTwipObject -= On_TwipObject;
                }
            }
            IsStarted = false;
        }

        public void On_TwipObject(TwipObject value)
        {
            if (IsStarted == true)
            {
                if (webSocket.eCurrentMessageKind == EMessageKind.roulette)
                {
                    IsRoulette = true;
                    value.comment = value.slotmachine_data.items[value.slotmachine_data.gotcha - 1];
                    if (DelayTime < 2000)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(DelayTime - 1500);
                    }
                }
                IsNickName = value.nickname;
                IsAmount = value.amount;
                IsComment = value.comment;
                NewStateEvent?.Invoke(MyProperty);
            }
        }

        public void On_ToonationObject(ToonationObject value)
        {
            if (IsStarted == true)
            {
                if (webSocket.eCurrentMessageKind == EMessageKind.roulette)
                {
                    IsRoulette = true;
                    var splitValue = value.content.message.Split('-').ToList();
                    splitValue.RemoveAt(0);
                    splitValue[0] = splitValue[0].Remove(0, 1);
                    value.content.message = string.Join("-", splitValue);
                    if (DelayTime < 2000)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(DelayTime - 1500);
                    }
                }
                IsNickName = value.content.account;
                IsAmount = value.content.amount;

                IsComment = value.content.message;
                NewStateEvent?.Invoke(MyProperty);
            }
        }
    }
}
