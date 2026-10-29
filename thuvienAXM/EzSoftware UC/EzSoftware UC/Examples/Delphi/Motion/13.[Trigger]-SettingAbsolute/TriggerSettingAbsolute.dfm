object Form1: TForm1
  Left = 2543
  Top = 1202
  BorderIcons = [biSystemMenu]
  Caption = 'TriggerSettingAbsolute'
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
    Top = 154
    Width = 455
    Height = 129
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
      Width = 120
      Height = 16
      Caption = 'Move Accel/Decel  :'
    end
    object Label16: TLabel
      Left = 262
      Top = 99
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
      Text = '100.000'
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
    object btnMove: TButton
      Left = 332
      Top = 39
      Width = 113
      Height = 38
      Caption = 'Move Target'
      TabOrder = 5
      OnClick = btnMoveClick
    end
    object btnMoveStop: TButton
      Left = 332
      Top = 80
      Width = 113
      Height = 38
      Caption = 'Move SStop'
      TabOrder = 6
      OnClick = btnMoveStopClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 12
    Top = 288
    Width = 455
    Height = 113
    Caption = '< Trigger Setting Method >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object Shape6: TShape
      Left = 264
      Top = 22
      Width = 3
      Height = 80
    end
    object Label3: TLabel
      Left = 9
      Top = 25
      Width = 118
      Height = 16
      Caption = 'Trigger Time(us)     :'
    end
    object Label6: TLabel
      Left = 9
      Top = 53
      Width = 118
      Height = 16
      Caption = 'Trigger Level Set    :'
    end
    object Label14: TLabel
      Left = 9
      Top = 82
      Width = 119
      Height = 16
      Caption = 'Trigger Target Sel  :'
    end
    object Label17: TLabel
      Left = 274
      Top = 25
      Width = 56
      Height = 16
      Caption = 'Int Count :'
    end
    object Label18: TLabel
      Left = 274
      Top = 53
      Width = 53
      Height = 16
      Caption = 'Interrupt :'
    end
    object Shape1: TShape
      Left = 332
      Top = 80
      Width = 120
      Height = 3
    end
    object edtTrigTime: TEdit
      Left = 133
      Top = 22
      Width = 124
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 0
      Text = '100.000'
    end
    object cboTrigLevel: TComboBox
      Left = 133
      Top = 51
      Width = 124
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Items.Strings = (
        '00: LOW'
        '01: HIGH')
    end
    object cboTrigTarget: TComboBox
      Left = 133
      Top = 80
      Width = 124
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 2
      Items.Strings = (
        '00: COMMAND'
        '01: ACTUAL')
    end
    object stcIntCount: TEdit
      Left = 332
      Top = 22
      Width = 113
      Height = 24
      Enabled = False
      ImeName = 'Microsoft IME 2010'
      TabOrder = 3
      Text = '0'
    end
    object cboIntUse: TComboBox
      Left = 332
      Top = 51
      Width = 113
      Height = 24
      Style = csDropDownList
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      Items.Strings = (
        '00: DISABLE'
        '01: ENABLE')
    end
    object btnSetMethod: TButton
      Left = 332
      Top = 88
      Width = 122
      Height = 24
      Caption = 'Set Method'
      TabOrder = 5
      OnClick = btnSetMethodClick
    end
  end
  object GroupBox5: TGroupBox
    Left = 12
    Top = 406
    Width = 455
    Height = 131
    Caption = '< Trigger Setting Absolute >'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object Label19: TLabel
      Left = 9
      Top = 25
      Width = 121
      Height = 16
      Caption = 'Block Start Position :'
    end
    object Shape2: TShape
      Left = 332
      Top = 101
      Width = 120
      Height = 3
    end
    object Shape3: TShape
      Left = 264
      Top = 22
      Width = 3
      Height = 80
    end
    object Label20: TLabel
      Left = 274
      Top = 25
      Width = 54
      Height = 16
      Caption = 'Trig Pos:'
    end
    object chkSetAbsolute: TCheckBox
      Left = 343
      Top = 105
      Width = 99
      Height = 24
      Caption = 'Set Absolute'
      TabOrder = 0
      OnClick = chkSetAbsoluteClick
    end
    object edtTrigPosAdd: TEdit
      Left = 332
      Top = 22
      Width = 113
      Height = 24
      ImeName = 'Microsoft IME 2010'
      TabOrder = 1
      Text = '10.0'
    end
    object btnTrigDataAdd: TButton
      Left = 332
      Top = 47
      Width = 113
      Height = 24
      Caption = '<< Add Item'
      TabOrder = 2
      OnClick = btnTrigDataAddClick
    end
    object btnTrigDataClr: TButton
      Left = 332
      Top = 73
      Width = 113
      Height = 24
      Caption = 'All Clear Item'
      TabOrder = 3
      OnClick = btnTrigDataClrClick
    end
    object lstTrigPos: TListBox
      Left = 133
      Top = 22
      Width = 124
      Height = 98
      ImeName = 'Microsoft IME 2010'
      TabOrder = 4
      OnDblClick = lstTrigPosDblClick
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
