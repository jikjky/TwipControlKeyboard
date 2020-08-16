using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using TCK.Class.Crawler;
using TCK.Class.INI;
using TCK.Class.Keyboard;
using TCK.Class;
using static TCK.Class.ProcessMain;

namespace TCK
{
    public partial class FormTCK : MetroFramework.Forms.MetroForm
    {
        ProcessMain process = new ProcessMain();

        public FormTCK()
        {
            InitializeComponent();
            textBoxCurrentMessage.ReadOnly = true;
            textBoxAlertBoxTwip.Text = process.URL.TwipURL;
            process.TwipCrawler.IsUrl = process.URL.TwipURL;
            process.TwipCrawler.DelayTime = process.URL.DelayTime;
            textBoxAlertBoxToonation.Text = process.URL.ToonationURL;
            metroTextBoxDelay.Text = process.URL.DelayTime.ToString();
            process.ToonationCrawler.IsUrl = process.URL.ToonationURL;
            Crawler.NewStateEvent += new NewState(NewState);
            if (new FileInfo("config.json").Exists == false)
            {
                process.SaveConfig();
            }
            process.LoadConfig();
            ListBoxUpdate();
        }

        public void ListBoxUpdate()
        {
            listBox1.Items.Clear();
            foreach (var item in process.currentConfig)
            {
                string addString = item.state.ToString() + "\t";
                if (item.state == Config.EState.Click)
                {
                    addString += "\t";
                }
                addString += "Key : " + item.key + "\t\t";
                addString += "Amount : " + item.amount + "\t\t";
                addString += "Roulette : " + item.roulette;
                listBox1.Items.Add(addString);
            } 
        }

        private void buttonAlertBoxSave_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(metroTextBoxDelay.Text, out value) == false)
            {
                MessageBox.Show("Delay Time is not number");
                return;
            }

            process.URL.DelayTime = value;
            process.URL.TwipURL = textBoxAlertBoxTwip.Text;
            process.URL.ToonationURL = textBoxAlertBoxToonation.Text;

            process.URL.SaveINI();
            process.TwipCrawler.IsUrl = process.URL.TwipURL;
            process.TwipCrawler.DelayTime = value;
            process.ToonationCrawler.IsUrl = process.URL.ToonationURL;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            process.TwipCrawler.Dispose();
            process.ToonationCrawler.Dispose();
        }

        private void NewState(TwipOrToonation eTot)
        {
            this.Invoke(new Action(() => 
            {
                string text = "";
                text += eTot.ToString() + "\r\n";
                if (eTot == TwipOrToonation.Twip)
                {
                    text += $"NickName = {process.TwipCrawler.IsNickName}\r\n";
                    text += $"Amount = {process.TwipCrawler.IsAmount}\r\n";
                    text += $"Comment = {process.TwipCrawler.IsComment}\r\n";
                }
                else
                {
                    text += $"NickName = {process.ToonationCrawler.IsNickName}\r\n";
                    text += $"Amount = {process.ToonationCrawler.IsAmount}\r\n";
                    text += $"Comment = {process.ToonationCrawler.IsComment}\r\n";
                }

                textBoxCurrentMessage.Text = text;
            }));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            process.TwipCrawler.Start();
            process.ToonationCrawler.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            process.TwipCrawler.Stop();
            process.ToonationCrawler.Stop();
        }

        private void timerState_Tick(object sender, EventArgs e)
        {
            string text = "";
            foreach (var item in process.keyboardHook.notInputKeys)
            {
                text += " Key : " + item.key;
                text += " Time : " + item.time.ToString("ss");
                text += " EndTime : " + item.timeOut.ToString("ss");

                labelKeyTime.Text = text;
            }
            if (process.keyboardHook.notInputKeys.Count == 0)
            {
                labelKeyTime.Text = "";
            }
            if (process.TwipCrawler.IsStarted == true || process.ToonationCrawler.IsStarted == true)
            {
                buttonAlertBoxSave.Enabled = false;
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                textBoxAlertBoxTwip.Enabled = false;
                textBoxAlertBoxToonation.Enabled = false;
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                labelState.Text = "IsRunning";
            }
            else
            {
                buttonAlertBoxSave.Enabled = true;
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                textBoxAlertBoxTwip.Enabled = true;
                textBoxAlertBoxToonation.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                labelState.Text = "Stop";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm(process, -1);
            dialogForm.ShowDialog();
            process.SaveConfig();
            ListBoxUpdate();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogForm dialogForm = new DialogForm(process, listBox1.SelectedIndex);
                dialogForm.ShowDialog();
                process.SaveConfig();
            }
            ListBoxUpdate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                process.currentConfig.RemoveAt(listBox1.SelectedIndex);
                process.SaveConfig();
            }
            ListBoxUpdate();
        }
    }
}
