object frmManualSet: TfrmManualSet
  Left = 403
  Top = 148
  BorderStyle = bsDialog
  Caption = 'Manual Set'
  ClientHeight = 163
  ClientWidth = 512
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object btnCmd: TButton
    Left = 10
    Top = 13
    Width = 65
    Height = 26
    Caption = 'CMD'
    TabOrder = 0
    OnClick = btnCmdClick
  end
  object btnRd: TButton
    Left = 10
    Top = 42
    Width = 65
    Height = 26
    Caption = 'RD'
    TabOrder = 1
    OnClick = btnRdClick
  end
  object btnWr: TButton
    Left = 80
    Top = 42
    Width = 65
    Height = 26
    Caption = 'WR'
    TabOrder = 2
    OnClick = btnWrClick
  end
  object edtCmd: TEdit
    Left = 80
    Top = 13
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 3
  end
  object edtData: TEdit
    Left = 152
    Top = 13
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 4
  end
  object cboPort: TComboBox
    Left = 152
    Top = 48
    Width = 104
    Height = 21
    Style = csDropDownList
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    TabOrder = 5
    Items.Strings = (
      'DATAPL0'
      'DATAPL1'
      'DATAPM0'
      'DATAPM1'
      'CMDP0'
      'CMDP1'
      'UIOP0'
      'UIOP1')
  end
  object chkHex: TCheckBox
    Left = 264
    Top = 16
    Width = 65
    Height = 17
    Caption = 'Hex/Dec'
    TabOrder = 6
  end
  object cboAxisSel: TComboBox
    Left = 330
    Top = 13
    Width = 176
    Height = 21
    Style = csDropDownList
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    TabOrder = 7
    OnChange = cboAxisSelChange
  end
  object chkOnOff1: TCheckBox
    Left = 11
    Top = 78
    Width = 54
    Height = 17
    Caption = 'On/Off'
    TabOrder = 8
    OnClick = chkOnOff1Click
  end
  object chkOnOff2: TCheckBox
    Left = 11
    Top = 107
    Width = 54
    Height = 17
    Caption = 'On/Off'
    TabOrder = 9
  end
  object chkOnOff3: TCheckBox
    Left = 11
    Top = 135
    Width = 57
    Height = 17
    Caption = 'On/Off'
    TabOrder = 10
  end
  object edtCmd1: TEdit
    Left = 80
    Top = 76
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 11
  end
  object edtCmd2: TEdit
    Left = 80
    Top = 105
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 12
  end
  object edtCmd3: TEdit
    Left = 80
    Top = 133
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 13
  end
  object edtData1: TEdit
    Left = 152
    Top = 76
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 14
  end
  object edtData2: TEdit
    Left = 152
    Top = 105
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 15
  end
  object edtData3: TEdit
    Left = 152
    Top = 133
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 16
  end
  object chkOnOff4: TCheckBox
    Left = 264
    Top = 78
    Width = 57
    Height = 17
    Caption = 'On/Off'
    TabOrder = 17
  end
  object chkOnOff5: TCheckBox
    Left = 264
    Top = 106
    Width = 57
    Height = 25
    Caption = 'On/Off'
    TabOrder = 18
  end
  object chkOnOff6: TCheckBox
    Left = 264
    Top = 135
    Width = 57
    Height = 17
    Caption = 'On/Off'
    TabOrder = 19
  end
  object edtCmd4: TEdit
    Left = 330
    Top = 76
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 20
  end
  object edtCmd5: TEdit
    Left = 330
    Top = 105
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 21
  end
  object edtCmd6: TEdit
    Left = 330
    Top = 132
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 22
  end
  object edtData4: TEdit
    Left = 402
    Top = 76
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 23
  end
  object edtData5: TEdit
    Left = 402
    Top = 105
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 24
  end
  object edtData6: TEdit
    Left = 402
    Top = 132
    Width = 102
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 25
  end
  object tmMonitor: TTimer
    Enabled = False
    Interval = 100
    OnTimer = tmMonitorTimer
    Left = 476
    Top = 40
  end
end
