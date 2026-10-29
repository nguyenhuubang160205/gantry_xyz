//---------------------------------------------------------------------------

#ifndef OutputWriteSingleH
#define OutputWriteSingleH
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
	long		m_lChannelNo;			// 제어할 채널 번호
	long		m_lChannelCount;		// 유효한 전체 채널 수
	double		m_dOldVolt;			    // OnTimer에서 사용할 이전 Volt

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
    TLabel *m_stcValueType;
    TLabel *Label4;
    TLabel *Label5;
    TGroupBox *GroupBox1;
    TComboBox *m_cboModule;
    TGroupBox *GroupBox2;
    TComboBox *m_cboChannel;
    TComboBox *m_cboVoltageRange;
    TEdit *m_edtSettingVoltage;
    TButton *m_btnSet;
    TScrollBar *m_scrSettingVoltage;
    TEdit *m_stcOutputVoltage;
    TTimer *m_timer;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall m_cboModuleChange(TObject *Sender);
    void __fastcall m_cboChannelChange(TObject *Sender);
    void __fastcall m_cboVoltageRangeChange(TObject *Sender);
    void __fastcall m_btnSetClick(TObject *Sender);
    void __fastcall m_scrSettingVoltageScroll(TObject *Sender,
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
