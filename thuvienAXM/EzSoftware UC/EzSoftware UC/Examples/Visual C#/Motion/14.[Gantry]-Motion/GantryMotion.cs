// GantryMotion.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 겐트리 함수들의 사용법을 읽히고 겐트리 기구물에서의 
//    원점검색 및 Slave축 Offset 설정 방법등에 대해 학습하는 예제입니다.
// >> [중요]: 겐트리 Slave축 Offset설정방법 
//     1) AxmGantrySetEnable함수의 uSlHomeUse인자를 2로 설정해서 원점검색을 합니다. 
//     2) 원점검색이 정상적으로 완료되면 Slave축 원점위치에서 Master축 원점
//        위치까지의 차이값이(Offset) Master축 지령위치가 됩니다.
//     3) AxmGantrySetEnable함수의 uSlHomeUse인자를 1로, dSlaveHmOffset인자에
//        위에서 측정한 Master축 지령위치값에 부호를 변경한 후 설정하면됩니다. 
// **************************************************************************


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GantryMotion
{
    public partial class GantryMotion : Form
    {
        public  int m_lAxisCounts = 0;                      // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo = 0;                          // 제어할 축 번호 선언 및 초기화
        private int m_lAxisNoMa = 0, m_lAxisNoSl = 0;       // Gantry Master/Slave 축 번호 선언 초기화
        public uint m_uModuleID = 0;                        // 제어할 축의 모듈 I/O 선언 및 초기화     
        public uint m_duOldResult = 0;                      // tmTimer에서 사용할 이전 Command Position 선언 및 초기화
        String      m_strResult;                            // 홈검색 결과를 출력 변수 선언
        public  int m_lBoardNo = 0, m_lModulePos = 0;

        public GantryMotion()
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

        private void GantryMotion_Load(object sender, EventArgs e)
        {
            initLibrary();                                   // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                   // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                   // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            double dSlOffset = 0.0, dSlORange = 0.0;
            uint   uSlHomeUse= 0, uState = 0;
            double dCmdPosMa = 0.0, dCmdPosSl = 0.0;
            double dActPosMa = 0.0, dActPosSl = 0.0;
            double dCmdVelMa = 0.0, dCmdVelSl = 0.0;

            //++ 지정한 축의 지령(Command)위치를 반환합니다.
            CAXM.AxmStatusGetCmdPos(m_lAxisNoMa, ref dCmdPosMa);
            //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
            CAXM.AxmStatusGetActPos(m_lAxisNoMa, ref dActPosMa);
            //++ 지정한 축의 구동 속도를 반환합니다.
            CAXM.AxmStatusReadVel(m_lAxisNoMa, ref dCmdVelMa);

            CAXM.AxmStatusGetCmdPos(m_lAxisNoSl, ref dCmdPosSl);
            CAXM.AxmStatusGetActPos(m_lAxisNoSl, ref dActPosSl);
            CAXM.AxmStatusReadVel(m_lAxisNoSl, ref dCmdVelSl);

            edtCmdPosMa.Text = String.Format("{0:0.000}", dCmdPosMa);
            edtActPosMa.Text = String.Format("{0:0.000}", dActPosMa);
            edtCmdVelMa.Text = String.Format("{0:0.000}", dCmdVelMa);
            edtCmdPosSl.Text = String.Format("{0:0.000}", dCmdPosSl);
            edtActPosSl.Text = String.Format("{0:0.000}", dActPosSl);
            edtCmdVelSl.Text = String.Format("{0:0.000}", dCmdVelSl);

            CAXM.AxmGantryGetEnable(m_lAxisNoMa, ref uSlHomeUse, ref dSlOffset, ref dSlORange, ref uState);
            if(uState == (uint)AXT_USE.ENABLE) lblGantryState.Text = "∞";
            else                       lblGantryState.Text = " ";  
        }

        // ++ =======================================================================
        // >> tmHomeInfo_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 홈 검색시 홈검색 진행률 및 상태를 읽어와서 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmHomeInfo_Tick(object sender, EventArgs e)
        {
            uint duRetCode,      duState = 0;
            uint duStepMain = 0, duStepSub = 0;

            //++ 지정한 축의 원점신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmHomeReadSignal(m_lAxisNoMa, ref duState);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) chkHomeStateMa.Checked = Convert.ToBoolean(duState);

            //++ 지정한 축의 원점신호의 상태를 확인합니다.
            duRetCode = CAXM.AxmHomeReadSignal(m_lAxisNoSl, ref duState);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) chkHomeStateSl.Checked = Convert.ToBoolean(duState);

            //++ 지정한 축의 원점검색 결과를 확인합니다
            CAXM.AxmHomeGetResult(m_lAxisNo, ref duState);
            if (m_duOldResult != duState){
                labelHomeSearch.Text = TranslateHomeResult(duState);
                m_duOldResult = duState;
            }
            //++ 지정한 축의 원점검색 진행율을 확인합니다.
            duRetCode = CAXM.AxmHomeGetRate(m_lAxisNo, ref duStepMain, ref duStepSub);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                labelHomeStepMain32.Text = Convert.ToString(duStepMain);
                labelHomeStepSub33.Text = Convert.ToString(duStepSub);
                prgHomeRate.Value = (int)duStepSub;
            }
        }

        // ++ =======================================================================
        // >> cboSelAxis_SelectedIndexChanged(...) : 축 번호 변경시 호출되는 핸들러 함수.
        //  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
        // -------------------------------------------------------------------------
        private void cboSelAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_lAxisNo = cboSelAxis.SelectedIndex;       // 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.
            m_lAxisNoMa = (m_lAxisNo / 2) * 2;          // 선택된 축번호로 겐트리 Master축 번호 생성
            m_lAxisNoSl = m_lAxisNoMa + 1;              // 선택된 축번호로 겐트리 Slave축 번호 생성 

            //++ 지정한 축번호의 모듈ID를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);

            UpdateState();                          // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.	
        }

        // ++ =======================================================================
        // >> btnLoadFile_Click(...) : "Load File"버튼 클릭시 호출되는 핸들러 함수.
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
        //  - 선택된 겐트리 축들의 위치정보를 0.0으로 설정합니다.
        //  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
        //    사용하는것과 동일한 효과를 냅니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 축별로 동작합니다.
        // --------------------------------------------------------------------------
        private void btnPosClear_Click(object sender, EventArgs e)
        {
            uint duState = 0, duHomeUse = 0;
            double duOffSet = 0.0, duOffSetRange = 0.0;

            //++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
            CAXM.AxmGantryGetEnable(m_lAxisNoMa, ref duHomeUse, ref duOffSet, ref duOffSetRange, ref duState);

            if (duState == 1)
            {
                //++ Command위치와 Actual위치를 입력한 값으로 설정합니다.
                CAXM.AxmStatusSetPosMatch(m_lAxisNoMa, 0);
                CAXM.AxmStatusSetPosMatch(m_lAxisNoSl, 0);
            }
            else
            {
                CAXM.AxmStatusSetPosMatch(m_lAxisNo, 0);
            }
        }

        // ++ =======================================================================
        // >> chkServoOn_Click(...) : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 겐트리 축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어도 위치설정, 서보온등은 각 축별로 동작합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint duState = 0, duHomeUse = 0, duOnOff = 0;
            double duOffSet = 0.0, duOffSetRange = 0.0;

            duOnOff = Convert.ToUInt32(chkServoOn.Checked);
            //++ 지정 축이 Gantry축으로 활성화되었는지 확인합니다.
            CAXM.AxmGantryGetEnable(m_lAxisNoMa, ref duHomeUse, ref duOffSet, ref duOffSetRange, ref duState);
            if (duState == 1)
            {
                //++ 지정 축의 Servo On/Off 신호를 출력합니다.
                CAXM.AxmSignalServoOn(m_lAxisNoMa, duOnOff);
                CAXM.AxmSignalServoOn(m_lAxisNoSl, duOnOff);
            }
            else
            {
                CAXM.AxmSignalServoOn(m_lAxisNo, duOnOff);
            }
        }

        // ++ =======================================================================
        // >> rdoAbsRel_Click(...) : "Absolute/Relative"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축의 구동 좌표계를 설정합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어있으면 Master축의 설정값으로 좌표구동합니다.
        // --------------------------------------------------------------------------
        private void rdoAbsRel_Click(object sender, EventArgs e)
        {
            //++ 지정 축의 구동 좌표계를 설정합니다. (0: POS_ABS_MODE, 1: POS_REL_MODE)
            CAXM.AxmMotSetAbsRelMode(m_lAxisNo, Convert.ToUInt32(((RadioButton)sender).Tag));
        }

        // ++ =======================================================================
        // >> btnMovePos_Click() : "Move Target"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
        //  - 지정한 축이 겐트리 축으로 활성화되어 있으면 두축이 동기되어 구동됩니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
        //    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
        //    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
        // --------------------------------------------------------------------------
        private void btnMovePos_Click(object sender, EventArgs e)
        {
            // 각각의 Edit 콘트롤에서 설정값을 가져옴
            double dPosition = Convert.ToDouble(edtMovePos.Value);
            double dVelocity = Convert.ToDouble(edtMoveVel.Value);
            double dAccel = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            //++ 지정한 축을 지정한 거리(또는 위치)/속도/가속도로 모션구동합니다.
            //   겐트리 구동시 Master축이 구동하면 Slave 축은 동일하게 구동 됩니다.
            CAXM.AxmMoveStartPos(m_lAxisNo, dPosition, dVelocity, dAccel, dDecel);
        }

        // ++ =======================================================================
        // >> btnMoveStop_Click() : "Move Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축으로 구동정지 함수를 호출하여 구동을 종료합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
        //    또한 동기되어 자동정지됩니다.
        // --------------------------------------------------------------------------
        private void btnMoveStop_Click(object sender, EventArgs e)
        {
            //++ 지정한 축의 모션구동(Jog구동/원점검색구동)을 종료합니다.
            // [INFO] Master 축을 정지 하면 Slave축도 정지 됩니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
        //    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
        //    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
        // --------------------------------------------------------------------------
        private void btnJogMoveP_MouseDown(object sender, MouseEventArgs e)
        {
            double dVelocity = Math.Abs(Convert.ToDouble(edtMoveVel.Value));
            double dAccel    = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel    = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveVel(m_lAxisNo, dVelocity, dAccel, dDecel);
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
        //    또한 동기되어 자동정지됩니다.
        // --------------------------------------------------------------------------
        private void btnJogMoveP_MouseUp(object sender, MouseEventArgs e)
        {
            //++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 종료합니다.           
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 구동전 반드시 Master축과 Slave축을
        //    각각 서보온 해야됩니다. 만약 한쪽만 서보온 되어있을 경우 모터에(Ballscrew) 
        //    따라 기구물에 부하가 가해져 알람이 발생할 수 있습니다.
        // --------------------------------------------------------------------------
        private void btnJogMoveN_MouseDown(object sender, MouseEventArgs e)
        {
            double dVelocity = Math.Abs(Convert.ToDouble(edtMoveVel.Value));
            double dAccel    = Math.Abs(Convert.ToDouble(edtMoveAcc.Value));
            double dDecel    = Math.Abs(Convert.ToDouble(edtMoveDec.Value));

            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveVel(m_lAxisNo, -dVelocity, dAccel, dDecel);
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
        //    또한 동기되어 자동정지됩니다.
        // --------------------------------------------------------------------------
        private void btnJogMoveN_MouseUp(object sender, MouseEventArgs e)
        {
            //++ 지정한 축의 Jog구동(모션구동/원점검색구동)을 종료합니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnHomeStart_Click() : "Home Start"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축으로 원점검색을 시작합니다.
        // ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 두축 모두 서보온이
        //    되어있지 않을 경우 AxmGantrySetEnable 함수로 겐트리 기능을 활성활 할 때 설정한 
        //    dwSlaveHmUse의 값에 따라 원점검색이 완료되지 않을 수 있습니다.
        // ※ [CAUTION] 지정한 축이 겐트리 축으로 설정되어 있을경우 CAXM.AxmGantrySetEnable
        //    함수로 겐트리 기능을 활성활 할 때 설정한 dwSlaveHmUse의 값에 따라 원점검색
        //    방법이 달라집니다.
        // --------------------------------------------------------------------------
        private void btnHomeStart_Click(object sender, EventArgs e)
        {
            // 원점검색 레벨 변경이 필요할 때 주석을 해제해서 사용하세요.
            // - dwLevel: [00]AXT_MOTION_LEVEL_MODE.LOW, [01]AXT_MOTION_LEVEL_MODE.HIGH
            // > AxmHomeSetSignalLevel(m_lAxisNoMa, dwLevel);
            // > AxmHomeSetSignalLevel(m_lAxisNoSl, dwLevel);

            // 원점검색 방법설정 변경이 필요할 때 주석을 해제해서 사용하세요.
            // - lHomeDir     : [00]AXT_MOTION_MOVE_DIR.DIR_CCW, [01]AXT_MOTION_MOVE_DIR.DIR_CW
            // - dwHomeSignal : [00]AXT_MOTION_HOME_DETECT.PosEndLimit, [01]AXT_MOTION_HOME_DETECT.NegEndLimit, [04]AXT_MOTION_HOME_DETECT.HomeSensor
            // - dwZPhaseUse  : [00]Not Use, [01]Home Dir, [02]Not Home Dir
            // > CAXM.AxmHomeSetMethod(m_lAxisNoMa, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);
            // > CAXM.AxmHomeSetMethod(m_lAxisNoSl, lHomeDir, dwHomeSignal, dwZPhaseUse, dHomeClrTime, dHomeOffset);

            // 원점검색 속도설정 변경이 필요할 때 주석을 해제해서 사용하세요.
            // > CAXM.AxmHomeSetVel(m_lAxisNoMa, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);	
            // > CAXM.AxmHomeSetVel(m_lAxisNoSl, dVelFirst, dVelSecond, dVelThird, dVelLast, dAccFirst, dAccSecond);. 
            CAXM.AxmHomeSetStart(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> btnHomeStop_Click() : "Home Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축으로 구동정지 함수를 호출하여 원점검색구동을 종료합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
        //    또한 동기되어 자동정지됩니다.
        // --------------------------------------------------------------------------
        private void btnHomeStop_Click(object sender, EventArgs e)
        {
            //++ 지정한 축의 원점검색구동(모션구동/Jog구동)을 종료합니다.
            CAXM.AxmMoveSStop(m_lAxisNo);
        }

        // ++ =======================================================================
        // >> OnChkGantryEnable() : "Gantry Enable"버튼 클릭시 호출되는 핸들러 함수.
        //  - 지정한 축으로 겐트리 기능을 활성화 합니다.
        // ※ [CAUTION] 겐트리 축으로 설정되어 있을경우 Master축의 구동을 종료하면 Slave축
        //    또한 동기되어 자동정지됩니다.
        // --------------------------------------------------------------------------
        private void chkGantryEnable_Click(object sender, EventArgs e)
        {
            uint   duSlaveHmUse,   duRetCode;
            double dSlaveHmOffset, dSlaveHmRange;

            if (chkGantryEnable.Checked){
                duSlaveHmUse = ConvertComboToAxm(ref cboGantryHmSlaveUse);
                dSlaveHmOffset = Convert.ToDouble(edtGantryHmOffset.Text);
                dSlaveHmRange = Convert.ToDouble(edtGantryHmRange.Text);

                //++ 지정한 Master축과 Slave축으로 겐트리 기능을 활성화 시킵니다.
                //[INFO] 겐트리 제어 기능을 활성화 시키고 이후 Slave축에 구동 명령이나 정지 명령등을 내려도 모두 무시 됩니다.
                duRetCode = CAXM.AxmGantrySetEnable(m_lAxisNoMa, m_lAxisNoSl, duSlaveHmUse, dSlaveHmOffset, dSlaveHmRange);

                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    chkGantryEnable.Checked = false;
                    MessageBox.Show(String.Format("AxmGantrySetEnable return error[Code:{0:d}]", duRetCode));                    
                }
            }else{
                //++ 지정한 Master축과 Slave축으로 겐트리 기능을 비활성화 시킵니다.
                duRetCode = CAXM.AxmGantrySetDisable(m_lAxisNoMa, m_lAxisNoSl);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    chkGantryEnable.Checked = true;
                    MessageBox.Show(String.Format("AxmGantrySetDisable return error[Code:{0:d}]", duRetCode));                    
                }
            }
        }

        // ++ =======================================================================
        // >> Project Name_FormClosed(...) : 프로젝트 Form 종료 함수.
        //  - Form을 Close시 불러내는 함수, Form 종료시 사용됩니다.
        // --------------------------------------------------------------------------
        private void GantryMotion_FormClosed(object sender, FormClosedEventArgs e)
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
            m_lAxisNoMa = 0;
            m_lAxisNoSl = 1;	
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
                    default:                                        strAxis = String.Format("{0:0}-[Unknown]", i);            break;
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
            prgHomeRate.Step         = 1;

            // Edit Control에 초기값 설정
            edtMovePos.Text        = "100.000";
            edtMoveVel.Text        = "100.000";
            edtMoveAcc.Text        = "400.000";
            edtMoveDec.Text        = "400.000";
            edtGantryHmOffset.Text = "0.000";
            edtGantryHmRange.Text  = "100.000";
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
            uint   duAbsRelMode = 0;
            uint duSlaveHmUse = 0, duGantryOn = 0, uOnOff = 0;
            double dSlaveHmOffset = 0.0, dSlaveHmRange = 1.0;

            //++ 지정한 축의 서보온 상태를 반환합니다.
            CAXM.AxmSignalIsServoOn(m_lAxisNo, ref uOnOff);
            chkServoOn.Checked = Convert.ToBoolean(uOnOff);

            //++ 지정한 축의 구동 좌표계 설정값을 확인합니다.
            CAXM.AxmMotGetAbsRelMode(m_lAxisNo, ref duAbsRelMode);

            if (duAbsRelMode == 1){
                rdoAbs.Checked = false; rdoRel.Checked = true;
            }else if (duAbsRelMode == 0){
                rdoAbs.Checked = true;  rdoRel.Checked = false;
            }

            //++ 지정한 축이 제어가 가능한 상태인지 확인합니다.
            if (CAXM.AxmInfoGetAxisStatus(m_lAxisNoSl) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){                
                edtCmdPosSl.Enabled = true;
                edtActPosSl.Enabled = true;
                edtCmdVelSl.Enabled = true;
            }else{
                edtCmdPosSl.Enabled = false;
                edtActPosSl.Enabled = false;
                edtCmdVelSl.Enabled = false;
            }
            labAxisNoMa.Text = string.Format("Ma Axis{0:d2}", m_lAxisNoMa);
            labAxisNoSl.Text = string.Format("Sl Axis{0:d2}", m_lAxisNoSl);

            //++ 지정한 축의 겐트리제어 관련 설정값을 확인합니다.
            CAXM.AxmGantryGetEnable(m_lAxisNoMa, ref duSlaveHmUse, ref dSlaveHmOffset, ref dSlaveHmRange, ref duGantryOn);
            ConvertAxmToCombo(ref cboGantryHmSlaveUse, ref duSlaveHmUse);
            edtGantryHmOffset.Text = Convert.ToString(dSlaveHmOffset);
            edtGantryHmRange.Text = Convert.ToString(dSlaveHmRange);

            chkGantryEnable.Checked = Convert.ToBoolean(duGantryOn);
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