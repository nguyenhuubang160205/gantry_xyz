unit ManualSet;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  AXL,AXM,AXHS,AxDev, Dialogs, StdCtrls, ExtCtrls;

type
    TfrmManualSet = class(TForm)
    btnCmd: TButton;
    btnRd: TButton;
    btnWr: TButton;
    edtCmd: TEdit;
    edtData: TEdit;
    cboPort: TComboBox;
    chkHex: TCheckBox;
    cboAxisSel: TComboBox;
    chkOnOff1: TCheckBox;
    chkOnOff2: TCheckBox;
    chkOnOff3: TCheckBox;
    edtCmd1: TEdit;
    edtCmd2: TEdit;
    edtCmd3: TEdit;
    edtData1: TEdit;
    edtData2: TEdit;
    edtData3: TEdit;
    chkOnOff4: TCheckBox;
    chkOnOff5: TCheckBox;
    chkOnOff6: TCheckBox;
    edtCmd4: TEdit;
    edtCmd5: TEdit;
    edtCmd6: TEdit;
    edtData4: TEdit;
    edtData5: TEdit;
    edtData6: TEdit;
    tmMonitor: TTimer;
    procedure btnCmdClick(Sender: TObject);
    procedure btnRdClick(Sender: TObject);
    procedure btnWrClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure cboAxisSelChange(Sender: TObject);
    procedure tmMonitorTimer(Sender: TObject);
    procedure chkOnOff1Click(Sender: TObject);
    procedure UpdateAxis(lAxis: SmallInt);
  private
    { Private declarations }
  public

  end;

var
  frmManualSet: TfrmManualSet;

implementation
var
    m_lAxisNo       : SmallInt;
    m_lAxisCount    : SmallInt;
{$R *.dfm}
procedure TfrmManualSet.UpdateAxis(lAxis: SmallInt);
begin
	m_lAxisNo := lAxis;
    cboAxisSel.ItemIndex := m_lAxisNo;
end;

procedure TfrmManualSet.btnCmdClick(Sender: TObject);
var
    strTemp : String;
	bCmd : BYTE;
	dwData : DWORD;
	lTempData : LongInt;
begin
    strTemp := edtCmd.Text;
    lTempData :=  StrToIntDef(strTemp, 0);
	bCmd	:=	$000000FF and lTempData;

    strTemp := edtData.Text;
    lTempData :=  StrToIntDef(strTemp, 0);
	dwData	:=	$ffffffff and lTempData;

	if(($80 and bCmd) = $80)then AxmSetCommandData32Qi(m_lAxisNo, bCmd, dwData)
	else			             AxmGetCommandData32Qi(m_lAxisNo, bCmd, @dwData);

	if(chkHex.Checked = TRUE)then strTemp := Format('0x%x', [dwData])
	else				          strTemp := Format('%d', [dwData]);

    edtData.Text := strTemp;
end;

procedure TfrmManualSet.btnRdClick(Sender: TObject);
var
    lTempData : LongInt;
	strTemp : AnsiString;
	bCmd : BYTE;
	dwData, wOffset : DWORD;
begin
	lTempData := cboPort.ItemIndex;
    wOffset := $200 or (($ff and lTempData) shr 2);

	AxmGetPortData(m_lAxisNo, wOffset, @dwData);

	if(chkHex.Checked = TRUE)then strTemp := Format('0x%x', [dwdata])
	else			   	          strTemp := Format('%d', [dwdata]);

    edtData.Text := strTemp;
end;

procedure TfrmManualSet.btnWrClick(Sender: TObject);
var
    strTemp : AnsiString;
	bCmd : BYTE;
	dwData, wOffset : DWORD;
	lTempData : LongInt;
begin
	lTempData := cboPort.ItemIndex;
	wOffset := $200 or (($ff and lTempData) shr 2);

    strTemp := edtData.Text;
    lTempData :=  StrToIntDef(strTemp, 0);

    dwData := lTempData;
	AxmSetPortDataQi(m_lAxisNo, wOffset, dwData);

	if(chkHex.Checked = TRUE)then strTemp := Format('0x%x', [dwData])
	else			  	          strTemp := Format('%d', [dwData]);

	edtData.Text := strTemp;
end;

procedure TfrmManualSet.FormCreate(Sender: TObject);
var
    lAxisCount : LongInt;
    i : smallInt;
begin
	AxmInfoGetAxisCount(@lAxisCount);

    for i := 0 to lAxisCount - 1 do
        cboAxisSel.Items.Add( IntToStr(i)+' Axis');

    cboAxisSel.ItemIndex := 0;
    cboPort.ItemIndex := 0;
    chkHex.Checked := true;
    tmMonitor.Enabled := true;
end;

procedure TfrmManualSet.cboAxisSelChange(Sender: TObject);
begin
    m_lAxisNo  := cboAxisSel.ItemIndex;
end;

procedure TfrmManualSet.tmMonitorTimer(Sender: TObject);
var
    dwReturn    : DWORD;
	strTemp     : AnsiString;
	dwCmd       : DWORD;
	dwData      : DWORD;
	lTempData   : LongInt;
	i           : Integer;
    chkOnOff    : TCheckBox;
    strName     : String;
    strData     : AnsiString;
    edtData, edtCmd : TEdit;
begin
    for i := 0 to 5 do
    begin
        strName := 'chkOnOff'+IntToStr(i+1);
        chkOnOff := TCheckBox(Self.FindComponent(strName));
		if(chkOnOff.Checked = true)then
        begin
            strName := 'edtCmd' +IntToStr(i+1);
            edtCmd := TEdit(Self.FindComponent(strName));
            strName := 'edtData'+IntToStr(i+1);
            edtData := TEdit(Self.FindComponent(strName));

            strTemp := edtCmd.Text;
		    lTempData := StrToIntDef(strTemp, 0);

            dwCmd := $0000007F and lTempData;
			AxmGetCommandData32Qi(m_lAxisNo, dwCmd, @dwData);

			if(chkHex.Checked = TRUE)then strTemp := Format('0x%x', [dwData])
			else			  	          strTemp := Format('%d', [dwData]);

            edtData.Text := strTemp;
		end;
    end;
end;

procedure TfrmManualSet.chkOnOff1Click(Sender: TObject);
begin
     tmMonitor.Enabled := true;
end;

end.

