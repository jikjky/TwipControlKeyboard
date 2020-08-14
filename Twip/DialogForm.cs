using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twip.Class;

namespace Twip
{
    public partial class DialogForm : MetroFramework.Forms.MetroForm
    {
        ProcessMain mProess;
        int mIndex;
        public DialogForm(ProcessMain process, int index)
        {
            InitializeComponent();
            mProess = process;
            mIndex = index;

            if (mIndex != -1)
            {
                Config editConfig = mProess.currentConfig[mIndex];
                if (editConfig.state == Config.EState.Click)
                {
                    radioButtonClick.Checked = true;
                }
                else
                {
                    radioButtonNoneClick.Checked = true;
                }
                textBoxKey.Text = ((char)editConfig.key).ToString();
                textBoxAmount.Text = editConfig.amount.ToString();
                textBoxTime.Text = editConfig.time.ToString();  
                checkBoxCtrl.Checked = editConfig.bCtrl;
                checkBoxAlt.Checked = editConfig.bAlt;
                checkBoxShift.Checked = editConfig.bShift;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButtonClick.Checked == true)
            {
                textBoxTime.Enabled = false;
                checkBoxCtrl.Enabled = true;
                checkBoxAlt.Enabled = true;
                checkBoxShift.Enabled = true;
            }
            else
            {
                textBoxTime.Enabled = true;
                checkBoxCtrl.Enabled = false;
                checkBoxAlt.Enabled = false;
                checkBoxShift.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int time;
            int amount;
            if (textBoxKey.Text.Length == 0)
            {
                MessageBox.Show("Empty Key");
                return;
            }
            if (mIndex == -1)
            {
                Config newConfig = new Config();
                newConfig.state = radioButtonClick.Checked == true ? Config.EState.Click : Config.EState.NoneClick;
                newConfig.key = (Keys)Enum.Parse(typeof(Keys), textBoxKey.Text.ToUpper());
                if (int.TryParse(textBoxTime.Text, out time) == false)
                {
                    MessageBox.Show("Time is not Number");
                    return;
                }
                newConfig.time = time;
                if (int.TryParse(textBoxAmount.Text, out amount) == false)
                {
                    MessageBox.Show("Amount is not Number");
                    return;
                }
                newConfig.amount = amount;
                newConfig.bCtrl = checkBoxCtrl.Checked;
                newConfig.bAlt = checkBoxAlt.Checked;
                newConfig.bShift = checkBoxShift.Checked;
                mProess.currentConfig.Add(newConfig);
            }
            else
            {
                Config editConfig = mProess.currentConfig[mIndex];
                editConfig.state = radioButtonClick.Checked == true ? Config.EState.Click : Config.EState.NoneClick;
                editConfig.key = (Keys)Enum.Parse(typeof(Keys), textBoxKey.Text.ToUpper());
                if (int.TryParse(textBoxTime.Text, out time) == false)
                {
                    MessageBox.Show("Time is not Number");
                    return;
                }
                editConfig.time = time;
                if (int.TryParse(textBoxAmount.Text, out amount) == false)
                {
                    MessageBox.Show("Amount is not Number");
                    return;
                }
                editConfig.amount = amount;
                editConfig.bCtrl = checkBoxCtrl.Checked;
                editConfig.bAlt = checkBoxAlt.Checked;
                editConfig.bShift = checkBoxShift.Checked;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {

        }
    }
}
