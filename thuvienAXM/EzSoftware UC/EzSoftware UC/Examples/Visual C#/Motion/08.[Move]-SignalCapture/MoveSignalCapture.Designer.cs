namespace MoveSignalCapture
{
    partial class MoveSignalCapture
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
            this.grpSignalCaptureMove = new System.Windows.Forms.GroupBox();
            this.btnGetPos = new System.Windows.Forms.Button();
            this.edtCapturePos = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboStopMethod = new System.Windows.Forms.ComboBox();
            this.cboCaptureTarget = new System.Windows.Forms.ComboBox();
            this.cboSignalEdge = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMovetop = new System.Windows.Forms.Button();
            this.btnCaptureMove = new System.Windows.Forms.Button();
            this.cboDetectSig = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.edtMoveAcc = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpSignalCaptureMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 35);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(343, 10);
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
            this.cboSelAxis.Location = new System.Drawing.Point(129, 10);
            this.cboSelAxis.Name = "cboSelAxis";
            this.cboSelAxis.Size = new System.Drawing.Size(208, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No :";
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
            this.groupBox3.Location = new System.Drawing.Point(8, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 106);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Jog(Velocity) Move";
            // 
            // edtJogDec
            // 
            this.edtJogDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogDec.DecimalPlaces = 3;
            this.edtJogDec.Location = new System.Drawing.Point(129, 74);
            this.edtJogDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogDec.Name = "edtJogDec";
            this.edtJogDec.Size = new System.Drawing.Size(143, 21);
            this.edtJogDec.TabIndex = 34;
            this.edtJogDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtJogAcc
            // 
            this.edtJogAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogAcc.DecimalPlaces = 3;
            this.edtJogAcc.Location = new System.Drawing.Point(129, 46);
            this.edtJogAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogAcc.Name = "edtJogAcc";
            this.edtJogAcc.Size = new System.Drawing.Size(143, 21);
            this.edtJogAcc.TabIndex = 33;
            this.edtJogAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtJogVel
            // 
            this.edtJogVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtJogVel.DecimalPlaces = 3;
            this.edtJogVel.Location = new System.Drawing.Point(129, 18);
            this.edtJogVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtJogVel.Name = "edtJogVel";
            this.edtJogVel.Size = new System.Drawing.Size(143, 21);
            this.edtJogVel.TabIndex = 27;
            this.edtJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnJogMoveN
            // 
            this.btnJogMoveN.Location = new System.Drawing.Point(343, 58);
            this.btnJogMoveN.Name = "btnJogMoveN";
            this.btnJogMoveN.Size = new System.Drawing.Size(110, 37);
            this.btnJogMoveN.TabIndex = 32;
            this.btnJogMoveN.Text = "Jog Move (-)";
            this.btnJogMoveN.UseVisualStyleBackColor = true;
            this.btnJogMoveN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseDown);
            this.btnJogMoveN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveN_MouseUp);
            // 
            // btnJogMoveP
            // 
            this.btnJogMoveP.Location = new System.Drawing.Point(343, 18);
            this.btnJogMoveP.Name = "btnJogMoveP";
            this.btnJogMoveP.Size = new System.Drawing.Size(110, 37);
            this.btnJogMoveP.TabIndex = 31;
            this.btnJogMoveP.Text = "Jog Move (+)";
            this.btnJogMoveP.UseVisualStyleBackColor = true;
            this.btnJogMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseDown);
            this.btnJogMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMoveP_MouseUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(272, 77);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 12);
            this.label22.TabIndex = 30;
            this.label22.Text = "Unit/Sec^2";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(122, 12);
            this.label27.TabIndex = 22;
            this.label27.Text = "Jog Velocity           :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 77);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(123, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "Jog Deceleration     :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(272, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 12);
            this.label24.TabIndex = 27;
            this.label24.Text = "Unit/Sec^2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(272, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 12);
            this.label26.TabIndex = 24;
            this.label26.Text = "Unit/Sec";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 12);
            this.label25.TabIndex = 25;
            this.label25.Text = "Jog Acceleration     :";
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
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 105);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(343, 68);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(110, 25);
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
            this.edtCmdVel.Location = new System.Drawing.Point(129, 72);
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
            this.edtActPos.Location = new System.Drawing.Point(129, 46);
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
            this.edtCmdPos.Location = new System.Drawing.Point(129, 19);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(143, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(343, 19);
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
            this.label10.Location = new System.Drawing.Point(272, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Unit/Sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Position  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Position :";
            // 
            // grpSignalCaptureMove
            // 
            this.grpSignalCaptureMove.Controls.Add(this.btnGetPos);
            this.grpSignalCaptureMove.Controls.Add(this.edtCapturePos);
            this.grpSignalCaptureMove.Controls.Add(this.label16);
            this.grpSignalCaptureMove.Controls.Add(this.cboStopMethod);
            this.grpSignalCaptureMove.Controls.Add(this.cboCaptureTarget);
            this.grpSignalCaptureMove.Controls.Add(this.cboSignalEdge);
            this.grpSignalCaptureMove.Controls.Add(this.groupBox2);
            this.grpSignalCaptureMove.Controls.Add(this.btnMovetop);
            this.grpSignalCaptureMove.Controls.Add(this.btnCaptureMove);
            this.grpSignalCaptureMove.Controls.Add(this.cboDetectSig);
            this.grpSignalCaptureMove.Controls.Add(this.label15);
            this.grpSignalCaptureMove.Controls.Add(this.label14);
            this.grpSignalCaptureMove.Controls.Add(this.label13);
            this.grpSignalCaptureMove.Controls.Add(this.label12);
            this.grpSignalCaptureMove.Controls.Add(this.label7);
            this.grpSignalCaptureMove.Controls.Add(this.label11);
            this.grpSignalCaptureMove.Controls.Add(this.edtMoveAcc);
            this.grpSignalCaptureMove.Controls.Add(this.edtMoveVel);
            this.grpSignalCaptureMove.Controls.Add(this.label6);
            this.grpSignalCaptureMove.Controls.Add(this.label5);
            this.grpSignalCaptureMove.Location = new System.Drawing.Point(8, 264);
            this.grpSignalCaptureMove.Name = "grpSignalCaptureMove";
            this.grpSignalCaptureMove.Size = new System.Drawing.Size(461, 232);
            this.grpSignalCaptureMove.TabIndex = 10;
            this.grpSignalCaptureMove.TabStop = false;
            this.grpSignalCaptureMove.Text = "< Signal Capture Move >";
            // 
            // btnGetPos
            // 
            this.btnGetPos.Location = new System.Drawing.Point(343, 200);
            this.btnGetPos.Name = "btnGetPos";
            this.btnGetPos.Size = new System.Drawing.Size(110, 21);
            this.btnGetPos.TabIndex = 51;
            this.btnGetPos.Text = "Get Position";
            this.btnGetPos.UseVisualStyleBackColor = true;
            this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
            // 
            // edtCapturePos
            // 
            this.edtCapturePos.Location = new System.Drawing.Point(129, 200);
            this.edtCapturePos.Name = "edtCapturePos";
            this.edtCapturePos.ReadOnly = true;
            this.edtCapturePos.Size = new System.Drawing.Size(208, 21);
            this.edtCapturePos.TabIndex = 50;
            this.edtCapturePos.Text = "xxx.xxx";
            this.edtCapturePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 12);
            this.label16.TabIndex = 49;
            this.label16.Text = "Capture Position    :";
            // 
            // cboStopMethod
            // 
            this.cboStopMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopMethod.FormattingEnabled = true;
            this.cboStopMethod.Items.AddRange(new object[] {
            "00: EMERGENCY_STOP",
            "01: SLOWDOWN_STOP"});
            this.cboStopMethod.Location = new System.Drawing.Point(129, 156);
            this.cboStopMethod.Name = "cboStopMethod";
            this.cboStopMethod.Size = new System.Drawing.Size(208, 20);
            this.cboStopMethod.TabIndex = 48;
            // 
            // cboCaptureTarget
            // 
            this.cboCaptureTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaptureTarget.FormattingEnabled = true;
            this.cboCaptureTarget.Items.AddRange(new object[] {
            "00: COMMAND",
            "01: ACTUAL"});
            this.cboCaptureTarget.Location = new System.Drawing.Point(129, 129);
            this.cboCaptureTarget.Name = "cboCaptureTarget";
            this.cboCaptureTarget.Size = new System.Drawing.Size(208, 20);
            this.cboCaptureTarget.TabIndex = 47;
            // 
            // cboSignalEdge
            // 
            this.cboSignalEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignalEdge.FormattingEnabled = true;
            this.cboSignalEdge.Items.AddRange(new object[] {
            "00: SIGNAL_DOWN_EDGE",
            "01: SIGNAL_UP_EDGE"});
            this.cboSignalEdge.Location = new System.Drawing.Point(129, 102);
            this.cboSignalEdge.Name = "cboSignalEdge";
            this.cboSignalEdge.Size = new System.Drawing.Size(208, 20);
            this.cboSignalEdge.TabIndex = 46;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 11);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnMovetop
            // 
            this.btnMovetop.Location = new System.Drawing.Point(343, 102);
            this.btnMovetop.Name = "btnMovetop";
            this.btnMovetop.Size = new System.Drawing.Size(110, 74);
            this.btnMovetop.TabIndex = 45;
            this.btnMovetop.Text = "Move Stop";
            this.btnMovetop.UseVisualStyleBackColor = true;
            this.btnMovetop.Click += new System.EventHandler(this.btnMovetop_Click);
            // 
            // btnCaptureMove
            // 
            this.btnCaptureMove.Location = new System.Drawing.Point(343, 16);
            this.btnCaptureMove.Name = "btnCaptureMove";
            this.btnCaptureMove.Size = new System.Drawing.Size(110, 78);
            this.btnCaptureMove.TabIndex = 44;
            this.btnCaptureMove.Text = "Capture Move";
            this.btnCaptureMove.UseVisualStyleBackColor = true;
            this.btnCaptureMove.Click += new System.EventHandler(this.btnCaptureMove_Click);
            // 
            // cboDetectSig
            // 
            this.cboDetectSig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetectSig.FormattingEnabled = true;
            this.cboDetectSig.Items.AddRange(new object[] {
            "00: PosEndLimit",
            "01: NegEndLimit",
            "04: HomeSensor",
            "05: EncodZPhase",
            "06: UniInput02",
            "07: UniInput03"});
            this.cboDetectSig.Location = new System.Drawing.Point(129, 75);
            this.cboDetectSig.Name = "cboDetectSig";
            this.cboDetectSig.Size = new System.Drawing.Size(208, 20);
            this.cboDetectSig.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 12);
            this.label15.TabIndex = 42;
            this.label15.Text = "Stop Method          :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "Signal Edge           :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 12);
            this.label13.TabIndex = 40;
            this.label13.Text = "Capture Target       :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "Detect Signal          :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "Unit/Sec^2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 12);
            this.label11.TabIndex = 35;
            this.label11.Text = "Unit/Sec";
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAcc.DecimalPlaces = 3;
            this.edtMoveAcc.Location = new System.Drawing.Point(129, 45);
            this.edtMoveAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(143, 21);
            this.edtMoveAcc.TabIndex = 38;
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(129, 17);
            this.edtMoveVel.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(143, 21);
            this.edtMoveVel.TabIndex = 37;
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "Move Acceleration  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "Move Velocity        :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // MoveSignalCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpSignalCaptureMove);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveSignalCapture";
            this.Text = "Move Signal Capture";
            this.Load += new System.EventHandler(this.MoveSignalCapture_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJogVel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSignalCaptureMove.ResumeLayout(false);
            this.grpSignalCaptureMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown edtJogDec;
        private System.Windows.Forms.NumericUpDown edtJogAcc;
        private System.Windows.Forms.NumericUpDown edtJogVel;
        private System.Windows.Forms.Button btnJogMoveN;
        private System.Windows.Forms.Button btnJogMoveP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
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
        private System.Windows.Forms.GroupBox grpSignalCaptureMove;
        private System.Windows.Forms.NumericUpDown edtMoveAcc;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMovetop;
        private System.Windows.Forms.Button btnCaptureMove;
        private System.Windows.Forms.ComboBox cboDetectSig;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboStopMethod;
        private System.Windows.Forms.ComboBox cboCaptureTarget;
        private System.Windows.Forms.ComboBox cboSignalEdge;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetPos;
        private System.Windows.Forms.TextBox edtCapturePos;
        private System.Windows.Forms.Timer tmDisplay;
    }
}

