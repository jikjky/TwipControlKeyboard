using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twip.Class.Crawler;
using Twip.Class.INI;
using Twip.Class.Keyboard;

namespace Twip.Class
{
    public class ProcessMain
    {
        public Twip.Class.Crawler.Crawler Crawler = new Twip.Class.Crawler.Crawler();
        public URLIni URL = new URLIni(new FileInfo("URL.ini"));
        public KeyboardHook keyboardHook = new KeyboardHook();

        public List<Config> currentConfig = new List<Config>();

        public ProcessMain()
        {
            Crawler.IsUrl = URL.URL;
            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.Start();
            Twip.Class.Crawler.Crawler.NewStateEvent += new NewState(NewState);
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

        private void NewState()
        {
            foreach (var item in currentConfig)
            {
                if (item.amount == Crawler.IsAmount)
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
