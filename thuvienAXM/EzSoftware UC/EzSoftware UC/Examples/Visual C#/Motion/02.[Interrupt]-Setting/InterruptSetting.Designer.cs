namespace InterruptSetting
{
    partial class InterruptSetting
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSelAxis = new System.Windows.Forms.ComboBox();
            this.GrpBank1 = new System.Windows.Forms.GroupBox();
            this.btnSetBank1 = new System.Windows.Forms.Button();
            this.chkBank1Bit31 = new System.Windows.Forms.CheckBox();
            this.Divide = new System.Windows.Forms.GroupBox();
            this.chkBank1Bit02 = new System.Windows.Forms.CheckBox();
            this.chkBank1Bit01 = new System.Windows.Forms.CheckBox();
            this.chkBank1Bit00 = new System.Windows.Forms.CheckBox();
            this.GrpBank2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetBank2 = new System.Windows.Forms.Button();
            this.chkBank2Bit22 = new System.Windows.Forms.CheckBox();
            this.chkBank2Bit21 = new System.Windows.Forms.CheckBox();
            this.chkBank2Bit20 = new System.Windows.Forms.CheckBox();
            this.chkBank2Bit16 = new System.Windows.Forms.CheckBox();
            this.chkBank2Bit15 = new System.Windows.Forms.CheckBox();
            this.chkBank2Bit14 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoEvent = new System.Windows.Forms.RadioButton();
            this.rdoCallback = new System.Windows.Forms.RadioButton();
            this.rdoMessage = new System.Windows.Forms.RadioButton();
            this.lstIntLog = new System.Windows.Forms.ListBox();
            this.chkIntEnable = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.GrpBank1.SuspendLayout();
            this.GrpBank2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No :";
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(114, 9);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(340, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboAxisSet_SelectedIndexChanged);
            // 
            // GrpBank1
            // 
            this.GrpBank1.Controls.Add(this.btnSetBank1);
            this.GrpBank1.Controls.Add(this.chkBank1Bit31);
            this.GrpBank1.Controls.Add(this.Divide);
            this.GrpBank1.Controls.Add(this.chkBank1Bit02);
            this.GrpBank1.Controls.Add(this.chkBank1Bit01);
            this.GrpBank1.Controls.Add(this.chkBank1Bit00);
            this.GrpBank1.Location = new System.Drawing.Point(9, 41);
            this.GrpBank1.Name = "GrpBank1";
            this.GrpBank1.Size = new System.Drawing.Size(456, 122);
            this.GrpBank1.TabIndex = 3;
            this.GrpBank1.TabStop = false;
            this.GrpBank1.Text = "< Interrupt Event Bank 1 [0x00000000] >";
            // 
            // btnSetBank1
            // 
            this.btnSetBank1.Location = new System.Drawing.Point(318, 98);
            this.btnSetBank1.Name = "btnSetBank1";
            this.btnSetBank1.Size = new System.Drawing.Size(137, 22);
            this.btnSetBank1.TabIndex = 5;
            this.btnSetBank1.Text = "Set Bank 1";
            this.btnSetBank1.UseVisualStyleBackColor = true;
            this.btnSetBank1.Click += new System.EventHandler(this.btnSetBank1_Click);
            // 
            // chkBank1Bit31
            // 
            this.chkBank1Bit31.AutoSize = true;
            this.chkBank1Bit31.Location = new System.Drawing.Point(11, 96);
            this.chkBank1Bit31.Name = "chkBank1Bit31";
            this.chkBank1Bit31.Size = new System.Drawing.Size(303, 16);
            this.chkBank1Bit31.TabIndex = 4;
            this.chkBank1Bit31.Text = "[Bit 31] Interrupt occurrence command execution";
            this.chkBank1Bit31.UseVisualStyleBackColor = true;
            // 
            // Divide
            // 
            this.Divide.Location = new System.Drawing.Point(29, 79);
            this.Divide.Name = "Divide";
            this.Divide.Size = new System.Drawing.Size(413, 10);
            this.Divide.TabIndex = 3;
            this.Divide.TabStop = false;
            // 
            // chkBank1Bit02
            // 
            this.chkBank1Bit02.AutoSize = true;
            this.chkBank1Bit02.Location = new System.Drawing.Point(11, 65);
            this.chkBank1Bit02.Name = "chkBank1Bit02";
            this.chkBank1Bit02.Size = new System.Drawing.Size(174, 16);
            this.chkBank1Bit02.TabIndex = 2;
            this.chkBank1Bit02.Text = "[Bit 02] When drive started";
            this.chkBank1Bit02.UseVisualStyleBackColor = true;
            // 
            // chkBank1Bit01
            // 
            this.chkBank1Bit01.AutoSize = true;
            this.chkBank1Bit01.Location = new System.Drawing.Point(11, 43);
            this.chkBank1Bit01.Name = "chkBank1Bit01";
            this.chkBank1Bit01.Size = new System.Drawing.Size(184, 16);
            this.chkBank1Bit01.TabIndex = 1;
            this.chkBank1Bit01.Text = "[Bit 01] When drive is exited";
            this.chkBank1Bit01.UseVisualStyleBackColor = true;
            // 
            // chkBank1Bit00
            // 
            this.chkBank1Bit00.AutoSize = true;
            this.chkBank1Bit00.Location = new System.Drawing.Point(11, 21);
            this.chkBank1Bit00.Name = "chkBank1Bit00";
            this.chkBank1Bit00.Size = new System.Drawing.Size(347, 16);
            this.chkBank1Bit00.TabIndex = 0;
            this.chkBank1Bit00.Text = "[Bit 00] When drive set interrupt occurrence use is exited";
            this.chkBank1Bit00.UseVisualStyleBackColor = true;
            // 
            // GrpBank2
            // 
            this.GrpBank2.Controls.Add(this.groupBox1);
            this.GrpBank2.Controls.Add(this.btnSetBank2);
            this.GrpBank2.Controls.Add(this.chkBank2Bit22);
            this.GrpBank2.Controls.Add(this.chkBank2Bit21);
            this.GrpBank2.Controls.Add(this.chkBank2Bit20);
            this.GrpBank2.Controls.Add(this.chkBank2Bit16);
            this.GrpBank2.Controls.Add(this.chkBank2Bit15);
            this.GrpBank2.Controls.Add(this.chkBank2Bit14);
            this.GrpBank2.Location = new System.Drawing.Point(9, 172);
            this.GrpBank2.Name = "GrpBank2";
            this.GrpBank2.Size = new System.Drawing.Size(456, 168);
            this.GrpBank2.TabIndex = 4;
            this.GrpBank2.TabStop = false;
            this.GrpBank2.Text = "< Interrupt Event Bank 2 [0x00000000] >";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(29, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 10);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnSetBank2
            // 
            this.btnSetBank2.Location = new System.Drawing.Point(318, 144);
            this.btnSetBank2.Name = "btnSetBank2";
            this.btnSetBank2.Size = new System.Drawing.Size(137, 22);
            this.btnSetBank2.TabIndex = 6;
            this.btnSetBank2.Text = "Set Bank 2";
            this.btnSetBank2.UseVisualStyleBackColor = true;
            this.btnSetBank2.Click += new System.EventHandler(this.btnSetBank2_Click);
            // 
            // chkBank2Bit22
            // 
            this.chkBank2Bit22.AutoSize = true;
            this.chkBank2Bit22.Location = new System.Drawing.Point(11, 142);
            this.chkBank2Bit22.Name = "chkBank2Bit22";
            this.chkBank2Bit22.Size = new System.Drawing.Size(301, 16);
            this.chkBank2Bit22.TabIndex = 7;
            this.chkBank2Bit22.Text = "[Bit 22] UInput 2 terminal signal is changed to \'1\'";
            this.chkBank2Bit22.UseVisualStyleBackColor = true;
            // 
            // chkBank2Bit21
            // 
            this.chkBank2Bit21.AutoSize = true;
            this.chkBank2Bit21.Location = new System.Drawing.Point(11, 120);
            this.chkBank2Bit21.Name = "chkBank2Bit21";
            this.chkBank2Bit21.Size = new System.Drawing.Size(404, 16);
            this.chkBank2Bit21.TabIndex = 6;
            this.chkBank2Bit21.Text = "[Bit 21] UInput 1 terminal signal is changed to \'1\' (Z-Phase Signal)";
            this.chkBank2Bit21.UseVisualStyleBackColor = true;
            // 
            // chkBank2Bit20
            // 
            this.chkBank2Bit20.AutoSize = true;
            this.chkBank2Bit20.Location = new System.Drawing.Point(11, 98);
            this.chkBank2Bit20.Name = "chkBank2Bit20";
            this.chkBank2Bit20.Size = new System.Drawing.Size(387, 16);
            this.chkBank2Bit20.TabIndex = 5;
            this.chkBank2Bit20.Text = "[Bit 20] UInput 0 terminal signal is changed to \'1\' (Home Signal)";
            this.chkBank2Bit20.UseVisualStyleBackColor = true;
            // 
            // chkBank2Bit16
            // 
            this.chkBank2Bit16.AutoSize = true;
            this.chkBank2Bit16.Location = new System.Drawing.Point(11, 64);
            this.chkBank2Bit16.Name = "chkBank2Bit16";
            this.chkBank2Bit16.Size = new System.Drawing.Size(293, 16);
            this.chkBank2Bit16.TabIndex = 2;
            this.chkBank2Bit16.Text = "[Bit 16] UOut 2 terminal signal is changed to \'1\'";
            this.chkBank2Bit16.UseVisualStyleBackColor = true;
            // 
            // chkBank2Bit15
            // 
            this.chkBank2Bit15.AutoSize = true;
            this.chkBank2Bit15.Location = new System.Drawing.Point(11, 42);
            this.chkBank2Bit15.Name = "chkBank2Bit15";
            this.chkBank2Bit15.Size = new System.Drawing.Size(374, 16);
            this.chkBank2Bit15.TabIndex = 1;
            this.chkBank2Bit15.Text = "[Bit 15] UOut 1 terminal signal is changed to \'1\' (Alarm Clear)";
            this.chkBank2Bit15.UseVisualStyleBackColor = true;
            // 
            // chkBank2Bit14
            // 
            this.chkBank2Bit14.AutoSize = true;
            this.chkBank2Bit14.Location = new System.Drawing.Point(11, 20);
            this.chkBank2Bit14.Name = "chkBank2Bit14";
            this.chkBank2Bit14.Size = new System.Drawing.Size(363, 16);
            this.chkBank2Bit14.TabIndex = 0;
            this.chkBank2Bit14.Text = "[Bit 14] UOut 0 terminal signal is changed to \'1\' (Servo On) ";
            this.chkBank2Bit14.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoEvent);
            this.groupBox2.Controls.Add(this.rdoCallback);
            this.groupBox2.Controls.Add(this.rdoMessage);
            this.groupBox2.Location = new System.Drawing.Point(11, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "< Interrupt Method >";
            // 
            // rdoEvent
            // 
            this.rdoEvent.AutoSize = true;
            this.rdoEvent.Location = new System.Drawing.Point(241, 18);
            this.rdoEvent.Name = "rdoEvent";
            this.rdoEvent.Size = new System.Drawing.Size(54, 16);
            this.rdoEvent.TabIndex = 2;
            this.rdoEvent.TabStop = true;
            this.rdoEvent.Text = "Event";
            this.rdoEvent.UseVisualStyleBackColor = true;
            // 
            // rdoCallback
            // 
            this.rdoCallback.AutoSize = true;
            this.rdoCallback.Location = new System.Drawing.Point(128, 18);
            this.rdoCallback.Name = "rdoCallback";
            this.rdoCallback.Size = new System.Drawing.Size(72, 16);
            this.rdoCallback.TabIndex = 1;
            this.rdoCallback.TabStop = true;
            this.rdoCallback.Text = "Callback";
            this.rdoCallback.UseVisualStyleBackColor = true;
            // 
            // rdoMessage
            // 
            this.rdoMessage.AutoSize = true;
            this.rdoMessage.Location = new System.Drawing.Point(15, 18);
            this.rdoMessage.Name = "rdoMessage";
            this.rdoMessage.Size = new System.Drawing.Size(76, 16);
            this.rdoMessage.TabIndex = 0;
            this.rdoMessage.TabStop = true;
            this.rdoMessage.Text = "Message";
            this.rdoMessage.UseVisualStyleBackColor = true;
            // 
            // lstIntLog
            // 
            this.lstIntLog.FormattingEnabled = true;
            this.lstIntLog.ItemHeight = 12;
            this.lstIntLog.Location = new System.Drawing.Point(11, 396);
            this.lstIntLog.Name = "lstIntLog";
            this.lstIntLog.Size = new System.Drawing.Size(456, 100);
            this.lstIntLog.TabIndex = 7;
            this.lstIntLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstIntLog_MouseDoubleClick);
            this.lstIntLog.DoubleClick += new System.EventHandler(this.lstIntLog_DoubleClick);
            // 
            // chkIntEnable
            // 
            this.chkIntEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIntEnable.Location = new System.Drawing.Point(327, 353);
            this.chkIntEnable.Name = "chkIntEnable";
            this.chkIntEnable.Size = new System.Drawing.Size(138, 32);
            this.chkIntEnable.TabIndex = 8;
            this.chkIntEnable.Text = "Interrupt Enable";
            this.chkIntEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIntEnable.UseVisualStyleBackColor = true;
            this.chkIntEnable.CheckedChanged += new System.EventHandler(this.chkInterruptEnable_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(9, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 32);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            // 
            // InterruptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(477, 504);
            this.Controls.Add(this.chkIntEnable);
            this.Controls.Add(this.lstIntLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GrpBank2);
            this.Controls.Add(this.GrpBank1);
            this.Controls.Add(this.cboSelAxis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterruptSetting";
            this.Text = "InterruptSetting";
            this.Load += new System.EventHandler(this.FormInterrupt_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InterruptSetting_FormClosed);
            this.GrpBank1.ResumeLayout(false);
            this.GrpBank1.PerformLayout();
            this.GrpBank2.ResumeLayout(false);
            this.GrpBank2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.GroupBox GrpBank1;
        private System.Windows.Forms.GroupBox Divide;
        private System.Windows.Forms.CheckBox chkBank1Bit02;
        private System.Windows.Forms.CheckBox chkBank1Bit01;
        private System.Windows.Forms.CheckBox chkBank1Bit00;
        private System.Windows.Forms.CheckBox chkBank1Bit31;
        private System.Windows.Forms.Button btnSetBank1;
        private System.Windows.Forms.GroupBox GrpBank2;
        private System.Windows.Forms.Button btnSetBank2;
        private System.Windows.Forms.CheckBox chkBank2Bit22;
        private System.Windows.Forms.CheckBox chkBank2Bit21;
        private System.Windows.Forms.CheckBox chkBank2Bit20;
        private System.Windows.Forms.CheckBox chkBank2Bit16;
        private System.Windows.Forms.CheckBox chkBank2Bit15;
        private System.Windows.Forms.CheckBox chkBank2Bit14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoEvent;
        private System.Windows.Forms.RadioButton rdoCallback;
        private System.Windows.Forms.RadioButton rdoMessage;
        private System.Windows.Forms.ListBox lstIntLog;
        private System.Windows.Forms.CheckBox chkIntEnable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer tmDisplay;
    }
}

