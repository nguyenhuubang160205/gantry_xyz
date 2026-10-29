VERSION 5.00
Object = "{3EACF94A-AC86-4C57-B5C8-470911DAC903}#1.1#0"; "AxtMessenger.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "TriggerSettingBlock"
   ClientHeight    =   7110
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7035
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7110
   ScaleWidth      =   7035
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame4 
      Caption         =   "< Trigger Setting Block >"
      Height          =   1440
      Left            =   90
      TabIndex        =   41
      Top             =   5595
      Width           =   6870
      Begin VB.CheckBox chkSetBlock 
         Caption         =   "Set Block"
         Height          =   300
         Left            =   5040
         Style           =   1  'Graphical
         TabIndex        =   54
         Top             =   990
         Width           =   1680
      End
      Begin VB.TextBox edtTrigStartPos 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1635
         TabIndex        =   44
         Text            =   "1000.0"
         Top             =   225
         Width           =   2400
      End
      Begin VB.TextBox edtTrigEndPos 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1620
         TabIndex        =   43
         Text            =   "1000.0"
         Top             =   615
         Width           =   2400
      End
      Begin VB.TextBox edtTrigPeriod 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1620
         TabIndex        =   42
         Text            =   "300.0"
         Top             =   990
         Width           =   2400
      End
      Begin VB.Line Line3 
         X1              =   5070
         X2              =   6705
         Y1              =   915
         Y2              =   915
      End
      Begin VB.Label Label24 
         Caption         =   "Block Start Position: "
         Height          =   225
         Left            =   165
         TabIndex        =   50
         Top             =   300
         Width           =   1545
      End
      Begin VB.Label Label23 
         Caption         =   "Block End Position :"
         Height          =   270
         Left            =   165
         TabIndex        =   49
         Top             =   660
         Width           =   1620
      End
      Begin VB.Label Label22 
         Caption         =   "Trigger Period        : "
         Height          =   225
         Left            =   165
         TabIndex        =   48
         Top             =   1020
         Width           =   1515
      End
      Begin VB.Label Label21 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   47
         Top             =   300
         Width           =   375
      End
      Begin VB.Label Label20 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   46
         Top             =   675
         Width           =   375
      End
      Begin VB.Label Label19 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   45
         Top             =   1050
         Width           =   735
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "< Trigger Setting Method >"
      Height          =   1635
      Left            =   90
      TabIndex        =   30
      Top             =   3945
      Width           =   6870
      Begin VB.CommandButton btnSetMethod 
         Caption         =   "Set Method"
         Height          =   285
         Left            =   5055
         TabIndex        =   53
         Top             =   1200
         Width           =   1665
      End
      Begin AXTMESSENGERLib.AxtMessenger AxtMsg 
         Height          =   345
         Left            =   3630
         TabIndex        =   51
         Top             =   1095
         Visible         =   0   'False
         Width           =   360
         _Version        =   65536
         _ExtentX        =   635
         _ExtentY        =   609
         _StockProps     =   0
         Message1        =   0
         Message2        =   0
         Message3        =   0
      End
      Begin VB.ComboBox cboIntUse 
         Height          =   315
         Left            =   5070
         TabIndex        =   39
         Top             =   645
         Width           =   1650
      End
      Begin VB.ComboBox cboTrigTarget 
         Height          =   315
         Left            =   1620
         TabIndex        =   37
         Top             =   1110
         Width           =   1665
      End
      Begin VB.TextBox edtTrigTime 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   1620
         TabIndex        =   33
         Text            =   "100.0"
         Top             =   255
         Width           =   1650
      End
      Begin VB.TextBox stcIntCount 
         Alignment       =   2  'Center
         BackColor       =   &H80000016&
         Height          =   360
         Left            =   5070
         TabIndex        =   32
         Text            =   "0"
         Top             =   210
         Width           =   1650
      End
      Begin VB.ComboBox cboTrigLevel 
         Height          =   315
         Left            =   1620
         TabIndex        =   31
         Top             =   705
         Width           =   1665
      End
      Begin VB.Label Label11 
         Caption         =   "Interrupt                : "
         Height          =   240
         Left            =   3615
         TabIndex        =   40
         Top             =   675
         Width           =   1455
      End
      Begin VB.Label Label8 
         Caption         =   "Trigger Target Sel  :"
         Height          =   240
         Left            =   165
         TabIndex        =   38
         Top             =   1140
         Width           =   1455
      End
      Begin VB.Label Label12 
         Caption         =   "Trigger Time(us)     :"
         Height          =   240
         Left            =   165
         TabIndex        =   36
         Top             =   360
         Width           =   1410
      End
      Begin VB.Label Label17 
         Caption         =   "Trigger Level Set   :"
         Height          =   240
         Left            =   165
         TabIndex        =   35
         Top             =   735
         Width           =   1455
      End
      Begin VB.Label Label18 
         Caption         =   "Int Count              : "
         Height          =   240
         Left            =   3630
         TabIndex        =   34
         Top             =   300
         Width           =   1410
      End
      Begin VB.Line Line1 
         X1              =   3450
         X2              =   3450
         Y1              =   225
         Y2              =   1470
      End
      Begin VB.Line Line2 
         X1              =   5070
         X2              =   6705
         Y1              =   1095
         Y2              =   1095
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   75
      TabIndex        =   26
      Top             =   15
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5055
         TabIndex        =   28
         Top             =   195
         Width           =   1665
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1620
         TabIndex        =   27
         Top             =   195
         Width           =   3315
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No       : "
         Height          =   300
         Left            =   165
         TabIndex        =   29
         Top             =   255
         Width           =   1590
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1440
      Left            =   75
      TabIndex        =   14
      Top             =   645
      Width           =   6885
      Begin VB.TextBox edtSetPos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   5055
         TabIndex        =   52
         Text            =   "0.000"
         Top             =   255
         Width           =   1680
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   300
         Left            =   5040
         Style           =   1  'Graphical
         TabIndex        =   19
         Top             =   990
         Width           =   1680
      End
      Begin VB.CommandButton btnPosSet 
         Caption         =   "Position Setting"
         Height          =   315
         Left            =   5040
         TabIndex        =   18
         Top             =   630
         Width           =   1680
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   17
         Text            =   "0.000"
         Top             =   990
         Width           =   2400
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   16
         Text            =   "0.000"
         Top             =   615
         Width           =   2400
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         BackColor       =   &H80000016&
         Enabled         =   0   'False
         Height          =   360
         Left            =   1620
         TabIndex        =   15
         Text            =   "0.000"
         Top             =   225
         Width           =   2400
      End
      Begin VB.Label Label7 
         Caption         =   "Unit/Sec"
         Height          =   255
         Left            =   4140
         TabIndex        =   25
         Top             =   1050
         Width           =   735
      End
      Begin VB.Label Label6 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   24
         Top             =   675
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4140
         TabIndex        =   23
         Top             =   300
         Width           =   375
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel        : "
         Height          =   225
         Left            =   165
         TabIndex        =   22
         Top             =   1020
         Width           =   1515
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos      :"
         Height          =   270
         Left            =   165
         TabIndex        =   21
         Top             =   660
         Width           =   1620
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos       : "
         Height          =   225
         Left            =   165
         TabIndex        =   20
         Top             =   300
         Width           =   1545
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Position Move >"
      Height          =   1800
      Left            =   90
      TabIndex        =   0
      Top             =   2115
      Width           =   6870
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   5115
         Top             =   150
      End
      Begin VB.OptionButton rdoAbs 
         Caption         =   "[00] Absolute"
         Height          =   285
         Left            =   1680
         TabIndex        =   7
         Top             =   300
         Width           =   1545
      End
      Begin VB.OptionButton rdoRel 
         Caption         =   "[01] Relative"
         Height          =   285
         Left            =   3270
         TabIndex        =   6
         Top             =   315
         Width           =   1545
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   5
         Text            =   "100.0"
         Top             =   690
         Width           =   2355
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   4
         Text            =   "100.0"
         Top             =   1020
         Width           =   2355
      End
      Begin VB.TextBox edtMoveAccDec 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1620
         TabIndex        =   3
         Text            =   "400.0"
         Top             =   1350
         Width           =   2355
      End
      Begin VB.CommandButton btnMove 
         Caption         =   "Move Target"
         Height          =   285
         Left            =   5055
         TabIndex        =   2
         Top             =   660
         Width           =   1665
      End
      Begin VB.CommandButton btnSStop 
         Caption         =   "Move SStop"
         Height          =   540
         Left            =   5055
         TabIndex        =   1
         Top             =   1035
         Width           =   1665
      End
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   5625
         Top             =   120
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Label Label16 
         Caption         =   "Unit/Sec^2"
         Height          =   195
         Left            =   4095
         TabIndex        =   13
         Top             =   1395
         Width           =   825
      End
      Begin VB.Label Label9 
         Caption         =   "Target Position      : "
         Height          =   240
         Left            =   165
         TabIndex        =   12
         Top             =   720
         Width           =   1410
      End
      Begin VB.Label Label10 
         Caption         =   "Unit"
         Height          =   195
         Left            =   4110
         TabIndex        =   11
         Top             =   735
         Width           =   480
      End
      Begin VB.Label Label13 
         Caption         =   "Move Velocity       : "
         Height          =   240
         Left            =   165
         TabIndex        =   10
         Top             =   1050
         Width           =   1410
      End
      Begin VB.Label Label14 
         Caption         =   "Unit/Sec"
         Height          =   195
         Left            =   4095
         TabIndex        =   9
         Top             =   1065
         Width           =   780
      End
      Begin VB.Label Label15 
         Caption         =   "Move Accel/Decel: "
         Height          =   240
         Left            =   150
         TabIndex        =   8
         Top             =   1380
         Width           =   1410
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' TriggerSettingBlock.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.12.22
' >> [개요]: 이 예제는 비젼트리거 함수들중 모션 구동중 트리거 시작위치에서 일정한
'    간격으로 트리거를 발생시키고 종료 위치를 만나면 트리거 출력을 정지하는 방식의
'    AxmTriggerSetBlock함수 사용법과 기능을 테스트하는 예제입니다.
' >> [중요]: Block 트리거에 대해서
'     1) 이 함수는 모션 콘트롤 칩의 트리거 기능을 사용하므로 구동속도에 영향을
'        받지않습니다.
'     2) 한번 설정하면 Reset하기 전에는 해당영역을 지날 때 계속 트리거가 발생됩니다.
'     3) 트리거 설정범위는 트리거 영역의 개념으로 구동방향에 상관없이 해당영역에
'        진입하면 트리거가 발생됩니다.
' **************************************************************************

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_dOldCmdPos As Double
    Private m_dOldActPos As Double
    Private m_dOldCmdVel As Double
    Private m_isFakeMessage As Boolean

    Public g_lIntCount As Long
    Public g_lIntCntOld As Long

    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
        m_dOldCmdPos = 0#
        m_dOldActPos = 0#
        m_dOldCmdVel = 0#
        m_isFakeMessage = False
        
        g_lIntCount = 0
        g_lIntCntOld = 0
    
        InitLibrary
        AddAxisInfo
        UpdateState
    End Sub

    ' **************************************************************************
    ' >> [구분]: control에 이벤트가 발생했을 때 처리하는 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelAxis_Click() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 id와 control들을 갱신합니다.
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
    ' >> rdoAbs_Click() : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
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
    ' >> btnMove_Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축을 "Position Move" Edit콘트롤에 입력된 거리(또는 위치)/속도/
    '    가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMove_Click()
        Dim dwRetCode As Long
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double
        
        dwRetCode = 0

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAccDec.Text
        dMoveDec = dMoveAcc

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
        dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveStartPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click()
        Dim dwRetCode As Long
        
        dwRetCode = AxmMoveSStop(m_lAxisNo)

        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveSStop return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSetMethod_Click() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 트리거 펄스출력 시간, 트리거 레벨, 인터럽트사용 유무를 설정하고
    '    트리거 기능을 활성화/비활성화 시킵니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetMethod_Click()
        Dim strData As String
        Dim dTrigTime As Double
        Dim dwRetCode, dwTrigLevel, dwTrigTarget, dwIntUse As Long
        Dim lEvent, lProc As Long
        
        strData = ""
        dTrigTime = 0#
        
        dTrigTime = edtTrigTime.Text
        dwTrigLevel = ConvertComboToAxm(cboTrigLevel)
        dwTrigTarget = ConvertComboToAxm(cboTrigTarget)
        dwIntUse = ConvertComboToAxm(cboIntUse)

        ' ++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 설정합니다.
        dwRetCode = AxmTriggerSetTimeLevel(m_lAxisNo, dTrigTime, dwTrigLevel, dwTrigTarget, dwIntUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmTriggerSetTimeLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If

        If dwIntUse = ENABLE Then
            ' ++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
            AxtMsg.Message1 = WM_AXL_INTERRUPT
            dwRetCode = AxmInterruptSetAxis(m_lAxisNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, lEvent, lProc)
            ' ++ AXL라이브러리의 인터럽트 발생을 허용합니다.
            dwRetCode = AxlInterruptEnable()
            ' ++ 지정한 축에 인터럽트 발생을 허용합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE)
        Else
            ' ++ AXL라이브러리의 인터럽트 발생을 금지합니다.
            dwRetCode = AxlInterruptDisable()
            ' ++ 지정한 축에 인터럽트 발생을 금지합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkSetBlock_Click() : "Set Block"버튼 클릭시 호출되는 핸들러 함수.
    '  - Block트리거 함수를 설정합니다.
    '  - AxmTriggerSetReset함수로 트리거 설정을 해제하면 트리거가 발생되지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub chkSetBlock_Click()
        Dim strData As String
        Dim dwRetCode As Long
        Dim dStartPos, dEndPos, dPeriod As Double
        
        strData = ""
        dwRetCode = 0

        If chkSetBlock.Value Then
            dStartPos = edtTrigStartPos.Text
            dEndPos = edtTrigEndPos.Text
            dPeriod = edtTrigPeriod.Text

            ' ++ 사용자가 지정한 하한영역 위치부터 상한영역 위치까지 지정한 간격으로 트리거를 출력합니다.
            '  - 한번 설정한 트리거 영역은 트리거 발생여부와 상관없이 AxmTriggerSetReset함수로 트리거 설정을
            '    해제하기 전 까지 유효합니다.
            dwRetCode = AxmTriggerSetBlock(m_lAxisNo, dStartPos, dEndPos, dPeriod)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmTriggerSetBlock return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If

            g_lIntCount = 0
        Else
            ' ++ 트리거 발생영역을 해제 합니다.
            dwRetCode = AxmTriggerSetReset(m_lAxisNo)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmTriggerSetReset return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer() : 타이머 이벤트 핸들러 함수.
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

        ' 인터럽트 발생 카운터값을 출력합니다.
        If g_lIntCntOld <> g_lIntCount Then
            stcIntCount.Text = Format(g_lIntCount, "0")
            g_lIntCntOld = g_lIntCount
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
        cboTrigLevel.AddItem ("00: LOW")
        cboTrigLevel.AddItem ("01: HIGH")
        
        cboTrigTarget.AddItem ("00: COMMAND")
        cboTrigTarget.AddItem ("01: ACTUAL")
        
        cboIntUse.AddItem ("00: DISABLE")
        cboIntUse.AddItem ("01: ENABLE")
        
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
        Dim dTrigTime, dStartPos, dEndPos, dPeriod As Double
        Dim dwTrigLevel, dwTrigTarget, dwIntUse As Long
        
        dwAbsRelMode = POS_ABS_MODE
        dwOnOff = 0

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

        ' ++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 확인합니다.
        dwRetCode = AxmTriggerGetTimeLevel(m_lAxisNo, dTrigTime, dwTrigLevel, dwTrigTarget, dwIntUse)
        edtTrigTime.Text = Format(dTrigTime, "0.000")
        dwRetCode = ConvertAxmToCombo(cboTrigLevel, dwTrigLevel)
        dwRetCode = ConvertAxmToCombo(cboTrigTarget, dwTrigTarget)
        dwRetCode = ConvertAxmToCombo(cboIntUse, dwIntUse)

        ' ++ 지정 축에 설정된 Block 트리거 하한영역, 상한영역, 트리거 간격으로 트리거을 확인합니다.
        dwTrigLevel = AxmTriggerGetBlock(m_lAxisNo, dStartPos, dEndPos, dPeriod)
        edtTrigStartPos.Text = Format(dStartPos, "0.000")
        edtTrigEndPos.Text = Format(dEndPos, "0.000")
        edtTrigPeriod.Text = Format(dPeriod, "0.000")

        UpdateState = True
    End Function

    ' ++ =======================================================================
    ' >> AxtMsg_OnMessage1(...) : 인터럽트 메시지 핸들러 함수.
    '  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
    '    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub AxtMsg_OnMessage1(ByVal wParam As Long, ByVal lParam As Long)
        If m_isFakeMessage Then
            m_isFakeMessage = False     ' 플래그 해제
        Else
            g_lIntCount = g_lIntCount + 1  ' 트리거 인터럽트 발생시 카운트값을 증가시킵니다.
            m_isFakeMessage = True      ' 동일하게 호출되는 두번째 메시지를 무시하기 위한 플래그 설정
        End If
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

