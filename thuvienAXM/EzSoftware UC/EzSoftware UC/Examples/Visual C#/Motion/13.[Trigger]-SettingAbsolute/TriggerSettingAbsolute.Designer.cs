namespace TriggerSettingAbsolute
{
    partial class TriggerSettingAbsolute
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
            this.edtSetPos = new System.Windows.Forms.TextBox();
            this.chkServoOn = new System.Windows.Forms.CheckBox();
            this.edtCmdVel = new System.Windows.Forms.TextBox();
            this.edtActPos = new System.Windows.Forms.TextBox();
            this.edtCmdPos = new System.Windows.Forms.TextBox();
            this.btnPosSet = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.grpTriggerSettingMethod = new System.Windows.Forms.GroupBox();
            this.btnSetMethod = new System.Windows.Forms.Button();
            this.cboIntUse = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.edtIntCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboTrigTarget = new System.Windows.Forms.ComboBox();
            this.cboTrigLevel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtTrigTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.grpPositionMove = new System.Windows.Forms.GroupBox();
            this.edtMoveAccDec = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.edtMovePos = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rdoRel = new System.Windows.Forms.RadioButton();
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.grpTriggerSettingAlsolutePeriod = new System.Windows.Forms.GroupBox();
            this.btnOverDataAdd = new System.Windows.Forms.Button();
            this.btnOverDataClr = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lstTrigData = new System.Windows.Forms.ListBox();
            this.edtTrigPosAdd = new System.Windows.Forms.TextBox();
            this.chkSetTrigAbs = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTriggerSettingMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigTime)).BeginInit();
            this.grpPositionMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).BeginInit();
            this.grpTriggerSettingAlsolutePeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 39);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(343, 10);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(110, 26);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(127, 12);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(206, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No       :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtSetPos);
            this.groupBox1.Controls.Add(this.chkServoOn);
            this.groupBox1.Controls.Add(this.edtCmdVel);
            this.groupBox1.Controls.Add(this.edtActPos);
            this.groupBox1.Controls.Add(this.edtCmdPos);
            this.groupBox1.Controls.Add(this.btnPosSet);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 96);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // edtSetPos
            // 
            this.edtSetPos.Location = new System.Drawing.Point(343, 11);
            this.edtSetPos.Name = "edtSetPos";
            this.edtSetPos.Size = new System.Drawing.Size(110, 21);
            this.edtSetPos.TabIndex = 14;
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 62);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(110, 26);
            this.chkServoOn.TabIndex = 13;
            this.chkServoOn.Text = "Servo On";
            this.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkServoOn.UseVisualStyleBackColor = true;
            this.chkServoOn.CheckedChanged += new System.EventHandler(this.chkServoOn_CheckedChanged);
            // 
            // edtCmdVel
            // 
            this.edtCmdVel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.edtCmdVel.ForeColor = System.Drawing.Color.Goldenrod;
            this.edtCmdVel.Location = new System.Drawing.Point(129, 67);
            this.edtCmdVel.Name = "edtCmdVel";
            this.edtCmdVel.ReadOnly = true;
            this.edtCmdVel.Size = new System.Drawing.Size(143, 21);
            this.edtCmdVel.TabIndex = 12;
            this.edtCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos
            // 
            this.edtActPos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.edtActPos.ForeColor = System.Drawing.Color.Goldenrod;
            this.edtActPos.Location = new System.Drawing.Point(129, 41);
            this.edtActPos.Name = "edtActPos";
            this.edtActPos.ReadOnly = true;
            this.edtActPos.Size = new System.Drawing.Size(143, 21);
            this.edtActPos.TabIndex = 11;
            this.edtActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos
            // 
            this.edtCmdPos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.edtCmdPos.ForeColor = System.Drawing.Color.Goldenrod;
            this.edtCmdPos.Location = new System.Drawing.Point(129, 15);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(143, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosSet
            // 
            this.btnPosSet.Location = new System.Drawing.Point(343, 34);
            this.btnPosSet.Name = "btnPosSet";
            this.btnPosSet.Size = new System.Drawing.Size(110, 26);
            this.btnPosSet.TabIndex = 9;
            this.btnPosSet.Text = "Position Setting";
            this.btnPosSet.UseVisualStyleBackColor = true;
            this.btnPosSet.Click += new System.EventHandler(this.btnPosSet_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Position  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Position :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // grpTriggerSettingMethod
            // 
            this.grpTriggerSettingMethod.Controls.Add(this.btnSetMethod);
            this.grpTriggerSettingMethod.Controls.Add(this.cboIntUse);
            this.grpTriggerSettingMethod.Controls.Add(this.label13);
            this.grpTriggerSettingMethod.Controls.Add(this.edtIntCount);
            this.grpTriggerSettingMethod.Controls.Add(this.label11);
            this.grpTriggerSettingMethod.Controls.Add(this.groupBox3);
            this.grpTriggerSettingMethod.Controls.Add(this.cboTrigTarget);
            this.grpTriggerSettingMethod.Controls.Add(this.cboTrigLevel);
            this.grpTriggerSettingMethod.Controls.Add(this.label7);
            this.grpTriggerSettingMethod.Controls.Add(this.label6);
            this.grpTriggerSettingMethod.Controls.Add(this.edtTrigTime);
            this.grpTriggerSettingMethod.Controls.Add(this.label5);
            this.grpTriggerSettingMethod.Controls.Add(this.groupBox5);
            this.grpTriggerSettingMethod.Location = new System.Drawing.Point(8, 274);
            this.grpTriggerSettingMethod.Name = "grpTriggerSettingMethod";
            this.grpTriggerSettingMethod.Size = new System.Drawing.Size(461, 102);
            this.grpTriggerSettingMethod.TabIndex = 18;
            this.grpTriggerSettingMethod.TabStop = false;
            this.grpTriggerSettingMethod.Text = "< Trigger Setting Method >";
            // 
            // btnSetMethod
            // 
            this.btnSetMethod.Location = new System.Drawing.Point(343, 74);
            this.btnSetMethod.Name = "btnSetMethod";
            this.btnSetMethod.Size = new System.Drawing.Size(118, 24);
            this.btnSetMethod.TabIndex = 26;
            this.btnSetMethod.Text = "Set Method";
            this.btnSetMethod.UseVisualStyleBackColor = true;
            this.btnSetMethod.Click += new System.EventHandler(this.btnSetMethod_Click);
            // 
            // cboIntUse
            // 
            this.cboIntUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntUse.FormattingEnabled = true;
            this.cboIntUse.Items.AddRange(new object[] {
            "00: DISABLE",
            "01: ENABLE"});
            this.cboIntUse.Location = new System.Drawing.Point(343, 48);
            this.cboIntUse.Name = "cboIntUse";
            this.cboIntUse.Size = new System.Drawing.Size(110, 20);
            this.cboIntUse.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(283, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "Interrupt :";
            // 
            // edtIntCount
            // 
            this.edtIntCount.Location = new System.Drawing.Point(343, 19);
            this.edtIntCount.Name = "edtIntCount";
            this.edtIntCount.ReadOnly = true;
            this.edtIntCount.Size = new System.Drawing.Size(110, 21);
            this.edtIntCount.TabIndex = 32;
            this.edtIntCount.Text = "0";
            this.edtIntCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(283, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "Int Count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(277, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(5, 82);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // cboTrigTarget
            // 
            this.cboTrigTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrigTarget.FormattingEnabled = true;
            this.cboTrigTarget.Items.AddRange(new object[] {
            "00: COMMAND",
            "01: ACTUAL"});
            this.cboTrigTarget.Location = new System.Drawing.Point(127, 73);
            this.cboTrigTarget.Name = "cboTrigTarget";
            this.cboTrigTarget.Size = new System.Drawing.Size(144, 20);
            this.cboTrigTarget.TabIndex = 30;
            // 
            // cboTrigLevel
            // 
            this.cboTrigLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrigLevel.FormattingEnabled = true;
            this.cboTrigLevel.Items.AddRange(new object[] {
            "00: LOW",
            "01: HIGH"});
            this.cboTrigLevel.Location = new System.Drawing.Point(127, 46);
            this.cboTrigLevel.Name = "cboTrigLevel";
            this.cboTrigLevel.Size = new System.Drawing.Size(144, 20);
            this.cboTrigLevel.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Trigger Target  Sel  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Trigger Level Set    :";
            // 
            // edtTrigTime
            // 
            this.edtTrigTime.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.edtTrigTime.DecimalPlaces = 3;
            this.edtTrigTime.Location = new System.Drawing.Point(128, 19);
            this.edtTrigTime.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtTrigTime.Name = "edtTrigTime";
            this.edtTrigTime.Size = new System.Drawing.Size(143, 21);
            this.edtTrigTime.TabIndex = 27;
            this.edtTrigTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "Trigger Time(us)    :";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(344, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 9);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            // 
            // grpPositionMove
            // 
            this.grpPositionMove.Controls.Add(this.edtMoveAccDec);
            this.grpPositionMove.Controls.Add(this.edtMoveVel);
            this.grpPositionMove.Controls.Add(this.edtMovePos);
            this.grpPositionMove.Controls.Add(this.btnStop);
            this.grpPositionMove.Controls.Add(this.label18);
            this.grpPositionMove.Controls.Add(this.label19);
            this.grpPositionMove.Controls.Add(this.label16);
            this.grpPositionMove.Controls.Add(this.label17);
            this.grpPositionMove.Controls.Add(this.btnMove1);
            this.grpPositionMove.Controls.Add(this.label14);
            this.grpPositionMove.Controls.Add(this.label12);
            this.grpPositionMove.Controls.Add(this.rdoRel);
            this.grpPositionMove.Controls.Add(this.rdoAbs);
            this.grpPositionMove.Location = new System.Drawing.Point(9, 146);
            this.grpPositionMove.Name = "grpPositionMove";
            this.grpPositionMove.Size = new System.Drawing.Size(461, 122);
            this.grpPositionMove.TabIndex = 17;
            this.grpPositionMove.TabStop = false;
            this.grpPositionMove.Text = "Position Move";
            // 
            // edtMoveAccDec
            // 
            this.edtMoveAccDec.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.edtMoveAccDec.DecimalPlaces = 3;
            this.edtMoveAccDec.Location = new System.Drawing.Point(127, 95);
            this.edtMoveAccDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAccDec.Name = "edtMoveAccDec";
            this.edtMoveAccDec.Size = new System.Drawing.Size(143, 21);
            this.edtMoveAccDec.TabIndex = 25;
            this.edtMoveAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(127, 68);
            this.edtMoveVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(143, 21);
            this.edtMoveVel.TabIndex = 24;
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMovePos
            // 
            this.edtMovePos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.edtMovePos.DecimalPlaces = 3;
            this.edtMovePos.Location = new System.Drawing.Point(127, 41);
            this.edtMovePos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMovePos.Name = "edtMovePos";
            this.edtMovePos.Size = new System.Drawing.Size(143, 21);
            this.edtMovePos.TabIndex = 22;
            this.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(342, 67);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 49);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Move Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(271, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Unit/Sec^2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Move Accel/Decel  :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(271, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "Unit/Sec";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(2, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity        :";
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(342, 38);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(110, 24);
            this.btnMove1.TabIndex = 10;
            this.btnMove1.Text = "Move Target";
            this.btnMove1.UseVisualStyleBackColor = true;
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "Unit";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Move Target Pos    :";
            // 
            // rdoRel
            // 
            this.rdoRel.AutoSize = true;
            this.rdoRel.Location = new System.Drawing.Point(238, 16);
            this.rdoRel.Name = "rdoRel";
            this.rdoRel.Size = new System.Drawing.Size(95, 16);
            this.rdoRel.TabIndex = 1;
            this.rdoRel.Text = "[01] Relative";
            this.rdoRel.UseVisualStyleBackColor = true;
            // 
            // rdoAbs
            // 
            this.rdoAbs.AutoSize = true;
            this.rdoAbs.Checked = true;
            this.rdoAbs.Location = new System.Drawing.Point(127, 16);
            this.rdoAbs.Name = "rdoAbs";
            this.rdoAbs.Size = new System.Drawing.Size(100, 16);
            this.rdoAbs.TabIndex = 0;
            this.rdoAbs.TabStop = true;
            this.rdoAbs.Text = "[00] Absolute";
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.CheckedChanged += new System.EventHandler(this.rdoAbs_CheckedChanged);
            // 
            // grpTriggerSettingAlsolutePeriod
            // 
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.groupBox2);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.chkSetTrigAbs);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.btnOverDataClr);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.lstTrigData);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.label21);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.btnOverDataAdd);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.edtTrigPosAdd);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.label22);
            this.grpTriggerSettingAlsolutePeriod.Controls.Add(this.groupBox6);
            this.grpTriggerSettingAlsolutePeriod.Location = new System.Drawing.Point(9, 382);
            this.grpTriggerSettingAlsolutePeriod.Name = "grpTriggerSettingAlsolutePeriod";
            this.grpTriggerSettingAlsolutePeriod.Size = new System.Drawing.Size(461, 120);
            this.grpTriggerSettingAlsolutePeriod.TabIndex = 19;
            this.grpTriggerSettingAlsolutePeriod.TabStop = false;
            this.grpTriggerSettingAlsolutePeriod.Text = "< Trigger Setting Alsolute Period >";
            // 
            // btnOverDataAdd
            // 
            this.btnOverDataAdd.Location = new System.Drawing.Point(342, 36);
            this.btnOverDataAdd.Name = "btnOverDataAdd";
            this.btnOverDataAdd.Size = new System.Drawing.Size(110, 24);
            this.btnOverDataAdd.TabIndex = 46;
            this.btnOverDataAdd.Text = "<< Add Item   ";
            this.btnOverDataAdd.UseVisualStyleBackColor = true;
            this.btnOverDataAdd.Click += new System.EventHandler(this.btnOverDataAdd_Click);
            // 
            // btnOverDataClr
            // 
            this.btnOverDataClr.Location = new System.Drawing.Point(342, 60);
            this.btnOverDataClr.Name = "btnOverDataClr";
            this.btnOverDataClr.Size = new System.Drawing.Size(110, 24);
            this.btnOverDataClr.TabIndex = 26;
            this.btnOverDataClr.Text = "All Clear Item";
            this.btnOverDataClr.UseVisualStyleBackColor = true;
            this.btnOverDataClr.Click += new System.EventHandler(this.btnOverDataClr_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(280, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 12);
            this.label22.TabIndex = 45;
            this.label22.Text = "Trig Pos :";
            // 
            // lstTrigData
            // 
            this.lstTrigData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTrigData.FormattingEnabled = true;
            this.lstTrigData.ItemHeight = 14;
            this.lstTrigData.Location = new System.Drawing.Point(126, 17);
            this.lstTrigData.Name = "lstTrigData";
            this.lstTrigData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstTrigData.Size = new System.Drawing.Size(144, 88);
            this.lstTrigData.TabIndex = 41;
            // 
            // edtTrigPosAdd
            // 
            this.edtTrigPosAdd.Location = new System.Drawing.Point(342, 15);
            this.edtTrigPosAdd.Name = "edtTrigPosAdd";
            this.edtTrigPosAdd.Size = new System.Drawing.Size(110, 21);
            this.edtTrigPosAdd.TabIndex = 43;
            this.edtTrigPosAdd.Text = "0.0";
            this.edtTrigPosAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSetTrigAbs
            // 
            this.chkSetTrigAbs.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSetTrigAbs.Location = new System.Drawing.Point(342, 95);
            this.chkSetTrigAbs.Name = "chkSetTrigAbs";
            this.chkSetTrigAbs.Size = new System.Drawing.Size(118, 24);
            this.chkSetTrigAbs.TabIndex = 40;
            this.chkSetTrigAbs.Text = "Set Absolute";
            this.chkSetTrigAbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSetTrigAbs.UseVisualStyleBackColor = true;
            this.chkSetTrigAbs.CheckedChanged += new System.EventHandler(this.chkSetTrigAbs_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 12);
            this.label21.TabIndex = 36;
            this.label21.Text = "Trigger Position List:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(276, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(5, 97);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(343, 83);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(116, 9);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            // 
            // TriggerSettingAbsolute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpTriggerSettingMethod);
            this.Controls.Add(this.grpPositionMove);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpTriggerSettingAlsolutePeriod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TriggerSettingAbsolute";
            this.Text = "TriggerSettingAbsolute";
            this.Load += new System.EventHandler(this.TriggerSettingAbsolute_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTriggerSettingMethod.ResumeLayout(false);
            this.grpTriggerSettingMethod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigTime)).EndInit();
            this.grpPositionMove.ResumeLayout(false);
            this.grpPositionMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).EndInit();
            this.grpTriggerSettingAlsolutePeriod.ResumeLayout(false);
            this.grpTriggerSettingAlsolutePeriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtSetPos;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.TextBox edtCmdVel;
        private System.Windows.Forms.TextBox edtActPos;
        private System.Windows.Forms.TextBox edtCmdPos;
        private System.Windows.Forms.Button btnPosSet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.GroupBox grpTriggerSettingMethod;
        private System.Windows.Forms.Button btnSetMethod;
        private System.Windows.Forms.ComboBox cboIntUse;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox edtIntCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboTrigTarget;
        private System.Windows.Forms.ComboBox cboTrigLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown edtTrigTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox grpPositionMove;
        private System.Windows.Forms.NumericUpDown edtMoveAccDec;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.NumericUpDown edtMovePos;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoRel;
        private System.Windows.Forms.RadioButton rdoAbs;
        private System.Windows.Forms.GroupBox grpTriggerSettingAlsolutePeriod;
        private System.Windows.Forms.CheckBox chkSetTrigAbs;
        private System.Windows.Forms.ListBox lstTrigData;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox edtTrigPosAdd;
        private System.Windows.Forms.Button btnOverDataAdd;
        private System.Windows.Forms.Button btnOverDataClr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

