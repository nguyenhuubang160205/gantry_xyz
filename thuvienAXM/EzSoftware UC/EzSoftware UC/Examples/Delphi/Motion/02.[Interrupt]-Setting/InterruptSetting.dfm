object Form1: TForm1
  Left = 855
  Top = 319
  BorderIcons = [biSystemMenu]
  Caption = 'InterruptSetting'
  ClientHeight = 539
  ClientWidth = 517
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
  object GroupBox1: TGroupBox
    Left = 13
    Top = 8
    Width = 460
    Height = 30
    TabOrder = 0
    object Label1: TLabel
      Left = 12
      Top = 9
      Width = 96
      Height = 16
      Caption = 'Select Axis No : '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboSelAxis: TComboBox
      Left = 109
      Top = 7
      Width = 340
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboSelAxisChange
    end
  end
  object grpBank1: TGroupBox
    Left = 12
    Top = 47
    Width = 460
    Height = 126
    Caption = '< Interrupt Event Bank 1 [0x00000000] >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Shape1: TShape
      Left = 33
      Top = 90
      Width = 416
      Height = 3
    end
    object chkBank1Bit00: TCheckBox
      Left = 16
      Top = 24
      Width = 353
      Height = 17
      Caption = '[Bit 00] When drive set interrupt occurrence use is exited'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object chkBank1Bit01: TCheckBox
      Left = 16
      Top = 46
      Width = 353
      Height = 17
      Caption = '[Bit 01] When drive is exited'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
    end
    object chkBank1Bit02: TCheckBox
      Left = 16
      Top = 68
      Width = 193
      Height = 17
      Caption = '[Bit 02] When drive started'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
    end
    object chkBank1Bit31: TCheckBox
      Left = 16
      Top = 98
      Width = 305
      Height = 17
      Caption = '[Bit 31] Interrupt occurrence command execution'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object btnSetBank1: TButton
      Left = 336
      Top = 99
      Width = 122
      Height = 25
      Caption = 'Set Bank 1'
      TabOrder = 4
      OnClick = btnSetBank1Click
    end
  end
  object grpBank2: TGroupBox
    Left = 12
    Top = 183
    Width = 460
    Height = 174
    Caption = '< Interrupt Event Bank 2 [0x00000000] >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Shape2: TShape
      Left = 33
      Top = 90
      Width = 416
      Height = 3
    end
    object chkBank2Bit14: TCheckBox
      Left = 16
      Top = 24
      Width = 361
      Height = 17
      Caption = '[Bit 14] UOut 0 terminal signal is changed to '#39'1'#39' (Servo On) '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object chkBank2Bit15: TCheckBox
      Left = 16
      Top = 46
      Width = 377
      Height = 17
      Caption = '[Bit 15] UOut 1 terminal signal is changed to '#39'1'#39' (Alarm Clear)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
    end
    object chkBank2Bit16: TCheckBox
      Left = 16
      Top = 68
      Width = 297
      Height = 17
      Caption = '[Bit 16] UOut 2 terminal signal is changed to '#39'1'#39
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
    end
    object chkBank2Bit20: TCheckBox
      Left = 16
      Top = 98
      Width = 393
      Height = 17
      Caption = 
        '[Bit 20] UInput 0 terminal signal is changed to '#39'1'#39' (Home Signal' +
        ')'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object btnSetBank2: TButton
      Left = 336
      Top = 147
      Width = 122
      Height = 25
      Caption = 'Set Bank 2'
      TabOrder = 4
      OnClick = btnSetBank2Click
    end
    object chkBank2Bit21: TCheckBox
      Left = 16
      Top = 120
      Width = 409
      Height = 17
      Caption = 
        '[Bit 21] UInput 1 terminal signal is changed to '#39'1'#39' (Z-Phase Sig' +
        'nal)'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 5
    end
    object chkBank2Bit22: TCheckBox
      Left = 16
      Top = 142
      Width = 305
      Height = 17
      Caption = '[Bit 22] UInput 2 terminal signal is changed to '#39'1'#39
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 6
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 367
    Width = 325
    Height = 54
    Caption = '< Interrupt Method >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object rdoMessage: TRadioButton
      Left = 16
      Top = 24
      Width = 81
      Height = 17
      Caption = 'Message'
      TabOrder = 0
    end
    object rdoCallback: TRadioButton
      Left = 128
      Top = 24
      Width = 81
      Height = 17
      Caption = 'Callback'
      TabOrder = 1
    end
    object rdoEvent: TRadioButton
      Left = 232
      Top = 24
      Width = 81
      Height = 17
      Caption = 'Event'
      TabOrder = 2
    end
  end
  object chkIntEnable: TCheckBox
    Left = 350
    Top = 388
    Width = 123
    Height = 25
    Caption = 'Interrupt Enable'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = chkIntEnableClick
  end
  object lstIntLog: TListBox
    Left = 12
    Top = 428
    Width = 460
    Height = 97
    ImeName = 'Microsoft IME 2010'
    ItemHeight = 13
    TabOrder = 5
    OnDblClick = lstIntLogDblClick
  end
end
