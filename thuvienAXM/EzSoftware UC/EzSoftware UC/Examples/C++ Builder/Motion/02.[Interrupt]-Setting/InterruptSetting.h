//---------------------------------------------------------------------------

#ifndef InterruptSettingH
#define InterruptSettingH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------

#include "AXL.h"
#include "AXM.h"

// 인터럽트 이벤트 종류 정의
enum{	INT_MESSAGE, INT_CALLBACK, INT_EVENT };

class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TComboBox *cboSelAxis;
        TGroupBox *grpBank1;
        TShape *Shape1;
        TCheckBox *chkBank1Bit00;
        TCheckBox *chkBank1Bit01;
        TCheckBox *chkBank1Bit02;
        TCheckBox *chkBank1Bit31;
        TButton *btnSetBank1;
        TGroupBox *grpBank2;
        TShape *Shape2;
        TCheckBox *chkBank2Bit14;
        TCheckBox *chkBank2Bit15;
        TCheckBox *chkBank2Bit16;
        TCheckBox *chkBank2Bit20;
        TButton *btnSetBank2;
        TCheckBox *chkBank2Bit21;
        TCheckBox *chkBank2Bit22;
        TGroupBox *GroupBox5;
        TRadioButton *rdoMessage;
        TRadioButton *rdoCallback;
        TRadioButton *rdoEvent;
        TCheckBox *chkIntEnable;
        TListBox *lstIntLog;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnSetBank1Click(TObject *Sender);
        void __fastcall btnSetBank2Click(TObject *Sender);
        void __fastcall chkIntEnableClick(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall lstIntLogDblClick(TObject *Sender);
private:	// User declarations

protected:
   BEGIN_MESSAGE_MAP
      VCL_MESSAGE_HANDLER(WM_AXL_INTERRUPT, TMessage, OnControlMessage)
   END_MESSAGE_MAP(TForm)

public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();		        // 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();                     // Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();			// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();			// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
        BOOL ThreadData();
        void OnControlMessage(TMessage Msg);

	DWORD ConvertComboToAxm(TComboBox *pCboItem);			// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.

        long m_lAxisNo;	     // 제어할 축 번호
	long m_lAxisCount;   // 유효한 전체 모션축수
	DWORD m_dwModuleID;  // 선택한 축의 모델ID
        long m_lIntCount;    // 인터럽트 발생 갯수
        HANDLE m_hHandle[64];
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
