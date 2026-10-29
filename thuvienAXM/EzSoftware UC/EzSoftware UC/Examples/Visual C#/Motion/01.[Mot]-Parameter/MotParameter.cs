// MotParameterDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2011.10.13
// >> [개요]: 이 예제는 모터 구동에 관련된 파라메타들을 설정변경한 후 파일로  
//    저장 또는 불러오기를 할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항 
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
//        변경해서 바꿀수 있습니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MotParameter
{
    public partial class MotParameter : Form
    {
        public  int m_lAxisCounts = 0;                          // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                          // 제어할 축 번호 선언 및 초기화
        public uint m_uModuleID   = 0;                          // 제어할 축의 모듈 I/O 선언 및 초기화 
        public  int m_lBoardNo    = 0, m_lModulePos = 0;
        

        public MotParameter()
        {
            InitializeComponent();
        }

        // **************************************************************************
        // >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
        // **************************************************************************

        // ++ =======================================================================
        // >> Project Name_Load(...) : 프로젝트 Form 초기화 함수.
        //  - Form을 Load시 불러내는 함수, 초기화에 사용합니다.
        // --------------------------------------------------------------------------
        private void MotParameter_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tm_Display_Tick(object sender, EventArgs e)
        {
            uint duState1 = 0, duState2 = 0, duRetCode;

            //++ Z상 신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmStatusReadMechanical(m_lAxisNo, ref duState1);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                duState1 = ((duState1 & (uint)AXT_MOTION_QIMECHANICAL_SIGNAL.QIMECHANICAL_ZPHASE_LEVEL) == 0) ? (uint)0 : (uint)1;
                chkZPhase.Checked = Convert.ToBoolean(duState1);
            }
            //++ Servo Alarm 신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadServoAlarm(m_lAxisNo, ref duState1);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkAlarm.Checked = Convert.ToBoolean(duState1);
            }
            //++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadInpos(m_lAxisNo, ref duState1);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkInp.Checked = Convert.ToBoolean(duState1);
            }
            //++ Emergency 신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadStop(m_lAxisNo, ref duState1);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkStopSig.Checked = Convert.ToBoolean(duState1);
            }
            //++ (+/-)End Limit신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadLimit(m_lAxisNo, ref duState1, ref duState2);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkElimitP.Checked = Convert.ToBoolean(duState1);
                chkElimitN.Checked = Convert.ToBoolean(duState2);
            }
        }

        // ++ =======================================================================
        // >> cboSelAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
        //  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
        // -------------------------------------------------------------------------
        private void cboSelAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_lAxisNo = cboSelAxis.SelectedIndex;       // 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.
            
            //++ 지정한 축번호의 모듈ID를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);

            UpdateState();      // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> btnLoadFile_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
        //  - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
        //  - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의 
        //    설정값들로 일괄 변경됩니다.
        // --------------------------------------------------------------------------
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "AXM files (*.mot)|*.mot|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            char[] nFilename = new char[255];
            string temp = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                temp = openFileDialog1.FileName;
                //++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
                if (CAXM.AxmMotLoadParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) 
                    MessageBox.Show("File load failed");
            }else{
                UpdateState();      // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
            }
        }

        // ++ =======================================================================
        // >> btnSaveFile_Click() : "Save File"버튼 클릭시 호출되는 핸들러 함수.
        //  - AXL 라이브러리 함수를 이용해 변경된 설정값들을 지정한 위치에
        //    Mot(AXM에서 사용하는 설정파일 형식) 파일 형식으로 저장합니다.
        // --------------------------------------------------------------------------
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "AXM files (*.mot)|*.mot|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            char[] nFilename = new char[255];
            string temp = null;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                temp = saveFileDialog1.FileName;
                //++ 함수 실행 성공시 각각의 모션축 설정값으로 지정한 Mot파일을 생성 및 저장 됩니다.
                if (CAXM.AxmMotSaveParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) 
                    MessageBox.Show("File save failed");
            }
        }

        // ++ =======================================================================
        // >> btnApplyPulse_Click() : "Pulse/Encoder Method && Move Parameter Setting"
        //    그룹의 "Apply" 버튼을 클릭했을 때 호출되는 핸들러 함수.
        //  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
        // ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
        //    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
        // --------------------------------------------------------------------------
        private void btnApplyPulse_Click(object sender, EventArgs e)
        {
            int nPulse = 1;
            double dUnit = 1.0, dMinVel = 1.0, dMaxVel = 100.0;
            uint duMethod = 0, duAbsRelMode = 0, duProfileMode = 0;	

            if(cboPulse.Enabled == true){
                duMethod = ConvertComboToAxm(ref cboPulse);
                //++ 지정 축의 펄스 출력 방식을 설정합니다.
                //uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
                //          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
                //          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
                //          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
                //          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High     
                //          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low     
                //          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
                //          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
                //          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
                //          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
                CAXM.AxmMotSetPulseOutMethod(m_lAxisNo, duMethod);
            }

            if (cboEncoder.Enabled == true)
            {
                duMethod = ConvertComboToAxm(ref cboEncoder);
                //++ 지정 축의 Encoder 입력 방식을 설정합니다.
                // uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
                //           (1)ObverseSqr1Mode   - 정방향 1체배
                //           (2)ObverseSqr2Mode   - 정방향 2체배
                //           (3)ObverseSqr4Mode   - 정방향 4체배
                //           (4)ReverseUpDownMode - 역방향 Up/Down
                //           (5)ReverseSqr1Mode   - 역방향 1체배
                //           (6)ReverseSqr2Mode   - 역방향 2체배
                //           (7)ReverseSqr4Mode   - 역방향 4체배
                CAXM.AxmMotSetEncInputMethod(m_lAxisNo, duMethod);
            }

	        if(cboAbsRel.Enabled == true){
		        duAbsRelMode = ConvertComboToAxm(ref cboAbsRel);
		        //++ 지정 축의 구동 좌표계를 설정합니다. 
		        // duAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
		        //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
		        CAXM.AxmMotSetAbsRelMode(m_lAxisNo, duAbsRelMode);
	        }
	        if(cboProfile.Enabled == true){
		        duProfileMode = ConvertComboToAxm(ref cboProfile);
		        //++ 지정 축의 구동 속도 프로파일 모드를 설정합니다.
		        // uProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
		        //                (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
		        //                (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
		        //                (3)SYM_S_CURVE_MODE    - Symmetric S Curve
		        //                (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
		        CAXM.AxmMotSetProfileMode(m_lAxisNo, duProfileMode);
	        }

	        dMinVel = Convert.ToDouble(edtMinVel.Text);
	        //++ 지정 축의 초기 구동속도를 설정합니다.
	        CAXM.AxmMotSetMinVel(m_lAxisNo, dMinVel);

            dMaxVel = Convert.ToDouble(edtMaxVel.Text);
	        //++ 지정 축의 최대 구동속도를 설정합니다.
	        CAXM.AxmMotSetMaxVel(m_lAxisNo, dMaxVel);

            nPulse = Convert.ToInt16(edtMovePulse.Text);
            dUnit = Convert.ToDouble(edtMoveUnit.Text);
	        //++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
	        CAXM.AxmMotSetMoveUnitPerPulse(m_lAxisNo, dUnit, nPulse);
        }

        // ++ =======================================================================
        // >> btnApplySignal_Click() : "Input/Output Signal Setting" 그룹의 "Apply" 버튼을 
        //    클릭했을 때 호출되는 핸들러 함수.
        //  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
        // ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
        //    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
        // --------------------------------------------------------------------------
        private void btnApplySignal_Click(object sender, EventArgs e)
        {
            uint duUse = 0, duLevel = 0, duEncoderType = 0, duRetCode;
            uint duStopMode = 0, duPosigitaveLevel = 0, duNegativeLevel = 0;

            duUse = ConvertComboToAxm(ref cboInp);
            //++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
            // - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
            // ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
            //              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
            // ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
            //              다음 구동을 할 수 없게 됩니다. 
            CAXM.AxmSignalSetInpos(m_lAxisNo, duUse);

            if (cboAlarmReset.Enabled == true)
            {
                duLevel = ConvertComboToAxm(ref cboAlarmReset);
                //++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
                CAXM.AxmSignalSetServoAlarmResetLevel(m_lAxisNo, duLevel);
            }

            //++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetLimit(m_lAxisNo, ref duStopMode, ref duPosigitaveLevel, ref duNegativeLevel);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                duNegativeLevel = ConvertComboToAxm(ref cboELimitN);
                duPosigitaveLevel = ConvertComboToAxm(ref cboELimitP);
                //++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
                CAXM.AxmSignalSetLimit(m_lAxisNo, duStopMode, duPosigitaveLevel, duNegativeLevel);
            }

            if (cboZPhaseLev.Enabled == true)
            {
                duLevel = ConvertComboToAxm(ref cboZPhaseLev);
                //++ 지정 축의 Z상 Active Level을 설정합니다.
                CAXM.AxmSignalSetZphaseLevel(m_lAxisNo, duLevel);
            }

            duStopMode = ConvertComboToAxm(ref cboStopMode);
            duLevel = ConvertComboToAxm(ref cboStopLevel);
            //++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
            CAXM.AxmSignalSetStop(m_lAxisNo, duStopMode, duLevel);


            duLevel = ConvertComboToAxm(ref cboServoOn);
            //++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
            CAXM.AxmSignalSetServoOnLevel(m_lAxisNo, duLevel);

            if (cboAlarm.Enabled == true)
            {
                duUse = ConvertComboToAxm(ref cboAlarm);
                //++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
                CAXM.AxmSignalSetServoAlarm(m_lAxisNo, duUse);
            }

            duEncoderType = ConvertComboToAxm(ref cboEncoderType);
            //++ 지정 축의 Encoder Input Type를 설정합니다.
            // duEncoderType : (0)TYPE_INCREMENTAL
            //                 (1)TYPE_ABSOLUTE
            CAXDev.AxmSignalSetEncoderType(m_lAxisNo, duEncoderType);
        }

        // ++ =======================================================================
        // >> btnApplyHome_Click() : "Home Search Setting" 그룹의 "Apply" 버튼을 클릭했을 때
        //    호출되는 핸들러 함수.
        //  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
        // ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
        //    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
        // --------------------------------------------------------------------------
        private void btnApplyHome_Click(object sender, EventArgs e)
        {
            int lHomeDir = 0;
            uint duHomeSignal = 0, duHomeLevel = 0, duZphas = 0;
            double dHomeClrTime = 1000.0, dHomeOffset = 0.0;

            duHomeLevel = ConvertComboToAxm(ref cboHomeLevel);
            //++ 지정 축의 원점신호 Active Level을 설정합니다.
            CAXM.AxmHomeSetSignalLevel(m_lAxisNo, duHomeLevel);

            duHomeSignal= ConvertComboToAxm(ref cboHomeSignal);
            lHomeDir    = (int)ConvertComboToAxm(ref cboHomeDir);
            duZphas     = ConvertComboToAxm(ref cboZPhaseUse);
            lHomeDir    = (int)ConvertComboToAxm(ref cboHomeDir);

            dHomeClrTime = Convert.ToDouble(edtHomeClrTime.Text);
            dHomeOffset = Convert.ToDouble(edtHomeOffset.Text);
            //++ 지정 축의 원점검색 관련 정보들을 설정합니다.
            CAXM.AxmHomeSetMethod(m_lAxisNo, lHomeDir, duHomeSignal, duZphas, dHomeClrTime, dHomeOffset);
        }

        // ++ =======================================================================
        // >> btnApplySoftlimit_Click() : "Software Limit Setting " 그룹의 "Apply" 버튼을 
        //    클릭했을 때 호출되는 핸들러 함수.
        //  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
        // ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
        //    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
        // --------------------------------------------------------------------------
        private void btnApplySoftlimit_Click(object sender, EventArgs e)
        {
            uint duRetCode;
            uint duUse = 0, duStopMode = 0, duSelection = 0;
            double dPositivePos = 0.0, dNegativePos = 0.0;

            //++ 지정한 축에 Software Limit기능을 확인합니다.
            duRetCode = CAXM.AxmSignalGetSoftLimit(m_lAxisNo, ref duUse, ref duStopMode, ref duSelection, ref dPositivePos, ref dNegativePos);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                dNegativePos = Convert.ToDouble(edtSwPosN.Text);
                dPositivePos = Convert.ToDouble(edtSwPosP.Text);
                //++ 지정 축의 소프트웨어 리미트를 설정합니다.
                // uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
                //              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
                // uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
                //              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
                // uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
                //              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
                CAXM.AxmSignalSetSoftLimit(m_lAxisNo, duUse, duStopMode, duSelection, dPositivePos, dNegativePos);
            }
        }

        // ++ =======================================================================
        // >> btnApplyUserPara_Click() : "User Move Parameter Setting " 그룹의 "Apply"  
        //    버튼을 클릭했을 때 호출되는 핸들러 함수.
        //  - 해당 그룹의 모든 설정값들을 각각의 AXL 함수들을 이용하여 적용합니다.
        // ※ [CAUTION] 각 콘트롤(ComboBox, Edit) 변경시 AXL에 즉시 반영되지않습니다.
        //    반드시 해당 그룹의 "Apply"버튼을 클릭해야 설정변경값이 AXL에 반영됩니다.
        // --------------------------------------------------------------------------
        private void btnApplyUserPara_Click(object sender, EventArgs e)
        {
            double dInitPos, dInitVel, dInitAccel, dInitDecel;

            dInitPos = Convert.ToDouble(edtPosition.Text);
            dInitVel = Convert.ToDouble(edtVelocity.Text);
            dInitAccel = Convert.ToDouble(edtAccel.Text);
            dInitDecel = Convert.ToDouble(edtDecel.Text);
            //++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
            CAXM.AxmMotSetParaLoad(m_lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);	
        }

        // ++ =======================================================================
        // >> btnApplyAllAxes_Click() : "Apply All Axes" 버튼을 클릭시 호출되는 핸들러 함수.
        //  - 모든 설정값들을 각각의 AXL 함수들을 이용하여 모든 축에 적용합니다.
        // ※ [CAUTION] 모든 축에 설정값 동일하게 적용시 모션축의 종류에 따라 적용
        //    되지않는 파라메타가 있을 수 있습니다. 
        // --------------------------------------------------------------------------
        private void btnApplyAllAxes_Click(object sender, EventArgs e)
        {
            int lAxisNo = 0;
            int lMovePulse = 1;
            uint duModeProfile = 0, duUseAlarm;
            uint duMethodPulse = 0, duMethodEncoder = 0, duModeAbsRel = 0;
            double dVelocityMin = 1.0, dVelocityMax = 100.0, dMoveUnit = 1.0;

            uint duUseInp, duLevelAlmRst, duRetCode;
            uint duLevelLimitN = 0, duLevelLimitP = 0, duLevelZPhase = 0;
            uint duModeStop = 0, duLevelStop = 0, duLevelServoOn = 0;
            uint duTypeEncoder = 0;

            int  lHomeDir = 0;
            uint duHomeSignal = 0, duLevelHome = 0, duZphas = 0;
            double dHomeClrTime = 1000.0, dHomeOffset = 0.0;

            uint duUse = 0, duStopMode = 0, duSelection = 0;
            double dPositivePos = 0.0, dNegativePos = 0.0;

            double dInitPos, dInitVel, dInitAccel, dInitDecel;

            // Pulse/Encoder Method && Move Parameter Setting
            duMethodPulse   = ConvertComboToAxm(ref cboPulse);
            duMethodEncoder = ConvertComboToAxm(ref cboEncoder);
            duUseAlarm      = ConvertComboToAxm(ref cboAlarm);
            duModeAbsRel    = ConvertComboToAxm(ref cboAbsRel);
            duModeProfile   = ConvertComboToAxm(ref cboProfile);
            dVelocityMin    = Convert.ToDouble(edtMinVel.Text);
            dVelocityMax    = Convert.ToDouble(edtMaxVel.Text);
            lMovePulse      = Convert.ToInt32(edtMovePulse.Text);
            dMoveUnit       = Convert.ToDouble(edtMoveUnit.Text);

            // Input/Output Signal Setting
            duUseInp        = ConvertComboToAxm(ref cboInp);
            duLevelAlmRst   = ConvertComboToAxm(ref cboAlarmReset);
            duLevelLimitN   = ConvertComboToAxm(ref cboELimitN);
            duLevelLimitP   = ConvertComboToAxm(ref cboELimitP);
            duLevelZPhase   = ConvertComboToAxm(ref cboZPhaseLev);
            duModeStop      = ConvertComboToAxm(ref cboStopMode);
            duLevelStop     = ConvertComboToAxm(ref cboStopLevel);
            duLevelServoOn  = ConvertComboToAxm(ref cboServoOn);
            duTypeEncoder   = ConvertComboToAxm(ref cboEncoderType);

            // Home Search Setting
            duLevelHome     = ConvertComboToAxm(ref cboHomeLevel);
            duHomeSignal    = ConvertComboToAxm(ref cboHomeSignal);
            lHomeDir        = (int)ConvertComboToAxm(ref cboHomeDir);
            duZphas         = ConvertComboToAxm(ref cboZPhaseUse);
            dHomeClrTime    = Convert.ToDouble(edtHomeClrTime.Text);
            dHomeOffset     = Convert.ToDouble(edtHomeOffset.Text);

            // Software Limit Setting
            dNegativePos    = Convert.ToDouble(edtSwPosN.Text);
            dPositivePos    = Convert.ToDouble(edtSwPosP.Text);

            // User Move Parameter Setting
            dInitPos        = Convert.ToDouble(edtPosition.Text);
            dInitVel        = Convert.ToDouble(edtVelocity.Text);
            dInitAccel      = Convert.ToDouble(edtAccel.Text);
            dInitDecel      = Convert.ToDouble(edtDecel.Text);

            for (lAxisNo = 0; lAxisNo < m_lAxisCounts; lAxisNo++)
            {
                // Pulse/Encoder Method && Move Parameter Setting
                if (cboPulse.Enabled == true)
                {
                    //++ 지정 축의 펄스 출력 방식을 설정합니다.
                    //uMethod : (0)OneHighLowHigh   - 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
                    //          (1)OneHighHighLow   - 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
                    //          (2)OneLowLowHigh    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
                    //          (3)OneLowHighLow    - 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
                    //          (4)TwoCcwCwHigh     - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High     
                    //          (5)TwoCcwCwLow      - 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low     
                    //          (6)TwoCwCcwHigh     - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
                    //          (7)TwoCwCcwLow      - 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
                    //          (8)TwoPhase         - 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
                    //          (9)TwoPhaseReverse  - 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)
                    CAXM.AxmMotSetPulseOutMethod(lAxisNo, duMethodPulse);
                }

                if (cboEncoder.Enabled == true)
                {
                    //++ 지정 축의 Encoder 입력 방식을 설정합니다.
                    // uMethod : (0)ObverseUpDownMode - 정방향 Up/Down
                    //           (1)ObverseSqr1Mode   - 정방향 1체배
                    //           (2)ObverseSqr2Mode   - 정방향 2체배
                    //           (3)ObverseSqr4Mode   - 정방향 4체배
                    //           (4)ReverseUpDownMode - 역방향 Up/Down
                    //           (5)ReverseSqr1Mode   - 역방향 1체배
                    //           (6)ReverseSqr2Mode   - 역방향 2체배
                    //           (7)ReverseSqr4Mode   - 역방향 4체배
                    CAXM.AxmMotSetEncInputMethod(lAxisNo, duMethodEncoder);
                }

                if (cboAlarm.Enabled == true)
                {
                    //++ 지정 축의 비상정지 신호 사용유무/Active Level을 설정합니다. 
                    CAXM.AxmSignalSetServoAlarm(lAxisNo, duUseAlarm);
                }
                if (cboAbsRel.Enabled == true)
                {
                    //++ 지정 축의 구동 좌표계를 설정합니다. 
                    // duAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
                    //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
                    CAXM.AxmMotSetAbsRelMode(lAxisNo, duMethodPulse);
                }
                if (cboProfile.Enabled == true)
                {
                    // duProfileMode : (0)SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
                    //                 (1)ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
                    //                 (2)QUASI_S_CURVE_MODE  - Symmetric Quasi-S Curve
                    //                 (3)SYM_S_CURVE_MODE    - Symmetric S Curve
                    //                 (4)ASYM_S_CURVE_MODE   - Asymmetric S Curve
                    CAXM.AxmMotSetProfileMode(lAxisNo, duModeProfile);
                }

                //++ 지정 축의 초기 구동속도를 설정합니다.
                CAXM.AxmMotSetMinVel(lAxisNo, dVelocityMin);

                //++ 지정 축의 최대 구동속도를 설정합니다.
                CAXM.AxmMotSetMaxVel(lAxisNo, dVelocityMax);

                //++ 지정 축의 거리/속도/가속도의 제어단위를 설정합니다.
                CAXM.AxmMotSetMoveUnitPerPulse(lAxisNo, dMoveUnit, lMovePulse);

                // Input/Output Signal Setting
                //++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
                // - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
                // ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
                //              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
                // ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
                //              다음 구동을 할 수 없게 됩니다. 
                CAXM.AxmSignalSetInpos(lAxisNo, duUseInp);

                //++ 지정 축의 Alarm Reset 신호 Active Level을 설정합니다.
                CAXM.AxmSignalSetServoAlarmResetLevel(lAxisNo, duLevelAlmRst);

                //++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
                duRetCode = CAXM.AxmSignalGetLimit(lAxisNo, ref duStopMode, ref duLevelLimitP, ref duLevelLimitN);
                if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    //++ 지정 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
                    CAXM.AxmSignalSetLimit(lAxisNo, duStopMode, duLevelLimitP, duLevelLimitN);
                }

                //++ 지정 축의 Z상 Active Level을 설정합니다.
                CAXM.AxmSignalSetZphaseLevel(lAxisNo, duLevelZPhase);

                //++ 지정 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
                CAXM.AxmSignalSetStop(lAxisNo, duModeStop, duLevelStop);

                //++ 지정 축의 Servo On/Off 신호 Active Level을 설정합니다.
                CAXM.AxmSignalSetServoOnLevel(lAxisNo, duLevelServoOn);

                //++ 지정 축의 Encoder Input Type를 설정합니다.
                // duEncoderType : (0)TYPE_INCREMENTAL
                //                 (1)TYPE_ABSOLUTE
                CAXDev.AxmSignalSetEncoderType(lAxisNo, duTypeEncoder);
                
                // Home Search Setting
                //++ 지정 축의 원점신호 Active Level을 설정합니다.
                CAXM.AxmHomeSetSignalLevel(lAxisNo, duLevelHome);

                //++ 지정 축의 원점검색 관련 정보들을 설정합니다.
                CAXM.AxmHomeSetMethod(lAxisNo, lHomeDir, duHomeSignal, duZphas, dHomeClrTime, dHomeOffset);

                // Software Limit Setting
                //++ 지정한 축에 Software Limit기능을 확인합니다.
                duRetCode = CAXM.AxmSignalGetSoftLimit(lAxisNo, ref duUse, ref duStopMode, ref duSelection, ref dPositivePos, ref dNegativePos);
                if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    //++ 지정 축의 소프트웨어 리미트를 설정합니다.
                    // uUse       : (0)DISABLE        - 소프트웨어 리미트 기능을 사용하지 않습니다.
                    //              (1)ENABLE         - 소프트웨어 리미트 기능을 사용합니다.
                    // uStopMode  : (0)EMERGENCY_STOP - 소프트웨어 리미트 영역을 벗어날 경우 급정지합니다.
                    //              (1)SLOWDOWN_STOP  - 소프트웨어 리미트 영역을 벗어날 경우 감속정지합니다.
                    // uSelection : (0)COMMAND        - 기준위치를 지령위치로 합니다.
                    //              (1)ACTUAL         - 기준위치를 엔코더 위치로 합니다.
                    CAXM.AxmSignalSetSoftLimit(lAxisNo, duUse, duStopMode, duSelection, dPositivePos, dNegativePos);
                }

                //++ 지정 축의 사용자 관련 파라메타들을 설정합니다.
                CAXM.AxmMotSetParaLoad(lAxisNo, dInitPos, dInitVel, dInitAccel, dInitDecel);
            }	
        }
        
        // **************************************************************************
        // >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음 
        // **************************************************************************

        // ++ =======================================================================
        // >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
        //  - AXL(AjineXtek Library)을 사용가능하게 합니다. 
        //  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
        //    지정해 모션관련 기본설정을 자동으로 합니다.
        // --------------------------------------------------------------------------
        public void initLibrary()
        {
            // ※ [CAUTION] 아래와 다른 Mot파일(모션 설정파일)을 사용할 경우 경로를 변경하십시요.
            String szFilePath = "C:\\Program Files\\EzSoftware RM\\EzSoftware\\MotionDefault.mot";

            //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) 
                MessageBox.Show("Intialize Fail..!!");

            //++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
            if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) 
                MessageBox.Show("Mot File Not Found.");
        }

        // ++ =======================================================================
        // >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
        //  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
        //    제어할 수 있도록 합니다.
        //  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를 
        //    100msec 주기로 동작시킵니다.
        // --------------------------------------------------------------------------
        public void AddAxisInfo()
        {
            String strAxis = "";

            //++ 유효한 전체 모션축수를 반환합니다.
            CAXM.AxmInfoGetAxisCount(ref m_lAxisCounts);
            m_lAxisNo = 0;
            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                CAXM.AxmInfoGetAxis(i, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
                switch (m_uModuleID)
                {
                    case (uint)AXT_MODULE.AXT_SMC_4V04: strAxis = String.Format("{0:0}-(AXT_SMC_4V04)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_2V04: strAxis = String.Format("{0:0}-[AXT_SMC_2V04]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIPM]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2Q]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04PM2QE]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM: strAxis = String.Format("{0:0}-(AXT_SMC_R1V04MLIIIPM)", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A5: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04A4]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04A4: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIICL]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04SIIIHMIV_R]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIISV_MD]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7S]", i); break;
                    case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W: strAxis = String.Format("{0:0}-[AXT_SMC_R1V04MLIIIS7W]", i); break;
                    case (uint)AXT_MODULE.AXT_ECAT_MOTION:
                        uint uModuleSubID = 0;
                        var szModuleName = new System.Text.StringBuilder(50);
                        var szModuleDesc = new System.Text.StringBuilder(80);
                        CAXM.AxmInfoGetAxisEx(i, ref uModuleSubID, szModuleName, szModuleDesc);
                        strAxis = String.Format("{0:0}-[ECAT-{1}]", i, szModuleName);
                        break;
                    default: strAxis = String.Format("{0:00}-[Unknown]", i); break;
                }
                cboSelAxis.Items.Add(strAxis);
            }
            InitControl();      // Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
        }

        // ++ =======================================================================
        // >> InitControl() : Control들에 초기값을 설정하는 함수.
        //  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
        // --------------------------------------------------------------------------
        public void InitControl()
        {
            cboSelAxis.SelectedIndex = m_lAxisNo;
        }

        // ++ =======================================================================
        // >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
        //  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는 
        //    역할을하는 함수입니다.
        //  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
        //  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
        // --------------------------------------------------------------------------
        public void UpdateState()
        {
            int nPulse = 1;
            double dUnit = 1.0, dMinVel = 1.0, dMaxVel = 100.0;
            double dSWLimitP = 0.0, dSWLimitN = 0.0;
            uint duMethod = 0, duStopMode = 0, duUse = 0;
            uint duPositiveLevel = 0, duNegativeLevel = 0;
            uint duSWEnable = 0, duSWStopMode = 0, duSWRef = 0;
            uint duLevel = 0, duAbsRelMode = 0, duProfileMode = 0, duRetCode;
            uint duEncoderType = 0;
            int lHmDir = 0;
            uint duHomeSignal = 0, duZphas = 0;
            double dHomeClrTime = 1000.0, dHomeOffset = 0.0;

            double dInitPos = 100.0, dInitVel = 100.0, dInitAccel = 400.0, dInitDecel = 400.0;
            double dVelFirst = 100.0, dVelSecond = 10.0, dVelThird = 5.0, dVelLast = 1.0, dAccFirst = 400.0, dAccSecond = 40.0;

            // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
            switch (m_uModuleID){
                case (uint)AXT_MODULE.AXT_SMC_4V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04:
                case (uint)AXT_MODULE.AXT_SMC_2V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = true;
                    cboPulse.Items.Add("00:OneHighLowHigh");
                    cboPulse.Items.Add("01:OneHighHighLow");
                    cboPulse.Items.Add("02:OneLowLowHigh");
                    cboPulse.Items.Add("03:OneLowHighLow");
                    cboPulse.Items.Add("04:TwoCcwCwHigh");
                    cboPulse.Items.Add("05:TwoCcwCwLow");
                    cboPulse.Items.Add("06:TwoCwCcwHigh");
                    cboPulse.Items.Add("07:TwoCwCcwLow");
                    cboPulse.Items.Add("08:TwoPhase");
                    cboPulse.Items.Add("09:TwoPhaseReverse");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = true;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");
                    cboEncoder.Items.Add("01:ObverseSqr1Mode");
                    cboEncoder.Items.Add("02:ObverseSqr2Mode");
                    cboEncoder.Items.Add("03:ObverseSqr4Mode");
                    cboEncoder.Items.Add("04:ReverseUpDownMode");
                    cboEncoder.Items.Add("05:ReverseSqr1Mode");
                    cboEncoder.Items.Add("06:ReverseSqr2Mode");
                    cboEncoder.Items.Add("07:ReverseSqr4Mode");

                    cboAbsRel.Items.Clear();
                    cboAbsRel.Enabled = true;
                    cboAbsRel.Items.Add("00:POS_ABS_MODE");
                    cboAbsRel.Items.Add("01:POS_REL_MODE");

                    cboProfile.Items.Clear();
                    cboProfile.Enabled = true;
                    cboProfile.Items.Add("00:SYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("01:ASYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("02:QUASI_S_CURVE_MODE");
                    cboProfile.Items.Add("03:SYS_CURVE_MODE");
                    cboProfile.Items.Add("04:ASYS_CURVE_MODE");

                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = true;
                    cboZPhaseLev.Items.Add("00:LOW");
                    cboZPhaseLev.Items.Add("01:HIGH");
                                        
                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = true;
                    cboZPhaseUse.Items.Add("00:LOW");
                    cboZPhaseUse.Items.Add("01:HIGH");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = true;
                    cboAlarm.Items.Add("00:LOW");
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("00:LOW");
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = true;
                    cboStopMode.Items.Add("00:EMERGENCY");
                    cboStopMode.Items.Add("01:SLOWDOWN_");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = true;
                    cboStopLevel.Items.Add("00:LOW");
                    cboStopLevel.Items.Add("01:HIGH");
                    cboStopLevel.Items.Add("02:UNUSED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = true;
                    cboELimitN.Items.Add("00:LOW");
                    cboELimitN.Items.Add("01:HIGH");
                    cboELimitN.Items.Add("02:UNUSED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = true;
                    cboELimitP.Items.Add("00:LOW");
                    cboELimitP.Items.Add("01:HIGH");
                    cboELimitP.Items.Add("02:UNUSED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = true;
                    cboServoOn.Items.Add("00:LOW");
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = true;
                    cboAlarmReset.Items.Add("00:LOW");
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = true;
                    edtSwPosP.Enabled = true;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = false;
                    cboEncoderType.Items.Add("00:INCREMENTAL");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00:PosEndLimit");
                    cboHomeSignal.Items.Add("01:NegEndLimit");
                    cboHomeSignal.Items.Add("04:HomeSensor");
                    cboHomeSignal.Items.Add("05:EncodZPhase");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("00:LOW");
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = true;
                    cboZPhaseUse.Items.Add("00:UNUSED");
                    cboZPhaseUse.Items.Add("01:(+)DIR_CW");
                    cboZPhaseUse.Items.Add("02:(-)DIR_CCW");   
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04A4:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = false;
                    cboPulse.Items.Add("00:OneHighLowHigh");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = false;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");

                    cboAbsRel.Items.Clear();
                    cboAbsRel.Enabled = true;
                    cboAbsRel.Items.Add("00:POS_ABS_MODE");
                    cboAbsRel.Items.Add("01:POS_REL_MODE");

                    cboProfile.Items.Clear();
                    cboProfile.Enabled = true;
                    cboProfile.Items.Add("00:SYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("01:ASYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("02:QUASI_S_CURVE_MODE");
                    cboProfile.Items.Add("03:SYS_CURVE_MODE");
                    cboProfile.Items.Add("04:ASYS_CURVE_MODE");

                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = true;
                    cboZPhaseLev.Items.Add("00:LOW");
                    cboZPhaseLev.Items.Add("01:HIGH");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = false;
                    cboZPhaseUse.Items.Add("02:UNUSED");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = true;
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = true;
                    cboStopMode.Items.Add("00:EMERGENCY");
                    cboStopMode.Items.Add("01:SLOWDOWN_");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = true;
                    cboStopLevel.Items.Add("00:LOW");
                    cboStopLevel.Items.Add("02:UNUSED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = true;
                    cboELimitN.Items.Add("00:LOW");
                    cboELimitN.Items.Add("02:UNUSED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = true;
                    cboELimitP.Items.Add("00:LOW");
                    cboELimitP.Items.Add("02:UNUSED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = true;
                    cboServoOn.Items.Add("00:LOW");
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = false;
                    edtSwPosP.Enabled = false;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = false;
                    cboEncoderType.Items.Add("00:INCREMENTAL");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00:PosEndLimit");
                    cboHomeSignal.Items.Add("01:NegEndLimit");
                    cboHomeSignal.Items.Add("04:HomeSensor");
                    cboHomeSignal.Items.Add("05:EncodZPhase");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("00:LOW");
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = false;
                    cboZPhaseUse.Items.Add("00:UNUSED");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = true;
                    cboPulse.Items.Add("00:OneHighLowHigh");
                    cboPulse.Items.Add("06:TwoCwCcwHigh");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = false;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");

                    cboAbsRel.Items.Clear();
                    cboAbsRel.Enabled = true;
                    cboAbsRel.Items.Add("00:POS_ABS_MODE");
                    cboAbsRel.Items.Add("01:POS_REL_MODE");

                    cboProfile.Items.Clear();
                    cboProfile.Enabled = true;
                    cboProfile.Items.Add("00:SYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("01:ASYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("02:QUASI_S_CURVE_MODE");
                    cboProfile.Items.Add("03:SYS_CURVE_MODE");
                    cboProfile.Items.Add("04:ASYS_CURVE_MODE");

                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = false;
                    cboZPhaseLev.Items.Add("02: UNUSED");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = false;
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = false;
                    cboInp.Items.Add("02:UNUSED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = false;
                    cboStopMode.Items.Add("00:EMERGENCY");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = false;
                    cboStopLevel.Items.Add("02:UNUSED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = false;
                    cboELimitN.Items.Add("02:UNUSED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = false;
                    cboELimitP.Items.Add("02:UNUSED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = false;
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = false;
                    edtSwPosP.Enabled = false;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = false;
                    cboEncoderType.Items.Add("00:INCREMENTAL");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = false;
                    cboHomeSignal.Items.Add("04:HomeSensor");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = false;
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = false;
                    cboZPhaseUse.Items.Add("02:UNUSED");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04A5:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIORI:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = false;
                    cboPulse.Items.Add("00:OneHighLowHigh");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = false;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");
                    
                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = false;
                    cboZPhaseLev.Items.Add("02:UNUSED");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = true;
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = false;
                    cboStopMode.Items.Add("00:EMERGENCY");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = true;
                    cboStopLevel.Items.Add("01:HIGH");
                    cboStopLevel.Items.Add("02:UNUSED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = true;
                    cboELimitN.Items.Add("01:HIGH");
                    cboELimitN.Items.Add("02:UNUSED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = true;
                    cboELimitP.Items.Add("01:HIGH");
                    cboELimitP.Items.Add("02:UNUSED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = false;
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = false;
                    edtSwPosP.Enabled = false;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = true;
                    cboEncoderType.Items.Add("00:INCREMENTAL");
                    cboEncoderType.Items.Add("01:ABSOLUTE");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00:PosEndLimit");
                    cboHomeSignal.Items.Add("01:NegEndLimit");
                    cboHomeSignal.Items.Add("04:HomeSensor");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = false;
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = true;
                    cboZPhaseUse.Items.Add("00:UNUSED");
                    cboZPhaseUse.Items.Add("01:(+)DIR_CW");
                    cboZPhaseUse.Items.Add("02:(-)DIR_CCW");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = false;
                    cboPulse.Items.Add("00:OneHighLowHigh");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = false;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");

                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = false;
                    cboZPhaseLev.Items.Add("02:UNUSED");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = true;
                    cboAlarm.Items.Add("00:LOW");
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("00:LOW");
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = false;
                    cboStopMode.Items.Add("00:EMERGENCY");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = false;
                    cboStopLevel.Items.Add("02:UNUSED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = true;
                    cboELimitN.Items.Add("00:LOW");
                    cboELimitN.Items.Add("01:HIGH");
                    cboELimitN.Items.Add("02:UNUSED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = true;
                    cboELimitP.Items.Add("00:LOW");
                    cboELimitP.Items.Add("01:HIGH");
                    cboELimitP.Items.Add("02:UNUSED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = false;
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = false;
                    edtSwPosP.Enabled = false;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = true;
                    cboEncoderType.Items.Add("00:INCREMENTAL");
                    cboEncoderType.Items.Add("01:ABSOLUTE");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00:PosEndLimit");
                    cboHomeSignal.Items.Add("01:NegEndLimit");
                    cboHomeSignal.Items.Add("04:HomeSensor");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = false;
                    cboHomeLevel.Items.Add("00:LOW");
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = true;
                    cboZPhaseUse.Items.Add("00:UNUSED");
                    cboZPhaseUse.Items.Add("01:(+)DIR_CW");
                    cboZPhaseUse.Items.Add("02:(-)DIR_CCW");
                    break;

                case (uint)AXT_MODULE.AXT_ECAT_MOTION:
                    cboPulse.Items.Clear();
                    cboPulse.Enabled = false;
                    cboPulse.Items.Add("00:OneHighLowHigh");

                    cboEncoder.Items.Clear();
                    cboEncoder.Enabled = false;
                    cboEncoder.Items.Add("00:ObverseUpDownMode");

                    cboAbsRel.Items.Clear();
                    cboAbsRel.Enabled = true;
                    cboAbsRel.Items.Add("00:POS_ABS_MODE");
                    cboAbsRel.Items.Add("01:POS_REL_MODE");

                    cboProfile.Items.Clear();
                    cboProfile.Enabled = true;
                    cboProfile.Items.Add("00:SYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("01:ASYTRAPEZOIDE_MODE");
                    cboProfile.Items.Add("02:QUASI_S_CURVE_MODE");
                    cboProfile.Items.Add("03:SYS_CURVE_MODE");
                    cboProfile.Items.Add("04:ASYS_CURVE_MODE");
                    
                    cboZPhaseLev.Items.Clear();
                    cboZPhaseLev.Enabled = false;
                    cboZPhaseLev.Items.Add("02:UNUSED");

                    cboAlarm.Items.Clear();
                    cboAlarm.Enabled = false;
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("00:LOW");
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");
                    cboInp.Items.Add("02:USED");

                    cboStopMode.Items.Clear();
                    cboStopMode.Enabled = false;
                    cboStopMode.Enabled = true;
                    cboStopMode.Items.Add("00:EMERGENCY");
                    cboStopMode.Items.Add("01:SLOWDOWN_");

                    cboStopLevel.Items.Clear();
                    cboStopLevel.Enabled = true;
                    cboStopLevel.Items.Add("00:LOW");
                    cboStopLevel.Items.Add("01:HIGH");
                    cboStopLevel.Items.Add("02:UNUSED");
                    cboStopLevel.Items.Add("02:USED");

                    cboELimitN.Items.Clear();
                    cboELimitN.Enabled = true;
                    cboELimitN.Items.Add("00:LOW");
                    cboELimitN.Items.Add("01:HIGH");
                    cboELimitN.Items.Add("02:UNUSED");
                    cboELimitN.Items.Add("02:USED");

                    cboELimitP.Items.Clear();
                    cboELimitP.Enabled = true;
                    cboELimitP.Items.Add("00:LOW");
                    cboELimitP.Items.Add("01:HIGH");
                    cboELimitP.Items.Add("02:UNUSED");
                    cboELimitP.Items.Add("02:USED");

                    cboServoOn.Items.Clear();
                    cboServoOn.Enabled = false;
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    edtSwPosN.Enabled = false;
                    edtSwPosP.Enabled = false;

                    cboEncoderType.Items.Clear();
                    cboEncoderType.Enabled = true;
                    cboEncoderType.Items.Add("00:INCREMENTAL");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00:PosEndLimit");
                    cboHomeSignal.Items.Add("01:NegEndLimit");
                    cboHomeSignal.Items.Add("04:HomeSensor");
                    cboHomeSignal.Items.Add("04:EncorderZPhase");

                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("00:Low");
                    cboHomeLevel.Items.Add("01:HIGH");

                    cboHomeDir.Items.Clear();
                    cboHomeDir.Enabled = true;
                    cboHomeDir.Items.Add("00:(-)DIR_CCW");
                    cboHomeDir.Items.Add("01:(+)DIR_CW");

                    cboZPhaseUse.Items.Clear();
                    cboZPhaseUse.Enabled = true;
                    cboZPhaseUse.Items.Add("00:UNUSED");
                    cboZPhaseUse.Items.Add("01:(+)DIR_CW");
                    cboZPhaseUse.Items.Add("02:(-)DIR_CCW");
                    break;

            }

            //++ 지정 축의 펄스 출력방식 설정값을 확인합니다.
            duRetCode = CAXM.AxmMotGetPulseOutMethod(m_lAxisNo, ref duMethod);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duMethod = (uint)AXT_MOTION_PULSE_OUTPUT.OneHighLowHigh;
            ConvertAxmToCombo(ref cboPulse, duMethod);

            //++ 지정 축의 엔코더 입력방식 설정값을 확인합니다.
            duRetCode = CAXM.AxmMotGetEncInputMethod(m_lAxisNo, ref duMethod);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duMethod = (uint)AXT_MOTION_EXTERNAL_COUNTER_INPUT.ObverseUpDownMode;
            ConvertAxmToCombo(ref cboEncoder, duMethod);

            //++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoAlarm(m_lAxisNo, ref duUse);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duUse = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboAlarm, duUse);

            //++ 지정 축에 Software Limit기능을 확인합니다.
            duRetCode = CAXM.AxmMotGetMinVel(m_lAxisNo, ref dMinVel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) dMinVel = 1.0;
            edtMinVel.Text = Convert.ToString(dMinVel);

            //++ 지정 축의 초기구동 속도를 확인합니다.
            duRetCode = CAXM.AxmMotGetMaxVel(m_lAxisNo, ref dMaxVel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) dMaxVel = 1.0;
            edtMaxVel.Text = Convert.ToString(dMaxVel);

            //++ 지정 축의 거리/속도/가속도의 제어단위/설정값들을 확인합니다.
            duRetCode = CAXM.AxmMotGetMoveUnitPerPulse(m_lAxisNo, ref dUnit, ref nPulse);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) dUnit = 1.0;
            edtMoveUnit.Text = Convert.ToString(dUnit);
            edtMovePulse.Text = Convert.ToString(nPulse);

            //++ 지정 축의 Z상 신호 Active Level 설정값을 확인합니다.
            duRetCode = CAXM.AxmSignalGetZphaseLevel(m_lAxisNo, ref duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboZPhaseLev, duLevel);

            //++ 지정 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoAlarm(m_lAxisNo, ref duUse);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duUse = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboAlarm, duUse);

            //++ 지정 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetInpos(m_lAxisNo, ref duUse);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duUse = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboInp, duUse);

            //++ 지정 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetStop(m_lAxisNo, ref duStopMode, ref duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboStopMode, duStopMode);
            ConvertAxmToCombo(ref cboStopLevel, duLevel);

            //++ 지정 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetLimit(m_lAxisNo, ref duStopMode, ref duPositiveLevel, ref duNegativeLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duPositiveLevel = duNegativeLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboELimitP, duPositiveLevel);
            ConvertAxmToCombo(ref cboELimitN, duNegativeLevel);

            //++ 지정 축의 Servo On/Off 신호 Active Level을 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoOnLevel(m_lAxisNo, ref duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboServoOn, duLevel);

            //++ 지정 축의 Alarm Reset 신호 Active Level을 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoAlarmResetLevel(m_lAxisNo, ref duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboAlarmReset, duLevel);
            
            //++ 지정한 축에 Software Limit기능을 확인합니다.
            duRetCode = CAXM.AxmSignalGetSoftLimit(m_lAxisNo, ref duSWEnable, ref duSWStopMode, ref duSWRef, ref dSWLimitP, ref dSWLimitN);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duSWStopMode = duSWRef = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            edtSwPosP.Text = Convert.ToString(dSWLimitP);
            edtSwPosN.Text = Convert.ToString(dSWLimitN);

            //++ 지정한 축에 설정된 구동 좌표계를 확인합니다.
            duRetCode = CAXM.AxmMotGetAbsRelMode(m_lAxisNo, ref duAbsRelMode);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duAbsRelMode = (uint)AXT_MOTION_ABSREL.POS_ABS_MODE;
            ConvertAxmToCombo(ref cboAbsRel, duAbsRelMode);

            //++ 지정한 축에 설정된 구동 프로파일 모드를 확인합니다.
            duRetCode = CAXM.AxmMotGetProfileMode(m_lAxisNo, ref duProfileMode);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duProfileMode = (uint)AXT_MOTION_PROFILE_MODE.SYM_TRAPEZOIDE_MODE;
            ConvertAxmToCombo(ref cboProfile, duProfileMode);


            //++ 지정한 축에 설정된 Encoder Type을 확인합니다.
            duRetCode = CAXDev.AxmSignalGetEncoderType(m_lAxisNo, ref duEncoderType);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duEncoderType = 0;
            ConvertAxmToCombo(ref cboEncoderType, duEncoderType);

            //++ 지정한 축에 원점검색 신호 Active Level을 확인합니다.
            CAXM.AxmHomeGetSignalLevel(m_lAxisNo, ref duLevel);
            ConvertAxmToCombo(ref cboHomeLevel, duLevel);

            //++ 지정한 축에 원점검색 방법 설정값을 확인합니다.
            CAXM.AxmHomeGetMethod(m_lAxisNo, ref lHmDir, ref duHomeSignal, ref duZphas, ref dHomeClrTime, ref dHomeOffset);
            ConvertAxmToCombo(ref cboHomeDir, (uint)lHmDir);
            ConvertAxmToCombo(ref cboHomeSignal, (uint)duHomeSignal);
            ConvertAxmToCombo(ref cboZPhaseUse, (uint)duZphas);            

            edtHomeClrTime.Text = Convert.ToString(dHomeClrTime);
            edtHomeOffset.Text = Convert.ToString(dHomeOffset);

            //++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
            CAXM.AxmHomeGetVel(m_lAxisNo, ref dVelFirst, ref dVelSecond, ref dVelThird, ref dVelLast, ref dAccFirst, ref dAccSecond);
            edtVelFirst.Text = Convert.ToString(dVelFirst);
            edtVelSecond.Text = Convert.ToString(dVelSecond);
            edtVelThird.Text = Convert.ToString(dVelThird);
            edtVelLast.Text = Convert.ToString(dVelLast);

            edtAccFirst.Text = Convert.ToString(dAccFirst);
            edtAccSecond.Text = Convert.ToString(dAccSecond);

            //++ 지정한 축에 원점검색 속도/가속도 설정값을 확인합니다.
            CAXM.AxmMotGetParaLoad(m_lAxisNo, ref dInitPos, ref dInitVel, ref dInitAccel, ref dInitDecel);
            edtPosition.Text = Convert.ToString(dInitPos);
            edtVelocity.Text = Convert.ToString(dInitVel);
            edtAccel.Text = Convert.ToString(dInitAccel);
            edtDecel.Text = Convert.ToString(dInitDecel);
        }

        // ++ =======================================================================
        // >> ConvertComboToAxm(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
        //    보드에 설정할 값으로 변경하는 함수.
        //  - ComboBox에 선택된 Item Index와 실제 모션보드에 설정되는 값이 다르므로 
        //    선택된 문자열에서 모션보드에 설정할 값을 추출해서 반환하는 함수입니다.
        //  - 변환 할 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
        //  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
        //    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
        //    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
        // --------------------------------------------------------------------------
        public uint ConvertComboToAxm(ref ComboBox pCboItem)
        {
            if (pCboItem == null) return 0;

            String strText;

            int iCount, iSeldate;

            iCount = pCboItem.Items.Count;
            if (iCount == 0) return 0;
            iSeldate = pCboItem.SelectedIndex;
            if (iSeldate < 0) return 0;

            strText = pCboItem.Text.Substring(0, 2);
            return Convert.ToUInt32(strText);
        }

        // ++ =======================================================================
        // >> ConvertAxmToCombo(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의  
        //    Item과 일치하는 Item을 찾아 선택하는 함수.
        //  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
        //    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
        //  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
        //  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
        //    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
        //    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
        // --------------------------------------------------------------------------
        public uint ConvertAxmToCombo(ref ComboBox pCboItem, uint diCurData)
        {
            if (pCboItem == null) return 0;

            uint lCount, lSeldata;
            String strText;
            
            lCount = (uint)pCboItem.Items.Count;

            if (lCount == 0) return 0;

            for (int i = 0; i < lCount; i++){
                strText = pCboItem.Items[i].ToString();
                lSeldata = Convert.ToUInt32(strText.Substring(0, 2));
                if (lSeldata == (uint)diCurData){
                    pCboItem.SelectedIndex = i;
                   return (uint)i;
                }
            }
            pCboItem.SelectedIndex = 0;
            return 0;
        }
    }       
}