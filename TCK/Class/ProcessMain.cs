using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCK.Class.Crawler;
using TCK.Class.INI;
using TCK.Class.Keyboard;

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

        public List<Config> currentConfig = new List<Config>();

        public ProcessMain()
        {
            TwipCrawler.IsUrl = URL.TwipURL;
            ToonationCrawler.IsUrl = URL.ToonationURL;
            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.Start();
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
                        if (item.roulette == TwipCrawler.IsComment)
                        {
                            if (item.state == Config.EState.Click)
                            {
                                KeyClick(item.key, item.bCtrl, item.bAlt, item.bShift);
                            }
                            else if (item.state == Config.EState.NoneClick)
                            {
                                keyboardHook.AddNotInputKey((char)item.key, item.time);
                            }
                        }
                        TwipCrawler.IsRoulette = false;
                    }
                    else
                    {
                        if (item.amount == TwipCrawler.IsAmount)
                        {
                            if (item.state == Config.EState.Click)
                            {
                                KeyClick(item.key, item.bCtrl, item.bAlt, item.bShift);
                            }
                            else if (item.state == Config.EState.NoneClick)
                            {
                                keyboardHook.AddNotInputKey((char)item.key, item.time);
                            }
                        }
                    }
                }
                else
                {
                    if (ToonationCrawler.IsRoulette == true)
                    {
                        if (item.roulette == ToonationCrawler.IsComment)
                        {
                            if (item.state == Config.EState.Click)
                            {
                                KeyClick(item.key, item.bCtrl, item.bAlt, item.bShift);
                            }
                            else if (item.state == Config.EState.NoneClick)
                            {
                                keyboardHook.AddNotInputKey((char)item.key, item.time);
                            }
                        }
                        ToonationCrawler.IsRoulette = false;
                    }
                    else
                    {
                        if (item.amount == ToonationCrawler.IsAmount)
                        {
                            if (item.state == Config.EState.Click)
                            {
                                KeyClick(item.key, item.bCtrl, item.bAlt, item.bShift);
                            }
                            else if (item.state == Config.EState.NoneClick)
                            {
                                keyboardHook.AddNotInputKey((char)item.key, item.time);
                            }
                        }
                    }
                }
            }
        }
        private void KeyClick(Keys key, bool bCtrl, bool bAlt, bool bShift)
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

            KeyboardSimulator.KeyPress(key);

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
        }
    }
}
