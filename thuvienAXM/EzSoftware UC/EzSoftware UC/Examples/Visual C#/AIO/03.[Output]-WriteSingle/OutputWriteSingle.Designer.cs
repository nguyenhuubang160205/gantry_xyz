namespace OutputWriteSingle
{
    partial class OutputWriteSingle
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
            this.m_sliSettingVoltage = new System.Windows.Forms.TrackBar();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.m_cboChannel = new System.Windows.Forms.ComboBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_stcOutputVoltage = new System.Windows.Forms.TextBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.m_cboModule = new System.Windows.Forms.ComboBox();
            this.m_cboVoltageRange = new System.Windows.Forms.ComboBox();
            this.m_edtSettingVoltage = new System.Windows.Forms.TextBox();
            this.m_btnSet = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_sliSettingVoltage)).BeginInit();
            this.Frame2.SuspendLayout();
            this.Frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_sliSettingVoltage
            // 
            this.m_sliSettingVoltage.Location = new System.Drawing.Point(186, 108);
            this.m_sliSettingVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.m_sliSettingVoltage.Name = "m_sliSettingVoltage";
            this.m_sliSettingVoltage.Size = new System.Drawing.Size(128, 45);
            this.m_sliSettingVoltage.TabIndex = 26;
            this.m_sliSettingVoltage.Scroll += new System.EventHandler(this.m_sliSettingVoltage_Scroll);
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
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
            this.Frame2.TabIndex = 18;
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
            this.m_cboChannel.TabIndex = 4;
            this.m_cboChannel.SelectedIndexChanged += new System.EventHandler(this.m_cboChannel_SelectedIndexChanged);
            // 
            // m_stcOutputVoltage
            // 
            this.m_stcOutputVoltage.AcceptsReturn = true;
            this.m_stcOutputVoltage.BackColor = System.Drawing.SystemColors.Window;
            this.m_stcOutputVoltage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_stcOutputVoltage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_stcOutputVoltage.Location = new System.Drawing.Point(113, 154);
            this.m_stcOutputVoltage.MaxLength = 0;
            this.m_stcOutputVoltage.Name = "m_stcOutputVoltage";
            this.m_stcOutputVoltage.ReadOnly = true;
            this.m_stcOutputVoltage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_stcOutputVoltage.Size = new System.Drawing.Size(193, 21);
            this.m_stcOutputVoltage.TabIndex = 24;
            this.m_stcOutputVoltage.Text = "0.0000";
            this.m_stcOutputVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.Frame1.TabIndex = 19;
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
            this.m_cboModule.TabIndex = 6;
            this.m_cboModule.SelectedIndexChanged += new System.EventHandler(this.m_cboModule_SelectedIndexChanged);
            // 
            // m_cboVoltageRange
            // 
            this.m_cboVoltageRange.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboVoltageRange.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_cboVoltageRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboVoltageRange.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboVoltageRange.Location = new System.Drawing.Point(113, 66);
            this.m_cboVoltageRange.Name = "m_cboVoltageRange";
            this.m_cboVoltageRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cboVoltageRange.Size = new System.Drawing.Size(224, 20);
            this.m_cboVoltageRange.TabIndex = 17;
            this.m_cboVoltageRange.SelectedIndexChanged += new System.EventHandler(this.m_cboVoltageRange_SelectedIndexChanged);
            // 
            // m_edtSettingVoltage
            // 
            this.m_edtSettingVoltage.AcceptsReturn = true;
            this.m_edtSettingVoltage.BackColor = System.Drawing.SystemColors.Window;
            this.m_edtSettingVoltage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_edtSettingVoltage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_edtSettingVoltage.Location = new System.Drawing.Point(113, 109);
            this.m_edtSettingVoltage.MaxLength = 0;
            this.m_edtSettingVoltage.Name = "m_edtSettingVoltage";
            this.m_edtSettingVoltage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_edtSettingVoltage.Size = new System.Drawing.Size(72, 21);
            this.m_edtSettingVoltage.TabIndex = 16;
            this.m_edtSettingVoltage.Text = "0.0000";
            this.m_edtSettingVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_btnSet
            // 
            this.m_btnSet.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnSet.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_btnSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnSet.Location = new System.Drawing.Point(366, 66);
            this.m_btnSet.Name = "m_btnSet";
            this.m_btnSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_btnSet.Size = new System.Drawing.Size(94, 108);
            this.m_btnSet.TabIndex = 15;
            this.m_btnSet.Text = "Set";
            this.m_btnSet.UseVisualStyleBackColor = false;
            this.m_btnSet.Click += new System.EventHandler(this.m_btnSet_Click);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(314, 157);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(25, 17);
            this.Label5.TabIndex = 25;
            this.Label5.Text = "Volt";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(18, 158);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(97, 17);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Output Voltage :";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(18, 69);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(97, 17);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Voltage Range :";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(18, 113);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(97, 17);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "Setting Voltage :";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(314, 112);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(25, 17);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "Volt";
            // 
            // OutputWriteSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 186);
            this.Controls.Add(this.m_sliSettingVoltage);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.m_stcOutputVoltage);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.m_cboVoltageRange);
            this.Controls.Add(this.m_edtSettingVoltage);
            this.Controls.Add(this.m_btnSet);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label3);
            this.Name = "OutputWriteSingle";
            this.Text = "OutputWriteSingle";
            this.Load += new System.EventHandler(this.OutputWriteSingle_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OutputWriteSingle_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.m_sliSettingVoltage)).EndInit();
            this.Frame2.ResumeLayout(false);
            this.Frame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TrackBar m_sliSettingVoltage;
        public System.Windows.Forms.Timer m_timer;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.ComboBox m_cboChannel;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.TextBox m_stcOutputVoltage;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.ComboBox m_cboModule;
        public System.Windows.Forms.ComboBox m_cboVoltageRange;
        public System.Windows.Forms.TextBox m_edtSettingVoltage;
        public System.Windows.Forms.Button m_btnSet;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
    }
}

