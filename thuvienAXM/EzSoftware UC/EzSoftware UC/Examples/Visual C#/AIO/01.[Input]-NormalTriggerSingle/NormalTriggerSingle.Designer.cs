namespace NormalTriggerSingle
{
    partial class NormalTriggerSingle
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
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnStart = new System.Windows.Forms.Button();
            this.m_cboValueType = new System.Windows.Forms.ComboBox();
            this.m_stcReadValue = new System.Windows.Forms.TextBox();
            this.m_cboVoltageRange = new System.Windows.Forms.ComboBox();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.m_cboChannel = new System.Windows.Forms.ComboBox();
            this.m_stcValueType = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.m_cboModule = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.Frame2.SuspendLayout();
            this.Frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStop
            // 
            this.m_btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_btnStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnStop.Location = new System.Drawing.Point(386, 93);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_btnStop.Size = new System.Drawing.Size(74, 20);
            this.m_btnStop.TabIndex = 21;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = false;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnStart
            // 
            this.m_btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnStart.Location = new System.Drawing.Point(302, 93);
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_btnStart.Size = new System.Drawing.Size(74, 20);
            this.m_btnStart.TabIndex = 20;
            this.m_btnStart.Text = "Start";
            this.m_btnStart.UseVisualStyleBackColor = false;
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
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
            this.m_cboValueType.Location = new System.Drawing.Point(302, 65);
            this.m_cboValueType.Name = "m_cboValueType";
            this.m_cboValueType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboValueType.Size = new System.Drawing.Size(160, 20);
            this.m_cboValueType.TabIndex = 18;
            this.m_cboValueType.SelectedIndexChanged += new System.EventHandler(this.m_cboValueType_SelectedIndexChanged);
            // 
            // m_stcReadValue
            // 
            this.m_stcReadValue.AcceptsReturn = true;
            this.m_stcReadValue.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcReadValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcReadValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcReadValue.Location = new System.Drawing.Point(89, 93);
            this.m_stcReadValue.MaxLength = 0;
            this.m_stcReadValue.Name = "m_stcReadValue";
            this.m_stcReadValue.ReadOnly = true;
            this.m_stcReadValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcReadValue.Size = new System.Drawing.Size(120, 21);
            this.m_stcReadValue.TabIndex = 16;
            this.m_stcReadValue.Text = "0.0000";
            this.m_stcReadValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_cboVoltageRange
            // 
            this.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboVoltageRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboVoltageRange.Location = new System.Drawing.Point(89, 65);
            this.m_cboVoltageRange.Name = "m_cboVoltageRange";
            this.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboVoltageRange.Size = new System.Drawing.Size(120, 20);
            this.m_cboVoltageRange.TabIndex = 15;
            this.m_cboVoltageRange.SelectedIndexChanged += new System.EventHandler(this.m_cboVoltageRange_SelectedIndexChanged);
            // 
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.SystemColors.Control;
            this.Frame2.Controls.Add(this.m_cboChannel);
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Location = new System.Drawing.Point(357, 12);
            this.Frame2.Name = "Frame2";
            this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame2.Size = new System.Drawing.Size(113, 44);
            this.Frame2.TabIndex = 12;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "[Channel]";
            // 
            // m_cboChannel
            // 
            this.m_cboChannel.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboChannel.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboChannel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboChannel.Location = new System.Drawing.Point(8, 16);
            this.m_cboChannel.Name = "m_cboChannel";
            this.m_cboChannel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboChannel.Size = new System.Drawing.Size(97, 20);
            this.m_cboChannel.TabIndex = 12;
            this.m_cboChannel.SelectedIndexChanged += new System.EventHandler(this.m_cboChannel_SelectedIndexChanged);
            // 
            // m_stcValueType
            // 
            this.m_stcValueType.BackColor = System.Drawing.SystemColors.Control;
            this.m_stcValueType.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_stcValueType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_stcValueType.Location = new System.Drawing.Point(218, 96);
            this.m_stcValueType.Name = "m_stcValueType";
            this.m_stcValueType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcValueType.Size = new System.Drawing.Size(73, 17);
            this.m_stcValueType.TabIndex = 19;
            this.m_stcValueType.Text = "Volt";
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.m_cboModule);
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Location = new System.Drawing.Point(9, 12);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(338, 44);
            this.Frame1.TabIndex = 11;
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
            this.m_cboModule.Size = new System.Drawing.Size(321, 20);
            this.m_cboModule.TabIndex = 11;
            this.m_cboModule.SelectedIndexChanged += new System.EventHandler(this.m_cboModule_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(218, 69);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(81, 17);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "Value Type  :";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(10, 96);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(73, 17);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Read Value :";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(10, 69);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(73, 17);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "Volt. Range :";
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // NormalTriggerSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 127);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnStart);
            this.Controls.Add(this.m_cboValueType);
            this.Controls.Add(this.m_stcReadValue);
            this.Controls.Add(this.m_cboVoltageRange);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.m_stcValueType);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NormalTriggerSingle";
            this.Text = "NormalTriggerSingle";
            this.Load += new System.EventHandler(this.NormalTriggerSingle_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NormalTriggerSingle_FormClosed);
            this.Frame2.ResumeLayout(false);
            this.Frame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button m_btnStop;
        public System.Windows.Forms.Button m_btnStart;
        public System.Windows.Forms.ComboBox m_cboValueType;
        public System.Windows.Forms.TextBox m_stcReadValue;
        public System.Windows.Forms.ComboBox m_cboVoltageRange;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.ComboBox m_cboChannel;
        public System.Windows.Forms.Label m_stcValueType;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.ComboBox m_cboModule;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Timer m_timer;
    }
}

