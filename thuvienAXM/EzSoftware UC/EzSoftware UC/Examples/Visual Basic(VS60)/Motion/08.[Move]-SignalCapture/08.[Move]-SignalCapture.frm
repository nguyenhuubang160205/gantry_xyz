VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "MoveSignalCapture"
   ClientHeight    =   6630
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7005
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6630
   ScaleWidth      =   7005
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame3 
      Caption         =   "< Signal Capture Move >"
      Height          =   2940
      Left            =   90
      TabIndex        =   28
      Top             =   3630
      Width           =   6855
      Begin VB.CommandButton btnGetPos 
         Caption         =   "Get Position"
         Height          =   300
         Left            =   4995
         TabIndex        =   47
         Top             =   2490
         Width           =   1695
      End
      Begin VB.TextBox stcCapturePos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   45
         Text            =   "xxx.xxx"
         Top             =   2490
         Width           =   3270
      End
      Begin VB.CommandButton btnMoveStop 
         Caption         =   "Move stop"
         Height          =   975
         Left            =   5025
         TabIndex        =   44
         Top             =   1290
         Width           =   1665
      End
      Begin VB.CommandButton btnCaptureMove 
         Caption         =   "Capture Move"
         Height          =   1005
         Left            =   5025
         TabIndex        =   43
         Top             =   240
         Width           =   1665
      End
      Begin VB.ComboBox cboStopMethod 
         Height          =   315
         Left            =   1605
         TabIndex        =   42
         Top             =   1965
         Width           =   3300
      End
      Begin VB.ComboBox cboCaptureTarget 
         Height          =   315
         Left            =   1605
         TabIndex        =   41
         Top             =   1605
         Width           =   3300
      End
      Begin VB.ComboBox cboSignalEdge 
         Height          =   315
         Left            =   1605
         TabIndex        =   40
         Top             =   1275
         Width           =   3300
      End
      Begin VB.ComboBox cboDetectSig 
         Height          =   315
         ItemData        =   "08.[Move]-SignalCapture.frx":0000
         Left            =   1605
         List            =   "08.[Move]-SignalCapture.frx":0002
         TabIndex        =   39
         Top             =   930
         Width           =   3300
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   30
         Text            =   "400.0"
         Top             =   585
         Width           =   2355
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1605
         TabIndex        =   29
         Text            =   "100.0"
         Top             =   255
         Width           =   2355
      End
      Begin VB.Label Label16 
         Caption         =   "Capture Position   : "
         Height          =   240
         Left            =   150
         TabIndex        =   46
         Top             =   2520
         Width           =   1410
      End
      Begin VB.Line Line1 
         X1              =   135
         X2              =   6675
         Y1              =   2415
         Y2              =   2415
      End
      Begin VB.Label Label15 
         Caption         =   "Stop Method         : "
         Height          =   240
         Left            =   150
         TabIndex        =   38
         Top             =   1980
         Width           =   1410
      End
      Begin VB.Label Label14 
         Caption         =   "Capture Target      : "
         Height          =   240
         Left            =   150
         TabIndex        =   37
         Top             =   1635
         Width           =   1410
      End
      Begin VB.Label Label13 
         Caption         =   "Signal Edge          :"
         Height          =   240
         Left            =   150
         TabIndex        =   36
         Top             =   1290
         Width           =   1410
      End
      Begin VB.Label Label12 
         Caption         =   "Detect Signal        :"
         Height          =   240
         Left            =   150
         TabIndex        =   35
         Top             =   960
         Width           =   1410
      End
      Begin VB.Label Label11 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4065
         TabIndex        =   34
         Top             =   645
         Width           =   1080
      End
      Begin VB.Label Label10 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4065
         TabIndex        =   33
         Top             =   300
         Width           =   855
      End
      Begin VB.Label Label9 
         Caption         =   "Move Acceleration: "
         Height          =   240
         Left            =   150
         TabIndex        =   32
         Top             =   630
         Width           =   1410
      End
      Begin VB.Label Label8 
         Caption         =   "Move Velocity       : "
         Height          =   240
         Left            =   150
         TabIndex        =   31
         Top             =   285
         Width           =   1410
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   60
      TabIndex        =   24
      Top             =   0
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5085
         TabIndex        =   26
         Top             =   195
         Width           =   1665
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1710
         TabIndex        =   25
         Top             =   210
         Width           =   3240
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No        : "
         Height          =   300
         Left            =   150
         TabIndex        =   27
         Top             =   255
         Width           =   1500
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1455
      Left            =   60
      TabIndex        =   12
      Top             =   630
      Width           =   6885
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   4560
         Top             =   405
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   4590
         Top             =   -30
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   330
         Left            =   5040
         Style           =   1  'Graphical
         TabIndex        =   17
         Top             =   960
         Width           =   1710
      End
      Begin VB.CommandButton btnPosClear 
         Caption         =   "Position Clear"
         Height          =   585
         Left            =   5055
         TabIndex        =   16
         Top             =   255
         Width           =   1695
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1680
         TabIndex        =   15
         Text            =   "0.000"
         Top             =   975
         Width           =   2325
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1680
         TabIndex        =   14
         Text            =   "0.000"
         Top             =   600
         Width           =   2325
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1680
         TabIndex        =   13
         Text            =   "0.000"
         Top             =   210
         Width           =   2310
      End
      Begin VB.Label Label7 
         Caption         =   "Unit/Sec"
         Height          =   255
         Left            =   4140
         TabIndex        =   23
         Top             =   1050
         Width           =   735
      End
      Begin VB.Label Label6 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   22
         Top             =   675
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   21
         Top             =   300
         Width           =   375
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel         : "
         Height          =   225
         Left            =   165
         TabIndex        =   20
         Top             =   1020
         Width           =   1455
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos        :"
         Height          =   270
         Left            =   165
         TabIndex        =   19
         Top             =   660
         Width           =   1485
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos        : "
         Height          =   225
         Left            =   165
         TabIndex        =   18
         Top             =   300
         Width           =   1455
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Jog ( Velocity ) Move >"
      Height          =   1530
      Left            =   75
      TabIndex        =   0
      Top             =   2100
      Width           =   6870
      Begin VB.CommandButton btnJogMoveN 
         Caption         =   "Jog Move ( - )"
         Height          =   495
         Left            =   5025
         TabIndex        =   5
         Top             =   810
         Width           =   1665
      End
      Begin VB.CommandButton btnJogMoveP 
         Caption         =   "Jog Move ( + )"
         Height          =   495
         Left            =   5025
         TabIndex        =   4
         Top             =   270
         Width           =   1665
      End
      Begin VB.TextBox edtJogDec 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1635
         TabIndex        =   3
         Text            =   "400.0"
         Top             =   1020
         Width           =   2355
      End
      Begin VB.TextBox edtJogAcc 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1635
         TabIndex        =   2
         Text            =   "400.0"
         Top             =   690
         Width           =   2355
      End
      Begin VB.TextBox edtJogVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1635
         TabIndex        =   1
         Text            =   "100.0"
         Top             =   360
         Width           =   2355
      End
      Begin VB.Label Label19 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4110
         TabIndex        =   11
         Top             =   1080
         Width           =   1080
      End
      Begin VB.Label Label20 
         Caption         =   "Jog Deceleration   : "
         Height          =   240
         Left            =   165
         TabIndex        =   10
         Top             =   1065
         Width           =   1410
      End
      Begin VB.Label Label21 
         Caption         =   "Jog Acceleration   : "
         Height          =   240
         Left            =   165
         TabIndex        =   9
         Top             =   720
         Width           =   1410
      End
      Begin VB.Label Label22 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4110
         TabIndex        =   8
         Top             =   405
         Width           =   735
      End
      Begin VB.Label Label23 
         Caption         =   "Jog Velocity           :"
         Height          =   240
         Left            =   165
         TabIndex        =   7
         Top             =   390
         Width           =   1410
      End
      Begin VB.Label Label24 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4110
         TabIndex        =   6
         Top             =   735
         Width           =   855
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' MoveSignalCapture.vb : implementation file

' **************************************************************************
' >> [일자]: 2015.11.30.
' >> [개요]: 이 예제는 신호검출 구동함수들의 사용법을 익히고 실제 특정 신호의
'    변화를 감지하여 그때 지령값 또는 엔코더값을 캡쳐해보는 예제입니다.
' >> [중요]: 위치캡쳐구동함수 응용범위
'     1) 구동중 특정 센서가 감지될 때의 지령위치 또는 피드벡 위치를 H/W 기능을
'        이용해 정확하게 저장해야될 때 응용됩니다.
'     2) 이 기능은 웨이퍼 이송 로봇에서 웨이퍼 틀어짐 파악, Tray 적재 로봇에서
'        Tray높이 파악등에 응용할 수 있습니다.
'     3) 구동중 고속 다중위치 캡쳐기능이 필요하신분은 별도로 기술문의 바랍니다.
' **************************************************************************


    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_dOldCmdPos As Double
    Private m_dOldActPos As Double
    Private m_dOldCmdVel As Double
        
    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
        m_dOldCmdPos = 0#
        m_dOldActPos = 0#
        m_dOldCmdVel = 0#
        
        cboDetectSig.AddItem ("00: PosEndLimit")
        cboDetectSig.AddItem ("01: NegEndLimit")
        cboDetectSig.AddItem ("04: HomeSensor")
        cboDetectSig.AddItem ("05: EncodZPhase")
        cboDetectSig.AddItem ("06: UniInput02")
        cboDetectSig.AddItem ("07: UniInput03")
        
        cboSignalEdge.AddItem ("00: SIGNAL_DOWN_EDGE")
        cboSignalEdge.AddItem ("01: SIGNAL_UP_EDGE")
        
        cboCaptureTarget.AddItem ("00: COMMAND")
        cboCaptureTarget.AddItem ("01: ACTUAL")
        
        cboStopMethod.AddItem ("00: EMERGENCY_STOP")
        cboStopMethod.AddItem ("01: SLOWDOWN_STOP")
        
        InitLibrary   ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo   ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState   ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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
    ' >> btnPosClear_Click() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 0.0으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click()
        dwRetCode = AxmStatusSetPosMatch(m_lAxisNo, 0#)
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_Click()
        Dim dwOnOff As Long

        dwOnOff = IIf(chkServoOn.Value, 1, 0)
        ' ++ 지정 축의 Servo On/Off 신호를 출력합니다.
        dwRetCode = AxmSignalServoOn(m_lAxisNo, dwOnOff)
    End Sub

    ' ++ =======================================================================
    ' >> btnCaptureMove_Click() : "Capture Move"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축으로 지정한 신호검출 위치캡쳐 구동을 시작합니다.
    '  - 선택한 신호의 Edge 신호가 검출되지않으면 지정한 속도로 무한 구동합니다.
    '  ※ [CAUTION] End Limit 신호는 Edge 검출이 되지 않음에 유의 바랍니다.
    ' --------------------------------------------------------------------------
    Private Sub btnCaptureMove_Click()
        Dim strData As String
        Dim dwRetCode, lDetectSig, lSignalEdge, lTarget, lStopMethod As Long
        Dim dMoveVel, dMoveAcc As Double

        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text

        lDetectSig = ConvertComboToAxm(cboDetectSig)
        lSignalEdge = ConvertComboToAxm(cboSignalEdge)
        lTarget = ConvertComboToAxm(cboCaptureTarget)
        lStopMethod = ConvertComboToAxm(cboStopMethod)

        ' ++ 지정 축에 설정된 신호를 검출하고 신호가 검출될 때 그 위치를 저장하기 위해 구동하는 함수입니다.
        dwRetCode = AxmMoveSignalCapture(m_lAxisNo, dMoveVel, dMoveAcc, lDetectSig, lSignalEdge, lTarget, lStopMethod)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveSignalCapture return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 신호검출 구동을 감속정지 합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click()
        ' ++ 지정한 축의 구동을 감속정지합니다.
        dwRetCode = AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnGetPos_Click() : "Get Position"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 신호검출 구동시 캡쳐한 위치값을 확인합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnGetPos_Click()
        Dim dwRetCode As Long
        Dim dCapturePos As Double
        
        dCapturePos = 0#

        ' ++ 'AxmMoveSignalCapture' 함수로 구동중 지정한 신호가 검출되어 저장된 위치값을 확인하는 함수입니다.
        ' ※ [CAUTION] 함수 실행 결과가 "AXT_RT_SUCCESS"일때 저장된 위치가 유효하며, 이 함수를 한번 실행하면
        '     저장된 위치값은 초기화됩니다.
        dwRetCode = AxmMoveGetCapturePos(m_lAxisNo, dCapturePos)
        If dwRetCode = AXT_RT_SUCCESS Then
            stcCapturePos.Text = Format(dCapturePos, "0.000")
        Else
            stcCapturePos.Text = "xxx.xxx "
        End If

    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseDown(...) : "Jog Move(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim dJogVel, dJogAcc, dJogDec As Double
        
        dwRetCode = 0

        dJogVel = Math.Abs(Val(edtJogVel.Text))
        dJogAcc = Math.Abs(Val(edtJogAcc.Text))
        dJogDec = Math.Abs(Val(edtJogDec.Text))

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
        
        dJogVel = Math.Abs(Val(edtJogVel.Text))
        dJogAcc = Math.Abs(Val(edtJogAcc.Text))
        dJogDec = Math.Abs(Val(edtJogDec.Text))

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
        dwRetCode = AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseUp(...) : "Jog Move(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        dwRetCode = AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        Dim dCmdPos As Double
        Dim dActPos As Double
        Dim dCmdVel As Double
        
        dCmdPos = 0#
        dActPos = 0#
        dCmdVel = 0#
        
        ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
        dwRetCode = AxmStatusGetCmdPos(m_lAxisNo, dCmdPos)
        If m_dOldCmdPos <> dCmdPos Then
            stcCmdPos.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPos = dCmdPos
        End If

        ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
        dwRetCode = AxmStatusGetActPos(m_lAxisNo, dActPos)
        If m_dOldActPos <> dActPos Then
            stcActPos.Text = Format(dActPos, "0.000")
            m_dOldActPos = dActPos
        End If

        ' ++ 지정한 축의 구동 속도를 반환합니다.
        dwRetCode = AxmStatusReadVel(m_lAxisNo, dCmdVel)
        If m_dOldCmdVel <> dCmdVel Then
            stcCmdVel.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVel = dCmdVel
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
        Dim lpBoardNo As Long
        Dim lpModulePosAs As Long
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

        cboDetectSig.ListIndex = 2
        cboSignalEdge.ListIndex = 1
        cboStopMethod.ListIndex = 1
        cboCaptureTarget.ListIndex = 0

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

        Dim dwOnOff As Long
        dwOnOff = 0

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        dwRetCode = AxmSignalIsServoOn(m_lAxisNo, dwOnOff)
        chkServoOn.Value = dwOnOff

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
            UpdateState = 0
            Exit Function
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.ListCount
        If dwCount = 0 Then
            UpdateState = 0
            Exit Function
        End If

        For i = 0 To (dwCount - 1)
            strText = pCboItem.List(i)
            dwSelData = Val(strText)
            If dwSelData = dwCurData Then
                pCboItem.ListIndex = i
                UpdateState = i
                Exit Function
            End If
        Next

        pCboItem.ListIndex = 0
        UpdateState = 0
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
