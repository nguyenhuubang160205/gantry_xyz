' GantryMotion.vb : implementation file
'// **************************************************************************
'// >> [일자]: 2015.12.02
'// >> [개요]: 이 예제는 겐트리 함수들의 사용법을 익히고 겐트리 기구물에서의 
'//    원점검색 및 Slave축 Offset 설정 방법등에 대해 학습하는 예제입니다.
'// >> [중요]: 겐트리 Slave축 Offset설정방법 
'//     1) AxmGantrySetEnable함수의 uSlHomeUse인자를 2로 설정해서 원점검색을 합니다. 
'//     2) 원점검색이 정상적으로 완료되면 Slave축 원점위치에서 Master축 원점
'//        위치까지의 차이값이(Offset) Master축 지령위치가 됩니다.
'//     3) AxmGantrySetEnable함수의 uSlHomeUse인자를 1로, dSlaveHmOffset인자에
'//        위에서 측정한 Master축 지령위치값에 부호를 변경한 후 설정하면됩니다. 
'// **************************************************************************

Public Class GantryMotion

    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101
    Const GANTRY_SLAVE_HM_DONE As Integer = 0
    Const GANTRY_SLAVE_HM_BOTH As Integer = 1
    Const GANTRY_SLAVE_HM_EACH As Integer = 2

    Private m_lAxisNo As Long = -1
    Private m_lAxisNoMa As Long = -1
    Private m_lAxisNoSl As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_dwOldResult As Long = HOME_ERR_UNKNOWN
    Private m_dOldCmdPosMa As Double = 0.0
    Private m_dOldActPosMa As Double = 0.0
    Private m_dOldCmdVelMa As Double = 0.0
    Private m_dOldCmdPosSl As Double = 0.0
    Private m_dOldActPosSl As Double = 0.0
    Private m_dOldCmdVelSl As Double = 0.0

    Private Sub GantryMotion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo()               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState()               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' ++ =======================================================================
    ' >> cboSelAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelAxis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSelAxis.SelectedIndexChanged
        m_lAxisNo = cboSelAxis.SelectedIndex

        m_lAxisNoMa = (m_lAxisNo \ 2) * 2   ' 선택된 축번호로 겐트리 Master축 번호 생성
        m_lAxisNoSl = m_lAxisNoMa + 1   ' 선택된 축번호로 겐트리 Slave축 번호 생성

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
    ' >> btnPosClear_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
    '    설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnPosClear_Click(sender As System.Object, e As System.EventArgs) Handles btnPosClear.Click
        Dim dwState As Long = DISABLE
        ' ++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
        AxmGantryGetEnable(m_lAxisNoMa, Nothing, Nothing, Nothing, dwState)
        If dwState = ENABLE Then
            ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            AxmStatusSetPosMatch(m_lAxisNoMa, 0.0)
            AxmStatusSetPosMatch(m_lAxisNoSl, 0.0)
        Else
            AxmStatusSetPosMatch(m_lAxisNo, 0.0)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkServoOn_CheckedChanged() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkServoOn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkServoOn.CheckedChanged
        Dim dwOnOff As Long = 0
        Dim dwState As Long = DISABLE

        dwOnOff = IIf(chkServoOn.Checked, 1, 0)
        ' ++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
        AxmGantryGetEnable(m_lAxisNoMa, Nothing, Nothing, Nothing, dwState)
        If dwState = ENABLE Then
            ' ++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            AxmSignalServoOn(m_lAxisNoMa, dwOnOff)
            AxmSignalServoOn(m_lAxisNoSl, dwOnOff)
        Else
            AxmSignalServoOn(m_lAxisNo, dwOnOff)
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
    ' >> btnMovePos_Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
    '  - 지정한 축이 겐트리 축으로 활성화되어 있으면 두축이 동기되어 구동됩니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
    '    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
    '    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMovePos_Click(sender As System.Object, e As System.EventArgs) Handles btnMovePos.Click
        Dim dMovePos, dMoveVel, dMoveAcc, dMoveDec As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dMovePos = edtMovePos.Text
        dMoveVel = edtMoveVel.Text
        dMoveAcc = edtMoveAcc.Text
        dMoveDec = edtMoveDec.Text

        ' ++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도로 모션구동합니다.
        AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec)
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveP_MouseDown(...) : "Jog Move(+)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveP_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveP.MouseDown
        Dim dwRetCode As Long = 0
        Dim dJogVel, dJogAcc, dJogDec As Double

        dJogVel = Math.Abs(Val(edtMoveVel.Text))
        dJogAcc = Math.Abs(Val(edtMoveAcc.Text))
        dJogDec = Math.Abs(Val(edtMoveDec.Text))

        ' ++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, dJogVel, dJogAcc, dJogDec)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmMoveVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnJogMoveN_MouseDown(...) : "Jog Move(-)"버튼 Down시 호출되는 핸들러 함수.
    '  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveN.MouseDown
        Dim dwRetCode As Long = 0
        Dim dJogVel, dJogAcc, dJogDec As Double

        dJogVel = Math.Abs(Val(edtMoveVel.Text))
        dJogAcc = Math.Abs(Val(edtMoveAcc.Text))
        dJogDec = Math.Abs(Val(edtMoveDec.Text))

        ' ++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
        dwRetCode = AxmMoveVel(m_lAxisNo, -dJogVel, dJogAcc, dJogDec)
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
    ' >> btnJogMoveN_MouseUp(...) : "Jog Move(-)"버튼 Up시 호출되는 핸들러 함수.    
    '  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnJogMoveN_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnJogMoveN.MouseUp
        ' ++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 구동정지 함수를 호출하여 구동을 종료합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveStop.Click
        ' ++ 지정한 축의 모션구동(Jog구동/원점검색구동)을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStart_Click() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 원점검색을 시작합니다.
    ' ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 두축 모두 서보온이
    '    되어있지 않을 경우 AxmGantrySetEnable 함수로 겐트리 기능을 활성활 할 때 설정한 
    '    dwSlaveHmUse의 값에 따라 원점검색이 완료되지 않을 수 있습니다.
    ' ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 AxmGantrySetEnable
    '    함수로 겐트리 기능을 활성활 할 때 설정한 dwSlaveHmUse의 값에 따라 원점검색
    '    방법이 달라집니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStart_Click(sender As System.Object, e As System.EventArgs) Handles btnHomeStart.Click
        Dim dwRetCode As Long
        ' 원점검색 레벨 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' - dwLevel: [00]LOW, [01]HIGH
        ' > AxmHomeSetSignalLevel(m_lAxisNoMa, dwLevel)
        ' > AxmHomeSetSignalLevel(m_lAxisNoSl, dwLevel)

        ' 원점검색 방법설정 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' - lHomeDir     : [00]DIR_CCW, [01]DIR_CW
        ' - dwHomeSignal : [00]PosEndLimit, [01]NegEndLimit, [04]HomeSensor
        ' - dwZPhaseUse  : [00]Not Use, [01]Home Dir, [02]Not Home Dir
        ' > AxmHomeSetMethod(m_lAxisNoMa, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        ' > AxmHomeSetMethod(m_lAxisNoSl, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)

        ' 원점검색 속도설정 변경이 필요할 때 주석을 해제해서 사용하세요.
        ' > AxmHomeSetVel(m_lAxisNoMa, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        ' > AxmHomeSetVel(m_lAxisNoSl, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)

        ' ++ 지정한 축의 원점검색 구동을 시작합니다.
        dwRetCode = AxmHomeSetStart(m_lAxisNo)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetStart return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStop_Click() : "Home Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 구동정지 함수를 호출하여 원점검색구동을 종료합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStop_Click(sender As System.Object, e As System.EventArgs) Handles btnHomeStop.Click
        ' ++ 지정한 축의 원점검색구동(모션구동/Jog구동)을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> chkGantryEnable_CheckedChanged() : "Gantry Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축으로 겐트리 기능을 활성화 합니다.
    ' ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
    '    또한 동기되어 자동정지됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkGantryEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkGantryEnable.CheckedChanged
        Dim dwSlaveHmUse, dwRetCode As Long
        Dim dSlaveHmOffset, dSlaveHmRange As Double

        If chkGantryEnable.Checked Then
            dwSlaveHmUse = ConvertComboToAxm(cboGantryHmSlaveUse)
            dSlaveHmOffset = edtGantryHmOffset.Text
            dSlaveHmRange = edtGantryHmRange.Text

            ' ++ 지정한 Master축과 Slave축으로 겐트리 기능을 활성화 시킵니다.
            dwRetCode = AxmGantrySetEnable(m_lAxisNoMa, m_lAxisNoSl, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange)
            If dwRetCode <> AXT_RT_SUCCESS Then
                Dim strData As String
                strData = "AxmGantrySetEnable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        Else
            ' ++ 지정한 Master축과 Slave축으로 겐트리 기능을 비활성화 시킵니다.
            dwRetCode = AxmGantrySetDisable(m_lAxisNoMa, m_lAxisNoSl)
            If dwRetCode <> AXT_RT_SUCCESS Then
                Dim strData As String
                chkGantryEnable.Checked = True
                strData = "AxmGantrySetDisable return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If

    End Sub

    ' ++ =======================================================================
    '// >> m_timerDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
    '//  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    '// --------------------------------------------------------------------------
    Private Sub m_timerDisplay_Tick(sender As System.Object, e As System.EventArgs) Handles m_timerDisplay.Tick
        Dim dwState As Long
        Dim dCmdPos As Double = 0.0
        Dim dActPos As Double = 0.0
        Dim dCmdVel As Double = 0.0

        ' ++ 지정한 축의 지령(Command)위치를 반환합니다.
        AxmStatusGetCmdPos(m_lAxisNoMa, dCmdPos)
        If m_dOldCmdPosMa <> dCmdPos Then
            stcCmdPosMa.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPosMa = dCmdPos
        End If
        AxmStatusGetCmdPos(m_lAxisNoSl, dCmdPos)
        If m_dOldCmdPosSl <> dCmdPos Then
            stcCmdPosSL.Text = Format(dCmdPos, "0.000")
            m_dOldCmdPosSl = dCmdPos
        End If

        ' ++ 지정한 축의 실제(Feedback)위치를 반환합니다.
        AxmStatusGetActPos(m_lAxisNoMa, dActPos)
        If m_dOldActPosMa <> dActPos Then
            stcActPosMa.Text = Format(dActPos, "0.000")
            m_dOldActPosMa = dActPos
        End If
        AxmStatusGetActPos(m_lAxisNoSl, dActPos)
        If m_dOldActPosSl <> dActPos Then
            stcActPosSL.Text = Format(dActPos, "0.000")
            m_dOldActPosSl = dActPos
        End If

        ' ++ 지정한 축의 구동 속도를 반환합니다.
        AxmStatusReadVel(m_lAxisNoMa, dCmdVel)
        If m_dOldCmdVelMa <> dCmdVel Then
            stcCmdVelMa.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVelMa = dCmdVel
        End If
        AxmStatusReadVel(m_lAxisNoSl, dCmdVel)
        If m_dOldCmdVelSl <> dCmdVel Then
            stcCmdVelSL.Text = Format(dCmdVel, "0.000")
            m_dOldCmdVelSl = dCmdVel
        End If

        ' ++ 지정한 축에 겐트리 기능이 활성화되었는지 확인합니다.
        AxmGantryGetEnable(m_lAxisNoMa, Nothing, Nothing, Nothing, dwState)
        If dwState = ENABLE Then
            stcGantryState.Text = "∞"
        Else
            stcGantryState.Text = " "
        End If

    End Sub

    ' ++ =======================================================================
    '// >> m_timerHomeInfo_Tick(...) : 타이머 이벤트 핸들러 함수.
    '//  - 일정한 주기로 변경되는 호밍 작업 정보등을 Control에 반영합니다.
    '// --------------------------------------------------------------------------
    Private Sub m_timerHomeInfo_Tick(sender As System.Object, e As System.EventArgs) Handles m_timerHomeInfo.Tick
        Dim dwRetCode As Long = 0
        Dim dwState As Long = 0
        Dim dwStepMain As Long = 0
        Dim dwStepSub As Long = 0

        ' ++ 지정한 축의 원점신호의 상태를 확인합니다.
        dwRetCode = AxmHomeReadSignal(m_lAxisNoMa, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeStateMa.Checked = dwState
        End If
        dwRetCode = AxmHomeReadSignal(m_lAxisNoSl, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeStateSL.Checked = dwState
        End If

        ' ++ 지정한 축의 원점검색 결과를 확인합니다.
        AxmHomeGetResult(m_lAxisNoMa, dwState)
        If m_dwOldResult <> dwState Then
            stcHomeResult.Text = TranslateHomeResult(dwState)
            m_dwOldResult = dwState
        End If

        ' ++ 지정한 축의 원점검색 진행율을 확인합니다.
        dwRetCode = AxmHomeGetRate(m_lAxisNoMa, dwStepMain, dwStepSub)
        If dwRetCode = AXT_RT_SUCCESS Then
            If Val(stcHomeStepMain.Text) <> dwStepMain Then
                stcHomeStepMain.Text = dwStepMain
            End If
            If Val(stcHomeStepSub.Text) <> dwStepSub Then
                stcHomeStepSub.Text = dwStepSub
            End If
            prgHomeRate.Value = dwStepSub
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
        m_lAxisNoMa = 0
        m_lAxisNoSl = -1
        ' ++ 지정한 축의 정보를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxisNoMa, dwBoardNo, dwModulePos, m_dwModuleId)

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

        Dim dwAbsRelMode As Long = POS_ABS_MODE
        Dim dwOnOff As Long = 0
        Dim dwSlaveHmUse As Long = 0
        Dim dwGantryOn = DISABLE
        Dim dSlaveHmOffset As Double = 0
        Dim dSlaveHmRange As Double = 1.0

        ' ++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
        AxmMotGetAbsRelMode(m_lAxisNo, dwAbsRelMode)
        If dwAbsRelMode = POS_ABS_MODE Then
            rdoAbs.Checked = True
        Else
            rdoRel.Checked = True
        End If

        ' ++ 지정한 축이 제어가 가능한 상태인지 확인합니다.
        If AxmInfoGetAxisStatus(m_lAxisNoSl) = AXT_RT_SUCCESS Then
            stcCmdPosSL.Enabled = True
            stcActPosSL.Enabled = True
            stcCmdVelSL.Enabled = True
        Else
            stcCmdPosSL.Enabled = False
            stcActPosSL.Enabled = False
            stcCmdVelSL.Enabled = False
        End If

        stcAxisNoMa.Text = Format(m_lAxisNoMa, "Ma Axis 00")
        stcAxisNoSl.Text = Format(m_lAxisNoSl, "Sl Axis 00")

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        AxmSignalIsServoOn(m_lAxisNoMa, dwOnOff)
        chkServoOn.Checked = dwOnOff

        ' ++ 지정한 축의 겐트리제어 관련 설정값을 확인합니다.
        AxmGantryGetEnable(m_lAxisNoMa, dwSlaveHmUse, dSlaveHmOffset, dSlaveHmRange, dwGantryOn)
        ConvertAxmToCombo(cboGantryHmSlaveUse, dwSlaveHmUse)
        edtGantryHmOffset.Text = Format(dSlaveHmOffset, "0.000")
        edtGantryHmRange.Text = Format(dSlaveHmRange, "0.000")
        chkGantryEnable.Checked = dwGantryOn

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

    Private Function TranslateHomeResult(ByVal dwHomeResult As Long)
        Dim strResult As String = ""

        Select Case dwHomeResult
            Case HOME_SUCCESS
                strResult = "[01H] HOME_SUCCESS"
            Case HOME_SEARCHING
                strResult = "[02H] HOME_SEARCHING"
            Case HOME_ERR_GNT_RANGE
                strResult = "[10H] HOME_ERR_GNT_RANGE"
            Case HOME_ERR_USER_BREAK
                strResult = "[11H] HOME_ERR_USER_BREAK"
            Case HOME_ERR_VELOCITY
                strResult = "[12H] HOME_ERR_VELOCITY"
            Case HOME_ERR_AMP_FAULT
                strResult = "[13H] HOME_ERR_AMP_FAULT"
            Case HOME_ERR_NEG_LIMIT
                strResult = "[14H] HOME_ERR_NEG_LIMIT"
            Case HOME_ERR_POS_LIMIT
                strResult = "[15H] HOME_ERR_POS_LIMIT"
            Case HOME_ERR_NOT_DETECT
                strResult = "[16H] HOME_ERR_NOT_DETECT"
            Case HOME_ERR_UNKNOWN
                strResult = "[FFH] HOME_ERR_UNKNOWN"
            Case Else

        End Select

        Return strResult
    End Function

End Class
