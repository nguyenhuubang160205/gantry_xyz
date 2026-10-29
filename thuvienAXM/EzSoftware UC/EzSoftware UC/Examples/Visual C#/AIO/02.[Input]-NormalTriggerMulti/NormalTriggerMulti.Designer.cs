namespace NormalTriggerMulti
{
    partial class NormalTriggerMulti
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
            this.m_stcCh03 = new System.Windows.Forms.TextBox();
            this.m_stcCh02 = new System.Windows.Forms.TextBox();
            this.m_stcCh01 = new System.Windows.Forms.TextBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.m_cboModule = new System.Windows.Forms.ComboBox();
            this.m_cboVoltageRange = new System.Windows.Forms.ComboBox();
            this.m_stcCh00 = new System.Windows.Forms.TextBox();
            this.m_cboValueType = new System.Windows.Forms.ComboBox();
            this.m_btnStart = new System.Windows.Forms.Button();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Label5 = new System.Windows.Forms.Label();
            this.CH02 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.Label3 = new System.Windows.Forms.Label();
            this.Frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_stcCh03
            // 
            this.m_stcCh03.AcceptsReturn = true;
            this.m_stcCh03.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcCh03.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcCh03.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcCh03.Location = new System.Drawing.Point(229, 105);
            this.m_stcCh03.MaxLength = 0;
            this.m_stcCh03.Name = "m_stcCh03";
            this.m_stcCh03.ReadOnly = true;
            this.m_stcCh03.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcCh03.Size = new System.Drawing.Size(68, 21);
            this.m_stcCh03.TabIndex = 29;
            this.m_stcCh03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_stcCh02
            // 
            this.m_stcCh02.AcceptsReturn = true;
            this.m_stcCh02.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcCh02.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcCh02.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcCh02.Location = new System.Drawing.Point(158, 105);
            this.m_stcCh02.MaxLength = 0;
            this.m_stcCh02.Name = "m_stcCh02";
            this.m_stcCh02.ReadOnly = true;
            this.m_stcCh02.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcCh02.Size = new System.Drawing.Size(68, 21);
            this.m_stcCh02.TabIndex = 28;
            this.m_stcCh02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_stcCh01
            // 
            this.m_stcCh01.AcceptsReturn = true;
            this.m_stcCh01.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcCh01.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcCh01.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcCh01.Location = new System.Drawing.Point(88, 105);
            this.m_stcCh01.MaxLength = 0;
            this.m_stcCh01.Name = "m_stcCh01";
            this.m_stcCh01.ReadOnly = true;
            this.m_stcCh01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcCh01.Size = new System.Drawing.Size(68, 21);
            this.m_stcCh01.TabIndex = 26;
            this.m_stcCh01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.m_cboModule);
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Location = new System.Drawing.Point(9, 5);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(461, 44);
            this.Frame1.TabIndex = 21;
            this.Frame1.TabStop = false;
            this.Frame1.Text = "[Board No◈Module No◈Module ID]";
            // 
            // m_cboModule
            // 
            this.m_cboModule.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboModule.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboModule.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboModule.Location = new System.Drawing.Point(8, 16);
            this.m_cboModule.Name = "m_cboModule";
            this.m_cboModule.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboModule.Size = new System.Drawing.Size(445, 20);
            this.m_cboModule.TabIndex = 6;
            this.m_cboModule.SelectedIndexChanged += new System.EventHandler(this.m_cboModule_SelectedIndexChanged);
            // 
            // m_cboVoltageRange
            // 
            this.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboVoltageRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboVoltageRange.Location = new System.Drawing.Point(89, 59);
            this.m_cboVoltageRange.Name = "m_cboVoltageRange";
            this.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboVoltageRange.Size = new System.Drawing.Size(138, 20);
            this.m_cboVoltageRange.TabIndex = 20;
            this.m_cboVoltageRange.SelectedIndexChanged += new System.EventHandler(this.m_cboVoltageRange_SelectedIndexChanged);
            // 
            // m_stcCh00
            // 
            this.m_stcCh00.AcceptsReturn = true;
            this.m_stcCh00.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcCh00.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcCh00.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcCh00.Location = new System.Drawing.Point(17, 105);
            this.m_stcCh00.MaxLength = 0;
            this.m_stcCh00.Name = "m_stcCh00";
            this.m_stcCh00.ReadOnly = true;
            this.m_stcCh00.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcCh00.Size = new System.Drawing.Size(68, 21);
            this.m_stcCh00.TabIndex = 19;
            this.m_stcCh00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_cboValueType
            // 
            this.m_cboValueType.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboValueType.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboValueType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboValueType.Items.AddRange(new object[] {
            "00: Volt",
            "01: Digit"});
            this.m_cboValueType.Location = new System.Drawing.Point(310, 59);
            this.m_cboValueType.Name = "m_cboValueType";
            this.m_cboValueType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboValueType.Size = new System.Drawing.Size(152, 20);
            this.m_cboValueType.TabIndex = 18;
            this.m_cboValueType.SelectedIndexChanged += new System.EventHandler(this.m_cboValueType_SelectedIndexChanged);
            // 
            // m_btnStart
            // 
            this.m_btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnStart.Location = new System.Drawing.Point(310, 87);
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_btnStart.Size = new System.Drawing.Size(70, 37);
            this.m_btnStart.TabIndex = 17;
            this.m_btnStart.Text = "Start";
            this.m_btnStart.UseVisualStyleBackColor = false;
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
            // 
            // m_btnStop
            // 
            this.m_btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_btnStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnStop.Location = new System.Drawing.Point(389, 87);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_btnStop.Size = new System.Drawing.Size(70, 37);
            this.m_btnStop.TabIndex = 16;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = false;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(249, 89);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(33, 17);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "CH03";
            // 
            // CH02
            // 
            this.CH02.BackColor = System.Drawing.SystemColors.Control;
            this.CH02.Cursor = System.Windows.Forms.Cursors.Default;
            this.CH02.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CH02.Location = new System.Drawing.Point(178, 89);
            this.CH02.Name = "CH02";
            this.CH02.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CH02.Size = new System.Drawing.Size(33, 17);
            this.CH02.TabIndex = 27;
            this.CH02.Text = "CH02";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(109, 89);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(33, 17);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "CH01";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(18, 62);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(73, 17);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Volt.Range:";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(37, 89);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(33, 17);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "CH00";
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(234, 62);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(81, 17);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Value Type :";
            // 
            // NormalTriggerMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 140);
            this.Controls.Add(this.m_stcCh03);
            this.Controls.Add(this.m_stcCh02);
            this.Controls.Add(this.m_stcCh01);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.m_cboVoltageRange);
            this.Controls.Add(this.m_stcCh00);
            this.Controls.Add(this.m_cboValueType);
            this.Controls.Add(this.m_btnStart);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CH02);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NormalTriggerMulti";
            this.Text = "NormalTriggerMulti";
            this.Load += new System.EventHandler(this.NormalTriggerMulti_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NormalTriggerMulti_FormClosed);
            this.Frame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox m_stcCh03;
        public System.Windows.Forms.TextBox m_stcCh02;
        public System.Windows.Forms.TextBox m_stcCh01;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.ComboBox m_cboModule;
        public System.Windows.Forms.ComboBox m_cboVoltageRange;
        public System.Windows.Forms.TextBox m_stcCh00;
        public System.Windows.Forms.ComboBox m_cboValueType;
        public System.Windows.Forms.Button m_btnStart;
        public System.Windows.Forms.Button m_btnStop;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label CH02;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Timer m_timer;
        public System.Windows.Forms.Label Label3;
    }
}

