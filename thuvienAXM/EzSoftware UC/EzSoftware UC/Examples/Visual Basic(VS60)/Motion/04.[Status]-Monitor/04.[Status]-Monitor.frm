VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "StatusMonitor"
   ClientHeight    =   7020
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7290
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7020
   ScaleWidth      =   7290
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame4 
      Caption         =   "Drive Status"
      Height          =   1695
      Left            =   120
      TabIndex        =   62
      Top             =   5220
      Width           =   7050
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   5
         Left            =   3510
         TabIndex        =   72
         Top             =   375
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   6
         Left            =   3510
         TabIndex        =   71
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   7
         Left            =   3510
         TabIndex        =   70
         Top             =   855
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   8
         Left            =   3510
         TabIndex        =   69
         Top             =   1095
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   9
         Left            =   3510
         TabIndex        =   68
         Top             =   1335
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   4
         Left            =   240
         TabIndex        =   67
         Top             =   1320
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   3
         Left            =   240
         TabIndex        =   66
         Top             =   1080
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   2
         Left            =   240
         TabIndex        =   65
         Top             =   840
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   1
         Left            =   240
         TabIndex        =   64
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkDriveBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   0
         Left            =   240
         TabIndex        =   63
         Top             =   360
         Width           =   285
      End
      Begin VB.Label Label41 
         Caption         =   "Bit 11: Direction of motor drive"
         Height          =   255
         Left            =   3870
         TabIndex        =   82
         Top             =   1335
         Width           =   2385
      End
      Begin VB.Label Label40 
         Caption         =   "Bit 10: In move of slave drive"
         Height          =   195
         Left            =   3870
         TabIndex        =   81
         Top             =   1095
         Width           =   2745
      End
      Begin VB.Label Label39 
         Caption         =   "Bit 07: In move of home drive"
         Height          =   255
         Left            =   3870
         TabIndex        =   80
         Top             =   855
         Width           =   2685
      End
      Begin VB.Label Label38 
         Caption         =   "Bit 06: In move of MPG drive"
         Height          =   255
         Left            =   3870
         TabIndex        =   79
         Top             =   615
         Width           =   2385
      End
      Begin VB.Label Label37 
         Caption         =   "Bit 05: In move of assigned drive"
         Height          =   195
         Left            =   3870
         TabIndex        =   78
         Top             =   375
         Width           =   2745
      End
      Begin VB.Label Label34 
         Caption         =   "Bit 04: In move of continuous drive"
         Height          =   255
         Left            =   585
         TabIndex        =   77
         Top             =   1320
         Width           =   2880
      End
      Begin VB.Label Label33 
         Caption         =   "Bit 03: UP (In acceleration)"
         Height          =   195
         Left            =   585
         TabIndex        =   76
         Top             =   1080
         Width           =   2745
      End
      Begin VB.Label Label32 
         Caption         =   "Bit 02: CONST (In constant speed)"
         Height          =   255
         Left            =   585
         TabIndex        =   75
         Top             =   840
         Width           =   2685
      End
      Begin VB.Label Label31 
         Caption         =   "Bit 01: DOWN (In deceleration)"
         Height          =   255
         Left            =   585
         TabIndex        =   74
         Top             =   600
         Width           =   2385
      End
      Begin VB.Label Label30 
         Caption         =   "Bit 00: BUSY (In drive move)"
         Height          =   195
         Left            =   585
         TabIndex        =   73
         Top             =   360
         Width           =   2745
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Motion End Status"
      Height          =   2175
      Left            =   120
      TabIndex        =   33
      Top             =   2985
      Width           =   7050
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   0
         Left            =   240
         TabIndex        =   47
         Top             =   360
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   1
         Left            =   240
         TabIndex        =   46
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   2
         Left            =   240
         TabIndex        =   45
         Top             =   840
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   3
         Left            =   240
         TabIndex        =   44
         Top             =   1080
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   4
         Left            =   240
         TabIndex        =   43
         Top             =   1320
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   5
         Left            =   240
         TabIndex        =   42
         Top             =   1560
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   6
         Left            =   240
         TabIndex        =   41
         Top             =   1800
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   13
         Left            =   3510
         TabIndex        =   40
         Top             =   1815
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   12
         Left            =   3510
         TabIndex        =   39
         Top             =   1575
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   11
         Left            =   3510
         TabIndex        =   38
         Top             =   1335
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   10
         Left            =   3510
         TabIndex        =   37
         Top             =   1095
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   9
         Left            =   3510
         TabIndex        =   36
         Top             =   855
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   8
         Left            =   3510
         TabIndex        =   35
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkEndBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   7
         Left            =   3510
         TabIndex        =   34
         Top             =   375
         Width           =   285
      End
      Begin VB.Label Label29 
         Caption         =   "Bit 00: Exit by positive end limit"
         Height          =   195
         Left            =   585
         TabIndex        =   61
         Top             =   360
         Width           =   2745
      End
      Begin VB.Label Label28 
         Caption         =   "Bit 01: Exit by negative end limit"
         Height          =   255
         Left            =   585
         TabIndex        =   60
         Top             =   600
         Width           =   2385
      End
      Begin VB.Label Label27 
         Caption         =   "Bit 04: Exit by positive SW E-Stop"
         Height          =   255
         Left            =   585
         TabIndex        =   59
         Top             =   840
         Width           =   2685
      End
      Begin VB.Label Label26 
         Caption         =   "Bit 05: Exit by negative SW E-Stop"
         Height          =   195
         Left            =   585
         TabIndex        =   58
         Top             =   1080
         Width           =   2745
      End
      Begin VB.Label Label25 
         Caption         =   "Bit 06: Exit by positive SW S-Stop"
         Height          =   255
         Left            =   585
         TabIndex        =   57
         Top             =   1320
         Width           =   2385
      End
      Begin VB.Label Label24 
         Caption         =   "Bit 07: Exit by negative SW S-Stop"
         Height          =   240
         Left            =   585
         TabIndex        =   56
         Top             =   1560
         Width           =   2685
      End
      Begin VB.Label Label23 
         Caption         =   "Bit 08: Exit by servo alarm signal"
         Height          =   285
         Left            =   585
         TabIndex        =   55
         Top             =   1800
         Width           =   2685
      End
      Begin VB.Label Label22 
         Caption         =   "Bit 09: Exit by emergency signal"
         Height          =   195
         Left            =   3870
         TabIndex        =   54
         Top             =   375
         Width           =   2745
      End
      Begin VB.Label Label21 
         Caption         =   "Bit 10: Exit by EMG stop CMD"
         Height          =   255
         Left            =   3870
         TabIndex        =   53
         Top             =   615
         Width           =   2385
      End
      Begin VB.Label Label20 
         Caption         =   "Bit 11: Exit by slow stop CMD"
         Height          =   255
         Left            =   3870
         TabIndex        =   52
         Top             =   855
         Width           =   2685
      End
      Begin VB.Label Label19 
         Caption         =   "Bit 15: Encoder input error"
         Height          =   195
         Left            =   3870
         TabIndex        =   51
         Top             =   1095
         Width           =   2745
      End
      Begin VB.Label Label18 
         Caption         =   "Bit 28: Current/Last move direction"
         Height          =   255
         Left            =   3870
         TabIndex        =   50
         Top             =   1335
         Width           =   3135
      End
      Begin VB.Label Label17 
         Caption         =   "Bit 30: Abnormal drive stop"
         Height          =   240
         Left            =   3870
         TabIndex        =   49
         Top             =   1575
         Width           =   2685
      End
      Begin VB.Label Label16 
         Caption         =   "Bit 31: Interpolation data error"
         Height          =   285
         Left            =   3870
         TabIndex        =   48
         Top             =   1815
         Width           =   2685
      End
   End
   Begin VB.Frame Frame1 
      Height          =   585
      Left            =   135
      TabIndex        =   8
      Top             =   90
      Width           =   7050
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1320
         TabIndex        =   10
         Top             =   180
         Width           =   3885
      End
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   270
         Left            =   5370
         TabIndex        =   9
         Top             =   195
         Width           =   1575
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No : "
         Height          =   225
         Left            =   120
         TabIndex        =   11
         Top             =   210
         Width           =   1200
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Mechanical Status"
      Height          =   2175
      Left            =   135
      TabIndex        =   0
      Top             =   735
      Width           =   7050
      Begin MSComDlg.CommonDialog CommonDialog1Open 
         Left            =   6360
         Top             =   825
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   6375
         Top             =   1320
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   7
         Left            =   3510
         TabIndex        =   18
         Top             =   360
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   8
         Left            =   3510
         TabIndex        =   17
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   9
         Left            =   3510
         TabIndex        =   16
         Top             =   855
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   10
         Left            =   3510
         TabIndex        =   15
         Top             =   1095
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   11
         Left            =   3510
         TabIndex        =   14
         Top             =   1335
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   12
         Left            =   3510
         TabIndex        =   13
         Top             =   1575
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   13
         Left            =   3510
         TabIndex        =   12
         Top             =   1815
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   6
         Left            =   240
         TabIndex        =   7
         Top             =   1800
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   5
         Left            =   240
         TabIndex        =   6
         Top             =   1560
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   4
         Left            =   240
         TabIndex        =   5
         Top             =   1320
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   3
         Left            =   240
         TabIndex        =   4
         Top             =   1080
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   2
         Left            =   240
         TabIndex        =   3
         Top             =   840
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   1
         Left            =   240
         TabIndex        =   2
         Top             =   600
         Width           =   285
      End
      Begin VB.CheckBox chkMechBit 
         Enabled         =   0   'False
         Height          =   225
         Index           =   0
         Left            =   240
         TabIndex        =   1
         Top             =   360
         Width           =   285
      End
      Begin VB.Label Label15 
         Caption         =   "Bit 17: MODE Signal State"
         Height          =   285
         Left            =   3870
         TabIndex        =   32
         Top             =   1815
         Width           =   2685
      End
      Begin VB.Label Label14 
         Caption         =   "Bit 14: SQSTR 2 Signal State"
         Height          =   285
         Left            =   3870
         TabIndex        =   31
         Top             =   1575
         Width           =   2685
      End
      Begin VB.Label Label13 
         Caption         =   "Bit 13: SQSTR 1 Signal State"
         Height          =   255
         Left            =   3870
         TabIndex        =   30
         Top             =   1335
         Width           =   2385
      End
      Begin VB.Label Label12 
         Caption         =   "Bit 12: EXMP(MPG)Signal State"
         Height          =   195
         Left            =   3870
         TabIndex        =   29
         Top             =   1095
         Width           =   2745
      End
      Begin VB.Label Label11 
         Caption         =   "Bit 11: EXPP(MPG) Signal State"
         Height          =   285
         Left            =   3870
         TabIndex        =   28
         Top             =   855
         Width           =   2685
      End
      Begin VB.Label Label10 
         Caption         =   "Bit 10: Encoder Dn Signal State"
         Height          =   255
         Left            =   3870
         TabIndex        =   27
         Top             =   615
         Width           =   2385
      End
      Begin VB.Label Label9 
         Caption         =   "Bit 09: Encoder Up Signal State"
         Height          =   195
         Left            =   3870
         TabIndex        =   26
         Top             =   375
         Width           =   2745
      End
      Begin VB.Label Label8 
         Caption         =   "Bit 08: Z Phase Signal State"
         Height          =   285
         Left            =   585
         TabIndex        =   25
         Top             =   1800
         Width           =   2685
      End
      Begin VB.Label Label7 
         Caption         =   "Bit 07: Home Signal State"
         Height          =   285
         Left            =   585
         TabIndex        =   24
         Top             =   1560
         Width           =   2685
      End
      Begin VB.Label Label6 
         Caption         =   "Bit 06: Emergency Signal State"
         Height          =   255
         Left            =   585
         TabIndex        =   23
         Top             =   1320
         Width           =   2385
      End
      Begin VB.Label Label5 
         Caption         =   "Bit 05: Inposition Signal State"
         Height          =   195
         Left            =   585
         TabIndex        =   22
         Top             =   1080
         Width           =   2745
      End
      Begin VB.Label Label4 
         Caption         =   "Bit 04: Alarm Signal State"
         Height          =   285
         Left            =   585
         TabIndex        =   21
         Top             =   840
         Width           =   2685
      End
      Begin VB.Label Label3 
         Caption         =   "Bit 01: Negative End Limit State"
         Height          =   255
         Left            =   585
         TabIndex        =   20
         Top             =   600
         Width           =   2385
      End
      Begin VB.Label Label2 
         Caption         =   "Bit 00: Positive End Limit State"
         Height          =   195
         Left            =   585
         TabIndex        =   19
         Top             =   360
         Width           =   2745
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' StatusMonitor.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.11.26
' >> [개요]: 이 예제는 모션구동과 관련된 상태들을 모니터링하는 예제입니다.
' >> [중요]: 상태함수들 응용범위
'     1) AxmStatusReadMechanical함수는 신호 상태값들을 한번에 읽어 확인할 수
'        있어 각각의 개별 함수들을 이용하는것 보다 효율적입니다.
'     2) AxmStatusReadStop 함수는 구동이 정지된 후 정상구동여부를 확인할 수
'        있습니다. 모션 구동시 목표위치까지 도달하지 않고 정지하였다면 이 함수의
'        반환값을 분석해 정지원인을 파악할 수 있습니다.
'     3) AxmStatusReadMotion 함수는 현재 모션 구동중인지, 어떤 구동중인지등의
'        구동상태를 확인할 수 있습니다.
' **************************************************************************

    Const TM_DISPLAY As Integer = 100
    Const MAX_ITEM_END As Integer = 14
    Const MAX_ITEM_MECH As Integer = 14
    Const MAX_ITEM_DRIVE As Integer = 10

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long
    Private OnBits(0 To 31) As Long

    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
    
        InitLibrary               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState              ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        ' 중요한 정보들만 모니터링 하도록 선택했습니다.
        Dim lDigitEnd(MAX_ITEM_END - 1) As Long
        lDigitEnd(0) = 0
        lDigitEnd(1) = 1
        lDigitEnd(2) = 4
        lDigitEnd(3) = 5
        lDigitEnd(4) = 6
        lDigitEnd(5) = 7
        lDigitEnd(6) = 8
        lDigitEnd(7) = 9
        lDigitEnd(8) = 10
        lDigitEnd(9) = 11
        lDigitEnd(10) = 15
        lDigitEnd(11) = 28
        lDigitEnd(12) = 30
        lDigitEnd(13) = 31

        
        Dim lDigitMech(MAX_ITEM_MECH - 1) As Long
        lDigitMech(0) = 0
        lDigitMech(1) = 1
        lDigitMech(2) = 4
        lDigitMech(3) = 5
        lDigitMech(4) = 6
        lDigitMech(5) = 7
        lDigitMech(6) = 8
        lDigitMech(7) = 9
        lDigitMech(8) = 10
        lDigitMech(9) = 11
        lDigitMech(10) = 12
        lDigitMech(11) = 13
        lDigitMech(12) = 14
        lDigitMech(13) = 17
        
        Dim lDigitDrive(MAX_ITEM_DRIVE - 1) As Long
        lDigitDrive(0) = 0
        lDigitDrive(1) = 1
        lDigitDrive(2) = 2
        lDigitDrive(3) = 3
        lDigitDrive(4) = 4
        lDigitDrive(5) = 5
        lDigitDrive(6) = 6
        lDigitDrive(7) = 7
        lDigitDrive(8) = 10
        lDigitDrive(9) = 11

        Dim lCheck As Long
        Dim dwRetCode As Long
        Dim dwStatus As Long
        Dim lIndex As Integer
        
        lCheck = 0
        dwRetCode = 0
        dwStatus = 0

        ' ++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadMechanical(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_MECH - 1)
                'lCheck = dwStatus / 2 ^ lDigitMech(lIndex) And &H1
                lCheck = RShiftLong(dwStatus, lDigitMech(lIndex)) And &H1
                chkMechBit(lIndex).Value = lCheck
            Next
        End If

        ' ++ 지정 축의 End Status(정지 상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadStop(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_END - 1)
                lCheck = dwStatus / 2 ^ lDigitEnd(lIndex) And &H1
                chkEndBit(lIndex).Value = lCheck
            Next
        End If

        ' ++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadMotion(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_DRIVE - 1)
                lCheck = dwStatus / 2 ^ lDigitDrive(lIndex) And &H1
                chkDriveBit(lIndex).Value = lCheck
            Next
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
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, dwBoardNo, dwModulePos, dwModuleID)


        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i = 0 To (m_lAxisCount - 1)
            ' ++ 지정한 축의 정보를 반환합니다.
            dwRetCode = AxmInfoGetAxis(i, lpBoadNo, lpModulePosAs, dwModuleID)
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

        UpdateState = True
    End Function


Public Function RShiftLong(ByVal Value As Long, ByVal Shift As Integer) As Long
    Dim hi As Long
    MakeOnBits
    If (Value And &H80000000) Then hi = &H40000000
  
    RShiftLong = (Value And &H7FFFFFFE) \ (2 ^ Shift)
End Function
 
Private Sub MakeOnBits()
    Dim j As Integer
    Dim v As Long
  
    For j = 0 To 30
        v = v + (2 ^ j)
        OnBits(j) = v
    Next j
  
    OnBits(j) = v + &H80000000
End Sub

