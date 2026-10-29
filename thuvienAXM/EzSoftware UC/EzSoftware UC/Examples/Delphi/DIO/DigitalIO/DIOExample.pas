unit DIOExample;

interface

uses
    Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
    Dialogs, AXL, AXHS, AXD, ExtCtrls, StdCtrls, MyThread;

type
    TFormDigitalIO = class(TForm)
        Label1: TLabel;
        m_cbModule: TComboBox;
        RadioGroup1: TRadioGroup;
        m_rdoMessage: TRadioButton;
        m_rdoCallback: TRadioButton;
        m_rdoEvent: TRadioButton;
        m_stcHIGH: TGroupBox;
        m_chkHigh00: TCheckBox;
        m_chkHigh01: TCheckBox;
        m_chkHigh02: TCheckBox;
        m_chkHigh03: TCheckBox;
        m_chkHigh04: TCheckBox;
        m_chkHigh05: TCheckBox;
        m_chkHigh06: TCheckBox;
        m_chkHigh07: TCheckBox;
        m_chkHigh08: TCheckBox;
        m_chkHigh09: TCheckBox;
        m_chkHigh15: TCheckBox;
        m_chkHigh14: TCheckBox;
        m_chkHigh13: TCheckBox;
        m_chkHigh12: TCheckBox;
        m_chkHigh11: TCheckBox;
        m_chkHigh10: TCheckBox;
        m_stcLOW: TGroupBox;
        m_chkLow10: TCheckBox;
        m_chkLow08: TCheckBox;
        m_chkLow07: TCheckBox;
        m_chkLow06: TCheckBox;
        m_chkLow05: TCheckBox;
        m_chkLow04: TCheckBox;
        m_chkLow03: TCheckBox;
        m_chkLow02: TCheckBox;
        m_chkLow01: TCheckBox;
        m_chkLow15: TCheckBox;
        m_chkLow14: TCheckBox;
        m_chkLow13: TCheckBox;
        m_chkLow12: TCheckBox;
        m_chkLow11: TCheckBox;
        m_chkLow09: TCheckBox;
        m_chkLow00: TCheckBox;
        m_btnClear: TButton;
        m_btnClose: TButton;
        m_lstInterrupt: TListBox;
        m_chkRigingedge: TCheckBox;
        m_chkFallingedge: TCheckBox;
        m_chkInterrupt: TCheckBox;
        Timer1: TTimer;
        procedure FormCreate(Sender: TObject);
        procedure m_cbModuleChange(Sender: TObject);
        procedure m_btnCloseClick(Sender: TObject);
        procedure Timer1Timer(Sender: TObject);
        procedure m_chkHigh00Click(Sender: TObject);
        procedure m_chkHigh01Click(Sender: TObject);
        procedure m_chkHigh02Click(Sender: TObject);
        procedure m_chkHigh03Click(Sender: TObject);
        procedure m_chkHigh04Click(Sender: TObject);
        procedure m_chkHigh05Click(Sender: TObject);
        procedure m_chkHigh06Click(Sender: TObject);
        procedure m_chkHigh07Click(Sender: TObject);
        procedure m_chkHigh08Click(Sender: TObject);
        procedure m_chkHigh09Click(Sender: TObject);
        procedure m_chkHigh10Click(Sender: TObject);
        procedure m_chkHigh11Click(Sender: TObject);
        procedure m_chkHigh12Click(Sender: TObject);
        procedure m_chkHigh13Click(Sender: TObject);
        procedure m_chkHigh14Click(Sender: TObject);
        procedure m_chkHigh15Click(Sender: TObject);
        procedure m_chkLow00Click(Sender: TObject);
        procedure m_chkLow01Click(Sender: TObject);
        procedure m_chkLow02Click(Sender: TObject);
        procedure m_chkLow03Click(Sender: TObject);
        procedure m_chkLow04Click(Sender: TObject);
        procedure m_chkLow05Click(Sender: TObject);
        procedure m_chkLow06Click(Sender: TObject);
        procedure m_chkLow07Click(Sender: TObject);
        procedure m_chkLow08Click(Sender: TObject);
        procedure m_chkLow09Click(Sender: TObject);
        procedure m_chkLow10Click(Sender: TObject);
        procedure m_chkLow11Click(Sender: TObject);
        procedure m_chkLow12Click(Sender: TObject);
        procedure m_chkLow13Click(Sender: TObject);
        procedure m_chkLow14Click(Sender: TObject);
        procedure m_chkLow15Click(Sender: TObject);
        procedure m_btnClearClick(Sender: TObject);
        procedure m_chkInterruptClick(Sender: TObject);
        procedure m_chkRigingedgeClick(Sender: TObject);
        procedure m_chkFallingedgeClick(Sender: TObject);
        procedure m_rdoMessageClick(Sender: TObject);
        procedure m_rdoCallbackClick(Sender: TObject);
        procedure OnDIOInterrupt(var Msg: TMessage);
        message WM_AXL_INTERRUPT;
        procedure m_rdoEventClick(Sender: TObject);
    private
        { Private declarations }
        ThreadFlag: TMyThread;

    public
        { Public declarations }
        procedure OpenDevice();

        procedure m_chkHighClick(nNum: Integer);
        procedure m_chkLowClick(nNum: Integer);
    end;

var
    FormDigitalIO: TFormDigitalIO;
    m_in: array [0 .. 15] of TCheckBox;
    m_out: array [0 .. 15] of TCheckBox;

    m_hHandle, m_hInterrupt: PLongInt;
    m_bThread: Boolean;

implementation

{$R *.dfm}

procedure TFormDigitalIO.FormCreate(Sender: TObject);
begin
    m_hHandle := nil;
    m_hInterrupt := nil;
    m_bThread := false;

    m_in[0] := m_chkHigh00;
    m_out[0] := m_chkLow00;
    m_in[1] := m_chkHigh01;
    m_out[1] := m_chkLow01;
    m_in[2] := m_chkHigh02;
    m_out[2] := m_chkLow02;
    m_in[3] := m_chkHigh03;
    m_out[3] := m_chkLow03;
    m_in[4] := m_chkHigh04;
    m_out[4] := m_chkLow04;
    m_in[5] := m_chkHigh05;
    m_out[5] := m_chkLow05;
    m_in[6] := m_chkHigh06;
    m_out[6] := m_chkLow06;
    m_in[7] := m_chkHigh07;
    m_out[7] := m_chkLow07;
    m_in[8] := m_chkHigh08;
    m_out[8] := m_chkLow08;
    m_in[9] := m_chkHigh09;
    m_out[9] := m_chkLow09;
    m_in[10] := m_chkHigh10;
    m_out[10] := m_chkLow10;
    m_in[11] := m_chkHigh11;
    m_out[11] := m_chkLow11;
    m_in[12] := m_chkHigh12;
    m_out[12] := m_chkLow12;
    m_in[13] := m_chkHigh13;
    m_out[13] := m_chkLow13;
    m_in[14] := m_chkHigh14;
    m_out[14] := m_chkLow14;
    m_in[15] := m_chkHigh15;
    m_out[15] := m_chkLow15;

    // Library and Motion initialize.
    OpenDevice();

    m_cbModuleChange(nil);

    Timer1.Enabled := true;
end;

procedure TFormDigitalIO.m_btnCloseClick(Sender: TObject);
begin
    AxlClose();
    Close();
end;

procedure TFormDigitalIO.OpenDevice();
var
    dwStatus, dwModuleID: DWORD;
    lModuleCount, lBoardNo, lModulePos: LongInt;
    i: SmallInt;
    strData: String;
    szModuleName: PAnsiChar;

begin
    // ++
    // Library initialize.
    if (AxlOpen(7) = AXT_RT_SUCCESS) then
    begin
        if (AxdInfoIsDIOModule(@dwStatus) = AXT_RT_SUCCESS) then
        begin
            if (dwStatus = STATUS_EXIST) then
            begin
                if (AxdInfoGetModuleCount(@lModuleCount) = AXT_RT_SUCCESS) then
                begin
                    for i := 0 to lModuleCount do
                    begin
                        if (AxdInfoGetModule(i, @lBoardNo, @lModulePos,
                                @dwModuleID) = AXT_RT_SUCCESS) then
                        begin
                            case dwModuleID of
                                AXT_SIO_DI32:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_DI32';
                                AXT_SIO_DO32P:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO-DO32P';
                                AXT_SIO_DB32P:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO-DB32P';
                                AXT_SIO_DO32T:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_DO32T';
                                AXT_SIO_DB32T:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO-DB32T';
                                AXT_SIO_RDI32:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDI32';
                                AXT_SIO_RDO32:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDO32';
                                AXT_SIO_RSIMPLEIOMLII:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RSIMPLEIOMLII';
                                AXT_SIO_RDI16MLII:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDI16MLII';
                                AXT_SIO_RDO16AMLII:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDO16AMLII';
                                AXT_SIO_RDO16BMLII:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDO16BMLII';
                                AXT_SIO_RDB96MLII:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDB96MLII';
                                AXT_SIO_RDO32RTEX:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDO32RTEX';
                                AXT_SIO_RDI32RTEX:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDI32RTEX';
                                AXT_SIO_RDB32RTEX:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDO32';
                                AXT_SIO_DI32_P:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_DI32_P';
                                AXT_SIO_DO32T_P:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_DO32T_P';
                                AXT_SIO_RDB32T:
                                    strData := '[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] SIO_RDB32T';
                                AXT_ECAT_DIO:
                                    begin
                                        szModuleName := Allocmem(50);
                                        AxdInfoGetModuleEx(i, nil, PChar(szModuleName), nil);
                                        strData := Format('[BD No:' + IntToStr(lBoardNo) + ' - MD No:' + IntToStr(i) + '] %s', [String(szModuleName)]);
                                    end
                            end;
                            m_cbModule.Items.Add(strData);
                        end;
                    end;
                end;
                m_cbModule.ItemIndex := 0;
            end
            else
            begin
                ShowMessage('Module does not exist.');
            end;
        end
        else
        begin
            ShowMessage('AxdInfoIsDIOModule Error!!');
        end;
    end
    else
    begin
        ShowMessage('Open Error!');
    end;
end;

procedure TFormDigitalIO.m_cbModuleChange(Sender: TObject);
var
    lModuleCounts, lBoardNo, lModulePos: LongInt;
    dwModuleID, dwDataHigh, dwDataLow, dwUse: DWORD;
    nIndex, nFlagHigh, nFlagLow: SmallInt;
    bFlagHigh, bFlagLow: Boolean;
    lFlagHigh, lFlagLow: LongInt;
    lInCount, lOutCount: LongInt;

begin
    AxdInfoGetModuleCount(@lModuleCounts);

    m_rdoMessage.Checked := true;
    if (lModuleCounts > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        case dwModuleID of
            AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_RDI16MLII, AXT_SIO_RDI32RTEX,
              AXT_SIO_DI32_P:
                begin
                    m_stcHIGH.Caption := 'INPUT  0bit ~ 15Bit';
                    m_stcLOW.Caption := 'INPUT 16bit ~ 31Bit';

                    if (dwModuleID = AXT_SIO_RDI32) then
                    begin
                        m_chkInterrupt.Enabled := false;
                        m_chkRigingedge.Enabled := false;
                        m_chkFallingedge.Enabled := false;
                        m_rdoMessage.Enabled := false;
                        m_rdoCallback.Enabled := false;
                        m_rdoEvent.Enabled := false;
                    end
                    else
                    begin
                        m_chkInterrupt.Enabled := true;
                        m_chkRigingedge.Enabled := true;
                        m_chkFallingedge.Enabled := true;
                        m_rdoMessage.Enabled := true;
                        m_rdoCallback.Enabled := true;
                        m_rdoEvent.Enabled := true;

                        AxdiInterruptGetModuleEnable(m_cbModule.ItemIndex, @dwUse);
                        if (dwUse = ENABLE) then
                        begin
                            m_chkInterrupt.Checked := true;
                        end
                        else
                        begin
                            m_chkInterrupt.Checked := false;
                        end;

                        AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 0, UP_EDGE, @dwDataHigh);
                        AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 1, UP_EDGE, @dwDataLow);
                        if (dwDataHigh = $FFFF) and (dwDataLow = $FFFF) then
                        begin
                            m_chkRigingedge.Checked := true;
                        end
                        else
                        begin
                            m_chkRigingedge.Checked := false;
                        end;

                        AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 0, DOWN_EDGE, @dwDataHigh);
                        AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 1, DOWN_EDGE, @dwDataLow);
                        if (dwDataHigh = $FFFF) and (dwDataLow = $FFFF) then
                        begin
                            m_chkFallingedge.Checked := true;
                        end
                        else
                        begin
                            m_chkFallingedge.Checked := false;
                        end;

                        for nIndex := 0 to 15 do
                        begin
                            m_in[nIndex].Caption := IntToStr(nIndex);
                            m_out[nIndex].Caption := IntToStr(16 + nIndex);
                        end;
                    end;
                end;
            AXT_SIO_DO32P, AXT_SIO_RDO32, AXT_SIO_DO32T, AXT_SIO_RDB32RTEX,
              AXT_SIO_RDB96MLII, AXT_SIO_RSIMPLEIOMLII:
                begin
                    m_stcHIGH.Caption := 'OUTPUT  0bit ~ 15Bit';
                    m_stcLOW.Caption := 'OUTPUT 16bit ~ 31Bit';

                    m_chkInterrupt.Checked := false;
                    m_chkRigingedge.Checked := false;
                    m_chkFallingedge.Checked := false;
                    m_rdoMessage.Enabled := false;
                    m_rdoCallback.Enabled := false;
                    m_rdoEvent.Enabled := false;

                    // ++
                    // Read the signal to become output to WORD.
                    AxdoReadOutportWord(m_cbModule.ItemIndex, 0, @dwDataHigh);
                    AxdoReadOutportWord(m_cbModule.ItemIndex, 1, @dwDataLow);

                    for nIndex := 0 to 15 do
                    begin
                        // Confirm a last bit price of data to read.
                        nFlagHigh := dwDataHigh and $01;
                        nFlagLow := dwDataLow and $01;

                        if (nFlagHigh = 1) then
                        begin
                            bFlagHigh := true;
                        end
                        else

                        begin
                            bFlagHigh := false;
                        end;

                        if (nFlagLow = 1) then
                        begin
                            bFlagLow := true;
                        end
                        else

                        begin
                            bFlagLow := false;
                        end;

                        // One bit does Shift to right.
                        dwDataHigh := dwDataHigh shr 1;
                        dwDataLow := dwDataLow shr 1;

                        // Update orders a bit price at Control.
                        m_in[nIndex].Checked := bFlagHigh;
                        m_out[nIndex].Checked := bFlagLow;
                        m_in[nIndex].Caption := IntToStr(nIndex);
                        m_out[nIndex].Caption := IntToStr(16 + nIndex);
                    end;
                end;
            AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB128MLII:

                begin
                    m_stcHIGH.Caption := 'INPUT  0bit ~ 15Bit';
                    m_stcLOW.Caption := 'OUTPUT  0bit ~ 15Bit';

                    m_chkInterrupt.Enabled := true;
                    m_chkRigingedge.Enabled := true;
                    m_chkFallingedge.Enabled := true;
                    m_rdoMessage.Enabled := true;
                    m_rdoCallback.Enabled := true;
                    m_rdoEvent.Enabled := true;

                    AxdiInterruptGetModuleEnable(m_cbModule.ItemIndex, @dwUse);
                    if (dwUse = ENABLE) then
                    begin
                        m_chkInterrupt.Checked := true;
                    end
                    else
                    begin
                        m_chkInterrupt.Checked := false;
                    end;

                    AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 0, UP_EDGE, @dwDataHigh);
                    if (dwDataHigh = $FFFF) then
                    begin
                        m_chkRigingedge.Checked := true;
                    end
                    else
                    begin
                        m_chkRigingedge.Checked := false;
                    end;

                    AxdiInterruptEdgeGetWord(m_cbModule.ItemIndex, 0, DOWN_EDGE, @dwDataHigh);
                    if (dwDataHigh = $FFFF) then
                    begin
                        m_chkFallingedge.Checked := true;
                    end
                    else
                    begin
                        m_chkFallingedge.Checked := false;
                    end;
                    // ++
                    // Read the signal to become output to WORD.
                    AxdoReadOutportWord(m_cbModule.ItemIndex, 0, @dwDataLow);

                    for nIndex := 0 to 15 do
                    begin
                        // Confirm a last bit price of data to read.
                        nFlagLow := dwDataLow and $01;

                        if (nFlagLow = 1) then
                        begin
                            bFlagLow := true;
                        end
                        else
                        begin
                            bFlagLow := false;
                        end;
                        // One bit does Shift to right.
                        dwDataLow := dwDataLow shr 1;
                        // Update orders a bit price at Control.
                        m_out[nIndex].Checked := bFlagLow;

                        m_in[nIndex].Caption := IntToStr(nIndex);
                        m_out[nIndex].Caption := IntToStr(nIndex);
                    end;
                end;

            AXT_ECAT_DIO:
            begin
                AxdInfoGetInputCount(m_cbModule.ItemIndex, @lInCount);
                AxdInfoGetOutputCount(m_cbModule.ItemIndex, @lOutCount);

                if (lInCount > 16) then
                begin
                    m_stcHIGH.Caption := 'INPUT  0bit ~ 15Bit';
                    m_stcLOW.Caption := 'INPUT 16bit ~ 31Bit';

                    for nIndex := 0 to 15 do
                    begin
                        m_out[nIndex].Enabled := false;
                        m_out[nIndex].Caption := IntToStr(nIndex + 16);
                    end;

                    for nIndex := 0 to 15 do
                    begin
                        m_in[nIndex].Enabled := false;
                    end;
                end

                else if (lInCount > 0) then
                begin
                    m_stcHIGH.Caption := 'INPUT  0bit ~ 15Bit';

                    for nIndex := 0 to 15 do
                    begin
                        m_in[nIndex].Enabled := false;
                    end;

                    if (lOutCount > 0) then
                    begin
                        m_stcLOW.Caption := 'OUTPUT  0bit ~ 15Bit';

                        AxdoReadOutportWord(m_cbModule.ItemIndex, 0, @dwDataLow);

                        for nIndex := 0 to 15 do
                        begin
                            m_out[nIndex].Enabled := true;
                            m_out[nIndex].Caption := IntToStr(nIndex);
                        end;
                    end
                    else
                    begin
                        m_stcLOW.Caption := '';
                    end;
                end

                else
                begin
                    if (lOutCount > 16) then
                    begin
                        m_stcHIGH.Caption := 'INPUT  0bit ~ 15Bit';
                        m_stcLOW.Caption := 'INPUT 16bit ~ 31Bit';

                        AxdoReadOutportWord(m_cbModule.ItemIndex, 0, @dwDataHigh);
                        AxdoReadOutportWord(m_cbModule.ItemIndex, 1, @dwDataLow);

                        for nIndex := 0 to 15 do
                        begin
                            m_in[nIndex].Enabled := true;
                        end;

                        for nIndex := 0 to 15 do
                        begin
                            m_out[nIndex].Enabled := true;
                            m_out[nIndex].Caption := IntToStr(nIndex + 16);
                        end;
                    end

                    else if (lOutCount > 0) then
                    begin
                        m_stcHIGH.Caption := 'OUTPUT  0bit ~ 15Bit';
                        m_stcLOW.Caption := '';
                        AxdoReadOutportWord
                          (m_cbModule.ItemIndex, 0, @dwDataHigh);

                        for nIndex := 0 to 15 do
                        begin
                            m_in[nIndex].Enabled := true;
                        end;
                    end;
                end;

                m_chkInterrupt.Checked := false;
                m_chkRigingedge.Checked := false;
                m_chkFallingedge.Checked := false;

                m_chkInterrupt.Enabled := false;
                m_chkRigingedge.Enabled := false;
                m_chkFallingedge.Enabled := false;

                m_rdoMessage.Enabled := false;
                m_rdoCallback.Enabled := false;
                m_rdoEvent.Enabled := false;

                for nIndex := 0 to 15 do
                begin
                    //bFlagHigh := dwDataHigh and $0001;
                    lFlagHigh := dwDataHigh and $0001;
                    lFlagLow := dwDataLow and $0001;
                    //bFlagLow := dwDataLow and $0001;

                    dwDataHigh := dwDataHigh shr 1;
                    dwDataLow := dwDataLow shr 1;

                    //if (bFlagLow = 1) then
                    if (lFlagLow = 1) then
                    begin
                        m_out[nIndex].Checked := true;
                    end
                    else
                    begin
                        m_out[nIndex].Checked := false;
                    end;

                    if (lOutCount > 16) then
                    begin
                        if (lFlagHigh = 1) then
                        begin
                            m_in[nIndex].Checked := true;
                        end
                        else
                        begin
                            m_in[nIndex].Checked := false;
                        end;
                    end;
                end;
            end;
        end;
    end;
end;

procedure TFormDigitalIO.Timer1Timer(Sender: TObject);
var
    nIndex, nFlagHigh, nFlagLow: SmallInt;
    dwDataHigh, dwDataLow, dwModuleID: DWORD;
    bFlagHigh, bFlagLow: Boolean;
    lFlagHigh, lFlagLow: LongInt;
    lBoardNo, lModulePos: LongInt;
    lInCount: LongInt;

begin
    AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos, @dwModuleID);

    case dwModuleID of
        AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_RDI16MLII, AXT_SIO_RDI32RTEX,
          AXT_SIO_DI32_P:
            begin
                // ++
                // Read the signal to become input to WORD.
                AxdiReadInportWord(m_cbModule.ItemIndex, 0, @dwDataHigh);
                AxdiReadInportWord(m_cbModule.ItemIndex, 1, @dwDataLow);
                for nIndex := 0 to 15 do
                begin
                    // Confirm a last bit price of data to read.
                    nFlagHigh := dwDataHigh and $01;
                    nFlagLow := dwDataLow and $01;

                    if (nFlagHigh = 1) then
                    begin
                        bFlagHigh := true;
                    end
                    else
                    begin
                        bFlagHigh := false;
                    end;

                    if (nFlagLow = 1) then
                    begin
                        bFlagLow := true;
                    end
                    else
                    begin
                        bFlagLow := false;
                    end;
                    // One bit does Shift to right.
                    dwDataHigh := dwDataHigh shr 1;
                    dwDataLow := dwDataLow shr 1;

                    // Update orders a bit price at Control.
                    m_in[nIndex].Checked := bFlagHigh;
                    m_out[nIndex].Checked := bFlagLow;
                end;
            end;
        AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB128MLII, AXT_SIO_RDB32RTEX,
          AXT_SIO_RDB32T, AXT_SIO_RDB96MLII, AXT_SIO_RSIMPLEIOMLII:
            begin
                // ++
                // Read the signal to become input to WORD.
                AxdiReadInportWord(m_cbModule.ItemIndex, 0, @dwDataHigh);
                for nIndex := 0 to 15 do
                begin
                    // Confirm a last bit price of data to read.
                    nFlagHigh := dwDataHigh and $01;

                    if (nFlagHigh = 1) then
                    begin
                        bFlagHigh := true;
                    end
                    else
                    begin
                        bFlagHigh := false;
                    end;
                    // One bit does Shift to right.
                    dwDataHigh := dwDataHigh shr 1;

                    // Update orders a bit price at Control.
                    m_in[nIndex].Checked := bFlagHigh;
                end;
            end;
         AXT_ECAT_DIO:
         begin
            AxdInfoGetInputCount(m_cbModule.ItemIndex, @lInCount);
            if (lInCount > 0) then
            begin
                AxdiReadInportWord(m_cbModule.ItemIndex, 0, @dwDataHigh);
                AxdiReadInportWord(m_cbModule.ItemIndex, 1, @dwDataLow);

                for nIndex := 0 to 15 do
                begin
                    lFlagHigh := dwDataHigh and $0001;
                    lFlagLow := dwDataLow and $0001;

                    dwDataHigh := dwDataHigh shr 1;
                    dwDataLow := dwDataLow shr 1;

                    if (lFlagHigh = 1) then
                    begin
                         m_in[nIndex].Checked := true;
                    end
                    else
                    begin
                         m_in[nIndex].Checked := false;
                    end;

                    if (lInCount > 16) then
                    begin
                        if (lFlagLow = 1) then
                        begin
                               m_out[nIndex].Checked := true;
                        end
                        else
                        begin
                            m_out[nIndex].Checked :=  false;
                        end;
                    end;
                end;
            end;
        end;
    end;
end;

// ++
// Event in click the collation box in the output case to happen.
procedure TFormDigitalIO.m_chkHighClick(nNum: Integer);
var
    lModuleCounts, lBoardNo, lModulePos: LongInt;
    dwModuleID: DWORD;
    nChecked: Integer;
    lOutCount: LongInt;
begin
    AxdInfoGetModuleCount(@lModuleCounts);

    if (lModuleCounts > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        if (m_in[nNum].Checked) then
        begin
            nChecked := 1;
        end
        else
        begin
            nChecked := 0;
        end;

        case dwModuleID of
            AXT_SIO_DO32P:
                AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
            AXT_SIO_DO32T:
                AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
            AXT_SIO_RDO32:
                AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
            AXT_ECAT_DIO:
            begin
                AxdInfoGetOutputCount(m_cbModule.ItemIndex, @lOutCount);
                if (lOutCount > 16) then
                begin
                    AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
                end;
            end;
        end;
    end;
end;
// ---------------------------------------------------------------------------

procedure TFormDigitalIO.m_chkLowClick(nNum: Integer);
var
    lModuleCounts, lBoardNo, lModulePos: LongInt;
    dwModuleID: DWORD;
    nChecked: Integer;
    lOutCount: LongInt;
begin
    AxdInfoGetModuleCount(@lModuleCounts);

    if (lModuleCounts > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        if (m_out[nNum].Checked) then
        begin
            nChecked := 1;
        end
        else
        begin
            nChecked := 0;
        end;

        case dwModuleID of
            AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB128MLII:
                AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
            AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32:
                AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum + 16, nChecked);
            AXT_ECAT_DIO:
            begin
                AxdInfoGetOutputCount(m_cbModule.ItemIndex, @lOutCount);
                if (lOutCount > 16) then
                begin
                    AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum+16, nChecked);
                end
                else if (lOutCount > 0) then
                begin
                    AxdoWriteOutportBit(m_cbModule.ItemIndex, nNum, nChecked);
                end;
            end;
        end;
    end;
end;
// ---------------------------------------------------------------------------

procedure TFormDigitalIO.m_chkHigh00Click(Sender: TObject);
begin
    m_chkHighClick(0);
end;

procedure TFormDigitalIO.m_chkHigh01Click(Sender: TObject);
begin
    m_chkHighClick(1);
end;

procedure TFormDigitalIO.m_chkHigh02Click(Sender: TObject);
begin
    m_chkHighClick(2);
end;

procedure TFormDigitalIO.m_chkHigh03Click(Sender: TObject);
begin
    m_chkHighClick(3);
end;

procedure TFormDigitalIO.m_chkHigh04Click(Sender: TObject);
begin
    m_chkHighClick(4);
end;

procedure TFormDigitalIO.m_chkHigh05Click(Sender: TObject);
begin
    m_chkHighClick(5);
end;

procedure TFormDigitalIO.m_chkHigh06Click(Sender: TObject);
begin
    m_chkHighClick(6);
end;

procedure TFormDigitalIO.m_chkHigh07Click(Sender: TObject);
begin
    m_chkHighClick(7);
end;

procedure TFormDigitalIO.m_chkHigh08Click(Sender: TObject);
begin
    m_chkHighClick(8);
end;

procedure TFormDigitalIO.m_chkHigh09Click(Sender: TObject);
begin
    m_chkHighClick(9);
end;

procedure TFormDigitalIO.m_chkHigh10Click(Sender: TObject);
begin
    m_chkHighClick(10);
end;

procedure TFormDigitalIO.m_chkHigh11Click(Sender: TObject);
begin
    m_chkHighClick(11);
end;

procedure TFormDigitalIO.m_chkHigh12Click(Sender: TObject);
begin
    m_chkHighClick(12);
end;

procedure TFormDigitalIO.m_chkHigh13Click(Sender: TObject);
begin
    m_chkHighClick(13);
end;

procedure TFormDigitalIO.m_chkHigh14Click(Sender: TObject);
begin
    m_chkHighClick(14);
end;

procedure TFormDigitalIO.m_chkHigh15Click(Sender: TObject);
begin
    m_chkHighClick(15);
end;

procedure TFormDigitalIO.m_chkLow00Click(Sender: TObject);
begin
    m_chkLowClick(0);
end;

procedure TFormDigitalIO.m_chkLow01Click(Sender: TObject);
begin
    m_chkLowClick(1);
end;

procedure TFormDigitalIO.m_chkLow02Click(Sender: TObject);
begin
    m_chkLowClick(2);
end;

procedure TFormDigitalIO.m_chkLow03Click(Sender: TObject);
begin
    m_chkLowClick(3);
end;

procedure TFormDigitalIO.m_chkLow04Click(Sender: TObject);
begin
    m_chkLowClick(4);
end;

procedure TFormDigitalIO.m_chkLow05Click(Sender: TObject);
begin
    m_chkLowClick(5);
end;

procedure TFormDigitalIO.m_chkLow06Click(Sender: TObject);
begin
    m_chkLowClick(6);
end;

procedure TFormDigitalIO.m_chkLow07Click(Sender: TObject);
begin
    m_chkLowClick(7);
end;

procedure TFormDigitalIO.m_chkLow08Click(Sender: TObject);
begin
    m_chkLowClick(8);
end;

procedure TFormDigitalIO.m_chkLow09Click(Sender: TObject);
begin
    m_chkLowClick(9);
end;

procedure TFormDigitalIO.m_chkLow10Click(Sender: TObject);
begin
    m_chkLowClick(10);
end;

procedure TFormDigitalIO.m_chkLow11Click(Sender: TObject);
begin
    m_chkLowClick(11);
end;

procedure TFormDigitalIO.m_chkLow12Click(Sender: TObject);
begin
    m_chkLowClick(12);
end;

procedure TFormDigitalIO.m_chkLow13Click(Sender: TObject);
begin
    m_chkLowClick(13);
end;

procedure TFormDigitalIO.m_chkLow14Click(Sender: TObject);
begin
    m_chkLowClick(14);
end;

procedure TFormDigitalIO.m_chkLow15Click(Sender: TObject);
begin
    m_chkLowClick(15);
end;

procedure TFormDigitalIO.m_btnClearClick(Sender: TObject);
begin
    m_lstInterrupt.Clear();
end;

procedure TFormDigitalIO.m_chkInterruptClick(Sender: TObject);
var
    lModuleCount, lBoardNo, lModulePos: LongInt;
    dwModuleID: DWORD;
begin
    AxdInfoGetModuleCount(@lModuleCount);

    if (lModuleCount > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        case dwModuleID of
            AXT_SIO_DI32, AXT_SIO_DB32P, AXT_SIO_DB32T:
                begin
                    if (m_chkInterrupt.Checked) then
                    begin
                        AxlInterruptEnable();
                        AxdiInterruptSetModuleEnable
                          (m_cbModule.ItemIndex, ENABLE);
                    end
                    else
                    begin
                        AxdiInterruptSetModuleEnable
                          (m_cbModule.ItemIndex, DISABLE);
                        AxdiInterruptSetModule(m_cbModule.ItemIndex,
                            FormDigitalIO.Handle, 0, nil, nil);
                        // Interrupt method release.
                        AxlInterruptDisable();
                    end;
                end;
        Else
            begin
                m_chkInterrupt.Checked := false;
                m_lstInterrupt.Items.Add(
                    'Enable Interrupt button can not be used');
                m_lstInterrupt.Selected[m_lstInterrupt.Count - 1] := true;
            end;
        end;
    end;
end;

procedure TFormDigitalIO.m_chkRigingedgeClick(Sender: TObject);
var
    lModuleCount, lBoardNo, lModulePos: LongInt;
    dwModuleID: DWORD;
begin
    AxdInfoGetModuleCount(@lModuleCount);

    if (lModuleCount > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        case dwModuleID of
            AXT_SIO_DI32:
                begin
                    if (m_chkRigingedge.Checked) then
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, UP_EDGE, $FFFF);
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 1, UP_EDGE, $FFFF);
                    end
                    else
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, UP_EDGE, $0000);
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 1, UP_EDGE, $0000);
                    end;
                end;
            AXT_SIO_DB32P, AXT_SIO_DB32T:
                begin
                    if (m_chkRigingedge.Checked) then
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, UP_EDGE, $FFFF);
                    end
                    else
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, UP_EDGE, $0000);
                    end;
                end;

        Else
            begin
                m_chkRigingedge.Checked := false;
                m_lstInterrupt.Items.Add(
                    'Riging Edge Interrupt button can not be used');
                m_lstInterrupt.Selected[m_lstInterrupt.Count - 1] := true;
            end;
        end;
    end;
end;

procedure TFormDigitalIO.m_chkFallingedgeClick(Sender: TObject);
var
    lModuleCount, lBoardNo, lModulePos: LongInt;
    dwModuleID: DWORD;
begin
    AxdInfoGetModuleCount(@lModuleCount);

    if (lModuleCount > 0) then
    begin
        AxdInfoGetModule(m_cbModule.ItemIndex, @lBoardNo, @lModulePos,
            @dwModuleID);

        case dwModuleID of
            AXT_SIO_DI32:
                begin
                    if (m_chkFallingedge.Checked) then
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, DOWN_EDGE, $FFFF);
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 1, DOWN_EDGE, $FFFF);
                    end
                    else
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, DOWN_EDGE, $0000);
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 1, DOWN_EDGE, $0000);
                    end;
                end;
            AXT_SIO_DB32P, AXT_SIO_DB32T:
                begin
                    if (m_chkFallingedge.Checked) then
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, DOWN_EDGE, $FFFF);
                    end
                    else
                    begin
                        AxdiInterruptEdgeSetWord
                          (m_cbModule.ItemIndex, 0, DOWN_EDGE, $0000);
                    end;
                end;
        Else
            begin
                m_chkFallingedge.Checked := false;
                m_lstInterrupt.Items.Add(
                    'Falling Edge Interrupt button can not be used');
                m_lstInterrupt.Selected[m_lstInterrupt.Count - 1] := true;
            end;
        end;
    end;
end;

procedure TFormDigitalIO.m_rdoMessageClick(Sender: TObject);
begin
    AxdiInterruptSetModule(m_cbModule.ItemIndex, FormDigitalIO.Handle, 0, nil,
        nil); // Interrupt method release.
    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, DISABLE);

    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, ENABLE);
    AxdiInterruptSetModule(m_cbModule.ItemIndex, FormDigitalIO.Handle,
        WM_AXL_INTERRUPT, nil, nil);
end;

// Interrupt message
procedure TFormDigitalIO.OnDIOInterrupt(var Msg: TMessage);
var
    nModule, nIntrFlag: Integer;
    strInt: String;
    dwValue: DWORD;
    i, j: SmallInt;
begin
    nModule := Msg.WParamLo; // Interrupt occurrence module number. ( 0, 1, 2, 3)
    nIntrFlag := Msg.LParam; // Interrupt occurrence Flag (Interrupt occurrence authenticate in Input Port.)

    for i := 0 to 3 do
    begin
        for j := 0 to 7 do
        begin
            if ((((nIntrFlag shr (i * 8)) shr j) and $01) = 1) then
            begin
                AxdiReadInportBit(nModule, ((i * 8) + j), @dwValue);

                if (dwValue = 1) then
                begin
                    strInt := '[Message] °„Rising Int Set Bit ' + IntToStr
                      ((i * 8) + j);
                end
                else
                begin
                    strInt := '[Message] °ÂFalling Int Set Bit ' + IntToStr
                      ((i * 8) + j);
                end;

                m_lstInterrupt.Items.Add(strInt);
                m_lstInterrupt.Selected[m_lstInterrupt.Count - 1] := true;
            end;
        end;
    end;
end;

// Interrupt callback
procedure InterruptCallback(lActiveNo: LongInt; uFlag: DWORD); stdcall;
var
    strInt: String;
    dwValue: DWORD;
    i, j: SmallInt;
begin
    for i := 0 to 3 do
    begin
        for j := 0 to 7 do
        begin
            if ((((uFlag shr (i * 8)) shr j) and $01) = 1) then
            begin
                AxdiReadInportBit(lActiveNo, ((i * 8) + j), @dwValue);

                if (dwValue = 1) then
                begin
                    strInt := '[Callback] °„Rising Int Set Bit ' + IntToStr
                      ((i * 8) + j);
                end
                else
                begin
                    strInt := '[Callback] °ÂFalling Int Set Bit ' + IntToStr
                      ((i * 8) + j);
                end;

                FormDigitalIO.m_lstInterrupt.Items.Add(strInt);
                FormDigitalIO.m_lstInterrupt.Selected
                  [FormDigitalIO.m_lstInterrupt.Count - 1] := true;
            end;
        end;
    end;
end;

procedure TFormDigitalIO.m_rdoCallbackClick(Sender: TObject);
begin
    AxdiInterruptSetModule(m_cbModule.ItemIndex, FormDigitalIO.Handle, 0, nil,
        nil); // Interrupt method release.
    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, DISABLE);

    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, ENABLE);
    AxdiInterruptSetModule(m_cbModule.ItemIndex, 0, 0, InterruptCallback, nil);
end;

procedure TFormDigitalIO.m_rdoEventClick(Sender: TObject);
begin
    AxdiInterruptSetModule(m_cbModule.ItemIndex, FormDigitalIO.Handle, 0, nil,
        nil); // Interrupt method release.
    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, DISABLE);

    AxdiInterruptSetModuleEnable(m_cbModule.ItemIndex, ENABLE);
    AxdiInterruptSetModule(m_cbModule.ItemIndex, 0, 0, nil, @m_hInterrupt);

    if (ThreadFlag <> nil) then
    begin
        m_bThread := false;
        ThreadFlag.Terminate;
        ThreadFlag := nil
    end;

    if (not m_bThread) then
    begin
        m_bThread := true;
        ThreadFlag := TMyThread.Create;
    end;
end;

end.
