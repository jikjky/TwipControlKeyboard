using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TCK.Class.ProcessMain;

namespace TCK.Class.Crawler
{
    public delegate void NewState(TCK.Class.ProcessMain.TwipOrToonation eTot);
    public class Crawler : IDisposable
    {
        ChromeDriverService mDriverService;
        ChromeDriver mDriver;
        private string mUrl;
        private bool mbGetting;
        private bool mbExitThread;
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
        Thread mThread;
        public Crawler(TwipOrToonation eTot)
        {
            MyProperty = eTot;
            mbExitThread = false;
            mbGetting = false;
            IsStarted = false;
            mDriverService = ChromeDriverService.CreateDefaultService();
            mDriverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();

            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArgument("headless");
            options.AddArgument("no-sandbox");
            options.AddArgument("autoplay-policy=no-user-gesture-required");
            options.AddArgument("--mute-audio");
            options.AddArgument("window-size=1920x1080");
            options.AddArgument("disable-gpu");
            options.AddArgument("lang=ko_KR");
            options.AddArgument("user-agent=Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36");
            mDriver = new ChromeDriver(mDriverService, options);
            mDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void Start()
        {
            try
            {
                if (IsUrl == string.Empty)
                    return;
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
            mDriver.Navigate().GoToUrl(new System.Uri(url));
        }

        private EState GetState()
        {
            try
            {
                if (MyProperty == TwipOrToonation.Twip)
                {
                    var idField = mDriver.FindElementById("body");
                    var classValue = idField.GetAttribute("class");
                    if (classValue == "layout-above")
                    {
                        return EState.Getting;
                    }
                    return EState.Nomal;
                }
                else
                {
                    var idField = mDriver.FindElementByClassName("content");
                    var divField = idField.FindElement(By.TagName("div"));
                    var classValue = divField.GetAttribute("class");
                    if (classValue == "alert-layout")
                    {
                        return EState.Getting;
                    }
                    return EState.Nomal;
                }
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
                if (MyProperty == TwipOrToonation.Twip)
                {
                    var idField = mDriver.FindElementById("nickname");
                    string returnValue = "";
                    foreach (var item in idField.FindElements(By.TagName("span")))
                    {
                        returnValue += item.Text;
                    }
                    return returnValue;
                }
                else
                {
                    var idField = mDriver.FindElementByClassName("text-system");
                    string returnValue = "";
                    int index = 0;
                    foreach (var item in idField.FindElements(By.TagName("span")))
                    {
                        if (index == 2)
                        {
                            returnValue += item.Text;
                            break;
                        }
                        index++;

                    }
                    return returnValue;
                }
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
                if (MyProperty == TwipOrToonation.Twip)
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
                else
                {
                    var idField = mDriver.FindElementByClassName("text-system");
                    string returnValue = "";
                    int index = 0;
                    foreach (var item in idField.FindElements(By.TagName("span")))
                    {
                        if (index == 4)
                        {
                            returnValue += item.Text;
                            break;
                        }
                        index++;
                        
                    }
                    returnValue = returnValue.Replace(",", "");
                    return Convert.ToInt32(returnValue);
                }

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
                if (MyProperty == TwipOrToonation.Twip)
                {
                    var idField = mDriver.FindElementById("comment");
                    var isRoulette = idField.FindElements(By.ClassName("candidate-inner"));
                    if (isRoulette.Count > 0)
                    {
                        if (DelayTime < 2000)
                        {
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Thread.Sleep(DelayTime - 1500);
                        }
                        string rouletteResult = "";
                        foreach (var item in isRoulette[0].FindElements(By.ClassName("candidate")))
                        {
                            if (item.Text != "")
                            {
                                rouletteResult = item.Text;
                            }
                        }
                        IsRoulette = true;
                        return rouletteResult;

                    }
                    string returnValue = idField.Text;

                    return returnValue;
                }
                else
                {
                    var idField = mDriver.FindElementByClassName("text-content");
                    string returnValue = "";
                    int index = 0;
                    foreach (var item in idField.FindElements(By.TagName("span")))
                    {
                        if (index == 1)
                        {
                            returnValue += item.Text;
                            break;
                        }

                        index++;   
                    }
                    return returnValue;
                }
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
                            var a = mDriver.Manage().Logs.GetLog(LogType.Browser);
                            
                            IsNickName = GetNickName();
                            IsAmount = GetAmount();
                            IsComment = GetComment();
                            NewStateEvent(MyProperty);
                            mbGetting = true;
                        }
                    }
                    else
                    {
                        mbGetting = false;
                    }
                }
                Thread.Sleep(50);
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
