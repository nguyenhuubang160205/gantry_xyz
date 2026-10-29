namespace TriggerSettingBlock
{
    partial class TriggerSettingBlock
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
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.rdoRel = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.edtMovePos = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.edtMoveAccDec = new System.Windows.Forms.NumericUpDown();
            this.grpPositionMove = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtTrigTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTrigLevel = new System.Windows.Forms.ComboBox();
            this.cboTrigTarget = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.edtIntCount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIntUse = new System.Windows.Forms.ComboBox();
            this.btnSetMethod = new System.Windows.Forms.Button();
            this.grpTriggerSettingMethod = new System.Windows.Forms.GroupBox();
            this.grpTriggerSettingBlock = new System.Windows.Forms.GroupBox();
            this.edtTrigPeriod = new System.Windows.Forms.TextBox();
            this.edtTrigEndPos = new System.Windows.Forms.TextBox();
            this.edtTrigStartPos = new System.Windows.Forms.TextBox();
            this.chkSetBlock = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).BeginInit();
            this.grpPositionMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigTime)).BeginInit();
            this.grpTriggerSettingMethod.SuspendLayout();
            this.grpTriggerSettingBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 34);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(343, 9);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(110, 21);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(127, 10);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(212, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No      :";
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
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 99);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // edtSetPos
            // 
            this.edtSetPos.Location = new System.Drawing.Point(343, 18);
            this.edtSetPos.Name = "edtSetPos";
            this.edtSetPos.Size = new System.Drawing.Size(110, 21);
            this.edtSetPos.TabIndex = 14;
            this.edtSetPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 66);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(110, 21);
            this.chkServoOn.TabIndex = 13;
            this.chkServoOn.Text = "Servo On";
            this.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkServoOn.UseVisualStyleBackColor = true;
            this.chkServoOn.Click += new System.EventHandler(this.chkServoOn_Click);
            // 
            // edtCmdVel
            // 
            this.edtCmdVel.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdVel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdVel.Location = new System.Drawing.Point(127, 66);
            this.edtCmdVel.Name = "edtCmdVel";
            this.edtCmdVel.ReadOnly = true;
            this.edtCmdVel.Size = new System.Drawing.Size(143, 21);
            this.edtCmdVel.TabIndex = 12;
            this.edtCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos
            // 
            this.edtActPos.BackColor = System.Drawing.SystemColors.Control;
            this.edtActPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtActPos.Location = new System.Drawing.Point(127, 42);
            this.edtActPos.Name = "edtActPos";
            this.edtActPos.ReadOnly = true;
            this.edtActPos.Size = new System.Drawing.Size(143, 21);
            this.edtActPos.TabIndex = 11;
            this.edtActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos
            // 
            this.edtCmdPos.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdPos.Location = new System.Drawing.Point(127, 18);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(143, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosSet
            // 
            this.btnPosSet.Location = new System.Drawing.Point(343, 42);
            this.btnPosSet.Name = "btnPosSet";
            this.btnPosSet.Size = new System.Drawing.Size(110, 21);
            this.btnPosSet.TabIndex = 9;
            this.btnPosSet.Text = "Position Setting";
            this.btnPosSet.UseVisualStyleBackColor = true;
            this.btnPosSet.Click += new System.EventHandler(this.btnPosSet_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
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
            this.label2.Location = new System.Drawing.Point(6, 23);
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
            // rdoAbs
            // 
            this.rdoAbs.AutoSize = true;
            this.rdoAbs.Checked = true;
            this.rdoAbs.Location = new System.Drawing.Point(127, 18);
            this.rdoAbs.Name = "rdoAbs";
            this.rdoAbs.Size = new System.Drawing.Size(100, 16);
            this.rdoAbs.TabIndex = 0;
            this.rdoAbs.TabStop = true;
            this.rdoAbs.Tag = "0";
            this.rdoAbs.Text = "[00] Absolute";
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // rdoRel
            // 
            this.rdoRel.AutoSize = true;
            this.rdoRel.Location = new System.Drawing.Point(238, 18);
            this.rdoRel.Name = "rdoRel";
            this.rdoRel.Size = new System.Drawing.Size(95, 16);
            this.rdoRel.TabIndex = 1;
            this.rdoRel.Tag = "1";
            this.rdoRel.Text = "[01] Relative";
            this.rdoRel.UseVisualStyleBackColor = true;
            this.rdoRel.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Move Target Pos   :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "Unit";
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(343, 38);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(110, 49);
            this.btnMove1.TabIndex = 10;
            this.btnMove1.Text = "Move Target";
            this.btnMove1.UseVisualStyleBackColor = true;
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity       :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(271, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "Unit/Sec";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Move Accel/Decel :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(271, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Unit/Sec^2";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(343, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 21);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Move Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnSStop_Click);
            // 
            // edtMovePos
            // 
            this.edtMovePos.BackColor = System.Drawing.SystemColors.Window;
            this.edtMovePos.DecimalPlaces = 3;
            this.edtMovePos.Location = new System.Drawing.Point(127, 38);
            this.edtMovePos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMovePos.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.edtMovePos.Name = "edtMovePos";
            this.edtMovePos.Size = new System.Drawing.Size(143, 21);
            this.edtMovePos.TabIndex = 22;
            this.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(127, 64);
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
            // edtMoveAccDec
            // 
            this.edtMoveAccDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAccDec.DecimalPlaces = 3;
            this.edtMoveAccDec.Location = new System.Drawing.Point(127, 90);
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
            this.grpPositionMove.Location = new System.Drawing.Point(8, 147);
            this.grpPositionMove.Name = "grpPositionMove";
            this.grpPositionMove.Size = new System.Drawing.Size(461, 122);
            this.grpPositionMove.TabIndex = 12;
            this.grpPositionMove.TabStop = false;
            this.grpPositionMove.Text = "Position Move";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(343, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 10);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "Trigger Time(us)   :";
            // 
            // edtTrigTime
            // 
            this.edtTrigTime.BackColor = System.Drawing.SystemColors.Window;
            this.edtTrigTime.DecimalPlaces = 3;
            this.edtTrigTime.Location = new System.Drawing.Point(127, 19);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Trigger Level Set   :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Trigger Target  Sel :";
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
            this.cboTrigLevel.Size = new System.Drawing.Size(143, 20);
            this.cboTrigLevel.TabIndex = 3;
            // 
            // cboTrigTarget
            // 
            this.cboTrigTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrigTarget.FormattingEnabled = true;
            this.cboTrigTarget.Items.AddRange(new object[] {
            "00: COMMAND",
            "01: ACTUAL"});
            this.cboTrigTarget.Location = new System.Drawing.Point(127, 72);
            this.cboTrigTarget.Name = "cboTrigTarget";
            this.cboTrigTarget.Size = new System.Drawing.Size(143, 20);
            this.cboTrigTarget.TabIndex = 30;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(276, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(5, 80);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(283, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "Interrupt :";
            // 
            // cboIntUse
            // 
            this.cboIntUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntUse.FormattingEnabled = true;
            this.cboIntUse.Items.AddRange(new object[] {
            "00: DISABLE",
            "01: ENABLE"});
            this.cboIntUse.Location = new System.Drawing.Point(343, 46);
            this.cboIntUse.Name = "cboIntUse";
            this.cboIntUse.Size = new System.Drawing.Size(110, 20);
            this.cboIntUse.TabIndex = 35;
            // 
            // btnSetMethod
            // 
            this.btnSetMethod.Location = new System.Drawing.Point(343, 79);
            this.btnSetMethod.Name = "btnSetMethod";
            this.btnSetMethod.Size = new System.Drawing.Size(117, 22);
            this.btnSetMethod.TabIndex = 26;
            this.btnSetMethod.Text = "Set Method";
            this.btnSetMethod.UseVisualStyleBackColor = true;
            this.btnSetMethod.Click += new System.EventHandler(this.btnSetMethod_Click);
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
            this.grpTriggerSettingMethod.Location = new System.Drawing.Point(7, 278);
            this.grpTriggerSettingMethod.Name = "grpTriggerSettingMethod";
            this.grpTriggerSettingMethod.Size = new System.Drawing.Size(461, 103);
            this.grpTriggerSettingMethod.TabIndex = 13;
            this.grpTriggerSettingMethod.TabStop = false;
            this.grpTriggerSettingMethod.Text = "< Trigger Setting Method >";
            // 
            // grpTriggerSettingBlock
            // 
            this.grpTriggerSettingBlock.Controls.Add(this.edtTrigPeriod);
            this.grpTriggerSettingBlock.Controls.Add(this.edtTrigEndPos);
            this.grpTriggerSettingBlock.Controls.Add(this.edtTrigStartPos);
            this.grpTriggerSettingBlock.Controls.Add(this.chkSetBlock);
            this.grpTriggerSettingBlock.Controls.Add(this.label24);
            this.grpTriggerSettingBlock.Controls.Add(this.label23);
            this.grpTriggerSettingBlock.Controls.Add(this.label22);
            this.grpTriggerSettingBlock.Controls.Add(this.label15);
            this.grpTriggerSettingBlock.Controls.Add(this.label20);
            this.grpTriggerSettingBlock.Controls.Add(this.label21);
            this.grpTriggerSettingBlock.Controls.Add(this.groupBox2);
            this.grpTriggerSettingBlock.Location = new System.Drawing.Point(7, 390);
            this.grpTriggerSettingBlock.Name = "grpTriggerSettingBlock";
            this.grpTriggerSettingBlock.Size = new System.Drawing.Size(461, 105);
            this.grpTriggerSettingBlock.TabIndex = 14;
            this.grpTriggerSettingBlock.TabStop = false;
            this.grpTriggerSettingBlock.Text = "< Trigger Setting Block >";
            // 
            // edtTrigPeriod
            // 
            this.edtTrigPeriod.Location = new System.Drawing.Point(127, 72);
            this.edtTrigPeriod.Name = "edtTrigPeriod";
            this.edtTrigPeriod.Size = new System.Drawing.Size(143, 21);
            this.edtTrigPeriod.TabIndex = 46;
            this.edtTrigPeriod.Text = "0.000";
            this.edtTrigPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtTrigEndPos
            // 
            this.edtTrigEndPos.Location = new System.Drawing.Point(127, 45);
            this.edtTrigEndPos.Name = "edtTrigEndPos";
            this.edtTrigEndPos.Size = new System.Drawing.Size(143, 21);
            this.edtTrigEndPos.TabIndex = 45;
            this.edtTrigEndPos.Text = "0.000";
            this.edtTrigEndPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtTrigStartPos
            // 
            this.edtTrigStartPos.Location = new System.Drawing.Point(127, 19);
            this.edtTrigStartPos.Name = "edtTrigStartPos";
            this.edtTrigStartPos.Size = new System.Drawing.Size(143, 21);
            this.edtTrigStartPos.TabIndex = 44;
            this.edtTrigStartPos.Text = "0.000";
            this.edtTrigStartPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSetBlock
            // 
            this.chkSetBlock.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSetBlock.Location = new System.Drawing.Point(343, 81);
            this.chkSetBlock.Name = "chkSetBlock";
            this.chkSetBlock.Size = new System.Drawing.Size(117, 22);
            this.chkSetBlock.TabIndex = 43;
            this.chkSetBlock.Text = "Set Block";
            this.chkSetBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSetBlock.UseVisualStyleBackColor = true;
            this.chkSetBlock.Click += new System.EventHandler(this.chkSetBlock_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(271, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 12);
            this.label24.TabIndex = 42;
            this.label24.Text = "Unit";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(271, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 12);
            this.label23.TabIndex = 41;
            this.label23.Text = "Unit";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(271, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 12);
            this.label22.TabIndex = 26;
            this.label22.Text = "Unit";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 12);
            this.label15.TabIndex = 38;
            this.label15.Text = "Trigger Period       :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 12);
            this.label20.TabIndex = 37;
            this.label20.Text = "Block End Position :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(118, 12);
            this.label21.TabIndex = 36;
            this.label21.Text = "Block Start Position:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(343, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 10);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // TriggerSettingBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpTriggerSettingBlock);
            this.Controls.Add(this.grpTriggerSettingMethod);
            this.Controls.Add(this.grpPositionMove);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TriggerSettingBlock";
            this.Text = "TriggerSettingBlock";
            this.Load += new System.EventHandler(this.TriggerSettingBlock_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).EndInit();
            this.grpPositionMove.ResumeLayout(false);
            this.grpPositionMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigTime)).EndInit();
            this.grpTriggerSettingMethod.ResumeLayout(false);
            this.grpTriggerSettingMethod.PerformLayout();
            this.grpTriggerSettingBlock.ResumeLayout(false);
            this.grpTriggerSettingBlock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.TextBox edtSetPos;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.RadioButton rdoAbs;
        private System.Windows.Forms.RadioButton rdoRel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown edtMovePos;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.NumericUpDown edtMoveAccDec;
        private System.Windows.Forms.GroupBox grpPositionMove;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown edtTrigTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTrigLevel;
        private System.Windows.Forms.ComboBox cboTrigTarget;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edtIntCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIntUse;
        private System.Windows.Forms.Button btnSetMethod;
        private System.Windows.Forms.GroupBox grpTriggerSettingMethod;
        private System.Windows.Forms.GroupBox grpTriggerSettingBlock;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chkSetBlock;
        private System.Windows.Forms.TextBox edtTrigPeriod;
        private System.Windows.Forms.TextBox edtTrigEndPos;
        private System.Windows.Forms.TextBox edtTrigStartPos;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

