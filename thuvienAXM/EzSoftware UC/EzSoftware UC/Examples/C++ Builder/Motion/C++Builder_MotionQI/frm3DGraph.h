//---------------------------------------------------------------------------

#ifndef Unit5H
#define Unit5H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <OleCtrls.hpp>
#include <ExtCtrls.hpp>
#include "AXTGRAPH3DLib_OCX.h"

//---------------------------------------------------------------------------
class Tfrm3DGraph : public TForm
{
__published:	// IDE-managed Components
    TTimer *tmGraph;

    TButton *btnHelical;
    TButton *btnHelicalPlay;
    TButton *btnSpline;
    TButton *btnSplinePlay;
    TButton *btnClear;
    TButton *btnClose;
        TGroupBox *GroupBox1;
        TComboBox *cboAxisReset;
        TComboBox *cboDimension;
        TCheckBox *chkBoxEnable;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TButton *btnSetRange;
    TAxtGraph3D *AxtGraph3D;
    TEdit *editRangeX;
    TEdit *editRangeY;
    TEdit *editRangeZ;
    TEdit *Edit1;
    TEdit *Edit2;
    TEdit *Edit3;
    TEdit *editXCMD;
    TEdit *editYCMD;
    TEdit *editZCMD;
    void __fastcall btnHelicalClick(TObject *Sender);
    void __fastcall btnHelicalPlayClick(TObject *Sender);
    void __fastcall btnSplineClick(TObject *Sender);
    void __fastcall btnSplinePlayClick(TObject *Sender);
    void __fastcall tmDisplay(TObject *Sender);
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall btnCloseClick(TObject *Sender);
        void __fastcall cboAxisResetChange(TObject *Sender);
        void __fastcall cboDimensionChange(TObject *Sender);
        void __fastcall chkBoxEnableClick(TObject *Sender);
        void __fastcall btnSetRangeClick(TObject *Sender);
        void __fastcall btnClearClick(TObject *Sender);



//    void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
    long    m_aAxis[4];

    void    UpdateAxis(long lAxis);

    __fastcall Tfrm3DGraph(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tfrm3DGraph *frm3DGraph;
//---------------------------------------------------------------------------
#endif
