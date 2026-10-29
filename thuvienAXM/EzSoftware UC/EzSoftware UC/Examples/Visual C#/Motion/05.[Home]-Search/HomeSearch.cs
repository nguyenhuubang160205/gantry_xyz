// HomeSearch.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 원점검색 함수들의 사용법을 읽히고 원점검색 방법과 각 
//    단계별 사용하는 원점검색 속도 설정법을 이해하여 빠르고 정밀한 원점 검색 
//    방법에 대해 학습하는 예제입니다.
// >> [중요]: 원점검색 방법 및 원점검색 단계별 속도사용에 대해
//     1) 원점검색은 기본적으로 5번의 신호검출 과정을 거쳐 완료됩니다.
//     2) 원점센서 검출 여부를 판단하여 원점검색 진행 방향으로 신호를 검출할 지
//        원점검색 반대방향으로 신호검출을 진행할지를 판단합니다.
//     3) 1차 원점신호 감지시에는 가감속이 있는 구동을 하여 비교적 빠른 속도로
//        원점신호를 감지합니다.
//     4) 1차 원점신호 감지 후 반대방향으로 2단계 속도로 1차 때와 마찬가지로 
//        가감속이 있는 구동을 하여 기구물이 원점센서의 검색진행 반대편에 위치
//        하도록 합니다.
//     5) 3단계 속도를 이용하여 가감속이 없이 원점신호를 검출하게 됩니다. 
//     6) 이 후 Z상검출 사용여부에 따라 4단계/5단계 신호 검출을 하여 빠르고 
//        정밀하게 원점검출을 완료하게 됩니다.
// >> [중요]: 원점검색 속도설정에 대해
//     1) dVelFirst: 초기 원점신호가 감지되지 않았을 때 원점신호 검색 방향으로 
//        On 상태를 검출할 때의 속도
//     2) dVelSecond: 초기 원점신호가 감지되어 있어 원점신호 검색 반대 방향으로 
//        Off 상태를 검출할 때의 속도
//     3) dVelFirst, dVelSecond속도는 원점검색 반복 정밀도 보다는 원점검색 시간과
//        관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 빠르게 설정합니다.
//     4) dVelThird: 1차 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     5) dVelLasts: 최종 원점신호 위치를 검출하기위해 On상태를 검출할 때의 속도
//     6) dVelLasts속도는 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이 
//        있으므로 10 PPS정도 설정하면 정밀하게 원점검색을 구현 할 수 있습니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomeSearch
{
    public partial class HomeSearch : Form
    {
        public int m_lAxisCounts  = 0;                // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                // 제어할 축 번호 선언 및 초기화   
        public uint m_uModuleID   = 0;                // 제어할 축의 모듈 I/O 선언 및 초기화
        public uint m_duOldResult = 0;                // tmTimer에서 사용할 이전 Command Position 선언 및 초기화
        String m_strResult;                           // 홈검색 결과를 출력 변수 선언
        public int  m_lBoardNo = 0, m_lModulePos = 0;
        

        public HomeSearch()
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

        private void HomeSearch_Load(object sender, EventArgs e)
        {
            initLibrary();      // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();      // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();      // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            double dCmdPosition = 0.0;
            double dActPosition = 0.0;
            double dCmdVelocity = 0.0;

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            CAXM.AxmStatusGetCmdPos(m_lAxisNo, ref dCmdPosition);
            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            CAXM.AxmStatusGetActPos(m_lAxisNo, ref dActPosition);
            //++ 지정한 축의 구동 속도를 반환합니다.
            CAXM.AxmStatusReadVel(m_lAxisNo, ref dCmdVelocity);

            textCmdPos.Text = String.Format("{0:0.000}", dCmdPosition);
            textActPos.Text = String.Format("{0:0.000}", dActPosition);
            textCmdVel.Text = String.Format("{0:0.000}", dCmdVelocity);
        }

        // ++ =======================================================================
        // >> tmHomeInfo_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 홈 검색시 홈검색 진행률 및 상태를 읽어와서 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmHomeInfo_Tick(object sender, EventArgs e)
        {
            uint duRetCode, duState = 0;
            uint duStepMain = 0, duStepSub = 0;

            //++ 지정한 축의 원점신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmHomeReadSignal(m_lAxisNo, ref duState);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) chkHomeState.Checked = Convert.ToBoolean(duState);

            //++ 지정한 축의 원점신호의 상태를 확인합니다.
            CAXM.AxmHomeGetResult(m_lAxisNo, ref duState);
            if (m_duOldResult != duState)
            {
                labelHomeSearch.Text = TranslateHomeResult(duState);
                m_duOldResult = duState;
            }
            //++ 지정한 축의 원점검색 결과를 확인합니다
            duRetCode = CAXM.AxmHomeGetRate(m_lAxisNo, ref duStepMain, ref duStepSub);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                labelHomeStepMain32.Text = Convert.ToString(duStepMain);
                labelHomeStepSub33.Text = Convert.ToString(duStepSub);
            }
            //++ 지정한 축의 원점검색 진행율을 확인합니다.
            duRetCode = CAXM.AxmHomeGetRate(m_lAxisNo, ref duStepMain, ref duStepSub);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                prgHomeRate.Value = (int)duStepSub;
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

            UpdateState();                          // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.	
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                temp = openFileDialog1.FileName;
                if (CAXM.AxmMotLoadParaAll(temp) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("File load failed");
            }
            else
            {
                UpdateState();      // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
            }
        }

        // ++ =======================================================================
        // >> OnBtnPosClear() : "Position Clear"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축의 위치정보를 0.0으로 설정합니다.
        //  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
        //    사용하는것과 동일한 효과를 냅니다.
        // --------------------------------------------------------------------------
        private void btnPosClear_Click(object sender, EventArgs e)
        {
            //CAXM.AxmStatusSetCmdPos(m_lAxisNo, 0.0);
            //CAXM.AxmStatusSetActPos(m_lAxisNo, 0.0);	
            //++ Command위치와 Actual위치를 지정한 값으로 설정합니다
            CAXM.AxmStatusSetPosMatch(m_lAxisNo, 0.0);
        }

        // ++ =======================================================================
        // >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint duOnOff;
            duOnOff = (uint)Convert.ToInt32(chkServoOn.Checked);
            //++ 지정 축의 Servo On/Off 신호를 출력합니다.
            CAXM.AxmSignalServoOn(m_lAxisNo, duOnOff);
        }

        // ++ =======================================================================
        // >> OnSelchangeCboHomeLevel() : "Home Level"콤보박스 Item변경시 호출되는 핸들러 함수.
        //  - 선택된 축의 원점신호 Active Level을 설정합니다.
        // ※ [CAUTION] 특정 네트웍 제품의 경우 원점신호레벨 변경을 지원하지않습니다.
        // --------------------------------------------------------------------------
        private void cboHomeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duLevel;
            uint duRetCode = 0;
            //이더켓은 AxmHomeSetSignalLevel을 지원하지 않음.
            if (m_uModuleID != (uint)AXT_MODULE.AXT_ECAT_MOTION)
            {
                duLevel = ConvertComboToAxm(ref cboHomeLevel);
                //++ 지정한 축의 원점신호 Active Level을 변경합니다.
                duRetCode = CAXM.AxmHomeSetSignalLevel(m_lAxisNo, duLevel);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmHomeSetSignalLevel return error[Code:{0:d}]", duRetCode));
            }         
        }

        // ++ =======================================================================
        // >> OnBtnSetMethod() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축의 원점검색 방향, 신호, Z상 검출여부, Offset등을 설정합니다.
        //  - 원점검색시 Z상 신호의 검출을 사용함으로 설정하였을 경우 1차로 지정한 
        //    원점신호를 검출 완료한 후 Z상 신호를 추가적으로 검출하게 됩니다.
        // ※ [CAUTION] Z상의 경우 모터와 Ballscrew를 연결해주는 커플링이 풀리거나 
        //    해체할 경우 Z상 위치가 변경되므로 원점검색 위치가 달라지게됩니다.
        // --------------------------------------------------------------------------
        private void btnSetMethod_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            int iHomeDir = 0;
            uint duHomeSignal = 2, duZPhaseUse = 0;
            double dHomeClrTime = 0.0, dHomeOffset = 0.0;

            iHomeDir     = (int)ConvertComboToAxm(ref cboHomeDir);
            duHomeSignal = ConvertComboToAxm(ref cboHomeSignal);
            duZPhaseUse  = ConvertComboToAxm(ref cboZphaseUse);

            edtHomeOffset.Value  = Convert.ToDecimal(dHomeOffset);
            edtHomeClrTime.Value = Convert.ToDecimal(dHomeClrTime);

            //++ 지정한 축의 원점검색 방법을 변경합니다.
            duRetCode = CAXM.AxmHomeSetMethod(m_lAxisNo, iHomeDir, duHomeSignal, duZPhaseUse, dHomeClrTime, dHomeOffset);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmHomeSetMethod return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> OnBtnSetVelocity() : "Set Velocity"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축의 단계별 원점검색 속도를 설정합니다.
        //  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
        // ※ [CAUTION] dVelFirst, dVelSecond는 초기 원점검색 속도로 원점검색 반복 정밀도
        //    보다는 원점검색 시간과 관련이 깊습니다. 따라서 dVelFirst, dVelSecond 속도는 
        //    비교적 빠르게 설정하고 원점검색 마지막에 사용되어 반복 정밀도와 밀접한 관련이 
        //    있는 dVelLasts속도 10 PPS정도에 설정하면 빠르고 정밀하게 원점검색을 구현
        //    할 수 있습니다.
        // --------------------------------------------------------------------------
        private void btnSetVelocity_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            double dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond;

            // 각각의 Edit 콘트롤에서 설정값을 가져옴
            dVelFirst  = Math.Abs(Convert.ToDouble(edtVelFirst.Value));
            dVelSecond = Math.Abs(Convert.ToDouble(edtVelSecend.Value));
            dVelThird  = Math.Abs(Convert.ToDouble(edtVelThird.Value));
            dVelLast   = Math.Abs(Convert.ToDouble(edtVelLast.Value));
            dAccFirst  = Math.Abs(Convert.ToDouble(edtAccFirst.Value));
            dAccSecond = Math.Abs(Convert.ToDouble(edtAccSecond.Value));

            //++ 원점검색에 사용되는 단계별 속도를 설정합니다.
            duRetCode = CAXM.AxmHomeSetVel(m_lAxisNo, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmHomeSetVel return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> OnBtnHomeStart() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축으로 원점검색을 진행합니다.
        //  - 원점검색의 단계를 세분화해 빠르고 정밀하게 원점검색을 구현할 수 있습니다.
        // ※ [CAUTION] 원점검색시 라이브러리 내부에서 해당축의 원점검색을 수행 할 쓰레드가
        //    자동 생성되어 원점검색을 순차적으로 수행한 후 자동 종료됩니다. 따라서 단일 
        //    CPU시스템의 경우 사용자 프로그램에서 CPU를 100% 점유할 경우 원점 검색 진행이
        //    원할하게 되지 않을 수 있습니다.
        // --------------------------------------------------------------------------
        private void btnHomeStart_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            //++ 지정한 축에 원점검색을 진행합니다.
            duRetCode = CAXM.AxmHomeSetStart(m_lAxisNo);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmHomeSetStart return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> OnBtnMoveStop() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축의 구동을 종료합니다. 만약 원점검색 중이면 검색을 중단하고 원점검색
        //    결과를 HOME_ERR_USER_BREAK로 설정합니다.
        // --------------------------------------------------------------------------
        private void btnMoveStop_Click(object sender, EventArgs e)
        {
            //++ 지정한 축의 구동을 정지합니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> Project Name_FormClosed(...) : 프로젝트 Form 종료 함수.
        //  - Form을 Close시 불러내는 함수, Form 종료시 사용됩니다.
        // --------------------------------------------------------------------------
        private void HomeSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            //++ Timer 사용을 종료합니다.
            tmDisplay.Enabled = false;
            tmHomeInfo.Enabled = false;
            //++ AXL 사용을 종료합니다.
            CAXL.AxlClose();
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
                    default:                                     strAxis = String.Format("{0:00}-[Unknown]",   i);  break;
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
            // 원점검색 진행율을 표시할 프로그래스바 설정
            prgHomeRate.Step = 1;
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
            int iHomeDir = 0;
            uint lHomeDir = 0;
            uint duRetCode, duLevel = 0, duOnOff = 0;
            uint duHomeSignal = 0, duZPhaseUse = 0;
            double dHomeClrTime = 0.0, dHomeOffset = 0.0;

            double dVelFirst = 100.0, dVelSecond = 50.0, dVelThird = 5.0, dVelLast = 1.0, dAccFirst = 400.0, dAccSecond = 100.0;

            // 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
            switch (m_uModuleID)
            {
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
                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("00: LOW");
                    cboHomeLevel.Items.Add("01: HIGH");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00: PosEndLimit");
                    cboHomeSignal.Items.Add("01: NegEndLimit");
                    cboHomeSignal.Items.Add("04: HomeSensor");
                    cboHomeSignal.Items.Add("05: EncodZPhase");
                    
                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = true;
                    cboZphaseUse.Items.Add("00: DISABLE");
                    cboZphaseUse.Items.Add("01: DIR_CHOME");
                    cboZphaseUse.Items.Add("02: DIR_HOME");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04A4:
                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("01: HIGH");
                    cboHomeLevel.Items.Add("02: UNUSED");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00: PosEndLimit");
                    cboHomeSignal.Items.Add("01: NegEndLimit");
                    cboHomeSignal.Items.Add("04: HomeSensor");

                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = true;
                    cboZphaseUse.Items.Add("00: DISABLE");
                    cboZphaseUse.Items.Add("01: DIR_CHOME");
                    cboZphaseUse.Items.Add("02: DIR_HOME");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIIPM:
                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = false;
                    cboHomeLevel.Items.Add("01: HIGH");
                    cboHomeLevel.Items.Add("02: UNUSED");

                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = false;
                    cboZphaseUse.Items.Add("00: DISABLE");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = false;
                    cboHomeSignal.Items.Add("04: HomeSensor");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIISV:
                case (uint)AXT_MODULE.AXT_SMC_R1V04SIIIHMIV:
                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = false;
                    cboHomeLevel.Items.Add("01: HIGH");
                    cboHomeLevel.Items.Add("02: UNUSED");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00: PosEndLimit");
                    cboHomeSignal.Items.Add("01: NegEndLimit");
                    cboHomeSignal.Items.Add("04: HomeSensor");

                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = true;
                    cboZphaseUse.Items.Add("00: DISABLE");
                    cboZphaseUse.Items.Add("01: DIR_CHOME");
                    cboZphaseUse.Items.Add("02: DIR_HOME");
                    break;

                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICL:
                case (uint)AXT_MODULE.AXT_SMC_R1V04MLIICR:
                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00: PosEndLimit");
                    cboHomeSignal.Items.Add("01: NegEndLimit");
                    cboHomeSignal.Items.Add("04: HomeSensor");

                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = true;
                    cboZphaseUse.Items.Add("00: DISABLE");
                    cboZphaseUse.Items.Add("01: DIR_CHOME");
                    cboZphaseUse.Items.Add("02: DIR_HOME");
                    break;

                case (uint)AXT_MODULE.AXT_ECAT_MOTION:
                    cboHomeLevel.Items.Clear();
                    cboHomeLevel.Enabled = true;
                    cboHomeLevel.Items.Add("00: LOW");
                    cboHomeLevel.Items.Add("01: HIGH");

                    cboHomeSignal.Items.Clear();
                    cboHomeSignal.Enabled = true;
                    cboHomeSignal.Items.Add("00: PosEndLimit");
                    cboHomeSignal.Items.Add("01: NegEndLimit");
                    cboHomeSignal.Items.Add("04: HomeSensor");
                    cboHomeSignal.Items.Add("05: EncodZPhase");
                    
                    cboZphaseUse.Items.Clear();
                    cboZphaseUse.Enabled = true;
                    cboZphaseUse.Items.Add("00: DISABLE");
                    cboZphaseUse.Items.Add("01: DIR_CHOME");
                    cboZphaseUse.Items.Add("02: DIR_HOME");

                    break;
            }
            //++ 지정한 축의 서보온 상태를 반환합니다.
            CAXM.AxmSignalIsServoOn(m_lAxisNo, ref duOnOff);
            chkServoOn.Checked = Convert.ToBoolean(duOnOff);

            //++ 선택한 축의 원점신호 Active Level 설정값을 확인합니다.
            duRetCode = CAXM.AxmHomeGetSignalLevel(m_lAxisNo, ref duLevel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) duLevel = (uint)AXT_MOTION_LEVEL_MODE.UNUSED;
            ConvertAxmToCombo(ref cboHomeLevel, ref duLevel);

            //++ 선택한 축의 원점검출 속도 설정값을 확인합니다.
            duRetCode = CAXM.AxmHomeGetVel(m_lAxisNo, ref dVelFirst, ref dVelSecond, ref dVelThird, ref dVelLast, ref dAccFirst, ref dAccSecond);
            edtVelFirst.Value    = Convert.ToDecimal(dVelFirst);
            edtVelSecend.Value   = Convert.ToDecimal(dVelSecond);
            edtVelThird.Value    = Convert.ToDecimal(dVelThird);
            edtVelLast.Value     = Convert.ToDecimal(dVelLast);
            edtAccFirst.Value    = Convert.ToDecimal(dAccFirst);
            edtAccSecond.Value   = Convert.ToDecimal(dAccSecond);

            //++ 선택한 축의 원점검출 방법 설정값을 확인합니다.
            duRetCode = CAXM.AxmHomeGetMethod(m_lAxisNo, ref iHomeDir, ref duHomeSignal, ref duZPhaseUse, ref dHomeClrTime, ref dHomeOffset);
            lHomeDir = (uint)iHomeDir;
            ConvertAxmToCombo(ref cboHomeDir, ref lHomeDir);
            ConvertAxmToCombo(ref cboZphaseUse, ref duZPhaseUse);
            ConvertAxmToCombo(ref cboHomeSignal, ref duHomeSignal);

            edtHomeClrTime.Value = Convert.ToDecimal(dHomeClrTime);
            edtHomeOffset.Value  = Convert.ToDecimal(dHomeOffset);
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

        // ++ =======================================================================
        // >> TranslateHomeResult(...) : 지정한 원점검색 결과에 해당하는 문자열을 반환
        //    하는 함수.
        //  - "AXHS.h"에 정의되어있는 AXT_MOTION_HOME_RESULT 구조체를 기반으로 합니다.
        // --------------------------------------------------------------------------
        public String TranslateHomeResult(uint duHomeResult)
        {
            switch (duHomeResult){
                case (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS:         m_strResult = ("[01H] HOME_SUCCESS");       break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING:       m_strResult = ("([02H] HOME_SEARCHING");    break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_GNT_RANGE:   m_strResult = ("[10H] HOME_ERR_GNT_RANGE"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_USER_BREAK:  m_strResult = ("[11H] HOME_ERR_USER_BREAK");break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_VELOCITY:    m_strResult = ("[12H] HOME_ERR_VELOCITY");  break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_AMP_FAULT:   m_strResult = ("[13H] HOME_ERR_AMP_FAULT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_NEG_LIMIT:   m_strResult = ("[14H] HOME_ERR_NEG_LIMIT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_POS_LIMIT:   m_strResult = ("[15H] HOME_ERR_POS_LIMIT"); break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_NOT_DETECT:  m_strResult = ("[16H] HOME_ERR_NOT_DETECT");break;
                case (uint)AXT_MOTION_HOME_RESULT.HOME_ERR_UNKNOWN:     m_strResult = ("[FFH] HOME_ERR_UNKNOWN");   break;
            }
            return m_strResult;
        }
    }
}