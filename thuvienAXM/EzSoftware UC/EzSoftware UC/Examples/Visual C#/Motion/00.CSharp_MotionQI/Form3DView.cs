using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAMC_QI
{
    public partial class Form3DView : Form
    {
        private Button btnClose;
        private Button btnClear;
        private Button btnSplinePlay;
        private Button btnHelicalPlay;
        private Button btnSpline;
        private Button btnHelical;
        private GroupBox groupBox1;
        private TextBox textRangeZ;
        private TextBox textRangeY;
        private TextBox textRangeX;
        private Button btnSetRange;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label YCMD;
        private Label XCMD;
        private ComboBox cboDimension;
        private ComboBox cboAxisReset;
        private CheckBox chkBoxEnable;
        private Label Dimension;
        private Label lblCmdPosX;
        private Label lblCmdPosY;
        private Label lblCmdPosZ;
        public Timer timer1;
        private IContainer components;
        private Label labeResetAxis;
        private AxAXTGRAPH3DLib.AxAxtGraph3D AxtGraph3D;
    
        private int[] m_aAxis   = new int[4];
        public Form3DView()
        {
            InitializeComponent();
            timer1.Enabled = true;
            
            textRangeX.Text = String.Format("2500");
            textRangeY.Text = String.Format("2500");
            textRangeZ.Text = String.Format("2500");

            cboAxisReset.SelectedIndex = 3;
            cboDimension.SelectedIndex = 3;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double dCmdXPosition = 0.0, dCmdYPosition = 0.0, dCmdZPosition = 0.0;

            CAXM.AxmStatusGetCmdPos(m_aAxis[0], ref dCmdXPosition);
            CAXM.AxmStatusGetCmdPos(m_aAxis[1], ref dCmdYPosition);
            CAXM.AxmStatusGetCmdPos(m_aAxis[2], ref dCmdZPosition);

            float flCmdXPosition = (float)Convert.ChangeType(dCmdXPosition, typeof(float));
            float flCmdYPosition = (float)Convert.ChangeType(dCmdYPosition, typeof(float));
            float flCmdZPosition = (float)Convert.ChangeType(dCmdZPosition, typeof(float));

            lblCmdPosX.Text = String.Format("{0:0.000}", dCmdXPosition);
            lblCmdPosY.Text = String.Format("{0:0.000}", dCmdYPosition);
            lblCmdPosZ.Text = String.Format("{0:0.000}", dCmdZPosition);

            AxtGraph3D.AddPoint(flCmdXPosition, flCmdYPosition, flCmdZPosition);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3DView));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSplinePlay = new System.Windows.Forms.Button();
            this.btnHelicalPlay = new System.Windows.Forms.Button();
            this.btnSpline = new System.Windows.Forms.Button();
            this.btnHelical = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textRangeZ = new System.Windows.Forms.TextBox();
            this.textRangeY = new System.Windows.Forms.TextBox();
            this.textRangeX = new System.Windows.Forms.TextBox();
            this.btnSetRange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDimension = new System.Windows.Forms.ComboBox();
            this.cboAxisReset = new System.Windows.Forms.ComboBox();
            this.chkBoxEnable = new System.Windows.Forms.CheckBox();
            this.Dimension = new System.Windows.Forms.Label();
            this.labeResetAxis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.YCMD = new System.Windows.Forms.Label();
            this.XCMD = new System.Windows.Forms.Label();
            this.lblCmdPosX = new System.Windows.Forms.Label();
            this.lblCmdPosY = new System.Windows.Forms.Label();
            this.lblCmdPosZ = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AxtGraph3D = new AxAXTGRAPH3DLib.AxAxtGraph3D();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxtGraph3D)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(135, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 41);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(7, 394);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 41);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSplinePlay
            // 
            this.btnSplinePlay.Location = new System.Drawing.Point(135, 291);
            this.btnSplinePlay.Name = "btnSplinePlay";
            this.btnSplinePlay.Size = new System.Drawing.Size(117, 41);
            this.btnSplinePlay.TabIndex = 12;
            this.btnSplinePlay.Text = "Spline Play";
            this.btnSplinePlay.UseVisualStyleBackColor = true;
            this.btnSplinePlay.Click += new System.EventHandler(this.btnSplinePlay_Click);
            // 
            // btnHelicalPlay
            // 
            this.btnHelicalPlay.Location = new System.Drawing.Point(7, 291);
            this.btnHelicalPlay.Name = "btnHelicalPlay";
            this.btnHelicalPlay.Size = new System.Drawing.Size(117, 41);
            this.btnHelicalPlay.TabIndex = 11;
            this.btnHelicalPlay.Text = "Helical Play";
            this.btnHelicalPlay.UseVisualStyleBackColor = true;
            this.btnHelicalPlay.Click += new System.EventHandler(this.btnHelicalPlay_Click);
            // 
            // btnSpline
            // 
            this.btnSpline.Location = new System.Drawing.Point(135, 244);
            this.btnSpline.Name = "btnSpline";
            this.btnSpline.Size = new System.Drawing.Size(117, 41);
            this.btnSpline.TabIndex = 10;
            this.btnSpline.Text = "Spline";
            this.btnSpline.UseVisualStyleBackColor = true;
            this.btnSpline.Click += new System.EventHandler(this.btnSpline_Click);
            // 
            // btnHelical
            // 
            this.btnHelical.Location = new System.Drawing.Point(7, 244);
            this.btnHelical.Name = "btnHelical";
            this.btnHelical.Size = new System.Drawing.Size(117, 41);
            this.btnHelical.TabIndex = 9;
            this.btnHelical.Text = "Helical";
            this.btnHelical.UseVisualStyleBackColor = true;
            this.btnHelical.Click += new System.EventHandler(this.btnHelical_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRangeZ);
            this.groupBox1.Controls.Add(this.textRangeY);
            this.groupBox1.Controls.Add(this.textRangeX);
            this.groupBox1.Controls.Add(this.btnSetRange);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDimension);
            this.groupBox1.Controls.Add(this.cboAxisReset);
            this.groupBox1.Controls.Add(this.chkBoxEnable);
            this.groupBox1.Controls.Add(this.Dimension);
            this.groupBox1.Controls.Add(this.labeResetAxis);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 226);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph Properties";
            // 
            // textRangeZ
            // 
            this.textRangeZ.BackColor = System.Drawing.SystemColors.WindowText;
            this.textRangeZ.ForeColor = System.Drawing.Color.Goldenrod;
            this.textRangeZ.Location = new System.Drawing.Point(161, 154);
            this.textRangeZ.Name = "textRangeZ";
            this.textRangeZ.Size = new System.Drawing.Size(70, 21);
            this.textRangeZ.TabIndex = 40;
            // 
            // textRangeY
            // 
            this.textRangeY.BackColor = System.Drawing.SystemColors.WindowText;
            this.textRangeY.ForeColor = System.Drawing.Color.Goldenrod;
            this.textRangeY.Location = new System.Drawing.Point(87, 154);
            this.textRangeY.Name = "textRangeY";
            this.textRangeY.Size = new System.Drawing.Size(70, 21);
            this.textRangeY.TabIndex = 39;
            // 
            // textRangeX
            // 
            this.textRangeX.BackColor = System.Drawing.SystemColors.ControlText;
            this.textRangeX.ForeColor = System.Drawing.Color.Goldenrod;
            this.textRangeX.Location = new System.Drawing.Point(12, 154);
            this.textRangeX.Name = "textRangeX";
            this.textRangeX.Size = new System.Drawing.Size(70, 21);
            this.textRangeX.TabIndex = 38;
            // 
            // btnSetRange
            // 
            this.btnSetRange.Location = new System.Drawing.Point(12, 181);
            this.btnSetRange.Name = "btnSetRange";
            this.btnSetRange.Size = new System.Drawing.Size(220, 33);
            this.btnSetRange.TabIndex = 34;
            this.btnSetRange.Text = "Set Range";
            this.btnSetRange.UseVisualStyleBackColor = true;
            this.btnSetRange.Click += new System.EventHandler(this.btnSetRange_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(161, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "RangeZ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(87, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "RangeY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(13, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "RangeX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDimension
            // 
            this.cboDimension.FormattingEnabled = true;
            this.cboDimension.Items.AddRange(new object[] {
            "X - Y Dimension",
            "Y - Z Dimension",
            "X - Z Dimension",
            "X - Y - Z Dimension"});
            this.cboDimension.Location = new System.Drawing.Point(96, 67);
            this.cboDimension.Name = "cboDimension";
            this.cboDimension.Size = new System.Drawing.Size(135, 20);
            this.cboDimension.TabIndex = 20;
            this.cboDimension.Text = "cboDimension";
            this.cboDimension.SelectedIndexChanged += new System.EventHandler(this.cboDimension_SelectedIndexChanged);
            // 
            // cboAxisReset
            // 
            this.cboAxisReset.FormattingEnabled = true;
            this.cboAxisReset.Items.AddRange(new object[] {
            "X - Y Axis",
            "Y - Z Axis",
            "X - Z Axis",
            "X - Y - Z Axis"});
            this.cboAxisReset.Location = new System.Drawing.Point(96, 30);
            this.cboAxisReset.Name = "cboAxisReset";
            this.cboAxisReset.Size = new System.Drawing.Size(135, 20);
            this.cboAxisReset.TabIndex = 19;
            this.cboAxisReset.Text = "cboAxisReset";
            this.cboAxisReset.SelectedIndexChanged += new System.EventHandler(this.cboAxisReset_SelectedIndexChanged);
            // 
            // chkBoxEnable
            // 
            this.chkBoxEnable.AutoSize = true;
            this.chkBoxEnable.Checked = true;
            this.chkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxEnable.Location = new System.Drawing.Point(141, 102);
            this.chkBoxEnable.Name = "chkBoxEnable";
            this.chkBoxEnable.Size = new System.Drawing.Size(89, 16);
            this.chkBoxEnable.TabIndex = 6;
            this.chkBoxEnable.Text = "Box Enable";
            this.chkBoxEnable.UseVisualStyleBackColor = true;
            this.chkBoxEnable.CheckedChanged += new System.EventHandler(this.chkBoxEnable_CheckedChanged);
            // 
            // Dimension
            // 
            this.Dimension.BackColor = System.Drawing.Color.Transparent;
            this.Dimension.Location = new System.Drawing.Point(6, 64);
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(84, 24);
            this.Dimension.TabIndex = 5;
            this.Dimension.Text = "Dimension";
            this.Dimension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeResetAxis
            // 
            this.labeResetAxis.BackColor = System.Drawing.Color.Transparent;
            this.labeResetAxis.Location = new System.Drawing.Point(6, 30);
            this.labeResetAxis.Name = "labeResetAxis";
            this.labeResetAxis.Size = new System.Drawing.Size(84, 24);
            this.labeResetAxis.TabIndex = 4;
            this.labeResetAxis.Text = "Reset Axis";
            this.labeResetAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(271, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "CMD Z:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YCMD
            // 
            this.YCMD.BackColor = System.Drawing.Color.Black;
            this.YCMD.ForeColor = System.Drawing.Color.Yellow;
            this.YCMD.Location = new System.Drawing.Point(271, 47);
            this.YCMD.Name = "YCMD";
            this.YCMD.Size = new System.Drawing.Size(50, 17);
            this.YCMD.TabIndex = 26;
            this.YCMD.Text = "CMD Y:";
            this.YCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XCMD
            // 
            this.XCMD.BackColor = System.Drawing.Color.Black;
            this.XCMD.ForeColor = System.Drawing.Color.Yellow;
            this.XCMD.Location = new System.Drawing.Point(271, 22);
            this.XCMD.Name = "XCMD";
            this.XCMD.Size = new System.Drawing.Size(50, 17);
            this.XCMD.TabIndex = 25;
            this.XCMD.Text = "CMD X:";
            this.XCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCmdPosX
            // 
            this.lblCmdPosX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCmdPosX.BackColor = System.Drawing.Color.Black;
            this.lblCmdPosX.ForeColor = System.Drawing.Color.Lime;
            this.lblCmdPosX.Location = new System.Drawing.Point(324, 22);
            this.lblCmdPosX.Name = "lblCmdPosX";
            this.lblCmdPosX.Size = new System.Drawing.Size(80, 17);
            this.lblCmdPosX.TabIndex = 25;
            this.lblCmdPosX.Text = "0.000";
            this.lblCmdPosX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCmdPosY
            // 
            this.lblCmdPosY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCmdPosY.BackColor = System.Drawing.Color.Black;
            this.lblCmdPosY.ForeColor = System.Drawing.Color.Lime;
            this.lblCmdPosY.Location = new System.Drawing.Point(324, 47);
            this.lblCmdPosY.Name = "lblCmdPosY";
            this.lblCmdPosY.Size = new System.Drawing.Size(80, 17);
            this.lblCmdPosY.TabIndex = 26;
            this.lblCmdPosY.Text = "0.000";
            this.lblCmdPosY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCmdPosZ
            // 
            this.lblCmdPosZ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCmdPosZ.BackColor = System.Drawing.Color.Black;
            this.lblCmdPosZ.ForeColor = System.Drawing.Color.Lime;
            this.lblCmdPosZ.Location = new System.Drawing.Point(324, 72);
            this.lblCmdPosZ.Name = "lblCmdPosZ";
            this.lblCmdPosZ.Size = new System.Drawing.Size(80, 17);
            this.lblCmdPosZ.TabIndex = 27;
            this.lblCmdPosZ.Text = "0.000";
            this.lblCmdPosZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AxtGraph3D
            // 
            this.AxtGraph3D.Enabled = true;
            this.AxtGraph3D.Location = new System.Drawing.Point(260, 13);
            this.AxtGraph3D.Name = "AxtGraph3D";
            this.AxtGraph3D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxtGraph3D.OcxState")));
            this.AxtGraph3D.Size = new System.Drawing.Size(529, 421);
            this.AxtGraph3D.TabIndex = 28;
            // 
            // Form3DView
            // 
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.lblCmdPosZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCmdPosY);
            this.Controls.Add(this.lblCmdPosX);
            this.Controls.Add(this.YCMD);
            this.Controls.Add(this.XCMD);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSplinePlay);
            this.Controls.Add(this.btnHelicalPlay);
            this.Controls.Add(this.btnSpline);
            this.Controls.Add(this.btnHelical);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AxtGraph3D);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form3DView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.Form3DView_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3DView_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxtGraph3D)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnSetRange_Click(object sender, EventArgs e)
        {
            double dRangeX = Convert.ToDouble(textRangeX.Text);
            double dRangeY = Convert.ToDouble(textRangeY.Text);
            double dRangeZ = Convert.ToDouble(textRangeZ.Text);

            float flRangeX = (float)Convert.ChangeType(dRangeX, typeof(float));
            float flRangeY = (float)Convert.ChangeType(dRangeY, typeof(float));
            float flRangeZ = (float)Convert.ChangeType(dRangeZ, typeof(float));

            AxtGraph3D.SetRangeX = flRangeX;
            AxtGraph3D.SetRangeY = flRangeY;
            AxtGraph3D.SetRangeZ = flRangeZ;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int lCoordinate = 0;

            CAXM.AxmStatusSetActPos(0, 0.0);
            CAXM.AxmStatusSetActPos(1, 0.0);
            CAXM.AxmStatusSetActPos(2, 0.0);
            CAXM.AxmStatusSetActPos(3, 0.0);

            CAXM.AxmContiWriteClear(lCoordinate);

            AxtGraph3D.Clear();
            textRangeX.Text = String.Format("2500");
            textRangeY.Text = String.Format("2500");
            textRangeZ.Text = String.Format("2500");
        }

        private void chkBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEnable.Checked == true) AxtGraph3D.SetBoxEnable = true;
            else AxtGraph3D.SetBoxEnable = false;
        }

        private void cboDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((uint)cboDimension.SelectedIndex)
            {
                case 0:     // X,Y Dimension
                    AxtGraph3D.SetDimensionXY();
                    break;
                case 1:     // Y,Z Dimension
                    AxtGraph3D.SetDimensionYZ();
                    break;
                case 2:      // Y,Z Dimension
                    AxtGraph3D.SetDimensionXZ();
                    break;
                case 3:     // All Dimension
                    AxtGraph3D.SetDimensionXYZ();
                    break;
                default:
                    AxtGraph3D.SetDimensionXYZ();
                    break;
            }
 
        }

        private void cboAxisReset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((uint)cboAxisReset.SelectedIndex)
            {
                case 0:     // X,Y Axis Reset
                    AxtGraph3D.SetRangeX = 2500;
                    AxtGraph3D.SetRangeY = 2500;
                    break;
                case 1:     // Y,Z Axis Reset
                    AxtGraph3D.SetRangeX = 2500;
                    AxtGraph3D.SetRangeY = 2500;
                    break;
                case 2:      // Y,Z Axis Reset
                    AxtGraph3D.SetRangeX = 2500;
                    AxtGraph3D.SetRangeZ = 2500;
                    break;
                case 3:     // All Axis Reset
                    AxtGraph3D.SetRange3Axis(2500, 2500, 2500);
                    break;
                default:
                    AxtGraph3D.SetRange3Axis(2500, 2500, 2500);
                    break;
            }  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            this.Close();
        }

        private void btnSpline_Click(object sender, EventArgs e)
        {
            double dVelocity = 2000;
            double dAccel = 4000;
            int[] arrnAxis = new int[3];
            double[] dPosX = new double[5];
            double[] dPosY = new double[5];
            int lCoordinate = 0;

            for (int i = 0; i < 3; i++)
            {
                arrnAxis[i] = i;
            }

            CAXM.AxmContiWriteClear(lCoordinate);
            CAXM.AxmContiSetAxisMap(lCoordinate, 3, arrnAxis);
            CAXM.AxmContiSetAbsRelMode(lCoordinate, 0);

            dPosX[0] = 0; dPosY[0] = 0;
            dPosX[1] = 450; dPosY[1] = 100;
            dPosX[2] = 750; dPosY[2] = 450;
            dPosX[3] = 1080; dPosY[3] = 750;
            dPosX[4] = 1300; dPosY[4] = 700;

            CAXM.AxmContiBeginNode(lCoordinate);
            CAXM.AxmSplineWrite(lCoordinate, 5, dPosX, dPosY, dVelocity, dAccel, dAccel, 1, 100);
            CAXM.AxmContiEndNode(lCoordinate); 
        }

        private void btnHelical_Click(object sender, EventArgs e)
        {
            double dVelocity = 2000;
            double dAccel = 4000;
            int[] arrnAxis = new int[4];
            double[] dPos = new double[4];
            int lCoordinate = 0;

            for (int i = 0; i < 4; i++)
            {
                arrnAxis[i] = i;
            }

            CAXM.AxmContiWriteClear(lCoordinate);
            CAXM.AxmContiSetAxisMap(lCoordinate, 4, arrnAxis);
            CAXM.AxmContiSetAbsRelMode(lCoordinate, 4);

            CAXM.AxmContiBeginNode(lCoordinate);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmHelixCenterMove(lCoordinate, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, 1);
            CAXM.AxmContiEndNode(lCoordinate);
        }

        private void btnSplinePlay_Click(object sender, EventArgs e)
        {
            int lCoordinate = 0;

            CAXM.AxmContiSetAbsRelMode(lCoordinate, 0);
            CAXM.AxmContiStart(lCoordinate, 0, 0);
        }

        private void btnHelicalPlay_Click(object sender, EventArgs e)
        {
            int lCoordinate = 0;
            CAXM.AxmContiSetAbsRelMode(lCoordinate, 1);
            CAXM.AxmContiStart(lCoordinate, 0, 0);

            timer1.Enabled = true;
        }

        public void UpdateAxis(int nAxis)
        {
            m_aAxis[0] = CAXHS.AXIS_N04(nAxis, 0);
            m_aAxis[1] = CAXHS.AXIS_N04(nAxis, 1);
            m_aAxis[2] = CAXHS.AXIS_N04(nAxis, 2);
            m_aAxis[3] = CAXHS.AXIS_N04(nAxis, 3);
        }

        private void Form3DView_Load(object sender, EventArgs e)
        {
		    cboAxisReset.SelectedIndex = 3;
		    cboDimension.SelectedIndex = 3;
		    chkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            AxtGraph3D.SetRange3Axis(2500, 2500, 2500);
        }

        private void Form3DView_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}