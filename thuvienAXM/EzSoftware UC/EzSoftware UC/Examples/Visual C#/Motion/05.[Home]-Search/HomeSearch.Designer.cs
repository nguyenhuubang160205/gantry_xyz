namespace HomeSearch
{
    partial class HomeSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkServoOn = new System.Windows.Forms.CheckBox();
            this.textCmdVel = new System.Windows.Forms.TextBox();
            this.textActPos = new System.Windows.Forms.TextBox();
            this.textCmdPos = new System.Windows.Forms.TextBox();
            this.btnPosClear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpHomeSignalLevel = new System.Windows.Forms.GroupBox();
            this.cboHomeLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHomeState = new System.Windows.Forms.CheckBox();
            this.grpHomeMethodSetting = new System.Windows.Forms.GroupBox();
            this.btnSetMethod = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.edtHomeClrTime = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.edtHomeOffset = new System.Windows.Forms.NumericUpDown();
            this.cboZphaseUse = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboHomeSignal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboHomeDir = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.grpHomeVelocitySetting = new System.Windows.Forms.GroupBox();
            this.btnSetVelocity = new System.Windows.Forms.Button();
            this.edtAccSecond = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.edtAccFirst = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.edtVelLast = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.edtVelThird = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.edtVelSecend = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.edtVelFirst = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grpHomeSearch = new System.Windows.Forms.GroupBox();
            this.labelHomeStepSub33 = new System.Windows.Forms.Label();
            this.labelHomeStepMain32 = new System.Windows.Forms.Label();
            this.labelHomeSearch = new System.Windows.Forms.Label();
            this.prgHomeRate = new System.Windows.Forms.ProgressBar();
            this.label22 = new System.Windows.Forms.Label();
            this.btnMoveStop = new System.Windows.Forms.Button();
            this.btnHomeStart = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.tmHomeInfo = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpHomeSignalLevel.SuspendLayout();
            this.grpHomeMethodSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeClrTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeOffset)).BeginInit();
            this.grpHomeVelocitySetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelThird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelSecend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelFirst)).BeginInit();
            this.grpHomeSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 35);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(336, 10);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(116, 21);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(112, 10);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(220, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkServoOn);
            this.groupBox1.Controls.Add(this.textCmdVel);
            this.groupBox1.Controls.Add(this.textActPos);
            this.groupBox1.Controls.Add(this.textCmdPos);
            this.groupBox1.Controls.Add(this.btnPosClear);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(336, 65);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(116, 24);
            this.chkServoOn.TabIndex = 13;
            this.chkServoOn.Text = "Servo On";
            this.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkServoOn.UseVisualStyleBackColor = true;
            this.chkServoOn.Click += new System.EventHandler(this.chkServoOn_Click);
            // 
            // textCmdVel
            // 
            this.textCmdVel.BackColor = System.Drawing.SystemColors.Control;
            this.textCmdVel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textCmdVel.Location = new System.Drawing.Point(112, 68);
            this.textCmdVel.Name = "textCmdVel";
            this.textCmdVel.ReadOnly = true;
            this.textCmdVel.Size = new System.Drawing.Size(161, 21);
            this.textCmdVel.TabIndex = 12;
            this.textCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textActPos
            // 
            this.textActPos.BackColor = System.Drawing.SystemColors.Control;
            this.textActPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textActPos.Location = new System.Drawing.Point(112, 43);
            this.textActPos.Name = "textActPos";
            this.textActPos.ReadOnly = true;
            this.textActPos.Size = new System.Drawing.Size(161, 21);
            this.textActPos.TabIndex = 11;
            this.textActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdPos
            // 
            this.textCmdPos.BackColor = System.Drawing.SystemColors.Control;
            this.textCmdPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textCmdPos.Location = new System.Drawing.Point(112, 18);
            this.textCmdPos.Name = "textCmdPos";
            this.textCmdPos.ReadOnly = true;
            this.textCmdPos.Size = new System.Drawing.Size(161, 21);
            this.textCmdPos.TabIndex = 10;
            this.textCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(336, 18);
            this.btnPosClear.Name = "btnPosClear";
            this.btnPosClear.Size = new System.Drawing.Size(116, 43);
            this.btnPosClear.TabIndex = 9;
            this.btnPosClear.Text = "Position Clear";
            this.btnPosClear.UseVisualStyleBackColor = true;
            this.btnPosClear.Click += new System.EventHandler(this.btnPosClear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Vel  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Pos  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Pos :";
            // 
            // grpHomeSignalLevel
            // 
            this.grpHomeSignalLevel.Controls.Add(this.cboHomeLevel);
            this.grpHomeSignalLevel.Controls.Add(this.label5);
            this.grpHomeSignalLevel.Controls.Add(this.groupBox2);
            this.grpHomeSignalLevel.Controls.Add(this.chkHomeState);
            this.grpHomeSignalLevel.Location = new System.Drawing.Point(9, 143);
            this.grpHomeSignalLevel.Name = "grpHomeSignalLevel";
            this.grpHomeSignalLevel.Size = new System.Drawing.Size(461, 44);
            this.grpHomeSignalLevel.TabIndex = 9;
            this.grpHomeSignalLevel.TabStop = false;
            this.grpHomeSignalLevel.Text = "< Home Signal Level >";
            // 
            // cboHomeLevel
            // 
            this.cboHomeLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomeLevel.FormattingEnabled = true;
            this.cboHomeLevel.Location = new System.Drawing.Point(336, 15);
            this.cboHomeLevel.Name = "cboHomeLevel";
            this.cboHomeLevel.Size = new System.Drawing.Size(116, 20);
            this.cboHomeLevel.TabIndex = 13;
            this.cboHomeLevel.SelectedIndexChanged += new System.EventHandler(this.cboHomeLevel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Home Level   : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(230, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(5, 30);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // chkHomeState
            // 
            this.chkHomeState.AutoSize = true;
            this.chkHomeState.Enabled = false;
            this.chkHomeState.Location = new System.Drawing.Point(12, 19);
            this.chkHomeState.Name = "chkHomeState";
            this.chkHomeState.Size = new System.Drawing.Size(128, 16);
            this.chkHomeState.TabIndex = 0;
            this.chkHomeState.Text = "Home Signal State";
            this.chkHomeState.UseVisualStyleBackColor = true;
            // 
            // grpHomeMethodSetting
            // 
            this.grpHomeMethodSetting.Controls.Add(this.btnSetMethod);
            this.grpHomeMethodSetting.Controls.Add(this.label14);
            this.grpHomeMethodSetting.Controls.Add(this.edtHomeClrTime);
            this.grpHomeMethodSetting.Controls.Add(this.label13);
            this.grpHomeMethodSetting.Controls.Add(this.edtHomeOffset);
            this.grpHomeMethodSetting.Controls.Add(this.cboZphaseUse);
            this.grpHomeMethodSetting.Controls.Add(this.label11);
            this.grpHomeMethodSetting.Controls.Add(this.cboHomeSignal);
            this.grpHomeMethodSetting.Controls.Add(this.label7);
            this.grpHomeMethodSetting.Controls.Add(this.groupBox3);
            this.grpHomeMethodSetting.Controls.Add(this.cboHomeDir);
            this.grpHomeMethodSetting.Controls.Add(this.label6);
            this.grpHomeMethodSetting.Controls.Add(this.label12);
            this.grpHomeMethodSetting.Controls.Add(this.groupBox5);
            this.grpHomeMethodSetting.Location = new System.Drawing.Point(9, 192);
            this.grpHomeMethodSetting.Name = "grpHomeMethodSetting";
            this.grpHomeMethodSetting.Size = new System.Drawing.Size(461, 100);
            this.grpHomeMethodSetting.TabIndex = 10;
            this.grpHomeMethodSetting.TabStop = false;
            this.grpHomeMethodSetting.Text = "< Home Method Setting >";
            // 
            // btnSetMethod
            // 
            this.btnSetMethod.Location = new System.Drawing.Point(336, 75);
            this.btnSetMethod.Name = "btnSetMethod";
            this.btnSetMethod.Size = new System.Drawing.Size(123, 23);
            this.btnSetMethod.TabIndex = 28;
            this.btnSetMethod.Text = "Set Method";
            this.btnSetMethod.UseVisualStyleBackColor = true;
            this.btnSetMethod.Click += new System.EventHandler(this.btnSetMethod_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(231, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "mSec";
            // 
            // edtHomeClrTime
            // 
            this.edtHomeClrTime.BackColor = System.Drawing.SystemColors.Window;
            this.edtHomeClrTime.DecimalPlaces = 3;
            this.edtHomeClrTime.Location = new System.Drawing.Point(110, 68);
            this.edtHomeClrTime.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtHomeClrTime.Name = "edtHomeClrTime";
            this.edtHomeClrTime.Size = new System.Drawing.Size(115, 21);
            this.edtHomeClrTime.TabIndex = 25;
            this.edtHomeClrTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "Home Clr Time  :";
            // 
            // edtHomeOffset
            // 
            this.edtHomeOffset.BackColor = System.Drawing.SystemColors.Window;
            this.edtHomeOffset.DecimalPlaces = 3;
            this.edtHomeOffset.Location = new System.Drawing.Point(110, 42);
            this.edtHomeOffset.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtHomeOffset.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.edtHomeOffset.Name = "edtHomeOffset";
            this.edtHomeOffset.Size = new System.Drawing.Size(115, 21);
            this.edtHomeOffset.TabIndex = 23;
            this.edtHomeOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboZphaseUse
            // 
            this.cboZphaseUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZphaseUse.FormattingEnabled = true;
            this.cboZphaseUse.Location = new System.Drawing.Point(336, 42);
            this.cboZphaseUse.Name = "cboZphaseUse";
            this.cboZphaseUse.Size = new System.Drawing.Size(116, 20);
            this.cboZphaseUse.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "Z Phase Use :";
            // 
            // cboHomeSignal
            // 
            this.cboHomeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomeSignal.FormattingEnabled = true;
            this.cboHomeSignal.Location = new System.Drawing.Point(336, 18);
            this.cboHomeSignal.Name = "cboHomeSignal";
            this.cboHomeSignal.Size = new System.Drawing.Size(116, 20);
            this.cboHomeSignal.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Home Signal  : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(231, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(5, 56);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // cboHomeDir
            // 
            this.cboHomeDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomeDir.FormattingEnabled = true;
            this.cboHomeDir.Items.AddRange(new object[] {
            "00: -DIR_CCW",
            "01: +DIR_CW"});
            this.cboHomeDir.Location = new System.Drawing.Point(110, 18);
            this.cboHomeDir.Name = "cboHomeDir";
            this.cboHomeDir.Size = new System.Drawing.Size(115, 20);
            this.cboHomeDir.TabIndex = 15;
            this.cboHomeDir.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Home Direction  :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "Home Set Offset :";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(336, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(123, 10);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // grpHomeVelocitySetting
            // 
            this.grpHomeVelocitySetting.Controls.Add(this.btnSetVelocity);
            this.grpHomeVelocitySetting.Controls.Add(this.edtAccSecond);
            this.grpHomeVelocitySetting.Controls.Add(this.groupBox7);
            this.grpHomeVelocitySetting.Controls.Add(this.label19);
            this.grpHomeVelocitySetting.Controls.Add(this.edtAccFirst);
            this.grpHomeVelocitySetting.Controls.Add(this.label20);
            this.grpHomeVelocitySetting.Controls.Add(this.edtVelLast);
            this.grpHomeVelocitySetting.Controls.Add(this.label18);
            this.grpHomeVelocitySetting.Controls.Add(this.edtVelThird);
            this.grpHomeVelocitySetting.Controls.Add(this.label17);
            this.grpHomeVelocitySetting.Controls.Add(this.edtVelSecend);
            this.grpHomeVelocitySetting.Controls.Add(this.label16);
            this.grpHomeVelocitySetting.Controls.Add(this.edtVelFirst);
            this.grpHomeVelocitySetting.Controls.Add(this.label15);
            this.grpHomeVelocitySetting.Controls.Add(this.groupBox6);
            this.grpHomeVelocitySetting.Location = new System.Drawing.Point(9, 298);
            this.grpHomeVelocitySetting.Name = "grpHomeVelocitySetting";
            this.grpHomeVelocitySetting.Size = new System.Drawing.Size(461, 125);
            this.grpHomeVelocitySetting.TabIndex = 11;
            this.grpHomeVelocitySetting.TabStop = false;
            this.grpHomeVelocitySetting.Text = "< Home Velocity Setting >";
            // 
            // btnSetVelocity
            // 
            this.btnSetVelocity.Location = new System.Drawing.Point(336, 97);
            this.btnSetVelocity.Name = "btnSetVelocity";
            this.btnSetVelocity.Size = new System.Drawing.Size(123, 26);
            this.btnSetVelocity.TabIndex = 30;
            this.btnSetVelocity.Text = "Set Velocity";
            this.btnSetVelocity.UseVisualStyleBackColor = true;
            this.btnSetVelocity.Click += new System.EventHandler(this.btnSetVelocity_Click);
            // 
            // edtAccSecond
            // 
            this.edtAccSecond.BackColor = System.Drawing.SystemColors.Window;
            this.edtAccSecond.DecimalPlaces = 3;
            this.edtAccSecond.Location = new System.Drawing.Point(336, 43);
            this.edtAccSecond.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtAccSecond.Name = "edtAccSecond";
            this.edtAccSecond.Size = new System.Drawing.Size(116, 21);
            this.edtAccSecond.TabIndex = 39;
            this.edtAccSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(336, 81);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(123, 10);
            this.groupBox7.TabIndex = 29;
            this.groupBox7.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(239, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 12);
            this.label19.TabIndex = 40;
            this.label19.Text = "Second Accel :";
            // 
            // edtAccFirst
            // 
            this.edtAccFirst.BackColor = System.Drawing.SystemColors.Window;
            this.edtAccFirst.DecimalPlaces = 3;
            this.edtAccFirst.Location = new System.Drawing.Point(336, 16);
            this.edtAccFirst.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtAccFirst.Name = "edtAccFirst";
            this.edtAccFirst.Size = new System.Drawing.Size(116, 21);
            this.edtAccFirst.TabIndex = 37;
            this.edtAccFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(238, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 12);
            this.label20.TabIndex = 38;
            this.label20.Text = "First Accel      :";
            // 
            // edtVelLast
            // 
            this.edtVelLast.BackColor = System.Drawing.SystemColors.Window;
            this.edtVelLast.DecimalPlaces = 3;
            this.edtVelLast.Location = new System.Drawing.Point(110, 97);
            this.edtVelLast.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtVelLast.Name = "edtVelLast";
            this.edtVelLast.Size = new System.Drawing.Size(115, 21);
            this.edtVelLast.TabIndex = 35;
            this.edtVelLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 12);
            this.label18.TabIndex = 36;
            this.label18.Text = "Last Velocity      :";
            // 
            // edtVelThird
            // 
            this.edtVelThird.BackColor = System.Drawing.SystemColors.Window;
            this.edtVelThird.DecimalPlaces = 3;
            this.edtVelThird.Location = new System.Drawing.Point(110, 70);
            this.edtVelThird.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtVelThird.Name = "edtVelThird";
            this.edtVelThird.Size = new System.Drawing.Size(115, 21);
            this.edtVelThird.TabIndex = 33;
            this.edtVelThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 12);
            this.label17.TabIndex = 34;
            this.label17.Text = "Third Velocity     :";
            // 
            // edtVelSecend
            // 
            this.edtVelSecend.BackColor = System.Drawing.SystemColors.Window;
            this.edtVelSecend.DecimalPlaces = 3;
            this.edtVelSecend.Location = new System.Drawing.Point(110, 43);
            this.edtVelSecend.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtVelSecend.Name = "edtVelSecend";
            this.edtVelSecend.Size = new System.Drawing.Size(115, 21);
            this.edtVelSecend.TabIndex = 31;
            this.edtVelSecend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "Second Velocity :";
            // 
            // edtVelFirst
            // 
            this.edtVelFirst.BackColor = System.Drawing.SystemColors.Window;
            this.edtVelFirst.DecimalPlaces = 3;
            this.edtVelFirst.Location = new System.Drawing.Point(110, 16);
            this.edtVelFirst.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtVelFirst.Name = "edtVelFirst";
            this.edtVelFirst.Size = new System.Drawing.Size(115, 21);
            this.edtVelFirst.TabIndex = 29;
            this.edtVelFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 12);
            this.label15.TabIndex = 30;
            this.label15.Text = "First Velocity      :";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(231, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(5, 110);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            // 
            // grpHomeSearch
            // 
            this.grpHomeSearch.Controls.Add(this.labelHomeStepSub33);
            this.grpHomeSearch.Controls.Add(this.labelHomeStepMain32);
            this.grpHomeSearch.Controls.Add(this.labelHomeSearch);
            this.grpHomeSearch.Controls.Add(this.prgHomeRate);
            this.grpHomeSearch.Controls.Add(this.label22);
            this.grpHomeSearch.Controls.Add(this.btnMoveStop);
            this.grpHomeSearch.Controls.Add(this.btnHomeStart);
            this.grpHomeSearch.Controls.Add(this.label21);
            this.grpHomeSearch.Location = new System.Drawing.Point(9, 429);
            this.grpHomeSearch.Name = "grpHomeSearch";
            this.grpHomeSearch.Size = new System.Drawing.Size(461, 70);
            this.grpHomeSearch.TabIndex = 12;
            this.grpHomeSearch.TabStop = false;
            this.grpHomeSearch.Text = "< Home Search >";
            // 
            // labelHomeStepSub33
            // 
            this.labelHomeStepSub33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeStepSub33.Location = new System.Drawing.Point(142, 41);
            this.labelHomeStepSub33.Name = "labelHomeStepSub33";
            this.labelHomeStepSub33.Size = new System.Drawing.Size(32, 20);
            this.labelHomeStepSub33.TabIndex = 50;
            this.labelHomeStepSub33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHomeStepMain32
            // 
            this.labelHomeStepMain32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeStepMain32.Location = new System.Drawing.Point(109, 41);
            this.labelHomeStepMain32.Name = "labelHomeStepMain32";
            this.labelHomeStepMain32.Size = new System.Drawing.Size(32, 20);
            this.labelHomeStepMain32.TabIndex = 49;
            this.labelHomeStepMain32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHomeSearch
            // 
            this.labelHomeSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeSearch.Location = new System.Drawing.Point(109, 18);
            this.labelHomeSearch.Name = "labelHomeSearch";
            this.labelHomeSearch.Size = new System.Drawing.Size(224, 20);
            this.labelHomeSearch.TabIndex = 48;
            this.labelHomeSearch.Text = " [FFH] HOME_ERR_UNKNOWN";
            this.labelHomeSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgHomeRate
            // 
            this.prgHomeRate.Location = new System.Drawing.Point(176, 40);
            this.prgHomeRate.Name = "prgHomeRate";
            this.prgHomeRate.Size = new System.Drawing.Size(157, 20);
            this.prgHomeRate.TabIndex = 47;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "Home Step/Rate: ";
            // 
            // btnMoveStop
            // 
            this.btnMoveStop.Location = new System.Drawing.Point(336, 40);
            this.btnMoveStop.Name = "btnMoveStop";
            this.btnMoveStop.Size = new System.Drawing.Size(116, 20);
            this.btnMoveStop.TabIndex = 43;
            this.btnMoveStop.Text = "Move Stop";
            this.btnMoveStop.UseVisualStyleBackColor = true;
            this.btnMoveStop.Click += new System.EventHandler(this.btnMoveStop_Click);
            // 
            // btnHomeStart
            // 
            this.btnHomeStart.Location = new System.Drawing.Point(336, 18);
            this.btnHomeStart.Name = "btnHomeStart";
            this.btnHomeStart.Size = new System.Drawing.Size(116, 20);
            this.btnHomeStart.TabIndex = 41;
            this.btnHomeStart.Text = "Home Start";
            this.btnHomeStart.UseVisualStyleBackColor = true;
            this.btnHomeStart.Click += new System.EventHandler(this.btnHomeStart_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 12);
            this.label21.TabIndex = 41;
            this.label21.Text = "Home Result     :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // tmHomeInfo
            // 
            this.tmHomeInfo.Enabled = true;
            this.tmHomeInfo.Tick += new System.EventHandler(this.tmHomeInfo_Tick);
            // 
            // HomeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpHomeSearch);
            this.Controls.Add(this.grpHomeVelocitySetting);
            this.Controls.Add(this.grpHomeSignalLevel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpHomeMethodSetting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeSearch";
            this.Text = "HomeSearch";
            this.Load += new System.EventHandler(this.HomeSearch_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeSearch_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpHomeSignalLevel.ResumeLayout(false);
            this.grpHomeSignalLevel.PerformLayout();
            this.grpHomeMethodSetting.ResumeLayout(false);
            this.grpHomeMethodSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeClrTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeOffset)).EndInit();
            this.grpHomeVelocitySetting.ResumeLayout(false);
            this.grpHomeVelocitySetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelThird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelSecend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVelFirst)).EndInit();
            this.grpHomeSearch.ResumeLayout(false);
            this.grpHomeSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.TextBox textCmdVel;
        private System.Windows.Forms.TextBox textActPos;
        private System.Windows.Forms.TextBox textCmdPos;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpHomeSignalLevel;
        private System.Windows.Forms.ComboBox cboHomeLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHomeState;
        private System.Windows.Forms.GroupBox grpHomeMethodSetting;
        private System.Windows.Forms.ComboBox cboZphaseUse;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboHomeSignal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboHomeDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown edtHomeOffset;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown edtHomeClrTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSetMethod;
        private System.Windows.Forms.GroupBox grpHomeVelocitySetting;
        private System.Windows.Forms.NumericUpDown edtVelLast;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown edtVelThird;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown edtVelSecend;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown edtVelFirst;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSetVelocity;
        private System.Windows.Forms.NumericUpDown edtAccSecond;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown edtAccFirst;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox grpHomeSearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnMoveStop;
        private System.Windows.Forms.Button btnHomeStart;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ProgressBar prgHomeRate;
        private System.Windows.Forms.Label labelHomeSearch;
        private System.Windows.Forms.Label labelHomeStepSub33;
        private System.Windows.Forms.Label labelHomeStepMain32;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.Timer tmHomeInfo;
    }
}

