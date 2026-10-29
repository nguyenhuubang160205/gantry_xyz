// OutputWriteMultiDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.21
// >> [개요]: 이 예제는 AIO모듈의 다중 채널 출력 기능 사용 방법을 학습하는 예제입니다.
// >> [중요]: 출력 관련 함수들
//     1) AxaoSetMultiRange 함수는 지정 다중 출력 채널에 출력 전압 범위를 설정합니다.
//     2) AxaoWriteMultiVoltage 함수는 지정 다중 출력 채널에 특정 전압 값을 출력합니다.
//     3) AxaoReadVoltage 함수는 지정 단일 출력 채널에 출력하고 있는 전압 값을
//        확인합니다.
// **************************************************************************

//---------------------------------------------------------------------------

#ifndef OutputWriteMultiH
#define OutputWriteMultiH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
// Customize area
public:
	DWORD		m_dwModuleID;			// 모델ID
	long		m_lModuleNo;			// 제어할 모듈 번호
	long		m_lModuleCount;			// 유효한 전체 모듈 수
	long		m_lChannelCount;		// 유효한 전체 채널 수
	double		m_dOldVoltArr[4];		// Timer에서 사용할 이전 Volt
    TEdit *     m_edtSetVoltChArr[4];
    TScrollBar *m_scrSetVoltChArr[4];
    TEdit *     m_stcOutVoltChArr[4];

public:
	BOOL		InitLibrary();			// 라이브러리 초기화 작업을 수행합니다.
	BOOL		InitControl();			// Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL		AddModuleChannelInfo();	// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
	BOOL		UpdateState();			// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.

	DWORD		ConvertComboToAxa(TComboBox *pCboItem);						// ComboBox콘트롤에 현재 선택된 Item Index를 AIO모듈에 설정할 값으로 변경하는 함수.
	long		ConvertAxaToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.

	void		UpdateVoltageRange();

__published:	// IDE-managed Components
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TLabel *Label4;
    TGroupBox *GroupBox1;
    TComboBox *m_cboModule;
    TComboBox *m_cboVoltageRange;
    TEdit *m_edtSetVoltCh00;
    TButton *m_btnSet;
    TScrollBar *m_scrSetVoltCh00;
    TEdit *m_stcOutVoltCh00;
    TEdit *m_edtSetVoltCh01;
    TScrollBar *m_scrSetVoltCh01;
    TEdit *m_stcOutVoltCh01;
    TEdit *m_edtSetVoltCh02;
    TScrollBar *m_scrSetVoltCh02;
    TEdit *m_stcOutVoltCh02;
    TEdit *m_edtSetVoltCh03;
    TScrollBar *m_scrSetVoltCh03;
    TEdit *m_stcOutVoltCh03;
    TTimer *m_timer;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall m_cboModuleChange(TObject *Sender);
    void __fastcall m_cboVoltageRangeChange(TObject *Sender);
    void __fastcall m_btnSetClick(TObject *Sender);
    void __fastcall m_scrSetVoltCh00Scroll(TObject *Sender,
          TScrollCode ScrollCode, int &ScrollPos);
    void __fastcall m_scrSetVoltCh01Scroll(TObject *Sender,
          TScrollCode ScrollCode, int &ScrollPos);
    void __fastcall m_scrSetVoltCh02Scroll(TObject *Sender,
          TScrollCode ScrollCode, int &ScrollPos);
    void __fastcall m_scrSetVoltCh03Scroll(TObject *Sender,
          TScrollCode ScrollCode, int &ScrollPos);
    void __fastcall m_timerTimer(TObject *Sender);
private:	// User declarations
public:		// User declarations
    __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
