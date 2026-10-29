object Form1: TForm1
  Left = 2249
  Top = 136
  Caption = 'OutputWriteSingle'
  ClientHeight = 161
  ClientWidth = 482
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
    Left = 7
    Top = 64
    Width = 97
    Height = 16
    Caption = 'Voltage Range :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 7
    Top = 96
    Width = 97
    Height = 16
    Caption = 'Setting Voltage :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 208
    Top = 64
    Width = 4
    Height = 16
    Caption = '`'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object m_stcValueType: TLabel
    Left = 315
    Top = 98
    Width = 23
    Height = 16
    Caption = 'Volt'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 7
    Top = 128
    Width = 97
    Height = 16
    Caption = 'Output  Voltage :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 315
    Top = 130
    Width = 23
    Height = 16
    Caption = 'Volt'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object GroupBox1: TGroupBox
    Left = 7
    Top = 7
    Width = 342
    Height = 47
    Caption = '[Board No'#9672'Module No'#9672'Module ID]'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    object m_cboModule: TComboBox
      Left = 6
      Top = 17
      Width = 329
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = 'm_cboModule'
      OnChange = m_cboModuleChange
    end
  end
  object GroupBox2: TGroupBox
    Left = 357
    Top = 7
    Width = 114
    Height = 47
    Caption = '[Channel]'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object m_cboChannel: TComboBox
      Left = 8
      Top = 17
      Width = 98
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = 'm_cboChannel'
      OnChange = m_cboChannelChange
    end
  end
  object m_cboVoltageRange: TComboBox
    Left = 108
    Top = 62
    Width = 234
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 2
    Text = 'm_cboVoltageRange'
    OnChange = m_cboVoltageRangeChange
  end
  object m_edtSettingVoltage: TEdit
    Left = 108
    Top = 94
    Width = 65
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 3
  end
  object m_btnSet: TButton
    Left = 365
    Top = 63
    Width = 96
    Height = 85
    Caption = 'Voltage Set'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = m_btnSetClick
  end
  object m_scrSettingVoltage: TScrollBar
    Left = 180
    Top = 98
    Width = 130
    Height = 17
    PageSize = 0
    TabOrder = 5
    OnScroll = m_scrSettingVoltageScroll
  end
  object m_stcOutputVoltage: TEdit
    Left = 108
    Top = 126
    Width = 203
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 6
    Text = '0.0000'
  end
  object m_timer: TTimer
    Interval = 100
    OnTimer = m_timerTimer
    Left = 432
  end
end
