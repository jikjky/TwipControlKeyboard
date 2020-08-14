using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twip.Class.Crawler
{
    public delegate void NewState();
    public class Crawler : IDisposable
    {
        ChromeDriverService mDriverService;
        ChromeDriver mDriver;
        private string mUrl;
        private bool mbGetting;
        private bool mbExitThread;
        public bool IsStarted { get; set; }
        public static event NewState NewStateEvent;

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
        Thread mThread;
        public Crawler()
        {
            mbExitThread = false;
            mbGetting = false;
            IsStarted = false;
            mDriverService = ChromeDriverService.CreateDefaultService();
            mDriverService.HideCommandPromptWindow = true;
            
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("window-size=1920x1080");
            options.AddArgument("disable-gpu");
            mDriver = new ChromeDriver(mDriverService, options);
        }

        public void Start()
        {
            try
            {
                if (IsStarted != true)
                {
                    GoToUrl(IsUrl);

                    mThread = new Thread(Excute);
                    mThread.IsBackground = true;
                    mbExitThread = false;
                    mThread.Start();

                    IsStarted = true;
                }
            }
            catch
            {
                IsStarted = false;
            }
        }

        public void Stop()
        {
            if (IsStarted != false)
            {
                mbExitThread = true;
                mThread.Join();
                mThread.Abort();

                IsStarted = false;
            }
        }

        private void GoToUrl(string url)
        {
            mDriver.Navigate().GoToUrl(url);
        }

        private EState GetState()
        {
            try
            {
                var idField = mDriver.FindElementById("body");
                var classValue = idField.GetAttribute("class");
                if (classValue == "layout-above")
                {
                    return EState.Getting;
                }
                return EState.Nomal;
            }
            catch
            {
                return EState.Nomal;
            }
        }
        private string GetNickName()
        {
            try
            {
                var idField = mDriver.FindElementById("nickname");
                string returnValue = "";
                foreach (var item in idField.FindElements(By.TagName("span")))
                {
                    returnValue += item.Text;
                }
                return returnValue;
            }
            catch
            {
                return "";
            }
        }

        private int GetAmount()
        {
            try
            {
                var idField = mDriver.FindElementById("amount");
                string returnValue = "";
                foreach (var item in idField.FindElements(By.TagName("span")))
                {
                    returnValue += item.Text;
                }
                returnValue = returnValue.Replace(",", "");

                return Convert.ToInt32(returnValue);
            }
            catch
            {
                return 0;
            }
        }

        private string GetComment()
        {
            try
            {
                var idField = mDriver.FindElementById("comment");
                string returnValue = idField.Text;

                return returnValue;
            }
            catch
            {
                return "";
            }
        }

        private void Excute()
        {
            EState currentState;
            while (mbExitThread == false)
            {
                if (IsUrl != "")
                {
                    currentState = GetState();
                    if (currentState == EState.Getting)
                    {
                        if (mbGetting == false)
                        {
                            IsNickName = GetNickName();
                            IsAmount = GetAmount();
                            IsComment = GetComment();
                            NewStateEvent();
                            mbGetting = true;
                        }
                    }
                    else
                    {
                        mbGetting = false;
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void Dispose()
        {
            mbExitThread = true;     
            mThread?.Join();
            mThread?.Abort();
            try
            {
                mDriver.Close();
            }
            catch
            {
            }
            mDriver.Dispose();
            mDriverService.Dispose();
            IsStarted = false;
        }
    }
}
