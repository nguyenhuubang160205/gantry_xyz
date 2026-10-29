namespace OverridePosition
{
    partial class OverridePosition
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtMoveDec = new System.Windows.Forms.NumericUpDown();
            this.edtMoveAcc = new System.Windows.Forms.NumericUpDown();
            this.edtMoveVel = new System.Windows.Forms.NumericUpDown();
            this.edtMovePos = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rdoRel = new System.Windows.Forms.RadioButton();
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.grpPositionOverride = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOverride2 = new System.Windows.Forms.Button();
            this.btmOverride28 = new System.Windows.Forms.PictureBox();
            this.btnOverride1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.edtOverrideDis2 = new System.Windows.Forms.NumericUpDown();
            this.edtOverrideDis1 = new System.Windows.Forms.NumericUpDown();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).BeginInit();
            this.grpPositionOverride.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmOverride28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDis1)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(8, 14);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Monitor";
            // 
            // edtSetPos
            // 
            this.edtSetPos.Location = new System.Drawing.Point(343, 15);
            this.edtSetPos.Name = "edtSetPos";
            this.edtSetPos.Size = new System.Drawing.Size(110, 21);
            this.edtSetPos.TabIndex = 14;
            this.edtSetPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.edtCmdVel.Location = new System.Drawing.Point(129, 61);
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
            this.edtActPos.Location = new System.Drawing.Point(129, 38);
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
            this.edtCmdPos.Location = new System.Drawing.Point(129, 15);
            this.edtCmdPos.Name = "edtCmdPos";
            this.edtCmdPos.ReadOnly = true;
            this.edtCmdPos.Size = new System.Drawing.Size(143, 21);
            this.edtCmdPos.TabIndex = 10;
            this.edtCmdPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPosSet
            // 
            this.btnPosSet.Location = new System.Drawing.Point(343, 38);
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
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Command Velocity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Feedback Position  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Command Position :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtMoveDec);
            this.groupBox2.Controls.Add(this.edtMoveAcc);
            this.groupBox2.Controls.Add(this.edtMoveVel);
            this.groupBox2.Controls.Add(this.edtMovePos);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnMove1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rdoRel);
            this.groupBox2.Controls.Add(this.rdoAbs);
            this.groupBox2.Location = new System.Drawing.Point(8, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 141);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position Move";
            // 
            // edtMoveDec
            // 
            this.edtMoveDec.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveDec.DecimalPlaces = 3;
            this.edtMoveDec.Location = new System.Drawing.Point(129, 109);
            this.edtMoveDec.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveDec.Name = "edtMoveDec";
            this.edtMoveDec.Size = new System.Drawing.Size(143, 21);
            this.edtMoveDec.TabIndex = 26;
            this.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveAcc.DecimalPlaces = 3;
            this.edtMoveAcc.Location = new System.Drawing.Point(129, 84);
            this.edtMoveAcc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(143, 21);
            this.edtMoveAcc.TabIndex = 25;
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.BackColor = System.Drawing.SystemColors.Window;
            this.edtMoveVel.DecimalPlaces = 3;
            this.edtMoveVel.Location = new System.Drawing.Point(129, 59);
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
            this.edtMovePos.Location = new System.Drawing.Point(129, 34);
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
            this.btnStop.Location = new System.Drawing.Point(343, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 69);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Move Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnSStop_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(273, 114);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 12);
            this.label20.TabIndex = 20;
            this.label20.Text = "Unit/Sec^2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 113);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(118, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "Move Deceleration :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(273, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 17;
            this.label18.Text = "Unit/Sec^2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 12);
            this.label19.TabIndex = 15;
            this.label19.Text = "Move Acceleration :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(273, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "Unit/Sec";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Move Velocity       :";
            // 
            // btnMove1
            // 
            this.btnMove1.Location = new System.Drawing.Point(343, 34);
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
            this.label14.Location = new System.Drawing.Point(273, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "Unit";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Move Target Pos   :";
            // 
            // rdoRel
            // 
            this.rdoRel.AutoSize = true;
            this.rdoRel.Location = new System.Drawing.Point(239, 16);
            this.rdoRel.Name = "rdoRel";
            this.rdoRel.Size = new System.Drawing.Size(95, 16);
            this.rdoRel.TabIndex = 1;
            this.rdoRel.Text = "[01] Relative";
            this.rdoRel.UseVisualStyleBackColor = true;
            this.rdoRel.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // rdoAbs
            // 
            this.rdoAbs.AutoSize = true;
            this.rdoAbs.Checked = true;
            this.rdoAbs.Location = new System.Drawing.Point(131, 16);
            this.rdoAbs.Name = "rdoAbs";
            this.rdoAbs.Size = new System.Drawing.Size(100, 16);
            this.rdoAbs.TabIndex = 0;
            this.rdoAbs.TabStop = true;
            this.rdoAbs.Text = "[00] Absolute";
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.Click += new System.EventHandler(this.rdoAbsRel_Click);
            // 
            // grpPositionOverride
            // 
            this.grpPositionOverride.Controls.Add(this.groupBox3);
            this.grpPositionOverride.Controls.Add(this.btnOverride2);
            this.grpPositionOverride.Controls.Add(this.btmOverride28);
            this.grpPositionOverride.Controls.Add(this.btnOverride1);
            this.grpPositionOverride.Controls.Add(this.label11);
            this.grpPositionOverride.Controls.Add(this.label6);
            this.grpPositionOverride.Controls.Add(this.label7);
            this.grpPositionOverride.Controls.Add(this.label5);
            this.grpPositionOverride.Controls.Add(this.edtOverrideDis2);
            this.grpPositionOverride.Controls.Add(this.edtOverrideDis1);
            this.grpPositionOverride.Location = new System.Drawing.Point(8, 290);
            this.grpPositionOverride.Name = "grpPositionOverride";
            this.grpPositionOverride.Size = new System.Drawing.Size(461, 204);
            this.grpPositionOverride.TabIndex = 13;
            this.grpPositionOverride.TabStop = false;
            this.grpPositionOverride.Text = "< Position Override >";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(13, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 10);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // btnOverride2
            // 
            this.btnOverride2.Location = new System.Drawing.Point(341, 172);
            this.btnOverride2.Name = "btnOverride2";
            this.btnOverride2.Size = new System.Drawing.Size(110, 21);
            this.btnOverride2.TabIndex = 40;
            this.btnOverride2.Text = "Override Pos 2";
            this.btnOverride2.UseVisualStyleBackColor = true;
            this.btnOverride2.Click += new System.EventHandler(this.btnOverride2_Click);
            // 
            // btmOverride28
            // 
            this.btmOverride28.Image = global::OverridePosition.Properties.Resources.PosOverrideAbs;
            this.btmOverride28.Location = new System.Drawing.Point(13, 16);
            this.btmOverride28.Name = "btmOverride28";
            this.btmOverride28.Size = new System.Drawing.Size(438, 113);
            this.btmOverride28.TabIndex = 0;
            this.btmOverride28.TabStop = false;
            // 
            // btnOverride1
            // 
            this.btnOverride1.Location = new System.Drawing.Point(341, 148);
            this.btnOverride1.Name = "btnOverride1";
            this.btnOverride1.Size = new System.Drawing.Size(110, 21);
            this.btnOverride1.TabIndex = 34;
            this.btnOverride1.Text = "Override Pos 1";
            this.btnOverride1.UseVisualStyleBackColor = true;
            this.btnOverride1.Click += new System.EventHandler(this.btnOverride1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 12);
            this.label11.TabIndex = 39;
            this.label11.Text = "Unit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "Override Distance 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "Override Distance 2:";
            // 
            // edtOverrideDis2
            // 
            this.edtOverrideDis2.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideDis2.DecimalPlaces = 3;
            this.edtOverrideDis2.Location = new System.Drawing.Point(129, 172);
            this.edtOverrideDis2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideDis2.Name = "edtOverrideDis2";
            this.edtOverrideDis2.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideDis2.TabIndex = 38;
            this.edtOverrideDis2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtOverrideDis1
            // 
            this.edtOverrideDis1.BackColor = System.Drawing.SystemColors.Window;
            this.edtOverrideDis1.DecimalPlaces = 3;
            this.edtOverrideDis1.Location = new System.Drawing.Point(129, 148);
            this.edtOverrideDis1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.edtOverrideDis1.Name = "edtOverrideDis1";
            this.edtOverrideDis1.Size = new System.Drawing.Size(143, 21);
            this.edtOverrideDis1.TabIndex = 37;
            this.edtOverrideDis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // OverridePosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.grpPositionOverride);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverridePosition";
            this.Text = "Override Position";
            this.Load += new System.EventHandler(this.OverridePosition_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMovePos)).EndInit();
            this.grpPositionOverride.ResumeLayout(false);
            this.grpPositionOverride.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmOverride28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOverrideDis1)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown edtMoveVel;
        private System.Windows.Forms.NumericUpDown edtMovePos;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoRel;
        private System.Windows.Forms.RadioButton rdoAbs;
        private System.Windows.Forms.TextBox edtSetPos;
        private System.Windows.Forms.GroupBox grpPositionOverride;
        private System.Windows.Forms.PictureBox btmOverride28;
        private System.Windows.Forms.NumericUpDown edtMoveDec;
        private System.Windows.Forms.NumericUpDown edtMoveAcc;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.Button btnOverride2;
        private System.Windows.Forms.Button btnOverride1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown edtOverrideDis2;
        private System.Windows.Forms.NumericUpDown edtOverrideDis1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

