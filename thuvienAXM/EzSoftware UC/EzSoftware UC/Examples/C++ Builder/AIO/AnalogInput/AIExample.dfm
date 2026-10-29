object FormAnalogInput: TFormAnalogInput
  Left = 1037
  Top = 237
  Width = 652
  Height = 373
  Caption = 'AnalogInput'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = Button1Click
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 8
    Width = 87
    Height = 13
    Caption = 'Select AI Module :'
  end
  object Label2: TLabel
    Left = 24
    Top = 40
    Width = 45
    Height = 13
    Caption = '[Channel]'
  end
  object Label3: TLabel
    Left = 88
    Top = 40
    Width = 77
    Height = 13
    Caption = '[Voltage Range]'
  end
  object Label4: TLabel
    Left = 280
    Top = 40
    Width = 45
    Height = 13
    Caption = '[Channel]'
  end
  object Label5: TLabel
    Left = 344
    Top = 40
    Width = 77
    Height = 13
    Caption = '[Voltage Range]'
  end
  object m_cbModulenum: TComboBox
    Left = 112
    Top = 8
    Width = 201
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 0
  end
  object m_chkChannel1: TCheckBox
    Left = 24
    Top = 56
    Width = 49
    Height = 17
    Caption = 'CH0'
    TabOrder = 1
  end
  object m_chkChannel2: TCheckBox
    Left = 24
    Top = 80
    Width = 49
    Height = 17
    Caption = 'CH1'
    TabOrder = 2
  end
  object m_chkChannel3: TCheckBox
    Left = 24
    Top = 104
    Width = 49
    Height = 17
    Caption = 'CH2'
    TabOrder = 3
  end
  object m_chkChannel4: TCheckBox
    Left = 24
    Top = 128
    Width = 49
    Height = 17
    Caption = 'CH3'
    TabOrder = 4
  end
  object m_cbVoltagerange1: TComboBox
    Left = 80
    Top = 56
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 9
  end
  object m_cbVoltagerange2: TComboBox
    Left = 80
    Top = 80
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 10
  end
  object m_cbVoltagerange3: TComboBox
    Left = 80
    Top = 104
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 11
  end
  object m_cbVoltagerange4: TComboBox
    Left = 80
    Top = 128
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 12
  end
  object Button1: TButton
    Left = 528
    Top = 8
    Width = 81
    Height = 25
    Caption = 'Exit(&X)'
    TabOrder = 17
    OnClick = Button1Click
  end
  object m_btnStart: TButton
    Left = 528
    Top = 56
    Width = 81
    Height = 89
    Caption = 'Start(&S)'
    TabOrder = 18
    OnClick = m_btnStartClick
  end
  object m_lstAIData: TStringGrid
    Left = 16
    Top = 160
    Width = 617
    Height = 169
    ColCount = 9
    TabOrder = 19
  end
  object m_chkChannel5: TCheckBox
    Left = 280
    Top = 56
    Width = 49
    Height = 17
    Caption = 'CH5'
    TabOrder = 5
  end
  object m_chkChannel6: TCheckBox
    Left = 280
    Top = 80
    Width = 49
    Height = 17
    Caption = 'CH6'
    TabOrder = 6
  end
  object m_chkChannel7: TCheckBox
    Left = 280
    Top = 104
    Width = 49
    Height = 17
    Caption = 'CH7'
    TabOrder = 7
  end
  object m_chkChannel8: TCheckBox
    Left = 280
    Top = 128
    Width = 49
    Height = 17
    Caption = 'CH8'
    TabOrder = 8
  end
  object m_cbVoltagerange5: TComboBox
    Left = 336
    Top = 56
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 13
  end
  object m_cbVoltagerange6: TComboBox
    Left = 336
    Top = 80
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 14
  end
  object m_cbVoltagerange7: TComboBox
    Left = 336
    Top = 104
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 15
  end
  object m_cbVoltagerange8: TComboBox
    Left = 336
    Top = 128
    Width = 145
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 16
  end
end
