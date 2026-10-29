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

Public Class StatusMonitor

    Const TM_DISPLAY As Integer = 100
    Const MAX_ITEM_END As Integer = 14
    Const MAX_ITEM_MECH As Integer = 14
    Const MAX_ITEM_DRIVE As Integer = 10

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0

    Private Sub StatusMonitorDlg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo()               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState()               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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
    ' >> btnLoadFile_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '   - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '   - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
    '       설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLoadFile_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadFile.Click
        Dim szFileName As String
        CommonDialog1Open.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2

        CommonDialog1Open.ShowDialog()
        szFileName = CommonDialog1Open.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox("File load fail!")
            End If
        End If

        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        ' 중요한 정보들만 모니터링 하도록 선택했습니다.
        Dim lDigitEnd(MAX_ITEM_END - 1) As Long
        lDigitEnd = New Long(MAX_ITEM_END - 1) {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 15, 28, 30, 31}
        Dim lDigitMech(MAX_ITEM_MECH - 1) As Long
        lDigitMech = New Long(MAX_ITEM_MECH - 1) {0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17}
        Dim lDigitDrive(MAX_ITEM_DRIVE - 1) As Long
        lDigitDrive = New Long(MAX_ITEM_DRIVE - 1) {0, 1, 2, 3, 4, 5, 6, 7, 10, 11}
        Dim chkGroupInpMech(MAX_ITEM_MECH - 1) As CheckBox
        chkGroupInpMech = New CheckBox(MAX_ITEM_MECH - 1) {chkMechBit00, chkMechBit01, chkMechBit04, _
                           chkMechBit05, chkMechBit06, chkMechBit07, _
                           chkMechBit08, chkMechBit09, chkMechBit10, _
                           chkMechBit11, chkMechBit12, chkMechBit13, _
                           chkMechBit14, chkMechBit17}
        Dim chkGroupInpEnd(MAX_ITEM_END - 1) As CheckBox
        chkGroupInpEnd = New CheckBox(MAX_ITEM_END - 1) {chkEndBit00, chkEndBit01, chkEndBit04, _
                          chkEndBit05, chkEndBit06, chkEndBit07, _
                          chkEndBit08, chkEndBit09, chkEndBit10, _
                          chkEndBit11, chkEndBit15, chkEndBit28, _
                          chkEndBit30, chkEndBit31}
        Dim chkGroupInpDrive(MAX_ITEM_DRIVE - 1) As CheckBox
        chkGroupInpDrive = New CheckBox(MAX_ITEM_DRIVE - 1) {chkDriveBit00, chkDriveBit01, chkDriveBit02, _
                            chkDriveBit03, chkDriveBit04, chkDriveBit05, _
                            chkDriveBit06, chkDriveBit07, chkDriveBit10, _
                            chkDriveBit11}

        Dim lCheck As Long = 0
        Dim dwRetCode As Long = 0
        Dim dwStatus As Long = 0
        Dim lIndex As Integer

        ' ++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadMechanical(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_MECH - 1)
                lCheck = (dwStatus >> lDigitMech(lIndex)) And &H1
                chkGroupInpMech(lIndex).Checked = lCheck
            Next
        End If

        ' ++ 지정 축의 End Status(정지 상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadStop(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_END - 1)
                lCheck = (dwStatus >> lDigitEnd(lIndex)) And &H1
                chkGroupInpEnd(lIndex).Checked = lCheck
            Next
        End If

        ' ++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
        '  ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
        dwRetCode = AxmStatusReadMotion(m_lAxisNo, dwStatus)
        If dwRetCode = AXT_RT_SUCCESS Then
            For lIndex = 0 To (MAX_ITEM_DRIVE - 1)
                lCheck = (dwStatus >> lDigitDrive(lIndex)) And &H1
                chkGroupInpDrive(lIndex).Checked = lCheck
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
            MsgBox("AxlOpen Fail...", vbOKCancel)
            Return False
        End If

        Dim szFilePath As String = "..\..\..\..\EzSoftware\MotionDefault.mot"
        If AxmMotLoadParaAll(szFilePath) <> AXT_RT_SUCCESS Then
            MsgBox("Mot File Not Found.", vbOKCancel)
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

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl()
        cboSelAxis.SelectedIndex = m_lAxisNo

        Return True
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
            Return False
        End If

        Return True
    End Function
End Class
