object frmCamcQI: TfrmCamcQI
  Left = 737
  Top = 145
  AutoSize = True
  BiDiMode = bdLeftToRight
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'CAMC-QI'
  ClientHeight = 743
  ClientWidth = 1002
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  ParentBiDiMode = False
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label5: TLabel
    Left = 2
    Top = 288
    Width = 56
    Height = 13
    Caption = '  Unit/Pulse'
    Color = clActiveBorder
    ParentColor = False
    Layout = tlCenter
  end
  object Label6: TLabel
    Left = 2
    Top = 311
    Width = 42
    Height = 13
    Caption = '  Axis No'
    Color = clActiveBorder
    ParentColor = False
    Layout = tlCenter
  end
  object GroupBox14: TGroupBox
    Left = 0
    Top = 698
    Width = 339
    Height = 45
    Caption = 'ETC'
    TabOrder = 0
    object LedBusyX: TLabel
      Left = 72
      Top = 17
      Width = 17
      Height = 17
      AutoSize = False
      Color = clOlive
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object LedBusyY: TLabel
      Left = 162
      Top = 17
      Width = 17
      Height = 17
      AutoSize = False
      Color = clOlive
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object LedEXPP: TLabel
      Left = 242
      Top = 17
      Width = 17
      Height = 17
      AutoSize = False
      Color = clRed
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object LedEXMP: TLabel
      Left = 312
      Top = 17
      Width = 17
      Height = 17
      AutoSize = False
      Color = clRed
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
  end
  object GroupBox5: TGroupBox
    Left = 10
    Top = 529
    Width = 121
    Height = 156
    Caption = 'Mechanical Signal'
    TabOrder = 1
    object Label20: TLabel
      Left = 8
      Top = 18
      Width = 65
      Height = 17
      AutoSize = False
      Caption = ' +End Limit'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
    end
    object Label21: TLabel
      Left = 8
      Top = 42
      Width = 65
      Height = 17
      AutoSize = False
      Caption = ' -End Limit'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
    end
    object Label24: TLabel
      Left = 8
      Top = 84
      Width = 65
      Height = 17
      AutoSize = False
      Caption = '   Inposition'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
    end
    object Label25: TLabel
      Left = 8
      Top = 63
      Width = 65
      Height = 17
      AutoSize = False
      Caption = '     Alarm'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_pendsignal: TLabel
      Left = 80
      Top = 16
      Width = 17
      Height = 17
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_nendsignal: TLabel
      Left = 80
      Top = 41
      Width = 17
      Height = 15
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_pslowsignal: TLabel
      Left = 80
      Top = 105
      Width = 17
      Height = 17
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_nslowsignal: TLabel
      Left = 80
      Top = 126
      Width = 17
      Height = 17
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_alarmsignal: TLabel
      Left = 80
      Top = 62
      Width = 17
      Height = 17
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object m_inpossignal: TLabel
      Left = 80
      Top = 84
      Width = 17
      Height = 17
      AutoSize = False
      Color = clMaroon
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clLime
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object Label84: TLabel
      Left = 8
      Top = 105
      Width = 65
      Height = 17
      AutoSize = False
      Caption = '      Home'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
    end
    object Label85: TLabel
      Left = 8
      Top = 126
      Width = 65
      Height = 17
      AutoSize = False
      Caption = '      Zphas'
      Color = clWindowFrame
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
    end
  end
  object GroupBox6: TGroupBox
    Left = 0
    Top = 337
    Width = 222
    Height = 358
    Caption = 'I / O'
    Color = clBtnFace
    ParentColor = False
    TabOrder = 2
    object GroupBox8: TGroupBox
      Left = 104
      Top = 13
      Width = 118
      Height = 169
      Caption = 'Universal I/O'
      TabOrder = 0
      object LedIn1: TLabel
        Left = 8
        Top = 60
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedIn2: TLabel
        Left = 8
        Top = 81
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedIn3: TLabel
        Left = 8
        Top = 101
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedOut0: TLabel
        Left = 64
        Top = 40
        Width = 17
        Height = 15
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut0Click
      end
      object LedOut1: TLabel
        Left = 64
        Top = 59
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut1Click
      end
      object LedOut2: TLabel
        Left = 64
        Top = 80
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut2Click
      end
      object LedOut3: TLabel
        Left = 64
        Top = 100
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut3Click
      end
      object LedIn4: TLabel
        Left = 8
        Top = 121
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedOut4: TLabel
        Left = 64
        Top = 120
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut4Click
      end
      object LedIn5: TLabel
        Left = 8
        Top = 141
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedOut5: TLabel
        Left = 64
        Top = 140
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
        OnClick = LedOut5Click
      end
      object LedIn0: TLabel
        Left = 8
        Top = 39
        Width = 17
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
    end
    object GroupBox9: TGroupBox
      Left = 0
      Top = 189
      Width = 100
      Height = 169
      Caption = 'Mechanical Signal'
      TabOrder = 1
      object LedPElm: TLabel
        Left = 79
        Top = 19
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedNElm: TLabel
        Left = 79
        Top = 40
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedInp: TLabel
        Left = 79
        Top = 61
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedAlarm: TLabel
        Left = 79
        Top = 82
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedHome: TLabel
        Left = 79
        Top = 103
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedZPhase: TLabel
        Left = 79
        Top = 124
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedEmg: TLabel
        Left = 79
        Top = 145
        Width = 14
        Height = 17
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object StaticText20: TStaticText
        Left = 7
        Top = 20
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = '+End Limit'
        TabOrder = 0
      end
      object StaticText21: TStaticText
        Left = 7
        Top = 40
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = '-End Limit'
        TabOrder = 1
      end
      object StaticText22: TStaticText
        Left = 7
        Top = 61
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = 'Inposition'
        TabOrder = 2
      end
      object StaticText23: TStaticText
        Left = 7
        Top = 82
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = 'Alarm'
        TabOrder = 3
      end
      object StaticText24: TStaticText
        Left = 7
        Top = 104
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = 'Home'
        TabOrder = 4
      end
      object StaticText25: TStaticText
        Left = 7
        Top = 124
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = 'Zphase'
        TabOrder = 5
      end
      object StaticText26: TStaticText
        Left = 7
        Top = 145
        Width = 70
        Height = 17
        Alignment = taCenter
        AutoSize = False
        BevelOuter = bvNone
        BorderStyle = sbsSunken
        Caption = 'Emg'
        TabOrder = 6
      end
    end
    object GroupBox10: TGroupBox
      Left = 104
      Top = 189
      Width = 117
      Height = 79
      Caption = 'MPG'
      TabOrder = 2
      object btnMPGOn: TButton
        Left = 8
        Top = 16
        Width = 100
        Height = 24
        Caption = 'MPG ON'
        Enabled = False
        TabOrder = 0
        OnClick = btnMPGOnClick
      end
      object btnMPGOff: TButton
        Left = 8
        Top = 48
        Width = 100
        Height = 24
        Caption = 'MPG OFF'
        Enabled = False
        TabOrder = 1
        OnClick = btnMPGOffClick
      end
    end
    object GroupBox11: TGroupBox
      Left = 104
      Top = 278
      Width = 117
      Height = 80
      Caption = 'CRC'
      TabOrder = 3
      object btnCRCOn: TButton
        Left = 8
        Top = 16
        Width = 100
        Height = 24
        Caption = 'CRC ON'
        TabOrder = 0
        OnClick = btnCRCOnClick
      end
      object btnCRCOff: TButton
        Left = 8
        Top = 48
        Width = 100
        Height = 24
        Caption = 'CRC OFF'
        TabOrder = 1
        OnClick = btnCRCOffClick
      end
    end
    object m_grLevel: TGroupBox
      Left = 0
      Top = 13
      Width = 100
      Height = 169
      Caption = 'Level Setting'
      TabOrder = 4
      object chkPElmLevel: TCheckBox
        Left = 80
        Top = 18
        Width = 17
        Height = 17
        AllowGrayed = True
        State = cbGrayed
        TabOrder = 0
        OnClick = chkPElmLevelClick
      end
      object chkNElmLevel: TCheckBox
        Left = 80
        Top = 38
        Width = 17
        Height = 17
        AllowGrayed = True
        State = cbGrayed
        TabOrder = 1
        OnClick = chkNElmLevelClick
      end
      object chkInpLevel: TCheckBox
        Left = 80
        Top = 59
        Width = 17
        Height = 17
        AllowGrayed = True
        State = cbGrayed
        TabOrder = 2
        OnClick = chkInpLevelClick
      end
      object chkAlarmLevel: TCheckBox
        Left = 80
        Top = 80
        Width = 16
        Height = 17
        AllowGrayed = True
        State = cbGrayed
        TabOrder = 3
        OnClick = chkAlarmLevelClick
      end
      object chkHomeLevel: TCheckBox
        Left = 80
        Top = 103
        Width = 16
        Height = 14
        TabOrder = 4
        OnClick = chkHomeLevelClick
      end
      object chkZPhaseLevel: TCheckBox
        Left = 80
        Top = 122
        Width = 17
        Height = 17
        TabOrder = 5
        OnClick = chkZPhaseLevelClick
      end
      object chkEmgLevel: TCheckBox
        Left = 80
        Top = 144
        Width = 16
        Height = 16
        AllowGrayed = True
        State = cbGrayed
        TabOrder = 6
        OnClick = chkEmgLevelClick
      end
    end
  end
  object cboAxisSet: TComboBox
    Left = 65
    Top = 311
    Width = 157
    Height = 21
    Style = csDropDownList
    Color = clWhite
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlack
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
    ItemHeight = 13
    ParentFont = False
    TabOrder = 3
    OnChange = cboAxisSetChange
  end
  object GroupBox17: TGroupBox
    Left = 346
    Top = 696
    Width = 474
    Height = 47
    Caption = 'Interrupt Method Setting'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label108: TLabel
      Left = 325
      Top = 16
      Width = 90
      Height = 22
      AutoSize = False
      Caption = 'Interrput Count : '
      Color = clBtnFace
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentColor = False
      ParentFont = False
      ParentShowHint = False
      ShowHint = False
      Layout = tlCenter
    end
    object btnIntMessage: TButton
      Left = 6
      Top = 18
      Width = 76
      Height = 21
      Caption = 'Message'
      Enabled = False
      TabOrder = 0
      OnClick = btnIntMessageClick
    end
    object btnIntEvent: TButton
      Left = 85
      Top = 18
      Width = 76
      Height = 21
      Caption = 'Event'
      Enabled = False
      TabOrder = 1
      OnClick = btnIntEventClick
    end
    object btnIntCallBack: TButton
      Left = 164
      Top = 18
      Width = 76
      Height = 21
      Caption = 'CallBack'
      Enabled = False
      TabOrder = 2
      OnClick = btnIntCallBackClick
    end
    object edtInterruptCount: TEdit
      Left = 418
      Top = 16
      Width = 47
      Height = 24
      Color = clActiveBorder
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ReadOnly = True
      TabOrder = 3
      Text = '0'
    end
    object btnIntDisable: TButton
      Left = 243
      Top = 18
      Width = 76
      Height = 21
      Caption = 'DISABLE'
      Enabled = False
      TabOrder = 4
      OnClick = btnIntDisableClick
    end
  end
  object GroupBox18: TGroupBox
    Left = 625
    Top = 358
    Width = 194
    Height = 127
    Caption = 'Signal Search'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    object cboDetect: TComboBox
      Left = 88
      Top = 18
      Width = 99
      Height = 23
      Style = csDropDownList
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Arial Narrow'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 15
      ParentFont = False
      TabOrder = 0
      Items.Strings = (
        'PosEndLimit (0)'
        'NegEndLimit (1)'
        'HomeSensor DN (4)'
        'EncodZPhase DN (5)'
        'UniInput02 DN (6)'
        'UniInput03 DN (7)'
        'HomeSensor UP (4)'
        'EncodZPhase UP (5)'
        'UniInput02 UP (6)'
        'UniInput03 UP (7)')
    end
    object cboDirection: TComboBox
      Left = 88
      Top = 43
      Width = 99
      Height = 23
      Style = csDropDownList
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Arial Narrow'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 15
      ParentFont = False
      TabOrder = 1
      Items.Strings = (
        '+ CW'
        '- CCW')
    end
    object cboStopM: TComboBox
      Left = 88
      Top = 68
      Width = 99
      Height = 23
      Style = csDropDownList
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Arial Narrow'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 15
      ParentFont = False
      TabOrder = 2
      Items.Strings = (
        'ESTOP'
        'SSTOP')
    end
    object btnSearch: TButton
      Left = 6
      Top = 96
      Width = 179
      Height = 24
      Caption = 'Search'
      TabOrder = 3
      OnClick = btnSearchClick
    end
    object StaticText47: TStaticText
      Left = 5
      Top = 19
      Width = 83
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Detect signal'
      TabOrder = 4
    end
    object StaticText48: TStaticText
      Left = 5
      Top = 44
      Width = 83
      Height = 21
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Direction'
      TabOrder = 5
    end
    object StaticText49: TStaticText
      Left = 5
      Top = 69
      Width = 83
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Stop Method'
      TabOrder = 6
    end
  end
  object GroupBox12: TGroupBox
    Left = 226
    Top = 300
    Width = 396
    Height = 395
    Caption = 'Motion'
    TabOrder = 6
    object edtUnit: TEdit
      Left = 38
      Top = 15
      Width = 45
      Height = 21
      Color = clNone
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      TabOrder = 0
      Text = '1.00000'
    end
    object cboPulseOutM: TComboBox
      Left = 84
      Top = 41
      Width = 130
      Height = 21
      Style = csDropDownList
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 13
      TabOrder = 1
      OnChange = cboPulseOutMChange
      Items.Strings = (
        'OneHighLowHigh'
        'OneHighHighLow'
        'OneLowLowHigh'
        'OneLowHighLow'
        'TwoCcwCwHigh'
        'TwoCcwCwLow'
        'TwoCwCcwHigh'
        'TwoCwCcwLow'
        'TwoPhase'
        'TwoPhaseReverse')
    end
    object edtCmdPosY: TEdit
      Left = 88
      Top = 119
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 2
      Text = '0.000'
    end
    object edtActPosY: TEdit
      Left = 175
      Top = 119
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 3
      Text = '0.000'
    end
    object edtCmdVelY: TEdit
      Left = 262
      Top = 119
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 4
      Text = '0.000'
    end
    object btnCountClr: TButton
      Left = 6
      Top = 68
      Width = 80
      Height = 22
      Caption = 'CNTCLR'
      TabOrder = 5
      OnClick = btnCountClrClick
    end
    object edtPulse: TEdit
      Left = 120
      Top = 15
      Width = 94
      Height = 21
      Color = clNone
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      TabOrder = 6
      Text = '1'
    end
    object edtCmdPosZ: TEdit
      Left = 88
      Top = 143
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 7
      Text = '0.000'
    end
    object edtCmdPosU: TEdit
      Left = 88
      Top = 167
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 8
      Text = '0.000'
    end
    object edtActPosU: TEdit
      Left = 175
      Top = 167
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 9
      Text = '0.000'
    end
    object edtActPosZ: TEdit
      Left = 175
      Top = 143
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 10
      Text = '0.000'
    end
    object edtCmdVelZ: TEdit
      Left = 262
      Top = 143
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 11
      Text = '0.000'
    end
    object edtCmdVelU: TEdit
      Left = 262
      Top = 167
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 12
      Text = '0.000'
    end
    object edtStartSpeed: TEdit
      Left = 290
      Top = 15
      Width = 44
      Height = 21
      BiDiMode = bdLeftToRight
      Color = clNone
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentBiDiMode = False
      ParentFont = False
      TabOrder = 13
      Text = '1'
    end
    object btnSetting: TButton
      Left = 333
      Top = 15
      Width = 58
      Height = 21
      Caption = 'Setting'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 14
      OnClick = btnSettingClick
    end
    object cboEncInputM: TComboBox
      Left = 290
      Top = 41
      Width = 102
      Height = 21
      Style = csDropDownList
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 13
      TabOrder = 15
      OnChange = cboEncInputMChange
      Items.Strings = (
        'Up/Down'
        '1 Multiple'
        '2 Multiples'
        '4 Multiples'
        'Rev Up/Down'
        'Rev 1 Multiple'
        'Rev 2 Multiples'
        'Rev 4 Multiples')
    end
    object edtActPosX: TEdit
      Left = 175
      Top = 95
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 16
      Text = '0.000'
    end
    object edtCmdVelX: TEdit
      Left = 262
      Top = 95
      Width = 84
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentFont = False
      ReadOnly = True
      TabOrder = 17
      Text = '0.000'
    end
    object GroupBox3: TGroupBox
      Left = 0
      Top = 194
      Width = 249
      Height = 102
      Caption = 'Interpolation'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 18
      object edtXEndCen: TEdit
        Left = 88
        Top = 19
        Width = 84
        Height = 21
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -12
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 0
        Text = '200.000'
      end
      object edtYEndCen: TEdit
        Left = 88
        Top = 46
        Width = 84
        Height = 21
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -12
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 1
        Text = '200.000'
      end
      object edtAngle: TEdit
        Left = 88
        Top = 73
        Width = 84
        Height = 21
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -12
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 2
        Text = '360.000'
      end
      object btnLinear: TButton
        Left = 173
        Top = 45
        Width = 72
        Height = 24
        Caption = 'Linear'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 3
        OnClick = btnLinearClick
      end
      object btnCircular: TButton
        Left = 173
        Top = 71
        Width = 72
        Height = 24
        Caption = 'Circular'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        OnClick = btnCirCularClick
      end
      object chkCwCcw: TCheckBox
        Left = 176
        Top = 18
        Width = 67
        Height = 17
        Caption = 'cw/ccw'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 5
      end
      object StaticText44: TStaticText
        Left = 6
        Top = 20
        Width = 80
        Height = 21
        Alignment = taCenter
        AutoSize = False
        BorderStyle = sbsSunken
        Caption = 'X end/cen'
        TabOrder = 6
      end
      object StaticText45: TStaticText
        Left = 6
        Top = 47
        Width = 80
        Height = 21
        Alignment = taCenter
        AutoSize = False
        BorderStyle = sbsSunken
        Caption = 'Y end/cen'
        TabOrder = 7
      end
      object StaticText46: TStaticText
        Left = 6
        Top = 73
        Width = 80
        Height = 21
        Alignment = taCenter
        AutoSize = False
        BorderStyle = sbsSunken
        Caption = 'Angle'
        TabOrder = 8
      end
    end
    object GroupBox4: TGroupBox
      Left = 248
      Top = 194
      Width = 148
      Height = 102
      Caption = 'Gantry'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 19
      object chkGantrySlave: TCheckBox
        Left = 8
        Top = 23
        Width = 121
        Height = 34
        AllowGrayed = True
        Caption = 'Slave Home Use'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -12
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 0
        OnClick = chkGantrySlaveClick
      end
      object chkGantry: TCheckBox
        Left = 9
        Top = 52
        Width = 113
        Height = 41
        BiDiMode = bdLeftToRight
        Caption = 'Gantry Enable'
        ParentBiDiMode = False
        TabOrder = 1
        OnClick = chkGantryClick
      end
    end
    object GroupBox7: TGroupBox
      Left = 0
      Top = 298
      Width = 396
      Height = 98
      Caption = 'One Axis'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 20
      DesignSize = (
        396
        98)
      object chkAsym: TCheckBox
        Left = 318
        Top = 48
        Width = 70
        Height = 17
        Cursor = crDrag
        Caption = 'Asym'
        Checked = True
        Ctl3D = True
        DragCursor = crAppStart
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentCtl3D = False
        ParentFont = False
        State = cbChecked
        TabOrder = 0
        OnClick = chkAsymClick
      end
      object chkSCurve: TCheckBox
        Left = 318
        Top = 63
        Width = 70
        Height = 17
        Cursor = crDrag
        Caption = 'S-Curve'
        Ctl3D = True
        DragCursor = crAppStart
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentCtl3D = False
        ParentFont = False
        TabOrder = 1
        OnClick = chkSCurveClick
      end
      object chkXYSyn: TCheckBox
        Left = 318
        Top = 78
        Width = 70
        Height = 17
        Cursor = crDrag
        Caption = 'X-Y Syn'
        Ctl3D = True
        DragCursor = crAppStart
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentCtl3D = False
        ParentFont = False
        TabOrder = 2
      end
      object edtPosition: TEdit
        Left = 6
        Top = 43
        Width = 74
        Height = 24
        Anchors = [akTop, akRight]
        Color = clBlack
        DragCursor = crIBeam
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 3
        Text = '200.000'
      end
      object btnMove: TButton
        Left = 6
        Top = 69
        Width = 74
        Height = 24
        Caption = 'Move'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        OnClick = btnMoveClick
      end
      object edtVelocity: TEdit
        Left = 84
        Top = 43
        Width = 74
        Height = 24
        Color = clBlack
        DragCursor = crIBeam
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 5
        Text = '300.000'
      end
      object btnRepeat: TButton
        Left = 84
        Top = 69
        Width = 74
        Height = 24
        Caption = 'Repeat'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 6
        OnClick = btnRepeatClick
      end
      object edtAccel: TEdit
        Left = 162
        Top = 43
        Width = 74
        Height = 24
        Color = clBlack
        DragCursor = crIBeam
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 7
        Text = '300.000'
      end
      object btnStop: TButton
        Left = 162
        Top = 69
        Width = 74
        Height = 24
        Caption = 'Stop'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 8
        OnClick = btnStopClick
      end
      object edtDecel: TEdit
        Left = 240
        Top = 43
        Width = 74
        Height = 24
        Color = clBlack
        DragCursor = crIBeam
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clYellow
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ParentFont = False
        TabOrder = 9
        Text = '300.000'
      end
      object btnEStop: TButton
        Left = 240
        Top = 69
        Width = 74
        Height = 24
        Caption = 'ESTOP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 10
        OnClick = btnEStopClick
      end
      object chkRelative: TCheckBox
        Left = 318
        Top = 34
        Width = 70
        Height = 17
        Cursor = crDrag
        BiDiMode = bdLeftToRight
        Caption = 'Relative'
        Color = clBtnFace
        Ctl3D = True
        DragCursor = crAppStart
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentBiDiMode = False
        ParentColor = False
        ParentCtl3D = False
        ParentFont = False
        TabOrder = 11
        OnClick = chkRelativeClick
      end
      object chkAbsolute: TCheckBox
        Left = 318
        Top = 18
        Width = 70
        Height = 17
        Cursor = crDrag
        BiDiMode = bdLeftToRight
        Caption = 'Absolute'
        Ctl3D = True
        DragCursor = crAppStart
        ParentBiDiMode = False
        ParentCtl3D = False
        TabOrder = 12
        OnClick = chkAbsoluteClick
      end
    end
    object StaticText34: TStaticText
      Left = 7
      Top = 41
      Width = 75
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Pulseout_M'
      TabOrder = 21
    end
    object StaticText35: TStaticText
      Left = 218
      Top = 41
      Width = 68
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Encoder_M'
      TabOrder = 22
    end
    object StaticText36: TStaticText
      Left = 89
      Top = 69
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'CMD POS'
      TabOrder = 23
    end
    object StaticText37: TStaticText
      Left = 175
      Top = 69
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'ACT POS'
      TabOrder = 24
    end
    object StaticText38: TStaticText
      Left = 262
      Top = 69
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'CMD VEL'
      TabOrder = 25
    end
    object StaticText39: TStaticText
      Left = 348
      Top = 69
      Width = 42
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'JOG'
      TabOrder = 26
    end
    object StaticText40: TStaticText
      Left = 6
      Top = 95
      Width = 80
      Height = 21
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Axis X'
      DragMode = dmAutomatic
      TabOrder = 27
    end
    object StaticText41: TStaticText
      Left = 6
      Top = 119
      Width = 80
      Height = 21
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Axis Y'
      TabOrder = 28
    end
    object StaticText42: TStaticText
      Left = 6
      Top = 143
      Width = 80
      Height = 21
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Axis Z'
      TabOrder = 29
    end
    object StaticText43: TStaticText
      Left = 6
      Top = 167
      Width = 80
      Height = 21
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Axis U'
      TabOrder = 30
    end
    object edtCmdPosX: TEdit
      Left = 88
      Top = 95
      Width = 84
      Height = 21
      BiDiMode = bdLeftToRight
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentBiDiMode = False
      ParentFont = False
      ReadOnly = True
      TabOrder = 31
      Text = '0.000'
    end
    object btnJogPX: TButton
      Left = 346
      Top = 95
      Width = 21
      Height = 21
      Caption = '+'
      TabOrder = 32
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogNX: TButton
      Tag = 1
      Left = 369
      Top = 95
      Width = 21
      Height = 21
      Caption = '-'
      TabOrder = 33
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogNY: TButton
      Tag = 3
      Left = 369
      Top = 119
      Width = 21
      Height = 21
      Caption = '-'
      TabOrder = 34
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogPY: TButton
      Tag = 2
      Left = 346
      Top = 119
      Width = 21
      Height = 21
      Caption = '+'
      TabOrder = 35
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogPZ: TButton
      Tag = 4
      Left = 346
      Top = 144
      Width = 21
      Height = 20
      Caption = '+'
      TabOrder = 36
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogNZ: TButton
      Tag = 5
      Left = 369
      Top = 143
      Width = 21
      Height = 21
      Caption = '-'
      TabOrder = 37
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogNU: TButton
      Tag = 7
      Left = 369
      Top = 167
      Width = 21
      Height = 21
      Caption = '-'
      TabOrder = 38
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
    object btnJogPU: TButton
      Tag = 6
      Left = 346
      Top = 167
      Width = 21
      Height = 21
      Caption = '+'
      TabOrder = 39
      OnMouseDown = btnJogMouseDown
      OnMouseUp = btnJogMouseUp
    end
  end
  object btnManualSet: TButton
    Left = 634
    Top = 306
    Width = 87
    Height = 24
    Caption = 'Manusl Set'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = False
    TabOrder = 7
    OnClick = btnManualSetClick
  end
  object btnLoad: TButton
    Left = 726
    Top = 306
    Width = 87
    Height = 24
    Caption = 'Load'
    ParentShowHint = False
    ShowHint = False
    TabOrder = 8
    OnClick = btnLoadClick
  end
  object btnStatus: TButton
    Left = 634
    Top = 332
    Width = 87
    Height = 24
    Caption = 'STATUS'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = False
    TabOrder = 9
    OnClick = btnStatusClick
  end
  object btnSave: TButton
    Left = 726
    Top = 332
    Width = 87
    Height = 24
    Caption = 'SAVE'
    ParentShowHint = False
    ShowHint = False
    TabOrder = 10
    OnClick = btnSaveClick
  end
  object GroupBox1: TGroupBox
    Left = 824
    Top = 0
    Width = 174
    Height = 250
    Caption = 'Conti lnterpolation'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 11
    object btnContiSpline: TButton
      Left = 10
      Top = 131
      Width = 106
      Height = 25
      Caption = '2Axis Spline'
      TabOrder = 0
      OnClick = btnContiSplineClick
    end
    object GroupBox13: TGroupBox
      Left = 0
      Top = 16
      Width = 174
      Height = 110
      Caption = 'Conti Queue'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      object Label1: TLabel
        Left = 6
        Top = 19
        Width = 65
        Height = 20
        AutoSize = False
        Caption = 'ContiNum : '
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label2: TLabel
        Left = 6
        Top = 40
        Width = 65
        Height = 20
        AutoSize = False
        Caption = 'TotalNum : '
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label3: TLabel
        Left = 6
        Top = 61
        Width = 65
        Height = 20
        AutoSize = False
        Caption = 'Q free :'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label4: TLabel
        Left = 6
        Top = 82
        Width = 65
        Height = 20
        AutoSize = False
        Caption = 'InMotion :'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object edtContiNum: TEdit
        Left = 78
        Top = 19
        Width = 88
        Height = 24
        Color = clActiveBorder
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ReadOnly = True
        TabOrder = 0
        Text = '0'
      end
      object edtTotalNum: TEdit
        Left = 78
        Top = 40
        Width = 88
        Height = 24
        Color = clActiveBorder
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ReadOnly = True
        TabOrder = 1
        Text = '0'
      end
      object edtQFree: TEdit
        Left = 78
        Top = 61
        Width = 88
        Height = 24
        Color = clActiveBorder
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ReadOnly = True
        TabOrder = 2
        Text = '0'
      end
      object edtInMotion: TEdit
        Left = 78
        Top = 82
        Width = 88
        Height = 24
        Color = clActiveBorder
        ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
        ReadOnly = True
        TabOrder = 3
        Text = '0'
      end
    end
    object btnContiBlend: TButton
      Left = 10
      Top = 159
      Width = 106
      Height = 25
      Caption = 'Line & Circle'
      TabOrder = 2
      OnClick = btnContiBlendClick
    end
    object btnContiCircle: TButton
      Left = 10
      Top = 188
      Width = 52
      Height = 25
      Caption = 'Circle'
      TabOrder = 3
      OnClick = btnContiCircleClick
    end
    object btnContiLine: TButton
      Left = 64
      Top = 188
      Width = 52
      Height = 25
      Caption = 'Line'
      TabOrder = 4
      OnClick = btnContiLineClick
    end
    object btnContiTest: TButton
      Left = 10
      Top = 216
      Width = 106
      Height = 25
      Caption = 'Verification'
      TabOrder = 5
      OnClick = btnContiTestClick
    end
    object btnContiStart: TButton
      Left = 120
      Top = 131
      Width = 48
      Height = 53
      Caption = 'Start'
      TabOrder = 6
      OnClick = btnContiStartClick
    end
    object btnContiClear: TButton
      Left = 120
      Top = 188
      Width = 48
      Height = 53
      Caption = 'CLR'
      TabOrder = 7
      OnClick = btnContiClearClick
    end
  end
  object edtGearRatio: TEdit
    Left = 930
    Top = 256
    Width = 65
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    TabOrder = 12
    Text = '1.0'
  end
  object Trigger: TGroupBox
    Left = 826
    Top = 282
    Width = 174
    Height = 172
    Caption = 'Block / One Shot Trigger'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 13
    object edtTrigStartPosition: TEdit
      Left = 96
      Top = 24
      Width = 73
      Height = 24
      ImeName = 'Microsoft Office IME 2007'
      TabOrder = 0
      Text = '1000'
    end
    object edtTrigCycle: TEdit
      Left = 96
      Top = 46
      Width = 73
      Height = 24
      ImeName = 'Microsoft Office IME 2007'
      TabOrder = 1
      Text = '100'
    end
    object edtTrigPulseWidth: TEdit
      Left = 96
      Top = 69
      Width = 73
      Height = 24
      ImeName = 'Microsoft Office IME 2007'
      TabOrder = 2
      Text = '1000'
    end
    object edtTrigEndPos: TEdit
      Left = 96
      Top = 92
      Width = 73
      Height = 24
      ImeName = 'Microsoft Office IME 2007'
      TabOrder = 3
      Text = '5000'
    end
    object btnTrigAbs: TButton
      Left = 8
      Top = 115
      Width = 85
      Height = 25
      Caption = 'Trig(abs)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 4
      OnClick = btnTrigAbsClick
    end
    object btnTrigOneShot: TButton
      Left = 97
      Top = 115
      Width = 74
      Height = 25
      Caption = 'OneShot'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 5
      OnClick = btnTrigOneShotClick
    end
    object btnTrigReset: TButton
      Left = 97
      Top = 144
      Width = 74
      Height = 25
      Caption = 'Trig Reset'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
      OnClick = btnTrigResetClick
    end
    object btnTrigPeriod: TButton
      Left = 8
      Top = 144
      Width = 85
      Height = 25
      Caption = 'Trig(Period)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 7
      OnClick = btnTrigPeriodClick
    end
    object StaticText50: TStaticText
      Left = 8
      Top = 25
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'Start Position'
      TabOrder = 8
    end
    object StaticText51: TStaticText
      Left = 8
      Top = 48
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'Cycle'
      TabOrder = 9
    end
    object StaticText52: TStaticText
      Left = 8
      Top = 94
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'End Position'
      TabOrder = 10
    end
    object StaticText53: TStaticText
      Left = 8
      Top = 71
      Width = 82
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'Pulse Width'
      TabOrder = 11
    end
  end
  object GroupBox16: TGroupBox
    Left = 826
    Top = 460
    Width = 174
    Height = 49
    Caption = 'Override & CaptureMove'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 14
    object btnSigCapture: TButton
      Left = 8
      Top = 18
      Width = 78
      Height = 25
      Caption = 'CaptureMove'
      Enabled = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      OnClick = btnSigCaptureClick
    end
    object btnVelOverride: TButton
      Left = 91
      Top = 18
      Width = 78
      Height = 25
      Caption = 'Override'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      OnClick = btnVelOverrideClick
    end
  end
  object GroupBox19: TGroupBox
    Left = 826
    Top = 510
    Width = 175
    Height = 185
    Caption = 'Home Search'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 15
    object edtHomeVelFirst: TEdit
      Left = 74
      Top = 17
      Width = 98
      Height = 24
      BiDiMode = bdLeftToRight
      Color = clMenuText
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentBiDiMode = False
      ParentFont = False
      TabOrder = 0
      Text = '10000.000'
    end
    object edtHomeVelSecond: TEdit
      Left = 74
      Top = 40
      Width = 98
      Height = 24
      Color = clMenuText
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 1
      Text = '5000.000'
    end
    object edtHomeVelThird: TEdit
      Left = 74
      Top = 63
      Width = 98
      Height = 24
      Color = clMenuText
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 2
      Text = '1000.000'
    end
    object edtHomeVelLast: TEdit
      Left = 74
      Top = 86
      Width = 98
      Height = 24
      Color = clMenuText
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 3
      Text = '100.000'
    end
    object cboHomeSignal: TComboBox
      Left = 74
      Top = 106
      Width = 98
      Height = 23
      Style = csDropDownList
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Arial Narrow'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 15
      ParentFont = False
      TabOrder = 4
      Items.Strings = (
        '+ELM DOWN (0)'
        '-ELM DOWN (1)'
        'UIN0  DOWN (4)')
    end
    object cboHomeDir: TComboBox
      Left = 74
      Top = 131
      Width = 98
      Height = 23
      Style = csDropDownList
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Arial Narrow'
      Font.Style = []
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ItemHeight = 15
      ParentFont = False
      TabOrder = 5
      Items.Strings = (
        '+ CW'
        '- CCW')
    end
    object btnHomeAll: TButton
      Left = 5
      Top = 155
      Width = 68
      Height = 25
      Caption = 'All Home'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
      OnClick = btnHomeAllClick
    end
    object btnHomeSingle: TButton
      Left = 76
      Top = 155
      Width = 94
      Height = 25
      Caption = 'Single Home'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 7
      OnClick = btnHomeSingleClick
    end
    object StaticText54: TStaticText
      Left = 6
      Top = 18
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Vel First'
      TabOrder = 8
    end
    object StaticText55: TStaticText
      Left = 6
      Top = 40
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Vel After'
      TabOrder = 9
    end
    object StaticText56: TStaticText
      Left = 6
      Top = 63
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Vel Again'
      TabOrder = 10
    end
    object StaticText57: TStaticText
      Left = 6
      Top = 87
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Vel Last'
      TabOrder = 11
    end
    object StaticText58: TStaticText
      Left = 6
      Top = 109
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Signal'
      TabOrder = 12
    end
    object StaticText59: TStaticText
      Left = 6
      Top = 132
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BorderStyle = sbsSunken
      Caption = 'Direction'
      TabOrder = 13
    end
  end
  object GroupBox20: TGroupBox
    Left = 826
    Top = 696
    Width = 176
    Height = 47
    Caption = 'Capture Position'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 16
    object edtCapturePos: TEdit
      Left = 76
      Top = 17
      Width = 94
      Height = 24
      BiDiMode = bdRightToLeft
      Color = clActiveBorder
      ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
      ParentBiDiMode = False
      ReadOnly = True
      TabOrder = 0
      Text = '0.000'
    end
    object btnReadCapture: TButton
      Left = 5
      Top = 18
      Width = 68
      Height = 21
      Caption = 'Get Pos'
      Enabled = False
      TabOrder = 1
      OnClick = btnReadCaptureClick
    end
  end
  object chkGearOnOff: TCheckBox
    Left = 826
    Top = 252
    Width = 97
    Height = 25
    Caption = 'Gear On/Off'
    TabOrder = 17
    OnClick = chkGearOnOffClick
  end
  object lstLog: TListBox
    Left = 625
    Top = 488
    Width = 194
    Height = 207
    ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
    ItemHeight = 13
    TabOrder = 18
    OnDblClick = lstLogDblClick
  end
  object btn3DGraph: TButton
    Left = 147
    Top = 288
    Width = 74
    Height = 21
    Caption = '3DGraph'
    TabOrder = 19
    OnClick = btn3DGraphClick
  end
  object StaticText1: TStaticText
    Left = 7
    Top = 369
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = '+End Limit'
    TabOrder = 20
  end
  object StaticText2: TStaticText
    Left = 7
    Top = 389
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = '-End Limit'
    TabOrder = 21
  end
  object StaticText3: TStaticText
    Left = 7
    Top = 410
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = 'Inposition'
    TabOrder = 22
  end
  object StaticText4: TStaticText
    Left = 7
    Top = 431
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = 'Alarm'
    TabOrder = 23
  end
  object StaticText5: TStaticText
    Left = 7
    Top = 452
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = 'Home'
    TabOrder = 24
  end
  object StaticText6: TStaticText
    Left = 7
    Top = 473
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = 'Zphase'
    TabOrder = 25
  end
  object StaticText7: TStaticText
    Left = 7
    Top = 494
    Width = 70
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BevelOuter = bvNone
    BorderStyle = sbsSunken
    Caption = 'Emg'
    TabOrder = 26
  end
  object Org: TStaticText
    Left = 133
    Top = 390
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Org'
    TabOrder = 27
  end
  object Zph: TStaticText
    Left = 133
    Top = 412
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Zph'
    TabOrder = 28
  end
  object StaticText10: TStaticText
    Left = 133
    Top = 432
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '2'
    TabOrder = 29
  end
  object StaticText11: TStaticText
    Left = 133
    Top = 452
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '3'
    TabOrder = 30
  end
  object StaticText12: TStaticText
    Left = 133
    Top = 472
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '4'
    TabOrder = 31
  end
  object StaticText13: TStaticText
    Left = 133
    Top = 492
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '5'
    Enabled = False
    TabOrder = 32
  end
  object StaticText14: TStaticText
    Left = 187
    Top = 389
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Son'
    TabOrder = 33
  end
  object StaticText15: TStaticText
    Left = 187
    Top = 410
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Alm'
    TabOrder = 34
  end
  object StaticText16: TStaticText
    Left = 187
    Top = 431
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '2'
    TabOrder = 35
  end
  object StaticText17: TStaticText
    Left = 187
    Top = 451
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '3'
    TabOrder = 36
  end
  object StaticText18: TStaticText
    Left = 187
    Top = 471
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '4'
    TabOrder = 37
  end
  object StaticText19: TStaticText
    Left = 187
    Top = 491
    Width = 28
    Height = 17
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = '5'
    Enabled = False
    TabOrder = 38
  end
  object StaticText8: TStaticText
    Left = 113
    Top = 367
    Width = 48
    Height = 20
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'IN'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 39
  end
  object StaticText9: TStaticText
    Left = 168
    Top = 366
    Width = 47
    Height = 20
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'OUT'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 40
  end
  object StaticText27: TStaticText
    Left = 9
    Top = 715
    Width = 60
    Height = 19
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'X axis ON'
    TabOrder = 41
  end
  object StaticText28: TStaticText
    Left = 98
    Top = 715
    Width = 60
    Height = 19
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Y axis ON'
    TabOrder = 42
  end
  object StaticText29: TStaticText
    Left = 206
    Top = 715
    Width = 32
    Height = 17
    Alignment = taCenter
    BorderStyle = sbsSunken
    Caption = 'EXPP'
    TabOrder = 43
  end
  object StaticText30: TStaticText
    Left = 273
    Top = 715
    Width = 34
    Height = 17
    Alignment = taCenter
    BorderStyle = sbsSunken
    Caption = 'EXMP'
    TabOrder = 44
  end
  object StaticText31: TStaticText
    Left = 234
    Top = 315
    Width = 30
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Unit'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 45
  end
  object StaticText32: TStaticText
    Left = 310
    Top = 315
    Width = 35
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Pulse'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 46
  end
  object StaticText33: TStaticText
    Left = 444
    Top = 315
    Width = 68
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Start Speed'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 47
  end
  object StaticText63: TStaticText
    Left = 466
    Top = 618
    Width = 74
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Decel'
    TabOrder = 48
  end
  object StaticText62: TStaticText
    Left = 388
    Top = 618
    Width = 74
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Accel'
    TabOrder = 49
  end
  object StaticText61: TStaticText
    Left = 310
    Top = 618
    Width = 74
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Velocity'
    TabOrder = 50
  end
  object StaticText60: TStaticText
    Left = 232
    Top = 618
    Width = 74
    Height = 21
    Alignment = taCenter
    AutoSize = False
    BorderStyle = sbsSunken
    Caption = 'Position'
    TabOrder = 51
  end
  object trkXYRange: TTrackBar
    Left = 626
    Top = 278
    Width = 198
    Height = 25
    Min = 1
    Position = 1
    TabOrder = 52
    ThumbLength = 10
    OnChange = trkXYRangeChange
  end
  object trkXYRange2: TTrackBar
    Left = 509
    Top = 278
    Width = 121
    Height = 22
    Max = 5
    Min = 1
    Position = 1
    TabOrder = 53
    ThumbLength = 10
    OnChange = trkXYRangeChange
  end
  object GraphX: TChart
    Left = 0
    Top = 1
    Width = 512
    Height = 138
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    Gradient.EndColor = 16744448
    Gradient.Visible = True
    LeftWall.Color = 16777088
    LeftWall.Pen.Color = clAqua
    MarginRight = 10
    Title.Color = 16777088
    Title.Font.Charset = DEFAULT_CHARSET
    Title.Font.Color = clTeal
    Title.Font.Height = -12
    Title.Font.Name = 'Arial'
    Title.Font.Style = [fsBold]
    Title.Frame.Width = 2
    Title.Frame.Visible = True
    Title.Text.Strings = (
      'Velocity')
    BottomAxis.Automatic = False
    BottomAxis.AutomaticMaximum = False
    BottomAxis.AutomaticMinimum = False
    BottomAxis.LabelsMultiLine = True
    BottomAxis.Maximum = 5000.000000000000000000
    Chart3DPercent = 1
    LeftAxis.Automatic = False
    LeftAxis.AutomaticMaximum = False
    LeftAxis.AutomaticMinimum = False
    LeftAxis.Maximum = 500.000000000000000000
    LeftAxis.Minimum = 2.000000000000000000
    Legend.Color = 16777088
    Legend.Visible = False
    View3D = False
    View3DOptions.ZoomText = False
    BorderStyle = bsSingle
    TabOrder = 54
    object Series1: TFastLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clRed
      LinePen.Color = clRed
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series2: TFastLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clGreen
      LinePen.Color = clGreen
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
  object edtMoveUnit: TEdit
    Left = 65
    Top = 288
    Width = 76
    Height = 21
    Color = clNone
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = #54620#44397#50612'('#54620#44544') (MS-IME98)'
    ParentFont = False
    ReadOnly = True
    TabOrder = 55
    Text = '1.0000000000'
  end
  object XYPlot: TChart
    Left = 514
    Top = 1
    Width = 305
    Height = 278
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    Gradient.Direction = gdFromBottomLeft
    Gradient.EndColor = 16744448
    Gradient.Visible = True
    LeftWall.Color = 16777088
    LeftWall.Pen.Color = clAqua
    MarginBottom = 1
    MarginLeft = 1
    MarginRight = 8
    MarginTop = 3
    Title.Color = 16777088
    Title.Font.Charset = DEFAULT_CHARSET
    Title.Font.Color = clTeal
    Title.Font.Height = -12
    Title.Font.Name = 'Arial'
    Title.Font.Style = [fsBold]
    Title.Frame.Width = 2
    Title.Frame.Visible = True
    Title.Text.Strings = (
      'X-Y POSITION')
    BottomAxis.Automatic = False
    BottomAxis.AutomaticMaximum = False
    BottomAxis.AutomaticMinimum = False
    BottomAxis.Axis.Width = 1
    BottomAxis.GridCentered = True
    BottomAxis.LabelsMultiLine = True
    BottomAxis.Maximum = 2500.000000000000000000
    BottomAxis.Minimum = -2500.000000000000000000
    Chart3DPercent = 1
    LeftAxis.Automatic = False
    LeftAxis.AutomaticMaximum = False
    LeftAxis.AutomaticMinimum = False
    LeftAxis.Axis.Width = 1
    LeftAxis.GridCentered = True
    LeftAxis.Maximum = 2500.000000000000000000
    LeftAxis.Minimum = -2500.000000000000000000
    Legend.Color = 16777088
    Legend.DividingLines.Visible = True
    Legend.ResizeChart = False
    Legend.Visible = False
    RightAxis.Visible = False
    TopAxis.Visible = False
    View3D = False
    View3DOptions.ZoomText = False
    BevelInner = bvLowered
    BorderStyle = bsSingle
    Color = clBlack
    TabOrder = 56
    object Series5: TPointSeries
      Marks.ArrowLength = 0
      Marks.Visible = False
      SeriesColor = 4259584
      Pointer.Brush.Color = clRed
      Pointer.HorizSize = 1
      Pointer.InflateMargins = True
      Pointer.Pen.Color = clRed
      Pointer.Pen.Width = 2
      Pointer.Pen.Visible = False
      Pointer.Style = psRectangle
      Pointer.VertSize = 1
      Pointer.Visible = True
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
  object GraphY: TChart
    Left = 0
    Top = 140
    Width = 512
    Height = 138
    BackWall.Brush.Color = clWhite
    BackWall.Brush.Style = bsClear
    Gradient.EndColor = 16744448
    Gradient.Visible = True
    LeftWall.Color = 16777088
    LeftWall.Pen.Color = clAqua
    MarginRight = 10
    Title.Color = 16777088
    Title.Font.Charset = DEFAULT_CHARSET
    Title.Font.Color = clTeal
    Title.Font.Height = -12
    Title.Font.Name = 'Arial'
    Title.Font.Style = [fsBold]
    Title.Frame.Width = 2
    Title.Frame.Visible = True
    Title.Text.Strings = (
      'Velocity')
    BottomAxis.Automatic = False
    BottomAxis.AutomaticMaximum = False
    BottomAxis.AutomaticMinimum = False
    BottomAxis.LabelsMultiLine = True
    BottomAxis.Maximum = 5000.000000000000000000
    Chart3DPercent = 1
    LeftAxis.Automatic = False
    LeftAxis.AutomaticMaximum = False
    LeftAxis.AutomaticMinimum = False
    LeftAxis.Maximum = 500.000000000000000000
    LeftAxis.Minimum = 2.000000000000000000
    Legend.Color = 16777088
    Legend.Visible = False
    View3D = False
    View3DOptions.ZoomText = False
    BorderStyle = bsSingle
    Color = clBlack
    TabOrder = 57
    object Series3: TFastLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clYellow
      Title = 'Series3'
      LinePen.Color = clYellow
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
    object Series4: TFastLineSeries
      Marks.ArrowLength = 8
      Marks.Visible = False
      SeriesColor = clAqua
      Title = 'Series4'
      LinePen.Color = clAqua
      XValues.DateTime = False
      XValues.Name = 'X'
      XValues.Multiplier = 1.000000000000000000
      XValues.Order = loAscending
      YValues.DateTime = False
      YValues.Name = 'Y'
      YValues.Multiplier = 1.000000000000000000
      YValues.Order = loNone
    end
  end
  object tmDisplay: TTimer
    Interval = 30
    OnTimer = tmDisplayTimer
    Left = 274
    Top = 282
  end
  object tmGraph: TTimer
    Interval = 50
    OnTimer = tmGraphTimer
    Left = 306
    Top = 282
  end
  object tmHome1: TTimer
    Enabled = False
    Interval = 100
    OnTimer = tmHomeTimer
    Left = 362
    Top = 282
  end
  object tmHome2: TTimer
    Tag = 1
    Enabled = False
    Interval = 100
    OnTimer = tmHomeTimer
    Left = 394
    Top = 283
  end
  object tmHome3: TTimer
    Tag = 2
    Enabled = False
    Interval = 100
    OnTimer = tmHomeTimer
    Left = 426
    Top = 283
  end
  object tmHome4: TTimer
    Tag = 3
    Enabled = False
    Interval = 100
    OnTimer = tmHomeTimer
    Left = 458
    Top = 283
  end
  object OpenDialog1: TOpenDialog
    Left = 792
    Top = 296
  end
  object SaveDialog1: TSaveDialog
    Left = 792
    Top = 336
  end
end
