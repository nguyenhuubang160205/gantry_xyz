object Form1: TForm1
  Left = 1240
  Top = 245
  Caption = 'DigitalIO'
  ClientHeight = 406
  ClientWidth = 376
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
  object Label1: TLabel
    Left = 16
    Top = 16
    Width = 118
    Height = 13
    Caption = '[Bo. No.:Mo. No.] Mo.ID '
  end
  object m_cbModule: TComboBox
    Left = 160
    Top = 8
    Width = 193
    Height = 21
    Style = csDropDownList
    ImeName = 'Microsoft IME 2003'
    TabOrder = 0
    OnChange = m_cbModuleChange
  end
  object RadioGroup1: TRadioGroup
    Left = 24
    Top = 72
    Width = 337
    Height = 41
    Caption = 'Interrupt'
    TabOrder = 2
  end
  object m_rdoMessage: TRadioButton
    Left = 40
    Top = 88
    Width = 73
    Height = 17
    Caption = 'Message'
    Enabled = False
    TabOrder = 4
    OnClick = m_rdoMessageClick
  end
  object m_rdoCallback: TRadioButton
    Left = 152
    Top = 88
    Width = 73
    Height = 17
    Caption = 'Callback'
    Enabled = False
    TabOrder = 5
    OnClick = m_rdoCallbackClick
  end
  object m_rdoEvent: TRadioButton
    Left = 264
    Top = 88
    Width = 65
    Height = 17
    Caption = 'Event'
    Enabled = False
    TabOrder = 6
    OnClick = m_rdoEventClick
  end
  object m_stcHIGH: TGroupBox
    Left = 24
    Top = 120
    Width = 337
    Height = 65
    TabOrder = 1
    object m_chkHigh00: TCheckBox
      Left = 8
      Top = 16
      Width = 41
      Height = 17
      Caption = '00'
      TabOrder = 0
      OnClick = m_chkHighClick
    end
    object m_chkHigh01: TCheckBox
      Tag = 1
      Left = 48
      Top = 16
      Width = 41
      Height = 17
      Caption = '01'
      TabOrder = 1
      OnClick = m_chkHighClick
    end
    object m_chkHigh02: TCheckBox
      Tag = 2
      Left = 88
      Top = 16
      Width = 41
      Height = 17
      Caption = '02'
      TabOrder = 2
      OnClick = m_chkHighClick
    end
    object m_chkHigh03: TCheckBox
      Tag = 3
      Left = 128
      Top = 16
      Width = 41
      Height = 17
      Caption = '03'
      TabOrder = 3
      OnClick = m_chkHighClick
    end
    object m_chkHigh04: TCheckBox
      Tag = 4
      Left = 168
      Top = 16
      Width = 41
      Height = 17
      Caption = '04'
      TabOrder = 4
      OnClick = m_chkHighClick
    end
    object m_chkHigh05: TCheckBox
      Tag = 5
      Left = 208
      Top = 16
      Width = 41
      Height = 17
      Caption = '05'
      TabOrder = 5
      OnClick = m_chkHighClick
    end
    object m_chkHigh06: TCheckBox
      Tag = 6
      Left = 248
      Top = 16
      Width = 41
      Height = 17
      Caption = '06'
      TabOrder = 6
      OnClick = m_chkHighClick
    end
    object m_chkHigh07: TCheckBox
      Tag = 7
      Left = 288
      Top = 16
      Width = 41
      Height = 17
      Caption = '07'
      TabOrder = 7
      OnClick = m_chkHighClick
    end
    object m_chkHigh08: TCheckBox
      Tag = 8
      Left = 8
      Top = 40
      Width = 41
      Height = 17
      Caption = '08'
      TabOrder = 8
      OnClick = m_chkHighClick
    end
    object m_chkHigh09: TCheckBox
      Tag = 9
      Left = 48
      Top = 40
      Width = 41
      Height = 17
      Caption = '09'
      TabOrder = 9
      OnClick = m_chkHighClick
    end
    object m_chkHigh15: TCheckBox
      Tag = 15
      Left = 288
      Top = 40
      Width = 41
      Height = 17
      Caption = '15'
      TabOrder = 15
      OnClick = m_chkHighClick
    end
    object m_chkHigh14: TCheckBox
      Tag = 14
      Left = 248
      Top = 40
      Width = 41
      Height = 17
      Caption = '14'
      TabOrder = 14
      OnClick = m_chkHighClick
    end
    object m_chkHigh13: TCheckBox
      Tag = 13
      Left = 208
      Top = 40
      Width = 41
      Height = 17
      Caption = '13'
      TabOrder = 13
      OnClick = m_chkHighClick
    end
    object m_chkHigh12: TCheckBox
      Tag = 12
      Left = 168
      Top = 40
      Width = 41
      Height = 17
      Caption = '12'
      TabOrder = 12
      OnClick = m_chkHighClick
    end
    object m_chkHigh11: TCheckBox
      Tag = 11
      Left = 128
      Top = 40
      Width = 41
      Height = 17
      Caption = '11'
      TabOrder = 11
      OnClick = m_chkHighClick
    end
    object m_chkHigh10: TCheckBox
      Tag = 10
      Left = 88
      Top = 40
      Width = 41
      Height = 17
      Caption = '10'
      TabOrder = 10
      OnClick = m_chkHighClick
    end
  end
  object m_stcLOW: TGroupBox
    Left = 24
    Top = 192
    Width = 337
    Height = 65
    TabOrder = 3
    object m_chkLow10: TCheckBox
      Tag = 10
      Left = 88
      Top = 40
      Width = 41
      Height = 17
      Caption = '10'
      TabOrder = 10
      OnClick = m_chkLowClick
    end
    object m_chkLow08: TCheckBox
      Tag = 8
      Left = 8
      Top = 40
      Width = 41
      Height = 17
      Caption = '08'
      TabOrder = 8
      OnClick = m_chkLowClick
    end
    object m_chkLow07: TCheckBox
      Tag = 7
      Left = 288
      Top = 16
      Width = 41
      Height = 17
      Caption = '07'
      TabOrder = 7
      OnClick = m_chkLowClick
    end
    object m_chkLow06: TCheckBox
      Tag = 6
      Left = 248
      Top = 16
      Width = 41
      Height = 17
      Caption = '06'
      TabOrder = 6
      OnClick = m_chkLowClick
    end
    object m_chkLow05: TCheckBox
      Tag = 5
      Left = 208
      Top = 16
      Width = 41
      Height = 17
      Caption = '05'
      TabOrder = 5
      OnClick = m_chkLowClick
    end
    object m_chkLow04: TCheckBox
      Tag = 4
      Left = 168
      Top = 16
      Width = 41
      Height = 17
      Caption = '04'
      TabOrder = 4
      OnClick = m_chkLowClick
    end
    object m_chkLow03: TCheckBox
      Tag = 3
      Left = 128
      Top = 16
      Width = 41
      Height = 17
      Caption = '03'
      TabOrder = 3
      OnClick = m_chkLowClick
    end
    object m_chkLow02: TCheckBox
      Tag = 2
      Left = 88
      Top = 16
      Width = 41
      Height = 17
      Caption = '02'
      TabOrder = 2
      OnClick = m_chkLowClick
    end
    object m_chkLow01: TCheckBox
      Tag = 1
      Left = 48
      Top = 16
      Width = 41
      Height = 17
      Caption = '01'
      TabOrder = 1
      OnClick = m_chkLowClick
    end
    object m_chkLow15: TCheckBox
      Tag = 15
      Left = 288
      Top = 40
      Width = 41
      Height = 17
      Caption = '15'
      TabOrder = 15
      OnClick = m_chkLowClick
    end
    object m_chkLow14: TCheckBox
      Tag = 14
      Left = 248
      Top = 40
      Width = 41
      Height = 17
      Caption = '14'
      TabOrder = 14
      OnClick = m_chkLowClick
    end
    object m_chkLow13: TCheckBox
      Tag = 13
      Left = 208
      Top = 40
      Width = 41
      Height = 17
      Caption = '13'
      TabOrder = 13
      OnClick = m_chkLowClick
    end
    object m_chkLow12: TCheckBox
      Tag = 12
      Left = 168
      Top = 40
      Width = 41
      Height = 17
      Caption = '12'
      TabOrder = 12
      OnClick = m_chkLowClick
    end
    object m_chkLow11: TCheckBox
      Tag = 11
      Left = 128
      Top = 40
      Width = 41
      Height = 17
      Caption = '11'
      TabOrder = 11
      OnClick = m_chkLowClick
    end
    object m_chkLow09: TCheckBox
      Tag = 9
      Left = 48
      Top = 40
      Width = 41
      Height = 17
      Caption = '09'
      TabOrder = 9
      OnClick = m_chkLowClick
    end
    object m_chkLow00: TCheckBox
      Left = 8
      Top = 16
      Width = 41
      Height = 17
      Caption = '00'
      TabOrder = 0
      OnClick = m_chkLowClick
    end
  end
  object m_btnClear: TButton
    Left = 24
    Top = 376
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 7
    OnClick = m_btnClearClick
  end
  object m_btnClose: TButton
    Left = 280
    Top = 376
    Width = 75
    Height = 25
    Caption = 'Exit'
    TabOrder = 8
    OnClick = m_btnCloseClick
  end
  object m_lstInterrupt: TListBox
    Left = 24
    Top = 264
    Width = 337
    Height = 105
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 9
  end
  object m_chkRising: TCheckBox
    Left = 120
    Top = 40
    Width = 81
    Height = 25
    Caption = 'Riging Edge'
    Enabled = False
    TabOrder = 10
    OnClick = m_chkRisingClick
  end
  object m_chkFalling: TCheckBox
    Left = 224
    Top = 40
    Width = 81
    Height = 25
    Caption = 'Falling Edge'
    Enabled = False
    TabOrder = 11
    OnClick = m_chkFallingClick
  end
  object m_chkInterrupt: TCheckBox
    Left = 24
    Top = 40
    Width = 73
    Height = 25
    Caption = 'Interrupt'
    Enabled = False
    TabOrder = 12
    OnClick = m_chkInterruptClick
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 100
    OnTimer = Timer1Timer
    Left = 336
    Top = 40
  end
end
