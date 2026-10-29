// TriggerSettingBlockDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 비젼트리거 함수들중 모션 구동중 트리거 시작위치에서 일정한 
//    간격으로 트리거를 발생시키고 종료 위치를 만나면 트리거 출력을 정지하는 방식의 
//    AxmTriggerSetBlock함수 사용법과 기능을 테스트하는 예제입니다. 
// >> [중요]: Block 트리거에 대해서
//     1) 이 함수는 모션 콘트롤 칩의 트리거 기능을 사용하므로 구동속도에 영향을 
//        받지않습니다.
//     2) 한번 설정하면 Reset하기 전에는 해당영역을 지날 때 계속 트리거가 발생됩니다.
//     3) 트리거 설정범위는 트리거 영역의 개념으로 구동방향에 상관없이 해당영역에
//        진입하면 트리거가 발생됩니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public enum AXT_INTERRUPT_CLASS : uint
{
    KIND_MESSAGE,
}

namespace TriggerSettingBlock
{
    public partial class TriggerSettingBlock : Form
    {
        private        int m_lAxisNo     = 0;                       // 제어 가능한 축갯수 선언 및 초기화
        public         int m_lAxisCounts = 0;                       // 제어할 축 번호 선언 및 초기화
        public        uint m_uModuleID   = 0;                       // 제어할 축의 모듈 I/O 선언 및 초기화 
        public        uint m_duOldResult = 0;                       // tmTimer에서 사용할 이전 Command Position 선언 및 초기화
        public         int m_lBoardNo    = 0, m_lModulePos   = 0;
        public static uint g_lIntCount	 = 0, g_lIntCountOld = 0;

        public TriggerSettingBlock()
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
        private void TriggerSettingBlock_Load(object sender, EventArgs e)
        {
            initLibrary();                                         // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                         // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                         // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            double dCmdPos = 0.0;
            double dActPos = 0.0;
            double dCmdVel = 0.0;

            CAXM.AxmStatusGetCmdPos(m_lAxisNo, ref dCmdPos);
            CAXM.AxmStatusGetActPos(m_lAxisNo, ref dActPos);
            CAXM.AxmStatusReadVel(m_lAxisNo, ref dCmdVel);

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            edtCmdPos.Text = String.Format("{0:0.000}", dCmdPos);
            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            edtActPos.Text = String.Format("{0:0.000}", dActPos);
            //++ 지정한 축의 구동 속도를 반환합니다.
            edtCmdVel.Text = String.Format("{0:0.000}", dCmdVel);

            // 인터럽트 발생 카운터값을 출력합니다.
            if (g_lIntCountOld != g_lIntCount)
            {
                edtIntCount.Text = Convert.ToString(g_lIntCount);
                g_lIntCountOld = g_lIntCount;
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
        // >> rdoAbsRel_Click(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
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

        // ++ =======================================================================
        // >> btnPosSet_Click() : "Position Setting"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 축의 위치정보를 지정한 값으로 설정합니다.
        //  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
        //    사용하는것과 동일한 효과를 냅니다.
        // --------------------------------------------------------------------------
        private void btnPosSet_Click(object sender, EventArgs e)
        {
            double dSetPos;

            dSetPos = Convert.ToDouble(edtSetPos.Text);
            //AxmStatusSetCmdPos(m_lAxisNo, dSetPos);
            //AxmStatusSetActPos(m_lAxisNo, dSetPos);
            //++ Command위치와 Actual위치를 지정한 값으로 설정합니다.
            CAXM.AxmStatusSetPosMatch(m_lAxisNo, dSetPos);
        }

        // ++ =======================================================================
        // >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint duOnOff;
            duOnOff = (uint)Convert.ToInt32(chkServoOn.Checked);
            //++ 지정 축의 Servo On/Off 신호를 출력합니다.
            CAXM.AxmSignalServoOn(m_lAxisNo, duOnOff);
        }

        // ++ =======================================================================
        // >> OnBtnPosMove() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축을 "Target Position" Edit콘트롤에 입력된 거리(또는 위치)/속도/
        //    가속도/감속도로 모션구동합니다.
        // --------------------------------------------------------------------------
        private void btnMove1_Click(object sender, EventArgs e)
        {
            double dMovePos, dMoveVel, dMoveAcc, dMoveDec;

            dMovePos = Convert.ToDouble(edtMovePos.Text);
            dMoveVel = Convert.ToDouble(edtMoveVel.Text);
            dMoveAcc = Convert.ToDouble(edtMoveAccDec.Text);
            dMoveDec = dMoveAcc;

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
            CAXM.AxmMoveStartPos(m_lAxisNo, dMovePos, dMoveVel, dMoveAcc, dMoveDec);	
        }

        // ++ =======================================================================
        // >> OnBtnPosStop() : "Move SStop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축에 구동정지 함수를 호출하여 구동을 감속정지합니다.
        // --------------------------------------------------------------------------
        private void btnSStop_Click(object sender, EventArgs e)
        {
            //++ 지정한 축의 구동을 감속정지합니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> OnBtnSetMethod() : "Set Method"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축에 트리거 펄스출력 시간, 트리거 레벨, 인터럽트사용 유무를 설정하고
        //    트리거 기능을 활성화/비활성화 시킵니다.
        // --------------------------------------------------------------------------
        private void btnSetMethod_Click(object sender, EventArgs e)
        {
            String strData;
            double dTrigTime;
            uint duRetCode, duTrigLevel, duTrigTarget, duIntUse;

            dTrigTime    = Convert.ToDouble(edtTrigTime.Value);            
            duTrigLevel  = ConvertComboToAxm(ref cboTrigLevel);
            duTrigTarget = ConvertComboToAxm(ref cboTrigTarget);
            duIntUse     = ConvertComboToAxm(ref cboIntUse);

            //++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 설정합니다.
            duRetCode = CAXM.AxmTriggerSetTimeLevel(m_lAxisNo, dTrigTime, duTrigLevel, duTrigTarget, duIntUse);

            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                strData = String.Format("AxmTriggerSetTimeLevel return error[Code:{0:d}]", duRetCode);
                MessageBox.Show(strData);
            }

            if (duIntUse == 1){
                uint uEvent = 0;
                //++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
                CAXM.AxmInterruptSetAxis(m_lAxisNo, (uint)this.Handle, (uint)AXT_EVENT.WM_AXL_INTERRUPT, null, ref uEvent);
                //++ AXL라이브러리의 인터럽트 발생을 허용합니다.
                CAXL.AxlInterruptEnable();
                //++ 지정한 축에 인터럽트 발생을 허용합니다.
                CAXM.AxmInterruptSetAxisEnable(m_lAxisNo, (uint)AXT_USE.ENABLE);
            }else{
                //++ AXL라이브러리의 인터럽트 발생을 금지합니다.
                CAXL.AxlInterruptDisable();
                //++ 지정한 축에 인터럽트 발생을 금지합니다.
                CAXM.AxmInterruptSetAxisEnable(m_lAxisNo, (uint)AXT_USE.DISABLE);
            }
        }

        // ++ =======================================================================
        // >> chkSetBlock_Click() : "Set Block"버튼 클릭시 호출되는 핸들러 함수.
        //  - Block트리거 함수를 설정합니다.
        //  - AxmTriggerSetReset함수로 트리거 설정을 해제하면 트리거가 발생되지않습니다.
        // --------------------------------------------------------------------------
        private void chkSetBlock_Click(object sender, EventArgs e)
        {
            uint   duRetCode;
            double dStartPos, dEndPos, dPeriod;

            if (chkSetBlock.Checked)
            {
                dStartPos = Convert.ToDouble(edtTrigStartPos.Text);
                dEndPos = Convert.ToDouble(edtTrigEndPos.Text);
                dPeriod = Convert.ToDouble(edtTrigPeriod.Text);

                //++ 사용자가 지정한 하한영역 위치부터 상한영역 위치까지 지정한 간격으로 트리거를 출력합니다.
                // - 한번 설정한 트리거 영역은 트리거 발생여부와 상관없이 AxmTriggerSetReset함수로 트리거 설정을
                //   해제하기 전 까지 유효합니다.
                duRetCode = CAXM.AxmTriggerSetBlock(m_lAxisNo, dStartPos, dEndPos, dPeriod);

                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    chkSetBlock.Checked = false;
                    MessageBox.Show(String.Format("AxmTriggerSetBlock return error[Code:{0:d}]", duRetCode));
                }
                g_lIntCount = 0;
            }else{
                //++ 트리거 발생영역을 해제 합니다.
                duRetCode = CAXM.AxmTriggerSetReset(m_lAxisNo);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    chkSetBlock.Checked = true;
                    MessageBox.Show(String.Format("AxmTriggerSetReset return error[Code:{0:d}]", duRetCode));
                }
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
                    default:                               strAxis = String.Format("{0:00}-[Unknown] : Not support", i);    break;
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

            // Edit Control에 초기값 설정
            edtSetPos.Text     = "0.000";
            edtMovePos.Text    = "100.000";
            edtMoveVel.Text    = "100.000";
            edtMoveAccDec.Text = "400.000";
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
            uint duAbsRelMode = 0;
            double dTrigTime = 1000.0;
            double dStartPos = 0.0, dEndPos = 0.0, dPeriod = 0.0;
            uint duTrigLevel = 1, duTrigTarget = 0, duIntUse = 0, uOnOff = 0;

            //++ 지정한 축의 서보온 상태를 반환합니다.
            CAXM.AxmSignalIsServoOn(m_lAxisNo, ref uOnOff);
            chkServoOn.Checked = Convert.ToBoolean(uOnOff);

            //++ 지정 축의 구동 좌표계를 확인합니다. 
            // dwAbsRelMode : (0)POS_ABS_MODE - 현재 위치와 상관없이 지정한 위치로 절대좌표 이동합니다.
            //                (1)POS_REL_MODE - 현재 위치에서 지정한 양만큼 상대좌표 이동합니다.
            CAXM.AxmMotGetAbsRelMode(m_lAxisNo, ref duAbsRelMode);
            if (duAbsRelMode == 1){
                rdoAbs.Checked = false; rdoRel.Checked = true;
            }else if (duAbsRelMode == 0){
                rdoAbs.Checked = true;  rdoRel.Checked = false;                
            }

            //++ 지정 축에 트리거 펄스출력 시간 및 트리거 출력 레벨, 트리거 출력방법을 확인합니다.
            CAXM.AxmTriggerGetTimeLevel(m_lAxisNo, ref dTrigTime, ref duTrigLevel, ref duTrigTarget, ref duIntUse);
            edtTrigTime.Value = Convert.ToDecimal(dTrigTime);
            ConvertAxmToCombo(ref cboTrigLevel, ref duTrigLevel);
            ConvertAxmToCombo(ref cboTrigTarget, ref duTrigTarget);
            ConvertAxmToCombo(ref cboIntUse, ref duIntUse);

            //++ 지정 축에 설정된 Block 트리거 하한영역, 상한영역, 트리거 간격으로 트리거을 확인합니다.
            duTrigLevel = CAXM.AxmTriggerGetBlock(m_lAxisNo, ref dStartPos, ref dEndPos, ref dPeriod);            
            edtTrigStartPos.Text = String.Format("{0:0.000}", dStartPos);
            edtTrigEndPos.Text   = String.Format("{0:0.000}", dEndPos);
            edtTrigPeriod.Text   = String.Format("{0:0.000}", dPeriod);         
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
        // >> InterruptProc(...) : Message, Callback, Event 메세지를 ListBox에 입력 하는 함수
        //  - 인터럽트 정보를 받아 Count++을 합니다.
        // --------------------------------------------------------------------------
        private bool InterruptProc(AXT_INTERRUPT_CLASS uClass, int nAxisNo, uint nIntrFlag)
        {
            int nInterFlag = (int)nIntrFlag;						// Interrupt generation axis location.

            switch (uClass){
                case AXT_INTERRUPT_CLASS.KIND_MESSAGE:
                    g_lIntCount++;
                    return true;
                default:
                    break;
            }
            return true;
        }

        // ++ =======================================================================
        // >> WndProc(...) : 인터럽트 메시지 핸들러 함수.
        //  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
        //    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
        // --------------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)AXT_EVENT.WM_AXL_INTERRUPT:
                    InterruptProc(AXT_INTERRUPT_CLASS.KIND_MESSAGE, (int)m.WParam, (uint)m.LParam);
                    break;
            }
            base.WndProc(ref m);
        }
    }
}