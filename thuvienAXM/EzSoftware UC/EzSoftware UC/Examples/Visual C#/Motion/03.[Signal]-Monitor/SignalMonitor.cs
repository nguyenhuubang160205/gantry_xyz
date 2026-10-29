// SignalMonitorDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는 
//    기능들을 파악할 수 있도록 작성된 예제입니다.
// >> [중요]: 신호설정 함수 사용시 주의사항 
//     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
//     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를 
//        변경해서 바꿀수 있습니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SignalMonitor
{
    public partial class SignalMonitor : Form
    {
        public  int m_lAxisCounts = 0;                          // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                          // 제어할 축 번호 선언 및 초기화
        public uint m_uModuleID   = 0;                          // 제어할 축의 모듈 I/O 선언 및 초기화 
        public  int m_lBoardNo    = 0, m_lModulePos = 0;
        

        public SignalMonitor()
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
        private void SignalMonitor_Load(object sender, EventArgs e)
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
            CheckBox[] SignalInput = new CheckBox[5];
            SignalInput[0] = chkInp00; SignalInput[1] = chkInp01; SignalInput[2] = chkInp02;
            SignalInput[3] = chkInp03; SignalInput[4] = chkInp04;

            CheckBox[] SignalOutput = new CheckBox[5];
            SignalOutput[0] = chkOut00; SignalOutput[1] = chkOut01; SignalOutput[2] = chkOut02;
            SignalOutput[3] = chkOut03; SignalOutput[4] = chkOut04;


            uint uBitNo = 0;
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
                chkEmg.Checked = Convert.ToBoolean(duState1);
            }
            //++ (+/-)End Limit신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadLimit(m_lAxisNo, ref duState1, ref duState2);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkElimitP.Checked = Convert.ToBoolean(duState1);
                chkElimitN.Checked = Convert.ToBoolean(duState2);
            }
            //++ (+/-)Software Limit의 Active 상태를 확인합니다.
            duRetCode = CAXM.AxmSignalReadSoftLimit(m_lAxisNo, ref duState1, ref duState2);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                chkSwlimitP.Checked = Convert.ToBoolean(duState1);
                chkSwlimitN.Checked = Convert.ToBoolean(duState2);
            }
            for (uBitNo = 0; uBitNo < (uint)AXT_MOTION_UNIV_OUTPUT.UIO_OUT5; uBitNo++)
            {
                //++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
                duRetCode = CAXM.AxmSignalReadInputBit(m_lAxisNo, (int)uBitNo, ref duState1);
                if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) SignalInput[uBitNo].Checked = Convert.ToBoolean(duState1);
                //++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
                duRetCode = CAXM.AxmSignalReadOutputBit(m_lAxisNo, (int)uBitNo, ref duState2);
                if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) SignalOutput[uBitNo].Checked = Convert.ToBoolean(duState2);
            }
        }

        // ++ =======================================================================
        // >> cboSelAxis_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
        //  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
        // -------------------------------------------------------------------------
        private void cboSelAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_lAxisNo = cboSelAxis.SelectedIndex;
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

            //++ 함수 실행 성공시 지정한 Mot파일의 설정값으로 모션축 설정이 일괄 변경됩니다.
            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                temp = openFileDialog1.FileName;
                if (CAXM.AxmMotLoadParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("File load failed");
            }else{
                UpdateState();      // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
            }
        }

        // ++ =======================================================================
        // >> chkSwEnable_Click() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축에 Software Limit기능을 설정합니다.
        // --------------------------------------------------------------------------
        private void chkSwEnable_Click(object sender, EventArgs e)
        {
            uint duRetCode;
            double dSWLimitP, dSWLimitN;
            uint duSWEnable, duSWStopMode, duSWRef;

            duSWEnable = Convert.ToUInt32(chkSwEnable.Checked);
            duSWStopMode = ConvertComboToAxm(ref cboSwStop);
            duSWRef = ConvertComboToAxm(ref cboSwRef);
            dSWLimitP = Convert.ToDouble(edtSwPosP.Value);
            dSWLimitN = Convert.ToDouble(edtSwPosN.Value);

            //++ 지정한 축에 Software Limit기능을 설정합니다.
            // ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
            duRetCode = CAXM.AxmSignalSetSoftLimit(m_lAxisNo, duSWEnable, duSWStopMode, duSWRef, dSWLimitP, dSWLimitN);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                MessageBox.Show(String.Format("AxmSignalSetSoftLimit return error[Code:{0:d}]", duRetCode));
                chkSwEnable.Checked = false;
            }
        }

        // ++ =======================================================================
        // >> chkOut_Click(...) : "Output Bit" 버튼 클릭시 호출되는 핸들러 함수. 
        //  - chkOut00 ~ chkOut04 버튼의 클릭이벤트 발생시 호출됩니다.
        // --------------------------------------------------------------------------
        private void chkOut_Click(object sender, EventArgs e)
        {
            uint duRetCode;
            int nBitNo;

            nBitNo = Convert.ToInt16(((CheckBox)sender).Tag);
            //++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
            duRetCode = CAXM.AxmSignalWriteOutputBit(m_lAxisNo, nBitNo, Convert.ToUInt32(((CheckBox)sender).Checked));
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                ((CheckBox)sender).Checked = false;
                MessageBox.Show(String.Format("AxmSignalWriteOutputBit return error[Code:{0:d}]", duRetCode));
            }
        }

        // ++ =======================================================================
        // >> cboZPhase_SelectedIndexChanged() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboZPhase_SelectedIndexChanged(object sender, EventArgs e)
        {            
            uint duLevel,duRetCode = 0;
            //이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
            if (m_uModuleID != (uint)AXT_MODULE.AXT_ECAT_MOTION)
            {
                duLevel = ConvertComboToAxm(ref cboZPhase);
                //++ 선택한 축의 Z상 Active Level을 설정합니다.
                duRetCode = CAXM.AxmSignalSetZphaseLevel(m_lAxisNo, duLevel);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmSignalSetZphaseLevel return error[Code:{0:d}]", duRetCode));
            }
           
        }

        // ++ =======================================================================
        // >> cboAlarm_SelectedIndexChanged() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
        //  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도 
        //    계속해서 목표지점까지 구동하게됩니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboAlarm_SelectedIndexChanged(object sender, EventArgs e)
        {            
            uint duLevel, duRetCode = 0;
            //이더켓은 AxmSignalSetServoAlarm을 지원하지 않음.
            if (m_uModuleID != (uint)AXT_MODULE.AXT_ECAT_MOTION)
            {
                duLevel = ConvertComboToAxm(ref cboAlarm);
                //++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
                duRetCode = CAXM.AxmSignalSetServoAlarm(m_lAxisNo, duLevel);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmSignalSetServoAlarm return error[Code:{0:d}]", duRetCode));
            }
        }

        // ++ =======================================================================
        // >> cboInp_SelectedIndexChanged() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboInp_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duLevel, duRetCode=0;

            duLevel = ConvertComboToAxm(ref cboInp);
            //++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
            // - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
            // ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터 
            //              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
            // ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아 
            //              다음 구동을 할 수 없게 됩니다. 
            duRetCode = CAXM.AxmSignalSetInpos(m_lAxisNo, duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmSignalSetInpos return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> OnSelchangeCboEmg() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
        //  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도 
        //    계속해서 목표지점까지 구동하게됩니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboEmg_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duRetCode = 0, duStopMode = 0, duLevel = 0;

            //++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        	duRetCode = CAXM.AxmSignalGetStop(m_lAxisNo, ref duStopMode, ref duLevel);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                duLevel = ConvertComboToAxm(ref cboEmg);
                //++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
                CAXM.AxmSignalSetStop(m_lAxisNo, duStopMode, duLevel);
            }else{
                MessageBox.Show(String.Format("AxmSignalGetStop return error[Code:{0:d}]", duRetCode)); 
            }
        }

        // ++ =======================================================================
        // >> OnSelchangeCboElimitN() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
        //  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
        //    Active되어도 계속해서 목표지점까지 구동하게됩니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboElimitP_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duRetCode, duStopMode = 0, duPLevel = 0, duNLevel = 0;
            duRetCode = CAXM.AxmSignalGetLimit(m_lAxisNo, ref duStopMode, ref duPLevel, ref duNLevel);

            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                duPLevel = ConvertComboToAxm(ref cboElimitP);
                //++ 선택한 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
                CAXM.AxmSignalSetLimit(m_lAxisNo, duStopMode, duPLevel, duNLevel);
            }else{
                MessageBox.Show(String.Format("AxmSignalSetLimit return error[Code:{0:d}]", duRetCode));
            }
        }

        // ++ =======================================================================
        // >> OnSelchangeCboElimitN() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
        //  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
        //    Active되어도 계속해서 목표지점까지 구동하게됩니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboElimitN_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duRetCode, duStopMode = 0, duPLevel = 0, duNLevel = 0;

            //++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetLimit(m_lAxisNo, ref duStopMode, ref duPLevel, ref duNLevel);

            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                duNLevel = ConvertComboToAxm(ref cboElimitN);
                //++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
                CAXM.AxmSignalSetLimit(m_lAxisNo, duStopMode, duPLevel, duNLevel);
            }else{
                MessageBox.Show(String.Format("AxmSignalSetLimit return error[Code:{0:d}]", duRetCode));
            }
        }

        // ++ =======================================================================
        // >> OnSelchangeCboServoOn() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboServoOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duLevel, duRetCode = 0;
            //이더켓은 AxmSignalSetServoOnLevel을 지원하지 않음.
            if (m_uModuleID != (uint)AXT_MODULE.AXT_ECAT_MOTION)
            {
                duLevel = ConvertComboToAxm(ref cboServoOn);
                //++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
                duRetCode = CAXM.AxmSignalSetServoOnLevel(m_lAxisNo, duLevel);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmSignalSetServoOnLevel return error[Code:{0:d}]", duRetCode));
            }
        }

        // ++ =======================================================================
        // >> OnSelchangeCboAlarmReset() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
        // ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboAlarmReset_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duLevel, duRetCode = 0;
            //이더켓은 AxmSignalSetServoAlarmResetLevel을 지원하지 않음.
            if (m_uModuleID != (uint)AXT_MODULE.AXT_ECAT_MOTION)
            {
                duLevel = ConvertComboToAxm(ref cboAlarmReset);
                //++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
                duRetCode = CAXM.AxmSignalSetServoAlarmResetLevel(m_lAxisNo, duLevel);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmSignalSetServoAlarmResetLevel return error[Code:{0:d}]", duRetCode));
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
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Intialize Fail..!!");
            //++ 지정한 Mot파일의 설정값들로 모션보드의 설정값들을 일괄변경 적용합니다.
            if (CAXM.AxmMotLoadParaAll(szFilePath) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Mot File Not Found.");
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
                switch (m_uModuleID)
                {
                    //++ 지정한 축의 정보를 반환합니다.
                    // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
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
            double dSWLimitP = 0.0, dSWLimitN = 0.0;
            uint duSWEnable = 0, duSWStopMode = 0, duSWRef = 0;
            uint duLevel1 = 0, duLevel2 = 0, duRetCode, duStopMode = 0;

            // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
            switch (m_uModuleID){
                case (uint)AXT_MODULE.AXT_SMC_4V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04:
                case (uint)AXT_MODULE.AXT_SMC_2V04:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2Q:
                case (uint)AXT_MODULE.AXT_SMC_R1V04PM2QE:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIPM:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIISV_MD: 
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7S: 
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIIS7W:
                    cboZPhase.Items.    Clear();
                    cboZPhase.Items.    Add("00: LOW");
                    cboZPhase.Items.    Add("01: HIGH");
                    cboAlarm.Items.     Clear();
                    cboAlarm.Items.     Add("00: LOW");
                    cboAlarm.Items.     Add("01: HIGH");
                    cboAlarm.Items.     Add("02: UNUSED");
                    cboInp.Items.       Clear();
                    cboInp.Items.       Add("00: LOW");
                    cboInp.Items.       Add("01: HIGH");
                    cboInp.Items.       Add("02: UNUSED");
                    cboEmg.Items.       Clear();
                    cboEmg.Items.       Add("00: LOW");
                    cboEmg.Items.       Add("01: HIGH");
                    cboEmg.Items.       Add("02: UNUSED");
                    cboElimitN.Items.   Clear();
                    cboElimitN.Items.   Add("00: LOW");
                    cboElimitN.Items.   Add("01: HIGH");
                    cboElimitN.Items.   Add("02: UNUSED");
                    cboElimitP.Items.   Clear();
                    cboElimitP.Items.   Add("00: LOW");
                    cboElimitP.Items.   Add("01: HIGH");
                    cboElimitP.Items.   Add("02: UNUSED");
                    cboServoOn.Items.   Clear();
                    cboServoOn.Items.   Add("00: LOW");
                    cboServoOn.Items.   Add("01: HIGH");
                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Items.Add("00: LOW");
                    cboAlarmReset.Items.Add("01: HIGH");
                    cboSwRef.Items.     Clear();
                    cboSwRef.Items.     Add("00: COMMAND");
                    cboSwRef.Items.     Add("01: ACTUAL");
                    cboSwStop.Items.    Clear();
                    cboSwStop.Items.    Add("00: E_STOP");
                    cboSwStop.Items.    Add("01: S_STOP");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04A4:
                    cboZPhase.Items.    Clear();
                    cboZPhase.Items.    Add("02: UNUSED");
                    cboAlarm.Items.     Clear();
                    cboAlarm.Items.     Add("01: HIGH");
                    cboAlarm.Items.     Add("02: UNUSED");
                    cboInp.Items.       Clear();
                    cboInp.Items.       Add("01: HIGH");
                    cboInp.Items.       Add("02: UNUSED");
                    cboEmg.Items.       Clear();
                    cboEmg.Items.       Add("00: LOW");
                    cboEmg.Items.       Add("02: UNUSED");
                    cboElimitN.Items.   Clear();
                    cboElimitN.Items.   Add("00: LOW");
                    cboElimitN.Items.   Add("02: UNUSED");
                    cboElimitP.Items.   Clear();
                    cboElimitP.Items.   Add("00: LOW");
                    cboElimitP.Items.   Add("02: UNUSED");
                    cboServoOn.Items.   Clear();
                    cboServoOn.Items.   Add("01: HIGH");
                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Items.Add("01: HIGH");
                    cboSwRef.Items.     Clear();
                    cboSwRef.Items.     Add("02: UNUSED");
                    cboSwStop.Items.    Clear();
                    cboSwStop.Items.    Add("02: UNUSED");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM:
                    cboZPhase.Items.    Clear();
                    cboZPhase.Items.    Add("02: UNUSED");
                    cboAlarm.Items.     Clear();
                    cboAlarm.Items.     Add("02: UNUSED");
                    cboInp.Items.       Clear();
                    cboInp.Items.       Add("02: UNUSED");
                    cboEmg.Items.       Clear();
                    cboEmg.Items.       Add("02: UNUSED");
                    cboElimitN.Items.   Clear();
                    cboElimitN.Items.   Add("02: UNUSED");
                    cboElimitP.Items.   Clear();
                    cboElimitP.Items.   Add("02: UNUSED");
                    cboServoOn.Items.   Clear();
                    cboServoOn.Items.   Add("01: HIGH");
                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Items.Add("01: HIGH");
                    cboSwRef.Items.     Clear();
                    cboSwRef.Items.     Add("02: UNUSED");
                    cboSwStop.Items.    Clear();
                    cboSwStop.Items.    Add("02: UNUSED");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV_R:
                    cboZPhase.Items.    Clear();
                    cboZPhase.Items.    Add("02: UNUSED");
                    cboAlarm.Items.     Clear();
                    cboAlarm.Items.     Add("01: HIGH");
                    cboAlarm.Items.     Add("02: UNUSED");
                    cboInp.Items.       Clear();
                    cboInp.Items.       Add("01: HIGH");
                    cboInp.Items.       Add("02: UNUSED");
                    cboEmg.Items.       Clear();
                    cboEmg.Items.       Add("02: UNUSED");
                    cboElimitN.Items.   Clear();
                    cboElimitN.Items.   Add("01: HIGH");
                    cboElimitN.Items.   Add("02: UNUSED");
                    cboElimitP.Items.   Clear();
                    cboElimitP.Items.   Add("01: HIGH");
                    cboElimitP.Items.   Add("02: UNUSED");
                    cboServoOn.Items.   Clear();
                    cboServoOn.Items.   Add("01: HIGH");
                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Items.Add("01: HIGH");
                    cboSwRef.Items.     Clear();
                    cboSwRef.Items.     Add("02: UNUSED");
                    cboSwStop.Items.    Clear();
                    cboSwStop.Items.    Add("02: UNUSED");                
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR:
                    cboAlarm.Items.Clear();
                    cboAlarm.Items.Add("01: HIGH");
                    cboAlarm.Items.Add("02: UNUSED");
                    cboInp.Items.Clear();
                    cboInp.Items.Add("01: HIGH");
                    cboInp.Items.Add("02: UNUSED");
                    cboEmg.Items.Clear();
                    cboEmg.Items.Add("02: UNUSED");
                    cboElimitN.Items.Clear();
                    cboElimitN.Items.Add("01: HIGH");
                    cboElimitN.Items.Add("02: UNUSED");
                    cboElimitP.Items.Clear();
                    cboElimitP.Items.Add("01: HIGH");
                    cboElimitP.Items.Add("02: UNUSED");
                    cboSwRef.Items.Clear();
                    cboSwRef.Items.Add("02: UNUSED");
                    cboSwStop.Items.Clear();
                    cboSwStop.Items.Add("02: UNUSED");
                    break;

                case (uint)AXT_MODULE.AXT_ECAT_MOTION:
                    cboZPhase.Items.    Clear();
                    cboZPhase.Enabled = false;
                    cboZPhase.Items.Add("02:UNUSED");

                    cboAlarm.Items.     Clear();
                    cboAlarm.Enabled = false;
                    cboAlarm.Items.Add("01:HIGH");
                    cboAlarm.Items.Add("02:UNUSED");

                    cboInp.Items.       Clear();
                    cboInp.Enabled = true;
                    cboInp.Items.Add("00:LOW");
                    cboInp.Items.Add("01:HIGH");
                    cboInp.Items.Add("02:UNUSED");
                    cboInp.Items.Add("03:USED");

                    cboEmg.Items.       Clear();
                    cboEmg.Enabled = true;
                    cboEmg.Items.Add("00:LOW");
                    cboEmg.Items.Add("01:HIGH");
                    cboEmg.Items.Add("02:UNUSED");
                    cboEmg.Items.Add("02:USED");

                    cboElimitN.Items.   Clear();
                    cboElimitN.Enabled = true;
                    cboElimitN.Items.Add("00:LOW");
                    cboElimitN.Items.Add("01:HIGH");
                    cboElimitN.Items.Add("02:UNUSED");
                    cboElimitN.Items.Add("02:USED");

                    cboElimitP.Items.   Clear();
                    cboElimitP.Enabled = true;
                    cboElimitP.Items.Add("00:LOW");
                    cboElimitP.Items.Add("01:HIGH");
                    cboElimitP.Items.Add("02:UNUSED");
                    cboElimitP.Items.Add("02:USED");

                    cboServoOn.Items.   Clear();
                    cboServoOn.Enabled = false;
                    cboServoOn.Items.Add("01:HIGH");

                    cboAlarmReset.Items.Clear();
                    cboAlarmReset.Enabled = false;
                    cboAlarmReset.Items.Add("01:HIGH");

                    cboSwRef.Items.Clear();
                    cboSwRef.Enabled = false;
                    cboSwRef.Items.Add("02: UNUSED");

                    cboSwStop.Items.Clear();
                    cboSwStop.Enabled = false;
                    cboSwStop.Items.Add("02: UNUSED");
                    break;

            }

            //++ 선택한 축의 Z상 신호 Active Level 설정값을 확인합니다.
            duRetCode = CAXM.AxmSignalGetZphaseLevel(m_lAxisNo, ref duLevel1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboZPhase, ref duLevel1);

            //++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoAlarm(m_lAxisNo, ref duLevel1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboAlarm, ref duLevel1);

            //++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetInpos(m_lAxisNo, ref duLevel1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboInp, ref duLevel1);

            if ((m_uModuleID == (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL) && (m_uModuleID == (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR))
            {
                //++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
                duRetCode = CAXM.AxmSignalGetStop(m_lAxisNo, ref duStopMode, ref duLevel1);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
                ConvertAxmToCombo(ref cboEmg, ref duLevel1);
            }

            //++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
            duRetCode = CAXM.AxmSignalGetLimit(m_lAxisNo, ref duStopMode, ref duLevel1, ref duLevel2);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = duLevel2 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboElimitN, ref duLevel1);
            ConvertAxmToCombo(ref cboElimitP, ref duLevel2);

            //++ 선택된 축의 Servo On/Off 신호 Active Level을 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoOnLevel(m_lAxisNo, ref duLevel1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboServoOn, ref duLevel1);

            //++ 선택된 축의 Alarm Reset 신호 Active Level을 확인합니다.
            duRetCode = CAXM.AxmSignalGetServoAlarmResetLevel(m_lAxisNo, ref duLevel1);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboAlarmReset, ref duLevel1);

            //++ 지정한 축에 Software Limit기능을 확인합니다.
            duRetCode = CAXM.AxmSignalGetSoftLimit(m_lAxisNo, ref duSWEnable, ref duSWStopMode, ref duSWRef, ref dSWLimitP, ref dSWLimitN);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel1 = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;

            chkSwEnable.Checked = Convert.ToBoolean(duSWEnable);
            ConvertAxmToCombo(ref cboSwRef, ref duSWRef);
            ConvertAxmToCombo(ref cboSwStop, ref duSWStopMode);
            edtSwPosP.Value = Convert.ToDecimal(dSWLimitP);
            edtSwPosN.Value = Convert.ToDecimal(dSWLimitN);
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
        public uint ConvertAxmToCombo(ref ComboBox pCboItem, ref uint diCurData)
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