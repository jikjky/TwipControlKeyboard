using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCK.Class;

namespace TCK
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
                else if(editConfig.state == Config.EState.NoneClick)
                {
                    radioButtonNoneClick.Checked = true;
                }
                else if (editConfig.state == Config.EState.MouseMove)
                {
                    radioButtonMove.Checked = true;
                }
                else if (editConfig.state == Config.EState.AbsMouseMove)
                {
                    radioButtonAbsMove.Checked = true;
                }
                metroComboBoxKey.Items.AddRange(Enum.GetNames(typeof(Keys)));
                metroComboBoxKey.SelectedIndex = metroComboBoxKey.Items.IndexOf(editConfig.key.ToString());
                textBoxAmount.Text = editConfig.amount.ToString();
                textBoxTime.Text = editConfig.time.ToString();
                metroTextBoxRoulette.Text = editConfig.roulette;
                checkBoxCtrl.Checked = editConfig.bCtrl;
                checkBoxAlt.Checked = editConfig.bAlt;
                checkBoxShift.Checked = editConfig.bShift;

                textBoxDelay.Text = editConfig.delay.ToString();

                metroComboBoxDirection.Items.AddRange(Enum.GetNames(typeof(TCK.Class.Config.EMoveDirection)));
                metroComboBoxDirection.SelectedIndex = metroComboBoxDirection.Items.IndexOf(editConfig.moveDirection.ToString());
                textBoxX.Text = editConfig.x.ToString();
                textBoxY.Text = editConfig.y.ToString();

                textBoxSpeed.Text = editConfig.speed.ToString();
            }
            else
            {
                metroComboBoxKey.Items.AddRange(Enum.GetNames(typeof(Keys)));
                metroComboBoxKey.SelectedIndex = 0;
                metroComboBoxDirection.Items.AddRange(Enum.GetNames(typeof(TCK.Class.Config.EMoveDirection)));
                metroComboBoxDirection.SelectedIndex = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButtonClick.Checked == true)
            {
                textBoxTime.Enabled = true;
                checkBoxCtrl.Enabled = true;
                checkBoxAlt.Enabled = true;
                checkBoxShift.Enabled = true;

                textBoxDelay.Enabled = true;

                metroComboBoxKey.Enabled = true;

                metroComboBoxDirection.Enabled = false;
                textBoxSpeed.Enabled = false;
                textBoxX.Enabled = false;
                textBoxY.Enabled = false;
            }
            else if(radioButtonNoneClick.Checked == true)
            {
                textBoxTime.Enabled = true;
                checkBoxCtrl.Enabled = false;
                checkBoxAlt.Enabled = false;
                checkBoxShift.Enabled = false;

                textBoxDelay.Enabled = true;

                metroComboBoxKey.Enabled = true;

                metroComboBoxDirection.Enabled = false;
                textBoxSpeed.Enabled = false;
                textBoxX.Enabled = false;
                textBoxY.Enabled = false;
            }
            else if (radioButtonMove.Checked == true)
            {
                textBoxTime.Enabled = true;
                checkBoxCtrl.Enabled = false;
                checkBoxAlt.Enabled = false;
                checkBoxShift.Enabled = false;

                textBoxDelay.Enabled = true;

                metroComboBoxKey.Enabled = false;

                metroComboBoxDirection.Enabled = true;
                textBoxSpeed.Enabled = true;
                textBoxX.Enabled = false;
                textBoxY.Enabled = false;
            }
            else if (radioButtonAbsMove.Checked == true)
            {
                textBoxTime.Enabled = false;
                checkBoxCtrl.Enabled = false;
                checkBoxAlt.Enabled = false;
                checkBoxShift.Enabled = false;

                textBoxDelay.Enabled = true;

                metroComboBoxKey.Enabled = false;

                metroComboBoxDirection.Enabled = false;
                textBoxSpeed.Enabled = false;
                textBoxX.Enabled = true;
                textBoxY.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int time;
            int amount;
            int delay;
            int x;
            int y;
            int speed;
            if (mIndex == -1)
            {
                Config newConfig = new Config();
                if (radioButtonClick.Checked == true)
                {
                    newConfig.state = Config.EState.Click;
                }
                else if (radioButtonNoneClick.Checked == true)
                {
                    newConfig.state = Config.EState.NoneClick;
                }
                else if (radioButtonMove.Checked == true)
                {
                    newConfig.state = Config.EState.MouseMove;
                }
                else if (radioButtonAbsMove.Checked == true)
                {
                    newConfig.state = Config.EState.AbsMouseMove;
                }
                newConfig.key = (Keys)Enum.Parse(typeof(Keys), metroComboBoxKey.Text);
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
                newConfig.roulette = metroTextBoxRoulette.Text;
                newConfig.amount = amount;
                newConfig.bCtrl = checkBoxCtrl.Checked;
                newConfig.bAlt = checkBoxAlt.Checked;
                newConfig.bShift = checkBoxShift.Checked;

                if (int.TryParse(textBoxDelay.Text, out delay) == false)
                {
                    MessageBox.Show("Delay is not Number");
                    return;
                }
                newConfig.delay = delay;

                if (int.TryParse(textBoxX.Text, out x) == false)
                {
                    MessageBox.Show("X is not Number");
                    return;
                }
                newConfig.x = x;

                if (int.TryParse(textBoxY.Text, out y) == false)
                {
                    MessageBox.Show("Y is not Number");
                    return;
                }
                newConfig.y = y;

                if (int.TryParse(textBoxSpeed.Text, out speed) == false)
                {
                    MessageBox.Show("Speed is not Number");
                    return;
                }
                newConfig.speed = speed;

                newConfig.moveDirection = (TCK.Class.Config.EMoveDirection)Enum.Parse(typeof(TCK.Class.Config.EMoveDirection), metroComboBoxDirection.Text);

                mProess.currentConfig.Add(newConfig);
            }
            else
            {
                Config editConfig = mProess.currentConfig[mIndex];
                if (radioButtonClick.Checked == true)
                {
                    editConfig.state = Config.EState.Click;
                }
                else if (radioButtonNoneClick.Checked == true)
                {
                    editConfig.state = Config.EState.NoneClick;
                }
                else if (radioButtonMove.Checked == true)
                {
                    editConfig.state = Config.EState.MouseMove;
                }
                else if (radioButtonAbsMove.Checked == true)
                {
                    editConfig.state = Config.EState.AbsMouseMove;
                }
                
                editConfig.key = (Keys)Enum.Parse(typeof(Keys), metroComboBoxKey.Text);
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
                editConfig.roulette = metroTextBoxRoulette.Text;
                editConfig.amount = amount;
                editConfig.bCtrl = checkBoxCtrl.Checked;
                editConfig.bAlt = checkBoxAlt.Checked;
                editConfig.bShift = checkBoxShift.Checked;

                if (int.TryParse(textBoxDelay.Text, out delay) == false)
                {
                    MessageBox.Show("Delay is not Number");
                    return;
                }
                editConfig.delay = delay;

                if (int.TryParse(textBoxX.Text, out x) == false)
                {
                    MessageBox.Show("X is not Number");
                    return;
                }
                editConfig.x = x;

                if (int.TryParse(textBoxY.Text, out y) == false)
                {
                    MessageBox.Show("Y is not Number");
                    return;
                }
                editConfig.y = y;

                if (int.TryParse(textBoxSpeed.Text, out speed) == false)
                {
                    MessageBox.Show("Speed is not Number");
                    return;
                }
                editConfig.speed = speed;

                editConfig.moveDirection = (TCK.Class.Config.EMoveDirection)Enum.Parse(typeof(TCK.Class.Config.EMoveDirection), metroComboBoxDirection.Text);
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
