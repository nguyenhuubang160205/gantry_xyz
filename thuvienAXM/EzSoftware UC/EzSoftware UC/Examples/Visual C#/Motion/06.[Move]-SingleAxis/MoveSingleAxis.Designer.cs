namespace MoveSingleAxis
{
    partial class MoveSingleAxis
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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkServoOn = new System.Windows.Forms.CheckBox();
            this.edtCmdVel = new System.Windows.Forms.TextBox();
            this.edtActPos = new System.Windows.Forms.TextBox();
            this.edtCmdPos = new System.Windows.Forms.TextBox();
            this.btnPosClear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.edtMoveDec = new System.Windows.Forms.NumericUpDown();
            this.edtMoveAcc = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.edtPos2 = new System.Windows.Forms.NumericUpDown();
            this.edtPos1 = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMove2 = new System.Windows.Forms.Button();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rdoRel = new System.Windows.Forms.RadioButton();
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edtJogDec = new System.Windows.Forms.NumericUpDown();
            this.edtJogAcc = new System.Windows.Forms.NumericUpDown();
            this.edtJogVel = new System.Windows.Forms.NumericUpDown();
            this.btnJogMoveN = new System.Windows.Forms.Button();
            this.btnJogMoveP = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPos1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No :";
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(132, 10);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(208, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkServoOn);
            this.groupBox1.Controls.Add(this.edtCmdVel);
            this.groupBox1.Controls.Add(this.edtActPos);
            this.groupBox1.Controls.Add(this.edtCmdPos);
            this.groupBox1.Controls.Add(this.btnPosClear);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 70);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(110, 26);
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
            this.edtCmdVel.Location = new System.Drawing.Point(132, 75);
            this.edtCmdVel.Name = "edtCmdVel";
            this.edtCmdVel.ReadOnly = true;
            this.edtCmdVel.Size = new System.Drawing.Size(138, 21);
            this.edtCmdVel.TabIndex = 12;
            this.edtCmdVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos
            // 
            this.edtActPos.BackColor = System.Drawing.SystemColors.Control;
            this.edtActPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtActPos.Location = new System.Drawing.Point(132, 48);
            this.edtActPos.Name = "edtActPos";
            this.edtActPos.ReadOnly = true;
            this.edtActPos.Size = new System.Drawing.Size(138, 21);
            this.edtActPos.TabIndex = 11;
            this.edtActPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos
            // 
            this.edtCmdPos.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdPos.Location = new System.Drawing.Point(132, 20);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(138, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(343, 20);
            this.btnPosClear.Name = "btnPosClear";
            this.btnPosClear.Size = new System.Drawing.Size(110, 46);
            this.btnPosClear.TabIndex = 9;
            this.btnPosClear.Text = "Position Clear";
            this.btnPosClear.UseVisualStyleBackColor = true;
            this.btnPosClear.Click += new System.EventHandler(this.btnPosClear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 50);
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
            this.label4.Location = new System.Drawing.Point(13, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Position  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Position :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRepeat);
            this.groupBox2.Controls.Add(this.edtMoveDec);
            this.groupBox2.Controls.Add(this.edtMoveAcc);
            this.groupBox2.Controls.Add(this.edtMoveVel);
            this.groupBox2.Controls.Add(this.edtPos2);
            this.groupBox2.Controls.Add(this.edtPos1);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnMove2);
            this.groupBox2.Controls.Add(this.btnMove1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboProfile);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.rdoRel);
            this.groupBox2.Controls.Add(this.rdoAbs);
            this.groupBox2.Location = new System.Drawing.Point(11, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 223);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "< Position Move >";
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(343, 120);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(110, 43);
            this.btnRepeat.TabIndex = 27;
            this.btnRepeat.Text = "<< Repeat >>";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // edtMoveDec
            // 
            this.edtMoveDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveDec.DecimalPlaces = 3;
            this.edtMoveDec.Location = new System.Drawing.Point(132, 191);
            this.edtMoveDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveDec.Name = "edtMoveDec";
            this.edtMoveDec.Size = new System.Drawing.Size(138, 21);
            this.edtMoveDec.TabIndex = 26;
            this.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAcc.DecimalPlaces = 3;
            this.edtMoveAcc.Location = new System.Drawing.Point(132, 164);
            this.edtMoveAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(138, 21);
            this.edtMoveAcc.TabIndex = 25;
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(132, 137);
            this.edtMoveVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(138, 21);
            this.edtMoveVel.TabIndex = 24;
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPos2
            // 
            this.edtPos2.BackColor = System.Drawing.SystemColors.Window;
            this.edtPos2.DecimalPlaces = 3;
            this.edtPos2.Location = new System.Drawing.Point(132, 99);
            this.edtPos2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtPos2.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.edtPos2.Name = "edtPos2";
            this.edtPos2.Size = new System.Drawing.Size(138, 21);
            this.edtPos2.TabIndex = 23;
            this.edtPos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPos1
            // 
            this.edtPos1.BackColor = System.Drawing.SystemColors.Window;
            this.edtPos1.DecimalPlaces = 3;
            this.edtPos1.Location = new System.Drawing.Point(132, 72);
            this.edtPos1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtPos1.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.edtPos1.Name = "edtPos1";
            this.edtPos1.Size = new System.Drawing.Size(138, 21);
            this.edtPos1.TabIndex = 22;
            this.edtPos1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(343, 168);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 43);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Move Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnSStop_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(274, 195);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 12);
            this.label20.TabIndex = 20;
            this.label20.Text = "Unit/Sec^2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 195);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "Move Deceleration  :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(274, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Unit/Sec^2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Move Acceleration  :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(274, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "Unit/Sec";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity        :";
            // 
            // btnMove2
            // 
            this.btnMove2.Location = new System.Drawing.Point(343, 95);
            this.btnMove2.Name = "btnMove2";
            this.btnMove2.Size = new System.Drawing.Size(110, 23);
            this.btnMove2.TabIndex = 11;
            this.btnMove2.Text = "Move Target 2";
            this.btnMove2.UseVisualStyleBackColor = true;
            this.btnMove2.Click += new System.EventHandler(this.btnMove2_Click);
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(343, 70);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(110, 23);
            this.btnMove1.TabIndex = 10;
            this.btnMove1.Text = "Move Target 1";
            this.btnMove1.UseVisualStyleBackColor = true;
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "Unit";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(274, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "Unit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "Target Position 2    :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Target Position 1    :";
            // 
            // cboProfile
            // 
            this.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Items.AddRange(new object[] {
            "00: SYM_TRAPEZOID_MODE",
            "01: ASYM_TRAPEZOID_MODE",
            "03: SYM_S_CURVE_MODE",
            "04: ASYM_S_CURVE_MODE"});
            this.cboProfile.Location = new System.Drawing.Point(132, 42);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(208, 20);
            this.cboProfile.TabIndex = 3;
            this.cboProfile.SelectedIndexChanged += new System.EventHandler(this.cboProfile_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "Velocity Profile Set :";
            // 
            // rdoRel
            // 
            this.rdoRel.AutoSize = true;
            this.rdoRel.Location = new System.Drawing.Point(245, 20);
            this.rdoRel.Name = "rdoRel";
            this.rdoRel.Size = new System.Drawing.Size(95, 16);
            this.rdoRel.TabIndex = 1;
            this.rdoRel.Tag = "1";
            this.rdoRel.Text = "[01] Relative";
            this.rdoRel.UseVisualStyleBackColor = true;
            this.rdoRel.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // rdoAbs
            // 
            this.rdoAbs.AutoSize = true;
            this.rdoAbs.Checked = true;
            this.rdoAbs.Location = new System.Drawing.Point(136, 20);
            this.rdoAbs.Name = "rdoAbs";
            this.rdoAbs.Size = new System.Drawing.Size(100, 16);
            this.rdoAbs.TabIndex = 0;
            this.rdoAbs.TabStop = true;
            this.rdoAbs.Tag = "0";
            this.rdoAbs.Text = "[00] Absolute";
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edtJogDec);
            this.groupBox3.Controls.Add(this.edtJogAcc);
            this.groupBox3.Controls.Add(this.edtJogVel);
            this.groupBox3.Controls.Add(this.btnJogMoveN);
            this.groupBox3.Controls.Add(this.btnJogMoveP);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Location = new System.Drawing.Point(11, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "< Jog(Velocity) Move >";
            // 
            // edtJogDec
            // 
            this.edtJogDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogDec.DecimalPlaces = 3;
            this.edtJogDec.Location = new System.Drawing.Point(132, 75);
            this.edtJogDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogDec.Name = "edtJogDec";
            this.edtJogDec.Size = new System.Drawing.Size(138, 21);
            this.edtJogDec.TabIndex = 34;
            this.edtJogDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtJogAcc
            // 
            this.edtJogAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogAcc.DecimalPlaces = 3;
            this.edtJogAcc.Location = new System.Drawing.Point(132, 48);
            this.edtJogAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogAcc.Name = "edtJogAcc";
            this.edtJogAcc.Size = new System.Drawing.Size(138, 21);
            this.edtJogAcc.TabIndex = 33;
            this.edtJogAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtJogVel
            // 
            this.edtJogVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogVel.DecimalPlaces = 3;
            this.edtJogVel.Location = new System.Drawing.Point(132, 20);
            this.edtJogVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogVel.Name = "edtJogVel";
            this.edtJogVel.Size = new System.Drawing.Size(138, 21);
            this.edtJogVel.TabIndex = 27;
            this.edtJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnJogMoveN
            // 
            this.btnJogMoveN.Location = new System.Drawing.Point(343, 60);
            this.btnJogMoveN.Name = "btnJogMoveN";
            this.btnJogMoveN.Size = new System.Drawing.Size(110, 36);
            this.btnJogMoveN.TabIndex = 32;
            this.btnJogMoveN.Text = "Jog Move (-)";
            this.btnJogMoveN.UseVisualStyleBackColor = true;
            this.btnJogMoveN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogNX_MouseDown);
            this.btnJogMoveN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogNX_MouseUp);
            // 
            // btnJogMoveP
            // 
            this.btnJogMoveP.Location = new System.Drawing.Point(343, 20);
            this.btnJogMoveP.Name = "btnJogMoveP";
            this.btnJogMoveP.Size = new System.Drawing.Size(110, 36);
            this.btnJogMoveP.TabIndex = 31;
            this.btnJogMoveP.Text = "Jog Move (+)";
            this.btnJogMoveP.UseVisualStyleBackColor = true;
            this.btnJogMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPX_MouseDown);
            this.btnJogMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPX_MouseUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(272, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 12);
            this.label22.TabIndex = 30;
            this.label22.Text = "Unit/Sec^2";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(4, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(122, 12);
            this.label27.TabIndex = 22;
            this.label27.Text = "Jog Velocity           :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(123, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "Jog Deceleration     :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(272, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 12);
            this.label24.TabIndex = 27;
            this.label24.Text = "Unit/Sec^2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(272, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 12);
            this.label26.TabIndex = 24;
            this.label26.Text = "Unit/Sec";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 12);
            this.label25.TabIndex = 25;
            this.label25.Text = "Jog Acceleration     :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmTimer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(11, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 34);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // MoveSingleAxis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveSingleAxis";
            this.Text = "MoveSingleAxis";
            this.Load += new System.EventHandler(this.FormMotion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPos1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdoAbs;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMove2;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnJogMoveN;
        private System.Windows.Forms.Button btnJogMoveP;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.TextBox edtCmdVel;
        private System.Windows.Forms.TextBox edtActPos;
        private System.Windows.Forms.TextBox edtCmdPos;
        private System.Windows.Forms.NumericUpDown edtMoveDec;
        private System.Windows.Forms.NumericUpDown edtMoveAcc;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.NumericUpDown edtPos2;
        private System.Windows.Forms.NumericUpDown edtPos1;
        private System.Windows.Forms.NumericUpDown edtJogDec;
        private System.Windows.Forms.NumericUpDown edtJogAcc;
        private System.Windows.Forms.NumericUpDown edtJogVel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.RadioButton rdoRel;
        private System.Windows.Forms.Button btnRepeat;
    }
}

