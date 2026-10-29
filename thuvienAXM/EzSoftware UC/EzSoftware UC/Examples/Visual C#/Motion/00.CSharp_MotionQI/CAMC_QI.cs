using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace CAMC_QI
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	/// 


	// FormMotion클래스외부에서 또다른 클래스나 구조체를 선언하면
	// 에러 발생



    public class FormMotion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblAxisSetting;
		private System.Windows.Forms.ComboBox cboAxisSet;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupMotion;
		private System.Windows.Forms.Label lblUnitPulse;
		private System.Windows.Forms.Label lblStartSpeed;
		private System.Windows.Forms.NumericUpDown numMoveUnit;
		private System.Windows.Forms.NumericUpDown numStartSpeed;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.ComboBox cboPulseOutM;
		private System.Windows.Forms.ComboBox cboEncInputM;
		private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.Label lbl3;
		private System.Windows.Forms.Label lbl4;
		private System.Windows.Forms.Label lbl5;
		private System.Windows.Forms.Label lbl6;
		private System.Windows.Forms.Label lbl7;
		
		private System.Windows.Forms.TextBox textCmdVelY;
		private System.Windows.Forms.TextBox textActPosY;
		private System.Windows.Forms.TextBox textCmdPosY;
		private System.Windows.Forms.TextBox textCmdVelX;
		private System.Windows.Forms.TextBox textActPosX;
		private System.Windows.Forms.TextBox textCmdPosX;
		private System.Windows.Forms.GroupBox groupInterpolation;
		private System.Windows.Forms.Label lbl8;
		private System.Windows.Forms.Label lbl9;
		private System.Windows.Forms.Label lbl10;
		private System.Windows.Forms.GroupBox groupOneAxis;
		private System.Windows.Forms.Label lbl11;
		private System.Windows.Forms.Label lbl12;
		private System.Windows.Forms.Button btnCNTCLR;
		private System.Windows.Forms.TextBox textXEnd;
		private System.Windows.Forms.TextBox textYEnd;
		private System.Windows.Forms.TextBox textAngle;
		private System.Windows.Forms.Button btnLinear;
		private System.Windows.Forms.Button btnCircular;
		private System.Windows.Forms.CheckBox chkDIR;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.Button btnRepeat;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnEStop;
		private System.Windows.Forms.CheckBox chkAbsolute;
		private System.Windows.Forms.CheckBox chkRelative;
		private System.Windows.Forms.CheckBox chkAsym;
		private System.Windows.Forms.CheckBox chkSCurve;
		private System.Windows.Forms.GroupBox groupSignalSearch;
		private System.Windows.Forms.Label lbl15;
		private System.Windows.Forms.Label lbl16;
		private System.Windows.Forms.Label lbl17;
		private System.Windows.Forms.Label lbl19;
		private System.Windows.Forms.ComboBox cboDetectSignal;
		private System.Windows.Forms.ComboBox cboDirection;
		private System.Windows.Forms.ComboBox cboStopMethod;
		private System.Windows.Forms.NumericUpDown numDistance;
		private System.Windows.Forms.NumericUpDown numVelocity;
		private System.Windows.Forms.NumericUpDown numAccel;
		private System.Windows.Forms.NumericUpDown numDecel;
		private System.Windows.Forms.CheckBox chkGantry;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ListBox lstLog;
		private System.Windows.Forms.Button btnHomeAll;
		private System.Windows.Forms.Button btnHomeSingle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSigCapture;
		private System.Windows.Forms.Button btnVelOverride;
		private System.Timers.Timer timerHomeFun1;
		private System.Timers.Timer timerHomeFun2;
		private System.Timers.Timer timerHomeFun3;
		private System.Timers.Timer timerHomeFun4;
		private System.Timers.Timer timerDisplay;
		private System.Timers.Timer timerGraph;
		private System.Windows.Forms.GroupBox groupIO;
		private System.Windows.Forms.GroupBox groupLevelSetting;
		private System.Windows.Forms.GroupBox groupUnivIO;
		private System.Windows.Forms.Label lbl20;
		private System.Windows.Forms.Label lbl21;
		private System.Windows.Forms.Label lbl22;
		private System.Windows.Forms.Label lbl23;
		private System.Windows.Forms.Label lbl24;
		private System.Windows.Forms.Label lbl25;
		private System.Windows.Forms.Label lbl26;
		private System.Windows.Forms.Label lbl27;
		private System.Windows.Forms.GroupBox groupMechanical;
		private System.Windows.Forms.GroupBox groupMPG;
		private System.Windows.Forms.Button btnMPGOn;
		private System.Windows.Forms.Button btnMPGOff;
		private System.Windows.Forms.GroupBox groupCRC;
		private System.Windows.Forms.Button btnCRCOff;
		private System.Windows.Forms.Button btnCRCOn;
		private System.Windows.Forms.CheckBox chkPELMLevel;
		private System.Windows.Forms.CheckBox chkNELMLevel;
		private System.Windows.Forms.CheckBox chkInpLevel;
		private System.Windows.Forms.CheckBox chkAlarmLevel;
		private System.Windows.Forms.Label lblLedIn0;
		private System.Windows.Forms.Label lblLedIn2;
		private System.Windows.Forms.Label lblLedIn3;
		private System.Windows.Forms.Label lblLedIn4;
		private System.Windows.Forms.Label lblLedIn5;
		private System.Windows.Forms.Label lblLedIn1;
		private System.Windows.Forms.Label lblLedOut1;
		private System.Windows.Forms.Label lblLedOut5;
		private System.Windows.Forms.Label lblLedOut4;
		private System.Windows.Forms.Label lblLedOut3;
		private System.Windows.Forms.Label lblLedOut2;
		private System.Windows.Forms.Label lblLedOut0;
		private System.Windows.Forms.Label lblLedAlarm;
		private System.Windows.Forms.Label lblLedInposition;
		private System.Windows.Forms.Label lblLedNELM;
		private System.Windows.Forms.Label lblLedPELM;
		private System.Windows.Forms.GroupBox groupETC;
		private System.Windows.Forms.Label lblLedBusyX;
		private System.Windows.Forms.Label lblLedEXPP;
		private System.Windows.Forms.Label lblLedBusyY;
		private System.Windows.Forms.Label lblLedEXMP;
		private System.Windows.Forms.GroupBox groupContiInterpolation;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbl28;
		private System.Windows.Forms.Label lbl29;
		private System.Windows.Forms.Label lbl30;
		private System.Windows.Forms.Label lbl31;
		private System.Windows.Forms.TextBox edtContiNum;
		private System.Windows.Forms.TextBox edtTotalNum;
		private System.Windows.Forms.TextBox edtQFree;
		private System.Windows.Forms.TextBox edtInMotion;
		private System.Windows.Forms.GroupBox groupInterruptMethodSetting;
		private System.Windows.Forms.Button btnIntMessage;
		private System.Windows.Forms.Button btnIntEvent;
		private System.Windows.Forms.Button btnIntDisable;
		private System.Windows.Forms.Label lbl32;
		private System.Windows.Forms.Label lblInterruptCount;
		private System.Windows.Forms.Label lbl33;
		private System.Windows.Forms.Label lbl34;
		private System.Windows.Forms.Button btnContiStart;
		private System.Windows.Forms.Button btnContiClear;
		private System.Windows.Forms.Button btnStatus;
		private System.Windows.Forms.Label lbl13;
		private System.Windows.Forms.Label lbl14;
		private System.Windows.Forms.Label lbl35;
		private System.Windows.Forms.Label lbl36;
		private System.Windows.Forms.Label lbl37;
		private System.Windows.Forms.GroupBox groupBlockOneShotTrigger;
		private System.Windows.Forms.Label lbl39;
		private System.Windows.Forms.Label lbl40;
		private System.Windows.Forms.Label lbl41;
		private System.Windows.Forms.Label lbl42;
		private System.Windows.Forms.GroupBox groupSenPosMove;
		private System.Windows.Forms.Button btnTrigAbs;
		private System.Windows.Forms.NumericUpDown edtTrigEndPos;
		private System.Windows.Forms.NumericUpDown edtTrigStartPosition;
		private System.Windows.Forms.NumericUpDown edtTrigCycle;
		private System.Windows.Forms.NumericUpDown edtTrigPulseWidth;
		private System.Windows.Forms.Button btnTrigPeriod;
		private System.Windows.Forms.GroupBox groupCapturePosition;


		private System.Windows.Forms.Button btnJogPY;
		private System.Windows.Forms.Button btnJogNY;
		private System.Windows.Forms.Button btnJogPX;
		private System.Windows.Forms.Button btnJogNX;

		private System.Windows.Forms.Button btnJogPU;
		private System.Windows.Forms.Button btnJogNU;
		private System.Windows.Forms.Button btnJogNZ;
		private System.Windows.Forms.Button btnJogPZ;

		private System.Windows.Forms.Button btnTrigOneShot;
		private System.Windows.Forms.Button btnTrigReset;
		private System.Windows.Forms.Button btnContiBlend;
		private System.Windows.Forms.Button btnContiCircle;
		private System.Windows.Forms.Button btnContiLine;
        private System.Windows.Forms.Button btnContiSpline;
		private System.Windows.Forms.Label lbl38;
        private System.Windows.Forms.Label lbl43;
		private System.Windows.Forms.NumericUpDown numMovePulse;
		private System.Windows.Forms.Button btnContiTest;
		private System.Windows.Forms.Label lbl44;
		private System.Windows.Forms.Label lbl45;
		private System.Windows.Forms.Button btn3DGraph;
		private System.Windows.Forms.TextBox textCmdVelU;
		private System.Windows.Forms.TextBox textActPosU;
		private System.Windows.Forms.TextBox textCmdPosU;
		private System.Windows.Forms.TextBox textCmdVelZ;
		private System.Windows.Forms.TextBox textActPosZ;
		private System.Windows.Forms.TextBox textCmdPosZ;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lbl47;
		private System.Windows.Forms.GroupBox groupJOG;
		private System.Windows.Forms.Label lbl49;
		private System.Windows.Forms.CheckBox chkEmg;
		private System.Windows.Forms.Label lblLedEMG;
		private System.Windows.Forms.CheckBox chkHomeLevel;
		private System.Windows.Forms.CheckBox chkZphase;
		private System.Windows.Forms.Label lblLedZphase;
		private System.Windows.Forms.Label lblLedHome;
		private System.Windows.Forms.CheckBox chkGearOnOff;
		private System.Windows.Forms.NumericUpDown edtGearRatio;
		private System.Windows.Forms.NumericUpDown edtHomeVelFirst;
		private System.Windows.Forms.NumericUpDown edtHomeVelSecond;
		private System.Windows.Forms.NumericUpDown edtHomeVelLast;
		private System.Windows.Forms.NumericUpDown edtHomeVelThird;
		private System.Windows.Forms.ComboBox cboHomeDir;
		private System.Windows.Forms.ComboBox cboHomeSignal;
		private System.Windows.Forms.Button btnReadCapture;
		private System.Windows.Forms.Label lblCapture;
		private AxAxtXYGraphLib.AxAxtXYGraph XYPlot;
		private System.Windows.Forms.ComboBox cboGantrySlave;
        private AxAXTGRAPHLib.AxAxtGraph GraphX;
        private AxAXTGRAPHLib.AxAxtGraph GraphY;
        private NumericUpDown edtMoveUnit;
		private System.Windows.Forms.CheckBox chkXYSync;

		public FormMotion()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
		}
        delegate void SetTextCallBack(string strLog);

        public int              m_lAxisCounts   = 0;
		private int				m_lAxis			= 0;	// 현재 축번호
        private bool            m_bA4NAxis      = false;

        public int              m_nSignalDir    = 0;
        public int              m_nSignalStop   = 0;
        public int              m_nSignalDetect = 0;

		// thread
		private static FormMotion	m_formMotion;

        private Thread[]        m_hTestThread   = new Thread[64];
		private bool[]          m_bTestActive   = new bool[64];

        private readonly static int COORD_NO        = 0;
        // Interrupt Count
		private	int				m_nInterruptCnt = 0; // 인터럽트 카운트

        Form3DView              m_frm3DView = null;
        private bool            m_b3DGraph = false;

		//	event
        uint[]                  m_uEventInterrupt   = new uint[64];
		// uint					m_uEventInterrupt	= 0;
		bool[]                  m_bEventThread      = new bool[64];
		private Thread[]		m_EventThread		= new Thread[64];

		public readonly static uint	INFINITE				= 0xFFFFFFFF;
		public readonly static uint	STATUS_WAIT_0			= 0x00000000;
		public readonly static uint	WAIT_OBJECT_0			= ((STATUS_WAIT_0 ) + 0 );
		[DllImport("kernel32",EntryPoint="WaitForSingleObject", SetLastError=true, CharSet = CharSet.Unicode)]
		private static extern uint WaitForSingleObject(uint hHandle, uint dwMilliseconds);

		// XY 그래프
		private	Point			m_ptOldOldXY	= new Point(0,0);
		private	Point			m_ptOldXY		= new Point(0,0);
		private	Point			m_ptCurrXY		= new Point(0,0);
		private uint			m_uMagnifications		= 200;	// Zoom

		// define
		private const int		LINEAR_INTERPOLATION	= 0;
		private const int		CIRCULAR_INTERPOLATION	= 1;

		private const int		DIOONEOUT_NOTUSE		= 0;
		private const int		DIOONEOUT_USE			= 1;

		private const int		DIO_OUTNOTUSE			= 0;
		private const int		DIO_OUTUSE				= 1;

		private const int		INTERRUPT_USE			= 0;
		private const int		INTERRUPT_NOTUSE		= 1;

		private const int		TRIG_USE				= 0;
		private const int		TRIG_NOTUSE				= 1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMotion));
            this.lblAxisSetting = new System.Windows.Forms.Label();
            this.cboAxisSet = new System.Windows.Forms.ComboBox();
            this.groupMotion = new System.Windows.Forms.GroupBox();
            this.btnJogPU = new System.Windows.Forms.Button();
            this.btnJogNU = new System.Windows.Forms.Button();
            this.btnJogNZ = new System.Windows.Forms.Button();
            this.btnJogPZ = new System.Windows.Forms.Button();
            this.textCmdVelU = new System.Windows.Forms.TextBox();
            this.textActPosU = new System.Windows.Forms.TextBox();
            this.textCmdPosU = new System.Windows.Forms.TextBox();
            this.textCmdVelZ = new System.Windows.Forms.TextBox();
            this.textActPosZ = new System.Windows.Forms.TextBox();
            this.textCmdPosZ = new System.Windows.Forms.TextBox();
            this.lbl44 = new System.Windows.Forms.Label();
            this.lbl45 = new System.Windows.Forms.Label();
            this.numMovePulse = new System.Windows.Forms.NumericUpDown();
            this.lbl43 = new System.Windows.Forms.Label();
            this.groupOneAxis = new System.Windows.Forms.GroupBox();
            this.numDecel = new System.Windows.Forms.NumericUpDown();
            this.numAccel = new System.Windows.Forms.NumericUpDown();
            this.numVelocity = new System.Windows.Forms.NumericUpDown();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.chkXYSync = new System.Windows.Forms.CheckBox();
            this.chkSCurve = new System.Windows.Forms.CheckBox();
            this.chkAsym = new System.Windows.Forms.CheckBox();
            this.chkRelative = new System.Windows.Forms.CheckBox();
            this.chkAbsolute = new System.Windows.Forms.CheckBox();
            this.btnEStop = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl33 = new System.Windows.Forms.Label();
            this.lbl34 = new System.Windows.Forms.Label();
            this.groupInterpolation = new System.Windows.Forms.GroupBox();
            this.chkDIR = new System.Windows.Forms.CheckBox();
            this.btnCircular = new System.Windows.Forms.Button();
            this.btnLinear = new System.Windows.Forms.Button();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.textYEnd = new System.Windows.Forms.TextBox();
            this.textXEnd = new System.Windows.Forms.TextBox();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.groupJOG = new System.Windows.Forms.GroupBox();
            this.cboGantrySlave = new System.Windows.Forms.ComboBox();
            this.chkGantry = new System.Windows.Forms.CheckBox();
            this.btnCNTCLR = new System.Windows.Forms.Button();
            this.textCmdVelY = new System.Windows.Forms.TextBox();
            this.textActPosY = new System.Windows.Forms.TextBox();
            this.textCmdPosY = new System.Windows.Forms.TextBox();
            this.textCmdVelX = new System.Windows.Forms.TextBox();
            this.textActPosX = new System.Windows.Forms.TextBox();
            this.textCmdPosX = new System.Windows.Forms.TextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.cboEncInputM = new System.Windows.Forms.ComboBox();
            this.cboPulseOutM = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.numStartSpeed = new System.Windows.Forms.NumericUpDown();
            this.numMoveUnit = new System.Windows.Forms.NumericUpDown();
            this.lblStartSpeed = new System.Windows.Forms.Label();
            this.lblUnitPulse = new System.Windows.Forms.Label();
            this.lbl47 = new System.Windows.Forms.Label();
            this.btnJogNX = new System.Windows.Forms.Button();
            this.btnJogPX = new System.Windows.Forms.Button();
            this.btnJogPY = new System.Windows.Forms.Button();
            this.btnJogNY = new System.Windows.Forms.Button();
            this.groupSignalSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboStopMethod = new System.Windows.Forms.ComboBox();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.cboDetectSignal = new System.Windows.Forms.ComboBox();
            this.lbl17 = new System.Windows.Forms.Label();
            this.lbl16 = new System.Windows.Forms.Label();
            this.lbl15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSigCapture = new System.Windows.Forms.Button();
            this.btnVelOverride = new System.Windows.Forms.Button();
            this.btnHomeSingle = new System.Windows.Forms.Button();
            this.btnHomeAll = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.edtHomeVelFirst = new System.Windows.Forms.NumericUpDown();
            this.edtGearRatio = new System.Windows.Forms.NumericUpDown();
            this.lbl19 = new System.Windows.Forms.Label();
            this.timerHomeFun1 = new System.Timers.Timer();
            this.timerHomeFun2 = new System.Timers.Timer();
            this.timerHomeFun3 = new System.Timers.Timer();
            this.timerHomeFun4 = new System.Timers.Timer();
            this.timerDisplay = new System.Timers.Timer();
            this.timerGraph = new System.Timers.Timer();
            this.groupIO = new System.Windows.Forms.GroupBox();
            this.groupCRC = new System.Windows.Forms.GroupBox();
            this.btnCRCOff = new System.Windows.Forms.Button();
            this.btnCRCOn = new System.Windows.Forms.Button();
            this.groupMPG = new System.Windows.Forms.GroupBox();
            this.btnMPGOff = new System.Windows.Forms.Button();
            this.btnMPGOn = new System.Windows.Forms.Button();
            this.groupMechanical = new System.Windows.Forms.GroupBox();
            this.lblLedEMG = new System.Windows.Forms.Label();
            this.lblLedZphase = new System.Windows.Forms.Label();
            this.lblLedHome = new System.Windows.Forms.Label();
            this.lblLedAlarm = new System.Windows.Forms.Label();
            this.lblLedInposition = new System.Windows.Forms.Label();
            this.lblLedNELM = new System.Windows.Forms.Label();
            this.lblLedPELM = new System.Windows.Forms.Label();
            this.groupUnivIO = new System.Windows.Forms.GroupBox();
            this.lblLedOut1 = new System.Windows.Forms.Label();
            this.lblLedOut5 = new System.Windows.Forms.Label();
            this.lblLedOut4 = new System.Windows.Forms.Label();
            this.lblLedOut3 = new System.Windows.Forms.Label();
            this.lblLedOut2 = new System.Windows.Forms.Label();
            this.lblLedOut0 = new System.Windows.Forms.Label();
            this.lblLedIn1 = new System.Windows.Forms.Label();
            this.lblLedIn5 = new System.Windows.Forms.Label();
            this.lblLedIn4 = new System.Windows.Forms.Label();
            this.lblLedIn3 = new System.Windows.Forms.Label();
            this.lblLedIn2 = new System.Windows.Forms.Label();
            this.lblLedIn0 = new System.Windows.Forms.Label();
            this.lbl27 = new System.Windows.Forms.Label();
            this.lbl26 = new System.Windows.Forms.Label();
            this.groupLevelSetting = new System.Windows.Forms.GroupBox();
            this.chkEmg = new System.Windows.Forms.CheckBox();
            this.lbl49 = new System.Windows.Forms.Label();
            this.chkZphase = new System.Windows.Forms.CheckBox();
            this.chkHomeLevel = new System.Windows.Forms.CheckBox();
            this.chkAlarmLevel = new System.Windows.Forms.CheckBox();
            this.chkInpLevel = new System.Windows.Forms.CheckBox();
            this.chkNELMLevel = new System.Windows.Forms.CheckBox();
            this.lbl25 = new System.Windows.Forms.Label();
            this.lbl24 = new System.Windows.Forms.Label();
            this.lbl23 = new System.Windows.Forms.Label();
            this.lbl22 = new System.Windows.Forms.Label();
            this.lbl21 = new System.Windows.Forms.Label();
            this.chkPELMLevel = new System.Windows.Forms.CheckBox();
            this.lbl20 = new System.Windows.Forms.Label();
            this.groupETC = new System.Windows.Forms.GroupBox();
            this.lblLedEXMP = new System.Windows.Forms.Label();
            this.lblLedBusyY = new System.Windows.Forms.Label();
            this.lblLedEXPP = new System.Windows.Forms.Label();
            this.lblLedBusyX = new System.Windows.Forms.Label();
            this.groupContiInterpolation = new System.Windows.Forms.GroupBox();
            this.btnContiTest = new System.Windows.Forms.Button();
            this.btnContiClear = new System.Windows.Forms.Button();
            this.btnContiSpline = new System.Windows.Forms.Button();
            this.btnContiStart = new System.Windows.Forms.Button();
            this.btnContiBlend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtInMotion = new System.Windows.Forms.TextBox();
            this.edtQFree = new System.Windows.Forms.TextBox();
            this.edtTotalNum = new System.Windows.Forms.TextBox();
            this.edtContiNum = new System.Windows.Forms.TextBox();
            this.lbl31 = new System.Windows.Forms.Label();
            this.lbl30 = new System.Windows.Forms.Label();
            this.lbl29 = new System.Windows.Forms.Label();
            this.lbl28 = new System.Windows.Forms.Label();
            this.btnContiCircle = new System.Windows.Forms.Button();
            this.btnContiLine = new System.Windows.Forms.Button();
            this.btnReadCapture = new System.Windows.Forms.Button();
            this.groupInterruptMethodSetting = new System.Windows.Forms.GroupBox();
            this.lblInterruptCount = new System.Windows.Forms.Label();
            this.lbl32 = new System.Windows.Forms.Label();
            this.btnIntDisable = new System.Windows.Forms.Button();
            this.btnIntEvent = new System.Windows.Forms.Button();
            this.btnIntMessage = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.groupSenPosMove = new System.Windows.Forms.GroupBox();
            this.edtHomeVelSecond = new System.Windows.Forms.NumericUpDown();
            this.edtHomeVelLast = new System.Windows.Forms.NumericUpDown();
            this.edtHomeVelThird = new System.Windows.Forms.NumericUpDown();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lbl35 = new System.Windows.Forms.Label();
            this.lbl36 = new System.Windows.Forms.Label();
            this.lbl37 = new System.Windows.Forms.Label();
            this.cboHomeDir = new System.Windows.Forms.ComboBox();
            this.cboHomeSignal = new System.Windows.Forms.ComboBox();
            this.groupBlockOneShotTrigger = new System.Windows.Forms.GroupBox();
            this.btnTrigReset = new System.Windows.Forms.Button();
            this.btnTrigOneShot = new System.Windows.Forms.Button();
            this.btnTrigPeriod = new System.Windows.Forms.Button();
            this.edtTrigPulseWidth = new System.Windows.Forms.NumericUpDown();
            this.edtTrigCycle = new System.Windows.Forms.NumericUpDown();
            this.edtTrigStartPosition = new System.Windows.Forms.NumericUpDown();
            this.btnTrigAbs = new System.Windows.Forms.Button();
            this.edtTrigEndPos = new System.Windows.Forms.NumericUpDown();
            this.lbl39 = new System.Windows.Forms.Label();
            this.lbl40 = new System.Windows.Forms.Label();
            this.lbl41 = new System.Windows.Forms.Label();
            this.lbl42 = new System.Windows.Forms.Label();
            this.groupCapturePosition = new System.Windows.Forms.GroupBox();
            this.lblCapture = new System.Windows.Forms.Label();
            this.edtMoveUnit = new System.Windows.Forms.NumericUpDown();
            this.lbl38 = new System.Windows.Forms.Label();
            this.btn3DGraph = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkGearOnOff = new System.Windows.Forms.CheckBox();
            this.XYPlot = new AxAxtXYGraphLib.AxAxtXYGraph();
            this.GraphY = new AxAXTGRAPHLib.AxAxtGraph();
            this.GraphX = new AxAXTGRAPHLib.AxAxtGraph();
            this.groupMotion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovePulse)).BeginInit();
            this.groupOneAxis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.groupInterpolation.SuspendLayout();
            this.groupJOG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveUnit)).BeginInit();
            this.groupSignalSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGearRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerGraph)).BeginInit();
            this.groupIO.SuspendLayout();
            this.groupCRC.SuspendLayout();
            this.groupMPG.SuspendLayout();
            this.groupMechanical.SuspendLayout();
            this.groupUnivIO.SuspendLayout();
            this.groupLevelSetting.SuspendLayout();
            this.groupETC.SuspendLayout();
            this.groupContiInterpolation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupInterruptMethodSetting.SuspendLayout();
            this.groupSenPosMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelThird)).BeginInit();
            this.groupBlockOneShotTrigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigPulseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigStartPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigEndPos)).BeginInit();
            this.groupCapturePosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XYPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAxisSetting
            // 
            this.lblAxisSetting.BackColor = System.Drawing.Color.Transparent;
            this.lblAxisSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAxisSetting.Location = new System.Drawing.Point(8, 308);
            this.lblAxisSetting.Name = "lblAxisSetting";
            this.lblAxisSetting.Size = new System.Drawing.Size(72, 20);
            this.lblAxisSetting.TabIndex = 2;
            this.lblAxisSetting.Text = "AxisNo";
            this.lblAxisSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboAxisSet
            // 
            this.cboAxisSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboAxisSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAxisSet.Location = new System.Drawing.Point(82, 308);
            this.cboAxisSet.Name = "cboAxisSet";
            this.cboAxisSet.Size = new System.Drawing.Size(147, 20);
            this.cboAxisSet.TabIndex = 3;
            this.cboAxisSet.SelectedIndexChanged += new System.EventHandler(this.cboAxisSetting_SelectedIndexChanged);
            // 
            // groupMotion
            // 
            this.groupMotion.BackColor = System.Drawing.Color.Transparent;
            this.groupMotion.Controls.Add(this.btnJogPU);
            this.groupMotion.Controls.Add(this.btnJogNU);
            this.groupMotion.Controls.Add(this.btnJogNZ);
            this.groupMotion.Controls.Add(this.btnJogPZ);
            this.groupMotion.Controls.Add(this.textCmdVelU);
            this.groupMotion.Controls.Add(this.textActPosU);
            this.groupMotion.Controls.Add(this.textCmdPosU);
            this.groupMotion.Controls.Add(this.textCmdVelZ);
            this.groupMotion.Controls.Add(this.textActPosZ);
            this.groupMotion.Controls.Add(this.textCmdPosZ);
            this.groupMotion.Controls.Add(this.lbl44);
            this.groupMotion.Controls.Add(this.lbl45);
            this.groupMotion.Controls.Add(this.numMovePulse);
            this.groupMotion.Controls.Add(this.lbl43);
            this.groupMotion.Controls.Add(this.groupOneAxis);
            this.groupMotion.Controls.Add(this.groupInterpolation);
            this.groupMotion.Controls.Add(this.groupJOG);
            this.groupMotion.Controls.Add(this.btnCNTCLR);
            this.groupMotion.Controls.Add(this.textCmdVelY);
            this.groupMotion.Controls.Add(this.textActPosY);
            this.groupMotion.Controls.Add(this.textCmdPosY);
            this.groupMotion.Controls.Add(this.textCmdVelX);
            this.groupMotion.Controls.Add(this.textActPosX);
            this.groupMotion.Controls.Add(this.textCmdPosX);
            this.groupMotion.Controls.Add(this.lbl7);
            this.groupMotion.Controls.Add(this.lbl6);
            this.groupMotion.Controls.Add(this.lbl5);
            this.groupMotion.Controls.Add(this.lbl4);
            this.groupMotion.Controls.Add(this.lbl3);
            this.groupMotion.Controls.Add(this.btnSetting);
            this.groupMotion.Controls.Add(this.cboEncInputM);
            this.groupMotion.Controls.Add(this.cboPulseOutM);
            this.groupMotion.Controls.Add(this.lbl2);
            this.groupMotion.Controls.Add(this.lbl1);
            this.groupMotion.Controls.Add(this.numStartSpeed);
            this.groupMotion.Controls.Add(this.numMoveUnit);
            this.groupMotion.Controls.Add(this.lblStartSpeed);
            this.groupMotion.Controls.Add(this.lblUnitPulse);
            this.groupMotion.Controls.Add(this.lbl47);
            this.groupMotion.Controls.Add(this.btnJogNX);
            this.groupMotion.Controls.Add(this.btnJogPX);
            this.groupMotion.Controls.Add(this.btnJogPY);
            this.groupMotion.Controls.Add(this.btnJogNY);
            this.groupMotion.Location = new System.Drawing.Point(235, 284);
            this.groupMotion.Name = "groupMotion";
            this.groupMotion.Size = new System.Drawing.Size(395, 411);
            this.groupMotion.TabIndex = 4;
            this.groupMotion.TabStop = false;
            this.groupMotion.Text = "Motion";
            // 
            // btnJogPU
            // 
            this.btnJogPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogPU.Location = new System.Drawing.Point(343, 172);
            this.btnJogPU.Name = "btnJogPU";
            this.btnJogPU.Size = new System.Drawing.Size(21, 21);
            this.btnJogPU.TabIndex = 40;
            this.btnJogPU.Text = "+";
            this.btnJogPU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPU_MouseDown);
            this.btnJogPU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPU_MouseUp);
            // 
            // btnJogNU
            // 
            this.btnJogNU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogNU.Location = new System.Drawing.Point(366, 172);
            this.btnJogNU.Name = "btnJogNU";
            this.btnJogNU.Size = new System.Drawing.Size(21, 21);
            this.btnJogNU.TabIndex = 41;
            this.btnJogNU.Text = "-";
            this.btnJogNU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogNU_MouseDown);
            this.btnJogNU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogNU_MouseUp);
            // 
            // btnJogNZ
            // 
            this.btnJogNZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogNZ.Location = new System.Drawing.Point(366, 148);
            this.btnJogNZ.Name = "btnJogNZ";
            this.btnJogNZ.Size = new System.Drawing.Size(21, 21);
            this.btnJogNZ.TabIndex = 38;
            this.btnJogNZ.Text = "-";
            this.btnJogNZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogNZ_MouseDown);
            this.btnJogNZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogNZ_MouseUp);
            // 
            // btnJogPZ
            // 
            this.btnJogPZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogPZ.Location = new System.Drawing.Point(343, 148);
            this.btnJogPZ.Name = "btnJogPZ";
            this.btnJogPZ.Size = new System.Drawing.Size(21, 21);
            this.btnJogPZ.TabIndex = 39;
            this.btnJogPZ.Text = "+";
            this.btnJogPZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPZ_MouseDown);
            this.btnJogPZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPZ_MouseUp);
            // 
            // textCmdVelU
            // 
            this.textCmdVelU.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdVelU.ForeColor = System.Drawing.Color.Black;
            this.textCmdVelU.Location = new System.Drawing.Point(256, 172);
            this.textCmdVelU.Name = "textCmdVelU";
            this.textCmdVelU.ReadOnly = true;
            this.textCmdVelU.Size = new System.Drawing.Size(85, 21);
            this.textCmdVelU.TabIndex = 36;
            this.textCmdVelU.Text = "0.000";
            this.textCmdVelU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textActPosU
            // 
            this.textActPosU.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textActPosU.ForeColor = System.Drawing.Color.Black;
            this.textActPosU.Location = new System.Drawing.Point(168, 172);
            this.textActPosU.Name = "textActPosU";
            this.textActPosU.ReadOnly = true;
            this.textActPosU.Size = new System.Drawing.Size(85, 21);
            this.textActPosU.TabIndex = 35;
            this.textActPosU.Text = "0.000";
            this.textActPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdPosU
            // 
            this.textCmdPosU.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdPosU.ForeColor = System.Drawing.Color.Black;
            this.textCmdPosU.Location = new System.Drawing.Point(80, 172);
            this.textCmdPosU.Name = "textCmdPosU";
            this.textCmdPosU.ReadOnly = true;
            this.textCmdPosU.Size = new System.Drawing.Size(85, 21);
            this.textCmdPosU.TabIndex = 34;
            this.textCmdPosU.Text = "0.000";
            this.textCmdPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdVelZ
            // 
            this.textCmdVelZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdVelZ.ForeColor = System.Drawing.Color.Black;
            this.textCmdVelZ.Location = new System.Drawing.Point(256, 148);
            this.textCmdVelZ.Name = "textCmdVelZ";
            this.textCmdVelZ.ReadOnly = true;
            this.textCmdVelZ.Size = new System.Drawing.Size(85, 21);
            this.textCmdVelZ.TabIndex = 33;
            this.textCmdVelZ.Text = "0.000";
            this.textCmdVelZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textActPosZ
            // 
            this.textActPosZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textActPosZ.ForeColor = System.Drawing.Color.Black;
            this.textActPosZ.Location = new System.Drawing.Point(168, 148);
            this.textActPosZ.Name = "textActPosZ";
            this.textActPosZ.ReadOnly = true;
            this.textActPosZ.Size = new System.Drawing.Size(85, 21);
            this.textActPosZ.TabIndex = 32;
            this.textActPosZ.Text = "0.000";
            this.textActPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdPosZ
            // 
            this.textCmdPosZ.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdPosZ.ForeColor = System.Drawing.Color.Black;
            this.textCmdPosZ.Location = new System.Drawing.Point(80, 148);
            this.textCmdPosZ.Name = "textCmdPosZ";
            this.textCmdPosZ.ReadOnly = true;
            this.textCmdPosZ.Size = new System.Drawing.Size(85, 21);
            this.textCmdPosZ.TabIndex = 31;
            this.textCmdPosZ.Text = "0.000";
            this.textCmdPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl44
            // 
            this.lbl44.BackColor = System.Drawing.Color.Transparent;
            this.lbl44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl44.Location = new System.Drawing.Point(8, 173);
            this.lbl44.Name = "lbl44";
            this.lbl44.Size = new System.Drawing.Size(69, 18);
            this.lbl44.TabIndex = 30;
            this.lbl44.Text = "Axis U";
            this.lbl44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl45
            // 
            this.lbl45.BackColor = System.Drawing.Color.Transparent;
            this.lbl45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl45.Location = new System.Drawing.Point(8, 149);
            this.lbl45.Name = "lbl45";
            this.lbl45.Size = new System.Drawing.Size(69, 18);
            this.lbl45.TabIndex = 29;
            this.lbl45.Text = "Axis Z";
            this.lbl45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMovePulse
            // 
            this.numMovePulse.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numMovePulse.ForeColor = System.Drawing.Color.Black;
            this.numMovePulse.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMovePulse.Location = new System.Drawing.Point(145, 16);
            this.numMovePulse.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numMovePulse.Name = "numMovePulse";
            this.numMovePulse.Size = new System.Drawing.Size(56, 21);
            this.numMovePulse.TabIndex = 28;
            this.numMovePulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl43
            // 
            this.lbl43.BackColor = System.Drawing.Color.Transparent;
            this.lbl43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl43.Location = new System.Drawing.Point(105, 16);
            this.lbl43.Name = "lbl43";
            this.lbl43.Size = new System.Drawing.Size(39, 21);
            this.lbl43.TabIndex = 27;
            this.lbl43.Text = "Pulse";
            this.lbl43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupOneAxis
            // 
            this.groupOneAxis.Controls.Add(this.numDecel);
            this.groupOneAxis.Controls.Add(this.numAccel);
            this.groupOneAxis.Controls.Add(this.numVelocity);
            this.groupOneAxis.Controls.Add(this.numDistance);
            this.groupOneAxis.Controls.Add(this.chkXYSync);
            this.groupOneAxis.Controls.Add(this.chkSCurve);
            this.groupOneAxis.Controls.Add(this.chkAsym);
            this.groupOneAxis.Controls.Add(this.chkRelative);
            this.groupOneAxis.Controls.Add(this.chkAbsolute);
            this.groupOneAxis.Controls.Add(this.btnEStop);
            this.groupOneAxis.Controls.Add(this.btnStop);
            this.groupOneAxis.Controls.Add(this.btnRepeat);
            this.groupOneAxis.Controls.Add(this.btnMove);
            this.groupOneAxis.Controls.Add(this.lbl12);
            this.groupOneAxis.Controls.Add(this.lbl11);
            this.groupOneAxis.Controls.Add(this.lbl33);
            this.groupOneAxis.Controls.Add(this.lbl34);
            this.groupOneAxis.Location = new System.Drawing.Point(0, 303);
            this.groupOneAxis.Name = "groupOneAxis";
            this.groupOneAxis.Size = new System.Drawing.Size(395, 108);
            this.groupOneAxis.TabIndex = 26;
            this.groupOneAxis.TabStop = false;
            this.groupOneAxis.Text = "One Axis";
            // 
            // numDecel
            // 
            this.numDecel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numDecel.DecimalPlaces = 3;
            this.numDecel.ForeColor = System.Drawing.Color.Black;
            this.numDecel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numDecel.Location = new System.Drawing.Point(238, 43);
            this.numDecel.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numDecel.Name = "numDecel";
            this.numDecel.Size = new System.Drawing.Size(74, 21);
            this.numDecel.TabIndex = 38;
            this.numDecel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numAccel
            // 
            this.numAccel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numAccel.DecimalPlaces = 3;
            this.numAccel.ForeColor = System.Drawing.Color.Black;
            this.numAccel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numAccel.Location = new System.Drawing.Point(162, 43);
            this.numAccel.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numAccel.Name = "numAccel";
            this.numAccel.Size = new System.Drawing.Size(74, 21);
            this.numAccel.TabIndex = 37;
            this.numAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numVelocity
            // 
            this.numVelocity.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numVelocity.DecimalPlaces = 3;
            this.numVelocity.ForeColor = System.Drawing.Color.Black;
            this.numVelocity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numVelocity.Location = new System.Drawing.Point(85, 43);
            this.numVelocity.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numVelocity.Name = "numVelocity";
            this.numVelocity.Size = new System.Drawing.Size(74, 21);
            this.numVelocity.TabIndex = 36;
            this.numVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numDistance
            // 
            this.numDistance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numDistance.DecimalPlaces = 3;
            this.numDistance.ForeColor = System.Drawing.Color.Black;
            this.numDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numDistance.Location = new System.Drawing.Point(8, 43);
            this.numDistance.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numDistance.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(74, 21);
            this.numDistance.TabIndex = 35;
            this.numDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkXYSync
            // 
            this.chkXYSync.Location = new System.Drawing.Point(316, 83);
            this.chkXYSync.Name = "chkXYSync";
            this.chkXYSync.Size = new System.Drawing.Size(70, 14);
            this.chkXYSync.TabIndex = 34;
            this.chkXYSync.Text = "X-Y Syn";
            // 
            // chkSCurve
            // 
            this.chkSCurve.Checked = true;
            this.chkSCurve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSCurve.Location = new System.Drawing.Point(316, 66);
            this.chkSCurve.Name = "chkSCurve";
            this.chkSCurve.Size = new System.Drawing.Size(70, 14);
            this.chkSCurve.TabIndex = 33;
            this.chkSCurve.Text = "S-Curve";
            // 
            // chkAsym
            // 
            this.chkAsym.Location = new System.Drawing.Point(316, 49);
            this.chkAsym.Name = "chkAsym";
            this.chkAsym.Size = new System.Drawing.Size(70, 14);
            this.chkAsym.TabIndex = 32;
            this.chkAsym.Text = "Asym";
            this.chkAsym.CheckedChanged += new System.EventHandler(this.chkAsym_CheckedChanged);
            // 
            // chkRelative
            // 
            this.chkRelative.Checked = true;
            this.chkRelative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelative.Location = new System.Drawing.Point(316, 32);
            this.chkRelative.Name = "chkRelative";
            this.chkRelative.Size = new System.Drawing.Size(70, 14);
            this.chkRelative.TabIndex = 31;
            this.chkRelative.Text = "Relative";
            this.chkRelative.CheckedChanged += new System.EventHandler(this.chkRelative_CheckedChanged);
            // 
            // chkAbsolute
            // 
            this.chkAbsolute.Location = new System.Drawing.Point(316, 15);
            this.chkAbsolute.Name = "chkAbsolute";
            this.chkAbsolute.Size = new System.Drawing.Size(70, 14);
            this.chkAbsolute.TabIndex = 30;
            this.chkAbsolute.Text = "Absolute";
            this.chkAbsolute.CheckedChanged += new System.EventHandler(this.chkAbsolute_CheckedChanged);
            // 
            // btnEStop
            // 
            this.btnEStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEStop.Location = new System.Drawing.Point(238, 73);
            this.btnEStop.Name = "btnEStop";
            this.btnEStop.Size = new System.Drawing.Size(74, 24);
            this.btnEStop.TabIndex = 29;
            this.btnEStop.Text = "ESTOP";
            this.btnEStop.Click += new System.EventHandler(this.btnEStop_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Location = new System.Drawing.Point(162, 73);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 24);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "STOP";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepeat.Location = new System.Drawing.Point(85, 73);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(74, 24);
            this.btnRepeat.TabIndex = 27;
            this.btnRepeat.Text = "Repeat";
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnMove
            // 
            this.btnMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove.Location = new System.Drawing.Point(8, 73);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(74, 24);
            this.btnMove.TabIndex = 26;
            this.btnMove.Text = "MOVE";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lbl12
            // 
            this.lbl12.BackColor = System.Drawing.Color.Transparent;
            this.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl12.Location = new System.Drawing.Point(85, 16);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(74, 22);
            this.lbl12.TabIndex = 18;
            this.lbl12.Text = "Velocity";
            this.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl11
            // 
            this.lbl11.BackColor = System.Drawing.Color.Transparent;
            this.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl11.Location = new System.Drawing.Point(8, 16);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(74, 22);
            this.lbl11.TabIndex = 17;
            this.lbl11.Text = "Position";
            this.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl33
            // 
            this.lbl33.BackColor = System.Drawing.Color.Transparent;
            this.lbl33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl33.Location = new System.Drawing.Point(238, 16);
            this.lbl33.Name = "lbl33";
            this.lbl33.Size = new System.Drawing.Size(74, 22);
            this.lbl33.TabIndex = 20;
            this.lbl33.Text = "Decel";
            this.lbl33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl34
            // 
            this.lbl34.BackColor = System.Drawing.Color.Transparent;
            this.lbl34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl34.Location = new System.Drawing.Point(162, 16);
            this.lbl34.Name = "lbl34";
            this.lbl34.Size = new System.Drawing.Size(74, 22);
            this.lbl34.TabIndex = 19;
            this.lbl34.Text = "Accel";
            this.lbl34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupInterpolation
            // 
            this.groupInterpolation.Controls.Add(this.chkDIR);
            this.groupInterpolation.Controls.Add(this.btnCircular);
            this.groupInterpolation.Controls.Add(this.btnLinear);
            this.groupInterpolation.Controls.Add(this.textAngle);
            this.groupInterpolation.Controls.Add(this.textYEnd);
            this.groupInterpolation.Controls.Add(this.textXEnd);
            this.groupInterpolation.Controls.Add(this.lbl10);
            this.groupInterpolation.Controls.Add(this.lbl9);
            this.groupInterpolation.Controls.Add(this.lbl8);
            this.groupInterpolation.Location = new System.Drawing.Point(0, 200);
            this.groupInterpolation.Name = "groupInterpolation";
            this.groupInterpolation.Size = new System.Drawing.Size(257, 93);
            this.groupInterpolation.TabIndex = 25;
            this.groupInterpolation.TabStop = false;
            this.groupInterpolation.Text = "Interpolation";
            // 
            // chkDIR
            // 
            this.chkDIR.Location = new System.Drawing.Point(168, 15);
            this.chkDIR.Name = "chkDIR";
            this.chkDIR.Size = new System.Drawing.Size(72, 16);
            this.chkDIR.TabIndex = 27;
            this.chkDIR.Text = "cw/ccw";
            // 
            // btnCircular
            // 
            this.btnCircular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCircular.Location = new System.Drawing.Point(168, 59);
            this.btnCircular.Name = "btnCircular";
            this.btnCircular.Size = new System.Drawing.Size(80, 24);
            this.btnCircular.TabIndex = 25;
            this.btnCircular.Text = "Circular";
            this.btnCircular.Click += new System.EventHandler(this.btnCircular_Click);
            // 
            // btnLinear
            // 
            this.btnLinear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinear.Location = new System.Drawing.Point(168, 35);
            this.btnLinear.Name = "btnLinear";
            this.btnLinear.Size = new System.Drawing.Size(80, 24);
            this.btnLinear.TabIndex = 24;
            this.btnLinear.Text = "Linear";
            this.btnLinear.Click += new System.EventHandler(this.btnLinear_Click);
            // 
            // textAngle
            // 
            this.textAngle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textAngle.ForeColor = System.Drawing.Color.Black;
            this.textAngle.Location = new System.Drawing.Point(80, 64);
            this.textAngle.Name = "textAngle";
            this.textAngle.ReadOnly = true;
            this.textAngle.Size = new System.Drawing.Size(85, 21);
            this.textAngle.TabIndex = 21;
            this.textAngle.Text = "0.000";
            this.textAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textYEnd
            // 
            this.textYEnd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textYEnd.ForeColor = System.Drawing.Color.Black;
            this.textYEnd.Location = new System.Drawing.Point(80, 40);
            this.textYEnd.Name = "textYEnd";
            this.textYEnd.ReadOnly = true;
            this.textYEnd.Size = new System.Drawing.Size(85, 21);
            this.textYEnd.TabIndex = 20;
            this.textYEnd.Text = "0.000";
            this.textYEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textXEnd
            // 
            this.textXEnd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textXEnd.ForeColor = System.Drawing.Color.Black;
            this.textXEnd.Location = new System.Drawing.Point(80, 16);
            this.textXEnd.Name = "textXEnd";
            this.textXEnd.ReadOnly = true;
            this.textXEnd.Size = new System.Drawing.Size(85, 21);
            this.textXEnd.TabIndex = 19;
            this.textXEnd.Text = "0.000";
            this.textXEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl10
            // 
            this.lbl10.BackColor = System.Drawing.Color.Transparent;
            this.lbl10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl10.Location = new System.Drawing.Point(8, 64);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(69, 21);
            this.lbl10.TabIndex = 18;
            this.lbl10.Text = "Angle";
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl9
            // 
            this.lbl9.BackColor = System.Drawing.Color.Transparent;
            this.lbl9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl9.Location = new System.Drawing.Point(8, 40);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(69, 21);
            this.lbl9.TabIndex = 17;
            this.lbl9.Text = "Y end/cen";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl8
            // 
            this.lbl8.BackColor = System.Drawing.Color.Transparent;
            this.lbl8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl8.Location = new System.Drawing.Point(8, 16);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(69, 21);
            this.lbl8.TabIndex = 16;
            this.lbl8.Text = "X end/cen";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupJOG
            // 
            this.groupJOG.BackColor = System.Drawing.Color.Transparent;
            this.groupJOG.Controls.Add(this.cboGantrySlave);
            this.groupJOG.Controls.Add(this.chkGantry);
            this.groupJOG.Location = new System.Drawing.Point(255, 200);
            this.groupJOG.Name = "groupJOG";
            this.groupJOG.Size = new System.Drawing.Size(140, 93);
            this.groupJOG.TabIndex = 24;
            this.groupJOG.TabStop = false;
            this.groupJOG.Text = "Gantry";
            // 
            // cboGantrySlave
            // 
            this.cboGantrySlave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGantrySlave.Items.AddRange(new object[] {
            "Do not Search",
            "Do origin revision after Search",
            "Do not origin revision after Search"});
            this.cboGantrySlave.Location = new System.Drawing.Point(9, 16);
            this.cboGantrySlave.Name = "cboGantrySlave";
            this.cboGantrySlave.Size = new System.Drawing.Size(120, 20);
            this.cboGantrySlave.TabIndex = 26;
            // 
            // chkGantry
            // 
            this.chkGantry.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGantry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkGantry.Location = new System.Drawing.Point(9, 38);
            this.chkGantry.Name = "chkGantry";
            this.chkGantry.Size = new System.Drawing.Size(120, 46);
            this.chkGantry.TabIndex = 25;
            this.chkGantry.Text = "Gantry Enable";
            this.chkGantry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGantry.CheckedChanged += new System.EventHandler(this.chkGantry_CheckedChanged);
            // 
            // btnCNTCLR
            // 
            this.btnCNTCLR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCNTCLR.Location = new System.Drawing.Point(8, 72);
            this.btnCNTCLR.Name = "btnCNTCLR";
            this.btnCNTCLR.Size = new System.Drawing.Size(70, 22);
            this.btnCNTCLR.TabIndex = 23;
            this.btnCNTCLR.Text = "CNTCLR";
            this.btnCNTCLR.Click += new System.EventHandler(this.btnCNTCLR_Click);
            // 
            // textCmdVelY
            // 
            this.textCmdVelY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdVelY.ForeColor = System.Drawing.Color.Black;
            this.textCmdVelY.Location = new System.Drawing.Point(256, 123);
            this.textCmdVelY.Name = "textCmdVelY";
            this.textCmdVelY.ReadOnly = true;
            this.textCmdVelY.Size = new System.Drawing.Size(85, 21);
            this.textCmdVelY.TabIndex = 22;
            this.textCmdVelY.Text = "0.000";
            this.textCmdVelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textActPosY
            // 
            this.textActPosY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textActPosY.ForeColor = System.Drawing.Color.Black;
            this.textActPosY.Location = new System.Drawing.Point(168, 123);
            this.textActPosY.Name = "textActPosY";
            this.textActPosY.ReadOnly = true;
            this.textActPosY.Size = new System.Drawing.Size(85, 21);
            this.textActPosY.TabIndex = 21;
            this.textActPosY.Text = "0.000";
            this.textActPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdPosY
            // 
            this.textCmdPosY.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdPosY.ForeColor = System.Drawing.Color.Black;
            this.textCmdPosY.Location = new System.Drawing.Point(80, 123);
            this.textCmdPosY.Name = "textCmdPosY";
            this.textCmdPosY.ReadOnly = true;
            this.textCmdPosY.Size = new System.Drawing.Size(85, 21);
            this.textCmdPosY.TabIndex = 20;
            this.textCmdPosY.Text = "0.000";
            this.textCmdPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdVelX
            // 
            this.textCmdVelX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdVelX.ForeColor = System.Drawing.Color.Black;
            this.textCmdVelX.Location = new System.Drawing.Point(256, 99);
            this.textCmdVelX.Name = "textCmdVelX";
            this.textCmdVelX.ReadOnly = true;
            this.textCmdVelX.Size = new System.Drawing.Size(85, 21);
            this.textCmdVelX.TabIndex = 19;
            this.textCmdVelX.Text = "0.000";
            this.textCmdVelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textActPosX
            // 
            this.textActPosX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textActPosX.ForeColor = System.Drawing.Color.Black;
            this.textActPosX.Location = new System.Drawing.Point(168, 99);
            this.textActPosX.Name = "textActPosX";
            this.textActPosX.ReadOnly = true;
            this.textActPosX.Size = new System.Drawing.Size(85, 21);
            this.textActPosX.TabIndex = 18;
            this.textActPosX.Text = "0.000";
            this.textActPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textCmdPosX
            // 
            this.textCmdPosX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCmdPosX.ForeColor = System.Drawing.Color.Black;
            this.textCmdPosX.Location = new System.Drawing.Point(80, 99);
            this.textCmdPosX.Name = "textCmdPosX";
            this.textCmdPosX.ReadOnly = true;
            this.textCmdPosX.Size = new System.Drawing.Size(85, 21);
            this.textCmdPosX.TabIndex = 17;
            this.textCmdPosX.Text = "0.000";
            this.textCmdPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl7
            // 
            this.lbl7.BackColor = System.Drawing.Color.Transparent;
            this.lbl7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl7.Location = new System.Drawing.Point(8, 124);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(69, 18);
            this.lbl7.TabIndex = 16;
            this.lbl7.Text = "Axis Y";
            this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl6
            // 
            this.lbl6.BackColor = System.Drawing.Color.Transparent;
            this.lbl6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl6.Location = new System.Drawing.Point(8, 101);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(69, 18);
            this.lbl6.TabIndex = 15;
            this.lbl6.Text = "Axis X";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl5
            // 
            this.lbl5.BackColor = System.Drawing.Color.Gray;
            this.lbl5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl5.Location = new System.Drawing.Point(256, 72);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(85, 22);
            this.lbl5.TabIndex = 14;
            this.lbl5.Text = "CMD VEL";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.Gray;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl4.Location = new System.Drawing.Point(168, 72);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(85, 22);
            this.lbl4.TabIndex = 13;
            this.lbl4.Text = "ACT POS";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.Gray;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl3.Location = new System.Drawing.Point(80, 72);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(85, 22);
            this.lbl3.TabIndex = 12;
            this.lbl3.Text = "CMD POS";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(334, 16);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(52, 21);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Setting";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // cboEncInputM
            // 
            this.cboEncInputM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboEncInputM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEncInputM.ItemHeight = 12;
            this.cboEncInputM.Items.AddRange(new object[] {
            "Up/Down",
            "1Multiple",
            "2Multiples",
            "4Multiples",
            "Rev Up/Down",
            "Rev 1 Multiple",
            "Rev 2 Multiples",
            "Rev 4 Multiples"});
            this.cboEncInputM.Location = new System.Drawing.Point(274, 44);
            this.cboEncInputM.Name = "cboEncInputM";
            this.cboEncInputM.Size = new System.Drawing.Size(113, 20);
            this.cboEncInputM.TabIndex = 10;
            this.cboEncInputM.SelectedIndexChanged += new System.EventHandler(this.cboEncInputM_SelectedIndexChanged);
            // 
            // cboPulseOutM
            // 
            this.cboPulseOutM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboPulseOutM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPulseOutM.Items.AddRange(new object[] {
            "OneHighLowHigh",
            "OneHighHighLow",
            "OneLowLowHigh",
            "OneLowHighLow",
            "TwoCcwCwHigh",
            "TwoCcwCwLow",
            "TwoCwCcwHigh",
            "TwoCwCcwLow",
            "TwoPhase",
            "TwoPhaseReverse"});
            this.cboPulseOutM.Location = new System.Drawing.Point(84, 44);
            this.cboPulseOutM.Name = "cboPulseOutM";
            this.cboPulseOutM.Size = new System.Drawing.Size(117, 20);
            this.cboPulseOutM.TabIndex = 9;
            this.cboPulseOutM.SelectedIndexChanged += new System.EventHandler(this.cboPulseOutM_SelectedIndexChanged);
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl2.Location = new System.Drawing.Point(202, 44);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(71, 20);
            this.lbl2.TabIndex = 8;
            this.lbl2.Text = "Encoder_M";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl1.Location = new System.Drawing.Point(8, 44);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(73, 20);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "Pulseout_M";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numStartSpeed
            // 
            this.numStartSpeed.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numStartSpeed.DecimalPlaces = 3;
            this.numStartSpeed.ForeColor = System.Drawing.Color.Black;
            this.numStartSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numStartSpeed.Location = new System.Drawing.Point(275, 16);
            this.numStartSpeed.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numStartSpeed.Name = "numStartSpeed";
            this.numStartSpeed.Size = new System.Drawing.Size(57, 21);
            this.numStartSpeed.TabIndex = 6;
            this.numStartSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStartSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numStartSpeed_KeyDown);
            // 
            // numMoveUnit
            // 
            this.numMoveUnit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numMoveUnit.DecimalPlaces = 3;
            this.numMoveUnit.ForeColor = System.Drawing.Color.Black;
            this.numMoveUnit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMoveUnit.Location = new System.Drawing.Point(40, 16);
            this.numMoveUnit.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numMoveUnit.Name = "numMoveUnit";
            this.numMoveUnit.Size = new System.Drawing.Size(64, 21);
            this.numMoveUnit.TabIndex = 5;
            this.numMoveUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMoveUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numMoveUnit_KeyDown);
            // 
            // lblStartSpeed
            // 
            this.lblStartSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblStartSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStartSpeed.Location = new System.Drawing.Point(203, 16);
            this.lblStartSpeed.Name = "lblStartSpeed";
            this.lblStartSpeed.Size = new System.Drawing.Size(70, 21);
            this.lblStartSpeed.TabIndex = 4;
            this.lblStartSpeed.Text = "StartSpeed";
            this.lblStartSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitPulse
            // 
            this.lblUnitPulse.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitPulse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnitPulse.Location = new System.Drawing.Point(8, 16);
            this.lblUnitPulse.Name = "lblUnitPulse";
            this.lblUnitPulse.Size = new System.Drawing.Size(32, 21);
            this.lblUnitPulse.TabIndex = 3;
            this.lblUnitPulse.Text = "Unit";
            this.lblUnitPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl47
            // 
            this.lbl47.BackColor = System.Drawing.Color.Gray;
            this.lbl47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl47.Location = new System.Drawing.Point(343, 72);
            this.lbl47.Name = "lbl47";
            this.lbl47.Size = new System.Drawing.Size(44, 22);
            this.lbl47.TabIndex = 37;
            this.lbl47.Text = "JOG";
            this.lbl47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnJogNX
            // 
            this.btnJogNX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogNX.Location = new System.Drawing.Point(366, 99);
            this.btnJogNX.Name = "btnJogNX";
            this.btnJogNX.Size = new System.Drawing.Size(21, 21);
            this.btnJogNX.TabIndex = 27;
            this.btnJogNX.Text = "-";
            this.btnJogNX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogNX_MouseDown);
            this.btnJogNX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogNX_MouseUp);
            // 
            // btnJogPX
            // 
            this.btnJogPX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogPX.Location = new System.Drawing.Point(343, 99);
            this.btnJogPX.Name = "btnJogPX";
            this.btnJogPX.Size = new System.Drawing.Size(21, 21);
            this.btnJogPX.TabIndex = 26;
            this.btnJogPX.Text = "+";
            this.btnJogPX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPX_MouseDown);
            this.btnJogPX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPX_MouseUp);
            // 
            // btnJogPY
            // 
            this.btnJogPY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogPY.Location = new System.Drawing.Point(343, 123);
            this.btnJogPY.Name = "btnJogPY";
            this.btnJogPY.Size = new System.Drawing.Size(21, 21);
            this.btnJogPY.TabIndex = 24;
            this.btnJogPY.Text = "+";
            this.btnJogPY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPY_MouseDown);
            this.btnJogPY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPY_MouseUp);
            // 
            // btnJogNY
            // 
            this.btnJogNY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJogNY.Location = new System.Drawing.Point(366, 123);
            this.btnJogNY.Name = "btnJogNY";
            this.btnJogNY.Size = new System.Drawing.Size(21, 21);
            this.btnJogNY.TabIndex = 25;
            this.btnJogNY.Text = "-";
            this.btnJogNY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogNY_MouseDown);
            this.btnJogNY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogNY_MouseUp);
            // 
            // groupSignalSearch
            // 
            this.groupSignalSearch.BackColor = System.Drawing.Color.Transparent;
            this.groupSignalSearch.Controls.Add(this.btnSearch);
            this.groupSignalSearch.Controls.Add(this.cboStopMethod);
            this.groupSignalSearch.Controls.Add(this.cboDirection);
            this.groupSignalSearch.Controls.Add(this.cboDetectSignal);
            this.groupSignalSearch.Controls.Add(this.lbl17);
            this.groupSignalSearch.Controls.Add(this.lbl16);
            this.groupSignalSearch.Controls.Add(this.lbl15);
            this.groupSignalSearch.Location = new System.Drawing.Point(636, 352);
            this.groupSignalSearch.Name = "groupSignalSearch";
            this.groupSignalSearch.Size = new System.Drawing.Size(195, 116);
            this.groupSignalSearch.TabIndex = 5;
            this.groupSignalSearch.TabStop = false;
            this.groupSignalSearch.Text = "Signal search";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(8, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(180, 24);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboStopMethod
            // 
            this.cboStopMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboStopMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopMethod.Items.AddRange(new object[] {
            "SSTOP",
            "ESTOP"});
            this.cboStopMethod.Location = new System.Drawing.Point(91, 60);
            this.cboStopMethod.Name = "cboStopMethod";
            this.cboStopMethod.Size = new System.Drawing.Size(97, 20);
            this.cboStopMethod.TabIndex = 22;
            // 
            // cboDirection
            // 
            this.cboDirection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirection.Items.AddRange(new object[] {
            "+CW",
            "-CCW"});
            this.cboDirection.Location = new System.Drawing.Point(91, 38);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(97, 20);
            this.cboDirection.TabIndex = 21;
            // 
            // cboDetectSignal
            // 
            this.cboDetectSignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDetectSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetectSignal.Items.AddRange(new object[] {
            "PosEndLimit (0)",
            "NegEndLimit (1)",
            "HomeSensor DN (4)",
            "EncZPhase DN (5)",
            "UniInput02 DN (6)",
            "UniInput03 DN (7)",
            "HomeSensor UP (4)",
            "EncZPhase UP (5)",
            "UniInput02 UP (6)",
            "UniInput03 UP (7)"});
            this.cboDetectSignal.Location = new System.Drawing.Point(91, 16);
            this.cboDetectSignal.Name = "cboDetectSignal";
            this.cboDetectSignal.Size = new System.Drawing.Size(97, 20);
            this.cboDetectSignal.TabIndex = 20;
            // 
            // lbl17
            // 
            this.lbl17.BackColor = System.Drawing.Color.Transparent;
            this.lbl17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl17.Location = new System.Drawing.Point(8, 60);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(80, 20);
            this.lbl17.TabIndex = 17;
            this.lbl17.Text = "Stop Method";
            this.lbl17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl16
            // 
            this.lbl16.BackColor = System.Drawing.Color.Transparent;
            this.lbl16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl16.Location = new System.Drawing.Point(8, 38);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(80, 20);
            this.lbl16.TabIndex = 16;
            this.lbl16.Text = "Direction";
            this.lbl16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl15
            // 
            this.lbl15.BackColor = System.Drawing.Color.Transparent;
            this.lbl15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl15.Location = new System.Drawing.Point(8, 16);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(80, 20);
            this.lbl15.TabIndex = 15;
            this.lbl15.Text = "Detect Sig";
            this.lbl15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSigCapture);
            this.groupBox1.Controls.Add(this.btnVelOverride);
            this.groupBox1.Location = new System.Drawing.Point(837, 458);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 48);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Override && CaptureMode";
            // 
            // btnSigCapture
            // 
            this.btnSigCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigCapture.Enabled = false;
            this.btnSigCapture.Location = new System.Drawing.Point(8, 16);
            this.btnSigCapture.Name = "btnSigCapture";
            this.btnSigCapture.Size = new System.Drawing.Size(88, 24);
            this.btnSigCapture.TabIndex = 28;
            this.btnSigCapture.Text = "CaptureMove";
            this.btnSigCapture.Click += new System.EventHandler(this.btnCaptureMove_Click);
            // 
            // btnVelOverride
            // 
            this.btnVelOverride.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVelOverride.Location = new System.Drawing.Point(98, 16);
            this.btnVelOverride.Name = "btnVelOverride";
            this.btnVelOverride.Size = new System.Drawing.Size(63, 24);
            this.btnVelOverride.TabIndex = 27;
            this.btnVelOverride.Text = "Override";
            this.btnVelOverride.Click += new System.EventHandler(this.btnVelOverride_Click);
            // 
            // btnHomeSingle
            // 
            this.btnHomeSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomeSingle.Location = new System.Drawing.Point(74, 152);
            this.btnHomeSingle.Name = "btnHomeSingle";
            this.btnHomeSingle.Size = new System.Drawing.Size(87, 24);
            this.btnHomeSingle.TabIndex = 28;
            this.btnHomeSingle.Text = "SingleHome";
            this.btnHomeSingle.Click += new System.EventHandler(this.btnHomeSingle_Click);
            // 
            // btnHomeAll
            // 
            this.btnHomeAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomeAll.Location = new System.Drawing.Point(8, 152);
            this.btnHomeAll.Name = "btnHomeAll";
            this.btnHomeAll.Size = new System.Drawing.Size(64, 24);
            this.btnHomeAll.TabIndex = 27;
            this.btnHomeAll.Text = "All Home";
            this.btnHomeAll.Click += new System.EventHandler(this.btnHomeAll_Click);
            // 
            // lstLog
            // 
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(636, 474);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(195, 220);
            this.lstLog.TabIndex = 27;
            // 
            // edtHomeVelFirst
            // 
            this.edtHomeVelFirst.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtHomeVelFirst.DecimalPlaces = 3;
            this.edtHomeVelFirst.ForeColor = System.Drawing.Color.Black;
            this.edtHomeVelFirst.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtHomeVelFirst.Location = new System.Drawing.Point(73, 16);
            this.edtHomeVelFirst.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtHomeVelFirst.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtHomeVelFirst.Name = "edtHomeVelFirst";
            this.edtHomeVelFirst.ReadOnly = true;
            this.edtHomeVelFirst.Size = new System.Drawing.Size(88, 21);
            this.edtHomeVelFirst.TabIndex = 24;
            this.edtHomeVelFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtHomeVelFirst.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // edtGearRatio
            // 
            this.edtGearRatio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtGearRatio.DecimalPlaces = 3;
            this.edtGearRatio.ForeColor = System.Drawing.Color.Black;
            this.edtGearRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtGearRatio.Location = new System.Drawing.Point(935, 255);
            this.edtGearRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtGearRatio.Name = "edtGearRatio";
            this.edtGearRatio.ReadOnly = true;
            this.edtGearRatio.Size = new System.Drawing.Size(63, 21);
            this.edtGearRatio.TabIndex = 23;
            this.edtGearRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl19
            // 
            this.lbl19.BackColor = System.Drawing.Color.Transparent;
            this.lbl19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl19.Location = new System.Drawing.Point(8, 17);
            this.lbl19.Name = "lbl19";
            this.lbl19.Size = new System.Drawing.Size(64, 21);
            this.lbl19.TabIndex = 19;
            this.lbl19.Text = "Vel First";
            this.lbl19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHomeFun1
            // 
            this.timerHomeFun1.SynchronizingObject = this;
            this.timerHomeFun1.Elapsed += new System.Timers.ElapsedEventHandler(this.timerHomeFun1_Elapsed);
            // 
            // timerHomeFun2
            // 
            this.timerHomeFun2.SynchronizingObject = this;
            this.timerHomeFun2.Elapsed += new System.Timers.ElapsedEventHandler(this.timerHomeFun2_Elapsed);
            // 
            // timerHomeFun3
            // 
            this.timerHomeFun3.SynchronizingObject = this;
            this.timerHomeFun3.Elapsed += new System.Timers.ElapsedEventHandler(this.timerHomeFun3_Elapsed);
            // 
            // timerHomeFun4
            // 
            this.timerHomeFun4.SynchronizingObject = this;
            this.timerHomeFun4.Elapsed += new System.Timers.ElapsedEventHandler(this.timerHomeFun4_Elapsed);
            // 
            // timerDisplay
            // 
            this.timerDisplay.Enabled = true;
            this.timerDisplay.Interval = 50;
            this.timerDisplay.SynchronizingObject = this;
            this.timerDisplay.Elapsed += new System.Timers.ElapsedEventHandler(this.timerDisplay_Elapsed);
            // 
            // timerGraph
            // 
            this.timerGraph.Enabled = true;
            this.timerGraph.Interval = 50;
            this.timerGraph.SynchronizingObject = this;
            this.timerGraph.Elapsed += new System.Timers.ElapsedEventHandler(this.timerGraph_Elapsed);
            // 
            // groupIO
            // 
            this.groupIO.BackColor = System.Drawing.Color.Transparent;
            this.groupIO.Controls.Add(this.groupCRC);
            this.groupIO.Controls.Add(this.groupMPG);
            this.groupIO.Controls.Add(this.groupMechanical);
            this.groupIO.Controls.Add(this.groupUnivIO);
            this.groupIO.Controls.Add(this.groupLevelSetting);
            this.groupIO.Location = new System.Drawing.Point(8, 332);
            this.groupIO.Name = "groupIO";
            this.groupIO.Size = new System.Drawing.Size(221, 362);
            this.groupIO.TabIndex = 6;
            this.groupIO.TabStop = false;
            this.groupIO.Tag = "";
            this.groupIO.Text = "I / O";
            // 
            // groupCRC
            // 
            this.groupCRC.Controls.Add(this.btnCRCOff);
            this.groupCRC.Controls.Add(this.btnCRCOn);
            this.groupCRC.Location = new System.Drawing.Point(109, 284);
            this.groupCRC.Name = "groupCRC";
            this.groupCRC.Size = new System.Drawing.Size(112, 78);
            this.groupCRC.TabIndex = 4;
            this.groupCRC.TabStop = false;
            this.groupCRC.Text = "CRC";
            // 
            // btnCRCOff
            // 
            this.btnCRCOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCRCOff.Location = new System.Drawing.Point(8, 45);
            this.btnCRCOff.Name = "btnCRCOff";
            this.btnCRCOff.Size = new System.Drawing.Size(96, 24);
            this.btnCRCOff.TabIndex = 25;
            this.btnCRCOff.Text = "CRC OFF";
            this.btnCRCOff.Click += new System.EventHandler(this.btnCRCOff_Click);
            // 
            // btnCRCOn
            // 
            this.btnCRCOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCRCOn.Location = new System.Drawing.Point(8, 16);
            this.btnCRCOn.Name = "btnCRCOn";
            this.btnCRCOn.Size = new System.Drawing.Size(96, 24);
            this.btnCRCOn.TabIndex = 24;
            this.btnCRCOn.Text = "CRC ON";
            this.btnCRCOn.Click += new System.EventHandler(this.btnCRCOn_Click);
            // 
            // groupMPG
            // 
            this.groupMPG.Controls.Add(this.btnMPGOff);
            this.groupMPG.Controls.Add(this.btnMPGOn);
            this.groupMPG.Location = new System.Drawing.Point(109, 192);
            this.groupMPG.Name = "groupMPG";
            this.groupMPG.Size = new System.Drawing.Size(112, 83);
            this.groupMPG.TabIndex = 3;
            this.groupMPG.TabStop = false;
            this.groupMPG.Text = "MPG";
            // 
            // btnMPGOff
            // 
            this.btnMPGOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMPGOff.Enabled = false;
            this.btnMPGOff.Location = new System.Drawing.Point(8, 48);
            this.btnMPGOff.Name = "btnMPGOff";
            this.btnMPGOff.Size = new System.Drawing.Size(96, 24);
            this.btnMPGOff.TabIndex = 25;
            this.btnMPGOff.Text = "MPG OFF";
            this.btnMPGOff.Click += new System.EventHandler(this.btnMPGOff_Click);
            // 
            // btnMPGOn
            // 
            this.btnMPGOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMPGOn.Enabled = false;
            this.btnMPGOn.Location = new System.Drawing.Point(8, 16);
            this.btnMPGOn.Name = "btnMPGOn";
            this.btnMPGOn.Size = new System.Drawing.Size(96, 24);
            this.btnMPGOn.TabIndex = 24;
            this.btnMPGOn.Text = "MPG ON";
            this.btnMPGOn.Click += new System.EventHandler(this.btnMPGOn_Click);
            // 
            // groupMechanical
            // 
            this.groupMechanical.Controls.Add(this.lblLedEMG);
            this.groupMechanical.Controls.Add(this.lblLedZphase);
            this.groupMechanical.Controls.Add(this.lblLedHome);
            this.groupMechanical.Controls.Add(this.lblLedAlarm);
            this.groupMechanical.Controls.Add(this.lblLedInposition);
            this.groupMechanical.Controls.Add(this.lblLedNELM);
            this.groupMechanical.Controls.Add(this.lblLedPELM);
            this.groupMechanical.Location = new System.Drawing.Point(0, 193);
            this.groupMechanical.Name = "groupMechanical";
            this.groupMechanical.Size = new System.Drawing.Size(104, 169);
            this.groupMechanical.TabIndex = 2;
            this.groupMechanical.TabStop = false;
            this.groupMechanical.Text = "Mechanical";
            // 
            // lblLedEMG
            // 
            this.lblLedEMG.BackColor = System.Drawing.Color.Transparent;
            this.lblLedEMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedEMG.Location = new System.Drawing.Point(8, 142);
            this.lblLedEMG.Name = "lblLedEMG";
            this.lblLedEMG.Size = new System.Drawing.Size(88, 18);
            this.lblLedEMG.TabIndex = 20;
            this.lblLedEMG.Text = "Emg";
            this.lblLedEMG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedZphase
            // 
            this.lblLedZphase.BackColor = System.Drawing.Color.Transparent;
            this.lblLedZphase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedZphase.Location = new System.Drawing.Point(8, 121);
            this.lblLedZphase.Name = "lblLedZphase";
            this.lblLedZphase.Size = new System.Drawing.Size(88, 18);
            this.lblLedZphase.TabIndex = 19;
            this.lblLedZphase.Text = "Zphas";
            this.lblLedZphase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedHome
            // 
            this.lblLedHome.BackColor = System.Drawing.Color.Transparent;
            this.lblLedHome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedHome.Location = new System.Drawing.Point(8, 100);
            this.lblLedHome.Name = "lblLedHome";
            this.lblLedHome.Size = new System.Drawing.Size(88, 18);
            this.lblLedHome.TabIndex = 18;
            this.lblLedHome.Text = "Home";
            this.lblLedHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedAlarm
            // 
            this.lblLedAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lblLedAlarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedAlarm.Location = new System.Drawing.Point(8, 79);
            this.lblLedAlarm.Name = "lblLedAlarm";
            this.lblLedAlarm.Size = new System.Drawing.Size(88, 18);
            this.lblLedAlarm.TabIndex = 17;
            this.lblLedAlarm.Text = "Alarm";
            this.lblLedAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedInposition
            // 
            this.lblLedInposition.BackColor = System.Drawing.Color.Transparent;
            this.lblLedInposition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedInposition.Location = new System.Drawing.Point(8, 58);
            this.lblLedInposition.Name = "lblLedInposition";
            this.lblLedInposition.Size = new System.Drawing.Size(88, 18);
            this.lblLedInposition.TabIndex = 16;
            this.lblLedInposition.Text = "Inposition";
            this.lblLedInposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedNELM
            // 
            this.lblLedNELM.BackColor = System.Drawing.Color.Transparent;
            this.lblLedNELM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedNELM.Location = new System.Drawing.Point(8, 37);
            this.lblLedNELM.Name = "lblLedNELM";
            this.lblLedNELM.Size = new System.Drawing.Size(88, 18);
            this.lblLedNELM.TabIndex = 15;
            this.lblLedNELM.Text = "- End Limit";
            this.lblLedNELM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedPELM
            // 
            this.lblLedPELM.BackColor = System.Drawing.Color.Transparent;
            this.lblLedPELM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedPELM.Location = new System.Drawing.Point(8, 16);
            this.lblLedPELM.Name = "lblLedPELM";
            this.lblLedPELM.Size = new System.Drawing.Size(88, 18);
            this.lblLedPELM.TabIndex = 13;
            this.lblLedPELM.Text = "+ End Limit";
            this.lblLedPELM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupUnivIO
            // 
            this.groupUnivIO.Controls.Add(this.lblLedOut1);
            this.groupUnivIO.Controls.Add(this.lblLedOut5);
            this.groupUnivIO.Controls.Add(this.lblLedOut4);
            this.groupUnivIO.Controls.Add(this.lblLedOut3);
            this.groupUnivIO.Controls.Add(this.lblLedOut2);
            this.groupUnivIO.Controls.Add(this.lblLedOut0);
            this.groupUnivIO.Controls.Add(this.lblLedIn1);
            this.groupUnivIO.Controls.Add(this.lblLedIn5);
            this.groupUnivIO.Controls.Add(this.lblLedIn4);
            this.groupUnivIO.Controls.Add(this.lblLedIn3);
            this.groupUnivIO.Controls.Add(this.lblLedIn2);
            this.groupUnivIO.Controls.Add(this.lblLedIn0);
            this.groupUnivIO.Controls.Add(this.lbl27);
            this.groupUnivIO.Controls.Add(this.lbl26);
            this.groupUnivIO.Location = new System.Drawing.Point(109, 19);
            this.groupUnivIO.Name = "groupUnivIO";
            this.groupUnivIO.Size = new System.Drawing.Size(112, 167);
            this.groupUnivIO.TabIndex = 1;
            this.groupUnivIO.TabStop = false;
            this.groupUnivIO.Text = "Universal";
            // 
            // lblLedOut1
            // 
            this.lblLedOut1.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut1.Location = new System.Drawing.Point(58, 59);
            this.lblLedOut1.Name = "lblLedOut1";
            this.lblLedOut1.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut1.TabIndex = 32;
            this.lblLedOut1.Text = "Alm";
            this.lblLedOut1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut1.Click += new System.EventHandler(this.lblLedOut1_Click);
            // 
            // lblLedOut5
            // 
            this.lblLedOut5.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut5.Enabled = false;
            this.lblLedOut5.Location = new System.Drawing.Point(58, 139);
            this.lblLedOut5.Name = "lblLedOut5";
            this.lblLedOut5.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut5.TabIndex = 31;
            this.lblLedOut5.Text = "5";
            this.lblLedOut5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut5.Click += new System.EventHandler(this.lblLedOut5_Click);
            // 
            // lblLedOut4
            // 
            this.lblLedOut4.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut4.Enabled = false;
            this.lblLedOut4.Location = new System.Drawing.Point(58, 119);
            this.lblLedOut4.Name = "lblLedOut4";
            this.lblLedOut4.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut4.TabIndex = 30;
            this.lblLedOut4.Text = "4";
            this.lblLedOut4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut4.Click += new System.EventHandler(this.lblLedOut4_Click);
            // 
            // lblLedOut3
            // 
            this.lblLedOut3.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut3.Location = new System.Drawing.Point(58, 99);
            this.lblLedOut3.Name = "lblLedOut3";
            this.lblLedOut3.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut3.TabIndex = 29;
            this.lblLedOut3.Text = "3";
            this.lblLedOut3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut3.Click += new System.EventHandler(this.lblLedOut3_Click);
            // 
            // lblLedOut2
            // 
            this.lblLedOut2.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut2.Location = new System.Drawing.Point(58, 79);
            this.lblLedOut2.Name = "lblLedOut2";
            this.lblLedOut2.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut2.TabIndex = 28;
            this.lblLedOut2.Text = "2";
            this.lblLedOut2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut2.Click += new System.EventHandler(this.lblLedOut2_Click);
            // 
            // lblLedOut0
            // 
            this.lblLedOut0.BackColor = System.Drawing.Color.Transparent;
            this.lblLedOut0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedOut0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLedOut0.Location = new System.Drawing.Point(58, 39);
            this.lblLedOut0.Name = "lblLedOut0";
            this.lblLedOut0.Size = new System.Drawing.Size(46, 18);
            this.lblLedOut0.TabIndex = 27;
            this.lblLedOut0.Text = "SvOn";
            this.lblLedOut0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLedOut0.Click += new System.EventHandler(this.lblLedOut0_Click);
            // 
            // lblLedIn1
            // 
            this.lblLedIn1.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn1.Location = new System.Drawing.Point(8, 59);
            this.lblLedIn1.Name = "lblLedIn1";
            this.lblLedIn1.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn1.TabIndex = 22;
            this.lblLedIn1.Text = "Zph";
            this.lblLedIn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedIn5
            // 
            this.lblLedIn5.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn5.Enabled = false;
            this.lblLedIn5.Location = new System.Drawing.Point(8, 139);
            this.lblLedIn5.Name = "lblLedIn5";
            this.lblLedIn5.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn5.TabIndex = 21;
            this.lblLedIn5.Text = "5";
            this.lblLedIn5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedIn4
            // 
            this.lblLedIn4.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn4.Enabled = false;
            this.lblLedIn4.Location = new System.Drawing.Point(8, 119);
            this.lblLedIn4.Name = "lblLedIn4";
            this.lblLedIn4.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn4.TabIndex = 20;
            this.lblLedIn4.Text = "4";
            this.lblLedIn4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedIn3
            // 
            this.lblLedIn3.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn3.Location = new System.Drawing.Point(8, 99);
            this.lblLedIn3.Name = "lblLedIn3";
            this.lblLedIn3.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn3.TabIndex = 19;
            this.lblLedIn3.Text = "3";
            this.lblLedIn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedIn2
            // 
            this.lblLedIn2.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn2.Location = new System.Drawing.Point(8, 79);
            this.lblLedIn2.Name = "lblLedIn2";
            this.lblLedIn2.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn2.TabIndex = 17;
            this.lblLedIn2.Text = "2";
            this.lblLedIn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedIn0
            // 
            this.lblLedIn0.BackColor = System.Drawing.Color.Transparent;
            this.lblLedIn0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedIn0.Location = new System.Drawing.Point(8, 39);
            this.lblLedIn0.Name = "lblLedIn0";
            this.lblLedIn0.Size = new System.Drawing.Size(46, 18);
            this.lblLedIn0.TabIndex = 16;
            this.lblLedIn0.Text = "Org";
            this.lblLedIn0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl27
            // 
            this.lbl27.BackColor = System.Drawing.Color.Gray;
            this.lbl27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl27.Location = new System.Drawing.Point(58, 19);
            this.lbl27.Name = "lbl27";
            this.lbl27.Size = new System.Drawing.Size(46, 18);
            this.lbl27.TabIndex = 15;
            this.lbl27.Text = "O U T";
            this.lbl27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl26
            // 
            this.lbl26.BackColor = System.Drawing.Color.Gray;
            this.lbl26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl26.Location = new System.Drawing.Point(8, 19);
            this.lbl26.Name = "lbl26";
            this.lbl26.Size = new System.Drawing.Size(46, 18);
            this.lbl26.TabIndex = 14;
            this.lbl26.Text = "I N";
            this.lbl26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupLevelSetting
            // 
            this.groupLevelSetting.Controls.Add(this.chkEmg);
            this.groupLevelSetting.Controls.Add(this.lbl49);
            this.groupLevelSetting.Controls.Add(this.chkZphase);
            this.groupLevelSetting.Controls.Add(this.chkHomeLevel);
            this.groupLevelSetting.Controls.Add(this.chkAlarmLevel);
            this.groupLevelSetting.Controls.Add(this.chkInpLevel);
            this.groupLevelSetting.Controls.Add(this.chkNELMLevel);
            this.groupLevelSetting.Controls.Add(this.lbl25);
            this.groupLevelSetting.Controls.Add(this.lbl24);
            this.groupLevelSetting.Controls.Add(this.lbl23);
            this.groupLevelSetting.Controls.Add(this.lbl22);
            this.groupLevelSetting.Controls.Add(this.lbl21);
            this.groupLevelSetting.Controls.Add(this.chkPELMLevel);
            this.groupLevelSetting.Controls.Add(this.lbl20);
            this.groupLevelSetting.Location = new System.Drawing.Point(0, 19);
            this.groupLevelSetting.Name = "groupLevelSetting";
            this.groupLevelSetting.Size = new System.Drawing.Size(104, 167);
            this.groupLevelSetting.TabIndex = 0;
            this.groupLevelSetting.TabStop = false;
            this.groupLevelSetting.Text = "Level setting";
            // 
            // chkEmg
            // 
            this.chkEmg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEmg.Location = new System.Drawing.Point(81, 139);
            this.chkEmg.Name = "chkEmg";
            this.chkEmg.Size = new System.Drawing.Size(16, 18);
            this.chkEmg.TabIndex = 26;
            this.chkEmg.ThreeState = true;
            this.chkEmg.CheckedChanged += new System.EventHandler(this.chkEmg_CheckedChanged);
            // 
            // lbl49
            // 
            this.lbl49.BackColor = System.Drawing.Color.Transparent;
            this.lbl49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl49.Location = new System.Drawing.Point(7, 139);
            this.lbl49.Name = "lbl49";
            this.lbl49.Size = new System.Drawing.Size(70, 18);
            this.lbl49.TabIndex = 25;
            this.lbl49.Text = "Emg";
            this.lbl49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkZphase
            // 
            this.chkZphase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkZphase.Location = new System.Drawing.Point(81, 119);
            this.chkZphase.Name = "chkZphase";
            this.chkZphase.Size = new System.Drawing.Size(16, 18);
            this.chkZphase.TabIndex = 24;
            this.chkZphase.CheckedChanged += new System.EventHandler(this.chkZphase_CheckedChanged);
            // 
            // chkHomeLevel
            // 
            this.chkHomeLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkHomeLevel.Location = new System.Drawing.Point(81, 99);
            this.chkHomeLevel.Name = "chkHomeLevel";
            this.chkHomeLevel.Size = new System.Drawing.Size(16, 18);
            this.chkHomeLevel.TabIndex = 23;
            this.chkHomeLevel.CheckedChanged += new System.EventHandler(this.chkHomeLevel_CheckedChanged);
            // 
            // chkAlarmLevel
            // 
            this.chkAlarmLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAlarmLevel.Location = new System.Drawing.Point(81, 79);
            this.chkAlarmLevel.Name = "chkAlarmLevel";
            this.chkAlarmLevel.Size = new System.Drawing.Size(16, 18);
            this.chkAlarmLevel.TabIndex = 22;
            this.chkAlarmLevel.ThreeState = true;
            this.chkAlarmLevel.CheckedChanged += new System.EventHandler(this.chkAlarmLevel_CheckedChanged);
            // 
            // chkInpLevel
            // 
            this.chkInpLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkInpLevel.Location = new System.Drawing.Point(81, 59);
            this.chkInpLevel.Name = "chkInpLevel";
            this.chkInpLevel.Size = new System.Drawing.Size(16, 18);
            this.chkInpLevel.TabIndex = 21;
            this.chkInpLevel.ThreeState = true;
            this.chkInpLevel.CheckedChanged += new System.EventHandler(this.chkInpositionLevel_CheckedChanged);
            // 
            // chkNELMLevel
            // 
            this.chkNELMLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkNELMLevel.Location = new System.Drawing.Point(81, 39);
            this.chkNELMLevel.Name = "chkNELMLevel";
            this.chkNELMLevel.Size = new System.Drawing.Size(16, 18);
            this.chkNELMLevel.TabIndex = 20;
            this.chkNELMLevel.ThreeState = true;
            this.chkNELMLevel.CheckedChanged += new System.EventHandler(this.chkNELMLevel_CheckedChanged);
            // 
            // lbl25
            // 
            this.lbl25.BackColor = System.Drawing.Color.Transparent;
            this.lbl25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl25.Location = new System.Drawing.Point(7, 119);
            this.lbl25.Name = "lbl25";
            this.lbl25.Size = new System.Drawing.Size(70, 18);
            this.lbl25.TabIndex = 19;
            this.lbl25.Text = "Zphas";
            this.lbl25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl24
            // 
            this.lbl24.BackColor = System.Drawing.Color.Transparent;
            this.lbl24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl24.Location = new System.Drawing.Point(7, 99);
            this.lbl24.Name = "lbl24";
            this.lbl24.Size = new System.Drawing.Size(70, 18);
            this.lbl24.TabIndex = 18;
            this.lbl24.Text = "Home";
            this.lbl24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl23
            // 
            this.lbl23.BackColor = System.Drawing.Color.Transparent;
            this.lbl23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl23.Location = new System.Drawing.Point(7, 79);
            this.lbl23.Name = "lbl23";
            this.lbl23.Size = new System.Drawing.Size(70, 18);
            this.lbl23.TabIndex = 17;
            this.lbl23.Text = "Alarm";
            this.lbl23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl22
            // 
            this.lbl22.BackColor = System.Drawing.Color.Transparent;
            this.lbl22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl22.Location = new System.Drawing.Point(7, 59);
            this.lbl22.Name = "lbl22";
            this.lbl22.Size = new System.Drawing.Size(70, 18);
            this.lbl22.TabIndex = 16;
            this.lbl22.Text = "Inposition";
            this.lbl22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl21
            // 
            this.lbl21.BackColor = System.Drawing.Color.Transparent;
            this.lbl21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl21.Location = new System.Drawing.Point(7, 39);
            this.lbl21.Name = "lbl21";
            this.lbl21.Size = new System.Drawing.Size(70, 18);
            this.lbl21.TabIndex = 15;
            this.lbl21.Text = "- End Limit";
            this.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkPELMLevel
            // 
            this.chkPELMLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPELMLevel.Location = new System.Drawing.Point(80, 19);
            this.chkPELMLevel.Name = "chkPELMLevel";
            this.chkPELMLevel.Size = new System.Drawing.Size(16, 18);
            this.chkPELMLevel.TabIndex = 14;
            this.chkPELMLevel.ThreeState = true;
            this.chkPELMLevel.CheckedChanged += new System.EventHandler(this.chkPELMLevel_CheckedChanged);
            // 
            // lbl20
            // 
            this.lbl20.BackColor = System.Drawing.Color.Transparent;
            this.lbl20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl20.Location = new System.Drawing.Point(7, 19);
            this.lbl20.Name = "lbl20";
            this.lbl20.Size = new System.Drawing.Size(70, 18);
            this.lbl20.TabIndex = 13;
            this.lbl20.Text = "+ End Limit";
            this.lbl20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupETC
            // 
            this.groupETC.BackColor = System.Drawing.Color.Transparent;
            this.groupETC.Controls.Add(this.lblLedEXMP);
            this.groupETC.Controls.Add(this.lblLedBusyY);
            this.groupETC.Controls.Add(this.lblLedEXPP);
            this.groupETC.Controls.Add(this.lblLedBusyX);
            this.groupETC.Location = new System.Drawing.Point(8, 696);
            this.groupETC.Name = "groupETC";
            this.groupETC.Size = new System.Drawing.Size(304, 40);
            this.groupETC.TabIndex = 7;
            this.groupETC.TabStop = false;
            this.groupETC.Text = "ETC";
            // 
            // lblLedEXMP
            // 
            this.lblLedEXMP.BackColor = System.Drawing.Color.Transparent;
            this.lblLedEXMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedEXMP.Location = new System.Drawing.Point(227, 14);
            this.lblLedEXMP.Name = "lblLedEXMP";
            this.lblLedEXMP.Size = new System.Drawing.Size(69, 20);
            this.lblLedEXMP.TabIndex = 17;
            this.lblLedEXMP.Text = "EXMP";
            this.lblLedEXMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedBusyY
            // 
            this.lblLedBusyY.BackColor = System.Drawing.Color.Transparent;
            this.lblLedBusyY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedBusyY.Location = new System.Drawing.Point(154, 14);
            this.lblLedBusyY.Name = "lblLedBusyY";
            this.lblLedBusyY.Size = new System.Drawing.Size(69, 20);
            this.lblLedBusyY.TabIndex = 16;
            this.lblLedBusyY.Text = "Y axis ON";
            this.lblLedBusyY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedEXPP
            // 
            this.lblLedEXPP.BackColor = System.Drawing.Color.Transparent;
            this.lblLedEXPP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedEXPP.Location = new System.Drawing.Point(81, 14);
            this.lblLedEXPP.Name = "lblLedEXPP";
            this.lblLedEXPP.Size = new System.Drawing.Size(69, 20);
            this.lblLedEXPP.TabIndex = 15;
            this.lblLedEXPP.Text = "EXPP";
            this.lblLedEXPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLedBusyX
            // 
            this.lblLedBusyX.BackColor = System.Drawing.Color.Transparent;
            this.lblLedBusyX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLedBusyX.Location = new System.Drawing.Point(8, 14);
            this.lblLedBusyX.Name = "lblLedBusyX";
            this.lblLedBusyX.Size = new System.Drawing.Size(69, 20);
            this.lblLedBusyX.TabIndex = 14;
            this.lblLedBusyX.Text = "X axis ON";
            this.lblLedBusyX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupContiInterpolation
            // 
            this.groupContiInterpolation.BackColor = System.Drawing.Color.Transparent;
            this.groupContiInterpolation.Controls.Add(this.btnContiTest);
            this.groupContiInterpolation.Controls.Add(this.btnContiClear);
            this.groupContiInterpolation.Controls.Add(this.btnContiSpline);
            this.groupContiInterpolation.Controls.Add(this.btnContiStart);
            this.groupContiInterpolation.Controls.Add(this.btnContiBlend);
            this.groupContiInterpolation.Controls.Add(this.groupBox2);
            this.groupContiInterpolation.Controls.Add(this.btnContiCircle);
            this.groupContiInterpolation.Controls.Add(this.btnContiLine);
            this.groupContiInterpolation.Location = new System.Drawing.Point(837, 8);
            this.groupContiInterpolation.Name = "groupContiInterpolation";
            this.groupContiInterpolation.Size = new System.Drawing.Size(168, 244);
            this.groupContiInterpolation.TabIndex = 8;
            this.groupContiInterpolation.TabStop = false;
            this.groupContiInterpolation.Text = "ContiInterpolation";
            // 
            // btnContiTest
            // 
            this.btnContiTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiTest.Location = new System.Drawing.Point(8, 213);
            this.btnContiTest.Name = "btnContiTest";
            this.btnContiTest.Size = new System.Drawing.Size(107, 24);
            this.btnContiTest.TabIndex = 38;
            this.btnContiTest.Text = "Verification";
            this.btnContiTest.Click += new System.EventHandler(this.btnContiTest_Click);
            // 
            // btnContiClear
            // 
            this.btnContiClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiClear.Location = new System.Drawing.Point(119, 189);
            this.btnContiClear.Name = "btnContiClear";
            this.btnContiClear.Size = new System.Drawing.Size(42, 48);
            this.btnContiClear.TabIndex = 35;
            this.btnContiClear.Text = "CLR";
            this.btnContiClear.Click += new System.EventHandler(this.btnContiClear_Click);
            // 
            // btnContiSpline
            // 
            this.btnContiSpline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiSpline.Location = new System.Drawing.Point(8, 141);
            this.btnContiSpline.Name = "btnContiSpline";
            this.btnContiSpline.Size = new System.Drawing.Size(107, 24);
            this.btnContiSpline.TabIndex = 32;
            this.btnContiSpline.Text = "2Axis Spline";
            this.btnContiSpline.Click += new System.EventHandler(this.btnContiSpline_Click);
            // 
            // btnContiStart
            // 
            this.btnContiStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiStart.Location = new System.Drawing.Point(119, 141);
            this.btnContiStart.Name = "btnContiStart";
            this.btnContiStart.Size = new System.Drawing.Size(42, 48);
            this.btnContiStart.TabIndex = 31;
            this.btnContiStart.Text = "Start";
            this.btnContiStart.Click += new System.EventHandler(this.btnContiStart_Click);
            // 
            // btnContiBlend
            // 
            this.btnContiBlend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiBlend.Location = new System.Drawing.Point(8, 165);
            this.btnContiBlend.Name = "btnContiBlend";
            this.btnContiBlend.Size = new System.Drawing.Size(107, 24);
            this.btnContiBlend.TabIndex = 27;
            this.btnContiBlend.Text = "Line && Circle";
            this.btnContiBlend.Click += new System.EventHandler(this.btnContiBlend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtInMotion);
            this.groupBox2.Controls.Add(this.edtQFree);
            this.groupBox2.Controls.Add(this.edtTotalNum);
            this.groupBox2.Controls.Add(this.edtContiNum);
            this.groupBox2.Controls.Add(this.lbl31);
            this.groupBox2.Controls.Add(this.lbl30);
            this.groupBox2.Controls.Add(this.lbl29);
            this.groupBox2.Controls.Add(this.lbl28);
            this.groupBox2.Location = new System.Drawing.Point(0, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conti Queue     ";
            // 
            // edtInMotion
            // 
            this.edtInMotion.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtInMotion.ForeColor = System.Drawing.Color.Black;
            this.edtInMotion.Location = new System.Drawing.Point(74, 88);
            this.edtInMotion.Name = "edtInMotion";
            this.edtInMotion.ReadOnly = true;
            this.edtInMotion.Size = new System.Drawing.Size(87, 21);
            this.edtInMotion.TabIndex = 23;
            this.edtInMotion.Text = "0";
            this.edtInMotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edtQFree
            // 
            this.edtQFree.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtQFree.ForeColor = System.Drawing.Color.Black;
            this.edtQFree.Location = new System.Drawing.Point(74, 64);
            this.edtQFree.Name = "edtQFree";
            this.edtQFree.ReadOnly = true;
            this.edtQFree.Size = new System.Drawing.Size(87, 21);
            this.edtQFree.TabIndex = 22;
            this.edtQFree.Text = "0";
            this.edtQFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edtTotalNum
            // 
            this.edtTotalNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtTotalNum.ForeColor = System.Drawing.Color.Black;
            this.edtTotalNum.Location = new System.Drawing.Point(74, 40);
            this.edtTotalNum.Name = "edtTotalNum";
            this.edtTotalNum.ReadOnly = true;
            this.edtTotalNum.Size = new System.Drawing.Size(87, 21);
            this.edtTotalNum.TabIndex = 21;
            this.edtTotalNum.Text = "0";
            this.edtTotalNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edtContiNum
            // 
            this.edtContiNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtContiNum.ForeColor = System.Drawing.Color.Black;
            this.edtContiNum.Location = new System.Drawing.Point(74, 16);
            this.edtContiNum.Name = "edtContiNum";
            this.edtContiNum.ReadOnly = true;
            this.edtContiNum.Size = new System.Drawing.Size(87, 21);
            this.edtContiNum.TabIndex = 20;
            this.edtContiNum.Text = "0";
            this.edtContiNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl31
            // 
            this.lbl31.BackColor = System.Drawing.Color.Transparent;
            this.lbl31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl31.Location = new System.Drawing.Point(8, 88);
            this.lbl31.Name = "lbl31";
            this.lbl31.Size = new System.Drawing.Size(64, 21);
            this.lbl31.TabIndex = 19;
            this.lbl31.Text = "InMotion";
            this.lbl31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl30
            // 
            this.lbl30.BackColor = System.Drawing.Color.Transparent;
            this.lbl30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl30.Location = new System.Drawing.Point(8, 64);
            this.lbl30.Name = "lbl30";
            this.lbl30.Size = new System.Drawing.Size(64, 21);
            this.lbl30.TabIndex = 18;
            this.lbl30.Text = "Q Free";
            this.lbl30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl29
            // 
            this.lbl29.BackColor = System.Drawing.Color.Transparent;
            this.lbl29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl29.Location = new System.Drawing.Point(8, 40);
            this.lbl29.Name = "lbl29";
            this.lbl29.Size = new System.Drawing.Size(64, 21);
            this.lbl29.TabIndex = 17;
            this.lbl29.Text = "TotalNum";
            this.lbl29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl28
            // 
            this.lbl28.BackColor = System.Drawing.Color.Transparent;
            this.lbl28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl28.Location = new System.Drawing.Point(8, 16);
            this.lbl28.Name = "lbl28";
            this.lbl28.Size = new System.Drawing.Size(64, 21);
            this.lbl28.TabIndex = 16;
            this.lbl28.Text = "ContiNum";
            this.lbl28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContiCircle
            // 
            this.btnContiCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiCircle.Location = new System.Drawing.Point(8, 189);
            this.btnContiCircle.Name = "btnContiCircle";
            this.btnContiCircle.Size = new System.Drawing.Size(53, 24);
            this.btnContiCircle.TabIndex = 28;
            this.btnContiCircle.Text = "Circle";
            this.btnContiCircle.Click += new System.EventHandler(this.btnContiCircle_Click);
            // 
            // btnContiLine
            // 
            this.btnContiLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContiLine.Location = new System.Drawing.Point(62, 189);
            this.btnContiLine.Name = "btnContiLine";
            this.btnContiLine.Size = new System.Drawing.Size(53, 24);
            this.btnContiLine.TabIndex = 30;
            this.btnContiLine.Text = "Line";
            this.btnContiLine.Click += new System.EventHandler(this.btnContiLine_Click);
            // 
            // btnReadCapture
            // 
            this.btnReadCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadCapture.Enabled = false;
            this.btnReadCapture.Location = new System.Drawing.Point(9, 14);
            this.btnReadCapture.Name = "btnReadCapture";
            this.btnReadCapture.Size = new System.Drawing.Size(64, 20);
            this.btnReadCapture.TabIndex = 29;
            this.btnReadCapture.Text = "Get Pos";
            this.btnReadCapture.Click += new System.EventHandler(this.btnReadCapture_Click);
            // 
            // groupInterruptMethodSetting
            // 
            this.groupInterruptMethodSetting.BackColor = System.Drawing.Color.Transparent;
            this.groupInterruptMethodSetting.Controls.Add(this.lblInterruptCount);
            this.groupInterruptMethodSetting.Controls.Add(this.lbl32);
            this.groupInterruptMethodSetting.Controls.Add(this.btnIntDisable);
            this.groupInterruptMethodSetting.Controls.Add(this.btnIntEvent);
            this.groupInterruptMethodSetting.Controls.Add(this.btnIntMessage);
            this.groupInterruptMethodSetting.Location = new System.Drawing.Point(320, 696);
            this.groupInterruptMethodSetting.Name = "groupInterruptMethodSetting";
            this.groupInterruptMethodSetting.Size = new System.Drawing.Size(511, 40);
            this.groupInterruptMethodSetting.TabIndex = 9;
            this.groupInterruptMethodSetting.TabStop = false;
            this.groupInterruptMethodSetting.Text = "Interrupt Method Setting";
            // 
            // lblInterruptCount
            // 
            this.lblInterruptCount.BackColor = System.Drawing.Color.Transparent;
            this.lblInterruptCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInterruptCount.Location = new System.Drawing.Point(435, 14);
            this.lblInterruptCount.Name = "lblInterruptCount";
            this.lblInterruptCount.Size = new System.Drawing.Size(68, 20);
            this.lblInterruptCount.TabIndex = 32;
            this.lblInterruptCount.Text = "0";
            this.lblInterruptCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl32
            // 
            this.lbl32.BackColor = System.Drawing.Color.Transparent;
            this.lbl32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl32.Location = new System.Drawing.Point(336, 14);
            this.lbl32.Name = "lbl32";
            this.lbl32.Size = new System.Drawing.Size(95, 20);
            this.lbl32.TabIndex = 31;
            this.lbl32.Text = "Interrupt Count:";
            this.lbl32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIntDisable
            // 
            this.btnIntDisable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntDisable.Enabled = false;
            this.btnIntDisable.Location = new System.Drawing.Point(234, 14);
            this.btnIntDisable.Name = "btnIntDisable";
            this.btnIntDisable.Size = new System.Drawing.Size(95, 20);
            this.btnIntDisable.TabIndex = 30;
            this.btnIntDisable.Text = "DISABLE";
            this.btnIntDisable.Click += new System.EventHandler(this.btnMethodDisable_Click);
            // 
            // btnIntEvent
            // 
            this.btnIntEvent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntEvent.Enabled = false;
            this.btnIntEvent.Location = new System.Drawing.Point(129, 14);
            this.btnIntEvent.Name = "btnIntEvent";
            this.btnIntEvent.Size = new System.Drawing.Size(103, 20);
            this.btnIntEvent.TabIndex = 28;
            this.btnIntEvent.Text = "Event";
            this.btnIntEvent.Click += new System.EventHandler(this.btnEventMethod_Click);
            // 
            // btnIntMessage
            // 
            this.btnIntMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntMessage.Enabled = false;
            this.btnIntMessage.Location = new System.Drawing.Point(8, 14);
            this.btnIntMessage.Name = "btnIntMessage";
            this.btnIntMessage.Size = new System.Drawing.Size(119, 20);
            this.btnIntMessage.TabIndex = 27;
            this.btnIntMessage.Text = "Message";
            this.btnIntMessage.Click += new System.EventHandler(this.btnMessageMethod_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.Transparent;
            this.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatus.Location = new System.Drawing.Point(636, 321);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(92, 24);
            this.btnStatus.TabIndex = 26;
            this.btnStatus.Text = "STATUS";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // groupSenPosMove
            // 
            this.groupSenPosMove.BackColor = System.Drawing.Color.Transparent;
            this.groupSenPosMove.Controls.Add(this.edtHomeVelSecond);
            this.groupSenPosMove.Controls.Add(this.edtHomeVelLast);
            this.groupSenPosMove.Controls.Add(this.edtHomeVelThird);
            this.groupSenPosMove.Controls.Add(this.lbl13);
            this.groupSenPosMove.Controls.Add(this.lbl14);
            this.groupSenPosMove.Controls.Add(this.lbl35);
            this.groupSenPosMove.Controls.Add(this.btnHomeSingle);
            this.groupSenPosMove.Controls.Add(this.btnHomeAll);
            this.groupSenPosMove.Controls.Add(this.lbl19);
            this.groupSenPosMove.Controls.Add(this.edtHomeVelFirst);
            this.groupSenPosMove.Controls.Add(this.lbl36);
            this.groupSenPosMove.Controls.Add(this.lbl37);
            this.groupSenPosMove.Controls.Add(this.cboHomeDir);
            this.groupSenPosMove.Controls.Add(this.cboHomeSignal);
            this.groupSenPosMove.Location = new System.Drawing.Point(837, 508);
            this.groupSenPosMove.Name = "groupSenPosMove";
            this.groupSenPosMove.Size = new System.Drawing.Size(168, 184);
            this.groupSenPosMove.TabIndex = 28;
            this.groupSenPosMove.TabStop = false;
            this.groupSenPosMove.Text = "Home Search";
            // 
            // edtHomeVelSecond
            // 
            this.edtHomeVelSecond.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtHomeVelSecond.DecimalPlaces = 3;
            this.edtHomeVelSecond.ForeColor = System.Drawing.Color.Black;
            this.edtHomeVelSecond.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtHomeVelSecond.Location = new System.Drawing.Point(73, 38);
            this.edtHomeVelSecond.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtHomeVelSecond.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtHomeVelSecond.Name = "edtHomeVelSecond";
            this.edtHomeVelSecond.ReadOnly = true;
            this.edtHomeVelSecond.Size = new System.Drawing.Size(88, 21);
            this.edtHomeVelSecond.TabIndex = 27;
            this.edtHomeVelSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtHomeVelSecond.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // edtHomeVelLast
            // 
            this.edtHomeVelLast.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtHomeVelLast.DecimalPlaces = 3;
            this.edtHomeVelLast.ForeColor = System.Drawing.Color.Black;
            this.edtHomeVelLast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtHomeVelLast.Location = new System.Drawing.Point(73, 80);
            this.edtHomeVelLast.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtHomeVelLast.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtHomeVelLast.Name = "edtHomeVelLast";
            this.edtHomeVelLast.ReadOnly = true;
            this.edtHomeVelLast.Size = new System.Drawing.Size(88, 21);
            this.edtHomeVelLast.TabIndex = 24;
            this.edtHomeVelLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtHomeVelLast.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // edtHomeVelThird
            // 
            this.edtHomeVelThird.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtHomeVelThird.DecimalPlaces = 3;
            this.edtHomeVelThird.ForeColor = System.Drawing.Color.Black;
            this.edtHomeVelThird.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtHomeVelThird.Location = new System.Drawing.Point(73, 60);
            this.edtHomeVelThird.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtHomeVelThird.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtHomeVelThird.Name = "edtHomeVelThird";
            this.edtHomeVelThird.ReadOnly = true;
            this.edtHomeVelThird.Size = new System.Drawing.Size(88, 21);
            this.edtHomeVelThird.TabIndex = 23;
            this.edtHomeVelThird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtHomeVelThird.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lbl13
            // 
            this.lbl13.BackColor = System.Drawing.Color.Transparent;
            this.lbl13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl13.Location = new System.Drawing.Point(8, 82);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(64, 21);
            this.lbl13.TabIndex = 19;
            this.lbl13.Text = "Vel Last";
            this.lbl13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl14
            // 
            this.lbl14.BackColor = System.Drawing.Color.Transparent;
            this.lbl14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl14.Location = new System.Drawing.Point(8, 62);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(64, 21);
            this.lbl14.TabIndex = 18;
            this.lbl14.Text = "Vel Again";
            this.lbl14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl35
            // 
            this.lbl35.BackColor = System.Drawing.Color.Transparent;
            this.lbl35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl35.Location = new System.Drawing.Point(8, 41);
            this.lbl35.Name = "lbl35";
            this.lbl35.Size = new System.Drawing.Size(64, 21);
            this.lbl35.TabIndex = 17;
            this.lbl35.Text = "Vel After";
            this.lbl35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl36
            // 
            this.lbl36.BackColor = System.Drawing.Color.Transparent;
            this.lbl36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl36.Location = new System.Drawing.Point(8, 129);
            this.lbl36.Name = "lbl36";
            this.lbl36.Size = new System.Drawing.Size(64, 21);
            this.lbl36.TabIndex = 16;
            this.lbl36.Text = "Direction";
            this.lbl36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl37
            // 
            this.lbl37.BackColor = System.Drawing.Color.Transparent;
            this.lbl37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl37.Location = new System.Drawing.Point(8, 105);
            this.lbl37.Name = "lbl37";
            this.lbl37.Size = new System.Drawing.Size(64, 21);
            this.lbl37.TabIndex = 15;
            this.lbl37.Text = "Signal";
            this.lbl37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboHomeDir
            // 
            this.cboHomeDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboHomeDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomeDir.Items.AddRange(new object[] {
            "(-)Direction",
            "(+)Direction"});
            this.cboHomeDir.Location = new System.Drawing.Point(73, 128);
            this.cboHomeDir.Name = "cboHomeDir";
            this.cboHomeDir.Size = new System.Drawing.Size(88, 20);
            this.cboHomeDir.TabIndex = 21;
            // 
            // cboHomeSignal
            // 
            this.cboHomeSignal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboHomeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHomeSignal.Items.AddRange(new object[] {
            "PosEndLimit",
            "NegEndLimit",
            "HomeSensor"});
            this.cboHomeSignal.Location = new System.Drawing.Point(73, 104);
            this.cboHomeSignal.Name = "cboHomeSignal";
            this.cboHomeSignal.Size = new System.Drawing.Size(88, 20);
            this.cboHomeSignal.TabIndex = 20;
            // 
            // groupBlockOneShotTrigger
            // 
            this.groupBlockOneShotTrigger.BackColor = System.Drawing.Color.Transparent;
            this.groupBlockOneShotTrigger.Controls.Add(this.btnTrigReset);
            this.groupBlockOneShotTrigger.Controls.Add(this.btnTrigOneShot);
            this.groupBlockOneShotTrigger.Controls.Add(this.btnTrigPeriod);
            this.groupBlockOneShotTrigger.Controls.Add(this.edtTrigPulseWidth);
            this.groupBlockOneShotTrigger.Controls.Add(this.edtTrigCycle);
            this.groupBlockOneShotTrigger.Controls.Add(this.edtTrigStartPosition);
            this.groupBlockOneShotTrigger.Controls.Add(this.btnTrigAbs);
            this.groupBlockOneShotTrigger.Controls.Add(this.edtTrigEndPos);
            this.groupBlockOneShotTrigger.Controls.Add(this.lbl39);
            this.groupBlockOneShotTrigger.Controls.Add(this.lbl40);
            this.groupBlockOneShotTrigger.Controls.Add(this.lbl41);
            this.groupBlockOneShotTrigger.Controls.Add(this.lbl42);
            this.groupBlockOneShotTrigger.Location = new System.Drawing.Point(837, 280);
            this.groupBlockOneShotTrigger.Name = "groupBlockOneShotTrigger";
            this.groupBlockOneShotTrigger.Size = new System.Drawing.Size(168, 174);
            this.groupBlockOneShotTrigger.TabIndex = 29;
            this.groupBlockOneShotTrigger.TabStop = false;
            this.groupBlockOneShotTrigger.Text = "Block  / One Shot Trigger";
            // 
            // btnTrigReset
            // 
            this.btnTrigReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrigReset.Location = new System.Drawing.Point(98, 142);
            this.btnTrigReset.Name = "btnTrigReset";
            this.btnTrigReset.Size = new System.Drawing.Size(63, 24);
            this.btnTrigReset.TabIndex = 34;
            this.btnTrigReset.Text = "Reset";
            this.btnTrigReset.Click += new System.EventHandler(this.btnTrigReset_Click);
            // 
            // btnTrigOneShot
            // 
            this.btnTrigOneShot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrigOneShot.Location = new System.Drawing.Point(98, 116);
            this.btnTrigOneShot.Name = "btnTrigOneShot";
            this.btnTrigOneShot.Size = new System.Drawing.Size(63, 24);
            this.btnTrigOneShot.TabIndex = 33;
            this.btnTrigOneShot.Text = "OneShot";
            this.btnTrigOneShot.Click += new System.EventHandler(this.btnOneShot_Click);
            // 
            // btnTrigPeriod
            // 
            this.btnTrigPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrigPeriod.Location = new System.Drawing.Point(8, 142);
            this.btnTrigPeriod.Name = "btnTrigPeriod";
            this.btnTrigPeriod.Size = new System.Drawing.Size(88, 24);
            this.btnTrigPeriod.TabIndex = 32;
            this.btnTrigPeriod.Text = "Trig(Period)";
            this.btnTrigPeriod.Click += new System.EventHandler(this.btnTrigPeriod_Click);
            // 
            // edtTrigPulseWidth
            // 
            this.edtTrigPulseWidth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtTrigPulseWidth.ForeColor = System.Drawing.Color.Black;
            this.edtTrigPulseWidth.Location = new System.Drawing.Point(98, 64);
            this.edtTrigPulseWidth.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtTrigPulseWidth.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtTrigPulseWidth.Name = "edtTrigPulseWidth";
            this.edtTrigPulseWidth.ReadOnly = true;
            this.edtTrigPulseWidth.Size = new System.Drawing.Size(63, 21);
            this.edtTrigPulseWidth.TabIndex = 29;
            this.edtTrigPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtTrigPulseWidth.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // edtTrigCycle
            // 
            this.edtTrigCycle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtTrigCycle.ForeColor = System.Drawing.Color.Black;
            this.edtTrigCycle.Location = new System.Drawing.Point(98, 40);
            this.edtTrigCycle.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtTrigCycle.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtTrigCycle.Name = "edtTrigCycle";
            this.edtTrigCycle.ReadOnly = true;
            this.edtTrigCycle.Size = new System.Drawing.Size(63, 21);
            this.edtTrigCycle.TabIndex = 28;
            this.edtTrigCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtTrigCycle.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // edtTrigStartPosition
            // 
            this.edtTrigStartPosition.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtTrigStartPosition.ForeColor = System.Drawing.Color.Black;
            this.edtTrigStartPosition.Location = new System.Drawing.Point(98, 16);
            this.edtTrigStartPosition.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtTrigStartPosition.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtTrigStartPosition.Name = "edtTrigStartPosition";
            this.edtTrigStartPosition.ReadOnly = true;
            this.edtTrigStartPosition.Size = new System.Drawing.Size(63, 21);
            this.edtTrigStartPosition.TabIndex = 27;
            this.edtTrigStartPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtTrigStartPosition.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnTrigAbs
            // 
            this.btnTrigAbs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrigAbs.Location = new System.Drawing.Point(8, 116);
            this.btnTrigAbs.Name = "btnTrigAbs";
            this.btnTrigAbs.Size = new System.Drawing.Size(88, 24);
            this.btnTrigAbs.TabIndex = 26;
            this.btnTrigAbs.Text = "Trig (Abs)";
            this.btnTrigAbs.Click += new System.EventHandler(this.btnTrigAbs_Click);
            // 
            // edtTrigEndPos
            // 
            this.edtTrigEndPos.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtTrigEndPos.ForeColor = System.Drawing.Color.Black;
            this.edtTrigEndPos.Location = new System.Drawing.Point(98, 88);
            this.edtTrigEndPos.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtTrigEndPos.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.edtTrigEndPos.Name = "edtTrigEndPos";
            this.edtTrigEndPos.ReadOnly = true;
            this.edtTrigEndPos.Size = new System.Drawing.Size(63, 21);
            this.edtTrigEndPos.TabIndex = 23;
            this.edtTrigEndPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtTrigEndPos.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lbl39
            // 
            this.lbl39.BackColor = System.Drawing.Color.Transparent;
            this.lbl39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl39.Location = new System.Drawing.Point(8, 88);
            this.lbl39.Name = "lbl39";
            this.lbl39.Size = new System.Drawing.Size(88, 21);
            this.lbl39.TabIndex = 18;
            this.lbl39.Text = "End Position";
            this.lbl39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl40
            // 
            this.lbl40.BackColor = System.Drawing.Color.Transparent;
            this.lbl40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl40.Location = new System.Drawing.Point(8, 64);
            this.lbl40.Name = "lbl40";
            this.lbl40.Size = new System.Drawing.Size(88, 21);
            this.lbl40.TabIndex = 17;
            this.lbl40.Text = "Pulse Width";
            this.lbl40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl41
            // 
            this.lbl41.BackColor = System.Drawing.Color.Transparent;
            this.lbl41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl41.Location = new System.Drawing.Point(8, 40);
            this.lbl41.Name = "lbl41";
            this.lbl41.Size = new System.Drawing.Size(88, 21);
            this.lbl41.TabIndex = 16;
            this.lbl41.Text = "Cycle";
            this.lbl41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl42
            // 
            this.lbl42.BackColor = System.Drawing.Color.Transparent;
            this.lbl42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl42.Location = new System.Drawing.Point(8, 16);
            this.lbl42.Name = "lbl42";
            this.lbl42.Size = new System.Drawing.Size(88, 21);
            this.lbl42.TabIndex = 15;
            this.lbl42.Text = "Start Position";
            this.lbl42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupCapturePosition
            // 
            this.groupCapturePosition.BackColor = System.Drawing.Color.Transparent;
            this.groupCapturePosition.Controls.Add(this.lblCapture);
            this.groupCapturePosition.Controls.Add(this.btnReadCapture);
            this.groupCapturePosition.Location = new System.Drawing.Point(837, 696);
            this.groupCapturePosition.Name = "groupCapturePosition";
            this.groupCapturePosition.Size = new System.Drawing.Size(168, 40);
            this.groupCapturePosition.TabIndex = 30;
            this.groupCapturePosition.TabStop = false;
            this.groupCapturePosition.Text = "Capture Position";
            // 
            // lblCapture
            // 
            this.lblCapture.BackColor = System.Drawing.Color.Transparent;
            this.lblCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCapture.Location = new System.Drawing.Point(75, 14);
            this.lblCapture.Name = "lblCapture";
            this.lblCapture.Size = new System.Drawing.Size(86, 20);
            this.lblCapture.TabIndex = 32;
            this.lblCapture.Text = "0";
            this.lblCapture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtMoveUnit
            // 
            this.edtMoveUnit.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edtMoveUnit.DecimalPlaces = 4;
            this.edtMoveUnit.ForeColor = System.Drawing.Color.Black;
            this.edtMoveUnit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edtMoveUnit.Location = new System.Drawing.Point(83, 284);
            this.edtMoveUnit.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.edtMoveUnit.Name = "edtMoveUnit";
            this.edtMoveUnit.ReadOnly = true;
            this.edtMoveUnit.Size = new System.Drawing.Size(78, 21);
            this.edtMoveUnit.TabIndex = 37;
            this.edtMoveUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl38
            // 
            this.lbl38.BackColor = System.Drawing.Color.Transparent;
            this.lbl38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl38.Location = new System.Drawing.Point(8, 284);
            this.lbl38.Name = "lbl38";
            this.lbl38.Size = new System.Drawing.Size(72, 20);
            this.lbl38.TabIndex = 36;
            this.lbl38.Text = "Unit/Pulse";
            this.lbl38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn3DGraph
            // 
            this.btn3DGraph.Location = new System.Drawing.Point(163, 283);
            this.btn3DGraph.Name = "btn3DGraph";
            this.btn3DGraph.Size = new System.Drawing.Size(66, 21);
            this.btn3DGraph.TabIndex = 38;
            this.btn3DGraph.Text = "3D Graph";
            this.btn3DGraph.Click += new System.EventHandler(this.btn3DGraph_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(730, 293);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 24);
            this.btnLoad.TabIndex = 41;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(730, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 24);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkGearOnOff
            // 
            this.chkGearOnOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGearOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkGearOnOff.Location = new System.Drawing.Point(845, 255);
            this.chkGearOnOff.Name = "chkGearOnOff";
            this.chkGearOnOff.Size = new System.Drawing.Size(88, 21);
            this.chkGearOnOff.TabIndex = 42;
            this.chkGearOnOff.Text = "Gear On/Off";
            this.chkGearOnOff.CheckedChanged += new System.EventHandler(this.chkGearOnOff_CheckedChanged);
            // 
            // XYPlot
            // 
            this.XYPlot.Enabled = true;
            this.XYPlot.Location = new System.Drawing.Point(526, 7);
            this.XYPlot.Name = "XYPlot";
            this.XYPlot.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("XYPlot.OcxState")));
            this.XYPlot.Size = new System.Drawing.Size(305, 271);
            this.XYPlot.TabIndex = 44;
            // 
            // GraphY
            // 
            this.GraphY.Enabled = true;
            this.GraphY.Location = new System.Drawing.Point(9, 144);
            this.GraphY.Name = "GraphY";
            this.GraphY.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("GraphY.OcxState")));
            this.GraphY.Size = new System.Drawing.Size(511, 135);
            this.GraphY.TabIndex = 43;
            // 
            // GraphX
            // 
            this.GraphX.Enabled = true;
            this.GraphX.Location = new System.Drawing.Point(8, 8);
            this.GraphX.Name = "GraphX";
            this.GraphX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("GraphX.OcxState")));
            this.GraphX.Size = new System.Drawing.Size(512, 130);
            this.GraphX.TabIndex = 43;
            // 
            // FormMotion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1012, 742);
            this.Controls.Add(this.XYPlot);
            this.Controls.Add(this.GraphY);
            this.Controls.Add(this.GraphX);
            this.Controls.Add(this.chkGearOnOff);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btn3DGraph);
            this.Controls.Add(this.edtMoveUnit);
            this.Controls.Add(this.lbl38);
            this.Controls.Add(this.groupBlockOneShotTrigger);
            this.Controls.Add(this.groupSenPosMove);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.groupInterruptMethodSetting);
            this.Controls.Add(this.groupContiInterpolation);
            this.Controls.Add(this.groupETC);
            this.Controls.Add(this.groupIO);
            this.Controls.Add(this.groupSignalSearch);
            this.Controls.Add(this.groupMotion);
            this.Controls.Add(this.cboAxisSet);
            this.Controls.Add(this.lblAxisSetting);
            this.Controls.Add(this.groupCapturePosition);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edtGearRatio);
            this.Controls.Add(this.lstLog);
            this.Name = "FormMotion";
            this.Text = "C# Motion Example";
            this.Load += new System.EventHandler(this.FormMotion_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMotion_FormClosed);
            this.groupMotion.ResumeLayout(false);
            this.groupMotion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovePulse)).EndInit();
            this.groupOneAxis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDecel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.groupInterpolation.ResumeLayout(false);
            this.groupInterpolation.PerformLayout();
            this.groupJOG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numStartSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveUnit)).EndInit();
            this.groupSignalSearch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGearRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerHomeFun4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerGraph)).EndInit();
            this.groupIO.ResumeLayout(false);
            this.groupCRC.ResumeLayout(false);
            this.groupMPG.ResumeLayout(false);
            this.groupMechanical.ResumeLayout(false);
            this.groupUnivIO.ResumeLayout(false);
            this.groupLevelSetting.ResumeLayout(false);
            this.groupETC.ResumeLayout(false);
            this.groupContiInterpolation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupInterruptMethodSetting.ResumeLayout(false);
            this.groupSenPosMove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHomeVelThird)).EndInit();
            this.groupBlockOneShotTrigger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigPulseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigStartPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrigEndPos)).EndInit();
            this.groupCapturePosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMoveUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XYPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphX)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run( new FormMotion());
		}

		private bool InitControl()
		{
            int     lBoardNo = 0, lModulePos = 0;
            uint    dwModuleID = 0;
            String  strAxis = "";

			cboDetectSignal.SelectedIndex		= 0;
			cboDirection.SelectedIndex		= 0;
			cboStopMethod.SelectedIndex		= 0;

			cboHomeDir.SelectedIndex	= 0;
			cboHomeSignal.SelectedIndex		= 2;

            GraphX.SetRanges(0, 400);
            GraphY.SetRanges(0, 400);

            XYPlot.SetRange(-2500, 2500, -2500, 2500);

            GraphX.SetRanges(0, 400);
            GraphX.SetPlotColor(0x0000FF, 0);
            GraphX.SetPlotColor(0x00FF00, 1);
            GraphX.SetXUnits("Time(sampling: 100 msec)", "0", "");
            GraphX.SetYUnits("unit/s", "0", "");

            GraphY.SetRanges(0, 400);
            GraphY.SetPlotColor(0x00FFFF, 0);
            GraphY.SetPlotColor(0xFFFF00, 1);
            GraphY.SetXUnits("Time(sampling: 100 msec)", "0", "");
            GraphY.SetYUnits("unit/s", "0", "");

            CAXM.AxmInfoGetAxisCount(ref m_lAxisCounts);
            // Initialize setup of axis
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                CAXM.AxmInfoGetAxis(i, ref lBoardNo, ref lModulePos, ref dwModuleID);
                switch (dwModuleID)
                {
                    case (uint)AXT_MODULE.AXT_SMC_2V02:                 strAxis = String.Format("{0:0}-[AXT_SMC_2V02]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_1V02:                 strAxis = String.Format("{0:0}-[AXT_SMC_1V02]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_4V04:                 strAxis = String.Format("{0:0}-(AXT_SMC_4V04)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04:                strAxis = String.Format("{0:0}-[AXT_SMC_R1V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_2V04:                 strAxis = String.Format("{0:0}-[AXT_SMC_2V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM:          strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIPM]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q:            strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2Q]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE:           strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2QE]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM:         strAxis = String.Format("{0:0}-(AXT_SMC_R1V04MLIIIPM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV:          strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A5:              strAxis = String.Format("{0:0}-[AXT_SMC_R1V04A4]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A4:              strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIICL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL:          strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIICL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR:          strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIICR]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIORI:         strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIORI]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV:        strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R:      strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV_R]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV:         strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD:      strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV_MD]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S:        strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7S]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W:        strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7W]", i); break;
                    case (uint)AXT_MODULE.AXT_ECAT_MOTION:
                        uint uModuleSubID = 0;
                        var szModuleName = new System.Text.StringBuilder(50);
                        var szModuleDesc = new System.Text.StringBuilder(80);
                        CAXM.AxmInfoGetAxisEx(i, ref uModuleSubID, szModuleName, szModuleDesc);
                        strAxis = String.Format("{0:0}-[ECAT-", i, szModuleName);
                        strAxis += szModuleName + "]";
                        break;
                    //strAxis = String.Format("{0:0}-[ECAT_MOTION]", i); break;
                    default: strAxis = String.Format("{0:0}-[Unknown]", i); break;
                }
                cboAxisSet.Items.Add(strAxis);                
            }
            
			return true;
		}

		// Combined Library and Module initialize
        private bool InitLibrary()
		{
			// Initialize AXT board
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
			{
                MessageBox.Show("Intialize Fail..!!");
                return false;
            }
			return true;
		}

        private void UpdateAxisInfo()
		{
            double dMinVelocity = 0.0;
            uint uEncInputMethod = 0, uPulseOutMethod = 0;
            double dInitpos = 0.0, dInitvel = 0.0, dInitaccel = 0.0, dInitdecel = 0.0;
            uint uAbsRel = 0, uProfile = 0, uSlaveNo = 0;
            double dUnit = 1.0;
            int nPulse = 1;
            uint dwModuleID = 0;
            int lBoardNo = 0, lModulePos = 0;

            cboAxisSet.SelectedIndex = m_lAxis;
            CAXM.AxmInfoGetAxis(m_lAxis, ref lBoardNo, ref lModulePos, ref dwModuleID);
            switch (dwModuleID)
            {
                case (uint)AXT_MODULE.AXT_SMC_2V02:
                case (uint)AXT_MODULE.AXT_SMC_1V02:
                case (uint)AXT_MODULE.AXT_SMC_4V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04:
                case (uint)AXT_MODULE.AXT_SMC_2V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM:


                    m_bA4NAxis = false;

                    cboPulseOutM.Enabled = true;
                    cboEncInputM.Enabled = true;

                    chkPELMLevel.ThreeState = true;
                    chkNELMLevel.ThreeState = true;
                    chkInpLevel.ThreeState = true;
                    chkAlarmLevel.ThreeState = true;
                    chkEmg.ThreeState = true;
                    chkHomeLevel.Enabled = true;
                    chkZphase.Enabled = true;

                    edtTrigStartPosition.Enabled = true;
                    edtTrigCycle.Enabled = true;
                    edtTrigPulseWidth.Enabled = true;
                    edtTrigEndPos.Enabled = true;
                    btnTrigAbs.Enabled = true;
                    btnTrigOneShot.Enabled = true;
                    btnTrigPeriod.Enabled = true;
                    btnTrigReset.Enabled = true;
                    btnCRCOn.Enabled = true;
                    btnCRCOff.Enabled = true;
                    groupLevelSetting.Text = "Level Setting";

                    if (dwModuleID == (uint)AXT_MODULE.AXT_SMC_R1V04 || dwModuleID == (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM)
                    {
                        btnIntMessage.Enabled = false;
                        btnIntEvent.Enabled = false;
                        btnIntDisable.Enabled = false;
                        btnReadCapture.Enabled = false;
                        btnMPGOn.Enabled = false;
                        btnMPGOff.Enabled = false;
                        btnCRCOn.Enabled = false;
                        btnCRCOff.Enabled = false;
		            }else{
                        btnIntMessage.Enabled = true;
                        btnIntEvent.Enabled = true;
                        btnIntDisable.Enabled = true;
                        btnSigCapture.Enabled = true;			            
                        btnReadCapture.Enabled = true;
                        btnMPGOn.Enabled = true;
                        btnMPGOff.Enabled = true;
                        btnCRCOn.Enabled = true;
                        btnCRCOff.Enabled = true;
                    }
                    
                break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04A5:
                case (uint)AXT_MODULE.AXT_SMC_R1V04A4:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIORI:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W:
                    m_bA4NAxis = true;

                    cboPulseOutM.Enabled = false;
                    cboEncInputM.Enabled = false;

                    chkPELMLevel.ThreeState = false;
                    chkNELMLevel.ThreeState = false;
                    chkInpLevel.ThreeState = false;
                    chkAlarmLevel.ThreeState = false;
                    chkEmg.ThreeState = false;
                    chkHomeLevel.Enabled = false;
                    chkZphase.Enabled = false;

                    edtTrigStartPosition.Enabled = false;
                    edtTrigCycle.Enabled = false;
                    edtTrigPulseWidth.Enabled = false;
                    edtTrigEndPos.Enabled = false;
                    btnTrigAbs.Enabled = false;
                    btnTrigOneShot.Enabled = false;
                    btnTrigPeriod.Enabled = false;
                    btnTrigReset.Enabled = false;
                    btnCRCOn.Enabled = false;
                    btnCRCOff.Enabled = false;
                    btnMPGOn.Enabled = false;
                    btnMPGOff.Enabled = false;
                    groupLevelSetting.Text = "Level/Usage";
                    break;
            }

            CAXM.AxmMotGetMoveUnitPerPulse(m_lAxis, ref dUnit, ref nPulse);
            CAXM.AxmMotGetMinVel(m_lAxis, ref dMinVelocity);
            CAXM.AxmMotGetProfileMode(m_lAxis, ref uProfile);
            CAXM.AxmMotGetAbsRelMode(m_lAxis, ref uAbsRel);
            CAXM.AxmMotGetParaLoad(m_lAxis, ref dInitpos, ref dInitvel, ref dInitaccel, ref dInitdecel);

            edtMoveUnit.Value = Convert.ToDecimal(dUnit / (double)nPulse);
            numMoveUnit.Value = Convert.ToDecimal(dUnit);
            numMovePulse.Value = Convert.ToDecimal((double)nPulse);
            numStartSpeed.Value = Convert.ToDecimal(dMinVelocity);

            numDistance.Value = Convert.ToDecimal(dInitpos);
            numVelocity.Value = Convert.ToDecimal(dInitvel);
            numAccel.Value = Convert.ToDecimal(dInitaccel);
            numDecel.Value = Convert.ToDecimal(dInitdecel);

            if (m_bA4NAxis == false)
            {
                CAXM.AxmMotGetEncInputMethod(m_lAxis, ref uEncInputMethod);
                CAXM.AxmMotGetPulseOutMethod(m_lAxis, ref uPulseOutMethod);
                cboEncInputM.SelectedIndex = (int)uEncInputMethod;
                cboPulseOutM.SelectedIndex = (int)uPulseOutMethod;
            }

            if (uAbsRel == 1)
            {
                chkRelative.Checked = true;
                chkAbsolute.Checked = false;
            }
            else
            {
                chkRelative.Checked = false;
                chkAbsolute.Checked = true;
            }

            if (uProfile == 2 || uProfile == 3 || uProfile == 4)   chkSCurve.Checked = true;
            else                                                   chkSCurve.Checked = false;

            if ((uProfile == 1) || (uProfile == 4))
            {
                numDecel.Enabled = true;
                chkAsym.Enabled = true;
            }
            else
            {
                numDecel.Enabled = false;
                chkAsym.Enabled = false;
            }

            double dGearRatio = 0.0;
            uint uPositiveLevel = 0, uNegativeLevel = 0, uStopMode = 0;
            uint uInposLevel = 0, uAlarmLevel = 0, uReadEmg = 0;
            uint uHomeLevel = 0, uZphaseLevel = 0;
            uint uSlHomeUse = 0;

            CAXM.AxmSignalGetLimit(m_lAxis, ref uStopMode, ref uPositiveLevel, ref uNegativeLevel);
            CAXM.AxmSignalGetServoAlarm(m_lAxis, ref uAlarmLevel);
            CAXM.AxmSignalGetInpos(m_lAxis, ref uInposLevel);
            CAXM.AxmSignalGetStop(m_lAxis, ref uStopMode, ref uReadEmg);

            if (!m_bA4NAxis)
            {
                CAXM.AxmHomeGetSignalLevel(m_lAxis, ref uHomeLevel);
                CAXM.AxmSignalGetZphaseLevel(m_lAxis, ref uZphaseLevel);

                chkPELMLevel.Checked = Convert.ToBoolean(uPositiveLevel);
                chkNELMLevel.Checked = Convert.ToBoolean(uNegativeLevel);
                chkAlarmLevel.Checked = Convert.ToBoolean(uAlarmLevel);
                chkEmg.Checked = Convert.ToBoolean(uReadEmg);
                chkHomeLevel.Checked = Convert.ToBoolean(uHomeLevel);
                chkZphase.Checked = Convert.ToBoolean(uZphaseLevel);
            }
            else
            {
                if (uPositiveLevel == (uint)AXT_MOTION_LEVEL_MODE.UNUSED) chkPELMLevel.Checked = true;
                else chkPELMLevel.Checked = false;

                if (uNegativeLevel == (uint)AXT_MOTION_LEVEL_MODE.UNUSED) chkNELMLevel.Checked = true;
                else chkNELMLevel.Checked = false;

                if (uReadEmg == (uint)AXT_MOTION_LEVEL_MODE.UNUSED) chkEmg.Checked = true;
                else chkEmg.Checked = false;

                if (uAlarmLevel == (uint)AXT_MOTION_LEVEL_MODE.UNUSED) chkAlarmLevel.Checked = true;
                else chkAlarmLevel.Checked = false;

                if (uInposLevel == (uint)AXT_MOTION_LEVEL_MODE.UNUSED) chkInpLevel.Checked = true;
                else chkInpLevel.Checked = false;
            }

            CAXM.AxmLinkGetMode(CAXHS.AXIS_EVN(m_lAxis), ref uSlaveNo, ref dGearRatio);
            if (dGearRatio > 0)
            {
                edtGearRatio.Value = Convert.ToDecimal(dGearRatio);
                chkGearOnOff.Checked = true;
            }
            else
            {
                chkGearOnOff.Checked = false;
            }

            String strData;
            uint uGatryOn = 0; 
            double dSlOffset = 0.0, dSlORange = 0;
            
            CAXM.AxmGantryGetEnable(m_lAxis, ref uSlHomeUse, ref dSlOffset, ref dSlORange, ref uGatryOn);
            cboGantrySlave.SelectedIndex = (int)uSlHomeUse;

            SetTitleBar(m_lAxis);

            if (CAXHS.AXIS_N04(m_lAxis, 0) < m_lAxisCounts)
            {
                strData = String.Format("{0:00} Axis", CAXHS.AXIS_N04(m_lAxis, 0));
                GraphX.SetLegendLabel(strData, 0);
            }
            else
            {
                GraphX.SetLegendLabel("None", 0);
            }

            if (CAXHS.AXIS_N04(m_lAxis, 1) < m_lAxisCounts)
            {
                strData = String.Format("{0:00} Axis", CAXHS.AXIS_N04(m_lAxis, 1));
                GraphX.SetLegendLabel(strData, 1);
            }
            else
            {
                GraphX.SetLegendLabel("None", 1);
            }

            if (CAXHS.AXIS_N04(m_lAxis, 2) < m_lAxisCounts)
            {
                strData = String.Format("{0:00} Axis", CAXHS.AXIS_N04(m_lAxis, 2));
                GraphY.SetLegendLabel(strData, 0);
            }
            else
            {
                GraphY.SetLegendLabel("None", 0);
            }

            if (CAXHS.AXIS_N04(m_lAxis, 3) < m_lAxisCounts)
            {
                strData = String.Format("{0:00} Axis", CAXHS.AXIS_N04(m_lAxis, 3));
                GraphY.SetLegendLabel(strData, 1);
            }
            else
            {
                GraphY.SetLegendLabel("None", 1);
            }
		}

        private void SetTitleBar(int nAxis)
        {
	        String  strCaption;
	        uint    uModuleID = 0;
	        int	    nAxtBoardNo = 0;
            int     nModulePos = 0;

            if ((uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS == CAXM.AxmInfoGetAxis(nAxis, ref nAxtBoardNo, ref nModulePos, ref uModuleID))
		        strCaption = String.Format("Ajinextek Motion Board No[{0:00}], Module Pos[{1:00}], Module ID[0x{2:X}]", nAxtBoardNo, nModulePos, uModuleID);
	        else
		        strCaption = String.Format("Ajinextek Motion Board is not detected");

	        this.Text = strCaption;
        }

		// Setup to fit to changed axis for distance rate by pulse when axis is changed, initial speed, pulse output method, encoder input method.
		private void cboAxisSetting_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            m_lAxis = cboAxisSet.SelectedIndex;
            UpdateAxisInfo();
		}

		private void FormMotion_Load(object sender, System.EventArgs e)
		{

            InitLibrary();  // Combined Library and Module initialize
            InitControl();  // Graph and btn control initialize 			

            if(m_lAxisCounts > 0)
                UpdateAxisInfo(); 
            
			m_formMotion = this;
            timerDisplay.Enabled = true;
            timerGraph.Enabled = true;
		}

		private void numMoveUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			numMoveUnit.Value = Convert.ToDecimal( e.KeyValue );
		}

		private void numStartSpeed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			numStartSpeed.Value = Convert.ToDecimal( e.KeyValue );
		}

		private void cboPulseOutM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( m_lAxis >=0 )
                CAXM.AxmMotSetPulseOutMethod( m_lAxis, (uint)cboPulseOutM.SelectedIndex );
		}

		private void cboEncInputM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( m_lAxis >=0 )
				CAXM.AxmMotSetEncInputMethod(m_lAxis, (uint)cboEncInputM.SelectedIndex );
		}

		// Setup distance rate and initial speed by pulse among those initial parameter.
		// Change maximum speed to fit if setup distance rate by pulse.
		private void btnSetting_Click(object sender, System.EventArgs e)
		{
			double	dMoveUnit	=0.0, dStartSpeed =0.0;
			double  dUnit = 0;
			int 	nPulse = 1;
			double	dMinVelocity =0.0;            

			nPulse		=  (int)(Convert.ToDouble( numMovePulse.Value));
			
			dMoveUnit	= Convert.ToDouble( numMoveUnit.Value);

            dStartSpeed = Convert.ToDouble(numStartSpeed.Value);
            			
			CAXM.AxmMotSetMoveUnitPerPulse( m_lAxis, dMoveUnit, nPulse);	// Unit : pulse = 1 : 1
            CAXM.AxmMotSetMinVel(m_lAxis, dStartSpeed);

			CAXM.AxmMotGetMoveUnitPerPulse( m_lAxis, ref dUnit, ref nPulse );
			CAXM.AxmMotGetMinVel( m_lAxis, ref dMinVelocity );

			edtMoveUnit.Value	= Convert.ToDecimal( dUnit/(double)nPulse );
			numMoveUnit.Value	= Convert.ToDecimal( dUnit );
			numMovePulse.Value	= Convert.ToDecimal( (double)nPulse );
            numStartSpeed.Value = Convert.ToDecimal(dMinVelocity);
		}

		private void btn2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			numStartSpeed.Value += 1;
		}

		private void btn2_MouseHover(object sender, System.EventArgs e)
		{
			numStartSpeed.Value += 1;
		}

		private void btn2_MouseEnter(object sender, System.EventArgs e)
		{
			numStartSpeed.Value += 1;
		}

		private void btn2_Click(object sender, System.EventArgs e)
		{
			numStartSpeed.Value += 1;
		}

		private void btnMove_Click(object sender, System.EventArgs e)
		{
			double dDistance = Convert.ToDouble( numDistance.Value );
			double dVelocity = Convert.ToDouble( numVelocity.Value );
			double dAccel	 = Math.Abs( Convert.ToDouble( numAccel.Value) );
			double dDecel	 = Math.Abs( Convert.ToDouble( numDecel.Value) );

            int i = 0;

			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
			if ( m_lAxis == 0 )
			{
//				m_GraphX.MaxRange = dVelocity + (dVelocity * 0.2);
//				m_GraphX.MinRange = m_lAxis;
			}
			else
			{
//				m_GraphY.MaxRange = dVelocity + (dVelocity * 0.2);
//				m_GraphY.MinRange = m_lAxis+1;
			}

			if( chkXYSync.Checked == true )
			{		
				int[]		arrnAxis			= new int[2];
				double[]	arrdPosition		= new double[2];
				double[]	arrdMaxVelocity		= new double[2];
				double[]	arrdMaxAccel		= new double[2];
				double[]	arrdMaxDecel		= new double[2];

				arrnAxis[0] = CAXHS.AXIS_ODD(m_lAxis);
				arrnAxis[1] = CAXHS.AXIS_EVN(m_lAxis);
		
				for( i=0; i<2; i++)
				{
					if( chkAsym.Checked == true )			CAXM.AxmMotSetProfileMode( i, 4 );
					else									CAXM.AxmMotSetProfileMode( i, 3 );

					if( chkAbsolute.Checked == true )		CAXM.AxmMotSetAbsRelMode( i, 0 );
					else									CAXM.AxmMotSetAbsRelMode( i, 1 );

					arrdPosition[i]		= dDistance;
					arrdMaxVelocity[i]  = dVelocity;
					arrdMaxAccel[i]		= dDistance;
					arrdMaxDecel[i]		= dVelocity;

				}

				CAXM.AxmMoveStartMultiPos(2, arrnAxis, arrdPosition, arrdMaxVelocity, arrdMaxAccel, arrdMaxDecel);
			}
			else
			{

				if( chkAsym.Checked == true )
				{		
					if( chkSCurve.Checked == true )
					{
						if( chkAbsolute.Checked == true )
						{
							CAXM.AxmMotSetProfileMode( m_lAxis, 4 );		// asymmetry S Curve
							CAXM.AxmMotSetAbsRelMode( m_lAxis, 0 );
							CAXM.AxmMoveStartPos( m_lAxis, dDistance, dVelocity, dAccel, dDecel);

						}
						else
						{
							CAXM.AxmMotSetProfileMode(m_lAxis, 4);		// asymmetry S Curve
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 1);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dDecel);
						}
					}
					else
					{
						if( chkAbsolute.Checked == true )
						{
							CAXM.AxmMotSetProfileMode(m_lAxis, 1);		// asymmetry Trapezode
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 0);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dDecel);
						}
						else
						{
							CAXM.AxmMotSetProfileMode(m_lAxis, 1);		// asymmetry Trapezode
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 1);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dDecel);
						}
					}
				}
				else
				{
					if( chkSCurve.Checked == true )
					{
						if( chkAbsolute.Checked == true )
						{
							CAXM.AxmMotSetProfileMode(m_lAxis, 3);		// Symmetric S-Curve
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 0);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dAccel);

						}
						else
						{

							CAXM.AxmMotSetProfileMode(m_lAxis, 3);		// Symmetric S-Curve
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 1);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dAccel);
						}
					}
					else
					{
						if( chkAbsolute.Checked == true )
						{

							CAXM.AxmMotSetProfileMode(m_lAxis, 0);		// symmetry Trapezode
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 0);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dAccel);
						}
						else
						{

							CAXM.AxmMotSetProfileMode(m_lAxis, 0);		// symmetry Trapezode
							CAXM.AxmMotSetAbsRelMode(m_lAxis, 1);
							CAXM.AxmMoveStartPos(m_lAxis, dDistance, dVelocity, dAccel, dAccel);
						}
					}
				}
			}

			CAXM.AxmMotSetParaLoad(m_lAxis, dDistance, dVelocity, dAccel, dDecel);	

		}

		private void RepeatThread(Object objData)
		{
			uint	uBusyStatus = 0;

            double  dCurPos = 0.0;
            uint    uMode = 0;
			int		nAxis		= (int)objData;
			double  dPosition	= Convert.ToDouble( numDistance.Value );
			double  dVelocity	= Convert.ToDouble( numVelocity.Value );
			double  dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value) );
	
            CAXM.AxmStatusGetCmdPos(nAxis, ref dCurPos);
        	CAXM.AxmMotGetAbsRelMode(nAxis, ref uMode);

            // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            m_formMotion.SetGraphRange(nAxis, dVelocity);
	
			while(m_formMotion.m_bTestActive[nAxis] == true)
			{
				CAXM.AxmMoveStartPos(nAxis, dPosition, dVelocity, dAccel, dAccel);

				do {
					CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
					Thread.Sleep( 1 );
				} while((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));

				if (m_formMotion.m_bTestActive[nAxis] == false)	break;

                if(uMode == (uint)AXT_MOTION_ABSREL.POS_ABS_MODE)
                {
                    if(dCurPos == dPosition)    break;

    				CAXM.AxmMoveStartPos( nAxis, dCurPos, dVelocity, dAccel, dAccel );
                }else{
        			if(0 == dPosition)		break;
                    CAXM.AxmMoveStartPos(nAxis, -dPosition, dVelocity, dAccel, dAccel);
                }

				do {
					CAXM.AxmStatusReadInMotion( nAxis, ref uBusyStatus );
					Thread.Sleep(1);
				} while((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));
			}

			m_formMotion.m_bTestActive[nAxis] = false;
			m_formMotion.m_hTestThread[nAxis] = null;
		}

		// Signal Search move thread
        private void SearchThread(Object objData)
        {
            int nSignal = 0;
            uint uEndStatus = 0;
            uint uBusyStatus = 0;
            int nEdge = 0;
            int nAxis = (int)objData;

            double dVelocity = Convert.ToDouble(m_formMotion.numVelocity.Value);
            double dAccel   = Convert.ToDouble(m_formMotion.numAccel.Value);
            int nDirect     = m_formMotion.m_nSignalDir;    
            int nStop       = m_formMotion.m_nSignalStop;
            int nDetectSig  = m_formMotion.m_nSignalDetect;

            if (nDetectSig < 2)
                nSignal = nDetectSig;
            else if (nDetectSig > 1 & nDetectSig < 6)
                nSignal = nDetectSig + 2;
            else
                nSignal = nDetectSig - 2;

            nEdge = nDetectSig / 6;

            // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            m_formMotion.SetGraphRange(nAxis, dVelocity);

            if (0 == nSignal)       CAXM.AxmSignalSetLimit(nAxis, (uint)AXT_MOTION_STOPMODE.EMERGENCY_STOP, (uint)AXT_MOTION_LEVEL_MODE.UNUSED, (uint)AXT_MOTION_LEVEL_MODE.USED);			// Positive End Limit.
            else if (1 == nSignal)  CAXM.AxmSignalSetLimit(nAxis, (uint)AXT_MOTION_STOPMODE.EMERGENCY_STOP, (uint)AXT_MOTION_LEVEL_MODE.USED, (uint)AXT_MOTION_LEVEL_MODE.UNUSED);			// Negative End Limit.

            if (nDirect == 1) CAXM.AxmMoveSignalSearch(nAxis, -dVelocity, dAccel, nSignal, nEdge, nStop);
            else CAXM.AxmMoveSignalSearch(nAxis, dVelocity, dAccel, nSignal, nEdge, nStop);

            do
            {
                CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
                Thread.Sleep(1);
            } while (uBusyStatus != 0);

            // Check how running was stopped on certain condition by referring End Status Register. 
            CAXM.AxmStatusReadStop(nAxis, ref uEndStatus);

            if (nSignal > 1)
            {
                if (0x0 == (uEndStatus & 0x40000))
                {
                    String strMsg = String.Format(" {0:0} Axis Search failed", nAxis);
                    AddLogMessage(strMsg);
                }
                else
                {
                    String strMsg = String.Format(" {0:0} Axis {1} signal search complete.", nAxis, nDetectSig);
                    AddLogMessage(strMsg);
                }
            }
            else if (nSignal < 2)
            {
                if (0x0 != (uEndStatus & 0x7FFF))
                {
                    AddLogMessage("Search failed");
                }
                else
                {
                    String strMsg = String.Format(" {0:0} Axis {1} signal search complete.", nAxis, nDetectSig);
                    AddLogMessage(strMsg);
                }
            }

            m_formMotion.m_bTestActive[nAxis] = false;
            m_formMotion.m_hTestThread[nAxis] = null;
        }


		private void btnRepeat_Click(object sender, System.EventArgs e)
		{
			if((m_hTestThread[m_lAxis] == null) && (m_bTestActive[m_lAxis] == false))
			{
				// Thread Setting
                m_hTestThread[m_lAxis] = new Thread(new ParameterizedThreadStart(RepeatThread));
				m_hTestThread[m_lAxis].IsBackground = true;
                m_hTestThread[m_lAxis].Start(m_lAxis);		
				m_bTestActive[m_lAxis] = true;
    		}else{
                lstLog.Items.Add("Already Moving");
				lstLog.SelectedIndex = lstLog.Items.Count-1;
			}
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
            if (m_bTestActive[m_lAxis] == true)
            {
                m_bTestActive[m_lAxis] = false;
                CAXM.AxmMoveSStop(m_lAxis);
            }
            else
            {
                CAXM.AxmMoveSStop(m_lAxis);
            }

			lstLog.Items.Add("Stop.");
			lstLog.SelectedIndex = lstLog.Items.Count-1;
		}

		private void btnEStop_Click(object sender, System.EventArgs e)
		{
            int i;
            for(i = 0; i < m_lAxisCounts; i++)
            {
                m_bTestActive[i] = false;
                CAXM.AxmMoveEStop(i);
            }

			lstLog.Items.Add("EStop.");
    		lstLog.SelectedIndex = lstLog.Items.Count-1;
		}

		// To absolute coordinate if it was chked when click the chk box of absolute coordinate.
		// To opposite coordinate if it was chked when click the chk box of opposite coordinate.
		private void chkAbsolute_CheckedChanged(object sender, System.EventArgs e)
		{
			uint	dwAbsRel = 0, dwProfile = 0;
			double	dDistance = 0.0f, dVelocity = 0.0f, dAccel = 0.0f, dDecel = 0.0f;

			CAXM.AxmMotGetParaLoad(m_lAxis, ref dDistance ,ref dVelocity, ref dAccel, ref dDecel);	
			CAXM.AxmMotGetProfileMode( m_lAxis, ref dwProfile );
			CAXM.AxmMotGetAbsRelMode( m_lAxis, ref dwAbsRel );    

			CAXM.AxmMotSetParaLoad(m_lAxis, dDistance, dVelocity, dAccel, dDecel);
			CAXM.AxmMotSetProfileMode( m_lAxis, dwProfile );
			CAXM.AxmMotSetAbsRelMode( m_lAxis, 0 );

			chkRelative.Checked = !chkAbsolute.Checked;
		}

		// To absolute coordinate if it was chked when click the chk box of absolute coordinate.
		// To opposite coordinate if it was chked when click the chk box of opposite coordinate.
		private void chkRelative_CheckedChanged(object sender, System.EventArgs e)
		{
			uint	dwAbsRel = 0, dwProfile = 0;
			double	dDistance = 0.0f, dVelocity = 0.0f, dAccel = 0.0f, dDecel = 0.0f;

			CAXM.AxmMotGetProfileMode( m_lAxis, ref dwProfile );
			CAXM.AxmMotGetAbsRelMode( m_lAxis, ref dwAbsRel );    
			CAXM.AxmMotGetParaLoad(m_lAxis, ref dDistance ,ref dVelocity, ref dAccel, ref dDecel);	

			CAXM.AxmMotSetParaLoad(m_lAxis, dDistance, dVelocity, dAccel, dDecel);
			CAXM.AxmMotSetProfileMode( m_lAxis, dwProfile );
			CAXM.AxmMotSetAbsRelMode( m_lAxis, 1 );

			chkAbsolute.Checked = !chkRelative.Checked;
		}

		// Make edit window to be active for setting a value of reduced speed when asymmetric running mode.
		private void chkAsym_CheckedChanged(object sender, System.EventArgs e)
		{
			numDecel.Enabled = chkAsym.Checked;
		}

		private void chkGantry_CheckedChanged(object sender, System.EventArgs e)
		{
			uint  uErrorCode = 0;
			uint  uSlave = 0;

			if( chkGantry.Checked == true )
			{
				if(cboGantrySlave.SelectedIndex == 0)
					uSlave = 0;
				else if (cboGantrySlave.SelectedIndex == 1)
					uSlave = 1;
				else
					uSlave = 2;

				uErrorCode = CAXM.AxmGantrySetEnable( CAXHS.AXIS_EVN(m_lAxis), CAXHS.AXIS_ODD(m_lAxis), uSlave, 0.0, 100000.0);

				if(uErrorCode != 0)	
				{
					String strMsg = String.Format(" Gantry Error Code: {0:0} ", uErrorCode);
					m_formMotion.lstLog.Items.Add( strMsg );
				}
				else
				{
					lstLog.Items.Add( "Gantry Enable" );
					lstLog.SelectedIndex = lstLog.Items.Count-1;
				}
			}
			else
			{
				CAXM.AxmGantrySetDisable( CAXHS.AXIS_EVN(m_lAxis), CAXHS.AXIS_ODD(m_lAxis) );
				lstLog.Items.Add( "Gantry Disable" );
				lstLog.SelectedIndex = lstLog.Items.Count-1;
			}
		}

		// It is for the test of Home searching, about setup signal to be searched and searching direction and stop method after searching 
		// Start searching after read.  Print out the result on list box after finishing search.
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
            if ((m_hTestThread[m_lAxis] == null) & (m_bTestActive[m_lAxis] == false))
			{
                m_nSignalDir    = cboDirection.SelectedIndex;
                m_nSignalStop   = cboStopMethod.SelectedIndex;
                m_nSignalDetect = cboDetectSignal.SelectedIndex;

                m_hTestThread[m_lAxis] = new Thread(new ParameterizedThreadStart(SearchThread));
                m_hTestThread[m_lAxis].Start(m_lAxis);
                m_hTestThread[m_lAxis].IsBackground = true;
                m_bTestActive[m_lAxis] = true;	
			}
			else
			{
                lstLog.Items.Add("Already Moving");
				lstLog.SelectedIndex = lstLog.Items.Count-1;
			}
		}

		private void btnVelOverride_Click(object sender, System.EventArgs e)
		{
			double dDistance = Convert.ToDouble( numDistance.Value );
			double dVelocity = Math.Abs( Convert.ToDouble(numVelocity.Value) );
			double dAccel	 = Math.Abs( Convert.ToDouble(numAccel.Value) );
			double dDecel	 = Math.Abs( Convert.ToDouble(numDecel.Value) );

            SetGraphRange(m_lAxis, dVelocity * 2);
			CAXM.AxmOverrideVelAtPos( m_lAxis, dDistance, dVelocity, dAccel, dAccel, dDistance/4, dVelocity*2, 
												(int)AXT_MOTION_SELECTION.COMMAND );
		}

		private void btnCaptureMove_Click(object sender, System.EventArgs e)
		{
            int     nEdge; 
            int     nSignal = 0;				
            double  dVelocity       = Convert.ToDouble(numVelocity.Value);
            double  dAccel          = Convert.ToDouble(numAccel.Value);
			int		nDirect		    = m_formMotion.cboDirection.SelectedIndex; 
			int     nSignalMethod   = m_formMotion.cboStopMethod.SelectedIndex;

            SetGraphRange(m_lAxis, dVelocity);
			if( cboDetectSignal.SelectedIndex < 8)
			{
                nEdge = 0; 
                nSignal = cboDetectSignal.SelectedIndex;				
			}
			else
			{
                nEdge = 1; 
                nSignal = cboDetectSignal.SelectedIndex - 8;				
			}

			if ( nDirect == 0)
                CAXM.AxmMoveSignalCapture(m_lAxis, dVelocity, dAccel, nSignal, nEdge, (int)AXT_MOTION_SELECTION.COMMAND, nSignalMethod);
			else
                CAXM.AxmMoveSignalCapture(m_lAxis, -dVelocity, dAccel, nSignal, nEdge, (int)AXT_MOTION_SELECTION.COMMAND, nSignalMethod);
		}

        private void btnHomeSingle_Click(object sender, System.EventArgs e)
		{
			double  dFirstVel = Convert.ToDouble( edtHomeVelFirst.Value );
			double  dSecondVel = Convert.ToDouble( edtHomeVelSecond.Value );
			double  dThirdVel = Convert.ToDouble( edtHomeVelThird.Value );
			double  dLastVel = Convert.ToDouble( edtHomeVelLast.Value );

			int		nHomeDir = cboHomeDir.SelectedIndex;
			uint	uHomeSig = (uint)cboHomeSignal.SelectedIndex;
			uint	uZphas = 0;
			double  dHomeClrTime = 1000.0, dHomeOffset = 0.0;

			if (uHomeSig > 1)
				uHomeSig += 2;

			if( chkGantry.Checked == true )
			{
				CAXM.AxmHomeSetMethod( CAXHS.AXIS_EVN(m_lAxis), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset );
				CAXM.AxmHomeSetMethod( CAXHS.AXIS_ODD(m_lAxis), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset );

				CAXM.AxmHomeSetVel( CAXHS.AXIS_EVN(m_lAxis), dFirstVel, dSecondVel, dThirdVel, dLastVel, dFirstVel*4, dSecondVel*10 );
				CAXM.AxmHomeSetVel( CAXHS.AXIS_ODD(m_lAxis), dFirstVel, dSecondVel, dThirdVel, dLastVel, dFirstVel*4, dSecondVel*10 );
                CAXM.AxmHomeSetStart(CAXHS.AXIS_EVN(m_lAxis));
                switch (CAXHS.AXIS_EVN(m_lAxis))
                {
                    case 0: timerHomeFun1.Enabled = true; break;
                    case 1: timerHomeFun2.Enabled = true; break;
                    case 2: timerHomeFun3.Enabled = true; break;
                    case 3: timerHomeFun4.Enabled = true; break;
                }
            }
			else
			{
				CAXM.AxmHomeSetMethod( m_lAxis, nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset );
				CAXM.AxmHomeSetVel( m_lAxis, dFirstVel, dSecondVel, dThirdVel, dLastVel, dFirstVel*4, dSecondVel*10 );
                CAXM.AxmHomeSetStart(m_lAxis);
                switch (m_lAxis)
                {
                    case 0: timerHomeFun1.Enabled = true; break;
                    case 1: timerHomeFun2.Enabled = true; break;
                    case 2: timerHomeFun3.Enabled = true; break;
                    case 3: timerHomeFun4.Enabled = true; break;
                }
            }
		}

        private void btnHomeAll_Click(object sender, System.EventArgs e)
		{
			int		nHomeDir = cboHomeDir.SelectedIndex;
			uint	uHomeSig = (uint)cboHomeSignal.SelectedIndex;
			uint	uZphas = 0;
			double  dHomeClrTime = 1000.0, dHomeOffset = 0.0;
            uint    dwResult = 0;

			if (uHomeSig > 1)
				uHomeSig += 2;

            SetGraphRange(CAXHS.AXIS_N04(m_lAxis, 0), 100);
            SetGraphRange(CAXHS.AXIS_N04(m_lAxis, 2), 100);

            // Speed of starting point searching by each step must be changed to fit to the device.
            dwResult = CAXM.AxmHomeSetVel(CAXHS.AXIS_N04(m_lAxis, 0), 100, 50, 5, 1, 400, 100); 
            if (dwResult == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                CAXM.AxmHomeSetMethod(CAXHS.AXIS_N04(m_lAxis, 0), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset);
                CAXM.AxmHomeSetStart(CAXHS.AXIS_N04(m_lAxis, 0));
                timerHomeFun1.Enabled = true;
            }

            dwResult = CAXM.AxmHomeSetVel(CAXHS.AXIS_N04(m_lAxis, 1), 100, 50, 5, 1, 400, 100);
            if (dwResult == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                CAXM.AxmHomeSetMethod(CAXHS.AXIS_N04(m_lAxis, 1), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset);
                CAXM.AxmHomeSetStart(CAXHS.AXIS_N04(m_lAxis, 1));
                timerHomeFun2.Enabled = true;
            }

            dwResult = CAXM.AxmHomeSetVel(CAXHS.AXIS_N04(m_lAxis, 2), 100, 50, 5, 1, 400, 100);
            if (dwResult == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                CAXM.AxmHomeSetMethod(CAXHS.AXIS_N04(m_lAxis, 2), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset);
                CAXM.AxmHomeSetStart(CAXHS.AXIS_N04(m_lAxis, 2));
                timerHomeFun3.Enabled = true;
            }

            dwResult = CAXM.AxmHomeSetVel(CAXHS.AXIS_N04(m_lAxis, 3), 100, 50, 5, 1, 400, 100);
            if (dwResult == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                CAXM.AxmHomeSetMethod(CAXHS.AXIS_N04(m_lAxis, 3), nHomeDir, uHomeSig, uZphas, dHomeClrTime, dHomeOffset);
                CAXM.AxmHomeSetStart(CAXHS.AXIS_N04(m_lAxis, 3));
                timerHomeFun4.Enabled = true;
            }
		}

		private void timerHomeFun1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            String  strData;
			uint    uHomeResult = 0;
			CAXM.AxmHomeGetResult( 0, ref uHomeResult);
            if (uHomeResult != (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
			{
				timerHomeFun1.Enabled = false;
                if (uHomeResult == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS)
                    MessageBox.Show("Home search1 complete", "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    strData = String.Format("Home search1 failed[0x{0:X}]", uHomeResult);
                    MessageBox.Show(strData, "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
			}
		}

		private void timerHomeFun2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            String strData;
            uint uHomeResult = 0;
            CAXM.AxmHomeGetResult(1, ref uHomeResult);
            if (uHomeResult != (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
            {
                timerHomeFun2.Enabled = false;
                if (uHomeResult == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS)
                    MessageBox.Show("Home search2 complete", "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    strData = String.Format("Home search2 failed[0x{0:X}]", uHomeResult);
                    MessageBox.Show(strData, "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
		}

		private void timerHomeFun3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            String strData;
            uint uHomeResult = 0;
            CAXM.AxmHomeGetResult(2, ref uHomeResult);
            if (uHomeResult != (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
            {
                timerHomeFun3.Enabled = false;
                if (uHomeResult == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS)
                    MessageBox.Show("Home search3 complete", "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    strData = String.Format("Home search3 failed[0x{0:X}]", uHomeResult);
                    MessageBox.Show(strData, "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
		}

		private void timerHomeFun4_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            String strData;
            uint uHomeResult = 0;
            CAXM.AxmHomeGetResult(3, ref uHomeResult);
            if (uHomeResult != (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
            {
                timerHomeFun4.Enabled = false;
                if (uHomeResult == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS)
                    MessageBox.Show("Home search4 complete", "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    strData = String.Format("Home search4 failed[0x{0:X}]", uHomeResult);
                    MessageBox.Show(strData, "Home search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
		}

		// Display speed of each axis by graph
		private void timerGraph_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if( m_lAxis >= -1 )
			{
                double dX1 = 0.0, dY1 = 0.0;
                double[] dCurVelX = new double[2];
                double[] dCurVelY = new double[2];

                CAXM.AxmStatusGetCmdPos(CAXHS.AXIS_EVN(m_lAxis), ref dX1);
                CAXM.AxmStatusGetCmdPos(CAXHS.AXIS_ODD(m_lAxis), ref dY1);

                CAXM.AxmStatusReadVel(CAXHS.AXIS_N04(m_lAxis, 0), ref dCurVelX[0]);
                CAXM.AxmStatusReadVel(CAXHS.AXIS_N04(m_lAxis, 1), ref dCurVelX[1]);
                CAXM.AxmStatusReadVel(CAXHS.AXIS_N04(m_lAxis, 2), ref dCurVelY[0]);
                CAXM.AxmStatusReadVel(CAXHS.AXIS_N04(m_lAxis, 3), ref dCurVelY[1]);

                textCmdVelX.Text = String.Format("{0:0.000}", dCurVelX[0]);
                textCmdVelY.Text = String.Format("{0:0.000}", dCurVelX[1]);
                textCmdVelZ.Text = String.Format("{0:0.000}", dCurVelY[0]);
                textCmdVelU.Text = String.Format("{0:0.000}", dCurVelY[1]);

                XYPlot.AppendPoint(dX1, dY1);

                if (dCurVelX[0] > 0 || dCurVelX[1] > 0) GraphX.AppendPoints(dCurVelX[0], dCurVelX[1]);
                if (dCurVelY[0] > 0 || dCurVelY[1] > 0) GraphY.AppendPoints(dCurVelY[0], dCurVelY[1]);
			}
		}

		// It is displayed part of motion on the screen and timer is setup 50msec.
		private void timerDisplay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if( m_lAxis >= -1 )
			{
				double	dCmdXPosition	=0.0, dCmdYPosition	=0.0;
				double	dCmdZPosition	=0.0, dCmdUPosition	=0.0;

				double	dActXPosition	=0.0, dActYPosition	=0.0;
				double	dActZPosition	=0.0, dActUPosition	=0.0;

				int nAxisX = CAXHS.AXIS_N04(m_lAxis, 0);
				int nAxisY = CAXHS.AXIS_N04(m_lAxis, 1);
				int nAxisZ = CAXHS.AXIS_N04(m_lAxis, 2);
				int nAxisU = CAXHS.AXIS_N04(m_lAxis, 3);

                CAXM.AxmStatusGetCmdPos(nAxisX, ref dCmdXPosition);
                CAXM.AxmStatusGetCmdPos(nAxisY, ref dCmdYPosition);
                CAXM.AxmStatusGetCmdPos(nAxisZ, ref dCmdZPosition);
                CAXM.AxmStatusGetCmdPos(nAxisU, ref dCmdUPosition);

                CAXM.AxmStatusGetActPos(nAxisX, ref dActXPosition);
                CAXM.AxmStatusGetActPos(nAxisY, ref dActYPosition);
                CAXM.AxmStatusGetActPos(nAxisZ, ref dActZPosition);
                CAXM.AxmStatusGetActPos(nAxisU, ref dActUPosition);

				textCmdPosX.Text = String.Format( "{0:0.000}", dCmdXPosition );
				textCmdPosY.Text = String.Format( "{0:0.000}", dCmdYPosition );
				textCmdPosZ.Text = String.Format( "{0:0.000}", dCmdZPosition );
				textCmdPosU.Text = String.Format( "{0:0.000}", dCmdUPosition );

				textActPosX.Text = String.Format( "{0:0.000}", dActXPosition );
				textActPosY.Text = String.Format( "{0:0.000}", dActYPosition );
				textActPosZ.Text = String.Format( "{0:0.000}", dActZPosition );
				textActPosU.Text = String.Format( "{0:0.000}", dActUPosition );

				uint	uReadInput	=0, uReadOutput	=0;
				uint	uMechanicalStatus	=0;

				CAXM.AxmSignalReadInput( m_lAxis, ref uReadInput );
				CAXM.AxmSignalReadOutput( m_lAxis, ref uReadOutput );
				CAXM.AxmStatusReadMechanical( m_lAxis, ref uMechanicalStatus );

				byte	byReadInput		= (byte)uReadInput;
				byte	byReadOutput	= (byte)uReadOutput;
				ushort	usMechanic		= (ushort)uMechanicalStatus;

				// General output
				if( (byReadOutput & 0x01) == 0 )	lblLedOut0.BackColor = Color.Transparent;					// bit0
				else								lblLedOut0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
				if( (byReadOutput & 0x02) == 0 )	lblLedOut1.BackColor = Color.Transparent;					// bit1
				else								lblLedOut1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
				if( (byReadOutput & 0x04) == 0 )	lblLedOut2.BackColor = Color.Transparent;					// bit2
				else								lblLedOut2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
				if( (byReadOutput & 0x08) == 0 )	lblLedOut3.BackColor = Color.Transparent;					// bit3
				else								lblLedOut3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
				if( (byReadOutput & 0x10) == 0 )	lblLedOut4.BackColor = Color.Transparent;					// bit4
				else								lblLedOut4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
				//if( (byReadOutput & 0x20) == 0 )	lblLedOut5.BackColor = Color.Transparent;					// bit5
				//else								lblLedOut5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5

				uint wReadHome = 0;
				CAXM.AxmHomeReadSignal(m_lAxis, ref wReadHome);				
				if(wReadHome == 0)		lblLedHome.BackColor = Color.FromArgb(200, Color.Gold);	// On
				else					lblLedHome.BackColor = Color.Transparent;	

				// General input
				if( (byReadInput & 0x01) == 0 )		lblLedIn0.BackColor = Color.Transparent;					// bit0
				else								lblLedIn0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
				if( (byReadInput & 0x02) == 0 )		lblLedIn1.BackColor = Color.Transparent;					// bit1
				else								lblLedIn1.BackColor = Color.FromArgb(200, Color.Gold);	// bit1
				if( wReadHome == 0 )				lblLedIn0.BackColor = Color.Transparent;					// bit0
				else								lblLedIn0.BackColor = Color.FromArgb(200, Color.Gold);	// bit0
				if( (byReadInput & 0x04) == 0 )		lblLedIn2.BackColor = Color.Transparent;					// bit2
				else								lblLedIn2.BackColor = Color.FromArgb(200, Color.Gold);	// bit2
				if( (byReadInput & 0x08) == 0 )		lblLedIn3.BackColor = Color.Transparent;					// bit3
				else								lblLedIn3.BackColor = Color.FromArgb(200, Color.Gold);	// bit3
				if( (byReadInput & 0x10) == 0 )		lblLedIn4.BackColor = Color.Transparent;					// bit4
				else								lblLedIn4.BackColor = Color.FromArgb(200, Color.Gold);	// bit4
		//		if( (byReadInput & 0x20) == 0 )		lblLedIn5.BackColor = Color.Transparent;					// bit5
		//		else								lblLedIn5.BackColor = Color.FromArgb(200, Color.Gold);	// bit5

				if( (usMechanic & 0x0001) == 0 )	lblLedPELM.BackColor = Color.Transparent;						// bit0
				else								lblLedPELM.BackColor = Color.FromArgb(200, Color.Gold);		// bit0
				if( (usMechanic & 0x0002) == 0 )	lblLedNELM.BackColor = Color.Transparent;						// bit1
				else								lblLedNELM.BackColor = Color.FromArgb(200, Color.Gold);		// bit1
				if( (usMechanic & 0x0010) == 0 )	lblLedAlarm.BackColor = Color.Transparent;					// bit4
				else								lblLedAlarm.BackColor = Color.FromArgb(200, Color.Gold);		// bit4
				if( (usMechanic & 0x0020) == 0 )	lblLedInposition.BackColor = Color.Transparent;				// bit5
				else								lblLedInposition.BackColor = Color.FromArgb(200, Color.Gold);	// bit5

				if( (usMechanic & 0x0040) == 0 )	lblLedEMG.BackColor = Color.Transparent;						// bit6
				else								lblLedEMG.BackColor = Color.FromArgb(200, Color.Gold);		// bit6

				// EXPP, EXMP
				if( (usMechanic & 0x0800) == 0 )	lblLedEXPP.BackColor = Color.Transparent;						// bit9
				else								lblLedEXPP.BackColor = Color.FromArgb(200, Color.Gold);		// bit9
				if( (usMechanic & 0x1000) == 0 )	lblLedEXMP.BackColor = Color.Transparent;						// bit8
				else								lblLedEXMP.BackColor = Color.FromArgb(200, Color.Gold);		// bit8

				if( (usMechanic & 0x0100) == 0 )	lblLedZphase.BackColor = Color.FromArgb(200, Color.Gold);	// On
				else								lblLedZphase.BackColor = Color.Transparent;					// Off
				
				uint	uBusyStatusX =0, uBusyStatusY =0;
				CAXM.AxmStatusReadInMotion( CAXHS.AXIS_EVN(m_lAxis), ref uBusyStatusX );
				CAXM.AxmStatusReadInMotion( CAXHS.AXIS_ODD(m_lAxis), ref uBusyStatusY );

				if( uBusyStatusX == 0 )				lblLedBusyX.BackColor = Color.Transparent;					// On
				else								lblLedBusyX.BackColor = Color.FromArgb(200, Color.Gold);		// Off
				if( uBusyStatusY == 0 )				lblLedBusyY.BackColor = Color.Transparent;					// On
				else								lblLedBusyY.BackColor = Color.FromArgb(200, Color.Gold);		// Off

				//
				uint	uReadInterpolationQueueFree =0;
				uint	uIsContMotion =0;

				// A function which reads current index value in interpolation queue
				CAXM.AxmContiReadFree( COORD_NO, ref uReadInterpolationQueueFree );
				
				// A function which chks running of serial interpolation
				CAXM.AxmContiIsMotion( COORD_NO, ref uIsContMotion );
				
				int		nNodeNum1 =0, nTotalNodeNum1 =0;
				CAXM.AxmContiGetNodeNum( m_lAxis, ref nNodeNum1 );
				CAXM.AxmContiGetTotalNodeNum( m_lAxis, ref nTotalNodeNum1 );

				edtTotalNum.Text	= nTotalNodeNum1.ToString();
				edtContiNum.Text	= nNodeNum1.ToString();				
				edtInMotion.Text	= uIsContMotion.ToString();
				edtQFree.Text	= uReadInterpolationQueueFree.ToString();
				lblInterruptCount.Text	= m_nInterruptCnt.ToString();
			}
		}

		// Setup active level value of (+) End Limit.
		private void chkPELMLevel_CheckedChanged(object sender, System.EventArgs e)
		{
			uint	uPositiveLevel =0, uNegativeLevel =0, uStopMode =0;

			if( chkPELMLevel.Checked == true )
			{
				CAXM.AxmSignalGetLimit( m_lAxis, ref uStopMode, ref uPositiveLevel, ref uNegativeLevel );
				CAXM.AxmSignalSetLimit( m_lAxis, 0, (uint)AXT_MOTION_LEVEL_MODE.HIGH, uNegativeLevel);	// Stop Mode : ESTOP, plevel: High
			}
			else
			{
				CAXM.AxmSignalGetLimit( m_lAxis, ref uStopMode, ref uPositiveLevel, ref uNegativeLevel );
				CAXM.AxmSignalSetLimit( m_lAxis, 0, (uint)AXT_MOTION_LEVEL_MODE.LOW, uNegativeLevel );	// Stop Mode : ESTOP, plevel: High
			}
		}

		// Setup active level value of (-) End Limit.
		private void chkNELMLevel_CheckedChanged(object sender, System.EventArgs e)
		{
			uint	uPositiveLevel =0, uNegativeLevel =0, uStopMode =0;

			if( chkNELMLevel.Checked == true )
			{
				CAXM.AxmSignalGetLimit( m_lAxis, ref uStopMode, ref uPositiveLevel, ref uNegativeLevel );
				CAXM.AxmSignalSetLimit( m_lAxis, 0, uPositiveLevel, (uint)AXT_MOTION_LEVEL_MODE.HIGH );	// Stop Mode : ESTOP, plevel: High
			}
			else
			{
				CAXM.AxmSignalGetLimit( m_lAxis, ref uStopMode, ref uPositiveLevel, ref uNegativeLevel );
				CAXM.AxmSignalSetLimit( m_lAxis, 0, uPositiveLevel, (uint)AXT_MOTION_LEVEL_MODE.LOW );	// Stop Mode : ESTOP, plevel: High
			}
		}

		// Setup active level value of in-position signal.  High if chked, Low if not chked.
		private void chkInpositionLevel_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkInpLevel.Checked == true )
                CAXM.AxmSignalSetInpos( m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.HIGH ); 
			else
				CAXM.AxmSignalSetInpos( m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.LOW ); 
		}

		// Setup active level value of alarm signal.  High if chked, Low if not chked.
		private void chkAlarmLevel_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkAlarmLevel.Checked == true )
				CAXM.AxmSignalSetServoAlarm( m_lAxis,(uint)AXT_MOTION_LEVEL_MODE.HIGH );
			else
				CAXM.AxmSignalSetServoAlarm( m_lAxis,(uint)AXT_MOTION_LEVEL_MODE.LOW );
		}

		private void chkHomeLevel_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkHomeLevel.Checked == true )
				CAXM.AxmHomeSetSignalLevel(m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.LOW); 
			else
				CAXM.AxmHomeSetSignalLevel(m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.HIGH); 
		}

		private void chkZphase_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkZphase.Checked == true )
				CAXM.AxmSignalSetZphaseLevel(m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.LOW); 
			else
				CAXM.AxmSignalSetZphaseLevel(m_lAxis, (uint)AXT_MOTION_LEVEL_MODE.HIGH); 
		}

		// Setup general output #0(Servo-On).  Output will go out if chked, Output will not go out if not chked.
		private void lblLedOut0_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 0, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalServoOn( m_lAxis, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalServoOn( m_lAxis, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void lblLedOut1_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 1, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalWriteOutputBit( m_lAxis, 1, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalWriteOutputBit( m_lAxis, 1, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void lblLedOut2_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 2, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalWriteOutputBit( m_lAxis, 2, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalWriteOutputBit( m_lAxis, 2, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void lblLedOut3_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 3, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalWriteOutputBit( m_lAxis, 3, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalWriteOutputBit( m_lAxis, 3, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void lblLedOut4_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 4, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalWriteOutputBit( m_lAxis, 4, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalWriteOutputBit( m_lAxis, 4, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void lblLedOut5_Click(object sender, System.EventArgs e)
		{
			uint	dwOutBit	=0;
			CAXM.AxmSignalReadOutputBit( m_lAxis, 5, ref dwOutBit );
	
			if( dwOutBit != 0 )		CAXM.AxmSignalWriteOutputBit( m_lAxis, 5, (uint)AXT_BOOLEAN.FALSE );
			else					CAXM.AxmSignalWriteOutputBit( m_lAxis, 5, (uint)AXT_BOOLEAN.TRUE );	
		}

		private void SettingForContiIPMove()
		{
			if( m_lAxis < 0 )
				return;

			uint	uModuleNo =0;
			double	dXEnd =0.0, dYEnd =0.0, dVelocity =0.0, dAccel =0.0, dStartSpeed =0.0;
			uint	uModuleCounts =0;

			dXEnd		= Convert.ToDouble( textXEnd.Text );
			dYEnd		= Convert.ToDouble( textYEnd.Text );
			dStartSpeed	= Convert.ToDouble( numStartSpeed.Value );
			dVelocity	= Convert.ToDouble( numVelocity.Value );
			dAccel		= Convert.ToDouble( numAccel.Value );
	
			CAXM.AxmInfoIsMotionModule( ref uModuleCounts );

			uModuleNo = uModuleCounts;

			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
			if ( m_lAxis == 0 )
			{
//				m_GraphX.MaxRange = dVelocity + (dVelocity * 0.2);
//				m_GraphX.MinRange = m_lAxis;
			}
			else
			{
//				m_GraphY.MaxRange = dVelocity + (dVelocity * 0.2);
//				m_GraphY.MinRange = m_lAxis+1;
			}

			// Mode = 1 : S-Curve /  Mode = 2 : Trapzoid
			if( chkSCurve.Checked == true )
			{
				CAXM.AxmMotSetProfileMode( m_lAxis, 4 );
				CAXM.AxmMotSetProfileMode( m_lAxis+1, 4 );
			}
			else
			{
				CAXM.AxmMotSetProfileMode( m_lAxis, 0 );
				CAXM.AxmMotSetProfileMode( m_lAxis+1, 0 );
			}
	
			if( chkAbsolute.Checked == true )
			{
				CAXM.AxmMotSetAbsRelMode( m_lAxis, 0 );
				CAXM.AxmMotSetAbsRelMode( m_lAxis+1, 0 );
			}
			else
			{
				CAXM.AxmMotSetAbsRelMode( m_lAxis, 1 );
				CAXM.AxmMotSetAbsRelMode( m_lAxis+1, 1 );
			}
		}

        private void btnContiBlend_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis < 0 )
				return;

			double	dVelocity	= Convert.ToDouble( numVelocity.Value );
			double	dAccel		= Convert.ToDouble( numAccel.Value );
			double	dDecel		= Convert.ToDouble( numDecel.Value );

			int[]	    nAxis	= new int[2];
			double[]	dPos	= new double[2];
			double[]	dCenPos	= new double[2];
			double[]	dEndPos	= new double[2];

            nAxis[0] = CAXHS.AXIS_N04(m_lAxis, 0);
            nAxis[1] = CAXHS.AXIS_N04(m_lAxis, 1);

            SetGraphRange(nAxis[0], dVelocity);

            
            CAXM.AxmContiSetAxisMap(COORD_NO, 2, nAxis);
            CAXM.AxmContiWriteClear(COORD_NO); 
            CAXM.AxmContiSetAbsRelMode(COORD_NO, 0);
	
			CAXM.AxmContiBeginNode(COORD_NO);

			dPos[0] = 0 ; dPos[1] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);
			dPos[0] = 1800 ; dPos[1] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);	
	
			dCenPos[0] = 1800 ; dCenPos[1] = 1800; dEndPos[0] = 2000; dEndPos[1] = 1800;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);
	
			dPos[0] = 2000 ; dPos[1] = -1800;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
			dCenPos[0] = 1800 ; dCenPos[1] = -1800; dEndPos[0] = 1800; dEndPos[1] = -2000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);

			dPos[0] = -1800 ; dPos[1] = -2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
			dCenPos[0] = -1800 ; dCenPos[1] = -1800; dEndPos[0] = -2000; dEndPos[1] = -1800;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);

			dPos[0] = -2000 ; dPos[1] = 1800;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);	
	
			dCenPos[0] = -1800 ; dCenPos[1] = 1800; dEndPos[0] = -1800; dEndPos[1] = 2000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dDecel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);

			dPos[0] = 0 ; dPos[1] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);	
	
			CAXM.AxmContiEndNode(COORD_NO);
		}

        private void btnContiCircle_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis < 0 )
				return;

			double	dVelocity	= Convert.ToDouble( numVelocity.Value );
			double	dAccel		= Convert.ToDouble( numAccel.Value );
			int[]	    nAxis	= new int[2];
			double[]	dPos	= new double[2];
			double[]	dCenPos	= new double[2];
			double[]	dEndPos	= new double[2];

            nAxis[0] = CAXHS.AXIS_N04(m_lAxis, 0);
            nAxis[1] = CAXHS.AXIS_N04(m_lAxis, 1);

            SetGraphRange(nAxis[0], dVelocity);	

			CAXM.AxmContiSetAxisMap(COORD_NO, 2, nAxis);
            CAXM.AxmContiWriteClear(COORD_NO); 
            CAXM.AxmContiSetAbsRelMode(COORD_NO, 0);
	
			CAXM.AxmContiBeginNode(COORD_NO); 	
			dCenPos[0] = 1000 ; dCenPos[1] = 1000; dEndPos[0] = 0; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);

			dCenPos[0] = -1000 ; dCenPos[1] = 1000; dEndPos[0] = 0; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);

			dCenPos[0] = -1000 ; dCenPos[1] = -1000; dEndPos[0] = 0; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);

			dCenPos[0] = 1000 ; dCenPos[1] = -1000; dEndPos[0] = 0; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);
			CAXM.AxmContiEndNode(COORD_NO);
		}

        private void btnContiLine_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis < 0 )
				return;

			double	dVelocity	= Convert.ToDouble( numVelocity.Value );
			double	dAccel		= Convert.ToDouble( numAccel.Value );
			int[]	nAxis	    = new int[3];
			double[] dPos		= new double[3];
			double	dDecel		= Convert.ToDouble( numDecel.Value );

            nAxis[0] = CAXHS.AXIS_N04(m_lAxis, 0);
            nAxis[1] = CAXHS.AXIS_N04(m_lAxis, 1);
            nAxis[2] = CAXHS.AXIS_N04(m_lAxis, 2);

            SetGraphRange(nAxis[0], dVelocity);
            SetGraphRange(nAxis[2], dVelocity);

            CAXM.AxmContiSetAxisMap(COORD_NO, 3, nAxis);
			CAXM.AxmContiWriteClear(COORD_NO);
            CAXM.AxmContiSetAbsRelMode(COORD_NO, (uint)AXT_MOTION_ABSREL.POS_ABS_MODE);
                        
            CAXM.AxmContiBeginNode(COORD_NO);

			dPos[0] = 0 ; dPos[1] = 0; dPos[2] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = 2000; dPos[2] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = 2000; dPos[2] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 2000 ; dPos[1] = 0; dPos[2] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = -2000; dPos[2] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = -2000 ; dPos[1] = 0; dPos[2] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = 2000; dPos[2] = 2000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = 2000; dPos[2] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			dPos[0] = 0 ; dPos[1] = 0; dPos[2] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dDecel);

			CAXM.AxmContiEndNode(COORD_NO);
		}

        private void btnReadCapture_Click(object sender, System.EventArgs e)
		{
			double	dCapPos =0.0;
			CAXM.AxmMoveGetCapturePos(m_lAxis, ref dCapPos);
			lblCapture.Text	= dCapPos.ToString();
    	}

        private void btnContiStart_Click(object sender, System.EventArgs e)
		{
			CAXM.AxmContiStart(COORD_NO, 0, 0);
		}

        private void btnContiSpline_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis < 0 )
				return;

			double[]	dPosX		= new double[5];
			double[]	dPosY		= new double[5];
            int[]       lAxisNo     = new int[2];
            
            double dVelocity = Convert.ToDouble(numVelocity.Value);
            double dAccel = Convert.ToDouble(numAccel.Value);
            double dDecel = Convert.ToDouble(numDecel.Value);

            lAxisNo[0] = CAXHS.AXIS_N04(m_lAxis, 0);
            lAxisNo[1] = CAXHS.AXIS_N04(m_lAxis, 1);

            // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            SetGraphRange(lAxisNo[0], dVelocity);
            			
            CAXM.AxmContiSetAxisMap(COORD_NO, 2, lAxisNo);
            CAXM.AxmContiWriteClear(COORD_NO);
			CAXM.AxmContiSetAbsRelMode(COORD_NO, 0);

			dPosX[0] = 0   ; dPosY[0] = 0;
			dPosX[1] = 450 ; dPosY[1] = 100;
			dPosX[2] = 750 ; dPosY[2] = 450;
			dPosX[3] = 1080; dPosY[3] = 750;
			dPosX[4] = 1300; dPosY[4] = 700;

			CAXM.AxmContiBeginNode(COORD_NO);
			CAXM.AxmSplineWrite(COORD_NO, 5, dPosX, dPosY, dVelocity, dAccel, dAccel, 0, 100);
			CAXM.AxmContiEndNode(COORD_NO);
		}

        private void btnContiClear_Click(object sender, System.EventArgs e)
		{
			CAXM.AxmContiWriteClear( COORD_NO );
		}

		private void btnStatus_Click(object sender, System.EventArgs e)
		{
			FormStatusView	formStatusView	= new FormStatusView();

			CAXHS.m_SendAxis = m_lAxis;

			formStatusView.Show();
		}

        private void btnTrigAbs_Click(object sender, System.EventArgs e)
		{
			double[] arrdTrigPos = new double[1];

			uint	uErrorCode	= 0;  
			int		nPulseWidth;
            
            arrdTrigPos[0] = Convert.ToDouble(edtTrigStartPosition.Value);
            nPulseWidth = Convert.ToInt32(edtTrigPulseWidth.Value);

			CAXM.AxmTriggerSetReset(m_lAxis);
			CAXM.AxmTriggerSetTimeLevel(m_lAxis, nPulseWidth, (uint)AXT_MOTION_LEVEL_MODE.HIGH, (uint)AXT_MOTION_SELECTION.COMMAND, (uint)AXT_USE.ENABLE);
			
			uErrorCode = CAXM.AxmTriggerOnlyAbs(m_lAxis, 1, arrdTrigPos);
			if ( uErrorCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS )
                lstLog.Items.Add("Setting Trigger");
            else
                lstLog.Items.Add("Not Setting Trigger");

			lstLog.SelectedIndex = lstLog.Items.Count-1;
		}

        private void btnTrigPeriod_Click(object sender, System.EventArgs e)
		{
            uint    uErrorCode  = 0;  
			double	dStartPos	= Convert.ToDouble( edtTrigStartPosition.Value );
			double  dCycle      = Convert.ToDouble( edtTrigCycle.Value );
			int		nPulseWidth	= Convert.ToInt32( edtTrigPulseWidth.Value );
			double	dEndPos		= Convert.ToDouble( edtTrigEndPos.Value );

			CAXM.AxmTriggerSetReset(m_lAxis);
			CAXM.AxmTriggerSetTimeLevel(m_lAxis, nPulseWidth, (uint)AXT_MOTION_LEVEL_MODE.HIGH, (uint)AXT_MOTION_SELECTION.COMMAND, (uint)AXT_USE.ENABLE);

            uErrorCode = CAXM.AxmTriggerSetBlock(m_lAxis, dStartPos, dEndPos, dCycle);
            if (uErrorCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                lstLog.Items.Add("Setting Trigger");
            else
                lstLog.Items.Add("Not Setting Trigger");

            lstLog.SelectedIndex = lstLog.Items.Count - 1;
		}

		public enum AXT_EVENT:uint
		{
			WM_USER				= 0x0400,
			WM_AXL_INTERRUPT	= (WM_USER + 1100)
		}

		public enum AXT_INTERRUPT_CLASS:uint
		{
			KIND_MESSAGE,
			KIND_CALLBACK,
			KIND_EVENT
		}

		private void btnMessageMethod_Click(object sender, System.EventArgs e)
		{
			uint uEvent	= (uint)0;
            uint uInterruptNum = 0;

            CAXL.AxlInterruptEnable();
			CAXM.AxmInterruptSetAxisEnable( m_lAxis, (uint)AXT_USE.ENABLE );

            // Setup whether interrupt is generated which user of the designated axis set.
            // lBank : Possible to setup interrupt bank number (0 - 1).
            // lInterruptNum : Setup interrupt
            CAXM.AxmInterruptSetUserEnable(m_lAxis, 1, (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_29);			// Input signal of limit signal (PELM, NELM).
            CAXM.AxmInterruptSetAxis(m_lAxis, (uint)this.Handle, (uint)AXT_EVENT.WM_AXL_INTERRUPT, null, ref uEvent);

            CAXM.AxmInterruptGetUserEnable(m_lAxis, 1, ref uInterruptNum);
            String strMsg = String.Format("Limit Int Enable[1][{0:X}]", uInterruptNum);
            lstLog.Items.Add(strMsg);

            lstLog.SelectedIndex = lstLog.Items.Count - 1;			
		}

		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				case (int)AXT_EVENT.WM_AXL_INTERRUPT:
					InterruptProc(AXT_INTERRUPT_CLASS.KIND_MESSAGE, (int)m.WParam, (uint)m.LParam);
					break;
			}
			base.WndProc( ref m );
		}

        private bool InterruptProc(AXT_INTERRUPT_CLASS uClass, int nAxisNo, uint nIntrFlag)
		{
            uint IntBank0 = 0;
            uint IntBank1 = 0;
			int nInterFlag	= (int)nIntrFlag;						// Interrupt generation axis location.
			
			String	strLog = "";
			switch (uClass)
			{
				case AXT_INTERRUPT_CLASS.KIND_MESSAGE:
                    ++m_nInterruptCnt;
                    strLog = String.Format("Msg[{0:d}]Axis[{1:d}]Flag[{2:d}]", m_formMotion.m_nInterruptCnt, nAxisNo, nInterFlag);
					break;

				case AXT_INTERRUPT_CLASS.KIND_CALLBACK:
                    if (m_formMotion.m_EventThread[nAxisNo] != null)
					{
                        m_EventThread[nAxisNo].Abort();
                        m_EventThread[nAxisNo] = null;
                        m_bEventThread[nAxisNo] = false;
					}

                    ++m_nInterruptCnt;
                    strLog = String.Format("Cal[{0:d}]Axis[{1:d}]Flag[{2:d}]", m_nInterruptCnt, nAxisNo, nInterFlag);
					break;

				case AXT_INTERRUPT_CLASS.KIND_EVENT:
                    ++m_formMotion.m_nInterruptCnt;

                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 0, ref IntBank0);
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 1, ref IntBank1);
                    strLog = String.Format("Event[{0:d}]Axis[{1:d}]Flag[{2:X},{3:X}]", m_nInterruptCnt, nAxisNo, IntBank0, IntBank1);
					break;
			}
            AddLogMessage(strLog);
			return true;
		}

        private void AddLogMessage(string strLog)
        {
            if (this.lstLog.InvokeRequired)
            {
                SetTextCallBack dele = new SetTextCallBack(AddLogMessage);
                this.Invoke(dele, new object[] { strLog });
            }
            else
            {
                this.lstLog.Items.Add(strLog);
                this.lstLog.SelectedIndex = this.lstLog.Items.Count - 1;
            }
        }

		private void btnMethodDisable_Click(object sender, System.EventArgs e)
		{
			if( m_EventThread[m_lAxis] != null )
			{
                m_EventThread[m_lAxis].Abort();
                m_EventThread[m_lAxis] = null;
                m_bEventThread[m_lAxis] = false;
			}

			m_nInterruptCnt = 0; // Interrupt count clear
			
			uint	uEvent	= (uint)0;
            CAXL.AxlInterruptDisable();
			CAXM.AxmInterruptSetAxis( m_lAxis, (uint)this.Handle, 0, null, ref uEvent );	// Cancel interrupt method
			CAXM.AxmInterruptSetAxisEnable( m_lAxis, (uint)AXT_USE.DISABLE );			// Interrupt DISABLE
		}

		public static void KeMotionInterruptCallback(int nAxisNo, uint uFlag)
		{
            m_formMotion.InterruptProc(AXT_INTERRUPT_CLASS.KIND_CALLBACK, nAxisNo, uFlag);
		}

		private void btnEventMethod_Click(object sender, System.EventArgs e)
		{
            uint uInterruptNum = 0;
            CAXL.AxlInterruptEnable();
			CAXM.AxmInterruptSetAxisEnable( m_lAxis, (uint)AXT_USE.ENABLE );

            // Setup whether interrupt is generated which user of the designated axis set.
            // lBank : Possible to setup interrupt bank number (0 - 1).
            // lInterruptNum : Setup interrupt
            CAXM.AxmInterruptSetUserEnable(m_lAxis, 0, (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_29);			// Accepted server alarm signal
            CAXM.AxmInterruptSetAxis(m_lAxis, 0, 0, null, ref m_uEventInterrupt[m_lAxis]);

            CAXM.AxmInterruptGetUserEnable(m_lAxis, 0, ref uInterruptNum);
            String strMsg = String.Format("Alarm Int Enable[0][{0:X}]", uInterruptNum);
            lstLog.Items.Add(strMsg);

            lstLog.SelectedIndex = lstLog.Items.Count - 1;
            if (m_EventThread[m_lAxis] != null)
			{
                m_EventThread[m_lAxis].Abort();
                m_EventThread[m_lAxis] = null;
                m_bEventThread[m_lAxis] = false;
			}
	
			if ( m_bEventThread[m_lAxis] == false)
			{
				// EventThread Setting
                int lAxisNo = new int();
                lAxisNo = m_lAxis;
				m_bEventThread[m_lAxis]	= true;
                m_EventThread[m_lAxis] = new Thread(new ParameterizedThreadStart(EventThreadProc));
                m_EventThread[m_lAxis].Start(lAxisNo);
                m_EventThread[m_lAxis].IsBackground = true;
               
			}
		}

		public void EventThreadProc(Object objData)
		{
            int nAxisNo = (int)objData;
            while (m_bEventThread[nAxisNo] == true)
            {
                if (WaitForSingleObject(m_uEventInterrupt[nAxisNo], INFINITE) == WAIT_OBJECT_0)
				{
                    InterruptProc(AXT_INTERRUPT_CLASS.KIND_EVENT, nAxisNo, 0);
				}
			}
		}

		private void btnJogPY_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );

            GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];
			double[]	dAccel2				= new double[2];

			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 0);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 1);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )	uProfileMode	= 0;	// symmetry Trapezoide
				else								uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )	uProfileMode	= 1;	// asymmetry Trapezoide
				else								uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis+1, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity2, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 1), dVelocity, dAccel, dDecel );
		}

		private void btnJogPY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 1));
		}

		private void btnJogNX_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];
			double[]	dAccel2				= new double[2];
			
			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 0);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 1);
		
			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity3, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 0), -dVelocity, dAccel, dDecel );
		}

		private void btnJogNX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 0));
		}

		private void btnJogPX_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];

			double[]	dAccel2				= new double[2];
			
			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 0);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 1);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity2, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 0), dVelocity, dAccel, dDecel );
		}

		private void btnJogPX_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 0));
		}

		private void btnJogNY_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];

			double[]	dAccel2				= new double[2];
			
			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 0);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 1);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis+1, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity3, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 1), -dVelocity, dAccel, dDecel );
		}

		private void btnJogNY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 1));
		}

        private void btnJogPU_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];
			double[]	dAccel2				= new double[2];

			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 2);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 3);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis+1, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity2, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 3), dVelocity, dAccel, dDecel );
		}

		private void btnJogPU_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 3));
		}

		private void btnJogNZ_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];
			double[]	dAccel2				= new double[2];
			
			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 2);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 3);
		
			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity3, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 2), -dVelocity, dAccel, dDecel );
		}

		private void btnJogNZ_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 2));
		}

		private void btnJogPZ_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];

			double[]	dAccel2				= new double[2];
			
			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 2);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 3);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity2, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 2), dVelocity, dAccel, dDecel );
		}

		private void btnJogPZ_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 2));
		}

		private void btnJogNU_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double	dVelocity	= Math.Abs( Convert.ToDouble( numVelocity.Value ) );
			double	dAccel		= Math.Abs( Convert.ToDouble( numAccel.Value ) );
			double	dDecel		= Math.Abs( Convert.ToDouble( numDecel.Value ) );
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2));

			int[]		arrnAxis			= new int[2];
			double[]	dVelocity2			= new double[2];
			double[]	dVelocity3			= new double[2];

			double[]	dAccel2				= new double[2];

			for( int i=0; i<2; i++)
			{
				dVelocity2[i] = dVelocity;
				dVelocity3[i] = -dVelocity;
				dAccel2[i] = dAccel;
			}

			arrnAxis[0]			= CAXHS.AXIS_N04(m_lAxis, 2);
			arrnAxis[1]			= CAXHS.AXIS_N04(m_lAxis, 3);

			// Setting Profile Mode
			uint	uProfileMode	= 0;
			if ( chkAsym.Checked == false )	// symmetry
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 0;	// symmetry Trapezoide
				else											uProfileMode	= 3;	// symmetry S-Curve
			}
			else
			{
				if( chkSCurve.Checked == false )				uProfileMode	= 1;	// asymmetry Trapezoide
				else											uProfileMode	= 4;	// asymmetry S-Curve
			}

			CAXM.AxmMotSetProfileMode( m_lAxis+1, uProfileMode );
			if( chkXYSync.Checked == true )
				CAXM.AxmMoveStartMultiVel(2, arrnAxis, dVelocity3, dAccel2, dAccel2);
			else
				CAXM.AxmMoveVel( CAXHS.AXIS_N04(m_lAxis, 3), -dVelocity, dAccel, dDecel );
		}

		private void btnJogNU_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CAXM.AxmMoveSStop(CAXHS.AXIS_N04(m_lAxis, 3));
		}

        private void btnCNTCLR_Click(object sender, System.EventArgs e)
		{
			CAXM.AxmStatusSetActPos( CAXHS.AXIS_N04(m_lAxis, 0), 0.0 );
			CAXM.AxmStatusSetActPos( CAXHS.AXIS_N04(m_lAxis, 1), 0.0 );
			CAXM.AxmStatusSetActPos( CAXHS.AXIS_N04(m_lAxis, 2), 0.0 );
			CAXM.AxmStatusSetActPos( CAXHS.AXIS_N04(m_lAxis, 3), 0.0 );

			CAXM.AxmStatusSetCmdPos( CAXHS.AXIS_N04(m_lAxis, 0), 0.0 );
			CAXM.AxmStatusSetCmdPos( CAXHS.AXIS_N04(m_lAxis, 1), 0.0 );
			CAXM.AxmStatusSetCmdPos( CAXHS.AXIS_N04(m_lAxis, 2), 0.0 );
			CAXM.AxmStatusSetCmdPos( CAXHS.AXIS_N04(m_lAxis, 3), 0.0 );

			// Init XY Graph
			XYPlot.Reset = 1;
            lstLog.Items.Clear();
		}

		private void btnLinear_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis<0 )
				return;

			double dXend =0.0, dYend =0.0, dVelocity =0.0, dAccel =0.0, dStartSpeed =0.0, dDecel =0.0;
			uint   lPosSize = 2, uErrorCode = 0;

			int[]		nAxis			= new int[2];
			double[]	arrdPosition	= new double[2];
		
			nAxis[0]	= CAXHS.AXIS_EVN(m_lAxis);
			nAxis[1]	= CAXHS.AXIS_ODD(m_lAxis);

			dXend		= Convert.ToDouble( textXEnd.Text );
			dYend		= Convert.ToDouble( textYEnd.Text );
			dStartSpeed	= Convert.ToDouble( numStartSpeed.Value );
			dVelocity	= Convert.ToDouble( numVelocity.Value );
			dAccel		= Convert.ToDouble( numAccel.Value ); 
			dDecel      = Convert.ToDouble( numDecel.Value ); 

			arrdPosition[0]		= dXend;
			arrdPosition[1]		= dYend;
	
			// Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            SetGraphRange(nAxis[0], dVelocity);
		
            CAXM.AxmContiSetAxisMap(COORD_NO, lPosSize, nAxis);
            CAXM.AxmContiWriteClear(COORD_NO);

            SetCoordMovePara();
			uErrorCode =CAXM.AxmLineMove(COORD_NO, arrdPosition, dVelocity, dAccel, dDecel);

			if(uErrorCode != 0)	
			{
				String strMsg = String.Format(" Linear Error Code: {0:0} ", uErrorCode);
				m_formMotion.lstLog.Items.Add( strMsg );
			}

			double	dInitpos =0.0, dInitvel =0.0, dInitaccel =0.0, dInitdecel =0.0;
			CAXM.AxmMotGetParaLoad( m_lAxis, ref dInitpos ,ref dInitvel, ref dInitaccel, ref dInitdecel);
			CAXM.AxmMotSetParaLoad( m_lAxis, dInitpos ,dVelocity, dAccel, dDecel);			
		}

		private void btnCircular_Click(object sender, System.EventArgs e)
		{
			double dVelocity =0.0, dAccel =0.0, dAngle =0.0, dDecel =0.0;
			uint   uErrorCode = 0;
			int[]		nAxis   		= new int[2];
			double[]	dCenPos			= new double[2];
			double[]	dEndPos			= new double[2];

			dVelocity	= Convert.ToDouble( numVelocity.Value );
			dAccel		= Convert.ToDouble( numAccel.Value ); 
			dAngle		= Convert.ToDouble( textAngle.Text ); 
			dDecel      = Convert.ToDouble( numDecel.Value );

            dCenPos[0] = Convert.ToDouble(textXEnd.Text);
            dCenPos[1] = Convert.ToDouble(textYEnd.Text);

            nAxis[0] = CAXHS.AXIS_EVN(m_lAxis);
            nAxis[1] = CAXHS.AXIS_ODD(m_lAxis);

            SetGraphRange(nAxis[0], dVelocity);
			
            CAXM.AxmContiSetAxisMap(COORD_NO, 2, nAxis);
            CAXM.AxmContiWriteClear(COORD_NO);
            SetCoordMovePara();

			if( chkDIR.Checked == true )
			{
                uErrorCode = CAXM.AxmCircleAngleMove(COORD_NO, nAxis, dCenPos, dAngle, dVelocity, dAccel, dDecel, 0);
			}
			else
			{
                uErrorCode = CAXM.AxmCircleAngleMove(COORD_NO, nAxis, dCenPos, dAngle, dVelocity, dAccel, dDecel, 1); 
			}

			if(uErrorCode != 0)	
			{
				String strMsg = String.Format(" Circle Error Code: {0:0} ", uErrorCode);
				m_formMotion.lstLog.Items.Add( strMsg );
			}

			double	dInitpos =0.0, dInitvel =0.0, dInitaccel =0.0, dInitdecel =0.0;

			CAXM.AxmMotGetParaLoad( m_lAxis, ref dInitpos ,ref dInitvel, 
				ref dInitaccel, ref dInitdecel);

			CAXM.AxmMotSetParaLoad( m_lAxis, dInitpos ,dVelocity, 
				dAccel, dDecel);
		}

        private void SetCoordMovePara()
        {
	        //ProfileMode: '0' - symmetry Trapezode
	        //             '1' - asymmetry Trapezode
	        //             '2' - symmetry Quasi-S Curve
	        //             '3' - symmetry S Curve
	        //             '4' - asymmetry S Curve
            if (chkAbsolute.Checked)    CAXM.AxmContiSetAbsRelMode(COORD_NO, (uint)AXT_MOTION_ABSREL.POS_ABS_MODE);
            else                        CAXM.AxmContiSetAbsRelMode(COORD_NO, (uint)AXT_MOTION_ABSREL.POS_REL_MODE);
        }

		private void btnMPGOn_Click(object sender, System.EventArgs e)
		{
			double dVelocity = Convert.ToDouble( numVelocity.Value );
			double dAccel = Convert.ToDouble( numAccel.Value );

			int		nInputMethod	=3;
			int		nDriveMode		=0;
			double	dMPGPosition	= 1000;
			double  dMPGdenominator = 4096; // MPG(Manual Pulse Generation device Input) divide value when running (Calculated to add 1 to input value)
			double  dMPGnumerator   = 1; //  MPG(Manual Pulse Generation device Input) multiply value when running (Calculated to add 1 to input value)

			CAXM.AxmMPGSetEnable( m_lAxis, nInputMethod, nDriveMode, dMPGPosition, dVelocity, dAccel);
			CAXM.AxmMPGSetRatio( m_lAxis, dMPGdenominator, dMPGnumerator );
		}

		private void btnMPGOff_Click(object sender, System.EventArgs e)
		{
			CAXM.AxmMPGReset( m_lAxis );
		}

		private void btnCRCOn_Click(object sender, System.EventArgs e)
		{
			uint	uLevel = (uint)AXT_MOTION_LEVEL_MODE.HIGH;    //  0: LOW, 1: HIGH ,2: DISABLE

			CAXM.AxmCrcSetMaskLevel(m_lAxis, uLevel, 6);
		}

		private void btnCRCOff_Click(object sender, System.EventArgs e)
		{
			uint	uLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;    //  0: LOW, 1: HIGH ,2: DISABLE

			CAXM.AxmCrcSetMaskLevel(m_lAxis, uLevel, 6);

		}

		private void btnOneShot_Click(object sender, System.EventArgs e)
		{
			int		nPulseWidth	= Convert.ToInt32( edtTrigPulseWidth.Value );
			// It is the function that user outputting one trigger pulse by force.
			CAXM.AxmTriggerSetTimeLevel(m_lAxis, nPulseWidth, (uint)AXT_MOTION_LEVEL_MODE.HIGH, (uint)AXT_MOTION_SELECTION.COMMAND, (uint)AXT_USE.ENABLE);
			CAXM.AxmTriggerOneShot(m_lAxis);
		}

        private void btnTrigReset_Click(object sender, System.EventArgs e)
		{
			CAXM.AxmTriggerSetReset(m_lAxis);
		}

        private void SetGraphRange(int nAxis, double dVelocity)
        {
            if (dVelocity <= 0) return;

            // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
            if (CAXHS.AXIS_QUR(nAxis) < 2) GraphX.SetRanges(0, dVelocity + (dVelocity * 0.2));
            else GraphY.SetRanges(0, dVelocity + (dVelocity * 0.2));
        }

		private void Refresh( int nAxis )
		{
			int		nPulse			= 0;
			double	dUnit			= 0.0;
			double	dMinVelocity	= 0.0;

			CAXM.AxmMotGetMoveUnitPerPulse( m_lAxis, ref dUnit, ref nPulse );
			CAXM.AxmMotGetMinVel( m_lAxis, ref dMinVelocity );

			uint	uMethod = 0, uMethod2 = 0;
			CAXM.AxmMotGetEncInputMethod( m_lAxis, ref uMethod );
			CAXM.AxmMotGetPulseOutMethod( m_lAxis, ref uMethod2 );

			numMoveUnit.Value	= Convert.ToDecimal( dUnit/(double)nPulse );
			numStartSpeed.Value	= Convert.ToDecimal( dMinVelocity );

			cboEncInputM.SelectedIndex	= (int)uMethod;
			cboPulseOutM.SelectedIndex	= (int)uMethod2;
		}

		private void btnGearModeOn_Click(object sender, System.EventArgs e)
		{
	
		}

		private void btnGearModeOff_Click(object sender, System.EventArgs e)
		{
	
		}

		private void btnZoomInGraph_Click(object sender, System.EventArgs e)
		{
			if( m_uMagnifications >= 2 )
				m_uMagnifications /= 2;
		}

		private void btnZoomOutGraph_Click(object sender, System.EventArgs e)
		{
			if( m_uMagnifications < 4294967295/2 )
				m_uMagnifications *= 2;
		}

        private void btnContiTest_Click(object sender, System.EventArgs e)
		{
			if( m_lAxis < 0 )
				return;

            double dVelocity    = Convert.ToDouble(numVelocity.Value);
            double dAccel       = Convert.ToDouble(numAccel.Value);
			int[] nAxis	        = new int[2];
			double[] dPos	    = new double[2];
			double[] dCenPos	= new double[2];
			double[] dEndPos	= new double[2];

            nAxis[0] = CAXHS.AXIS_N04(m_lAxis, 0);
            nAxis[1] = CAXHS.AXIS_N04(m_lAxis, 1);

            SetGraphRange(nAxis[0], dVelocity);	
			
            CAXM.AxmContiSetAxisMap(COORD_NO, 2, nAxis);
            CAXM.AxmContiWriteClear(COORD_NO);
            CAXM.AxmContiSetAbsRelMode(COORD_NO, (uint)AXT_MOTION_ABSREL.POS_REL_MODE);

			CAXM.AxmContiBeginNode(COORD_NO); dPos[0] = -15000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos , dVelocity, dAccel, dAccel);                  //1
			dCenPos[0] = 0 ; dCenPos[1] = 5000; dEndPos[0] = -5000; dEndPos[1] = 5000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);  //2	
			dPos[0] = 0 ; dPos[1] = 30000;
			CAXM.AxmLineMove(COORD_NO, dPos , dVelocity, dAccel, dAccel);  //3
			dCenPos[0] = 5000 ; dCenPos[1] = 0; dEndPos[0] = 5000; dEndPos[1] = 5000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);   //4
			dPos[0] = 30000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);				   //5
			dCenPos[0] = 0 ; dCenPos[1] = -5000; dEndPos[0] = 5000; dEndPos[1] = -5000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//6
			dPos[0] = 0 ; dPos[1] = -30000;
			CAXM.AxmLineMove(COORD_NO, dPos , dVelocity, dAccel, dAccel);                  //7
			dCenPos[0] = -5000 ; dCenPos[1] = 0; dEndPos[0] = -5000; dEndPos[1] = -5000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//8
			dPos[0] = -15000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);				   //9
			dPos[0] = -10000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                  //10
			dCenPos[0] = 0 ; dCenPos[1] = 10000; dEndPos[0] = -10000; dEndPos[1] = 10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//11
			dPos[0] = 0 ; dPos[1] = 20000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                    //12
			dCenPos[0] = 10000 ; dCenPos[1] = 0; dEndPos[0] = 10000; dEndPos[1] = 10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW); //13
			dPos[0] = 20000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                    //14
			dCenPos[0] = 0 ; dCenPos[1] = -10000; dEndPos[0] = 10000; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//15
			dPos[0] = 0 ; dPos[1] = -20000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                    //16
			dCenPos[0] = -10000 ; dCenPos[1] = 0; dEndPos[0] = -10000; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//17
			dPos[0] = -10000 ; dPos[1] = 0;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                      //18
			dCenPos[0] = 0 ; dCenPos[1] = 20000; dEndPos[0] = 0; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);            //19
			dCenPos[0] = 0 ; dCenPos[1] = 10000; dEndPos[0] = -7071; dEndPos[1] = 2929;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);    //20
			dPos[0] = -10000 ; dPos[1] = 10000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                  //21
			dCenPos[0] = 7071 ; dCenPos[1] = 7071; dEndPos[0] =0; dEndPos[1] = 14142;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);    //22
			dPos[0] = 10000 ; dPos[1] = 10000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                   //23
			dCenPos[0] = 7071 ; dCenPos[1] = -7071; dEndPos[0] = 14142; dEndPos[1] = 0;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);   //24
			dPos[0] = 10000 ; dPos[1] = -10000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);                  //25
			dCenPos[0] = -7071 ; dCenPos[1] = -7071; dEndPos[0] = 0; dEndPos[1] = -14142;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW); //26
			dPos[0] = -10000 ; dPos[1] = -10000;
			CAXM.AxmLineMove(COORD_NO, dPos, dVelocity, dAccel, dAccel);     //27
			dCenPos[0] = -7071 ; dCenPos[1] = 7071; dEndPos[0] = -7071; dEndPos[1] = -2929;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);//28
			dCenPos[0] = 0 ; dCenPos[1] = 10000; dEndPos[0] = 0; dEndPos[1] = 20000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);      //29
			dCenPos[0] = 0 ; dCenPos[1] = 10000; dEndPos[0] = 0; dEndPos[1] = 20000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);      //30
			dCenPos[0] = 0 ; dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);     //31
			dCenPos[0] = 0 ; dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);     //32
			dCenPos[0] = 0 ; dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CCW);     //33
			dCenPos[0] = 0 ; dCenPos[1] = -5000; dEndPos[0] = 0; dEndPos[1] = -10000;
            CAXM.AxmCircleCenterMove(COORD_NO, nAxis, dCenPos, dEndPos, dVelocity, dAccel, dAccel, (uint)AXT_MOTION_MOVE_DIR.DIR_CW);     //34
			CAXM.AxmContiEndNode(COORD_NO);
		}

		private void btn3DGraph_Click(object sender, System.EventArgs e)
		{            
            if (m_b3DGraph == false)
            {
                m_frm3DView = new Form3DView();
                m_b3DGraph = true;
            }else{
                m_frm3DView.Close();
                m_frm3DView = new Form3DView();
            }

            m_frm3DView.UpdateAxis(m_lAxis);
            m_frm3DView.Show(this);
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
 
			openFileDialog1.Filter = "txt files (*.mot)|*.mot|All files (*.*)|*.*"  ;
			openFileDialog1.FilterIndex = 2 ;
			openFileDialog1.RestoreDirectory = true ;
 
			char[] nFilename = new char[255];
			string temp = null;

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				temp = openFileDialog1.FileName;

			if (CAXM.AxmMotLoadParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
					MessageBox.Show("File load failed");
			}				
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
 
			saveFileDialog1.Filter = "mot files (*.mot)|*.mot|All files (*.*)|*.*"  ;
			saveFileDialog1.FilterIndex = 2 ;
			saveFileDialog1.RestoreDirectory = true ;
 
			char[] nFilename = new char[255];
			string temp = null;			

			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				temp = saveFileDialog1.FileName;

				if (CAXM.AxmMotSaveParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
					MessageBox.Show("File save failed");
			}				
		}

		// Trance String to byte
		private byte[] StringToByte(String str)
		{
			byte[] nFilename = new byte[255];
			short  i   = 0;

			// String >> Byte
			while (i < str.Length)
			{
				nFilename[i] = (byte)str[i++];
			}

			return nFilename;
		}

		// Trance String to char
		private char[] StringToChar(String str)
		{
			char[] nFilename = new char[255];

			nFilename = str.ToCharArray(0, str.Length);
	
			return nFilename;
		}

		private void chkEmg_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkEmg.Checked == true )
				CAXM.AxmSignalSetStop( m_lAxis, (uint)AXT_MOTION_STOPMODE.EMERGENCY_STOP, (uint)AXT_MOTION_LEVEL_MODE.HIGH );
			else
				CAXM.AxmSignalSetStop( m_lAxis, (uint)AXT_MOTION_STOPMODE.EMERGENCY_STOP,(uint)AXT_MOTION_LEVEL_MODE.LOW );
		}

		private void chkGearOnOff_CheckedChanged(object sender, System.EventArgs e)
		{
			double dRatio = Convert.ToDouble( edtGearRatio.Value );

			if(chkGearOnOff.Checked == true)
			{
				// It is a function to setup gear rate of Master axis and Slave axis on Electric Gear mode.
				CAXM.AxmLinkSetMode( CAXHS.AXIS_EVN(m_lAxis), CAXHS.AXIS_ODD(m_lAxis), dRatio); 
			}
			else
			{
				CAXM.AxmLinkResetMode( CAXHS.AXIS_EVN(m_lAxis));
			}
		}

        private void FormMotion_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerDisplay.Enabled = false;
            timerGraph.Enabled = false;
        }

	}
}
