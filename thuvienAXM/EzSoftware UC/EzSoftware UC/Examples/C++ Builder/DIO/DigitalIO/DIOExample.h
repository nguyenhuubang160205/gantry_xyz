//---------------------------------------------------------------------------

#ifndef DIOExampleH
#define DIOExampleH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>

#include "AXL.h"
#include "AXD.h"

#define IO_SU   32
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TComboBox *m_cbModule;
        TRadioGroup *RadioGroup1;
        TRadioButton *m_rdoMessage;
        TRadioButton *m_rdoCallback;
        TRadioButton *m_rdoEvent;
        TGroupBox *m_stcHIGH;
        TCheckBox *m_chkHigh00;
        TCheckBox *m_chkHigh01;
        TCheckBox *m_chkHigh02;
        TCheckBox *m_chkHigh03;
        TCheckBox *m_chkHigh04;
        TCheckBox *m_chkHigh05;
        TCheckBox *m_chkHigh06;
        TCheckBox *m_chkHigh07;
        TCheckBox *m_chkHigh08;
        TCheckBox *m_chkHigh09;
        TCheckBox *m_chkHigh15;
        TCheckBox *m_chkHigh14;
        TCheckBox *m_chkHigh13;
        TCheckBox *m_chkHigh12;
        TCheckBox *m_chkHigh11;
        TCheckBox *m_chkHigh10;
        TGroupBox *m_stcLOW;
        TCheckBox *m_chkLow10;
        TCheckBox *m_chkLow08;
        TCheckBox *m_chkLow07;
        TCheckBox *m_chkLow06;
        TCheckBox *m_chkLow05;
        TCheckBox *m_chkLow04;
        TCheckBox *m_chkLow03;
        TCheckBox *m_chkLow02;
        TCheckBox *m_chkLow01;
        TCheckBox *m_chkLow15;
        TCheckBox *m_chkLow14;
        TCheckBox *m_chkLow13;
        TCheckBox *m_chkLow12;
        TCheckBox *m_chkLow11;
        TCheckBox *m_chkLow09;
        TCheckBox *m_chkLow00;
        TButton *m_btnClear;
        TButton *m_btnClose;
        TTimer *Timer1;
        TListBox *m_lstInterrupt;
    TCheckBox *m_chkRising;
    TCheckBox *m_chkFalling;
        TCheckBox *m_chkInterrupt;

        void __fastcall m_chkHighClick(TObject *Sender);
        void __fastcall m_chkLowClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall m_cbModuleChange(TObject *Sender);
        void __fastcall m_btnCloseClick(TObject *Sender);
        void __fastcall Timer1Timer(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall m_btnClearClick(TObject *Sender);
        void __fastcall m_chkInterruptClick(TObject *Sender);
        void __fastcall m_chkRisingClick(TObject *Sender);
        void __fastcall m_chkFallingClick(TObject *Sender);
        void __fastcall m_rdoMessageClick(TObject *Sender);
        void __fastcall m_rdoCallbackClick(TObject *Sender);
        void __fastcall m_rdoEventClick(TObject *Sender);
        
     

public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL	        OpenDevice();
	BOOL	        ThreadData();
        void            OnInterruptMessage(TMessage Msg);

        HANDLE		m_hHandle;
	HANDLE		m_hInterrupt;
	BOOL		m_bThread;

        TCheckBox   **m_in;
        TCheckBox   **m_out;

protected:
   BEGIN_MESSAGE_MAP
      VCL_MESSAGE_HANDLER(WM_AXL_INTERRUPT, TMessage, OnInterruptMessage)
   END_MESSAGE_MAP(TForm)
};

void _stdcall InterruptCallback(long lActiveNo, DWORD bwFlag);

//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
