' MoveMultiAxes.vb : implementation file
'// **************************************************************************
'// >> [일자]: 2015.11.30.
'// >> [개요]: 이 예제는 다축구동 함수들의 사용법을 익히고 각 함수들의 인자값을 
'//    변경하면서 구동해 보는 예제입니다.
'// >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
'//    구동을 정지하게 됩니다.
'// >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
'//     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
'//     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
'//        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
'// **************************************************************************

Public Class MoveMultiAxes

    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101
    Const MAX_MULTI_MOVE_AXIS As Integer = 4

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_dOldCmdPos(MAX_MULTI_MOVE_AXIS - 1), _
        m_dOldActPos(MAX_MULTI_MOVE_AXIS - 1), _
        m_dOldCmdVel(MAX_MULTI_MOVE_AXIS - 1) As Double
    Private m_lMoveMultiAxesCount As Integer
    Private m_lMoveMultiAxes(MAX_MULTI_MOVE_AXIS - 1) As Integer

    Private m_stcCmdPos(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_stcActPos(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_stcCmdVel(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_chkMoveMultiAxes(MAX_MULTI_MOVE_AXIS - 1) As CheckBox
    Private m_edtMovePos(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtMoveVel(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtMoveAcc(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtMoveDec(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtJogVel(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtJogAcc(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtJogDec(MAX_MULTI_MOVE_AXIS - 1) As TextBox
    Private m_edtLinePos(MAX_MULTI_MOVE_AXIS - 1) As TextBox

    Private Sub MoveMultiAxes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim index As Integer

        For index = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            m_lMoveMultiAxes(index) = -1
            m_dOldCmdPos(index) = 0.0
            m_dOldActPos(index) = 0.0
            m_dOldCmdVel(index) = 0.0
        Next

        m_stcCmdPos = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {stcCmdPos00, stcCmdPos01, stcCmdPos02, stcCmdPos03}
        m_stcActPos = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {stcActPos00, stcActPos01, stcActPos02, stcActPos03}
        m_stcCmdVel = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {stcCmdVel00, stcCmdVel01, stcCmdVel02, stcCmdVel03}
        m_chkMoveMultiAxes = New CheckBox(MAX_MULTI_MOVE_AXIS - 1) {chkAxis00, chkAxis01, chkAxis02, chkAxis03}
        m_edtMovePos = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtMovePos00, edtMovePos01, edtMovePos02, edtMovePos03}
        m_edtMoveVel = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtMoveVel00, edtMoveVel01, edtMoveVel02, edtMoveVel03}
        m_edtMoveAcc = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtMoveAcc00, edtMoveAcc01, edtMoveAcc02, edtMoveAcc03}
        m_edtMoveDec = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtMoveDec00, edtMoveDec01, edtMoveDec02, edtMoveDec03}
        m_edtJogVel = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtJogVel00, edtJogVel01, edtJogVel02, edtJogVel03}
        m_edtJogAcc = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtJogAcc00, edtJogAcc01, edtJogAcc02, edtJogAcc03}
        m_edtJogDec = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtJogDec00, edtJogDec01, edtJogDec02, edtJogDec03}
        m_edtLinePos = New TextBox(MAX_MULTI_MOVE_AXIS - 1) {edtLinePos00, edtLinePos01, edtLinePos02, edtLinePos03}

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
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        OpenFileDialog1.FileName = "*.mot"
        OpenFileDialog1.FilterIndex = 2

        OpenFileDialog1.ShowDialog()
        szFileName = OpenFileDialog1.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox("File load fail!")
            End If
        End If

        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> chkAxisXX_CheckedChanged(...) : 축 변경이 있을 때 호출되는 핸들러 함수. 
    '  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
    '    번호 배열값을 재할당합니다.
    '  - IDC_CHK_AXIS_00 ~ IDC_CHK_AXIS_03 버튼의 클릭이벤트 발생시 호출됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkAxis00_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAxis00.CheckedChanged
        UpdateState()
    End Sub

    Private Sub chkAxis01_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAxis01.CheckedChanged
        UpdateState()
    End Sub

    Private Sub chkAxis02_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAxis02.CheckedChanged
        UpdateState()
    End Sub

    Private Sub chkAxis03_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAxis03.CheckedChanged
        UpdateState()
    End Sub

    ' ++ =======================================================================
    ' >> btnPosClear_Click() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 0.0으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click(sender As System.Object, e As System.EventArgs) Handles btnPosClear.Click
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            '++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            AxmStatusSetPosMatch(m_lMoveMultiAxes(lCount), 0.0)
        Next

        AxmStatusSetPosMatch(m_lAxisNo, 0.0)
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_CheckedChanged() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkServoOn.CheckedChanged
        Dim dwIsChecked As Long
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            dwIsChecked = IIf(chkServoOn.Checked, 1, 0)
            AxmSignalServoOn(m_lMoveMultiAxes(lCount), dwIsChecked)
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnPosMove_Click() : "Move"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosMove_Click(sender As System.Object, e As System.EventArgs) Handles btnPosMove.Click
        Dim strData As String
        Dim dwRetCode, lCount, lArrayIndex As Integer
        Dim dMultiPos(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiVel(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiAcc(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double

        lArrayIndex = 0
        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                dMultiPos(lArrayIndex) = m_edtMovePos(lCount).Text
                dMultiVel(lArrayIndex) = m_edtMoveVel(lCount).Text
                dMultiAcc(lArrayIndex) = m_edtMoveAcc(lCount).Text
                dMultiDec(lArrayIndex) = m_edtMoveDec(lCount).Text
                lArrayIndex += 1
            End If
        Next

        If chkMoveBlock.Checked Then
            ' ++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
            dwRetCode = AxmMoveMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiPos(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0), 0)
            If dwRetCode <> AXT_RT_SUCCESS Then

                strData = "AxmMoveMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        Else
            ' ++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            dwRetCode = AxmMoveStartMultiPos(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiPos(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0), 0)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmMoveStartMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnPosStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축들로 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이 
    '    구동을 정지하게 됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosStop_Click(sender As System.Object, e As System.EventArgs) Handles btnPosStop.Click
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveMultiAxesCount - 1)
            ' ++ 지정한 축의 구동을 감속정지합니다.
            AxmMoveSStop(m_lMoveMultiAxes(lCount))
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnJogP_MouseDown(...) : "Jog(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogP_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogP.MouseDown
        Dim dwRetCode As Long = 0
        Dim lArrayIndex As Long = 0
        Dim strData As String
        Dim lCount As Integer
        Dim dMultiVel(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiAcc(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                dMultiVel(lArrayIndex) = Math.Abs(Val(m_edtJogVel(lCount).Text))
                dMultiAcc(lArrayIndex) = Math.Abs(Val(m_edtJogAcc(lCount).Text))
                dMultiDec(lArrayIndex) = Math.Abs(Val(m_edtJogDec(lCount).Text))
                lArrayIndex += 1
            End If
        Next

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0))
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartMultiVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogN_MouseDown(...) : "Jog(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogN_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogN.MouseDown
        Dim dwRetCode As Long = 0
        Dim lArrayIndex As Long = 0
        Dim strData As String
        Dim lCount As Integer
        Dim dMultiVel(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiAcc(MAX_MULTI_MOVE_AXIS - 1), _
            dMultiDec(MAX_MULTI_MOVE_AXIS - 1) As Double

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                dMultiVel(lArrayIndex) = -Math.Abs(Val(m_edtJogVel(lCount).Text))
                dMultiAcc(lArrayIndex) = Math.Abs(Val(m_edtJogAcc(lCount).Text))
                dMultiDec(lArrayIndex) = Math.Abs(Val(m_edtJogDec(lCount).Text))
                lArrayIndex += 1
            End If
        Next

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartMultiVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dMultiVel(0), dMultiAcc(0), dMultiDec(0))
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnLineP_MouseDown(...) : Line Move의 "Jog(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineP_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnLineP.MouseDown
        Dim dwRetCode As Long = 0
        Dim lArrayIndex As Long = 0
        Dim strData As String
        Dim lCount As Integer
        Dim dLinePos(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dLineVel, dLineAcc, dLineDec As Double

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                dLinePos(lArrayIndex) = Math.Abs(Val(m_edtLinePos(lCount).Text))
                lArrayIndex += 1
            End If
        Next

        dLineVel = Math.Abs(Val(edtLineVel.Text))
        dLineAcc = Math.Abs(Val(edtLineAcc.Text))
        dLineDec = Math.Abs(Val(edtLineDec.Text))

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dLinePos(0), dLineVel, dLineAcc, dLineDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartLineVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnLineN_MouseDown(...) : Line Move의 "Jog(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 다축구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineN_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnLineN.MouseDown
        Dim dwRetCode As Long = 0
        Dim lArrayIndex As Long = 0
        Dim strData As String
        Dim lCount As Integer
        Dim dLinePos(MAX_MULTI_MOVE_AXIS - 1) As Double
        Dim dLineVel, dLineAcc, dLineDec As Double

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                dLinePos(lArrayIndex) = -Math.Abs(Val(m_edtLinePos(lCount).Text))
                lArrayIndex += 1
            End If
        Next

        dLineVel = Math.Abs(Val(edtLineVel.Text))
        dLineAcc = Math.Abs(Val(edtLineAcc.Text))
        dLineDec = Math.Abs(Val(edtLineDec.Text))

        ' ++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveStartLineVel(m_lMoveMultiAxesCount, m_lMoveMultiAxes(0), dLinePos(0), dLineVel, dLineAcc, dLineDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmMoveStartLineVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogP_MouseUp(...) : "Jog(+)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogP_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogP.MouseUp
        btnPosStop_Click(Nothing, Nothing)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogN_MouseUp(...) : "Jog(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogN_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogN.MouseUp
        btnPosStop_Click(Nothing, Nothing)
    End Sub

    ' ++ =======================================================================
    ' >> btnLineP_MouseUp(...) : Line Move의 "Jog(+)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineP_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnLineP.MouseUp
        btnPosStop_Click(Nothing, Nothing)
    End Sub

    ' ++ =======================================================================
    ' >> btnLineN_MouseUp(...) : Line Move의 "Jog(-)"버튼 Up시 호출되는 핸들러 함수.
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLineN_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnLineN.MouseUp
        btnPosStop_Click(Nothing, Nothing)
    End Sub

    ' ++ =======================================================================
    '// >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    '// --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim dCmdPos As Double = 0.0
        Dim dActPos As Double = 0.0
        Dim dCmdVel As Double = 0.0
        Dim lArrayIndex As Long = 0
        Dim lCount As Integer

        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            If m_chkMoveMultiAxes(lCount).Checked Then
                ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
                AxmStatusGetCmdPos(m_lMoveMultiAxes(lArrayIndex), dCmdPos)
                If m_dOldCmdPos(lCount) <> dCmdPos Then
                    m_stcCmdPos(lCount).Text = Format(dCmdPos, "0.000")
                    m_dOldCmdPos(lCount) = dCmdPos
                End If

                ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                AxmStatusGetActPos(m_lMoveMultiAxes(lArrayIndex), dActPos)
                If m_dOldActPos(lCount) <> dActPos Then
                    m_stcActPos(lCount).Text = Format(dActPos, "0.000")
                    m_dOldActPos(lCount) = dActPos
                End If

                ' ++ 지정한 축의 구동 속도를 반환합니다.
                AxmStatusReadVel(m_lMoveMultiAxes(lArrayIndex), dCmdVel)
                If m_dOldCmdVel(lCount) <> dCmdVel Then
                    m_stcCmdVel(lCount).Text = Format(dCmdVel, "0.000")
                    m_dOldCmdVel(lCount) = dCmdVel
                End If

                lArrayIndex += 1
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

        szModuleName = Space(50)
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
                    AxmInfoGetAxisEx(i, Nothing, szModuleName, Nothing)
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

        Dim bSelectCheck, bEmptyCheck, bAllCheck As Boolean
        Dim strData As String
        Dim dwOnOff As Long = 0
        Dim lTotalCount As Long = 0
        Dim lBoardNo As Long = 0
        Dim lModulePos As Long = 0
        Dim lFirstAxisNo As Long = 0
        Dim lCount As Integer

        ' ++ 지정한 축의 정보를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxisNo, lBoardNo, lModulePos, Nothing)
        ' ++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
        AxmInfoGetFirstAxisNo(lBoardNo, lModulePos, lFirstAxisNo)

        m_lMoveMultiAxesCount = 0
        bSelectCheck = False
        bEmptyCheck = False
        For lCount = 0 To (MAX_MULTI_MOVE_AXIS - 1)
            ' 지정한 축이 제어가 가능한 상태인지 반환합니다.
            If AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS Then
                strData = "Axis " + Format(lFirstAxisNo, "00")
                m_chkMoveMultiAxes(lCount).Enabled = True
                bSelectCheck = m_chkMoveMultiAxes(lCount).Checked
                bEmptyCheck = bEmptyCheck Or bSelectCheck

                If bSelectCheck = True Then
                    m_lMoveMultiAxes(m_lMoveMultiAxesCount) = lFirstAxisNo
                    m_lMoveMultiAxesCount = m_lMoveMultiAxesCount + 1
                End If

                m_edtMovePos(lCount).Enabled = bSelectCheck
                m_edtMoveVel(lCount).Enabled = bSelectCheck
                m_edtMoveAcc(lCount).Enabled = bSelectCheck
                m_edtMoveDec(lCount).Enabled = bSelectCheck

                m_edtJogVel(lCount).Enabled = bSelectCheck
                m_edtJogAcc(lCount).Enabled = bSelectCheck
                m_edtJogDec(lCount).Enabled = bSelectCheck

                m_edtLinePos(lCount).Enabled = bSelectCheck
            Else
                m_lMoveMultiAxes(lCount) = -1
                strData = "Axis --"
                m_chkMoveMultiAxes(lCount).Enabled = False
                m_chkMoveMultiAxes(lCount).Checked = False

                m_edtMovePos(lCount).Enabled = False
                m_edtMoveVel(lCount).Enabled = False
                m_edtMoveAcc(lCount).Enabled = False
                m_edtMoveDec(lCount).Enabled = False

                m_edtJogVel(lCount).Enabled = False
                m_edtJogAcc(lCount).Enabled = False
                m_edtJogDec(lCount).Enabled = False

                m_edtLinePos(lCount).Enabled = False
            End If

            lFirstAxisNo = lFirstAxisNo + 1
            m_chkMoveMultiAxes(lCount).Text = strData

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
            AxmSignalIsServoOn(m_lMoveMultiAxes(lCount), dwOnOff)
            ' 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
            bAllCheck = bAllCheck And dwOnOff
        Next

        chkServoOn.Checked = bAllCheck

        Return True
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

End Class
