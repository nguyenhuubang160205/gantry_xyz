object Form1: TForm1
  Left = 2607
  Top = 1298
  BorderIcons = [biSystemMenu]
  Caption = 'MoveSignalCapture'
  ClientHeight = 512
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
    Height = 105
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
      Width = 119
      Height = 16
      Caption = 'Command Position :'
    end
    object Label9: TLabel
      Left = 9
      Top = 47
      Width = 119
      Height = 16
      Caption = 'Feedback Position :'
    end
    object Label10: TLabel
      Left = 9
      Top = 74
      Width = 119
      Height = 16
      Caption = 'Command Velocity :'
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
      Left = 133
      Top = 18
      Width = 124
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '0.000'
    end
    object stcActPos: TEdit
      Left = 133
      Top = 45
      Width = 124
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '0.000'
    end
    object stcCmdVel: TEdit
      Left = 133
      Top = 72
      Width = 124
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
    Top = 268
    Width = 455
    Height = 230
    Caption = '< Signal Capture Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label4: TLabel
      Left = 9
      Top = 25
      Width = 118
      Height = 16
      Caption = 'Move Velocity          :'
    end
    object Label7: TLabel
      Left = 262
      Top = 25
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label14: TLabel
      Left = 9
      Top = 104
      Width = 118
      Height = 16
      Caption = 'Velocity Profile Set :'
    end
    object Label15: TLabel
      Left = 9
      Top = 52
      Width = 118
      Height = 16
      Caption = 'Move Acceleration :'
    end
    object Label16: TLabel
      Left = 262
      Top = 52
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label2: TLabel
      Left = 9
      Top = 78
      Width = 119
      Height = 16
      Caption = 'Detect Signal            :'
    end
    object Label3: TLabel
      Left = 9
      Top = 105
      Width = 119
      Height = 16
      Caption = 'Signal Edge              :'
    end
    object Label5: TLabel
      Left = 9
      Top = 132
      Width = 117
      Height = 16
      Caption = 'Capture Target        :'
    end
    object Label6: TLabel
      Left = 9
      Top = 158
      Width = 118
      Height = 16
      Caption = 'Stop Method             :'
    end
    object Shape2: TShape
      Left = 9
      Top = 187
      Width = 435
      Height = 3
    end
    object Label17: TLabel
      Left = 9
      Top = 198
      Width = 116
      Height = 16
      Caption = 'Capture Position     :'
    end
    object edtMoveVel: TEdit
      Left = 133
      Top = 23
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object cboDetectSig: TComboBox
      Left = 133
      Top = 77
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 2
      TabOrder = 1
      Text = '04: HomeSensor'
      Items.Strings = (
        '00: PosEndLimit'
        '01: NegEndLimit'
        '04: HomeSensor'
        '05: EncodZPhase'
        '06: UniInput02'
        '07: UniInput03')
    end
    object edtMoveAcc: TEdit
      Left = 133
      Top = 50
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object btnCaptureMove: TButton
      Left = 332
      Top = 23
      Width = 113
      Height = 74
      Caption = 'Capture Move'
      TabOrder = 3
      OnClick = btnCaptureMoveClick
    end
    object btnMoveStop: TButton
      Left = 332
      Top = 105
      Width = 113
      Height = 74
      Caption = 'Move Stop'
      TabOrder = 4
      OnClick = btnMoveStopClick
    end
    object cboSignalEdge: TComboBox
      Left = 133
      Top = 104
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 1
      TabOrder = 5
      Text = '01: SIGNAL_UP_EDGE'
      Items.Strings = (
        '00: SIGNAL_DOWN_EDGE'
        '01: SIGNAL_UP_EDGE')
    end
    object cboCaptureTarget: TComboBox
      Left = 133
      Top = 131
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 0
      TabOrder = 6
      Text = '00: COMMAND'
      Items.Strings = (
        '00: COMMAND'
        '01: ACTUAL')
    end
    object cboStopMethod: TComboBox
      Left = 133
      Top = 157
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 1
      TabOrder = 7
      Text = '01: SLOWDOWN_STOP'
      Items.Strings = (
        '00: EMERGENCY_STOP'
        '01: SLOWDOWN_STOP')
    end
    object stcCapturePos: TEdit
      Left = 133
      Top = 196
      Width = 194
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
      Text = 'xxx.xxx'
    end
    object btnGetPos: TButton
      Left = 332
      Top = 196
      Width = 113
      Height = 24
      Caption = 'Get Position'
      TabOrder = 9
      OnClick = btnGetPosClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 157
    Width = 455
    Height = 105
    Caption = '< Jog(Velocity) Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label19: TLabel
      Left = 9
      Top = 20
      Width = 119
      Height = 16
      Caption = 'Jog Velocity              :'
    end
    object Label20: TLabel
      Left = 9
      Top = 47
      Width = 119
      Height = 16
      Caption = 'Jog Acceleration     :'
    end
    object Label21: TLabel
      Left = 9
      Top = 74
      Width = 118
      Height = 16
      Caption = 'Jog Deceleration    :'
    end
    object Label22: TLabel
      Left = 262
      Top = 20
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label23: TLabel
      Left = 262
      Top = 47
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label24: TLabel
      Left = 262
      Top = 74
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object edtJogVel: TEdit
      Left = 133
      Top = 18
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtJogAcc: TEdit
      Left = 133
      Top = 45
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '400.000'
    end
    object edtJogDec: TEdit
      Left = 133
      Top = 72
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object btnJogMoveP: TButton
      Left = 332
      Top = 15
      Width = 113
      Height = 38
      Caption = 'Jog Move(+)'
      TabOrder = 3
      OnMouseDown = btnJogMovePMouseDown
      OnMouseUp = btnJogMovePMouseUp
    end
    object btnJogMoveN: TButton
      Left = 332
      Top = 55
      Width = 113
      Height = 38
      Caption = 'Jog Move(-)'
      TabOrder = 4
      OnMouseDown = btnJogMoveNMouseDown
      OnMouseUp = btnJogMoveNMouseUp
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 437
    Top = 12
  end
  object m_timer: TTimer
    Interval = 100
    OnTimer = m_timerTimer
  end
end
