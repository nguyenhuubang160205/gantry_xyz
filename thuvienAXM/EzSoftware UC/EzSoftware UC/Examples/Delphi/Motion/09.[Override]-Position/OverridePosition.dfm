object Form1: TForm1
  Left = 3272
  Top = 415
  BorderIcons = [biSystemMenu]
  Caption = 'OverridePosition'
  ClientHeight = 557
  ClientWidth = 480
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
    object btnPosSet: TButton
      Left = 332
      Top = 45
      Width = 113
      Height = 24
      Caption = 'Position Setting'
      TabOrder = 3
      OnClick = btnPosSetClick
    end
    object chkServoOn: TCheckBox
      Left = 350
      Top = 70
      Width = 80
      Height = 24
      Caption = 'Servo On'
      TabOrder = 4
      OnClick = chkServoOnClick
    end
    object edtSetPos: TEdit
      Left = 332
      Top = 18
      Width = 113
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '0.000'
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 160
    Width = 455
    Height = 161
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
      Top = 42
      Width = 119
      Height = 16
      Caption = 'Move Target Pos    :'
    end
    object Label4: TLabel
      Left = 9
      Top = 70
      Width = 118
      Height = 16
      Caption = 'Move Velocity          :'
    end
    object Label5: TLabel
      Left = 262
      Top = 43
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label7: TLabel
      Left = 262
      Top = 70
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label15: TLabel
      Left = 9
      Top = 99
      Width = 118
      Height = 16
      Caption = 'Move Acceleration :'
    end
    object Label16: TLabel
      Left = 262
      Top = 99
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label17: TLabel
      Left = 9
      Top = 129
      Width = 120
      Height = 16
      Caption = 'Move Deceleration :'
    end
    object Label18: TLabel
      Left = 262
      Top = 129
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object edtMovePos: TEdit
      Left = 133
      Top = 39
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '1000.000'
    end
    object edtMoveVel: TEdit
      Left = 133
      Top = 68
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '200.000'
    end
    object edtMoveAcc: TEdit
      Left = 133
      Top = 97
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '400.000'
    end
    object edtMoveDec: TEdit
      Left = 133
      Top = 127
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '400.000'
    end
    object rdoAbs: TRadioButton
      Left = 133
      Top = 18
      Width = 100
      Height = 17
      Caption = '[00] Absolute'
      TabOrder = 4
      OnClick = rdoAbsClick
    end
    object rdoRel: TRadioButton
      Left = 232
      Top = 18
      Width = 100
      Height = 17
      Caption = '[01] Relative'
      TabOrder = 5
      OnClick = rdoRelClick
    end
    object btnMove1: TButton
      Left = 332
      Top = 39
      Width = 113
      Height = 51
      Caption = 'Move Target'
      TabOrder = 6
      OnClick = btnMove1Click
    end
    object btnSStop: TButton
      Left = 332
      Top = 97
      Width = 113
      Height = 51
      Caption = 'Move SStop'
      TabOrder = 7
      OnClick = btnSStopClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 329
    Width = 455
    Height = 214
    Caption = '< Position Move >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label20: TLabel
      Left = 9
      Top = 154
      Width = 121
      Height = 16
      Caption = 'Override Distance 1:'
    end
    object Label21: TLabel
      Left = 9
      Top = 181
      Width = 121
      Height = 16
      Caption = 'Override Distance 2:'
    end
    object Label23: TLabel
      Left = 262
      Top = 154
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label24: TLabel
      Left = 262
      Top = 181
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Shape6: TShape
      Left = 11
      Top = 142
      Width = 435
      Height = 3
    end
    object btmOverride: TImage
      Left = 6
      Top = 20
      Width = 441
      Height = 115
    end
    object edtOverrideDis1: TEdit
      Left = 133
      Top = 152
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '2000.000'
    end
    object edtOverrideDis2: TEdit
      Left = 133
      Top = 179
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '1000.000'
    end
    object btnOverride1: TButton
      Left = 332
      Top = 152
      Width = 113
      Height = 24
      Caption = 'Override Pos 1'
      TabOrder = 2
      OnClick = btnOverride1Click
    end
    object btnOverride2: TButton
      Left = 332
      Top = 179
      Width = 113
      Height = 24
      Caption = 'Override Pos 2'
      TabOrder = 3
      OnClick = btnOverride2Click
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
