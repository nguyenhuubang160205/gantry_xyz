object Form1: TForm1
  Left = 1335
  Top = 469
  BorderIcons = [biSystemMenu]
  Caption = 'HomeSearch'
  ClientHeight = 537
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
      Left = 108
      Top = 7
      Width = 220
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
    Height = 99
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
      Top = 20
      Width = 95
      Height = 16
      Caption = 'Command Pos :'
    end
    object Label9: TLabel
      Left = 9
      Top = 47
      Width = 95
      Height = 16
      Caption = 'Feedback Pos :'
    end
    object Label10: TLabel
      Left = 9
      Top = 74
      Width = 91
      Height = 16
      Caption = 'Command Vel :'
    end
    object Label11: TLabel
      Left = 262
      Top = 20
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label12: TLabel
      Left = 262
      Top = 47
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label13: TLabel
      Left = 262
      Top = 74
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object stcCmdPos: TEdit
      Left = 107
      Top = 18
      Width = 150
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '0.000'
    end
    object stcActPos: TEdit
      Left = 107
      Top = 45
      Width = 150
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '0.000'
    end
    object stcCmdVel: TEdit
      Left = 107
      Top = 72
      Width = 150
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '0.000'
    end
    object btnPosClear: TButton
      Left = 332
      Top = 15
      Width = 113
      Height = 44
      Caption = 'Position Clear'
      TabOrder = 3
      OnClick = btnPosClearClick
    end
    object chkServoOn: TCheckBox
      Left = 350
      Top = 68
      Width = 80
      Height = 24
      Caption = 'Servo On'
      TabOrder = 4
      OnClick = chkServoOnClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 157
    Width = 455
    Height = 46
    Caption = '< Home Signal Level >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Shape2: TShape
      Left = 233
      Top = 18
      Width = 3
      Height = 20
    end
    object Label2: TLabel
      Left = 242
      Top = 21
      Width = 85
      Height = 16
      Caption = 'Home Level   :'
    end
    object chkHomeState: TCheckBox
      Left = 11
      Top = 20
      Width = 150
      Height = 16
      Caption = 'Home SIgnal State'
      Enabled = False
      TabOrder = 0
    end
    object cboHomeLevel: TComboBox
      Left = 332
      Top = 16
      Width = 113
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      OnChange = cboHomeLevelChange
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 212
    Width = 455
    Height = 99
    Caption = '< Home Method Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Shape3: TShape
      Left = 233
      Top = 15
      Width = 3
      Height = 50
    end
    object Label3: TLabel
      Left = 9
      Top = 20
      Width = 96
      Height = 16
      Caption = 'Home Direction:'
    end
    object Label14: TLabel
      Left = 9
      Top = 47
      Width = 100
      Height = 16
      Caption = 'Home Set Offset:'
    end
    object Label15: TLabel
      Left = 9
      Top = 74
      Width = 99
      Height = 16
      Caption = 'Home Clr Time  :'
    end
    object Label16: TLabel
      Left = 242
      Top = 20
      Width = 87
      Height = 16
      Caption = 'Home Signal  :'
    end
    object Label17: TLabel
      Left = 242
      Top = 47
      Width = 87
      Height = 16
      Caption = 'Z Phase Use  :'
    end
    object Label18: TLabel
      Left = 231
      Top = 74
      Width = 35
      Height = 16
      Caption = 'mSec'
    end
    object cboHomeDir: TComboBox
      Left = 107
      Top = 15
      Width = 120
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Items.Strings = (
        '00: -DIR_CCW'
        '01: +DIR_CW')
    end
    object edtHomeOffset: TEdit
      Left = 107
      Top = 45
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object edtHomeClrTime: TEdit
      Left = 107
      Top = 71
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object cboHomeSignal: TComboBox
      Left = 332
      Top = 15
      Width = 113
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object cboZPhaseUse: TComboBox
      Left = 332
      Top = 45
      Width = 113
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
    end
    object btnSetMethod: TButton
      Left = 332
      Top = 76
      Width = 123
      Height = 23
      Caption = 'Set Method'
      TabOrder = 5
      OnClick = btnSetMethodClick
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 454
    Width = 455
    Height = 73
    Caption = '< Home Search >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label4: TLabel
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
    object btnMoveStop: TButton
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
      OnClick = btnMoveStopClick
    end
    object stcHomeResult: TEdit
      Left = 107
      Top = 15
      Width = 220
      Height = 21
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = ' [FFH] HOME_ERR_UNKNOWN'
    end
    object stcHomeStepMain: TEdit
      Left = 107
      Top = 41
      Width = 30
      Height = 21
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '100'
    end
    object stcHomeStepSub: TEdit
      Left = 139
      Top = 41
      Width = 30
      Height = 21
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
  object GroupBox6: TGroupBox
    Left = 12
    Top = 320
    Width = 455
    Height = 125
    Caption = '< Home Velocity Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    object Shape1: TShape
      Left = 233
      Top = 15
      Width = 3
      Height = 100
    end
    object Label19: TLabel
      Left = 9
      Top = 20
      Width = 91
      Height = 16
      Caption = 'First Velocity    :'
    end
    object Label20: TLabel
      Left = 9
      Top = 47
      Width = 101
      Height = 16
      Caption = 'Second Velocity:'
    end
    object Label21: TLabel
      Left = 9
      Top = 74
      Width = 94
      Height = 16
      Caption = 'Third Velocity   :'
    end
    object Label22: TLabel
      Left = 242
      Top = 20
      Width = 89
      Height = 16
      Caption = 'First Accel        :'
    end
    object Label23: TLabel
      Left = 242
      Top = 47
      Width = 90
      Height = 16
      Caption = 'Second Accel :'
    end
    object Label6: TLabel
      Left = 9
      Top = 98
      Width = 94
      Height = 16
      Caption = 'Last Velocity     :'
    end
    object edtVelSecond: TEdit
      Left = 107
      Top = 42
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object edtVelThird: TEdit
      Left = 107
      Top = 69
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object btnSetVelocity: TButton
      Left = 332
      Top = 102
      Width = 123
      Height = 23
      Caption = 'Set Velocity'
      TabOrder = 2
      OnClick = btnSetVelocityClick
    end
    object edtVelFirst: TEdit
      Left = 107
      Top = 15
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object edtVelLast: TEdit
      Left = 107
      Top = 96
      Width = 120
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
    end
    object edtAccFirst: TEdit
      Left = 332
      Top = 15
      Width = 113
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
    end
    object edtAccSecond: TEdit
      Left = 332
      Top = 42
      Width = 113
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
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
