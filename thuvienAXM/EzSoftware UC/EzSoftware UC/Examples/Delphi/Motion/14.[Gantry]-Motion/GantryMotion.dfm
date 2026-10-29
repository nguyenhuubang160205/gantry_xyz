object Form1: TForm1
  Left = 2344
  Top = 1150
  BorderIcons = [biSystemMenu]
  Caption = 'GantryMotion'
  ClientHeight = 534
  ClientWidth = 479
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
    Left = 12
    Top = 12
    Width = 455
    Height = 30
    TabOrder = 0
    object Label1: TLabel
      Left = 12
      Top = 9
      Width = 93
      Height = 16
      Caption = 'Select Axis No :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboSelAxis: TComboBox
      Left = 133
      Top = 7
      Width = 195
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboSelAxisChange
    end
    object btnLoadFile: TButton
      Left = 333
      Top = 7
      Width = 113
      Height = 20
      Caption = 'Load File'
      TabOrder = 1
      OnClick = btnLoadFileClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 12
    Top = 46
    Width = 455
    Height = 142
    Caption = 'Position Monitor'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Label8: TLabel
      Left = 9
      Top = 38
      Width = 119
      Height = 16
      Caption = 'Command Position :'
    end
    object Label9: TLabel
      Left = 9
      Top = 65
      Width = 119
      Height = 16
      Caption = 'Feedback Position :'
    end
    object Label10: TLabel
      Left = 9
      Top = 92
      Width = 119
      Height = 16
      Caption = 'Command Velocity :'
    end
    object stcAxisNoMa: TLabel
      Left = 148
      Top = 16
      Width = 64
      Height = 16
      Caption = 'Ma Axis 00'
    end
    object stcAxisNoSl: TLabel
      Left = 249
      Top = 16
      Width = 57
      Height = 16
      Caption = 'Sl Axis 00'
    end
    object stcGantryState: TLabel
      Left = 225
      Top = 13
      Width = 9
      Height = 24
      Caption = #8734
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -20
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object stcCmdPosMa: TEdit
      Left = 133
      Top = 36
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '0.000'
    end
    object btnPosClear: TButton
      Left = 332
      Top = 36
      Width = 113
      Height = 49
      Caption = 'Position Clear'
      TabOrder = 1
      OnClick = btnPosClearClick
    end
    object chkServoOn: TCheckBox
      Left = 350
      Top = 91
      Width = 80
      Height = 24
      Caption = 'Servo On'
      TabOrder = 2
      OnClick = chkServoOnClick
    end
    object stcCmdPosSL: TEdit
      Left = 231
      Top = 36
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '0.000'
    end
    object stcActPosMa: TEdit
      Left = 133
      Top = 63
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      Text = '0.000'
    end
    object stcActPosSL: TEdit
      Left = 231
      Top = 63
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '0.000'
    end
    object stcCmdVelMa: TEdit
      Left = 133
      Top = 90
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '0.000'
    end
    object stcCmdVelSL: TEdit
      Left = 231
      Top = 90
      Width = 95
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '0.000'
    end
    object chkHomeStateMa: TCheckBox
      Left = 133
      Top = 116
      Width = 96
      Height = 24
      Caption = 'Home State'
      Enabled = False
      TabOrder = 8
    end
    object chkHomeStateSL: TCheckBox
      Left = 231
      Top = 116
      Width = 93
      Height = 24
      Caption = 'Home State'
      Enabled = False
      TabOrder = 9
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 193
    Width = 455
    Height = 161
    Caption = 'Position Move'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label2: TLabel
      Left = 9
      Top = 42
      Width = 118
      Height = 16
      Caption = 'Target Position        :'
    end
    object Label4: TLabel
      Left = 9
      Top = 70
      Width = 118
      Height = 16
      Caption = 'Move Velocity          :'
    end
    object Label15: TLabel
      Left = 9
      Top = 99
      Width = 121
      Height = 16
      Caption = 'Move Acceleration  :'
    end
    object Label12: TLabel
      Left = 9
      Top = 128
      Width = 120
      Height = 16
      Caption = 'Move Deceleration :'
    end
    object edtMovePos: TEdit
      Left = 133
      Top = 39
      Width = 195
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtMoveVel: TEdit
      Left = 133
      Top = 68
      Width = 195
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '100.000'
    end
    object edtMoveAcc: TEdit
      Left = 133
      Top = 97
      Width = 195
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object rdoAbs: TRadioButton
      Left = 133
      Top = 18
      Width = 100
      Height = 17
      Caption = '[00] Absolute'
      TabOrder = 3
      OnClick = rdoAbsClick
    end
    object rdoRel: TRadioButton
      Left = 232
      Top = 18
      Width = 100
      Height = 17
      Caption = '[01] Relative'
      TabOrder = 4
      OnClick = rdoRelClick
    end
    object btnMovePos: TButton
      Left = 332
      Top = 39
      Width = 113
      Height = 24
      Caption = 'Move Target'
      TabOrder = 5
      OnClick = btnMovePosClick
    end
    object btnMoveStop: TButton
      Left = 332
      Top = 68
      Width = 113
      Height = 24
      Caption = 'Move Stop'
      TabOrder = 6
      OnClick = btnMoveStopClick
    end
    object edtMoveDec: TEdit
      Left = 133
      Top = 126
      Width = 195
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '400.000'
    end
    object btnJogMoveP: TButton
      Left = 332
      Top = 97
      Width = 113
      Height = 24
      Caption = 'Move Jog(+)'
      TabOrder = 8
      OnMouseDown = btnJogMovePMouseDown
      OnMouseUp = btnJogMovePMouseUp
    end
    object btnJogMoveN: TButton
      Left = 332
      Top = 126
      Width = 113
      Height = 24
      Caption = 'Move Jog(-)'
      TabOrder = 9
      OnMouseDown = btnJogMoveNMouseDown
      OnMouseUp = btnJogMoveNMouseUp
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 440
    Width = 455
    Height = 83
    Caption = '< Gantry Enable >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label19: TLabel
      Left = 9
      Top = 25
      Width = 121
      Height = 16
      Caption = 'Block Start Position :'
    end
    object Label20: TLabel
      Left = 9
      Top = 53
      Width = 121
      Height = 16
      Caption = 'Block End Position  :'
    end
    object Shape2: TShape
      Left = 332
      Top = 50
      Width = 120
      Height = 3
    end
    object Shape1: TShape
      Left = 232
      Top = 22
      Width = 3
      Height = 52
    end
    object Label13: TLabel
      Left = 241
      Top = 25
      Width = 90
      Height = 16
      Caption = 'Slave Hm Use:'
    end
    object edtGantryHmOffset: TEdit
      Left = 133
      Top = 22
      Width = 95
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '1000.000'
    end
    object edtGantryHmRange: TEdit
      Left = 133
      Top = 51
      Width = 95
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '1000.000'
    end
    object chkGantryEnable: TCheckBox
      Left = 340
      Top = 54
      Width = 105
      Height = 24
      Caption = 'Gantry Enable'
      TabOrder = 2
      OnClick = chkGantryEnableClick
    end
    object cboGantryHmSlaveUse: TComboBox
      Left = 332
      Top = 22
      Width = 113
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Items.Strings = (
        '00: NONE'
        '01: BOTH'
        '02: EACH')
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 361
    Width = 455
    Height = 73
    Caption = '< Home Search >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label5: TLabel
      Left = 10
      Top = 45
      Width = 104
      Height = 16
      Caption = 'Home Step/Rate:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 9
      Top = 20
      Width = 105
      Height = 16
      Caption = 'Home Result        :'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object btnHomeStart: TButton
      Left = 332
      Top = 14
      Width = 113
      Height = 23
      Caption = 'Home Start'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      OnClick = btnHomeStartClick
    end
    object btnHomeStop: TButton
      Left = 332
      Top = 41
      Width = 113
      Height = 23
      Caption = 'Move Stop'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      OnClick = btnHomeStopClick
    end
    object stcHomeResult: TEdit
      Left = 107
      Top = 15
      Width = 220
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = ' [FFH] HOME_ERR_UNKNOWN'
    end
    object stcHomeStepMain: TEdit
      Left = 107
      Top = 41
      Width = 30
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '100'
    end
    object stcHomeStepSub: TEdit
      Left = 139
      Top = 41
      Width = 30
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      Text = '100'
    end
    object prgHomeRate: TProgressBar
      Left = 171
      Top = 41
      Width = 156
      Height = 21
      Step = 1
      TabOrder = 5
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 437
    Top = 12
  end
  object m_timerDisplay: TTimer
    Interval = 100
    OnTimer = m_timerDisplayTimer
  end
  object m_timerHomeInfo: TTimer
    Interval = 200
    OnTimer = m_timerHomeInfoTimer
    Left = 32
  end
end
