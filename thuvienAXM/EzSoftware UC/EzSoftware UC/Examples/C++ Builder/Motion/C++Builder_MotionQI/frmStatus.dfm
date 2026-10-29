object frmReadStatus: TfrmReadStatus
  Left = 192
  Top = 114
  Width = 472
  Height = 559
  Caption = 'frmReadStatus'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object btnPrev: TButton
    Left = 376
    Top = 1
    Width = 26
    Height = 15
    Caption = '<<'
    TabOrder = 0
    OnClick = btnPrevClick
  end
  object btnNext: TButton
    Left = 420
    Top = 1
    Width = 26
    Height = 15
    Caption = '>>'
    TabOrder = 1
    OnClick = btnNextClick
  end
  object grbAxisX: TGroupBox
    Left = 10
    Top = 16
    Width = 215
    Height = 504
    Caption = 'X Axis : 00'
    TabOrder = 2
    object GroupBox2: TGroupBox
      Left = 0
      Top = 16
      Width = 208
      Height = 308
      Caption = 'EndStatus'
      TabOrder = 0
      object Label7: TLabel
        Left = 34
        Top = 182
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 7bit : NSWSLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label8: TLabel
        Left = 34
        Top = 197
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 6bit : PSWSLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label9: TLabel
        Left = 34
        Top = 212
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 5bit : NSWLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label10: TLabel
        Left = 34
        Top = 227
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 4bit : PSWLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label11: TLabel
        Left = 34
        Top = 287
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 0bit : PELM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label12: TLabel
        Left = 34
        Top = 272
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 1bit : NELM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS07: TLabel
        Left = 8
        Top = 182
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS06: TLabel
        Left = 8
        Top = 197
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS05: TLabel
        Left = 8
        Top = 212
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS04: TLabel
        Left = 8
        Top = 227
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS01: TLabel
        Left = 8
        Top = 272
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS00: TLabel
        Left = 8
        Top = 287
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label27: TLabel
        Left = 34
        Top = 242
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 3bit : NSLM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label28: TLabel
        Left = 34
        Top = 257
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 2bit : PSLM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXENS03: TLabel
        Left = 8
        Top = 242
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS02: TLabel
        Left = 8
        Top = 257
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS14: TLabel
        Left = 8
        Top = 77
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS15: TLabel
        Left = 8
        Top = 62
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS13: TLabel
        Left = 8
        Top = 92
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS12: TLabel
        Left = 8
        Top = 107
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS11: TLabel
        Left = 8
        Top = 122
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS10: TLabel
        Left = 8
        Top = 137
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS09: TLabel
        Left = 8
        Top = 152
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXENS08: TLabel
        Left = 8
        Top = 167
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label44: TLabel
        Left = 34
        Top = 167
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 8bit : SVALARM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label45: TLabel
        Left = 34
        Top = 152
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 9bit: ESTOP stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label47: TLabel
        Left = 34
        Top = 137
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 10bit : ESTOPCMD stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label48: TLabel
        Left = 34
        Top = 122
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 11bit : SSTOPCMD stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label49: TLabel
        Left = 34
        Top = 107
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 12bit : ESTOPALL stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label50: TLabel
        Left = 34
        Top = 92
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 13bit : SQSTP#1 stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label51: TLabel
        Left = 34
        Top = 77
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 14bit : SQSTP#2 stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label52: TLabel
        Left = 34
        Top = 62
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 15bit : ENCERR'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXENS31: TLabel
        Left = 8
        Top = 17
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label54: TLabel
        Left = 34
        Top = 17
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 31bit : INPERR'
        Color = clBtnFace
        Font.Charset = ANSI_CHARSET
        Font.Color = clBlack
        Font.Height = -13
        Font.Name = '@'#46027#50880
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXENS30: TLabel
        Left = 8
        Top = 32
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label56: TLabel
        Left = 34
        Top = 32
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 30bit : ERRSTATE'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXENS16: TLabel
        Left = 8
        Top = 47
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label58: TLabel
        Left = 34
        Top = 47
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 16bit : MPGERR stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
    end
    object GroupBox5: TGroupBox
      Left = 0
      Top = 329
      Width = 208
      Height = 175
      Caption = 'Drive Status'
      TabOrder = 1
      object Label20: TLabel
        Left = 34
        Top = 47
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 7bit : ORG BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label21: TLabel
        Left = 34
        Top = 62
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 6bit : MPG BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label22: TLabel
        Left = 34
        Top = 77
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 5bit : PRESET BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label23: TLabel
        Left = 34
        Top = 92
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 4bit : CONTI BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label24: TLabel
        Left = 34
        Top = 152
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 0bit : BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label25: TLabel
        Left = 34
        Top = 137
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 1bit : DOWN'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS07: TLabel
        Left = 8
        Top = 47
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS06: TLabel
        Left = 8
        Top = 62
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS05: TLabel
        Left = 8
        Top = 77
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS04: TLabel
        Left = 8
        Top = 92
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS01: TLabel
        Left = 8
        Top = 137
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS00: TLabel
        Left = 8
        Top = 152
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label46: TLabel
        Left = 34
        Top = 107
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 3bit : UP'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label31: TLabel
        Left = 34
        Top = 122
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 2bit : CONST'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXDRS03: TLabel
        Left = 8
        Top = 107
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS02: TLabel
        Left = 8
        Top = 122
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedXDRS09: TLabel
        Left = 8
        Top = 32
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label30: TLabel
        Left = 35
        Top = 32
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 9bit : INP BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label32: TLabel
        Left = 35
        Top = 17
        Width = 142
        Height = 17
        AutoSize = False
        Caption = '10bit : SLAVE BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedXDRS10: TLabel
        Left = 8
        Top = 17
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
    end
  end
  object grbAxisY: TGroupBox
    Left = 240
    Top = 16
    Width = 215
    Height = 504
    Caption = 'Y Axis : 01'
    TabOrder = 3
    object GroupBox1: TGroupBox
      Left = 0
      Top = 329
      Width = 208
      Height = 175
      Caption = 'Drive Status'
      TabOrder = 0
      object Label5: TLabel
        Left = 34
        Top = 152
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 0bit : BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label6: TLabel
        Left = 34
        Top = 137
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 1bit : DOWN'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS07: TLabel
        Left = 8
        Top = 47
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS06: TLabel
        Left = 8
        Top = 62
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS05: TLabel
        Left = 8
        Top = 77
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS04: TLabel
        Left = 8
        Top = 92
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS01: TLabel
        Left = 8
        Top = 137
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS00: TLabel
        Left = 8
        Top = 152
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label13: TLabel
        Left = 34
        Top = 107
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 3bit : UP'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label14: TLabel
        Left = 34
        Top = 122
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 2bit : CONST'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object LedYDRS03: TLabel
        Left = 8
        Top = 107
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS02: TLabel
        Left = 8
        Top = 122
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS10: TLabel
        Left = 8
        Top = 17
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYDRS09: TLabel
        Left = 8
        Top = 32
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label1: TLabel
        Left = 35
        Top = 17
        Width = 142
        Height = 17
        AutoSize = False
        Caption = '10bit : SLAVE BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label2: TLabel
        Left = 35
        Top = 32
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 9bit : INP BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label3: TLabel
        Left = 34
        Top = 47
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 7bit : ORG BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label4: TLabel
        Left = 34
        Top = 62
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 6bit : MPG BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label29: TLabel
        Left = 34
        Top = 77
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 5bit : PRESET BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label33: TLabel
        Left = 34
        Top = 92
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 4bit : CONTI BUSY'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
    end
    object GroupBox3: TGroupBox
      Left = 0
      Top = 16
      Width = 208
      Height = 308
      Caption = 'EndStatus'
      TabOrder = 1
      object LedYENS07: TLabel
        Left = 8
        Top = 182
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS06: TLabel
        Left = 8
        Top = 197
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS05: TLabel
        Left = 8
        Top = 212
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS04: TLabel
        Left = 8
        Top = 227
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS01: TLabel
        Left = 8
        Top = 272
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS00: TLabel
        Left = 8
        Top = 287
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS03: TLabel
        Left = 8
        Top = 242
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS02: TLabel
        Left = 8
        Top = 257
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS31: TLabel
        Left = 8
        Top = 17
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS30: TLabel
        Left = 8
        Top = 32
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS16: TLabel
        Left = 8
        Top = 47
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS15: TLabel
        Left = 8
        Top = 62
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS14: TLabel
        Left = 8
        Top = 77
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS13: TLabel
        Left = 8
        Top = 92
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS12: TLabel
        Left = 8
        Top = 107
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS11: TLabel
        Left = 8
        Top = 122
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS10: TLabel
        Left = 8
        Top = 137
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS09: TLabel
        Left = 8
        Top = 152
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object LedYENS08: TLabel
        Left = 8
        Top = 167
        Width = 16
        Height = 14
        AutoSize = False
        Color = clMaroon
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label59: TLabel
        Left = 34
        Top = 167
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 8bit : SVALARM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label60: TLabel
        Left = 34
        Top = 152
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 9bit: ESTOP stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label61: TLabel
        Left = 34
        Top = 137
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 10bit : ESTOPCMD stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label62: TLabel
        Left = 34
        Top = 122
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 11bit : SSTOPCMD stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label63: TLabel
        Left = 34
        Top = 107
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 12bit : ESTOPALL stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label64: TLabel
        Left = 34
        Top = 92
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 13bit : SQSTP#1 stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label65: TLabel
        Left = 34
        Top = 77
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 14bit : SQSTP#2 stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label66: TLabel
        Left = 34
        Top = 62
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 15bit : ENCERR'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label67: TLabel
        Left = 34
        Top = 47
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 16bit : MPGERR stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label68: TLabel
        Left = 34
        Top = 32
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 30bit : ERRSTATE'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label69: TLabel
        Left = 34
        Top = 17
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 31bit : INPERR'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label15: TLabel
        Left = 34
        Top = 182
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 7bit : NSWSLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label16: TLabel
        Left = 34
        Top = 197
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 6bit : PSWSLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label17: TLabel
        Left = 34
        Top = 212
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 5bit : NSWLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label18: TLabel
        Left = 34
        Top = 227
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 4bit : PSWLMT stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label19: TLabel
        Left = 34
        Top = 242
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 3bit : NSLM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label26: TLabel
        Left = 34
        Top = 257
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 2bit : PSLM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
      object Label36: TLabel
        Left = 34
        Top = 272
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 1bit : NELM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        Layout = tlCenter
      end
      object Label37: TLabel
        Left = 34
        Top = 287
        Width = 142
        Height = 17
        AutoSize = False
        Caption = ' 0bit : PELM stopped'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
      end
    end
  end
  object btnCur: TButton
    Left = 402
    Top = 1
    Width = 18
    Height = 15
    Caption = '||'
    TabOrder = 4
    OnClick = btnCurClick
  end
  object tmStatusView: TTimer
    Interval = 100
    OnTimer = tmStatusViewTimer
    Left = 216
  end
end
