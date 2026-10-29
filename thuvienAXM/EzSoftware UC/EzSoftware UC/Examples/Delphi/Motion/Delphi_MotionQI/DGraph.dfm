object frm3DGraph: Tfrm3DGraph
  Left = 518
  Top = 349
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = '3DGraphView'
  ClientHeight = 442
  ClientWidth = 800
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
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
    TabOrder = 0
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
    TabOrder = 1
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
    TabOrder = 2
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
    TabOrder = 3
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
    TabOrder = 5
    OnClick = btnClearClick
  end
  object btnClose: TButton
    Left = 137
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
    TabOrder = 4
    OnClick = btnCloseClick
  end
  object Trigger: TGroupBox
    Left = 8
    Top = 8
    Width = 249
    Height = 217
    Caption = 'Graph Properties'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    object StaticText50: TStaticText
      Left = 8
      Top = 24
      Width = 66
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'Reset Axis'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      Transparent = False
    end
    object StaticText51: TStaticText
      Left = 8
      Top = 56
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      BorderStyle = sbsSunken
      Caption = 'Dimension'
      TabOrder = 1
    end
    object editRangeX: TEdit
      Left = 11
      Top = 136
      Width = 70
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 2
      Text = '2500'
    end
    object editRangeY: TEdit
      Left = 88
      Top = 136
      Width = 70
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 3
      Text = '2500'
    end
    object editRangeZ: TEdit
      Left = 164
      Top = 137
      Width = 70
      Height = 21
      Color = clBlack
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clYellow
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ImeName = 'Microsoft Office IME 2007'
      ParentFont = False
      TabOrder = 4
      Text = '2500'
    end
    object RangeX: TStaticText
      Left = 8
      Top = 111
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      Caption = 'RangeX'
      TabOrder = 5
    end
    object RangeY: TStaticText
      Left = 88
      Top = 111
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      Caption = 'RangeY'
      TabOrder = 6
    end
    object RangeZ: TStaticText
      Left = 168
      Top = 111
      Width = 65
      Height = 20
      Alignment = taCenter
      AutoSize = False
      BevelInner = bvNone
      Caption = 'RangeZ'
      TabOrder = 7
    end
    object btnSetRange: TButton
      Left = 11
      Top = 168
      Width = 222
      Height = 33
      Caption = 'Set Range'
      TabOrder = 8
      OnClick = btnSetRangeClick
    end
  end
  object cboAxisReset: TComboBox
    Left = 88
    Top = 32
    Width = 153
    Height = 21
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    TabOrder = 7
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
    ImeName = 'Microsoft Office IME 2007'
    ItemHeight = 13
    TabOrder = 9
    Text = 'cboDimension'
    OnChange = cboDimensionChange
    Items.Strings = (
      'X - Y Dimension'
      'Y - Z Dimension'
      'X - Z Dimension'
      'X - Y - Z Dimension')
  end
  object chkBoxEnable: TCheckBox
    Left = 160
    Top = 96
    Width = 81
    Height = 17
    Caption = 'Box Enable'
    Checked = True
    State = cbChecked
    TabOrder = 13
    OnClick = chkBoxEnableClick
  end
  object AxtGraph3D: TAxtGraph3D
    Left = 264
    Top = 8
    Width = 529
    Height = 425
    TabOrder = 8
    ControlData = {
      00000100AC360000ED2B0000000000000000A04000000000EC00EC0000401C45
      00401C4500401C4500000000ECFFFFFF0000000000000000000000ECFFFFFF00
      000000ECFFFFFF00000000000000000000000000000000000000000000000000
      0000000000000000000100000000000000000000000000000000}
  end
  object editXCMD: TEdit
    Left = 320
    Top = 16
    Width = 73
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 10
    Text = 'X CMD'
  end
  object editYCMD: TEdit
    Left = 320
    Top = 40
    Width = 73
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 11
    Text = 'Y CMD'
  end
  object editZCMD: TEdit
    Left = 320
    Top = 64
    Width = 73
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 12
    Text = 'Z CMD'
  end
  object Edit1: TEdit
    Left = 272
    Top = 16
    Width = 42
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 14
    Text = 'CMD X:'
  end
  object Edit2: TEdit
    Left = 272
    Top = 40
    Width = 42
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 15
    Text = 'CMD Y:'
  end
  object Edit3: TEdit
    Left = 272
    Top = 64
    Width = 42
    Height = 21
    BorderStyle = bsNone
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clYellow
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ImeName = 'Microsoft Office IME 2007'
    ParentFont = False
    TabOrder = 16
    Text = 'CMD Z:'
  end
  object tmGraph: TTimer
    Enabled = False
    Interval = 20
    OnTimer = tmGraphTimer
    Left = 8
    Top = 344
  end
end
