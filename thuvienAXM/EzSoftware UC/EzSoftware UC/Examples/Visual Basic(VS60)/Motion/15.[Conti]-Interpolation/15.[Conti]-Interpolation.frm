VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "ContiInterpolation"
   ClientHeight    =   6690
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7095
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6690
   ScaleWidth      =   7095
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame3 
      Caption         =   "< Interpolation Move >"
      Height          =   2925
      Left            =   90
      TabIndex        =   35
      Top             =   3675
      Width           =   6885
      Begin VB.CommandButton btnIntpClear 
         Caption         =   "Clear"
         Height          =   330
         Left            =   5790
         TabIndex        =   52
         Top             =   2430
         Width           =   945
      End
      Begin VB.CommandButton btnIntpStart 
         Caption         =   "Start"
         Height          =   345
         Left            =   5790
         TabIndex        =   51
         Top             =   2010
         Width           =   945
      End
      Begin VB.CommandButton btnIntpLineArc 
         Caption         =   "Line && Arc"
         Height          =   765
         Left            =   180
         TabIndex        =   50
         Top             =   2010
         Width           =   1710
      End
      Begin VB.CommandButton btnIntpHelical 
         Caption         =   "Helical"
         Height          =   765
         Left            =   2010
         TabIndex        =   49
         Top             =   2010
         Width           =   1725
      End
      Begin VB.CommandButton btnIntpSpline 
         Caption         =   "Spline"
         Height          =   765
         Left            =   3825
         TabIndex        =   48
         Top             =   2010
         Width           =   1710
      End
      Begin VB.CommandButton btnIntpCircle 
         Caption         =   "Circle(Angle)"
         Height          =   315
         Left            =   3825
         TabIndex        =   47
         Top             =   1500
         Width           =   1710
      End
      Begin VB.CommandButton btnIntpArc 
         Caption         =   "Arc(Radius)"
         Height          =   315
         Left            =   2010
         TabIndex        =   46
         Top             =   1500
         Width           =   1725
      End
      Begin VB.CommandButton btnIntpLine 
         Caption         =   "Line"
         Height          =   315
         Left            =   180
         TabIndex        =   45
         Top             =   1500
         Width           =   1710
      End
      Begin VB.CommandButton btnIntpStop 
         Caption         =   "Stop"
         Height          =   1470
         Left            =   5805
         TabIndex        =   44
         Top             =   285
         Width           =   945
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   2250
         TabIndex        =   38
         Text            =   "400.0"
         Top             =   675
         Width           =   2190
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   2250
         TabIndex        =   37
         Text            =   "100.0"
         Top             =   345
         Width           =   2190
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   2250
         TabIndex        =   36
         Text            =   "400.0"
         Top             =   1005
         Width           =   2190
      End
      Begin VB.Label Label7 
         Caption         =   "Interpolation Acceleration    : "
         Height          =   240
         Left            =   195
         TabIndex        =   53
         Top             =   705
         Width           =   2040
      End
      Begin VB.Line Line3 
         X1              =   180
         X2              =   5610
         Y1              =   1920
         Y2              =   1920
      End
      Begin VB.Line Line2 
         X1              =   180
         X2              =   5610
         Y1              =   1380
         Y2              =   1380
      End
      Begin VB.Label Label14 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4590
         TabIndex        =   43
         Top             =   390
         Width           =   780
      End
      Begin VB.Label Label13 
         Caption         =   "Interpolation Velocity           : "
         Height          =   240
         Left            =   195
         TabIndex        =   42
         Top             =   375
         Width           =   2040
      End
      Begin VB.Label Label16 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4590
         TabIndex        =   41
         Top             =   720
         Width           =   825
      End
      Begin VB.Label Label8 
         Caption         =   "Interpolation Deceleration    : "
         Height          =   240
         Left            =   180
         TabIndex        =   40
         Top             =   1035
         Width           =   2070
      End
      Begin VB.Label Label11 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4590
         TabIndex        =   39
         Top             =   1050
         Width           =   825
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "< Interpolation Monitor >"
      Height          =   1140
      Left            =   90
      TabIndex        =   26
      Top             =   2490
      Width           =   6885
      Begin VB.CheckBox chkIntpInMotion 
         Enabled         =   0   'False
         Height          =   195
         Left            =   5190
         TabIndex        =   34
         Top             =   720
         Width           =   315
      End
      Begin VB.CheckBox chkIntpQueueFree 
         Enabled         =   0   'False
         Height          =   210
         Left            =   5190
         TabIndex        =   33
         Top             =   375
         Width           =   300
      End
      Begin VB.TextBox stcIntpExeNode 
         Alignment       =   2  'Center
         Enabled         =   0   'False
         Height          =   360
         Left            =   2250
         TabIndex        =   28
         Text            =   "0"
         Top             =   255
         Width           =   945
      End
      Begin VB.TextBox stcIntpTotalNode 
         Alignment       =   2  'Center
         Enabled         =   0   'False
         Height          =   360
         Left            =   2250
         TabIndex        =   27
         Text            =   "0"
         Top             =   630
         Width           =   945
      End
      Begin VB.Label Label6 
         Caption         =   "Interpolation Q Free  :"
         Height          =   240
         Left            =   3600
         TabIndex        =   32
         Top             =   360
         Width           =   1650
      End
      Begin VB.Label Label5 
         Caption         =   "In Interpolation Move:"
         Height          =   240
         Left            =   3600
         TabIndex        =   31
         Top             =   690
         Width           =   1815
      End
      Begin VB.Label Label12 
         Caption         =   "Interpolation Execute Node :"
         Height          =   240
         Left            =   165
         TabIndex        =   30
         Top             =   360
         Width           =   2055
      End
      Begin VB.Label Label17 
         Caption         =   "Interpolation Total Node      : "
         Height          =   240
         Left            =   165
         TabIndex        =   29
         Top             =   690
         Width           =   2055
      End
      Begin VB.Line Line1 
         X1              =   3450
         X2              =   3450
         Y1              =   225
         Y2              =   990
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   90
      TabIndex        =   22
      Top             =   15
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5445
         TabIndex        =   24
         Top             =   195
         Width           =   1305
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1410
         TabIndex        =   23
         Top             =   210
         Width           =   3915
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No : "
         Height          =   300
         Left            =   150
         TabIndex        =   25
         Top             =   255
         Width           =   1245
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1770
      Left            =   90
      TabIndex        =   0
      Top             =   675
      Width           =   6885
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   18
         Text            =   "0.000"
         Top             =   570
         Width           =   990
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   17
         Text            =   "0.000"
         Top             =   585
         Width           =   990
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   16
         Text            =   "0.000"
         Top             =   585
         Width           =   990
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   15
         Text            =   "0.000"
         Top             =   585
         Width           =   990
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 00"
         Height          =   195
         Index           =   0
         Left            =   1425
         TabIndex        =   14
         Top             =   300
         Width           =   870
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 01"
         Height          =   195
         Index           =   1
         Left            =   2550
         TabIndex        =   13
         Top             =   300
         Width           =   870
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 02"
         Height          =   195
         Index           =   2
         Left            =   3705
         TabIndex        =   12
         Top             =   300
         Width           =   870
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 03"
         Height          =   195
         Index           =   3
         Left            =   4830
         TabIndex        =   11
         Top             =   300
         Width           =   870
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   10
         Text            =   "0.000"
         Top             =   930
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   9
         Text            =   "0.000"
         Top             =   945
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   8
         Text            =   "0.000"
         Top             =   945
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   7
         Text            =   "0.000"
         Top             =   945
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   6
         Text            =   "0.000"
         Top             =   1275
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   5
         Text            =   "0.000"
         Top             =   1290
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   4
         Text            =   "0.000"
         Top             =   1290
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   3
         Text            =   "0.000"
         Top             =   1290
         Width           =   990
      End
      Begin VB.CommandButton btnPosClear 
         Caption         =   "Clear"
         Height          =   630
         Left            =   5790
         TabIndex        =   2
         Top             =   585
         Width           =   945
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   270
         Left            =   5805
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   1290
         Width           =   930
      End
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   5820
         Top             =   105
      End
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   6270
         Top             =   75
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos :"
         Height          =   240
         Left            =   120
         TabIndex        =   21
         Top             =   600
         Width           =   1215
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos :"
         Height          =   240
         Left            =   120
         TabIndex        =   20
         Top             =   960
         Width           =   1245
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel  :"
         Height          =   225
         Left            =   120
         TabIndex        =   19
         Top             =   1320
         Width           =   1140
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' ContiInterpolation.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.12.02
' >> [개요]: 이 예제는 보간함수들의 사용법을 익히고 정해진 패턴의 연속보간
'    데이타들을 연속보간 Queue에 예약 및 실행 해 보는 예제입니다.
' >> [중요]: 연속보간 데이타 예약 및 구동하기
'     1) AxmContiSetAxisMap함수를 이용해서 필요한 축수의 좌표계를 맵핑합니다.
'     2) AxmContiSetAbsRelMode함수를 이용해 해당좌표계의 구동모드를 설정합니다.
'     3) AxmContiBeginNode함수를 이용해 보간구동 예약을 시작합니다.
'     4) AxmLineMove, AxmCircleCenterMove등의 보간함수를 이용해 구동을 예약합니다.
'     5) AxmContiEndNode함수를 이용해 보간구동 예약을 종료합니다.
'     6) AxmContiStart함수를 이용해 예약된 보간구동을 시작합니다.
' **************************************************************************

    Const COORD_NO As Integer = 0
    Const MAX_SPLINE_NODE As Integer = 5
    Const MAX_INTP_MOVE_AXIS As Integer = 4

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_lMoveIntpAxesCount As Integer
    Private m_lMoveIntpAxes(MAX_INTP_MOVE_AXIS - 1) As Long
    Private m_dOldCmdPos(MAX_INTP_MOVE_AXIS - 1), _
        m_dOldActPos(MAX_INTP_MOVE_AXIS - 1), _
        m_dOldCmdVel(MAX_INTP_MOVE_AXIS - 1) As Double
        
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    Private Sub Form_Load()
        Dim index As Integer
        
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0

        For index = 0 To (MAX_INTP_MOVE_AXIS - 1)
            m_lMoveIntpAxes(index) = -1
            m_dOldCmdPos(index) = 0#
            m_dOldActPos(index) = 0#
            m_dOldCmdVel(index) = 0#
        Next

        InitLibrary               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    Private Sub ContiInterpolation_FormClosed()
        AxlClose
    End Sub

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelAxis_Click() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelAxis_Click()
        Dim lpBoardNo As Long
        Dim lpModulePos As Long
        m_lAxisNo = cboSelAxis.ListIndex

        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, lpBoardNo, lpModulePos, m_dwModuleId)

        UpdateState       ' 변경한 축의 상태와 Control들의 상태를 일치시킵니다..
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
    ' >> chkAxis_Click(...) : 축 변경이 있을 때 호출되는 핸들러 함수.
    '  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
    '    번호 배열값을 재할당합니다.
    '  - chkAxis(0) ~ chkAxis(3) 버튼의 클릭이벤트 발생시 호출됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkAxis_Click(intIndex As Integer)
        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> btnPosClear_Click() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 0.0으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click()
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            '++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            dwRetCode = AxmStatusSetPosMatch(m_lMoveIntpAxes(lCount), 0#)
        Next
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_Click()
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            '++ 지정 축의 Servo On/Off 신호를 출력합니다.
            If chkServoOn.Value Then
                dwRetCode = AxmSignalServoOn(m_lMoveIntpAxes(lCount), 1)
            Else
                dwRetCode = AxmSignalServoOn(m_lMoveIntpAxes(lCount), 0)
            End If
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpLine_Click() : "Line"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpLine_Click()
        Dim dwRetCode As Long
        Dim dMovePos(1) As Double
        Dim dVelocity, dAccel, dDecel As Double
        
        dwRetCode = 0

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dMovePos(0) = 100#  ' 첫번째 축의 이동할 위치값
        dMovePos(1) = 200#  ' 두번째 축의 이동할 위치값

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        dwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)

        ' ++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다.
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmLineMove return error[Code:0000]")
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    '// >> btnIntpArc_Click() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
    '//  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
    '// --------------------------------------------------------------------------
    Private Sub btnIntpArc_Click()
        Dim dwRetCode As Long
        Dim dwArcDir, dwShortDis As Long
        Dim dEndPos(1) As Double
        Dim dVelocity, dAccel, dDecel, dRadius As Double
        
        dwRetCode = 0

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dEndPos(0) = 100#
        dEndPos(1) = 100#
        dRadius = 141#
        dwArcDir = DIR_CW
        dwShortDis = LONG_DISTANCE

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AdwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.
        dwRetCode = AxmCircleRadiusMove(COORD_NO, m_lMoveIntpAxes(0), dRadius, dEndPos(0), dVelocity, dAccel, dDecel, dwArcDir, dwShortDis)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmCircleRadiusMove return error[Code:0000]")
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpCircle_Click() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpCircle_Click()
        Dim dwRetCode As Long
        Dim dwArcDir As Long
        Dim dCenterPos(1) As Double
        Dim dVelocity, dAccel, dDecel, dAngle As Double

        dwRetCode = 0
        
        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dCenterPos(0) = 200#
        dCenterPos(1) = 200#
        dAngle = 359#
        dwArcDir = DIR_CCW

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        dwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.
        'Threading.Thread.Sleep (1)
        Sleep 1
        
        dwRetCode = AxmCircleAngleMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dAngle, dVelocity, dAccel, dDecel, dwArcDir)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmCircleAngleMove return error[Code:0000]")
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpLineArc_Click() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpLineArc_Click()
        Dim dwRetCode As Long
        Dim dMovePos(1), dCenterPos(1), dEndPos(1) As Double
        Dim dVelocity, dAccel, dDecel As Double

        dwRetCode = 0
        
        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        dwRetCode = AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        dwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        AxmContiBeginNode (COORD_NO)

        dMovePos(0) = 0#
        dMovePos(1) = 200#
        ' ++ 지정한 좌표계에 직선보간 구동을 예약합니다.
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dMovePos(0) = 180#
        dMovePos(1) = 200#
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = 180#
        dCenterPos(1) = 180#
        dEndPos(0) = 200#
        dEndPos(1) = 180#
        ' ++ 지정한 좌표계에 중심점과 종료점을 이용하는 원호보간 구동을 예약합니다.
        dwRetCode = AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = 200#
        dMovePos(1) = -180#
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = 180#
        dCenterPos(1) = -180#
        dEndPos(0) = 180#
        dEndPos(1) = -200#
        dwRetCode = AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = -180#
        dMovePos(1) = -200#
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = -180#
        dCenterPos(1) = -180#
        dEndPos(0) = -200#
        dEndPos(1) = -180#
        dwRetCode = AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = -200#
        dMovePos(1) = 180#
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = -180#
        dCenterPos(1) = 180#
        dEndPos(0) = -180#
        dEndPos(1) = 200#
        dwRetCode = AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = 0#
        dMovePos(1) = 200#
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        dwRetCode = AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpHelical_Click() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpHelical_Click()
        Dim dwArcDir As Long
        Dim dVelocity, dAccel, dDecel As Double
        Dim dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dCenterPosX = 100#
        dCenterPosY = 100#
        dEndPosX = 0#
        dEndPosY = 0#
        dZPos = 10#
        dwArcDir = DIR_CW

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 4, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        dwRetCode = AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        dwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        dwRetCode = AxmContiBeginNode(COORD_NO)
        '++ 지정한 좌표계에 중심점과 종료점을 이용하는 헬리컬 보간구동을 예약합니다
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        dwRetCode = AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        dwRetCode = AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpSpline_Click() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpSpline_Click()
        Dim lPointFactor As Long
        Dim dVelocity, dAccel, dDecel As Double
        Dim dPosX(MAX_SPLINE_NODE - 1), dPosY(MAX_SPLINE_NODE - 1), dPosZ As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        dwRetCode = AxmContiSetAxisMap(COORD_NO, 3, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        dwRetCode = AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        dwRetCode = AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        dPosX(0) = 0
        dPosY(0) = 0
        dPosX(1) = 45
        dPosY(1) = 10
        dPosX(2) = 75
        dPosY(2) = 45
        dPosX(3) = 108
        dPosY(3) = 75
        dPosX(4) = 130
        dPosY(4) = 70
        dPosZ = 1#
        lPointFactor = 100

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        dwRetCode = AxmContiBeginNode(COORD_NO)
        '++ 지정한 좌표계에 X좌표, Y좌표, Z좌표를 이용하는 스플라인 보간구동을 예약합니다.
        dwRetCode = AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, dPosZ, lPointFactor)

        dPosX(0) = 130
        dPosY(0) = 70
        dPosX(1) = 108
        dPosY(1) = 75
        dPosX(2) = 75
        dPosY(2) = 45
        dPosX(3) = 45
        dPosY(3) = 10
        dPosX(4) = 0
        dPosY(4) = 0
        dPosZ = 1#
        lPointFactor = 100
        dwRetCode = AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, dPosZ, lPointFactor)


        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        dwRetCode = AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpStart_Click() : "Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpStart_Click()
        Dim dwRetCode As Long

        '++ 지정한 좌표계의 연속보간 구동을 시작합니다.
        dwRetCode = AxmContiStart(COORD_NO, CONTI_NODE_VELOCITY, 0)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmContiStart return error[Code:0000d]")
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpClear_Click() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 예약된 연속보간 데이타들을 지우는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpClear_Click()
        Dim dwRetCode As Long

        '++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
        dwRetCode = AxmContiWriteClear(COORD_NO)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmContiWriteClear return error[Code:0000d]")
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 연속보간을 정지하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpStop_Click()
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            ' ++ 지정한 좌표계에 연속 보간 구동을 감속정지합니다.
            ' [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
            AxmMoveSStop (m_lMoveIntpAxes(lCount))
        Next

    End Sub

    ' =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        Dim dCmdPos As Double
        Dim dActPos As Double
        Dim dCmdVel As Double
        Dim lArrayIndex As Long
        Dim dwQueueFree As Long
        Dim dwIntpInMotion As Long
        Dim lExeNode As Long
        Dim lTotalNode As Long
        Dim isTrue As Boolean
        Dim lCount As Integer
        
        dCmdPos = 0#
        dActPos = 0#
        dCmdVel = 0#
        lArrayIndex = 0
        dwQueueFree = 0
        dwIntpInMotion = 0
        lExeNode = 0
        lTotalNode = 0
        isTrue = False

        For lCount = 0 To (MAX_INTP_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
                dwRetCode = AxmStatusGetCmdPos(m_lMoveIntpAxes(lArrayIndex), dCmdPos)
                If m_dOldCmdPos(lCount) <> dCmdPos Then
                    stcCmdPos(lCount).Text = Format(dCmdPos, "0.000")
                    m_dOldCmdPos(lCount) = dCmdPos
                End If

                ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                dwRetCode = AxmStatusGetActPos(m_lMoveIntpAxes(lArrayIndex), dActPos)
                If m_dOldActPos(lCount) <> dActPos Then
                    stcActPos(lCount).Text = Format(dActPos, "0.000")
                    m_dOldActPos(lCount) = dActPos
                End If

                ' ++ 지정한 축의 구동 속도를 반환합니다.
                dwRetCode = AxmStatusReadVel(m_lMoveIntpAxes(lArrayIndex), dCmdVel)
                If m_dOldCmdVel(lCount) <> dCmdVel Then
                    stcCmdVel(lCount).Text = Format(dCmdVel, "0.000")
                    m_dOldCmdVel(lCount) = dCmdVel
                End If

                lArrayIndex = lArrayIndex + 1
            End If
        Next

        ' ++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
        dwRetCode = AxmContiReadFree(COORD_NO, dwQueueFree)
        isTrue = IIf(dwQueueFree = 1, True, False)
        If isTrue Then
            chkIntpQueueFree.Value = 1
        Else
            chkIntpQueueFree.Value = 0
        End If
                

        ' ++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
        dwRetCode = AxmContiIsMotion(COORD_NO, dwIntpInMotion)
        isTrue = IIf(dwIntpInMotion = 1, True, False)
        If isTrue Then
            chkIntpInMotion.Value = 1
        Else
            chkIntpInMotion.Value = 0
        End If

        ' ++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
        dwRetCode = AxmContiGetNodeNum(COORD_NO, lExeNode)
        If Val(stcIntpExeNode.Text) <> lExeNode Then
            stcIntpExeNode.Text = lExeNode
        End If

        ' ++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
        dwRetCode = AxmContiGetTotalNodeNum(COORD_NO, lTotalNode)
        If Val(stcIntpTotalNode.Text) <> lTotalNode Then
            stcIntpTotalNode.Text = lTotalNode
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

        ' ++ 유효한 전체 모션축수를 반환합니다.
        dwRetCode = AxmInfoGetAxisCount(m_lAxisCount)
        If m_lAxisCount < 1 Then
            AddAxisInfo = False
            Exit Function
        End If
        
        szModuleName = Space(50)
        szModuleDescription = Space(80)
        m_lAxisNo = 0
        ' ++ 지정한 축의 정보를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, dwBoardNo, dwModulePos, m_dwModuleId)

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

        Dim bSelectCheck, bEmptyCheck, bAllCheck As Boolean
        Dim strData As String
        Dim dwOnOff As Long
        Dim lTotalCount As Long
        Dim lBoardNo As Long
        Dim lModulePos As Long
        Dim lFirstAxisNo As Long
        Dim lCount As Integer
        
        dwOnOff = 0
        lTotalCount = 0
        lBoardNo = 0
        lModulePos = 0
        lFirstAxisNo = 0

        ' ++ 지정한 축의 정보를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, lBoardNo, lModulePos, lModuleID)
        ' ++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
        dwRetCode = AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, lFirstAxisNo)

        bSelectCheck = False
        bEmptyCheck = False
        m_lMoveIntpAxesCount = 0
        For lCount = 0 To (MAX_INTP_MOVE_AXIS - 1)
            ' 지정한 축이 제어가 가능한 상태인지 반환합니다.
            If AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS Then
                strData = "Axis " + Format(lFirstAxisNo, "00")
                chkAxis(lCount).Enabled = True
                bSelectCheck = chkAxis(lCount).Value
                bEmptyCheck = bEmptyCheck Or bSelectCheck

                If bSelectCheck = 1 Then
                    m_lMoveIntpAxes(m_lMoveIntpAxesCount) = lFirstAxisNo
                    m_lMoveIntpAxesCount = m_lMoveIntpAxesCount + 1
                End If
            Else
                m_lMoveIntpAxes(lCount) = -1
                strData = "Axis --"
                chkAxis(lCount).Enabled = False
                chkAxis(lCount).Value = False
            End If
            lFirstAxisNo = lFirstAxisNo + 1
            chkAxis(lCount).Caption = strData
        Next

        ' 선택된 축이 없으면 Disable처리
        chkServoOn.Enabled = bEmptyCheck

        bAllCheck = False
        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            ' ++ 지정한 축의 서보온 상태를 반환합니다.
            dwRetCode = AxmSignalIsServoOn(m_lMoveIntpAxes(lCount), dwOnOff)
            ' 선택된 보간축들이 모두 서보온 되어있을 때 TRUE
            bAllCheck = bAllCheck And dwOnOff
        Next

        chkServoOn.Value = bAllCheck

        ' 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
        If m_lMoveIntpAxesCount < 2 Then
            btnIntpLine.Enabled = DISABLE
            btnIntpArc.Enabled = DISABLE
            btnIntpCircle.Enabled = DISABLE
            btnIntpLineArc.Enabled = DISABLE
            btnIntpHelical.Enabled = DISABLE
            btnIntpSpline.Enabled = DISABLE
        Else
            btnIntpLine.Enabled = ENABLE
            btnIntpArc.Enabled = ENABLE
            btnIntpCircle.Enabled = ENABLE
            btnIntpLineArc.Enabled = ENABLE
            If m_lMoveIntpAxesCount >= 3 Then
                btnIntpSpline.Enabled = ENABLE
            Else
                btnIntpSpline.Enabled = DISABLE
            End If

            If m_lMoveIntpAxesCount = 4 Then
                btnIntpHelical.Enabled = ENABLE
            Else
                btnIntpHelical.Enabled = DISABLE
            End If
        End If
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


