object Form1: TForm1
  Left = 2567
  Top = 1079
  BorderIcons = [biSystemMenu]
  Caption = 'StatusMonitor'
  ClientHeight = 525
  ClientWidth = 479
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 12
    Top = 12
    Width = 455
    Height = 30
    TabOrder = 0
    object Label1: TLabel
      Left = 12
      Top = 9
      Width = 93
      Height = 16
      Caption = 'Select Axis No :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboSelAxis: TComboBox
      Left = 108
      Top = 7
      Width = 221
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboSelAxisChange
    end
    object btnLoadFile: TButton
      Left = 333
      Top = 7
      Width = 113
      Height = 20
      Caption = 'Load File'
      TabOrder = 1
      OnClick = btnLoadFileClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 12
    Top = 47
    Width = 455
    Height = 165
    Caption = 'Mechanical Status'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Label2: TLabel
      Left = 31
      Top = 18
      Width = 177
      Height = 16
      Caption = 'Bit 00: Positive End Limit State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 31
      Top = 38
      Width = 184
      Height = 16
      Caption = 'Bit 01: Negative End Limit State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 31
      Top = 58
      Width = 148
      Height = 16
      Caption = 'Bit 04: Alarm Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 31
      Top = 78
      Width = 170
      Height = 16
      Caption = 'Bit 05: Inposition Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label6: TLabel
      Left = 31
      Top = 98
      Width = 182
      Height = 16
      Caption = 'Bit 06: Emergency Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 31
      Top = 118
      Width = 150
      Height = 16
      Caption = 'Bit 07: Home Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label8: TLabel
      Left = 31
      Top = 138
      Width = 163
      Height = 16
      Caption = 'Bit 08: Z Phase Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label9: TLabel
      Left = 249
      Top = 18
      Width = 185
      Height = 16
      Caption = 'Bit 09: Encoder Up Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label10: TLabel
      Left = 249
      Top = 38
      Width = 184
      Height = 16
      Caption = 'Bit 10: Encoder Dn Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label11: TLabel
      Left = 249
      Top = 58
      Width = 186
      Height = 16
      Caption = 'Bit 11: EXPP(MPG) Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label12: TLabel
      Left = 249
      Top = 78
      Width = 188
      Height = 16
      Caption = 'Bit 12: EXMP(MPG) Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label13: TLabel
      Left = 249
      Top = 98
      Width = 170
      Height = 16
      Caption = 'Bit 13: SQSTR 1 Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label14: TLabel
      Left = 249
      Top = 118
      Width = 170
      Height = 16
      Caption = 'Bit 14: SQSTR 2 Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label15: TLabel
      Left = 249
      Top = 138
      Width = 153
      Height = 16
      Caption = 'Bit 17: MODE Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object chkMechBit00: TCheckBox
      Left = 12
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 0
    end
    object chkMechBit01: TCheckBox
      Left = 12
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 1
    end
    object chkMechBit04: TCheckBox
      Left = 12
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 2
    end
    object chkMechBit05: TCheckBox
      Left = 12
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 3
    end
    object chkMechBit06: TCheckBox
      Left = 12
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 4
    end
    object chkMechBit07: TCheckBox
      Left = 12
      Top = 120
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 5
    end
    object chkMechBit08: TCheckBox
      Left = 12
      Top = 140
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 6
    end
    object chkMechBit09: TCheckBox
      Left = 230
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 7
    end
    object chkMechBit10: TCheckBox
      Left = 230
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 8
    end
    object chkMechBit11: TCheckBox
      Left = 230
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 9
    end
    object chkMechBit12: TCheckBox
      Left = 230
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 10
    end
    object chkMechBit13: TCheckBox
      Left = 230
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 11
    end
    object chkMechBit14: TCheckBox
      Left = 230
      Top = 120
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 12
    end
    object chkMechBit17: TCheckBox
      Left = 230
      Top = 140
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 13
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 218
    Width = 455
    Height = 165
    Caption = 'Motion End Status'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label16: TLabel
      Left = 31
      Top = 18
      Width = 179
      Height = 16
      Caption = 'Bit 00: Exit by positive end limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label17: TLabel
      Left = 31
      Top = 38
      Width = 184
      Height = 16
      Caption = 'Bit 01: Exit by negative end limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label18: TLabel
      Left = 31
      Top = 58
      Width = 196
      Height = 16
      Caption = 'Bit 04: Exit by positive SW E-Stop'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label19: TLabel
      Left = 31
      Top = 78
      Width = 201
      Height = 16
      Caption = 'Bit 05: Exit by negative SW E-Stop'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label20: TLabel
      Left = 31
      Top = 98
      Width = 196
      Height = 16
      Caption = 'Bit 06: Exit by positive SW S-Stop'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label21: TLabel
      Left = 31
      Top = 118
      Width = 150
      Height = 16
      Caption = 'Bit 07: Home Signal State'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label22: TLabel
      Left = 31
      Top = 138
      Width = 190
      Height = 16
      Caption = 'Bit 08: Exit by servo alarm signal'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label23: TLabel
      Left = 249
      Top = 18
      Width = 187
      Height = 16
      Caption = 'Bit 09: Exit by emergency signal'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label24: TLabel
      Left = 249
      Top = 38
      Width = 172
      Height = 16
      Caption = 'Bit 10: Exit by EMG stop CMD'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label25: TLabel
      Left = 249
      Top = 58
      Width = 169
      Height = 16
      Caption = 'Bit 11: Exit by slow stop CMD'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label26: TLabel
      Left = 249
      Top = 78
      Width = 151
      Height = 16
      Caption = 'Bit 15: Encoder input error'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label27: TLabel
      Left = 249
      Top = 98
      Width = 200
      Height = 16
      Caption = 'Bit 28: Current/Last move direction'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label28: TLabel
      Left = 249
      Top = 118
      Width = 158
      Height = 16
      Caption = 'Bit 30: Abnormal drive stop'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label29: TLabel
      Left = 249
      Top = 138
      Width = 175
      Height = 16
      Caption = 'Bit 31: Interpolation data error '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object chkEndBit00: TCheckBox
      Left = 12
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 0
    end
    object chkEndBit01: TCheckBox
      Left = 12
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 1
    end
    object chkEndBit04: TCheckBox
      Left = 12
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 2
    end
    object chkEndBit05: TCheckBox
      Left = 12
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 3
    end
    object chkEndBit06: TCheckBox
      Left = 12
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 4
    end
    object chkEndBit07: TCheckBox
      Left = 12
      Top = 120
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 5
    end
    object chkEndBit08: TCheckBox
      Left = 12
      Top = 140
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 6
    end
    object chkEndBit09: TCheckBox
      Left = 230
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 7
    end
    object chkEndBit10: TCheckBox
      Left = 230
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 8
    end
    object chkEndBit11: TCheckBox
      Left = 230
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 9
    end
    object chkEndBit15: TCheckBox
      Left = 230
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 10
    end
    object chkEndBit28: TCheckBox
      Left = 230
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 11
    end
    object chkEndBit30: TCheckBox
      Left = 230
      Top = 120
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 12
    end
    object chkEndBit31: TCheckBox
      Left = 230
      Top = 140
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 13
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 389
    Width = 455
    Height = 124
    Caption = 'Drive Status'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label30: TLabel
      Left = 31
      Top = 18
      Width = 166
      Height = 16
      Caption = 'Bit 00: BUSY (In drive move)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label31: TLabel
      Left = 31
      Top = 38
      Width = 180
      Height = 16
      Caption = 'Bit 01: DOWN (In deceleration)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label32: TLabel
      Left = 31
      Top = 58
      Width = 201
      Height = 16
      Caption = 'Bit 02: CONST (In constant speed)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label33: TLabel
      Left = 31
      Top = 78
      Width = 155
      Height = 16
      Caption = 'Bit 03: UP (in acceleration)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label34: TLabel
      Left = 31
      Top = 98
      Width = 199
      Height = 16
      Caption = 'Bit 04: In move of continuous drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label37: TLabel
      Left = 249
      Top = 18
      Width = 191
      Height = 16
      Caption = 'Bit 05: In move of assigned drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label38: TLabel
      Left = 249
      Top = 38
      Width = 165
      Height = 16
      Caption = 'Bit 06: In move of MPG drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label39: TLabel
      Left = 249
      Top = 58
      Width = 169
      Height = 16
      Caption = 'Bit 07: In move of home drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label40: TLabel
      Left = 249
      Top = 78
      Width = 168
      Height = 16
      Caption = 'Bit 10: In move of slave drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label41: TLabel
      Left = 249
      Top = 98
      Width = 175
      Height = 16
      Caption = 'Bit 11: Direction of motor drive'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object chkDriveBit00: TCheckBox
      Left = 12
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 0
    end
    object chkDriveBit01: TCheckBox
      Left = 12
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 1
    end
    object chkDriveBit02: TCheckBox
      Left = 12
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 2
    end
    object chkDriveBit03: TCheckBox
      Left = 12
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 3
    end
    object chkDriveBit04: TCheckBox
      Left = 12
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 4
    end
    object chkDriveBit05: TCheckBox
      Left = 230
      Top = 20
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 5
    end
    object chkDriveBit06: TCheckBox
      Left = 230
      Top = 40
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 6
    end
    object chkDriveBit07: TCheckBox
      Left = 230
      Top = 60
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 7
    end
    object chkDriveBit10: TCheckBox
      Left = 230
      Top = 80
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 8
    end
    object chkDriveBit11: TCheckBox
      Left = 230
      Top = 100
      Width = 15
      Height = 14
      Enabled = False
      TabOrder = 9
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 437
    Top = 12
  end
  object m_timer: TTimer
    Interval = 100
    OnTimer = m_timerTimer
  end
end
