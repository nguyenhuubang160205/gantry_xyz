object FormAnalogInput: TFormAnalogInput
  Left = 1228
  Top = 258
  Width = 626
  Height = 330
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
    Left = 16
    Top = 40
    Width = 45
    Height = 13
    Caption = '[Channel]'
  end
  object Label3: TLabel
    Left = 80
    Top = 40
    Width = 77
    Height = 13
    Caption = '[Voltage Range]'
  end
  object Label5: TLabel
    Left = 400
    Top = 112
    Width = 65
    Height = 13
    Caption = '[Data Length]'
  end
  object Label4: TLabel
    Left = 216
    Top = 40
    Width = 45
    Height = 13
    Caption = '[Channel]'
  end
  object Label6: TLabel
    Left = 280
    Top = 40
    Width = 77
    Height = 13
    Caption = '[Voltage Range]'
  end
  object m_cbModulenum: TComboBox
    Left = 112
    Top = 8
    Width = 169
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 0
  end
  object m_chkChannel0: TCheckBox
    Left = 16
    Top = 56
    Width = 49
    Height = 17
    Caption = 'CH0'
    TabOrder = 1
  end
  object m_chkChannel1: TCheckBox
    Left = 16
    Top = 80
    Width = 49
    Height = 17
    Caption = 'CH1'
    TabOrder = 2
  end
  object m_chkChannel2: TCheckBox
    Left = 16
    Top = 104
    Width = 49
    Height = 17
    Caption = 'CH2'
    TabOrder = 3
  end
  object m_chkChannel3: TCheckBox
    Left = 16
    Top = 128
    Width = 49
    Height = 17
    Caption = 'CH3'
    TabOrder = 4
  end
  object m_cbVoltagerange0: TComboBox
    Left = 72
    Top = 56
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 5
  end
  object m_cbVoltagerange1: TComboBox
    Left = 72
    Top = 80
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 6
  end
  object m_cbVoltagerange2: TComboBox
    Left = 72
    Top = 104
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 7
  end
  object m_cbVoltagerange3: TComboBox
    Left = 72
    Top = 128
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 8
  end
  object m_edtLength: TEdit
    Left = 392
    Top = 128
    Width = 81
    Height = 21
    ImeName = 'Microsoft IME 2003'
    TabOrder = 9
    Text = '1000'
  end
  object Button1: TButton
    Left = 488
    Top = 48
    Width = 113
    Height = 49
    Caption = 'Exit(&X)'
    TabOrder = 10
    OnClick = Button1Click
  end
  object m_btnStart: TButton
    Left = 488
    Top = 104
    Width = 113
    Height = 49
    Caption = 'Start(&S)'
    TabOrder = 11
    OnClick = m_btnStartClick
  end
  object m_lstAIData: TStringGrid
    Left = 16
    Top = 160
    Width = 593
    Height = 137
    ColCount = 9
    TabOrder = 12
  end
  object m_chkChannel4: TCheckBox
    Left = 216
    Top = 56
    Width = 49
    Height = 17
    Caption = 'CH4'
    TabOrder = 13
  end
  object m_chkChannel5: TCheckBox
    Left = 216
    Top = 80
    Width = 49
    Height = 17
    Caption = 'CH5'
    TabOrder = 14
  end
  object m_chkChannel6: TCheckBox
    Left = 216
    Top = 104
    Width = 49
    Height = 17
    Caption = 'CH6'
    TabOrder = 15
  end
  object m_chkChannel7: TCheckBox
    Left = 216
    Top = 128
    Width = 49
    Height = 17
    Caption = 'CH7'
    TabOrder = 16
  end
  object m_cbVoltagerange4: TComboBox
    Left = 272
    Top = 56
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 17
  end
  object m_cbVoltagerange5: TComboBox
    Left = 272
    Top = 80
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 18
  end
  object m_cbVoltagerange6: TComboBox
    Left = 272
    Top = 104
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 19
  end
  object m_cbVoltagerange7: TComboBox
    Left = 272
    Top = 128
    Width = 97
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 20
  end
end
