' MoveSingleAxis.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.11.27
' >> [개요]: 이 예제는 단축구동 관련 함수들의 사용법을 익히고 단축구동에 필요한
'    기본 파라메타 설정 및 구동을 학습하는 예제입니다.
' >> [중요]: 단축 구동관련 설정함수들
'     1) AxmMotSetMoveUnitPerPulse 함수는 거리/속도/가감속도의 단위를 설정합니다.
'     2) AxmMotSetAbsRelMode 함수는 구동 좌표계(절대좌표/상대좌표)를 설정합니다. 
'     3) AxmMotSetProfileMode 함수는 구동 프로파일 형태를 설정합니다.
' **************************************************************************

Public Class MoveSingleAxis

    Const TM_DISPLAY As Integer = 100

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_dOldCmdPos As Double = 0.0
    Private m_dOldActPos As Double = 0.0
    Private m_dOldCmdVel As Double = 0.0
    Private m_bTestActive(7) As Boolean
    Private m_hTestThread(7) As Threading.Thread


    Private Sub MoveSingleAxis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()   ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo()   ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState()   ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    Private Sub MoveSingleAxis_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
    ' >> btnPosClear_Click() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 위치정보를 0.0으로 설정합니다.
    '  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
    '    사용하는것과 동일한 효과를 냅니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click(sender As System.Object, e As System.EventArgs) Handles btnPosClear.Click
        AxmStatusSetPosMatch(m_lAxisNo, 0.0)
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_CheckedChanged() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkServoOn.CheckedChanged
        Dim dwOnOff As Long

        'dwOnOff = chkServoOn.Checked
        dwOnOff = IIf(chkServoOn.Checked, 1, 0)
        ' ++ 지정 축의 Servo On/Off 신호를 출력합니다.
        AxmSignalServoOn(m_lAxisNo, dwOnOff)
    End Sub

    ' ++ =======================================================================
    ' >> btnMove1_Click() : "Move Target 1"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축을 "Target Position 1" Edit콘트롤에 입력된 거리(또는 위치)/속도/
    '    가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMove1_Click(sender As System.Object, e As System.EventArgs) Handles btnMove1.Click
        Dim dwRetCode As Long = 0
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtPos1.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
        dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveStartPos1 return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMove2_Click() : "Move Target 2"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축을 "Target Position 2" Edit콘트롤에 입력된 거리(또는 위치)/속도/
    '    가속도/감속도로 모션구동합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMove2_Click(sender As System.Object, e As System.EventArgs) Handles btnMove2.Click
        Dim dwRetCode As Long = 0
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtPos2.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
        dwRetCode = AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveStartPos2 return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnRepeat_Click(...) : "<< Repeat >> " 버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 지정된 Position을 이용하여 Repeat 구동을 합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnRepeat_Click(sender As System.Object, e As System.EventArgs) Handles btnRepeat.Click
        Dim nCurSel As Integer = cboSelAxis.SelectedIndex

        If m_bTestActive(nCurSel) = False Then
            m_bTestActive(nCurSel) = True
            If IsNothing(m_hTestThread(nCurSel)) Then
                m_hTestThread(nCurSel) = New Threading.Thread(AddressOf RepeatThread)
                m_hTestThread(nCurSel).Start()
            End If
        Else
            MsgBox("Already Moving")
        End If

    End Sub

    ' ++ =======================================================================
    ' >> btnSStop_Click() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSStop_Click(sender As System.Object, e As System.EventArgs) Handles btnSStop.Click
        Dim dwRetCode As Long = 0

        dwRetCode = AxmMoveSStop(m_lAxisNo)
        If m_bTestActive(m_lAxisNo) = True Then
            m_bTestActive(m_lAxisNo) = False
        End If
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveSStop return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
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
    ' >> cboProfile_SelectedIndexChanged(...) : "Velocity Profile Set" ComboBox 콘트롤 Item선택 
    '    변경시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동 프로파일을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboProfile_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProfile.SelectedIndexChanged
        Dim dwRetCode As Long = 0
        Dim dwProfileMode = ConvertComboToAxm(cboProfile)

        ' ++ 지정 축의 구동 속도 프로파일 모드를 설정한다.
        ' dwProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
        '                 (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
        '                 (3)SYM_S_CURVE_MODE    - Symmetric S Curve
        '                 (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
        dwRetCode = AxmMotSetProfileMode(m_lAxisNo, dwProfileMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMotSetProfileMode return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseDown(...) : "Jog Move(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveP.MouseDown
        Dim dwRetCode As Long = 0
        Dim dJogVel, dJogAcc, dJogDec As Double

        dJogVel = Math.Abs(Val(edtJogVel.Text))
        dJogAcc = Math.Abs(Val(edtJogAcc.Text))
        dJogDec = Math.Abs(Val(edtJogDec.Text))

        ' ++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseUp(...) : "Jog Move(+)"버튼 Up시 호출되는 핸들러 함수.    
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveP.MouseUp
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseDown(...) : "Jog Move(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveN.MouseDown
        Dim dwRetCode As Long = 0
        Dim dJogVel, dJogAcc, dJogDec As Double

        dJogVel = Math.Abs(Val(edtJogVel.Text))
        dJogAcc = Math.Abs(Val(edtJogAcc.Text))
        dJogDec = Math.Abs(Val(edtJogDec.Text))

        ' ++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseUp(...) : "Jog Move(-)"버튼 Up시 호출되는 핸들러 함수.    
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveN.MouseUp
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
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
        Dim i As Integer

        cboProfile.Items.Clear()
        cboProfile.Enabled = True
        cboProfile.Items.Add("00: SYM_TRAPEZOID_MODE")
        cboProfile.Items.Add("01: ASYM_TRAPEZOID_MODE")
        cboProfile.Items.Add("03: SYM_S_CURVE_MODE")
        cboProfile.Items.Add("04: ASYM_S_CURVE_MODE")

        cboSelAxis.SelectedIndex = m_lAxisNo

        rdoAbs.Checked = True

        For i = 0 To 7
            m_bTestActive(i) = False
            m_hTestThread(i) = Nothing
        Next

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

        ' ++ 지정한 축의 구동 프로파일 설정값을 확인합니다.
        AxmMotGetProfileMode(m_lAxisNo, dwProfile)
        If dwProfile > 2 Then
            cboProfile.SelectedIndex = dwProfile - 1
        Else
            cboProfile.SelectedIndex = dwProfile
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
    ' >> RepeatThread(...) : "btnRepeat_Click" 함수에서 호출되는 스레드용 함수.
    '  - 선택한 축에 지정된 Position을 이용하여 Repeat 구동을 합니다.
    ' --------------------------------------------------------------------------
    Private Sub RepeatThread()
        Dim dCurPos As Double
        Dim dwMode As Long
        Dim dwBusyStatus As Long = True
        Dim nCurSel As Integer = m_lAxisNo
        Dim dPos, dVel, dAcc, dDec As Double

        dPos = edtPos2.Text
        dVel = Math.Abs(Val(edtMoveVel.Text))
        dAcc = Math.Abs(Val(edtMoveAcc.Text))
        dDec = Math.Abs(Val(edtMoveDec.Text))

        AxmMotGetAbsRelMode(nCurSel, dwMode)
        AxmStatusGetCmdPos(nCurSel, dCurPos)

        ' Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.
        While m_bTestActive(nCurSel) = True
            AxmMoveStartPos(nCurSel, dPos, dVel, dAcc, dDec)

            dwBusyStatus = True
            Do While m_bTestActive(nCurSel) And dwBusyStatus
                AxmStatusReadInMotion(nCurSel, dwBusyStatus)
                Threading.Thread.Sleep(100)
            Loop

            If m_bTestActive(nCurSel) = False Then
                Exit While
            End If

            If dwMode = POS_ABS_MODE Then
                If dCurPos = dPos Then
                    Exit While
                End If
                AxmMoveStartPos(nCurSel, dCurPos, dVel, dAcc, dDec)
            Else
                If dPos = 0 Then
                    Exit While
                End If
                AxmMoveStartPos(nCurSel, -dPos, dVel, dAcc, dDec)
            End If

            dwBusyStatus = True
            Do While m_bTestActive(nCurSel) And dwBusyStatus
                AxmStatusReadInMotion(nCurSel, dwBusyStatus)
                Threading.Thread.Sleep(1)
            Loop

        End While

        m_bTestActive(nCurSel) = False
        m_hTestThread(nCurSel) = Nothing

    End Sub
End Class
