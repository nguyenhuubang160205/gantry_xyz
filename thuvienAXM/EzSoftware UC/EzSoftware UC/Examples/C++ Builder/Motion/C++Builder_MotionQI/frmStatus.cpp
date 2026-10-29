//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "frmStatus.h"
#include "stdio.h "
#include "Axm.h "

//---------------------------------------------------------------------------
#define AXIS_EVN(AXIS_NO)		(AXIS_NO - (AXIS_NO % 2))			// Searching for even number axis of axis which makes couple
#define AXIS_ODD(AXIS_NO)		(AXIS_NO + ((AXIS_NO + 1) % 2))		// Searching for odd number axis of axis which makes couple
#define LED_RED(ON)             ((ON == 1) ? clRed : clMaroon)

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2 : 1, b3 : 1, b4 : 1, b5 : 1, b6 : 1, b7 : 1;
} byte_bits;

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2  : 1, b3  : 1, b4  : 1, b5  : 1, b6  : 1, b7  : 1,
				b8 : 1, b9 : 1, b10 : 1, b11 : 1, b12 : 1, b13 : 1, b14 : 1, b15 : 1;
} word_bits;

typedef struct {
	unsigned	b0 : 1, b1 : 1, b2  : 1, b3  : 1, b4  : 1, b5  : 1, b6  : 1, b7  : 1,
				b8 : 1, b9 : 1, b10 : 1, b11 : 1, b12 : 1, b13 : 1, b14 : 1, b15 : 1,
				b16 : 1, b17 : 1, b18 : 1, b19 : 1, b20 : 1, b21 : 1, b22 : 1, b23 : 1,
				b24 : 1, b25 : 1, b26 : 1, b27 : 1, b28 : 1, b29 : 1, b30 : 1, b31 : 1;
} dword_bits;

typedef union {
	WORD wWord;
	BYTE bByte;
    DWORD dwWord;
	word_bits wbit;
	dword_bits dwbit;
	byte_bits bit;
} lsByte;
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmReadStatus *frmReadStatus;
//---------------------------------------------------------------------------
__fastcall TfrmReadStatus::TfrmReadStatus(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void TfrmReadStatus::UpdateAxis(long nAxis)
{
	m_aAxis[0]	= AXIS_EVN(nAxis);
	m_aAxis[1]	= AXIS_ODD(nAxis);

	LampUpdate();
}
//---------------------------------------------------------------------------
void TfrmReadStatus::LampUpdate()
{
	char    strAxis[200];
	long	lAxisCount;
	lsByte	byteEnd;
	DWORD	EndStatus;

	AxmStatusReadStop(m_aAxis[0], &EndStatus);

	byteEnd.dwWord		= (UINT32)EndStatus;

	LedXENS31->Color  = LED_RED(byteEnd.dwbit.b31);
	LedXENS30->Color  = LED_RED(byteEnd.dwbit.b30);
	LedXENS16->Color  = LED_RED(byteEnd.dwbit.b16);
	LedXENS15->Color  = LED_RED(byteEnd.dwbit.b15);
	LedXENS14->Color  = LED_RED(byteEnd.dwbit.b14);
	LedXENS13->Color  = LED_RED(byteEnd.dwbit.b13);
	LedXENS12->Color  = LED_RED(byteEnd.dwbit.b12);
	LedXENS11->Color  = LED_RED(byteEnd.dwbit.b11);
	LedXENS10->Color  = LED_RED(byteEnd.dwbit.b10);
	LedXENS09->Color  = LED_RED(byteEnd.dwbit.b9);
	LedXENS08->Color  = LED_RED(byteEnd.dwbit.b8);
	LedXENS07->Color  = LED_RED(byteEnd.dwbit.b7);
	LedXENS06->Color  = LED_RED(byteEnd.dwbit.b6);
	LedXENS05->Color  = LED_RED(byteEnd.dwbit.b5);
	LedXENS04->Color  = LED_RED(byteEnd.dwbit.b4);
	LedXENS03->Color  = LED_RED(byteEnd.dwbit.b3);
	LedXENS02->Color  = LED_RED(byteEnd.dwbit.b2);
	LedXENS01->Color  = LED_RED(byteEnd.dwbit.b1);
	LedXENS00->Color  = LED_RED(byteEnd.dwbit.b0);

	AxmStatusReadStop(m_aAxis[1], &EndStatus);

	byteEnd.dwWord		= (UINT32)EndStatus;

	LedYENS31->Color  = LED_RED(byteEnd.dwbit.b31);
	LedYENS30->Color  = LED_RED(byteEnd.dwbit.b30);
	LedYENS16->Color  = LED_RED(byteEnd.dwbit.b16);
	LedYENS15->Color  = LED_RED(byteEnd.dwbit.b15);
	LedYENS14->Color  = LED_RED(byteEnd.dwbit.b14);
	LedYENS13->Color  = LED_RED(byteEnd.dwbit.b13);
	LedYENS12->Color  = LED_RED(byteEnd.dwbit.b12);
	LedYENS11->Color  = LED_RED(byteEnd.dwbit.b11);
	LedYENS10->Color  = LED_RED(byteEnd.dwbit.b10);
	LedYENS09->Color  = LED_RED(byteEnd.dwbit.b9);
	LedYENS08->Color  = LED_RED(byteEnd.dwbit.b8);
	LedYENS07->Color  = LED_RED(byteEnd.dwbit.b7);
	LedYENS06->Color  = LED_RED(byteEnd.dwbit.b6);
	LedYENS05->Color  = LED_RED(byteEnd.dwbit.b5);
	LedYENS04->Color  = LED_RED(byteEnd.dwbit.b4);
	LedYENS03->Color  = LED_RED(byteEnd.dwbit.b3);
	LedYENS02->Color  = LED_RED(byteEnd.dwbit.b2);
	LedYENS01->Color  = LED_RED(byteEnd.dwbit.b1);
	LedYENS00->Color  = LED_RED(byteEnd.dwbit.b0);

	sprintf(strAxis, "X Axis: %02d", m_aAxis[0]);
	grbAxisX->Caption = strAxis;

	sprintf(strAxis, "Y Axis: %02d", m_aAxis[1]);
	grbAxisY->Caption = strAxis;

	AxmInfoGetAxisCount(&lAxisCount);
	if(m_aAxis[0] == 0)	btnPrev->Enabled = DISABLE;
	else				btnPrev->Enabled = ENABLE;

	if(m_aAxis[1] == (lAxisCount - 1))	btnNext->Enabled = DISABLE;
	else								btnNext->Enabled = ENABLE;
}
//---------------------------------------------------------------------------
void __fastcall TfrmReadStatus::btnPrevClick(TObject *Sender)
{
	if(m_aAxis[0] >= 2){
		m_aAxis[0]	-= 2;
		m_aAxis[1]	-= 2;
		LampUpdate();
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmReadStatus::btnNextClick(TObject *Sender)
{
	long	lAxisCount;
	AxmInfoGetAxisCount(&lAxisCount);
	if(m_aAxis[1] < lAxisCount-1){
		m_aAxis[0]	+= 2;
		m_aAxis[1]	+= 2;
		LampUpdate();
	}	
}
//---------------------------------------------------------------------------
void __fastcall TfrmReadStatus::btnCurClick(TObject *Sender)
{
    LampUpdate();
}
//---------------------------------------------------------------------------


void __fastcall TfrmReadStatus::tmStatusViewTimer(TObject *Sender)
{
    DWORD	dwIsMotionModule;

	AxmInfoIsMotionModule(&dwIsMotionModule);
	if(!dwIsMotionModule)
	{
		return;
	}
	char    strAxis[200];
	long	lAxisCount;
	lsByte	byteDriver;
	DWORD	DrvStatus;

	AxmStatusReadMotion(m_aAxis[0], &DrvStatus);

	byteDriver.dwWord	= (UINT32)DrvStatus;

    LedXDRS10->Color  = LED_RED(byteDriver.dwbit.b10);
	LedXDRS09->Color  = LED_RED(byteDriver.dwbit.b9);
	LedXDRS07->Color  = LED_RED(byteDriver.dwbit.b8);
	LedXDRS06->Color  = LED_RED(byteDriver.dwbit.b6);
	LedXDRS05->Color  = LED_RED(byteDriver.dwbit.b5);
	LedXDRS04->Color  = LED_RED(byteDriver.dwbit.b4);
	LedXDRS03->Color  = LED_RED(byteDriver.dwbit.b3);
	LedXDRS02->Color  = LED_RED(byteDriver.dwbit.b2);
	LedXDRS01->Color  = LED_RED(byteDriver.dwbit.b1);
	LedXDRS00->Color  = LED_RED(byteDriver.dwbit.b0);

	AxmStatusReadMotion(m_aAxis[1], &DrvStatus);

	byteDriver.dwWord	= (UINT32)DrvStatus;

	LedYDRS10->Color  = LED_RED(byteDriver.dwbit.b10);
	LedYDRS09->Color  = LED_RED(byteDriver.dwbit.b9);
	LedYDRS07->Color  = LED_RED(byteDriver.dwbit.b8);
	LedYDRS06->Color  = LED_RED(byteDriver.dwbit.b6);
	LedYDRS05->Color  = LED_RED(byteDriver.dwbit.b5);
	LedYDRS04->Color  = LED_RED(byteDriver.dwbit.b4);
	LedYDRS03->Color  = LED_RED(byteDriver.dwbit.b3);
	LedYDRS02->Color  = LED_RED(byteDriver.dwbit.b2);
	LedYDRS01->Color  = LED_RED(byteDriver.dwbit.b1);
	LedYDRS00->Color  = LED_RED(byteDriver.dwbit.b0);
}
//---------------------------------------------------------------------------

