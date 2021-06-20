namespace TCK
{
    partial class FormTCK
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTCK));
            this.panelTop = new System.Windows.Forms.Panel();
            this.metroTextBoxTwipDelay = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBoxAlertBoxToonation = new MetroFramework.Controls.MetroTextBox();
            this.buttonAlertBoxSave = new MetroFramework.Controls.MetroButton();
            this.textBoxAlertBoxTwip = new MetroFramework.Controls.MetroTextBox();
            this.labelAlertBox = new MetroFramework.Controls.MetroLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelKeyTime = new MetroFramework.Controls.MetroLabel();
            this.labelState = new MetroFramework.Controls.MetroLabel();
            this.textBoxCurrentMessage = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonStop = new MetroFramework.Controls.MetroButton();
            this.buttonStart = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDelete = new MetroFramework.Controls.MetroButton();
            this.buttonEdit = new MetroFramework.Controls.MetroButton();
            this.buttonAdd = new MetroFramework.Controls.MetroButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timerState = new System.Windows.Forms.Timer(this.components);
            this.metroTextBoxToonationDelay = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.metroTextBoxToonationDelay);
            this.panelTop.Controls.Add(this.metroLabel3);
            this.panelTop.Controls.Add(this.metroTextBoxTwipDelay);
            this.panelTop.Controls.Add(this.metroLabel2);
            this.panelTop.Controls.Add(this.metroLabel1);
            this.panelTop.Controls.Add(this.textBoxAlertBoxToonation);
            this.panelTop.Controls.Add(this.buttonAlertBoxSave);
            this.panelTop.Controls.Add(this.textBoxAlertBoxTwip);
            this.panelTop.Controls.Add(this.labelAlertBox);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(20, 60);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(810, 78);
            this.panelTop.TabIndex = 1;
            // 
            // metroTextBoxTwipDelay
            // 
            this.metroTextBoxTwipDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTextBoxTwipDelay.Location = new System.Drawing.Point(661, 7);
            this.metroTextBoxTwipDelay.Name = "metroTextBoxTwipDelay";
            this.metroTextBoxTwipDelay.Size = new System.Drawing.Size(61, 28);
            this.metroTextBoxTwipDelay.TabIndex = 12;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(562, 10);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Roulette Delay";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(5, 44);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Toonation";
            // 
            // textBoxAlertBoxToonation
            // 
            this.textBoxAlertBoxToonation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlertBoxToonation.Location = new System.Drawing.Point(75, 41);
            this.textBoxAlertBoxToonation.Name = "textBoxAlertBoxToonation";
            this.textBoxAlertBoxToonation.PasswordChar = '*';
            this.textBoxAlertBoxToonation.Size = new System.Drawing.Size(481, 28);
            this.textBoxAlertBoxToonation.TabIndex = 9;
            // 
            // buttonAlertBoxSave
            // 
            this.buttonAlertBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAlertBoxSave.Location = new System.Drawing.Point(728, 7);
            this.buttonAlertBoxSave.Name = "buttonAlertBoxSave";
            this.buttonAlertBoxSave.Size = new System.Drawing.Size(75, 28);
            this.buttonAlertBoxSave.TabIndex = 8;
            this.buttonAlertBoxSave.Text = "Save";
            this.buttonAlertBoxSave.Click += new System.EventHandler(this.buttonAlertBoxSave_Click);
            // 
            // textBoxAlertBoxTwip
            // 
            this.textBoxAlertBoxTwip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlertBoxTwip.Location = new System.Drawing.Point(75, 7);
            this.textBoxAlertBoxTwip.Name = "textBoxAlertBoxTwip";
            this.textBoxAlertBoxTwip.PasswordChar = '*';
            this.textBoxAlertBoxTwip.Size = new System.Drawing.Size(481, 28);
            this.textBoxAlertBoxTwip.TabIndex = 7;
            // 
            // labelAlertBox
            // 
            this.labelAlertBox.AutoSize = true;
            this.labelAlertBox.Location = new System.Drawing.Point(5, 10);
            this.labelAlertBox.Name = "labelAlertBox";
            this.labelAlertBox.Size = new System.Drawing.Size(35, 19);
            this.labelAlertBox.TabIndex = 7;
            this.labelAlertBox.Text = "Twip";
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.labelKeyTime);
            this.panelBottom.Controls.Add(this.labelState);
            this.panelBottom.Controls.Add(this.textBoxCurrentMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(20, 472);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(810, 128);
            this.panelBottom.TabIndex = 4;
            // 
            // labelKeyTime
            // 
            this.labelKeyTime.AutoSize = true;
            this.labelKeyTime.Location = new System.Drawing.Point(171, 98);
            this.labelKeyTime.Name = "labelKeyTime";
            this.labelKeyTime.Size = new System.Drawing.Size(38, 19);
            this.labelKeyTime.TabIndex = 10;
            this.labelKeyTime.Text = "State";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(7, 98);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(38, 19);
            this.labelState.TabIndex = 9;
            this.labelState.Text = "State";
            // 
            // textBoxCurrentMessage
            // 
            this.textBoxCurrentMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentMessage.Location = new System.Drawing.Point(7, 11);
            this.textBoxCurrentMessage.Multiline = true;
            this.textBoxCurrentMessage.Name = "textBoxCurrentMessage";
            this.textBoxCurrentMessage.Size = new System.Drawing.Size(794, 85);
            this.textBoxCurrentMessage.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(743, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 312);
            this.panel1.TabIndex = 5;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(5, 41);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 28);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(5, 7);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 28);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonEdit);
            this.panel2.Controls.Add(this.buttonAdd);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(20, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 312);
            this.panel2.TabIndex = 6;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(636, 75);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 28);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(636, 41);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 28);
            this.buttonEdit.TabIndex = 12;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(636, 7);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 28);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(624, 292);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // timerState
            // 
            this.timerState.Enabled = true;
            this.timerState.Tick += new System.EventHandler(this.timerState_Tick);
            // 
            // metroTextBoxToonationDelay
            // 
            this.metroTextBoxToonationDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTextBoxToonationDelay.Location = new System.Drawing.Point(661, 41);
            this.metroTextBoxToonationDelay.Name = "metroTextBoxToonationDelay";
            this.metroTextBoxToonationDelay.Size = new System.Drawing.Size(61, 28);
            this.metroTextBoxToonationDelay.TabIndex = 14;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(562, 44);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(93, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Roulette Delay";
            // 
            // FormTCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "FormTCK";
            this.Text = "T C K";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timerState;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton buttonAlertBoxSave;
        private MetroFramework.Controls.MetroTextBox textBoxAlertBoxTwip;
        private MetroFramework.Controls.MetroLabel labelAlertBox;
        private MetroFramework.Controls.MetroLabel labelState;
        private MetroFramework.Controls.MetroTextBox textBoxCurrentMessage;
        private MetroFramework.Controls.MetroButton buttonStop;
        private MetroFramework.Controls.MetroButton buttonStart;
        private MetroFramework.Controls.MetroButton buttonDelete;
        private MetroFramework.Controls.MetroButton buttonEdit;
        private MetroFramework.Controls.MetroButton buttonAdd;
        private MetroFramework.Controls.MetroLabel labelKeyTime;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBoxAlertBoxToonation;
        private MetroFramework.Controls.MetroTextBox metroTextBoxTwipDelay;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBoxToonationDelay;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}

