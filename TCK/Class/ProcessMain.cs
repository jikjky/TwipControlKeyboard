using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCK.Class.Crawler;
using TCK.Class.Hook;
using TCK.Class.INI;
using TKC.Class.Hook;

namespace TCK.Class
{
    public class ProcessMain
    {
        public enum TwipOrToonation
        {
            Twip,
            Toonation
        }
        public TCK.Class.Crawler.Crawler ToonationCrawler = new TCK.Class.Crawler.Crawler(TwipOrToonation.Toonation);
        public TCK.Class.Crawler.Crawler TwipCrawler = new TCK.Class.Crawler.Crawler(TwipOrToonation.Twip);

        public URLIni URL = new URLIni(new FileInfo("URL.ini"));

        public KeyboardHook keyboardHook = new KeyboardHook();
        public MouseHook mouseHook = new MouseHook();

        public List<Config> currentConfig = new List<Config>();

        public ProcessMain()
        {
            TwipCrawler.IsUrl = URL.TwipURL;
            ToonationCrawler.IsUrl = URL.ToonationURL;
            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.Start();

            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.Start();
            TCK.Class.Crawler.Crawler.NewStateEvent += new NewState(NewState);
        }
        public void SaveConfig()
        {
            string jsonString;
            jsonString = JsonConvert.SerializeObject(currentConfig);
            File.WriteAllText("config.json", jsonString);
        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
        }

        public void LoadConfig()
        {
            string jsonString;
            jsonString = File.ReadAllText("config.json");
            currentConfig = JsonConvert.DeserializeObject<List<Config>>(jsonString);
        }

        private void NewState(TwipOrToonation eTot)
        {
            foreach (var item in currentConfig)
            {
                if (eTot == TwipOrToonation.Twip)
                {
                    if (TwipCrawler.IsRoulette == true)
                    {
                        if (TwipCrawler.IsComment == item.roulette)
                        {
                            ExcuteControl(item);
                        }
                    }
                    else
                    {
                        if (item.amount == TwipCrawler.IsAmount)
                        {
                            ExcuteControl(item);
                        }
                    }
                }
                else
                {
                    if (ToonationCrawler.IsRoulette == true)
                    {
                        if (ToonationCrawler.IsComment == item.roulette)
                        {
                            ExcuteControl(item);
                        }
                    }
                    else
                    {
                        if (item.amount == ToonationCrawler.IsAmount)
                        {
                            ExcuteControl(item);
                        }
                    }
                }
            }
            if (eTot == TwipOrToonation.Twip)
            {
                TwipCrawler.IsRoulette = false;
            }
            else
            {
                ToonationCrawler.IsRoulette = false;
            }
        }

        private void ExcuteControl(Config item)
        {
            if (item.state == Config.EState.Click)
            {
                new Thread(() =>
                {
                    DateTime objCurrentTime = new DateTime();
                    objCurrentTime = DateTime.Now;

                    while (true)
                    {
                        var time = DateTime.Now - objCurrentTime;
                        if (item.delay < time.TotalMilliseconds)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }
                    if (item.key == Keys.LButton || item.key == Keys.RButton || item.key == Keys.MButton || item.key == Keys.XButton1 || item.key == Keys.XButton2)
                    {
                        MouseClick(item.key, item.time);
                    }                                                                    
                    else
                    {                                                                
                        KeyClick(item.key,item.time , item.bCtrl, item.bAlt, item.bShift);
                    }
                }).Start();
            }
            else if (item.state == Config.EState.NoneClick)
            {
                if (item.key == Keys.LButton || item.key == Keys.RButton || item.key == Keys.MButton || item.key == Keys.XButton1 || item.key == Keys.XButton2)
                {
                    new Thread(() =>
                    {
                        DateTime objCurrentTime = new DateTime();
                        objCurrentTime = DateTime.Now;

                        while (true)
                        {
                            var time = DateTime.Now - objCurrentTime;
                            if (item.delay < time.TotalMilliseconds)
                            {
                                break;
                            }
                            Thread.Sleep(10);
                        }
                        mouseHook.AddNotInputKey(item.key, item.time);
                    }).Start();
                }
                else
                {
                    new Thread(() =>
                    {
                        DateTime objCurrentTime = new DateTime();
                        objCurrentTime = DateTime.Now;

                        while (true)
                        {
                            var time = DateTime.Now - objCurrentTime;
                            if (item.delay < time.TotalMilliseconds)
                            {
                                break;
                            }
                            Thread.Sleep(10);
                        }
                        keyboardHook.AddNotInputKey(item.key, item.time);
                    }).Start();                       
                }
            }
            else if (item.state == Config.EState.MouseMove)
            {
                new Thread(() =>
                {
                    DateTime objCurrentTime = new DateTime();
                    objCurrentTime = DateTime.Now;

                    while (true)
                    {
                        var time = DateTime.Now - objCurrentTime;
                        if (item.delay < time.TotalMilliseconds)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }

                    objCurrentTime = DateTime.Now;

                    while (true)
                    {
                        var time = DateTime.Now - objCurrentTime;
                        if (item.time < time.TotalMilliseconds)
                        {
                            break;
                        }
                        if (item.moveDirection == Config.EMoveDirection.Left || item.moveDirection == Config.EMoveDirection.Right)
                        {
                            int x = MouseSimulator.X;
                            if (item.moveDirection == Config.EMoveDirection.Left)
                            {
                                MouseMove.ExecuteMove(-item.speed, 0);
                                x -= item.speed;
                            }
                            else
                            {
                                MouseMove.ExecuteMove(item.speed, 0);
                                x += item.speed;
                            }
                        }
                        else
                        {
                            int y = MouseSimulator.Y;
                            if (item.moveDirection == Config.EMoveDirection.Bottom)
                            {
                                MouseMove.ExecuteMove(0, item.speed);
                                y += item.speed;
                            }
                            else
                            {
                                MouseMove.ExecuteMove(0, -item.speed);
                                y -= item.speed;
                            }
                        }
                        Thread.Sleep(10);
                    }
                }).Start();
            }
            else if (item.state == Config.EState.AbsMouseMove)
            {
                new Thread(() =>
                {
                    DateTime objCurrentTime = new DateTime();
                    objCurrentTime = DateTime.Now;

                    while (true)
                    {
                        var time = DateTime.Now - objCurrentTime;
                        if (item.delay < time.TotalMilliseconds)
                        {                                                  
                            break;
                        }
                        Thread.Sleep(10);
                    }
                    MouseSimulator.X = item.x;
                    MouseSimulator.Y = item.y;
                }).Start();
            }
        }

        private void KeyClick(Keys key,int pressTime, bool bCtrl, bool bAlt, bool bShift)
        {
            if (bCtrl == true)
            {
                KeyboardSimulator.KeyDown(Keys.Control);
            }
            if (bAlt == true)
            {
                KeyboardSimulator.KeyDown(Keys.Alt);
            }
            if (bShift == true)
            {
                KeyboardSimulator.KeyDown(Keys.Shift);
            }

            KeyboardSimulator.KeyDown(key);


            new Thread(() =>
            {
                DateTime objCurrentTime = new DateTime();
                objCurrentTime = DateTime.Now;

                while (true)
                {
                    var time = DateTime.Now - objCurrentTime;
                    if (pressTime < time.TotalMilliseconds)
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }

                KeyboardSimulator.KeyUp(key);

                if (bCtrl == true)
                {
                    KeyboardSimulator.KeyUp(Keys.Control);
                }
                if (bAlt == true)
                {
                    KeyboardSimulator.KeyUp(Keys.Alt);
                }
                if (bShift == true)
                {
                    KeyboardSimulator.KeyUp(Keys.Shift);
                }
            }).Start();
        }

        private void MouseClick(Keys key, int pressTime)
        {
            if (key == Keys.LButton)
            {
                MouseSimulator.MouseDown(MouseButtons.Left);
            }
            else if (key == Keys.RButton)
            {
                MouseSimulator.MouseDown(MouseButtons.Right);
            }
            else if (key == Keys.MButton)
            {
                MouseSimulator.MouseDown(MouseButtons.Middle);
            }
            else if (key == Keys.XButton1)
            {
                MouseSimulator.MouseDown(MouseButtons.XButton1);
            }
            else if (key == Keys.XButton2)
            {
                MouseSimulator.MouseDown(MouseButtons.XButton2);
            }

            new Thread(() =>
            {
                DateTime objCurrentTime = new DateTime();
                objCurrentTime = DateTime.Now;

                while (true)
                {
                    var time = DateTime.Now - objCurrentTime;
                    if (pressTime < time.TotalMilliseconds)
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }

                if (key == Keys.LButton)
                {
                    MouseSimulator.MouseUp(MouseButtons.Left);
                }
                else if (key == Keys.RButton)
                {
                    MouseSimulator.MouseUp(MouseButtons.Right);
                }
                else if (key == Keys.MButton)
                {
                    MouseSimulator.MouseUp(MouseButtons.Middle);
                }
                else if (key == Keys.XButton1)
                {
                    MouseSimulator.MouseUp(MouseButtons.XButton1);
                }
                else if (key == Keys.XButton2)
                {
                    MouseSimulator.MouseUp(MouseButtons.XButton2);
                }
            }).Start();
        }
    }
}
