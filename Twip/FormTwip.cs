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
using Twip.Class.Crawler;
using Twip.Class.INI;
using Twip.Class.Keyboard;
using Twip.Class;

namespace Twip
{
    public partial class FormTwip : Form
    {
        ProcessMain process = new ProcessMain();

        public FormTwip()
        {
            InitializeComponent();
            textBoxCurrentMessage.ReadOnly = true;
            textBoxAlertBox.Text = process.URL.URL;
            process.Crawler.IsUrl = process.URL.URL;
            Crawler.NewStateEvent += new NewState(NewState);
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
                addString += "Amount : " + item.amount;
                listBox1.Items.Add(addString);
            } 
        }

        private void buttonAlertBoxSave_Click(object sender, EventArgs e)
        {
            process.URL.URL = textBoxAlertBox.Text;
            process.URL.SaveINI();
            process.Crawler.IsUrl = process.URL.URL;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            process.Crawler.Dispose();
        }

        private void NewState()
        {
            this.Invoke(new Action(() => 
            {
                string text = $"NickName = {process.Crawler.IsNickName}\r\n";
                text += $"Amount = {process.Crawler.IsAmount}\r\n";
                text += $"Comment = {process.Crawler.IsComment}\r\n";

                textBoxCurrentMessage.Text = text;
            }));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            process.Crawler.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            process.Crawler.Stop();
        }

        private void timerState_Tick(object sender, EventArgs e)
        {
            labelKeyTime.Text = "";
            foreach (var item in process.keyboardHook.notInputKeys)
            {
                labelKeyTime.Text += " Key : " + item.key;
                labelKeyTime.Text += " Time : " + item.time.ToString("ss");
                labelKeyTime.Text += " EndTime : " + item.timeOut.ToString("ss");
            }
            if (process.Crawler.IsStarted == true)
            {
                buttonAlertBoxSave.Enabled = false;
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                textBoxAlertBox.Enabled = false;
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
                textBoxAlertBox.Enabled = true;
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
