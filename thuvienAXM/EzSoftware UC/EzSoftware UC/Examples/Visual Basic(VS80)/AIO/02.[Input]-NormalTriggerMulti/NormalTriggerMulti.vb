Option Strict Off
Option Explicit On
Friend Class NormalTriggerMulti
    Inherits System.Windows.Forms.Form
    ' NormalTriggerMulti.frm : implementation file
    '
    ' **************************************************************************
    ' >> [일자]: 2016.01.20
    ' >> [개요]: 이 예제는 AIO모듈의 Normal Trigger 관련 함수들의 사용법을 익히고
    '    다중 채널의 아날로그 입력 값을 전압 혹은 Digit 값으로 반환하는 방법을
    '    학습하는 예제입니다.
    ' >> [중요]: Normal Trigger 관련 함수들
    '     1) AxaiSetMultiRange 함수는 지정 다중 입력 채널에 입력 전압 범위를 설정합니다.
    '     2) AxaiSetTriggerMode 함수는 지정 입력 모듈에 A/D변환 방식을 설정합니다.
    '     3) AxaiSwReadMultiVoltage 함수는 지정 다중 입력 채널의 아날로그 입력 값을
    '        전압으로 반환합니다.
    '     4) AxaiSwReadMultiVoltage 함수는 지정 다중 입력 채널의 아날로그 입력 값을
    '        Digit 값으로 반환합니다.
    '     ※ AxaiSwReadMultiVoltage 함수를 사용하기 전에 AxaiSetTriggerMode 함수를 사용하여
    '        Normal Trigger Mode로 설정해야 합니다.
    ' **************************************************************************

    Dim m_dwModuleID As Integer
    Dim m_lModuleNo As Integer
    Dim m_lModuleCount As Integer
    Dim m_lChannelCount As Integer
    Dim m_bIsReadVoltage As Boolean
    Dim m_dOldVoltArr(3) As Double
    Dim m_dwOldDigitArr(3) As Short

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        InitLibrary() ' 라이브러리 초기화 작업을 수행합니다.
        AddModuleChannelInfo() ' 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState() ' AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' AXL 사용을 종료합니다.
        AxlClose()
    End Sub

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> m_cboModule_Click() : 모듈 변경시 호출되는 핸들러 함수.
    '  - 모듈이 변경되었을 때 변경된 모듈의 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_cboModule_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_cboModule.SelectedIndexChanged
        Dim dwRetCode As Short
        Dim lBoardNo As Long
        Dim lModulePos As Integer

        lBoardNo = 0
        lModulePos = 0

        m_lModuleNo = m_cboModule.SelectedIndex
        ' 변경된 모듈의 ID를 가져옵니다.
        dwRetCode = AxaInfoGetModule(m_lModuleNo, lBoardNo, lModulePos, m_dwModuleID)

        ' 변경된 모듈의 채널 수를 가져옵니다.
        dwRetCode = AxaInfoGetInputCount(m_lModuleNo, m_lChannelCount)

        ' 전압 범위 업데이트
        ' ++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> m_cboVoltageRange_Click() : 입력 전압 범위 변경시 호출되는 핸들러 함수.
    '  - 해당 채널의 입력 전압 범위를 갱신합니다.
    '  - 입력 전압 범위는 A/D변환 성능과 관련이 있으므로 측정 범위 확인 후 설정하시기 바랍니다.
    '  - 모듈별로 허용 입력 전압이 정해져 있습니다.
    '  - 사용자가 입력 전압 설정범위 이외 전압을 입력하면 자동으로 그 값을 포함하는 근삿값으로 자동 설정됩니다.
    ' --------------------------------------------------------------------------
    Private Sub m_cboVoltageRange_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_cboVoltageRange.SelectedIndexChanged
        Dim dwRetCode As Short
        Dim dMinVolt As Double
        Dim dMaxVolt As Double
        Dim lChannelArr(3) As Integer

        dwRetCode = 0
        dMinVolt = 0.0#
        dMaxVolt = 0.0#
        lChannelArr(0) = 0
        lChannelArr(1) = 1
        lChannelArr(2) = 2
        lChannelArr(3) = 3

        Select Case m_cboVoltageRange.SelectedIndex
            Case 0
                dMinVolt = -10.0#
                dMaxVolt = 10.0#

            Case 1
                dMinVolt = -5.0#
                dMaxVolt = 5.0#

            Case 2
                dMinVolt = 0.0#
                dMaxVolt = 10.0#

            Case 3
                dMinVolt = 0.0#
                dMaxVolt = 5.0#
        End Select

        ' 입력 전압 범위를 설정합니다.
        dwRetCode = AxaiSetMultiRange(4, lChannelArr(0), dMinVolt, dMaxVolt)
        Dim strData As String
        If (dwRetCode <> AXT_RT_SUCCESS) Then
            strData = "AxaiSetMultiRange return error[Code:" & Format(dwRetCode, "0000") & "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_cboValueType_Click() : 입력 정보 종류를 변경시 호출되는 핸들러 함수.
    '  - 입력값을 전압 또는 10진수로 출력할 때 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_cboValueType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_cboValueType.SelectedIndexChanged
        Dim nValueType As Short

        nValueType = ConvertComboToAxa(m_cboValueType)
        If (nValueType = 0) Then
            m_bIsReadVoltage = True
        Else
            m_bIsReadVoltage = False
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_btnStart_Click() : "Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 단일 채널에 들어오는 값을 Normal Trigger로 읽기 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_btnStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_btnStart.Click
        m_cboModule.Enabled = False
        m_cboVoltageRange.Enabled = False
        m_cboValueType.Enabled = False
        m_btnStart.Enabled = False
        m_btnStop.Enabled = True

        m_dOldVoltArr(0) = 0.0#
        m_dOldVoltArr(1) = 0.0#
        m_dOldVoltArr(2) = 0.0#
        m_dOldVoltArr(3) = 0.0#
        m_dwOldDigitArr(0) = 0
        m_dwOldDigitArr(1) = 0
        m_dwOldDigitArr(2) = 0
        m_dwOldDigitArr(3) = 0

        m_timer.Enabled = True ' Normal Trigger 시작
    End Sub

    ' ++ =======================================================================
    ' >> m_btnStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 작업을 중지합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_btnStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_btnStop.Click
        m_cboModule.Enabled = True
        m_cboVoltageRange.Enabled = True
        m_cboValueType.Enabled = True
        m_btnStart.Enabled = True
        m_btnStop.Enabled = False

        m_timer.Enabled = False
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer(...) : 타이머 이벤트 핸들러 함수.
    '  - Normal Trigger로 입력 값을 주기적으로 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_timer.Tick
        Dim strValue As String
        Dim dwRetCode As Short
        Dim lChannelArr(3) As Integer

        lChannelArr(0) = 0
        lChannelArr(1) = 1
        lChannelArr(2) = 2
        lChannelArr(3) = 3

        Dim dVoltArr(3) As Double
        Dim dwDigitArr(3) As Integer
        If (m_bIsReadVoltage = True) Then
            ' 지정 채널로 들어오는 값을 전압 단위로 읽어옵니다.
            dwRetCode = AxaiSwReadMultiVoltage(4, lChannelArr(0), dVoltArr(0))
            If (m_dOldVoltArr(0) <> dVoltArr(0)) Then
                strValue = Format(dVoltArr(0), "0.0000")
                m_stcCh00.Text = strValue
                m_dOldVoltArr(0) = dVoltArr(0)
            End If
            If (m_dOldVoltArr(1) <> dVoltArr(1)) Then
                strValue = Format(dVoltArr(1), "0.0000")
                m_stcCh01.Text = strValue
                m_dOldVoltArr(1) = dVoltArr(1)
            End If
            If (m_dOldVoltArr(2) <> dVoltArr(2)) Then
                strValue = Format(dVoltArr(2), "0.0000")
                m_stcCh02.Text = strValue
                m_dOldVoltArr(2) = dVoltArr(2)
            End If
            If (m_dOldVoltArr(3) <> dVoltArr(3)) Then
                strValue = Format(dVoltArr(3), "0.0000")
                m_stcCh03.Text = strValue
                m_dOldVoltArr(3) = dVoltArr(3)
            End If
        Else
            ' 지정 채널로 들어오는 값을 10진수 단위로 읽어옵니다.
            ' dwRetCode = AxaiSwReadDigit(m_lChannelNo, dwDigit)
            dwRetCode = AxaiSwReadMultiDigit(4, lChannelArr(0), dwDigitArr(0))
            If (m_dwOldDigitArr(0) <> dwDigitArr(0)) Then
                strValue = Format(dwDigitArr(0), "0")
                m_stcCh00.Text = strValue
                m_dwOldDigitArr(0) = dwDigitArr(0)
            End If
            If (m_dwOldDigitArr(1) <> dwDigitArr(1)) Then
                strValue = Format(dwDigitArr(1), "0")
                m_stcCh01.Text = strValue
                m_dwOldDigitArr(1) = dwDigitArr(1)
            End If
            If (m_dwOldDigitArr(2) <> dwDigitArr(2)) Then
                strValue = Format(dwDigitArr(0), "0")
                m_stcCh02.Text = strValue
                m_dwOldDigitArr(2) = dwDigitArr(2)
            End If
            If (m_dwOldDigitArr(3) <> dwDigitArr(3)) Then
                strValue = Format(dwDigitArr(3), "0")
                m_stcCh03.Text = strValue
                m_dwOldDigitArr(3) = dwDigitArr(3)
            End If
        End If
    End Sub

    ' **************************************************************************
    ' >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> InitLibrary() : 라이브러리 초기화 함수.
    '  - AXL(AjineXtek Library)을 사용가능하게 합니다.
    ' --------------------------------------------------------------------------
    Private Function InitLibrary() As Long
        ' ++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
        Dim dwStatus As Long
        Dim dwRetCode As Short
        Dim lModuleCounts As Integer
        dwStatus = 0
        dwRetCode = AxlOpenNoReset(7) ' 설정값들을 초기화하지 않음
        lModuleCounts = 0

        If (dwRetCode <> AXT_RT_SUCCESS) Then
            MsgBox("AxlOpen Fail...")
            InitLibrary = False
        End If

        dwRetCode = AxaInfoIsAIOModule(dwStatus) ' AIO모듈 존재여부를 확인합니다
        If (dwStatus <> STATUS_EXIST) Then
            MsgBox("The Module does not exist...")
            InitLibrary = False
        End If

        InitLibrary = True
    End Function

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl() As Long
        Dim dwRetCode As Short

        m_lModuleNo = 0
        m_bIsReadVoltage = True

        m_cboModule.SelectedIndex = 0
        m_cboValueType.SelectedIndex = 0

        m_btnStop.Enabled = False

        ' 첫번째 모듈의 ID를 가져옵니다.
        dwRetCode = AxaInfoGetModule(m_lModuleNo, 0, 0, m_dwModuleID)

        InitControl = True
    End Function

    ' ++ =======================================================================
    ' >> AddModuleChannelInfo() : 시스템에 장착된 AIO모듈들을 ComboBox에 등록하는 함수.
    '  - AIO모듈 정보를 읽어 ComboBox에 등록하여 사용자가 선택
    '    제어할 수 있도록 합니다.
    '  - 유효한 모듈이 검색되었을 때 Control들을 초기화 합니다.
    ' --------------------------------------------------------------------------
    Private Sub AddModuleChannelInfo()
        Dim iModuleNo As Integer
        Dim lInputCounts As Long
        Dim strData As String
        Dim szModuleName As String
        Dim lBoardNo As Long
        Dim lModulePos As Integer
        Dim dwModuleID As Long
        Dim dwRetCode As Long
        ' 시스템에 장착된 모든AIO 모듈의 개수를 확인합니다.
        szModuleName = Space(50)
        lInputCounts = 0
        lBoardNo = 0
        lModulePos = 0
        dwModuleID = 0
        dwRetCode = AxaInfoGetModuleCount(m_lModuleCount)
        strData = ""

        For iModuleNo = 0 To (m_lModuleCount - 1)
            ' 각 모듈의 입력 채널 수를 확인합니다.
            dwRetCode = AxaInfoGetInputCount(iModuleNo, lInputCounts)
            If (lInputCounts > 0) Then
                ' 해당 모듈의 정보를 가져옵니다.
                dwRetCode = AxaInfoGetModule(iModuleNo, lBoardNo, lModulePos, dwModuleID)
                If (dwRetCode = AXT_RT_SUCCESS) Then
                    Select Case dwModuleID
                        Case AXT_SIO_AI4RB
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_AI4RB [Input : " & lInputCounts & "]"
                        Case AXT_SIO_AI16H
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_AI16H [Input : " & lInputCounts & "]"
                        Case AXT_SIO_AI16HB
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_AI16HB [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RAI8RB
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RAI8RB [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RAI4MLII
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RAI4MLII [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RAI16RB
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RAI16RB [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RAVCI4MLII
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RAVCI4MLII [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RATI4MLII
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RATI4MLII [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RARTDI4MLII
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RARTDI4MLII [Input : " & lInputCounts & "]"
                        Case AXT_SIO_RAO08RTEX
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_RAO08RTEX [Input : " & lInputCounts & "]"
                        Case AXT_SIO_AI8F
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_AI8F [Input : " & lInputCounts & "]"
                        Case AXT_SIO_AI8AO4F
                            strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] SIO_AI8A04F [Input : " & lInputCounts & "]"
                        Case AXT_ECAT_AIO
                            If (lInputCounts > 0) Then
                                ' EtherCAT AIO 전용 모듈 정보 추출
                                dwRetCode = AxaInfoGetModuleEx(iModuleNo, Nothing, szModuleName, Nothing)
                                strData = "[BD No:" & lBoardNo & " - MD No:" & iModuleNo & "] " & szModuleName & " [Input : " & lInputCounts & "]"
                            End If
                        Case Else
                            strData = "[Unknown]"
                    End Select

                    m_cboModule.Items.Add((strData))
                End If
            End If
        Next

        InitControl()
    End Sub

    ' ++ =======================================================================
    ' >> UpdateState() : 지정한 모듈의 설정값들을 읽어 Control과 일치시키는 함수.
    '  - 모듈이 변경되었을 때 변경한 모듈의 설정값들과 Control들과 일치시키는
    '    역할을하는 함수입니다.
    '  - 지정한 모듈의 모델별 제약들을 Control에 반영하는 역할을 합니다.
    '  - 프로그램 초기 실행시, 모듈 번호 바뀔 때 사용됩니다.
    ' --------------------------------------------------------------------------
    Private Function UpdateState() As Long
        If (m_lModuleCount < 1) Then
            UpdateState = False
        End If

        Dim dwRetCode As Short
        dwRetCode = 0

        ' ++ 각 모듈별 지원여부에 따라 콘트롤 값들을 변경합니다.
        m_cboVoltageRange.Items.Clear()
        m_cboVoltageRange.Enabled = True
        Select Case m_dwModuleID
            Case AXT_SIO_AI4RB, AXT_SIO_AO4RB, AXT_SIO_AI8AO4F
                m_cboVoltageRange.Items.Add(("00: -10V ~ +10V"))
                m_cboVoltageRange.Items.Add(("01: -5V ~ +5V"))
                m_cboVoltageRange.Items.Add(("02: 0V ~ +10V"))
                m_cboVoltageRange.Items.Add(("03: 0V ~ +5V"))

            Case AXT_SIO_AI8F, AXT_SIO_AO4F
                m_cboVoltageRange.Items.Add(("00: -10V ~ +10V"))
                m_cboVoltageRange.Items.Add(("01: -5V ~ +5V"))
        End Select

        ' ++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
        UpdateVoltageRange()

        UpdateState = True
    End Function

    ' ++ =======================================================================
    ' >> ConvertComboToAxa(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
    '    보드에 설정할 값으로 변경하는 함수.
    '  - ComboBox에 선택된 Item Index와 실제 모듈에 설정되는 값이 다르므로
    '    선택된 문자열에서 모듈에 설정할 값을 추출해서 반환하는 함수입니다.
    '  - 변환 할 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "00: Volt", "01: Digit"
    ' --------------------------------------------------------------------------
    Private Function ConvertComboToAxa(ByRef pCboItem As System.Windows.Forms.ComboBox) As Long
        If IsNothing(pCboItem) Then
            Return 0
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.Items.Count
        If dwCount = 0 Then
            Return 0
        End If

        dwSelData = pCboItem.SelectedIndex
        If dwSelData < 0 Then
            Return 0
        End If

        strText = pCboItem.Items.Item(dwSelData)
        Return Val(strText)
    End Function

    ' ++ =======================================================================
    ' >> ConvertAxaToCombo(...) : 지정한 모듈의 설정값과 ComboBox콘트롤의
    '    Item과 일치하는 Item을 찾아 선택하는 함수.
    '  - 실제 모듈값과 ComboBox의 Item Index가  다르므로 지정한
    '    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
    '  - 변경하고자하는 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "00: Volt", "01: Digit"
    ' --------------------------------------------------------------------------
    Private Function ConvertAxaToCombo(ByRef pCboItem As System.Windows.Forms.ComboBox, ByVal dwCurData As Short) As Long
        Dim i As Integer

        If IsNothing(pCboItem) Then
            Return 0
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.Items.Count
        If dwCount = 0 Then
            Return 0
        End If

        For i = 0 To (dwCount - 1)
            strText = pCboItem.Items.Item(i)
            dwSelData = Val(strText)
            If dwSelData = dwCurData Then
                pCboItem.SelectedIndex = i
                Return i
            End If
        Next

        pCboItem.SelectedIndex = 0
        Return 0
    End Function

    ' ++ =======================================================================
    ' >> UpdateVoltageRange(...) : 전압 범위를 갱신하는 함수.
    '  - 모듈이나 채널 변경 시 해당 채널의 입력 전압 범위로
    '    Control값을 변경합니다.
    ' --------------------------------------------------------------------------
    Private Sub UpdateVoltageRange()
        Dim dwRetCode As Short
        Dim dMinVolt As Double
        Dim dMaxVolt As Double

        dwRetCode = 0
        dMinVolt = 0
        dMaxVolt = 0

        ' ++ 0번 입력 채널을 대표로 입력 전압 범위를 확인합니다.
        dwRetCode = AxaiGetRange(0, dMinVolt, dMaxVolt)
        If (dwRetCode = AXT_RT_SUCCESS) Then
            If (dMinVolt = -10.0# And dMaxVolt = 10.0#) Then
                m_cboVoltageRange.SelectedIndex = 0
            ElseIf (dMinVolt = -5.0# And dMaxVolt = 5.0#) Then
                m_cboVoltageRange.SelectedIndex = 1
            ElseIf (dMinVolt = 0.0# And dMaxVolt = 10.0#) Then
                m_cboVoltageRange.SelectedIndex = 2
            ElseIf (dMinVolt = 0.0# And dMaxVolt = 5.0#) Then
                m_cboVoltageRange.SelectedIndex = 3
            End If
        Else
            m_cboVoltageRange.SelectedIndex = 0
        End If
    End Sub
End Class