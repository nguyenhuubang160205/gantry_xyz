VERSION 5.00
Begin VB.Form frmStatus 
   BorderStyle     =   1  '단일 고정
   Caption         =   "Status View(END ,DRV)"
   ClientHeight    =   9570
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7065
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   9570
   ScaleWidth      =   7065
   StartUpPosition =   3  'Windows 기본값
   Begin VB.Timer tmStatusView 
      Interval        =   100
      Left            =   3240
      Top             =   120
   End
   Begin VB.CommandButton btnCur 
      Caption         =   "Ⅱ"
      Height          =   220
      Left            =   6165
      TabIndex        =   126
      Top             =   120
      Width           =   255
   End
   Begin VB.CommandButton btnNext 
      Caption         =   ">>"
      Height          =   220
      Left            =   6435
      TabIndex        =   125
      Top             =   120
      Width           =   400
   End
   Begin VB.CommandButton btnPrev 
      Caption         =   "<<"
      Height          =   220
      Left            =   5740
      TabIndex        =   124
      Top             =   120
      Width           =   400
   End
   Begin VB.Frame frmAxisY 
      Caption         =   "Y Axis: 00"
      Height          =   9200
      Left            =   3600
      TabIndex        =   62
      Top             =   240
      Width           =   3250
      Begin VB.Frame Frame1 
         Caption         =   "Drive Status"
         Height          =   3195
         Left            =   0
         TabIndex        =   103
         Top             =   6000
         Width           =   3075
         Begin VB.PictureBox LedYDRS09 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   113
            Top             =   520
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS10 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   112
            Top             =   240
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS07 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   111
            Top             =   800
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS06 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   110
            Top             =   1080
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS05 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   109
            Top             =   1360
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS04 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   108
            Top             =   1640
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS03 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   107
            Top             =   1920
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS02 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   106
            Top             =   2200
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS01 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   105
            Top             =   2500
            Width           =   290
         End
         Begin VB.PictureBox LedYDRS00 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   104
            Top             =   2780
            Width           =   290
         End
         Begin VB.Label Label69 
            Caption         =   "9bit : INP BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   123
            Top             =   520
            Width           =   2500
         End
         Begin VB.Label Label70 
            Caption         =   "10bit : SLAVE BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   122
            Top             =   240
            Width           =   2500
         End
         Begin VB.Label Label67 
            Caption         =   "7bit : ORG BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   121
            Top             =   800
            Width           =   2500
         End
         Begin VB.Label Label66 
            Caption         =   "6bit : MPG BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   120
            Top             =   1080
            Width           =   2500
         End
         Begin VB.Label Label65 
            Caption         =   "5bit : PRESET BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   119
            Top             =   1360
            Width           =   2500
         End
         Begin VB.Label Label64 
            Caption         =   "4bit : CONTI BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   118
            Top             =   1640
            Width           =   2500
         End
         Begin VB.Label Label63 
            Caption         =   "3bit : UP"
            Height          =   270
            Left            =   480
            TabIndex        =   117
            Top             =   1920
            Width           =   2500
         End
         Begin VB.Label Label62 
            Caption         =   "2bit : CONST"
            Height          =   270
            Left            =   480
            TabIndex        =   116
            Top             =   2200
            Width           =   2500
         End
         Begin VB.Label Label61 
            Caption         =   "1bit : DOWN"
            Height          =   270
            Left            =   480
            TabIndex        =   115
            Top             =   2500
            Width           =   2500
         End
         Begin VB.Label Label60 
            Caption         =   "0bit : BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   114
            Top             =   2780
            Width           =   2500
         End
      End
      Begin VB.Frame Frame2 
         Caption         =   "End Status"
         Height          =   5625
         Left            =   0
         TabIndex        =   63
         Top             =   240
         Width           =   3070
         Begin VB.PictureBox LedYENS16 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   82
            Top             =   800
            Width           =   290
         End
         Begin VB.PictureBox LedYENS30 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   81
            Top             =   520
            Width           =   290
         End
         Begin VB.PictureBox LedYENS31 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   80
            Top             =   240
            Width           =   290
         End
         Begin VB.PictureBox LedYENS08 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   79
            Top             =   3060
            Width           =   290
         End
         Begin VB.PictureBox LedYENS09 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   78
            Top             =   2780
            Width           =   290
         End
         Begin VB.PictureBox LedYENS10 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   77
            Top             =   2500
            Width           =   290
         End
         Begin VB.PictureBox LedYENS11 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   76
            Top             =   2200
            Width           =   290
         End
         Begin VB.PictureBox LedYENS12 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   75
            Top             =   1920
            Width           =   290
         End
         Begin VB.PictureBox LedYENS13 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   74
            Top             =   1640
            Width           =   290
         End
         Begin VB.PictureBox LedYENS14 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   73
            Top             =   1360
            Width           =   290
         End
         Begin VB.PictureBox LedYENS15 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   72
            Top             =   1080
            Width           =   290
         End
         Begin VB.PictureBox LedYENS07 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   71
            Top             =   3340
            Width           =   290
         End
         Begin VB.PictureBox LedYENS06 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   70
            Top             =   3620
            Width           =   290
         End
         Begin VB.PictureBox LedYENS05 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   69
            Top             =   3900
            Width           =   290
         End
         Begin VB.PictureBox LedYENS04 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   68
            Top             =   4180
            Width           =   290
         End
         Begin VB.PictureBox LedYENS03 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   67
            Top             =   4460
            Width           =   290
         End
         Begin VB.PictureBox LedYENS02 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   66
            Top             =   4740
            Width           =   290
         End
         Begin VB.PictureBox LedYENS01 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   65
            Top             =   5020
            Width           =   290
         End
         Begin VB.PictureBox LedYENS00 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   64
            Top             =   5300
            Width           =   290
         End
         Begin VB.Label Label58 
            Caption         =   "16bit : MPGERR stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   102
            Top             =   800
            Width           =   2500
         End
         Begin VB.Label Label57 
            Caption         =   "30bit : ERRSTATE"
            Height          =   270
            Left            =   480
            TabIndex        =   101
            Top             =   520
            Width           =   2500
         End
         Begin VB.Label Label56 
            Caption         =   "31bit : INPERR"
            Height          =   270
            Left            =   480
            TabIndex        =   100
            Top             =   240
            Width           =   2500
         End
         Begin VB.Label Label55 
            Caption         =   "8bit : SVALARM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   99
            Top             =   3060
            Width           =   2500
         End
         Begin VB.Label Label54 
            Caption         =   "9bit : ESTOP stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   98
            Top             =   2780
            Width           =   2500
         End
         Begin VB.Label Label53 
            Caption         =   "10bit : ESTOPCMD stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   97
            Top             =   2500
            Width           =   2500
         End
         Begin VB.Label Label52 
            Caption         =   "11bit : SSTOPCMD stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   96
            Top             =   2200
            Width           =   2500
         End
         Begin VB.Label Label51 
            Caption         =   "12bit : ESTOPALL stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   95
            Top             =   1920
            Width           =   2500
         End
         Begin VB.Label Label50 
            Caption         =   "13bit : SQSTP#1 stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   94
            Top             =   1640
            Width           =   2500
         End
         Begin VB.Label Label49 
            Caption         =   "14bit : SQSTP#2 stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   93
            Top             =   1360
            Width           =   2500
         End
         Begin VB.Label Label48 
            Caption         =   "15bit : ENCERR"
            Height          =   270
            Left            =   480
            TabIndex        =   92
            Top             =   1080
            Width           =   2500
         End
         Begin VB.Label lblAxis 
            Alignment       =   1  '오른쪽 맞춤
            AutoSize        =   -1  'True
            Caption         =   "Label33"
            Height          =   180
            Index           =   1
            Left            =   4680
            TabIndex        =   91
            Top             =   0
            Width           =   645
         End
         Begin VB.Label Label47 
            Caption         =   "7bit : NSWSLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   90
            Top             =   3340
            Width           =   2500
         End
         Begin VB.Label Label46 
            Caption         =   "6bit : PSWSLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   89
            Top             =   3620
            Width           =   2500
         End
         Begin VB.Label Label45 
            Caption         =   "5bit : NSWLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   88
            Top             =   3900
            Width           =   2500
         End
         Begin VB.Label Label44 
            Caption         =   "4bit : PSWLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   87
            Top             =   4180
            Width           =   2500
         End
         Begin VB.Label Label43 
            Caption         =   "3bit : NSLM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   86
            Top             =   4460
            Width           =   2500
         End
         Begin VB.Label Label42 
            Caption         =   "2bit : PSLM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   85
            Top             =   4740
            Width           =   2500
         End
         Begin VB.Label Label41 
            Caption         =   "1bit : NELM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   84
            Top             =   5020
            Width           =   2500
         End
         Begin VB.Label Label40 
            Caption         =   "0bit : PELM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   83
            Top             =   5300
            Width           =   2500
         End
      End
   End
   Begin VB.Frame frmAxisX 
      Caption         =   "X Axis: 00"
      Height          =   9200
      Left            =   180
      TabIndex        =   0
      Top             =   240
      Width           =   3250
      Begin VB.Frame Frame6 
         Caption         =   "Drive Status"
         Height          =   3195
         Left            =   0
         TabIndex        =   41
         Top             =   6000
         Width           =   3075
         Begin VB.PictureBox LedXDRS00 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   51
            Top             =   2780
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS01 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   50
            Top             =   2500
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS02 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   49
            Top             =   2200
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS03 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   48
            Top             =   1920
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS04 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   47
            Top             =   1640
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS05 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   46
            Top             =   1360
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS06 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   45
            Top             =   1080
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS07 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   44
            Top             =   800
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS10 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   43
            Top             =   240
            Width           =   290
         End
         Begin VB.PictureBox LedXDRS09 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   42
            Top             =   520
            Width           =   290
         End
         Begin VB.Label Label25 
            Caption         =   "0bit : BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   61
            Top             =   2780
            Width           =   2500
         End
         Begin VB.Label Label24 
            Caption         =   "1bit : DOWN"
            Height          =   270
            Left            =   480
            TabIndex        =   60
            Top             =   2500
            Width           =   2500
         End
         Begin VB.Label Label23 
            Caption         =   "2bit : CONST"
            Height          =   270
            Left            =   480
            TabIndex        =   59
            Top             =   2200
            Width           =   2500
         End
         Begin VB.Label Label22 
            Caption         =   "3bit : UP"
            Height          =   270
            Left            =   480
            TabIndex        =   58
            Top             =   1920
            Width           =   2500
         End
         Begin VB.Label Label21 
            Caption         =   "4bit : CONTI BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   57
            Top             =   1640
            Width           =   2500
         End
         Begin VB.Label Label20 
            Caption         =   "5bit : PRESET BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   56
            Top             =   1360
            Width           =   2500
         End
         Begin VB.Label Label1 
            Caption         =   "6bit : MPG BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   55
            Top             =   1080
            Width           =   2500
         End
         Begin VB.Label Label2 
            Caption         =   "7bit : ORG BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   54
            Top             =   800
            Width           =   2500
         End
         Begin VB.Label Label33 
            Caption         =   "10bit : SLAVE BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   53
            Top             =   240
            Width           =   2500
         End
         Begin VB.Label Label34 
            Caption         =   "9bit : INP BUSY"
            Height          =   270
            Left            =   480
            TabIndex        =   52
            Top             =   520
            Width           =   2500
         End
      End
      Begin VB.Frame Frame3 
         Caption         =   "End Status"
         Height          =   5625
         Left            =   0
         TabIndex        =   1
         Top             =   240
         Width           =   3070
         Begin VB.PictureBox LedXENS00 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   20
            Top             =   5300
            Width           =   290
         End
         Begin VB.PictureBox LedXENS01 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   19
            Top             =   5020
            Width           =   290
         End
         Begin VB.PictureBox LedXENS02 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   18
            Top             =   4740
            Width           =   290
         End
         Begin VB.PictureBox LedXENS03 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   17
            Top             =   4460
            Width           =   290
         End
         Begin VB.PictureBox LedXENS04 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   16
            Top             =   4180
            Width           =   290
         End
         Begin VB.PictureBox LedXENS05 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   15
            Top             =   3900
            Width           =   290
         End
         Begin VB.PictureBox LedXENS06 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   14
            Top             =   3620
            Width           =   290
         End
         Begin VB.PictureBox LedXENS07 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   13
            Top             =   3340
            Width           =   290
         End
         Begin VB.PictureBox LedXENS15 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   12
            Top             =   1080
            Width           =   290
         End
         Begin VB.PictureBox LedXENS14 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   11
            Top             =   1360
            Width           =   290
         End
         Begin VB.PictureBox LedXENS13 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   10
            Top             =   1640
            Width           =   290
         End
         Begin VB.PictureBox LedXENS12 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   9
            Top             =   1920
            Width           =   290
         End
         Begin VB.PictureBox LedXENS11 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   8
            Top             =   2200
            Width           =   290
         End
         Begin VB.PictureBox LedXENS10 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   7
            Top             =   2500
            Width           =   290
         End
         Begin VB.PictureBox LedXENS09 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   6
            Top             =   2780
            Width           =   290
         End
         Begin VB.PictureBox LedXENS08 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   5
            Top             =   3060
            Width           =   290
         End
         Begin VB.PictureBox LedXENS31 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   4
            Top             =   240
            Width           =   290
         End
         Begin VB.PictureBox LedXENS30 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   3
            Top             =   520
            Width           =   290
         End
         Begin VB.PictureBox LedXENS16 
            BackColor       =   &H00000080&
            Height          =   270
            Left            =   120
            ScaleHeight     =   210
            ScaleWidth      =   225
            TabIndex        =   2
            Top             =   800
            Width           =   290
         End
         Begin VB.Label Label19 
            Caption         =   "0bit : PELM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   40
            Top             =   5300
            Width           =   2500
         End
         Begin VB.Label Label26 
            Caption         =   "1bit : NELM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   39
            Top             =   5020
            Width           =   2500
         End
         Begin VB.Label Label27 
            Caption         =   "2bit : PSLM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   38
            Top             =   4740
            Width           =   2500
         End
         Begin VB.Label Label28 
            Caption         =   "3bit : NSLM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   37
            Top             =   4460
            Width           =   2500
         End
         Begin VB.Label Label29 
            Caption         =   "4bit : PSWLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   36
            Top             =   4180
            Width           =   2500
         End
         Begin VB.Label Label30 
            Caption         =   "5bit : NSWLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   35
            Top             =   3900
            Width           =   2500
         End
         Begin VB.Label Label31 
            Caption         =   "6bit : PSWSLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   34
            Top             =   3620
            Width           =   2500
         End
         Begin VB.Label Label32 
            Caption         =   "7bit : NSWSLMT stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   33
            Top             =   3340
            Width           =   2500
         End
         Begin VB.Label lblAxis 
            Alignment       =   1  '오른쪽 맞춤
            AutoSize        =   -1  'True
            Caption         =   "Label33"
            Height          =   180
            Index           =   0
            Left            =   4680
            TabIndex        =   32
            Top             =   0
            Width           =   645
         End
         Begin VB.Label Label11 
            Caption         =   "15bit : ENCERR"
            Height          =   270
            Left            =   480
            TabIndex        =   31
            Top             =   1080
            Width           =   2500
         End
         Begin VB.Label Label12 
            Caption         =   "14bit : SQSTP#2 stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   30
            Top             =   1360
            Width           =   2500
         End
         Begin VB.Label Label13 
            Caption         =   "13bit : SQSTP#1 stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   29
            Top             =   1640
            Width           =   2500
         End
         Begin VB.Label Label14 
            Caption         =   "12bit : ESTOPALL stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   28
            Top             =   1920
            Width           =   2500
         End
         Begin VB.Label Label15 
            Caption         =   "11bit : SSTOPCMD stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   27
            Top             =   2200
            Width           =   2500
         End
         Begin VB.Label Label16 
            Caption         =   "10bit : ESTOPCMD stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   26
            Top             =   2500
            Width           =   2500
         End
         Begin VB.Label Label17 
            Caption         =   "9bit : ESTOP stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   25
            Top             =   2780
            Width           =   2500
         End
         Begin VB.Label Label18 
            Caption         =   "8bit : SVALARM stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   24
            Top             =   3060
            Width           =   2500
         End
         Begin VB.Label Label37 
            Caption         =   "31bit : INPERR"
            Height          =   270
            Left            =   480
            TabIndex        =   23
            Top             =   240
            Width           =   2500
         End
         Begin VB.Label Label38 
            Caption         =   "30bit : ERRSTATE"
            Height          =   270
            Left            =   480
            TabIndex        =   22
            Top             =   520
            Width           =   2500
         End
         Begin VB.Label Label39 
            Caption         =   "16bit : MPGERR stopped"
            Height          =   270
            Left            =   480
            TabIndex        =   21
            Top             =   800
            Width           =   2500
         End
      End
   End
End
Attribute VB_Name = "frmStatus"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim m_aAxis(2) As Long

Public Sub UpdateAxis(lAxis As Long)
    m_aAxis(0) = AXIS_EVN(lAxis)
    m_aAxis(1) = AXIS_ODD(lAxis)

    LampUpdate
End Sub
Public Sub LampUpdate()
    Dim lAxisCount As Long
    Dim EndStatus As Long

    Call AxmStatusReadStop(m_aAxis(0), EndStatus)
    
    LedXENS31.BackColor = LED_RED((EndStatus And &H80000000) = &H80000000)
    LedXENS30.BackColor = LED_RED((EndStatus And &H40000000) = &H40000000)
    LedXENS16.BackColor = LED_RED((EndStatus And &H10000) = &H10000)
    LedXENS15.BackColor = LED_RED((EndStatus And &H8000) = &H8000)
    LedXENS14.BackColor = LED_RED((EndStatus And &H4000) = &H4000)
    LedXENS13.BackColor = LED_RED((EndStatus And &H2000) = &H2000)
    LedXENS12.BackColor = LED_RED((EndStatus And &H1000) = &H1000)
    LedXENS11.BackColor = LED_RED((EndStatus And &H800) = &H800)
    LedXENS10.BackColor = LED_RED((EndStatus And &H400) = &H400)
    LedXENS09.BackColor = LED_RED((EndStatus And &H200) = &H200)
    LedXENS08.BackColor = LED_RED((EndStatus And &H100) = &H100)
    LedXENS07.BackColor = LED_RED((EndStatus And &H80) = &H80)
    LedXENS06.BackColor = LED_RED((EndStatus And &H40) = &H40)
    LedXENS05.BackColor = LED_RED((EndStatus And &H20) = &H20)
    LedXENS04.BackColor = LED_RED((EndStatus And &H10) = &H10)
    LedXENS03.BackColor = LED_RED((EndStatus And &H8) = &H8)
    LedXENS02.BackColor = LED_RED((EndStatus And &H4) = &H4)
    LedXENS01.BackColor = LED_RED((EndStatus And &H2) = &H2)
    LedXENS00.BackColor = LED_RED((EndStatus And &H1) = &H1)
    
    Call AxmStatusReadStop(m_aAxis(1), EndStatus)

    LedYENS31.BackColor = LED_RED((EndStatus And &H80000000) = &H80000000)
    LedYENS30.BackColor = LED_RED((EndStatus And &H40000000) = &H40000000)
    LedYENS16.BackColor = LED_RED((EndStatus And &H10000) = &H10000)
    LedYENS15.BackColor = LED_RED((EndStatus And &H8000) = &H8000)
    LedYENS14.BackColor = LED_RED((EndStatus And &H4000) = &H4000)
    LedYENS13.BackColor = LED_RED((EndStatus And &H2000) = &H2000)
    LedYENS12.BackColor = LED_RED((EndStatus And &H1000) = &H1000)
    LedYENS11.BackColor = LED_RED((EndStatus And &H800) = &H800)
    LedYENS10.BackColor = LED_RED((EndStatus And &H400) = &H400)
    LedYENS09.BackColor = LED_RED((EndStatus And &H200) = &H200)
    LedYENS08.BackColor = LED_RED((EndStatus And &H100) = &H100)
    LedYENS07.BackColor = LED_RED((EndStatus And &H80) = &H80)
    LedYENS06.BackColor = LED_RED((EndStatus And &H40) = &H40)
    LedYENS05.BackColor = LED_RED((EndStatus And &H20) = &H20)
    LedYENS04.BackColor = LED_RED((EndStatus And &H10) = &H10)
    LedYENS03.BackColor = LED_RED((EndStatus And &H8) = &H8)
    LedYENS02.BackColor = LED_RED((EndStatus And &H4) = &H4)
    LedYENS01.BackColor = LED_RED((EndStatus And &H2) = &H2)
    LedYENS00.BackColor = LED_RED((EndStatus And &H1) = &H1)

    frmAxisX.Caption = "X Axis: " + Format(m_aAxis(0), "00")
    frmAxisY.Caption = "Y Axis: " + Format(m_aAxis(1), "00")

    Call AxmInfoGetAxisCount(lAxisCount)
    If (m_aAxis(0) = 0) Then
        btnPrev.Enabled = DISABLE
    Else
        btnPrev.Enabled = ENABLE
    End If
    
    If (m_aAxis(1) = (lAxisCount - 1)) Then
        btnNext.Enabled = DISABLE
    Else
        btnNext.Enabled = ENABLE
    End If
End Sub

Private Sub btnCur_Click()
    LampUpdate
End Sub

Private Sub btnNext_Click()
    Dim lAxisCount As Long
    Call AxmInfoGetAxisCount(lAxisCount)
    If (m_aAxis(1) < lAxisCount - 1) Then
        m_aAxis(0) = m_aAxis(0) + 2
        m_aAxis(1) = m_aAxis(1) + 2
        LampUpdate
    End If
End Sub

Private Sub btnPrev_Click()
    If (m_aAxis(0) >= 2) Then
        m_aAxis(0) = m_aAxis(0) - 2
        m_aAxis(1) = m_aAxis(1) - 2
        LampUpdate
    End If
End Sub

Private Sub tmStatusView_Timer()
    Dim DrvStatus As Long
    
    Call AxmStatusReadMotion(m_aAxis(0), DrvStatus)

    LedXDRS10.BackColor = LED_RED((DrvStatus And &H400) = &H400)
    LedXDRS09.BackColor = LED_RED((DrvStatus And &H200) = &H200)
    LedXDRS07.BackColor = LED_RED((DrvStatus And &H80) = &H80)
    LedXDRS06.BackColor = LED_RED((DrvStatus And &H40) = &H40)
    LedXDRS05.BackColor = LED_RED((DrvStatus And &H20) = &H20)
    LedXDRS04.BackColor = LED_RED((DrvStatus And &H10) = &H10)
    LedXDRS03.BackColor = LED_RED((DrvStatus And &H8) = &H8)
    LedXDRS02.BackColor = LED_RED((DrvStatus And &H4) = &H4)
    LedXDRS01.BackColor = LED_RED((DrvStatus And &H2) = &H2)
    LedXDRS00.BackColor = LED_RED((DrvStatus And &H1) = &H1)

    Call AxmStatusReadMotion(m_aAxis(1), DrvStatus)
    
    LedYDRS10.BackColor = LED_RED((DrvStatus And &H400) = &H400)
    LedYDRS09.BackColor = LED_RED((DrvStatus And &H200) = &H200)
    LedYDRS07.BackColor = LED_RED((DrvStatus And &H80) = &H80)
    LedYDRS06.BackColor = LED_RED((DrvStatus And &H40) = &H40)
    LedYDRS05.BackColor = LED_RED((DrvStatus And &H20) = &H20)
    LedYDRS04.BackColor = LED_RED((DrvStatus And &H10) = &H10)
    LedYDRS03.BackColor = LED_RED((DrvStatus And &H8) = &H8)
    LedYDRS02.BackColor = LED_RED((DrvStatus And &H4) = &H4)
    LedYDRS01.BackColor = LED_RED((DrvStatus And &H2) = &H2)
    LedYDRS00.BackColor = LED_RED((DrvStatus And &H1) = &H1)
End Sub
