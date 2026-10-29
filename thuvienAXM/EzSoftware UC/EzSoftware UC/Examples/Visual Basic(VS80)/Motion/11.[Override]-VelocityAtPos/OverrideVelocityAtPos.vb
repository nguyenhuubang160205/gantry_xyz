'  OverrideVelocityAtPos.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.12.01.
' >> [개요]: 이 예제는 지정한 위치에서 속도 오버라이드하는 함수들의 사용법을
'    익히고 여러 위치에서 다중 속도 오버라이드를 확인할 수 있는 예제입니다.
' >> [중요]: 속도오버라이드 제약사항
'     1) 속도오버라이드는 가속/감속 중에는 반영되지 않습니다.
'     2) 등속구간 진입시 가속/감속 중에 변경한 속도값이 반영됩니다.
'     3) AxmOverrideVelAtMultiPos 함수를 이용해서 오버라이드 구동중에는 별도의
'        속도 오버라이드 함수를 호출하여 속도를 변경하면 지정한 오버라이드 
'        위치에서 지정한 속도가 되도록 하는 기능은 보장 할 수 없습니다.
' **************************************************************************

Public Class OverrideVelocityAtPos

    Const MAX_OVER_MULTI_POS As Integer = 50
    Const FW_NORMAL As Integer = 400
    Const WIDTH_PER_LIST_WORD As Integer = 18

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_dOldCmdPos As Double = 0.0
    Private m_dOldActPos As Double = 0.0
    Private m_dOldCmdVel As Double = 0.0

    Private m_ftItemList As Font

    Private Sub OverrideVelocityAtPos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()   ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo()   ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState()   ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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
    ' >> btnPosSet_Click() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 0.0으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosSet_Click(sender As System.Object, e As System.EventArgs) Handles btnPosSet.Click
        Dim dSetPos As Double = edtSetPos.Text

        ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
        AxmStatusSetPosMatch(m_lAxisNo, dSetPos)
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_CheckedChanged() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkServoOn.CheckedChanged
        Dim dwOnOff As Long

        dwOnOff = IIf(chkServoOn.Checked, 1, 0)
        ' ++ 지정 축의 Servo On/Off 신호를 출력합니다.
        AxmSignalServoOn(m_lAxisNo, dwOnOff)
    End Sub

    ' ++ =======================================================================
    ' >> rdoAbs_CheckedChanged(...) : "Absolute"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 좌표계를 절대좌표계로 설정합니다.
    '  - Ex) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
    ' --------------------------------------------------------------------------
    Private Sub rdoAbs_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoAbs.CheckedChanged
        Dim dwRetCode As Long = 0

        ' ++ 지정 축의 구동 좌표계를 설정합니다. 
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_ABS_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> rdoRel_CheckedChanged(...) : "Relative"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 좌표계를 상대좌표계로 설정합니다.
    '  - Ex) 현재 Command위치 100으로 가정
    '     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
    '     2) AxmMoveStartPos(0, 200, ...)
    '     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
    ' --------------------------------------------------------------------------
    Private Sub rdoRel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoRel.CheckedChanged
        Dim dwRetCode As Long = 0

        ' ++ 지정 축의 구동 좌표계를 설정합니다. 
        ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
        '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
        dwRetCode = AxmMotSetAbsRelMode(m_lAxisNo, POS_REL_MODE)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetAbsRelMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkOverMulti_CheckedChanged() : "Override Vel At Multi Pos Use"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 오버라이드 할 함수의 종류를 설정합니다.
    '  - 오버라이드 함수에 따라 필요한 인자들을 활성화/비활성화 시킵니다. 
    ' --------------------------------------------------------------------------
    Private Sub chkOverMulti_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverMulti.CheckedChanged
        Dim bEnableMulti As Boolean = chkOverMulti.Checked

        edtOverPos.Enabled = Not bEnableMulti
        edtOverVel.Enabled = Not bEnableMulti
        btnOverVelAtPos.Enabled = Not bEnableMulti

        cboOverMode.Enabled = bEnableMulti
        lstOverData.Enabled = bEnableMulti
        btnOverVelAtMPos.Enabled = bEnableMulti
        btnOverDataAdd.Enabled = bEnableMulti
        btnOverDataClr.Enabled = bEnableMulti
        edtOverPosAdd.Enabled = bEnableMulti
        edtOverVelAdd.Enabled = bEnableMulti
    End Sub

    ' ++ =======================================================================
    ' >> btnOverVelAtPos_Click() : "Override At Pos"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnOverVelAtPos_Click(sender As System.Object, e As System.EventArgs) Handles btnOverVelAtPos.Click
        Dim dwRetCode As Long
        Dim strData As String
        Dim lCampTarget As Long
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel As Double

        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        dOverPos = edtOverPos.Text
        dOverVel = edtOverVel.Text

        lCampTarget = ConvertComboToAxm(cboCampTarget)
        ' ++ 선택한 축에 모션 구동중 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
        dwRetCode = AxmOverrideVelAtPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, dOverPos, dOverVel, lCampTarget)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmOverrideVelAtPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnOverVelAtMPos_Click() : "Multi At Pos"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 여러개의 지정한 위치에서 정확하게 오버라이드하는 구동을 시작합니다.
    '  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제 구현 편의상 50개로
    '    제한하였습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnOverVelAtMPos_Click(sender As System.Object, e As System.EventArgs) Handles btnOverVelAtMPos.Click
        Dim dwRetCode As Long
        Dim strData As String
        Dim lCampTarget, lOverMode, lArraySize As Long
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double
        Dim daOverPos(MAX_OVER_MULTI_POS - 1), daOverVel(MAX_OVER_MULTI_POS - 1) As Double

        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        lCampTarget = ConvertComboToAxm(cboCampTarget)
        lOverMode = ConvertComboToAxm(cboOverMode)
        lArraySize = ConvertListBoxToArray(lstOverData, daOverPos, daOverVel)

        ' ++ 선택한 축에 모션 구동중 여러개의 지정한 위치에서 속도 오버라이드 하는 구동을 시작합니다.
        '   함수 사용시 진행 방향 기준으로 먼저 도달하는 포지션부터 배열에 입력이 되어야 합니다.
        '   dwOverrideMode : (0)OVERRIDE_POS_START 지정한 위치에서 지정한 속도로 오버라이드 시작함        
        '                  : (1)OVERRIDE_POS_END 지정한 위치에서 지정한 속도가 되도록 미리 오버라이드 시작함
        dwRetCode = AxmOverrideVelAtMultiPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec, lArraySize, daOverPos(0), daOverVel(0), lCampTarget, lOverMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmOverrideVelAtMultiPos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        ' ++ 지정한 축의 구동을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnOverDataAdd_Click() : "<< Add Item"버튼 클릭시 호출되는 핸들러 함수.
    '  - 속도 오버라이드 정보를 ListBox에 등록합니다. 
    ' --------------------------------------------------------------------------
    Private Sub btnOverDataAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnOverDataAdd.Click
        Dim strData As String
        Dim dOverPos As Double = edtOverPosAdd.Text
        Dim dOverVel As Double = edtOverVelAdd.Text

        strData = RSet(Format(dOverPos, "0.000"), WIDTH_PER_LIST_WORD) + ", " + _
            RSet(Format(dOverVel, "0.000"), WIDTH_PER_LIST_WORD)

        lstOverData.Items.Add(strData)
    End Sub

    ' ++ =======================================================================
    ' >> lstOverData_DoubleClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
    '  - 등록된 속도 오버라이드 정보중 선택된 Item을 지울때 호출됩니다.
    '  - List Box 콘트롤에서 마우스 포인트를 삭제할 Item 으로 이동한 후 마우스 
    '    왼쪽 버튼을 더블클릭하면 해당 Item이 선택 삭제됩니다.
    ' --------------------------------------------------------------------------
    Private Sub lstOverData_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lstOverData.DoubleClick
        Dim objSelected As Object = lstOverData.SelectedItem
        lstOverData.Items.Remove(objSelected)
    End Sub

    ' ++ =======================================================================
    ' >> btnOverDataClr_Click() : "All Clear Item"버튼 클릭시 호출되는 핸들러 함수.
    '  - 등록된 오버라이드 데이타를 모두 지웁니다.
    ' --------------------------------------------------------------------------
    Private Sub btnOverDataClr_Click(sender As System.Object, e As System.EventArgs) Handles btnOverDataClr.Click
        lstOverData.Items.Clear()
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim dCmdPos As Double = 0.0
        Dim dActPos As Double = 0.0
        Dim dCmdVel As Double = 0.0

        ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
        AxmStatusGetCmdPos(m_lAxisNo, dCmdPos)
        If m_dOldCmdPos <> dCmdPos Then
            stcCmdPos.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPos = dCmdPos
        End If

        ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
        AxmStatusGetActPos(m_lAxisNo, dActPos)
        If m_dOldActPos <> dActPos Then
            stcActPos.Text = Format(dActPos, "0.000")
            m_dOldActPos = dActPos
        End If

        ' ++ 지정한 축의 구동 속도를 반환합니다.
        AxmStatusReadVel(m_lAxisNo, dCmdVel)
        If m_dOldCmdVel <> dCmdVel Then
            stcCmdVel.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVel = dCmdVel
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

        cboOverMode.SelectedIndex = 0
        cboCampTarget.SelectedIndex = 0

        'm_ftItemList = New Font(-12, 0, 0, 0, FW_NORMAL, False, False, 0, 0, 0, 0, 0, 0, "Courier")
        m_ftItemList = New Font("Courier", 10)
        lstOverData.Font = m_ftItemList

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

        Dim dwAbsRelMode As Long = POS_ABS_MODE
        Dim dwProfile As Long = ASYM_S_CURVE_MODE
        Dim dwOnOff As Long = 0

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        AxmSignalIsServoOn(m_lAxisNo, dwOnOff)
        chkServoOn.Checked = dwOnOff

        ' ++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
        AxmMotGetAbsRelMode(m_lAxisNo, dwAbsRelMode)
        If dwAbsRelMode = POS_ABS_MODE Then
            rdoAbs.Checked = True
        Else
            rdoRel.Checked = True
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

    ' ++ =======================================================================
    ' >> ConvertListBoxToArray(...) : 지정한 콘트롤에 설정되어 있는 텍스트를 
    '    오버라이드 정보값으로  변환하여 반환하는 함수.
    '  - ListBox 콘트롤에 설정된 텍스트를 두개의 오버라이드 정보값으로 변환하여
    '    코드를 간결하게 구현하였습니다.
    '  - 실제 오버라이드 함수의 위치지정 갯수 제한은 없으나 예제구현 편의상 50개로
    '    제한하였습니다.
    ' --------------------------------------------------------------------------
    Private Function ConvertListBoxToArray(ByRef pLstItem As ListBox, ByRef dpOverPos As Double(), ByRef dpOverVel As Double())
        Dim lCount As Integer

        If IsNothing(pLstItem) Or IsNothing(dpOverPos) Or IsNothing(dpOverVel) Then
            Return 0
        End If

        Dim strData As String
        Dim nSection, nLength As Integer
        Dim lArraySize As Long

        lArraySize = pLstItem.Items.Count
        If lArraySize = 0 Then
            Return 0
        End If

        For lCount = 0 To lArraySize - 1
            If lCount = MAX_OVER_MULTI_POS Then
                lArraySize = MAX_OVER_MULTI_POS
                Exit For
            End If
            strData = pLstItem.Items.Item(lCount)

            nLength = strData.Length
            nSection = strData.IndexOf(",")
            dpOverPos(lCount) = Val(Trim(strData.Substring(0, nSection)))
            dpOverVel(lCount) = Val(Trim(strData.Substring(nSection + 1)))
        Next

        Return lArraySize
    End Function
End Class
