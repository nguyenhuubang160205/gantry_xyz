object Form1: TForm1
  Left = 2254
  Top = 132
  BorderIcons = [biSystemMenu]
  Caption = 'NormalTriggerMulti'
  ClientHeight = 147
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
    Left = 29
    Top = 91
    Width = 33
    Height = 16
    Caption = 'CH00'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 217
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
  object Label4: TLabel
    Left = 98
    Top = 91
    Width = 33
    Height = 16
    Caption = 'CH01'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 166
    Top = 91
    Width = 33
    Height = 16
    Caption = 'CH02'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 234
    Top = 91
    Width = 33
    Height = 16
    Caption = 'CH03'
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
    Width = 463
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
      Width = 449
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = 'm_cboModule'
      OnChange = m_cboModuleChange
    end
  end
  object m_cboVoltageRange: TComboBox
    Left = 86
    Top = 60
    Width = 126
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 1
    Text = 'm_cboVoltageRange'
    OnChange = m_cboVoltageRangeChange
  end
  object m_cboValueType: TComboBox
    Left = 300
    Top = 60
    Width = 162
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 2
    Text = 'ComboBox3'
    OnChange = m_cboValueTypeChange
    Items.Strings = (
      '00: Volt'
      '01: Digit')
  end
  object m_stcCh00: TEdit
    Left = 13
    Top = 111
    Width = 65
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 3
  end
  object m_btnStart: TButton
    Left = 300
    Top = 92
    Width = 75
    Height = 41
    Caption = 'Start'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = m_btnStartClick
  end
  object m_btnStop: TButton
    Left = 386
    Top = 92
    Width = 75
    Height = 41
    Caption = 'Stop'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = m_btnStopClick
  end
  object m_stcCh01: TEdit
    Left = 82
    Top = 111
    Width = 65
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
  end
  object m_stcCh02: TEdit
    Left = 150
    Top = 111
    Width = 65
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 7
  end
  object m_stcCh03: TEdit
    Left = 218
    Top = 111
    Width = 65
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 8
  end
  object m_timer: TTimer
    Enabled = False
    Interval = 100
    OnTimer = m_timerTimer
    Left = 432
  end
end
