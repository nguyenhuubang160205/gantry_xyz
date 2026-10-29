object Form1: TForm1
  Left = 2561
  Top = 1039
  BorderIcons = [biSystemMenu]
  Caption = 'Form1'
  ClientHeight = 812
  ClientWidth = 484
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
    Top = 12
    Width = 460
    Height = 30
    TabOrder = 0
    object Label1: TLabel
      Left = 12
      Top = 9
      Width = 42
      Height = 16
      Caption = '00:Axis'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboSelAxis: TComboBox
      Left = 69
      Top = 7
      Width = 150
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      OnChange = cboSelAxisChange
    end
    object btnLoadFile: TButton
      Left = 227
      Top = 7
      Width = 110
      Height = 20
      Caption = 'Load File'
      TabOrder = 1
      OnClick = btnLoadFileClick
    end
    object btnSaveFile: TButton
      Left = 340
      Top = 7
      Width = 110
      Height = 20
      Caption = 'Save File'
      TabOrder = 2
      OnClick = btnSaveFileClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 12
    Top = 51
    Width = 460
    Height = 141
    Caption = '< Pulse/Encoder Method & Move Parameter Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Label2: TLabel
      Left = 11
      Top = 29
      Width = 51
      Height = 16
      Caption = '01:Pulse'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 11
      Top = 55
      Width = 40
      Height = 16
      Caption = '02:Enc'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 11
      Top = 81
      Width = 41
      Height = 16
      Caption = '32:Abs'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 11
      Top = 107
      Width = 55
      Height = 16
      Caption = '33:Profile'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label6: TLabel
      Left = 238
      Top = 29
      Width = 89
      Height = 16
      Caption = '07:Min Velocity'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 238
      Top = 55
      Width = 93
      Height = 16
      Caption = '08:Max Velocity'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label8: TLabel
      Left = 238
      Top = 81
      Width = 88
      Height = 16
      Caption = '26:Move Pulse'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label9: TLabel
      Left = 238
      Top = 107
      Width = 77
      Height = 16
      Caption = '27:Move Unit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape1: TShape
      Left = 227
      Top = 26
      Width = 3
      Height = 98
    end
    object cboPulse: TComboBox
      Left = 69
      Top = 26
      Width = 150
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object cboEncoder: TComboBox
      Left = 69
      Top = 52
      Width = 150
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object cboAbsRel: TComboBox
      Left = 69
      Top = 78
      Width = 150
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object cboProfile: TComboBox
      Left = 69
      Top = 104
      Width = 150
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object edtMinVel: TEdit
      Left = 340
      Top = 25
      Width = 110
      Height = 21
      BiDiMode = bdRightToLeft
      ImeName = 'Microsoft IME 2010'
      ParentBiDiMode = False
      TabOrder = 4
    end
    object edtMaxVel: TEdit
      Left = 340
      Top = 52
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
    end
    object edtMovePulse: TEdit
      Left = 340
      Top = 79
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
    end
    object edtMoveUnit: TEdit
      Left = 340
      Top = 105
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
    end
    object btnApplyPulse: TButton
      Left = 340
      Top = 0
      Width = 110
      Height = 22
      Caption = 'Apply'
      TabOrder = 8
      OnClick = btnApplyPulseClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 12
    Top = 198
    Width = 460
    Height = 164
    Caption = '< Input/Output Signal Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object Label10: TLabel
      Left = 11
      Top = 29
      Width = 74
      Height = 16
      Caption = '03:Inposition'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label11: TLabel
      Left = 11
      Top = 55
      Width = 52
      Height = 16
      Caption = '04:Alarm'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label12: TLabel
      Left = 11
      Top = 81
      Width = 73
      Height = 16
      Caption = '05:Neg Limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label13: TLabel
      Left = 11
      Top = 107
      Width = 71
      Height = 16
      Caption = '06:Pos Limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label14: TLabel
      Left = 238
      Top = 29
      Width = 81
      Height = 16
      Caption = '12:ZPhase Lv'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label15: TLabel
      Left = 238
      Top = 55
      Width = 92
      Height = 16
      Caption = '14:EStop Mode'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label16: TLabel
      Left = 238
      Top = 81
      Width = 71
      Height = 16
      Caption = '15:EStop Lv'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label17: TLabel
      Left = 238
      Top = 107
      Width = 96
      Height = 16
      Caption = '35:Alm Reset Lv'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape2: TShape
      Left = 227
      Top = 26
      Width = 3
      Height = 124
    end
    object Label18: TLabel
      Left = 11
      Top = 133
      Width = 98
      Height = 16
      Caption = '34:Servo On Lev'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label19: TLabel
      Left = 238
      Top = 133
      Width = 75
      Height = 16
      Caption = '36:Enc Type'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object cboInp: TComboBox
      Left = 114
      Top = 26
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object chkInp: TCheckBox
      Left = 93
      Top = 28
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 1
    end
    object chkAlarm: TCheckBox
      Left = 93
      Top = 52
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 2
    end
    object cboAlarm: TComboBox
      Left = 114
      Top = 50
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object chkELimitP: TCheckBox
      Left = 93
      Top = 105
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 4
    end
    object cboELimitP: TComboBox
      Left = 114
      Top = 103
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
    end
    object chkELimitN: TCheckBox
      Left = 93
      Top = 79
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 6
    end
    object cboELimitN: TComboBox
      Left = 114
      Top = 77
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
    end
    object cboServoOn: TComboBox
      Left = 114
      Top = 130
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
    end
    object chkZPhase: TCheckBox
      Left = 325
      Top = 29
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 9
    end
    object cboZPhaseLev: TComboBox
      Left = 340
      Top = 26
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 10
    end
    object cboStopMode: TComboBox
      Left = 340
      Top = 50
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 11
    end
    object cboStopLevel: TComboBox
      Left = 340
      Top = 77
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 12
    end
    object cboAlarmReset: TComboBox
      Left = 340
      Top = 103
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 13
    end
    object cboEncoderType: TComboBox
      Left = 340
      Top = 130
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 14
    end
    object chkEmg: TCheckBox
      Left = 325
      Top = 80
      Width = 15
      Height = 20
      Enabled = False
      TabOrder = 15
    end
    object btnApplySignal: TButton
      Left = 340
      Top = 0
      Width = 110
      Height = 22
      Caption = 'Apply'
      TabOrder = 16
      OnClick = btnApplySignalClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 368
    Width = 460
    Height = 197
    Caption = '< Home Search Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Label20: TLabel
      Left = 11
      Top = 29
      Width = 95
      Height = 16
      Caption = '09:Home Signal'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label21: TLabel
      Left = 11
      Top = 55
      Width = 90
      Height = 16
      Caption = '10:Home Level'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label22: TLabel
      Left = 11
      Top = 88
      Width = 65
      Height = 16
      Caption = '16:First Vel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label23: TLabel
      Left = 11
      Top = 142
      Width = 71
      Height = 16
      Caption = '18:Third Vel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label24: TLabel
      Left = 238
      Top = 29
      Width = 74
      Height = 16
      Caption = '11:Home Dir'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape3: TShape
      Left = 227
      Top = 26
      Width = 3
      Height = 46
    end
    object Label28: TLabel
      Left = 11
      Top = 169
      Width = 65
      Height = 16
      Caption = '19:Last Vel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label30: TLabel
      Left = 11
      Top = 115
      Width = 87
      Height = 16
      Caption = '17:Second Vel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label25: TLabel
      Left = 238
      Top = 55
      Width = 92
      Height = 16
      Caption = '13:ZPhase Use'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label26: TLabel
      Left = 238
      Top = 88
      Width = 79
      Height = 16
      Caption = '20:First Accel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label27: TLabel
      Left = 238
      Top = 115
      Width = 101
      Height = 16
      Caption = '21:Second Accel'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label29: TLabel
      Left = 238
      Top = 142
      Width = 98
      Height = 16
      Caption = '22:Clear TM[ms]'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label31: TLabel
      Left = 238
      Top = 169
      Width = 78
      Height = 16
      Caption = '23:End Offset'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape4: TShape
      Left = 227
      Top = 84
      Width = 3
      Height = 100
    end
    object Shape5: TShape
      Left = 12
      Top = 77
      Width = 437
      Height = 1
      Pen.Color = clActiveBorder
    end
    object cboHomeSignal: TComboBox
      Left = 114
      Top = 26
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object cboHomeLevel: TComboBox
      Left = 114
      Top = 50
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object cboHomeDir: TComboBox
      Left = 340
      Top = 26
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object cboZPhaseUse: TComboBox
      Left = 340
      Top = 50
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object edtVelFirst: TEdit
      Left = 114
      Top = 84
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
    end
    object edtVelSecond: TEdit
      Left = 114
      Top = 111
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 5
    end
    object edtVelThird: TEdit
      Left = 114
      Top = 138
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 6
    end
    object edtVelLast: TEdit
      Left = 114
      Top = 165
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 7
    end
    object edtAccFirst: TEdit
      Left = 340
      Top = 84
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
    end
    object edtAccSecond: TEdit
      Left = 340
      Top = 111
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 9
    end
    object edtHomeClrTime: TEdit
      Left = 340
      Top = 138
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 10
    end
    object edtHomeOffset: TEdit
      Left = 340
      Top = 165
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 11
    end
    object btnApplyHome: TButton
      Left = 340
      Top = 0
      Width = 110
      Height = 22
      Caption = 'Apply'
      TabOrder = 12
      OnClick = btnApplyHomeClick
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 571
    Width = 460
    Height = 107
    Caption = '< Software Limit Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label32: TLabel
      Left = 11
      Top = 29
      Width = 60
      Height = 16
      Caption = '39:Enable'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label33: TLabel
      Left = 11
      Top = 55
      Width = 99
      Height = 16
      Caption = '24:Neg Soft Limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label34: TLabel
      Left = 11
      Top = 81
      Width = 55
      Height = 16
      Caption = '37:Select'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label37: TLabel
      Left = 238
      Top = 55
      Width = 97
      Height = 16
      Caption = '25:Pos Soft Limit'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label38: TLabel
      Left = 238
      Top = 81
      Width = 83
      Height = 16
      Caption = '38:Stop Mode'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape6: TShape
      Left = 227
      Top = 26
      Width = 3
      Height = 72
    end
    object cboSLimitEnable: TComboBox
      Left = 114
      Top = 26
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object cboSLimitSelect: TComboBox
      Left = 114
      Top = 78
      Width = 105
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object edtSLimitPosP: TEdit
      Left = 340
      Top = 52
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object edtSLimitPosN: TEdit
      Left = 114
      Top = 51
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object cboSLimitStopMode: TComboBox
      Left = 340
      Top = 79
      Width = 110
      Height = 21
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
    end
    object btnApplySoftLimit: TButton
      Left = 340
      Top = 0
      Width = 110
      Height = 22
      Caption = 'Apply'
      TabOrder = 5
      OnClick = btnApplySoftLimitClick
    end
  end
  object GroupBox6: TGroupBox
    Left = 12
    Top = 684
    Width = 460
    Height = 83
    Caption = '< User Move Parameter Setting >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    object Label35: TLabel
      Left = 11
      Top = 29
      Width = 65
      Height = 16
      Caption = '28:Position'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label36: TLabel
      Left = 11
      Top = 55
      Width = 65
      Height = 16
      Caption = '29:Velocity'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label40: TLabel
      Left = 238
      Top = 55
      Width = 94
      Height = 16
      Caption = '31:Deceleration'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Shape7: TShape
      Left = 227
      Top = 26
      Width = 3
      Height = 45
    end
    object Label39: TLabel
      Left = 238
      Top = 29
      Width = 92
      Height = 16
      Caption = '30:Acceleration'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object edtDecel: TEdit
      Left = 340
      Top = 52
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
    end
    object edtVelocity: TEdit
      Left = 114
      Top = 51
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
    end
    object edtAccel: TEdit
      Left = 340
      Top = 25
      Width = 110
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
    end
    object edtPosition: TEdit
      Left = 114
      Top = 24
      Width = 105
      Height = 21
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
    end
    object btnApplyUserPara: TButton
      Left = 340
      Top = 0
      Width = 110
      Height = 22
      Caption = 'Apply'
      TabOrder = 4
      OnClick = btnApplyUserParaClick
    end
  end
  object btnApplyAllAxes: TButton
    Left = 12
    Top = 773
    Width = 460
    Height = 25
    Caption = 'Apply All Axes'
    TabOrder = 6
    OnClick = btnApplyAllAxesClick
  end
  object OpenDialog1: TOpenDialog
    Left = 325
    Top = 12
  end
  object SaveDialog1: TSaveDialog
    Left = 445
    Top = 12
  end
  object m_timer: TTimer
    Interval = 100
    OnTimer = m_timerTimer
    Left = 8
    Top = 8
  end
end
