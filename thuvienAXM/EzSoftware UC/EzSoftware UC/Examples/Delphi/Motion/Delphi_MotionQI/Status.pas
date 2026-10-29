unit Status;

interface

uses
    Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
    Dialogs, ExtCtrls, StdCtrls,AXM;

type
    TfrmStatus = class(TForm)
    btnPrev: TButton;
    btnNext: TButton;
    grbAxisX: TGroupBox;
    GroupBox2: TGroupBox;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    LedXENS07: TLabel;
    LedXENS06: TLabel;
    LedXENS05: TLabel;
    LedXENS04: TLabel;
    LedXENS01: TLabel;
    LedXENS00: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    LedXENS03: TLabel;
    LedXENS02: TLabel;
    LedXENS14: TLabel;
    LedXENS15: TLabel;
    LedXENS13: TLabel;
    LedXENS12: TLabel;
    LedXENS11: TLabel;
    LedXENS10: TLabel;
    LedXENS09: TLabel;
    LedXENS08: TLabel;
    Label44: TLabel;
    Label45: TLabel;
    Label47: TLabel;
    Label48: TLabel;
    Label49: TLabel;
    Label50: TLabel;
    Label51: TLabel;
    Label52: TLabel;
    LedXENS31: TLabel;
    Label54: TLabel;
    LedXENS30: TLabel;
    Label56: TLabel;
    LedXENS16: TLabel;
    Label58: TLabel;
    GroupBox5: TGroupBox;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    LedXDRS07: TLabel;
    LedXDRS06: TLabel;
    LedXDRS05: TLabel;
    LedXDRS04: TLabel;
    LedXDRS01: TLabel;
    LedXDRS00: TLabel;
    Label46: TLabel;
    Label31: TLabel;
    LedXDRS03: TLabel;
    LedXDRS02: TLabel;
    LedXDRS09: TLabel;
    Label30: TLabel;
    Label32: TLabel;
    LedXDRS10: TLabel;
    grbAxisY: TGroupBox;
    GroupBox1: TGroupBox;
    Label5: TLabel;
    Label6: TLabel;
    LedYDRS07: TLabel;
    LedYDRS06: TLabel;
    LedYDRS05: TLabel;
    LedYDRS04: TLabel;
    LedYDRS01: TLabel;
    LedYDRS00: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    LedYDRS03: TLabel;
    LedYDRS02: TLabel;
    LedYDRS10: TLabel;
    LedYDRS09: TLabel;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label29: TLabel;
    Label33: TLabel;
    GroupBox3: TGroupBox;
    LedYENS07: TLabel;
    LedYENS06: TLabel;
    LedYENS05: TLabel;
    LedYENS04: TLabel;
    LedYENS01: TLabel;
    LedYENS00: TLabel;
    LedYENS03: TLabel;
    LedYENS02: TLabel;
    LedYENS31: TLabel;
    LedYENS30: TLabel;
    LedYENS16: TLabel;
    LedYENS15: TLabel;
    LedYENS14: TLabel;
    LedYENS13: TLabel;
    LedYENS12: TLabel;
    LedYENS11: TLabel;
    LedYENS10: TLabel;
    LedYENS09: TLabel;
    LedYENS08: TLabel;
    Label59: TLabel;
    Label60: TLabel;
    Label61: TLabel;
    Label62: TLabel;
    Label63: TLabel;
    Label64: TLabel;
    Label65: TLabel;
    Label66: TLabel;
    Label67: TLabel;
    Label68: TLabel;
    Label69: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Label26: TLabel;
    Label36: TLabel;
    Label37: TLabel;
    btnCur: TButton;
    tmStatusView: TTimer;
    procedure btnPrevClick(Sender: TObject);
    procedure btnNextClick(Sender: TObject);
    procedure btnCurClick(Sender: TObject);
    procedure UpdateAxis(lAxis: SmallInt);
    Function LampUpdate():Integer;stdcall;
    procedure tmStatusViewTimer(Sender: TObject);
  private
    { Private declarations }
  public
  end;

var
    frmStatus: TfrmStatus;

implementation

uses CamcQI;

var
    m_aAxis : array[0..2] of LongInt;

{$R *.dfm}
procedure TfrmStatus.btnPrevClick(Sender: TObject);
begin
    if(m_aAxis[0] >= 2)then
    begin
		m_aAxis[0]	:= m_aAxis[0] - 2;
		m_aAxis[1]	:= m_aAxis[1] - 2;
		LampUpdate();
    end;
end;

procedure TfrmStatus.btnNextClick(Sender: TObject);
var
    lAxisCount : LongInt;
begin
	AxmInfoGetAxisCount(@lAxisCount);
	if(m_aAxis[1] < lAxisCount-1)Then
    begin
		m_aAxis[0]	:= m_aAxis[0] + 2;
		m_aAxis[1]	:= m_aAxis[1] + 2;
		LampUpdate();
    end;
end;

procedure TfrmStatus.btnCurClick(Sender: TObject);
begin
    LampUpdate();
end;

procedure TfrmStatus.UpdateAxis(lAxis: SmallInt);
begin
	m_aAxis[0]	:= frmCamcQI.AXIS_EVN(lAxis);
	m_aAxis[1]	:= frmCamcQI.AXIS_ODD(lAxis);

	LampUpdate();
end;

Function TfrmStatus.LampUpdate() : Integer;
var
	lAxisCount : LongInt;
	EndStatus : DWord;
begin
	AxmStatusReadStop(m_aAxis[0], @EndStatus);

    LedXENS31.color := frmCamcQI.LED_RED(((EndStatus shr  31) and $01) = $01);
    LedXENS30.color := frmCamcQI.LED_RED(((EndStatus shr  30) and $01) = $01);
    LedXENS16.color := frmCamcQI.LED_RED(((EndStatus shr  16) and $01) = $01);
    LedXENS15.color := frmCamcQI.LED_RED(((EndStatus shr  15) and $01) = $01);
    LedXENS14.color := frmCamcQI.LED_RED(((EndStatus shr  14) and $01) = $01);
    LedXENS13.color := frmCamcQI.LED_RED(((EndStatus shr  13) and $01) = $01);

    LedXENS11.color := frmCamcQI.LED_RED(((EndStatus shr  11) and $01) = $01);
    LedXENS10.color := frmCamcQI.LED_RED(((EndStatus shr  10) and $01) = $01);
    LedXENS09.color := frmCamcQI.LED_RED(((EndStatus shr  9) and $01) = $01);
    LedXENS08.color := frmCamcQI.LED_RED(((EndStatus shr  8) and $01) = $01);
    LedXENS07.color := frmCamcQI.LED_RED(((EndStatus shr  7) and $01) = $01);
    LedXENS06.color := frmCamcQI.LED_RED(((EndStatus shr  6) and $01) = $01);
    LedXENS05.color := frmCamcQI.LED_RED(((EndStatus shr  5) and $01) = $01);
    LedXENS04.color := frmCamcQI.LED_RED(((EndStatus shr  4) and $01) = $01);
    LedXENS03.color := frmCamcQI.LED_RED(((EndStatus shr  3) and $01) = $01);
    LedXENS02.color := frmCamcQI.LED_RED(((EndStatus shr  2) and $01) = $01);
    LedXENS01.color := frmCamcQI.LED_RED(((EndStatus shr  1) and $01) = $01);
    LedXENS00.color := frmCamcQI.LED_RED(((EndStatus shr  0) and $01) = $01);

	AxmStatusReadStop(m_aAxis[1], @EndStatus);

    LedYENS31.color := frmCamcQI.LED_RED(((EndStatus shr  31) and $01) = $01);
    LedYENS30.color := frmCamcQI.LED_RED(((EndStatus shr  30) and $01) = $01);
    LedYENS16.color := frmCamcQI.LED_RED(((EndStatus shr  16) and $01) = $01);
    LedYENS15.color := frmCamcQI.LED_RED(((EndStatus shr  15) and $01) = $01);
    LedYENS14.color := frmCamcQI.LED_RED(((EndStatus shr  14) and $01) = $01);
    LedYENS13.color := frmCamcQI.LED_RED(((EndStatus shr  13) and $01) = $01);

    LedYENS11.color := frmCamcQI.LED_RED(((EndStatus shr  11) and $01) = $01);
    LedYENS10.color := frmCamcQI.LED_RED(((EndStatus shr  10) and $01) = $01);
    LedYENS09.color := frmCamcQI.LED_RED(((EndStatus shr  9) and $01) = $01);
    LedYENS08.color := frmCamcQI.LED_RED(((EndStatus shr  8) and $01) = $01);
    LedYENS07.color := frmCamcQI.LED_RED(((EndStatus shr  7) and $01) = $01);
    LedYENS06.color := frmCamcQI.LED_RED(((EndStatus shr  6) and $01) = $01);
    LedYENS05.color := frmCamcQI.LED_RED(((EndStatus shr  5) and $01) = $01);
    LedYENS04.color := frmCamcQI.LED_RED(((EndStatus shr  4) and $01) = $01);
    LedYENS03.color := frmCamcQI.LED_RED(((EndStatus shr  3) and $01) = $01);
    LedYENS02.color := frmCamcQI.LED_RED(((EndStatus shr  2) and $01) = $01);
    LedYENS01.color := frmCamcQI.LED_RED(((EndStatus shr  1) and $01) = $01);
    LedYENS00.color := frmCamcQI.LED_RED(((EndStatus shr  0) and $01) = $01);

    grbAxisX.Caption := 'X Axis: ' + Format('%d ', [m_aAxis[0]]);
    grbAxisY.Caption := 'Y Axis: ' + Format('%d ', [m_aAxis[1]]);

	AxmInfoGetAxisCount(@lAxisCount);
	if(m_aAxis[0] = 0)then	btnPrev.Enabled := False
	else				    btnPrev.Enabled := TRue;

	if(m_aAxis[1] = (lAxisCount - 1))then btnNext.Enabled := False
	else								  btnNext.Enabled := True;
end;

procedure TfrmStatus.tmStatusViewTimer(Sender: TObject);
var
	lAxisCount : LongInt;
	DrvStatus : DWord;
begin
	AxmStatusReadMotion(m_aAxis[0], @DrvStatus);

    LedXDRS10.color := frmCamcQI.LED_RED(((DrvStatus shr 10) and $01) = $01);
    LedXDRS09.color := frmCamcQI.LED_RED(((DrvStatus shr 9) and $01) = $01);
    LedXDRS07.color := frmCamcQI.LED_RED(((DrvStatus shr 8) and $01) = $01);
    LedXDRS06.color := frmCamcQI.LED_RED(((DrvStatus shr 6) and $01) = $01);
    LedXDRS05.color := frmCamcQI.LED_RED(((DrvStatus shr 5) and $01) = $01);
    LedXDRS04.color := frmCamcQI.LED_RED(((DrvStatus shr 4) and $01) = $01);
    LedXDRS03.color := frmCamcQI.LED_RED(((DrvStatus shr 3) and $01) = $01);
    LedXDRS02.color := frmCamcQI.LED_RED(((DrvStatus shr 2) and $01) = $01);
    LedXDRS01.color := frmCamcQI.LED_RED(((DrvStatus shr 1) and $01) = $01);
    LedXDRS00.color := frmCamcQI.LED_RED(((DrvStatus shr 0) and $01) = $01);

	AxmStatusReadMotion(m_aAxis[1], @DrvStatus);

    LedYDRS10.color := frmCamcQI.LED_RED(((DrvStatus shr 10) and $01) = $01);
    LedYDRS09.color := frmCamcQI.LED_RED(((DrvStatus shr 9) and $01) = $01);
    LedYDRS07.color := frmCamcQI.LED_RED(((DrvStatus shr 8) and $01) = $01);
    LedYDRS06.color := frmCamcQI.LED_RED(((DrvStatus shr 6) and $01) = $01);
    LedYDRS05.color := frmCamcQI.LED_RED(((DrvStatus shr 5) and $01) = $01);
    LedYDRS04.color := frmCamcQI.LED_RED(((DrvStatus shr 4) and $01) = $01);
    LedYDRS03.color := frmCamcQI.LED_RED(((DrvStatus shr 3) and $01) = $01);
    LedYDRS02.color := frmCamcQI.LED_RED(((DrvStatus shr 2) and $01) = $01);
    LedYDRS01.color := frmCamcQI.LED_RED(((DrvStatus shr 1) and $01) = $01);
    LedYDRS00.color := frmCamcQI.LED_RED(((DrvStatus shr 0) and $01) = $01);
end;

end.







