namespace SignalMonitor
{
    partial class SignalMonitor
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.cboSelAxis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInputSignalMonitor = new System.Windows.Forms.GroupBox();
            this.cboElimitP = new System.Windows.Forms.ComboBox();
            this.cboEmg = new System.Windows.Forms.ComboBox();
            this.cboInp = new System.Windows.Forms.ComboBox();
            this.chkElimitP = new System.Windows.Forms.CheckBox();
            this.chkEmg = new System.Windows.Forms.CheckBox();
            this.chkInp = new System.Windows.Forms.CheckBox();
            this.cboElimitN = new System.Windows.Forms.ComboBox();
            this.cboAlarm = new System.Windows.Forms.ComboBox();
            this.cboZPhase = new System.Windows.Forms.ComboBox();
            this.chkElimitN = new System.Windows.Forms.CheckBox();
            this.chkAlarm = new System.Windows.Forms.CheckBox();
            this.chkZPhase = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpOutputSignalMonitor = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAlarmReset = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServoOn = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkOut04 = new System.Windows.Forms.CheckBox();
            this.chkOut03 = new System.Windows.Forms.CheckBox();
            this.chkOut02 = new System.Windows.Forms.CheckBox();
            this.chkOut01 = new System.Windows.Forms.CheckBox();
            this.chkOut00 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkInp04 = new System.Windows.Forms.CheckBox();
            this.chkInp03 = new System.Windows.Forms.CheckBox();
            this.chkInp02 = new System.Windows.Forms.CheckBox();
            this.chkInp01 = new System.Windows.Forms.CheckBox();
            this.chkInp00 = new System.Windows.Forms.CheckBox();
            this.grpSoftwareLimit = new System.Windows.Forms.GroupBox();
            this.edtSwPosP = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSwRef = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtSwPosN = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboSwStop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSwlimitP = new System.Windows.Forms.CheckBox();
            this.chkSwlimitN = new System.Windows.Forms.CheckBox();
            this.chkSwEnable = new System.Windows.Forms.CheckBox();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.grpInputSignalMonitor.SuspendLayout();
            this.grpOutputSignalMonitor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpSoftwareLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSwPosP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSwPosN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 35);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(346, 10);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(111, 21);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(116, 11);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(225, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No :";
            // 
            // grpInputSignalMonitor
            // 
            this.grpInputSignalMonitor.Controls.Add(this.cboElimitP);
            this.grpInputSignalMonitor.Controls.Add(this.cboEmg);
            this.grpInputSignalMonitor.Controls.Add(this.cboInp);
            this.grpInputSignalMonitor.Controls.Add(this.chkElimitP);
            this.grpInputSignalMonitor.Controls.Add(this.chkEmg);
            this.grpInputSignalMonitor.Controls.Add(this.chkInp);
            this.grpInputSignalMonitor.Controls.Add(this.cboElimitN);
            this.grpInputSignalMonitor.Controls.Add(this.cboAlarm);
            this.grpInputSignalMonitor.Controls.Add(this.cboZPhase);
            this.grpInputSignalMonitor.Controls.Add(this.chkElimitN);
            this.grpInputSignalMonitor.Controls.Add(this.chkAlarm);
            this.grpInputSignalMonitor.Controls.Add(this.chkZPhase);
            this.grpInputSignalMonitor.Controls.Add(this.groupBox1);
            this.grpInputSignalMonitor.Location = new System.Drawing.Point(6, 50);
            this.grpInputSignalMonitor.Name = "grpInputSignalMonitor";
            this.grpInputSignalMonitor.Size = new System.Drawing.Size(465, 97);
            this.grpInputSignalMonitor.TabIndex = 8;
            this.grpInputSignalMonitor.TabStop = false;
            this.grpInputSignalMonitor.Text = "< Input Signal Monitor >";
            // 
            // cboElimitP
            // 
            this.cboElimitP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElimitP.FormattingEnabled = true;
            this.cboElimitP.Location = new System.Drawing.Point(346, 66);
            this.cboElimitP.Name = "cboElimitP";
            this.cboElimitP.Size = new System.Drawing.Size(111, 20);
            this.cboElimitP.TabIndex = 18;
            this.cboElimitP.SelectedIndexChanged += new System.EventHandler(this.cboElimitP_SelectedIndexChanged);
            // 
            // cboEmg
            // 
            this.cboEmg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmg.FormattingEnabled = true;
            this.cboEmg.Location = new System.Drawing.Point(346, 40);
            this.cboEmg.Name = "cboEmg";
            this.cboEmg.Size = new System.Drawing.Size(111, 20);
            this.cboEmg.TabIndex = 17;
            this.cboEmg.SelectedIndexChanged += new System.EventHandler(this.cboEmg_SelectedIndexChanged);
            // 
            // cboInp
            // 
            this.cboInp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInp.FormattingEnabled = true;
            this.cboInp.Location = new System.Drawing.Point(346, 14);
            this.cboInp.Name = "cboInp";
            this.cboInp.Size = new System.Drawing.Size(111, 20);
            this.cboInp.TabIndex = 16;
            this.cboInp.SelectedIndexChanged += new System.EventHandler(this.cboInp_SelectedIndexChanged);
            // 
            // chkElimitP
            // 
            this.chkElimitP.AutoSize = true;
            this.chkElimitP.Enabled = false;
            this.chkElimitP.Location = new System.Drawing.Point(242, 68);
            this.chkElimitP.Name = "chkElimitP";
            this.chkElimitP.Size = new System.Drawing.Size(105, 16);
            this.chkElimitP.TabIndex = 15;
            this.chkElimitP.Text = "(+) End Limit :";
            this.chkElimitP.UseVisualStyleBackColor = true;
            // 
            // chkEmg
            // 
            this.chkEmg.AutoSize = true;
            this.chkEmg.Enabled = false;
            this.chkEmg.Location = new System.Drawing.Point(242, 44);
            this.chkEmg.Name = "chkEmg";
            this.chkEmg.Size = new System.Drawing.Size(102, 16);
            this.chkEmg.TabIndex = 14;
            this.chkEmg.Text = "Emerency    :";
            this.chkEmg.UseVisualStyleBackColor = true;
            // 
            // chkInp
            // 
            this.chkInp.AutoSize = true;
            this.chkInp.Enabled = false;
            this.chkInp.Location = new System.Drawing.Point(242, 18);
            this.chkInp.Name = "chkInp";
            this.chkInp.Size = new System.Drawing.Size(102, 16);
            this.chkInp.TabIndex = 13;
            this.chkInp.Text = "Inposition     :";
            this.chkInp.UseVisualStyleBackColor = true;
            // 
            // cboElimitN
            // 
            this.cboElimitN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElimitN.FormattingEnabled = true;
            this.cboElimitN.Location = new System.Drawing.Point(116, 68);
            this.cboElimitN.Name = "cboElimitN";
            this.cboElimitN.Size = new System.Drawing.Size(111, 20);
            this.cboElimitN.TabIndex = 12;
            this.cboElimitN.SelectedIndexChanged += new System.EventHandler(this.cboElimitN_SelectedIndexChanged);
            // 
            // cboAlarm
            // 
            this.cboAlarm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarm.FormattingEnabled = true;
            this.cboAlarm.Location = new System.Drawing.Point(116, 42);
            this.cboAlarm.Name = "cboAlarm";
            this.cboAlarm.Size = new System.Drawing.Size(111, 20);
            this.cboAlarm.TabIndex = 11;
            this.cboAlarm.SelectedIndexChanged += new System.EventHandler(this.cboAlarm_SelectedIndexChanged);
            // 
            // cboZPhase
            // 
            this.cboZPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZPhase.FormattingEnabled = true;
            this.cboZPhase.Location = new System.Drawing.Point(116, 16);
            this.cboZPhase.Name = "cboZPhase";
            this.cboZPhase.Size = new System.Drawing.Size(111, 20);
            this.cboZPhase.TabIndex = 10;
            this.cboZPhase.SelectedIndexChanged += new System.EventHandler(this.cboZPhase_SelectedIndexChanged);
            // 
            // chkElimitN
            // 
            this.chkElimitN.AutoSize = true;
            this.chkElimitN.Enabled = false;
            this.chkElimitN.Location = new System.Drawing.Point(9, 70);
            this.chkElimitN.Name = "chkElimitN";
            this.chkElimitN.Size = new System.Drawing.Size(105, 16);
            this.chkElimitN.TabIndex = 2;
            this.chkElimitN.Text = "(-) End Limit :";
            this.chkElimitN.UseVisualStyleBackColor = true;
            // 
            // chkAlarm
            // 
            this.chkAlarm.AutoSize = true;
            this.chkAlarm.Enabled = false;
            this.chkAlarm.Location = new System.Drawing.Point(9, 45);
            this.chkAlarm.Name = "chkAlarm";
            this.chkAlarm.Size = new System.Drawing.Size(105, 16);
            this.chkAlarm.TabIndex = 1;
            this.chkAlarm.Text = "Servo Alarm  :";
            this.chkAlarm.UseVisualStyleBackColor = true;
            // 
            // chkZPhase
            // 
            this.chkZPhase.AutoSize = true;
            this.chkZPhase.Enabled = false;
            this.chkZPhase.Location = new System.Drawing.Point(9, 20);
            this.chkZPhase.Name = "chkZPhase";
            this.chkZPhase.Size = new System.Drawing.Size(104, 16);
            this.chkZPhase.TabIndex = 0;
            this.chkZPhase.Text = "Z Phase       :";
            this.chkZPhase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(232, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(4, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // grpOutputSignalMonitor
            // 
            this.grpOutputSignalMonitor.Controls.Add(this.label3);
            this.grpOutputSignalMonitor.Controls.Add(this.cboAlarmReset);
            this.grpOutputSignalMonitor.Controls.Add(this.groupBox2);
            this.grpOutputSignalMonitor.Controls.Add(this.label2);
            this.grpOutputSignalMonitor.Controls.Add(this.cboServoOn);
            this.grpOutputSignalMonitor.Location = new System.Drawing.Point(6, 154);
            this.grpOutputSignalMonitor.Name = "grpOutputSignalMonitor";
            this.grpOutputSignalMonitor.Size = new System.Drawing.Size(465, 48);
            this.grpOutputSignalMonitor.TabIndex = 9;
            this.grpOutputSignalMonitor.TabStop = false;
            this.grpOutputSignalMonitor.Text = "< Output Signal Monitor >";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Alm Reset Level :";
            // 
            // cboAlarmReset
            // 
            this.cboAlarmReset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarmReset.FormattingEnabled = true;
            this.cboAlarmReset.Location = new System.Drawing.Point(346, 17);
            this.cboAlarmReset.Name = "cboAlarmReset";
            this.cboAlarmReset.Size = new System.Drawing.Size(111, 20);
            this.cboAlarmReset.TabIndex = 22;
            this.cboAlarmReset.SelectedIndexChanged += new System.EventHandler(this.cboAlarmReset_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(232, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(4, 30);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Servo On Level  :";
            // 
            // cboServoOn
            // 
            this.cboServoOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServoOn.FormattingEnabled = true;
            this.cboServoOn.Location = new System.Drawing.Point(116, 17);
            this.cboServoOn.Name = "cboServoOn";
            this.cboServoOn.Size = new System.Drawing.Size(111, 20);
            this.cboServoOn.TabIndex = 20;
            this.cboServoOn.SelectedIndexChanged += new System.EventHandler(this.cboServoOn_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkOut04);
            this.groupBox3.Controls.Add(this.chkOut03);
            this.groupBox3.Controls.Add(this.chkOut02);
            this.groupBox3.Controls.Add(this.chkOut01);
            this.groupBox3.Controls.Add(this.chkOut00);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.chkInp04);
            this.groupBox3.Controls.Add(this.chkInp03);
            this.groupBox3.Controls.Add(this.chkInp02);
            this.groupBox3.Controls.Add(this.chkInp01);
            this.groupBox3.Controls.Add(this.chkInp00);
            this.groupBox3.Location = new System.Drawing.Point(6, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 155);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "< Universal In / Out Signal Monitor >";
            // 
            // chkOut04
            // 
            this.chkOut04.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOut04.Location = new System.Drawing.Point(242, 123);
            this.chkOut04.Name = "chkOut04";
            this.chkOut04.Size = new System.Drawing.Size(215, 22);
            this.chkOut04.TabIndex = 15;
            this.chkOut04.Tag = "4";
            this.chkOut04.Text = "  Output Bit 04";
            this.chkOut04.UseVisualStyleBackColor = true;
            this.chkOut04.Click += new System.EventHandler(this.chkOut_Click);
            // 
            // chkOut03
            // 
            this.chkOut03.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOut03.Location = new System.Drawing.Point(242, 97);
            this.chkOut03.Name = "chkOut03";
            this.chkOut03.Size = new System.Drawing.Size(215, 22);
            this.chkOut03.TabIndex = 14;
            this.chkOut03.Tag = "3";
            this.chkOut03.Text = "  Output Bit 03";
            this.chkOut03.UseVisualStyleBackColor = true;
            this.chkOut03.Click += new System.EventHandler(this.chkOut_Click);
            // 
            // chkOut02
            // 
            this.chkOut02.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOut02.Location = new System.Drawing.Point(242, 70);
            this.chkOut02.Name = "chkOut02";
            this.chkOut02.Size = new System.Drawing.Size(215, 22);
            this.chkOut02.TabIndex = 13;
            this.chkOut02.Tag = "2";
            this.chkOut02.Text = "  Output Bit 02";
            this.chkOut02.UseVisualStyleBackColor = true;
            this.chkOut02.Click += new System.EventHandler(this.chkOut_Click);
            // 
            // chkOut01
            // 
            this.chkOut01.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOut01.Location = new System.Drawing.Point(242, 44);
            this.chkOut01.Name = "chkOut01";
            this.chkOut01.Size = new System.Drawing.Size(215, 22);
            this.chkOut01.TabIndex = 12;
            this.chkOut01.Tag = "1";
            this.chkOut01.Text = "  Output Bit 01 (Alarm Clear)";
            this.chkOut01.UseVisualStyleBackColor = true;
            this.chkOut01.Click += new System.EventHandler(this.chkOut_Click);
            // 
            // chkOut00
            // 
            this.chkOut00.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOut00.Location = new System.Drawing.Point(242, 17);
            this.chkOut00.Name = "chkOut00";
            this.chkOut00.Size = new System.Drawing.Size(215, 22);
            this.chkOut00.TabIndex = 11;
            this.chkOut00.Tag = "0";
            this.chkOut00.Text = "  Output Bit 00 (Servo On)";
            this.chkOut00.UseVisualStyleBackColor = true;
            this.chkOut00.Click += new System.EventHandler(this.chkOut_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(232, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(4, 135);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            // 
            // chkInp04
            // 
            this.chkInp04.AutoSize = true;
            this.chkInp04.Enabled = false;
            this.chkInp04.Location = new System.Drawing.Point(9, 127);
            this.chkInp04.Name = "chkInp04";
            this.chkInp04.Size = new System.Drawing.Size(85, 16);
            this.chkInp04.TabIndex = 4;
            this.chkInp04.Text = "Input Bit 04";
            this.chkInp04.UseVisualStyleBackColor = true;
            // 
            // chkInp03
            // 
            this.chkInp03.AutoSize = true;
            this.chkInp03.Enabled = false;
            this.chkInp03.Location = new System.Drawing.Point(9, 101);
            this.chkInp03.Name = "chkInp03";
            this.chkInp03.Size = new System.Drawing.Size(85, 16);
            this.chkInp03.TabIndex = 3;
            this.chkInp03.Text = "Input Bit 03";
            this.chkInp03.UseVisualStyleBackColor = true;
            // 
            // chkInp02
            // 
            this.chkInp02.AutoSize = true;
            this.chkInp02.Enabled = false;
            this.chkInp02.Location = new System.Drawing.Point(9, 74);
            this.chkInp02.Name = "chkInp02";
            this.chkInp02.Size = new System.Drawing.Size(85, 16);
            this.chkInp02.TabIndex = 2;
            this.chkInp02.Text = "Input Bit 02";
            this.chkInp02.UseVisualStyleBackColor = true;
            // 
            // chkInp01
            // 
            this.chkInp01.AutoSize = true;
            this.chkInp01.Enabled = false;
            this.chkInp01.Location = new System.Drawing.Point(9, 48);
            this.chkInp01.Name = "chkInp01";
            this.chkInp01.Size = new System.Drawing.Size(149, 16);
            this.chkInp01.TabIndex = 1;
            this.chkInp01.Text = "Input Bit 01 (Z-Phase)";
            this.chkInp01.UseVisualStyleBackColor = true;
            // 
            // chkInp00
            // 
            this.chkInp00.AutoSize = true;
            this.chkInp00.Enabled = false;
            this.chkInp00.Location = new System.Drawing.Point(9, 21);
            this.chkInp00.Name = "chkInp00";
            this.chkInp00.Size = new System.Drawing.Size(173, 16);
            this.chkInp00.TabIndex = 0;
            this.chkInp00.Text = "Input Bit 00 (Orgin Sensor)";
            this.chkInp00.UseVisualStyleBackColor = true;
            // 
            // grpSoftwareLimit
            // 
            this.grpSoftwareLimit.Controls.Add(this.edtSwPosP);
            this.grpSoftwareLimit.Controls.Add(this.label6);
            this.grpSoftwareLimit.Controls.Add(this.cboSwRef);
            this.grpSoftwareLimit.Controls.Add(this.label7);
            this.grpSoftwareLimit.Controls.Add(this.edtSwPosN);
            this.grpSoftwareLimit.Controls.Add(this.label5);
            this.grpSoftwareLimit.Controls.Add(this.groupBox6);
            this.grpSoftwareLimit.Controls.Add(this.cboSwStop);
            this.grpSoftwareLimit.Controls.Add(this.label4);
            this.grpSoftwareLimit.Controls.Add(this.chkSwlimitP);
            this.grpSoftwareLimit.Controls.Add(this.chkSwlimitN);
            this.grpSoftwareLimit.Location = new System.Drawing.Point(6, 369);
            this.grpSoftwareLimit.Name = "grpSoftwareLimit";
            this.grpSoftwareLimit.Size = new System.Drawing.Size(465, 128);
            this.grpSoftwareLimit.TabIndex = 11;
            this.grpSoftwareLimit.TabStop = false;
            this.grpSoftwareLimit.Text = "< Software Limit >";
            // 
            // edtSwPosP
            // 
            this.edtSwPosP.BackColor = System.Drawing.SystemColors.Window;
            this.edtSwPosP.DecimalPlaces = 3;
            this.edtSwPosP.Location = new System.Drawing.Point(346, 65);
            this.edtSwPosP.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.edtSwPosP.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.edtSwPosP.Name = "edtSwPosP";
            this.edtSwPosP.Size = new System.Drawing.Size(111, 21);
            this.edtSwPosP.TabIndex = 31;
            this.edtSwPosP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "(+) Soft EndPos :";
            // 
            // cboSwRef
            // 
            this.cboSwRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSwRef.FormattingEnabled = true;
            this.cboSwRef.Location = new System.Drawing.Point(346, 40);
            this.cboSwRef.Name = "cboSwRef";
            this.cboSwRef.Size = new System.Drawing.Size(111, 20);
            this.cboSwRef.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "Reference Pos  :";
            // 
            // edtSwPosN
            // 
            this.edtSwPosN.BackColor = System.Drawing.SystemColors.Window;
            this.edtSwPosN.DecimalPlaces = 3;
            this.edtSwPosN.Location = new System.Drawing.Point(116, 65);
            this.edtSwPosN.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.edtSwPosN.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.edtSwPosN.Name = "edtSwPosN";
            this.edtSwPosN.Size = new System.Drawing.Size(111, 21);
            this.edtSwPosN.TabIndex = 27;
            this.edtSwPosN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "(-) Soft EndPos :";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(232, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(4, 80);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            // 
            // cboSwStop
            // 
            this.cboSwStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSwStop.FormattingEnabled = true;
            this.cboSwStop.Location = new System.Drawing.Point(116, 40);
            this.cboSwStop.Name = "cboSwStop";
            this.cboSwStop.Size = new System.Drawing.Size(111, 20);
            this.cboSwStop.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Stop Mode        :";
            // 
            // chkSwlimitP
            // 
            this.chkSwlimitP.AutoSize = true;
            this.chkSwlimitP.Enabled = false;
            this.chkSwlimitP.Location = new System.Drawing.Point(242, 18);
            this.chkSwlimitP.Name = "chkSwlimitP";
            this.chkSwlimitP.Size = new System.Drawing.Size(150, 16);
            this.chkSwlimitP.TabIndex = 1;
            this.chkSwlimitP.Text = "(+) Software End Limit";
            this.chkSwlimitP.UseVisualStyleBackColor = true;
            // 
            // chkSwlimitN
            // 
            this.chkSwlimitN.AutoSize = true;
            this.chkSwlimitN.Enabled = false;
            this.chkSwlimitN.Location = new System.Drawing.Point(9, 18);
            this.chkSwlimitN.Name = "chkSwlimitN";
            this.chkSwlimitN.Size = new System.Drawing.Size(150, 16);
            this.chkSwlimitN.TabIndex = 0;
            this.chkSwlimitN.Text = "(-) Software End Limit";
            this.chkSwlimitN.UseVisualStyleBackColor = true;
            // 
            // chkSwEnable
            // 
            this.chkSwEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSwEnable.Location = new System.Drawing.Point(15, 464);
            this.chkSwEnable.Name = "chkSwEnable";
            this.chkSwEnable.Size = new System.Drawing.Size(448, 24);
            this.chkSwEnable.TabIndex = 12;
            this.chkSwEnable.Text = "Enable";
            this.chkSwEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSwEnable.UseVisualStyleBackColor = true;
            this.chkSwEnable.Click += new System.EventHandler(this.chkSwEnable_Click);
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tm_Display_Tick);
            // 
            // SignalMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.chkSwEnable);
            this.Controls.Add(this.grpSoftwareLimit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpOutputSignalMonitor);
            this.Controls.Add(this.grpInputSignalMonitor);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignalMonitor";
            this.Text = "SignalMonitor";
            this.Load += new System.EventHandler(this.SignalMonitor_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpInputSignalMonitor.ResumeLayout(false);
            this.grpInputSignalMonitor.PerformLayout();
            this.grpOutputSignalMonitor.ResumeLayout(false);
            this.grpOutputSignalMonitor.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpSoftwareLimit.ResumeLayout(false);
            this.grpSoftwareLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSwPosP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSwPosN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpInputSignalMonitor;
        private System.Windows.Forms.CheckBox chkElimitN;
        private System.Windows.Forms.CheckBox chkAlarm;
        private System.Windows.Forms.CheckBox chkZPhase;
        private System.Windows.Forms.ComboBox cboElimitP;
        private System.Windows.Forms.ComboBox cboEmg;
        private System.Windows.Forms.ComboBox cboInp;
        private System.Windows.Forms.CheckBox chkElimitP;
        private System.Windows.Forms.CheckBox chkEmg;
        private System.Windows.Forms.CheckBox chkInp;
        private System.Windows.Forms.ComboBox cboElimitN;
        private System.Windows.Forms.ComboBox cboAlarm;
        private System.Windows.Forms.ComboBox cboZPhase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpOutputSignalMonitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAlarmReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboServoOn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkInp04;
        private System.Windows.Forms.CheckBox chkInp03;
        private System.Windows.Forms.CheckBox chkInp02;
        private System.Windows.Forms.CheckBox chkInp01;
        private System.Windows.Forms.CheckBox chkInp00;
        private System.Windows.Forms.CheckBox chkOut00;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkOut04;
        private System.Windows.Forms.CheckBox chkOut03;
        private System.Windows.Forms.CheckBox chkOut02;
        private System.Windows.Forms.CheckBox chkOut01;
        private System.Windows.Forms.GroupBox grpSoftwareLimit;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkSwlimitP;
        private System.Windows.Forms.CheckBox chkSwlimitN;
        private System.Windows.Forms.NumericUpDown edtSwPosP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSwRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown edtSwPosN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSwStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSwEnable;
        private System.Windows.Forms.Timer tmDisplay;
    }
}

