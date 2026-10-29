VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form MotParameter 
   Caption         =   "MotParameter"
   ClientHeight    =   11865
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   7200
   LinkTopic       =   "MotParameter"
   ScaleHeight     =   11865
   ScaleWidth      =   7200
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1Save 
      Left            =   5130
      Top             =   615
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Timer m_timer 
      Interval        =   100
      Left            =   4200
      Top             =   660
   End
   Begin VB.CommandButton btnApplyAllAxes 
      Caption         =   "Apply All Axes"
      Height          =   315
      Left            =   120
      TabIndex        =   99
      Top             =   11400
      Width           =   6975
   End
   Begin VB.CommandButton btnApplySoftLimit 
      Caption         =   "Apply"
      Height          =   420
      Left            =   5610
      TabIndex        =   93
      Top             =   8160
      Width           =   1380
   End
   Begin VB.TextBox edtDecel 
      Alignment       =   1  'Right Justify
      Height          =   330
      Left            =   5145
      TabIndex        =   92
      Top             =   10680
      Width           =   1815
   End
   Begin VB.TextBox edtAccel 
      Alignment       =   1  'Right Justify
      Height          =   330
      Left            =   5160
      TabIndex        =   91
      Top             =   10245
      Width           =   1800
   End
   Begin VB.Frame Frame6 
      Caption         =   "< User Move Parameter Setting >"
      Height          =   1455
      Left            =   120
      TabIndex        =   88
      Top             =   9825
      Width           =   6975
      Begin VB.CommandButton BtnApplyUserPara 
         Caption         =   "Apply"
         Height          =   390
         Left            =   5535
         TabIndex        =   94
         Top             =   -30
         Width           =   1335
      End
      Begin VB.TextBox edtVelocity 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   1530
         TabIndex        =   90
         Top             =   840
         Width           =   1800
      End
      Begin VB.TextBox edtPosition 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   1530
         TabIndex        =   89
         Top             =   420
         Width           =   1785
      End
      Begin VB.Label Label40 
         Caption         =   "31:Deceleration"
         Height          =   210
         Left            =   3735
         TabIndex        =   98
         Top             =   930
         Width           =   1125
      End
      Begin VB.Label Label39 
         Caption         =   "30:Acceleration"
         Height          =   240
         Left            =   3735
         TabIndex        =   97
         Top             =   510
         Width           =   1215
      End
      Begin VB.Label Label38 
         Caption         =   "29:Velocity"
         Height          =   285
         Left            =   165
         TabIndex        =   96
         Top             =   870
         Width           =   1200
      End
      Begin VB.Label Label37 
         Caption         =   "28:Position"
         Height          =   270
         Left            =   180
         TabIndex        =   95
         Top             =   465
         Width           =   990
      End
      Begin VB.Line Line7 
         X1              =   3555
         X2              =   3555
         Y1              =   255
         Y2              =   1320
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "< Software Limit Setting >"
      Height          =   1560
      Left            =   105
      TabIndex        =   77
      Top             =   8160
      Width           =   7005
      Begin VB.ComboBox cboSLimitStopMode 
         Height          =   315
         Left            =   5055
         TabIndex        =   85
         Top             =   1050
         Width           =   1815
      End
      Begin VB.TextBox edtSLimitPosP 
         Alignment       =   1  'Right Justify
         Height          =   345
         Left            =   5055
         TabIndex        =   84
         Top             =   660
         Width           =   1800
      End
      Begin VB.ComboBox cboSLimitSelect 
         Height          =   315
         Left            =   1530
         TabIndex        =   82
         Top             =   1035
         Width           =   1800
      End
      Begin VB.TextBox edtSLimitPosN 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1530
         TabIndex        =   80
         Top             =   675
         Width           =   1800
      End
      Begin VB.ComboBox cboSLimitEnable 
         Height          =   315
         Left            =   1530
         TabIndex        =   78
         Top             =   315
         Width           =   1800
      End
      Begin VB.Label Label36 
         Caption         =   "38:Stop Mode"
         Height          =   255
         Left            =   3720
         TabIndex        =   87
         Top             =   1110
         Width           =   1200
      End
      Begin VB.Label Label35 
         Caption         =   "25:Pos Soft Limit"
         Height          =   270
         Left            =   3735
         TabIndex        =   86
         Top             =   720
         Width           =   1410
      End
      Begin VB.Line Line6 
         X1              =   3555
         X2              =   3555
         Y1              =   315
         Y2              =   1425
      End
      Begin VB.Label Label34 
         Caption         =   "37:Select"
         Height          =   270
         Left            =   180
         TabIndex        =   83
         Top             =   1080
         Width           =   945
      End
      Begin VB.Label Label33 
         Caption         =   "24:Neg Soft Limit"
         Height          =   330
         Left            =   180
         TabIndex        =   81
         Top             =   705
         Width           =   1590
      End
      Begin VB.Label Label32 
         Caption         =   "39:Enable"
         Height          =   300
         Left            =   180
         TabIndex        =   79
         Top             =   345
         Width           =   1245
      End
   End
   Begin VB.TextBox edtHomeOffset 
      Alignment       =   1  'Right Justify
      Height          =   285
      Left            =   5160
      TabIndex        =   64
      Top             =   7695
      Width           =   1800
   End
   Begin VB.TextBox edtHomeClrTime 
      Alignment       =   1  'Right Justify
      Height          =   285
      Left            =   5160
      TabIndex        =   63
      Top             =   7335
      Width           =   1800
   End
   Begin VB.TextBox edtAccSecond 
      Alignment       =   1  'Right Justify
      Height          =   285
      Left            =   5160
      TabIndex        =   62
      Top             =   6975
      Width           =   1800
   End
   Begin VB.TextBox edtAccFirst 
      Alignment       =   1  'Right Justify
      Height          =   285
      Left            =   5160
      TabIndex        =   61
      Top             =   6630
      Width           =   1800
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Home Search Setting > "
      Height          =   2820
      Left            =   120
      TabIndex        =   50
      Top             =   5265
      Width           =   6990
      Begin VB.TextBox edtVelLast 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1515
         TabIndex        =   60
         Top             =   2430
         Width           =   1785
      End
      Begin VB.TextBox edtVelThird 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1515
         TabIndex        =   59
         Top             =   2070
         Width           =   1785
      End
      Begin VB.TextBox edtVelSecond 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1515
         TabIndex        =   58
         Top             =   1710
         Width           =   1785
      End
      Begin VB.TextBox edtVelFirst 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1515
         TabIndex        =   57
         Top             =   1365
         Width           =   1785
      End
      Begin VB.ComboBox cboZPhaseUse 
         Height          =   315
         Left            =   5040
         TabIndex        =   56
         Top             =   825
         Width           =   1830
      End
      Begin VB.ComboBox cboHomeDir 
         Height          =   315
         Left            =   5040
         TabIndex        =   55
         Top             =   450
         Width           =   1830
      End
      Begin VB.ComboBox cboHomeLevel 
         Height          =   315
         Left            =   1530
         TabIndex        =   54
         Top             =   825
         Width           =   1815
      End
      Begin VB.ComboBox cboHomeSignal 
         Height          =   315
         Left            =   1530
         TabIndex        =   53
         Top             =   450
         Width           =   1815
      End
      Begin VB.CommandButton btnApplyHome 
         Caption         =   "Apply"
         Height          =   420
         Left            =   5565
         TabIndex        =   52
         Top             =   -45
         Width           =   1290
      End
      Begin VB.Label Label31 
         Caption         =   "23:End Offset"
         Height          =   225
         Left            =   3690
         TabIndex        =   76
         Top             =   2445
         Width           =   1350
      End
      Begin VB.Label Label30 
         Caption         =   "22:Clear TM[ms]"
         Height          =   255
         Left            =   3690
         TabIndex        =   75
         Top             =   2100
         Width           =   1185
      End
      Begin VB.Label Label29 
         Caption         =   "21:Second Accel"
         Height          =   315
         Left            =   3690
         TabIndex        =   74
         Top             =   1740
         Width           =   1230
      End
      Begin VB.Label Label28 
         Caption         =   "20:First Accel"
         Height          =   270
         Left            =   3690
         TabIndex        =   73
         Top             =   1395
         Width           =   1125
      End
      Begin VB.Label Label27 
         Caption         =   "13:ZPhase Use"
         Height          =   240
         Left            =   3690
         TabIndex        =   72
         Top             =   885
         Width           =   1380
      End
      Begin VB.Label Label26 
         Caption         =   "11:Home Dir"
         Height          =   240
         Left            =   3690
         TabIndex        =   71
         Top             =   495
         Width           =   1230
      End
      Begin VB.Label Label25 
         Caption         =   "19:Last Vel"
         Height          =   225
         Left            =   180
         TabIndex        =   70
         Top             =   2445
         Width           =   1185
      End
      Begin VB.Label Label24 
         Caption         =   "18:Third Vel"
         Height          =   195
         Left            =   180
         TabIndex        =   69
         Top             =   2100
         Width           =   930
      End
      Begin VB.Label Label23 
         Caption         =   "17:Second Vel"
         Height          =   240
         Left            =   180
         TabIndex        =   68
         Top             =   1740
         Width           =   1275
      End
      Begin VB.Label Label22 
         Caption         =   "16:First Vel"
         Height          =   255
         Left            =   180
         TabIndex        =   67
         Top             =   1410
         Width           =   960
      End
      Begin VB.Label Label21 
         Caption         =   "10:Home Level"
         Height          =   285
         Left            =   180
         TabIndex        =   66
         Top             =   870
         Width           =   1365
      End
      Begin VB.Label Label20 
         Caption         =   "09:Home Signal"
         Height          =   345
         Left            =   180
         TabIndex        =   65
         Top             =   480
         Width           =   1140
      End
      Begin VB.Line Line5 
         X1              =   3540
         X2              =   3540
         Y1              =   1395
         Y2              =   2715
      End
      Begin VB.Line Line4 
         X1              =   3540
         X2              =   3540
         Y1              =   360
         Y2              =   1125
      End
      Begin VB.Line Line3 
         X1              =   135
         X2              =   6825
         Y1              =   1245
         Y2              =   1245
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Input/Output Signal Setting >"
      Height          =   2505
      Left            =   105
      TabIndex        =   23
      Top             =   2730
      Width           =   7005
      Begin VB.CommandButton btnApplySignal 
         Caption         =   "Apply"
         Height          =   420
         Left            =   5565
         TabIndex        =   51
         Top             =   -60
         Width           =   1290
      End
      Begin VB.CheckBox chkEmg 
         Caption         =   "Check6"
         Enabled         =   0   'False
         Height          =   195
         Left            =   4815
         TabIndex        =   44
         Top             =   1260
         Width           =   165
      End
      Begin VB.CheckBox chkZPhase 
         Caption         =   "Check5"
         Enabled         =   0   'False
         Height          =   195
         Left            =   4815
         TabIndex        =   43
         Top             =   510
         Width           =   165
      End
      Begin VB.ComboBox cboEncoderType 
         Height          =   315
         Left            =   5025
         TabIndex        =   42
         Top             =   1980
         Width           =   1860
      End
      Begin VB.ComboBox cboAlarmReset 
         Height          =   315
         Left            =   5025
         TabIndex        =   41
         Top             =   1575
         Width           =   1860
      End
      Begin VB.ComboBox cboStopLevel 
         Height          =   315
         Left            =   5025
         TabIndex        =   40
         Top             =   1185
         Width           =   1860
      End
      Begin VB.ComboBox cboStopMode 
         Height          =   315
         Left            =   5025
         TabIndex        =   39
         Top             =   825
         Width           =   1860
      End
      Begin VB.ComboBox cboZPhaseLev 
         Height          =   315
         Left            =   5025
         TabIndex        =   38
         Top             =   465
         Width           =   1860
      End
      Begin VB.CheckBox chkELimitP 
         Caption         =   "Check4"
         Enabled         =   0   'False
         Height          =   225
         Left            =   1275
         TabIndex        =   32
         Top             =   1620
         Width           =   165
      End
      Begin VB.CheckBox chkELimitN 
         Caption         =   "Check3"
         Enabled         =   0   'False
         Height          =   195
         Left            =   1275
         TabIndex        =   31
         Top             =   1245
         Width           =   195
      End
      Begin VB.CheckBox chkAlarm 
         Caption         =   "Check2"
         Enabled         =   0   'False
         Height          =   255
         Left            =   1275
         TabIndex        =   30
         Top             =   840
         Width           =   225
      End
      Begin VB.ComboBox cboServoOn 
         Height          =   315
         Left            =   1515
         TabIndex        =   29
         Top             =   1980
         Width           =   1830
      End
      Begin VB.ComboBox cboELimitP 
         Height          =   315
         Left            =   1515
         TabIndex        =   28
         Top             =   1575
         Width           =   1830
      End
      Begin VB.ComboBox cboELimitN 
         Height          =   315
         Left            =   1515
         TabIndex        =   27
         Top             =   1185
         Width           =   1830
      End
      Begin VB.ComboBox cboAlarm 
         Height          =   315
         Left            =   1515
         TabIndex        =   26
         Top             =   825
         Width           =   1830
      End
      Begin VB.CheckBox chkInp 
         Caption         =   "Check1"
         Enabled         =   0   'False
         Height          =   255
         Left            =   1275
         TabIndex        =   25
         Top             =   480
         Width           =   255
      End
      Begin VB.ComboBox cboInp 
         Height          =   315
         Left            =   1515
         TabIndex        =   24
         Top             =   465
         Width           =   1830
      End
      Begin VB.Label Label19 
         Caption         =   "36:Encoder Type"
         Height          =   405
         Left            =   3690
         TabIndex        =   49
         Top             =   2025
         Width           =   2940
      End
      Begin VB.Label Label18 
         Caption         =   "35:Alm Reset Lev"
         Height          =   330
         Left            =   3690
         TabIndex        =   48
         Top             =   1635
         Width           =   2790
      End
      Begin VB.Label Label17 
         Caption         =   "15:EStop Level"
         Height          =   195
         Left            =   3675
         TabIndex        =   47
         Top             =   1245
         Width           =   1665
      End
      Begin VB.Label Label16 
         Caption         =   "14:EStop Mode"
         Height          =   375
         Left            =   3690
         TabIndex        =   46
         Top             =   870
         Width           =   1290
      End
      Begin VB.Label Label15 
         Caption         =   "12:ZPhase Lev"
         Height          =   195
         Left            =   3690
         TabIndex        =   45
         Top             =   495
         Width           =   2340
      End
      Begin VB.Label Label14 
         Caption         =   "34:Servo On Lev"
         Height          =   375
         Left            =   120
         TabIndex        =   37
         Top             =   2040
         Width           =   1455
      End
      Begin VB.Label Label13 
         Caption         =   "06:Pos Limit"
         Height          =   210
         Left            =   120
         TabIndex        =   36
         Top             =   1620
         Width           =   1215
      End
      Begin VB.Label Label12 
         Caption         =   "05:Neg Limit"
         Height          =   255
         Left            =   120
         TabIndex        =   35
         Top             =   1230
         Width           =   975
      End
      Begin VB.Label Label11 
         Caption         =   "04:Alarm"
         Height          =   255
         Left            =   120
         TabIndex        =   34
         Top             =   855
         Width           =   1095
      End
      Begin VB.Label Label10 
         Caption         =   "03:Inposition"
         Height          =   255
         Left            =   120
         TabIndex        =   33
         Top             =   480
         Width           =   1095
      End
      Begin VB.Line Line2 
         X1              =   3525
         X2              =   3525
         Y1              =   330
         Y2              =   2370
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Pulse/Encoder Method && Move Parameter Setting >"
      Height          =   1965
      Left            =   120
      TabIndex        =   5
      Top             =   705
      Width           =   6975
      Begin MSComDlg.CommonDialog CommonDialog1Open 
         Left            =   4530
         Top             =   -90
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.TextBox edtMoveUnit 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   5025
         TabIndex        =   14
         Top             =   1545
         Width           =   1830
      End
      Begin VB.TextBox edtMovePulse 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   5025
         TabIndex        =   13
         Top             =   1170
         Width           =   1830
      End
      Begin VB.TextBox edtMaxVel 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   5025
         TabIndex        =   12
         Top             =   795
         Width           =   1830
      End
      Begin VB.TextBox edtMinVel 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   5025
         TabIndex        =   11
         Top             =   405
         Width           =   1830
      End
      Begin VB.ComboBox cboProfile 
         Height          =   315
         Left            =   900
         TabIndex        =   10
         Top             =   1560
         Width           =   2430
      End
      Begin VB.ComboBox cboAbsRel 
         Height          =   315
         Left            =   900
         TabIndex        =   9
         Top             =   1185
         Width           =   2430
      End
      Begin VB.ComboBox cboEncoder 
         Height          =   315
         Left            =   900
         TabIndex        =   8
         Top             =   810
         Width           =   2430
      End
      Begin VB.ComboBox cboPulse 
         Height          =   315
         Left            =   900
         TabIndex        =   7
         Top             =   420
         Width           =   2430
      End
      Begin VB.CommandButton btnApplyPulse 
         Caption         =   "Apply"
         Height          =   375
         Left            =   5520
         TabIndex        =   6
         Top             =   -30
         Width           =   1335
      End
      Begin VB.Label Label9 
         Caption         =   "27:Move Unit"
         Height          =   225
         Left            =   3690
         TabIndex        =   22
         Top             =   1605
         Width           =   1155
      End
      Begin VB.Label Label8 
         Caption         =   "26:Move Pulse"
         Height          =   225
         Left            =   3690
         TabIndex        =   21
         Top             =   1230
         Width           =   1155
      End
      Begin VB.Label Label7 
         Caption         =   "08:Max Velocity"
         Height          =   270
         Left            =   3690
         TabIndex        =   20
         Top             =   855
         Width           =   1755
      End
      Begin VB.Label Label6 
         Caption         =   "07: Min Velocity"
         Height          =   375
         Left            =   3690
         TabIndex        =   19
         Top             =   465
         Width           =   1170
      End
      Begin VB.Label Label5 
         Caption         =   "33:Profile"
         Height          =   270
         Left            =   135
         TabIndex        =   18
         Top             =   1605
         Width           =   705
      End
      Begin VB.Label Label4 
         Caption         =   "32:Abs"
         Height          =   270
         Left            =   135
         TabIndex        =   17
         Top             =   1230
         Width           =   690
      End
      Begin VB.Label Label3 
         Caption         =   "02:Enc"
         Height          =   285
         Left            =   135
         TabIndex        =   16
         Top             =   855
         Width           =   675
      End
      Begin VB.Label Label2 
         Caption         =   "01:Pulse"
         Height          =   300
         Left            =   135
         TabIndex        =   15
         Top             =   450
         Width           =   705
      End
      Begin VB.Line Line1 
         X1              =   3510
         X2              =   3510
         Y1              =   345
         Y2              =   1860
      End
   End
   Begin VB.CommandButton btnSaveFile 
      Caption         =   "Save File"
      Height          =   375
      Left            =   5640
      TabIndex        =   2
      Top             =   225
      Width           =   1335
   End
   Begin VB.CommandButton btnLoadFile 
      Caption         =   "Load File"
      Height          =   375
      Left            =   4200
      TabIndex        =   1
      Top             =   225
      Width           =   1335
   End
   Begin VB.ComboBox cboSelectAxis 
      Height          =   315
      Left            =   1005
      TabIndex        =   0
      Top             =   240
      Width           =   2865
   End
   Begin VB.Frame Frame1 
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   6975
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "00:Axis"
         DragMode        =   1  'Automatic
         Height          =   195
         Left            =   165
         TabIndex        =   4
         Top             =   180
         Width           =   510
      End
   End
End
Attribute VB_Name = "MotParameter"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' MotParameter.vb : implementation file

' **************************************************************************
' >> [일자]: 2015.11.25
' >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로
'    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
' >> [중요]: 신호설정 함수 사용시 주의사항
'     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
'     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
'        변경해서 바꿀수 있습니다.
' **************************************************************************
    
    Dim m_lAxis As Integer
    Dim m_lAxisCounts As Long
    Dim m_dwModuleID As Long

    Private Sub Form_Load()
        InitLibrary
        AddAxisInfo
        UpdateState
    End Sub
    
   Private Sub Form_Unload(Cancel As Integer)
        AxlClose
    End Sub
    

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelectAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelectAxis_Click()
        Dim lpBoardNo As Long
        Dim lpBoardPos As Long
        Dim dwRetCode As Integer
        
        lpBoardNo = 0
        lpBoardPos = 0
        
        m_lAxis = cboSelectAxis.ListIndex
        
        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxis, lpBoardNo, lpBoardPos, m_dwModuleID)

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> btnLoadFile_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '   - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '   - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
    '       설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLoadFile_Click()
        Dim szFileName As String
        CommonDialog1Open.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Save.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Save.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2
        CommonDialog1Save.FilterIndex = 2

        CommonDialog1Open.Action = 1
        CommonDialog1Save.FileName = CommonDialog1Open.FileName
        szFileName = CommonDialog1Open.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox ("File load fail!")
            End If
        End If

        UpdateState

    End Sub

    ' ++ =======================================================================
    ' >> btnSaveFile_Click() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
    '  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에
    '    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSaveFile_Click()
        Dim szFileName As String

        CommonDialog1Open.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
        CommonDialog1Save.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"

        CommonDialog1Save.Action = 2
        CommonDialog1Open.FileName = CommonDialog1Save.FileName
        szFileName = CommonDialog1Save.FileName
        If szFileName <> "" Then
            If AxmMotSaveParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox ("File save fail!")
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyPulse_Click() : "Pulse/Encoder Method && Move Parameter Setting"
    '    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyPulse_Click()
        Dim dwPulse As Long
        Dim dUnit As Double
        Dim dMinVel As Double
        Dim dMaxVel As Double
        Dim dwMethod As Long
        Dim dwAbsRelMode As Long
        Dim dwProfileMode As Long
        Dim dwRetCode As Integer
        
        dwPulse = 1
        dUnit = 1#
        dMinVel = 1#
        dMaxVel = 100#
        dwMethod = 0
        dwAbsRelMode = 0
        dwProfileMode = 0

        If cboPulse.Enabled = True Then
            dwMethod = ConvertComboToAxm(cboPulse)
            ' ++ 지정 축의 펄스 출력 방식을 설정합니다.
            ' uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
            '           (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
            '           (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
            '           (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
            '           (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
            '           (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
            '           (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
            '           (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
            '           (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
            '           (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
            dwRetCode = AxmMotSetPulseOutMethod(m_lAxis, dwMethod)
        End If

        If cboEncoder.Enabled = True Then
            dwMethod = ConvertComboToAxm(cboEncoder)
            ' ++ 지정 축의 Encoder 입력 방식을 설정합니다.
            ' uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
            '           (1)ObverseSqr1Mode   - 정방향 1체배
            '           (2)ObverseSqr2Mode   - 정방향 2체배
            '           (3)ObverseSqr4Mode   - 정방향 4체배
            '           (4)ReverseUpDownMode - 역방향 Up/Down
            '           (5)ReverseSqr1Mode   - 역방향 1체배
            '           (6)ReverseSqr2Mode   - 역방향 2체배
            '           (7)ReverseSqr4Mode   - 역방향 4체배
            dwRetCode = AxmMotSetEncInputMethod(m_lAxis, dwMethod)
        End If

        If cboAbsRel.Enabled = True Then
            dwAbsRelMode = ConvertComboToAxm(cboAbsRel)
            ' ++ 지정 축의 구동 좌표계를 설정합니다.
            ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            dwRetCode = AxmMotSetAbsRelMode(m_lAxis, dwAbsRelMode)
        End If

        If cboProfile.Enabled = True Then
            dwProfileMode = ConvertComboToAxm(cboProfile)
            ' ++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
            ' uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
            '                (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
            '                (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
            '                (3)SYM_S_CURVE_MODE    - Symmetric S Curve
            '                (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
            dwRetCode = AxmMotSetProfileMode(m_lAxis, dwProfileMode)
        End If

        dMinVel = edtMinVel.Text
        ' ++ 지정 축의 최소 구동속도를 설정합니다.
        dwRetCode = AxmMotSetMinVel(m_lAxis, dMinVel)

        dMaxVel = edtMaxVel.Text
        ' ++ 지정 축의 최대 구동속도를 설정합니다.
        dwRetCode = AxmMotSetMaxVel(m_lAxis, dMaxVel)

        dwPulse = edtMovePulse.Text
        dUnit = edtMoveUnit.Text
        ' ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
        dwRetCode = AxmMotSetMoveUnitPerPulse(m_lAxis, dUnit, dwPulse)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplySignal_Click() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을
    '    클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplySignal_Click()
        Dim dwUse As Long
        Dim dwLevel As Long
        Dim dwStopMode As Long
        Dim dwPositiveLevel As Long
        Dim dwNegativeLevel As Long
        Dim dwEncoderType As Long
        Dim dwRetCode As Integer
        Dim upPositiveLevel As Long
        Dim upNegativeLevel As Long
        
        dwUse = 0
        dwLevel = 0
        dwRetCode = 0
        dwStopMode = 0
        dwPositiveLevel = 0
        dwNegativeLevel = 0
        dwEncoderType = 0
        

        dwUse = ConvertComboToAxm(cboInp)
        ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
        ' - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
        '              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
        '              다음 구동을 할 수 없게 됩니다.
        dwRetCode = AxmSignalSetInpos(m_lAxis, dwUse)

        If cboAlarmReset.Enabled Then
            dwLevel = ConvertComboToAxm(cboAlarmReset)
            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoAlarmResetLevel(m_lAxis, dwLevel)
        End If

        ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxis, dwStopMode, upPositiveLevel, upNegativeLevel)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwNegativeLevel = ConvertComboToAxm(cboELimitN)
            dwPositiveLevel = ConvertComboToAxm(cboELimitP)
            ' ++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetLimit(m_lAxis, dwStopMode, dwPositiveLevel, dwNegativeLevel)
        End If

        If cboZPhaseLev.Enabled Then
            dwLevel = ConvertComboToAxm(cboZPhaseLev)
            ' ++ 지정 축의 Z상 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetZphaseLevel(m_lAxis, dwLevel)
        End If

        dwStopMode = ConvertComboToAxm(cboStopMode)
        dwLevel = ConvertComboToAxm(cboStopLevel)
        ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
        dwRetCode = AxmSignalSetStop(m_lAxis, dwStopMode, dwLevel)

        dwLevel = ConvertComboToAxm(cboServoOn)
        ' ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
        dwRetCode = AxmSignalSetServoOnLevel(m_lAxis, dwLevel)

        If cboAlarm.Enabled Then
            dwUse = ConvertComboToAxm(cboAlarm)
            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoAlarm(m_lAxis, dwUse)
        End If

        dwEncoderType = ConvertComboToAxm(cboEncoderType)
        ' ++ 지정 축의 Encoder Input Type를 설정합니다.
        '  dwEncoderType : (0)TYPE_INCREMENTAL
        '                  (1)TYPE_ABSOLUTE
        dwRetCode = AxmSignalSetEncoderType(m_lAxis, dwEncoderType)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplyHome_Click() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
    '    호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyHome_Click()
        Dim dwHomeDir As Long
        Dim dwHomeSignal As Long
        Dim dwHomeLevel As Long
        Dim dwZPhas As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Double
        Dim dwRetCode As Integer
        
        dwHomeDir = 0
        dwHomeSignal = 0
        dwHomeLevel = 0
        dwZPhas = 0
        dHomeClrTime = 1000#
        dHomeOffset = 0
        

        dwHomeLevel = ConvertComboToAxm(cboHomeLevel)
        ' ++ 지정 축의 원점신호 Active Level을 설정합니다.
        dwRetCode = AxmHomeSetSignalLevel(m_lAxis, dwHomeLevel)

        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwHomeDir = ConvertComboToAxm(cboHomeDir)
        dwZPhas = ConvertComboToAxm(cboZPhaseUse)

        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text
        ' ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
        dwRetCode = AxmHomeSetMethod(m_lAxis, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplySoftLimit_Click() : "Software Limit Setting" 그룹의 "Apply" 버튼을
    '    클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplySoftLimit_Click()
        Dim dwRetCode As Long
        Dim dwUse As Long
        Dim dwStopMode As Long
        Dim dwSelection As Long
        Dim dPositivePos As Double
        Dim dNegativePos As Double
        
        dwRetCode = 0
        dwUse = 0
        dwStopMode = 0
        dwSelection = 0
        dPositivePos = 0#
        dNegativePos = 0#

        ' ++ 지정한 축에 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxis, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos)
        If dwRetCode = AXT_RT_SUCCESS Then
            dNegativePos = edtSLimitPosN.Text
            dPositivePos = edtSLimitPosP.Text

            dwUse = ConvertComboToAxm(cboSLimitEnable)
            dwStopMode = ConvertComboToAxm(cboSLimitStopMode)
            dwSelection = ConvertComboToAxm(cboSLimitSelect)

            ' ++ 지정 축의 소프트웨어 리미트를 설정합니다.
            ' uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
            '              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
            ' uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
            '              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
            ' uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
            '              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
            dwRetCode = AxmSignalSetSoftLimit(m_lAxis, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyUserPara_Click() : "User Move Parameter Setting " 그룹의 "Apply"
    '    버튼을 클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyUserPara_Click()
        Dim dInitPos As Double
        Dim dInitVel As Double
        Dim dInitAccel As Double
        Dim dInitDecel As Double
        
        dInitPos = 0#
        dInitVel = 0#
        dInitAccel = 0#
        dInitDecel = 0#
              
        dInitPos = edtPosition.Text
        dInitVel = edtVelocity.Text
        dInitAccel = edtAccel.Text
        dInitDecel = edtDecel.Text
        ' ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
        dwRetCode = AxmMotSetParaLoad(m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel)
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyAllAxes_Click() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
    '  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
    ' ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
    '    되지않는 파라메타가 있을 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyAllAxes_Click()
        Dim dwAxisNo As Long
        Dim dwMovePulse As Long
        Dim dwModeProfile As Long
        Dim dwUseAlarm As Long
        Dim dwMethodPulse As Long
        Dim dwMethodEncoder As Long
        Dim dwModeAbsRel As Long
        Dim dVelocityMin As Double
        Dim dVelocityMax As Double
        Dim dMoveUnit As Double
        
        dwAxisNo = 0
        dwMovePulse = 1
        dwModeProfile = 0
        dwUseAlarm = 0
        dwMethodPulse = 0
        dwMethodEncoder = 0
        dwModeAbsRel = 0
        dwvelocitymin = 1#
        dVelocityMin = 1#
        dVelocityMax = 100#
        dMoveUnit = 1#

        Dim dwUseInp, dwLevelAlarmReset, dwRetCode As Long
        Dim dwLevelLimitN As Long
        Dim dwLevelLimitP As Long
        Dim dwLevelZPhase As Long
        Dim dwModeStop As Long
        Dim dwLevelStop As Long
        Dim dwLevelServoOn As Long
        Dim dwTypeEncoder As Long
        
        dwLevelLimitN = 0
        dwLevelLimitP = 0
        dwLevelZPhase = 0
        dwModeStop = 0
        dwLevelStop = 0
        dwLevelServoOn = 0
        dwTypeEncoder = 0
        
        Dim dwHomeDir As Long
        Dim dwHomeSignal As Long
        Dim dwLevelHome As Long
        Dim dwZPhase As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Double
        
        dwHomeDir = 0
        dwHomeSignal = 0
        dwLevelHome = 0
        dwZPhase = 0
        dHomeClrTime = 0#
        dHomeOffset = 0#

        Dim dwUse As Long
        Dim dwStopMode As Long
        Dim dwSelection As Long
        Dim dPositivePos As Double
        Dim dNegativePos As Double
        
        dwUse = 0
        dwStopMode = 0
        dwSelection = 0
        dPositivePos = 0#
        dNegativePos = 0#
        
        Dim upPositiveLevel As Long
        Dim upNegativeLevel As Long
        
        Dim dpPositivePos As Double
        Dim dpNegativePos As Double

        Dim dInitPos, dInitVel, dInitAccel, dInitDecel As Double

        ' Pulse/Encoder Method && Move Parameter Setting
        dwMethodPulse = ConvertComboToAxm(cboPulse)
        dwMethodEncoder = ConvertComboToAxm(cboEncoder)
        dwUseAlarm = ConvertComboToAxm(cboAlarm)
        dwModeAbsRel = ConvertComboToAxm(cboAbsRel)
        dwModeProfile = ConvertComboToAxm(cboProfile)
        dVelocityMin = edtMinVel.Text
        dVelocityMax = edtMaxVel.Text
        dwMovePulse = edtMovePulse.Text
        dMoveUnit = edtMoveUnit.Text

        ' Input/Output Signal Setting
        dwUseInp = ConvertComboToAxm(cboInp)
        dwLevelAlarmReset = ConvertComboToAxm(cboAlarmReset)
        dwLevelLimitN = ConvertComboToAxm(cboELimitN)
        dwLevelLimitP = ConvertComboToAxm(cboELimitP)
        dwLevelZPhase = ConvertComboToAxm(cboZPhaseLev)
        dwModeStop = ConvertComboToAxm(cboStopMode)
        dwLevelStop = ConvertComboToAxm(cboStopLevel)
        dwLevelServoOn = ConvertComboToAxm(cboServoOn)
        dwTypeEncoder = ConvertComboToAxm(cboEncoderType)

        ' Home Search Setting
        dwLevelHome = ConvertComboToAxm(cboHomeLevel)
        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwHomeDir = ConvertComboToAxm(cboHomeDir)
        dwZPhas = ConvertComboToAxm(cboZPhaseUse)
        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text

        ' Software Limit Setting
        dNegativePos = edtSLimitPosN.Text
        dPositivePos = edtSLimitPosP.Text

        ' User Move Parameter Setting
        dInitPos = edtPosition.Text
        dInitVel = edtVelocity.Text
        dInitAccel = edtAccel.Text
        dInitDecel = edtDecel.Text

        For dwAxisNo = 0 To (m_lAxisCounts - 1)

            ' Pulse/Encoder Method && Move Parameter Setting
            If cboPulse.Enabled = True Then
                ' ++ 지정 축의 펄스 출력 방식을 설정합니다.
                'uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
                '          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
                '          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
                '          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
                '          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
                '          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
                '          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
                '          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
                '          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
                '          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
                dwRetCode = AxmMotSetPulseOutMethod(dwAxisNo, dwMethodPulse)
            End If

            ' Pulse/Encoder Method && Move Parameter Setting
            If cboEncoder.Enabled = True Then
                ' ++ 지정 축의 Encoder 입력 방식을 설정합니다.
                ' uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
                '           (1)ObverseSqr1Mode   - 정방향 1체배
                '           (2)ObverseSqr2Mode   - 정방향 2체배
                '           (3)ObverseSqr4Mode   - 정방향 4체배
                '           (4)ReverseUpDownMode - 역방향 Up/Down
                '           (5)ReverseSqr1Mode   - 역방향 1체배
                '           (6)ReverseSqr2Mode   - 역방향 2체배
                '           (7)ReverseSqr4Mode   - 역방향 4체배
                dwRetCode = AxmMotSetEncInputMethod(dwAxisNo, dwMethodEncoder)
            End If

            If cboAlarm.Enabled = True Then
                ' ++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다.
               dwRetCode = AxmSignalSetServoAlarm(dwAxisNo, dwUseAlarm)
            End If

            If cboAbsRel.Enabled = True Then
                ' ++ 지정 축의 구동 좌표계를 설정합니다.
                ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
                '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
                dwRetCode = AxmMotSetAbsRelMode(dwAxisNo, dwMethodPulse)
            End If

            If cboProfile.Enabled = True Then
                ' dwProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
                '                 (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
                '                 (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
                '                 (3)SYM_S_CURVE_MODE    - Symmetric S Curve
                '                 (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
                dwRetCode = AxmMotSetProfileMode(dwAxisNo, dwModeProfile)
            End If

            ' ++ 지정 축의 초기 구동속도를 설정합니다.
            dwRetCode = AxmMotSetMinVel(dwAxisNo, dVelocityMin)

            ' ++ 지정 축의 최대 구동속도를 설정합니다.
            dwRetCode = AxmMotSetMaxVel(dwAxisNo, dVelocityMax)

            ' ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
            dwRetCode = AxmMotSetMoveUnitPerPulse(dwAxisNo, dMoveUnit, dwMovePulse)

            ' Input/Output Signal Setting
            ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
            '  - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
            '  ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
            '               Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
            '  ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
            '               다음 구동을 할 수 없게 됩니다.
            dwRetCode = AxmSignalSetInpos(dwAxisNo, dwUseInp)

            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoAlarmResetLevel(dwAxisNo, dwLevelAlarmReset)

            ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.

            dwRetCode = AxmSignalGetLimit(dwAxisNo, dwStopMode, upPositiveLevel, upNegativeLevel)
            If dwRetCode = AXT_RT_SUCCESS Then
                ' ++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
                dwRetCode = AxmSignalSetLimit(dwAxisNo, dwStopMode, dwLevelLimitP, dwLevelLimitN)
            End If

            ' ++ 지정 축의 Z상 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetZphaseLevel(dwAxisNo, dwLevelZPhase)

            ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetStop(dwAxisNo, dwModeStop, dwLevelStop)

            ' ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoOnLevel(dwAxisNo, dwLevelServoOn)

            ' ++ 지정 축의 Encoder Input Type를 설정합니다.
            '  dwEncoderType : (0)TYPE_INCREMENTAL
            '                  (1)TYPE_ABSOLUTE
            dwRetCode = AxmSignalSetEncoderType(dwAxisNo, dwTypeEncoder)

            ' Home Search Setting
            ' ++ 지정 축의 원점신호 Active Level을 설정합니다.
            dwRetCode = AxmHomeSetSignalLevel(dwAxisNo, dwLevelHome)

            ' ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
            dwRetCode = AxmHomeSetMethod(dwAxisNo, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)

            ' Software Limit Setting
            ' ++ 지정한 축에 Software Limit기능을 확인합니다.
            dwRetCode = AxmSignalGetSoftLimit(dwAxisNo, dwUse, dwStopMode, dwSelection, dpPositivePos, dpNegativePos)
            If dwRetCode = AXT_RT_SUCCESS Then
                dwUse = ConvertComboToAxm(cboSLimitEnable)
                dwStopMode = ConvertComboToAxm(cboSLimitStopMode)
                dwSelection = ConvertComboToAxm(cboSLimitSelect)

                ' ++ 지정 축의 소프트웨어 리미트를 설정합니다.
                ' uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
                '              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
                ' uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
                '              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
                ' uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
                '              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
                dwRetCode = AxmSignalSetSoftLimit(dwAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos)
            End If

            ' ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
            dwRetCode = AxmMotSetParaLoad(dwAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel)

        Next

    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer() : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        Dim dwState1, dwState2, dwRetCode As Long

        ' ++ Z상 신호의 상태를 확인합니다.
        dwRetCode = AxmStatusReadMechanical(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwState1 = IIf(((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) = 0), 0, 1)
            chkZPhase.Value = dwState1
        End If

        ' ++ Servo Alarm 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadServoAlarm(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkAlarm.Value = dwState1
        End If

        ' ++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadInpos(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkInp.Value = dwState1
        End If

        ' ++ Emergency 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadStop(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkEmg.Value = dwState1
        End If

        ' ++ (+/-)End Limit신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadLimit(m_lAxis, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkELimitP.Value = dwState1
            chkELimitN.Value = dwState2
        End If
    End Sub

    ' **************************************************************************
    ' >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
    '  - AXL(AjineXtek Library)을 사용가능하게 합니다.
    '  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
    '    지정해 모션관련 기본설정을 자동으로 합니다.
    ' --------------------------------------------------------------------------
    Private Function InitLibrary() As Boolean
        Dim dwRetCode As Long

        If AxlIsOpened = False Then
            dwRetCode = AxlOpenNoReset(7)
            If dwRetCode <> AXT_RT_SUCCESS Then
                MsgBox ("AxlOpen Fail... ErrorCode:" + Format(dwRetCode, "0000"))
                InitLibrary = False
            End If
        End If

        Dim szFilePath As String
        szFilePath = "..\..\..\..\EzSoftware\MotionDefault.mot"
        If AxmMotLoadParaAll(szFilePath) <> AXT_RT_SUCCESS Then
            MsgBox ("Mot File Not Found.")
        End If

        InitLibrary = True
    End Function

    ' ++ =======================================================================
    ' >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
    '  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
    '    제어할 수 있도록 합니다.
    '  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를
    '    100msec 주기로 동작시킵니다.
    ' --------------------------------------------------------------------------
    Private Function AddAxisInfo()
        Dim strData As String
        Dim dwModuleID, dwBoardNo, dwModulePos As Long
        Dim szModuleName As String
        Dim strModulename As String
        Dim lpBoadNo As Long
        Dim lpModulePosAs As Long
        Dim upModuleSubID As Long
        Dim szModuleDescription As String

        szModuleName = Space(50)
        szModuleDescription = Space(80)
        upModuleSubID = 0
        m_lAxis = 0
        m_lAxisCounts = 0
        ' ++ 유효한 전체 모션축수를 반환합니다.
        dwRetCode = AxmInfoGetAxisCount(m_lAxisCounts)
        If m_lAxisCounts < 1 Then
            AddAxisInfo = False
            Exit Function
        End If


        ' ++ 지정한 축의 정보를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxis, dwBoardNo, dwModulePos, m_dwModuleID)

        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i = 0 To (m_lAxisCounts - 1)
            ' ++ 지정한 축의 정보를 반환합니다.
            dwRetCode = AxmInfoGetAxis(i, lpBoadNo, lpModulePosAs, dwModuleID)
            If (dwRetCode = AXT_RT_SUCCESS) Then
                Select Case dwModuleID
                    Case AXT_SMC_4V04
                        strData = Format(i, "00") + "-[4V04]"
                    Case AXT_SMC_R1V04
                        strData = Format(i, "00") + "-[R1V04]"
                    Case AXT_SMC_2V04
                        strData = Format(i, "00") + "-[2V04]"
                    Case AXT_SMC_R1V04MLIIPM
                        strData = Format(i, "00") + "-[R1V04MLIIPM]"
                    Case AXT_SMC_R1V04PM2Q
                        strData = Format(i, "00") + "-[R1V04PM2Q]"
                    Case AXT_SMC_R1V04PM2QE
                        strData = Format(i, "00") + "-[R1V04PM2QE]"
                    Case AXT_SMC_R1V04MLIIIPM
                        strData = Format(i, "00") + "-[R1V04MLIIIPM]"
                    Case AXT_SMC_R1V04MLIISV
                        strData = Format(i, "00") + "-[R1V04MLIISV]"
                    Case AXT_SMC_R1V04A5
                        strData = Format(i, "00") + "-[R1V04A5]"
                    Case AXT_SMC_R1V04A4
                        strData = Format(i, "00") + "-[R1V04A4]"
                    Case AXT_SMC_R1V04SIIIHMIV
                        strData = Format(i, "00") + "-[R1V04SIIIHMIV]"
                    Case AXT_SMC_R1V04SIIIHMIV_R
                        strData = Format(i, "00") + "-[R1V04SIIIHMIV_R]"
                    Case AXT_SMC_R1V04MLIIISV
                        strData = Format(i, "00") + "-[R1V04MLIIISV]"
                    Case AXT_SMC_R1V04MLIIISV_MD
                        strData = Format(i, "00") + "-[R1V04MLIIISV_MD]"
                    Case AXT_SMC_R1V04MLIIIS7S
                        strData = Format(i, "00") + "-[R1V04MLIIIS7S]"
                    Case AXT_SMC_R1V04MLIIIS7W
                        strData = Format(i, "00") + "-[R1V04MLIIIS7W]"
                    Case AXT_ECAT_MOTION
                        dwRetCode = AxmInfoGetAxisEx(i, upModuleSubID, szModuleName, szModuleDescription)
                        strModulename = Replace(szModuleName, Chr(0), "")
                        strData = Format(i, "00") + "-[ECAT-" + strModulename + "]"
                End Select
                cboSelectAxis.AddItem (strData)
            End If
        Next i

        InitControl
        AddAxisInfo = True
    End Function

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl()
        cboSelectAxis.ListIndex = m_lAxis

        InitControl = True
    End Function

    ' ++ =======================================================================
    ' >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
    '  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는
    '    역할을하는 함수입니다.
    '  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
    '  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
    ' --------------------------------------------------------------------------
    Private Sub UpdateState()
        Dim dwPulse As Long
        Dim dUnit As Double
        Dim dMinVel As Double
        Dim dMaxVel As Double
        Dim dSWLimitP As Double
        Dim dSWLimitN As Double
        Dim dwMethod As Long
        Dim dwStopMode As Long
        Dim dwUse As Long
        Dim dwPositiveLevel As Long
        Dim dwNegativeLevel As Long
        Dim dwSWEnable As Long
        Dim dwSWStopMode As Long
        Dim dwSWRef As Long
        Dim dwLevel As Long
        Dim dwAbsRelMode As Long
        Dim dwProfileMode As Long
        Dim dwRetCode As Long
        Dim dwEncoderType As Long
        Dim dwHmDir As Long
        Dim dwHomeSignal As Long
        Dim dwZPhas As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Double
        Dim dInitPos As Double
        Dim dInitVel As Double
        Dim dInitAccel As Double
        Dim dInitDecel As Double
        Dim dVelFirst As Double
        Dim dVelSecond As Double
        Dim dVelThird As Double
        Dim dVelLast As Double
        Dim dAccFirst As Double
        Dim dAccSecond As Double
        Dim upStopMode As Long
        
        dwPulse = 1
        dUnit = 1#
        dMinVel = 1#
        dMaxVel = 100#
        dSWLimitP = 0#
        dSWLimitN = 0#
        dwMethod = 0
        dwStopMode = 0
        dwUse = 0
        dwPositiveLevel = 0
        dwNegativeLevel = 0
        dwSWEnable = 0
        dwSWStopMode = 0
        dwSWRef = 0
        dwLevel = 0
        dwAbsRelMode = 0
        dwProfileMode = 0
        dwRetCode = 0
        dwEncoderType = 0
        dwHmDir = 0
        dwHomeSignal = 0
        dwZPhas = 0
        dHomeClrTime = 1000#
        dHomeOffset = 0
        dInitPos = 100#
        dInitVel = 100#
        dInitAccel = 400#
        dInitDecel = 400#
        dVelFirst = 100#
        dvelsecound = 10#
        dVelThird = 5#
        dVelLast = 1#
        dAccFirst = 400#
        dAccSecond = 40#
        

        ' 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
        Select Case m_dwModuleID
            Case AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM
                cboPulse.Clear
                cboPulse.Enabled = True
                cboPulse.AddItem ("00:OneHighLowHigh")
                cboPulse.AddItem ("01:OneHighHighLow")
                cboPulse.AddItem ("02:OneLowLowHigh")
                cboPulse.AddItem ("03:OneLowHighLow")
                cboPulse.AddItem ("04:TwoCcwCwHigh")
                cboPulse.AddItem ("05:TwoCcwCwLow")
                cboPulse.AddItem ("06:TwoCwCcwHigh")
                cboPulse.AddItem ("07:TwoCwCcwLow")
                cboPulse.AddItem ("08:TwoPhase")
                cboPulse.AddItem ("09:TwoPhaseReverse")

                cboEncoder.Clear
                cboEncoder.Enabled = True
                cboEncoder.AddItem ("00:ObverseUpDownMode")
                cboEncoder.AddItem ("01:ObverseSqr1Mode")
                cboEncoder.AddItem ("02:ObverseSqr2Mode")
                cboEncoder.AddItem ("03:ObverseSqr4Mode")
                cboEncoder.AddItem ("04:ReverseUpDownMode")
                cboEncoder.AddItem ("05:ReverseSqr1Mode")
                cboEncoder.AddItem ("06:ReverseSqr2Mode")
                cboEncoder.AddItem ("07:ReverseSqr4Mode")

                cboAbsRel.Clear
                cboAbsRel.Enabled = True
                cboAbsRel.AddItem ("00:POS_ABS_MODE")
                cboAbsRel.AddItem ("01:POS_REL_MODE")

                cboProfile.Clear
                cboProfile.Enabled = True
                cboProfile.AddItem ("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("02:QUASI_S_CURVE_MODE")
                cboProfile.AddItem ("03:SYM_S_CURVE_MODE")
                cboProfile.AddItem ("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = True
                cboZPhaseLev.AddItem ("00:LOW")
                cboZPhaseLev.AddItem ("01:HIGH")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("00:LOW")
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("00:LOW")
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboStopMode.Clear
                cboStopMode.Enabled = True
                cboStopMode.AddItem ("00:EMERGENCY")
                cboStopMode.AddItem ("01:SLOWDOWN")

                cboStopLevel.Clear
                cboStopLevel.Enabled = True
                cboStopLevel.AddItem ("00:LOW")
                cboStopLevel.AddItem ("01:HIGH")
                cboStopLevel.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = True
                cboServoOn.AddItem ("00:LOW")
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = True
                cboAlarmReset.AddItem ("00:LOW")
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = True
                edtSLimitPosP.Enabled = True

                cboEncoderType.Clear
                cboEncoderType.Enabled = False
                cboEncoderType.AddItem ("00:INCREMENTAL")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")
                cboHomeSignal.AddItem ("05:EncodZPhase")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:LOW")
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeDir.Enabled = True
                cboHomeDir.AddItem ("00:(-)DIR_CCW")
                cboHomeDir.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:UNUSED")
                cboZPhaseUse.AddItem ("01:(+)DIR_CW")
                cboZPhaseUse.AddItem ("02:(-)DIR_CCW")

            Case AXT_SMC_R1V04A4
                cboPulse.Clear
                cboPulse.Enabled = False
                cboPulse.AddItem ("00:OneHighLowHigh")

                cboEncoder.Clear
                cboEncoder.Enabled = False
                cboEncoder.AddItem ("00:ObverseUpDownMode")

                cboAbsRel.Clear
                cboAbsRel.Enabled = True
                cboAbsRel.AddItem ("00:POS_ABS_MODE")
                cboAbsRel.AddItem ("01:POS_REL_MODE")

                cboProfile.Clear
                cboProfile.Enabled = True
                cboProfile.AddItem ("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("02:QUASI_S_CURVE_MODE")
                cboProfile.AddItem ("03:SYM_S_CURVE_MODE")
                cboProfile.AddItem ("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboStopMode.Clear
                cboStopMode.Enabled = True
                cboStopMode.AddItem ("00:EMERGENCY")
                cboStopMode.AddItem ("01:SLOWDOWN")

                cboStopLevel.Clear
                cboStopLevel.Enabled = True
                cboStopLevel.AddItem ("00:LOW")
                cboStopLevel.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Clear
                cboEncoderType.Enabled = False
                cboEncoderType.AddItem ("00:INCREMENTAL")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:LOW")
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:(-)DIR_CCW")
                cboHomeLevel.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.AddItem ("00:UNUSED")

            Case AXT_SMC_R1V04MLIIPM
                cboPulse.Clear
                cboPulse.Enabled = True
                cboPulse.AddItem ("00:OneHighLowHigh")
                cboPulse.AddItem ("06:TwoCwCcwHigh")

                cboEncoder.Clear
                cboEncoder.Enabled = False
                cboEncoder.AddItem ("00:ObverseUpDownMode")

                cboAbsRel.Clear
                cboAbsRel.Enabled = True
                cboAbsRel.AddItem ("00:POS_ABS_MODE")
                cboAbsRel.AddItem ("01:POS_REL_MODE")

                cboProfile.Clear
                cboProfile.Enabled = True
                cboProfile.AddItem ("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("02:QUASI_S_CURVE_MODE")
                cboProfile.AddItem ("03:SYM_S_CURVE_MODE")
                cboProfile.AddItem ("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = False
                cboAlarm.AddItem ("02:UNUSED")
                
                cboInp.Clear
                cboInp.Enabled = False
                cboInp.AddItem ("02:UNUSED")

                cboStopMode.Clear
                cboStopMode.Enabled = False
                cboStopMode.AddItem ("00:EMERGENCY")

                cboStopLevel.Clear
                cboStopLevel.Enabled = False
                cboStopLevel.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = False
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = False
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Clear
                cboEncoderType.Enabled = False
                cboEncoderType.AddItem ("00:INCREMENTAL")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = False
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = False
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:(-)DIR_CCW")
                cboHomeLevel.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.AddItem ("00:UNUSED")

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboPulse.Clear
                cboPulse.Enabled = False
                cboPulse.AddItem ("00:OneHighLowHigh")

                cboEncoder.Clear
                cboEncoder.Enabled = False
                cboEncoder.AddItem ("00:ObverseUpDownMode")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboStopMode.Clear
                cboStopMode.Enabled = False
                cboStopMode.AddItem ("00:EMERGENCY")

                cboStopLevel.Clear
                cboStopLevel.Enabled = False
                cboStopLevel.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")
                
                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Clear
                cboEncoderType.Enabled = True
                cboEncoderType.AddItem ("00:INCREMENTAL")
                cboEncoderType.AddItem ("01:ABSOLUTE")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = False
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:(-)DIR_CCW")
                cboHomeLevel.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:UNUSED")
                cboZPhaseUse.AddItem ("01:(+)DIR_CW")
                cboZPhaseUse.AddItem ("02:(-)DIR_CCW")

            Case AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W
                cboPulse.Clear
                cboPulse.Enabled = False
                cboPulse.AddItem ("00:OneHighLowHigh")

                cboEncoder.Clear
                cboEncoder.Enabled = False
                cboEncoder.AddItem ("00:ObverseUpDownMode")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.AddItem ("02:UNUSED")
                
                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("00:LOW")
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("00:LOW")
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboStopMode.Clear
                cboStopMode.Enabled = False
                cboStopMode.AddItem ("00:EMERGENCY")

                cboStopLevel.Clear
                cboStopLevel.Enabled = False
                cboStopLevel.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Clear
                cboEncoderType.Enabled = True
                cboEncoderType.AddItem ("00:INCREMENTAL")
                cboEncoderType.AddItem ("01:ABSOLUTE")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:LOW")
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:(-)DIR_CCW")
                cboHomeLevel.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:UNUSED")
                cboZPhaseUse.AddItem ("01:(+)DIR_CW")
                cboZPhaseUse.AddItem ("02:(-)DIR_CCW")

            Case AXT_ECAT_MOTION
                cboPulse.Clear
                cboPulse.Enabled = False
                cboPulse.AddItem ("00:OneHighLowHigh")

                cboEncoder.Clear
                cboEncoder.Enabled = False
                cboEncoder.AddItem ("00:ObverseUpDownMode")

                cboAbsRel.Clear
                cboAbsRel.Enabled = True
                cboAbsRel.AddItem ("00:POS_ABS_MODE")
                cboAbsRel.AddItem ("01:POS_REL_MODE")

                cboProfile.Clear
                cboProfile.Enabled = True
                cboProfile.AddItem ("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.AddItem ("02:QUASI_S_CURVE_MODE")
                cboProfile.AddItem ("03:SYM_S_CURVE_MODE")
                cboProfile.AddItem ("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Clear
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("00:LOW")
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")
                cboInp.AddItem ("03:USED")

                cboStopMode.Clear
                cboStopMode.Enabled = True
                cboStopMode.AddItem ("00:EMERGENCY")
                cboStopMode.AddItem ("01:SLOWDOWN")

                cboStopLevel.Clear
                cboStopLevel.Enabled = True
                cboStopLevel.AddItem ("00:LOW")
                cboStopLevel.AddItem ("01:HIGH")
                cboStopLevel.AddItem ("02:UNUSED")
                cboStopLevel.AddItem ("03:USED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")
                cboELimitN.AddItem ("03:USED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")
                cboELimitP.AddItem ("03:USED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False
                
                cboEncoderType.Clear
                cboEncoderType.Enabled = False
                cboEncoderType.AddItem ("00:INCREMENTAL")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")
                cboHomeSignal.AddItem ("05:EncodZPhase")

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:LOW")
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeDir.Clear
                cboHomeDir.Enabled = True
                cboHomeDir.AddItem ("00:(-)DIR_CCW")
                cboHomeDir.AddItem ("01:(+)DIR_CW")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:UNUSED")
                cboZPhaseUse.AddItem ("01:(+)DIR_CW")
                cboZPhaseUse.AddItem ("02:(-)DIR_CCW")

            Case Else

        End Select

        ' ++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
        dwRetCode = AxmMotGetPulseOutMethod(m_lAxis, dwMethod)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwMethod = OneHighLowHigh
        End If
        dwRetCode = ConvertAxmToCombo(cboPulse, dwMethod)

        ' ++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
        dwRetCode = AxmMotGetEncInputMethod(m_lAxis, dwMethod)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwMethod = ObverseUpDownMode
        End If
        dwRetCode = ConvertAxmToCombo(cboEncoder, dwMethod)

        ' ++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetServoAlarm(m_lAxis, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboAlarm, dwUse)

        ' ++ 지정 축의 최저속도를 확인합니다.
        dwRetCode = AxmMotGetMinVel(m_lAxis, dMinVel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dMinVel = 1#
        End If
        edtMinVel.Text = Format(dMinVel, "0.000")

        ' ++ 지정 축의 최고속도를 확인합니다.
        dwRetCode = AxmMotGetMaxVel(m_lAxis, dMaxVel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dMaxVel = 1#
        End If
        edtMaxVel.Text = Format(dMaxVel, "0.000")

        ' ++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
        dwRetCode = AxmMotGetMoveUnitPerPulse(m_lAxis, dUnit, dwPulse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dUnit = 1#
            dwPulse = 1
        End If
        edtMoveUnit.Text = Format(dUnit, "0.000")
        edtMovePulse.Text = Format(dwPulse, "0")

        ' ++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmSignalGetZphaseLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboZPhaseLev, dwLevel)

        ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetInpos(m_lAxis, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboInp, dwUse)

        ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetStop(m_lAxis, dwStopMode, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwStopMode = UNUSED
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboStopMode, dwStopMode)
        dwRetCode = ConvertAxmToCombo(cboStopLevel, dwLevel)

        ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxis, upStopMode, dwPositiveLevel, dwNegativeLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwPositiveLevel = dwNegativeLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboELimitP, dwPositiveLevel)
        dwRetCode = ConvertAxmToCombo(cboELimitN, dwNegativeLevel)

        ' ++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoOnLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboServoOn, dwLevel)

        ' ++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboAlarmReset, dwLevel)

        ' ++ 지정 축의 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxis, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwSWEnable = DISABLE
            dwSWStopMode = EMERGENCY_STOP
            dwSWRef = UNUSED
        End If
        cboSLimitEnable.Clear
        cboSLimitEnable.Enabled = True
        cboSLimitEnable.AddItem ("00:DISABLE")
        cboSLimitEnable.AddItem ("01:ENABLE")
        cboSLimitStopMode.Clear
        cboSLimitStopMode.Enabled = True
        cboSLimitStopMode.AddItem ("00:EMERGENCY_STOP")
        cboSLimitStopMode.AddItem ("01:SLOWDOWN_STOP")
        cboSLimitSelect.Clear
        cboSLimitSelect.Enabled = True
        cboSLimitSelect.AddItem ("00:COMMAND")
        cboSLimitSelect.AddItem ("01:ACTUAL")
        dwRetCode = ConvertAxmToCombo(cboSLimitEnable, dwSWEnable)
        dwRetCode = ConvertAxmToCombo(cboSLimitStopMode, dwSWStopMode)
        dwRetCode = ConvertAxmToCombo(cboSLimitSelect, dwSWRef)

        edtSLimitPosP.Text = Format(dSWLimitP, "0.000")
        edtSLimitPosN.Text = Format(dSWLimitN, "0.000")

        ' ++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
        dwRetCode = AxmMotGetAbsRelMode(m_lAxis, dwAbsRelMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwAbsRelMode = POS_ABS_MODE
        End If
        dwRetCode = ConvertAxmToCombo(cboAbsRel, dwAbsRelMode)

        ' ++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
        dwRetCode = AxmMotGetProfileMode(m_lAxis, dwProfileMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwProfileMode = SYM_TRAPEZOIDE_MODE
        End If
        dwRetCode = ConvertAxmToCombo(cboProfile, dwProfileMode)

        ' ++ 지정한 축에 설정된 Encoder Type을 확인합니다.
        dwRetCode = AxmSignalGetEncoderType(m_lAxis, dwEncoderType)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwEncoderType = 0
        End If
        dwRetCode = ConvertAxmToCombo(cboEncoderType, dwEncoderType)

        ' ++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
        dwRetCode = AxmHomeGetSignalLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboHomeLevel, dwLevel)

        ' ++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
        dwRetCode = AxmHomeGetMethod(m_lAxis, dwHmDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwHmDir = DIR_CCW
            dwHomeSignal = HomeSensor
            dwZPhas = UNUSED
            dHomeClrTime = 1000#
            dHomeOffset = 0#
        End If
        dwRetCode = ConvertAxmToCombo(cboHomeDir, dwHmDir)
        dwRetCode = ConvertAxmToCombo(cboHomeSignal, dwHomeSignal)
        dwRetCode = ConvertAxmToCombo(cboZPhaseUse, dwZPhas)
        edtHomeClrTime.Text = Format(dHomeClrTime, "0.000")
        edtHomeOffset.Text = Format(dHomeOffset, "0.000")

        ' ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
        dwRetCode = AxmHomeGetVel(m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dVelFirst = 100#
            dVelSecond = 100#
            dVelThird = 20#
            dVelLast = 1#
            dAccFirst = 400#
            dAccSecond = 400#
        End If
        edtVelFirst.Text = Format(dVelFirst, "0.000")
        edtVelSecond.Text = Format(dVelSecond, "0.000")
        edtVelThird.Text = Format(dVelThird, "0.000")
        edtVelLast.Text = Format(dVelLast, "0.000")
        edtAccFirst.Text = Format(dAccFirst, "0.000")
        edtAccSecond.Text = Format(dAccSecond, "0.000")

        ' ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
        dwRetCode = AxmMotGetParaLoad(m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dInitPos = 1000#
            dInitVel = 200#
            dInitAccel = 400#
            dInitDecel = 400#
        End If
        edtPosition.Text = Format(dInitPos, "0.000")
        edtVelocity.Text = Format(dInitVel, "0.000")
        edtAccel.Text = Format(dInitAccel, "0.000")
        edtDecel.Text = Format(dInitDecel, "0.000")

    End Sub

    ' ++ =======================================================================
    ' >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
    '    Item과 일치하는 Item을 찾아 선택하는 함수.
    '  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
    '    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
    '  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
    ' --------------------------------------------------------------------------
    Private Function ConvertAxmToCombo(ByRef pCboItem As ComboBox, ByVal dwCurData As Long) As Long
        Dim i As Integer

        If pCboItem Is Nothing Then
            ConvertAxmToCombo = 0
            Exit Function
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.ListCount
        If dwCount = 0 Then
            ConvertAxmToCombo = 0
            Exit Function
        End If

        For i = 0 To (dwCount - 1)
            strText = pCboItem.List(i)
            dwSelData = Val(strText)
            If dwSelData = dwCurData Then
                pCboItem.ListIndex = i
                ConvertAxmToCombo = i
                Exit Function
            End If
        Next

        pCboItem.ListIndex = 0
        ConvertAxmToCombo = 0
    End Function

    ' ++ =======================================================================
    ' >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
    '    Item과 일치하는 Item을 찾아 선택하는 함수.
    '  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
    '    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
    '  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
    ' --------------------------------------------------------------------------
    Private Function ConvertComboToAxm(ByRef pCboItem As ComboBox) As Long
        If pCboItem Is Nothing Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.ListCount
        If dwCount = 0 Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        dwSelData = pCboItem.ListIndex
        If dwSelData < 0 Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        strText = pCboItem.List(dwSelData)
        ConvertComboToAxm = Val(strText)
    End Function

