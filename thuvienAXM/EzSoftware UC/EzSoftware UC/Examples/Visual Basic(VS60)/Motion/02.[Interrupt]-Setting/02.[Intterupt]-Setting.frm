VERSION 5.00
Object = "{3EACF94A-AC86-4C57-B5C8-470911DAC903}#1.1#0"; "AxtMessenger.ocx"
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "InterruptSetting"
   ClientHeight    =   7440
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6615
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7440
   ScaleWidth      =   6615
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox lstIntLog 
      Height          =   1425
      Left            =   120
      TabIndex        =   22
      Top             =   5895
      Width           =   6390
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Interrupt Method >"
      Height          =   690
      Left            =   105
      TabIndex        =   18
      Top             =   5070
      Width           =   6405
      Begin VB.CheckBox chkIntEnable 
         Caption         =   "Interrupt Enable"
         Height          =   285
         Left            =   4680
         Style           =   1  'Graphical
         TabIndex        =   23
         Top             =   255
         Width           =   1545
      End
      Begin VB.OptionButton rdoEvent 
         Caption         =   "Event"
         Height          =   195
         Left            =   3330
         TabIndex        =   21
         Top             =   300
         Width           =   945
      End
      Begin VB.OptionButton rdoCallback 
         Caption         =   "Callback"
         Height          =   195
         Left            =   1755
         TabIndex        =   20
         Top             =   300
         Width           =   1200
      End
      Begin VB.OptionButton rdoMessage 
         Caption         =   "Message"
         Height          =   195
         Left            =   285
         TabIndex        =   19
         Top             =   300
         Width           =   1200
      End
   End
   Begin VB.Frame grpBank2 
      Caption         =   "< Interrupt Event Bank 2 [0x00000000] >"
      Height          =   2640
      Left            =   105
      TabIndex        =   9
      Top             =   2370
      Width           =   6420
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 22] UInput 2 terminal signal is changed to '1' "
         Height          =   255
         Index           =   5
         Left            =   360
         TabIndex        =   17
         Top             =   2220
         Width           =   4230
      End
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 21] UInput 1 terminal signal is changed to '1' (Z-Phase Signal)"
         Height          =   255
         Index           =   4
         Left            =   360
         TabIndex        =   16
         Top             =   1860
         Width           =   5310
      End
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 20] UInput 0 terminal signal is changed to '1' (Home Signal)"
         Height          =   255
         Index           =   3
         Left            =   360
         TabIndex        =   15
         Top             =   1530
         Width           =   5130
      End
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 16] UOut 2 terminal signal is changed to '1'"
         Height          =   375
         Index           =   2
         Left            =   360
         TabIndex        =   14
         Top             =   960
         Width           =   5580
      End
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 15] UOut 1 terminal signal is changed to '1' (Alarm Clear)"
         Height          =   255
         Index           =   1
         Left            =   360
         TabIndex        =   13
         Top             =   645
         Width           =   5505
      End
      Begin VB.CheckBox chkGroupBank2 
         Caption         =   "[Bit 14] UOut 0 terminal signal is changed to '1' (Servo On)"
         Height          =   255
         Index           =   0
         Left            =   360
         TabIndex        =   12
         Top             =   285
         Width           =   5010
      End
      Begin VB.CommandButton btnSetBank2 
         Caption         =   "Set Bank 2"
         Height          =   300
         Left            =   4650
         TabIndex        =   11
         Top             =   2205
         Width           =   1620
      End
      Begin VB.Label Label9 
         Height          =   255
         Left            =   705
         TabIndex        =   10
         Top             =   1575
         Width           =   4710
      End
      Begin VB.Line Line3 
         X1              =   705
         X2              =   6300
         Y1              =   1425
         Y2              =   1425
      End
   End
   Begin VB.Frame grpBank1 
      Caption         =   "< Interrupt Event Bank 1 [0x00000000] >"
      Height          =   1695
      Left            =   105
      TabIndex        =   3
      Top             =   600
      Width           =   6405
      Begin AXTMESSENGERLib.AxtMessenger AxtMsg 
         Height          =   360
         Left            =   5010
         TabIndex        =   24
         Top             =   270
         Visible         =   0   'False
         Width           =   375
         _Version        =   65536
         _ExtentX        =   661
         _ExtentY        =   635
         _StockProps     =   0
         Message1        =   0
         Message2        =   0
         Message3        =   0
      End
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   5490
         Top             =   225
      End
      Begin VB.CheckBox chkGroupBank1 
         Caption         =   "[Bit 31] Interrupt occurrence command execution"
         Height          =   195
         Index           =   3
         Left            =   345
         TabIndex        =   8
         Top             =   1335
         Width           =   3975
      End
      Begin VB.CheckBox chkGroupBank1 
         Caption         =   "[Bit 02] When drive started"
         Height          =   195
         Index           =   2
         Left            =   345
         TabIndex        =   7
         Top             =   945
         Width           =   4005
      End
      Begin VB.CheckBox chkGroupBank1 
         Caption         =   "[Bit 01] When drive is exited"
         Height          =   195
         Index           =   1
         Left            =   345
         TabIndex        =   6
         Top             =   645
         Width           =   4575
      End
      Begin VB.CheckBox chkGroupBank1 
         Caption         =   "[Bit 00] When drive set interrupt occurrence use is exited"
         Height          =   195
         Index           =   0
         Left            =   345
         TabIndex        =   5
         Top             =   345
         Width           =   5025
      End
      Begin VB.CommandButton btnSetBank1 
         Caption         =   "Set Bank 1"
         Height          =   300
         Left            =   4590
         TabIndex        =   4
         Top             =   1260
         Width           =   1650
      End
      Begin VB.Line Line1 
         X1              =   675
         X2              =   6240
         Y1              =   1245
         Y2              =   1245
      End
   End
   Begin VB.Frame Frame1 
      Height          =   465
      Left            =   120
      TabIndex        =   0
      Top             =   75
      Width           =   6405
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1455
         TabIndex        =   1
         Top             =   120
         Width           =   4860
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No :"
         Height          =   285
         Left            =   210
         TabIndex        =   2
         Top             =   150
         Width           =   1245
      End
   End
   Begin VB.Line Line2 
      X1              =   0
      X2              =   5565
      Y1              =   0
      Y2              =   0
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' InterruptSetting.vb : implementation file
'
' **************************************************************************
' >> [일자]: 2015.12.23
' >> [개요]: 이 예제는 인터럽트 함수들의 사용법을 익히고 윈도우 응용프로그램에서
'     여러가지 인터럽트 처리 방법에 대해 학습하는 예제입니다.
' >> [중요]: 인터럽트 사용방법
'     1) AxlInterruptEnable함수를 이용해서 AXL라이브러리에 인터럽트를 허용합니다.
'     2) AxmInterruptSetAxis함수를 이용해 각 축에 인터럽트 처리 방식을 설정합니다.
'     3) AxmInterruptSetUserEnable함수를 이용해 지정한 축에 사용할 인터럽트
'        종류들을 설정합니다. Ex) AxmInterruptSetUserEnable(0, INT_BANK_1, 0x6)
'     4) AxmInterruptSetAxisEnable 함수를 이용해 지정한 축에 인터럽트를 허용합니다.
' **************************************************************************

    Dim m_nIntMethod As Integer
    Dim m_lAxisNo As Long
    Dim m_lAxisCount As Long
    Dim m_lIntCount As Long
    Dim m_dwModuleId As Long
    Dim m_isFakeMessage As Boolean
        
    Dim m_hIntEvent(63) As Integer
    Dim m_bThHandle(63) As Boolean

    ' CInterruptSettingDlg dialog
    Const INT_BANK_1 As Long = 0
    Const INT_BANK_2 As Long = 1

    Const MAX_BANK_1 As Long = 4
    Const MAX_BANK_2 As Long = 6
    Const MAX_AXIS_COUNT As Long = 64

    ' 인터럽트 이벤트 종류 정의
    Private Enum InterruptCategory
        INT_MESSAGE
        INT_CALLBACK
        INT_EVENT
    End Enum

    ' 인터럽트 정보 구조체
    Private Type stIntItem
         szTime As String
         lAxisNo As Long
         dwBank0 As Long
         dwBank1 As Long
         dwIntFlag As Long
         byIntType As Byte
    End Type

    Private m_aIntItem As Collection

    Private Sub Form_Load()
        m_nIntMethod = 0
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_lIntCount = 0
        m_dwModuleId = 0
        m_isFakeMessage = False
    
        InitLibrary
        AddAxisInfo
        UpdateState
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
    ' >> btnSetBank1_Click() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetBank1_Click()
        Dim strData As String
        Dim dwIntMask As Integer
        Dim dwRetCode As Long
        Dim i As Integer
        Dim dwBitMask(MAX_BANK_1 - 1) As Long
        dwBitMask(0) = &H1
        dwBitMask(1) = &H2
        dwBitMask(2) = &H4
        dwBitMask(3) = &H80000000
                
        dwIntMask = 0

        For i = 0 To (MAX_BANK_1 - 1)
            If chkGroupBank1(i).Value = True Then
                dwIntMask = dwIntMask Or dwBitMask(i)
            End If
        Next

        ' ++ 지정한 축에 모션구동 시작시, 모션구동 종료시 등의 인터럽트를 설정합니다.
        dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmInterruptSetUserEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> btnSetBank2_Click() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetBank2_Click()
        Dim strData As String
        Dim dwIntMask As Integer
        Dim dwRetCode As Long
        Dim i As Integer
        Dim dwBitMask(MAX_BANK_2 - 1) As Long
        
        dwIntMask = 0
        
        'dwBitMask = New Integer(MAX_BANK_2 - 1) {&H4000, &H8000, &H10000, &H100000, &H200000, &H400000}
        dwBitMask(0) = &H4000
        dwBitMask(1) = &H8000
        dwBitMask(2) = &H10000
        dwBitMask(3) = &H100000
        dwBitMask(4) = &H200000
        dwBitMask(5) = &H400000
        
        For i = 0 To (MAX_BANK_2 - 1)
            If chkGroupBank2(i).Value = True Then
                dwIntMask = dwIntMask Or dwBitMask(i)
            End If
        Next

        ' ++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
        dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmInterruptSetUserEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> chkIntEnable_Click() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
    ' ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
    '    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면
    '    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가
    '    빈번하게 발생할 수 있기 때문입니다.
    ' --------------------------------------------------------------------------
    Private Sub chkIntEnable_Click()
        Dim strData As String
        Dim dwRetCode As Long
        Dim lProc, lEvent As Long

        If chkIntEnable.Value = True Then

            Select Case m_nIntMethod
                Case InterruptCategory.INT_MESSAGE
                    ' ++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
                    AxtMsg.Message1 = WM_AXL_INTERRUPT
                    dwRetCode = AxmInterruptSetAxis(m_lAxisNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, lProc, lEvent)

                Case InterruptCategory.INT_CALLBACK
                    ' ++ 인터럽트 처리방식을 콜백함수 방식으로 지정함


                Case InterruptCategory.INT_EVENT
                    ' ++ 인터럽트 처리방식을 이벤트 방식으로 지정함
                    'AxmInterruptSetAxis(m_lAxisNo, Nothing, 0, Nothing, m_hIntEvent(m_lAxisNo))
                    'AxmInterruptSetAxis(m_lAxisNo, Nothing, 0, Nothing, AddressOf EventStart)
                    'If m_bThHandle(m_lAxisNo) = False Then
                    'm_bThHandle(m_lAxisNo) = True
                    'm_hThread(m_lAxisNo) = New Threading.Thread(AddressOf ThreadEventProc)
                    'm_hThread(m_lAxisNo).Start()
                    'End If

            End Select

            ' ++ AXL라이브러리의 인터럽트 발생을 허용합니다.
            dwRetCode = AxlInterruptEnable()
            ' ++ 지정한 축에 인터럽트 발생을 허용합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE)
            If dwRetCode <> AXT_RT_SUCCESS Then
                chkIntEnable.Value = 0
                strData = "AxmInterruptSetAxisEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        Else
            ' ++ AXL라이브러리의 인터럽트 발생을 금지합니다.
            dwRetCode = AxlInterruptDisable()
            ' ++ 지정한 축에 인터럽트 발생을 금지합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE)
            If dwRetCode <> AXT_RT_SUCCESS Then
                chkIntEnable.Value = 1
                strData = "AxmInterruptSetAxisEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    Private Sub AxtMsg_OnMessage1(ByVal wParam As Long, ByVal lParam As Long)
        Dim time As Date
        Dim stIntItem As stIntItem
        Dim lAxisNo As Long
        Dim dwIntBank0, dwIntBank1 As Long
        Dim nIntrFlag As Integer
        
        data = Now()
        stIntItem = New stIntItem

        lAxisNo = CByte(e.wParam)     ' Interrupt generation axis number.
        nIntrFlag = CInt(e.lParam)    ' Interrupt generation axis location.

        If m_isFakeMessage Then
            m_isFakeMessage = False     ' 플래그 해제
        Else
            dwRetCode = AxmInterruptReadAxisFlag(lAxisNo, 0, dwIntBank0)
            dwRetCode = AxmInterruptReadAxisFlag(lAxisNo, 1, dwIntBank1)

            stIntItem.szTime = time.Hour.ToString("D2") + ":" + time.Minute.ToString("D2") + ":" + time.Second.ToString("D2") + ":" + time.Millisecond.ToString("D2")
            stIntItem.lAxisNo = lAxisNo
            stIntItem.byIntType = InterruptCategory.INT_MESSAGE
            stIntItem.dwBank0 = dwIntBank0
            stIntItem.dwBank1 = dwIntBank1
            stIntItem.dwIntFlag = nIntrFlag

            m_aIntItem.Add (stIntItem)  ' 인터럽트 정보 어레이에 추가합니다.

            m_isFakeMessage = True      ' 동일하게 호출되는 두번째 메시지를 무시하기 위한 플래그 설정
        End If
    End Sub
    
    ' ++ =======================================================================
    ' >> lstIntLog_DblClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
    '  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스
    '    왼쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
    ' --------------------------------------------------------------------------
    Private Sub lstIntLog_DblClick()
        m_lIntCount = 0
        m_aIntItem.Clear
        lstIntLog.Clear
    End Sub


    Private Sub m_timer_Timer()
        Dim nCntFront, nCntRear, i As Integer

        nCntRear = lstIntLog.ListCount
        If Not m_aIntItem Is Nothing Then
            nCntFront = m_aIntItem.Count
        End If

        ' 인터럽트 정보를 담고있는 어레이에 데이타가 추가된만큼 List Box에 등록함.
        For i = nCntRear To (nCntFront - 1)
            AddMsgToLog (m_aIntItem.Item(i))
            nCntRear = nCntRear + 1
        Next
    End Sub

    Private Sub AddMsgToLog(ByVal stIntItem As Collection)
        Dim strData As String
        
        strData = ""

        Select Case stIntItem.byIntType
            Case InterruptCategory.INT_MESSAGE
                m_lIntCount = m_lIntCount + 1
                strData = Format(m_lIntCount, "[000][M] ")
                strData = strData & Format(stIntItem.lAxisNo, "AxisNo: 00, ")
                strData = strData & Format(stIntItem.dwIntFlag, "Flag: 0")
                strData = strData & "[" + stIntItem.dwIntFlag.ToString("X") + "],"
                strData = strData & Format(stIntItem.dwBank0, "Bank0: 0")
                strData = strData & "[" + stIntItem.dwBank0.ToString("X") + "],"
                strData = strData & Format(stIntItem.dwBank1, "Bank1: 0")
                strData = strData & "[" + stIntItem.dwBank1.ToString("X") + "],"

            Case InterruptCategory.INT_CALLBACK
                '

            Case InterruptCategory.INT_EVENT
                '

            Case Else

        End Select

        lstIntLog.AddItem (strData)
        lstIntLog.ListIndex = lstIntLog.ListCount - 1
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
    Private Function InitLibrary()
        If AxlOpen(7) <> AXT_RT_SUCCESS Then
            MsgBox ("AxlOpen Fail...")
            InitLibrary = False
            Exit Function
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
        Dim upModuleSubID As Long
        Dim szModuleDescription As String

        szModuleName = Space(50)
        szModuleDescription = Space(80)
        upModuleSubID = 0

        ' ++ 유효한 전체 모션축수를 반환합니다.
        dwRetCode = AxmInfoGetAxisCount(m_lAxisCount)
        If m_lAxisCount < 1 Then
            AddAxisInfo = False
            Exit Function
        End If
        
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
    ' --------------------------------------------------------------------------
    Private Function UpdateState()
        If m_lAxisCount < 1 Then
            UpdateState = False
            Exit Function
        End If

        Dim dwIntMask As Long
        Dim dwOnOff As Long
        Dim strIntMask As String
        Dim testValue As Integer
        
        dwIntmast = 0
        dwOnOff = 0
        strIntMask = ""
        testValue = 0

        ' ++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
        dwRetCode = AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask)
        strIntMask = "Interrupt Event Bank 1 [0x" + Format(dwIntMask, "00000000") + "]"
        grpBank1.Caption = strIntMask

        ' 인터럽트 설정값 해당 콘트롤에 적용
        chkGroupBank1(0).Value = dwIntMask And &H1
        chkGroupBank1(1).Value = dwIntMask And &H2
        chkGroupBank1(2).Value = dwIntMask And &H4
        chkGroupBank1(3).Value = dwIntMask And &H80000000

        ' ++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
        dwRetCode = AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask)
        strIntMask = "Interrupt Event Bank 2 [0x" + Format(dwIntMask, "00000000") + "]"
        grpBank2.Caption = strIntMask

        ' 인터럽트 설정값 해당 콘트롤에 적용
        chkGroupBank2(0).Value = dwIntMask And &H4000
        chkGroupBank2(1).Value = dwIntMask And &H8000
        chkGroupBank2(2).Value = dwIntMask And &H10000
        chkGroupBank2(3).Value = dwIntMask And &H100000
        chkGroupBank2(4).Value = dwIntMask And &H200000
        chkGroupBank2(5).Value = dwIntMask And &H400000

        UpdateState = True
    End Function

