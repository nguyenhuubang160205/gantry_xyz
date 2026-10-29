//---------------------------------------------------------------------------

#ifndef AIExampleH
#define AIExampleH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>

#include "AXL.h"
#include "AXA.h"
#include <ExtCtrls.hpp>

//---------------------------------------------------------------------------
class TFormAnalogInput : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TComboBox *m_cbModulenum;
        TLabel *Label2;
        TLabel *Label3;
        TCheckBox *m_chkChannel1;
        TCheckBox *m_chkChannel2;
        TCheckBox *m_chkChannel3;
        TCheckBox *m_chkChannel4;
        TComboBox *m_cbVoltagerange1;
        TComboBox *m_cbVoltagerange2;
        TComboBox *m_cbVoltagerange3;
        TComboBox *m_cbVoltagerange4;
        TButton *Button1;
        TButton *m_btnStart;
        TStringGrid *m_lstAIData;
        TLabel *Label4;
        TLabel *Label5;
        TCheckBox *m_chkChannel5;
        TCheckBox *m_chkChannel6;
        TCheckBox *m_chkChannel7;
        TCheckBox *m_chkChannel8;
        TComboBox *m_cbVoltagerange5;
        TComboBox *m_cbVoltagerange6;
        TComboBox *m_cbVoltagerange7;
        TComboBox *m_cbVoltagerange8;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall m_btnStartClick(TObject *Sender);
private:	// User declarations
        TCheckBox       *m_AICH[8];
        TComboBox       *m_AIVoltRange[8];
        TLabel          *m_AIModuleNum[4];
        TLabel          *m_AIModuleID[4];


        long            m_lAIModuleNum[10];
        long            m_lAICount;
        bool            m_bStart;

        void            InitControl();
        void            InitDeviceInformation();

public:		// User declarations
        __fastcall TFormAnalogInput(TComponent* Owner);

        BOOL	        ThreadData();
        bool		    m_bThread;
};

void __stdcall TestEventProc(long lChannelNo, DWORD dwStatus);

//---------------------------------------------------------------------------
extern PACKAGE TFormAnalogInput *FormAnalogInput;
//---------------------------------------------------------------------------
#endif
