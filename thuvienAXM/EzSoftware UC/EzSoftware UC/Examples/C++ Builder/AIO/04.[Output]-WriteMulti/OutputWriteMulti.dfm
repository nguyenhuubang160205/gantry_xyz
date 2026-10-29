object Form1: TForm1
  Left = 192
  Top = 124
  BorderIcons = [biSystemMenu]
  Caption = 'OutputWriteMulti'
  ClientHeight = 198
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
  object Label4: TLabel
    Left = 7
    Top = 156
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
  object GroupBox1: TGroupBox
    Left = 7
    Top = 7
    Width = 468
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
      Width = 450
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = 'm_cboModule'
      OnChange = m_cboModuleChange
    end
  end
  object m_cboVoltageRange: TComboBox
    Left = 108
    Top = 62
    Width = 261
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
  object m_edtSetVoltCh00: TEdit
    Left = 108
    Top = 94
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 2
    Text = '0.0000'
  end
  object m_btnSet: TButton
    Left = 379
    Top = 63
    Width = 80
    Height = 21
    Caption = 'Voltage Set'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = m_btnSetClick
  end
  object m_scrSetVoltCh00: TScrollBar
    Left = 109
    Top = 128
    Width = 80
    Height = 17
    PageSize = 0
    TabOrder = 4
    OnScroll = m_scrSetVoltCh00Scroll
  end
  object m_stcOutVoltCh00: TEdit
    Left = 108
    Top = 154
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 5
    Text = '0.0000'
  end
  object m_edtSetVoltCh01: TEdit
    Left = 198
    Top = 94
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 6
    Text = '0.0000'
  end
  object m_scrSetVoltCh01: TScrollBar
    Left = 199
    Top = 128
    Width = 80
    Height = 17
    PageSize = 0
    TabOrder = 7
    OnScroll = m_scrSetVoltCh01Scroll
  end
  object m_stcOutVoltCh01: TEdit
    Left = 198
    Top = 154
    Width = 80
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
    Text = '0.0000'
  end
  object m_edtSetVoltCh02: TEdit
    Left = 288
    Top = 94
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 9
    Text = '0.0000'
  end
  object m_scrSetVoltCh02: TScrollBar
    Left = 289
    Top = 128
    Width = 80
    Height = 17
    PageSize = 0
    TabOrder = 10
    OnScroll = m_scrSetVoltCh02Scroll
  end
  object m_stcOutVoltCh02: TEdit
    Left = 288
    Top = 154
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 11
    Text = '0.0000'
  end
  object m_edtSetVoltCh03: TEdit
    Left = 379
    Top = 94
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    TabOrder = 12
    Text = '0.0000'
  end
  object m_scrSetVoltCh03: TScrollBar
    Left = 380
    Top = 128
    Width = 80
    Height = 17
    PageSize = 0
    TabOrder = 13
    OnScroll = m_scrSetVoltCh03Scroll
  end
  object m_stcOutVoltCh03: TEdit
    Left = 379
    Top = 154
    Width = 80
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft IME 2010'
    ParentFont = False
    ReadOnly = True
    TabOrder = 14
    Text = '0.0000'
  end
  object m_timer: TTimer
    Interval = 100
    OnTimer = m_timerTimer
    Left = 432
  end
end
