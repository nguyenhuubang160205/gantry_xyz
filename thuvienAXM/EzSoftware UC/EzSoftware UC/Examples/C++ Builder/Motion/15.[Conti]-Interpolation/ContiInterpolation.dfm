object Form1: TForm1
  Left = 2602
  Top = 1336
  BorderIcons = [biSystemMenu]
  Caption = 'ContiInterpolation'
  ClientHeight = 507
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
      TabOrder = 0
      Text = '0.000'
    end
    object stcActPos00: TEdit
      Left = 108
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 1
      Text = '0.000'
    end
    object stcCmdVel00: TEdit
      Left = 108
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 2
      Text = '0.000'
    end
    object btnPosClear: TButton
      Left = 370
      Top = 34
      Width = 75
      Height = 50
      Caption = 'Clear'
      TabOrder = 3
      OnClick = btnPosClearClick
    end
    object chkServoOn: TCheckBox
      Left = 371
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
      TabOrder = 5
      Text = '0.000'
    end
    object stcCmdPos02: TEdit
      Left = 234
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 6
      Text = '0.000'
    end
    object stcCmdPos03: TEdit
      Left = 297
      Top = 34
      Width = 60
      Height = 24
      Enabled = False
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
      TabOrder = 12
      Text = '0.000'
    end
    object stcActPos02: TEdit
      Left = 234
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 13
      Text = '0.000'
    end
    object stcActPos03: TEdit
      Left = 297
      Top = 61
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 14
      Text = '0.000'
    end
    object stcCmdVel01: TEdit
      Left = 171
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 15
      Text = '0.000'
    end
    object stcCmdVel02: TEdit
      Left = 234
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 16
      Text = '0.000'
    end
    object stcCmdVel03: TEdit
      Left = 297
      Top = 88
      Width = 60
      Height = 24
      Enabled = False
      TabOrder = 17
      Text = '0.000'
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 172
    Width = 455
    Height = 77
    Caption = '< Interpolation Monitor >'
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
      Width = 165
      Height = 16
      Caption = 'Interpolation Total Node      :'
    end
    object Label5: TLabel
      Left = 9
      Top = 21
      Width = 164
      Height = 16
      Caption = 'Interpolation Execute Node:'
    end
    object Shape1: TShape
      Left = 236
      Top = 18
      Width = 3
      Height = 49
    end
    object Label3: TLabel
      Left = 244
      Top = 21
      Width = 123
      Height = 16
      Caption = 'Interpolation Q Free :'
    end
    object Label4: TLabel
      Left = 243
      Top = 46
      Width = 126
      Height = 16
      Caption = 'In Interpolation Move:'
    end
    object stcIntpTotalNode: TEdit
      Left = 176
      Top = 44
      Width = 55
      Height = 24
      Enabled = False
      TabOrder = 0
      Text = '0'
    end
    object stcIntpExeNode: TEdit
      Left = 176
      Top = 18
      Width = 55
      Height = 24
      Enabled = False
      TabOrder = 1
      Text = '0'
    end
    object chkIntpQueueFree: TCheckBox
      Left = 371
      Top = 22
      Width = 16
      Height = 17
      Enabled = False
      TabOrder = 2
    end
    object chkIntpInMotion: TCheckBox
      Left = 371
      Top = 46
      Width = 16
      Height = 17
      Enabled = False
      TabOrder = 3
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 258
    Width = 455
    Height = 235
    Caption = '< Interpolation Move >'
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
      Width = 157
      Height = 16
      Caption = 'Interpolation Velocity          :'
    end
    object Label7: TLabel
      Left = 9
      Top = 47
      Width = 160
      Height = 16
      Caption = 'Interpolation Acceleration  :'
    end
    object Label11: TLabel
      Left = 9
      Top = 74
      Width = 159
      Height = 16
      Caption = 'Interpolation Deceleration :'
    end
    object Label12: TLabel
      Left = 298
      Top = 23
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label13: TLabel
      Left = 298
      Top = 49
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label14: TLabel
      Left = 298
      Top = 76
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Shape2: TShape
      Left = 9
      Top = 102
      Width = 355
      Height = 3
    end
    object Shape3: TShape
      Left = 9
      Top = 149
      Width = 355
      Height = 3
    end
    object btnIntpStop: TButton
      Left = 370
      Top = 16
      Width = 75
      Height = 125
      Caption = 'Stop'
      TabOrder = 0
      OnClick = btnIntpStopClick
    end
    object edtMoveVel: TEdit
      Left = 171
      Top = 18
      Width = 123
      Height = 24
      TabOrder = 1
      Text = '100.000'
    end
    object edtMoveAcc: TEdit
      Left = 171
      Top = 45
      Width = 123
      Height = 24
      TabOrder = 2
      Text = '400.000'
    end
    object edtMoveDec: TEdit
      Left = 171
      Top = 72
      Width = 123
      Height = 24
      TabOrder = 3
      Text = '400.000'
    end
    object btnIntpLine: TButton
      Left = 8
      Top = 112
      Width = 115
      Height = 30
      Caption = 'Line'
      TabOrder = 4
      OnClick = btnIntpLineClick
    end
    object btnIntpArc: TButton
      Left = 129
      Top = 112
      Width = 115
      Height = 30
      Caption = 'Arc(Radius)'
      TabOrder = 5
      OnClick = btnIntpArcClick
    end
    object btnIntpCircle: TButton
      Left = 250
      Top = 112
      Width = 115
      Height = 30
      Caption = 'CirCle(Angle)'
      TabOrder = 6
      OnClick = btnIntpCircleClick
    end
    object btnIntpLineArc: TButton
      Left = 8
      Top = 158
      Width = 115
      Height = 64
      Caption = 'Line && Arc'
      TabOrder = 7
      OnClick = btnIntpLineArcClick
    end
    object btnIntpHelical: TButton
      Left = 129
      Top = 158
      Width = 115
      Height = 64
      Caption = 'Helical'
      TabOrder = 8
      OnClick = btnIntpHelicalClick
    end
    object btnIntpSpline: TButton
      Left = 250
      Top = 158
      Width = 115
      Height = 64
      Caption = 'Spline'
      TabOrder = 9
      OnClick = btnIntpSplineClick
    end
    object btnIntpStart: TButton
      Left = 371
      Top = 158
      Width = 75
      Height = 30
      Caption = 'Start'
      TabOrder = 10
      OnClick = btnIntpStartClick
    end
    object btnIntpClear: TButton
      Left = 371
      Top = 192
      Width = 75
      Height = 30
      Caption = 'Clear'
      TabOrder = 11
      OnClick = btnIntpClearClick
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
