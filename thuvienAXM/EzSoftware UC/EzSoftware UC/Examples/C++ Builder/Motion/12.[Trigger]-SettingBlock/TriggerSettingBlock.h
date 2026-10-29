//---------------------------------------------------------------------------

#ifndef TriggerSettingBlockH
#define TriggerSettingBlockH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>

#include "AXL.h"
#include "AXM.h"
//---------------------------------------------------------------------------
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
        TLabel *Label11;
        TLabel *Label12;
        TLabel *Label13;
        TEdit *stcCmdPos;
        TEdit *stcActPos;
        TEdit *stcCmdVel;
        TButton *btnPosSet;
        TCheckBox *chkServoOn;
        TEdit *edtSetPos;
        TGroupBox *GroupBox3;
        TLabel *Label2;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label7;
        TLabel *Label15;
        TLabel *Label16;
        TEdit *edtMovePos;
        TEdit *edtMoveVel;
        TEdit *edtMoveAcc;
        TRadioButton *rdoAbs;
        TRadioButton *rdoRel;
        TButton *btnMove;
        TButton *btnMoveStop;
        TGroupBox *GroupBox4;
        TShape *Shape6;
        TLabel *Label3;
        TLabel *Label6;
        TLabel *Label14;
        TLabel *Label17;
        TLabel *Label18;
        TShape *Shape1;
        TEdit *edtTrigTime;
        TComboBox *cboTrigLevel;
        TComboBox *cboTrigTarget;
        TEdit *stcIntCount;
        TComboBox *cboIntUse;
        TButton *btnSetMethod;
        TGroupBox *GroupBox5;
        TLabel *Label19;
        TLabel *Label20;
        TLabel *Label21;
        TLabel *Label22;
        TLabel *Label23;
        TLabel *Label24;
        TShape *Shape2;
        TEdit *edtTrigStartPos;
        TEdit *edtTrigEndPos;
        TEdit *edtTrigPeriod;
        TCheckBox *chkSetBlock;
        TOpenDialog *OpenDialog1;
        TTimer *m_timer;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnLoadFileClick(TObject *Sender);
        void __fastcall btnPosSetClick(TObject *Sender);
        void __fastcall chkServoOnClick(TObject *Sender);
        void __fastcall rdoAbsClick(TObject *Sender);
        void __fastcall rdoRelClick(TObject *Sender);
        void __fastcall btnMoveClick(TObject *Sender);
        void __fastcall btnMoveStopClick(TObject *Sender);
        void __fastcall btnSetMethodClick(TObject *Sender);
        void __fastcall chkSetBlockClick(TObject *Sender);
        void __fastcall m_timerTimer(TObject *Sender);
private:	// User declarations

protected:
   BEGIN_MESSAGE_MAP
      VCL_MESSAGE_HANDLER(WM_AXL_INTERRUPT, TMessage, OnAxmIntMessage)
   END_MESSAGE_MAP(TForm)

public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();		        // 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();                     // Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();			// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();			// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
        DWORD ConvertComboToAxm(TComboBox *pCboItem);			// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.
        void OnAxmIntMessage(TMessage Msg);

        long		m_lAxisNo;	  	// 제어할 축 번호
	long		m_lAxisCount;	        // 유효한 전체 모션축수
	DWORD		m_dwModuleID;		// 선택한 축의 모델ID
        double		m_dOldCmdPos;		// OnTimer에서 사용할 이전 Command Position
	double		m_dOldActPos;		// OnTimer에서 사용할 이전 Actual Position
	double		m_dOldCmdVel;		// OnTimer에서 사용할 이전 Command Velocity
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
