VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "GantryMotion"
   ClientHeight    =   7200
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6975
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7200
   ScaleWidth      =   6975
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame5 
      Caption         =   "< Gantry Enable >"
      Height          =   1140
      Left            =   60
      TabIndex        =   48
      Top             =   5940
      Width           =   6870
      Begin VB.CheckBox chkGantryEnable 
         Caption         =   "Gantry Enable"
         Height          =   330
         Left            =   5070
         Style           =   1  'Graphical
         TabIndex        =   56
         Top             =   690
         Width           =   1635
      End
      Begin VB.ComboBox cboGantryHmSlaveUse 
         Height          =   315
         Left            =   5070
         TabIndex        =   54
         Top             =   255
         Width           =   1665
      End
      Begin VB.TextBox edtGantryHmRange 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1620
         TabIndex        =   53
         Text            =   "100.0"
         Top             =   645
         Width           =   1575
      End
      Begin VB.TextBox edtGantryHmOffset 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1620
         TabIndex        =   52
         Text            =   "0.0"
         Top             =   255
         Width           =   1575
      End
      Begin VB.Line Line2 
         X1              =   5070
         X2              =   6705
         Y1              =   630
         Y2              =   630
      End
      Begin VB.Line Line1 
         X1              =   3450
         X2              =   3450
         Y1              =   225
         Y2              =   990
      End
      Begin VB.Label Label18 
         Caption         =   "Slave Home Use : "
         Height          =   240
         Left            =   3660
         TabIndex        =   55
         Top             =   300
         Width           =   1410
      End
      Begin VB.Label Label17 
         Caption         =   "Slave Home Range: "
         Height          =   240
         Left            =   165
         TabIndex        =   50
         Top             =   690
         Width           =   1455
      End
      Begin VB.Label Label12 
         Caption         =   "Slave Home Offset: "
         Height          =   240
         Left            =   165
         TabIndex        =   49
         Top             =   360
         Width           =   1410
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Home Search >"
      Height          =   1140
      Left            =   60
      TabIndex        =   40
      Top             =   4800
      Width           =   6870
      Begin ComctlLib.ProgressBar prgHomeRate 
         Height          =   300
         Left            =   2970
         TabIndex        =   51
         Top             =   645
         Width           =   1965
         _ExtentX        =   3466
         _ExtentY        =   529
         _Version        =   327682
         Appearance      =   1
      End
      Begin VB.TextBox stcHomeStepSub 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   315
         Left            =   2295
         TabIndex        =   47
         Text            =   "100"
         Top             =   660
         Width           =   630
      End
      Begin VB.CommandButton btnHomeStop 
         Caption         =   "Home Stop"
         Height          =   285
         Left            =   5055
         TabIndex        =   44
         Top             =   660
         Width           =   1650
      End
      Begin VB.CommandButton btnHomeStart 
         Caption         =   "Home Start"
         Height          =   285
         Left            =   5055
         TabIndex        =   43
         Top             =   300
         Width           =   1650
      End
      Begin VB.TextBox stcHomeStepMain 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   315
         Left            =   1620
         TabIndex        =   42
         Text            =   "100"
         Top             =   660
         Width           =   630
      End
      Begin VB.TextBox stcHomeResult 
         Alignment       =   2  'Center
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   315
         Left            =   1620
         TabIndex        =   41
         Text            =   " [FFH] HOME_ERR_UNKNOWN"
         Top             =   300
         Width           =   3300
      End
      Begin VB.Label Label20 
         Caption         =   "Home Step/Rate  : "
         Height          =   240
         Left            =   165
         TabIndex        =   46
         Top             =   690
         Width           =   1410
      End
      Begin VB.Label Label22 
         Caption         =   "Home Result         : "
         Height          =   240
         Left            =   165
         TabIndex        =   45
         Top             =   360
         Width           =   1410
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Position Move >"
      Height          =   2175
      Left            =   60
      TabIndex        =   21
      Top             =   2625
      Width           =   6870
      Begin VB.Timer m_timerHomeInfo 
         Interval        =   200
         Left            =   5580
         Top             =   150
      End
      Begin VB.CommandButton btnJogMoveP 
         Caption         =   "Move Jog ( + )"
         Height          =   285
         Left            =   5055
         TabIndex        =   39
         Top             =   1380
         Width           =   1665
      End
      Begin VB.CommandButton btnJogMoveN 
         Caption         =   "Move Jog ( - )"
         Height          =   285
         Left            =   5040
         TabIndex        =   38
         Top             =   1725
         Width           =   1665
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   35
         Text            =   "400.0"
         Top             =   1680
         Width           =   2355
      End
      Begin VB.Timer m_timerDisplay 
         Interval        =   100
         Left            =   5115
         Top             =   150
      End
      Begin VB.OptionButton rdoAbs 
         Caption         =   "[00] Absolute"
         Height          =   285
         Left            =   1680
         TabIndex        =   28
         Top             =   300
         Width           =   1545
      End
      Begin VB.OptionButton rdoRel 
         Caption         =   "[01] Relative"
         Height          =   285
         Left            =   3270
         TabIndex        =   27
         Top             =   315
         Width           =   1545
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   26
         Text            =   "100.0"
         Top             =   690
         Width           =   2355
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   25
         Text            =   "100.0"
         Top             =   1020
         Width           =   2355
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   24
         Text            =   "400.0"
         Top             =   1350
         Width           =   2355
      End
      Begin VB.CommandButton btnMovePos 
         Caption         =   "Move Target"
         Height          =   285
         Left            =   5055
         TabIndex        =   23
         Top             =   660
         Width           =   1665
      End
      Begin VB.CommandButton btnMoveStop 
         Caption         =   "Move SStop"
         Height          =   285
         Left            =   5055
         TabIndex        =   22
         Top             =   1005
         Width           =   1665
      End
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   6045
         Top             =   120
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Label Label11 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4065
         TabIndex        =   37
         Top             =   1725
         Width           =   825
      End
      Begin VB.Label Label8 
         Caption         =   "Move Deceleration: "
         Height          =   240
         Left            =   150
         TabIndex        =   36
         Top             =   1710
         Width           =   1410
      End
      Begin VB.Label Label16 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4065
         TabIndex        =   34
         Top             =   1395
         Width           =   825
      End
      Begin VB.Label Label9 
         Caption         =   "Target Position      : "
         Height          =   240
         Left            =   165
         TabIndex        =   33
         Top             =   720
         Width           =   1410
      End
      Begin VB.Label Label10 
         Caption         =   "Unit"
         Height          =   195
         Left            =   4065
         TabIndex        =   32
         Top             =   735
         Width           =   480
      End
      Begin VB.Label Label13 
         Caption         =   "Move Velocity       : "
         Height          =   240
         Left            =   165
         TabIndex        =   31
         Top             =   1050
         Width           =   1410
      End
      Begin VB.Label Label14 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4065
         TabIndex        =   30
         Top             =   1065
         Width           =   780
      End
      Begin VB.Label Label15 
         Caption         =   "Move Acceleration: "
         Height          =   240
         Left            =   150
         TabIndex        =   29
         Top             =   1380
         Width           =   1410
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   45
      TabIndex        =   7
      Top             =   0
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5055
         TabIndex        =   9
         Top             =   195
         Width           =   1665
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1620
         TabIndex        =   8
         Top             =   195
         Width           =   3315
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No       : "
         Height          =   300
         Left            =   165
         TabIndex        =   10
         Top             =   255
         Width           =   1590
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1995
      Left            =   45
      TabIndex        =   0
      Top             =   630
      Width           =   6885
      Begin VB.CheckBox chkHomeStateSL 
         Caption         =   "Home State"
         Height          =   285
         Left            =   3315
         TabIndex        =   20
         Top             =   1620
         Width           =   1305
      End
      Begin VB.CheckBox chkHomeStateMa 
         Caption         =   "Home State"
         Height          =   195
         Left            =   1620
         TabIndex        =   19
         Top             =   1665
         Width           =   1395
      End
      Begin VB.TextBox stcCmdVelSL 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   3315
         TabIndex        =   15
         Text            =   "0.000"
         Top             =   1230
         Width           =   1575
      End
      Begin VB.TextBox stcCmdVelMa 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   14
         Text            =   "0.000"
         Top             =   1245
         Width           =   1575
      End
      Begin VB.TextBox stcActPosSL 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   3315
         TabIndex        =   13
         Text            =   "0.000"
         Top             =   840
         Width           =   1575
      End
      Begin VB.TextBox stcActPosMa 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   12
         Text            =   "0.000"
         Top             =   855
         Width           =   1575
      End
      Begin VB.TextBox stcCmdPosSL 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   3315
         TabIndex        =   11
         Text            =   "0.000"
         Top             =   465
         Width           =   1575
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   315
         Left            =   5040
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   1245
         Width           =   1680
      End
      Begin VB.CommandButton btnPosClear 
         Caption         =   "Position Clear"
         Height          =   750
         Left            =   5040
         TabIndex        =   2
         Top             =   450
         Width           =   1680
      End
      Begin VB.TextBox stcCmdPosMa 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   1
         Text            =   "0.000"
         Top             =   480
         Width           =   1575
      End
      Begin VB.Label stcGantryState 
         Alignment       =   2  'Center
         Caption         =   "∞"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   390
         Left            =   3195
         TabIndex        =   18
         Top             =   135
         Width           =   165
      End
      Begin VB.Label stcAxisNoSl 
         Caption         =   "SI Axis 00"
         Height          =   165
         Left            =   3705
         TabIndex        =   17
         Top             =   210
         Width           =   1395
      End
      Begin VB.Label stcAxisNoMa 
         Caption         =   "Ma Axis 00"
         Height          =   180
         Left            =   1995
         TabIndex        =   16
         Top             =   210
         Width           =   1095
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel        : "
         Height          =   225
         Left            =   165
         TabIndex        =   6
         Top             =   1260
         Width           =   1515
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos      :"
         Height          =   270
         Left            =   165
         TabIndex        =   5
         Top             =   900
         Width           =   1620
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos       : "
         Height          =   225
         Left            =   165
         TabIndex        =   4
         Top             =   540
         Width           =   1545
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' GantryMotion.vb : implementation file
' *********************************************************************************
' >> [일자]: 2015.12.02
' >> [개요]: 이 예제는 겐트리 함수들의 사용법을 익히고 겐트리 기구물에서의
'    원점검색 및 Slave축 Offset 설정 방법등에 대해 학습하는 예제입니다.
' >> [중요]: 겐트리 Slave축 Offset설정방법
'     1) AxmGantrySetEnable함수의 uSlHomeUse인자를 2로 설정해서 원점검색을 합니다.
'     2) 원점검색이 정상적으로 완료되면 Slave축 원점위치에서 Master축 원점
'        위치까지의 차이값이(Offset) Master축 지령위치가 됩니다.
'     3) AxmGantrySetEnable함수의 uSlHomeUse인자를 1로, dSlaveHmOffset인자에
'        위에서 측정한 Master축 지령위치값에 부호를 변경한 후 설정하면 됩니다.
' *********************************************************************************

    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101
    Const GANTRY_SLAVE_HM_DONE As Integer = 0
    Const GANTRY_SLAVE_HM_BOTH As Integer = 1
    Const GANTRY_SLAVE_HM_EACH As Integer = 2

    Private m_lAxisNo As Long
    Private m_lAxisNoMa As Long
    Private m_lAxisNoSl As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_dwOldResult As Long
    Private m_dOldCmdPosMa As Double
    Private m_dOldActPosMa As Double
    Private m_dOldCmdVelMa As Double
    Private m_dOldCmdPosSl As Double
    Private m_dOldActPosSl As Double

    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisNoMa = -1
        m_lAxisNoSl = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
        m_dwOldResult = HOME_ERR_UNKNOWN
        m_dOldCmdPosMa = 0#
        m_dOldActPosMa = 0#
        m_dOldCmdVelMa = 0#
        m_dOldCmdPosSl = 0#
        m_dOldActPosSl = 0#
        m_dOldCmdVelSl = 0#
    
        InitLibrary               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' ++ =======================================================================
    ' >> cboSelAxis_Click() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelAxis_Click()
        Dim lpBoardNo As Long
        Dim lpModulePos As Long
        
        m_lAxisNo = cboSelAxis.ListIndex
        
        m_lAxisNoMa = (m_lAxisNo \ 2) * 2   ' 선택된 축번호로 겐트리 Master축 번호 생성
        m_lAxisNoSl = m_lAxisNoMa + 1   ' 선택된 축번호로 겐트리 Slave축 번호 생성

        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, lpBoardNo, lpModulePos, m_dwModuleId)

        UpdateState       ' 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' ++ =======================================================================
    ' >> btnLoadFile_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '   - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '   - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
    '       설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLoadFile_Click()
        Dim szFileName As String
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        OpenFileDialog1.FileName = "*.mot"
        OpenFileDialog1.FilterIndex = 2

        OpenFileDialog1.Action = 1
        szFileName = OpenFileDialog1.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox ("File load fail!")
            End If
        End If

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> btnPosClear_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
    '    설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click()
        Dim dwState As Long
        Dim dwSlHomeUse As Long
        Dim dwSlOffset As Double
        Dim dwSlIORange As Double
        
        dwState = DISABLE
        ' ++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
        dwRetCode = AxmGantryGetEnable(m_lAxisNoMa, dwSlHomeUse, dwSlOffset, dwSlIORange, dwState)
        If dwState = ENABLE Then
            ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            dwRetCode = AxmStatusSetPosMatch(m_lAxisNoMa, 0#)
            dwRetCode = AxmStatusSetPosMatch(m_lAxisNoSl, 0#)
        Else
            dwRetCode = AxmStatusSetPosMatch(m_lAxisNo, 0#)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 chkServoOn_Click 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_Click()
        Dim dwOnOff As Long
        Dim dwState As Long
        Dim dwSlHomeUse As Long
        Dim dwSlOffset As Double
        Dim dwSlIORange As Double
        
        dwOnOff = 0
        dwState = DISABLE

        dwOnOff = IIf(chkServoOn.Value, 1, 0)
        ' ++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
        dwRetCode = AxmGantryGetEnable(m_lAxisNoMa, dwSlHomeUse, dwSlOffset, dwSlIORange, dwState)
        If dwState = ENABLE Then
            ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            dwRetCode = AxmSignalServoOn(m_lAxisNoMa, dwOnOff)
            dwRetCode = AxmSignalServoOn(m_lAxisNoSl, dwOnOff)
        Else
            dwRetCode = AxmSignalServoOn(m_lAxisNo, dwOnOff)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> rdoAbs_Click(...) : "Absolute"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 좌표계를 절대좌표계로 설정합니다.
    '  - Ex) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
    ' --------------------------------------------------------------------------
    Private Sub rdoAbs_Click()
        Dim dwRetCode As Long
        dwRetCode = 0

        ' ++ 지정 축의 구동 좌표계를 설정합니다.
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_ABS_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> rdoRel_Click(...) : "Relative"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 좌표계를 상대좌표계로 설정합니다.
    '  - Ex) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
    ' --------------------------------------------------------------------------
    Private Sub rdoRel_Click()
        Dim dwRetCode As Long
        dwRetCode = 0

        ' ++ 지정 축의 구동 좌표계를 설정합니다.
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMovePos_Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
    '  - 지정한 축이 겐트리 축으로 활성화되어 있으면 두축이 동기되어 구동됩니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
    '    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew)
    '    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMovePos_Click()
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도로 모션구동합니다.
        dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseDown(...) : "Jog Move(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim dJogVel, dJogAcc, dJogDec As Double
        
        dwRetCode = 0

        dJogVel = Math.Abs(Val(edtMoveVel.Text))
        dJogAcc = Math.Abs(Val(edtMoveAcc.Text))
        dJogDec = Math.Abs(Val(edtMoveDec.Text))

        ' ++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseDown(...) : "Jog Move(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim dJogVel, dJogAcc, dJogDec As Double
        
        dwRetCode = 0

        dJogVel = Math.Abs(Val(edtMoveVel.Text))
        dJogAcc = Math.Abs(Val(edtMoveAcc.Text))
        dJogDec = Math.Abs(Val(edtMoveDec.Text))

        ' ++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseUp(...) : "Jog Move(+)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop (m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseUp(...) : "Jog Move(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop (m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 구동정지 함수를 호출하여 구동을 종료합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click()
        ' ++ 지정한 축의 모션구동(Jog구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop (m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStart_Click() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 원점검색을 시작합니다.
    ' ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 두축 모두 서보온이
    '    되어있지 않을 경우 AxmGantrySetEnable 함수로 겐트리 기능을 활성활 할 때 설정한
    '    dwSlaveHmUse의 값에 따라 원점검색이 완료되지 않을 수 있습니다.
    ' ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 AxmGantrySetEnable
    '    함수로 겐트리 기능을 활성활 할 때 설정한 dwSlaveHmUse의 값에 따라 원점검색
    '    방법이 달라집니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStart_Click()
        Dim dwRetCode As Long
        ' 원점검색 레벨 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' - dwLevel: [00]LOW, [01]HIGH
        ' > AxmHomeSetSignalLevel(m_lAxisNoMa, dwLevel)
        ' > AxmHomeSetSignalLevel(m_lAxisNoSl, dwLevel)

        ' 원점검색 방법설정 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' - lHomeDir     : [00]DIR_CCW, [01]DIR_CW
        ' - dwHomeSignal : [00]PosEndLimit, [01]NegEndLimit, [04]HomeSensor
        ' - dwZPhaseUse  : [00]Not Use, [01]Home Dir, [02]Not Home Dir
        ' > AxmHomeSetMethod(m_lAxisNoMa, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        ' > AxmHomeSetMethod(m_lAxisNoSl, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)

        ' 원점검색 속도설정 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' > AxmHomeSetVel(m_lAxisNoMa, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        ' > AxmHomeSetVel(m_lAxisNoSl, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)

        ' ++ 지정한 축의 원점검색 구동을 시작합니다.
        dwRetCode = AxmHomeSetStart(m_lAxisNo)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetStart return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStop_Click() : "Home Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 구동정지 함수를 호출하여 원점검색구동을 종료합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStop_Click()
        ' ++ 지정한 축의 원점검색구동(모션구동/Jog구동)을 감속정지합니다.
        AxmMoveSStop (m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> chkGantryEnable_Click() : "Gantry Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 겐트리 기능을 활성화 합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkGantryEnable_Click()
        Dim dwSlaveHmUse, dwRetCode As Long
        Dim dSlaveHmOffset, dSlaveHmRange As Double
        Dim strData As String

        If chkGantryEnable.Value Then
            dwSlaveHmUse = ConvertComboToAxm(cboGantryHmSlaveUse)
            dSlaveHmOffset = edtGantryHmOffset.Text
            dSlaveHmRange = edtGantryHmRange.Text

            ' ++ 지정한 Master축과 Slave축으로 겐트리 기능을 활성화 시킵니다.
            dwRetCode = AxmGantrySetEnable(m_lAxisNoMa, m_lAxisNoSl, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmGantrySetEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        Else
            ' ++ 지정한 Master축과 Slave축으로 겐트리 기능을 비활성화 시킵니다.
            dwRetCode = AxmGantrySetDisable(m_lAxisNoMa, m_lAxisNoSl)
            If dwRetCode <> AXT_RT_SUCCESS Then
                chkGantryEnable.Value = True
                strData = "AxmGantrySetDisable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If

    End Sub

    ' ++ =======================================================================
    ' >> m_timerDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerDisplay_Timer()
        Dim dwState As Long
        Dim dCmdPos As Double
        Dim dActPos As Double
        Dim dCmdVel As Double
        Dim dwSlHomeUse As Long
        Dim dwSlOffset As Double
        Dim dwSlIORange As Double
        
        dCmdPos = 0#
        dActPos = 0#
        dcmdvle = 0#

        ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
        dwRetCode = AxmStatusGetCmdPos(m_lAxisNoMa, dCmdPos)
        If m_dOldCmdPosMa <> dCmdPos Then
            stcCmdPosMa.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPosMa = dCmdPos
        End If
        dwRetCode = AxmStatusGetCmdPos(m_lAxisNoSl, dCmdPos)
        If m_dOldCmdPosSl <> dCmdPos Then
            stcCmdPosSL.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPosSl = dCmdPos
        End If

        ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
        dwRetCode = AxmStatusGetActPos(m_lAxisNoMa, dActPos)
        If m_dOldActPosMa <> dActPos Then
            stcActPosMa.Text = Format(dActPos, "0.000")
            m_dOldActPosMa = dActPos
        End If
        dwRetCode = AxmStatusGetActPos(m_lAxisNoSl, dActPos)
        If m_dOldActPosSl <> dActPos Then
            stcActPosSL.Text = Format(dActPos, "0.000")
            m_dOldActPosSl = dActPos
        End If

        ' ++ 지정한 축의 구동 속도를 반환합니다.
        dwRetCode = AxmStatusReadVel(m_lAxisNoMa, dCmdVel)
        If m_dOldCmdVelMa <> dCmdVel Then
            stcCmdVelMa.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVelMa = dCmdVel
        End If
        dwRetCode = AxmStatusReadVel(m_lAxisNoSl, dCmdVel)
        If m_dOldCmdVelSl <> dCmdVel Then
            stcCmdVelSL.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVelSl = dCmdVel
        End If

        ' ++ 지정한 축에 겐트리 기능이 활성화되었는지 확인합니다.
        dwRetCode = AxmGantryGetEnable(m_lAxisNoMa, dwSlHomeUse, dwSlOffset, dwSlIORange, dwState)
        If dwState = ENABLE Then
            stcGantryState.Caption = "∞"
        Else
            stcGantryState.Caption = " "
        End If

    End Sub

    ' ++ =======================================================================
    ' >> m_timerHomeInfo_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 호밍 작업 정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerHomeInfo_Timer()
        Dim dwRetCode As Long
        Dim dwState As Long
        Dim dwStepMain As Long
        Dim dwStepSub As Long
        
        dwRetCode = 0
        dwState = 0
        dwStepMain = 0
        dwStepSub = 0
        
        ' ++ 지정한 축의 원점신호의 상태를 확인합니다.
        dwRetCode = AxmHomeReadSignal(m_lAxisNoMa, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeStateMa.Value = dwState
        End If
        dwRetCode = AxmHomeReadSignal(m_lAxisNoSl, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeStateSL.Value = dwState
        End If

        ' ++ 지정한 축의 원점검색 결과를 확인합니다.
        dwRetCode = AxmHomeGetResult(m_lAxisNoMa, dwState)
        If m_dwOldResult <> dwState Then
            stcHomeResult.Text = TranslateHomeResult(dwState)
            m_dwOldResult = dwState
        End If

        ' ++ 지정한 축의 원점검색 진행율을 확인합니다.
        dwRetCode = AxmHomeGetRate(m_lAxisNoMa, dwStepMain, dwStepSub)
        If dwRetCode = AXT_RT_SUCCESS Then
            If Val(stcHomeStepMain.Text) <> dwStepMain Then
                stcHomeStepMain.Text = dwStepMain
            End If
            If Val(stcHomeStepSub.Text) <> dwStepSub Then
                stcHomeStepSub.Text = dwStepSub
            End If
            prgHomeRate.Value = dwStepSub
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
        If AxlOpen(7) <> AXT_RT_SUCCESS Then
            MsgBox ("AxlOpen Fail...")
            InitLibrary = False
            Exit Function
        End If

        Dim szFilePath As String
        szFilePath = "..\..\..\..\EzSoftware\MotionDefault.mot"
        If AxmMotLoadParaAll(szFilePath) <> AXT_RT_SUCCESS Then
            Dim res As Integer
            res = MsgBox("Mot File Not Found.", 1)
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
    Private Function AddAxisInfo() As Boolean
        Dim strData As String
        Dim dwModuleID, dwBoardNo, dwModulePos As Long
        Dim szModuleName As String
        Dim strModuleName As String
        Dim szModuleDescription As String
        Dim upModuleSubID As Long

        ' ++ 유효한 전체 모션축수를 반환합니다.
        dwRetCode = AxmInfoGetAxisCount(m_lAxisCount)
        If m_lAxisCount < 1 Then
            AddAxisInfo = False
            Exit Function
        End If

        szModuleName = Space(50)
        szModuleDescription = Space(80)
        m_lAxisNo = 0
        m_lAxisNoMa = 0
        m_lAxisNoSl = -1
        ' ++ 지정한 축의 정보를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNoMa, dwBoardNo, dwModulePos, m_dwModuleId)

        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i = 0 To (m_lAxisCount - 1)
            ' ++ 지정한 축의 정보를 반환합니다.
            dwRetCode = AxmInfoGetAxis(i, lpBoardNo, lpModulePosAs, dwModuleID)
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
                    strModuleName = Replace(szModuleName, Chr(0), "")
                    strData = Format(i, "00") + "-[ECAT-" + strModuleName + "]"
                Case Else
                    strData = Format(i, "00") + "-[Unknown]"
            End Select

            cboSelAxis.AddItem (strData)

        Next

        InitControl
        AddAxisInfo = True
    End Function

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl()
        cboGantryHmSlaveUse.AddItem ("00: NONE")
        cboGantryHmSlaveUse.AddItem ("01: BOTH")
        cboGantryHmSlaveUse.AddItem ("02: EACH")
            
        cboSelAxis.ListIndex = m_lAxisNo

        InitControl = True
    End Function

    ' ++ =======================================================================
    ' >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
    '  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는
    '    역할을하는 함수입니다.
    '  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
    '  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
    ' --------------------------------------------------------------------------
    Private Function UpdateState()
        If m_lAxisCount < 1 Then
            UpdateState = False
            Exit Function
        End If

        Dim dwAbsRelMode As Long
        Dim dwOnOff As Long
        Dim dwSlaveHmUse As Long
        Dim dwGantryOn
        Dim dSlaveHmOffset As Double
        Dim dSlaveHmRange As Double
        
        dwAbsRelMode = POS_ABS_MODE
        dwOnOff = 0
        dwSlaveHmUse = 0
        dwGantryOn = DIABLE
        dSlaveHmOffset = 0
        dSlaveHmRange = 1#

        ' ++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
        dwRetCode = AxmMotGetAbsRelMode(m_lAxisNo, dwAbsRelMode)
        If dwAbsRelMode = POS_ABS_MODE Then
            rdoAbs.Value = True
        Else
            rdoRel.Value = True
        End If

        ' ++ 지정한 축이 제어가 가능한 상태인지 확인합니다.
        If AxmInfoGetAxisStatus(m_lAxisNoSl) = AXT_RT_SUCCESS Then
            stcCmdPosSL.Enabled = True
            stcActPosSL.Enabled = True
            stcCmdVelSL.Enabled = True
        Else
            stcCmdPosSL.Enabled = False
            stcActPosSL.Enabled = False
            stcCmdVelSL.Enabled = False
        End If

        stcAxisNoMa.Caption = "Ma Axis " + Format(m_lAxisNoMa, "00")
        stcAxisNoSl.Caption = "Sl Axis " + Format(m_lAxisNoSl, "00")

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        dwRetCode = AxmSignalIsServoOn(m_lAxisNoMa, dwOnOff)
        chkServoOn.Value = dwOnOff

        ' ++ 지정한 축의 겐트리제어 관련 설정값을 확인합니다.
        dwRetCode = AxmGantryGetEnable(m_lAxisNoMa, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange, dwGantryOn)
        dwRetCode = ConvertAxmToCombo(cboGantryHmSlaveUse, dwSlaveHmUse)
        edtGantryHmOffset.Text = Format(dSlaveHmOffset, "0.000")
        edtGantryHmRange.Text = Format(dSlaveHmRange, "0.000")
        chkGantryEnable.Value = dwGantryOn

        UpdateState = True
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

    Private Function TranslateHomeResult(ByVal dwHomeResult As Long)
        Dim strResult As String
        
        strResult = ""

        Select Case dwHomeResult
            Case HOME_SUCCESS
                strResult = "[01H] HOME_SUCCESS"
            Case HOME_SEARCHING
                strResult = "[02H] HOME_SEARCHING"
            Case HOME_ERR_GNT_RANGE
                strResult = "[10H] HOME_ERR_GNT_RANGE"
            Case HOME_ERR_USER_BREAK
                strResult = "[11H] HOME_ERR_USER_BREAK"
            Case HOME_ERR_VELOCITY
                strResult = "[12H] HOME_ERR_VELOCITY"
            Case HOME_ERR_AMP_FAULT
                strResult = "[13H] HOME_ERR_AMP_FAULT"
            Case HOME_ERR_NEG_LIMIT
                strResult = "[14H] HOME_ERR_NEG_LIMIT"
            Case HOME_ERR_POS_LIMIT
                strResult = "[15H] HOME_ERR_POS_LIMIT"
            Case HOME_ERR_NOT_DETECT
                strResult = "[16H] HOME_ERR_NOT_DETECT"
            Case HOME_ERR_UNKNOWN
                strResult = "[FFH] HOME_ERR_UNKNOWN"
            Case Else

        End Select

        TranslateHomeResult = strResult
    End Function
