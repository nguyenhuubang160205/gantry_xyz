using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CAMC_QI
{
	/// <summary>
	/// FormStatusView에 대한 요약 설명입니다.
	/// </summary>
	public class FormStatusView : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label labelLedXEndStatus7;
		private System.Windows.Forms.Label labelLedXEndStatus6;
		private System.Windows.Forms.Label labelLedXEndStatus5;
		private System.Windows.Forms.Label labelLedXEndStatus4;
		private System.Windows.Forms.Label labelLedXEndStatus0;
		private System.Windows.Forms.Label labelLedXEndStatus1;
		private System.Windows.Forms.Label labelLedXEndStatus2;
		private System.Windows.Forms.Label labelLedXEndStatus3;
		private System.Windows.Forms.Label labelLedXDriveStatus0;
		private System.Windows.Forms.Label labelLedXDriveStatus1;
		private System.Windows.Forms.Label labelLedXDriveStatus2;
		private System.Windows.Forms.Label labelLedXDriveStatus3;
		private System.Windows.Forms.Label labelLedXDriveStatus4;
		private System.Windows.Forms.Label labelLedXDriveStatus5;
		private System.Windows.Forms.Label labelLedXDriveStatus6;
		private System.Windows.Forms.Label labelLedXDriveStatus7;
		private System.Windows.Forms.Label labelLedYDriveStatus0;
		private System.Windows.Forms.Label labelLedYDriveStatus1;
		private System.Windows.Forms.Label labelLedYDriveStatus2;
		private System.Windows.Forms.Label labelLedYDriveStatus3;
		private System.Windows.Forms.Label labelLedYDriveStatus4;
		private System.Windows.Forms.Label labelLedYDriveStatus5;
		private System.Windows.Forms.Label labelLedYDriveStatus6;
		private System.Windows.Forms.Label labelLedYDriveStatus7;
		private System.Windows.Forms.Label labelLedYEndStatus0;
		private System.Windows.Forms.Label labelLedYEndStatus1;
		private System.Windows.Forms.Label labelLedYEndStatus2;
		private System.Windows.Forms.Label labelLedYEndStatus3;
		private System.Windows.Forms.Label labelLedYEndStatus4;
		private System.Windows.Forms.Label labelLedYEndStatus5;
		private System.Windows.Forms.Label labelLedYEndStatus6;
		private System.Windows.Forms.Label labelLedYEndStatus7;
		private System.Windows.Forms.TextBox textStatusViewAxisX;
		private System.Windows.Forms.TextBox textStatusViewAxisY;
		private System.Timers.Timer timerUpdateStatus;
		private System.Windows.Forms.Label labelLedXDriveStatus9;
		private System.Windows.Forms.Label labelLedXDriveStatus10;
		private System.Windows.Forms.Label labelLedXEndStatus16;
		private System.Windows.Forms.Label labelLedXEndStatus30;
		private System.Windows.Forms.Label labelLedXEndStatus31;
		private System.Windows.Forms.Label labelLedXEndStatus8;
		private System.Windows.Forms.Label labelLedXEndStatus9;
		private System.Windows.Forms.Label labelLedXEndStatus10;
		private System.Windows.Forms.Label labelLedXEndStatus11;
		private System.Windows.Forms.Label labelLedXEndStatus12;
		private System.Windows.Forms.Label labelLedXEndStatus13;
		private System.Windows.Forms.Label labelLedXEndStatus14;
		private System.Windows.Forms.Label labelLedXEndStatus15;
		private System.Windows.Forms.Label labelLedYDriveStatus9;
		private System.Windows.Forms.Label labelLedYDriveStatus10;
		private System.Windows.Forms.Label labelLedYEndStatus16;
		private System.Windows.Forms.Label labelLedYEndStatus30;
		private System.Windows.Forms.Label labelLedYEndStatus31;
		private System.Windows.Forms.Label labelLedYEndStatus8;
		private System.Windows.Forms.Label labelLedYEndStatus9;
		private System.Windows.Forms.Label labelLedYEndStatus10;
		private System.Windows.Forms.Label labelLedYEndStatus11;
		private System.Windows.Forms.Label labelLedYEndStatus12;
		private System.Windows.Forms.Label labelLedYEndStatus13;
		private System.Windows.Forms.Label labelLedYEndStatus14;
		private System.Windows.Forms.Label labelLedYEndStatus15;
		private System.Windows.Forms.Button View;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormStatusView()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textStatusViewAxisX = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labelLedXDriveStatus9 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus10 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus0 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus1 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus2 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus3 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus4 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus5 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus6 = new System.Windows.Forms.Label();
			this.labelLedXDriveStatus7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labelLedXEndStatus16 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus30 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus31 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus8 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus9 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus10 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus11 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus12 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus13 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus14 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus15 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus0 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus1 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus2 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus3 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus4 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus5 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus6 = new System.Windows.Forms.Label();
			this.labelLedXEndStatus7 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textStatusViewAxisY = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.labelLedYDriveStatus9 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus10 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus0 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus1 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus2 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus3 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus4 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus5 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus6 = new System.Windows.Forms.Label();
			this.labelLedYDriveStatus7 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.labelLedYEndStatus16 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus30 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus31 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus8 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus9 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus10 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus11 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus12 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus13 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus14 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus15 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus0 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus1 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus2 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus3 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus4 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus5 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus6 = new System.Windows.Forms.Label();
			this.labelLedYEndStatus7 = new System.Windows.Forms.Label();
			this.timerUpdateStatus = new System.Timers.Timer();
			this.View = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timerUpdateStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.textStatusViewAxisX);
			this.groupBox1.Controls.Add(this.label33);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(8, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 824);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "X Axis";
			// 
			// textStatusViewAxisX
			// 
			this.textStatusViewAxisX.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textStatusViewAxisX.Enabled = false;
			this.textStatusViewAxisX.ForeColor = System.Drawing.Color.Goldenrod;
			this.textStatusViewAxisX.Location = new System.Drawing.Point(304, 16);
			this.textStatusViewAxisX.Name = "textStatusViewAxisX";
			this.textStatusViewAxisX.Size = new System.Drawing.Size(48, 21);
			this.textStatusViewAxisX.TabIndex = 21;
			this.textStatusViewAxisX.Text = "";
			this.textStatusViewAxisX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label33
			// 
			this.label33.BackColor = System.Drawing.Color.Transparent;
			this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label33.Location = new System.Drawing.Point(248, 16);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(48, 16);
			this.label33.TabIndex = 18;
			this.label33.Text = "axis : ";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus9);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus10);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus0);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus1);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus2);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus3);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus4);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus5);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus6);
			this.groupBox3.Controls.Add(this.labelLedXDriveStatus7);
			this.groupBox3.Location = new System.Drawing.Point(8, 544);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(344, 272);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Drive Status";
			// 
			// labelLedXDriveStatus9
			// 
			this.labelLedXDriveStatus9.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus9.Location = new System.Drawing.Point(8, 47);
			this.labelLedXDriveStatus9.Name = "labelLedXDriveStatus9";
			this.labelLedXDriveStatus9.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus9.TabIndex = 26;
			this.labelLedXDriveStatus9.Text = "9bit : INP BUSY";
			this.labelLedXDriveStatus9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus10
			// 
			this.labelLedXDriveStatus10.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus10.Location = new System.Drawing.Point(8, 23);
			this.labelLedXDriveStatus10.Name = "labelLedXDriveStatus10";
			this.labelLedXDriveStatus10.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus10.TabIndex = 25;
			this.labelLedXDriveStatus10.Text = "10bit : SLAVE BUSY";
			this.labelLedXDriveStatus10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus0
			// 
			this.labelLedXDriveStatus0.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus0.Location = new System.Drawing.Point(8, 240);
			this.labelLedXDriveStatus0.Name = "labelLedXDriveStatus0";
			this.labelLedXDriveStatus0.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus0.TabIndex = 24;
			this.labelLedXDriveStatus0.Text = "0bit : BUSY";
			this.labelLedXDriveStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus1
			// 
			this.labelLedXDriveStatus1.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus1.Location = new System.Drawing.Point(8, 216);
			this.labelLedXDriveStatus1.Name = "labelLedXDriveStatus1";
			this.labelLedXDriveStatus1.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus1.TabIndex = 23;
			this.labelLedXDriveStatus1.Text = "1bit : DOWN";
			this.labelLedXDriveStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus2
			// 
			this.labelLedXDriveStatus2.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus2.Location = new System.Drawing.Point(8, 192);
			this.labelLedXDriveStatus2.Name = "labelLedXDriveStatus2";
			this.labelLedXDriveStatus2.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus2.TabIndex = 22;
			this.labelLedXDriveStatus2.Text = "2bit : CONST";
			this.labelLedXDriveStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus3
			// 
			this.labelLedXDriveStatus3.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus3.Location = new System.Drawing.Point(8, 168);
			this.labelLedXDriveStatus3.Name = "labelLedXDriveStatus3";
			this.labelLedXDriveStatus3.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus3.TabIndex = 21;
			this.labelLedXDriveStatus3.Text = "3bit : UP";
			this.labelLedXDriveStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus4
			// 
			this.labelLedXDriveStatus4.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus4.Location = new System.Drawing.Point(8, 144);
			this.labelLedXDriveStatus4.Name = "labelLedXDriveStatus4";
			this.labelLedXDriveStatus4.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus4.TabIndex = 20;
			this.labelLedXDriveStatus4.Text = "4bit : CONTI BUSY";
			this.labelLedXDriveStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus5
			// 
			this.labelLedXDriveStatus5.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus5.Location = new System.Drawing.Point(8, 120);
			this.labelLedXDriveStatus5.Name = "labelLedXDriveStatus5";
			this.labelLedXDriveStatus5.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus5.TabIndex = 19;
			this.labelLedXDriveStatus5.Text = "5bit : PRESET BUSY";
			this.labelLedXDriveStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus6
			// 
			this.labelLedXDriveStatus6.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus6.Location = new System.Drawing.Point(8, 96);
			this.labelLedXDriveStatus6.Name = "labelLedXDriveStatus6";
			this.labelLedXDriveStatus6.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus6.TabIndex = 18;
			this.labelLedXDriveStatus6.Text = "6bit : MPG BUSY";
			this.labelLedXDriveStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXDriveStatus7
			// 
			this.labelLedXDriveStatus7.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXDriveStatus7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXDriveStatus7.Location = new System.Drawing.Point(8, 72);
			this.labelLedXDriveStatus7.Name = "labelLedXDriveStatus7";
			this.labelLedXDriveStatus7.Size = new System.Drawing.Size(328, 24);
			this.labelLedXDriveStatus7.TabIndex = 17;
			this.labelLedXDriveStatus7.Text = "7bit : ORG BUSY";
			this.labelLedXDriveStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labelLedXEndStatus16);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus30);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus31);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus8);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus9);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus10);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus11);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus12);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus13);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus14);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus15);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus0);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus1);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus2);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus3);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus4);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus5);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus6);
			this.groupBox2.Controls.Add(this.labelLedXEndStatus7);
			this.groupBox2.Location = new System.Drawing.Point(8, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(344, 496);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "End Status";
			// 
			// labelLedXEndStatus16
			// 
			this.labelLedXEndStatus16.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus16.Location = new System.Drawing.Point(8, 78);
			this.labelLedXEndStatus16.Name = "labelLedXEndStatus16";
			this.labelLedXEndStatus16.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus16.TabIndex = 35;
			this.labelLedXEndStatus16.Text = "16bit : MPGERR stopped";
			this.labelLedXEndStatus16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus30
			// 
			this.labelLedXEndStatus30.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus30.Location = new System.Drawing.Point(8, 54);
			this.labelLedXEndStatus30.Name = "labelLedXEndStatus30";
			this.labelLedXEndStatus30.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus30.TabIndex = 34;
			this.labelLedXEndStatus30.Text = "30bit : ERRSTATE";
			this.labelLedXEndStatus30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus31
			// 
			this.labelLedXEndStatus31.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus31.Location = new System.Drawing.Point(8, 30);
			this.labelLedXEndStatus31.Name = "labelLedXEndStatus31";
			this.labelLedXEndStatus31.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus31.TabIndex = 33;
			this.labelLedXEndStatus31.Text = "31bit : INPERR";
			this.labelLedXEndStatus31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus8
			// 
			this.labelLedXEndStatus8.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus8.Location = new System.Drawing.Point(8, 272);
			this.labelLedXEndStatus8.Name = "labelLedXEndStatus8";
			this.labelLedXEndStatus8.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus8.TabIndex = 32;
			this.labelLedXEndStatus8.Text = "8bit : SVALARM stopped";
			this.labelLedXEndStatus8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus9
			// 
			this.labelLedXEndStatus9.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus9.Location = new System.Drawing.Point(8, 246);
			this.labelLedXEndStatus9.Name = "labelLedXEndStatus9";
			this.labelLedXEndStatus9.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus9.TabIndex = 31;
			this.labelLedXEndStatus9.Text = "9bit : ESTOP stopped";
			this.labelLedXEndStatus9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus10
			// 
			this.labelLedXEndStatus10.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus10.Location = new System.Drawing.Point(8, 222);
			this.labelLedXEndStatus10.Name = "labelLedXEndStatus10";
			this.labelLedXEndStatus10.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus10.TabIndex = 30;
			this.labelLedXEndStatus10.Text = "10bit : ESTOPCMD stopped";
			this.labelLedXEndStatus10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus11
			// 
			this.labelLedXEndStatus11.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus11.Location = new System.Drawing.Point(8, 198);
			this.labelLedXEndStatus11.Name = "labelLedXEndStatus11";
			this.labelLedXEndStatus11.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus11.TabIndex = 29;
			this.labelLedXEndStatus11.Text = "11bit : SSTOPCMD stopped";
			this.labelLedXEndStatus11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus12
			// 
			this.labelLedXEndStatus12.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus12.Location = new System.Drawing.Point(8, 174);
			this.labelLedXEndStatus12.Name = "labelLedXEndStatus12";
			this.labelLedXEndStatus12.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus12.TabIndex = 28;
			this.labelLedXEndStatus12.Text = "12bit : ESTOPALL stopped";
			this.labelLedXEndStatus12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus13
			// 
			this.labelLedXEndStatus13.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus13.Location = new System.Drawing.Point(8, 150);
			this.labelLedXEndStatus13.Name = "labelLedXEndStatus13";
			this.labelLedXEndStatus13.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus13.TabIndex = 27;
			this.labelLedXEndStatus13.Text = "13bit : SQSTP#1 stopped";
			this.labelLedXEndStatus13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus14
			// 
			this.labelLedXEndStatus14.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus14.Location = new System.Drawing.Point(8, 126);
			this.labelLedXEndStatus14.Name = "labelLedXEndStatus14";
			this.labelLedXEndStatus14.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus14.TabIndex = 26;
			this.labelLedXEndStatus14.Text = "14bit : SQSTP#2 stopped";
			this.labelLedXEndStatus14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus15
			// 
			this.labelLedXEndStatus15.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus15.Location = new System.Drawing.Point(8, 102);
			this.labelLedXEndStatus15.Name = "labelLedXEndStatus15";
			this.labelLedXEndStatus15.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus15.TabIndex = 25;
			this.labelLedXEndStatus15.Text = "15bit : ENCERR";
			this.labelLedXEndStatus15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus0
			// 
			this.labelLedXEndStatus0.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus0.Location = new System.Drawing.Point(8, 464);
			this.labelLedXEndStatus0.Name = "labelLedXEndStatus0";
			this.labelLedXEndStatus0.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus0.TabIndex = 24;
			this.labelLedXEndStatus0.Text = "0bit : PELM stopped";
			this.labelLedXEndStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus1
			// 
			this.labelLedXEndStatus1.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus1.Location = new System.Drawing.Point(8, 440);
			this.labelLedXEndStatus1.Name = "labelLedXEndStatus1";
			this.labelLedXEndStatus1.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus1.TabIndex = 23;
			this.labelLedXEndStatus1.Text = "1bit : NELM stopped";
			this.labelLedXEndStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus2
			// 
			this.labelLedXEndStatus2.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus2.Location = new System.Drawing.Point(8, 416);
			this.labelLedXEndStatus2.Name = "labelLedXEndStatus2";
			this.labelLedXEndStatus2.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus2.TabIndex = 22;
			this.labelLedXEndStatus2.Text = "2bit : PSLM stopped";
			this.labelLedXEndStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus3
			// 
			this.labelLedXEndStatus3.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus3.Location = new System.Drawing.Point(8, 392);
			this.labelLedXEndStatus3.Name = "labelLedXEndStatus3";
			this.labelLedXEndStatus3.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus3.TabIndex = 21;
			this.labelLedXEndStatus3.Text = "3bit : NSLM stopped";
			this.labelLedXEndStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus4
			// 
			this.labelLedXEndStatus4.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus4.Location = new System.Drawing.Point(8, 368);
			this.labelLedXEndStatus4.Name = "labelLedXEndStatus4";
			this.labelLedXEndStatus4.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus4.TabIndex = 20;
			this.labelLedXEndStatus4.Text = "4bit : PSWLMT stopped";
			this.labelLedXEndStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus5
			// 
			this.labelLedXEndStatus5.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus5.Location = new System.Drawing.Point(8, 344);
			this.labelLedXEndStatus5.Name = "labelLedXEndStatus5";
			this.labelLedXEndStatus5.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus5.TabIndex = 19;
			this.labelLedXEndStatus5.Text = "5bit : NSWLMT stopped";
			this.labelLedXEndStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus6
			// 
			this.labelLedXEndStatus6.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus6.Location = new System.Drawing.Point(8, 320);
			this.labelLedXEndStatus6.Name = "labelLedXEndStatus6";
			this.labelLedXEndStatus6.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus6.TabIndex = 18;
			this.labelLedXEndStatus6.Text = "6bit : PSWSLMT stopped";
			this.labelLedXEndStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedXEndStatus7
			// 
			this.labelLedXEndStatus7.BackColor = System.Drawing.Color.Transparent;
			this.labelLedXEndStatus7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedXEndStatus7.Location = new System.Drawing.Point(8, 296);
			this.labelLedXEndStatus7.Name = "labelLedXEndStatus7";
			this.labelLedXEndStatus7.Size = new System.Drawing.Size(328, 24);
			this.labelLedXEndStatus7.TabIndex = 17;
			this.labelLedXEndStatus7.Text = "7bit : NSWSLMT stopped";
			this.labelLedXEndStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.Color.Transparent;
			this.groupBox4.Controls.Add(this.textStatusViewAxisY);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Location = new System.Drawing.Point(376, 40);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(360, 824);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Y Axis";
			// 
			// textStatusViewAxisY
			// 
			this.textStatusViewAxisY.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textStatusViewAxisY.Enabled = false;
			this.textStatusViewAxisY.ForeColor = System.Drawing.Color.Goldenrod;
			this.textStatusViewAxisY.Location = new System.Drawing.Point(304, 16);
			this.textStatusViewAxisY.Name = "textStatusViewAxisY";
			this.textStatusViewAxisY.Size = new System.Drawing.Size(48, 21);
			this.textStatusViewAxisY.TabIndex = 21;
			this.textStatusViewAxisY.Text = "";
			this.textStatusViewAxisY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(248, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 16);
			this.label17.TabIndex = 18;
			this.label17.Text = "axis : ";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus9);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus10);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus0);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus1);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus2);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus3);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus4);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus5);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus6);
			this.groupBox5.Controls.Add(this.labelLedYDriveStatus7);
			this.groupBox5.Location = new System.Drawing.Point(8, 544);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(344, 272);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Drive Status";
			// 
			// labelLedYDriveStatus9
			// 
			this.labelLedYDriveStatus9.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus9.Location = new System.Drawing.Point(8, 47);
			this.labelLedYDriveStatus9.Name = "labelLedYDriveStatus9";
			this.labelLedYDriveStatus9.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus9.TabIndex = 28;
			this.labelLedYDriveStatus9.Text = "9bit : INP BUSY";
			this.labelLedYDriveStatus9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus10
			// 
			this.labelLedYDriveStatus10.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus10.Location = new System.Drawing.Point(8, 23);
			this.labelLedYDriveStatus10.Name = "labelLedYDriveStatus10";
			this.labelLedYDriveStatus10.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus10.TabIndex = 27;
			this.labelLedYDriveStatus10.Text = "10bit : SLAVE BUSY";
			this.labelLedYDriveStatus10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus0
			// 
			this.labelLedYDriveStatus0.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus0.Location = new System.Drawing.Point(8, 240);
			this.labelLedYDriveStatus0.Name = "labelLedYDriveStatus0";
			this.labelLedYDriveStatus0.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus0.TabIndex = 24;
			this.labelLedYDriveStatus0.Text = "0bit : BUSY";
			this.labelLedYDriveStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus1
			// 
			this.labelLedYDriveStatus1.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus1.Location = new System.Drawing.Point(8, 216);
			this.labelLedYDriveStatus1.Name = "labelLedYDriveStatus1";
			this.labelLedYDriveStatus1.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus1.TabIndex = 23;
			this.labelLedYDriveStatus1.Text = "1bit : DOWN";
			this.labelLedYDriveStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus2
			// 
			this.labelLedYDriveStatus2.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus2.Location = new System.Drawing.Point(8, 192);
			this.labelLedYDriveStatus2.Name = "labelLedYDriveStatus2";
			this.labelLedYDriveStatus2.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus2.TabIndex = 22;
			this.labelLedYDriveStatus2.Text = "2bit : CONST";
			this.labelLedYDriveStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus3
			// 
			this.labelLedYDriveStatus3.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus3.Location = new System.Drawing.Point(8, 168);
			this.labelLedYDriveStatus3.Name = "labelLedYDriveStatus3";
			this.labelLedYDriveStatus3.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus3.TabIndex = 21;
			this.labelLedYDriveStatus3.Text = "3bit : UP";
			this.labelLedYDriveStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus4
			// 
			this.labelLedYDriveStatus4.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus4.Location = new System.Drawing.Point(8, 144);
			this.labelLedYDriveStatus4.Name = "labelLedYDriveStatus4";
			this.labelLedYDriveStatus4.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus4.TabIndex = 20;
			this.labelLedYDriveStatus4.Text = "4bit : CONTI BUSY";
			this.labelLedYDriveStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus5
			// 
			this.labelLedYDriveStatus5.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus5.Location = new System.Drawing.Point(8, 120);
			this.labelLedYDriveStatus5.Name = "labelLedYDriveStatus5";
			this.labelLedYDriveStatus5.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus5.TabIndex = 19;
			this.labelLedYDriveStatus5.Text = "5bit : PRESET BUSY";
			this.labelLedYDriveStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus6
			// 
			this.labelLedYDriveStatus6.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus6.Location = new System.Drawing.Point(8, 96);
			this.labelLedYDriveStatus6.Name = "labelLedYDriveStatus6";
			this.labelLedYDriveStatus6.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus6.TabIndex = 18;
			this.labelLedYDriveStatus6.Text = "6bit : MPG BUSY";
			this.labelLedYDriveStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYDriveStatus7
			// 
			this.labelLedYDriveStatus7.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYDriveStatus7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYDriveStatus7.Location = new System.Drawing.Point(8, 72);
			this.labelLedYDriveStatus7.Name = "labelLedYDriveStatus7";
			this.labelLedYDriveStatus7.Size = new System.Drawing.Size(328, 24);
			this.labelLedYDriveStatus7.TabIndex = 17;
			this.labelLedYDriveStatus7.Text = "7bit : ORG BUSY";
			this.labelLedYDriveStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.labelLedYEndStatus16);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus30);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus31);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus8);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus9);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus10);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus11);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus12);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus13);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus14);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus15);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus0);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus1);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus2);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus3);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus4);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus5);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus6);
			this.groupBox6.Controls.Add(this.labelLedYEndStatus7);
			this.groupBox6.Location = new System.Drawing.Point(8, 40);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(344, 496);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "End Status";
			// 
			// labelLedYEndStatus16
			// 
			this.labelLedYEndStatus16.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus16.Location = new System.Drawing.Point(8, 78);
			this.labelLedYEndStatus16.Name = "labelLedYEndStatus16";
			this.labelLedYEndStatus16.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus16.TabIndex = 46;
			this.labelLedYEndStatus16.Text = "16bit : MPGERR stopped";
			this.labelLedYEndStatus16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus30
			// 
			this.labelLedYEndStatus30.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus30.Location = new System.Drawing.Point(8, 54);
			this.labelLedYEndStatus30.Name = "labelLedYEndStatus30";
			this.labelLedYEndStatus30.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus30.TabIndex = 45;
			this.labelLedYEndStatus30.Text = "30bit : ERRSTATE";
			this.labelLedYEndStatus30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus31
			// 
			this.labelLedYEndStatus31.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus31.Location = new System.Drawing.Point(8, 30);
			this.labelLedYEndStatus31.Name = "labelLedYEndStatus31";
			this.labelLedYEndStatus31.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus31.TabIndex = 44;
			this.labelLedYEndStatus31.Text = "31bit : INPERR";
			this.labelLedYEndStatus31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus8
			// 
			this.labelLedYEndStatus8.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus8.Location = new System.Drawing.Point(8, 270);
			this.labelLedYEndStatus8.Name = "labelLedYEndStatus8";
			this.labelLedYEndStatus8.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus8.TabIndex = 43;
			this.labelLedYEndStatus8.Text = "8bit : SVALARM stopped";
			this.labelLedYEndStatus8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus9
			// 
			this.labelLedYEndStatus9.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus9.Location = new System.Drawing.Point(8, 246);
			this.labelLedYEndStatus9.Name = "labelLedYEndStatus9";
			this.labelLedYEndStatus9.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus9.TabIndex = 42;
			this.labelLedYEndStatus9.Text = "9bit : ESTOP stopped";
			this.labelLedYEndStatus9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus10
			// 
			this.labelLedYEndStatus10.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus10.Location = new System.Drawing.Point(8, 222);
			this.labelLedYEndStatus10.Name = "labelLedYEndStatus10";
			this.labelLedYEndStatus10.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus10.TabIndex = 41;
			this.labelLedYEndStatus10.Text = "10bit : ESTOPCMD stopped";
			this.labelLedYEndStatus10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus11
			// 
			this.labelLedYEndStatus11.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus11.Location = new System.Drawing.Point(8, 198);
			this.labelLedYEndStatus11.Name = "labelLedYEndStatus11";
			this.labelLedYEndStatus11.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus11.TabIndex = 40;
			this.labelLedYEndStatus11.Text = "11bit : SSTOPCMD stopped";
			this.labelLedYEndStatus11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus12
			// 
			this.labelLedYEndStatus12.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus12.Location = new System.Drawing.Point(8, 174);
			this.labelLedYEndStatus12.Name = "labelLedYEndStatus12";
			this.labelLedYEndStatus12.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus12.TabIndex = 39;
			this.labelLedYEndStatus12.Text = "12bit : ESTOPALL stopped";
			this.labelLedYEndStatus12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus13
			// 
			this.labelLedYEndStatus13.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus13.Location = new System.Drawing.Point(8, 150);
			this.labelLedYEndStatus13.Name = "labelLedYEndStatus13";
			this.labelLedYEndStatus13.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus13.TabIndex = 38;
			this.labelLedYEndStatus13.Text = "13bit : SQSTP#1 stopped";
			this.labelLedYEndStatus13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus14
			// 
			this.labelLedYEndStatus14.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus14.Location = new System.Drawing.Point(8, 126);
			this.labelLedYEndStatus14.Name = "labelLedYEndStatus14";
			this.labelLedYEndStatus14.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus14.TabIndex = 37;
			this.labelLedYEndStatus14.Text = "14bit : SQSTP#2 stopped";
			this.labelLedYEndStatus14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus15
			// 
			this.labelLedYEndStatus15.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus15.Location = new System.Drawing.Point(8, 102);
			this.labelLedYEndStatus15.Name = "labelLedYEndStatus15";
			this.labelLedYEndStatus15.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus15.TabIndex = 36;
			this.labelLedYEndStatus15.Text = "15bit : ENCERR";
			this.labelLedYEndStatus15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus0
			// 
			this.labelLedYEndStatus0.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus0.Location = new System.Drawing.Point(8, 464);
			this.labelLedYEndStatus0.Name = "labelLedYEndStatus0";
			this.labelLedYEndStatus0.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus0.TabIndex = 24;
			this.labelLedYEndStatus0.Text = "0bit : PELM stopped";
			this.labelLedYEndStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus1
			// 
			this.labelLedYEndStatus1.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus1.Location = new System.Drawing.Point(8, 440);
			this.labelLedYEndStatus1.Name = "labelLedYEndStatus1";
			this.labelLedYEndStatus1.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus1.TabIndex = 23;
			this.labelLedYEndStatus1.Text = "1bit : NELM stopped";
			this.labelLedYEndStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus2
			// 
			this.labelLedYEndStatus2.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus2.Location = new System.Drawing.Point(8, 416);
			this.labelLedYEndStatus2.Name = "labelLedYEndStatus2";
			this.labelLedYEndStatus2.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus2.TabIndex = 22;
			this.labelLedYEndStatus2.Text = "2bit : PSLM stopped";
			this.labelLedYEndStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus3
			// 
			this.labelLedYEndStatus3.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus3.Location = new System.Drawing.Point(8, 392);
			this.labelLedYEndStatus3.Name = "labelLedYEndStatus3";
			this.labelLedYEndStatus3.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus3.TabIndex = 21;
			this.labelLedYEndStatus3.Text = "3bit : NSLM stopped";
			this.labelLedYEndStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus4
			// 
			this.labelLedYEndStatus4.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus4.Location = new System.Drawing.Point(8, 368);
			this.labelLedYEndStatus4.Name = "labelLedYEndStatus4";
			this.labelLedYEndStatus4.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus4.TabIndex = 20;
			this.labelLedYEndStatus4.Text = "4bit : PSWLMT stopped";
			this.labelLedYEndStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus5
			// 
			this.labelLedYEndStatus5.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus5.Location = new System.Drawing.Point(8, 344);
			this.labelLedYEndStatus5.Name = "labelLedYEndStatus5";
			this.labelLedYEndStatus5.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus5.TabIndex = 19;
			this.labelLedYEndStatus5.Text = "5bit : NSWLMT stopped";
			this.labelLedYEndStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus6
			// 
			this.labelLedYEndStatus6.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus6.Location = new System.Drawing.Point(8, 320);
			this.labelLedYEndStatus6.Name = "labelLedYEndStatus6";
			this.labelLedYEndStatus6.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus6.TabIndex = 18;
			this.labelLedYEndStatus6.Text = "6bit : PSWSLMT stopped";
			this.labelLedYEndStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLedYEndStatus7
			// 
			this.labelLedYEndStatus7.BackColor = System.Drawing.Color.Transparent;
			this.labelLedYEndStatus7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelLedYEndStatus7.Location = new System.Drawing.Point(8, 296);
			this.labelLedYEndStatus7.Name = "labelLedYEndStatus7";
			this.labelLedYEndStatus7.Size = new System.Drawing.Size(328, 24);
			this.labelLedYEndStatus7.TabIndex = 17;
			this.labelLedYEndStatus7.Text = "7bit : NSWSLMT stopped";
			this.labelLedYEndStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerUpdateStatus
			// 
			this.timerUpdateStatus.Enabled = true;
			this.timerUpdateStatus.SynchronizingObject = this;
			this.timerUpdateStatus.Elapsed += new System.Timers.ElapsedEventHandler(this.timerUpdateStatus_Elapsed);
			// 
			// View
			// 
			this.View.Location = new System.Drawing.Point(648, 8);
			this.View.Name = "View";
			this.View.Size = new System.Drawing.Size(32, 24);
			this.View.TabIndex = 2;
			this.View.Text = "||";
			this.View.Click += new System.EventHandler(this.View_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(616, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "<<";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(680, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = ">>";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// FormStatusView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(744, 870);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.View);
			this.Name = "FormStatusView";
			this.Text = "STATUS VIEW (END ,DRV)";
			this.Load += new System.EventHandler(this.FormStatusView_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.timerUpdateStatus)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void timerUpdateStatus_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			uint	uIsMotionModule =0;
			CAXM.AxmInfoIsMotionModule( ref uIsMotionModule );
			if( uIsMotionModule == ( uint)AXT_BOOLEAN.FALSE )
				return;

			// Update status of LEDs
			int[]	arrnAxis	= new int[2];

			arrnAxis[0]			= CAXHS.AXIS_EVN(CAXHS.m_SendAxis);
			arrnAxis[1]			= CAXHS.AXIS_ODD(CAXHS.m_SendAxis);

			// Set status (light)
			uint	uDrvStatusX =0, uDrvStatusY =0;

			CAXM.AxmStatusReadMotion(arrnAxis[0], ref uDrvStatusX );

			byte	byDrvStatusX	= (byte)uDrvStatusX;
						
			if( (byDrvStatusX & 0x01) == 0 )	labelLedXDriveStatus0.BackColor = Color.Transparent;				// bit0
			else								labelLedXDriveStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byDrvStatusX & 0x02) == 0 )	labelLedXDriveStatus1.BackColor = Color.Transparent;				// bit1
			else								labelLedXDriveStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byDrvStatusX & 0x04) == 0 )	labelLedXDriveStatus2.BackColor = Color.Transparent;				// bit2
			else								labelLedXDriveStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byDrvStatusX & 0x08) == 0 )	labelLedXDriveStatus3.BackColor = Color.Transparent;				// bit3
			else								labelLedXDriveStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byDrvStatusX & 0x10) == 0 )	labelLedXDriveStatus4.BackColor = Color.Transparent;				// bit4
			else								labelLedXDriveStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byDrvStatusX & 0x20) == 0 )	labelLedXDriveStatus5.BackColor = Color.Transparent;				// bit5
			else								labelLedXDriveStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byDrvStatusX & 0x40) == 0 )	labelLedXDriveStatus6.BackColor = Color.Transparent;				// bit6
			else								labelLedXDriveStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byDrvStatusX & 0x80) == 0 )	labelLedXDriveStatus7.BackColor = Color.Transparent;				// bit7
			else								labelLedXDriveStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byDrvStatusX & 0x200) == 0 )	labelLedXDriveStatus9.BackColor = Color.Transparent;				// bit7
			else								labelLedXDriveStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byDrvStatusX & 0x400) == 0 )	labelLedXDriveStatus10.BackColor = Color.Transparent;				// bit7
			else								labelLedXDriveStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			CAXM.AxmStatusReadMotion( arrnAxis[1], ref uDrvStatusY );

			byte	byDrvStatusY	= (byte)uDrvStatusY;

			if( (byDrvStatusY & 0x01) == 0 )	labelLedYDriveStatus0.BackColor = Color.Transparent;				// bit0
			else								labelLedYDriveStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byDrvStatusY & 0x02) == 0 )	labelLedYDriveStatus1.BackColor = Color.Transparent;				// bit1
			else								labelLedYDriveStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byDrvStatusY & 0x04) == 0 )	labelLedYDriveStatus2.BackColor = Color.Transparent;				// bit2
			else								labelLedYDriveStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byDrvStatusY & 0x08) == 0 )	labelLedYDriveStatus3.BackColor = Color.Transparent;				// bit3
			else								labelLedYDriveStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byDrvStatusY & 0x10) == 0 )	labelLedYDriveStatus4.BackColor = Color.Transparent;				// bit4
			else								labelLedYDriveStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byDrvStatusY & 0x20) == 0 )	labelLedYDriveStatus5.BackColor = Color.Transparent;				// bit5
			else								labelLedYDriveStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byDrvStatusY & 0x40) == 0 )	labelLedYDriveStatus6.BackColor = Color.Transparent;				// bit6
			else								labelLedYDriveStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byDrvStatusY & 0x80) == 0 )	labelLedYDriveStatus7.BackColor = Color.Transparent;				// bit7
			else								labelLedYDriveStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byDrvStatusY & 0x200) == 0 )	labelLedYDriveStatus9.BackColor = Color.Transparent;				// bit7
			else								labelLedYDriveStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byDrvStatusY & 0x400) == 0 )	labelLedYDriveStatus10.BackColor = Color.Transparent;				// bit7
			else								labelLedYDriveStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
		}

		private void FormStatusView_Load(object sender, System.EventArgs e)
		{
		
		}

		private void View_Click(object sender, System.EventArgs e)
		{
			if( CAXL.AxlIsOpened() == ( int)AXT_BOOLEAN.FALSE )
				return;

			uint	uIsMotionModule =0;
			CAXM.AxmInfoIsMotionModule( ref uIsMotionModule );
			if( uIsMotionModule == ( uint)AXT_BOOLEAN.FALSE )
				return;

			// Update status of LEDs
			int[]	arrnAxis	= new int[2];

			arrnAxis[0]			= CAXHS.AXIS_EVN(CAXHS.m_SendAxis);
			arrnAxis[1]			= CAXHS.AXIS_ODD(CAXHS.m_SendAxis);

			// Position을 보여주는 타이머
			textStatusViewAxisX.Text = String.Format("{0:d}", arrnAxis[0]);
			textStatusViewAxisY.Text = String.Format("{0:d}", arrnAxis[1]);

			// Set status (light)
			uint	uEndStatusX =0, uEndStatusY =0;

			CAXM.AxmStatusReadStop(arrnAxis[0], ref uEndStatusX );

			uint	byEndStatusX	= uEndStatusX;

			if( (byEndStatusX & 0x01) == 0 )	labelLedXEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedXEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusX & 0x02) == 0 )	labelLedXEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedXEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusX & 0x04) == 0 )	labelLedXEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedXEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusX & 0x08) == 0 )	labelLedXEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedXEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusX & 0x10) == 0 )	labelLedXEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedXEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusX & 0x20) == 0 )	labelLedXEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedXEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusX & 0x40) == 0 )	labelLedXEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedXEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusX & 0x80) == 0 )	labelLedXEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x100) == 0 )	labelLedXEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x200) == 0 )	labelLedXEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x400) == 0 )	labelLedXEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x800) == 0 )	labelLedXEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x1000) == 0 )	labelLedXEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x2000) == 0 )	labelLedXEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x4000) == 0 )	labelLedXEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x8000) == 0 )	labelLedXEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x10000) == 0 )	labelLedXEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x40000000) == 0 )	labelLedXEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x80000000) == 0 )	labelLedXEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			CAXM.AxmStatusReadStop( arrnAxis[1], ref uEndStatusY );

			uint	byEndStatusY	= uEndStatusY;

			if( (byEndStatusY & 0x01) == 0 )	labelLedYEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedYEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusY & 0x02) == 0 )	labelLedYEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedYEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusY & 0x04) == 0 )	labelLedYEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedYEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusY & 0x08) == 0 )	labelLedYEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedYEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusY & 0x10) == 0 )	labelLedYEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedYEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusY & 0x20) == 0 )	labelLedYEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedYEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusY & 0x40) == 0 )	labelLedYEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedYEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusY & 0x80) == 0 )	labelLedYEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			if( (byEndStatusY & 0x100) == 0 )	labelLedYEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x200) == 0 )	labelLedYEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x400) == 0 )	labelLedYEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x800) == 0 )	labelLedYEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x1000) == 0 )	labelLedYEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x2000) == 0 )	labelLedYEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x4000) == 0 )	labelLedYEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x8000) == 0 )	labelLedYEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x10000) == 0 )	labelLedYEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x40000000) == 0 )	labelLedYEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x80000000) == 0 )	labelLedYEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		
			if( CAXL.AxlIsOpened() == ( int)AXT_BOOLEAN.FALSE )
				return;

			uint	uIsMotionModule =0;
			CAXM.AxmInfoIsMotionModule( ref uIsMotionModule );
			if( uIsMotionModule == ( uint)AXT_BOOLEAN.FALSE )
				return;

			// Update status of LEDs
			int[]	arrnAxis	= new int[2];

			arrnAxis[0]			= CAXHS.AXIS_EVN(CAXHS.m_SendAxis) -2;
			arrnAxis[1]			= CAXHS.AXIS_ODD(CAXHS.m_SendAxis) -2;

			if(arrnAxis[0] < 0)
			{
				arrnAxis[0]			= 0;
				arrnAxis[1]			= 1;
			}

			CAXHS.m_SendAxis = arrnAxis[0];

			// Position을 보여주는 타이머
			textStatusViewAxisX.Text = String.Format("{0:d}", arrnAxis[0]);
			textStatusViewAxisY.Text = String.Format("{0:d}", arrnAxis[1]);

			// Set status (light)
			uint	uEndStatusX =0, uEndStatusY =0;

			CAXM.AxmStatusReadStop(arrnAxis[0], ref uEndStatusX );

			byte	byEndStatusX	= (byte)uEndStatusX;

			if( (byEndStatusX & 0x01) == 0 )	labelLedXEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedXEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusX & 0x02) == 0 )	labelLedXEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedXEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusX & 0x04) == 0 )	labelLedXEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedXEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusX & 0x08) == 0 )	labelLedXEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedXEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusX & 0x10) == 0 )	labelLedXEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedXEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusX & 0x20) == 0 )	labelLedXEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedXEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusX & 0x40) == 0 )	labelLedXEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedXEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusX & 0x80) == 0 )	labelLedXEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x100) == 0 )	labelLedXEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x200) == 0 )	labelLedXEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x400) == 0 )	labelLedXEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x800) == 0 )	labelLedXEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x1000) == 0 )	labelLedXEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x2000) == 0 )	labelLedXEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x4000) == 0 )	labelLedXEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x8000) == 0 )	labelLedXEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x10000) == 0 )	labelLedXEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x40000000) == 0 )	labelLedXEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x80000000) == 0 )	labelLedXEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			CAXM.AxmStatusReadStop( arrnAxis[1], ref uEndStatusY );

			byte	byEndStatusY	= (byte)uEndStatusY;

			if( (byEndStatusY & 0x01) == 0 )	labelLedYEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedYEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusY & 0x02) == 0 )	labelLedYEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedYEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusY & 0x04) == 0 )	labelLedYEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedYEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusY & 0x08) == 0 )	labelLedYEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedYEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusY & 0x10) == 0 )	labelLedYEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedYEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusY & 0x20) == 0 )	labelLedYEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedYEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusY & 0x40) == 0 )	labelLedYEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedYEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusY & 0x80) == 0 )	labelLedYEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			if( (byEndStatusY & 0x100) == 0 )	labelLedYEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x200) == 0 )	labelLedYEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x400) == 0 )	labelLedYEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x800) == 0 )	labelLedYEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x1000) == 0 )	labelLedYEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x2000) == 0 )	labelLedYEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x4000) == 0 )	labelLedYEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x8000) == 0 )	labelLedYEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x10000) == 0 )	labelLedYEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x40000000) == 0 )	labelLedYEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x80000000) == 0 )	labelLedYEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if( CAXL.AxlIsOpened() == ( int)AXT_BOOLEAN.FALSE )
				return;

			uint	uIsMotionModule =0;
			CAXM.AxmInfoIsMotionModule( ref uIsMotionModule );
			if( uIsMotionModule == ( uint)AXT_BOOLEAN.FALSE )
				return;

			// Update status of LEDs
			int[]	arrnAxis	= new int[2];

			arrnAxis[0]			= CAXHS.AXIS_EVN(CAXHS.m_SendAxis) +2;
			arrnAxis[1]			= CAXHS.AXIS_ODD(CAXHS.m_SendAxis) +2;

			if(arrnAxis[0] < 0)
			{
				arrnAxis[0]			= CAXHS.AXIS_EVN(CAXHS.m_SendAxis);
				arrnAxis[1]			= CAXHS.AXIS_ODD(CAXHS.m_SendAxis);
			}
	
			CAXHS.m_SendAxis = arrnAxis[0];

			// Position을 보여주는 타이머
			textStatusViewAxisX.Text = String.Format("{0:d}", arrnAxis[0]);
			textStatusViewAxisY.Text = String.Format("{0:d}", arrnAxis[1]);

			// Set status (light)
			uint	uEndStatusX =0, uEndStatusY =0;

			CAXM.AxmStatusReadStop(arrnAxis[0], ref uEndStatusX );

			byte	byEndStatusX	= (byte)uEndStatusX;

			if( (byEndStatusX & 0x01) == 0 )	labelLedXEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedXEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusX & 0x02) == 0 )	labelLedXEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedXEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusX & 0x04) == 0 )	labelLedXEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedXEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusX & 0x08) == 0 )	labelLedXEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedXEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusX & 0x10) == 0 )	labelLedXEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedXEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusX & 0x20) == 0 )	labelLedXEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedXEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusX & 0x40) == 0 )	labelLedXEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedXEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusX & 0x80) == 0 )	labelLedXEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x100) == 0 )	labelLedXEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x200) == 0 )	labelLedXEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x400) == 0 )	labelLedXEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x800) == 0 )	labelLedXEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x1000) == 0 )	labelLedXEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x2000) == 0 )	labelLedXEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x4000) == 0 )	labelLedXEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x8000) == 0 )	labelLedXEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x10000) == 0 )	labelLedXEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x40000000) == 0 )	labelLedXEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusX & 0x80000000) == 0 )	labelLedXEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedXEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			CAXM.AxmStatusReadStop( arrnAxis[1], ref uEndStatusY );

			byte	byEndStatusY	= (byte)uEndStatusY;

			if( (byEndStatusY & 0x01) == 0 )	labelLedYEndStatus0.BackColor = Color.Transparent;					// bit0
			else								labelLedYEndStatus0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
			if( (byEndStatusY & 0x02) == 0 )	labelLedYEndStatus1.BackColor = Color.Transparent;					// bit1
			else								labelLedYEndStatus1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
			if( (byEndStatusY & 0x04) == 0 )	labelLedYEndStatus2.BackColor = Color.Transparent;					// bit2
			else								labelLedYEndStatus2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
			if( (byEndStatusY & 0x08) == 0 )	labelLedYEndStatus3.BackColor = Color.Transparent;					// bit3
			else								labelLedYEndStatus3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
			if( (byEndStatusY & 0x10) == 0 )	labelLedYEndStatus4.BackColor = Color.Transparent;					// bit4
			else								labelLedYEndStatus4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
			if( (byEndStatusY & 0x20) == 0 )	labelLedYEndStatus5.BackColor = Color.Transparent;					// bit5
			else								labelLedYEndStatus5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5
			if( (byEndStatusY & 0x40) == 0 )	labelLedYEndStatus6.BackColor = Color.Transparent;					// bit6
			else								labelLedYEndStatus6.BackColor = Color.FromArgb(200, Color.Gold);	// bit6
			if( (byEndStatusY & 0x80) == 0 )	labelLedYEndStatus7.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus7.BackColor = Color.FromArgb(200, Color.Gold);	// bit7

			if( (byEndStatusY & 0x100) == 0 )	labelLedYEndStatus8.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus8.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x200) == 0 )	labelLedYEndStatus9.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus9.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x400) == 0 )	labelLedYEndStatus10.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus10.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x800) == 0 )	labelLedYEndStatus11.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus11.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x1000) == 0 )	labelLedYEndStatus12.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus12.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x2000) == 0 )	labelLedYEndStatus13.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus13.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x4000) == 0 )	labelLedYEndStatus14.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus14.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x8000) == 0 )	labelLedYEndStatus15.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus15.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x10000) == 0 )	labelLedYEndStatus16.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus16.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x40000000) == 0 )	labelLedYEndStatus30.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus30.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
			if( (byEndStatusY & 0x80000000) == 0 )	labelLedYEndStatus31.BackColor = Color.Transparent;					// bit7
			else								labelLedYEndStatus31.BackColor = Color.FromArgb(200, Color.Gold);	// bit7
		}



	}
}
