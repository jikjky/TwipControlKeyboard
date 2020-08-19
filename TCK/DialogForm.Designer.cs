namespace TCK
{
    partial class DialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSave = new MetroFramework.Controls.MetroButton();
            this.radioButtonClick = new MetroFramework.Controls.MetroRadioButton();
            this.buttonCancel = new MetroFramework.Controls.MetroButton();
            this.checkBoxCtrl = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxAlt = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxShift = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.textBoxAmount = new MetroFramework.Controls.MetroTextBox();
            this.textBoxTime = new MetroFramework.Controls.MetroTextBox();
            this.radioButtonNoneClick = new MetroFramework.Controls.MetroRadioButton();
            this.metroComboBoxKey = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxRoulette = new MetroFramework.Controls.MetroTextBox();
            this.radioButtonMove = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonAbsMove = new MetroFramework.Controls.MetroRadioButton();
            this.textBoxDelay = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.textBoxX = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.textBoxY = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxDirection = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.textBoxSpeed = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(500, 84);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // radioButtonClick
            // 
            this.radioButtonClick.AutoSize = true;
            this.radioButtonClick.Checked = true;
            this.radioButtonClick.Location = new System.Drawing.Point(19, 63);
            this.radioButtonClick.Name = "radioButtonClick";
            this.radioButtonClick.Size = new System.Drawing.Size(49, 15);
            this.radioButtonClick.TabIndex = 14;
            this.radioButtonClick.TabStop = true;
            this.radioButtonClick.Text = "Click";
            this.radioButtonClick.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(500, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(19, 145);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(42, 15);
            this.checkBoxCtrl.TabIndex = 16;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlt
            // 
            this.checkBoxAlt.AutoSize = true;
            this.checkBoxAlt.Location = new System.Drawing.Point(74, 145);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(38, 15);
            this.checkBoxAlt.TabIndex = 17;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(128, 145);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(47, 15);
            this.checkBoxShift.TabIndex = 18;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 110);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(29, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Key";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(19, 266);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Amount";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(19, 292);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(38, 19);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Time";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(81, 266);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(148, 20);
            this.textBoxAmount.TabIndex = 23;
            this.textBoxAmount.Text = "0";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(81, 292);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(148, 20);
            this.textBoxTime.TabIndex = 24;
            this.textBoxTime.Text = "0";
            // 
            // radioButtonNoneClick
            // 
            this.radioButtonNoneClick.AutoSize = true;
            this.radioButtonNoneClick.Location = new System.Drawing.Point(83, 63);
            this.radioButtonNoneClick.Name = "radioButtonNoneClick";
            this.radioButtonNoneClick.Size = new System.Drawing.Size(78, 15);
            this.radioButtonNoneClick.TabIndex = 25;
            this.radioButtonNoneClick.Text = "NoneClick";
            this.radioButtonNoneClick.UseVisualStyleBackColor = true;
            // 
            // metroComboBoxKey
            // 
            this.metroComboBoxKey.FormattingEnabled = true;
            this.metroComboBoxKey.ItemHeight = 23;
            this.metroComboBoxKey.Location = new System.Drawing.Point(77, 105);
            this.metroComboBoxKey.Name = "metroComboBoxKey";
            this.metroComboBoxKey.Size = new System.Drawing.Size(147, 29);
            this.metroComboBoxKey.TabIndex = 26;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(19, 240);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(57, 19);
            this.metroLabel4.TabIndex = 27;
            this.metroLabel4.Text = "Roulette";
            // 
            // metroTextBoxRoulette
            // 
            this.metroTextBoxRoulette.Location = new System.Drawing.Point(81, 240);
            this.metroTextBoxRoulette.Name = "metroTextBoxRoulette";
            this.metroTextBoxRoulette.Size = new System.Drawing.Size(148, 20);
            this.metroTextBoxRoulette.TabIndex = 28;
            // 
            // radioButtonMove
            // 
            this.radioButtonMove.AutoSize = true;
            this.radioButtonMove.Location = new System.Drawing.Point(176, 63);
            this.radioButtonMove.Name = "radioButtonMove";
            this.radioButtonMove.Size = new System.Drawing.Size(53, 15);
            this.radioButtonMove.TabIndex = 29;
            this.radioButtonMove.Text = "Move";
            this.radioButtonMove.UseVisualStyleBackColor = true;
            // 
            // radioButtonAbsMove
            // 
            this.radioButtonAbsMove.AutoSize = true;
            this.radioButtonAbsMove.Location = new System.Drawing.Point(244, 63);
            this.radioButtonAbsMove.Name = "radioButtonAbsMove";
            this.radioButtonAbsMove.Size = new System.Drawing.Size(76, 15);
            this.radioButtonAbsMove.TabIndex = 30;
            this.radioButtonAbsMove.Text = "Abs Move";
            this.radioButtonAbsMove.UseVisualStyleBackColor = true;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(81, 318);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(148, 20);
            this.textBoxDelay.TabIndex = 32;
            this.textBoxDelay.Text = "0";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(19, 318);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(41, 19);
            this.metroLabel5.TabIndex = 31;
            this.metroLabel5.Text = "Delay";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(298, 166);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(148, 20);
            this.textBoxX.TabIndex = 34;
            this.textBoxX.Text = "0";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(236, 166);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(17, 19);
            this.metroLabel6.TabIndex = 33;
            this.metroLabel6.Text = "X";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(298, 192);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(148, 20);
            this.textBoxY.TabIndex = 36;
            this.textBoxY.Text = "0";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(236, 192);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(17, 19);
            this.metroLabel7.TabIndex = 35;
            this.metroLabel7.Text = "Y";
            // 
            // metroComboBoxDirection
            // 
            this.metroComboBoxDirection.FormattingEnabled = true;
            this.metroComboBoxDirection.ItemHeight = 23;
            this.metroComboBoxDirection.Location = new System.Drawing.Point(299, 105);
            this.metroComboBoxDirection.Name = "metroComboBoxDirection";
            this.metroComboBoxDirection.Size = new System.Drawing.Size(147, 29);
            this.metroComboBoxDirection.TabIndex = 38;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(236, 110);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(61, 19);
            this.metroLabel8.TabIndex = 37;
            this.metroLabel8.Text = "Direction";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(298, 140);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(148, 20);
            this.textBoxSpeed.TabIndex = 40;
            this.textBoxSpeed.Text = "0";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(236, 140);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(46, 19);
            this.metroLabel9.TabIndex = 39;
            this.metroLabel9.Text = "Speed";
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 366);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroComboBoxDirection);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.radioButtonAbsMove);
            this.Controls.Add(this.radioButtonMove);
            this.Controls.Add(this.metroTextBoxRoulette);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroComboBoxKey);
            this.Controls.Add(this.radioButtonNoneClick);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.checkBoxShift);
            this.Controls.Add(this.checkBoxAlt);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.radioButtonClick);
            this.Controls.Add(this.buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 250);
            this.Name = "DialogForm";
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroButton buttonSave;
        private MetroFramework.Controls.MetroRadioButton radioButtonClick;
        private MetroFramework.Controls.MetroButton buttonCancel;
        private MetroFramework.Controls.MetroCheckBox checkBoxCtrl;
        private MetroFramework.Controls.MetroCheckBox checkBoxAlt;
        private MetroFramework.Controls.MetroCheckBox checkBoxShift;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox textBoxAmount;
        private MetroFramework.Controls.MetroTextBox textBoxTime;
        private MetroFramework.Controls.MetroRadioButton radioButtonNoneClick;
        private MetroFramework.Controls.MetroComboBox metroComboBoxKey;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRoulette;
        private MetroFramework.Controls.MetroRadioButton radioButtonMove;
        private MetroFramework.Controls.MetroRadioButton radioButtonAbsMove;
        private MetroFramework.Controls.MetroTextBox textBoxDelay;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox textBoxX;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox textBoxY;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox metroComboBoxDirection;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox textBoxSpeed;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}