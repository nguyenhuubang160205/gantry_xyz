using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;

public enum AXT_INTERRUPT_CLASS:uint
{
	KIND_MESSAGE,
	KIND_CALLBACK,
	KIND_EVENT
}

namespace DititalIO
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class FormDigitalIO : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label labelModule;
		private System.Windows.Forms.ComboBox comboModule;
		private System.Windows.Forms.CheckBox checkInterrupt;
		private System.Windows.Forms.CheckBox checkRigingEdge;
		private System.Windows.Forms.CheckBox checkFallingEdge;
		private System.Windows.Forms.GroupBox groupInterruptType;
		private System.Windows.Forms.RadioButton radioMessage;
		private System.Windows.Forms.RadioButton radioCallback;
		private System.Windows.Forms.RadioButton radioEvent;
		private System.Windows.Forms.CheckBox checkHigh00;
		private System.Windows.Forms.CheckBox checkHigh01;
		private System.Windows.Forms.CheckBox checkHigh02;
		private System.Windows.Forms.CheckBox checkHigh03;
		private System.Windows.Forms.CheckBox checkHigh04;
		private System.Windows.Forms.CheckBox checkHigh05;
		private System.Windows.Forms.CheckBox checkHigh06;
		private System.Windows.Forms.CheckBox checkHigh07;
		private System.Windows.Forms.CheckBox checkHigh15;
		private System.Windows.Forms.CheckBox checkHigh14;
		private System.Windows.Forms.CheckBox checkHigh13;
		private System.Windows.Forms.CheckBox checkHigh12;
		private System.Windows.Forms.CheckBox checkHigh11;
		private System.Windows.Forms.CheckBox checkHigh10;
		private System.Windows.Forms.CheckBox checkHigh09;
		private System.Windows.Forms.CheckBox checkHigh08;
		private System.Windows.Forms.GroupBox groupLow;
		private System.Windows.Forms.CheckBox checkLow00;
		private System.Windows.Forms.CheckBox checkLow01;
		private System.Windows.Forms.CheckBox checkLow02;
		private System.Windows.Forms.CheckBox checkLow03;
		private System.Windows.Forms.CheckBox checkLow04;
		private System.Windows.Forms.CheckBox checkLow05;
		private System.Windows.Forms.CheckBox checkLow06;
		private System.Windows.Forms.CheckBox checkLow07;
		private System.Windows.Forms.CheckBox checkLow08;
		private System.Windows.Forms.CheckBox checkLow09;
		private System.Windows.Forms.CheckBox checkLow10;
		private System.Windows.Forms.CheckBox checkLow11;
		private System.Windows.Forms.CheckBox checkLow12;
		private System.Windows.Forms.CheckBox checkLow13;
		private System.Windows.Forms.CheckBox checkLow14;
		private System.Windows.Forms.CheckBox checkLow15;
        private System.Windows.Forms.TextBox textInterrupt;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Timer timerSensor;
        private System.Windows.Forms.GroupBox groupHigh;
        private System.ComponentModel.IContainer components;

        CAXHS.AXT_INTERRUPT_PROC Callbackfunction = new CAXHS.AXT_INTERRUPT_PROC(InterruptCallback);

		public FormDigitalIO()
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
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            this.labelModule = new System.Windows.Forms.Label();
            this.comboModule = new System.Windows.Forms.ComboBox();
            this.groupInterruptType = new System.Windows.Forms.GroupBox();
            this.radioMessage = new System.Windows.Forms.RadioButton();
            this.radioCallback = new System.Windows.Forms.RadioButton();
            this.radioEvent = new System.Windows.Forms.RadioButton();
            this.checkInterrupt = new System.Windows.Forms.CheckBox();
            this.checkRigingEdge = new System.Windows.Forms.CheckBox();
            this.checkFallingEdge = new System.Windows.Forms.CheckBox();
            this.groupHigh = new System.Windows.Forms.GroupBox();
            this.checkHigh00 = new System.Windows.Forms.CheckBox();
            this.checkHigh01 = new System.Windows.Forms.CheckBox();
            this.checkHigh02 = new System.Windows.Forms.CheckBox();
            this.checkHigh03 = new System.Windows.Forms.CheckBox();
            this.checkHigh04 = new System.Windows.Forms.CheckBox();
            this.checkHigh05 = new System.Windows.Forms.CheckBox();
            this.checkHigh06 = new System.Windows.Forms.CheckBox();
            this.checkHigh07 = new System.Windows.Forms.CheckBox();
            this.checkHigh08 = new System.Windows.Forms.CheckBox();
            this.checkHigh09 = new System.Windows.Forms.CheckBox();
            this.checkHigh10 = new System.Windows.Forms.CheckBox();
            this.checkHigh11 = new System.Windows.Forms.CheckBox();
            this.checkHigh12 = new System.Windows.Forms.CheckBox();
            this.checkHigh13 = new System.Windows.Forms.CheckBox();
            this.checkHigh14 = new System.Windows.Forms.CheckBox();
            this.checkHigh15 = new System.Windows.Forms.CheckBox();
            this.groupLow = new System.Windows.Forms.GroupBox();
            this.checkLow00 = new System.Windows.Forms.CheckBox();
            this.checkLow01 = new System.Windows.Forms.CheckBox();
            this.checkLow02 = new System.Windows.Forms.CheckBox();
            this.checkLow03 = new System.Windows.Forms.CheckBox();
            this.checkLow04 = new System.Windows.Forms.CheckBox();
            this.checkLow05 = new System.Windows.Forms.CheckBox();
            this.checkLow06 = new System.Windows.Forms.CheckBox();
            this.checkLow07 = new System.Windows.Forms.CheckBox();
            this.checkLow08 = new System.Windows.Forms.CheckBox();
            this.checkLow09 = new System.Windows.Forms.CheckBox();
            this.checkLow10 = new System.Windows.Forms.CheckBox();
            this.checkLow11 = new System.Windows.Forms.CheckBox();
            this.checkLow12 = new System.Windows.Forms.CheckBox();
            this.checkLow13 = new System.Windows.Forms.CheckBox();
            this.checkLow14 = new System.Windows.Forms.CheckBox();
            this.checkLow15 = new System.Windows.Forms.CheckBox();
            this.textInterrupt = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerSensor = new System.Windows.Forms.Timer(this.components);
            this.groupInterruptType.SuspendLayout();
            this.groupHigh.SuspendLayout();
            this.groupLow.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelModule
            // 
            this.labelModule.Location = new System.Drawing.Point(8, 8);
            this.labelModule.Name = "labelModule";
            this.labelModule.Size = new System.Drawing.Size(152, 16);
            this.labelModule.TabIndex = 0;
            this.labelModule.Text = "[Bo.No.:Mo.No.] Mo.ID";
            // 
            // comboModule
            // 
            this.comboModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModule.Location = new System.Drawing.Point(168, 8);
            this.comboModule.Name = "comboModule";
            this.comboModule.Size = new System.Drawing.Size(216, 20);
            this.comboModule.TabIndex = 1;
            this.comboModule.SelectedIndexChanged += new System.EventHandler(this.comboModule_SelectedIndexChanged);
            // 
            // groupInterruptType
            // 
            this.groupInterruptType.Controls.Add(this.radioMessage);
            this.groupInterruptType.Controls.Add(this.radioCallback);
            this.groupInterruptType.Controls.Add(this.radioEvent);
            this.groupInterruptType.Location = new System.Drawing.Point(8, 64);
            this.groupInterruptType.Name = "groupInterruptType";
            this.groupInterruptType.Size = new System.Drawing.Size(376, 36);
            this.groupInterruptType.TabIndex = 5;
            this.groupInterruptType.TabStop = false;
            this.groupInterruptType.Text = "Interrupt Method";
            // 
            // radioMessage
            // 
            this.radioMessage.Location = new System.Drawing.Point(20, 12);
            this.radioMessage.Name = "radioMessage";
            this.radioMessage.Size = new System.Drawing.Size(80, 20);
            this.radioMessage.TabIndex = 0;
            this.radioMessage.Text = "Message";
            this.radioMessage.CheckedChanged += new System.EventHandler(this.radioMessage_CheckedChanged);
            // 
            // radioCallback
            // 
            this.radioCallback.Location = new System.Drawing.Point(273, 12);
            this.radioCallback.Name = "radioCallback";
            this.radioCallback.Size = new System.Drawing.Size(80, 20);
            this.radioCallback.TabIndex = 1;
            this.radioCallback.Text = "Callback";
            this.radioCallback.CheckedChanged += new System.EventHandler(this.radioCallback_CheckedChanged);
            // 
            // radioEvent
            // 
            this.radioEvent.Location = new System.Drawing.Point(160, 12);
            this.radioEvent.Name = "radioEvent";
            this.radioEvent.Size = new System.Drawing.Size(56, 20);
            this.radioEvent.TabIndex = 2;
            this.radioEvent.Text = "Event";
            this.radioEvent.CheckedChanged += new System.EventHandler(this.radioEvent_CheckedChanged);
            // 
            // checkInterrupt
            // 
            this.checkInterrupt.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkInterrupt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkInterrupt.Location = new System.Drawing.Point(8, 36);
            this.checkInterrupt.Name = "checkInterrupt";
            this.checkInterrupt.Size = new System.Drawing.Size(135, 24);
            this.checkInterrupt.TabIndex = 2;
            this.checkInterrupt.Text = "Interrupt";
            this.checkInterrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkInterrupt.CheckedChanged += new System.EventHandler(this.checkInterrupt_CheckedChanged);
            // 
            // checkRigingEdge
            // 
            this.checkRigingEdge.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkRigingEdge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkRigingEdge.Location = new System.Drawing.Point(168, 36);
            this.checkRigingEdge.Name = "checkRigingEdge";
            this.checkRigingEdge.Size = new System.Drawing.Size(103, 24);
            this.checkRigingEdge.TabIndex = 3;
            this.checkRigingEdge.Text = "Riging Edge";
            this.checkRigingEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkRigingEdge.CheckedChanged += new System.EventHandler(this.checkRigingEdge_CheckedChanged);
            // 
            // checkFallingEdge
            // 
            this.checkFallingEdge.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkFallingEdge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkFallingEdge.Location = new System.Drawing.Point(281, 36);
            this.checkFallingEdge.Name = "checkFallingEdge";
            this.checkFallingEdge.Size = new System.Drawing.Size(103, 24);
            this.checkFallingEdge.TabIndex = 4;
            this.checkFallingEdge.Text = "Falling Edge";
            this.checkFallingEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkFallingEdge.CheckedChanged += new System.EventHandler(this.checkFallingEdge_CheckedChanged);
            // 
            // groupHigh
            // 
            this.groupHigh.Controls.Add(this.checkHigh00);
            this.groupHigh.Controls.Add(this.checkHigh01);
            this.groupHigh.Controls.Add(this.checkHigh02);
            this.groupHigh.Controls.Add(this.checkHigh03);
            this.groupHigh.Controls.Add(this.checkHigh04);
            this.groupHigh.Controls.Add(this.checkHigh05);
            this.groupHigh.Controls.Add(this.checkHigh06);
            this.groupHigh.Controls.Add(this.checkHigh07);
            this.groupHigh.Controls.Add(this.checkHigh08);
            this.groupHigh.Controls.Add(this.checkHigh09);
            this.groupHigh.Controls.Add(this.checkHigh10);
            this.groupHigh.Controls.Add(this.checkHigh11);
            this.groupHigh.Controls.Add(this.checkHigh12);
            this.groupHigh.Controls.Add(this.checkHigh13);
            this.groupHigh.Controls.Add(this.checkHigh14);
            this.groupHigh.Controls.Add(this.checkHigh15);
            this.groupHigh.Location = new System.Drawing.Point(8, 108);
            this.groupHigh.Name = "groupHigh";
            this.groupHigh.Size = new System.Drawing.Size(376, 64);
            this.groupHigh.TabIndex = 5;
            this.groupHigh.TabStop = false;
            this.groupHigh.Text = "High";
            // 
            // checkHigh00
            // 
            this.checkHigh00.Location = new System.Drawing.Point(16, 16);
            this.checkHigh00.Name = "checkHigh00";
            this.checkHigh00.Size = new System.Drawing.Size(40, 20);
            this.checkHigh00.TabIndex = 0;
            this.checkHigh00.Text = "00";
            this.checkHigh00.CheckedChanged += new System.EventHandler(this.checkHigh00_CheckedChanged);
            // 
            // checkHigh01
            // 
            this.checkHigh01.Location = new System.Drawing.Point(60, 16);
            this.checkHigh01.Name = "checkHigh01";
            this.checkHigh01.Size = new System.Drawing.Size(40, 20);
            this.checkHigh01.TabIndex = 1;
            this.checkHigh01.Text = "01";
            this.checkHigh01.CheckedChanged += new System.EventHandler(this.checkHigh01_CheckedChanged);
            // 
            // checkHigh02
            // 
            this.checkHigh02.Location = new System.Drawing.Point(104, 16);
            this.checkHigh02.Name = "checkHigh02";
            this.checkHigh02.Size = new System.Drawing.Size(40, 20);
            this.checkHigh02.TabIndex = 2;
            this.checkHigh02.Text = "02";
            this.checkHigh02.CheckedChanged += new System.EventHandler(this.checkHigh02_CheckedChanged);
            // 
            // checkHigh03
            // 
            this.checkHigh03.Location = new System.Drawing.Point(148, 16);
            this.checkHigh03.Name = "checkHigh03";
            this.checkHigh03.Size = new System.Drawing.Size(40, 20);
            this.checkHigh03.TabIndex = 3;
            this.checkHigh03.Text = "03";
            this.checkHigh03.CheckedChanged += new System.EventHandler(this.checkHigh03_CheckedChanged);
            // 
            // checkHigh04
            // 
            this.checkHigh04.Location = new System.Drawing.Point(192, 16);
            this.checkHigh04.Name = "checkHigh04";
            this.checkHigh04.Size = new System.Drawing.Size(40, 20);
            this.checkHigh04.TabIndex = 4;
            this.checkHigh04.Text = "04";
            this.checkHigh04.CheckedChanged += new System.EventHandler(this.checkHigh04_CheckedChanged);
            // 
            // checkHigh05
            // 
            this.checkHigh05.Location = new System.Drawing.Point(236, 16);
            this.checkHigh05.Name = "checkHigh05";
            this.checkHigh05.Size = new System.Drawing.Size(40, 20);
            this.checkHigh05.TabIndex = 5;
            this.checkHigh05.Text = "05";
            this.checkHigh05.CheckedChanged += new System.EventHandler(this.checkHigh05_CheckedChanged);
            // 
            // checkHigh06
            // 
            this.checkHigh06.Location = new System.Drawing.Point(280, 16);
            this.checkHigh06.Name = "checkHigh06";
            this.checkHigh06.Size = new System.Drawing.Size(40, 20);
            this.checkHigh06.TabIndex = 6;
            this.checkHigh06.Text = "06";
            this.checkHigh06.CheckedChanged += new System.EventHandler(this.checkHigh06_CheckedChanged);
            // 
            // checkHigh07
            // 
            this.checkHigh07.Location = new System.Drawing.Point(324, 16);
            this.checkHigh07.Name = "checkHigh07";
            this.checkHigh07.Size = new System.Drawing.Size(40, 20);
            this.checkHigh07.TabIndex = 7;
            this.checkHigh07.Text = "07";
            this.checkHigh07.CheckedChanged += new System.EventHandler(this.checkHigh07_CheckedChanged);
            // 
            // checkHigh08
            // 
            this.checkHigh08.Location = new System.Drawing.Point(16, 40);
            this.checkHigh08.Name = "checkHigh08";
            this.checkHigh08.Size = new System.Drawing.Size(40, 20);
            this.checkHigh08.TabIndex = 8;
            this.checkHigh08.Text = "08";
            this.checkHigh08.CheckedChanged += new System.EventHandler(this.checkHigh08_CheckedChanged);
            // 
            // checkHigh09
            // 
            this.checkHigh09.Location = new System.Drawing.Point(60, 40);
            this.checkHigh09.Name = "checkHigh09";
            this.checkHigh09.Size = new System.Drawing.Size(40, 20);
            this.checkHigh09.TabIndex = 9;
            this.checkHigh09.Text = "09";
            this.checkHigh09.CheckedChanged += new System.EventHandler(this.checkHigh09_CheckedChanged);
            // 
            // checkHigh10
            // 
            this.checkHigh10.Location = new System.Drawing.Point(104, 40);
            this.checkHigh10.Name = "checkHigh10";
            this.checkHigh10.Size = new System.Drawing.Size(40, 20);
            this.checkHigh10.TabIndex = 10;
            this.checkHigh10.Text = "10";
            this.checkHigh10.CheckedChanged += new System.EventHandler(this.checkHigh10_CheckedChanged);
            // 
            // checkHigh11
            // 
            this.checkHigh11.Location = new System.Drawing.Point(148, 40);
            this.checkHigh11.Name = "checkHigh11";
            this.checkHigh11.Size = new System.Drawing.Size(40, 20);
            this.checkHigh11.TabIndex = 11;
            this.checkHigh11.Text = "11";
            this.checkHigh11.CheckedChanged += new System.EventHandler(this.checkHigh11_CheckedChanged);
            // 
            // checkHigh12
            // 
            this.checkHigh12.Location = new System.Drawing.Point(192, 40);
            this.checkHigh12.Name = "checkHigh12";
            this.checkHigh12.Size = new System.Drawing.Size(40, 20);
            this.checkHigh12.TabIndex = 12;
            this.checkHigh12.Text = "12";
            this.checkHigh12.CheckedChanged += new System.EventHandler(this.checkHigh12_CheckedChanged);
            // 
            // checkHigh13
            // 
            this.checkHigh13.Location = new System.Drawing.Point(236, 40);
            this.checkHigh13.Name = "checkHigh13";
            this.checkHigh13.Size = new System.Drawing.Size(40, 20);
            this.checkHigh13.TabIndex = 13;
            this.checkHigh13.Text = "13";
            this.checkHigh13.CheckedChanged += new System.EventHandler(this.checkHigh13_CheckedChanged);
            // 
            // checkHigh14
            // 
            this.checkHigh14.Location = new System.Drawing.Point(280, 40);
            this.checkHigh14.Name = "checkHigh14";
            this.checkHigh14.Size = new System.Drawing.Size(40, 20);
            this.checkHigh14.TabIndex = 14;
            this.checkHigh14.Text = "14";
            this.checkHigh14.CheckedChanged += new System.EventHandler(this.checkHigh14_CheckedChanged);
            // 
            // checkHigh15
            // 
            this.checkHigh15.Location = new System.Drawing.Point(324, 40);
            this.checkHigh15.Name = "checkHigh15";
            this.checkHigh15.Size = new System.Drawing.Size(40, 20);
            this.checkHigh15.TabIndex = 15;
            this.checkHigh15.Text = "15";
            this.checkHigh15.CheckedChanged += new System.EventHandler(this.checkHigh15_CheckedChanged);
            // 
            // groupLow
            // 
            this.groupLow.Controls.Add(this.checkLow00);
            this.groupLow.Controls.Add(this.checkLow01);
            this.groupLow.Controls.Add(this.checkLow02);
            this.groupLow.Controls.Add(this.checkLow03);
            this.groupLow.Controls.Add(this.checkLow04);
            this.groupLow.Controls.Add(this.checkLow05);
            this.groupLow.Controls.Add(this.checkLow06);
            this.groupLow.Controls.Add(this.checkLow07);
            this.groupLow.Controls.Add(this.checkLow08);
            this.groupLow.Controls.Add(this.checkLow09);
            this.groupLow.Controls.Add(this.checkLow10);
            this.groupLow.Controls.Add(this.checkLow11);
            this.groupLow.Controls.Add(this.checkLow12);
            this.groupLow.Controls.Add(this.checkLow13);
            this.groupLow.Controls.Add(this.checkLow14);
            this.groupLow.Controls.Add(this.checkLow15);
            this.groupLow.Location = new System.Drawing.Point(8, 176);
            this.groupLow.Name = "groupLow";
            this.groupLow.Size = new System.Drawing.Size(376, 64);
            this.groupLow.TabIndex = 16;
            this.groupLow.TabStop = false;
            this.groupLow.Text = "Low";
            // 
            // checkLow00
            // 
            this.checkLow00.Location = new System.Drawing.Point(16, 16);
            this.checkLow00.Name = "checkLow00";
            this.checkLow00.Size = new System.Drawing.Size(40, 20);
            this.checkLow00.TabIndex = 0;
            this.checkLow00.Text = "16";
            this.checkLow00.CheckedChanged += new System.EventHandler(this.checkLow00_CheckedChanged);
            // 
            // checkLow01
            // 
            this.checkLow01.Location = new System.Drawing.Point(60, 16);
            this.checkLow01.Name = "checkLow01";
            this.checkLow01.Size = new System.Drawing.Size(40, 20);
            this.checkLow01.TabIndex = 1;
            this.checkLow01.Text = "17";
            this.checkLow01.CheckedChanged += new System.EventHandler(this.checkLow01_CheckedChanged);
            // 
            // checkLow02
            // 
            this.checkLow02.Location = new System.Drawing.Point(104, 16);
            this.checkLow02.Name = "checkLow02";
            this.checkLow02.Size = new System.Drawing.Size(40, 20);
            this.checkLow02.TabIndex = 2;
            this.checkLow02.Text = "18";
            this.checkLow02.CheckedChanged += new System.EventHandler(this.checkLow02_CheckedChanged);
            // 
            // checkLow03
            // 
            this.checkLow03.Location = new System.Drawing.Point(148, 16);
            this.checkLow03.Name = "checkLow03";
            this.checkLow03.Size = new System.Drawing.Size(40, 20);
            this.checkLow03.TabIndex = 3;
            this.checkLow03.Text = "19";
            this.checkLow03.CheckedChanged += new System.EventHandler(this.checkLow03_CheckedChanged);
            // 
            // checkLow04
            // 
            this.checkLow04.Location = new System.Drawing.Point(192, 16);
            this.checkLow04.Name = "checkLow04";
            this.checkLow04.Size = new System.Drawing.Size(40, 20);
            this.checkLow04.TabIndex = 4;
            this.checkLow04.Text = "20";
            this.checkLow04.CheckedChanged += new System.EventHandler(this.checkLow04_CheckedChanged);
            // 
            // checkLow05
            // 
            this.checkLow05.Location = new System.Drawing.Point(236, 16);
            this.checkLow05.Name = "checkLow05";
            this.checkLow05.Size = new System.Drawing.Size(40, 20);
            this.checkLow05.TabIndex = 5;
            this.checkLow05.Text = "21";
            this.checkLow05.CheckedChanged += new System.EventHandler(this.checkLow05_CheckedChanged);
            // 
            // checkLow06
            // 
            this.checkLow06.Location = new System.Drawing.Point(280, 16);
            this.checkLow06.Name = "checkLow06";
            this.checkLow06.Size = new System.Drawing.Size(40, 20);
            this.checkLow06.TabIndex = 6;
            this.checkLow06.Text = "22";
            this.checkLow06.CheckedChanged += new System.EventHandler(this.checkLow06_CheckedChanged);
            // 
            // checkLow07
            // 
            this.checkLow07.Location = new System.Drawing.Point(324, 16);
            this.checkLow07.Name = "checkLow07";
            this.checkLow07.Size = new System.Drawing.Size(40, 20);
            this.checkLow07.TabIndex = 7;
            this.checkLow07.Text = "23";
            this.checkLow07.CheckedChanged += new System.EventHandler(this.checkLow07_CheckedChanged);
            // 
            // checkLow08
            // 
            this.checkLow08.Location = new System.Drawing.Point(16, 40);
            this.checkLow08.Name = "checkLow08";
            this.checkLow08.Size = new System.Drawing.Size(40, 20);
            this.checkLow08.TabIndex = 17;
            this.checkLow08.Text = "24";
            this.checkLow08.CheckedChanged += new System.EventHandler(this.checkLow08_CheckedChanged);
            // 
            // checkLow09
            // 
            this.checkLow09.Location = new System.Drawing.Point(60, 40);
            this.checkLow09.Name = "checkLow09";
            this.checkLow09.Size = new System.Drawing.Size(40, 20);
            this.checkLow09.TabIndex = 18;
            this.checkLow09.Text = "25";
            this.checkLow09.CheckedChanged += new System.EventHandler(this.checkLow09_CheckedChanged);
            // 
            // checkLow10
            // 
            this.checkLow10.Location = new System.Drawing.Point(104, 40);
            this.checkLow10.Name = "checkLow10";
            this.checkLow10.Size = new System.Drawing.Size(40, 20);
            this.checkLow10.TabIndex = 19;
            this.checkLow10.Text = "26";
            this.checkLow10.CheckedChanged += new System.EventHandler(this.checkLow10_CheckedChanged);
            // 
            // checkLow11
            // 
            this.checkLow11.Location = new System.Drawing.Point(148, 40);
            this.checkLow11.Name = "checkLow11";
            this.checkLow11.Size = new System.Drawing.Size(40, 20);
            this.checkLow11.TabIndex = 20;
            this.checkLow11.Text = "27";
            this.checkLow11.CheckedChanged += new System.EventHandler(this.checkLow11_CheckedChanged);
            // 
            // checkLow12
            // 
            this.checkLow12.Location = new System.Drawing.Point(192, 40);
            this.checkLow12.Name = "checkLow12";
            this.checkLow12.Size = new System.Drawing.Size(40, 20);
            this.checkLow12.TabIndex = 21;
            this.checkLow12.Text = "28";
            this.checkLow12.CheckedChanged += new System.EventHandler(this.checkLow12_CheckedChanged);
            // 
            // checkLow13
            // 
            this.checkLow13.Location = new System.Drawing.Point(236, 40);
            this.checkLow13.Name = "checkLow13";
            this.checkLow13.Size = new System.Drawing.Size(40, 20);
            this.checkLow13.TabIndex = 22;
            this.checkLow13.Text = "29";
            this.checkLow13.CheckedChanged += new System.EventHandler(this.checkLow13_CheckedChanged);
            // 
            // checkLow14
            // 
            this.checkLow14.Location = new System.Drawing.Point(280, 40);
            this.checkLow14.Name = "checkLow14";
            this.checkLow14.Size = new System.Drawing.Size(40, 20);
            this.checkLow14.TabIndex = 23;
            this.checkLow14.Text = "30";
            this.checkLow14.CheckedChanged += new System.EventHandler(this.checkLow14_CheckedChanged);
            // 
            // checkLow15
            // 
            this.checkLow15.Location = new System.Drawing.Point(324, 40);
            this.checkLow15.Name = "checkLow15";
            this.checkLow15.Size = new System.Drawing.Size(40, 20);
            this.checkLow15.TabIndex = 24;
            this.checkLow15.Text = "31";
            this.checkLow15.CheckedChanged += new System.EventHandler(this.checkLow15_CheckedChanged);
            // 
            // textInterrupt
            // 
            this.textInterrupt.Location = new System.Drawing.Point(8, 248);
            this.textInterrupt.Multiline = true;
            this.textInterrupt.Name = "textInterrupt";
            this.textInterrupt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInterrupt.Size = new System.Drawing.Size(376, 82);
            this.textInterrupt.TabIndex = 25;
            // 
            // buttonClear
            // 
            this.buttonClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClear.Location = new System.Drawing.Point(12, 336);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 24);
            this.buttonClear.TabIndex = 26;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(284, 336);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 24);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Exit";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timerSensor
            // 
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // FormDigitalIO
            // 
            this.ClientSize = new System.Drawing.Size(392, 368);
            this.Controls.Add(this.labelModule);
            this.Controls.Add(this.comboModule);
            this.Controls.Add(this.checkInterrupt);
            this.Controls.Add(this.checkRigingEdge);
            this.Controls.Add(this.checkFallingEdge);
            this.Controls.Add(this.groupInterruptType);
            this.Controls.Add(this.groupHigh);
            this.Controls.Add(this.groupLow);
            this.Controls.Add(this.textInterrupt);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDigitalIO";
            this.Text = "DigitalIO";
            this.Load += new System.EventHandler(this.FormDigitalIO_Load);
            this.Closed += new System.EventHandler(this.windowCancel_Click);
            this.groupInterruptType.ResumeLayout(false);
            this.groupHigh.ResumeLayout(false);
            this.groupLow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormDigitalIO());
		}

		// is selected OCX

		private CheckBox[]	checkHigh = new CheckBox[16];
		private CheckBox[]	checkLow = new CheckBox[16];
		private	uint		hInterrupt = 0;
		private	Thread		EventThread = null;
		private	bool		bThread = false;
		static public FormDigitalIO	frmDigitalIO;

		public readonly static uint	INFINITE				= 0xFFFFFFFF;
		public readonly static uint	STATUS_WAIT_0			= 0x00000000;
		public readonly static uint	WAIT_OBJECT_0			= ((STATUS_WAIT_0 ) + 0 );
		[DllImport("kernel32",EntryPoint="WaitForSingleObject", SetLastError=true, CharSet = CharSet.Unicode)]
		private static extern uint WaitForSingleObject(uint hHandle, uint dwMilliseconds);

        [DllImport("KERNEL32", EntryPoint="SetEvent", SetLastError=true, CharSet = CharSet.Unicode)]
        private static extern bool SetEvent(long hEvent);

		private void FormDigitalIO_Load(object sender, System.EventArgs e)
		{
			checkHigh[00]	= checkHigh00;
			checkHigh[01]	= checkHigh01;
			checkHigh[02]	= checkHigh02;
			checkHigh[03]	= checkHigh03;
			checkHigh[04]	= checkHigh04;
			checkHigh[05]	= checkHigh05;
			checkHigh[06]	= checkHigh06;
			checkHigh[07]	= checkHigh07;
			checkHigh[08]	= checkHigh08;
			checkHigh[09]	= checkHigh09;
			checkHigh[10]	= checkHigh10;
			checkHigh[11]	= checkHigh11;
			checkHigh[12]	= checkHigh12;
			checkHigh[13]	= checkHigh13;
			checkHigh[14]	= checkHigh14;
			checkHigh[15]	= checkHigh15;

			checkLow[00]	= checkLow00;
			checkLow[01]	= checkLow01;
			checkLow[02]	= checkLow02;
			checkLow[03]	= checkLow03;
			checkLow[04]	= checkLow04;
			checkLow[05]	= checkLow05;
			checkLow[06]	= checkLow06;
			checkLow[07]	= checkLow07;
			checkLow[08]	= checkLow08;
			checkLow[09]	= checkLow09;
			checkLow[10]	= checkLow10;
			checkLow[11]	= checkLow11;
			checkLow[12]	= checkLow12;
			checkLow[13]	= checkLow13;
			checkLow[14]	= checkLow14;
			checkLow[15]	= checkLow15;

			if (OpenDevice())
			{
				radioMessage.Checked	= true;
				timerSensor.Enabled		= true;
				frmDigitalIO			= this;
			}
            CheckForIllegalCrossThreadCalls = false;
		}

		private bool OpenDevice()
		{
			//++
			// Initialize library 
            uint uRetCode = (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            uRetCode = CAXL.AxlOpen(7);
            if (uRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
			{
				uint	uStatus = 0;

				if (CAXD.AxdInfoIsDIOModule(ref uStatus) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
				{
					if ((AXT_EXISTENCE)uStatus == AXT_EXISTENCE.STATUS_EXIST)
					{
						int	nModuleCount = 0;

						if (CAXD.AxdInfoGetModuleCount(ref nModuleCount) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
						{
							short	i = 0;
							int		nBoardNo = 0;
							int		nModulePos = 0;
							uint	uModuleID = 0;
							string	strData = "";

							for (i = 0; i < nModuleCount; i++)
							{
								if (CAXD.AxdInfoGetModule(i, ref nBoardNo, ref nModulePos, ref uModuleID) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
								{
									switch ((AXT_MODULE)uModuleID)
									{
										case AXT_MODULE.AXT_SIO_DI32:			strData	= String.Format("[{0:D2}:{1:D2}] SIO-DI32", nBoardNo, i);		     break;
										case AXT_MODULE.AXT_SIO_DO32P:      	strData	= String.Format("[{0:D2}:{1:D2}] SIO-DO32P", nBoardNo, i);		     break;
                                        case AXT_MODULE.AXT_SIO_DB32P:			strData	= String.Format("[{0:D2}:{1:D2}] SIO-DB32P", nBoardNo, i);		     break;
                                        case AXT_MODULE.AXT_SIO_DO32T:			strData	= String.Format("[{0:D2}:{1:D2}] SIO-DO32T", nBoardNo, i);		     break;
										case AXT_MODULE.AXT_SIO_DB32T:			strData	= String.Format("[{0:D2}:{1:D2}] SIO-DB32T", nBoardNo, i);   		 break;
                                        case AXT_MODULE.AXT_SIO_RDI32:          strData = String.Format("[{0:D2}:{1:D2}] SIO_RDI32", nBoardNo, i);           break;
                                        case AXT_MODULE.AXT_SIO_RDO32:          strData = String.Format("[{0:D2}:{1:D2}] SIO_RDO32", nBoardNo, i);           break;
                                        case AXT_MODULE.AXT_SIO_RDB128MLII:     strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB128MLII", nBoardNo, i);      break;
                                        case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII:  strData = String.Format("[{0:D2}:{1:D2}] SIO-RSIMPLEIOMLII", nBoardNo, i);   break;
                                        case AXT_MODULE.AXT_SIO_RDO16AMLII:     strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO16AMLII", nBoardNo, i);      break;
                                        case AXT_MODULE.AXT_SIO_RDO16BMLII:     strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO16BMLII", nBoardNo, i);      break;
                                        case AXT_MODULE.AXT_SIO_RDB96MLII:      strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB96MLII", nBoardNo, i);       break;
                                        case AXT_MODULE.AXT_SIO_RDO32RTEX:      strData = String.Format("[{0:D2}:{1:D2}] SIO-RDO32RTEX", nBoardNo, i);       break;
                                        case AXT_MODULE.AXT_SIO_RDI32RTEX:      strData = String.Format("[{0:D2}:{1:D2}] SIO-RDI32RTEX", nBoardNo, i);       break;
                                        case AXT_MODULE.AXT_SIO_RDB32RTEX:      strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB32RTEX", nBoardNo, i);       break;
                                        case AXT_MODULE.AXT_SIO_DI32_P:         strData = String.Format("[{0:D2}:{1:D2}] SIO-DI32_P", nBoardNo, i);          break;
                                        case AXT_MODULE.AXT_SIO_DO32T_P:        strData = String.Format("[{0:D2}:{1:D2}] SIO-DO32T_P", nBoardNo, i);         break;
                                        case AXT_MODULE.AXT_SIO_RDB32T:         strData = String.Format("[{0:D2}:{1:D2}] SIO-RDB32T", nBoardNo, i);          break;
                                        case AXT_MODULE.AXT_ECAT_DIO:
                                            uint uModuleSubID = 0;
                                            var szModuleName = new System.Text.StringBuilder(50);
                                            var szModuleDesc = new System.Text.StringBuilder(80);
                                            CAXD.AxdInfoGetModuleEx(i, ref uModuleSubID, szModuleName, szModuleDesc);
                                            strData = String.Format("[{0:D2}:{1:D2}] {2}",nBoardNo, i, szModuleName);
                                            break;
                                        default:
                                            strData = String.Format("[{0:D2}:{1:D2}] Unknown", nBoardNo, i);
                                            break;
                                    }
									comboModule.Items.Add(strData);
								}
							}

							comboModule.SelectedIndex	= 0;
						}
					}
					else
					{
						MessageBox.Show("Module not exist.");

						return	false;
					}
				}
			}
			else
			{
				MessageBox.Show("Open Error!");
			}

			return true;
		}

		private bool SelectModule()
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
				short	nIndex = 0;
				uint	uDataHigh = 0;
				uint	uDataLow = 0;
				uint	uFlagHigh = 0;
				uint	uFlagLow = 0;
				uint	uUse = 0;
                int     nInCount = 0, nOutCount = 0;

				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
					case AXT_MODULE.AXT_SIO_DI32:
                    case AXT_MODULE.AXT_SIO_RDI32:
                    case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII:
                    case AXT_MODULE.AXT_SIO_RDO16AMLII:
                    case AXT_MODULE.AXT_SIO_RDO16BMLII:
                    case AXT_MODULE.AXT_SIO_DI32_P:
                    case AXT_MODULE.AXT_SIO_RDI32RTEX:
                        groupHigh.Text = "INPUT  0bit ~ 15Bit";
                        groupLow.Text = "INPUT 16bit ~ 31Bit";

                        if(((AXT_MODULE)uModuleID) == AXT_MODULE.AXT_SIO_RDI32)
                        {
						    checkInterrupt.Checked		= false;
                            radioCallback.Enabled = false;
                            radioMessage.Enabled = false;
                            radioEvent.Enabled = false;
						    checkRigingEdge.Checked		= false;
						    checkFallingEdge.Checked	= false;
                        }
                        else
                        {
                            checkInterrupt.Checked = true;
                            radioCallback.Enabled = true;
                            radioMessage.Enabled = true;
                            radioEvent.Enabled = true;
                            checkRigingEdge.Checked = true;
                            checkFallingEdge.Checked = true;
                            
                            CAXD.AxdiInterruptGetModuleEnable(comboModule.SelectedIndex, ref uUse);
						    if (uUse == (uint)AXT_USE.ENABLE)
						    {
							    checkInterrupt.Checked	= true;
							    SelectMessage();
						    }
						    else
							    checkInterrupt.Checked	= false;

						    CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, ref uDataHigh);
						    CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.UP_EDGE, ref uDataLow);
						    if (uDataHigh == 0xFFFF && uDataLow == 0xFFFF)
							    checkRigingEdge.Checked		= true;
						    else
							    checkRigingEdge.Checked		= false;

						    CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, ref uDataHigh);
						    CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.DOWN_EDGE, ref uDataLow);
						    if (uDataHigh == 0xFFFF && uDataLow == 0xFFFF)
							    checkFallingEdge.Checked	= true;
						    else
							    checkFallingEdge.Checked	= false;
                        }

                        for (nIndex = 0; nIndex < 16; nIndex++)
                        {
                            checkHigh[nIndex].Text = String.Format("{0:D2}", nIndex);
                            checkLow[nIndex].Text = String.Format("{0:D2}", nIndex + 16);
                        }
						break;

					case AXT_MODULE.AXT_SIO_DO32P:
					case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDO32:
                    case AXT_MODULE.AXT_SIO_DO32T_P:
                    case AXT_MODULE.AXT_SIO_RDO32RTEX:
                        groupHigh.Text = "OUTPUT  0bit ~ 15Bit";
                        groupLow.Text = "OUTPUT 16bit ~ 31Bit";

						checkInterrupt.Checked		= false;
                        radioCallback.Enabled = false;
                        radioMessage.Enabled = false;
                        radioEvent.Enabled = false;
						checkRigingEdge.Checked		= false;
						checkFallingEdge.Checked	= false;

						//++
						// Read outputting signal in WORD
						CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 0, ref uDataHigh);
						CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 1, ref uDataLow);

						for (nIndex = 0; nIndex < 16; nIndex++)
						{
							// Verify the last bit value of data read
							uFlagHigh	= uDataHigh & 0x0001;
							uFlagLow	= uDataLow & 0x0001;
				
							// Shift rightward by bit by bit
							uDataHigh	= uDataHigh >> 1;
							uDataLow	= uDataLow >> 1;

							// Updat bit value in control
							if (uFlagHigh == 1)
								checkHigh[nIndex].Checked	= true;
							else
								checkHigh[nIndex].Checked	= false;

							if (uFlagLow == 1)
								checkLow[nIndex].Checked	= true;
							else
								checkLow[nIndex].Checked	= false;

                            checkHigh[nIndex].Text = String.Format("{0:D2}", nIndex);
                            checkLow[nIndex].Text = String.Format("{0:D2}", nIndex + 16);
                        }
						break;

					case AXT_MODULE.AXT_SIO_DB32P:
					case AXT_MODULE.AXT_SIO_DB32T:
                    case AXT_MODULE.AXT_SIO_RDB128MLII:
                    case AXT_MODULE.AXT_SIO_RDB32T:
                    case AXT_MODULE.AXT_SIO_RDB32RTEX:
                    case AXT_MODULE.AXT_SIO_RDB96MLII:
                        groupHigh.Text = "INPUT  0bit ~ 15Bit";
                        groupLow.Text = "OUTPUT  0bit ~ 15Bit";

                        // Only Digital Input was used
                        checkInterrupt.Enabled = true;
                        checkRigingEdge.Enabled = true;
                        checkFallingEdge.Enabled = true;

						CAXD.AxdiInterruptGetModuleEnable(comboModule.SelectedIndex, ref uUse);
						if (uUse == (uint)AXT_USE.ENABLE)
						{
							checkInterrupt.Checked		= true;
							SelectMessage();
						}
						else
							checkInterrupt.Checked		= false;

						CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, ref uDataHigh);
						if (uDataHigh == 0xFFFF)
							checkRigingEdge.Checked		= true;
						else
							checkRigingEdge.Checked		= false;

						CAXD.AxdiInterruptEdgeGetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, ref uDataHigh);
						if (uDataHigh == 0xFFFF)
							checkFallingEdge.Checked	= true;
						else
							checkFallingEdge.Checked	= false;

						//++
						// Read outputting signal in WORD
						CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 0, ref uDataLow);

						for (nIndex = 0; nIndex < 16; nIndex++)
						{
							// Verify the last bit value of data read
							uFlagLow	= uDataLow & 0x0001;
				
							// Shift rightward by bit by bit
							uDataLow	= uDataLow >> 1;

							// Updat bit value in control
							if (uFlagLow == 1)
								checkLow[nIndex].Checked	= true;
							else
								checkLow[nIndex].Checked	= false;

                            checkHigh[nIndex].Text = String.Format("{0:D2}", nIndex);
                            checkLow[nIndex].Text = String.Format("{0:D2}", nIndex);
                        }
						break;

                    case AXT_MODULE.AXT_ECAT_DIO:
                        CAXD.AxdInfoGetInputCount(comboModule.SelectedIndex, ref nInCount);
                        CAXD.AxdInfoGetOutputCount(comboModule.SelectedIndex, ref nOutCount);

                        if (nInCount > 16)
                        {
                            groupHigh.Text = "INPUT  0bit ~ 15Bit";
                            groupLow.Text  = "INPUT 16bit ~ 31Bit";

                            for (nIndex = 0; nIndex < 16; nIndex++)
                            {
                                checkLow[nIndex].Enabled = false;
                                checkLow[nIndex].Text = String.Format("{0:D2}", nIndex+16);
                            }
                            for (nIndex = 0; nIndex < 16; nIndex++)
                            {
                                checkHigh[nIndex].Enabled = false;
                            }
                        }
                        else if (nInCount > 0)
                        {
                            groupHigh.Text = "INPUT  0bit ~ 15Bit";
                            for (nIndex = 0; nIndex < 16; nIndex++)
                            {
                                checkHigh[nIndex].Enabled = false;
                            }

                            if (nOutCount > 0)
                            {
                                groupLow.Text = "OUTPUT  0bit ~ 15Bit";

                                CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 0, ref uDataLow);
                                for (nIndex = 0; nIndex < 16; nIndex++)
                                {
                                    checkLow[nIndex].Enabled = true;
                                    checkLow[nIndex].Text = String.Format("{0:D2}", nIndex);
                                }
                            }
                            else
                            {
                                groupLow.Text = "";
                            }
                        }
                        else
                        {
                            if (nOutCount > 16)
                            {
                                groupHigh.Text = "OUTPUT  0bit ~ 15Bit";
                                groupLow.Text = "OUTPUT 16bit ~ 31Bit";

                                CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 0, ref uDataHigh);
                                CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 1, ref uDataLow);

                                for (nIndex = 0; nIndex < 16; nIndex++)
                                {
                                    checkHigh[nIndex].Enabled = true;
                                }
                                                                
                                for (nIndex = 0; nIndex < 16; nIndex++)
                                {                                    
                                    checkLow[nIndex].Enabled = true;
                                    checkLow[nIndex].Text = String.Format("{0:D2}", nIndex + 16);
                                }
                            }
                            else if(nOutCount > 0)
                            {
                                groupHigh.Text = "OUTPUT  0bit ~ 15Bit";
                                groupLow.Text = "";
                                CAXD.AxdoReadOutportWord(comboModule.SelectedIndex, 0, ref uDataHigh);

                                for (nIndex = 0; nIndex < 16; nIndex++)
                                {
                                    checkHigh[nIndex].Enabled = true;
                                }
                            }
                        }

                        radioCallback.Enabled = false;
                        radioMessage.Enabled = false;
                        radioEvent.Enabled = false;

                        // Only Digital Input was used
                        checkInterrupt.Enabled = false;
                        checkRigingEdge.Enabled = false;
                        checkFallingEdge.Enabled = false;

						checkInterrupt.Checked		= false;
                        checkRigingEdge.Checked		= false;
                        checkFallingEdge.Checked	= false;

						for (nIndex = 0; nIndex < 16; nIndex++)
						{
							// Verify the last bit value of data read
                            uFlagHigh = uDataHigh & 0x0001;
							uFlagLow  = uDataLow  & 0x0001;
				
							// Shift rightward by bit by bit
                            uDataHigh = uDataHigh >> 1;
							uDataLow  = uDataLow  >> 1;

							// Updat bit value in control
							if (uFlagLow == 1)
								checkLow[nIndex].Checked	= true;
							else
								checkLow[nIndex].Checked	= false;
                            if (nOutCount > 16)
                            {
                                if (uFlagHigh == 1)
                                    checkHigh[nIndex].Checked = true;
                                else
                                    checkHigh[nIndex].Checked = false;
                            }
                        }
                        break;
				}
			}

			return true;
		}

		private bool InterruptProc(AXT_INTERRUPT_CLASS uClass, int nModuleNo, uint uFlag)
		{
			int		i = 0;
			int		j = 0;
			uint	uValue = 0;
			string	strClass = "";
			string	strInt = "";

			switch (uClass)
			{
			case AXT_INTERRUPT_CLASS.KIND_MESSAGE:
				strClass	= "Message";
				break;

			case AXT_INTERRUPT_CLASS.KIND_CALLBACK:
				strClass	= "Callback";
				break;

			case AXT_INTERRUPT_CLASS.KIND_EVENT:
				strClass	= "Event";
				break;
			}
            
			for (i = 0; i < 4; i++)
			{
				for (j = 0; j < 8; j++)
				{
					if ((((uFlag >> (i * 8)) >> j) & 0x01) == 0x01)
					{
						CAXD.AxdiReadInportBit(nModuleNo, ((i * 8)+ j), ref uValue);

						if (uValue == 0x01)
							strInt	= String.Format("{0:s} : Rising Int Set Bit {1:X2}", strClass, (i * 8)+ j);
						else
							strInt	= String.Format("{0:s} : Falling Int Set Bit {1:X2}", strClass, (i * 8)+ j);

                        
                        if (textInterrupt.TextLength == 0)
                            textInterrupt.Text += strInt;
                        else
                            textInterrupt.Text += "\r\n" + strInt;
                     
                        
						textInterrupt.SelectionStart	= textInterrupt.TextLength;
						textInterrupt.ScrollToCaret();	
                       
					}
				}
			}
           
			return true;
		}

		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				case (int)AXT_EVENT.WM_AXL_INTERRUPT:
					InterruptProc(AXT_INTERRUPT_CLASS.KIND_MESSAGE, (int)m.WParam, (uint)m.LParam);
					break;
			}

			base.WndProc (ref m);
		}

		private bool SelectMessage()
		{
			uint	pEvent = 0;

			if (EventThread != null)
			{
                bThread = false;
                SetEvent(hInterrupt);
				EventThread.Abort();
				EventThread	= null;
			}
			CAXD.AxdiInterruptSetModule(comboModule.SelectedIndex, this.Handle, (uint)AXT_EVENT.WM_AXL_INTERRUPT, null, ref pEvent);

			return true;
		}
      
		public static void InterruptCallback(int nModuleNo, uint uFlag)
		{
			frmDigitalIO.InterruptProc(AXT_INTERRUPT_CLASS.KIND_CALLBACK, nModuleNo, uFlag);
		}

		private void ThreadProc()
		{
			while(bThread)
			{
				if (WaitForSingleObject(hInterrupt, INFINITE) == WAIT_OBJECT_0)
				{
					int		nModuleNo = 0;
					uint	uFlag = 0;
					CAXD.AxdiInterruptRead(ref nModuleNo, ref uFlag);
                    frmDigitalIO.InterruptProc(AXT_INTERRUPT_CLASS.KIND_EVENT, nModuleNo, uFlag);
				}
			}
            EventThread = null;
		}

		private bool SelectCallback()
        {
            uint	pEvent = 0;

            if (EventThread != null)
            {
                EventThread.Abort();
                EventThread	= null;
                bThread		= false;
            }

            CAXD.AxdiInterruptSetModule(comboModule.SelectedIndex, (IntPtr)null, 0, Callbackfunction, ref pEvent);

            return true;
        }
        

		private bool SelectEvent()
		{
            CAXD.AxdiInterruptSetModule(comboModule.SelectedIndex, (IntPtr)null, 0, null, ref hInterrupt);

			if (EventThread != null)
			{
				EventThread.Abort();
				EventThread	= null;
				bThread		= false;
			}

			if (!bThread)
			{
				bThread		= true;
				EventThread	= new Thread(new ThreadStart(this.ThreadProc));
				EventThread.Start();
			}

			return true;
		}

		private bool SelectHighIndex(int nIndex, uint uValue)
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
                int     nOutCount = 0;

				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
					case AXT_MODULE.AXT_SIO_DO32P:
					case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDO32:
						CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex, uValue);
						break;

                    case AXT_MODULE.AXT_ECAT_DIO:
                        CAXD.AxdInfoGetOutputCount(comboModule.SelectedIndex, ref nOutCount);
                        if (nOutCount > 16)
                        {
                            CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex, uValue);
                        }
                        break;

					default:
						return false;
				}
			}

			return true;
		}

		private bool SelectLowIndex(int nIndex, uint uValue)
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
                int     nOutCount = 0;

				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
                    case AXT_MODULE.AXT_SIO_DO32P:
                    case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDO32:
                        CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex+16, uValue);
                        break;
					case AXT_MODULE.AXT_SIO_DB32P:
					case AXT_MODULE.AXT_SIO_DB32T:
                    case AXT_MODULE.AXT_SIO_RDB128MLII:
                        CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex, uValue);
						break;

                    case AXT_MODULE.AXT_ECAT_DIO:
                        CAXD.AxdInfoGetOutputCount(comboModule.SelectedIndex, ref nOutCount);
                        if (nOutCount > 16)
                        {
                            CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex+16, uValue);
                        } else if (nOutCount > 0)
                        {
                            CAXD.AxdoWriteOutportBit(comboModule.SelectedIndex, nIndex, uValue);
                        }
                        break;

					default:
						return false;
				}
			}

			return true;
		}

		private void CloseWindow()
		{
			if (EventThread != null)
			{
                bThread = false; 
                SetEvent(hInterrupt);
                EventThread.Abort();
				EventThread	= null;
				
			}

			CAXL.AxlClose();
		}

		private void timerSensor_Tick(object sender, System.EventArgs e)
		{
			short		nIndex = 0;
			uint		uDataHigh = 0;
			uint		uDataLow = 0;
			uint		uFlagHigh = 0;
			uint		uFlagLow = 0;
			int			nBoardNo = 0;
			int			nModulePos = 0;
			uint		uModuleID = 0;
            int         nInCount = 0;

			CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

			switch ((AXT_MODULE)uModuleID)
			{
				case AXT_MODULE.AXT_SIO_DI32:
                case AXT_MODULE.AXT_SIO_RDI32:
                case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII:
                case AXT_MODULE.AXT_SIO_RDO16AMLII:
                case AXT_MODULE.AXT_SIO_RDO16BMLII:
                case AXT_MODULE.AXT_SIO_DI32_P:
                case AXT_MODULE.AXT_SIO_RDI32RTEX:
					//++
					// Read inputting signal in WORD
					CAXD.AxdiReadInportWord(comboModule.SelectedIndex, 0, ref uDataHigh);
					CAXD.AxdiReadInportWord(comboModule.SelectedIndex, 1, ref uDataLow);

					for (nIndex = 0; nIndex < 16; nIndex++)
					{
						// Verify the last bit value of data read
						uFlagHigh	= uDataHigh & 0x0001;
						uFlagLow	= uDataLow & 0x0001;
					
						// Shift rightward by bit by bit
						uDataHigh	= uDataHigh >> 1;
						uDataLow	= uDataLow >> 1;

						// Updat bit value in control
						if (uFlagHigh == 1)
							checkHigh[nIndex].Checked	= true;
						else
							checkHigh[nIndex].Checked	= false;

						if (uFlagLow == 1)
							checkLow[nIndex].Checked	= true;
						else
							checkLow[nIndex].Checked	= false;
					}
					break;

				case AXT_MODULE.AXT_SIO_DB32P:
				case AXT_MODULE.AXT_SIO_DB32T:
                case AXT_MODULE.AXT_SIO_RDB32T:
                case AXT_MODULE.AXT_SIO_RDB32RTEX:
                case AXT_MODULE.AXT_SIO_RDB96MLII:
                case AXT_MODULE.AXT_SIO_RDB128MLII:
					//++
					// Read inputting signal in WORD
					CAXD.AxdiReadInportWord(comboModule.SelectedIndex, 0, ref uDataHigh);

					for (nIndex = 0; nIndex < 16; nIndex++)
					{
						// Verify the last bit value of data read
						uFlagHigh	= uDataHigh & 0x0001;

						// Shift rightward by bit by bit
						uDataHigh	= uDataHigh >> 1;

						// Updat bit value in control
						if (uFlagHigh == 1)
							checkHigh[nIndex].Checked	= true;
						else
							checkHigh[nIndex].Checked	= false;
					}
					break;

                case AXT_MODULE.AXT_ECAT_DIO:
                    CAXD.AxdInfoGetInputCount(comboModule.SelectedIndex, ref nInCount);
                    if (nInCount > 0)
                    {
                        CAXD.AxdiReadInportWord(comboModule.SelectedIndex, 0, ref uDataHigh);
                        CAXD.AxdiReadInportWord(comboModule.SelectedIndex, 1, ref uDataLow);

                        for (nIndex = 0; nIndex < 16; nIndex++)
                        {
                            // Verify the last bit value of data read
                            uFlagHigh = uDataHigh & 0x0001;
                            uFlagLow  = uDataLow  & 0x0001;

                            // Shift rightward by bit by bit
                            uDataHigh = uDataHigh >> 1;
                            uDataLow  = uDataLow  >> 1;

                            // Updat bit value in control
                            if (uFlagHigh == 1)
                                checkHigh[nIndex].Checked = true;
                            else
                                checkHigh[nIndex].Checked = false;
                            if (nInCount > 16)
                            {
                                if (uFlagLow == 1)
                                    checkLow[nIndex].Checked = true;
                                else
                                    checkLow[nIndex].Checked = false;
                            }
                        }
                    }
                    break;
			}
		}

		private void comboModule_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectModule();
		}

		private void checkInterrupt_CheckedChanged(object sender, System.EventArgs e)
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
		
				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
					case AXT_MODULE.AXT_SIO_DI32:
					case AXT_MODULE.AXT_SIO_DB32P:
					case AXT_MODULE.AXT_SIO_DB32T:
						if (checkInterrupt.Checked)
						{
							CAXL.AxlInterruptEnable();
							CAXD.AxdiInterruptSetModuleEnable(comboModule.SelectedIndex, (uint)AXT_USE.ENABLE);
						}
						else
						{
							IntPtr	pEvent = (IntPtr)0;

                                 
							CAXD.AxdiInterruptSetModuleEnable(comboModule.SelectedIndex, (uint)AXT_USE.DISABLE);
							CAXL.AxlInterruptDisable();
						}
						break;

					case AXT_MODULE.AXT_SIO_DO32P:
					case AXT_MODULE.AXT_SIO_DO32T:
                    case AXT_MODULE.AXT_SIO_RDB128MLII:
                    case AXT_MODULE.AXT_SIO_RSIMPLEIOMLII:
                    case AXT_MODULE.AXT_SIO_RDO16AMLII:
                    case AXT_MODULE.AXT_SIO_RDO16BMLII:
                    case AXT_MODULE.AXT_SIO_DI32_P:
                    case AXT_MODULE.AXT_SIO_RDI32RTEX:
                    case AXT_MODULE.AXT_SIO_DO32T_P:
                    case AXT_MODULE.AXT_SIO_RDO32RTEX:
                    case AXT_MODULE.AXT_SIO_RDB32T:
                    case AXT_MODULE.AXT_SIO_RDB32RTEX:
                    case AXT_MODULE.AXT_SIO_RDB96MLII:
						checkInterrupt.Checked	= false;
						break;
				}	
			}
    	}

		private void checkRigingEdge_CheckedChanged(object sender, System.EventArgs e)
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
		
				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
					case AXT_MODULE.AXT_SIO_DI32:
						if (checkRigingEdge.Checked)
						{
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, 0xFFFF);
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.UP_EDGE, 0xFFFF);
						}
						else
						{
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, 0x0000);
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.UP_EDGE, 0x0000);
						}
						break;

					case AXT_MODULE.AXT_SIO_DB32P:
					case AXT_MODULE.AXT_SIO_DB32T:
						if (checkRigingEdge.Checked)
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, 0xFFFF);
						else
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.UP_EDGE, 0x0000);
						break;
				}	
			}
		}

		private void checkFallingEdge_CheckedChanged(object sender, System.EventArgs e)
		{
			int	nModuleCount = 0;

			CAXD.AxdInfoGetModuleCount(ref nModuleCount);

			if (nModuleCount > 0)
			{
				int		nBoardNo = 0;
				int		nModulePos = 0;
				uint	uModuleID = 0;
		
				CAXD.AxdInfoGetModule(comboModule.SelectedIndex, ref nBoardNo, ref nModulePos, ref uModuleID);

				switch ((AXT_MODULE)uModuleID)
				{
					case AXT_MODULE.AXT_SIO_DI32:
						if (checkFallingEdge.Checked)
						{
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0xFFFF);
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0xFFFF);
						}
						else
						{
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0x0000);
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 1, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0x0000);
						}
						break;

					case AXT_MODULE.AXT_SIO_DB32P:
					case AXT_MODULE.AXT_SIO_DB32T:
                        if (checkFallingEdge.Checked)
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0xFFFF);
						else
							CAXD.AxdiInterruptEdgeSetWord(comboModule.SelectedIndex, 0, (uint)AXT_DIO_EDGE.DOWN_EDGE, 0x0000);
						break;
				}	
			}
		}
		
		private void radioMessage_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioMessage.Checked)
				SelectMessage();
		}

		private void radioCallback_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioCallback.Checked)
				SelectCallback();
		}

		private void radioEvent_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioEvent.Checked)
				SelectEvent();
		}

		private void checkHigh00_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(0, (uint)checkHigh[00].CheckState);
		}

		private void checkHigh01_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(1, (uint)checkHigh[01].CheckState);
		}

		private void checkHigh02_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(2, (uint)checkHigh[02].CheckState);
		}

		private void checkHigh03_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(3, (uint)checkHigh[03].CheckState);
		}

		private void checkHigh04_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(4, (uint)checkHigh[04].CheckState);
		}

		private void checkHigh05_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(5, (uint)checkHigh[05].CheckState);
		}

		private void checkHigh06_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(6, (uint)checkHigh[06].CheckState);
		}

		private void checkHigh07_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(7, (uint)checkHigh[07].CheckState);
		}

		private void checkHigh08_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(8, (uint)checkHigh[08].CheckState);
		}

		private void checkHigh09_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(9, (uint)checkHigh[09].CheckState);
		}

		private void checkHigh10_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(10, (uint)checkHigh[10].CheckState);
		}

		private void checkHigh11_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(11, (uint)checkHigh[11].CheckState);
		}

		private void checkHigh12_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(12, (uint)checkHigh[12].CheckState);
		}

		private void checkHigh13_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(13, (uint)checkHigh[13].CheckState);
		}

		private void checkHigh14_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(14, (uint)checkHigh[14].CheckState);
		}

		private void checkHigh15_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectHighIndex(15, (uint)checkHigh[15].CheckState);		
		}

		private void checkLow00_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(0, (uint)checkLow[00].CheckState);
		}

		private void checkLow01_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(1, (uint)checkLow[01].CheckState);
		}

		private void checkLow02_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(2, (uint)checkLow[02].CheckState);
		}

		private void checkLow03_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(3, (uint)checkLow[03].CheckState);
		}

		private void checkLow04_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(4, (uint)checkLow[04].CheckState);
		}

		private void checkLow05_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(5, (uint)checkLow[05].CheckState);
		}

		private void checkLow06_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(6, (uint)checkLow[06].CheckState);
		}

		private void checkLow07_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(7, (uint)checkLow[07].CheckState);
		}

		private void checkLow08_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(8, (uint)checkLow[08].CheckState);
		}

		private void checkLow09_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(9, (uint)checkLow[09].CheckState);
		}

		private void checkLow10_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(10, (uint)checkLow[10].CheckState);
		}

		private void checkLow11_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(11, (uint)checkLow[11].CheckState);
		}

		private void checkLow12_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(12, (uint)checkLow[12].CheckState);
		}

		private void checkLow13_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(13, (uint)checkLow[13].CheckState);
		}

		private void checkLow14_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(14, (uint)checkLow[14].CheckState);
		}

		private void checkLow15_CheckedChanged(object sender, System.EventArgs e)
		{
			SelectLowIndex(15, (uint)checkLow[15].CheckState);		
		}

		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			textInterrupt.ResetText();
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			CloseWindow();
			this.Close();
		}

		private void windowCancel_Click(object sender, System.EventArgs e)
		{
			CloseWindow();
		}
	}
}
