//---------------------------------------------------------------------------

#ifndef Builder1H
#define Builder1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Chart.hpp>
#include <ExtCtrls.hpp>
#include <MXGRAPH.hpp>
#include <Series.hpp>
#include <TeEngine.hpp>
#include <TeeProcs.hpp>

#include <Buttons.hpp>
#include <ComCtrls.hpp>

#include "AXL.h"
#include "AXM.h"
#include <Dialogs.hpp>

#define HOME_BIT                0
#define HOME_STEP               4
#define IN0_UPEDGE              0xC0
#define IN0_DNEDGE              0x40
#define IN1_UPEDGE              0xD0
#define IN1_DNEDGE              0x50
#define DIR_CW	                0x08
#define DIR_CCW	                0x00
#define STOP_EMG                0x04
#define USE_STEP                0x01
#define WM_CAMCIP_INTERRUPT		(WM_USER + 2009)

#define WAIT_ABANDONED          ((STATUS_ABANDONED_WAIT_0 ) + 0 )
#define WAIT_ABANDONED_0        ((STATUS_ABANDONED_WAIT_0 ) + 0 )

#define MAX_AXIS_COUNT                  64

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2 : 1, b3 : 1, b4 : 1, b5 : 1, b6 : 1, b7 : 1;
} byte_bits;

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2  : 1, b3  : 1, b4  : 1, b5  : 1, b6  : 1, b7  : 1,
				b8 : 1, b9 : 1, b10 : 1, b11 : 1, b12 : 1, b13 : 1, b14 : 1, b15 : 1;
} word_bits;

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2  : 1, b3  : 1, b4  : 1, b5  : 1, b6  : 1, b7  : 1,
				b8 : 1, b9 : 1, b10 : 1, b11 : 1, b12 : 1, b13 : 1, b14 : 1, b15 : 1,
				b16 : 1, b17 : 1, b18 : 1, b19 : 1, b20 : 1, b21 : 1, b22 : 1, b23 : 1,
				b24 : 1, b25 : 1, b26 : 1, b27 : 1, b28 : 1, b29 : 1, b30 : 1, b31 : 1;
} dword_bits;
typedef union {
	WORD wWord;
	BYTE bByte;
    DWORD dwWord;
	word_bits wbit; 
	dword_bits dwbit; 
	byte_bits bit;
} lsByte;

//---------------------------------------------------------------------------
class TfrmCamcQI : public TForm
{
__published:	// IDE-managed Components
    TGroupBox *GroupBox14;
    TLabel *LedBusyX;
    TLabel *LedBusyY;
    TLabel *LedEXPP;
    TLabel *LedEXMP;
    TGroupBox *GroupBox5;
    TLabel *Label20;
    TLabel *Label21;
    TLabel *Label24;
    TLabel *Label25;
    TLabel *m_pendsignal;
    TLabel *m_nendsignal;
    TLabel *m_pslowsignal;
    TLabel *m_nslowsignal;
    TLabel *m_alarmsignal;
    TLabel *m_inpossignal;
    TLabel *Label84;
    TLabel *Label85;
    TGroupBox *GroupBox6;
    TGroupBox *GroupBox8;
    TLabel *LedIn1;
    TLabel *LedIn2;
    TLabel *LedIn3;
    TLabel *LedOut0;
    TLabel *LedOut1;
    TLabel *LedOut2;
    TLabel *LedOut3;
    TLabel *LedIn4;
    TLabel *LedOut4;
    TLabel *LedIn5;
    TLabel *LedOut5;
    TGroupBox *GroupBox9;
    TGroupBox *GroupBox10;
    TButton *btnMPGOn;
    TButton *btnMPGOff;
    TGroupBox *GroupBox11;
    TButton *btnCRCOn;
    TButton *btnCRCOff;
    TComboBox *cboAxisSet;
    TEdit *edtMoveUnit;
    TGroupBox *GroupBox17;
    TLabel *Label108;
    TButton *btnIntMessage;
    TButton *btnIntEvent;
    TButton *edtIntCallBack;
    TEdit *edtIntCount;
    TGroupBox *GroupBox18;
    TComboBox *cboDetect;
    TComboBox *cboDirection;
    TComboBox *cboStopM;
        TGroupBox *m_grLevel;
    TGroupBox *GroupBox12;
    TEdit *edtUnit;
    TComboBox *cboPulseOutM;
    TEdit *edtCmdPosY;
    TEdit *edtActPosY;
    TEdit *edtCmdVelY;
    TButton *btnCountClr;
    TEdit *edtPulse;
    TEdit *edtCmdPosZ;
    TEdit *edtCmdPosU;
    TEdit *edtActPosU;
    TEdit *edtActPosZ;
    TEdit *edtCmdVelZ;
    TEdit *edtCmdVelU;
    TLabel *Label5;
    TLabel *Label6;
    TCheckBox *chkPElmLevel;
    TCheckBox *chkNElmLevel;
    TCheckBox *chkInpLevel;
    TCheckBox *chkAlarmLevel;
    TCheckBox *chkHomeLevel;
    TCheckBox *chkZPhaseLevel;
    TCheckBox *chkEmgLevel;
    TEdit *edtStartSpeed;
    TButton *btnSetting;
    TComboBox *cboEncInputM;
    TEdit *edtCmdPosX;
    TEdit *edtActPosX;
    TEdit *edtCmdVelX;
    TButton *btnJogPX;
    TButton *btnJogPY;
    TButton *btnJogPZ;
    TButton *btnJogPU;
    TButton *btnJogNX;
    TButton *btnJogNY;
    TButton *btnJogNZ;
    TButton *btnJogNU;
    TGroupBox *GroupBox3;
    TGroupBox *GroupBox4;
    TEdit *edtXCen;
    TEdit *edtYCen;
    TEdit *edtAngle;
    TButton *btnLinear;
    TButton *btnCircular;
    TCheckBox *chkCwCcw;
    TCheckBox *chkGantrySlave;
    TGroupBox *GroupBox7;
    TCheckBox *chkAbsolute;
    TCheckBox *chkAsym;
    TCheckBox *chkSCurve;
    TCheckBox *chkXYSyn;
    TEdit *edtPosition;
    TButton *btnMove;
    TEdit *edtVelocity;
    TButton *btnRepeat;
    TEdit *edtAccel;
    TButton *btnStop;
    TEdit *edtDecel;
    TButton *btnEStop;
    TButton *btnManualSet;
    TButton *btnLoad;
    TButton *btnStatus;
    TButton *btnSave;
    TButton *btnSearch;
    TButton *btnIntDisable;
    TGroupBox *GroupBox1;
    TButton *btnContiSpline;
    TGroupBox *GroupBox13;
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TLabel *Label4;
    TEdit *edtContiNum;
    TEdit *edtTotalNum;
    TEdit *edtQFree;
    TEdit *edtInMotion;
    TButton *btnContiBlend;
    TButton *btnContiCircle;
    TButton *btnContiLine;
    TButton *btnContiTest;
    TButton *btnContiStart;
    TButton *btnContiClear;
    TEdit *edtGearRatio;
    TGroupBox *Trigger;
    TGroupBox *GroupBox16;
    TGroupBox *GroupBox19;
    TEdit *edtTrigStartPosition;
    TEdit *edtTrigCycle;
    TEdit *edtTrigPulseWidth;
    TEdit *edtTrigEndPos;
    TButton *btnTrigAbs;
    TButton *btnTrigOneShot;
    TButton *btnTrigReset;
    TButton *btnTridPeriod;
    TButton *btnSigCapture;
    TButton *btnVelOverride;
    TEdit *edtHomeVelFirst;
    TEdit *edtHomeVelSecond;
    TEdit *edtHomeVelThird;
    TEdit *edtHomeVelLast;
    TComboBox *cboHomeSignal;
    TButton *btnHomeAll;
    TButton *btnHomeSingle;
    TGroupBox *GroupBox20;
    TEdit *edtCapturePos;
    TCheckBox *chkGearOnOff;
    TListBox *lstLog;
    TButton *btn3DGraph;
    TLabel *LedPElm;
    TLabel *LedNElm;
    TLabel *LedInp;
    TLabel *LedAlarm;
    TLabel *LedHome;
    TLabel *LedZPhase;
    TLabel *LedEmg;
    TLabel *LedIn0;
    TChart *XYPlot;
    TPointSeries *Series5;
    TCheckBox *chkRelative;
    TCheckBox *chkGantry;
    TStaticText *StaticText1;
    TStaticText *StaticText2;
    TStaticText *StaticText3;
    TStaticText *StaticText4;
    TStaticText *StaticText5;
    TStaticText *StaticText6;
    TStaticText *StaticText7;
    TStaticText *Org;
    TStaticText *Zph;
    TStaticText *StaticText10;
    TStaticText *StaticText11;
    TStaticText *StaticText12;
    TStaticText *StaticText13;
    TStaticText *StaticText14;
    TStaticText *StaticText15;
    TStaticText *StaticText16;
    TStaticText *StaticText17;
    TStaticText *StaticText18;
    TStaticText *StaticText19;
    TStaticText *StaticText8;
    TStaticText *StaticText9;
    TStaticText *StaticText20;
    TStaticText *StaticText21;
    TStaticText *StaticText22;
    TStaticText *StaticText23;
    TStaticText *StaticText24;
    TStaticText *StaticText25;
    TStaticText *StaticText26;
    TStaticText *StaticText27;
    TStaticText *StaticText28;
    TStaticText *StaticText29;
    TStaticText *StaticText30;
    TStaticText *StaticText31;
    TStaticText *StaticText32;
    TStaticText *StaticText33;
    TStaticText *StaticText34;
    TStaticText *StaticText35;
    TStaticText *StaticText36;
    TStaticText *StaticText37;
    TStaticText *StaticText38;
    TStaticText *StaticText39;
    TStaticText *StaticText40;
    TStaticText *StaticText41;
    TStaticText *StaticText42;
    TStaticText *StaticText43;
    TStaticText *StaticText44;
    TStaticText *StaticText45;
    TStaticText *StaticText46;
    TStaticText *StaticText47;
    TStaticText *StaticText48;
    TStaticText *StaticText49;
    TStaticText *StaticText50;
    TStaticText *StaticText51;
    TStaticText *StaticText52;
    TStaticText *StaticText53;
    TStaticText *StaticText54;
    TStaticText *StaticText55;
    TStaticText *StaticText56;
    TStaticText *StaticText57;
    TStaticText *StaticText58;
    TStaticText *StaticText59;
    TStaticText *StaticText63;
    TStaticText *StaticText62;
    TStaticText *StaticText61;
    TStaticText *StaticText60;
    TTrackBar *trkXYRange;
    TTrackBar *trkXYRange2;
    TComboBox *cboHomeDir;
    TButton *btnReadCapture;
    TChart *GraphX;
    TFastLineSeries *Series1;
    TFastLineSeries *Series2;
    TChart *GraphY;
    TFastLineSeries *Series3;
    TFastLineSeries *Series4;
    TTimer *tmDisplay;
    TTimer *tmGraph;
    TTimer *tmHome1;
    TTimer *tmHome2;
    TTimer *tmHome3;
    TTimer *tmHome4;
    TSaveDialog *SaveDlg;
    TOpenDialog *OpenDlg;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall cboAxisSetChange(TObject *Sender);
    void __fastcall chkPElmLevelClick(TObject *Sender);
    void __fastcall chkNElmLevelClick(TObject *Sender);
    void __fastcall chkAlarmLevelClick(TObject *Sender);
    void __fastcall chkInpLevelClick(TObject *Sender);
    void __fastcall chkZPhaseLevelClick(TObject *Sender);
    void __fastcall btnMPGOnClick(TObject *Sender);
    void __fastcall btnMPGOffClick(TObject *Sender);
    void __fastcall cboPulseOutMChange(TObject *Sender);
    void __fastcall btnSettingClick(TObject *Sender);
    void __fastcall cboEncInputMChange(TObject *Sender);
    void __fastcall btnCountClrClick(TObject *Sender);
    void __fastcall btnMoveClick(TObject *Sender);
    void __fastcall btnStopClick(TObject *Sender);
    void __fastcall chkAsymClick(TObject *Sender);
    void __fastcall chkSCurveClick(TObject *Sender);
    void __fastcall btnSearchClick(TObject *Sender);
    void __fastcall btnHomeAllClick(TObject *Sender);
    void __fastcall btnHomeSingleClick(TObject *Sender);
    void __fastcall btnContiSplineClick(TObject *Sender);
    void __fastcall btnContiTestClick(TObject *Sender);
    void __fastcall btnContiClearClick(TObject *Sender);
    void __fastcall chkGearOnOffClick(TObject *Sender);
    void __fastcall btnTrigAbsClick(TObject *Sender);
    void __fastcall btnTrigOneShotClick(TObject *Sender);
    void __fastcall btnTridPeriodClick(TObject *Sender);
    void __fastcall btnTrigResetClick(TObject *Sender);
    void __fastcall btnSigCaptureClick(TObject *Sender);
    void __fastcall btnVelOverrideClick(TObject *Sender);
    void __fastcall btnIntMessageClick(TObject *Sender);
    void __fastcall edtIntCallBackClick(TObject *Sender);
    void __fastcall btnIntDisableClick(TObject *Sender);
    void __fastcall tmDisplayTimer(TObject *Sender);
    void __fastcall tmGraphTimer(TObject *Sender);
    void __fastcall tmHomeTimer(TObject *Sender);
    void __fastcall btnCRCOnClick(TObject *Sender);
    void __fastcall btnCRCOffClick(TObject *Sender);
    void __fastcall chkEmgLevelClick(TObject *Sender);
    void __fastcall chkHomeLevelClick(TObject *Sender);
    void __fastcall btnJogMouseDown(TObject *Sender, TMouseButton Button,
          TShiftState Shift, int X, int Y);
    void __fastcall btnJogMouseUp(TObject *Sender, TMouseButton Button,
          TShiftState Shift, int X, int Y);

    //ReapeatÇÔ¼ö
    void __fastcall btnRepeatClick(TObject *Sender);
    void __fastcall btn3DGraphClick(TObject *Sender);
    void __fastcall btnStatusClick(TObject *Sender);
    void __fastcall btnManualSetClick(TObject *Sender);
    void __fastcall chkGantryClick(TObject *Sender);
    void __fastcall btnContiBlendClick(TObject *Sender);
    void __fastcall btnContiCircleClick(TObject *Sender);
    void __fastcall btnContiLineClick(TObject *Sender);
    void __fastcall btnLinearClick(TObject *Sender);
    void __fastcall btnCircularClick(TObject *Sender);
    void __fastcall chkAbsoluteClick(TObject *Sender);
    void __fastcall chkRelativeClick(TObject *Sender);
    void __fastcall trkXYRangeChange(TObject *Sender);
    void __fastcall btnReadCaptureClick(TObject *Sender);
    void __fastcall LedOut0Click(TObject *Sender);
    void __fastcall LedOut1Click(TObject *Sender);
    void __fastcall LedOut2Click(TObject *Sender);
    void __fastcall LedOut3Click(TObject *Sender);
    void __fastcall LedOut4Click(TObject *Sender);
    void __fastcall LedOut5Click(TObject *Sender);
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall btnEStopClick(TObject *Sender);
    void __fastcall btnContiStartClick(TObject *Sender);
    void __fastcall btnIntEventClick(TObject *Sender);
    void __fastcall btnLoadClick(TObject *Sender);
    void __fastcall btnSaveClick(TObject *Sender);
    void __fastcall lstLogDblClick(TObject *Sender);
        void __fastcall chkGantrySlaveClick(TObject *Sender);
 private:	// User declarations

protected:
   BEGIN_MESSAGE_MAP
      VCL_MESSAGE_HANDLER(WM_AXL_INTERRUPT, TMessage, OnControlMessage)
   END_MESSAGE_MAP(TForm)

public:		    // User declarations
    INT16       count1, count2;

    BOOL        m_bA4NAxis;

    long        m_lAxis;
    long        m_lRange;
    long        m_lAxisCounts;
    
    long        detectsignal;
    BOOL        RepeatFlag, Stop, EStop, TestActive1, TestActive2;

    HANDLE      m_hInterrupt[MAX_AXIS_COUNT];
    HANDLE      m_hHandle[MAX_AXIS_COUNT];
    BOOL        m_bThread[MAX_AXIS_COUNT];

    BOOL	m_bTestActive[MAX_AXIS_COUNT];
    HANDLE	m_hTestThread[MAX_AXIS_COUNT];

public:
    bool    InitLibrary(void);
    bool    InitControl(void);
    void    UpdateAxisInfo(void);
    void    SetTitleBar(long lAxis);
    bool    SetGraphRange(long lAxis, double dVelocity);
    void    SetCoordMovePara();
    BOOL    ThreadData();

    void    OnControlMessage(TMessage Msg);
    __fastcall TfrmCamcQI(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmCamcQI *frmCamcQI;
//---------------------------------------------------------------------------
#endif
