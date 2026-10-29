VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "OverridePosition"
   ClientHeight    =   7320
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6990
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7320
   ScaleWidth      =   6990
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame4 
      Caption         =   "< Position Move >"
      Height          =   2940
      Left            =   60
      TabIndex        =   34
      Top             =   4305
      Width           =   6855
      Begin VB.CommandButton btnOverride2 
         Caption         =   "Override Pos 2"
         Height          =   285
         Left            =   5025
         TabIndex        =   43
         Top             =   2520
         Width           =   1665
      End
      Begin VB.CommandButton btnOverride1 
         Caption         =   "Override Pos 1"
         Height          =   285
         Left            =   5025
         TabIndex        =   42
         Top             =   2160
         Width           =   1665
      End
      Begin VB.TextBox edtOverrideDis1 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   37
         Text            =   "2000.0"
         Top             =   2145
         Width           =   2355
      End
      Begin VB.TextBox edtOverrideDis2 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   36
         Text            =   "1000.0"
         Top             =   2490
         Width           =   2355
      End
      Begin VB.PictureBox btmOverride 
         Height          =   1755
         Left            =   90
         Picture         =   "09.[Override]-Position.frx":0000
         ScaleHeight     =   1695
         ScaleWidth      =   6555
         TabIndex        =   35
         Top             =   225
         Width           =   6615
      End
      Begin VB.Label Label19 
         Caption         =   "Unit"
         Height          =   195
         Left            =   4095
         TabIndex        =   41
         Top             =   2190
         Width           =   825
      End
      Begin VB.Label Label12 
         Caption         =   "Override Distance1: "
         Height          =   240
         Left            =   150
         TabIndex        =   40
         Top             =   2175
         Width           =   1410
      End
      Begin VB.Label Label11 
         Caption         =   "Override Distance2: "
         Height          =   240
         Left            =   150
         TabIndex        =   39
         Top             =   2520
         Width           =   1410
      End
      Begin VB.Label Label8 
         Caption         =   "Unit"
         Height          =   195
         Left            =   4095
         TabIndex        =   38
         Top             =   2535
         Width           =   870
      End
      Begin VB.Line Line1 
         X1              =   105
         X2              =   6705
         Y1              =   2070
         Y2              =   2070
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Position Move >"
      Height          =   2145
      Left            =   60
      TabIndex        =   16
      Top             =   2145
      Width           =   6870
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   5115
         Top             =   150
      End
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   5625
         Top             =   120
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.OptionButton rdoAbs 
         Caption         =   "[00] Absolute"
         Height          =   285
         Left            =   1680
         TabIndex        =   24
         Top             =   300
         Width           =   1545
      End
      Begin VB.OptionButton rdoRel 
         Caption         =   "[01] Relative"
         Height          =   285
         Left            =   3375
         TabIndex        =   23
         Top             =   300
         Width           =   1545
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1635
         TabIndex        =   22
         Text            =   "1000.0"
         Top             =   690
         Width           =   2355
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   21
         Text            =   "200.0"
         Top             =   1020
         Width           =   2355
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   20
         Text            =   "400.0"
         Top             =   1350
         Width           =   2355
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   19
         Text            =   "400.0"
         Top             =   1680
         Width           =   2355
      End
      Begin VB.CommandButton btnMove1 
         Caption         =   "Move Target 1"
         Height          =   285
         Left            =   5025
         TabIndex        =   18
         Top             =   660
         Width           =   1665
      End
      Begin VB.CommandButton btnSStop 
         Caption         =   "Move SStop"
         Height          =   870
         Left            =   5025
         TabIndex        =   17
         Top             =   1035
         Width           =   1665
      End
      Begin VB.Label Label16 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4095
         TabIndex        =   32
         Top             =   1395
         Width           =   825
      End
      Begin VB.Label Label9 
         Caption         =   "Target Position 1   : "
         Height          =   240
         Left            =   165
         TabIndex        =   31
         Top             =   720
         Width           =   1410
      End
      Begin VB.Label Label10 
         Caption         =   "Unit"
         Height          =   195
         Left            =   4110
         TabIndex        =   30
         Top             =   735
         Width           =   480
      End
      Begin VB.Label Label13 
         Caption         =   "Move Velocity       : "
         Height          =   240
         Left            =   165
         TabIndex        =   29
         Top             =   1050
         Width           =   1410
      End
      Begin VB.Label Label14 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4095
         TabIndex        =   28
         Top             =   1065
         Width           =   780
      End
      Begin VB.Label Label15 
         Caption         =   "Move Acceleration: "
         Height          =   240
         Left            =   150
         TabIndex        =   27
         Top             =   1380
         Width           =   1410
      End
      Begin VB.Label Label17 
         Caption         =   "Move Deceleration: "
         Height          =   240
         Left            =   150
         TabIndex        =   26
         Top             =   1725
         Width           =   1410
      End
      Begin VB.Label Label18 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4095
         TabIndex        =   25
         Top             =   1740
         Width           =   870
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   60
      TabIndex        =   12
      Top             =   15
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5445
         TabIndex        =   14
         Top             =   195
         Width           =   1305
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1410
         TabIndex        =   13
         Top             =   210
         Width           =   3915
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No : "
         Height          =   300
         Left            =   150
         TabIndex        =   15
         Top             =   255
         Width           =   1245
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1440
      Left            =   60
      TabIndex        =   0
      Top             =   660
      Width           =   6885
      Begin VB.TextBox edtSetPos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   5025
         TabIndex        =   33
         Text            =   "0.0"
         Top             =   210
         Width           =   1725
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   300
         Left            =   5025
         Style           =   1  'Graphical
         TabIndex        =   5
         Top             =   990
         Width           =   1725
      End
      Begin VB.CommandButton btnPosSet 
         Caption         =   "Position Setting"
         Height          =   315
         Left            =   5025
         TabIndex        =   4
         Top             =   615
         Width           =   1725
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   3
         Text            =   "0.000"
         Top             =   975
         Width           =   2550
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   2
         Text            =   "0.000"
         Top             =   600
         Width           =   2550
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   1
         Text            =   "0.000"
         Top             =   210
         Width           =   2550
      End
      Begin VB.Label Label7 
         Caption         =   "Unit/Sec"
         Height          =   255
         Left            =   4140
         TabIndex        =   11
         Top             =   1050
         Width           =   735
      End
      Begin VB.Label Label6 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   10
         Top             =   675
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   9
         Top             =   300
         Width           =   375
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel  : "
         Height          =   225
         Left            =   165
         TabIndex        =   8
         Top             =   1020
         Width           =   1230
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos :"
         Height          =   270
         Left            =   165
         TabIndex        =   7
         Top             =   660
         Width           =   1260
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos : "
         Height          =   225
         Left            =   165
         TabIndex        =   6
         Top             =   300
         Width           =   1140
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' OverridePosition.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.12.01
' >> [개요]: 이 예제는 거리오버라이드 함수의 사용법을 익히고 좌표계 설정에 따른
'    오버라이드 값의 지정 방법에 대해 학습하는 예제입니다.
' >> [중요]: 거리 오버라이드시 주의사항
'     1) 거리오버라이드 함수는 모션 구동중에만 정상적으로 구동됩니다. 다시말해
'        모션이 정지된 상태에서는 에러코드를 반환하며 무시됩니다.
'     2) AxmOverridePos(0, dOverridePos) 함수에서 사용하는 dOverridePos는 절대
'        위치가 아닌 전체 이동할 양에 대한 변경값(오버라이드 값)입니다.
'      3) 모션 가속, 등속, 감속 중일때 사용 가능하며, 모션이 정지한 후에는 지령을
'        내려도 무시 됩니다.
'     4) 전체 이동할 양은 설정된 구동좌표계에 따라 달라집니다. 예를들어 구동전
'        상대좌표로 설정되어있었다면 구동함수에 입력되는 dPos 값이 전체 이동량
'        이되며, 절대좌표로 설정되어있었다면 구동함수에 입력되는 dPos값에 현재
'        위치값을 뺀 값이 전체이동량이 됩니다.
'     Ex1) 현재 Command위치 100으로 가정
'       1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
'       2) AxmMoveStartPos(0, 200, ...)
'       -> 전체 이동량은 200(dPos) - 100(현재위치)으로 100이됩니다.
'     Ex2) 현재 Command위치 100으로 가정
'       1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
'       2) AxmMoveStartPos(0, 200, ...)
'       -> 전체 이동량은 200(dPos)이 됩니다.
' **************************************************************************

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_dOldCmdPos As Double
    Private m_dOldActPos As Double

    Private m_btmOverride(1) As String

    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
        m_dOldCmdPos = 0
        m_dOldActPos = 0#
        m_dOldCmdVel = 0#
            
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
    ' >> btnPosSet_Click() : "Position Setting"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 지정한 값으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosSet_Click()
        Dim dSetPos As Double
        dSetPos = edtSetPos.Text

        ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
        dwRetCode = AxmStatusSetPosMatch(m_lAxisNo, dSetPos)
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
    ' >> btnMove1_Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축을 "Move Target Pos" Edit콘트롤에 입력된 거리(또는 위치)/속도/
    '    가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMove1_Click()
        Dim dwRetCode As Long
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
        dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveStartPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSStop_Click() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSStop_Click()
        Dim dwRetCode As Long
        dwRetCode = AxmMoveSStop(m_lAxisNo)

        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveSStop return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> rdoAbs_Click(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 좌표계를 설정합니다.
    '  - 설정된 좌표계에 따라 구동 함수들에 전달되는 dPos의 값은 절대위치 또는
    '    상대 이동량이 됩니다.
    '  - Ex1) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
    '  - Ex2) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
    ' --------------------------------------------------------------------------
    Private Sub rdoAbs_Click()
        Dim dwRetCode As Long

        ' ++ 지정 축의 구동 좌표계를 설정합니다.
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_ABS_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If

        btmOverride.Picture = LoadPicture("PosOverrideAbs.bmp")

    End Sub

    Private Sub rdoRel_Click()
        Dim dwRetCode As Long

        ' ++ 지정 축의 구동 좌표계를 설정합니다.
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If

        btmOverride.Picture = LoadPicture("PosOverrideRel.bmp")
    End Sub

    ' ++ =======================================================================
    ' >> btnOverrideX_Click() : "Override Pos X"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축의 전체 이동량을 변경합니다.
    ' ※ [CAUTION] 거리오버라이드 함수는 모션 구동중에만 정상적으로 구동됩니다.
    '    다시말해 모션이 정지된 상태에서는 에러코드를 반환하며 무시됩니다.
    ' ※ [CAUTION] 모션 가속, 등속, 감속 중일때 사용 가능하며, 모션이 구동이 정지한
    '    후에는 지령을 내려도 무시 됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnOverride1_Click()
        Dim strData As String
        Dim dwRetCode As Long
        Dim dOverridePos As Double
        dOverridePos = edtOverrideDis1.Text

        ' ++ 지정 축의 구동이 종료되기 전 전체구동량을 변경합니다.
        dwRetCode = AxmOverridePos(m_lAxisNo, dOverridePos)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmOverridePos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    Private Sub btnOverride2_Click()
        Dim strData As String
        Dim dwRetCode As Long
        Dim dOverridePos As Double
        dOverridePos = edtOverrideDis2.Text

        ' ++ 지정 축의 구동이 종료되기 전 전체구동량을 변경합니다.
        dwRetCode = AxmOverridePos(m_lAxisNo, dOverridePos)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmOverridePos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer(...) : 타이머 이벤트 핸들러 함수.
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

        m_btmOverride(POS_ABS_MODE) = "PosOverrideAbs.bmp"
        m_btmOverride(POS_REL_MODE) = "PosOverrideRel.bmp"

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
        
        dwAbsRelMode = POS_ABS_MODE

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        dwRetCode = AxmSignalIsServoOn(m_lAxisNo, dwOnOff)
        chkServoOn.Value = dwOnOff

        ' ++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
        dwRetCode = AxmMotGetAbsRelMode(m_lAxisNo, dwAbsRelMode)
        If dwAbsRelMode = POS_ABS_MODE Then
            rdoAbs.Value = True
        Else
            rdoRel.Value = True
        End If

        btmOverride.Picture = LoadPicture(m_btmOverride(dwAbsRelMode))
        'btmOverride.Update()

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

