object frm3DGraph: Tfrm3DGraph
  Left = 383
  Top = 286
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = '3DGraphView'
  ClientHeight = 442
  ClientWidth = 800
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clScrollBar
  Font.Height = -11
  Font.Name = '@'#46027#50880#52404
  Font.Style = [fsBold]
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 11
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 249
    Height = 217
    BiDiMode = bdLeftToRight
    Caption = 'Graph Properties'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentBiDiMode = False
    ParentFont = False
    TabOrder = 7
    object Label2: TLabel
      Left = 8
      Top = 24
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      Caption = 'Reset Axis'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 8
      Top = 56
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      Caption = 'Dimension'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 8
      Top = 112
      Width = 70
      Height = 20
      Alignment = taCenter
      AutoSize = False
      Caption = 'RANGE X'
      Layout = tlCenter
    end
    object Label5: TLabel
      Left = 88
      Top = 112
      Width = 70
      Height = 20
      Alignment = taCenter
      AutoSize = False
      Caption = 'RANGE Y'
      Layout = tlCenter
    end
    object Label6: TLabel
      Left = 160
      Top = 112
      Width = 70
      Height = 20
      Alignment = taCenter
      AutoSize = False
      Caption = 'RANGE Z'
      Layout = tlCenter
    end
    object chkBoxEnable: TCheckBox
      Left = 152
      Top = 88
      Width = 81
      Height = 17
      Caption = 'Box Enable'
      Checked = True
      State = cbChecked
      TabOrder = 0
      OnClick = chkBoxEnableClick
    end
    object btnSetRange: TButton
      Left = 11
      Top = 166
      Width = 222
      Height = 33
      Caption = 'Set Range'
      TabOrder = 1
      OnClick = btnSetRangeClick
    end
  end
  object btnHelical: TButton
    Left = 8
    Top = 230
    Width = 120
    Height = 40
    Caption = 'Helical'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnClick = btnHelicalClick
  end
  object btnHelicalPlay: TButton
    Left = 8
    Top = 280
    Width = 120
    Height = 40
    Caption = 'Helical Play'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    OnClick = btnHelicalPlayClick
  end
  object btnSpline: TButton
    Left = 137
    Top = 230
    Width = 120
    Height = 40
    Caption = 'Spline'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = btnSplineClick
  end
  object btnSplinePlay: TButton
    Left = 137
    Top = 280
    Width = 120
    Height = 40
    Caption = 'SplinePlay'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = btnSplinePlayClick
  end
  object btnClear: TButton
    Left = 8
    Top = 392
    Width = 120
    Height = 40
    Caption = 'Clear'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = btnClearClick
  end
  object btnClose: TButton
    Left = 139
    Top = 392
    Width = 120
    Height = 40
    Caption = 'Close'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = btnCloseClick
  end
  object cboAxisReset: TComboBox
    Left = 88
    Top = 32
    Width = 153
    Height = 21
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    ParentFont = False
    TabOrder = 8
    Text = 'cboAxisReset'
    OnChange = cboAxisResetChange
    Items.Strings = (
      'X - Y Axis'
      'Y - Z Axis'
      'X - Z Axis'
      'X - Y - Z Axis')
  end
  object cboDimension: TComboBox
    Left = 88
    Top = 64
    Width = 153
    Height = 21
    DropDownCount = 4
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    ParentFont = False
    TabOrder = 9
    Text = 'cboDimension'
    OnChange = cboDimensionChange
    Items.Strings = (
      'X - Y Dimension'
      'Y - Z Dimension'
      'X - Z Dimension'
      'X - Y - Z Dimension')
  end
  object AxtGraph3D: TAxtGraph3D
    Left = 264
    Top = 8
    Width = 530
    Height = 425
    TabStop = False
    TabOrder = 0
    ControlData = {
      00000100C7360000ED2B00000000000000000000A0400000000000401C450040
      1C4500401C450000000000000000000000000000000000000000000000000000
      0000000000000000000000000000000000000000000000000000000000000000
      000000000000000100000000000000000000000000000000}
  end
  object editRangeX: TEdit
    Left = 19
    Top = 143
    Width = 70
    Height = 21
    Color = clBlack
    Ctl3D = True
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 10
    Text = 'RangeX'
  end
  object editRangeY: TEdit
    Left = 96
    Top = 144
    Width = 70
    Height = 21
    Color = clBlack
    Ctl3D = True
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 11
    Text = 'RangeY'
  end
  object editRangeZ: TEdit
    Left = 172
    Top = 143
    Width = 70
    Height = 21
    Color = clBlack
    Ctl3D = True
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 12
    Text = 'RangeZ'
  end
  object Edit1: TEdit
    Left = 272
    Top = 16
    Width = 42
    Height = 19
    Color = clNone
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 13
    Text = 'CMD X:'
  end
  object Edit2: TEdit
    Left = 272
    Top = 40
    Width = 42
    Height = 19
    Color = clNone
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 14
    Text = 'CMD Y:'
  end
  object Edit3: TEdit
    Left = 272
    Top = 64
    Width = 42
    Height = 19
    Color = clNone
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    TabOrder = 15
    Text = 'CMD Z:'
  end
  object editXCMD: TEdit
    Left = 320
    Top = 16
    Width = 73
    Height = 19
    TabStop = False
    Color = clBlack
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    ReadOnly = True
    TabOrder = 16
    Text = 'X CMD'
  end
  object editYCMD: TEdit
    Left = 320
    Top = 40
    Width = 73
    Height = 19
    TabStop = False
    Color = clBlack
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    ReadOnly = True
    TabOrder = 17
    Text = 'Y CMD'
  end
  object editZCMD: TEdit
    Left = 320
    Top = 64
    Width = 73
    Height = 19
    TabStop = False
    Color = clBlack
    Ctl3D = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentCtl3D = False
    ParentFont = False
    ReadOnly = True
    TabOrder = 18
    Text = 'Z CMD'
  end
  object tmGraph: TTimer
    Enabled = False
    Interval = 20
    OnTimer = tmDisplay
    Left = 8
    Top = 344
  end
end
