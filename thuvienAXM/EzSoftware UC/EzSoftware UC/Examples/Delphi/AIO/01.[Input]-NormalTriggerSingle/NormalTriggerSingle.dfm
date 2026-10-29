object Form1: TForm1
  Left = 2264
  Top = 142
  BorderIcons = [biSystemMenu]
  Caption = 'NormalTriggerSingle'
  ClientHeight = 127
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
    Top = 62
    Width = 76
    Height = 16
    Caption = 'Volt. Range :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 7
    Top = 94
    Width = 75
    Height = 16
    Caption = 'Read Value:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 208
    Top = 62
    Width = 79
    Height = 16
    Caption = 'Value Type  :'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object m_stcValueType: TLabel
    Left = 208
    Top = 95
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
    Left = 86
    Top = 60
    Width = 119
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
  object m_cboValueType: TComboBox
    Left = 292
    Top = 60
    Width = 170
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 3
    Text = 'ComboBox3'
    OnChange = m_cboValueTypeChange
    Items.Strings = (
      '00: Volt'
      '01: Digit')
  end
  object m_stcReadValue: TEdit
    Left = 86
    Top = 92
    Width = 119
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 4
  end
  object m_btnStart: TButton
    Left = 292
    Top = 92
    Width = 80
    Height = 25
    Caption = 'Start'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = m_btnStartClick
  end
  object m_btnStop: TButton
    Left = 380
    Top = 92
    Width = 80
    Height = 25
    Caption = 'Stop'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = m_btnStopClick
  end
  object m_timer: TTimer
    Enabled = False
    Interval = 100
    OnTimer = m_timerTimer
    Left = 432
  end
end
