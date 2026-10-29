' SignalMonitor.vb : implementation file

' **************************************************************************
' >> [일자]: 2011.11.26
' >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는 
'    기능들을 파악할 수 있도록 작성된 예제입니다.
' >> [중요]: 신호설정 함수 사용시 주의사항 
'     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
'     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
'        변경해서 바꿀수 있습니다.
' **************************************************************************


Public Class SignalMonitor

    Const TM_DISPLAY As Integer = 100
    Const Z_PHASE_BIT As Integer = 1

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0

    Private Sub SignalMonitorDlg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    ' >> chkOutXX_CheckedChanged(...) : "Output Bit" 버튼들 클릭 시 호출되는 핸들러 함수. 
    '  - IDC_CHK_OUT_00 ~ IDC_CHK_OUT_04 버튼의 클릭이벤트 발생시 호출됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkOut00_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOut00.CheckedChanged
        chkOut_Changed(0, chkInp00, chkOut00)
    End Sub

    Private Sub chkOut01_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOut01.CheckedChanged
        chkOut_Changed(1, chkInp01, chkOut01)
    End Sub

    Private Sub chkOut02_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOut02.CheckedChanged
        chkOut_Changed(2, chkInp02, chkOut02)
    End Sub

    Private Sub chkOut03_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOut03.CheckedChanged
        chkOut_Changed(3, chkInp03, chkOut03)
    End Sub

    Private Sub chkOut04_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOut04.CheckedChanged
        chkOut_Changed(4, chkInp04, chkOut04)
    End Sub

    ' ++ =======================================================================
    ' >> cboZPhase_SelectedIndexChanged() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboZPhase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboZPhase.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboZPhase)
            ' ++ 선택한 축의 Z상 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetZphaseLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboAlarm_SelectedIndexChanged() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
    '  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도 
    '    계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboAlarm_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAlarm.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoAlarm을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboAlarm)
            ' ++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetServoAlarm(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoAlarm return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboInp_SelectedIndexChanged() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboInp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboInp.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        dwLevel = ConvertComboToAxm(cboInp)
        ' ++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
        ' - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
        '              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
        '              다음 구동을 할 수 없게 됩니다.
        dwRetCode = AxmSignalSetInpos(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmSignalSetInpos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboEmg_SelectedIndexChanged() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
    '  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도 
    '    계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboEmg_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEmg.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetStop(m_lAxisNo, dwStopMode, dwLevel)
        ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwLevel = ConvertComboToAxm(cboEmg)
            ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel)
        Else
            strData = "AxmSignalGetStop return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboELimitN_SelectedIndexChanged() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
    '  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
    '    Active되어도 계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboELimitN_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboELimitN.SelectedIndexChanged
        Dim strData As String
        Dim dwPLevel, dwNLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel)
        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwNLevel = ConvertComboToAxm(cboELimitN)
            ' ++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel)
        Else
            strData = "AxmSignalSetLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboELimitP_SelectedIndexChanged() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
    '  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
    '    Active되어도 계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboELimitP_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboELimitP.SelectedIndexChanged
        Dim strData As String
        Dim dwPLevel, dwNLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel)
        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwPLevel = ConvertComboToAxm(cboELimitP)
            ' ++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwPLevel, dwNLevel)
        Else
            strData = "AxmSignalSetLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    '// >> cboServoOn_SelectedIndexChanged() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '//  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
    '// ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
    '// --------------------------------------------------------------------------
    Private Sub cboServoOn_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServoOn.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoOnLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboServoOn)
            ' ++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoOnLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboAlarmReset_SelectedIndexChanged() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboAlarmReset_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAlarmReset.SelectedIndexChanged
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoAlarmResetLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboAlarmReset)
            ' ++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoAlarmResetLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkSWEnable_CheckedChanged() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축에 Software Limit기능을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkSWEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSWEnable.CheckedChanged
        Dim strData As String
        Dim dSWLimitP, dSWLimitN As Double
        Dim dwSWEnable, dwSWStopMode, dwSWRef, dwRetCode As Long

        dwSWEnable = chkSWEnable.Checked
        dwSWStopMode = ConvertComboToAxm(cboSWStop)
        dwSWRef = ConvertComboToAxm(cboSWRef)
        dSWLimitP = edtSWPosP.Text
        dSWLimitN = edtSWPosN.Text

        ' ++ 지정한 축에 Software Limit기능을 설정합니다.
        '  ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
        dwRetCode = AxmSignalSetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            chkSWEnable.Checked = False
            strData = "AxmSignalSetSoftLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim dwState1 As Long = 0
        Dim dwState2 As Long = 0
        Dim dwRetCode As Long = 0
        Dim lBitNo As Integer
        Dim chkGroupInp(UIO_OUT5 - 1) As CheckBox
        chkGroupInp = New CheckBox(UIO_OUT5 - 1) {chkInp00, chkInp01, chkInp02, chkInp03, chkInp04}
        Dim chkGroupOut(UIO_OUT5 - 1) As CheckBox
        chkGroupOut = New CheckBox(UIO_OUT5 - 1) {chkOut00, chkOut01, chkOut02, chkOut03, chkOut04}

        ' ++ Z상 신호의 상태를 확인합니다.
        dwRetCode = AxmStatusReadMechanical(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwState1 = IIf(((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) = 0), 0, 1)
            chkZPhase.Checked = dwState1
        End If

        ' ++ Servo Alarm 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadServoAlarm(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkAlarm.Checked = dwState1
        End If

        ' ++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadInpos(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkInp.Checked = dwState1
        End If

        ' ++ Emergency 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadStop(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkEmg.Checked = dwState1
        End If

        ' ++ (+/-)End Limit신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadLimit(m_lAxisNo, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkELimitP.Checked = dwState1
            chkELimitN.Checked = dwState2
        End If

        For lBitNo = 0 To (UIO_OUT5 - 1)
            ' ++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
            dwRetCode = AxmSignalReadInputBit(m_lAxisNo, lBitNo, dwState1)
            If dwRetCode = AXT_RT_SUCCESS Then
                chkGroupInp(lBitNo).Checked = dwState1
            End If

            ' ++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
            dwRetCode = AxmSignalReadOutputBit(m_lAxisNo, lBitNo, dwState2)
            If dwRetCode = AXT_RT_SUCCESS Then
                chkGroupOut(lBitNo).Checked = dwState2
            End If
        Next

        ' ++ (+/-)Software Limit의 Active 상태를 확인합니다.
        dwRetCode = AxmSignalReadSoftLimit(m_lAxisNo, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkSWLimitP.Checked = dwState1
            chkSWLimitN.Checked = dwState2
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
    Private Sub UpdateState()

        Dim dwPulse As Long = 1
        Dim dUnit As Double = 1.0
        Dim dMinVel As Double = 1.0
        Dim dMaxVel As Double = 100.0
        Dim dSWLimitP As Double = 0.0
        Dim dSWLimitN As Double = 0.0
        Dim dwMethod As Long = 0
        Dim dwStopMode As Long = 0
        Dim dwUse As Long = 0
        Dim dwPositiveLevel As Long = 0
        Dim dwNegativeLevel As Long = 0
        Dim dwSWEnable As Long = 0
        Dim dwSWStopMode As Long = 0
        Dim dwSWRef As Long = 0
        Dim dwLevel As Long = 0
        Dim dwAbsRelMode As Long = 0
        Dim dwProfileMode As Long = 0
        Dim dwRetCode As Long = 0
        Dim dwEncoderType As Long = 0
        Dim dwHmDir As Long = 0
        Dim dwHomeSignal As Long = 0
        Dim dwZPhas As Long = 0
        Dim dHomeClrTime As Double = 1000.0
        Dim dHomeOffset As Long = 0.0
        Dim dInitPos As Double = 100.0
        Dim dInitVel As Double = 100.0
        Dim dInitAccel As Double = 400.0
        Dim dInitDecel As Double = 400.0
        Dim dVelFirst As Double = 100.0
        Dim dVelSecond As Double = 10.0
        Dim dVelThird As Double = 5.0
        Dim dVelLast As Double = 1.0
        Dim dAccFirst As Double = 400.0
        Dim dAccSecond As Double = 40.0

        ' 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
        Select Case m_dwModuleId
            Case AXT_SMC_4V04, AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM
                cboZPhase.Items.Clear()
                cboZPhase.Enabled = True
                cboZPhase.Items.Add("00:LOW")
                cboZPhase.Items.Add("01:HIGH")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("00:LOW")
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("00:LOW")
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = True
                cboEmg.Items.Add("00:LOW")
                cboEmg.Items.Add("01:HIGH")
                cboEmg.Items.Add("02:UNUSED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = True
                cboELimitN.Items.Add("00:LOW")
                cboELimitN.Items.Add("01:HIGH")
                cboELimitN.Items.Add("02:UNUSED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = True
                cboELimitP.Items.Add("00:LOW")
                cboELimitP.Items.Add("01:HIGH")
                cboELimitP.Items.Add("02:UNUSED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = True
                cboServoOn.Items.Add("00:LOW")
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = True
                cboAlarmReset.Items.Add("00:LOW")
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = True
                cboSWRef.Items.Add("00:COMMAND")
                cboSWRef.Items.Add("01:ACTUAL")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = True
                cboSWStop.Items.Add("00:E_STOP")
                cboSWStop.Items.Add("01:S_STOP")

                edtSWPosN.Enabled = True
                edtSWPosP.Enabled = True
                chkSWEnable.Enabled = True

            Case AXT_SMC_R1V04A4
                cboZPhase.Items.Clear()
                cboZPhase.Enabled = False
                cboZPhase.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = True
                cboEmg.Items.Add("00:LOW")
                cboEmg.Items.Add("02:UNUSED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = True
                cboELimitN.Items.Add("00:LOW")
                cboELimitN.Items.Add("02:UNUSED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = True
                cboELimitP.Items.Add("00:LOW")
                cboELimitP.Items.Add("02:UNUSED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = False
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = False
                cboSWRef.Items.Add("02:UNUSED")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = False
                cboSWStop.Items.Add("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIIPM
                cboZPhase.Items.Clear()
                cboZPhase.Enabled = False
                cboZPhase.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = False
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = False
                cboInp.Items.Add("02:UNUSED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = False
                cboEmg.Items.Add("02:UNUSED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = False
                cboELimitN.Items.Add("02:UNUSED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = False
                cboELimitP.Items.Add("02:UNUSED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = False
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = False
                cboSWRef.Items.Add("02:UNUSED")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = False
                cboSWStop.Items.Add("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboZPhase.Items.Clear()
                cboZPhase.Enabled = False
                cboZPhase.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = False
                cboEmg.Items.Add("02:UNUSED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = True
                cboELimitN.Items.Add("01:HIGH")
                cboELimitN.Items.Add("02:UNUSED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = True
                cboELimitP.Items.Add("01:HIGH")
                cboELimitP.Items.Add("02:UNUSED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = False
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = False
                cboSWRef.Items.Add("02:UNUSED")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = False
                cboSWStop.Items.Add("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W

                cboZPhase.Items.Clear()
                cboZPhase.Enabled = False
                cboZPhase.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("00:LOW")
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = False
                cboEmg.Items.Add("02:UNUSED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = True
                cboELimitN.Items.Add("00:LOW")
                cboELimitN.Items.Add("01:HIGH")
                cboELimitN.Items.Add("02:UNUSED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = True
                cboELimitP.Items.Add("00:LOW")
                cboELimitP.Items.Add("01:HIGH")
                cboELimitP.Items.Add("02:UNUSED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = True
                cboServoOn.Items.Add("00:LOW")
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = False
                cboSWRef.Items.Add("02:UNUSED")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = False
                cboSWStop.Items.Add("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_ECAT_MOTION
                cboZPhase.Items.Clear()
                cboZPhase.Enabled = False
                cboZPhase.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("00:LOW")
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")
                cboInp.Items.Add("03:USED")

                cboEmg.Items.Clear()
                cboEmg.Enabled = True
                cboEmg.Items.Add("00:LOW")
                cboEmg.Items.Add("01:HIGH")
                cboEmg.Items.Add("02:UNUSED")
                cboEmg.Items.Add("03:USED")

                cboELimitN.Items.Clear()
                cboELimitN.Enabled = True
                cboELimitN.Items.Add("00:LOW")
                cboELimitN.Items.Add("01:HIGH")
                cboELimitN.Items.Add("02:UNUSED")
                cboELimitN.Items.Add("03:USED")

                cboELimitP.Items.Clear()
                cboELimitP.Enabled = True
                cboELimitP.Items.Add("00:LOW")
                cboELimitP.Items.Add("01:HIGH")
                cboELimitP.Items.Add("02:UNUSED")
                cboELimitP.Items.Add("03:USED")

                cboServoOn.Items.Clear()
                cboServoOn.Enabled = False
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                cboSWRef.Items.Clear()
                cboSWRef.Enabled = False
                cboSWRef.Items.Add("02:UNUSED")

                cboSWStop.Items.Clear()
                cboSWStop.Enabled = False
                cboSWStop.Items.Add("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case Else

        End Select

        ' ++ 선택한 축의 Z상 신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboZPhase, dwLevel)

        ' ++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        ConvertAxmToCombo(cboAlarm, dwUse)

        ' ++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetInpos(m_lAxisNo, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        ConvertAxmToCombo(cboInp, dwUse)

        ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetStop(m_lAxisNo, Nothing, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboEmg, dwLevel)

        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxisNo, Nothing, dwPositiveLevel, dwNegativeLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwPositiveLevel = dwNegativeLevel = UNUSED
        End If
        ConvertAxmToCombo(cboELimitP, dwPositiveLevel)
        ConvertAxmToCombo(cboELimitN, dwNegativeLevel)

        ' ++ 선택한 축의 Servo On/Off 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboServoOn, dwLevel)

        ' ++ 선택한 축의 Alarm Reset 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboAlarmReset, dwLevel)

        ' ++ 선택한 축의 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwSWStopMode = EMERGENCY_STOP
            dwSWRef = UNUSED
        End If
        ConvertAxmToCombo(cboSWStop, dwSWStopMode)
        ConvertAxmToCombo(cboSWRef, dwSWRef)

        edtSWPosP.Text = Format(dSWLimitP, "0.000")
        edtSWPosN.Text = Format(dSWLimitN, "0.000")
    End Sub

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
    ' >> chkOut_Changed(...) : chkOutXX_CheckedChanged 핸들러 함수에서 호출하는 함수.
    '    각 Output bit의 출력접점을 변경합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkOut_Changed(ByVal lBitNo As Long, ByRef chkInpx As CheckBox, ByRef chkOutx As CheckBox)
        Dim strData As String
        Dim dwRetCode, dwOnOff As Long

        dwOnOff = IIf(chkInpx.Checked, 1, 0)
        ' ++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
        dwRetCode = AxmSignalWriteOutputBit(m_lAxisNo, lBitNo, dwOnOff)
        If dwRetCode <> AXT_RT_SUCCESS Then
            chkOutx.Checked = False
            strData = Format(lBitNo, "00") + "bit AxmSignalWriteOutputBit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

End Class
