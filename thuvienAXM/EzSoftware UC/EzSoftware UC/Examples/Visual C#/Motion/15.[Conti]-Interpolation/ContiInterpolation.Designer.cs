namespace ContiInterpolation
{
    partial class ContiInterpolation
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
            this.gprPositionMonitor = new System.Windows.Forms.GroupBox();
            this.chkServoOn = new System.Windows.Forms.CheckBox();
            this.btnPosClear = new System.Windows.Forms.Button();
            this.edtCmdVel03 = new System.Windows.Forms.TextBox();
            this.edtCmdVel02 = new System.Windows.Forms.TextBox();
            this.edtCmdVel01 = new System.Windows.Forms.TextBox();
            this.edtCmdVel00 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtActPos03 = new System.Windows.Forms.TextBox();
            this.edtActPos02 = new System.Windows.Forms.TextBox();
            this.edtActPos01 = new System.Windows.Forms.TextBox();
            this.edtActPos00 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtCmdPos03 = new System.Windows.Forms.TextBox();
            this.edtCmdPos02 = new System.Windows.Forms.TextBox();
            this.edtCmdPos01 = new System.Windows.Forms.TextBox();
            this.edtCmdPos00 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAxis03 = new System.Windows.Forms.CheckBox();
            this.chkAxis02 = new System.Windows.Forms.CheckBox();
            this.chkAxis01 = new System.Windows.Forms.CheckBox();
            this.chkAxis00 = new System.Windows.Forms.CheckBox();
            this.grpInterpolationMonitor = new System.Windows.Forms.GroupBox();
            this.chkIntpInMotion = new System.Windows.Forms.CheckBox();
            this.chkIntpQueueFree = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtIntpTotalNode = new System.Windows.Forms.TextBox();
            this.edtIntpExeNode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIntpClear = new System.Windows.Forms.Button();
            this.btnIntpStart = new System.Windows.Forms.Button();
            this.btnIntpSpline = new System.Windows.Forms.Button();
            this.btnIntpHelical = new System.Windows.Forms.Button();
            this.btnIntpLineArc = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnIntpCircle = new System.Windows.Forms.Button();
            this.btnIntpArc = new System.Windows.Forms.Button();
            this.btnIntpLine = new System.Windows.Forms.Button();
            this.btnIntpStop = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.edtMoveDec = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edtMoveAcc = new System.Windows.Forms.TextBox();
            this.edtMoveVel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.gprPositionMonitor.SuspendLayout();
            this.grpInterpolationMonitor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadFile);
            this.groupBox4.Controls.Add(this.cboSelAxis);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(8, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(464, 34);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(339, 10);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(118, 20);
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
            this.cboSelAxis.Size = new System.Drawing.Size(206, 20);
            this.cboSelAxis.TabIndex = 1;
            this.cboSelAxis.SelectedIndexChanged += new System.EventHandler(this.cboSelAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axis No       :";
            // 
            // tmDisplay
            // 
            this.tmDisplay.Enabled = true;
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // gprPositionMonitor
            // 
            this.gprPositionMonitor.Controls.Add(this.chkServoOn);
            this.gprPositionMonitor.Controls.Add(this.btnPosClear);
            this.gprPositionMonitor.Controls.Add(this.edtCmdVel03);
            this.gprPositionMonitor.Controls.Add(this.edtCmdVel02);
            this.gprPositionMonitor.Controls.Add(this.edtCmdVel01);
            this.gprPositionMonitor.Controls.Add(this.edtCmdVel00);
            this.gprPositionMonitor.Controls.Add(this.label4);
            this.gprPositionMonitor.Controls.Add(this.edtActPos03);
            this.gprPositionMonitor.Controls.Add(this.edtActPos02);
            this.gprPositionMonitor.Controls.Add(this.edtActPos01);
            this.gprPositionMonitor.Controls.Add(this.edtActPos00);
            this.gprPositionMonitor.Controls.Add(this.label3);
            this.gprPositionMonitor.Controls.Add(this.edtCmdPos03);
            this.gprPositionMonitor.Controls.Add(this.edtCmdPos02);
            this.gprPositionMonitor.Controls.Add(this.edtCmdPos01);
            this.gprPositionMonitor.Controls.Add(this.edtCmdPos00);
            this.gprPositionMonitor.Controls.Add(this.label2);
            this.gprPositionMonitor.Controls.Add(this.chkAxis03);
            this.gprPositionMonitor.Controls.Add(this.chkAxis02);
            this.gprPositionMonitor.Controls.Add(this.chkAxis01);
            this.gprPositionMonitor.Controls.Add(this.chkAxis00);
            this.gprPositionMonitor.Location = new System.Drawing.Point(8, 41);
            this.gprPositionMonitor.Name = "gprPositionMonitor";
            this.gprPositionMonitor.Size = new System.Drawing.Size(464, 118);
            this.gprPositionMonitor.TabIndex = 17;
            this.gprPositionMonitor.TabStop = false;
            this.gprPositionMonitor.Text = "Position Monitor";
            // 
            // chkServoOn
            // 
            this.chkServoOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkServoOn.Location = new System.Drawing.Point(387, 89);
            this.chkServoOn.Name = "chkServoOn";
            this.chkServoOn.Size = new System.Drawing.Size(68, 21);
            this.chkServoOn.TabIndex = 20;
            this.chkServoOn.Text = "Servo On";
            this.chkServoOn.UseVisualStyleBackColor = true;
            this.chkServoOn.Click += new System.EventHandler(this.chkServoOn_Click);
            // 
            // btnPosClear
            // 
            this.btnPosClear.Location = new System.Drawing.Point(387, 41);
            this.btnPosClear.Name = "btnPosClear";
            this.btnPosClear.Size = new System.Drawing.Size(68, 46);
            this.btnPosClear.TabIndex = 19;
            this.btnPosClear.Text = "Clear";
            this.btnPosClear.UseVisualStyleBackColor = true;
            this.btnPosClear.Click += new System.EventHandler(this.btnPosClear_Click);
            // 
            // edtCmdVel03
            // 
            this.edtCmdVel03.Location = new System.Drawing.Point(316, 89);
            this.edtCmdVel03.Name = "edtCmdVel03";
            this.edtCmdVel03.ReadOnly = true;
            this.edtCmdVel03.Size = new System.Drawing.Size(69, 21);
            this.edtCmdVel03.TabIndex = 18;
            this.edtCmdVel03.Text = "0.000";
            this.edtCmdVel03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdVel02
            // 
            this.edtCmdVel02.Location = new System.Drawing.Point(244, 89);
            this.edtCmdVel02.Name = "edtCmdVel02";
            this.edtCmdVel02.ReadOnly = true;
            this.edtCmdVel02.Size = new System.Drawing.Size(69, 21);
            this.edtCmdVel02.TabIndex = 17;
            this.edtCmdVel02.Text = "0.000";
            this.edtCmdVel02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdVel01
            // 
            this.edtCmdVel01.Location = new System.Drawing.Point(172, 89);
            this.edtCmdVel01.Name = "edtCmdVel01";
            this.edtCmdVel01.ReadOnly = true;
            this.edtCmdVel01.Size = new System.Drawing.Size(69, 21);
            this.edtCmdVel01.TabIndex = 16;
            this.edtCmdVel01.Text = "0.000";
            this.edtCmdVel01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdVel00
            // 
            this.edtCmdVel00.Location = new System.Drawing.Point(100, 89);
            this.edtCmdVel00.Name = "edtCmdVel00";
            this.edtCmdVel00.ReadOnly = true;
            this.edtCmdVel00.Size = new System.Drawing.Size(69, 21);
            this.edtCmdVel00.TabIndex = 15;
            this.edtCmdVel00.Text = "0.000";
            this.edtCmdVel00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Command Vel :";
            // 
            // edtActPos03
            // 
            this.edtActPos03.Location = new System.Drawing.Point(316, 65);
            this.edtActPos03.Name = "edtActPos03";
            this.edtActPos03.ReadOnly = true;
            this.edtActPos03.Size = new System.Drawing.Size(69, 21);
            this.edtActPos03.TabIndex = 13;
            this.edtActPos03.Text = "0.000";
            this.edtActPos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos02
            // 
            this.edtActPos02.Location = new System.Drawing.Point(244, 65);
            this.edtActPos02.Name = "edtActPos02";
            this.edtActPos02.ReadOnly = true;
            this.edtActPos02.Size = new System.Drawing.Size(69, 21);
            this.edtActPos02.TabIndex = 12;
            this.edtActPos02.Text = "0.000";
            this.edtActPos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos01
            // 
            this.edtActPos01.Location = new System.Drawing.Point(172, 65);
            this.edtActPos01.Name = "edtActPos01";
            this.edtActPos01.ReadOnly = true;
            this.edtActPos01.Size = new System.Drawing.Size(69, 21);
            this.edtActPos01.TabIndex = 11;
            this.edtActPos01.Text = "0.000";
            this.edtActPos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtActPos00
            // 
            this.edtActPos00.Location = new System.Drawing.Point(100, 65);
            this.edtActPos00.Name = "edtActPos00";
            this.edtActPos00.ReadOnly = true;
            this.edtActPos00.Size = new System.Drawing.Size(69, 21);
            this.edtActPos00.TabIndex = 10;
            this.edtActPos00.Text = "0.000";
            this.edtActPos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Feedback Pos :";
            // 
            // edtCmdPos03
            // 
            this.edtCmdPos03.Location = new System.Drawing.Point(316, 41);
            this.edtCmdPos03.Name = "edtCmdPos03";
            this.edtCmdPos03.ReadOnly = true;
            this.edtCmdPos03.Size = new System.Drawing.Size(69, 21);
            this.edtCmdPos03.TabIndex = 8;
            this.edtCmdPos03.Text = "0.000";
            this.edtCmdPos03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos02
            // 
            this.edtCmdPos02.Location = new System.Drawing.Point(244, 41);
            this.edtCmdPos02.Name = "edtCmdPos02";
            this.edtCmdPos02.ReadOnly = true;
            this.edtCmdPos02.Size = new System.Drawing.Size(69, 21);
            this.edtCmdPos02.TabIndex = 7;
            this.edtCmdPos02.Text = "0.000";
            this.edtCmdPos02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos01
            // 
            this.edtCmdPos01.Location = new System.Drawing.Point(172, 41);
            this.edtCmdPos01.Name = "edtCmdPos01";
            this.edtCmdPos01.ReadOnly = true;
            this.edtCmdPos01.Size = new System.Drawing.Size(69, 21);
            this.edtCmdPos01.TabIndex = 6;
            this.edtCmdPos01.Text = "0.000";
            this.edtCmdPos01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtCmdPos00
            // 
            this.edtCmdPos00.Location = new System.Drawing.Point(100, 41);
            this.edtCmdPos00.Name = "edtCmdPos00";
            this.edtCmdPos00.ReadOnly = true;
            this.edtCmdPos00.Size = new System.Drawing.Size(69, 21);
            this.edtCmdPos00.TabIndex = 5;
            this.edtCmdPos00.Text = "0.000";
            this.edtCmdPos00.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Command Pos:";
            // 
            // chkAxis03
            // 
            this.chkAxis03.AutoSize = true;
            this.chkAxis03.Location = new System.Drawing.Point(317, 19);
            this.chkAxis03.Name = "chkAxis03";
            this.chkAxis03.Size = new System.Drawing.Size(61, 16);
            this.chkAxis03.TabIndex = 3;
            this.chkAxis03.Text = "Axis03";
            this.chkAxis03.UseVisualStyleBackColor = true;
            this.chkAxis03.Click += new System.EventHandler(this.chkAxis_Click);
            // 
            // chkAxis02
            // 
            this.chkAxis02.AutoSize = true;
            this.chkAxis02.Location = new System.Drawing.Point(246, 19);
            this.chkAxis02.Name = "chkAxis02";
            this.chkAxis02.Size = new System.Drawing.Size(61, 16);
            this.chkAxis02.TabIndex = 2;
            this.chkAxis02.Text = "Axis02";
            this.chkAxis02.UseVisualStyleBackColor = true;
            this.chkAxis02.Click += new System.EventHandler(this.chkAxis_Click);
            // 
            // chkAxis01
            // 
            this.chkAxis01.AutoSize = true;
            this.chkAxis01.Location = new System.Drawing.Point(173, 19);
            this.chkAxis01.Name = "chkAxis01";
            this.chkAxis01.Size = new System.Drawing.Size(61, 16);
            this.chkAxis01.TabIndex = 1;
            this.chkAxis01.Text = "Axis01";
            this.chkAxis01.UseVisualStyleBackColor = true;
            this.chkAxis01.Click += new System.EventHandler(this.chkAxis_Click);
            // 
            // chkAxis00
            // 
            this.chkAxis00.AutoSize = true;
            this.chkAxis00.Location = new System.Drawing.Point(101, 19);
            this.chkAxis00.Name = "chkAxis00";
            this.chkAxis00.Size = new System.Drawing.Size(65, 16);
            this.chkAxis00.TabIndex = 0;
            this.chkAxis00.Text = "Axis 00";
            this.chkAxis00.UseVisualStyleBackColor = true;
            this.chkAxis00.Click += new System.EventHandler(this.chkAxis_Click);
            // 
            // grpInterpolationMonitor
            // 
            this.grpInterpolationMonitor.Controls.Add(this.chkIntpInMotion);
            this.grpInterpolationMonitor.Controls.Add(this.chkIntpQueueFree);
            this.grpInterpolationMonitor.Controls.Add(this.label7);
            this.grpInterpolationMonitor.Controls.Add(this.label8);
            this.grpInterpolationMonitor.Controls.Add(this.groupBox2);
            this.grpInterpolationMonitor.Controls.Add(this.edtIntpTotalNode);
            this.grpInterpolationMonitor.Controls.Add(this.edtIntpExeNode);
            this.grpInterpolationMonitor.Controls.Add(this.label5);
            this.grpInterpolationMonitor.Controls.Add(this.label6);
            this.grpInterpolationMonitor.Location = new System.Drawing.Point(8, 167);
            this.grpInterpolationMonitor.Name = "grpInterpolationMonitor";
            this.grpInterpolationMonitor.Size = new System.Drawing.Size(464, 70);
            this.grpInterpolationMonitor.TabIndex = 18;
            this.grpInterpolationMonitor.TabStop = false;
            this.grpInterpolationMonitor.Text = "< Interpolation Monitor >";
            // 
            // chkIntpInMotion
            // 
            this.chkIntpInMotion.AutoSize = true;
            this.chkIntpInMotion.Enabled = false;
            this.chkIntpInMotion.Location = new System.Drawing.Point(388, 43);
            this.chkIntpInMotion.Name = "chkIntpInMotion";
            this.chkIntpInMotion.Size = new System.Drawing.Size(15, 14);
            this.chkIntpInMotion.TabIndex = 27;
            this.chkIntpInMotion.UseVisualStyleBackColor = true;
            // 
            // chkIntpQueueFree
            // 
            this.chkIntpQueueFree.AutoSize = true;
            this.chkIntpQueueFree.Enabled = false;
            this.chkIntpQueueFree.Location = new System.Drawing.Point(388, 21);
            this.chkIntpQueueFree.Name = "chkIntpQueueFree";
            this.chkIntpQueueFree.Size = new System.Drawing.Size(15, 14);
            this.chkIntpQueueFree.TabIndex = 26;
            this.chkIntpQueueFree.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "In Interpolation Move :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Interpolation Q Free  :";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(251, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(5, 51);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // edtIntpTotalNode
            // 
            this.edtIntpTotalNode.Location = new System.Drawing.Point(174, 41);
            this.edtIntpTotalNode.Name = "edtIntpTotalNode";
            this.edtIntpTotalNode.ReadOnly = true;
            this.edtIntpTotalNode.Size = new System.Drawing.Size(71, 21);
            this.edtIntpTotalNode.TabIndex = 22;
            this.edtIntpTotalNode.Text = "0";
            this.edtIntpTotalNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edtIntpExeNode
            // 
            this.edtIntpExeNode.Location = new System.Drawing.Point(174, 17);
            this.edtIntpExeNode.Name = "edtIntpExeNode";
            this.edtIntpExeNode.ReadOnly = true;
            this.edtIntpExeNode.Size = new System.Drawing.Size(71, 21);
            this.edtIntpExeNode.TabIndex = 21;
            this.edtIntpExeNode.Text = "0";
            this.edtIntpExeNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Interpolation Total Node      :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "Interpolation Execute Node :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnIntpClear);
            this.groupBox3.Controls.Add(this.btnIntpStart);
            this.groupBox3.Controls.Add(this.btnIntpSpline);
            this.groupBox3.Controls.Add(this.btnIntpHelical);
            this.groupBox3.Controls.Add(this.btnIntpLineArc);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.btnIntpCircle);
            this.groupBox3.Controls.Add(this.btnIntpArc);
            this.groupBox3.Controls.Add(this.btnIntpLine);
            this.groupBox3.Controls.Add(this.btnIntpStop);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.edtMoveDec);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.edtMoveAcc);
            this.groupBox3.Controls.Add(this.edtMoveVel);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(8, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 252);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "< Interpolation Move >";
            // 
            // btnIntpClear
            // 
            this.btnIntpClear.Location = new System.Drawing.Point(387, 202);
            this.btnIntpClear.Name = "btnIntpClear";
            this.btnIntpClear.Size = new System.Drawing.Size(68, 41);
            this.btnIntpClear.TabIndex = 35;
            this.btnIntpClear.Text = "Clear";
            this.btnIntpClear.UseVisualStyleBackColor = true;
            this.btnIntpClear.Click += new System.EventHandler(this.btnIntpClear_Click);
            // 
            // btnIntpStart
            // 
            this.btnIntpStart.Location = new System.Drawing.Point(387, 158);
            this.btnIntpStart.Name = "btnIntpStart";
            this.btnIntpStart.Size = new System.Drawing.Size(68, 41);
            this.btnIntpStart.TabIndex = 21;
            this.btnIntpStart.Text = "Start";
            this.btnIntpStart.UseVisualStyleBackColor = true;
            this.btnIntpStart.Click += new System.EventHandler(this.btnIntpStart_Click);
            // 
            // btnIntpSpline
            // 
            this.btnIntpSpline.Location = new System.Drawing.Point(257, 158);
            this.btnIntpSpline.Name = "btnIntpSpline";
            this.btnIntpSpline.Size = new System.Drawing.Size(121, 85);
            this.btnIntpSpline.TabIndex = 34;
            this.btnIntpSpline.Text = "Spline";
            this.btnIntpSpline.UseVisualStyleBackColor = true;
            this.btnIntpSpline.Click += new System.EventHandler(this.btnIntpSpline_Click);
            // 
            // btnIntpHelical
            // 
            this.btnIntpHelical.Location = new System.Drawing.Point(133, 158);
            this.btnIntpHelical.Name = "btnIntpHelical";
            this.btnIntpHelical.Size = new System.Drawing.Size(121, 85);
            this.btnIntpHelical.TabIndex = 33;
            this.btnIntpHelical.Text = "Helical";
            this.btnIntpHelical.UseVisualStyleBackColor = true;
            this.btnIntpHelical.Click += new System.EventHandler(this.btnIntpHelical_Click);
            // 
            // btnIntpLineArc
            // 
            this.btnIntpLineArc.Location = new System.Drawing.Point(9, 158);
            this.btnIntpLineArc.Name = "btnIntpLineArc";
            this.btnIntpLineArc.Size = new System.Drawing.Size(121, 85);
            this.btnIntpLineArc.TabIndex = 32;
            this.btnIntpLineArc.Text = "Line && Arc";
            this.btnIntpLineArc.UseVisualStyleBackColor = true;
            this.btnIntpLineArc.Click += new System.EventHandler(this.btnIntpLineArc_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(10, 144);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(369, 10);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            // 
            // btnIntpCircle
            // 
            this.btnIntpCircle.Location = new System.Drawing.Point(257, 106);
            this.btnIntpCircle.Name = "btnIntpCircle";
            this.btnIntpCircle.Size = new System.Drawing.Size(121, 37);
            this.btnIntpCircle.TabIndex = 31;
            this.btnIntpCircle.Text = "Circle(Angle)";
            this.btnIntpCircle.UseVisualStyleBackColor = true;
            this.btnIntpCircle.Click += new System.EventHandler(this.btnIntpCircle_Click);
            // 
            // btnIntpArc
            // 
            this.btnIntpArc.Location = new System.Drawing.Point(133, 106);
            this.btnIntpArc.Name = "btnIntpArc";
            this.btnIntpArc.Size = new System.Drawing.Size(121, 37);
            this.btnIntpArc.TabIndex = 30;
            this.btnIntpArc.Text = "Arc(Radius)";
            this.btnIntpArc.UseVisualStyleBackColor = true;
            this.btnIntpArc.Click += new System.EventHandler(this.btnIntpArc_Click);
            // 
            // btnIntpLine
            // 
            this.btnIntpLine.Location = new System.Drawing.Point(9, 106);
            this.btnIntpLine.Name = "btnIntpLine";
            this.btnIntpLine.Size = new System.Drawing.Size(121, 37);
            this.btnIntpLine.TabIndex = 29;
            this.btnIntpLine.Text = "Line";
            this.btnIntpLine.UseVisualStyleBackColor = true;
            this.btnIntpLine.Click += new System.EventHandler(this.btnIntpLine_Click);
            // 
            // btnIntpStop
            // 
            this.btnIntpStop.Location = new System.Drawing.Point(387, 17);
            this.btnIntpStop.Name = "btnIntpStop";
            this.btnIntpStop.Size = new System.Drawing.Size(68, 126);
            this.btnIntpStop.TabIndex = 21;
            this.btnIntpStop.Text = "Stop";
            this.btnIntpStop.UseVisualStyleBackColor = true;
            this.btnIntpStop.Click += new System.EventHandler(this.btnIntpStop_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(317, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 12);
            this.label20.TabIndex = 28;
            this.label20.Text = "Unit/Sec^2";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(10, 91);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(369, 10);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(317, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 27;
            this.label18.Text = "Unit/Sec^2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(317, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 12);
            this.label16.TabIndex = 26;
            this.label16.Text = "Unit/Sec";
            // 
            // edtMoveDec
            // 
            this.edtMoveDec.Location = new System.Drawing.Point(174, 68);
            this.edtMoveDec.Name = "edtMoveDec";
            this.edtMoveDec.Size = new System.Drawing.Size(139, 21);
            this.edtMoveDec.TabIndex = 25;
            this.edtMoveDec.Text = "0";
            this.edtMoveDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "Interpolation Deceleration    :";
            // 
            // edtMoveAcc
            // 
            this.edtMoveAcc.Location = new System.Drawing.Point(174, 42);
            this.edtMoveAcc.Name = "edtMoveAcc";
            this.edtMoveAcc.Size = new System.Drawing.Size(139, 21);
            this.edtMoveAcc.TabIndex = 22;
            this.edtMoveAcc.Text = "0";
            this.edtMoveAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMoveVel
            // 
            this.edtMoveVel.Location = new System.Drawing.Point(174, 17);
            this.edtMoveVel.Name = "edtMoveVel";
            this.edtMoveVel.Size = new System.Drawing.Size(139, 21);
            this.edtMoveVel.TabIndex = 21;
            this.edtMoveVel.Text = "0";
            this.edtMoveVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "Interpolation Acceleration    :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "Interpolation Velocity          :";
            // 
            // ContiInterpolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpInterpolationMonitor);
            this.Controls.Add(this.gprPositionMonitor);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContiInterpolation";
            this.Text = "ContiInterpolation";
            this.Load += new System.EventHandler(this.ContiInterpolation_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContiInterpolation_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gprPositionMonitor.ResumeLayout(false);
            this.gprPositionMonitor.PerformLayout();
            this.grpInterpolationMonitor.ResumeLayout(false);
            this.grpInterpolationMonitor.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox cboSelAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.GroupBox gprPositionMonitor;
        private System.Windows.Forms.CheckBox chkServoOn;
        private System.Windows.Forms.Button btnPosClear;
        private System.Windows.Forms.TextBox edtCmdVel03;
        private System.Windows.Forms.TextBox edtCmdVel02;
        private System.Windows.Forms.TextBox edtCmdVel01;
        private System.Windows.Forms.TextBox edtCmdVel00;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtActPos03;
        private System.Windows.Forms.TextBox edtActPos02;
        private System.Windows.Forms.TextBox edtActPos01;
        private System.Windows.Forms.TextBox edtActPos00;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtCmdPos03;
        private System.Windows.Forms.TextBox edtCmdPos02;
        private System.Windows.Forms.TextBox edtCmdPos01;
        private System.Windows.Forms.TextBox edtCmdPos00;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAxis03;
        private System.Windows.Forms.CheckBox chkAxis02;
        private System.Windows.Forms.CheckBox chkAxis01;
        private System.Windows.Forms.CheckBox chkAxis00;
        private System.Windows.Forms.GroupBox grpInterpolationMonitor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtIntpTotalNode;
        private System.Windows.Forms.TextBox edtIntpExeNode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIntpInMotion;
        private System.Windows.Forms.CheckBox chkIntpQueueFree;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox edtMoveAcc;
        private System.Windows.Forms.TextBox edtMoveVel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnIntpStop;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox edtMoveDec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnIntpSpline;
        private System.Windows.Forms.Button btnIntpHelical;
        private System.Windows.Forms.Button btnIntpLineArc;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnIntpCircle;
        private System.Windows.Forms.Button btnIntpArc;
        private System.Windows.Forms.Button btnIntpLine;
        private System.Windows.Forms.Button btnIntpClear;
        private System.Windows.Forms.Button btnIntpStart;
    }
}

