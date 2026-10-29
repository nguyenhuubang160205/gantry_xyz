' ContiInterpolation.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.12.02
' >> [개요]: 이 예제는 보간함수들의 사용법을 익히고 정해진 패턴의 연속보간
'    데이타들을 연속보간 Queue에 예약 및 실행 해 보는 예제입니다.    
' >> [중요]: 연속보간 데이타 예약 및 구동하기
'     1) AxmContiSetAxisMap함수를 이용해서 필요한 축수의 좌표계를 맵핑합니다.
'     2) AxmContiSetAbsRelMode함수를 이용해 해당좌표계의 구동모드를 설정합니다.
'     3) AxmContiBeginNode함수를 이용해 보간구동 예약을 시작합니다.
'     4) AxmLineMove, AxmCircleCenterMove등의 보간함수를 이용해 구동을 예약합니다.
'     5) AxmContiEndNode함수를 이용해 보간구동 예약을 종료합니다.
'     6) AxmContiStart함수를 이용해 예약된 보간구동을 시작합니다.
' **************************************************************************

Public Class ContiInterpolation

    Const COORD_NO As Integer = 0
    Const MAX_SPLINE_NODE As Integer = 5
    Const MAX_INTP_MOVE_AXIS As Integer = 4

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_lMoveIntpAxesCount As Integer
    Private m_lMoveIntpAxes(MAX_INTP_MOVE_AXIS - 1) As Integer
    Private m_chkMoveIntpAxes(MAX_INTP_MOVE_AXIS - 1) As CheckBox
    Private m_dOldCmdPos(MAX_INTP_MOVE_AXIS - 1), _
        m_dOldActPos(MAX_INTP_MOVE_AXIS - 1), _
        m_dOldCmdVel(MAX_INTP_MOVE_AXIS - 1) As Double
    Private m_stcCmdPos(MAX_INTP_MOVE_AXIS - 1) As TextBox
    Private m_stcActPos(MAX_INTP_MOVE_AXIS - 1) As TextBox
    Private m_stcCmdVel(MAX_INTP_MOVE_AXIS - 1) As TextBox

    Private Sub ContiInterpolation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim index As Integer

        For index = 0 To (MAX_INTP_MOVE_AXIS - 1)
            m_lMoveIntpAxes(index) = -1
            m_dOldCmdPos(index) = 0.0
            m_dOldActPos(index) = 0.0
            m_dOldCmdVel(index) = 0.0
        Next
        m_chkMoveIntpAxes = New CheckBox(MAX_INTP_MOVE_AXIS - 1) {chkAxis00, chkAxis01, chkAxis02, chkAxis03}
        m_stcCmdPos = New TextBox(MAX_INTP_MOVE_AXIS - 1) {stcCmdPos00, stcCmdPos01, stcCmdPos02, stcCmdPos03}
        m_stcActPos = New TextBox(MAX_INTP_MOVE_AXIS - 1) {stcActPos00, stcActPos01, stcActPos02, stcActPos03}
        m_stcCmdVel = New TextBox(MAX_INTP_MOVE_AXIS - 1) {stcCmdVel00, stcCmdVel01, stcCmdVel02, stcCmdVel03}

        InitLibrary()               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo()               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState()               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    Private Sub ContiInterpolation_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        AxlClose()
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

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            '++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            AxmStatusSetPosMatch(m_lMoveIntpAxes(lCount), 0.0)
        Next
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_CheckedChanged() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkServoOn.CheckedChanged
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            '++ 지정 축의 Servo On/Off 신호를 출력합니다.
            If chkServoOn.Checked Then
                AxmSignalServoOn(m_lMoveIntpAxes(lCount), 1)
            Else
                AxmSignalServoOn(m_lMoveIntpAxes(lCount), 0)
            End If
        Next
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpLine_Click() : "Line"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpLine_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpLine.Click
        Dim dwRetCode As Long = 0
        Dim dMovePos(1) As Double
        Dim dVelocity, dAccel, dDecel As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dMovePos(0) = 100.0 ' 첫번째 축의 이동할 위치값
        dMovePos(1) = 200.0 ' 두번째 축의 이동할 위치값

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)

        ' ++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다.  
        dwRetCode = AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmLineMove return error[Code:0000]")
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    '// >> btnIntpArc_Click() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
    '//  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
    '// --------------------------------------------------------------------------
    Private Sub btnIntpArc_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpArc.Click
        Dim dwRetCode As Long = 0
        Dim dwArcDir, dwShortDis As Long
        Dim dEndPos(1) As Double
        Dim dVelocity, dAccel, dDecel, dRadius As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dEndPos(0) = 100.0
        dEndPos(1) = 100.0
        dRadius = 141.0
        dwArcDir = DIR_CW
        dwShortDis = LONG_DISTANCE

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.
        dwRetCode = AxmCircleRadiusMove(COORD_NO, m_lMoveIntpAxes(0), dRadius, dEndPos(0), dVelocity, dAccel, dDecel, dwArcDir, dwShortDis)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmCircleRadiusMove return error[Code:0000]")
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpCircle_Click() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpCircle_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpCircle.Click
        Dim dwRetCode As Long = 0
        Dim dwArcDir As Long
        Dim dCenterPos(1) As Double
        Dim dVelocity, dAccel, dDecel, dAngle As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dCenterPos(0) = 200.0
        dCenterPos(1) = 200.0
        dAngle = 359.0
        dwArcDir = DIR_CCW

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.
        Threading.Thread.Sleep(1)
        dwRetCode = AxmCircleAngleMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dAngle, dVelocity, dAccel, dDecel, dwArcDir)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmCircleAngleMove return error[Code:0000]")
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpLineArc_Click() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpLineArc_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpLineArc.Click
        Dim dwRetCode As Long = 0
        Dim dMovePos(1), dCenterPos(1), dEndPos(1) As Double
        Dim dVelocity, dAccel, dDecel As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 2, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        AxmContiBeginNode(COORD_NO)

        dMovePos(0) = 0.0
        dMovePos(1) = 200.0
        ' ++ 지정한 좌표계에 직선보간 구동을 예약합니다.
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dMovePos(0) = 180.0
        dMovePos(1) = 200.0
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = 180.0
        dCenterPos(1) = 180.0
        dEndPos(0) = 200.0
        dEndPos(1) = 180.0
        ' ++ 지정한 좌표계에 중심점과 종료점을 이용하는 원호보간 구동을 예약합니다.
        AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = 200.0
        dMovePos(1) = -180.0
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = 180.0
        dCenterPos(1) = -180.0
        dEndPos(0) = 180.0
        dEndPos(1) = -200.0
        AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = -180.0
        dMovePos(1) = -200.0
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = -180.0
        dCenterPos(1) = -180.0
        dEndPos(0) = -200.0
        dEndPos(1) = -180.0
        AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = -200.0
        dMovePos(1) = 180.0
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        dCenterPos(0) = -180.0
        dCenterPos(1) = 180.0
        dEndPos(0) = -180.0
        dEndPos(1) = 200.0
        AxmCircleCenterMove(COORD_NO, m_lMoveIntpAxes(0), dCenterPos(0), dEndPos(0), dVelocity, dAccel, dDecel, DIR_CW)

        dMovePos(0) = 0.0
        dMovePos(1) = 200.0
        AxmLineMove(COORD_NO, dMovePos(0), dVelocity, dAccel, dDecel)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpHelical_Click() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpHelical_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpHelical.Click
        Dim dwArcDir As Long
        Dim dVelocity, dAccel, dDecel As Double
        Dim dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        dCenterPosX = 100.0
        dCenterPosY = 100.0
        dEndPosX = 0.0
        dEndPosY = 0.0
        dZPos = 10.0
        dwArcDir = DIR_CW

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 4, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_REL_MODE)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        AxmContiBeginNode(COORD_NO)
        '++ 지정한 좌표계에 중심점과 종료점을 이용하는 헬리컬 보간구동을 예약합니다
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)
        AxmHelixCenterMove(COORD_NO, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, dwArcDir)

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpSpline_Click() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpSpline_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpSpline.Click
        Dim lPointFactor As Long
        Dim dVelocity, dAccel, dDecel As Double
        Dim dPosX(MAX_SPLINE_NODE - 1), dPosY(MAX_SPLINE_NODE - 1), dPosZ As Double

        dVelocity = edtMoveVel.Text
        dAccel = edtMoveAcc.Text
        dDecel = edtMoveDec.Text

        ' ++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
        AxmContiSetAxisMap(COORD_NO, 3, m_lMoveIntpAxes(0))
        ' ++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
        AxmContiWriteClear(COORD_NO)
        ' ++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
        AxmContiSetAbsRelMode(COORD_NO, POS_ABS_MODE)

        dPosX(0) = 0
        dPosY(0) = 0
        dPosX(1) = 45
        dPosY(1) = 10
        dPosX(2) = 75
        dPosY(2) = 45
        dPosX(3) = 108
        dPosY(3) = 75
        dPosX(4) = 130
        dPosY(4) = 70
        dPosZ = 1.0
        lPointFactor = 100

        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
        ' ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
        AxmContiBeginNode(COORD_NO)
        '++ 지정한 좌표계에 X좌표, Y좌표, Z좌표를 이용하는 스플라인 보간구동을 예약합니다.
        AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, dPosZ, lPointFactor)

        dPosX(0) = 130
        dPosY(0) = 70
        dPosX(1) = 108
        dPosY(1) = 75
        dPosX(2) = 75
        dPosY(2) = 45
        dPosX(3) = 45
        dPosY(3) = 10
        dPosX(4) = 0
        dPosY(4) = 0
        dPosZ = 1.0
        lPointFactor = 100
        AxmSplineWrite(COORD_NO, MAX_SPLINE_NODE, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, dPosZ, lPointFactor)


        ' ++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
        ' ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
        '              연속보간 구동을 실행할 수 있습니다.
        AxmContiEndNode(COORD_NO)
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpStart_Click() : "Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpStart_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpStart.Click
        Dim dwRetCode As Long

        '++ 지정한 좌표계의 연속보간 구동을 시작합니다.
        dwRetCode = AxmContiStart(COORD_NO, CONTI_NODE_VELOCITY, 0)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmContiStart return error[Code:0000d]")
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpClear_Click() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 예약된 연속보간 데이타들을 지우는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpClear_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpClear.Click
        Dim dwRetCode As Long

        '++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
        dwRetCode = AxmContiWriteClear(COORD_NO)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = Format(dwRetCode, "AxmContiWriteClear return error[Code:0000d]")
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnIntpStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 연속보간을 정지하는 함수입니다.
    ' --------------------------------------------------------------------------
    Private Sub btnIntpStop_Click(sender As System.Object, e As System.EventArgs) Handles btnIntpStop.Click
        Dim lCount As Integer

        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            ' ++ 지정한 좌표계에 연속 보간 구동을 감속정지합니다.
            ' [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
            AxmMoveSStop(m_lMoveIntpAxes(lCount))
        Next

    End Sub

    ' =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim dCmdPos As Double = 0.0
        Dim dActPos As Double = 0.0
        Dim dCmdVel As Double = 0.0
        Dim lArrayIndex As Long = 0
        Dim dwQueueFree As Long = 0
        Dim dwIntpInMotion As Long = 0
        Dim lExeNode As Integer = 0
        Dim lTotalNode As Long = 0
        Dim isTrue As Boolean = False
        Dim lCount As Integer

        For lCount = 0 To (MAX_INTP_MOVE_AXIS - 1)
            If m_chkMoveIntpAxes(lCount).Checked Then
                ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
                AxmStatusGetCmdPos(m_lMoveIntpAxes(lArrayIndex), dCmdPos)
                If m_dOldCmdPos(lCount) <> dCmdPos Then
                    m_stcCmdPos(lCount).Text = Format(dCmdPos, "0.000")
                    m_dOldCmdPos(lCount) = dCmdPos
                End If

                ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                AxmStatusGetActPos(m_lMoveIntpAxes(lArrayIndex), dActPos)
                If m_dOldActPos(lCount) <> dActPos Then
                    m_stcActPos(lCount).Text = Format(dActPos, "0.000")
                    m_dOldActPos(lCount) = dActPos
                End If

                ' ++ 지정한 축의 구동 속도를 반환합니다.
                AxmStatusReadVel(m_lMoveIntpAxes(lArrayIndex), dCmdVel)
                If m_dOldCmdVel(lCount) <> dCmdVel Then
                    m_stcCmdVel(lCount).Text = Format(dCmdVel, "0.000")
                    m_dOldCmdVel(lCount) = dCmdVel
                End If

                lArrayIndex += 1
            End If
        Next

        ' ++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
        AxmContiReadFree(COORD_NO, dwQueueFree)
        isTrue = IIf(dwQueueFree = 1, True, False)
        chkIntpQueueFree.Checked = isTrue

        ' ++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
        AxmContiIsMotion(COORD_NO, dwIntpInMotion)
        isTrue = IIf(dwIntpInMotion = 1, True, False)
        chkIntpInMotion.Checked = isTrue

        ' ++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
        AxmContiGetNodeNum(COORD_NO, lExeNode)
        If Val(stcIntpExeNode.Text) <> lExeNode Then
            stcIntpExeNode.Text = lExeNode
        End If

        ' ++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
        AxmContiGetTotalNodeNum(COORD_NO, lTotalNode)
        If Val(stcIntpTotalNode.Text) <> lTotalNode Then
            stcIntpTotalNode.Text = lTotalNode
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

        bSelectCheck = False
        bEmptyCheck = False
        m_lMoveIntpAxesCount = 0
        For lCount = 0 To (MAX_INTP_MOVE_AXIS - 1)
            ' 지정한 축이 제어가 가능한 상태인지 반환합니다.
            If AxmInfoGetAxisStatus(lFirstAxisNo) = AXT_RT_SUCCESS Then
                strData = Format(lFirstAxisNo, "Axis 00")
                m_chkMoveIntpAxes(lCount).Enabled = True
                bSelectCheck = m_chkMoveIntpAxes(lCount).Checked
                bEmptyCheck = bEmptyCheck Or bSelectCheck

                If bSelectCheck = True Then
                    m_lMoveIntpAxes(m_lMoveIntpAxesCount) = lFirstAxisNo
                    m_lMoveIntpAxesCount += 1
                End If
            Else
                m_lMoveIntpAxes(lCount) = -1
                strData = "Axis --"
                m_chkMoveIntpAxes(lCount).Enabled = False
                m_chkMoveIntpAxes(lCount).Checked = False
            End If
            lFirstAxisNo += 1
            m_chkMoveIntpAxes(lCount).Text = strData
        Next

        ' 선택된 축이 없으면 Disable처리
        chkServoOn.Enabled = bEmptyCheck

        bAllCheck = True
        For lCount = 0 To (m_lMoveIntpAxesCount - 1)
            ' ++ 지정한 축의 서보온 상태를 반환합니다.
            AxmSignalIsServoOn(m_lMoveIntpAxes(lCount), dwOnOff)
            ' 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
            bAllCheck = bAllCheck And dwOnOff
        Next

        chkServoOn.Checked = bAllCheck

        ' 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
        If m_lMoveIntpAxesCount < 2 Then
            btnIntpLine.Enabled = DISABLE
            btnIntpArc.Enabled = DISABLE
            btnIntpCircle.Enabled = DISABLE
            btnIntpLineArc.Enabled = DISABLE
            btnIntpHelical.Enabled = DISABLE
            btnIntpSpline.Enabled = DISABLE
        Else
            btnIntpLine.Enabled = ENABLE
            btnIntpArc.Enabled = ENABLE
            btnIntpCircle.Enabled = ENABLE
            btnIntpLineArc.Enabled = ENABLE
            If m_lMoveIntpAxesCount >= 3 Then
                btnIntpSpline.Enabled = ENABLE
            Else
                btnIntpSpline.Enabled = DISABLE
            End If

            If m_lMoveIntpAxesCount = 4 Then
                btnIntpHelical.Enabled = ENABLE
            Else
                btnIntpHelical.Enabled = DISABLE
            End If
        End If
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
