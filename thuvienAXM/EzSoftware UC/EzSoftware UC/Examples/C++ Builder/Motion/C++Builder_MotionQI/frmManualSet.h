//---------------------------------------------------------------------------

#ifndef Unit4H
#define Unit4H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TfrmManualSet : public TForm
{
__published:	// IDE-managed Components
    TButton *btnCmd;
    TButton *btnRd;
    TButton *btnWr;
    TEdit *edtCmd;
    TEdit *edtData;
    TComboBox *cboPort;
    TCheckBox *chkHex;
    TComboBox *cboAxisSel;
    TCheckBox *chkOnOff1;
    TCheckBox *chkOnOff2;
    TCheckBox *chkOnOff3;
    TEdit *edtCmd1;
    TEdit *edtCmd2;
    TEdit *edtCmd3;
    TEdit *edtData1;
    TEdit *edtData2;
    TEdit *edtData3;
    TCheckBox *chkOnOff4;
    TCheckBox *chkOnOff5;
    TCheckBox *chkOnOff6;
    TEdit *edtCmd4;
    TEdit *edtCmd5;
    TEdit *edtCmd6;
    TEdit *edtData4;
    TEdit *edtData5;
    TEdit *edtData6;
    TTimer *tmMonitor;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall btnCmdClick(TObject *Sender);
    void __fastcall btnRdClick(TObject *Sender);
    void __fastcall btnWrClick(TObject *Sender);
    void __fastcall tmMonitorTimer(TObject *Sender);
    void __fastcall cboAxisSelClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	long	m_lAxisCount;
	long	m_lAxisNo;
    
public:
	void	UpdateAxis(long lAxis);

    __fastcall TfrmManualSet(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmManualSet *frmManualSet;
//---------------------------------------------------------------------------
#endif
