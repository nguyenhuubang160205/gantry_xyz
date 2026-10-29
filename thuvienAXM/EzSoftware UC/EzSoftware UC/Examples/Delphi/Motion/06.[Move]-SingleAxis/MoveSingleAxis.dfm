object Form1: TForm1
  Left = 2593
  Top = 1084
  BorderIcons = [biSystemMenu]
  Caption = 'MoveSingleAxis'
  ClientHeight = 511
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
      Left = 132
      Top = 44
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
    Top = 160
    Width = 455
    Height = 225
    Caption = '< Position Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label2: TLabel
      Left = 9
      Top = 76
      Width = 119
      Height = 16
      Caption = 'Target Position 1     :'
    end
    object Label3: TLabel
      Left = 9
      Top = 104
      Width = 119
      Height = 16
      Caption = 'Target Position 2     :'
    end
    object Label4: TLabel
      Left = 9
      Top = 133
      Width = 118
      Height = 16
      Caption = 'Move Velocity          :'
    end
    object Label5: TLabel
      Left = 262
      Top = 77
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label6: TLabel
      Left = 262
      Top = 104
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label7: TLabel
      Left = 262
      Top = 133
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label14: TLabel
      Left = 9
      Top = 46
      Width = 118
      Height = 16
      Caption = 'Velocity Profile Set :'
    end
    object Label15: TLabel
      Left = 9
      Top = 162
      Width = 118
      Height = 16
      Caption = 'Move Acceleration :'
    end
    object Label16: TLabel
      Left = 262
      Top = 162
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label17: TLabel
      Left = 9
      Top = 192
      Width = 120
      Height = 16
      Caption = 'Move Deceleration :'
    end
    object Label18: TLabel
      Left = 262
      Top = 192
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object edtPos1: TEdit
      Left = 133
      Top = 73
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '0.000'
    end
    object edtPos2: TEdit
      Left = 133
      Top = 102
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '100.000'
    end
    object edtMoveVel: TEdit
      Left = 133
      Top = 131
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '100.000'
    end
    object btnRepeat: TButton
      Left = 332
      Top = 131
      Width = 113
      Height = 38
      Caption = 'Repeat Target 2'
      TabOrder = 3
      OnClick = btnRepeatClick
    end
    object cboProfile: TComboBox
      Left = 133
      Top = 43
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      OnChange = cboProfileChange
    end
    object edtMoveAcc: TEdit
      Left = 133
      Top = 160
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '400.000'
    end
    object edtMoveDec: TEdit
      Left = 133
      Top = 190
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
      Text = '400.000'
    end
    object rdoAbs: TRadioButton
      Left = 133
      Top = 18
      Width = 100
      Height = 17
      Caption = '[00] Absolute'
      TabOrder = 7
      OnClick = rdoAbsClick
    end
    object rdoRel: TRadioButton
      Left = 232
      Top = 18
      Width = 100
      Height = 17
      Caption = '[01] Relative'
      TabOrder = 8
      OnClick = rdoRelClick
    end
    object btnMove1: TButton
      Left = 332
      Top = 73
      Width = 113
      Height = 24
      Caption = 'Move Target 1'
      TabOrder = 9
      OnClick = btnMove1Click
    end
    object btnMove2: TButton
      Left = 332
      Top = 102
      Width = 113
      Height = 24
      Caption = 'Move Target 2'
      TabOrder = 10
      OnClick = btnMove2Click
    end
    object btnSStop: TButton
      Left = 332
      Top = 173
      Width = 113
      Height = 38
      Caption = 'Move SStop'
      TabOrder = 11
      OnClick = btnSStopClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 395
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
