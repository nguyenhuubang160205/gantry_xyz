VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "HomeSearch"
   ClientHeight    =   7395
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7095
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7395
   ScaleWidth      =   7095
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame4 
      Caption         =   "< Home Method Setting >"
      Height          =   1410
      Left            =   120
      TabIndex        =   42
      Top             =   2850
      Width           =   6885
      Begin VB.TextBox edtHomeClrTime 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1560
         TabIndex        =   48
         Top             =   975
         Width           =   1800
      End
      Begin VB.TextBox edtHomeOffset 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1560
         TabIndex        =   47
         Top             =   615
         Width           =   1800
      End
      Begin VB.CommandButton btnSetMethod 
         Caption         =   "Set Method"
         Height          =   300
         Left            =   4890
         TabIndex        =   46
         Top             =   1005
         Width           =   1860
      End
      Begin VB.ComboBox cboZPhaseUse 
         Height          =   315
         Left            =   4890
         TabIndex        =   45
         Top             =   630
         Width           =   1875
      End
      Begin VB.ComboBox cboHomeSignal 
         Height          =   315
         Left            =   4890
         TabIndex        =   44
         Top             =   255
         Width           =   1875
      End
      Begin VB.ComboBox cboHomeDir 
         Height          =   315
         Left            =   1560
         TabIndex        =   43
         Top             =   240
         Width           =   1800
      End
      Begin VB.Label Label14 
         Caption         =   "Z Phase Use    :"
         Height          =   180
         Left            =   3690
         TabIndex        =   54
         Top             =   660
         Width           =   1230
      End
      Begin VB.Label Label13 
         Caption         =   "Home Signal     :"
         Height          =   210
         Left            =   3690
         TabIndex        =   53
         Top             =   285
         Width           =   1170
      End
      Begin VB.Label Label12 
         Caption         =   "mSec"
         Height          =   195
         Left            =   3390
         TabIndex        =   52
         Top             =   1035
         Width           =   480
      End
      Begin VB.Label Label11 
         Caption         =   "Home Clr Time    :"
         Height          =   300
         Left            =   240
         TabIndex        =   51
         Top             =   990
         Width           =   1305
      End
      Begin VB.Label Label10 
         Caption         =   "Home Set Offset :"
         Height          =   315
         Left            =   240
         TabIndex        =   50
         Top             =   645
         Width           =   1320
      End
      Begin VB.Label Label9 
         Caption         =   "Home Direction   : "
         Height          =   360
         Left            =   240
         TabIndex        =   49
         Top             =   285
         Width           =   1275
      End
      Begin VB.Line Line2 
         X1              =   3480
         X2              =   3480
         Y1              =   195
         Y2              =   930
      End
   End
   Begin VB.Frame Frame6 
      Caption         =   "< Home Search >"
      Height          =   1065
      Left            =   120
      TabIndex        =   34
      Top             =   6255
      Width           =   6885
      Begin ComctlLib.ProgressBar prgHomeRate 
         Height          =   315
         Left            =   2850
         TabIndex        =   55
         Top             =   645
         Width           =   1935
         _ExtentX        =   3413
         _ExtentY        =   556
         _Version        =   327682
         Appearance      =   1
      End
      Begin VB.TextBox stcHomeStepSub 
         Enabled         =   0   'False
         Height          =   285
         Left            =   2205
         TabIndex        =   41
         Top             =   645
         Width           =   615
      End
      Begin VB.TextBox stcHomeStepMain 
         Enabled         =   0   'False
         Height          =   285
         Left            =   1560
         TabIndex        =   40
         Top             =   645
         Width           =   615
      End
      Begin VB.CommandButton btnMoveStop 
         Caption         =   "Move Stop"
         Height          =   300
         Left            =   4890
         TabIndex        =   38
         Top             =   615
         Width           =   1860
      End
      Begin VB.CommandButton btnHomeStart 
         Caption         =   "Home Start"
         Height          =   300
         Left            =   4890
         TabIndex        =   37
         Top             =   210
         Width           =   1860
      End
      Begin VB.TextBox stcHomeResult 
         Enabled         =   0   'False
         Height          =   330
         Left            =   1560
         TabIndex        =   36
         Text            =   " [FFH] HOME_ERR_UNKNOWN"
         Top             =   210
         Width           =   3240
      End
      Begin VB.Label Label22 
         Caption         =   "Home Step/Rate:"
         Height          =   240
         Left            =   285
         TabIndex        =   39
         Top             =   645
         Width           =   1350
      End
      Begin VB.Label Label21 
         Caption         =   "Home Result :"
         Height          =   240
         Left            =   285
         TabIndex        =   35
         Top             =   285
         Width           =   975
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "< Home Velocity Setting >"
      Height          =   1875
      Left            =   120
      TabIndex        =   20
      Top             =   4320
      Width           =   6885
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   4485
         Top             =   975
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Timer m_timerHomeInfo 
         Interval        =   200
         Left            =   4065
         Top             =   1005
      End
      Begin VB.Timer m_timerDisplay 
         Interval        =   100
         Left            =   3645
         Top             =   1005
      End
      Begin VB.CommandButton btnSetVelocity 
         Caption         =   "Set Velocity"
         Height          =   300
         Left            =   4890
         TabIndex        =   33
         Top             =   1410
         Width           =   1860
      End
      Begin VB.TextBox edtAccSecond 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   4935
         TabIndex        =   32
         Top             =   660
         Width           =   1800
      End
      Begin VB.TextBox edtAccFirst 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   4935
         TabIndex        =   31
         Top             =   300
         Width           =   1800
      End
      Begin VB.TextBox edtVelLast 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1590
         TabIndex        =   28
         Top             =   1410
         Width           =   1800
      End
      Begin VB.TextBox edtVelThird 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1575
         TabIndex        =   27
         Top             =   1050
         Width           =   1800
      End
      Begin VB.TextBox edtVelSecond 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1575
         TabIndex        =   26
         Top             =   675
         Width           =   1800
      End
      Begin VB.TextBox edtVelFirst 
         Alignment       =   1  'Right Justify
         Height          =   315
         Left            =   1575
         TabIndex        =   25
         Top             =   315
         Width           =   1800
      End
      Begin VB.Label Label20 
         Caption         =   "Second Accel   :"
         Height          =   195
         Left            =   3705
         TabIndex        =   30
         Top             =   705
         Width           =   1545
      End
      Begin VB.Label Label19 
         Caption         =   "First Accel         :"
         Height          =   195
         Left            =   3720
         TabIndex        =   29
         Top             =   345
         Width           =   1560
      End
      Begin VB.Label Label18 
         Caption         =   "Last Velocity       :"
         Height          =   195
         Left            =   240
         TabIndex        =   24
         Top             =   1440
         Width           =   1320
      End
      Begin VB.Label Label17 
         Caption         =   "Third Velocity      :"
         Height          =   195
         Left            =   240
         TabIndex        =   23
         Top             =   1080
         Width           =   1320
      End
      Begin VB.Label Label16 
         Caption         =   "Second Velocity  :"
         Height          =   195
         Left            =   240
         TabIndex        =   22
         Top             =   720
         Width           =   1320
      End
      Begin VB.Label Label15 
         Caption         =   "First Velocity        :"
         Height          =   195
         Left            =   240
         TabIndex        =   21
         Top             =   360
         Width           =   1320
      End
      Begin VB.Line Line3 
         X1              =   3495
         X2              =   3495
         Y1              =   210
         Y2              =   1725
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Home Signal Level >"
      Height          =   630
      Left            =   120
      TabIndex        =   16
      Top             =   2175
      Width           =   6885
      Begin VB.ComboBox cboHomeLevel 
         Height          =   315
         Left            =   4905
         TabIndex        =   18
         Top             =   225
         Width           =   1875
      End
      Begin VB.CheckBox chkHomeState 
         Caption         =   "Home Signal State"
         Enabled         =   0   'False
         Height          =   225
         Left            =   180
         TabIndex        =   17
         Top             =   285
         Width           =   2640
      End
      Begin VB.Label Label8 
         Caption         =   "Home Level      : "
         Height          =   270
         Left            =   3690
         TabIndex        =   19
         Top             =   270
         Width           =   1440
      End
      Begin VB.Line Line1 
         X1              =   3465
         X2              =   3465
         Y1              =   180
         Y2              =   555
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1440
      Left            =   120
      TabIndex        =   4
      Top             =   720
      Width           =   6885
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   330
         Left            =   5430
         Style           =   1  'Graphical
         TabIndex        =   15
         Top             =   960
         Width           =   1320
      End
      Begin VB.CommandButton btnPosClear 
         Caption         =   "Position Clear"
         Height          =   585
         Left            =   5430
         TabIndex        =   14
         Top             =   255
         Width           =   1320
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   10
         Text            =   "0.000"
         Top             =   975
         Width           =   2910
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   9
         Text            =   "0.000"
         Top             =   600
         Width           =   2910
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   1440
         TabIndex        =   8
         Text            =   "0.000"
         Top             =   210
         Width           =   2910
      End
      Begin VB.Label Label7 
         Caption         =   "Unit/Sec"
         Height          =   255
         Left            =   4410
         TabIndex        =   13
         Top             =   1050
         Width           =   735
      End
      Begin VB.Label Label6 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4410
         TabIndex        =   12
         Top             =   675
         Width           =   375
      End
      Begin VB.Label Label5 
         Caption         =   "Unit"
         Height          =   255
         Left            =   4410
         TabIndex        =   11
         Top             =   300
         Width           =   375
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel    : "
         Height          =   225
         Left            =   165
         TabIndex        =   7
         Top             =   1020
         Width           =   1230
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos   :"
         Height          =   270
         Left            =   165
         TabIndex        =   6
         Top             =   660
         Width           =   1260
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos    : "
         Height          =   225
         Left            =   150
         TabIndex        =   5
         Top             =   285
         Width           =   1680
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   120
      TabIndex        =   0
      Top             =   15
      Width           =   6885
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5445
         TabIndex        =   3
         Top             =   195
         Width           =   1305
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1410
         TabIndex        =   2
         Top             =   210
         Width           =   3915
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No : "
         Height          =   300
         Left            =   150
         TabIndex        =   1
         Top             =   255
         Width           =   1245
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' HomeSearch.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.11.27
' >> [개요]: 이 예제는 원점검색 함수들의 사용법을 익히고 원점검색 방법과 각
'    단계별 사용하는 원점검색 속도 설정법을 이해하여 빠르고 정밀한 원점 검색
'    방법에 대해 학습하는 예제입니다.
' >> [중요]: 원점검색 방법 및 원점검색 단계별 속도사용에 대해
'     1) 원점검색은 기본적으로 5번의 신호검출 과정을 거쳐 완료됩니다.
'     2) 원점센서 검출 여부를 판단하여 원점검색 진행 방향으로 신호를 검출할 지
'        원점검색 반대방향으로 신호검출을 진행할지를 판단합니다.
'     3) 1차 원점신호 감지시에는 가감속이 있는 구동을 하여 비교적 빠른 속도로
'        원점신호를 감지합니다.
'     4) 1차 원점신호 감지 후 반대방향으로 2단계 속도로 1차 때와 마찬가지로
'        가감속이 있는 구동을 하여 기구물이 원점센서의 검색진행 반대편에 위치
'        하도록 합니다.
'     5) 3단계 속도를 이용하여 가감속이 없이 원점신호를 검출하게 됩니다.
'     6) 이 후 Z상검출 사용여부에 따라 4단계/5단계 신호 검출을 하여 빠르고
'        정밀하게 원점검출을 완료하게 됩니다.
' >> [중요]: 원점검색 속도설정에 대해
'     1) dVelFirst: 초기 원점신호가 감지되지 않았을 때 원점신호 검색 방향으로
'        On 상태를 검출할 때의 속도
'     2) dVelSecond: 초기 원점신호가 감지되어 있어 원점신호 검색 반대 방향으로
'        Off 상태를 검출할 때의 속도
'     3) dVelFirst, dVelSecond속도는 원점검색 반복 정밀도 보다는 원점검색 시간과
'        관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 빠르게 설정합니다.
'     4) dVelThird: 1차 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
'     5) dVelLasts: 최종 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
'     6) dVelLasts속도는 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이
'        있으므로 10 PPS정도 설정하면 정밀하게 원점검색을 구현 할 수 있습니다.
' **************************************************************************

    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private m_dwOldResult As Long
    Private m_dOldCmdPos As Double
    Private m_dOldActPos As Double
    Private m_dOldCmdVel As Double
    
    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
        m_dwOldResult = HOME_ERR_UNKNOWN
        m_dOldCmdPos = 0#
        m_dOldActPos = 0#
        m_dOldCmdVel = 0#
    
        InitLibrary               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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

        UpdateState         ' 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
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
    '// >> cboHomeLevel_Change() : "Home Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '//  - 선택된 축의 원점신호 Active Level을 설정합니다.
    '// ※ [CAUTION] 특정 네트웍 제품의 경우 원점신호레벨 변경을 지원하지않습니다.
    '// --------------------------------------------------------------------------
    Private Sub cboHomeLevel_Change()
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmHomeSetSignalLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboHomeLevel)
            ' ++ 지정한 축의 원점신호 Active Level을 변경합니다.
            dwRetCode = AxmHomeSetSignalLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                Dim strData As String
                strData = "AxmHomeSetSignalLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSetMethod_Click() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 원점검색 방향, 신호, Z상 검출여부, Offset등을 설정합니다.
    '  - 원점검색시 Z상 신호의 검출을 사용함으로 설정하였을 경우 1차로 지정한
    '    원점신호를 검출 완료한 후 Z상 신호를 추가적으로 검출하게 됩니다.
    ' ※ [CAUTION] Z상의 경우 모터와 Ballscrew를 연결해주는 커플링이 풀리거나
    '    해체할 경우 Z상 위치가 변경되므로 원점검색 위치가 달라지게됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetMethod_Click()
        Dim lHomeDir As Long
        Dim dwRetCode As Long
        Dim dwHomeSignal As Long
        Dim dwZPhaseUse As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Double
        
        lHomeDir = 0
        dwRetCode = 0
        dwHomeSignal = HomeSensor
        dwZPhaseUse = DISABLE
        dHomeClrTime = 0#
        dHomeOffset = 0#
        
        lHomeDir = ConvertComboToAxm(cboHomeDir)
        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwZPhaseUse = ConvertComboToAxm(cboZPhaseUse)
        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text

        ' ++ 지정한 축의 원점검색 방법을 변경합니다.
        dwRetCode = AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetMethod return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSetVelocity_Click() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 단계별 원점검색 속도를 설정합니다.
    '  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
    ' ※ [CAUTION] dVelFirst, dVelSecond는 초기 원점검색 속도로 원점검색 반복 정밀도
    '    보다는 원점검색 시간과 관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는
    '    비교적 빠르게 설정하고 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이
    '    있는 dVelLasts속도 10 PPS정도에 설정하면 빠르고 정밀하게 원점검색을 구현
    '    할 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetVelocity_Click()
        Dim dwRetCode As Long
        Dim dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond As Double
        
        dwRetCode = 0

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dVelFirst = edtVelFirst.Text
        dVelSecond = edtVelSecond.Text
        dVelThird = edtVelThird.Text
        dVelLast = edtVelLast.Text
        dAccFirst = edtAccFirst.Text
        dAccSecond = edtAccSecond.Text

        ' ++ 원점검색에 사용되는 단계별 속도를 설정합니다.
        dwRetCode = AxmHomeSetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStart_Click() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축으로 원점검색을 진행합니다.
    '  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
    ' ※ [CAUTION] 원점검색시 라이브러리 내부에서 해당축의 원점검색을 수행 할 쓰레드가
    '    자동 생성되어 원점검색을 순차적으로 수행한 후 자동 종료됩니다. 따라서 단일
    '    CPU시스템의 경우 사용자 프로그램에서 CPU를 100% 점유할 경우 원점 검색 진행이
    '    원할하게 되지 않을 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStart_Click()
        Dim dwRetCode As Long

        ' ++ 지정한 축에 원점검색을 진행합니다.
        dwRetCode = AxmHomeSetStart(m_lAxisNo)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetStart return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동을 종료합니다. 만약 원점검색 중이면 검색을 중단하고 원점검색
    '    결과를 HOME_ERR_USER_BREAK로 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click()
        ' ++ 지정한 축의 구동을 감속정지합니다.
        dwRetCode = AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> m_timerDisplay_Timer(...) : 일반 정보 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerDisplay_Timer()
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

    ' ++ =======================================================================
    ' >> m_timerHomeInfo_Timer(...) : 호밍 정보 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 호밍 작업 정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerHomeInfo_Timer()
        Dim dwRetCode As Long
        Dim dwState As Long
        Dim dwStepMain As Long
        Dim dwStepSub As Long
        
        dwRetCode = 0
        dwState = 0
        swstepmain = 0
        dwStepSub = 0

        ' ++ 지정한 축의 원점신호의 상태를 확인합니다.
        dwRetCode = AxmHomeReadSignal(m_lAxisNo, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeState.Value = dwState
        End If

        ' ++ 지정한 축의 원점검색 결과를 확인합니다.
        dwRetCode = AxmHomeGetResult(m_lAxisNo, dwState)
        If m_dwOldResult <> dwState Then
            stcHomeResult.Text = TranslateHomeResult(dwState)
            m_dwOldResult = dwState
        End If

        ' ++ 지정한 축의 원점검색 진행율을 확인합니다.
        dwRetCode = AxmHomeGetRate(m_lAxisNo, dwStepMain, dwStepSub)
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
        Dim res As Integer
        If AxlOpen(7) <> AXT_RT_SUCCESS Then
            res = MsgBox("AxlOpen Fail...", vbOKCancel)
            InitLibrary = False
            Exit Function
        End If

        Dim szFilePath As String
        szFilePath = "..\..\..\..\EzSoftware\MotionDefault.mot"
        If AxmMotLoadParaAll(szFilePath) <> AXT_RT_SUCCESS Then
            res = MsgBox("Mot File Not Found.", vbOKCancel)
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
        Dim lpBoardNo As Long
        Dim lpModulePosAs As Long
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

        cboHomeDir.Clear
        cboHomeDir.Enabled = True
        cboHomeDir.AddItem ("00: -DIR_CCW")
        cboHomeDir.AddItem ("01: +DIR_CW")

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

        Dim lHomeDir As Long
        Dim dwRetCode As Long
        Dim dwLevel As Long
        Dim dwHomeSignal As Long
        Dim dwZPhaseUse As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Double

        Dim dVelFirst As Double
        Dim dVelSecond As Double
        Dim dVelThird As Double
        Dim dVelLast As Double
        Dim dAccFirst As Double
        Dim dAccSecond As Double
        Dim res As Double
        
        
        lHomeDir = 0
        dwRetCode = 0
        dwLevel = 0
        dwHomeSignal = 0
        dwZPhaseUse = 0
        dHomeClrTime = 0#
        dHomeOffset = 0#

        dVelFirst = 100#
        dVelSecond = 10#
        dVelThird = 5#
        dVelLast = 1#
        dAccFirst = 400#
        dAccSecond = 40#

        ' 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
        Select Case m_dwModuleId
            Case AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM, _
                AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W, AXT_ECAT_MOTION

                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("00:LOW")
                cboHomeLevel.AddItem ("01:HIGH")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")
                cboHomeSignal.AddItem ("05:EncodZPhase")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:DISABLE")
                cboZPhaseUse.AddItem ("01:DIR_CHOME")
                cboZPhaseUse.AddItem ("02:DIR_HOME")

            Case AXT_SMC_R1V04A4
                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("01:HIGH")
                cboHomeLevel.AddItem ("02:UNUSED")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:DISABLE")
                cboZPhaseUse.AddItem ("01:DIR_CHOME")
                cboZPhaseUse.AddItem ("02:DIR_HOME")

            Case AXT_SMC_R1V04MLIIPM
                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("01:HIGH")
                cboHomeLevel.AddItem ("02:UNUSED")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = False
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.AddItem ("00:DISABLE")

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, _
                AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboHomeLevel.Clear
                cboHomeLevel.Enabled = True
                cboHomeLevel.AddItem ("01:HIGH")
                cboHomeLevel.AddItem ("02:UNUSED")

                cboHomeSignal.Clear
                cboHomeSignal.Enabled = True
                cboHomeSignal.AddItem ("00:PosEndLimit")
                cboHomeSignal.AddItem ("01:NegEndLimit")
                cboHomeSignal.AddItem ("04:HomeSensor")

                cboZPhaseUse.Clear
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.AddItem ("00:DISABLE")
                cboZPhaseUse.AddItem ("01:DIR_CHOME")
                cboZPhaseUse.AddItem ("02:DIR_HOME")

            Case Else

        End Select

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        dwRetCode = AxmSignalIsServoOn(m_lAxisNo, dwLevel)
        chkServoOn.Value = dwLevel

        ' ++ 선택한 축의 원점신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmHomeGetSignalLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboHomeLevel, dwLevel)

        ' ++ 선택한 축의 원점검출 속도 설정값을 확인합니다.
        dwRetCode = AxmHomeGetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        edtVelFirst.Text = Format(dVelFirst, "0.000")
        edtVelSecond.Text = Format(dVelSecond, "0.000")
        edtVelThird.Text = Format(dVelThird, "0.000")
        edtVelLast.Text = Format(dVelLast, "0.000")
        edtAccFirst.Text = Format(dAccFirst, "0.000")
        edtAccSecond.Text = Format(dAccSecond, "0.000")

        ' ++ 선택한 축의 원점검출 방법 설정값을 확인합니다.
        dwRetCode = AxmHomeGetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        res = ConvertAxmToCombo(cboHomeDir, lHomeDir)
        res = ConvertAxmToCombo(cboHomeSignal, dwHomeSignal)
        res = ConvertAxmToCombo(cboZPhaseUse, dwZPhaseUse)
        edtHomeClrTime.Text = Format(dHomeClrTime, "0.000")
        edtHomeOffset.Text = Format(dHomeOffset, "0.000")

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
