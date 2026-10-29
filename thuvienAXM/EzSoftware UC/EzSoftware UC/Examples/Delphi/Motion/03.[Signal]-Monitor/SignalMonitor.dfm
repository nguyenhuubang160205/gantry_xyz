object Form1: TForm1
  Left = 2586
  Top = 1348
  BorderIcons = [biSystemMenu]
  Caption = 'SignalMonitor'
  ClientHeight = 491
  ClientWidth = 479
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
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
    end
  end
  object GroupBox2: TGroupBox
    Left = 12
    Top = 46
    Width = 455
    Height = 96
    Caption = '< Input Signal Monitor >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Shape1: TShape
      Left = 227
      Top = 18
      Width = 3
      Height = 68
    end
    object cboZPhase: TComboBox
      Left = 108
      Top = 18
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboZPhaseChange
    end
    object cboAlarm: TComboBox
      Left = 108
      Top = 42
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      OnChange = cboAlarmChange
    end
    object cboELimitN: TComboBox
      Left = 108
      Top = 66
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      OnChange = cboELimitNChange
    end
    object chkZPhase: TCheckBox
      Left = 12
      Top = 20
      Width = 96
      Height = 16
      Caption = 'Z Phase       :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object cboInp: TComboBox
      Left = 333
      Top = 18
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      OnChange = cboInpChange
    end
    object chkAlarm: TCheckBox
      Left = 12
      Top = 44
      Width = 96
      Height = 16
      Caption = 'Servo Alarm:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 5
    end
    object chkELimitN: TCheckBox
      Left = 12
      Top = 68
      Width = 96
      Height = 16
      Caption = '(-) End Limit :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
    end
    object chkInp: TCheckBox
      Left = 237
      Top = 20
      Width = 95
      Height = 16
      Caption = 'Inposition   :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 7
    end
    object cboEmg: TComboBox
      Left = 333
      Top = 42
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
      OnChange = cboEmgChange
    end
    object cboELimitP: TComboBox
      Left = 333
      Top = 66
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 9
      OnChange = cboELimitPChange
    end
    object chkEmg: TCheckBox
      Left = 237
      Top = 44
      Width = 95
      Height = 16
      Caption = 'Emergency  :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 10
    end
    object chkELimitP: TCheckBox
      Left = 237
      Top = 68
      Width = 95
      Height = 16
      Caption = '(+) End Limit :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 11
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 148
    Width = 455
    Height = 46
    Caption = '< Output Signal Monitor >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Shape2: TShape
      Left = 227
      Top = 18
      Width = 3
      Height = 20
    end
    object Label2: TLabel
      Left = 10
      Top = 21
      Width = 98
      Height = 16
      Caption = 'Servo On Level :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 235
      Top = 21
      Width = 104
      Height = 16
      Caption = 'Alm Reset Level::'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboServoOn: TComboBox
      Left = 108
      Top = 18
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboServoOnChange
    end
    object cboAlarmReset: TComboBox
      Left = 333
      Top = 18
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      OnChange = cboAlarmResetChange
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 200
    Width = 455
    Height = 141
    Caption = '< Input Signal Monitor >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Shape3: TShape
      Left = 227
      Top = 18
      Width = 3
      Height = 110
    end
    object chkInp00: TCheckBox
      Left = 12
      Top = 20
      Width = 176
      Height = 20
      Caption = 'Input Bit 00 (Origin Sensor)'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object chkInp01: TCheckBox
      Left = 12
      Top = 43
      Width = 149
      Height = 20
      Caption = 'Input Bit 01 (Z-Phase)'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
    end
    object chkInp02: TCheckBox
      Left = 12
      Top = 66
      Width = 85
      Height = 20
      Caption = 'Input Bit 02'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
    end
    object chkInp03: TCheckBox
      Left = 12
      Top = 89
      Width = 85
      Height = 20
      Caption = 'Input Bit 03'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object chkInp04: TCheckBox
      Left = 12
      Top = 112
      Width = 85
      Height = 20
      Caption = 'Input Bit 04'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 4
    end
    object chkOut00: TCheckBox
      Left = 237
      Top = 20
      Width = 207
      Height = 20
      Caption = 'Output Bit 00 (Servo On)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 5
      OnClick = chkOut00Click
    end
    object chkOut01: TCheckBox
      Left = 237
      Top = 43
      Width = 207
      Height = 20
      Caption = 'Output Bit 01 (Alarm Clear)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
      OnClick = chkOut01Click
    end
    object chkOut02: TCheckBox
      Left = 237
      Top = 66
      Width = 207
      Height = 20
      Caption = 'Output Bit 02'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 7
      OnClick = chkOut02Click
    end
    object chkOut03: TCheckBox
      Left = 237
      Top = 89
      Width = 207
      Height = 20
      Caption = 'Output Bit 03'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 8
      OnClick = chkOut03Click
    end
    object chkOut04: TCheckBox
      Left = 237
      Top = 112
      Width = 207
      Height = 20
      Caption = 'Output Bit 04'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 9
      OnClick = chkOut04Click
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 347
    Width = 455
    Height = 134
    Caption = '< Software Limit >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Shape4: TShape
      Left = 227
      Top = 18
      Width = 3
      Height = 70
    end
    object Label4: TLabel
      Left = 10
      Top = 45
      Width = 96
      Height = 16
      Caption = 'Stop Mode         :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 235
      Top = 45
      Width = 96
      Height = 16
      Caption = 'Reference Pos :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label6: TLabel
      Left = 10
      Top = 73
      Width = 95
      Height = 16
      Caption = '(-) Soft EndPos :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 235
      Top = 73
      Width = 98
      Height = 16
      Caption = '(+) Soft EndPos :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object chkSWLimitN: TCheckBox
      Left = 12
      Top = 20
      Width = 176
      Height = 20
      Caption = '(-) Software End Limit'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object chkSWLimitP: TCheckBox
      Left = 237
      Top = 20
      Width = 207
      Height = 20
      Caption = '(+) Software End Limit'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
    end
    object cboSWStop: TComboBox
      Left = 108
      Top = 42
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object cboSWRef: TComboBox
      Left = 333
      Top = 42
      Width = 111
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object edtSWPosN: TEdit
      Left = 108
      Top = 68
      Width = 111
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
    end
    object edtSWPosP: TEdit
      Left = 333
      Top = 68
      Width = 111
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
    end
    object chkSWEnable: TCheckBox
      Left = 192
      Top = 96
      Width = 80
      Height = 25
      Caption = 'Enable'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -17
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
      OnClick = chkSWEnableClick
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
