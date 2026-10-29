//---------------------------------------------------------------------------

#ifndef GantryMotionH
#define GantryMotionH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------

#define GANTYR_SLAVE_HM_DONE	0
#define GANTYR_SLAVE_HM_BOTH	1
#define GANTYR_SLAVE_HM_EACH	2

class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TComboBox *cboSelAxis;
        TButton *btnLoadFile;
        TGroupBox *GroupBox2;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TLabel *stcAxisNoMa;
        TLabel *stcAxisNoSl;
        TLabel *stcGantryState;
        TEdit *stcCmdPosMa;
        TButton *btnPosClear;
        TCheckBox *chkServoOn;
        TEdit *stcCmdPosSL;
        TEdit *stcActPosMa;
        TEdit *stcActPosSL;
        TEdit *stcCmdVelMa;
        TEdit *stcCmdVelSL;
        TCheckBox *chkHomeStateMa;
        TCheckBox *chkHomeStateSL;
        TGroupBox *GroupBox3;
        TLabel *Label2;
        TLabel *Label4;
        TLabel *Label15;
        TLabel *Label12;
        TEdit *edtMovePos;
        TEdit *edtMoveVel;
        TEdit *edtMoveAcc;
        TRadioButton *rdoAbs;
        TRadioButton *rdoRel;
        TButton *btnMovePos;
        TButton *btnMoveStop;
        TEdit *edtMoveDec;
        TButton *btnJogMoveP;
        TButton *btnJogMoveN;
        TGroupBox *GroupBox5;
        TLabel *Label19;
        TLabel *Label20;
        TShape *Shape2;
        TShape *Shape1;
        TLabel *Label13;
        TEdit *edtGantryHmOffset;
        TEdit *edtGantryHmRange;
        TCheckBox *chkGantryEnable;
        TComboBox *cboGantryHmSlaveUse;
        TGroupBox *GroupBox4;
        TLabel *Label5;
        TLabel *Label7;
        TButton *btnHomeStart;
        TButton *btnHomeStop;
        TEdit *stcHomeResult;
        TEdit *stcHomeStepMain;
        TEdit *stcHomeStepSub;
        TProgressBar *prgHomeRate;
        TOpenDialog *OpenDialog1;
        TTimer *m_timerDisplay;
        TTimer *m_timerHomeInfo;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnLoadFileClick(TObject *Sender);
        void __fastcall btnPosClearClick(TObject *Sender);
        void __fastcall chkServoOnClick(TObject *Sender);
        void __fastcall rdoAbsClick(TObject *Sender);
        void __fastcall rdoRelClick(TObject *Sender);
        void __fastcall btnMovePosClick(TObject *Sender);
        void __fastcall btnJogMovePMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogMoveNMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogMovePMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogMoveNMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnMoveStopClick(TObject *Sender);
        void __fastcall btnHomeStartClick(TObject *Sender);
        void __fastcall btnHomeStopClick(TObject *Sender);
        void __fastcall chkGantryEnableClick(TObject *Sender);
        void __fastcall m_timerDisplayTimer(TObject *Sender);
        void __fastcall m_timerHomeInfoTimer(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();		        // 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();                     // Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();			// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();			// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
        DWORD ConvertComboToAxm(TComboBox *pCboItem);			// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.
        String TranslateHomeResult(DWORD dwHomeResult);	    // 원점검색 결과값을 문자열로 변환해주는 함수.

        long		m_lAxisNo;	  	// 제어할 축 번호
        long		m_lAxisNoMa;	  	// 제어할 축 번호
        long		m_lAxisNoSl;	  	// 제어할 축 번호
	long		m_lAxisCount;	        // 유효한 전체 모션축수
	DWORD		m_dwModuleID;		// 선택한 축의 모델ID
        double		m_dOldCmdPosMa;		// OnTimer에서 사용할 이전 Command Position
	double		m_dOldActPosMa;		// OnTimer에서 사용할 이전 Actual Position
	double		m_dOldCmdVelMa;		// OnTimer에서 사용할 이전 Command Velocity
        double		m_dOldCmdPosSl;		// OnTimer에서 사용할 이전 Command Position
	double		m_dOldActPosSl;		// OnTimer에서 사용할 이전 Actual Position
	double		m_dOldCmdVelSl;		// OnTimer에서 사용할 이전 Command Velocity
	DWORD		m_dwOldResult;		// OnTimer에서 사용할 원점검색 결과 이전값
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
