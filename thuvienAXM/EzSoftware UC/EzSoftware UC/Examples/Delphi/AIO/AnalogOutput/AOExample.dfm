object FormAnalogOutput: TFormAnalogOutput
  Left = 1327
  Top = 625
  Width = 475
  Height = 262
  Caption = 'AOExample'
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
  object Label6: TLabel
    Left = 16
    Top = 8
    Width = 92
    Height = 13
    Caption = 'Select AO Module :'
  end
  object Label7: TLabel
    Left = 16
    Top = 40
    Width = 36
    Height = 13
    Caption = '[Ch No]'
  end
  object Label8: TLabel
    Left = 64
    Top = 40
    Width = 58
    Height = 13
    Caption = '[Module No]'
  end
  object Label9: TLabel
    Left = 128
    Top = 40
    Width = 55
    Height = 13
    Caption = '[Module ID]'
  end
  object Label10: TLabel
    Left = 200
    Top = 40
    Width = 35
    Height = 13
    Caption = '[Wave]'
  end
  object Label11: TLabel
    Left = 264
    Top = 40
    Width = 36
    Height = 13
    Caption = '[Period]'
  end
  object Label12: TLabel
    Left = 328
    Top = 40
    Width = 48
    Height = 13
    Caption = '[V Range]'
  end
  object Label13: TLabel
    Left = 400
    Top = 40
    Width = 24
    Height = 13
    Caption = '[Volt]'
  end
  object m_stcModulenum0: TLabel
    Left = 88
    Top = 64
    Width = 12
    Height = 13
    Caption = '00'
  end
  object m_stcModulenum1: TLabel
    Left = 88
    Top = 88
    Width = 12
    Height = 13
    Caption = '00'
  end
  object m_stcModulenum2: TLabel
    Left = 88
    Top = 112
    Width = 12
    Height = 13
    Caption = '00'
  end
  object m_stcModulenum3: TLabel
    Left = 88
    Top = 136
    Width = 12
    Height = 13
    Caption = '00'
  end
  object m_stcModuleid0: TLabel
    Left = 136
    Top = 64
    Width = 19
    Height = 13
    Caption = 'A2h'
  end
  object m_stcModuleid1: TLabel
    Left = 136
    Top = 88
    Width = 19
    Height = 13
    Caption = 'A2h'
  end
  object m_stcModuleid2: TLabel
    Left = 136
    Top = 112
    Width = 19
    Height = 13
    Caption = 'A2h'
  end
  object m_stcModuleid3: TLabel
    Left = 136
    Top = 136
    Width = 19
    Height = 13
    Caption = 'A2h'
  end
  object Label2: TLabel
    Left = 328
    Top = 8
    Width = 41
    Height = 13
    Caption = '[Interval]'
  end
  object m_btnClose: TButton
    Left = 368
    Top = 184
    Width = 75
    Height = 25
    Caption = 'Exit(&X)'
    TabOrder = 0
    OnClick = m_btnCloseClick
  end
  object m_cbModulenum: TComboBox
    Left = 112
    Top = 8
    Width = 169
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 1
    OnChange = m_cbModulenumChange
  end
  object m_chkChannel0: TCheckBox
    Left = 16
    Top = 64
    Width = 49
    Height = 17
    Caption = 'CH0'
    TabOrder = 2
  end
  object m_chkChannel1: TCheckBox
    Left = 16
    Top = 88
    Width = 49
    Height = 17
    Caption = 'CH1'
    TabOrder = 3
  end
  object m_chkChannel2: TCheckBox
    Left = 16
    Top = 112
    Width = 49
    Height = 17
    Caption = 'CH2'
    TabOrder = 4
  end
  object m_chkChannel3: TCheckBox
    Left = 16
    Top = 136
    Width = 49
    Height = 17
    Caption = 'CH3'
    TabOrder = 5
  end
  object m_cbWave0: TComboBox
    Left = 176
    Top = 64
    Width = 73
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 6
    Text = 'Sin'
  end
  object m_cbWave1: TComboBox
    Left = 176
    Top = 88
    Width = 73
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 7
    Text = 'Sin'
  end
  object m_cbWave2: TComboBox
    Left = 176
    Top = 112
    Width = 73
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 8
    Text = 'Sin'
  end
  object m_cbWave3: TComboBox
    Left = 176
    Top = 136
    Width = 73
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 9
    Text = 'Sin'
  end
  object m_edtPeriod0: TEdit
    Left = 256
    Top = 64
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    TabOrder = 10
    Text = '100'
  end
  object m_edtPeriod1: TEdit
    Left = 256
    Top = 88
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    TabOrder = 11
    Text = '100'
  end
  object m_edtPeriod2: TEdit
    Left = 256
    Top = 112
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    TabOrder = 12
    Text = '100'
  end
  object m_edtPeriod3: TEdit
    Left = 256
    Top = 136
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    TabOrder = 13
    Text = '100'
  end
  object m_cbVRange0: TComboBox
    Left = 312
    Top = 64
    Width = 73
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 14
    Text = ' -10 ~  10'
    OnChange = m_cbVRange0Change
  end
  object m_cbVRange1: TComboBox
    Left = 312
    Top = 88
    Width = 73
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 15
    Text = ' -10 ~  10'
    OnChange = m_cbVRange1Change
  end
  object m_cbVRange2: TComboBox
    Left = 312
    Top = 112
    Width = 73
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 16
    Text = ' -10 ~  10'
    OnChange = m_cbVRange2Change
  end
  object m_cbVRange3: TComboBox
    Left = 312
    Top = 136
    Width = 73
    Height = 21
    DropDownCount = 0
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 17
    Text = ' -10 ~  10'
    OnChange = m_cbVRange3Change
  end
  object m_edtValtage0: TEdit
    Left = 392
    Top = 64
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ReadOnly = True
    TabOrder = 18
    Text = '0'
    OnChange = m_edtValtage0Change
  end
  object m_edtValtage1: TEdit
    Left = 392
    Top = 88
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ReadOnly = True
    TabOrder = 19
    Text = '0'
    OnChange = m_edtValtage1Change
  end
  object m_edtValtage2: TEdit
    Left = 392
    Top = 112
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ReadOnly = True
    TabOrder = 20
    Text = '0'
    OnChange = m_edtValtage2Change
  end
  object m_edtValtage3: TEdit
    Left = 392
    Top = 136
    Width = 49
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ReadOnly = True
    TabOrder = 21
    Text = '0'
    OnChange = m_edtValtage3Change
  end
  object m_cbGap: TComboBox
    Left = 376
    Top = 8
    Width = 65
    Height = 21
    ImeName = 'Microsoft IME 2003'
    ItemHeight = 13
    TabOrder = 22
    Text = '1ms'
  end
  object m_btnStart: TButton
    Left = 272
    Top = 184
    Width = 75
    Height = 25
    Caption = 'Start(&S)'
    TabOrder = 23
    OnClick = m_btnStartClick
  end
  object m_spnVoltage0: TUpDown
    Left = 441
    Top = 64
    Width = 16
    Height = 21
    Associate = m_edtValtage0
    TabOrder = 24
  end
  object m_spnVoltage1: TUpDown
    Left = 441
    Top = 88
    Width = 16
    Height = 21
    Associate = m_edtValtage1
    TabOrder = 25
  end
  object m_spnVoltage2: TUpDown
    Left = 441
    Top = 112
    Width = 16
    Height = 21
    Associate = m_edtValtage2
    TabOrder = 26
  end
  object m_spnVoltage3: TUpDown
    Left = 441
    Top = 136
    Width = 16
    Height = 21
    Associate = m_edtValtage3
    TabOrder = 27
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 50
    OnTimer = Timer1Timer
    Left = 16
    Top = 168
  end
end
