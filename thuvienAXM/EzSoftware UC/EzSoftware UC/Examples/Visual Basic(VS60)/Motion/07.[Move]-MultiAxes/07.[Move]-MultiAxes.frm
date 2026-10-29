VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "MoveMultiAxes"
   ClientHeight    =   7605
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7095
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7605
   ScaleWidth      =   7095
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame5 
      Caption         =   "< Multi Jog ( Velocity ) Line Move >"
      Height          =   1530
      Left            =   105
      TabIndex        =   68
      Top             =   6000
      Width           =   6885
      Begin VB.TextBox edtLinePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   77
         Text            =   "100.000"
         Top             =   360
         Width           =   990
      End
      Begin VB.TextBox edtLinePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   76
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtLinePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   75
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtLinePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   74
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtLineVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1350
         TabIndex        =   73
         Text            =   "100.000"
         Top             =   720
         Width           =   2115
      End
      Begin VB.TextBox edtLineAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1350
         TabIndex        =   72
         Text            =   "400.000"
         Top             =   1065
         Width           =   2115
      End
      Begin VB.TextBox edtLineDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   3615
         TabIndex        =   71
         Text            =   "200.000"
         Top             =   1080
         Width           =   2130
      End
      Begin VB.CommandButton btnLineP 
         Caption         =   "Jog ( + )"
         Height          =   450
         Left            =   5790
         TabIndex        =   70
         Top             =   375
         Width           =   945
      End
      Begin VB.CommandButton btnLineN 
         Caption         =   "Jog ( - )"
         Height          =   450
         Left            =   5790
         TabIndex        =   69
         Top             =   900
         Width           =   945
      End
      Begin VB.Label Label14 
         Caption         =   "Target Position  :"
         Height          =   240
         Left            =   120
         TabIndex        =   80
         Top             =   390
         Width           =   1215
      End
      Begin VB.Label Label13 
         Caption         =   "Move Velocity   :"
         Height          =   240
         Left            =   120
         TabIndex        =   79
         Top             =   750
         Width           =   1245
      End
      Begin VB.Label Label12 
         Caption         =   "Move Acc/Dec :"
         Height          =   225
         Left            =   120
         TabIndex        =   78
         Top             =   1110
         Width           =   1230
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Multi Jog ( Velocity ) Move >"
      Height          =   1530
      Left            =   105
      TabIndex        =   43
      Top             =   4425
      Width           =   6885
      Begin VB.CommandButton btnJogN 
         Caption         =   "Jog ( - )"
         Height          =   450
         Left            =   5790
         TabIndex        =   66
         Top             =   900
         Width           =   945
      End
      Begin VB.CommandButton btnJogP 
         Caption         =   "Jog ( + )"
         Height          =   450
         Left            =   5790
         TabIndex        =   65
         Top             =   375
         Width           =   945
      End
      Begin VB.TextBox edtJogDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   55
         Text            =   "400.000"
         Top             =   1080
         Width           =   990
      End
      Begin VB.TextBox edtJogDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   54
         Text            =   "400.000"
         Top             =   1080
         Width           =   990
      End
      Begin VB.TextBox edtJogDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   53
         Text            =   "400.000"
         Top             =   1080
         Width           =   990
      End
      Begin VB.TextBox edtJogDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   52
         Text            =   "400.000"
         Top             =   1065
         Width           =   990
      End
      Begin VB.TextBox edtJogAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   51
         Text            =   "400.000"
         Top             =   735
         Width           =   990
      End
      Begin VB.TextBox edtJogAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   50
         Text            =   "400.000"
         Top             =   735
         Width           =   990
      End
      Begin VB.TextBox edtJogAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   49
         Text            =   "400.000"
         Top             =   735
         Width           =   990
      End
      Begin VB.TextBox edtJogAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   48
         Text            =   "400.000"
         Top             =   720
         Width           =   990
      End
      Begin VB.TextBox edtJogVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   47
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtJogVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   46
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtJogVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   45
         Text            =   "100.000"
         Top             =   375
         Width           =   990
      End
      Begin VB.TextBox edtJogVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   44
         Text            =   "100.000"
         Top             =   360
         Width           =   990
      End
      Begin VB.Label Label10 
         Caption         =   "Move Decel     :"
         Height          =   225
         Left            =   120
         TabIndex        =   58
         Top             =   1110
         Width           =   1140
      End
      Begin VB.Label Label9 
         Caption         =   "Move Accel      :"
         Height          =   240
         Left            =   120
         TabIndex        =   57
         Top             =   750
         Width           =   1245
      End
      Begin VB.Label Label8 
         Caption         =   "Move Velocity   :"
         Height          =   240
         Left            =   120
         TabIndex        =   56
         Top             =   390
         Width           =   1215
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Multi Position Move >"
      Height          =   1920
      Left            =   105
      TabIndex        =   26
      Top             =   2475
      Width           =   6885
      Begin VB.CheckBox chkMoveBlock 
         Caption         =   "Block"
         Height          =   240
         Left            =   5805
         TabIndex        =   67
         Top             =   450
         Width           =   810
      End
      Begin VB.CommandButton btnPosStop 
         Caption         =   "Stop"
         Height          =   450
         Left            =   5775
         TabIndex        =   64
         Top             =   1290
         Width           =   945
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   62
         Text            =   "400.000"
         Top             =   1455
         Width           =   990
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   61
         Text            =   "400.000"
         Top             =   1470
         Width           =   990
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   60
         Text            =   "400.000"
         Top             =   1470
         Width           =   990
      End
      Begin VB.TextBox edtMoveDec 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   59
         Text            =   "400.000"
         Top             =   1470
         Width           =   990
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   39
         Text            =   "100.000"
         Top             =   405
         Width           =   990
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   38
         Text            =   "100.000"
         Top             =   420
         Width           =   990
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   37
         Text            =   "100.000"
         Top             =   420
         Width           =   990
      End
      Begin VB.TextBox edtMovePos 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   36
         Text            =   "100.000"
         Top             =   420
         Width           =   990
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   35
         Text            =   "100.000"
         Top             =   765
         Width           =   990
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   34
         Text            =   "100.000"
         Top             =   780
         Width           =   990
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   33
         Text            =   "100.000"
         Top             =   780
         Width           =   990
      End
      Begin VB.TextBox edtMoveVel 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   32
         Text            =   "100.000"
         Top             =   780
         Width           =   990
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   31
         Text            =   "400.000"
         Top             =   1110
         Width           =   990
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   30
         Text            =   "400.000"
         Top             =   1125
         Width           =   990
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   2
         Left            =   3615
         TabIndex        =   29
         Text            =   "400.000"
         Top             =   1125
         Width           =   990
      End
      Begin VB.TextBox edtMoveAcc 
         Alignment       =   1  'Right Justify
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   28
         Text            =   "400.000"
         Top             =   1125
         Width           =   990
      End
      Begin VB.CommandButton btnPosMove 
         Caption         =   "Move"
         Height          =   450
         Left            =   5775
         TabIndex        =   27
         Top             =   780
         Width           =   945
      End
      Begin VB.Label Label11 
         Caption         =   "Move Decel    :"
         Height          =   225
         Left            =   120
         TabIndex        =   63
         Top             =   1500
         Width           =   1140
      End
      Begin VB.Label Label7 
         Caption         =   "Target Position :"
         Height          =   240
         Left            =   120
         TabIndex        =   42
         Top             =   435
         Width           =   1215
      End
      Begin VB.Label Label6 
         Caption         =   "Move Velocity  :"
         Height          =   240
         Left            =   120
         TabIndex        =   41
         Top             =   795
         Width           =   1245
      End
      Begin VB.Label Label5 
         Caption         =   "Move Accel     :"
         Height          =   225
         Left            =   120
         TabIndex        =   40
         Top             =   1155
         Width           =   1140
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Position Monitor >"
      Height          =   1770
      Left            =   105
      TabIndex        =   4
      Top             =   675
      Width           =   6885
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   6000
         Top             =   -15
      End
      Begin MSComDlg.CommonDialog OpenFileDialog1 
         Left            =   6435
         Top             =   -45
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.CheckBox chkServoOn 
         Caption         =   "Servo On"
         Height          =   270
         Left            =   5790
         Style           =   1  'Graphical
         TabIndex        =   25
         Top             =   1290
         Width           =   930
      End
      Begin VB.CommandButton btnPosClear 
         Caption         =   "Clear"
         Height          =   630
         Left            =   5790
         TabIndex        =   24
         Top             =   585
         Width           =   945
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   23
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
         TabIndex        =   22
         Text            =   "0.000"
         Top             =   1290
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   21
         Text            =   "0.000"
         Top             =   1290
         Width           =   990
      End
      Begin VB.TextBox stcCmdVel 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   20
         Text            =   "0.000"
         Top             =   1275
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   19
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
         TabIndex        =   18
         Text            =   "0.000"
         Top             =   945
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   17
         Text            =   "0.000"
         Top             =   945
         Width           =   990
      End
      Begin VB.TextBox stcActPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   16
         Text            =   "0.000"
         Top             =   930
         Width           =   990
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 03"
         Height          =   195
         Index           =   3
         Left            =   4830
         TabIndex        =   15
         Top             =   300
         Width           =   870
      End
      Begin VB.CheckBox chkAxis 
         Caption         =   "Axis 02"
         Height          =   195
         Index           =   2
         Left            =   3705
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
         Caption         =   "Axis 00"
         Height          =   195
         Index           =   0
         Left            =   1425
         TabIndex        =   12
         Top             =   300
         Width           =   870
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   3
         Left            =   4740
         TabIndex        =   11
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
         TabIndex        =   10
         Text            =   "0.000"
         Top             =   585
         Width           =   990
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   1
         Left            =   2475
         TabIndex        =   9
         Text            =   "0.000"
         Top             =   585
         Width           =   990
      End
      Begin VB.TextBox stcCmdPos 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   285
         Index           =   0
         Left            =   1350
         TabIndex        =   8
         Text            =   "0.000"
         Top             =   570
         Width           =   990
      End
      Begin VB.Label Label4 
         Caption         =   "Command Vel  :"
         Height          =   225
         Left            =   120
         TabIndex        =   7
         Top             =   1320
         Width           =   1140
      End
      Begin VB.Label Label3 
         Caption         =   "Feedback Pos :"
         Height          =   240
         Left            =   120
         TabIndex        =   6
         Top             =   960
         Width           =   1245
      End
      Begin VB.Label Label2 
         Caption         =   "Command Pos :"
         Height          =   240
         Left            =   120
         TabIndex        =   5
         Top             =   600
         Width           =   1215
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   105
      TabIndex        =   0
      Top             =   15
      Width           =   6885
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1410
         TabIndex        =   2
         Top             =   210
         Width           =   3915
      End
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5445
         TabIndex        =   1
         Top             =   195
         Width           =   1305
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No : "
         Height          =   300
         Left            =   150
         TabIndex        =   3
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
' MoveMultiAxes.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.11.30.
' >> [개요]: 이 예제는 다축구동 함수들의 사용법을 익히고 각 함수들의 인자값을
'    변경하면서 구동해 보는 예제입니다.
' >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
'    구동을 정지하게 됩니다.
' >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
'     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
'     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
'        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
' **************************************************************************


    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101
    Const MAX_MULTI_MOVE_AXIS As Integer = 4

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    
    Private m_dOldCmdPos(MAX_MULTI_MOVE_AXIS - 1), _
        m_dOldActPos(MAX_MULTI_MOVE_AXIS - 1), _
        m_dOldCmdVel(MAX_MULTI_MOVE_AXIS - 1) As Double
    Private m_lMoveMultiAxesCount As Long
    Private m_lMoveMultiAxes(MAX_MULTI_MOVE_AXIS - 1) As Long
    
    Private Sub Form_Load()
        Dim Index As Integer

        For Index = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            m_lMoveMultiAxes(Index) = -1
            m_dOldCmdPos(Index) = 0#
            m_dOldActPos(Index) = 0#
            m_dOldCmdVel(Index) = 0#
        Next

        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0

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
        CommonDialog1Open.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2

        CommonDialog1Open.Action = 1
        szFileName = CommonDialog1Open.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox ("File load fail!")
            End If
        End If

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> chkAxisXX_CheckedChanged(...) : 축 변경이 있을 때 호출되는 핸들러 함수.
    '  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
    '    번호 배열값을 재할당합니다.
    '  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
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

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            '++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            dwRetCode = AxmStatusSetPosMatch(m_lMoveMultiAxes(lCount), 0#)
        Next

        dwRetCode = AxmStatusSetPosMatch(m_lAxisNo, 0#)
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_Click()
        Dim dwIsChecked As Long
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            dwIsChecked = IIf(chkServoOn.Value, 1, 0)
            dwRetCode = AxmSignalServoOn(m_lMoveMultiAxes(lCount), dwIsChecked)
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnPosMove_Click() : "Move"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosMove_Click()
        Dim strData As String
        Dim dwRetCode, lCount, lArrayIndex As Integer
        Dim dMultiPos(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiVel(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiAcc(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double

        lArrayIndex = 0
        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                dMultiPos(lArrayIndex) = edtMovePos(lCount).Text
                dMultiVel(lArrayIndex) = edtMoveVel(lCount).Text
                dMultiAcc(lArrayIndex) = edtMoveAcc(lCount).Text
                dMultiDec(lArrayIndex) = edtMoveDec(lCount).Text
                lArrayIndex = lArrayIndex + 1
            End If
        Next

        If chkMoveBlock.Value Then
            ' ++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
            dwRetCode = AxmMoveMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiPos(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0), 0)
            If dwRetCode <> AXT_RT_SUCCESS Then

                strData = "AxmMoveMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        Else
            ' ++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            dwRetCode = AxmMoveStartMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiPos(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0), 0)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmMoveStartMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnPosStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축들로 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이
    '    구동을 정지하게 됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosStop_Click()
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            ' ++ 지정한 축의 구동을 감속정지합니다.
            dwRetCode = AxmMoveSStop(m_lMoveMultiAxes(lCount))
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnJogP_MouseDown(...) : "Jog(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim lArrayIndex As Long
        Dim strData As String
        Dim lCount As Integer
        Dim dMultiVel(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiAcc(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double
            
        dwRetCode = 0
        lArrayIndex = 0
            

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                dMultiVel(lArrayIndex) = Math.Abs(Val(edtJogVel(lCount).Text))
                dMultiAcc(lArrayIndex) = Math.Abs(Val(edtJogAcc(lCount).Text))
                dMultiDec(lArrayIndex) = Math.Abs(Val(edtJogDec(lCount).Text))
                lArrayIndex = lArrayIndex + 1
            End If
        Next

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0))
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartMultiVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogN_MouseDown(...) : "Jog(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim lArrayIndex As Long
        Dim strData As String
        Dim lCount As Integer
        Dim dMultiVel(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiAcc(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double
            
        dwRetCode = 0
        lArrayIndex = 0

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                dMultiVel(lArrayIndex) = -Math.Abs(Val(edtJogVel(lCount).Text))
                dMultiAcc(lArrayIndex) = Math.Abs(Val(edtJogAcc(lCount).Text))
                dMultiDec(lArrayIndex) = Math.Abs(Val(edtJogDec(lCount).Text))
                lArrayIndex = lArrayIndex + 1
            End If
        Next

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0))
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnLineP_MouseDown(...) : Line Move의 "Jog(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim lArrayIndex As Long
        Dim strData As String
        Dim lCount As Integer
        Dim dLinePos(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dLineVel, dLineAcc, dLineDec As Double

        dwRetCode = 0
        lArrayIndex = 0

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                dLinePos(lArrayIndex) = Math.Abs(Val(edtLinePos(lCount).Text))
                lArrayIndex = lArrayIndex + 1
            End If
        Next

        dLineVel = Math.Abs(Val(edtLineVel.Text))
        dLineAcc = Math.Abs(Val(edtLineAcc.Text))
        dLineDec = Math.Abs(Val(edtLineDec.Text))

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dLinePos(0), dLineVel, dLineAcc, dLineDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartLineVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnLineN_MouseDown(...) : Line Move의 "Jog(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
        Dim dwRetCode As Long
        Dim lArrayIndex As Long
        Dim strData As String
        Dim lCount As Integer
        Dim dLinePos(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dLineVel, dLineAcc, dLineDec As Double
        
        dwRetCode = 0
        lArrayIndex = 0
        
        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                dLinePos(lArrayIndex) = -Math.Abs(Val(edtLinePos(lCount).Text))
                lArrayIndex = lArrayIndex + 1
            End If
        Next

        dLineVel = Math.Abs(Val(edtLineVel.Text))
        dLineAcc = Math.Abs(Val(edtLineAcc.Text))
        dLineDec = Math.Abs(Val(edtLineDec.Text))

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dLinePos(0), dLineVel, dLineAcc, dLineDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartLineVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogP_MouseUp(...) : "Jog(+)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        btnPosStop_Click
    End Sub

    ' ++ =======================================================================
    ' >> btnJogN_MouseUp(...) : "Jog(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        btnPosStop_Click
    End Sub

    ' ++ =======================================================================
    ' >> btnLineP_MouseUp(...) : Line Move의 "Jog(+)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        btnPosStop_Click
    End Sub

    ' ++ =======================================================================
    ' >> btnLineN_MouseUp(...) : Line Move의 "Jog(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
        btnPosStop_Click
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        Dim dCmdPos As Double
        Dim dActPos As Double
        Dim dCmdVel As Double
        Dim lArrayIndex As Long
        Dim lCount As Integer
        
        dCmdPos = 0#
        dActPos = 0#
        dCmdVel = 0#
        lArrayIndex = 0

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If chkAxis(lCount).Value Then
                ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
                dwRetCode = AxmStatusGetCmdPos(m_lMoveMultiAxes(lArrayIndex), dCmdPos)
                If m_dOldCmdPos(lCount) <> dCmdPos Then
                    stcCmdPos(lCount).Text = Format(dCmdPos, "0.000")
                    m_dOldCmdPos(lCount) = dCmdPos
                End If

                ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                dwRetCode = AxmStatusGetActPos(m_lMoveMultiAxes(lArrayIndex), dActPos)
                If m_dOldActPos(lCount) <> dActPos Then
                    stcActPos(lCount).Text = Format(dActPos, "0.000")
                    m_dOldActPos(lCount) = dActPos
                End If

                ' ++ 지정한 축의 구동 속도를 반환합니다.
                dwRetCode = AxmStatusReadVel(m_lMoveMultiAxes(lArrayIndex), dCmdVel)
                If m_dOldCmdVel(lCount) <> dCmdVel Then
                    stcCmdVel(lCount).Text = Format(dCmdVel, "0.000")
                    m_dOldCmdVel(lCount) = dCmdVel
                End If

                lArrayIndex = lArrayIndex + 1
            End If
        Next
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
        Dim lModuleID As Long
        
        dwOnOff = 0
        lTotalCount = 0
        lBoardNo = 0
        lModulePos = 0
        lFirstAxisNo = 0

        ' ++ 지정한 축의 정보를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, lBoardNo, lModulePos, lModuleID)
        ' ++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
        dwRetCode = AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, lFirstAxisNo)

        m_lMoveMultiAxesCount = 0
        bSelectCheck = False
        bEmptyCheck = False
        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            ' 지정한 축이 제어가 가능한 상태인지 반환합니다.
            If AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS Then
                strData = "Axis " + Format(lFirstAxisNo, "00")
                chkAxis(lCount).Enabled = True
                bSelectCheck = chkAxis(lCount).Value
                bEmptyCheck = bEmptyCheck Or bSelectCheck

                If bSelectCheck > 0 Then
                    m_lMoveMultiAxes(m_lMoveMultiAxesCount) = lFirstAxisNo
                    m_lMoveMultiAxesCount = m_lMoveMultiAxesCount + 1
                End If

                edtMovePos(lCount).Enabled = bSelectCheck
                edtMoveVel(lCount).Enabled = bSelectCheck
                edtMoveAcc(lCount).Enabled = bSelectCheck
                edtMoveDec(lCount).Enabled = bSelectCheck

                edtJogVel(lCount).Enabled = bSelectCheck
                edtJogAcc(lCount).Enabled = bSelectCheck
                edtJogDec(lCount).Enabled = bSelectCheck

                edtLinePos(lCount).Enabled = bSelectCheck
            Else
                m_lMoveMultiAxes(lCount) = -1
                strData = "Axis --"
                chkAxis(lCount).Enabled = False
                chkAxis(lCount).Value = False

                edtMovePos(lCount).Enabled = False
                edtMoveVel(lCount).Enabled = False
                edtMoveAcc(lCount).Enabled = False
                edtMoveDec(lCount).Enabled = False

                edtJogVel(lCount).Enabled = False
                edtJogAcc(lCount).Enabled = False
                edtJogDec(lCount).Enabled = False

                edtLinePos(lCount).Enabled = False
            End If

            lFirstAxisNo = lFirstAxisNo + 1
            chkAxis(lCount).Caption = strData

        Next

        edtLineVel.Enabled = bEmptyCheck
        edtLineAcc.Enabled = bEmptyCheck
        edtLineDec.Enabled = bEmptyCheck

        btnJogN.Enabled = bEmptyCheck
        btnJogP.Enabled = bEmptyCheck

        btnLineN.Enabled = bEmptyCheck
        btnLineP.Enabled = bEmptyCheck

        btnPosMove.Enabled = bEmptyCheck
        btnPosStop.Enabled = bEmptyCheck

        btnPosClear.Enabled = bEmptyCheck
        chkMoveBlock.Enabled = bEmptyCheck
        chkServoOn.Enabled = bEmptyCheck

        bAllCheck = False
        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            ' ++ 지정한 축의 서보온 상태를 반환합니다.
            dwRetCode = AxmSignalIsServoOn(m_lMoveMultiAxes(lCount), dwOnOff)
            ' 선택된 보간축들이 모두 서보온 되어있을 때 TRUE
            bAllCheck = bAllCheck And dwOnOff
        Next

        chkServoOn.Value = bAllCheck

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



