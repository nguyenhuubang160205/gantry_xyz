object Form1: TForm1
  Left = 2549
  Top = 1324
  BorderIcons = [biSystemMenu]
  Caption = 'MoveMultiAxes'
  ClientHeight = 540
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
    Height = 119
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
      Top = 36
      Width = 95
      Height = 16
      Caption = 'Command Pos :'
    end
    object Label9: TLabel
      Left = 9
      Top = 63
      Width = 95
      Height = 16
      Caption = 'Feedback Pos :'
    end
    object Label10: TLabel
      Left = 9
      Top = 90
      Width = 94
      Height = 16
      Caption = 'Command Vel  :'
    end
    object stcCmdPos00: TEdit
      Left = 108
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '0.000'
    end
    object stcActPos00: TEdit
      Left = 108
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '0.000'
    end
    object stcCmdVel00: TEdit
      Left = 108
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '0.000'
    end
    object btnPosClear: TButton
      Left = 365
      Top = 34
      Width = 80
      Height = 50
      Caption = 'Clear'
      TabOrder = 3
      OnClick = btnPosClearClick
    end
    object chkServoOn: TCheckBox
      Left = 366
      Top = 89
      Width = 80
      Height = 24
      Caption = 'Servo On'
      TabOrder = 4
      OnClick = chkServoOnClick
    end
    object stcCmdPos01: TEdit
      Left = 171
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '0.000'
    end
    object stcCmdPos02: TEdit
      Left = 234
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '0.000'
    end
    object stcCmdPos03: TEdit
      Left = 297
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '0.000'
    end
    object chkAxis00: TCheckBox
      Left = 108
      Top = 15
      Width = 65
      Height = 17
      Caption = 'Axis00'
      TabOrder = 8
      OnClick = chkAxis00Click
    end
    object chkAxis01: TCheckBox
      Left = 171
      Top = 15
      Width = 65
      Height = 17
      Caption = 'Axis01'
      TabOrder = 9
      OnClick = chkAxis01Click
    end
    object chkAxis02: TCheckBox
      Left = 234
      Top = 15
      Width = 65
      Height = 17
      Caption = 'Axis02'
      TabOrder = 10
      OnClick = chkAxis02Click
    end
    object chkAxis03: TCheckBox
      Left = 297
      Top = 15
      Width = 65
      Height = 17
      Caption = 'Axis03'
      TabOrder = 11
      OnClick = chkAxis03Click
    end
    object stcActPos01: TEdit
      Left = 171
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 12
      Text = '0.000'
    end
    object stcActPos02: TEdit
      Left = 234
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 13
      Text = '0.000'
    end
    object stcActPos03: TEdit
      Left = 297
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 14
      Text = '0.000'
    end
    object stcCmdVel01: TEdit
      Left = 171
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 15
      Text = '0.000'
    end
    object stcCmdVel02: TEdit
      Left = 234
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 16
      Text = '0.000'
    end
    object stcCmdVel03: TEdit
      Left = 297
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 17
      Text = '0.000'
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 172
    Width = 455
    Height = 130
    Caption = '< Multi Position Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label2: TLabel
      Left = 9
      Top = 46
      Width = 97
      Height = 16
      Caption = 'Move Velocity   :'
    end
    object Label3: TLabel
      Left = 9
      Top = 73
      Width = 95
      Height = 16
      Caption = 'Move Accel       :'
    end
    object Label4: TLabel
      Left = 9
      Top = 100
      Width = 94
      Height = 16
      Caption = 'Move Decel      :'
    end
    object Label5: TLabel
      Left = 9
      Top = 21
      Width = 97
      Height = 16
      Caption = 'Target Position :'
    end
    object edtMoveVel00: TEdit
      Left = 108
      Top = 44
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtMoveAcc00: TEdit
      Left = 108
      Top = 71
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '400.000'
    end
    object edtMoveDec00: TEdit
      Left = 108
      Top = 98
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object btnPosMove: TButton
      Left = 365
      Top = 42
      Width = 80
      Height = 36
      Caption = 'Move'
      TabOrder = 3
      OnClick = btnPosMoveClick
    end
    object chkMoveBlock: TCheckBox
      Left = 367
      Top = 19
      Width = 60
      Height = 24
      Caption = 'Block'
      TabOrder = 4
    end
    object edtMoveVel01: TEdit
      Left = 171
      Top = 44
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '100.000'
    end
    object edtMoveVel02: TEdit
      Left = 234
      Top = 44
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '100.000'
    end
    object edtMoveVel03: TEdit
      Left = 297
      Top = 44
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '100.000'
    end
    object edtMoveAcc01: TEdit
      Left = 171
      Top = 71
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
      Text = '400.000'
    end
    object edtMoveAcc02: TEdit
      Left = 234
      Top = 71
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 9
      Text = '400.000'
    end
    object edtMoveAcc03: TEdit
      Left = 297
      Top = 71
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 10
      Text = '400.000'
    end
    object edtMoveDec01: TEdit
      Left = 171
      Top = 98
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 11
      Text = '400.000'
    end
    object edtMoveDec02: TEdit
      Left = 234
      Top = 98
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 12
      Text = '400.000'
    end
    object edtMoveDec03: TEdit
      Left = 297
      Top = 98
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 13
      Text = '400.000'
    end
    object edtMovePos00: TEdit
      Left = 108
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 14
      Text = '100.000'
    end
    object edtMovePos01: TEdit
      Left = 171
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 15
      Text = '100.000'
    end
    object edtMovePos02: TEdit
      Left = 234
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 16
      Text = '100.000'
    end
    object edtMovePos03: TEdit
      Left = 297
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 17
      Text = '100.000'
    end
    object btnPosStop: TButton
      Left = 365
      Top = 84
      Width = 80
      Height = 36
      Caption = 'Stop'
      TabOrder = 18
      OnClick = btnPosStopClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 310
    Width = 455
    Height = 105
    Caption = '< Multi Jog(Velocity) Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label6: TLabel
      Left = 9
      Top = 20
      Width = 94
      Height = 16
      Caption = 'Move Velocity  :'
    end
    object Label7: TLabel
      Left = 9
      Top = 47
      Width = 92
      Height = 16
      Caption = 'Move Accel      :'
    end
    object Label11: TLabel
      Left = 9
      Top = 74
      Width = 91
      Height = 16
      Caption = 'Move Decel     :'
    end
    object edtJogVel00: TEdit
      Left = 108
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtJogAcc00: TEdit
      Left = 108
      Top = 45
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '400.000'
    end
    object edtJogDec00: TEdit
      Left = 108
      Top = 72
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object btnJogP: TButton
      Left = 365
      Top = 16
      Width = 80
      Height = 36
      Caption = 'Jog(+)'
      TabOrder = 3
      OnMouseDown = btnJogPMouseDown
      OnMouseUp = btnJogPMouseUp
    end
    object edtJogVel01: TEdit
      Left = 171
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      Text = '100.000'
    end
    object edtJogVel02: TEdit
      Left = 234
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '100.000'
    end
    object edtJogVel03: TEdit
      Left = 297
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '100.000'
    end
    object edtJogAcc01: TEdit
      Left = 171
      Top = 45
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '400.000'
    end
    object edtJogAcc02: TEdit
      Left = 234
      Top = 45
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
      Text = '400.000'
    end
    object edtJogAcc03: TEdit
      Left = 297
      Top = 45
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 9
      Text = '400.000'
    end
    object edtJogDec01: TEdit
      Left = 171
      Top = 72
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 10
      Text = '400.000'
    end
    object edtJogDec02: TEdit
      Left = 234
      Top = 72
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 11
      Text = '400.000'
    end
    object edtJogDec03: TEdit
      Left = 297
      Top = 72
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 12
      Text = '400.000'
    end
    object btnJogN: TButton
      Left = 365
      Top = 58
      Width = 80
      Height = 36
      Caption = 'Jog(-)'
      TabOrder = 13
      OnMouseDown = btnJogNMouseDown
      OnMouseUp = btnJogNMouseUp
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 423
    Width = 455
    Height = 105
    Caption = '< Multi Jog(Velocity) Line Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label12: TLabel
      Left = 9
      Top = 20
      Width = 97
      Height = 16
      Caption = 'Target Position :'
    end
    object Label13: TLabel
      Left = 9
      Top = 47
      Width = 94
      Height = 16
      Caption = 'Move Velocity  :'
    end
    object Label14: TLabel
      Left = 9
      Top = 74
      Width = 95
      Height = 16
      Caption = 'Move Acc/Dec :'
    end
    object edtLinePos00: TEdit
      Left = 108
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtLineVel: TEdit
      Left = 108
      Top = 45
      Width = 123
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '100.000'
    end
    object edtLineAcc: TEdit
      Left = 108
      Top = 72
      Width = 123
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object btnLineP: TButton
      Left = 365
      Top = 16
      Width = 80
      Height = 36
      Caption = 'Jog(+)'
      TabOrder = 3
      OnMouseDown = btnLinePMouseDown
      OnMouseUp = btnLinePMouseUp
    end
    object edtLinePos01: TEdit
      Left = 171
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      Text = '100.000'
    end
    object edtLinePos02: TEdit
      Left = 234
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '100.000'
    end
    object edtLinePos03: TEdit
      Left = 297
      Top = 18
      Width = 60
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '100.000'
    end
    object edtLineDec: TEdit
      Left = 234
      Top = 72
      Width = 123
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
      Text = '200.000'
    end
    object btnLineN: TButton
      Left = 365
      Top = 58
      Width = 80
      Height = 36
      Caption = 'Jog(-)'
      TabOrder = 8
      OnMouseDown = btnLineNMouseDown
      OnMouseUp = btnLineNMouseUp
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
