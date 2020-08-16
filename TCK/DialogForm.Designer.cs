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
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(282, 63);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // radioButtonClick
            // 
            this.radioButtonClick.AutoSize = true;
            this.radioButtonClick.Location = new System.Drawing.Point(14, 63);
            this.radioButtonClick.Name = "radioButtonClick";
            this.radioButtonClick.Size = new System.Drawing.Size(49, 15);
            this.radioButtonClick.TabIndex = 14;
            this.radioButtonClick.TabStop = true;
            this.radioButtonClick.Text = "Click";
            this.radioButtonClick.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(282, 92);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.AutoSize = true;
            this.checkBoxCtrl.Location = new System.Drawing.Point(21, 206);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(42, 15);
            this.checkBoxCtrl.TabIndex = 16;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlt
            // 
            this.checkBoxAlt.AutoSize = true;
            this.checkBoxAlt.Location = new System.Drawing.Point(76, 206);
            this.checkBoxAlt.Name = "checkBoxAlt";
            this.checkBoxAlt.Size = new System.Drawing.Size(38, 15);
            this.checkBoxAlt.TabIndex = 17;
            this.checkBoxAlt.Text = "Alt";
            this.checkBoxAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.Location = new System.Drawing.Point(130, 206);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(47, 15);
            this.checkBoxShift.TabIndex = 18;
            this.checkBoxShift.Text = "Shift";
            this.checkBoxShift.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(29, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Key";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 148);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Amount";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 174);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(38, 19);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Time";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(76, 148);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(148, 20);
            this.textBoxAmount.TabIndex = 23;
            this.textBoxAmount.Text = "0";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(76, 174);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(148, 20);
            this.textBoxTime.TabIndex = 24;
            this.textBoxTime.Text = "0";
            // 
            // radioButtonNoneClick
            // 
            this.radioButtonNoneClick.AutoSize = true;
            this.radioButtonNoneClick.Location = new System.Drawing.Point(77, 63);
            this.radioButtonNoneClick.Name = "radioButtonNoneClick";
            this.radioButtonNoneClick.Size = new System.Drawing.Size(78, 15);
            this.radioButtonNoneClick.TabIndex = 25;
            this.radioButtonNoneClick.TabStop = true;
            this.radioButtonNoneClick.Text = "NoneClick";
            this.radioButtonNoneClick.UseVisualStyleBackColor = true;
            // 
            // metroComboBoxKey
            // 
            this.metroComboBoxKey.FormattingEnabled = true;
            this.metroComboBoxKey.ItemHeight = 23;
            this.metroComboBoxKey.Location = new System.Drawing.Point(77, 84);
            this.metroComboBoxKey.Name = "metroComboBoxKey";
            this.metroComboBoxKey.Size = new System.Drawing.Size(147, 29);
            this.metroComboBoxKey.TabIndex = 26;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(14, 122);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(57, 19);
            this.metroLabel4.TabIndex = 27;
            this.metroLabel4.Text = "Roulette";
            // 
            // metroTextBoxRoulette
            // 
            this.metroTextBoxRoulette.Location = new System.Drawing.Point(76, 122);
            this.metroTextBoxRoulette.Name = "metroTextBoxRoulette";
            this.metroTextBoxRoulette.Size = new System.Drawing.Size(148, 20);
            this.metroTextBoxRoulette.TabIndex = 28;
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 250);
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
            this.MaximumSize = new System.Drawing.Size(380, 250);
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
    }
}