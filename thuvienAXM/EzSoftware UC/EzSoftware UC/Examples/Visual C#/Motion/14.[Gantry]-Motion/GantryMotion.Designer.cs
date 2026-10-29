namespace GantryMotion
{
    partial class GantryMotion
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
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtCmdVelSl = new System.Windows.Forms.TextBox();
            this.edtActPosSl = new System.Windows.Forms.TextBox();
            this.edtCmdPosSl = new System.Windows.Forms.TextBox();
            this.edtCmdVelMa = new System.Windows.Forms.TextBox();
            this.edtActPosMa = new System.Windows.Forms.TextBox();
            this.edtCmdPosMa = new System.Windows.Forms.TextBox();
            this.chkHomeStateSl = new System.Windows.Forms.CheckBox();
            this.chkHomeStateMa = new System.Windows.Forms.CheckBox();
            this.lblGantryState = new System.Windows.Forms.Label();
            this.labAxisNoSl = new System.Windows.Forms.Label();
            this.labAxisNoMa = new System.Windows.Forms.Label();
            this.chkServoOn = new System.Windows.Forms.CheckBox();
            this.btnPosClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpOverrideVelocityAtPosition = new System.Windows.Forms.GroupBox();
            this.btnJogMoveP = new System.Windows.Forms.Button();
            this.btnMoveStop = new System.Windows.Forms.Button();
            this.edtMoveDec = new System.Windows.Forms.NumericUpDown();
            this.edtMoveAcc = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.edtMovePos = new System.Windows.Forms.NumericUpDown();
            this.btnJogMoveN = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMovePos = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.rdoRel = new System.Windows.Forms.RadioButton();
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.grpHomeSearch = new System.Windows.Forms.GroupBox();
            this.labelHomeStepSub33 = new System.Windows.Forms.Label();
            this.labelHomeStepMain32 = new System.Windows.Forms.Label();
            this.labelHomeSearch = new System.Windows.Forms.Label();
            this.prgHomeRate = new System.Windows.Forms.ProgressBar();
            this.label22 = new System.Windows.Forms.Label();
            this.btnHomeStop = new System.Windows.Forms.Button();
            this.btnHomeStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.grpGantryEnable = new System.Windows.Forms.GroupBox();
            this.chkGantryEnable = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboGantryHmSlaveUse = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edtGantryHmOffset = new System.Windows.Forms.TextBox();
            this.edtGantryHmRange = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tmHomeInfo = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpOverrideVelocityAtPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).BeginInit();
            this.grpHomeSearch.SuspendLayout();
            this.grpGantryEnable.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 32);
            this.groupBox4.TabIndex = 16;
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
            this.cboSelAxis.Size = new System.Drawing.Size(211, 20);
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
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtCmdVelSl);
            this.groupBox1.Controls.Add(this.edtActPosSl);
            this.groupBox1.Controls.Add(this.edtCmdPosSl);
            this.groupBox1.Controls.Add(this.edtCmdVelMa);
            this.groupBox1.Controls.Add(this.edtActPosMa);
            this.groupBox1.Controls.Add(this.edtCmdPosMa);
            this.groupBox1.Controls.Add(this.chkHomeStateSl);
            this.groupBox1.Controls.Add(this.chkHomeStateMa);
            this.groupBox1.Controls.Add(this.lblGantryState);
            this.groupBox1.Controls.Add(this.labAxisNoSl);
            this.groupBox1.Controls.Add(this.labAxisNoMa);
            this.groupBox1.Controls.Add(this.chkServoOn);
            this.groupBox1.Controls.Add(this.btnPosClear);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 125);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // edtCmdVelSl
            // 
            this.edtCmdVelSl.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdVelSl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdVelSl.Location = new System.Drawing.Point(233, 77);
            this.edtCmdVelSl.Name = "edtCmdVelSl";
            this.edtCmdVelSl.ReadOnly = true;
            this.edtCmdVelSl.Size = new System.Drawing.Size(104, 21);
            this.edtCmdVelSl.TabIndex = 28;
            this.edtCmdVelSl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPosSl
            // 
            this.edtActPosSl.BackColor = System.Drawing.SystemColors.Control;
            this.edtActPosSl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtActPosSl.Location = new System.Drawing.Point(233, 54);
            this.edtActPosSl.Name = "edtActPosSl";
            this.edtActPosSl.ReadOnly = true;
            this.edtActPosSl.Size = new System.Drawing.Size(104, 21);
            this.edtActPosSl.TabIndex = 27;
            this.edtActPosSl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPosSl
            // 
            this.edtCmdPosSl.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdPosSl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdPosSl.Location = new System.Drawing.Point(233, 31);
            this.edtCmdPosSl.Name = "edtCmdPosSl";
            this.edtCmdPosSl.ReadOnly = true;
            this.edtCmdPosSl.Size = new System.Drawing.Size(104, 21);
            this.edtCmdPosSl.TabIndex = 26;
            this.edtCmdPosSl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdVelMa
            // 
            this.edtCmdVelMa.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdVelMa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdVelMa.Location = new System.Drawing.Point(127, 77);
            this.edtCmdVelMa.Name = "edtCmdVelMa";
            this.edtCmdVelMa.ReadOnly = true;
            this.edtCmdVelMa.Size = new System.Drawing.Size(104, 21);
            this.edtCmdVelMa.TabIndex = 25;
            this.edtCmdVelMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPosMa
            // 
            this.edtActPosMa.BackColor = System.Drawing.SystemColors.Control;
            this.edtActPosMa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtActPosMa.Location = new System.Drawing.Point(127, 54);
            this.edtActPosMa.Name = "edtActPosMa";
            this.edtActPosMa.ReadOnly = true;
            this.edtActPosMa.Size = new System.Drawing.Size(104, 21);
            this.edtActPosMa.TabIndex = 24;
            this.edtActPosMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPosMa
            // 
            this.edtCmdPosMa.BackColor = System.Drawing.SystemColors.Control;
            this.edtCmdPosMa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCmdPosMa.Location = new System.Drawing.Point(127, 31);
            this.edtCmdPosMa.Name = "edtCmdPosMa";
            this.edtCmdPosMa.ReadOnly = true;
            this.edtCmdPosMa.Size = new System.Drawing.Size(104, 21);
            this.edtCmdPosMa.TabIndex = 23;
            this.edtCmdPosMa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkHomeStateSl
            // 
            this.chkHomeStateSl.AutoSize = true;
            this.chkHomeStateSl.Enabled = false;
            this.chkHomeStateSl.Location = new System.Drawing.Point(234, 102);
            this.chkHomeStateSl.Name = "chkHomeStateSl";
            this.chkHomeStateSl.Size = new System.Drawing.Size(89, 16);
            this.chkHomeStateSl.TabIndex = 22;
            this.chkHomeStateSl.Text = "Home State";
            this.chkHomeStateSl.UseVisualStyleBackColor = true;
            // 
            // chkHomeStateMa
            // 
            this.chkHomeStateMa.AutoSize = true;
            this.chkHomeStateMa.Enabled = false;
            this.chkHomeStateMa.Location = new System.Drawing.Point(128, 102);
            this.chkHomeStateMa.Name = "chkHomeStateMa";
            this.chkHomeStateMa.Size = new System.Drawing.Size(89, 16);
            this.chkHomeStateMa.TabIndex = 21;
            this.chkHomeStateMa.Text = "Home State";
            this.chkHomeStateMa.UseVisualStyleBackColor = true;
            // 
            // lblGantryState
            // 
            this.lblGantryState.AutoSize = true;
            this.lblGantryState.Location = new System.Drawing.Point(225, 15);
            this.lblGantryState.Name = "lblGantryState";
            this.lblGantryState.Size = new System.Drawing.Size(15, 12);
            this.lblGantryState.TabIndex = 20;
            this.lblGantryState.Text = "∞";
            this.lblGantryState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labAxisNoSl
            // 
            this.labAxisNoSl.AutoSize = true;
            this.labAxisNoSl.Location = new System.Drawing.Point(252, 15);
            this.labAxisNoSl.Name = "labAxisNoSl";
            this.labAxisNoSl.Size = new System.Drawing.Size(61, 12);
            this.labAxisNoSl.TabIndex = 19;
            this.labAxisNoSl.Text = "Sl Axis 01";
            this.labAxisNoSl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labAxisNoMa
            // 
            this.labAxisNoMa.AutoSize = true;
            this.labAxisNoMa.Location = new System.Drawing.Point(147, 15);
            this.labAxisNoMa.Name = "labAxisNoMa";
            this.labAxisNoMa.Size = new System.Drawing.Size(68, 12);
            this.labAxisNoMa.TabIndex = 18;
            this.labAxisNoMa.Text = "Ma Axis 00";
            this.labAxisNoMa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 77);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(110, 21);
            this.chkServoOn.TabIndex = 13;
            this.chkServoOn.Text = "Servo On";
            this.chkServoOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkServoOn.UseVisualStyleBackColor = true;
            this.chkServoOn.Click += new System.EventHandler(this.chkServoOn_Click);
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(343, 31);
            this.btnPosClear.Name = "btnPosClear";
            this.btnPosClear.Size = new System.Drawing.Size(110, 43);
            this.btnPosClear.TabIndex = 9;
            this.btnPosClear.Text = "Position Clear";
            this.btnPosClear.UseVisualStyleBackColor = true;
            this.btnPosClear.Click += new System.EventHandler(this.btnPosClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Position  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Position :";
            // 
            // grpOverrideVelocityAtPosition
            // 
            this.grpOverrideVelocityAtPosition.Controls.Add(this.btnJogMoveP);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.btnMoveStop);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.edtMoveDec);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.edtMoveAcc);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.edtMoveVel);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.edtMovePos);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.btnJogMoveN);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.label21);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.label10);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.label17);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.btnMovePos);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.label12);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.rdoRel);
            this.grpOverrideVelocityAtPosition.Controls.Add(this.rdoAbs);
            this.grpOverrideVelocityAtPosition.Location = new System.Drawing.Point(8, 173);
            this.grpOverrideVelocityAtPosition.Name = "grpOverrideVelocityAtPosition";
            this.grpOverrideVelocityAtPosition.Size = new System.Drawing.Size(461, 145);
            this.grpOverrideVelocityAtPosition.TabIndex = 18;
            this.grpOverrideVelocityAtPosition.TabStop = false;
            this.grpOverrideVelocityAtPosition.Text = "Position Move";
            // 
            // btnJogMoveP
            // 
            this.btnJogMoveP.Location = new System.Drawing.Point(343, 86);
            this.btnJogMoveP.Name = "btnJogMoveP";
            this.btnJogMoveP.Size = new System.Drawing.Size(110, 24);
            this.btnJogMoveP.TabIndex = 28;
            this.btnJogMoveP.Text = "Move Jog(+)";
            this.btnJogMoveP.UseVisualStyleBackColor = true;
            this.btnJogMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseDown);
            this.btnJogMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseUp);
            // 
            // btnMoveStop
            // 
            this.btnMoveStop.Location = new System.Drawing.Point(343, 60);
            this.btnMoveStop.Name = "btnMoveStop";
            this.btnMoveStop.Size = new System.Drawing.Size(110, 24);
            this.btnMoveStop.TabIndex = 27;
            this.btnMoveStop.Text = "Move Stop";
            this.btnMoveStop.UseVisualStyleBackColor = true;
            this.btnMoveStop.Click += new System.EventHandler(this.btnMoveStop_Click);
            // 
            // edtMoveDec
            // 
            this.edtMoveDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveDec.DecimalPlaces = 3;
            this.edtMoveDec.Location = new System.Drawing.Point(127, 114);
            this.edtMoveDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveDec.Name = "edtMoveDec";
            this.edtMoveDec.Size = new System.Drawing.Size(211, 21);
            this.edtMoveDec.TabIndex = 26;
            this.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAcc.DecimalPlaces = 3;
            this.edtMoveAcc.Location = new System.Drawing.Point(127, 88);
            this.edtMoveAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(211, 21);
            this.edtMoveAcc.TabIndex = 25;
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(127, 62);
            this.edtMoveVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(211, 21);
            this.edtMoveVel.TabIndex = 24;
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMovePos
            // 
            this.edtMovePos.BackColor = System.Drawing.SystemColors.Window;
            this.edtMovePos.DecimalPlaces = 3;
            this.edtMovePos.Location = new System.Drawing.Point(127, 36);
            this.edtMovePos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMovePos.Name = "edtMovePos";
            this.edtMovePos.Size = new System.Drawing.Size(211, 21);
            this.edtMovePos.TabIndex = 22;
            this.edtMovePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnJogMoveN
            // 
            this.btnJogMoveN.Location = new System.Drawing.Point(343, 112);
            this.btnJogMoveN.Name = "btnJogMoveN";
            this.btnJogMoveN.Size = new System.Drawing.Size(110, 24);
            this.btnJogMoveN.TabIndex = 21;
            this.btnJogMoveN.Text = "Move Jog(-)";
            this.btnJogMoveN.UseVisualStyleBackColor = true;
            this.btnJogMoveN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseDown);
            this.btnJogMoveN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(118, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "Move Deceleration :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "Move Acceleration :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity       :";
            // 
            // btnMovePos
            // 
            this.btnMovePos.Location = new System.Drawing.Point(343, 34);
            this.btnMovePos.Name = "btnMovePos";
            this.btnMovePos.Size = new System.Drawing.Size(110, 24);
            this.btnMovePos.TabIndex = 10;
            this.btnMovePos.Text = "Move Target";
            this.btnMovePos.UseVisualStyleBackColor = true;
            this.btnMovePos.Click += new System.EventHandler(this.btnMovePos_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Target Position      :";
            // 
            // rdoRel
            // 
            this.rdoRel.AutoSize = true;
            this.rdoRel.Location = new System.Drawing.Point(236, 16);
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
            this.rdoAbs.Location = new System.Drawing.Point(132, 16);
            this.rdoAbs.Name = "rdoAbs";
            this.rdoAbs.Size = new System.Drawing.Size(100, 16);
            this.rdoAbs.TabIndex = 0;
            this.rdoAbs.TabStop = true;
            this.rdoAbs.Tag = "0";
            this.rdoAbs.Text = "[00] Absolute";
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // grpHomeSearch
            // 
            this.grpHomeSearch.Controls.Add(this.labelHomeStepSub33);
            this.grpHomeSearch.Controls.Add(this.labelHomeStepMain32);
            this.grpHomeSearch.Controls.Add(this.labelHomeSearch);
            this.grpHomeSearch.Controls.Add(this.prgHomeRate);
            this.grpHomeSearch.Controls.Add(this.label22);
            this.grpHomeSearch.Controls.Add(this.btnHomeStop);
            this.grpHomeSearch.Controls.Add(this.btnHomeStart);
            this.grpHomeSearch.Controls.Add(this.label6);
            this.grpHomeSearch.Location = new System.Drawing.Point(8, 327);
            this.grpHomeSearch.Name = "grpHomeSearch";
            this.grpHomeSearch.Size = new System.Drawing.Size(461, 75);
            this.grpHomeSearch.TabIndex = 19;
            this.grpHomeSearch.TabStop = false;
            this.grpHomeSearch.Text = "Home Search";
            // 
            // labelHomeStepSub33
            // 
            this.labelHomeStepSub33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeStepSub33.Location = new System.Drawing.Point(163, 45);
            this.labelHomeStepSub33.Name = "labelHomeStepSub33";
            this.labelHomeStepSub33.Size = new System.Drawing.Size(32, 21);
            this.labelHomeStepSub33.TabIndex = 50;
            this.labelHomeStepSub33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHomeStepMain32
            // 
            this.labelHomeStepMain32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeStepMain32.Location = new System.Drawing.Point(127, 45);
            this.labelHomeStepMain32.Name = "labelHomeStepMain32";
            this.labelHomeStepMain32.Size = new System.Drawing.Size(32, 21);
            this.labelHomeStepMain32.TabIndex = 49;
            this.labelHomeStepMain32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHomeSearch
            // 
            this.labelHomeSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHomeSearch.Location = new System.Drawing.Point(127, 20);
            this.labelHomeSearch.Name = "labelHomeSearch";
            this.labelHomeSearch.Size = new System.Drawing.Size(211, 21);
            this.labelHomeSearch.TabIndex = 48;
            this.labelHomeSearch.Text = " [FFH] HOME_ERR_UNKNOWN";
            this.labelHomeSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prgHomeRate
            // 
            this.prgHomeRate.Location = new System.Drawing.Point(199, 45);
            this.prgHomeRate.Name = "prgHomeRate";
            this.prgHomeRate.Size = new System.Drawing.Size(139, 21);
            this.prgHomeRate.TabIndex = 47;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "Home Step/Rate    : ";
            // 
            // btnHomeStop
            // 
            this.btnHomeStop.Location = new System.Drawing.Point(343, 45);
            this.btnHomeStop.Name = "btnHomeStop";
            this.btnHomeStop.Size = new System.Drawing.Size(110, 21);
            this.btnHomeStop.TabIndex = 43;
            this.btnHomeStop.Text = "Home Stop";
            this.btnHomeStop.UseVisualStyleBackColor = true;
            this.btnHomeStop.Click += new System.EventHandler(this.btnHomeStop_Click);
            // 
            // btnHomeStart
            // 
            this.btnHomeStart.Location = new System.Drawing.Point(343, 21);
            this.btnHomeStart.Name = "btnHomeStart";
            this.btnHomeStart.Size = new System.Drawing.Size(110, 21);
            this.btnHomeStart.TabIndex = 41;
            this.btnHomeStart.Text = "Home Start";
            this.btnHomeStart.UseVisualStyleBackColor = true;
            this.btnHomeStart.Click += new System.EventHandler(this.btnHomeStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "Home Result         :";
            // 
            // grpGantryEnable
            // 
            this.grpGantryEnable.Controls.Add(this.chkGantryEnable);
            this.grpGantryEnable.Controls.Add(this.groupBox2);
            this.grpGantryEnable.Controls.Add(this.cboGantryHmSlaveUse);
            this.grpGantryEnable.Controls.Add(this.label9);
            this.grpGantryEnable.Controls.Add(this.groupBox3);
            this.grpGantryEnable.Controls.Add(this.edtGantryHmOffset);
            this.grpGantryEnable.Controls.Add(this.edtGantryHmRange);
            this.grpGantryEnable.Controls.Add(this.label7);
            this.grpGantryEnable.Controls.Add(this.label8);
            this.grpGantryEnable.Location = new System.Drawing.Point(8, 412);
            this.grpGantryEnable.Name = "grpGantryEnable";
            this.grpGantryEnable.Size = new System.Drawing.Size(461, 81);
            this.grpGantryEnable.TabIndex = 20;
            this.grpGantryEnable.TabStop = false;
            this.grpGantryEnable.Text = "< Gantry Enable >";
            // 
            // chkGantryEnable
            // 
            this.chkGantryEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGantryEnable.Location = new System.Drawing.Point(343, 55);
            this.chkGantryEnable.Name = "chkGantryEnable";
            this.chkGantryEnable.Size = new System.Drawing.Size(117, 24);
            this.chkGantryEnable.TabIndex = 29;
            this.chkGantryEnable.Text = "Gantry Enable";
            this.chkGantryEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGantryEnable.UseVisualStyleBackColor = true;
            this.chkGantryEnable.Click += new System.EventHandler(this.chkGantryEnable_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(343, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 10);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // cboGantryHmSlaveUse
            // 
            this.cboGantryHmSlaveUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGantryHmSlaveUse.FormattingEnabled = true;
            this.cboGantryHmSlaveUse.Items.AddRange(new object[] {
            "00: NONE",
            "01: BOTH",
            "02: EACH"});
            this.cboGantryHmSlaveUse.Location = new System.Drawing.Point(343, 19);
            this.cboGantryHmSlaveUse.Name = "cboGantryHmSlaveUse";
            this.cboGantryHmSlaveUse.Size = new System.Drawing.Size(110, 20);
            this.cboGantryHmSlaveUse.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "Slave Hm Use :";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(236, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(5, 56);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // edtGantryHmOffset
            // 
            this.edtGantryHmOffset.Location = new System.Drawing.Point(127, 21);
            this.edtGantryHmOffset.Name = "edtGantryHmOffset";
            this.edtGantryHmOffset.Size = new System.Drawing.Size(102, 21);
            this.edtGantryHmOffset.TabIndex = 33;
            this.edtGantryHmOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtGantryHmRange
            // 
            this.edtGantryHmRange.Location = new System.Drawing.Point(127, 48);
            this.edtGantryHmRange.Name = "edtGantryHmRange";
            this.edtGantryHmRange.Size = new System.Drawing.Size(102, 21);
            this.edtGantryHmRange.TabIndex = 32;
            this.edtGantryHmRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "Slave Home Range :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "Slave Home Offset  :";
            // 
            // tmHomeInfo
            // 
            this.tmHomeInfo.Enabled = true;
            this.tmHomeInfo.Tick += new System.EventHandler(this.tmHomeInfo_Tick);
            // 
            // GantryMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpGantryEnable);
            this.Controls.Add(this.grpHomeSearch);
            this.Controls.Add(this.grpOverrideVelocityAtPosition);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GantryMotion";
            this.Text = "GantryMotion";
            this.Load += new System.EventHandler(this.GantryMotion_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GantryMotion_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpOverrideVelocityAtPosition.ResumeLayout(false);
            this.grpOverrideVelocityAtPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).EndInit();
            this.grpHomeSearch.ResumeLayout(false);
            this.grpHomeSearch.PerformLayout();
            this.grpGantryEnable.ResumeLayout(false);
            this.grpGantryEnable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkHomeStateMa;
        private System.Windows.Forms.Label lblGantryState;
        private System.Windows.Forms.Label labAxisNoSl;
        private System.Windows.Forms.Label labAxisNoMa;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHomeStateSl;
        private System.Windows.Forms.GroupBox grpOverrideVelocityAtPosition;
        private System.Windows.Forms.Button btnJogMoveP;
        private System.Windows.Forms.Button btnMoveStop;
        private System.Windows.Forms.NumericUpDown edtMoveDec;
        private System.Windows.Forms.NumericUpDown edtMoveAcc;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.NumericUpDown edtMovePos;
        private System.Windows.Forms.Button btnJogMoveN;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMovePos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoRel;
        private System.Windows.Forms.RadioButton rdoAbs;
        private System.Windows.Forms.GroupBox grpHomeSearch;
        private System.Windows.Forms.Label labelHomeStepSub33;
        private System.Windows.Forms.Label labelHomeStepMain32;
        private System.Windows.Forms.Label labelHomeSearch;
        private System.Windows.Forms.ProgressBar prgHomeRate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnHomeStop;
        private System.Windows.Forms.Button btnHomeStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpGantryEnable;
        private System.Windows.Forms.TextBox edtGantryHmRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboGantryHmSlaveUse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox edtGantryHmOffset;
        private System.Windows.Forms.TextBox edtCmdVelSl;
        private System.Windows.Forms.TextBox edtActPosSl;
        private System.Windows.Forms.TextBox edtCmdPosSl;
        private System.Windows.Forms.TextBox edtCmdVelMa;
        private System.Windows.Forms.TextBox edtActPosMa;
        private System.Windows.Forms.TextBox edtCmdPosMa;
        private System.Windows.Forms.CheckBox chkGantryEnable;
        private System.Windows.Forms.Timer tmHomeInfo;
    }
}

