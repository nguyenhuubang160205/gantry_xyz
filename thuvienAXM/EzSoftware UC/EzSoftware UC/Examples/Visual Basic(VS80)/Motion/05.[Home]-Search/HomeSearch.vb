' HomeSearch.vb : implementation file
' **************************************************************************
' >> [일자]: 2015.11.27
' >> [개요]: 이 예제는 원점검색 함수들의 사용법을 익히고 원점검색 방법과 각 
'    단계별 사용하는 원점검색 속도 설정법을 이해하여 빠르고 정밀한 원점 검색 
'    방법에 대해 학습하는 예제입니다.
' >> [중요]: 원점검색 방법 및 원점검색 단계별 속도사용에 대해
'     1) 원점검색은 기본적으로 5번의 신호검출 과정을 거쳐 완료됩니다.
'     2) 원점센서 검출 여부를 판단하여 원점검색 진행 방향으로 신호를 검출할 지
'        원점검색 반대방향으로 신호검출을 진행할지를 판단합니다.
'     3) 1차 원점신호 감지시에는 가감속이 있는 구동을 하여 비교적 빠른 속도로
'        원점신호를 감지합니다.
'     4) 1차 원점신호 감지 후 반대방향으로 2단계 속도로 1차 때와 마찬가지로 
'        가감속이 있는 구동을 하여 기구물이 원점센서의 검색진행 반대편에 위치
'        하도록 합니다.
'     5) 3단계 속도를 이용하여 가감속이 없이 원점신호를 검출하게 됩니다. 
'     6) 이 후 Z상검출 사용여부에 따라 4단계/5단계 신호 검출을 하여 빠르고 
'        정밀하게 원점검출을 완료하게 됩니다.
' >> [중요]: 원점검색 속도설정에 대해
'     1) dVelFirst: 초기 원점신호가 감지되지 않았을 때 원점신호 검색 방향으로 
'        On 상태를 검출할 때의 속도
'     2) dVelSecond: 초기 원점신호가 감지되어 있어 원점신호 검색 반대 방향으로 
'        Off 상태를 검출할 때의 속도
'     3) dVelFirst, dVelSecond속도는 원점검색 반복 정밀도 보다는 원점검색 시간과
'        관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 빠르게 설정합니다.
'     4) dVelThird: 1차 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
'     5) dVelLasts: 최종 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
'     6) dVelLasts속도는 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이 
'        있으므로 10 PPS정도 설정하면 정밀하게 원점검색을 구현 할 수 있습니다.
' **************************************************************************

Public Class HomeSearch

    Const TM_DISPLAY As Integer = 100
    Const TM_HOME_INFO As Integer = 101

    Private m_lAxisNo As Long = -1
    Private m_lAxisCount As Long = 0
    Private m_dwModuleId As Long = 0
    Private m_dwOldResult As Long = HOME_ERR_UNKNOWN
    Private m_dOldCmdPos As Double = 0.0
    Private m_dOldActPos As Double = 0.0
    Private m_dOldCmdVel As Double = 0.0

    Private Sub HomeSearchDlg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    '// >> cboHomeLevel_SelectedIndexChanged() : "Home Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '//  - 선택된 축의 원점신호 Active Level을 설정합니다.
    '// ※ [CAUTION] 특정 네트웍 제품의 경우 원점신호레벨 변경을 지원하지않습니다.
    '// --------------------------------------------------------------------------
    Private Sub cboHomeLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboHomeLevel.SelectedIndexChanged
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmHomeSetSignalLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboHomeLevel)
            ' ++ 지정한 축의 원점신호 Active Level을 변경합니다.
            dwRetCode = AxmHomeSetSignalLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                Dim strData As String
                strData = "AxmHomeSetSignalLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox(strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSetMethod_Click() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 원점검색 방향, 신호, Z상 검출여부, Offset등을 설정합니다.
    '  - 원점검색시 Z상 신호의 검출을 사용함으로 설정하였을 경우 1차로 지정한 
    '    원점신호를 검출 완료한 후 Z상 신호를 추가적으로 검출하게 됩니다.
    ' ※ [CAUTION] Z상의 경우 모터와 Ballscrew를 연결해주는 커플링이 풀리거나 
    '    해체할 경우 Z상 위치가 변경되므로 원점검색 위치가 달라지게됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetMethod_Click(sender As System.Object, e As System.EventArgs) Handles btnSetMethod.Click
        Dim lHomeDir As Long = 0
        Dim dwRetCode As Long = 0
        Dim dwHomeSignal As Long = HomeSensor
        Dim dwZPhaseUse As Long = DISABLE
        Dim dHomeClrTime As Double = 0.0
        Dim dHomeOffset As Double = 0.0

        lHomeDir = ConvertComboToAxm(cboHomeDir)
        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwZPhaseUse = ConvertComboToAxm(cboZPhaseUse)
        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text

        ' ++ 지정한 축의 원점검색 방법을 변경합니다.
        dwRetCode = AxmHomeSetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetMethod return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnSetVelocity_Click() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축의 단계별 원점검색 속도를 설정합니다.
    '  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
    ' ※ [CAUTION] dVelFirst, dVelSecond는 초기 원점검색 속도로 원점검색 반복 정밀도
    '    보다는 원점검색 시간과 관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 
    '    비교적 빠르게 설정하고 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이 
    '    있는 dVelLasts속도 10 PPS정도에 설정하면 빠르고 정밀하게 원점검색을 구현
    '    할 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSetVelocity_Click(sender As System.Object, e As System.EventArgs) Handles btnSetVelocity.Click
        Dim dwRetCode As Long = 0
        Dim dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond As Double

        ' 각각의 Edit 콘트롤에서 설정값을 가져옴
        dVelFirst = edtVelFirst.Text
        dVelSecond = edtVelSecond.Text
        dVelThird = edtVelThird.Text
        dVelLast = edtVelLast.Text
        dAccFirst = edtAccFirst.Text
        dAccSecond = edtAccSecond.Text

        ' ++ 원점검색에 사용되는 단계별 속도를 설정합니다.
        dwRetCode = AxmHomeSetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetVel return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnHomeStart_Click() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택한 축으로 원점검색을 진행합니다.
    '  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
    ' ※ [CAUTION] 원점검색시 라이브러리 내부에서 해당축의 원점검색을 수행 할 쓰레드가
    '    자동 생성되어 원점검색을 순차적으로 수행한 후 자동 종료됩니다. 따라서 단일 
    '    CPU시스템의 경우 사용자 프로그램에서 CPU를 100% 점유할 경우 원점 검색 진행이
    '    원할하게 되지 않을 수 있습니다.
    ' --------------------------------------------------------------------------
    Private Sub btnHomeStart_Click(sender As System.Object, e As System.EventArgs) Handles btnHomeStart.Click
        Dim dwRetCode As Long

        ' ++ 지정한 축에 원점검색을 진행합니다.
        dwRetCode = AxmHomeSetStart(m_lAxisNo)
        If dwRetCode <> AXT_RT_SUCCESS Then
            Dim strData As String
            strData = "AxmHomeSetStart return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox(strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
    '  - 지정한 축의 구동을 종료합니다. 만약 원점검색 중이면 검색을 중단하고 원점검색
    '    결과를 HOME_ERR_USER_BREAK로 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnMoveStop_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveStop.Click
        ' ++ 지정한 축의 구동을 감속정지합니다.
        AxmMoveSStop(m_lAxisNo)
    End Sub

    ' ++ =======================================================================
    ' >> m_timerDisplay_Tick(...) : 일반 정보 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerDisplay_Tick(sender As System.Object, e As System.EventArgs) Handles m_timerDisplay.Tick
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

    ' ++ =======================================================================
    ' >> m_timerHomeInfo_Tick(...) : 호밍 정보 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 호밍 작업 정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timerHomeInfo_Tick(sender As System.Object, e As System.EventArgs) Handles m_timerHomeInfo.Tick
        Dim dwRetCode As Long = 0
        Dim dwState As Long = 0
        Dim dwStepMain As Long = 0
        Dim dwStepSub As Long = 0

        ' ++ 지정한 축의 원점신호의 상태를 확인합니다.
        dwRetCode = AxmHomeReadSignal(m_lAxisNo, dwState)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkHomeState.Checked = dwState
        End If

        ' ++ 지정한 축의 원점검색 결과를 확인합니다.
        AxmHomeGetResult(m_lAxisNo, dwState)
        If m_dwOldResult <> dwState Then
            stcHomeResult.Text = TranslateHomeResult(dwState)
            m_dwOldResult = dwState
        End If

        ' ++ 지정한 축의 원점검색 진행율을 확인합니다.
        dwRetCode = AxmHomeGetRate(m_lAxisNo, dwStepMain, dwStepSub)
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

        cboHomeDir.Items.Clear()
        cboHomeDir.Enabled = True
        cboHomeDir.Items.Add("00: -DIR_CCW")
        cboHomeDir.Items.Add("01: +DIR_CW")

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

        Dim lHomeDir As Long = 0
        Dim dwRetCode As Long = 0
        Dim dwLevel As Long = 0
        Dim dwHomeSignal As Long = 0
        Dim dwZPhaseUse As Long = 0
        Dim dHomeClrTime As Double = 0.0
        Dim dHomeOffset As Long = 0.0

        Dim dVelFirst As Double = 100.0
        Dim dVelSecond As Double = 10.0
        Dim dVelThird As Double = 5.0
        Dim dVelLast As Double = 1.0
        Dim dAccFirst As Double = 400.0
        Dim dAccSecond As Double = 40.0

        ' 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
        Select Case m_dwModuleId
            Case AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM, _
                AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W, AXT_ECAT_MOTION

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:LOW")
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")
                cboHomeSignal.Items.Add("05:EncodZPhase")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:DISABLE")
                cboZPhaseUse.Items.Add("01:DIR_CHOME")
                cboZPhaseUse.Items.Add("02:DIR_HOME")

            Case AXT_SMC_R1V04A4
                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("01:HIGH")
                cboHomeLevel.Items.Add("02:UNUSED")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:DISABLE")
                cboZPhaseUse.Items.Add("01:DIR_CHOME")
                cboZPhaseUse.Items.Add("02:DIR_HOME")

            Case AXT_SMC_R1V04MLIIPM
                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("01:HIGH")
                cboHomeLevel.Items.Add("02:UNUSED")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = False
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.Items.Add("00:DISABLE")

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, _
                AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("01:HIGH")
                cboHomeLevel.Items.Add("02:UNUSED")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:DISABLE")
                cboZPhaseUse.Items.Add("01:DIR_CHOME")
                cboZPhaseUse.Items.Add("02:DIR_HOME")

            Case Else

        End Select

        ' ++ 지정한 축의 서보온 상태를 반환합니다.
        AxmSignalIsServoOn(m_lAxisNo, dwLevel)
        chkServoOn.Checked = dwLevel

        ' ++ 선택한 축의 원점신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmHomeGetSignalLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboHomeLevel, dwLevel)

        ' ++ 선택한 축의 원점검출 속도 설정값을 확인합니다.
        dwRetCode = AxmHomeGetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        edtVelFirst.Text = Format(dVelFirst, "0.000")
        edtVelSecond.Text = Format(dVelSecond, "0.000")
        edtVelThird.Text = Format(dVelThird, "0.000")
        edtVelLast.Text = Format(dVelLast, "0.000")
        edtAccFirst.Text = Format(dAccFirst, "0.000")
        edtAccSecond.Text = Format(dAccSecond, "0.000")

        ' ++ 선택한 축의 원점검출 방법 설정값을 확인합니다.
        dwRetCode = AxmHomeGetMethod(m_lAxisNo, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset)
        ConvertAxmToCombo(cboHomeDir, lHomeDir)
        ConvertAxmToCombo(cboHomeSignal, dwHomeSignal)
        ConvertAxmToCombo(cboZPhaseUse, dwZPhaseUse)
        edtHomeClrTime.Text = Format(dHomeClrTime, "0.000")
        edtHomeOffset.Text = Format(dHomeOffset, "0.000")

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
