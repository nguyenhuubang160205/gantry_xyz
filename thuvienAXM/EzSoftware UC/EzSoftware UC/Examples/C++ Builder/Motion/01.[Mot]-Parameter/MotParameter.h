//---------------------------------------------------------------------------

#ifndef MotParameterH
#define MotParameterH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TComboBox *cboSelAxis;
        TButton *btnLoadFile;
        TButton *btnSaveFile;
        TGroupBox *GroupBox2;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TShape *Shape1;
        TComboBox *cboPulse;
        TComboBox *cboEncoder;
        TComboBox *cboAbsRel;
        TComboBox *cboProfile;
        TEdit *edtMinVel;
        TEdit *edtMaxVel;
        TEdit *edtMovePulse;
        TEdit *edtMoveUnit;
        TButton *btnApplyPulse;
        TGroupBox *GroupBox3;
        TLabel *Label10;
        TLabel *Label11;
        TLabel *Label12;
        TLabel *Label13;
        TLabel *Label14;
        TLabel *Label15;
        TLabel *Label16;
        TLabel *Label17;
        TShape *Shape2;
        TLabel *Label18;
        TLabel *Label19;
        TComboBox *cboInp;
        TCheckBox *chkInp;
        TCheckBox *chkAlarm;
        TComboBox *cboAlarm;
        TCheckBox *chkELimitP;
        TComboBox *cboELimitP;
        TCheckBox *chkELimitN;
        TComboBox *cboELimitN;
        TComboBox *cboServoOn;
        TCheckBox *chkZPhase;
        TComboBox *cboZPhaseLev;
        TComboBox *cboStopMode;
        TComboBox *cboStopLevel;
        TComboBox *cboAlarmReset;
        TComboBox *cboEncoderType;
        TCheckBox *chkEmg;
        TButton *btnApplySignal;
        TGroupBox *GroupBox4;
        TLabel *Label20;
        TLabel *Label21;
        TLabel *Label22;
        TLabel *Label23;
        TLabel *Label24;
        TShape *Shape3;
        TLabel *Label28;
        TLabel *Label30;
        TLabel *Label25;
        TLabel *Label26;
        TLabel *Label27;
        TLabel *Label29;
        TLabel *Label31;
        TShape *Shape4;
        TShape *Shape5;
        TComboBox *cboHomeSignal;
        TComboBox *cboHomeLevel;
        TComboBox *cboHomeDir;
        TComboBox *cboZPhaseUse;
        TEdit *edtVelFirst;
        TEdit *edtVelSecond;
        TEdit *edtVelThird;
        TEdit *edtVelLast;
        TEdit *edtAccFirst;
        TEdit *edtAccSecond;
        TEdit *edtHomeClrTime;
        TEdit *edtHomeOffset;
        TButton *btnApplyHome;
        TGroupBox *GroupBox5;
        TLabel *Label32;
        TLabel *Label33;
        TLabel *Label34;
        TLabel *Label37;
        TLabel *Label38;
        TShape *Shape6;
        TComboBox *cboSLimitEnable;
        TComboBox *cboSLimitSelect;
        TEdit *edtSLimitPosP;
        TEdit *edtSLimitPosN;
        TComboBox *cboSLimitStopMode;
        TButton *btnApplySoftLimit;
        TGroupBox *GroupBox6;
        TLabel *Label35;
        TLabel *Label36;
        TLabel *Label40;
        TShape *Shape7;
        TLabel *Label39;
        TEdit *edtDecel;
        TEdit *edtVelocity;
        TEdit *edtAccel;
        TEdit *edtPosition;
        TButton *btnApplyUserPara;
        TButton *btnApplyAllAxes;
        TOpenDialog *OpenDialog1;
        TSaveDialog *SaveDialog1;
        TTimer *m_timer;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnLoadFileClick(TObject *Sender);
        void __fastcall btnSaveFileClick(TObject *Sender);
        void __fastcall btnApplyPulseClick(TObject *Sender);
        void __fastcall btnApplySignalClick(TObject *Sender);
        void __fastcall btnApplyHomeClick(TObject *Sender);
        void __fastcall btnApplySoftLimitClick(TObject *Sender);
        void __fastcall btnApplyUserParaClick(TObject *Sender);
        void __fastcall btnApplyAllAxesClick(TObject *Sender);
        void __fastcall m_timerTimer(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();				// 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();				// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();				// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();				// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.

	DWORD ConvertComboToAxm(TComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.									// 지정한 콘트롤에 설정되어 있는 텍스트를 double값으로 변환하여 반환하는 함수.

        long m_lAxisNo;	     // 제어할 축 번호
	long m_lAxisCount;   // 유효한 전체 모션축수
	DWORD m_dwModuleID;  // 선택한 축의 모델ID
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
