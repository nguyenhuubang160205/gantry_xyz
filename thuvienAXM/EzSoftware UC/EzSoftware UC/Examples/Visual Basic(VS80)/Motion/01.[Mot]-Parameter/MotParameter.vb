' MotParameter.vb : implementation file

' **************************************************************************
' >> [일자]: 2015.11.25
' >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로  
'    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
' >> [중요]: 신호설정 함수 사용시 주의사항 
'     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
'     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
'        변경해서 바꿀수 있습니다.
' **************************************************************************

Public Class MotParameter

    Private m_lAxis As Integer
    Private m_lAxisCounts As Integer
    Private m_dwModuleID As Long

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitLibrary()
        AddAxisInfo()
        UpdateState()
    End Sub

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelectAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelectAxis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSelectAxis.SelectedIndexChanged
        m_lAxis = cboSelectAxis.SelectedIndex

        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxis, Nothing, Nothing, m_dwModuleID)

        UpdateState()
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
        CommonDialog1Save.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Save.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2
        CommonDialog1Save.FilterIndex = 2

        CommonDialog1Open.ShowDialog()
        CommonDialog1Save.FileName = CommonDialog1Open.FileName
        szFileName = CommonDialog1Open.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox("File load fail!")
            End If
        End If

        UpdateState()

    End Sub

    ' ++ =======================================================================
    ' >> btnSaveFile_Click() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
    '  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에 
    '    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
    ' --------------------------------------------------------------------------
    Private Sub btnSaveFile_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveFile.Click
        Dim szFileName As String

        CommonDialog1Open.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
        CommonDialog1Save.Filter = "Data File (*.mot)|*.mot|All Files (*.*)|*.*||"
        CommonDialog1Open.Title = "Save"
        CommonDialog1Save.Title = "Save"

        CommonDialog1Save.ShowDialog()
        CommonDialog1Open.FileName = CommonDialog1Save.FileName
        szFileName = CommonDialog1Save.FileName
        If szFileName <> "" Then
            If AxmMotSaveParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox("File save fail!")
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyPulse_Click() : "Pulse/Encoder Method && Move Parameter Setting"
    '    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyPulse_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyPulse.Click
        Dim dwPulse As Long = 1
        Dim dUnit As Double = 1.0
        Dim dMinVel As Double = 1.0
        Dim dMaxVel As Double = 100.0
        Dim dwMethod As Long = 0
        Dim dwAbsRelMode As Long = 0
        Dim dwProfileMode As Long = 0

        If cboPulse.Enabled = True Then
            dwMethod = ConvertComboToAxm(cboPulse)
            ' ++ 지정 축의 펄스 출력 방식을 설정합니다.
            ' uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
            '           (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
            '           (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
            '           (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
            '           (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High     
            '           (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low     
            '           (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
            '           (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
            '           (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
            '           (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
            AxmMotSetPulseOutMethod(m_lAxis, dwMethod)
        End If

        If cboEncoder.Enabled = True Then
            dwMethod = ConvertComboToAxm(cboEncoder)
            ' ++ 지정 축의 Encoder 입력 방식을 설정합니다.
            ' uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
            '           (1)ObverseSqr1Mode   - 정방향 1체배
            '           (2)ObverseSqr2Mode   - 정방향 2체배
            '           (3)ObverseSqr4Mode   - 정방향 4체배
            '           (4)ReverseUpDownMode - 역방향 Up/Down
            '           (5)ReverseSqr1Mode   - 역방향 1체배
            '           (6)ReverseSqr2Mode   - 역방향 2체배
            '           (7)ReverseSqr4Mode   - 역방향 4체배
            AxmMotSetEncInputMethod(m_lAxis, dwMethod)
        End If

        If cboAbsRel.Enabled = True Then
            dwAbsRelMode = ConvertComboToAxm(cboAbsRel)
            ' ++ 지정 축의 구동 좌표계를 설정합니다.
            ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            AxmMotSetAbsRelMode(m_lAxis, dwAbsRelMode)
        End If

        If cboProfile.Enabled = True Then
            dwProfileMode = ConvertComboToAxm(cboProfile)
            ' ++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
            ' uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
            '                (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
            '                (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
            '                (3)SYM_S_CURVE_MODE    - Symmetric S Curve
            '                (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
            AxmMotSetProfileMode(m_lAxis, dwProfileMode)
        End If

        dMinVel = edtMinVel.Text
        ' ++ 지정 축의 최소 구동속도를 설정합니다.
        AxmMotSetMinVel(m_lAxis, dMinVel)

        dMaxVel = edtMaxVel.Text
        ' ++ 지정 축의 최대 구동속도를 설정합니다.
        AxmMotSetMaxVel(m_lAxis, dMaxVel)

        dwPulse = edtMovePulse.Text
        dUnit = edtMoveUnit.Text
        ' ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
        AxmMotSetMoveUnitPerPulse(m_lAxis, dUnit, dwPulse)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplySignal_Click() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을 
    '    클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplySignal_Click(sender As System.Object, e As System.EventArgs) Handles btnApplySignal.Click
        Dim dwUse As Long = 0
        Dim dwLevel As Long = 0
        Dim dwRetCode As Long = 0
        Dim dwStopMode As Long = 0
        Dim dwPositiveLevel As Long = 0
        Dim dwNegativeLevel As Long = 0
        Dim dwEncoderType As Long = 0

        dwUse = ConvertComboToAxm(cboInp)
        ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
        ' - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
        '              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
        '              다음 구동을 할 수 없게 됩니다. 
        AxmSignalSetInpos(m_lAxis, dwUse)

        If cboAlarmReset.Enabled Then
            dwLevel = ConvertComboToAxm(cboAlarmReset)
            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            AxmSignalSetServoAlarmResetLevel(m_lAxis, dwLevel)
        End If

        ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxis, dwStopMode, Nothing, Nothing)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwNegativeLevel = ConvertComboToAxm(cboELimitN)
            dwPositiveLevel = ConvertComboToAxm(cboELimitP)
            ' ++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetLimit(m_lAxis, dwStopMode, dwPositiveLevel, dwNegativeLevel)
        End If

        If cboZPhaseLev.Enabled Then
            dwLevel = ConvertComboToAxm(cboZPhaseLev)
            ' ++ 지정 축의 Z상 Active Level을 설정합니다.
            AxmSignalSetZphaseLevel(m_lAxis, dwLevel)
        End If

        dwStopMode = ConvertComboToAxm(cboStopMode)
        dwLevel = ConvertComboToAxm(cboStopLevel)
        ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
        AxmSignalSetStop(m_lAxis, dwStopMode, dwLevel)

        dwLevel = ConvertComboToAxm(cboServoOn)
        ' ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
        dwRetCode = AxmSignalSetServoOnLevel(m_lAxis, dwLevel)

        If cboAlarm.Enabled Then
            dwUse = ConvertComboToAxm(cboAlarm)
            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            AxmSignalSetServoAlarm(m_lAxis, dwUse)
        End If

        dwEncoderType = ConvertComboToAxm(cboEncoderType)
        ' ++ 지정 축의 Encoder Input Type를 설정합니다.
        '  dwEncoderType : (0)TYPE_INCREMENTAL
        '                  (1)TYPE_ABSOLUTE
        AxmSignalSetEncoderType(m_lAxis, dwEncoderType)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplyHome_Click() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
    '    호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyHome_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyHome.Click
        Dim dwHomeDir As Long = 0
        Dim dwHomeSignal As Long = 0
        Dim dwHomeLevel As Long = 0
        Dim dwZPhas As Long = 0
        Dim dHomeClrTime As Double = 1000.0
        Dim dHomeOffset As Double = 0.0

        dwHomeLevel = ConvertComboToAxm(cboHomeLevel)
        ' ++ 지정 축의 원점신호 Active Level을 설정합니다.
        AxmHomeSetSignalLevel(m_lAxis, dwHomeLevel)

        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwHomeDir = ConvertComboToAxm(cboHomeDir)
        dwZPhas = ConvertComboToAxm(cboZPhaseUse)

        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text
        ' ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
        AxmHomeSetMethod(m_lAxis, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)

    End Sub

    ' ++ =======================================================================
    ' >> btnApplySoftLimit_Click() : "Software Limit Setting" 그룹의 "Apply" 버튼을 
    '    클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplySoftLimit_Click(sender As System.Object, e As System.EventArgs) Handles btnApplySoftLimit.Click
        Dim dwRetCode As Long = 0
        Dim dwUse As Long = 0
        Dim dwStopMode As Long = 0
        Dim dwSelection As Long = 0
        Dim dPositivePos As Double = 0.0
        Dim dNegativePos As Double = 0.0

        ' ++ 지정한 축에 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxis, dwUse, dwStopMode, dwSelection, Nothing, Nothing)
        If dwRetCode = AXT_RT_SUCCESS Then
            dNegativePos = edtSLimitPosN.Text
            dPositivePos = edtSLimitPosP.Text

            dwUse = ConvertComboToAxm(cboSLimitEnable)
            dwStopMode = ConvertComboToAxm(cboSLimitStopMode)
            dwSelection = ConvertComboToAxm(cboSLimitSelect)

            ' ++ 지정 축의 소프트웨어 리미트를 설정합니다.
            ' uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
            '              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
            ' uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
            '              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
            ' uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
            '              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
            AxmSignalSetSoftLimit(m_lAxis, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyUserPara_Click() : "User Move Parameter Setting " 그룹의 "Apply"  
    '    버튼을 클릭했을 때 호출되는 핸들러 함수.
    '  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
    ' ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
    '    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnApplyUserPara_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyUserPara.Click
        Dim dInitPos As Double = 0.0
        Dim dInitVel As Double = 0.0
        Dim dInitAccel As Double = 0.0
        Dim dInitDecel As Double = 0.0

        dInitPos = edtPosition.Text
        dInitVel = edtVelocity.Text
        dInitAccel = edtAccel.Text
        dInitDecel = edtDecel.Text
        ' ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
        AxmMotSetParaLoad(m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel)
    End Sub

    ' ++ =======================================================================
    ' >> btnApplyAllAxes_Click() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
    '  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
    ' ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
    '    되지않는 파라메타가 있을 수 있습니다. 
    ' --------------------------------------------------------------------------
    Private Sub btnApplyAllAxes_Click(sender As System.Object, e As System.EventArgs) Handles btnApplyAllAxes.Click
        Dim dwAxisNo As Long = 0
        Dim dwMovePulse As Long = 1
        Dim dwModeProfile As Long = 0
        Dim dwUseAlarm As Long = 0
        Dim dwMethodPulse As Long = 0
        Dim dwMethodEncoder As Long = 0
        Dim dwModeAbsRel As Long = 0
        Dim dVelocityMin As Double = 1.0
        Dim dVelocityMax As Double = 100.0
        Dim dMoveUnit As Double = 1.0

        Dim dwUseInp, dwLevelAlarmReset, dwRetCode As Long
        Dim dwLevelLimitN As Long = 0
        Dim dwLevelLimitP As Long = 0
        Dim dwLevelZPhase As Long = 0
        Dim dwModeStop As Long = 0
        Dim dwLevelStop As Long = 0
        Dim dwLevelServoOn As Long = 0
        Dim dwTypeEncoder As Long = 0

        Dim dwHomeDir As Long = 0
        Dim dwHomeSignal As Long = 0
        Dim dwLevelHome As Long = 0
        Dim dwZPhas As Long = 0
        Dim dHomeClrTime As Double = 0.0
        Dim dHomeOffset As Double = 0.0

        Dim dwUse As Long = 0
        Dim dwStopMode As Long = 0
        Dim dwSelection As Long = 0
        Dim dPositivePos As Double = 0.0
        Dim dNegativePos As Double = 0.0

        Dim dInitPos, dInitVel, dInitAccel, dInitDecel As Double

        ' Pulse/Encoder Method && Move Parameter Setting
        dwMethodPulse = ConvertComboToAxm(cboPulse)
        dwMethodEncoder = ConvertComboToAxm(cboEncoder)
        dwUseAlarm = ConvertComboToAxm(cboAlarm)
        dwModeAbsRel = ConvertComboToAxm(cboAbsRel)
        dwModeProfile = ConvertComboToAxm(cboProfile)
        dVelocityMin = edtMinVel.Text
        dVelocityMax = edtMaxVel.Text
        dwMovePulse = edtMovePulse.Text
        dMoveUnit = edtMoveUnit.Text

        ' Input/Output Signal Setting
        dwUseInp = ConvertComboToAxm(cboInp)
        dwLevelAlarmReset = ConvertComboToAxm(cboAlarmReset)
        dwLevelLimitN = ConvertComboToAxm(cboELimitN)
        dwLevelLimitP = ConvertComboToAxm(cboELimitP)
        dwLevelZPhase = ConvertComboToAxm(cboZPhaseLev)
        dwModeStop = ConvertComboToAxm(cboStopMode)
        dwLevelStop = ConvertComboToAxm(cboStopLevel)
        dwLevelServoOn = ConvertComboToAxm(cboServoOn)
        dwTypeEncoder = ConvertComboToAxm(cboEncoderType)

        ' Home Search Setting
        dwLevelHome = ConvertComboToAxm(cboHomeLevel)
        dwHomeSignal = ConvertComboToAxm(cboHomeSignal)
        dwHomeDir = ConvertComboToAxm(cboHomeDir)
        dwZPhas = ConvertComboToAxm(cboZPhaseUse)
        dHomeClrTime = edtHomeClrTime.Text
        dHomeOffset = edtHomeOffset.Text

        ' Software Limit Setting
        dNegativePos = edtSLimitPosN.Text
        dPositivePos = edtSLimitPosP.Text

        ' User Move Parameter Setting
        dInitPos = edtPosition.Text
        dInitVel = edtVelocity.Text
        dInitAccel = edtAccel.Text
        dInitDecel = edtDecel.Text

        For dwAxisNo = 0 To (m_lAxisCounts - 1)

            ' Pulse/Encoder Method && Move Parameter Setting
            If cboPulse.Enabled = True Then
                ' ++ 지정 축의 펄스 출력 방식을 설정합니다.
                'uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
                '          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
                '          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
                '          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
                '          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High     
                '          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low     
                '          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
                '          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
                '          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
                '          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
                AxmMotSetPulseOutMethod(dwAxisNo, dwMethodPulse)
            End If

            ' Pulse/Encoder Method && Move Parameter Setting
            If cboEncoder.Enabled = True Then
                ' ++ 지정 축의 Encoder 입력 방식을 설정합니다.
                ' uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
                '           (1)ObverseSqr1Mode   - 정방향 1체배
                '           (2)ObverseSqr2Mode   - 정방향 2체배
                '           (3)ObverseSqr4Mode   - 정방향 4체배
                '           (4)ReverseUpDownMode - 역방향 Up/Down
                '           (5)ReverseSqr1Mode   - 역방향 1체배
                '           (6)ReverseSqr2Mode   - 역방향 2체배
                '           (7)ReverseSqr4Mode   - 역방향 4체배
                AxmMotSetEncInputMethod(dwAxisNo, dwMethodEncoder)
            End If

            If cboAlarm.Enabled = True Then
                ' ++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다. 
                AxmSignalSetServoAlarm(dwAxisNo, dwUseAlarm)
            End If

            If cboAbsRel.Enabled = True Then
                ' ++ 지정 축의 구동 좌표계를 설정합니다. 
                ' dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
                '                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
                AxmMotSetAbsRelMode(dwAxisNo, dwMethodPulse)
            End If

            If cboProfile.Enabled = True Then
                ' dwProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
                '                 (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
                '                 (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
                '                 (3)SYM_S_CURVE_MODE    - Symmetric S Curve
                '                 (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
                AxmMotSetProfileMode(dwAxisNo, dwModeProfile)
            End If

            ' ++ 지정 축의 초기 구동속도를 설정합니다.
            AxmMotSetMinVel(dwAxisNo, dVelocityMin)

            ' ++ 지정 축의 최대 구동속도를 설정합니다.
            AxmMotSetMaxVel(dwAxisNo, dVelocityMax)

            ' ++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
            AxmMotSetMoveUnitPerPulse(dwAxisNo, dMoveUnit, dwMovePulse)

            ' Input/Output Signal Setting
            ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
            '  - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
            '  ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
            '               Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
            '  ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
            '               다음 구동을 할 수 없게 됩니다. 
            AxmSignalSetInpos(dwAxisNo, dwUseInp)

            ' ++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
            AxmSignalSetServoAlarmResetLevel(dwAxisNo, dwLevelAlarmReset)

            ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
            dwRetCode = AxmSignalGetLimit(dwAxisNo, dwStopMode, Nothing, Nothing)
            If dwRetCode = AXT_RT_SUCCESS Then
                ' ++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
                AxmSignalSetLimit(dwAxisNo, dwStopMode, dwLevelLimitP, dwLevelLimitN)
            End If

            ' ++ 지정 축의 Z상 Active Level을 설정합니다.
            AxmSignalSetZphaseLevel(dwAxisNo, dwLevelZPhase)

            ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
            AxmSignalSetStop(dwAxisNo, dwModeStop, dwLevelStop)

            ' ++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
            AxmSignalSetServoOnLevel(dwAxisNo, dwLevelServoOn)

            ' ++ 지정 축의 Encoder Input Type를 설정합니다.
            '  dwEncoderType : (0)TYPE_INCREMENTAL
            '                  (1)TYPE_ABSOLUTE
            AxmSignalSetEncoderType(dwAxisNo, dwTypeEncoder)

            ' Home Search Setting
            ' ++ 지정 축의 원점신호 Active Level을 설정합니다.
            AxmHomeSetSignalLevel(dwAxisNo, dwLevelHome)

            ' ++ 지정 축의 원점검색 관련 정보들을 설정합니다.
            AxmHomeSetMethod(dwAxisNo, dwHomeDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)

            ' Software Limit Setting
            ' ++ 지정한 축에 Software Limit기능을 확인합니다.
            dwRetCode = AxmSignalGetSoftLimit(dwAxisNo, dwUse, dwStopMode, dwSelection, Nothing, Nothing)
            If dwRetCode = AXT_RT_SUCCESS Then
                dwUse = ConvertComboToAxm(cboSLimitEnable)
                dwStopMode = ConvertComboToAxm(cboSLimitStopMode)
                dwSelection = ConvertComboToAxm(cboSLimitSelect)

                ' ++ 지정 축의 소프트웨어 리미트를 설정합니다.
                ' uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
                '              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
                ' uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
                '              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
                ' uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
                '              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
                AxmSignalSetSoftLimit(dwAxisNo, dwUse, dwStopMode, dwSelection, dPositivePos, dNegativePos)
            End If

            ' ++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
            AxmMotSetParaLoad(dwAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel)

        Next

    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Tick(sender As System.Object, e As System.EventArgs) Handles m_timer.Tick
        Dim dwState1, dwState2, dwRetCode As Long

        ' ++ Z상 신호의 상태를 확인합니다.
        dwRetCode = AxmStatusReadMechanical(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwState1 = IIf(((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) = 0), 0, 1)
            chkZPhase.Checked = dwState1
        End If

        ' ++ Servo Alarm 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadServoAlarm(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkAlarm.Checked = dwState1
        End If

        ' ++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadInpos(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkInp.Checked = dwState1
        End If

        ' ++ Emergency 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadStop(m_lAxis, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkEmg.Checked = dwState1
        End If

        ' ++ (+/-)End Limit신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadLimit(m_lAxis, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkELimitP.Checked = dwState1
            chkELimitN.Checked = dwState2
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
        Dim dwRetCode As Long

        If AxlIsOpened() = False Then
            dwRetCode = AxlOpenNoReset(7)
            If dwRetCode <> AXT_RT_SUCCESS Then
                MsgBox("AxlOpen Fail... ErrorCode:" + Format(dwRetCode, "0000"))
                Return False
            End If
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
        Dim strModulename As String

        ' ++ 유효한 전체 모션축수를 반환합니다.
        AxmInfoGetAxisCount(m_lAxisCounts)
        If m_lAxisCounts < 1 Then
            Return False
        End If

        szModuleName = Space(50)
        m_lAxis = 0
        ' ++ 지정한 축의 정보를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
        AxmInfoGetAxis(m_lAxis, dwBoardNo, dwModulePos, m_dwModuleID)

        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i As Integer = 0 To (m_lAxisCounts - 1)
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
                    strModulename = Replace(szModuleName, Chr(0), "")
                    strData = Format(i, "00") + "-[ECAT-" + strModulename + "]"
                Case Else
                    strData = Format(i, "00") + "-[Unknown]"
            End Select

            cboSelectAxis.Items.Add(strData)

        Next

        InitControl()
        Return True
    End Function

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl()
        cboSelectAxis.SelectedIndex = m_lAxis

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
        Select Case m_dwModuleID
            Case AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM
                cboPulse.Items.Clear()
                cboPulse.Enabled = True
                cboPulse.Items.Add("00:OneHighLowHigh")
                cboPulse.Items.Add("01:OneHighHighLow")
                cboPulse.Items.Add("02:OneLowLowHigh")
                cboPulse.Items.Add("03:OneLowHighLow")
                cboPulse.Items.Add("04:TwoCcwCwHigh")
                cboPulse.Items.Add("05:TwoCcwCwLow")
                cboPulse.Items.Add("06:TwoCwCcwHigh")
                cboPulse.Items.Add("07:TwoCwCcwLow")
                cboPulse.Items.Add("08:TwoPhase")
                cboPulse.Items.Add("09:TwoPhaseReverse")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = True
                cboEncoder.Items.Add("00:ObverseUpDownMode")
                cboEncoder.Items.Add("01:ObverseSqr1Mode")
                cboEncoder.Items.Add("02:ObverseSqr2Mode")
                cboEncoder.Items.Add("03:ObverseSqr4Mode")
                cboEncoder.Items.Add("04:ReverseUpDownMode")
                cboEncoder.Items.Add("05:ReverseSqr1Mode")
                cboEncoder.Items.Add("06:ReverseSqr2Mode")
                cboEncoder.Items.Add("07:ReverseSqr4Mode")

                cboAbsRel.Items.Clear()
                cboAbsRel.Enabled = True
                cboAbsRel.Items.Add("00:POS_ABS_MODE")
                cboAbsRel.Items.Add("01:POS_REL_MODE")

                cboProfile.Items.Clear()
                cboProfile.Enabled = True
                cboProfile.Items.Add("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("02:QUASI_S_CURVE_MODE")
                cboProfile.Items.Add("03:SYM_S_CURVE_MODE")
                cboProfile.Items.Add("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = True
                cboZPhaseLev.Items.Add("00:LOW")
                cboZPhaseLev.Items.Add("01:HIGH")

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

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = True
                cboStopMode.Items.Add("00:EMERGENCY")
                cboStopMode.Items.Add("01:SLOWDOWN")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = True
                cboStopLevel.Items.Add("00:LOW")
                cboStopLevel.Items.Add("01:HIGH")
                cboStopLevel.Items.Add("02:UNUSED")

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

                edtSLimitPosN.Enabled = True
                edtSLimitPosP.Enabled = True

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = False
                cboEncoderType.Items.Add("00:INCREMENTAL")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")
                cboHomeSignal.Items.Add("05:EncodZPhase")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:LOW")
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeDir.Enabled = True
                cboHomeDir.Items.Add("00:(-)DIR_CCW")
                cboHomeDir.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:UNUSED")
                cboZPhaseUse.Items.Add("01:(+)DIR_CW")
                cboZPhaseUse.Items.Add("02:(-)DIR_CCW")

            Case AXT_SMC_R1V04A4
                cboPulse.Items.Clear()
                cboPulse.Enabled = False
                cboPulse.Items.Add("00:OneHighLowHigh")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = False
                cboEncoder.Items.Add("00:ObverseUpDownMode")

                cboAbsRel.Items.Clear()
                cboAbsRel.Enabled = True
                cboAbsRel.Items.Add("00:POS_ABS_MODE")
                cboAbsRel.Items.Add("01:POS_REL_MODE")

                cboProfile.Items.Clear()
                cboProfile.Enabled = True
                cboProfile.Items.Add("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("02:QUASI_S_CURVE_MODE")
                cboProfile.Items.Add("03:SYM_S_CURVE_MODE")
                cboProfile.Items.Add("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = True
                cboStopMode.Items.Add("00:EMERGENCY")
                cboStopMode.Items.Add("01:SLOWDOWN")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = True
                cboStopLevel.Items.Add("00:LOW")
                cboStopLevel.Items.Add("02:UNUSED")

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

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = False
                cboEncoderType.Items.Add("00:INCREMENTAL")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:LOW")
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:(-)DIR_CCW")
                cboHomeLevel.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.Items.Add("00:UNUSED")

            Case AXT_SMC_R1V04MLIIPM
                cboPulse.Items.Clear()
                cboPulse.Enabled = True
                cboPulse.Items.Add("00:OneHighLowHigh")
                cboPulse.Items.Add("06:TwoCwCcwHigh")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = False
                cboEncoder.Items.Add("00:ObverseUpDownMode")

                cboAbsRel.Items.Clear()
                cboAbsRel.Enabled = True
                cboAbsRel.Items.Add("00:POS_ABS_MODE")
                cboAbsRel.Items.Add("01:POS_REL_MODE")

                cboProfile.Items.Clear()
                cboProfile.Enabled = True
                cboProfile.Items.Add("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("02:QUASI_S_CURVE_MODE")
                cboProfile.Items.Add("03:SYM_S_CURVE_MODE")
                cboProfile.Items.Add("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = False
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = False
                cboInp.Items.Add("02:UNUSED")

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = False
                cboStopMode.Items.Add("00:EMERGENCY")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = False
                cboStopLevel.Items.Add("02:UNUSED")

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

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = False
                cboEncoderType.Items.Add("00:INCREMENTAL")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = False
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = False
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:(-)DIR_CCW")
                cboHomeLevel.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = False
                cboZPhaseUse.Items.Add("00:UNUSED")

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboPulse.Items.Clear()
                cboPulse.Enabled = False
                cboPulse.Items.Add("00:OneHighLowHigh")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = False
                cboEncoder.Items.Add("00:ObverseUpDownMode")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.Items.Add("02:UNUSED")

                cboAlarm.Items.Clear()
                cboAlarm.Enabled = True
                cboAlarm.Items.Add("01:HIGH")
                cboAlarm.Items.Add("02:UNUSED")

                cboInp.Items.Clear()
                cboInp.Enabled = True
                cboInp.Items.Add("01:HIGH")
                cboInp.Items.Add("02:UNUSED")

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = False
                cboStopMode.Items.Add("00:EMERGENCY")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = False
                cboStopLevel.Items.Add("02:UNUSED")

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

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = True
                cboEncoderType.Items.Add("00:INCREMENTAL")
                cboEncoderType.Items.Add("01:ABSOLUTE")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = False
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:(-)DIR_CCW")
                cboHomeLevel.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:UNUSED")
                cboZPhaseUse.Items.Add("01:(+)DIR_CW")
                cboZPhaseUse.Items.Add("02:(-)DIR_CCW")

            Case AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W
                cboPulse.Items.Clear()
                cboPulse.Enabled = False
                cboPulse.Items.Add("00:OneHighLowHigh")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = False
                cboEncoder.Items.Add("00:ObverseUpDownMode")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.Items.Add("02:UNUSED")

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

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = False
                cboStopMode.Items.Add("00:EMERGENCY")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = False
                cboStopLevel.Items.Add("02:UNUSED")

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
                cboServoOn.Enabled = False
                cboServoOn.Items.Add("01:HIGH")

                cboAlarmReset.Items.Clear()
                cboAlarmReset.Enabled = False
                cboAlarmReset.Items.Add("01:HIGH")

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = True
                cboEncoderType.Items.Add("00:INCREMENTAL")
                cboEncoderType.Items.Add("01:ABSOLUTE")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:LOW")
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:(-)DIR_CCW")
                cboHomeLevel.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:UNUSED")
                cboZPhaseUse.Items.Add("01:(+)DIR_CW")
                cboZPhaseUse.Items.Add("02:(-)DIR_CCW")

            Case AXT_ECAT_MOTION
                cboPulse.Items.Clear()
                cboPulse.Enabled = False
                cboPulse.Items.Add("00:OneHighLowHigh")

                cboEncoder.Items.Clear()
                cboEncoder.Enabled = False
                cboEncoder.Items.Add("00:ObverseUpDownMode")

                cboAbsRel.Items.Clear()
                cboAbsRel.Enabled = True
                cboAbsRel.Items.Add("00:POS_ABS_MODE")
                cboAbsRel.Items.Add("01:POS_REL_MODE")

                cboProfile.Items.Clear()
                cboProfile.Enabled = True
                cboProfile.Items.Add("00:SYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("01:ASYM_TRAPEZOIDE_MODE")
                cboProfile.Items.Add("02:QUASI_S_CURVE_MODE")
                cboProfile.Items.Add("03:SYM_S_CURVE_MODE")
                cboProfile.Items.Add("04:ASYM_S_CURVE_MODE")

                cboZPhaseLev.Items.Clear()
                cboZPhaseLev.Enabled = False
                cboZPhaseLev.Items.Add("02:UNUSED")

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

                cboStopMode.Items.Clear()
                cboStopMode.Enabled = True
                cboStopMode.Items.Add("00:EMERGENCY")
                cboStopMode.Items.Add("01:SLOWDOWN")

                cboStopLevel.Items.Clear()
                cboStopLevel.Enabled = True
                cboStopLevel.Items.Add("00:LOW")
                cboStopLevel.Items.Add("01:HIGH")
                cboStopLevel.Items.Add("02:UNUSED")
                cboStopLevel.Items.Add("03:USED")

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

                edtSLimitPosN.Enabled = False
                edtSLimitPosP.Enabled = False

                cboEncoderType.Items.Clear()
                cboEncoderType.Enabled = False
                cboEncoderType.Items.Add("00:INCREMENTAL")

                cboHomeSignal.Items.Clear()
                cboHomeSignal.Enabled = True
                cboHomeSignal.Items.Add("00:PosEndLimit")
                cboHomeSignal.Items.Add("01:NegEndLimit")
                cboHomeSignal.Items.Add("04:HomeSensor")
                cboHomeSignal.Items.Add("05:EncodZPhase")

                cboHomeLevel.Items.Clear()
                cboHomeLevel.Enabled = True
                cboHomeLevel.Items.Add("00:LOW")
                cboHomeLevel.Items.Add("01:HIGH")

                cboHomeDir.Items.Clear()
                cboHomeDir.Enabled = True
                cboHomeDir.Items.Add("00:(-)DIR_CCW")
                cboHomeDir.Items.Add("01:(+)DIR_CW")

                cboZPhaseUse.Items.Clear()
                cboZPhaseUse.Enabled = True
                cboZPhaseUse.Items.Add("00:UNUSED")
                cboZPhaseUse.Items.Add("01:(+)DIR_CW")
                cboZPhaseUse.Items.Add("02:(-)DIR_CCW")

            Case Else

        End Select

        ' ++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
        dwRetCode = AxmMotGetPulseOutMethod(m_lAxis, dwMethod)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwMethod = OneHighLowHigh
        End If
        ConvertAxmToCombo(cboPulse, dwMethod)

        ' ++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
        dwRetCode = AxmMotGetEncInputMethod(m_lAxis, dwMethod)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwMethod = ObverseUpDownMode
        End If
        ConvertAxmToCombo(cboEncoder, dwMethod)

        ' ++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetServoAlarm(m_lAxis, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        ConvertAxmToCombo(cboAlarm, dwUse)

        ' ++ 지정 축의 최저속도를 확인합니다.
        dwRetCode = AxmMotGetMinVel(m_lAxis, dMinVel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dMinVel = 1.0
        End If
        edtMinVel.Text = Format(dMinVel, "0.000")

        ' ++ 지정 축의 최고속도를 확인합니다.
        dwRetCode = AxmMotGetMaxVel(m_lAxis, dMaxVel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dMaxVel = 1.0
        End If
        edtMaxVel.Text = Format(dMaxVel, "0.000")

        ' ++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
        dwRetCode = AxmMotGetMoveUnitPerPulse(m_lAxis, dUnit, dwPulse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dUnit = 1.0
            dwPulse = 1
        End If
        edtMoveUnit.Text = Format(dUnit, "0.000")
        edtMovePulse.Text = Format(dwPulse, "0")

        ' ++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmSignalGetZphaseLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboZPhaseLev, dwLevel)

        ' ++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetInpos(m_lAxis, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        ConvertAxmToCombo(cboInp, dwUse)

        ' ++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetStop(m_lAxis, dwStopMode, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwStopMode = UNUSED
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboStopMode, dwStopMode)
        ConvertAxmToCombo(cboStopLevel, dwLevel)

        ' ++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxis, Nothing, dwPositiveLevel, dwNegativeLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwPositiveLevel = dwNegativeLevel = UNUSED
        End If
        ConvertAxmToCombo(cboELimitP, dwPositiveLevel)
        ConvertAxmToCombo(cboELimitN, dwNegativeLevel)

        ' ++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoOnLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboServoOn, dwLevel)

        ' ++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboAlarmReset, dwLevel)

        ' ++ 지정 축의 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxis, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwSWEnable = DISABLE
            dwSWStopMode = EMERGENCY_STOP
            dwSWRef = UNUSED
        End If
        cboSLimitEnable.Items.Clear()
        cboSLimitEnable.Enabled = True
        cboSLimitEnable.Items.Add("00:DISABLE")
        cboSLimitEnable.Items.Add("01:ENABLE")
        cboSLimitStopMode.Items.Clear()
        cboSLimitStopMode.Enabled = True
        cboSLimitStopMode.Items.Add("00:EMERGENCY_STOP")
        cboSLimitStopMode.Items.Add("01:SLOWDOWN_STOP")
        cboSLimitSelect.Items.Clear()
        cboSLimitSelect.Enabled = True
        cboSLimitSelect.Items.Add("00:COMMAND")
        cboSLimitSelect.Items.Add("01:ACTUAL")
        ConvertAxmToCombo(cboSLimitEnable, dwSWEnable)
        ConvertAxmToCombo(cboSLimitStopMode, dwSWStopMode)
        ConvertAxmToCombo(cboSLimitSelect, dwSWRef)

        edtSLimitPosP.Text = Format(dSWLimitP, "0.000")
        edtSLimitPosN.Text = Format(dSWLimitN, "0.000")

        ' ++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
        dwRetCode = AxmMotGetAbsRelMode(m_lAxis, dwAbsRelMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwAbsRelMode = POS_ABS_MODE
        End If
        ConvertAxmToCombo(cboAbsRel, dwAbsRelMode)

        ' ++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
        dwRetCode = AxmMotGetProfileMode(m_lAxis, dwProfileMode)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwProfileMode = SYM_TRAPEZOIDE_MODE
        End If
        ConvertAxmToCombo(cboProfile, dwProfileMode)

        ' ++ 지정한 축에 설정된 Encoder Type을 확인합니다.
        dwRetCode = AxmSignalGetEncoderType(m_lAxis, dwEncoderType)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwEncoderType = 0
        End If
        ConvertAxmToCombo(cboEncoderType, dwEncoderType)

        ' ++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
        dwRetCode = AxmHomeGetSignalLevel(m_lAxis, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        ConvertAxmToCombo(cboHomeLevel, dwLevel)

        ' ++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
        dwRetCode = AxmHomeGetMethod(m_lAxis, dwHmDir, dwHomeSignal, dwZPhas, dHomeClrTime, dHomeOffset)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwHmDir = DIR_CCW
            dwHomeSignal = HomeSensor
            dwZPhas = UNUSED
            dHomeClrTime = 1000.0
            dHomeOffset = 0.0
        End If
        ConvertAxmToCombo(cboHomeDir, dwHmDir)
        ConvertAxmToCombo(cboHomeSignal, dwHomeSignal)
        ConvertAxmToCombo(cboZPhaseUse, dwZPhas)
        edtHomeClrTime.Text = Format(dHomeClrTime, "0.000")
        edtHomeOffset.Text = Format(dHomeOffset, "0.000")

        ' ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
        dwRetCode = AxmHomeGetVel(m_lAxis, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dVelFirst = 100.0
            dVelSecond = 100.0
            dVelThird = 20.0
            dVelLast = 1.0
            dAccFirst = 400.0
            dAccSecond = 400.0
        End If
        edtVelFirst.Text = Format(dVelFirst, "0.000")
        edtVelSecond.Text = Format(dVelSecond, "0.000")
        edtVelThird.Text = Format(dVelThird, "0.000")
        edtVelLast.Text = Format(dVelLast, "0.000")
        edtAccFirst.Text = Format(dAccFirst, "0.000")
        edtAccSecond.Text = Format(dAccSecond, "0.000")

        ' ++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
        dwRetCode = AxmMotGetParaLoad(m_lAxis, dInitPos, dInitVel, dInitAccel, dInitDecel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dInitPos = 1000.0
            dInitVel = 200.0
            dInitAccel = 400.0
            dInitDecel = 400.0
        End If
        edtPosition.Text = Format(dInitPos, "0.000")
        edtVelocity.Text = Format(dInitVel, "0.000")
        edtAccel.Text = Format(dInitAccel, "0.000")
        edtDecel.Text = Format(dInitDecel, "0.000")

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

End Class
