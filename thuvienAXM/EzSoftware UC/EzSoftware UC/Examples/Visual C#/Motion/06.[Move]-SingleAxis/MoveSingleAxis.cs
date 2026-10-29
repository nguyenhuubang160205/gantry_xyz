// MoveSingleAxisDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 단축구동 관련 함수들의 사용법을 익히고 단축구동에 필요한
//    기본 파라메타 설정 및 구동을 학습하는 예제입니다.
// >> [중요]: 단축 구동관련 설정함수들
//     1) AxmMotSetMoveUnitPerPulse 함수는 거리/속도/가감속도의 단위를 설정합니다.
//     2) AxmMotSetAbsRelMode 함수는 구동 좌표계(절대좌표/상대좌표)를 설정합니다. 
//     3) AxmMotSetProfileMode 함수는 구동 프로파일 형태를 설정합니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MoveSingleAxis
{
    public partial class MoveSingleAxis : Form
    {
        public  int m_lAxisCounts = 0;                          // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                          // 제어할 축 번호 선언 및 초기화
        public  uint m_uModuleID   = 0;                         // 제어할 축의 모듈 I/O 선언 및 초기화 
        public  int m_lBoardNo    = 0, m_lModulePos = 0;

        private static MoveSingleAxis m_formMotion;

        private Thread[] m_hTestThread = new Thread[64];
        private bool[]   m_bTestActive = new bool[64];

        public MoveSingleAxis()
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
        private void FormMotion_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
            m_formMotion = this;
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmTimer_Tick(object sender, EventArgs e)
        {
            double dCmdPos = 0.0, dCmdVel = 0.0, dActPos = 0.0;

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            CAXM.AxmStatusGetCmdPos(m_lAxisNo, ref dCmdPos);
            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            CAXM.AxmStatusGetActPos(m_lAxisNo, ref dActPos);
            //++ 지정한 축의 구동 속도를 반환합니다.
            CAXM.AxmStatusReadVel(m_lAxisNo, ref dCmdVel);

            edtCmdPos.Text = String.Format("{0:0.000}", dCmdPos);
            edtActPos.Text = String.Format("{0:0.000}", dActPos);
            edtCmdVel.Text = String.Format("{0:0.000}", dCmdVel);
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
        // >> btnPosClear_Click() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들의 위치정보를 0.0으로 설정합니다.
        //  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
        //    사용하는것과 동일한 효과를 냅니다.
        // --------------------------------------------------------------------------
        private void btnPosClear_Click(object sender, EventArgs e)
        {
            //CAXM.AxmStatusSetCmdPos(m_lAxisNo, 0);
            //CAXM.AxmStatusSetActPos(m_lAxisNo, 0);
            //++ Command위치와 Actual위치를 입력한 값으로 설정합니다.
            CAXM.AxmStatusSetPosMatch(m_lAxisNo, 0.0);    
        }

        // ++ =======================================================================
        // >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint duOnOff;

            //++ 지정 축의 Servo On/Off 신호를 출력합니다.
            duOnOff = (uint)Convert.ToInt32(chkServoOn.Checked);
            CAXM.AxmSignalServoOn(m_lAxisNo, duOnOff);
        }

        // ++ =======================================================================
        // >> cboProfile(...) : "Velocity Profile Set" ComboBox 콘트롤 Item선택 
        //    변경시 호출되는 핸들러 함수.
        //  - 지정한 축의 구동 프로파일을 설정합니다.
        // --------------------------------------------------------------------------
        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint duRetCode     = 0;
            uint SelVelProfile = 0;

            SelVelProfile = ConvertComboToAxm(ref cboProfile);

            //++ 지정 축의 구동 속도 프로파일 모드를 설정한다.
            // 0: SYM_TRAPEZOID_MODE  - Symmetric Trapezoid
            // 1: ASYM_TRAPEZOID_MODE - Asymmetric Trapezoid
            // 3: SYM_S_CURVE_MODE    - Symmetric S Curve
            // 4: ASYM_S_CURVE_MODE   - Asymmetric S Curve
            duRetCode = CAXM.AxmMotSetProfileMode(m_lAxisNo, SelVelProfile);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMotSetProfileMode return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> rdoAbs_CheckedChanged(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축의 구동 좌표계를 설정합니다.
        //  - 설정된 좌표계에 따라 구동 함수들에 전달되는 dPos의 값은 절대위치 또는 
        //    상대 이동량이 됩니다.
        //  - Ex1) 현재 Command위치 100으로 가정
        //     1) AxmMotSetAbsRelMode(0, POS_ABS_MODE)
        //     2) AxmMoveStartPos(0, 200, ...)
        //     -> Command위치 기준 200 위치로 이동, 즉 (+)방향으로 100만큼 이동함
        //  - Ex2) 현재 Command위치 100으로 가정
        //     1) AxmMotSetAbsRelMode(0, POS_REL_MODE)
        //     2) AxmMoveStartPos(0, 200, ...)
        //     -> Command위치 기준 300 위치로 이동, 즉 (+)방향으로 200만큼 이동함
        // --------------------------------------------------------------------------
        private void rdoAbsRel_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;

            //++ 지정 축의 구동 좌표계를 설정합니다. 
            // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            duRetCode = CAXM.AxmMotSetAbsRelMode(m_lAxisNo, Convert.ToUInt32(((RadioButton)sender).Tag));
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMotSetAbsRelMode return error[Code:{0:d}]", duRetCode));

        }

        private void rdoAbs_CheckedChanged(object sender, EventArgs e)
        {
        }

        // ++ =======================================================================
        // >> btnMove1_Click() : "Move Target 1"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축을 "Target Position 1" Edit콘트롤에 입력된 거리(또는 위치)/속도/
        //    가속도/감속도로 모션구동합니다.
        // --------------------------------------------------------------------------
        private void btnMove1_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            double dPosition1 = Convert.ToDouble(edtPos1.Value);
            double dVelocity  = Convert.ToDouble(edtMoveVel.Value);
            double dAccel     = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel     = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            duRetCode = CAXM.AxmMoveStartPos(m_lAxisNo, dPosition1, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartPos return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> btnMove2_Click() : "Move Target 2"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축을 "Target Position 2" Edit콘트롤에 입력된 거리(또는 위치)/속도/
        //    가속도/감속도로 모션구동합니다.
        // --------------------------------------------------------------------------
        private void btnMove2_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            double dPosition2 = Convert.ToDouble(edtPos2.Value);
            double dVelocity  = Convert.ToDouble(edtMoveVel.Value);
            double dAccel     = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel     = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            duRetCode = CAXM.AxmMoveStartPos(m_lAxisNo, dPosition2, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartPos return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> btnSStop_Click() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
        // --------------------------------------------------------------------------
        private void btnSStop_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;

            if (m_bTestActive[m_lAxisNo] == true){
                //++ 지정한 축의 구동을 감속정지합니다.
                duRetCode = CAXM.AxmMoveSStop(m_lAxisNo);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmMoveSStop return error[Code:{0:d}]", duRetCode));
                m_bTestActive[m_lAxisNo] = false;
            }else{
                //++ 지정한 축의 구동을 감속정지합니다.
                duRetCode = CAXM.AxmMoveSStop(m_lAxisNo);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmMoveSStop return error[Code:{0:d}]", duRetCode));                
            }
        }

        // ++ =======================================================================
        // >> btnJogPX_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // --------------------------------------------------------------------------
        private void btnJogPX_MouseDown(object sender, MouseEventArgs e)
        {
            uint duRetCode   = 0;

            double dVelocity = Math.Abs(Convert.ToDouble(edtJogVel.Value));
            double dAccel    = Math.Abs(Convert.ToDouble(edtJogAcc.Value));
            double dDecel    = Math.Abs(Convert.ToDouble(edtJogDec.Value));

            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            duRetCode = CAXM.AxmMoveVel(m_lAxisNo, dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveVel return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> btnJogPX_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnJogPX_MouseUp(object sender, MouseEventArgs e)
        {
            //++ 지정한 축의 Jog구동(모션구동)을 종료합니다.  
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnJogNX_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // --------------------------------------------------------------------------
        private void btnJogNX_MouseDown(object sender, MouseEventArgs e)
        {
            uint duRetCode   = 0;

            double dVelocity = Math.Abs(Convert.ToDouble(edtJogVel.Value));
            double dAccel    = Math.Abs(Convert.ToDouble(edtJogAcc.Value));
            double dDecel    = Math.Abs(Convert.ToDouble(edtJogDec.Value));

            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            duRetCode = CAXM.AxmMoveVel(m_lAxisNo, -dVelocity, dAccel, dDecel);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveVel return error[Code:{0:d}]", duRetCode));
        }

        // ++ =======================================================================
        // >> btnJogPX_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnJogNX_MouseUp(object sender, MouseEventArgs e)
        {
            //++ 지정한 축의 Jog구동(모션구동)을 종료합니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnRepeat_Click(...) : "<< Repeat >>"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축에 지정된 Position을 이용하여 Repeat 구동을 합니다.
        // --------------------------------------------------------------------------
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            if ((m_hTestThread[m_lAxisNo] == null) && (m_bTestActive[m_lAxisNo] == false))
            {
                // Thread Setting
                m_hTestThread[m_lAxisNo] = new Thread(new ParameterizedThreadStart(RepeatThread));
                m_hTestThread[m_lAxisNo].IsBackground = true;
                m_hTestThread[m_lAxisNo].Start(m_lAxisNo);
                m_bTestActive[m_lAxisNo] = true;
    		}else{
                MessageBox.Show("Already Moving");
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
            // Edit Control에 초기값 설정
            edtPos1.Value    = Convert.ToDecimal("0.000");
            edtPos2.Value    = Convert.ToDecimal("100.000");
            edtMoveVel.Value = Convert.ToDecimal("100.000");
            edtMoveAcc.Value = Convert.ToDecimal("400.000");
            edtMoveDec.Value = Convert.ToDecimal("400.000");
            edtJogVel.Value  = Convert.ToDecimal("100.000");
            edtJogAcc.Value  = Convert.ToDecimal("400.000");
            edtJogDec.Value  = Convert.ToDecimal("400.000");
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
            uint uAbsRel = 0, uProfile = 0, uOnOff = 0;

            cboSelAxis.SelectedIndex = m_lAxisNo;

            //++ 지정한 축의 서보온 상태를 반환합니다.
            CAXM.AxmSignalIsServoOn(m_lAxisNo, ref uOnOff);
            chkServoOn.Checked = Convert.ToBoolean(uOnOff);

            //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
            CAXM.AxmMotGetAbsRelMode(m_lAxisNo, ref uAbsRel);
            if (uAbsRel == 1){
                rdoAbs.Checked = false; rdoRel.Checked = true;
            }else{
                rdoAbs.Checked = true;  rdoRel.Checked = false;
            }
            //++ 지정한 축의 구동 프로파일 설정값을 확인합니다.
            CAXM.AxmMotGetProfileMode(m_lAxisNo, ref uProfile);
            if (uProfile > 2) cboProfile.SelectedIndex = (int)uProfile - 1;
            else cboProfile.SelectedIndex = (int)uProfile;
            
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
        // >> RepeatThread() : 지정한 축의 Repeat 구동을 위한 쓰레드 함수
        //  - Repeat 구동시 호출되는 쓰레드 함수 입니다.
        // --------------------------------------------------------------------------
        private void RepeatThread(Object objData)
        {
            uint uBusyStatus = 0;

            double dCurPos = 0.0;
            uint uMode = 0;
            int nAxis = (int)objData;
            double dPosition = Convert.ToDouble(edtPos1.Value);
            double dVelocity = Convert.ToDouble(edtMoveVel.Value);
            double dAccel = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            CAXM.AxmStatusGetCmdPos(nAxis, ref dCurPos);
            CAXM.AxmMotGetAbsRelMode(nAxis, ref uMode);

            // Re-setup of the maximum value in chart for displaying running speed of each axis on the chart.

            while (m_formMotion.m_bTestActive[nAxis] == true){
                CAXM.AxmMoveStartPos(nAxis, dPosition, dVelocity, dAccel, dDecel);
                do{
                    CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
                    Thread.Sleep(1);
                }while ((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));

                if (m_formMotion.m_bTestActive[nAxis] == false) break;

                if (uMode == (uint)AXT_MOTION_ABSREL.POS_ABS_MODE){
                    if (dCurPos == dPosition) break;
                    CAXM.AxmMoveStartPos(nAxis, dCurPos, dVelocity, dAccel, dDecel);
                }else{
                    if (0 == dPosition) break;
                    CAXM.AxmMoveStartPos(nAxis, -dPosition, dVelocity, dAccel, dDecel);
                }
                do{
                    CAXM.AxmStatusReadInMotion(nAxis, ref uBusyStatus);
                    Thread.Sleep(1);
                } while ((m_formMotion.m_bTestActive[nAxis] == true) && (uBusyStatus != 0));
            }
            m_formMotion.m_bTestActive[nAxis] = false;
            m_formMotion.m_hTestThread[nAxis] = null;
        }
    }
}