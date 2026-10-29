//---------------------------------------------------------------------------

#ifndef frmStatusH
#define frmStatusH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TfrmReadStatus : public TForm
{
__published:	// IDE-managed Components
        TButton *btnPrev;
        TButton *btnNext;
        TGroupBox *grbAxisX;
        TGroupBox *GroupBox2;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TLabel *Label11;
        TLabel *Label12;
        TLabel *LedXENS07;
        TLabel *LedXENS06;
        TLabel *LedXENS05;
        TLabel *LedXENS04;
        TLabel *LedXENS01;
        TLabel *LedXENS00;
        TLabel *Label27;
        TLabel *Label28;
        TLabel *LedXENS03;
        TLabel *LedXENS02;
        TLabel *LedXENS14;
        TLabel *LedXENS15;
        TLabel *LedXENS13;
        TLabel *LedXENS12;
        TLabel *LedXENS11;
        TLabel *LedXENS10;
        TLabel *LedXENS09;
        TLabel *LedXENS08;
        TLabel *Label44;
        TLabel *Label45;
        TLabel *Label47;
        TLabel *Label48;
        TLabel *Label49;
        TLabel *Label50;
        TLabel *Label51;
        TLabel *Label52;
        TLabel *LedXENS31;
        TLabel *Label54;
        TLabel *LedXENS30;
        TLabel *Label56;
        TLabel *LedXENS16;
        TLabel *Label58;
        TGroupBox *GroupBox5;
        TLabel *Label20;
        TLabel *Label21;
        TLabel *Label22;
        TLabel *Label23;
        TLabel *Label24;
        TLabel *Label25;
        TLabel *LedXDRS07;
        TLabel *LedXDRS06;
        TLabel *LedXDRS05;
        TLabel *LedXDRS04;
        TLabel *LedXDRS01;
        TLabel *LedXDRS00;
        TLabel *Label46;
        TLabel *Label31;
        TLabel *LedXDRS03;
        TLabel *LedXDRS02;
        TLabel *LedXDRS09;
        TLabel *Label30;
        TLabel *Label32;
        TLabel *LedXDRS10;
        TGroupBox *grbAxisY;
        TGroupBox *GroupBox1;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *LedYDRS07;
        TLabel *LedYDRS06;
        TLabel *LedYDRS05;
        TLabel *LedYDRS04;
        TLabel *LedYDRS01;
        TLabel *LedYDRS00;
        TLabel *Label13;
        TLabel *Label14;
        TLabel *LedYDRS03;
        TLabel *LedYDRS02;
        TLabel *LedYDRS10;
        TLabel *LedYDRS09;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label29;
        TLabel *Label33;
        TGroupBox *GroupBox3;
        TLabel *LedYENS07;
        TLabel *LedYENS06;
        TLabel *LedYENS05;
        TLabel *LedYENS04;
        TLabel *LedYENS01;
        TLabel *LedYENS00;
        TLabel *LedYENS03;
        TLabel *LedYENS02;
        TLabel *LedYENS31;
        TLabel *LedYENS30;
        TLabel *LedYENS16;
        TLabel *LedYENS15;
        TLabel *LedYENS14;
        TLabel *LedYENS13;
        TLabel *LedYENS12;
        TLabel *LedYENS11;
        TLabel *LedYENS10;
        TLabel *LedYENS09;
        TLabel *LedYENS08;
        TLabel *Label59;
        TLabel *Label60;
        TLabel *Label61;
        TLabel *Label62;
        TLabel *Label63;
        TLabel *Label64;
        TLabel *Label65;
        TLabel *Label66;
        TLabel *Label67;
        TLabel *Label68;
        TLabel *Label69;
        TLabel *Label15;
        TLabel *Label16;
        TLabel *Label17;
        TLabel *Label18;
        TLabel *Label19;
        TLabel *Label26;
        TLabel *Label36;
        TLabel *Label37;
        TButton *btnCur;
    TTimer *tmStatusView;
    void __fastcall btnPrevClick(TObject *Sender);
    void __fastcall btnNextClick(TObject *Sender);
    void __fastcall btnCurClick(TObject *Sender);
    void __fastcall tmStatusViewTimer(TObject *Sender);
private:	// User declarations
public:		// User declarations
    long	m_aAxis[2];

public:
	void	LampUpdate();
	void	UpdateAxis(long nAxis);
        
        __fastcall TfrmReadStatus(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmReadStatus *frmReadStatus;
//---------------------------------------------------------------------------
#endif
