//---------------------------------------------------------------------------

#ifndef AOExampleH
#define AOExampleH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <CheckLst.hpp>
#include <ComCtrls.hpp>

#include "AXL.h"
#include "AXA.h"
#include <math.h>
#include <ExtCtrls.hpp>

//---------------------------------------------------------------------------
class TFormAnalogOutput : public TForm
{
__published:	// IDE-managed Components
        TButton *m_btnClose;
        TLabel *Label6;
        TComboBox *m_cbModulenum;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TLabel *Label11;
        TLabel *Label12;
        TLabel *Label13;
        TCheckBox *m_chkChannel0;
        TCheckBox *m_chkChannel1;
        TCheckBox *m_chkChannel2;
        TCheckBox *m_chkChannel3;
        TLabel *m_stcModulenum0;
        TLabel *m_stcModulenum1;
        TLabel *m_stcModulenum2;
        TLabel *m_stcModulenum3;
        TLabel *m_stcModuleid0;
        TLabel *m_stcModuleid1;
        TLabel *m_stcModuleid2;
        TLabel *m_stcModuleid3;
        TComboBox *m_cbWave0;
        TComboBox *m_cbWave1;
        TComboBox *m_cbWave2;
        TComboBox *m_cbWave3;
        TEdit *m_edtPeriod0;
        TEdit *m_edtPeriod1;
        TEdit *m_edtPeriod2;
        TEdit *m_edtPeriod3;
        TComboBox *m_cbVRange0;
        TComboBox *m_cbVRange1;
        TComboBox *m_cbVRange2;
        TComboBox *m_cbVRange3;
        TEdit *m_edtValtage0;
        TEdit *m_edtValtage1;
        TEdit *m_edtValtage2;
        TEdit *m_edtValtage3;
        TLabel *Label1;
        TComboBox *m_cbGap;
        TButton *m_btnStart;
        TTimer *Timer1;
        TUpDown *m_spnVoltage0;
        TUpDown *m_spnVoltage1;
        TUpDown *m_spnVoltage2;
        TUpDown *m_spnVoltage3;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall m_btnCloseClick(TObject *Sender);
        void __fastcall m_btnStartClick(TObject *Sender);
        void __fastcall Timer1Timer(TObject *Sender);
        void __fastcall m_cbModulenumChange(TObject *Sender);
        void __fastcall m_edtValtage0Change(TObject *Sender);
        void __fastcall m_edtValtage1Change(TObject *Sender);
        void __fastcall m_edtValtage2Change(TObject *Sender);
        void __fastcall m_edtValtage3Change(TObject *Sender);
        void __fastcall m_cbVRange0Change(TObject *Sender);
        void __fastcall m_cbVRange1Change(TObject *Sender);
        void __fastcall m_cbVRange2Change(TObject *Sender);
        void __fastcall m_cbVRange3Change(TObject *Sender);
private:	// User declarations
        TCheckBox       *m_AOCH[4];
        TLabel          *m_AOModuleNum[4];
        TLabel          *m_AOModuleID[4];
        TComboBox       *m_AOWave[4];
        TEdit           *m_AOPeriod[4];
        TComboBox       *m_AOVoltRange[4];
        TEdit           *m_AOValtage[4];
        TUpDown         *m_AOValtageUpDown[4];

        long            m_lAOModuleNum[10];
        long            m_lAOIndex[10];
        long            m_lChannelCount;
        long            m_nGap;
        bool            m_bStart;

        void            InitControl();
        void            InitDeviceInformation();

public:		// User declarations
        __fastcall TFormAnalogOutput(TComponent* Owner);

        void            VoltageChange(int ch);
        void            VRangeChange(int ch);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormAnalogOutput *FormAnalogOutput;
//---------------------------------------------------------------------------
#endif
