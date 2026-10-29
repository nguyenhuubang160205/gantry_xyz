namespace OverrideVelocity
{
    partial class OverrideVelocity
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.cboSelAxis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.grpJogMove = new System.Windows.Forms.GroupBox();
            this.btnJogMoveStop = new System.Windows.Forms.Button();
            this.btnJogMove = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edtJogAccDec = new System.Windows.Forms.NumericUpDown();
            this.edtJogVel = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpOverrideVelocity = new System.Windows.Forms.GroupBox();
            this.btnSetOverride = new System.Windows.Forms.Button();
            this.btnSetOverrideMaxVel = new System.Windows.Forms.Button();
            this.chkOverrideOnlyVel = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labOverrideMaxVel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.edtOverrideMaxVel = new System.Windows.Forms.NumericUpDown();
            this.edtOverrideDec = new System.Windows.Forms.NumericUpDown();
            this.edtOverrideAcc = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.edtOverrideVel = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpJogMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAccDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).BeginInit();
            this.grpOverrideVelocity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideMaxVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideVel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtMoveAccDec);
            this.groupBox2.Controls.Add(this.edtMoveVel);
            this.groupBox2.Controls.Add(this.edtMovePos);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnMove1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rdoRel);
            this.groupBox2.Controls.Add(this.rdoAbs);
            this.groupBox2.Location = new System.Drawing.Point(8, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 124);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position Move";
            // 
            // edtMoveAccDec
            // 
            this.edtMoveAccDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAccDec.DecimalPlaces = 3;
            this.edtMoveAccDec.Location = new System.Drawing.Point(127, 92);
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
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(127, 66);
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
            this.edtMovePos.BackColor = System.Drawing.SystemColors.Window;
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
            this.btnStop.Location = new System.Drawing.Point(343, 67);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 46);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Move Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(273, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Unit/Sec^2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Move Accel/Decel :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(273, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "Unit/Sec";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity       :";
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(343, 41);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(110, 21);
            this.btnMove1.TabIndex = 10;
            this.btnMove1.Text = "Move Target";
            this.btnMove1.UseVisualStyleBackColor = true;
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(273, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "Unit";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Target Position      :";
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 33);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(343, 9);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(110, 20);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // cboSelAxis
            // 
            this.cboSelAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelAxis.FormattingEnabled = true;
            this.cboSelAxis.Location = new System.Drawing.Point(127, 9);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(212, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No      :";
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
            this.groupBox1.Location = new System.Drawing.Point(8, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 92);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 61);
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
            this.edtCmdVel.Location = new System.Drawing.Point(127, 61);
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
            this.edtActPos.Location = new System.Drawing.Point(127, 38);
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
            this.edtCmdPos.Location = new System.Drawing.Point(127, 15);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(143, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(343, 15);
            this.btnPosClear.Name = "btnPosClear";
            this.btnPosClear.Size = new System.Drawing.Size(110, 41);
            this.btnPosClear.TabIndex = 9;
            this.btnPosClear.Text = "Position Clear";
            this.btnPosClear.UseVisualStyleBackColor = true;
            this.btnPosClear.Click += new System.EventHandler(this.btnPosClear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
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
            // grpJogMove
            // 
            this.grpJogMove.Controls.Add(this.btnJogMoveStop);
            this.grpJogMove.Controls.Add(this.btnJogMove);
            this.grpJogMove.Controls.Add(this.label11);
            this.grpJogMove.Controls.Add(this.label7);
            this.grpJogMove.Controls.Add(this.edtJogAccDec);
            this.grpJogMove.Controls.Add(this.edtJogVel);
            this.grpJogMove.Controls.Add(this.label6);
            this.grpJogMove.Controls.Add(this.label5);
            this.grpJogMove.Location = new System.Drawing.Point(8, 264);
            this.grpJogMove.Name = "grpJogMove";
            this.grpJogMove.Size = new System.Drawing.Size(461, 76);
            this.grpJogMove.TabIndex = 16;
            this.grpJogMove.TabStop = false;
            this.grpJogMove.Text = "Jog(Velocity) Move";
            // 
            // btnJogMoveStop
            // 
            this.btnJogMoveStop.Location = new System.Drawing.Point(343, 43);
            this.btnJogMoveStop.Name = "btnJogMoveStop";
            this.btnJogMoveStop.Size = new System.Drawing.Size(110, 21);
            this.btnJogMoveStop.TabIndex = 30;
            this.btnJogMoveStop.Text = "Velocity Stop";
            this.btnJogMoveStop.UseVisualStyleBackColor = true;
            this.btnJogMoveStop.Click += new System.EventHandler(this.btnJogMoveStop_Click);
            // 
            // btnJogMove
            // 
            this.btnJogMove.Location = new System.Drawing.Point(343, 18);
            this.btnJogMove.Name = "btnJogMove";
            this.btnJogMove.Size = new System.Drawing.Size(110, 21);
            this.btnJogMove.TabIndex = 26;
            this.btnJogMove.Text = "Velocity Move";
            this.btnJogMove.UseVisualStyleBackColor = true;
            this.btnJogMove.Click += new System.EventHandler(this.btnJogMove_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "Unit/Sec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Unit/Sec^2";
            // 
            // edtJogAccDec
            // 
            this.edtJogAccDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogAccDec.DecimalPlaces = 3;
            this.edtJogAccDec.Location = new System.Drawing.Point(127, 43);
            this.edtJogAccDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogAccDec.Name = "edtJogAccDec";
            this.edtJogAccDec.Size = new System.Drawing.Size(143, 21);
            this.edtJogAccDec.TabIndex = 29;
            this.edtJogAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtJogVel
            // 
            this.edtJogVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogVel.DecimalPlaces = 3;
            this.edtJogVel.Location = new System.Drawing.Point(127, 18);
            this.edtJogVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogVel.Name = "edtJogVel";
            this.edtJogVel.Size = new System.Drawing.Size(143, 21);
            this.edtJogVel.TabIndex = 28;
            this.edtJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "Jog Velocity          :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Jog Accel/Decel    :";
            // 
            // grpOverrideVelocity
            // 
            this.grpOverrideVelocity.Controls.Add(this.btnSetOverride);
            this.grpOverrideVelocity.Controls.Add(this.btnSetOverrideMaxVel);
            this.grpOverrideVelocity.Controls.Add(this.chkOverrideOnlyVel);
            this.grpOverrideVelocity.Controls.Add(this.label27);
            this.grpOverrideVelocity.Controls.Add(this.label26);
            this.grpOverrideVelocity.Controls.Add(this.label25);
            this.grpOverrideVelocity.Controls.Add(this.label24);
            this.grpOverrideVelocity.Controls.Add(this.label23);
            this.grpOverrideVelocity.Controls.Add(this.labOverrideMaxVel);
            this.grpOverrideVelocity.Controls.Add(this.label22);
            this.grpOverrideVelocity.Controls.Add(this.label21);
            this.grpOverrideVelocity.Controls.Add(this.edtOverrideMaxVel);
            this.grpOverrideVelocity.Controls.Add(this.edtOverrideDec);
            this.grpOverrideVelocity.Controls.Add(this.edtOverrideAcc);
            this.grpOverrideVelocity.Controls.Add(this.label20);
            this.grpOverrideVelocity.Controls.Add(this.edtOverrideVel);
            this.grpOverrideVelocity.Controls.Add(this.label15);
            this.grpOverrideVelocity.Controls.Add(this.label13);
            this.grpOverrideVelocity.Location = new System.Drawing.Point(8, 345);
            this.grpOverrideVelocity.Name = "grpOverrideVelocity";
            this.grpOverrideVelocity.Size = new System.Drawing.Size(461, 149);
            this.grpOverrideVelocity.TabIndex = 17;
            this.grpOverrideVelocity.TabStop = false;
            this.grpOverrideVelocity.Text = "< Override Velocity >";
            // 
            // btnSetOverride
            // 
            this.btnSetOverride.Location = new System.Drawing.Point(343, 66);
            this.btnSetOverride.Name = "btnSetOverride";
            this.btnSetOverride.Size = new System.Drawing.Size(110, 72);
            this.btnSetOverride.TabIndex = 27;
            this.btnSetOverride.Text = "Override";
            this.btnSetOverride.UseVisualStyleBackColor = true;
            this.btnSetOverride.Click += new System.EventHandler(this.btnSetOverride_Click);
            // 
            // btnSetOverrideMaxVel
            // 
            this.btnSetOverrideMaxVel.Location = new System.Drawing.Point(343, 39);
            this.btnSetOverrideMaxVel.Name = "btnSetOverrideMaxVel";
            this.btnSetOverrideMaxVel.Size = new System.Drawing.Size(110, 21);
            this.btnSetOverrideMaxVel.TabIndex = 26;
            this.btnSetOverrideMaxVel.Text = "Set Velocity";
            this.btnSetOverrideMaxVel.UseVisualStyleBackColor = true;
            this.btnSetOverrideMaxVel.Click += new System.EventHandler(this.btnSetOverrideMaxVel_Click);
            // 
            // chkOverrideOnlyVel
            // 
            this.chkOverrideOnlyVel.Location = new System.Drawing.Point(345, 14);
            this.chkOverrideOnlyVel.Name = "chkOverrideOnlyVel";
            this.chkOverrideOnlyVel.Size = new System.Drawing.Size(110, 20);
            this.chkOverrideOnlyVel.TabIndex = 39;
            this.chkOverrideOnlyVel.Text = "Over Only Vel";
            this.chkOverrideOnlyVel.UseVisualStyleBackColor = true;
            this.chkOverrideOnlyVel.Click += new System.EventHandler(this.chkOverrideOnlyVel_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(273, 69);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 12);
            this.label27.TabIndex = 38;
            this.label27.Text = "Unit/Sec";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(273, 121);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 12);
            this.label26.TabIndex = 37;
            this.label26.Text = "Unit/Sec^2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(273, 95);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 12);
            this.label25.TabIndex = 31;
            this.label25.Text = "Unit/Sec^2";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(273, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 12);
            this.label24.TabIndex = 36;
            this.label24.Text = "Unit/Sec";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(273, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 12);
            this.label23.TabIndex = 31;
            this.label23.Text = "Unit/Sec";
            // 
            // labOverrideMaxVel
            // 
            this.labOverrideMaxVel.Location = new System.Drawing.Point(127, 12);
            this.labOverrideMaxVel.Name = "labOverrideMaxVel";
            this.labOverrideMaxVel.Size = new System.Drawing.Size(143, 21);
            this.labOverrideMaxVel.TabIndex = 35;
            this.labOverrideMaxVel.Text = "xxx.xxx";
            this.labOverrideMaxVel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 12);
            this.label22.TabIndex = 34;
            this.label22.Text = "Valid Over Max Vel:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(119, 12);
            this.label21.TabIndex = 32;
            this.label21.Text = "Override Max Vel   :";
            // 
            // edtOverrideMaxVel
            // 
            this.edtOverrideMaxVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideMaxVel.DecimalPlaces = 3;
            this.edtOverrideMaxVel.Location = new System.Drawing.Point(127, 39);
            this.edtOverrideMaxVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideMaxVel.Name = "edtOverrideMaxVel";
            this.edtOverrideMaxVel.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideMaxVel.TabIndex = 33;
            this.edtOverrideMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtOverrideDec
            // 
            this.edtOverrideDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideDec.DecimalPlaces = 3;
            this.edtOverrideDec.Location = new System.Drawing.Point(127, 117);
            this.edtOverrideDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideDec.Name = "edtOverrideDec";
            this.edtOverrideDec.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideDec.TabIndex = 31;
            this.edtOverrideDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtOverrideAcc
            // 
            this.edtOverrideAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideAcc.DecimalPlaces = 3;
            this.edtOverrideAcc.Location = new System.Drawing.Point(127, 91);
            this.edtOverrideAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideAcc.Name = "edtOverrideAcc";
            this.edtOverrideAcc.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideAcc.TabIndex = 30;
            this.edtOverrideAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 12);
            this.label20.TabIndex = 26;
            this.label20.Text = "Override Velocity   :";
            // 
            // edtOverrideVel
            // 
            this.edtOverrideVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideVel.DecimalPlaces = 3;
            this.edtOverrideVel.Location = new System.Drawing.Point(127, 65);
            this.edtOverrideVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideVel.Name = "edtOverrideVel";
            this.edtOverrideVel.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideVel.TabIndex = 29;
            this.edtOverrideVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "Override Accel      :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "Override Decel      :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // OverrideVelocity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpOverrideVelocity);
            this.Controls.Add(this.grpJogMove);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverrideVelocity";
            this.Text = "OverrideVelocity";
            this.Load += new System.EventHandler(this.OverrideVelocity_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAccDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpJogMove.ResumeLayout(false);
            this.grpJogMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAccDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).EndInit();
            this.grpOverrideVelocity.ResumeLayout(false);
            this.grpOverrideVelocity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideMaxVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideVel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.TextBox edtCmdVel;
        private System.Windows.Forms.TextBox edtActPos;
        private System.Windows.Forms.TextBox edtCmdPos;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpJogMove;
        private System.Windows.Forms.GroupBox grpOverrideVelocity;
        private System.Windows.Forms.Button btnJogMoveStop;
        private System.Windows.Forms.Button btnJogMove;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown edtJogAccDec;
        private System.Windows.Forms.NumericUpDown edtJogVel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labOverrideMaxVel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown edtOverrideMaxVel;
        private System.Windows.Forms.NumericUpDown edtOverrideDec;
        private System.Windows.Forms.NumericUpDown edtOverrideAcc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown edtOverrideVel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSetOverride;
        private System.Windows.Forms.Button btnSetOverrideMaxVel;
        private System.Windows.Forms.CheckBox chkOverrideOnlyVel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer tmDisplay;
    }
}

