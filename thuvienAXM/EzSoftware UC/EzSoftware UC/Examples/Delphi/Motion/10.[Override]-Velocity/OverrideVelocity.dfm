object Form1: TForm1
  Left = 1361
  Top = 479
  BorderIcons = [biSystemMenu]
  Caption = 'OverrideVelocity'
  ClientHeight = 562
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
    Top = 160
    Width = 455
    Height = 132
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
      Top = 44
      Width = 118
      Height = 16
      Caption = 'Target Position        :'
    end
    object Label4: TLabel
      Left = 9
      Top = 73
      Width = 118
      Height = 16
      Caption = 'Move Velocity          :'
    end
    object Label5: TLabel
      Left = 262
      Top = 45
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label7: TLabel
      Left = 262
      Top = 73
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label15: TLabel
      Left = 9
      Top = 102
      Width = 118
      Height = 16
      Caption = 'Move Acceleration :'
    end
    object Label16: TLabel
      Left = 262
      Top = 102
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object edtMovePos: TEdit
      Left = 133
      Top = 41
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtMoveVel: TEdit
      Left = 133
      Top = 71
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '100.000'
    end
    object edtMoveAccDec: TEdit
      Left = 133
      Top = 100
      Width = 124
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
    object btnMove1: TButton
      Left = 332
      Top = 41
      Width = 113
      Height = 38
      Caption = 'Move Target'
      TabOrder = 5
      OnClick = btnMove1Click
    end
    object btnSStop: TButton
      Left = 332
      Top = 83
      Width = 113
      Height = 38
      Caption = 'Move SStop'
      TabOrder = 6
      OnClick = btnSStopClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 301
    Width = 455
    Height = 78
    Caption = 'Jog(Velocity) Move'
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
    object edtJogVel: TEdit
      Left = 133
      Top = 18
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object edtJogAccDec: TEdit
      Left = 133
      Top = 45
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '400.000'
    end
    object btnJogMove: TButton
      Left = 332
      Top = 15
      Width = 113
      Height = 24
      Caption = 'Velocity Move'
      TabOrder = 2
      OnClick = btnJogMoveClick
    end
    object btnJogStop: TButton
      Left = 332
      Top = 45
      Width = 113
      Height = 24
      Caption = 'Velocity Stop'
      TabOrder = 3
      OnClick = btnJogStopClick
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 387
    Width = 455
    Height = 166
    Caption = '< Override Velocity >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label3: TLabel
      Left = 9
      Top = 48
      Width = 118
      Height = 16
      Caption = 'Override Max Vel    :'
    end
    object Label6: TLabel
      Left = 9
      Top = 77
      Width = 118
      Height = 16
      Caption = 'Override Velocity    :'
    end
    object Label14: TLabel
      Left = 262
      Top = 49
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label17: TLabel
      Left = 262
      Top = 77
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label18: TLabel
      Left = 9
      Top = 106
      Width = 116
      Height = 16
      Caption = 'Override Accel        :'
    end
    object Label21: TLabel
      Left = 262
      Top = 106
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label24: TLabel
      Left = 9
      Top = 135
      Width = 115
      Height = 16
      Caption = 'Override Decel       :'
    end
    object Label25: TLabel
      Left = 262
      Top = 135
      Width = 65
      Height = 16
      Caption = 'Unit/Sec^2'
    end
    object Label26: TLabel
      Left = 9
      Top = 21
      Width = 120
      Height = 16
      Caption = 'Valid Over Max Vel :'
    end
    object stcOverrideMaxVel: TLabel
      Left = 216
      Top = 21
      Width = 39
      Height = 16
      Alignment = taRightJustify
      Caption = 'xxx.xxx'
    end
    object Label28: TLabel
      Left = 262
      Top = 21
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object edtOverrideMaxVel: TEdit
      Left = 133
      Top = 45
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '1000.000'
    end
    object edtOverrideVel: TEdit
      Left = 133
      Top = 75
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '300.000'
    end
    object edtOverrideAcc: TEdit
      Left = 133
      Top = 104
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '600.000'
    end
    object btnSetOverrideMaxVel: TButton
      Left = 332
      Top = 45
      Width = 113
      Height = 52
      Caption = 'Set Velocity'
      TabOrder = 3
      OnClick = btnSetOverrideMaxVelClick
    end
    object btnSetOverride: TButton
      Left = 332
      Top = 100
      Width = 113
      Height = 52
      Caption = 'Override'
      TabOrder = 4
      OnClick = btnSetOverrideClick
    end
    object edtOverrideDec: TEdit
      Left = 133
      Top = 133
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
      Text = '1200.000'
    end
    object chkOverrideOnlyVel: TCheckBox
      Left = 333
      Top = 21
      Width = 106
      Height = 17
      Caption = 'Over Only Vel'
      TabOrder = 6
      OnClick = chkOverrideOnlyVelClick
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
