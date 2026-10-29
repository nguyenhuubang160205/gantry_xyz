//---------------------------------------------------------------------------

#ifndef SignalMonitorH
#define SignalMonitorH
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
        TGroupBox *GroupBox2;
        TShape *Shape1;
        TComboBox *cboZPhase;
        TComboBox *cboAlarm;
        TComboBox *cboELimitN;
        TCheckBox *chkZPhase;
        TComboBox *cboInp;
        TCheckBox *chkAlarm;
        TCheckBox *chkELimitN;
        TCheckBox *chkInp;
        TComboBox *cboEmg;
        TComboBox *cboELimitP;
        TCheckBox *chkEmg;
        TCheckBox *chkELimitP;
        TGroupBox *GroupBox3;
        TShape *Shape2;
        TLabel *Label2;
        TLabel *Label3;
        TComboBox *cboServoOn;
        TComboBox *cboAlarmReset;
        TGroupBox *GroupBox4;
        TShape *Shape3;
        TCheckBox *chkInp00;
        TCheckBox *chkInp01;
        TCheckBox *chkInp02;
        TCheckBox *chkInp03;
        TCheckBox *chkInp04;
        TCheckBox *chkOut00;
        TCheckBox *chkOut01;
        TCheckBox *chkOut02;
        TCheckBox *chkOut03;
        TCheckBox *chkOut04;
        TGroupBox *GroupBox5;
        TShape *Shape4;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TCheckBox *chkSWLimitN;
        TCheckBox *chkSWLimitP;
        TComboBox *cboSWStop;
        TComboBox *cboSWRef;
        TEdit *edtSWPosN;
        TEdit *edtSWPosP;
        TCheckBox *chkSWEnable;
        TOpenDialog *OpenDialog1;
        TTimer *m_timer;
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnLoadFileClick(TObject *Sender);
        void __fastcall chkOut00Click(TObject *Sender);
        void __fastcall chkOut01Click(TObject *Sender);
        void __fastcall chkOut02Click(TObject *Sender);
        void __fastcall chkOut03Click(TObject *Sender);
        void __fastcall chkOut04Click(TObject *Sender);
        void __fastcall cboZPhaseChange(TObject *Sender);
        void __fastcall cboAlarmChange(TObject *Sender);
        void __fastcall cboInpChange(TObject *Sender);
        void __fastcall cboEmgChange(TObject *Sender);
        void __fastcall cboELimitNChange(TObject *Sender);
        void __fastcall cboELimitPChange(TObject *Sender);
        void __fastcall cboServoOnChange(TObject *Sender);
        void __fastcall cboAlarmResetChange(TObject *Sender);
        void __fastcall chkSWEnableClick(TObject *Sender);
        void __fastcall m_timerTimer(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();		        // 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();                     // Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();			// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();			// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
        DWORD ConvertComboToAxm(TComboBox *pCboItem);			// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.
        void chkOut_Changed(DWORD lBitNo, TCheckBox *chkInpX, TCheckBox *chkOutX);								      

        long m_lAxisNo;	     // 제어할 축 번호
	long m_lAxisCount;   // 유효한 전체 모션축수
	DWORD m_dwModuleID;  // 선택한 축의 모델ID
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
