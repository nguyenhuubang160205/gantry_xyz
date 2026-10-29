object Form1: TForm1
  Left = 2597
  Top = 1288
  BorderIcons = [biSystemMenu]
  Caption = 'OverrideVelocityAtPos'
  ClientHeight = 580
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
    Height = 408
    Caption = '< Override Velocity At Position >'
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
    object Shape1: TShape
      Left = 11
      Top = 368
      Width = 435
      Height = 3
    end
    object Label3: TLabel
      Left = 9
      Top = 158
      Width = 118
      Height = 16
      Caption = 'Override Position    :'
    end
    object Label6: TLabel
      Left = 262
      Top = 158
      Width = 23
      Height = 16
      Caption = 'Unit'
    end
    object Label14: TLabel
      Left = 9
      Top = 187
      Width = 118
      Height = 16
      Caption = 'Override Velocity    :'
    end
    object Label19: TLabel
      Left = 262
      Top = 187
      Width = 51
      Height = 16
      Caption = 'Unit/Sec'
    end
    object Label20: TLabel
      Left = 9
      Top = 216
      Width = 117
      Height = 16
      Caption = 'Compare Target     :'
    end
    object Shape2: TShape
      Left = 133
      Top = 244
      Width = 195
      Height = 3
    end
    object Label21: TLabel
      Left = 9
      Top = 255
      Width = 117
      Height = 16
      Caption = 'Override Mode        :'
    end
    object Label22: TLabel
      Left = 9
      Top = 378
      Width = 119
      Height = 16
      Caption = 'Override (Pos:Vel)  :'
    end
    object Label23: TLabel
      Left = 9
      Top = 288
      Width = 117
      Height = 16
      Caption = 'Multi List(Pos, Vel)  :'
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
      Text = '100.000'
    end
    object edtMoveAcc: TEdit
      Left = 133
      Top = 97
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Text = '200.000'
    end
    object edtMoveDec: TEdit
      Left = 133
      Top = 127
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '200.000'
    end
    object rdoAbs: TRadioButton
      Left = 334
      Top = 18
      Width = 100
      Height = 17
      Caption = '[00] Absolute'
      TabOrder = 4
      OnClick = rdoAbsClick
    end
    object rdoRel: TRadioButton
      Left = 334
      Top = 43
      Width = 100
      Height = 17
      Caption = '[01] Relative'
      TabOrder = 5
      OnClick = rdoRelClick
    end
    object btnOverVelAtPos: TButton
      Left = 332
      Top = 68
      Width = 113
      Height = 82
      Caption = 'Override At Pos'
      TabOrder = 6
      OnClick = btnOverVelAtPosClick
    end
    object btnStop: TButton
      Left = 332
      Top = 156
      Width = 113
      Height = 51
      Caption = 'Move Stop'
      TabOrder = 7
      OnClick = btnStopClick
    end
    object edtOverPos: TEdit
      Left = 133
      Top = 156
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 8
      Text = '200.000'
    end
    object edtOverVel: TEdit
      Left = 133
      Top = 185
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 9
      Text = '200.000'
    end
    object cboCampTarget: TComboBox
      Left = 133
      Top = 214
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 0
      TabOrder = 10
      Text = '00: COMMAND'
      Items.Strings = (
        '00: COMMAND'
        '01: ACTUAL')
    end
    object cboOverMode: TComboBox
      Left = 133
      Top = 253
      Width = 195
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      ItemIndex = 0
      TabOrder = 11
      Text = '00: OVERRIDE_POS_START'
      Items.Strings = (
        '00: OVERRIDE_POS_START'
        '01: OVERRIDE_POS_END')
    end
    object lstOverData: TListBox
      Left = 133
      Top = 283
      Width = 195
      Height = 80
      ImeName = 'Microsoft IME 2010'
      TabOrder = 12
      OnDblClick = lstOverDataDblClick
    end
    object edtOverPosAdd: TEdit
      Left = 133
      Top = 376
      Width = 95
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 13
      Text = '300.000'
    end
    object edtOverVelAdd: TEdit
      Left = 232
      Top = 376
      Width = 95
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 14
      Text = '300.000'
    end
    object btnOverVelAtMPos: TButton
      Left = 332
      Top = 214
      Width = 113
      Height = 105
      Caption = 'Multi At Pos'
      TabOrder = 15
      OnClick = btnOverVelAtMPosClick
    end
    object btnOverDataClr: TButton
      Left = 332
      Top = 326
      Width = 113
      Height = 35
      Caption = 'All Clear Item'
      TabOrder = 16
      OnClick = btnOverDataClrClick
    end
    object btnOverDataAdd: TButton
      Left = 332
      Top = 375
      Width = 113
      Height = 24
      Caption = '<< Add Item'
      TabOrder = 17
      OnClick = btnOverDataAddClick
    end
    object chkOverMulti: TCheckBox
      Left = 134
      Top = 18
      Width = 196
      Height = 20
      Caption = 'Override Vel At Multi Pos Use'
      TabOrder = 18
      OnClick = chkOverMultiClick
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
