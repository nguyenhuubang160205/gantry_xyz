VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{0B59C452-8CDF-4072-BB63-BD371D4DEFEB}#1.1#0"; "AxtGraph.ocx"
Object = "{76FAD8B6-BAF3-414D-BD7E-2FD2DFF49F21}#1.1#0"; "AxtXYGraph.ocx"
Object = "{3EACF94A-AC86-4C57-B5C8-470911DAC903}#1.1#0"; "AxtMessenger.ocx"
Begin VB.Form frmCamcQI 
   BorderStyle     =   1  '단일 고정
   Caption         =   "Ajinextek Motion Board is not detected"
   ClientHeight    =   11265
   ClientLeft      =   45
   ClientTop       =   4995
   ClientWidth     =   15210
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MousePointer    =   1  '화살표
   ScaleHeight     =   11265
   ScaleWidth      =   15210
   StartUpPosition =   1  '소유자 가운데
   Begin AXTMESSENGERLib.AxtMessenger AxtMsg 
      Height          =   375
      Left            =   9600
      TabIndex        =   223
      Top             =   10080
      Visible         =   0   'False
      Width           =   375
      _Version        =   65536
      _ExtentX        =   661
      _ExtentY        =   661
      _StockProps     =   0
      Message1        =   0
      Message2        =   0
      Message3        =   0
   End
   Begin AXTGRAPHLib.AxtGraph GraphY 
      Height          =   2025
      Left            =   105
      TabIndex        =   222
      Top             =   2190
      Width           =   7635
      _Version        =   65536
      _ExtentX        =   13467
      _ExtentY        =   3581
      _StockProps     =   0
      GridColor       =   16761024
      BackColor       =   4194304
      PlotColor1      =   65535
      PlotColor2      =   16776960
      MaxRange        =   0
      MinRange        =   0
      XUnits          =   " X Axis"
      YUnits          =   " Y Axis"
   End
   Begin AXTGRAPHLib.AxtGraph GraphX 
      Height          =   2025
      Left            =   105
      TabIndex        =   221
      Top             =   120
      Width           =   7635
      _Version        =   65536
      _ExtentX        =   13467
      _ExtentY        =   3581
      _StockProps     =   0
      GridColor       =   16761024
      BackColor       =   4194304
      PlotColor1      =   255
      PlotColor2      =   65280
      MaxRange        =   0
      MinRange        =   0
      XUnits          =   " X Axis"
      YUnits          =   " Y Axis"
   End
   Begin VB.Frame Frame15 
      Caption         =   "Conti Interpolation"
      Height          =   3715
      Left            =   12540
      TabIndex        =   197
      Top             =   120
      Width           =   2600
      Begin VB.Frame Frame16 
         Caption         =   "Conti Queue"
         Height          =   1575
         Left            =   0
         TabIndex        =   205
         Top             =   240
         Width           =   2600
         Begin VB.Label Label71 
            Caption         =   "ContiNum:"
            Height          =   255
            Left            =   120
            TabIndex        =   213
            Top             =   280
            Width           =   950
         End
         Begin VB.Label Label72 
            Caption         =   "TotalNum:"
            Height          =   255
            Left            =   120
            TabIndex        =   212
            Top             =   600
            Width           =   950
         End
         Begin VB.Label Label73 
            Caption         =   "Q free :"
            Height          =   255
            Left            =   120
            TabIndex        =   211
            Top             =   920
            Width           =   950
         End
         Begin VB.Label Label74 
            Caption         =   "InMotion :"
            Height          =   255
            Left            =   120
            TabIndex        =   210
            Top             =   1240
            Width           =   950
         End
         Begin VB.Label edtContiNum 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "0"
            Height          =   255
            Left            =   1120
            TabIndex        =   209
            Top             =   260
            Width           =   1380
         End
         Begin VB.Label edtTotalNum 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "0"
            Height          =   255
            Left            =   1120
            TabIndex        =   208
            Top             =   570
            Width           =   1380
         End
         Begin VB.Label edtQFree 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "1"
            Height          =   255
            Left            =   1120
            TabIndex        =   207
            Top             =   880
            Width           =   1380
         End
         Begin VB.Label edtInMotion 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "0"
            Height          =   255
            Left            =   1120
            TabIndex        =   206
            Top             =   1200
            Width           =   1380
         End
      End
      Begin VB.CommandButton btnContiSpline 
         Caption         =   "2Axis Spline"
         Height          =   375
         Left            =   120
         TabIndex        =   204
         Top             =   1920
         Width           =   1610
      End
      Begin VB.CommandButton btnContiBlend 
         Caption         =   "Line & Circle"
         Height          =   375
         Left            =   120
         TabIndex        =   203
         Top             =   2340
         Width           =   1610
      End
      Begin VB.CommandButton btnContiCircle 
         Caption         =   "Circle"
         Height          =   375
         Left            =   120
         TabIndex        =   202
         Top             =   2760
         Width           =   800
      End
      Begin VB.CommandButton btnContiLine 
         Caption         =   "Line"
         Height          =   375
         Left            =   930
         TabIndex        =   201
         Top             =   2760
         Width           =   800
      End
      Begin VB.CommandButton btnContiTest 
         Caption         =   "Verification"
         Height          =   375
         Left            =   120
         TabIndex        =   200
         Top             =   3180
         Width           =   1610
      End
      Begin VB.CommandButton btnContiStart 
         Caption         =   "Start"
         Height          =   810
         Left            =   1750
         TabIndex        =   199
         Top             =   1920
         Width           =   750
      End
      Begin VB.CommandButton btnContiClear 
         Caption         =   "CLR"
         Height          =   810
         Left            =   1750
         TabIndex        =   198
         Top             =   2750
         Width           =   750
      End
   End
   Begin VB.Frame Frame17 
      Caption         =   "Block / One Shot Trigger"
      Height          =   2535
      Left            =   12540
      TabIndex        =   184
      Top             =   4350
      Width           =   2580
      Begin VB.TextBox edtTrigStartPosition 
         Alignment       =   1  '오른쪽 맞춤
         Height          =   310
         Left            =   1440
         MousePointer    =   3  'I-빔
         TabIndex        =   192
         Text            =   "1000"
         Top             =   300
         Width           =   1100
      End
      Begin VB.TextBox edtTrigCycle 
         Alignment       =   1  '오른쪽 맞춤
         Height          =   310
         Left            =   1440
         MousePointer    =   3  'I-빔
         TabIndex        =   191
         Text            =   "100"
         Top             =   640
         Width           =   1100
      End
      Begin VB.TextBox edtTrigPulseWidth 
         Alignment       =   1  '오른쪽 맞춤
         Height          =   310
         Left            =   1440
         MousePointer    =   3  'I-빔
         TabIndex        =   190
         Text            =   "1000"
         Top             =   960
         Width           =   1100
      End
      Begin VB.TextBox edtTrigEndPos 
         Alignment       =   1  '오른쪽 맞춤
         Height          =   310
         Left            =   1440
         MousePointer    =   3  'I-빔
         TabIndex        =   189
         Text            =   "5000"
         Top             =   1320
         Width           =   1100
      End
      Begin VB.CommandButton btnTrigAbs 
         Caption         =   "Trig(Abs)"
         Height          =   375
         Left            =   140
         TabIndex        =   188
         Top             =   1680
         Width           =   1300
      End
      Begin VB.CommandButton btnTrigOneShot 
         Caption         =   "OneShot"
         Height          =   375
         Left            =   1450
         TabIndex        =   187
         Top             =   1680
         Width           =   1050
      End
      Begin VB.CommandButton btnTrigPeriod 
         Caption         =   "Trig(Period)"
         Height          =   375
         Left            =   120
         TabIndex        =   186
         Top             =   2070
         Width           =   1300
      End
      Begin VB.CommandButton btnTrigReset 
         Caption         =   "Trig Reset"
         Height          =   375
         Left            =   1450
         TabIndex        =   185
         Top             =   2070
         Width           =   1050
      End
      Begin VB.Label Label60 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Start Position"
         Height          =   310
         Left            =   120
         TabIndex        =   196
         Top             =   300
         Width           =   1300
      End
      Begin VB.Label Label61 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Cycle"
         Height          =   310
         Left            =   120
         TabIndex        =   195
         Top             =   640
         Width           =   1305
      End
      Begin VB.Label Label62 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Pulse Width"
         Height          =   310
         Left            =   120
         TabIndex        =   194
         Top             =   990
         Width           =   1300
      End
      Begin VB.Label Label63 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "End Position"
         Height          =   310
         Left            =   120
         TabIndex        =   193
         Top             =   1320
         Width           =   1300
      End
   End
   Begin VB.Frame Frame19 
      Caption         =   "Home Search"
      Height          =   2720
      Left            =   12540
      TabIndex        =   169
      Top             =   7770
      Width           =   2580
      Begin VB.CommandButton btnHomeAll 
         Caption         =   "All Home"
         Height          =   340
         Left            =   120
         TabIndex        =   177
         Top             =   2280
         Width           =   1035
      End
      Begin VB.CommandButton btnHomeSingle 
         Caption         =   "Single Home"
         Height          =   340
         Left            =   1200
         TabIndex        =   176
         Top             =   2280
         Width           =   1240
      End
      Begin VB.ComboBox cboHomeDir 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":0000
         Left            =   1080
         List            =   "frmCamcQI.frx":000A
         Style           =   2  '드롭다운 목록
         TabIndex        =   175
         Top             =   1920
         Width           =   1400
      End
      Begin VB.ComboBox cboHomeSignal 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":002A
         Left            =   1080
         List            =   "frmCamcQI.frx":0037
         Style           =   2  '드롭다운 목록
         TabIndex        =   174
         Top             =   1590
         Width           =   1400
      End
      Begin VB.TextBox edtHomeVelFirst 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   1080
         MousePointer    =   3  'I-빔
         TabIndex        =   173
         Text            =   "10000"
         Top             =   270
         Width           =   1400
      End
      Begin VB.TextBox edtHomeVelSecond 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   1080
         MousePointer    =   3  'I-빔
         TabIndex        =   172
         Text            =   "5000"
         Top             =   600
         Width           =   1400
      End
      Begin VB.TextBox edtHomeVelThird 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   1080
         MousePointer    =   3  'I-빔
         TabIndex        =   171
         Text            =   "1000"
         Top             =   910
         Width           =   1400
      End
      Begin VB.TextBox edtHomeVelLast 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   1080
         MousePointer    =   3  'I-빔
         TabIndex        =   170
         Text            =   "100"
         Top             =   1250
         Width           =   1400
      End
      Begin VB.Label Label64 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Vel First"
         Height          =   255
         Left            =   120
         TabIndex        =   183
         Top             =   270
         Width           =   950
      End
      Begin VB.Label Label65 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Vel Begin"
         Height          =   255
         Left            =   120
         TabIndex        =   182
         Top             =   910
         Width           =   945
      End
      Begin VB.Label Label66 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Vel Last"
         Height          =   255
         Left            =   120
         TabIndex        =   181
         Top             =   1250
         Width           =   945
      End
      Begin VB.Label Label67 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Vel After"
         Height          =   255
         Left            =   120
         TabIndex        =   180
         Top             =   600
         Width           =   950
      End
      Begin VB.Label Label68 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Signal"
         Height          =   255
         Left            =   120
         TabIndex        =   179
         Top             =   1590
         Width           =   945
      End
      Begin VB.Label Label69 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Direction"
         Height          =   255
         Left            =   120
         TabIndex        =   178
         Top             =   1920
         Width           =   945
      End
   End
   Begin VB.ListBox lstLog 
      Height          =   3300
      Left            =   9525
      TabIndex        =   103
      Top             =   7230
      Width           =   2895
   End
   Begin VB.Frame Frame13 
      Caption         =   "Signal Search"
      Height          =   1815
      Left            =   9540
      TabIndex        =   95
      Top             =   5350
      Width           =   2900
      Begin VB.CommandButton btnsearch 
         Caption         =   "Search"
         Height          =   375
         Left            =   110
         TabIndex        =   99
         Top             =   1320
         Width           =   2700
      End
      Begin VB.ComboBox cboDetect 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":0061
         Left            =   1330
         List            =   "frmCamcQI.frx":0083
         Style           =   2  '드롭다운 목록
         TabIndex        =   98
         Top             =   240
         Width           =   1470
      End
      Begin VB.ComboBox cboDirection 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":013F
         Left            =   1320
         List            =   "frmCamcQI.frx":0149
         Style           =   2  '드롭다운 목록
         TabIndex        =   97
         Top             =   600
         Width           =   1470
      End
      Begin VB.ComboBox cboStopM 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":015A
         Left            =   1330
         List            =   "frmCamcQI.frx":0164
         Style           =   2  '드롭다운 목록
         TabIndex        =   96
         Top             =   960
         Width           =   1470
      End
      Begin VB.Label Label57 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Detect signal"
         Height          =   255
         Left            =   110
         TabIndex        =   102
         Top             =   240
         Width           =   1215
      End
      Begin VB.Label Label58 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Direction"
         Height          =   255
         Left            =   110
         TabIndex        =   101
         Top             =   600
         Width           =   1095
      End
      Begin VB.Label Label59 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Stop Method"
         Height          =   255
         Left            =   110
         TabIndex        =   100
         Top             =   960
         Width           =   1215
      End
   End
   Begin VB.Timer tmTest 
      Enabled         =   0   'False
      Index           =   3
      Interval        =   100
      Left            =   7125
      Top             =   4200
   End
   Begin VB.Timer tmTest 
      Enabled         =   0   'False
      Index           =   2
      Interval        =   100
      Left            =   6765
      Top             =   4200
   End
   Begin VB.Timer tmTest 
      Enabled         =   0   'False
      Index           =   1
      Interval        =   100
      Left            =   6405
      Top             =   4200
   End
   Begin VB.Timer tmTest 
      Enabled         =   0   'False
      Index           =   0
      Interval        =   100
      Left            =   6045
      Top             =   4200
   End
   Begin VB.Timer tmHome 
      Enabled         =   0   'False
      Index           =   3
      Interval        =   100
      Left            =   5565
      Top             =   4200
   End
   Begin VB.Timer tmHome 
      Enabled         =   0   'False
      Index           =   2
      Interval        =   100
      Left            =   5205
      Top             =   4200
   End
   Begin VB.Timer tmHome 
      Enabled         =   0   'False
      Index           =   1
      Interval        =   100
      Left            =   4845
      Top             =   4200
   End
   Begin VB.Timer tmHome 
      Enabled         =   0   'False
      Index           =   0
      Interval        =   100
      Left            =   4485
      Top             =   4200
   End
   Begin VB.Timer tmGraph 
      Enabled         =   0   'False
      Interval        =   50
      Left            =   3885
      Top             =   4200
   End
   Begin VB.Timer tmDisplay 
      Enabled         =   0   'False
      Interval        =   50
      Left            =   3525
      Top             =   4200
   End
   Begin VB.CheckBox chkGearOnOff 
      Alignment       =   1  '오른쪽 맞춤
      Appearance      =   0  '평면
      Caption         =   "Gear On/Off"
      ForeColor       =   &H80000008&
      Height          =   375
      Left            =   12600
      OLEDropMode     =   1  '수동
      Style           =   1  '그래픽
      TabIndex        =   93
      Top             =   3915
      Width           =   1335
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   15600
      Top             =   9360
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame Frame18 
      Caption         =   "Override & CaptureMove"
      Height          =   750
      Left            =   12540
      TabIndex        =   88
      Top             =   6960
      Width           =   2580
      Begin VB.CommandButton btnSigCapture 
         Caption         =   "CaptureMove"
         Enabled         =   0   'False
         Height          =   375
         Left            =   120
         TabIndex        =   90
         Top             =   240
         Width           =   1335
      End
      Begin VB.CommandButton btnVelOverride 
         Caption         =   "Override"
         Height          =   375
         Left            =   1500
         TabIndex        =   89
         Top             =   260
         Width           =   980
      End
   End
   Begin VB.Frame Frame20 
      Caption         =   "Capture Positon"
      Height          =   600
      Left            =   12540
      TabIndex        =   85
      Top             =   10545
      Width           =   2580
      Begin VB.CommandButton btnReadCapture 
         Caption         =   "GetPos"
         Enabled         =   0   'False
         Height          =   255
         Left            =   120
         TabIndex        =   94
         Top             =   240
         Width           =   855
      End
      Begin VB.Label edtCapturePos 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "0.000"
         Height          =   255
         Left            =   1080
         TabIndex        =   86
         Top             =   240
         Width           =   1410
      End
   End
   Begin VB.TextBox edtGearRatio 
      Alignment       =   1  '오른쪽 맞춤
      Height          =   310
      Left            =   13995
      MousePointer    =   3  'I-빔
      TabIndex        =   84
      Text            =   "1.000"
      Top             =   3945
      Width           =   1140
   End
   Begin VB.CommandButton btnSave 
      Caption         =   "SAVE"
      Height          =   375
      Left            =   11010
      TabIndex        =   83
      Top             =   4860
      Width           =   1320
   End
   Begin VB.CommandButton btnStatus 
      Caption         =   "STATUS"
      Height          =   375
      Left            =   9645
      TabIndex        =   82
      Top             =   4860
      Width           =   1320
   End
   Begin VB.CommandButton btnLoad 
      Caption         =   "LOAD"
      Height          =   375
      Left            =   11010
      TabIndex        =   81
      Top             =   4410
      Width           =   1320
   End
   Begin VB.CommandButton btnManualSet 
      Caption         =   "Manual Set"
      Height          =   375
      Left            =   9645
      TabIndex        =   80
      Top             =   4410
      Width           =   1320
   End
   Begin VB.Frame Frame12 
      Caption         =   "Interrupt Method Setting"
      Height          =   600
      Left            =   5250
      TabIndex        =   73
      Top             =   10545
      Width           =   7200
      Begin VB.CommandButton btnIntDisable 
         Caption         =   "DISABLE"
         Enabled         =   0   'False
         Height          =   255
         Left            =   3680
         TabIndex        =   77
         Top             =   240
         Width           =   1160
      End
      Begin VB.CommandButton btnIntCallback 
         Caption         =   "CallBack"
         Enabled         =   0   'False
         Height          =   255
         Left            =   2480
         TabIndex        =   76
         Top             =   240
         Width           =   1160
      End
      Begin VB.CommandButton btnIntEvent 
         Caption         =   "Event"
         Enabled         =   0   'False
         Height          =   255
         Left            =   1310
         TabIndex        =   75
         Top             =   240
         Width           =   1160
      End
      Begin VB.CommandButton btnIntMessage 
         Caption         =   "Message"
         Enabled         =   0   'False
         Height          =   255
         Left            =   120
         TabIndex        =   74
         Top             =   240
         Width           =   1160
      End
      Begin VB.Label edtIntCount 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "0"
         Height          =   255
         Left            =   6360
         TabIndex        =   79
         Top             =   240
         Width           =   735
      End
      Begin VB.Label Label55 
         Caption         =   "Interrupt Count:"
         Height          =   255
         Left            =   5025
         TabIndex        =   78
         Top             =   240
         Width           =   1335
      End
   End
   Begin VB.Frame Frame11 
      Caption         =   "ETC"
      Height          =   600
      Left            =   50
      TabIndex        =   64
      Top             =   10545
      Width           =   5055
      Begin VB.PictureBox LedEXMP 
         BackColor       =   &H000000FF&
         Height          =   255
         Left            =   4680
         ScaleHeight     =   195
         ScaleWidth      =   195
         TabIndex        =   72
         Top             =   240
         Width           =   255
      End
      Begin VB.PictureBox LedEXPP 
         BackColor       =   &H000000FF&
         Height          =   255
         Left            =   3630
         ScaleHeight     =   195
         ScaleWidth      =   195
         TabIndex        =   71
         Top             =   240
         Width           =   255
      End
      Begin VB.PictureBox LedBusyy 
         BackColor       =   &H00008080&
         Height          =   255
         Left            =   2570
         ScaleHeight     =   195
         ScaleWidth      =   195
         TabIndex        =   70
         Top             =   240
         Width           =   255
      End
      Begin VB.PictureBox LedBusyx 
         BackColor       =   &H00008080&
         Height          =   255
         Left            =   1140
         ScaleHeight     =   195
         ScaleWidth      =   195
         TabIndex        =   69
         Top             =   240
         Width           =   255
      End
      Begin VB.Label Label54 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "EXMP"
         Height          =   255
         Left            =   3920
         TabIndex        =   68
         Top             =   240
         Width           =   735
      End
      Begin VB.Label Label53 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "EXPP"
         Height          =   255
         Left            =   2850
         TabIndex        =   67
         Top             =   240
         Width           =   735
      End
      Begin VB.Label Label52 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Y axis ON"
         Height          =   255
         Left            =   1430
         TabIndex        =   66
         Top             =   240
         Width           =   1095
      End
      Begin VB.Label Label51 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "X axis ON"
         Height          =   255
         Left            =   120
         TabIndex        =   65
         Top             =   240
         Width           =   975
      End
   End
   Begin VB.CommandButton btnJog 
      Caption         =   "+"
      Height          =   360
      Index           =   4
      Left            =   8685
      TabIndex        =   62
      Top             =   6555
      Width           =   310
   End
   Begin VB.CommandButton btnJog 
      Caption         =   "+"
      Height          =   360
      Index           =   6
      Left            =   8685
      TabIndex        =   61
      Top             =   6960
      Width           =   310
   End
   Begin VB.CommandButton btnJog 
      Caption         =   "+"
      Height          =   360
      Index           =   2
      Left            =   8685
      TabIndex        =   60
      Top             =   6165
      Width           =   310
   End
   Begin VB.CommandButton btn3DGraph 
      Caption         =   "3D Helical"
      Height          =   300
      Left            =   2400
      TabIndex        =   3
      Top             =   4395
      Width           =   1050
   End
   Begin VB.ComboBox cboAxisSet 
      Height          =   300
      ItemData        =   "frmCamcQI.frx":0176
      Left            =   1245
      List            =   "frmCamcQI.frx":0178
      Style           =   2  '드롭다운 목록
      TabIndex        =   1
      Top             =   4755
      Width           =   2205
   End
   Begin VB.TextBox edtMoveUnit 
      Alignment       =   1  '오른쪽 맞춤
      BackColor       =   &H80000006&
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   300
      Left            =   1250
      Locked          =   -1  'True
      TabIndex        =   63
      Text            =   "1"
      Top             =   4400
      Width           =   1125
   End
   Begin VB.Frame Frame7 
      Caption         =   "Motion"
      Height          =   6195
      Left            =   3525
      TabIndex        =   104
      Top             =   4320
      Width           =   5955
      Begin VB.TextBox edtCmdPosU 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   1320
         TabIndex        =   224
         Text            =   "0.000"
         Top             =   2640
         Width           =   1215
      End
      Begin VB.TextBox edtUnit 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   600
         MousePointer    =   3  'I-빔
         TabIndex        =   157
         Text            =   "1"
         Top             =   260
         Width           =   700
      End
      Begin VB.TextBox edtPulse 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   2000
         MousePointer    =   3  'I-빔
         TabIndex        =   156
         Text            =   "1"
         Top             =   260
         Width           =   1280
      End
      Begin VB.CommandButton btnSetting 
         Caption         =   "Setting"
         Height          =   300
         Left            =   5000
         TabIndex        =   155
         Top             =   260
         Width           =   855
      End
      Begin VB.TextBox edtStartSpeed 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H00000000&
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   4420
         MousePointer    =   3  'I-빔
         TabIndex        =   154
         Text            =   "100"
         Top             =   260
         Width           =   560
      End
      Begin VB.ComboBox cboPulseOutM 
         Appearance      =   0  '평면
         Height          =   300
         ItemData        =   "frmCamcQI.frx":017A
         Left            =   1320
         List            =   "frmCamcQI.frx":019C
         Style           =   2  '드롭다운 목록
         TabIndex        =   153
         Top             =   650
         Width           =   1950
      End
      Begin VB.ComboBox cboEncInputM 
         Height          =   300
         ItemData        =   "frmCamcQI.frx":022F
         Left            =   4395
         List            =   "frmCamcQI.frx":024B
         Style           =   2  '드롭다운 목록
         TabIndex        =   152
         Top             =   645
         Width           =   1455
      End
      Begin VB.CommandButton btnCountclr 
         Caption         =   "CNTCLR"
         Height          =   300
         Left            =   110
         TabIndex        =   151
         Top             =   1080
         Width           =   1195
      End
      Begin VB.Frame Frame9 
         Caption         =   "Gantry"
         Height          =   1575
         Left            =   3840
         TabIndex        =   149
         Top             =   3120
         Width           =   2050
         Begin VB.ComboBox cbGantrySlave 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":02BD
            Left            =   120
            List            =   "frmCamcQI.frx":02CA
            Style           =   2  '드롭다운 목록
            TabIndex        =   220
            Top             =   240
            Width           =   1815
         End
         Begin VB.CheckBox chkGantry 
            Caption         =   "Gantry Enable"
            Height          =   825
            Left            =   120
            Style           =   1  '그래픽
            TabIndex        =   150
            Top             =   600
            Width           =   1815
         End
      End
      Begin VB.Frame Frame10 
         Caption         =   "One Axis"
         Height          =   1390
         Left            =   0
         TabIndex        =   131
         Top             =   4800
         Width           =   5940
         Begin VB.TextBox edtPosition 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   9.75
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   120
            MousePointer    =   3  'I-빔
            TabIndex        =   144
            Text            =   "0.0"
            Top             =   520
            Width           =   1120
         End
         Begin VB.TextBox edtVelocity 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   9.75
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   1260
            MousePointer    =   3  'I-빔
            TabIndex        =   143
            Text            =   "0.0"
            Top             =   520
            Width           =   1120
         End
         Begin VB.TextBox edtAccel 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   9.75
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   2400
            MousePointer    =   3  'I-빔
            TabIndex        =   142
            Text            =   "0.0"
            Top             =   520
            Width           =   1120
         End
         Begin VB.TextBox edtDecel 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   9.75
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   3560
            MousePointer    =   3  'I-빔
            TabIndex        =   141
            Text            =   "0.0"
            Top             =   520
            Width           =   1120
         End
         Begin VB.CheckBox chkAbsolute 
            Appearance      =   0  '평면
            BackColor       =   &H80000016&
            Caption         =   "Absolute"
            ForeColor       =   &H80000008&
            Height          =   255
            Left            =   4770
            TabIndex        =   140
            Top             =   150
            Width           =   1095
         End
         Begin VB.CheckBox chkRelative 
            Appearance      =   0  '평면
            BackColor       =   &H80000016&
            Caption         =   "Relative"
            ForeColor       =   &H80000008&
            Height          =   255
            Left            =   4770
            TabIndex        =   139
            Top             =   383
            Width           =   1095
         End
         Begin VB.CheckBox chkAsym 
            Appearance      =   0  '평면
            BackColor       =   &H80000016&
            Caption         =   "Asym"
            ForeColor       =   &H80000008&
            Height          =   255
            Left            =   4770
            TabIndex        =   138
            Top             =   616
            Width           =   1095
         End
         Begin VB.CheckBox chkSCurve 
            Appearance      =   0  '평면
            BackColor       =   &H80000016&
            Caption         =   "S-Curve"
            ForeColor       =   &H80000008&
            Height          =   255
            Left            =   4770
            TabIndex        =   137
            Top             =   849
            Width           =   1095
         End
         Begin VB.CheckBox chkXYSyn 
            Appearance      =   0  '평면
            BackColor       =   &H80000016&
            Caption         =   "X-Y Syn"
            ForeColor       =   &H80000008&
            Height          =   255
            Left            =   4770
            TabIndex        =   136
            Top             =   1080
            Width           =   1095
         End
         Begin VB.CommandButton btnMove 
            Caption         =   "MOVE"
            Height          =   375
            Left            =   120
            Picture         =   "frmCamcQI.frx":0323
            TabIndex        =   135
            Top             =   900
            Width           =   1125
         End
         Begin VB.CommandButton btnRepeat 
            Caption         =   "Repeat"
            Height          =   375
            Left            =   1260
            TabIndex        =   134
            Top             =   900
            Width           =   1120
         End
         Begin VB.CommandButton btnStop 
            Caption         =   "Stop"
            Height          =   375
            Left            =   2400
            TabIndex        =   133
            Top             =   900
            Width           =   1120
         End
         Begin VB.CommandButton btnEstop 
            Caption         =   "ESTOP"
            Height          =   375
            Left            =   3570
            TabIndex        =   132
            Top             =   900
            Width           =   1120
         End
         Begin VB.Label Label47 
            Alignment       =   2  '가운데 맞춤
            BackStyle       =   0  '투명
            BorderStyle     =   1  '단일 고정
            Caption         =   "Position"
            Height          =   255
            Left            =   110
            TabIndex        =   148
            Top             =   240
            Width           =   1120
         End
         Begin VB.Label Label48 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Velocity"
            Height          =   255
            Left            =   1260
            TabIndex        =   147
            Top             =   240
            Width           =   1120
         End
         Begin VB.Label Label49 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Accel"
            Height          =   255
            Left            =   2400
            TabIndex        =   146
            Top             =   240
            Width           =   1120
         End
         Begin VB.Label Label50 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Decel"
            Height          =   255
            Left            =   3570
            TabIndex        =   145
            Top             =   240
            Width           =   1120
         End
      End
      Begin VB.CommandButton btnJog 
         Caption         =   "-"
         Height          =   360
         Index           =   1
         Left            =   5520
         TabIndex        =   130
         Top             =   1440
         Width           =   310
      End
      Begin VB.CommandButton btnJog 
         Caption         =   "-"
         Height          =   360
         Index           =   3
         Left            =   5520
         TabIndex        =   129
         Top             =   1845
         Width           =   310
      End
      Begin VB.CommandButton btnJog 
         Caption         =   "-"
         Height          =   360
         Index           =   5
         Left            =   5520
         TabIndex        =   128
         Top             =   2235
         Width           =   310
      End
      Begin VB.CommandButton btnJog 
         Caption         =   "-"
         Height          =   360
         Index           =   7
         Left            =   5520
         TabIndex        =   127
         Top             =   2640
         Width           =   310
      End
      Begin VB.CommandButton btnJog 
         Caption         =   "+"
         Height          =   360
         Index           =   0
         Left            =   5160
         TabIndex        =   126
         Top             =   1440
         Width           =   310
      End
      Begin VB.TextBox edtCmdPosX 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   1320
         TabIndex        =   125
         Text            =   "0.000"
         Top             =   1440
         Width           =   1215
      End
      Begin VB.TextBox edtCmdPosY 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   1320
         TabIndex        =   124
         Text            =   "0.000"
         Top             =   1845
         Width           =   1215
      End
      Begin VB.TextBox edtCmdPosZ 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   1320
         TabIndex        =   123
         Text            =   "0.000"
         Top             =   2235
         Width           =   1215
      End
      Begin VB.TextBox edtActPosX 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   2595
         TabIndex        =   122
         Text            =   "0.000"
         Top             =   1440
         Width           =   1215
      End
      Begin VB.TextBox edtActPosY 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   2595
         TabIndex        =   121
         Text            =   "0.000"
         Top             =   1845
         Width           =   1215
      End
      Begin VB.TextBox edtActPosZ 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   2595
         TabIndex        =   120
         Text            =   "0.000"
         Top             =   2235
         Width           =   1215
      End
      Begin VB.TextBox edtActPosU 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   2595
         TabIndex        =   119
         Text            =   "0.000"
         Top             =   2640
         Width           =   1215
      End
      Begin VB.TextBox edtCmdVelX 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   3870
         TabIndex        =   118
         Text            =   "0.000"
         Top             =   1425
         Width           =   1215
      End
      Begin VB.TextBox edtCmdVelY 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   3870
         TabIndex        =   117
         Text            =   "0.000"
         Top             =   1830
         Width           =   1215
      End
      Begin VB.TextBox edtCmdVelZ 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   3855
         TabIndex        =   116
         Text            =   "0.000"
         Top             =   2220
         Width           =   1215
      End
      Begin VB.TextBox edtCmdVelU 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   11.25
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   360
         Left            =   3870
         TabIndex        =   115
         Text            =   "0.000"
         Top             =   2625
         Width           =   1215
      End
      Begin VB.Frame Frame8 
         Caption         =   "Interpolation"
         Height          =   1575
         Left            =   0
         TabIndex        =   105
         Top             =   3120
         Width           =   3910
         Begin VB.CommandButton btnCircular 
            Caption         =   "Circular"
            Height          =   350
            Left            =   2630
            TabIndex        =   111
            Top             =   1065
            Width           =   1100
         End
         Begin VB.CommandButton btnlinear 
            Caption         =   "Linear"
            Height          =   350
            Left            =   2630
            TabIndex        =   110
            Top             =   660
            Width           =   1100
         End
         Begin VB.CheckBox chkCwCcw 
            Caption         =   "cw/ccw"
            Height          =   255
            Left            =   2630
            TabIndex        =   109
            Top             =   360
            Width           =   1095
         End
         Begin VB.TextBox edtAngle 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   11.25
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   390
            Left            =   1320
            MousePointer    =   3  'I-빔
            TabIndex        =   108
            Text            =   "360.000"
            Top             =   1065
            Width           =   1280
         End
         Begin VB.TextBox edtYCen 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   11.25
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   1320
            MousePointer    =   3  'I-빔
            TabIndex        =   107
            Text            =   "200.000"
            Top             =   660
            Width           =   1280
         End
         Begin VB.TextBox edtXCen 
            Alignment       =   1  '오른쪽 맞춤
            BackColor       =   &H00000000&
            BeginProperty Font 
               Name            =   "굴림"
               Size            =   11.25
               Charset         =   129
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H0000FFFF&
            Height          =   350
            Left            =   1320
            MousePointer    =   3  'I-빔
            TabIndex        =   106
            Text            =   "200.000"
            Top             =   270
            Width           =   1280
         End
         Begin VB.Label Label46 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Angle"
            Height          =   345
            Left            =   105
            TabIndex        =   114
            Top             =   1065
            Width           =   1155
         End
         Begin VB.Label Label45 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Y end/cen"
            Height          =   345
            Left            =   105
            TabIndex        =   113
            Top             =   660
            Width           =   1155
         End
         Begin VB.Label Label44 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "X end/cen "
            Height          =   320
            Left            =   105
            TabIndex        =   112
            Top             =   270
            Width           =   1155
         End
      End
      Begin VB.Label Label43 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Axis U"
         Height          =   300
         Left            =   105
         TabIndex        =   226
         Top             =   2655
         Width           =   1155
      End
      Begin VB.Label Label42 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Axis Z"
         Height          =   300
         Left            =   105
         TabIndex        =   225
         Top             =   2265
         Width           =   1155
      End
      Begin VB.Label Label6 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Unit"
         Height          =   300
         Left            =   110
         TabIndex        =   168
         Top             =   260
         Width           =   490
      End
      Begin VB.Label Label26 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Start Speed"
         Height          =   300
         Left            =   3330
         TabIndex        =   167
         Top             =   255
         Width           =   1095
      End
      Begin VB.Label Label25 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Pulse"
         Height          =   300
         Left            =   1320
         TabIndex        =   166
         Top             =   240
         Width           =   660
      End
      Begin VB.Label Label27 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "PulseOut_M"
         Height          =   300
         Left            =   120
         TabIndex        =   165
         Top             =   650
         Width           =   1140
      End
      Begin VB.Label Label28 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Encoder_M"
         Height          =   300
         Left            =   3310
         TabIndex        =   164
         Top             =   650
         Width           =   1040
      End
      Begin VB.Label Label36 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "CMD POS"
         Height          =   300
         Left            =   1320
         TabIndex        =   163
         Top             =   1080
         Width           =   1215
      End
      Begin VB.Label Label37 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "ACT POS"
         Height          =   300
         Left            =   2580
         TabIndex        =   162
         Top             =   1080
         Width           =   1215
      End
      Begin VB.Label Label38 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "CMD VEL"
         Height          =   300
         Left            =   3870
         TabIndex        =   161
         Top             =   1065
         Width           =   1215
      End
      Begin VB.Label Label39 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "JOG"
         Height          =   300
         Left            =   5190
         TabIndex        =   160
         Top             =   1080
         Width           =   660
      End
      Begin VB.Label Label40 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Axis X"
         Height          =   300
         Left            =   105
         TabIndex        =   159
         Top             =   1470
         Width           =   1155
      End
      Begin VB.Label Label41 
         Alignment       =   2  '가운데 맞춤
         BorderStyle     =   1  '단일 고정
         Caption         =   "Axis Y"
         Height          =   300
         Left            =   105
         TabIndex        =   158
         Top             =   1875
         Width           =   1155
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "I / O"
      Height          =   5395
      Left            =   50
      TabIndex        =   4
      Top             =   5100
      Width           =   3420
      Begin VB.Frame Frame6 
         Caption         =   "CRC"
         Height          =   1270
         Left            =   1720
         TabIndex        =   9
         Top             =   4120
         Width           =   1695
         Begin VB.CommandButton btnCRCOff 
            Caption         =   "CRC OFF"
            Height          =   375
            Left            =   120
            TabIndex        =   92
            Top             =   770
            Width           =   1455
         End
         Begin VB.CommandButton btnCRCOn 
            Caption         =   "CRC ON"
            Height          =   375
            Left            =   120
            TabIndex        =   91
            Top             =   280
            Width           =   1455
         End
      End
      Begin VB.Frame Frame5 
         Caption         =   "MPG"
         Height          =   1215
         Left            =   1720
         TabIndex        =   8
         Top             =   2850
         Width           =   1695
         Begin VB.CommandButton btnMPGOff 
            Caption         =   "MPG OFF"
            Height          =   340
            Left            =   120
            TabIndex        =   59
            Top             =   720
            Width           =   1455
         End
         Begin VB.CommandButton btnMPGOn 
            Caption         =   "MPG ON"
            Height          =   340
            Left            =   120
            TabIndex        =   58
            Top             =   280
            Width           =   1455
         End
      End
      Begin VB.Frame Frame4 
         Caption         =   "Mechanical"
         Height          =   2550
         Left            =   0
         TabIndex        =   7
         Top             =   2850
         Width           =   1680
         Begin VB.PictureBox LedEmg 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   57
            Top             =   2140
            Width           =   250
         End
         Begin VB.PictureBox LedZPhase 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   53
            Top             =   1830
            Width           =   250
         End
         Begin VB.PictureBox LedHome 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   52
            Top             =   1520
            Width           =   250
         End
         Begin VB.PictureBox LedAlarm 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   51
            Top             =   1220
            Width           =   250
         End
         Begin VB.PictureBox LedInp 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   50
            Top             =   900
            Width           =   250
         End
         Begin VB.PictureBox LedNElm 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   49
            Top             =   580
            Width           =   250
         End
         Begin VB.PictureBox LedPElm 
            BackColor       =   &H00000080&
            Height          =   255
            Left            =   1250
            ScaleHeight     =   195
            ScaleWidth      =   195
            TabIndex        =   48
            Top             =   270
            Width           =   250
         End
         Begin VB.Label Label35 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Emg"
            Height          =   255
            Left            =   90
            TabIndex        =   56
            Top             =   2140
            Width           =   1050
         End
         Begin VB.Label Label34 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Zphase"
            Height          =   255
            Left            =   90
            TabIndex        =   47
            Top             =   1830
            Width           =   1050
         End
         Begin VB.Label Label33 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Home"
            Height          =   255
            Left            =   90
            TabIndex        =   46
            Top             =   1520
            Width           =   1050
         End
         Begin VB.Label Label32 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Alarm"
            Height          =   255
            Left            =   90
            TabIndex        =   45
            Top             =   1220
            Width           =   1050
         End
         Begin VB.Label Label31 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Inposition"
            Height          =   255
            Left            =   90
            TabIndex        =   44
            Top             =   900
            Width           =   1050
         End
         Begin VB.Label Label30 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "- End Limit"
            Height          =   255
            Left            =   90
            TabIndex        =   43
            Top             =   580
            Width           =   1050
         End
         Begin VB.Label Label29 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "+ End Limit"
            Height          =   255
            Left            =   90
            TabIndex        =   42
            Top             =   270
            Width           =   1050
         End
      End
      Begin VB.Frame Frame3 
         Caption         =   "Universal I/O"
         Height          =   2500
         Left            =   1720
         TabIndex        =   6
         Top             =   200
         Width           =   1690
         Begin VB.PictureBox LedOut2 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   87
            Top             =   1200
            Width           =   255
         End
         Begin VB.PictureBox LedOut5 
            BackColor       =   &H00000080&
            Enabled         =   0   'False
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   29
            Top             =   2140
            Width           =   255
         End
         Begin VB.PictureBox LedOut4 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   28
            Top             =   1820
            Width           =   255
         End
         Begin VB.PictureBox LedOut3 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   27
            Top             =   1500
            Width           =   255
         End
         Begin VB.PictureBox LedOut0 
            BackColor       =   &H00000080&
            ForeColor       =   &H00000000&
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   26
            Top             =   565
            Width           =   255
         End
         Begin VB.PictureBox LedOut1 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   870
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   25
            Top             =   880
            Width           =   255
         End
         Begin VB.PictureBox LedIn5 
            BackColor       =   &H00000080&
            Enabled         =   0   'False
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   24
            Top             =   2140
            Width           =   255
         End
         Begin VB.PictureBox LedIn4 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   23
            Top             =   1820
            Width           =   255
         End
         Begin VB.PictureBox LedIn3 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   22
            Top             =   1500
            Width           =   255
         End
         Begin VB.PictureBox LedIn2 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   21
            Top             =   1200
            Width           =   255
         End
         Begin VB.PictureBox LedIn0 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   20
            Top             =   565
            Width           =   255
         End
         Begin VB.PictureBox LedIn1 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   195
            TabIndex        =   19
            Top             =   880
            Width           =   255
         End
         Begin VB.Label Label24 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "5"
            Enabled         =   0   'False
            Height          =   270
            Left            =   1160
            TabIndex        =   41
            Top             =   2140
            Width           =   440
         End
         Begin VB.Label Label23 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "4"
            Height          =   270
            Left            =   1160
            TabIndex        =   40
            Top             =   1820
            Width           =   440
         End
         Begin VB.Label Label22 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "3"
            Height          =   270
            Left            =   1160
            TabIndex        =   39
            Top             =   1500
            Width           =   440
         End
         Begin VB.Label Label21 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "2"
            Height          =   270
            Left            =   1160
            TabIndex        =   38
            Top             =   1200
            Width           =   440
         End
         Begin VB.Label Label20 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Alm"
            Height          =   270
            Left            =   1160
            TabIndex        =   37
            Top             =   880
            Width           =   440
         End
         Begin VB.Label Label19 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Son"
            Height          =   270
            Left            =   1160
            TabIndex        =   36
            Top             =   565
            Width           =   435
         End
         Begin VB.Label Label18 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "5"
            Enabled         =   0   'False
            Height          =   270
            Left            =   410
            TabIndex        =   35
            Top             =   2140
            Width           =   420
         End
         Begin VB.Label Label17 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "4"
            Height          =   270
            Left            =   410
            TabIndex        =   34
            Top             =   1820
            Width           =   420
         End
         Begin VB.Label Label16 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "3"
            Height          =   270
            Left            =   410
            TabIndex        =   33
            Top             =   1500
            Width           =   420
         End
         Begin VB.Label Label15 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "2"
            Height          =   270
            Left            =   410
            TabIndex        =   32
            Top             =   1200
            Width           =   420
         End
         Begin VB.Label Label14 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Zph"
            Height          =   270
            Left            =   410
            TabIndex        =   31
            Top             =   880
            Width           =   420
         End
         Begin VB.Label Label13 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Org"
            Height          =   270
            Left            =   410
            TabIndex        =   30
            Top             =   565
            Width           =   420
         End
         Begin VB.Label Label12 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "OUT"
            Height          =   270
            Left            =   850
            TabIndex        =   18
            Top             =   240
            Width           =   735
         End
         Begin VB.Label Label11 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "IN"
            Height          =   270
            Left            =   120
            TabIndex        =   17
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.Frame m_grLevel 
         Caption         =   "Level Setting"
         Height          =   2510
         Left            =   0
         TabIndex        =   5
         Top             =   200
         Width           =   1680
         Begin VB.ComboBox cboLevel4 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":0806
            Left            =   1160
            List            =   "frmCamcQI.frx":0813
            Style           =   2  '드롭다운 목록
            TabIndex        =   219
            Top             =   2160
            Width           =   480
         End
         Begin VB.ComboBox cboLevel3 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":0820
            Left            =   1160
            List            =   "frmCamcQI.frx":082D
            Style           =   2  '드롭다운 목록
            TabIndex        =   218
            Top             =   1200
            Width           =   480
         End
         Begin VB.ComboBox cboLevel2 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":083A
            Left            =   1160
            List            =   "frmCamcQI.frx":0847
            Style           =   2  '드롭다운 목록
            TabIndex        =   217
            Top             =   960
            Width           =   480
         End
         Begin VB.ComboBox cboLevel1 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":0854
            Left            =   1160
            List            =   "frmCamcQI.frx":0861
            Style           =   2  '드롭다운 목록
            TabIndex        =   216
            Top             =   600
            Width           =   480
         End
         Begin VB.ComboBox cboLevel0 
            Height          =   300
            ItemData        =   "frmCamcQI.frx":086E
            Left            =   1160
            List            =   "frmCamcQI.frx":087B
            Style           =   2  '드롭다운 목록
            TabIndex        =   215
            Top             =   240
            Width           =   480
         End
         Begin VB.CheckBox chkZPhaseLevel 
            Height          =   255
            Left            =   1280
            TabIndex        =   16
            Top             =   1820
            Value           =   1  '확인
            Width           =   255
         End
         Begin VB.CheckBox chkHomeLevel 
            Height          =   180
            Left            =   1280
            TabIndex        =   15
            Top             =   1540
            Value           =   1  '확인
            Width           =   255
         End
         Begin VB.Label Label10 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Emg"
            Height          =   270
            Left            =   90
            TabIndex        =   14
            Top             =   2140
            Width           =   1050
         End
         Begin VB.Label Label9 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Zphase"
            Height          =   270
            Left            =   90
            TabIndex        =   13
            Top             =   1820
            Width           =   1050
         End
         Begin VB.Label Label8 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Home"
            Height          =   270
            Left            =   90
            TabIndex        =   12
            Top             =   1500
            Width           =   1050
         End
         Begin VB.Label Label7 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Alarm"
            Height          =   270
            Left            =   90
            TabIndex        =   11
            Top             =   1200
            Width           =   1050
         End
         Begin VB.Label Label5 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "Inposition"
            Height          =   270
            Left            =   90
            TabIndex        =   10
            Top             =   880
            Width           =   1050
         End
         Begin VB.Label lbl 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "- End Level"
            Height          =   270
            Left            =   90
            TabIndex        =   55
            Top             =   565
            Width           =   1050
         End
         Begin VB.Label Label3 
            Alignment       =   2  '가운데 맞춤
            BorderStyle     =   1  '단일 고정
            Caption         =   "+ End Limit"
            Height          =   270
            Left            =   90
            TabIndex        =   54
            Top             =   240
            Width           =   1050
         End
      End
   End
   Begin AxtXYGraphLib.AxtXYGraph XYPlot 
      Height          =   4095
      Left            =   7845
      TabIndex        =   214
      Top             =   120
      Width           =   4575
      _Version        =   65536
      _ExtentX        =   8070
      _ExtentY        =   7223
      _StockProps     =   0
      GridColor       =   16761024
      BackColor       =   4194304
      PlotColor       =   65280
      LeftRange       =   0
      RightRange      =   250
      LowerRange      =   0
      UpperRange      =   250
      XUnits          =   " X Axis"
      YUnits          =   " Y Axis"
      AppendPointX    =   0
      AppendPointY    =   0
   End
   Begin VB.Label Label2 
      Alignment       =   2  '가운데 맞춤
      BorderStyle     =   1  '단일 고정
      Caption         =   "Axis No"
      Height          =   270
      Index           =   1
      Left            =   45
      TabIndex        =   0
      Top             =   4760
      Width           =   1170
   End
   Begin VB.Label Label1 
      Alignment       =   2  '가운데 맞춤
      BorderStyle     =   1  '단일 고정
      Caption         =   "Unit/Pulse"
      Height          =   270
      Left            =   45
      TabIndex        =   2
      Top             =   4395
      Width           =   1170
   End
End
Attribute VB_Name = "frmCamcQI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public m_lAxis As Long
Public m_lAxisCounts As Long

Public m_bA4NAxis As Boolean

Dim m_lRange As Long

Dim g_Search(3) As New clsSearch
Dim g_Repeat(3) As New clsRepeat
Dim g_nTest As Integer
Dim g_nIntCnt As Integer
Private Sub CLR_Click()
    AxmContiWriteClear COORD_NO
End Sub
Private Sub AxtMsg_OnMessage1(ByVal wParam As Long, ByVal lParam As Long)
    Dim nBoard As Integer
    Dim lAxisNo As Long
    Dim nIntrFlag As Integer
    Dim IntBank0, IntBank1 As Long
    
    nBoard = wParam / 256       ' Interrupt generation board number.
    lAxisNo = CByte(wParam)     ' Interrupt generation axis number.
    nIntrFlag = CInt(lParam)    ' Interrupt generation axis location.
    
    AxmInterruptReadAxisFlag lAxisNo, 0, IntBank0
    AxmInterruptReadAxisFlag lAxisNo, 1, IntBank1

    g_nIntCnt = g_nIntCnt + 1
    lstLog.AddItem "Msg[" + Format(g_nIntCnt) + "]Axis[" + Format(lAxisNo) + "]Flag[0x" + Format(nIntrFlag) + "]"

End Sub
' Setup active level value of (+) End Limit.
Private Sub cboLevel0_Click()
    Dim dwPositiveLevel, dwNegativeLevel, upStopMode As Long
  
    AxmSignalGetLimit m_lAxis, upStopMode, 0, dwNegativeLevel
    
    If (m_bA4NAxis = False) Then
        AxmSignalSetLimit m_lAxis, upStopMode, cboLevel0.ListIndex, dwNegativeLevel
    Else
        If (cboLevel0.ListIndex = 0) Then
            dwPositiveLevel = 2
        Else
            dwPositiveLevel = 1
        End If
        AxmSignalSetLimit m_lAxis, upStopMode, dwPositiveLevel, dwNegativeLevel
    End If
End Sub

' Setup active level value of (-) End Limit.
Private Sub cboLevel1_Click()
    Dim dwPositiveLevel, dwNegativeLevel, upStopMode As Long
  
    AxmSignalGetLimit m_lAxis, upStopMode, dwPositiveLevel, 0
    
    If (m_bA4NAxis = False) Then
        AxmSignalSetLimit m_lAxis, upStopMode, dwPositiveLevel, cboLevel1.ListIndex
    Else
        If (cboLevel1.ListIndex = 0) Then
            dwNegativeLevel = 2
        Else
            dwNegativeLevel = 1
        End If
        AxmSignalSetLimit m_lAxis, upStopMode, dwPositiveLevel, dwNegativeLevel
    End If
End Sub

' Setup active level value of in-position signal.  High if checked, Low if not checked.
Private Sub cboLevel2_Click()
    Dim dwLevel As Long
    
    If (m_bA4NAxis = False) Then
        AxmSignalSetInpos m_lAxis, cboLevel2.ListIndex
    Else
        If (cboLevel2.ListIndex = 0) Then
            dwLevel = 2
        Else
            dwLevel = 1
        End If
        AxmSignalSetInpos m_lAxis, dwLevel
    End If
End Sub

' Setup active level value of alarm signal.  High if checked, Low if not checked.
Private Sub cboLevel3_Click()
    Dim dwLevel As Long
    
    If (m_bA4NAxis = False) Then
        AxmSignalSetServoAlarm m_lAxis, cboLevel3.ListIndex
    Else
        If (cboLevel3.ListIndex = 0) Then
            dwLevel = 2
        Else
            dwLevel = 1
        End If
        AxmSignalSetServoAlarm m_lAxis, dwLevel
    End If
End Sub
' Setup active level value of Emg Signal.
Private Sub cboLevel4_Click()
    Dim dwLevel As Long
    
    If (m_bA4NAxis = False) Then
        AxmSignalSetStop m_lAxis, EMERGENCY_STOP, cboLevel4.ListIndex
    Else
        If (cboLevel4.ListIndex = 0) Then
            dwLevel = 2
        Else
            dwLevel = 1
        End If
        AxmSignalSetStop m_lAxis, EMERGENCY_STOP, dwLevel
    End If
End Sub
Private Sub chkHomeLevel_Click()
    If (m_bA4NAxis = False) Then
        AxmHomeSetSignalLevel m_lAxis, chkHomeLevel.Value
    End If
End Sub
Private Sub chkZphaseLevel_Click()
    If (m_bA4NAxis = False) Then
        AxmSignalSetZphaseLevel m_lAxis, chkZPhaseLevel.Value
    End If
End Sub

Private Sub Form_Load()
    m_lRange = 2500
    
    InitLibrary     ' Combined Library and Module initialize
    InitControl     ' Graph and button control initialize
    
    If (m_lAxisCounts > 0) Then
        UpdateAxisInfo
    End If
    
    tmDisplay.Enabled = True
    tmGraph.Enabled = True
End Sub
Private Sub btnContiLine_Click()
    Dim lAxis(2) As Long
    Dim dPos(2) As Double
    Dim dVelocity As Double
    Dim dAccel, dDecel As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)
    lAxis(2) = AXIS_N04(m_lAxis, 2)

    SetGraphRange lAxis(0), dVelocity
    SetGraphRange lAxis(2), dVelocity

    AxmContiSetAxisMap COORD_NO, 3, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE

    AxmContiBeginNode COORD_NO

    dPos(0) = 0: dPos(1) = 0: dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = 2000: dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = 2000: dPos(2) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 2000: dPos(1) = 0: dPos(2) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = -2000: dPos(2) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = -2000: dPos(1) = 0: dPos(2) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = 2000: dPos(2) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = 2000: dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0: dPos(1) = 0: dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    AxmContiEndNode COORD_NO
End Sub
Private Sub btnContiCircle_Click()
    Dim lAxis(2) As Long
    Dim dAccel, dDecel As Double
    Dim dVelocity As Double
    Dim dCenPos(2), dEndPos(2) As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)

    SetGraphRange lAxis(0), dVelocity

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE

    AxmContiBeginNode COORD_NO

    dCenPos(0) = 1000: dCenPos(1) = 1000: dEndPos(0) = 0: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = -1000: dCenPos(1) = 1000: dEndPos(0) = 0: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = -1000: dCenPos(1) = -1000: dEndPos(0) = 0: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = 1000: dCenPos(1) = -1000: dEndPos(0) = 0: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    AxmContiEndNode COORD_NO
End Sub
Private Sub btnContiSpline_Click()
    Dim lAxis(2) As Long
    Dim dPosX(4) As Double
    Dim dPosY(4) As Double
    Dim dAccel, dDecel As Double
    Dim dVelocity As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)

    SetGraphRange lAxis(0), dVelocity

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE

    dPosX(0) = 0:    dPosY(0) = 0
    dPosX(1) = 450:  dPosY(1) = 100
    dPosX(2) = 750:  dPosY(2) = 450
    dPosX(3) = 1080: dPosY(3) = 750
    dPosX(4) = 1300: dPosY(4) = 700
    AxmContiBeginNode COORD_NO

    AxmSplineWrite COORD_NO, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 0, 100
    AxmContiEndNode COORD_NO
End Sub
Private Sub btnContiBlend_Click()
    Dim lAxis(2) As Long
    Dim dPos(2) As Double
    Dim dCenPos(2) As Double
    Dim dEndPos(2) As Double
    Dim dAccel, dDecel As Double
    Dim dVelocity As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)

    SetGraphRange lAxis(0), dVelocity

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE

    AxmContiBeginNode COORD_NO
    dPos(0) = 0: dPos(1) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 1800: dPos(1) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dCenPos(0) = 1800: dCenPos(1) = 1800: dEndPos(0) = 2000: dEndPos(1) = 1800
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW

    dPos(0) = 2000: dPos(1) = -1800
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel

    dCenPos(0) = 1800: dCenPos(1) = -1800: dEndPos(0) = 1800: dEndPos(1) = -2000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW

    dPos(0) = -1800: dPos(1) = -2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel

    dCenPos(0) = -1800:  dCenPos(1) = -1800: dEndPos(0) = -2000: dEndPos(1) = -1800
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW

    dPos(0) = -2000: dPos(1) = 1800
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel

    dCenPos(0) = -1800: dCenPos(1) = 1800: dEndPos(0) = -1800: dEndPos(1) = 2000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW

    dPos(0) = 0: dPos(1) = 2000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel

    AxmContiEndNode COORD_NO
End Sub
Private Sub btnContiStart_Click()
    AxmContiStart COORD_NO, 0, 0
End Sub
Private Sub btn3DGraph_Click()
    frm3DGraph.UpdateAxis m_lAxis
    frm3DGraph.Show
End Sub
Private Sub btnContiTestLine_Click()
    Dim lAxis(0 To 3) As Long
    Dim dPos(0 To 3) As Double
    Dim dVelocity, dAccel, dDecel As Double
    
    dVelocity = CDbl(edtVelocity)
    dAccel = CDbl(edtAccel)
    dDecel = CDbl(edtDecel)

    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)
    lAxis(2) = AXIS_N04(m_lAxis, 2)
    
    AxmContiSetAxisMap COORD_NO, 3, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE
    
    AxmContiBeginNode COORD_NO

    dPos(0) = 0:     dPos(1) = 0:     dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = 1000:  dPos(2) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = 1000:  dPos(2) = 1000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 1000:  dPos(1) = 0:     dPos(2) = 1000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = -1000: dPos(2) = 1000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = -1000: dPos(1) = 0:     dPos(2) = 1000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = 1000:  dPos(2) = 1000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = 1000:  dPos(2) = 0:
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel

    dPos(0) = 0:     dPos(1) = 0:     dPos(2) = 0:
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dDecel
    
    AxmContiEndNode COORD_NO
End Sub
Private Sub btnJog_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim lAxisNo As Long
    Dim lAxis(2) As Long
    Dim dMVel(2), dMAcc(2), dMDec(2) As Double
    Dim dVelocity, dAccel, dDecel As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)
    
    dMAcc(0) = dMAcc(1) = dAccel
    dMDec(0) = dMDec(1) = dDecel
    
    Select Case Index
        Case 0
            lAxisNo = AXIS_N04(m_lAxis, 0)
            lAxis(0) = AXIS_N04(m_lAxis, 0)
            lAxis(1) = AXIS_N04(m_lAxis, 1)
            dMVel(0) = dVelocity
            dMVel(1) = dVelocity
        Case 1
            lAxisNo = AXIS_N04(m_lAxis, 0)
            lAxis(0) = AXIS_N04(m_lAxis, 0)
            lAxis(1) = AXIS_N04(m_lAxis, 1)
            dMVel(0) = -dVelocity
            dMVel(1) = -dVelocity
        Case 2
            lAxisNo = AXIS_N04(m_lAxis, 1)
            lAxis(0) = AXIS_N04(m_lAxis, 0)
            lAxis(1) = AXIS_N04(m_lAxis, 1)
            dMVel(0) = dVelocity
            dMVel(1) = dVelocity
        Case 3
            lAxisNo = AXIS_N04(m_lAxis, 1)
            lAxis(0) = AXIS_N04(m_lAxis, 0)
            lAxis(1) = AXIS_N04(m_lAxis, 1)
            dMVel(0) = -dVelocity
            dMVel(1) = -dVelocity
        Case 4
            lAxisNo = AXIS_N04(m_lAxis, 2)
            lAxis(0) = AXIS_N04(m_lAxis, 2)
            lAxis(1) = AXIS_N04(m_lAxis, 3)
            dMVel(0) = dVelocity
            dMVel(1) = dVelocity
        Case 5
            lAxisNo = AXIS_N04(m_lAxis, 2)
            lAxis(0) = AXIS_N04(m_lAxis, 2)
            lAxis(1) = AXIS_N04(m_lAxis, 3)
            dMVel(0) = -dVelocity
            dMVel(1) = -dVelocity
        Case 6
            lAxisNo = AXIS_N04(m_lAxis, 3)
            lAxis(0) = AXIS_N04(m_lAxis, 2)
            lAxis(1) = AXIS_N04(m_lAxis, 3)
            dMVel(0) = dVelocity
            dMVel(1) = dVelocity
        Case 7
            lAxisNo = AXIS_N04(m_lAxis, 3)
            lAxis(0) = AXIS_N04(m_lAxis, 2)
            lAxis(1) = AXIS_N04(m_lAxis, 3)
            dMVel(0) = -dVelocity
            dMVel(1) = -dVelocity
    End Select
    
    If (Index < 4) Then
        GraphX.SetRanges 0, dVelocity + (dVelocity * 0.2)
    Else
        GraphY.SetRanges 0, dVelocity + (dVelocity * 0.2)
    End If
    
    If (chkXYSyn.Value = 1) Then
        If (chkAsym.Value = True) Then
            AxmMoveStartMultiVel 2, lAxis(0), dMVel(0), dMAcc(0), dMDec(0)
        Else
            AxmMoveStartMultiVel 2, lAxis(0), dMVel(0), dMAcc(0), dMAcc(0)
        End If
    Else
        If (chkAsym.Value = 1) Then
            AxmMoveVel lAxisNo, dMVel(0), dAccel, dDecel
        Else
            AxmMoveVel lAxisNo, dMVel(0), dAccel, dAccel
        End If
    End If
End Sub
Private Sub btnJog_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim lAxisNo As Long
    lAxisNo = AXIS_N04(m_lAxis, Index \ 2)
    AxmMoveSStop lAxisNo
End Sub
Private Sub btnlinear_Click()
    Dim strMsg As String
    Dim lAxis(2) As Long
    Dim dPos(2) As Double
    Dim uErrorCode As Long
    Dim dPosition, dAccel, dDecel As Double
    Dim dVelocity As Double

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    dPos(0) = CDbl(edtXCen.Text)
    dPos(1) = CDbl(edtYCen.Text)

    lAxis(0) = AXIS_EVN(m_lAxis)
    lAxis(1) = AXIS_ODD(m_lAxis)

    SetGraphRange lAxis(0), dVelocity

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    
    SetCoordMovePara
    uErrorCode = AxmLineMove(COORD_NO, dPos(0), dVelocity, dAccel, dDecel)

    strMsg = "Linear Error Code:" + Format(uErrorCode)
    If (uErrorCode <> AXT_RT_SUCCESS) Then lstLog.AddItem (strMsg)

    AxmMotGetParaLoad m_lAxis, dPosition, 0, 0, 0
    AxmMotSetParaLoad m_lAxis, dPosition, dVelocity, dAccel, dDecel
End Sub
Private Sub SetCoordMovePara()
    If (chkAbsolute.Value = 1) Then
        AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE
    Else
        AxmContiSetAbsRelMode COORD_NO, POS_REL_MODE
    End If
End Sub
Private Sub btnCircular_Click()
    Dim lAxis(2) As Long
    Dim dCenPos(2) As Double
    Dim uErrorCode As Long
    Dim dAccel, dDecel, dAngle As Double
    Dim dPosition, dVelocity As Double
    
    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)
    dAngle = CDbl(edtAngle.Text)

    dCenPos(0) = CDbl(edtXCen.Text)
    dCenPos(1) = CDbl(edtYCen.Text)

    lAxis(0) = AXIS_EVN(m_lAxis)
    lAxis(0) = AXIS_ODD(m_lAxis)

    SetGraphRange lAxis(0), dVelocity


    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    SetCoordMovePara
    If chkCwCcw.Value = True Then
        uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis(0), dCenPos(0), dAngle, dVelocity, dAccel, dDecel, 0)
    Else
        uErrorCode = AxmCircleAngleMove(COORD_NO, lAxis(0), dCenPos(0), dAngle, dVelocity, dAccel, dDecel, 1)
    End If

    If uErrorCode <> AXT_RT_SUCCESS Then
        lstLog.AddItem "Circular Error Code: " + Format(uErrorCode)
    End If

    AxmMotGetParaLoad m_lAxis, dPosition, 0, 0, 0
    AxmMotSetParaLoad m_lAxis, dPosition, dVelocity, dAccel, dDecel
End Sub
Private Sub btnManualSet_Click()
    frmManualSet.UpdateAxis m_lAxis
    frmManualSet.Show
End Sub
Private Sub btnReadCapture_Click()
    Dim dCapPos As Double
    
    AxmMoveGetCapturePos m_lAxis, dCapPos
    edtCapturePos.Caption = Format(dCapPos, "0.00000")
End Sub
Private Sub btnStop_Click()
    If tmTest(AXIS_QUR(m_lAxis)).Enabled = True Then
        g_Repeat(AXIS_QUR(m_lAxis)).nRun = 0
        g_Search(AXIS_QUR(m_lAxis)).nRun = 0
        AxmMoveSStop m_lAxis
    Else
        AxmMoveSStop m_lAxis
    End If

    lstLog.AddItem "Stop move."
    lstLog.ListIndex = lstLog.ListCount - 1
End Sub
Private Sub btnEstop_Click()
    Dim i As Integer
    
    frmCamcQI.tmTest(AXIS_QUR(0)).Enabled = False
    frmCamcQI.tmTest(AXIS_QUR(1)).Enabled = False
    frmCamcQI.tmTest(AXIS_QUR(2)).Enabled = False
    frmCamcQI.tmTest(AXIS_QUR(3)).Enabled = False

    For i = 0 To m_lAxisCounts - 1
        AxmMoveEStop i
    Next i

    lstLog.AddItem "All axis emergency stopped."
    lstLog.ListIndex = lstLog.ListCount - 1
End Sub
Private Sub btnVelover_Click()
    Dim dPosition As Double
    Dim dVelocity As Double
    Dim dAccel As Double
    Dim dDecel As Double

    dPosition = CDbl(edtPosition.Text)
    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)

    SetGraphRange m_lAxis, dVelocity * 2
    AxmOverrideVelAtPos m_lAxis, dPosition, dVelocity, dAccel, dAccel, dPosition / 4, dVelocity * 2, Command
End Sub
' Make edit window to be active for setting a value of reduced speed when asymmetric running mode.
Private Sub chkAsym_Click()
    Dim dwProfile As Long
    'ProfileMode: '0' - symmetry Trapezode
    '             '1' - asymmetry Trapezode
    '             '2' - symmetry Quasi-S Curve
    '             '3' - symmetry S Curve
    '             '4' - asymmetry S Curve
    AxmMotGetProfileMode m_lAxis, dwProfile
    If chkAsym.Value = 1 Then
        edtDecel.Enabled = True
        If (dwProfile = 0) Or (dwProfile = 3) Then
            dwProfile = (dwProfile + 1)
        Else
            dwProfile = 4
        End If
    Else
        edtDecel.Enabled = False
        If (dwProfile = 1) Or (dwProfile = 4) Then
            dwProfile = (dwProfile - 1)
        Else
            dwProfile = 3
        End If
    End If
    
    AxmMotSetProfileMode m_lAxis, dwProfile
End Sub
Private Sub chkSCurve_Click()
    Dim dwProfile As Long
    'ProfileMode: '0' - symmetry Trapezode
    '             '1' - asymmetry Trapezode
    '             '2' - symmetry Quasi-S Curve
    '             '3' - symmetry S Curve
    '             '4' - asymmetry S Curve
    AxmMotGetProfileMode m_lAxis, dwProfile
    If chkSCurve.Value = 1 Then
        If (dwProfile = 0 Or dwProfile = 1) Then
            dwProfile = (dwProfile + 3)
        Else
            dwProfile = 3
        End If
    Else
        If (dwProfile = 3 Or dwProfile = 4) Then
            dwProfile = (dwProfile - 3)
        Else
            dwProfile = 0
        End If
    End If
    AxmMotSetProfileMode m_lAxis, dwProfile
End Sub
Private Sub chkGantry_Click()
    Dim uErrorCode As Long
    If (chkGantry.Value = 1) Then
        uErrorCode = AxmGantrySetEnable(AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), cbGantrySlave.ListIndex, 0#, 100000#)
        lstLog.AddItem "Gantry Enable ErrCode " + Trim(uErrorCode)
    Else
        AxmGantrySetDisable AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis)
        lstLog.AddItem "Gantry Disable"
    End If
End Sub
Private Sub chkGearOnOff_Click()
   Dim dRatio As Double
    dRatio = CDbl(edtGearRatio.Text)
    ' It is a function to setup gear rate of Master axis and Slave axis on Electric Gear mode.
    If (chkGearOnOff.Value = 1) Then
        AxmLinkSetMode AXIS_EVN(m_lAxis), AXIS_ODD(m_lAxis), dRatio
    Else
        AxmLinkResetMode AXIS_EVN(m_lAxis)
    End If
End Sub
Private Sub btnContiTestSpline_Click()
    Dim dVelocity, dAccel, dDecel As Double
    Dim dPosX(0 To 4) As Double
    Dim dPosY(0 To 4) As Double
    Dim lAxis(0 To 1) As Long
    
    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)
   
    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, 0
    
    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiSetAbsRelMode COORD_NO, 0

    dPosX(0) = 0: dPosY(0) = 0
    dPosX(1) = 450: dPosY(1) = 100
    dPosX(2) = 750: dPosY(2) = 450
    dPosX(3) = 1080: dPosY(3) = 750
    dPosX(4) = 1300: dPosY(4) = 700

    AxmContiBeginNode COORD_NO
    AxmSplineWrite COORD_NO, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 0, 100
    AxmContiEndNode COORD_NO
End Sub
Private Sub btnContiClear_Click()
    AxmContiWriteClear COORD_NO
End Sub
Private Sub btnContiTest_Click()
    Dim dVelocity As Double
    Dim dAccel As Double
    
    Dim lAxis(1) As Long
    Dim dPos(1) As Double
    Dim lPosSize As Long
    Dim dCenPos(1) As Double
    Dim dEndPos(1) As Double

    lPosSize = 2
    lAxis(0) = 0
    lAxis(1) = 1
    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)

    SetGraphRange lAxis(0), dVelocity

    AxmContiSetAxisMap COORD_NO, lPosSize, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_REL_MODE

    AxmContiBeginNode COORD_NO: dPos(0) = -15000: dPos(1) = 0

    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                  '1
    dCenPos(0) = 0: dCenPos(1) = 5000: dEndPos(0) = -5000: dEndPos(1) = 5000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '2
    dPos(0) = 0: dPos(1) = 30000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel  '3
    dCenPos(0) = 5000: dCenPos(1) = 0: dEndPos(0) = 5000: dEndPos(1) = 5000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '4
    dPos(0) = 30000: dPos(1) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                '5
    dCenPos(0) = 0: dCenPos(1) = -5000: dEndPos(0) = 5000: dEndPos(1) = -5000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '6
    dPos(0) = 0: dPos(1) = -30000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                  '7
    dCenPos(0) = -5000: dCenPos(1) = 0: dEndPos(0) = -5000: dEndPos(1) = -5000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '8
    dPos(0) = -15000: dPos(1) = 0

    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                '9
    dPos(0) = -10000: dPos(1) = 0

    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                  '10
    dCenPos(0) = 0: dCenPos(1) = 10000: dEndPos(0) = -10000: dEndPos(1) = 10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '11
    dPos(0) = 0: dPos(1) = 20000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                    '12
    dCenPos(0) = 10000: dCenPos(1) = 0: dEndPos(0) = 10000: dEndPos(1) = 10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '13
    dPos(0) = 20000: dPos(1) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                    '14
    dCenPos(0) = 0: dCenPos(1) = -10000: dEndPos(0) = 10000: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '15
    dPos(0) = 0:  dPos(1) = -20000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                    '16
    dCenPos(0) = -10000: dCenPos(1) = 0: dEndPos(0) = -10000: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW    '17
    dPos(0) = -10000: dPos(1) = 0
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                      '18
    dCenPos(0) = 0: dCenPos(1) = 20000: dEndPos(0) = 0: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '19
    dCenPos(0) = 0: dCenPos(1) = 10000: dEndPos(0) = -7071: dEndPos(1) = 2929
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '20

    dPos(0) = -10000: dPos(1) = 10000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                  '21
    dCenPos(0) = 7071: dCenPos(1) = 7071: dEndPos(0) = 0: dEndPos(1) = 14142
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '22
    dPos(0) = 10000: dPos(1) = 10000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                   '23
    dCenPos(0) = 7071: dCenPos(1) = -7071: dEndPos(0) = 14142: dEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '24
    dPos(0) = 10000: dPos(1) = -10000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel                  '25
    dCenPos(0) = -7071: dCenPos(1) = -7071: dEndPos(0) = 0: dEndPos(1) = -14142
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '26
    dPos(0) = -10000: dPos(1) = -10000
    AxmLineMove COORD_NO, dPos(0), dVelocity, dAccel, dAccel     '27
    dCenPos(0) = -7071: dCenPos(1) = 7071: dEndPos(0) = -7071: dEndPos(1) = -2929

    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '28
    dCenPos(0) = 0: dCenPos(1) = 10000: dEndPos(0) = 0: dEndPos(1) = 20000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '29
    dCenPos(0) = 0: dCenPos(1) = 10000: dEndPos(0) = 0: dEndPos(1) = 20000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW           '30
    dCenPos(0) = 0: dCenPos(1) = -5000: dEndPos(0) = 0: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW           '31

    dCenPos(0) = 0: dCenPos(1) = -5000: dEndPos(0) = 0: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '32
    dCenPos(0) = 0: dCenPos(1) = -5000: dEndPos(0) = 0: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW           '33
    dCenPos(0) = 0: dCenPos(1) = -5000: dEndPos(0) = 0: dEndPos(1) = -10000
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dEndPos(0), dVelocity, dAccel, dAccel, DIR_CW            '34

    AxmContiEndNode COORD_NO
End Sub
Private Sub btnStatus_Click()
    frmStatus.UpdateAxis m_lAxis
    frmStatus.Show
End Sub
Private Sub btnCountclr_Click()
    AxmStatusSetActPos AXIS_N04(m_lAxis, 0), 0#
    AxmStatusSetActPos AXIS_N04(m_lAxis, 1), 0#
    AxmStatusSetCmdPos AXIS_N04(m_lAxis, 2), 0#
    AxmStatusSetCmdPos AXIS_N04(m_lAxis, 3), 0#

    AxmStatusSetCmdPos AXIS_N04(m_lAxis, 0), 0#
    AxmStatusSetCmdPos AXIS_N04(m_lAxis, 1), 0#
    AxmStatusSetActPos AXIS_N04(m_lAxis, 2), 0#
    AxmStatusSetActPos AXIS_N04(m_lAxis, 3), 0#

    XYPlot.Reset = 1
    lstLog.Clear
End Sub
Function InitLibrary() As Boolean
    ' Initialize AXT board
    If (AxlOpen(7) <> AXT_RT_SUCCESS) Then
        MsgBox ("Intialize Fail..!!")
    End If
End Function
' Initialize Control
Sub InitControl()
    Dim i As Integer
    Dim lModuleID As Long

    cboDetect.ListIndex = 4
    cboDirection.ListIndex = 1
    cboStopM.ListIndex = 1
    
    cboHomeSignal.ListIndex = 2
    cboHomeDir.ListIndex = 0
    
    
    XYPlot.SetRange -2500, 2500, -2500, 2500
        
    GraphX.SetRanges 0, 400
    GraphX.SetPlotColor vbRed, 0
    GraphX.SetPlotColor vbGreen, 1
    GraphX.SetXUnits "Time(sampling: 100 msec)", "0", ""
    GraphX.SetYUnits "unit/s", "0", ""
    
    GraphY.SetRanges 0, 400
    GraphY.SetPlotColor vbYellow, 0
    GraphY.SetPlotColor vbCyan, 1
    GraphY.SetXUnits "Time(sampling: 100 msec)", "0", ""
    GraphY.SetYUnits "unit/s", "0", ""
  
    AxmInfoGetAxisCount m_lAxisCounts
    ' Initialize setup of axis
    For i = 0 To m_lAxisCounts - 1
        AxmInfoGetAxis i, 0, 0, lModuleID
        Select Case lModuleID
        Case AXT_SMC_4V04
            cboAxisSet.AddItem Format(i, "00") + "-[PCIB-QI4A]"
        Case AXT_SMC_2V04
            cboAxisSet.AddItem Format(i, "00") + "-[PCIB-QI2A]"
        Case AXT_SMC_R1V04
            cboAxisSet.AddItem Format(i, "00") + "-(RTEX-PM)"
        Case AXT_SMC_R1V04PM2Q
            cboAxisSet.AddItem Format(i, "00") + "-(RTEX-PM2Q)"
        Case AXT_SMC_R1V04PM2QE
            cboAxisSet.AddItem Format(i, "00") + "-(RTEX-PM2QE)"
        Case AXT_SMC_R1V04A4
            cboAxisSet.AddItem Format(i, "00") + "-[RTEX-A4N]"
        Case AXT_SMC_R1V04A5
            cboAxisSet.AddItem Format(i, "00") + "-[RTEX-A5N]"
        Case AXT_SMC_R1V04MLIISV
            cboAxisSet.AddItem Format(i, "00") + "-[MLII-SGDV]"
        Case AXT_SMC_R1V04MLIICL
            cboAxisSet.AddItem Format(i, "00") + "-[MLII-CSDL]"
        Case AXT_SMC_R1V04MLIICR
            cboAxisSet.AddItem Format(i, "00") + "-[MLII-CSDH]"
        Case AXT_SMC_R1V04MLIIPM
            cboAxisSet.AddItem Format(i, "00") + "-(MLII-PM)"
        Case AXT_SMC_R1V04SIIIHMIV
            cboAxisSet.AddItem Format(i, "00") + "-[SIIIH-MRJ4]"
        Case Else
            cboAxisSet.AddItem Format(i, "00") + "-[Unknown]"
        End Select
    Next
End Sub

Sub UpdateAxisInfo()
    Dim dwMEncInput, dwMPulseOut As Long
    Dim dwAbsRel, dwProfile As Long
     
    Dim lPulse As Long
    Dim dUnit As Double
    Dim dMinVelocity As Double
    Dim dInitPos, dInitVel, dInitAccel, dInitDecel As Double
    
    Dim dwPositiveLevel, dwNegativeLevel, dwAlarmLevel, dwInposLevel, dwSlhomeUse As Long
    Dim dwHomeLevel, dwZphaseLevel As Long
    Dim dwStopMode, dwReadEmg As Long
    Dim dGearRatio As Double

    Dim dwModuleID As Long
    
    cboAxisSet.ListIndex = m_lAxis
    lPulse = 1
    dUnit = 1#: dGearRatio = 1#
    dMinVelocity = 1#: dInitPos = 1#: dInitVel = 1#: dInitAccel = 1#: dInitDecel = 1#
    dwPositiveLevel = 0: dwNegativeLevel = 0: dwAlarmLevel = 0: dwInposLevel = 0: dwSlhomeUse = 0
    
    
    AxmInfoGetAxis m_lAxis, 0, 0, dwModuleID
    If (dwModuleID = AXT_SMC_4V04) Or (dwModuleID = AXT_SMC_2V04) Or (dwModuleID = AXT_SMC_2V03) Or (dwModuleID = AXT_SMC_R1V04) Or (dwModuleID = AXT_SMC_R1V04PM2Q) Or (dwModuleID = AXT_SMC_R1V04PM2QE) Then
        m_bA4NAxis = False
        
        cboEncInputM.Enabled = True
        cboPulseOutM.Enabled = True

        cboLevel0.Clear
        cboLevel0.AddItem "L"
        cboLevel0.AddItem "H"
        cboLevel0.AddItem "D"
        cboLevel1.Clear
        cboLevel1.AddItem "L"
        cboLevel1.AddItem "H"
        cboLevel1.AddItem "D"
        cboLevel2.Clear
        cboLevel2.AddItem "L"
        cboLevel2.AddItem "H"
        cboLevel2.AddItem "D"
        cboLevel3.Clear
        cboLevel3.AddItem "L"
        cboLevel3.AddItem "H"
        cboLevel3.AddItem "D"
        cboLevel4.Clear
        cboLevel4.AddItem "L"
        cboLevel4.AddItem "H"
        cboLevel4.AddItem "D"
        
        chkZPhaseLevel.Enabled = True
        chkHomeLevel.Enabled = True

        edtTrigStartPosition.Enabled = True
        edtTrigCycle.Enabled = True
        edtTrigPulseWidth.Enabled = True
        edtTrigEndPos.Enabled = True
        btnTrigAbs.Enabled = True
        btnTrigOneShot.Enabled = True
        btnTrigPeriod.Enabled = True
        btnTrigReset.Enabled = True
        m_grLevel.Caption = "Level Setting"
        
        If (dwModuleID = AXT_SMC_R1V04) Or (dwModuleID = AXT_SMC_R1V04PM2Q) Or (dwModuleID = AXT_SMC_R1V04PM2QE) Then
            btnMPGOn.Enabled = False
            btnMPGOff.Enabled = False
            btnCRCOn.Enabled = False
            btnCRCOff.Enabled = False
            btnIntMessage.Enabled = False
            btnIntDisable.Enabled = False
            btnReadCapture.Enabled = False
            btnSigCapture.Enabled = False
        Else
            btnMPGOn.Enabled = True
            btnMPGOff.Enabled = True
            btnCRCOn.Enabled = True
            btnCRCOff.Enabled = True
            btnIntMessage.Enabled = True
            btnIntDisable.Enabled = True
            btnReadCapture.Enabled = True
            btnSigCapture.Enabled = True
        End If
        
    ElseIf (dwModuleID = AXT_SMC_R1V04A4) Or (dwModuleID = AXT_SMC_R1V04A5) Or (dwModuleID = AXT_SMC_R1V04MLIISV) Or (dwModuleID = AXT_SMC_R1V04SIIIHMIV) Then
        m_bA4NAxis = True
        
        cboEncInputM.Enabled = False
        cboPulseOutM.Enabled = False

        cboLevel0.Clear
        cboLevel0.AddItem "D"
        cboLevel0.AddItem "E"
        cboLevel1.Clear
        cboLevel1.AddItem "D"
        cboLevel1.AddItem "E"
        cboLevel2.Clear
        cboLevel2.AddItem "D"
        cboLevel2.AddItem "E"
        cboLevel3.Clear
        cboLevel3.AddItem "D"
        cboLevel3.AddItem "E"
        cboLevel4.Clear
        cboLevel4.AddItem "D"
        cboLevel4.AddItem "E"
        
        chkZPhaseLevel.Enabled = False
        chkHomeLevel.Enabled = False

        edtTrigStartPosition.Enabled = False
        edtTrigCycle.Enabled = False
        edtTrigPulseWidth.Enabled = False
        edtTrigEndPos.Enabled = False
        btnTrigAbs.Enabled = False
        btnTrigOneShot.Enabled = False
        btnTrigPeriod.Enabled = False
        btnTrigReset.Enabled = False
        btnMPGOn.Enabled = False
        btnMPGOff.Enabled = False
        btnCRCOn.Enabled = False
        btnCRCOff.Enabled = False
        
        m_grLevel.Caption = "Level/Usage"
        
        btnIntMessage.Enabled = False
        btnIntDisable.Enabled = False
        btnReadCapture.Enabled = False
        btnSigCapture.Enabled = False
   End If
        
    AxmMotGetParaLoad m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel

    ' Display pulse output method after initialization, encoder input method, initial speed, distance rate by pulse on the screen.
    AxmMotGetMoveUnitPerPulse m_lAxis, dUnit, lPulse
    AxmMotGetMinVel m_lAxis, dMinVelocity
    
    edtUnit.Text = Format(dUnit, "0.00000")
    edtPulse.Text = CStr(lPulse)
    edtMoveUnit.Text = Format(dUnit / lPulse, "0.000000")
    edtStartSpeed.Text = Format(dMinVelocity, "0.000")
    
    edtPosition.Text = Format(dInitPos, "0.000")
    edtVelocity.Text = Format(dInitVel, "0.000")
    edtAccel.Text = Format(dInitAccel, "0.000")
    edtDecel.Text = Format(dInitDecel, "0.000")

    AxmMotGetProfileMode m_lAxis, dwProfile
    AxmMotGetAbsRelMode m_lAxis, dwAbsRel

    If (m_bA4NAxis = False) Then
        AxmMotGetEncInputMethod m_lAxis, dwMEncInput
        AxmMotGetPulseOutMethod m_lAxis, dwMPulseOut
        cboEncInputM.ListIndex = dwMEncInput
        cboPulseOutM.ListIndex = dwMPulseOut
    End If
    
    If (dwAbsRel = 1) Then
        chkRelative.Value = 1
        chkAbsolute.Value = 0
    Else
        chkRelative.Value = 0
        chkAbsolute.Value = 1
    End If

    If ((dwProfile = 2) Or (dwProfile = 3) Or (dwProfile = 4)) Then
        chkSCurve.Value = 1
    Else
        chkSCurve.Value = 0
    End If


    If ((dwProfile = 1) Or (dwProfile = 4)) Then
        edtDecel.Enabled = True
        chkAsym.Value = 1
    Else
        edtDecel.Enabled = False
        chkAsym.Value = 0
    End If

    AxmSignalGetLimit m_lAxis, dwStopMode, dwPositiveLevel, dwNegativeLevel
    AxmSignalGetServoAlarm m_lAxis, dwAlarmLevel
    AxmSignalGetInpos m_lAxis, dwInposLevel

    AxmSignalGetStop m_lAxis, dwStopMode, dwReadEmg
    
    If (m_bA4NAxis = False) Then
        AxmHomeGetSignalLevel m_lAxis, dwHomeLevel
        AxmSignalGetZphaseLevel m_lAxis, dwZphaseLevel

        If (dwPositiveLevel = 3) Then
            dwPositiveLevel = 0
        End If
        cboLevel0.ListIndex = dwPositiveLevel
        If (dwNegativeLevel = 3) Then
            dwNegativeLevel = 0
        End If
        cboLevel1.ListIndex = dwNegativeLevel
        If (dwReadEmg = 3) Then
            dwReadEmg = 0
        End If
        cboLevel4.ListIndex = dwReadEmg
        If (dwAlarmLevel = 3) Then
            dwAlarmLevel = 0
        End If
        cboLevel3.ListIndex = dwAlarmLevel
        If (dwInposLevel = 3) Then
            dwInposLevel = 0
        End If
        cboLevel2.ListIndex = dwInposLevel
        chkHomeLevel.Value = dwHomeLevel
        chkZPhaseLevel.Value = dwZphaseLevel
    Else
        If (dwPositiveLevel = 2) Then
            dwPositiveLevel = 0
        Else
            dwPositiveLevel = 1
        End If
        cboLevel0.ListIndex = dwPositiveLevel
        If (dwNegativeLevel = 2) Then
            dwNegativeLevel = 0
        Else
            dwNegativeLevel = 1
        End If
        cboLevel1.ListIndex = dwNegativeLevel
        If (dwReadEmg = 2) Then
            dwReadEmg = 0
        Else
            dwReadEmg = 1
        End If
        cboLevel4.ListIndex = dwReadEmg
        If (dwAlarmLevel = 2) Then
            dwAlarmLevel = 0
        Else
            dwAlarmLevel = 1
        End If
        cboLevel3.ListIndex = dwAlarmLevel
        If (dwInposLevel = 2) Then
            dwInposLevel = 0
        Else
            dwInposLevel = 1
        End If
        cboLevel2.ListIndex = dwInposLevel
    End If

    AxmLinkGetMode AXIS_EVN(m_lAxis), 0, dGearRatio
    If (dGearRatio > 0) Then
        edtGearRatio.Text = Format(dGearRatio, "0.000")
        chkGearOnOff.Value = 1
    Else
        chkGearOnOff.Value = 0
    End If

    SetTitleBar m_lAxis
    
    AxmGantryGetEnable m_lAxis, dwSlhomeUse, 0, 0, 0
    
    cbGantrySlave.ListIndex = dwSlhomeUse
    
    
    If AXIS_N04(m_lAxis, 0) < m_lAxisCounts Then
        GraphX.SetLegendLabel Format(AXIS_N04(m_lAxis, 0), "00") + "Axis", 0
    Else
        GraphX.SetLegendLabel "None", 0
    End If

    If AXIS_N04(m_lAxis, 1) < m_lAxisCounts Then
        GraphX.SetLegendLabel Format(AXIS_N04(m_lAxis, 1), "00") + "Axis", 1
    Else
        GraphX.SetLegendLabel "None", 1
    End If

    If AXIS_N04(m_lAxis, 2) < m_lAxisCounts Then
        GraphY.SetLegendLabel Format(AXIS_N04(m_lAxis, 2), "00") + "Axis", 0
    Else
        GraphY.SetLegendLabel "None", 0
    End If

    If AXIS_N04(m_lAxis, 3) < m_lAxisCounts Then
        GraphY.SetLegendLabel Format(AXIS_N04(m_lAxis, 3), "00") + "Axis", 1
    Else
        GraphY.SetLegendLabel "None", 1
    End If
    
End Sub
Sub SetTitleBar(lAxis As Long)
    Dim dwModuleID As Long
    Dim lAxtBoardNo, lModulePos As Long

    If AXT_RT_SUCCESS = AxmInfoGetAxis(lAxis, lAxtBoardNo, lModulePos, dwModuleID) Then
        frmCamcQI.Caption = "Ajinextek Motion Board No[" + Format(lAxtBoardNo, "00") + "], Module Pos[" + Format(lModulePos, "00") + _
        "], Module ID[0x" + Format(Hex(dwModuleID), "00") + "]"
    Else
        frmCamcQI.Caption = "Ajinextek Motion Board is not detected"
    End If
End Sub
Private Sub Form_Unload(Cancel As Integer)
    Dim i As Integer
    For i = 0 To i < m_lAxisCounts
        AxmMoveEStop i
        AxmSignalWriteOutputBit i, 0, 0
    Next i
    
    AxlClose
    End
End Sub
' To absolute coordinate if it was checked when click the check box of absolute coordinate.
Private Sub chkAbsolute_Click()
    If (chkAbsolute.Value = 1) Then
        chkRelative.Value = 0
        AxmMotSetAbsRelMode m_lAxis, POS_ABS_MODE
    Else
        chkRelative.Value = 1
        AxmMotSetAbsRelMode m_lAxis, POS_REL_MODE
    End If
End Sub
' To opposite coordinate if it was checked when click the check box of opposite coordinate.
Private Sub chkRelative_Click()
    If (chkRelative.Value = 1) Then
        chkAbsolute.Value = 0
        AxmMotSetAbsRelMode m_lAxis, POS_REL_MODE
    Else
        chkAbsolute.Value = 1
        AxmMotSetAbsRelMode m_lAxis, POS_ABS_MODE
    End If
End Sub
Private Sub chkAsy_Click()
 If (chkAsym.Value = 1) Then
        edtDecel.Enabled = True
                
    Else
        edtDecel.Enabled = False
 End If
    
End Sub
Private Sub btnSigCapture_Click()
    Dim bySignal As Byte
    Dim dAccel As Double
    Dim dVelocity As Double
    Dim dwEdge As Long
    Dim lDirect As Integer
    Dim lSignalMethod As Long

    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    bySignal = cboDetect.ListIndex
    lDirect = cboDirection.ListIndex
    lSignalMethod = cboStopM.ListIndex

    ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    SetGraphRange m_lAxis, dVelocity

    If (bySignal < 8) Then
        dwEdge = 0
        bySignal = cboDetect.ListIndex
    Else
        dwEdge = 1
        bySignal = cboDetect.ListIndex - 8
    End If

    If (lDirect = 0) Then
        AxmMoveSignalCapture m_lAxis, dVelocity, dAccel, bySignal, dwEdge, Command, lSignalMethod
    Else
        AxmMoveSignalCapture m_lAxis, -dVelocity, dAccel, bySignal, dwEdge, Command, lSignalMethod
    End If
End Sub
Private Sub btnContiTestCircle_Click()
    Dim lAxis(0 To 1) As Long
    Dim dVelocity, dAccel, dDecel As Double
    Dim dCenPos(0 To 1), dedtTrigEndPos(0 To 1) As Double

    dVelocity = CDbl(edtVelocity)
    dAccel = CDbl(edtAccel)
    dDecel = CDbl(edtDecel)
    
    lAxis(0) = AXIS_N04(m_lAxis, 0)
    lAxis(1) = AXIS_N04(m_lAxis, 1)

    AxmContiSetAxisMap COORD_NO, 2, lAxis(0)
    AxmContiWriteClear COORD_NO
    AxmContiSetAbsRelMode COORD_NO, POS_ABS_MODE

    'AxmContiBeginNode COORD_NO

    dCenPos(0) = 500: dCenPos(1) = 500: dedtTrigEndPos(0) = 0: dedtTrigEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = -500: dCenPos(1) = 500: dedtTrigEndPos(0) = 0: dedtTrigEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = -500: dCenPos(1) = -500: dedtTrigEndPos(0) = 0: dedtTrigEndPos(1) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    dCenPos(0) = 500: dCenPos(1) = -500: dedtTrigEndPos(0) = 0: dedtTrigEndPos(0) = 0
    AxmCircleCenterMove COORD_NO, lAxis(0), dCenPos(0), dedtTrigEndPos(0), dVelocity, dAccel, dAccel, DIR_CCW

    AxmContiEndNode COORD_NO
End Sub
Private Sub btnCRCOn_Click()
    ' Level   : LOW(0), HIGH(1), UNUSED(2), USED(3)
    ' uMethod : Remove remaining pulse, possible to setup output signal pulse range of 0 - 6
    ' 0: Don't care , 1: Don't care, 2: 500 uSec, 3: 1 mSec, 4: 10 mSec, 5: 50 mSec, 6: 100 mSec
    AxmCrcSetMaskLevel m_lAxis, HIGH, 6
End Sub
Private Sub btnCRCOff_Click()
   AxmCrcSetMaskLevel m_lAxis, UNUSED, 6
End Sub
Private Sub btnMPGOn_Click()
    Dim dVelocity, dAccel As Double

    dVelocity = CDbl(edtVelocity)
    dAccel = CDbl(edtAccel)

    Dim lInputMethod  As Long
    Dim lDriveMode As Long

    Dim dMPGPosition As Double
    Dim dMPGdenominator As Double
    Dim dMPGnumerator As Double
    
    lInputMethod = 3
    lDriveMode = 0
    
    dMPGPosition = 1000
    dMPGdenominator = 4096      ' MPG(Manual Pulse Generation device Input) divide value when running (Calculated to add 1 to input value)
    dMPGnumerator = 1           ' MPG(Manual Pulse Generation device Input) multiply value when running (Calculated to add 1 to input value)
    
    ' dwNumerator   : Possible to setup maximum (1 to 64).
    ' dwDenominator : Possible to setup maximum (1 to 4096).
    AxmMPGSetEnable m_lAxis, lInputMethod, lDriveMode, dMPGPosition, dVelocity, dAccel
    AxmMPGSetRatio m_lAxis, dMPGnumerator, dMPGdenominator
End Sub
Private Sub btnMPGOff_Click()
    AxmMPGReset m_lAxis
End Sub
Private Sub btnLoad_Click()
    Dim sFileName As String
    
    CommonDialog1.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.dat||"
    CommonDialog1.FileName = "*.mot"
    CommonDialog1.FilterIndex = 2
    
    CommonDialog1.ShowOpen
    sFileName = CommonDialog1.FileName
    If sFileName <> "" Then
        If AxmMotLoadParaAll(sFileName) <> AXT_RT_SUCCESS Then
            lstLog.AddItem ("File load fail!")
            lstLog.ListIndex = lstLog.ListCount - 1
        End If
    End If

    UpdateAxisInfo
End Sub
Private Sub btnSave_Click()
    Dim sFileName As String
    
    CommonDialog1.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
    CommonDialog1.DialogTitle = "Save"
    CommonDialog1.FileName = "Default.mot"

    CommonDialog1.ShowSave
    sFileName = CommonDialog1.FileName
    If sFileName <> "" Then
        If AxmMotSaveParaAll(sFileName) <> AXT_RT_SUCCESS Then
            lstLog.AddItem ("File save fail!")
            lstLog.ListIndex = lstLog.ListCount - 1
        End If
    End If
End Sub
Private Sub btnMove_Click()
    Dim dPosition As Double
    Dim dVelocity As Double
    Dim dAccel As Double
    Dim dDecel As Double
    Dim lAxis(0 To 1) As Long
    Dim dMPos(0 To 1) As Double
    Dim dMVel(0 To 1) As Double
    Dim dMAcc(0 To 1) As Double
    Dim dMDec(0 To 1) As Double
    
    dPosition = CDbl(edtPosition.Text)
    dVelocity = CDbl(edtVelocity.Text)
    dAccel = CDbl(edtAccel.Text)
    dDecel = CDbl(edtDecel.Text)
    
    SetGraphRange m_lAxis, dVelocity
    
    If (chkXYSyn.Value = True) Then
        lAxis(0) = AXIS_ODD(m_lAxis)
        lAxis(1) = AXIS_EVN(m_lAxis)
        
        dMPos(0) = dPosition: dMPos(1) = dPosition
        dMVel(0) = dVelocity: dMVel(1) = dVelocity
        dMAcc(0) = dAccel:    dMAcc(1) = dAccel
        dMDec(0) = dDecel:    dMDec(1) = dDecel
        
        AxmMoveStartMultiPos 2, lAxis(0), dMPos(0), dMVel(0), dMAcc(0), dMDec(0), 0
    Else
        AxmMoveStartPos m_lAxis, dPosition, dVelocity, dAccel, dDecel
    End If
    
    AxmMotSetParaLoad m_lAxis, dPosition, dVelocity, dAccel, dDecel
End Sub
Private Sub btnVelOverride_Click()
    Dim dDistance As Double
    Dim dVelocity As Double
    Dim dAcceleration As Double
    Dim dDeceleration As Double
        
    dDistance = CDbl(edtPosition.Text)
    dVelocity = CDbl(edtVelocity.Text)
    dAcceleration = CDbl(edtAccel.Text)
    dDeceleration = CDbl(edtDecel.Text)
      
    ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
    If ((m_lAxis Mod 2) = 0) Then
        GraphX.MaxRange = dVelocity * 2 '+ (dVelocity * 2 * 0.2)
    Else
        GraphY.MaxRange = dVelocity * 2 '+ (dVelocity * 2 * 0.2)
    End If
    
    AxmOverrideVelAtPos m_lAxis, dDistance, dVelocity, dAcceleration, dAcceleration, dVelocity * 2, dDistance / 2, 0
End Sub
Private Sub cboPulseOutM_Click()
    AxmMotSetPulseOutMethod m_lAxis, cboPulseOutM.ListIndex
End Sub
Private Sub cboEncInputM_Click()
     AxmMotSetEncInputMethod m_lAxis, cboEncInputM.ListIndex
End Sub
Private Sub btnHomeAll_Click()
    Dim lHmDir As Long
    Dim lHmsig As Long
    Dim dwZphas As Long
    Dim dHClrTim As Double
    Dim dHOffset As Double
    Dim dwResult As Long

    lHmsig = cboHomeSignal.ListIndex    ' Setup a direction of Home searching.
    lHmDir = cboHomeDir.ListIndex       ' Setup Home sensor.
    dwZphas = 0                         ' Setup whether Z phase is searching or not.
    dHClrTim = 1000#                    ' Delay time of Position Clear after searching Home sensor.
    dHOffset = 0#                       ' Setup Offset movement value after searching Home sensor.
    
    If lHmsig > 1 Then
        lHmsig = lHmsig + 2
    End If
    
    SetGraphRange AXIS_N04(m_lAxis, 0), 100
    SetGraphRange AXIS_N04(m_lAxis, 2), 100
    
    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 0), 100, 50, 5, 1, 400, 100)
    If (dwResult = AXT_RT_SUCCESS) Then
        AxmHomeSetMethod AXIS_N04(m_lAxis, 0), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetStart AXIS_N04(m_lAxis, 0)
        tmHome.Item(0).Enabled = True
    End If
    
    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 1), 100, 50, 5, 1, 400, 100)
    If (dwResult = AXT_RT_SUCCESS) Then
        AxmHomeSetMethod AXIS_N04(m_lAxis, 1), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetStart AXIS_N04(m_lAxis, 1)
        tmHome.Item(1).Enabled = True
    End If
    
    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 2), 100, 50, 5, 1, 400, 100)
    If (dwResult = AXT_RT_SUCCESS) Then
        AxmHomeSetMethod AXIS_N04(m_lAxis, 2), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetStart AXIS_N04(m_lAxis, 2)
        tmHome.Item(2).Enabled = True
    End If
    
    dwResult = AxmHomeSetVel(AXIS_N04(m_lAxis, 3), 100, 50, 5, 1, 400, 100)
    If (dwResult = AXT_RT_SUCCESS) Then
        AxmHomeSetMethod AXIS_N04(m_lAxis, 3), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetStart AXIS_N04(m_lAxis, 3)
        tmHome.Item(3).Enabled = True
    End If
End Sub
Private Sub btnHomeSingle_Click()
    Dim dwZphas As Long
    Dim dHClrTim As Double
    Dim dHOffset As Double
    
    Dim dVelFirst As Double
    Dim dVelSecond As Double
    Dim dVelThird As Double
    Dim dVelLast As Double
    
    Dim lHmsig As Long
    Dim lHmDir As Long
    
    dVelFirst = CDbl(edtHomeVelFirst.Text)
    dVelSecond = CDbl(edtHomeVelSecond.Text)
    dVelThird = CDbl(edtHomeVelThird.Text)
    dVelLast = CDbl(edtHomeVelLast.Text)
    
    dwZphas = 0                         ' Setup whether Z phase is searching or not.
    dHClrTim = 1000#                    ' Delay time of Position Clear after searching Home sensor.
    dHOffset = 0#                       ' Setup Offset movement value after searching Home sensor.
    lHmsig = cboHomeSignal.ListIndex    ' Setup Home sensor.
    lHmDir = cboHomeDir.ListIndex       ' Setup a direction of Home searching.
    
    If lHmsig > 1 Then
        lHmsig = lHmsig + 2
    End If
    
    SetGraphRange m_lAxis, dVelFirst
    
    If cbGantrySlave.ListIndex Then
        AxmHomeSetVel AXIS_EVN(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10
        AxmHomeSetVel AXIS_ODD(m_lAxis), dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10

        AxmHomeSetMethod AXIS_EVN(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetMethod AXIS_ODD(m_lAxis), lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset

        AxmHomeSetStart AXIS_EVN(m_lAxis)
        tmHome.Item(AXIS_EVN(m_lAxis)).Enabled = True
    Else
        AxmHomeSetVel m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dVelFirst * 4, dVelSecond * 10

        AxmHomeSetMethod m_lAxis, lHmDir, lHmsig, dwZphas, dHClrTim, dHOffset
        AxmHomeSetStart m_lAxis
        tmHome.Item(AXIS_QUR(m_lAxis)).Enabled = True
    End If
End Sub
' It is for the test of Home searching, about setup signal to be searched and searching direction and stop method after searching
' Start searching after read.  Print out the result on list box after finishing search.
Private Sub btnSearch_Click()
    Dim lAxis As Long
    
    lAxis = AXIS_QUR(m_lAxis)
    If (tmTest(lAxis).Enabled = False) Then
        g_Search(lAxis).nAxis = m_lAxis
        g_Search(lAxis).nDir = cboDirection.ListIndex
        g_Search(lAxis).nSignal = cboDetect.ListIndex
        g_Search(lAxis).nStopM = cboStopM.ListIndex
        g_Search(lAxis).dVelocity = CDbl(edtVelocity.Text)
        g_Search(lAxis).dAccel = CDbl(edtAccel.Text)
        g_Search(lAxis).nRun = 1
        g_Search(lAxis).SearchSignal
        g_nTest = 1
    Else
        lstLog.AddItem ("Now moving.")
        lstLog.ListIndex = lstLog.ListCount - 1
    End If
End Sub
' Repeated running after reading running parameter from edit box.
' Create thread for repeated running.
Private Sub btnRepeat_Click()
    Dim lAxis As Long
    
    lAxis = AXIS_QUR(m_lAxis)
    If (tmTest(lAxis).Enabled = False) Then
        g_Repeat(lAxis).nAxis = m_lAxis
        g_Repeat(lAxis).dPosition = CDbl(edtPosition.Text)
        g_Repeat(lAxis).dVelocity = CDbl(edtVelocity.Text)
        g_Repeat(lAxis).dAccel = CDbl(edtAccel.Text)
        g_Repeat(lAxis).dDecel = CDbl(edtDecel.Text)
        g_Repeat(lAxis).nRun = 1
        g_nTest = 0
        g_Repeat(lAxis).StartRepeat
    Else
        lstLog.AddItem ("Now moving.")
        lstLog.ListIndex = lstLog.ListCount - 1
    End If
End Sub
' Setup distance rate and initial speed by pulse among those initial parameter.
' Change maximum speed to fit if setup distance rate by pulse.
Private Sub btnSetting_Click()
    Dim lPulse As Long
    Dim dMoveUnit, dStartStop As Double
    Dim dUnit, dMinVelocity As Double
        
    lPulse = CDbl(edtPulse.Text)
    dMoveUnit = CDbl(edtUnit.Text)
    dStartStop = CDbl(edtStartSpeed.Text)
    
    AxmMotSetMoveUnitPerPulse m_lAxis, dMoveUnit, lPulse
    AxmMotSetMinVel m_lAxis, dStartStop
    AxmMotGetMoveUnitPerPulse m_lAxis, dUnit, lPulse
    AxmMotGetMinVel m_lAxis, dMinVelocity
    
    edtMoveUnit.Text = Format(dUnit / lPulse, "0.000000")
    edtUnit.Text = Format(dUnit, "0.000")
    edtPulse.Text = Format(lPulse)
    edtStartSpeed.Text = Format(dMinVelocity, "0.0000")
End Sub
Private Sub btnTrigOneShot_Click()
    Dim pulse_width As Long
    pulse_width = CLng(edtTrigPulseWidth.Text)
    
    ' It is the function that user outputting one trigger pulse by force.
    Call AxmTriggerSetTimeLevel(m_lAxis, pulse_width, HIGH, Command, ENABLE)
    Call AxmTriggerOneShot(m_lAxis)
End Sub
Private Sub btnTrigAbs_Click()
    Dim uErrorCode As Long
    Dim trig_pos(0 To 1) As Double
    Dim pulse_width As Integer
        
    trig_pos(0) = CDbl(edtTrigStartPosition.Text)
    pulse_width = CDbl(edtTrigPulseWidth.Text)
    
    AxmTriggerSetReset m_lAxis
    AxmTriggerSetTimeLevel m_lAxis, pulse_width, HIGH, Command, ENABLE
    
    uErrorCode = AxmTriggerOnlyAbs(m_lAxis, 1, trig_pos(0))
    If (uErrorCode = AXT_RT_SUCCESS) Then
        lstLog.AddItem "Trigger absolute position set"
    Else
        lstLog.AddItem "Trigger absolute position not set"
    End If
End Sub
Private Sub btnTrigPeriod_Click()
    Dim uErrorCode As Double
    Dim start_pos As Double
    Dim cycle As Double
    Dim end_pos As Double
    Dim pulse_width As Integer
    
    start_pos = CDbl(edtTrigStartPosition.Text)
    cycle = CDbl(edtTrigCycle.Text)
    end_pos = CDbl(edtTrigEndPos.Text)
    pulse_width = CDbl(edtTrigPulseWidth.Text)

    AxmTriggerSetReset m_lAxis
    AxmTriggerSetTimeLevel m_lAxis, pulse_width, HIGH, Command, ENABLE

    uErrorCode = AxmTriggerSetBlock(m_lAxis, start_pos, end_pos, cycle)
    
    If (uErrorCode = AXT_RT_SUCCESS) Then
        lstLog.AddItem "Trigger cycle position set"
    Else
        lstLog.AddItem "Trigger cycle position not set"
    End If
End Sub
Private Sub btnTrigReset_Click()
    AxmTriggerSetReset m_lAxis
End Sub
Private Sub btnIntDisable_Click()
    g_nIntCnt = 0                                      ' Interrupt count clear
    AxlInterruptDisable
    AxmInterruptSetAxis m_lAxis, hWnd, 0, 0, 0         ' Cancel interrupt method
    AxmInterruptSetAxisEnable m_lAxis, 0 '             ' Interrupt DISABLE
End Sub
Private Sub btnIntMessage_Click()
    Dim dwInterruptNum As Long

    g_nIntCnt = 0
    
    AxlInterruptEnable
    AxmInterruptSetAxisEnable m_lAxis, ENABLE

    ' Setup whether interrupt is generated which user of the designated axis set.
    ' lBank : Possible to setup interrupt bank number (0 - 1).
    ' lInterruptNum : Setup interrupt
    AxmInterruptSetUserEnable m_lAxis, 1, QIINTBANK2_29           ' Input signal of limit signal (PELM, NELM).
    AxtMsg.Message1 = WM_AXL_INTERRUPT
    AxmInterruptSetAxis m_lAxis, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0

    AxmInterruptGetUserEnable m_lAxis, 1, dwInterruptNum
    lstLog.AddItem "Limit Int Enable[1][0x" + Format(Hex(dwInterruptNum), "00000000") + "]"
End Sub
Private Sub cboAxisSet_Click()
    m_lAxis = cboAxisSet.ListIndex
    UpdateAxisInfo
End Sub

' Setup general output #0(Servo-On).  Output will go out if checked, Output will not go out if not checked.
Private Sub LedOut0_Click()
    Dim dwOnOff As Long
    
    AxmSignalIsServoOn m_lAxis, dwOnOff
    If (dwOnOff) Then
        AxmSignalServoOn m_lAxis, 0
    Else
        AxmSignalServoOn m_lAxis, 1
    End If
End Sub
' Setup general output #1(Alarm-Clear).
Private Sub LedOut1_Click()
    Dim dwOutBit As Long
    
    AxmSignalReadOutputBit m_lAxis, 1, dwOutBit
    If (dwOutBit) Then
        AxmSignalServoAlarmReset m_lAxis, 0
    Else
        AxmSignalServoAlarmReset m_lAxis, 1
    End If
End Sub
' Setup general output #2.
Private Sub LedOut2_Click()
    Dim dwOutBit As Long
  
    AxmSignalReadOutputBit m_lAxis, 2, dwOutBit
    If (dwOutBit) Then
        AxmSignalWriteOutputBit m_lAxis, 2, 0
    Else
        AxmSignalWriteOutputBit m_lAxis, 2, 1
    End If
End Sub
' Setup general output #3.
Private Sub LedOut3_Click()
    Dim dwOutBit As Long
  
    AxmSignalReadOutputBit m_lAxis, 3, dwOutBit
    If (dwOutBit) Then
            AxmSignalWriteOutputBit m_lAxis, 3, 0
    Else
            AxmSignalWriteOutputBit m_lAxis, 3, 1
    End If
End Sub
' Setup general output #4.
Private Sub LedOut4_Click()
     Dim dwOutBit As Long
  
    AxmSignalReadOutputBit m_lAxis, 4, dwOutBit
    If (dwOutBit) Then
            AxmSignalWriteOutputBit m_lAxis, 4, 0
    Else
            AxmSignalWriteOutputBit m_lAxis, 4, 1
    End If
End Sub
' Setup general output #5.
Private Sub LedOut5_Click()
    Dim dwOutBit As Long
  
    AxmSignalReadOutputBit m_lAxis, 5, dwOutBit
    If (dwOutBit) Then
            AxmSignalWriteOutputBit m_lAxis, 5, 0
    Else
            AxmSignalWriteOutputBit m_lAxis, 5, 1
    End If
End Sub
Private Sub lstLog_DblClick()
    lstLog.Clear
End Sub

Private Sub sldXYRange_Scroll(Index As Integer)
    Dim nTicPos, nTicPos2 As Integer
    Dim dUnit As Double
    Dim lPulse As Long

    'nTicPos = sldXYRange(0).Value
    'nTicPos2 = sldXYRange(1).Value

    AxmMotGetMoveUnitPerPulse m_lAxis, dUnit, lPulse
    m_lRange = (nTicPos * 5) * (10 ^ nTicPos2) * (dUnit / lPulse)
    XYPlot.SetRange -m_lRange, m_lRange, -m_lRange, m_lRange
End Sub

Private Sub tmDisplay_Timer()
    Dim dCmdPos(0 To 3) As Double
    Dim dActPos(0 To 3) As Double
    Dim wReadInput, wReadOuput, wMechanicalStatus As Long
    Dim wReadInterpolationQueueFree, wIsContMotion, wBusyStatus As Long

    Dim wReadHome As Long
    Dim lNodeNum1, lTotalNodeNum1 As Long


    AxmStatusGetCmdPos AXIS_N04(m_lAxis, 0), dCmdPos(0)
    AxmStatusGetActPos AXIS_N04(m_lAxis, 0), dActPos(0)
    
    AxmStatusGetCmdPos AXIS_N04(m_lAxis, 1), dCmdPos(1)
    AxmStatusGetActPos AXIS_N04(m_lAxis, 1), dActPos(1)
    
    AxmStatusGetCmdPos AXIS_N04(m_lAxis, 2), dCmdPos(2)
    AxmStatusGetActPos AXIS_N04(m_lAxis, 2), dActPos(2)
    
    AxmStatusGetCmdPos AXIS_N04(m_lAxis, 3), dCmdPos(3)
    AxmStatusGetActPos AXIS_N04(m_lAxis, 3), dActPos(3)
    
    edtCmdPosX.Text = Format(dCmdPos(0), "0.000")
    edtCmdPosY.Text = Format(dCmdPos(1), "0.000")
    
    edtActPosX.Text = Format(dActPos(0), "0.000")
    edtActPosY.Text = Format(dActPos(1), "0.000")
    
    edtCmdPosZ.Text = Format(dCmdPos(2), "0.000")
    edtCmdPosU.Text = Format(dCmdPos(3), "0.000")
    
    edtActPosZ.Text = Format(dActPos(2), "0.000")
    edtActPosU.Text = Format(dActPos(3), "0.000")
    
    AxmSignalReadInput m_lAxis, wReadInput
    AxmSignalReadOutput m_lAxis, wReadOuput
    AxmStatusReadMechanical m_lAxis, wMechanicalStatus
    
    ' General output
    LedOut0.BackColor = LED_RED((wReadOuput And &H1) = &H1)
    LedOut1.BackColor = LED_RED((wReadOuput And &H2) = &H2)
    LedOut2.BackColor = LED_RED((wReadOuput And &H4) = &H4)
    LedOut3.BackColor = LED_RED((wReadOuput And &H8) = &H8)
    LedOut4.BackColor = LED_RED((wReadOuput And &H10) = &H10)
   ' LedOut5.BackColor = LED_RED((wReadOuput And &H20) = &H20)

    AxmHomeReadSignal m_lAxis, wReadHome
    LedHome.BackColor = LED_RED(wReadHome = 1)
    
    ' General input
    'LedIn0.BackColor = LED_RED((wReadInput And &H1) = &H1)
    LedIn0.BackColor = LED_RED(wReadHome = 1)
    LedIn1.BackColor = LED_RED((wReadInput And &H2) = &H2)
    LedIn2.BackColor = LED_RED((wReadInput And &H4) = &H4)
    LedIn3.BackColor = LED_RED((wReadInput And &H8) = &H8)
    LedIn4.BackColor = LED_RED((wReadInput And &H10) = &H10)
   ' LedIn5.BackColor = LED_RED((wReadInput And &H20) = &H20)

    ' Hardware signal
    LedPElm.BackColor = LED_RED((wMechanicalStatus And &H1) = &H1)
    LedNElm.BackColor = LED_RED((wMechanicalStatus And &H2) = &H2)
    LedAlarm.BackColor = LED_RED((wMechanicalStatus And &H10) = &H10)
    LedInp.BackColor = LED_RED((wMechanicalStatus And &H20) = &H20)
    LedEmg.BackColor = LED_RED((wMechanicalStatus And &H40) = &H40)
    LedZPhase.BackColor = LED_RED((wMechanicalStatus And &H100) = &H100)
    LedEXPP.BackColor = LED_RED((wMechanicalStatus And &H400) = &H400)
    LedEXMP.BackColor = LED_RED((wMechanicalStatus And &H800) = &H800)

    AxmStatusReadInMotion AXIS_EVN(m_lAxis), wBusyStatus
    LedBusyx.BackColor = LED_YELLOW(wBusyStatus = 1)
    
    AxmStatusReadInMotion AXIS_ODD(m_lAxis), wBusyStatus
    LedBusyy.BackColor = LED_YELLOW(wBusyStatus = 1)
    
    AxmContiReadFree COORD_NO, wReadInterpolationQueueFree
    ' A function which checks running of serial interpolation
    AxmContiIsMotion COORD_NO, wIsContMotion
    ' A function which reads current index value in interpolation queue
    AxmContiGetNodeNum COORD_NO, lNodeNum1
    AxmContiGetTotalNodeNum COORD_NO, lTotalNodeNum1

    edtTotalNum.Caption = Format(lTotalNodeNum1)
    edtContiNum.Caption = Format(lNodeNum1)
    edtInMotion.Caption = Format(wIsContMotion)
    edtQFree.Caption = Format(wReadInterpolationQueueFree)
    edtIntCount.Caption = Format(g_nIntCnt)
End Sub
Private Sub tmGraph_Timer()
    Dim dX1, dY1 As Double
    Dim dCurVelX(1), dCurVelY(1) As Double
    
    AxmStatusGetCmdPos AXIS_EVN(m_lAxis), dX1
    AxmStatusGetCmdPos AXIS_ODD(m_lAxis), dY1
    
    AxmStatusReadVel AXIS_N04(m_lAxis, 0), dCurVelX(0)
    AxmStatusReadVel AXIS_N04(m_lAxis, 1), dCurVelX(1)
    AxmStatusReadVel AXIS_N04(m_lAxis, 2), dCurVelY(0)
    AxmStatusReadVel AXIS_N04(m_lAxis, 3), dCurVelY(1)
    
    edtCmdVelX = Format(dCurVelX(0), "0.000")
    edtCmdVelY = Format(dCurVelX(1), "0.000")
    edtCmdVelZ = Format(dCurVelY(0), "0.000")
    edtCmdVelU = Format(dCurVelY(1), "0.000")
    
    XYPlot.AppendPoint dX1, dY1
    
    If (dCurVelX(0) > 0 Or dCurVelX(1) > 0) Then
        GraphX.AppendPoints dCurVelX(0), dCurVelX(1)
    End If
        
    If (dCurVelY(0) > 0 Or dCurVelY(1) > 0) Then
        GraphY.AppendPoints dCurVelY(0), dCurVelY(1)
    End If
    
End Sub
Private Sub tmHome_Timer(Index As Integer)
    
    Dim nTimeNo As Integer
    Dim wHomeResult As Long
    
    nTimeNo = Index
    AxmHomeGetResult AXIS_N04(m_lAxis, CLng(nTimeNo)), wHomeResult
    If (wHomeResult <> HOME_SEARCHING) Then
        tmHome.Item(nTimeNo).Enabled = False
        If (wHomeResult = HOME_SUCCESS) Then
            MsgBox ("Home Search " + Format(nTimeNo + 1) + " Success")
        Else
            MsgBox ("Home Search " + Format(nTimeNo + 1) + "Fail[0x" + Format(Hex(wHomeResult)) + "]")
        End If
    End If
End Sub
Public Sub SetGraphRange(lAxis As Long, dVelocity As Double)
    If (dVelocity > 0) Then
        ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
        If (AXIS_QUR(lAxis) < 2) Then
            GraphX.SetRanges 0, dVelocity + (dVelocity * 0.2)
        Else
            GraphY.SetRanges 0, dVelocity + (dVelocity * 0.2)
        End If
    End If
End Sub
Private Sub tmTest_Timer(Index As Integer)
    If g_nTest = 0 Then
        g_Repeat(Index).StartRepeatLoop
    ElseIf g_nTest = 1 Then
        g_Search(Index).SearchSignalLoop
    End If
End Sub
