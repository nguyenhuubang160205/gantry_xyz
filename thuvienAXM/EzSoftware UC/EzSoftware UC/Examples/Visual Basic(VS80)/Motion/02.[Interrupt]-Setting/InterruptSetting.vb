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

Public Class InterruptSetting

    Private m_nIntMethod As Integer = 0
    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_lIntCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_isFakeMessage As Boolean = False
    Private m_hIntEvent(63) As Integer
    Private m_bThHandle(63) As Boolean
    Private m_hThread(63) As Threading.Thread

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
    Private Structure STIntItem
        Dim szTime As String
        Dim lAxisNo, dwBank0, dwBank1, dwIntFlag As Long
        Dim byIntType As Byte
    End Structure

    Private m_aIntItem As New ArrayList

    Private Sub InterruptSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()
        AddAxisInfo()
        UpdateState()
    End Sub

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelAxis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSelAxis.SelectedIndexChanged
        m_lAxisNo = cboSelAxis.SelectedIndex

        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxisNo, Nothing, Nothing, m_dwModuleId)

        UpdateState()       ' 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' ++ =======================================================================
    ' >> btnSetBank1_Click() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetBank1_Click(sender As System.Object, e As System.EventArgs) Handles btnSetBank1.Click
        Dim strData As String
        Dim dwIntMask As Integer = 0
        Dim dwRetCode As Long = 0
        Dim i As Integer
        Dim dwBitMask(MAX_BANK_1 - 1) As Integer
        dwBitMask = New Integer(MAX_BANK_1 - 1) {&H1, &H2, &H4, &H80000000}
        Dim chkGroupBank1(MAX_BANK_1 - 1) As CheckBox
        chkGroupBank1 = New CheckBox(MAX_BANK_1 - 1) {chkBank1Bit00, chkBank1Bit01, chkBank1Bit02, chkBank1Bit31}

        For i = 0 To (MAX_BANK_1 - 1)
            If chkGroupBank1(i).Checked = True Then
                dwIntMask = dwIntMask Or dwBitMask(i)
            End If
        Next

        ' ++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
        dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmInterruptSetUserEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If

        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> btnSetBank2_Click() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetBank2_Click(sender As System.Object, e As System.EventArgs) Handles btnSetBank2.Click
        Dim strData As String
        Dim dwIntMask As Integer = 0
        Dim dwRetCode As Long = 0
        Dim i As Integer
        Dim dwBitMask(MAX_BANK_2 - 1) As Integer
        dwBitMask = New Integer(MAX_BANK_2 - 1) {&H4000, &H8000, &H10000, &H100000, &H200000, &H400000}
        Dim chkGroupBank2(MAX_BANK_2 - 1) As CheckBox
        chkGroupBank2 = New CheckBox(MAX_BANK_2 - 1) {chkBank2Bit14, chkBank2Bit15, chkBank2Bit16, chkBank2Bit20, chkBank2Bit21, chkBank2Bit22}

        For i = 0 To (MAX_BANK_2 - 1)
            If chkGroupBank2(i).Checked = True Then
                dwIntMask = dwIntMask Or dwBitMask(i)
            End If
        Next

        ' ++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
        dwRetCode = AxmInterruptSetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmInterruptSetUserEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If

        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> chkIntEnable_CheckedChanged() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
    ' ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
    '    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면 
    '    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가 
    '    빈번하게 발생할 수 있기 때문입니다.
    ' --------------------------------------------------------------------------
    Private Sub chkIntEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntEnable.CheckedChanged
        Dim strData As String
        Dim dwRetCode As Long

        If chkIntEnable.Checked = True Then

            Select Case m_nIntMethod
                Case InterruptCategory.INT_MESSAGE
                    ' ++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
                    AxtMsg.Message1 = WM_AXL_INTERRUPT
                    AxmInterruptSetAxis(m_lAxisNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, Nothing, Nothing)

                Case InterruptCategory.INT_CALLBACK
                    ' ++ 인터럽트 처리방식을 콜백함수 방식으로 지정함
                    'AxmInterruptSetAxis(m_lAxisNo, Nothing, 0, MotionIntCallBack., Nothing)
                    ' 콜백함수 방식과 이벤트 방식이 가능한지 모르겠음...

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
            AxlInterruptEnable()
            ' ++ 지정한 축에 인터럽트 발생을 허용합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, ENABLE)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmInterruptSetAxisEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        Else
            ' ++ AXL라이브러리의 인터럽트 발생을 금지합니다.
            AxlInterruptDisable()
            ' ++ 지정한 축에 인터럽트 발생을 금지합니다.
            dwRetCode = AxmInterruptSetAxisEnable(m_lAxisNo, DISABLE)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmInterruptSetAxisEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    Private Sub AxtMsg_OnMessage1(sender As System.Object, e As AxAXTMESSENGERLib._DAxtMessengerEvents_OnMessage1Event) Handles AxtMsg.OnMessage1
        Dim time As Date = Date.Now
        Dim stIntItem As STIntItem = New STIntItem
        Dim lAxisNo As Long
        Dim dwIntBank0, dwIntBank1 As Long
        Dim nIntrFlag As Integer

        lAxisNo = CByte(e.wParam)     ' Interrupt generation axis number.
        nIntrFlag = CInt(e.lParam)    ' Interrupt generation axis location.

        If m_isFakeMessage Then
            m_isFakeMessage = False     ' 플래그 해제
        Else
            AxmInterruptReadAxisFlag(lAxisNo, 0, dwIntBank0)
            AxmInterruptReadAxisFlag(lAxisNo, 1, dwIntBank1)

            stIntItem.szTime = time.Hour.ToString("D2") + ":" + time.Minute.ToString("D2") + ":" + time.Second.ToString("D2") + ":" + time.Millisecond.ToString("D2")
            stIntItem.lAxisNo = lAxisNo
            stIntItem.byIntType = InterruptCategory.INT_MESSAGE
            stIntItem.dwBank0 = dwIntBank0
            stIntItem.dwBank1 = dwIntBank1
            stIntItem.dwIntFlag = nIntrFlag

            m_aIntItem.Add(stIntItem)   ' 인터럽트 정보 어레이에 추가합니다.

            m_isFakeMessage = True      ' 동일하게 호출되는 두번째 메시지를 무시하기 위한 플래그 설정
        End If
    End Sub

    Private Sub lstIntLog_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstIntLog.MouseDoubleClick
        m_lIntCount = 0
        m_aIntItem.Clear()
        lstIntLog.Items.Clear()
    End Sub

    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim nCntFront, nCntRear, i As Integer

        nCntRear = lstIntLog.Items.Count
        nCntFront = m_aIntItem.Count

        ' 인터럽트 정보를 담고있는 어레이에 데이타가 추가된만큼 List Box에 등록함.
        For i = nCntRear To (nCntFront - 1)
            AddMsgToLog(m_aIntItem.Item(i))
            nCntRear += 1
        Next
    End Sub

    Private Sub AddMsgToLog(ByVal stIntItem As STIntItem)
        Dim strData As String = ""

        Select Case stIntItem.byIntType
            Case InterruptCategory.INT_MESSAGE
                m_lIntCount += 1
                strData = Format(m_lIntCount, "[000][M] ")
                strData += Format(stIntItem.lAxisNo, "AxisNo: 00, ")
                strData += Format(stIntItem.dwIntFlag, "Flag: 0")
                strData += "[" + stIntItem.dwIntFlag.ToString("X") + "],"
                strData += Format(stIntItem.dwBank0, "Bank0: 0")
                strData += "[" + stIntItem.dwBank0.ToString("X") + "],"
                strData += Format(stIntItem.dwBank1, "Bank1: 0")
                strData += "[" + stIntItem.dwBank1.ToString("X") + "],"

            Case InterruptCategory.INT_CALLBACK
                '

            Case InterruptCategory.INT_EVENT
                '

            Case Else

        End Select

        lstIntLog.Items.Add(strData)
        lstIntLog.SelectedIndex = lstIntLog.Items.Count - 1
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
            MsgBox("AxlOpen Fail...", vbOKCancel)
            Return False
        End If

        Return True
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

        ' ++ 유효한 전체 모션축수를 반환합니다.
        AxmInfoGetAxisCount(m_lAxisCount)
        If m_lAxisCount < 1 Then
            Return False
        End If

        szModulename = Space(50)
        m_lAxisNo = 0
        ' ++ 지정한 축의 정보를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxisNo, dwBoardNo, dwModulePos, m_dwModuleId)

        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i As Integer = 0 To (m_lAxisCount - 1)
            ' ++ 지정한 축의 정보를 반환합니다.
            ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
            AxmInfoGetAxis(i, Nothing, Nothing, dwModuleID)
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
                    AxmInfoGetAxisEx(i, Nothing, szModulename, Nothing)
                    strModuleName = Replace(szModuleName, Chr(0), "")
                    strData = Format(i, "00") + "-[ECAT-" + strModuleName + "]"
                Case Else
                    strData = Format(i, "00") + "-[Unknown]"
            End Select

            cboSelAxis.Items.Add(strData)

        Next

        InitControl()
        Return True
    End Function

    Private Function InitControl()
        cboSelAxis.SelectedIndex = m_lAxisNo

        Return True
    End Function

    Private Function UpdateState()
        If m_lAxisCount < 1 Then
            Return False
        End If

        Dim dwIntMask As Integer = 0
        Dim dwOnOff As Long = 0
        Dim strIntMask As String = ""
        Dim testValue As Integer = 0

        ' ++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
        AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_1, dwIntMask)
        strIntMask = "Interrupt Event Bank 1 [0x" + dwIntMask.ToString("X8") + "]"
        grpBank1.Text = strIntMask

        ' 인터럽트 설정값 해당 콘트롤에 적용
        chkBank1Bit00.Checked = dwIntMask And &H1
        chkBank1Bit01.Checked = dwIntMask And &H2
        chkBank1Bit02.Checked = dwIntMask And &H4
        chkBank1Bit31.Checked = dwIntMask And &H80000000

        ' ++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
        AxmInterruptGetUserEnable(m_lAxisNo, INT_BANK_2, dwIntMask)
        strIntMask = "Interrupt Event Bank 2 [0x" + dwIntMask.ToString("X8") + "]"
        grpBank2.Text = strIntMask

        ' 인터럽트 설정값 해당 콘트롤에 적용
        chkBank2Bit14.Checked = dwIntMask And &H4000
        chkBank2Bit15.Checked = dwIntMask And &H8000
        chkBank2Bit16.Checked = dwIntMask And &H10000
        chkBank2Bit20.Checked = dwIntMask And &H100000
        chkBank2Bit21.Checked = dwIntMask And &H200000
        chkBank2Bit22.Checked = dwIntMask And &H400000

        Return True
    End Function
End Class
