// ContiInterpolation.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 보간함수들의 사용법을 읽히고 정해진 패턴의 연속보간
//    데이타들을 연속보간 Queue에 예약 및 실행 해 보는 예제입니다.    
// >> [중요]: 연속보간 데이타 예약 및 구동하기
//     1) AxmContiSetAxisMap함수를 이용해서 필요한 축수의 좌표계를 맵핑합니다.
//     2) AxmContiSetAbsRelMode함수를 이용해 해당좌표계의 구동모드를 설정합니다.
//     3) AxmContiBeginNode함수를 이용해 보간구동 예약을 시작합니다.
//     4) AxmLineMove, AxmCircleCenterMove등의 보간함수를 이용해 구동을 예약합니다.
//     5) AxmContiEndNode함수를 이용해 보간구동 예약을 종료합니다.
//     6) AxmContiStart함수를 이용해 예약된 보간구동을 시작합니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContiInterpolation
{
    public partial class ContiInterpolation : Form
    {
        public  int     m_lAxisCounts = 0;                        // 제어 가능한 축갯수
        private int     m_lAxisNo = 0;                            // 제어할 축 번호 
        public uint     m_uModuleID = 0;                          // 제어할 축의 모듈 I/O
        public uint     m_lMoveIntpAxesCount = 0;                 // 보간에 사용할 축 갯수
        public int[]    m_lMoveIntpAxes = { -1, -1, -1, -1 };     // 보간에 사용할 축 배열
        public int      m_lBoardNo = 0, m_lModulePos = 0;

        public double[] m_dOldCmdPos ={ 0.0, 0.0, 0.0, 0.0 };     // tmTimer에서 사용할 이전 Command Position
        public double[] m_dOldActPos ={ 0.0, 0.0, 0.0, 0.0 };     // tmTimer에서 사용할 이전 Actual Position
        public double[] m_dOldCmdVel ={ 0.0, 0.0, 0.0, 0.0 };     // tmTimer에서 사용할 이전 Command Velocity

        public ContiInterpolation()
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
        private void ContiInterpolation_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> Project Name_FormClosed(...) : 프로젝트 Form 종료 함수.
        //  - Form을 Close시 불러내는 함수, Form 종료시 사용됩니다.
        // --------------------------------------------------------------------------
        private void ContiInterpolation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //++ Timer 사용을 종료합니다.
            tmDisplay.Enabled = false;
            //++ AXL 사용을 종료합니다.
            CAXL.AxlClose();
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmDisplay_Tick(object sender, EventArgs e)
        {
            TextBox[] DisplayCmdPos = new TextBox[4];
            DisplayCmdPos[0] = edtCmdPos00; DisplayCmdPos[1] = edtCmdPos01; DisplayCmdPos[2] = edtCmdPos02; DisplayCmdPos[3] = edtCmdPos03;
            TextBox[] DisplayActPos = new TextBox[4];
            DisplayActPos[0] = edtActPos00; DisplayActPos[1] = edtActPos01; DisplayActPos[2] = edtActPos02; DisplayActPos[3] = edtActPos03;
            TextBox[] DisplayCmdVel = new TextBox[4];
            DisplayCmdVel[0] = edtCmdVel00; DisplayCmdVel[1] = edtCmdVel01; DisplayCmdVel[2] = edtCmdVel02; DisplayCmdVel[3] = edtCmdVel03;

            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint    lCount, lArrayIndex = 0;
            uint    duQueueFree = 0, duIntpInMotion = 0;
            double  dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;            
            int	    uExeNode = 0, uTotalNode = 0; 	        

            for (lCount = 0; lCount < 4; lCount++){
                // 버튼 콘트롤의 체크 상태를 확인합니다.
                if (chkMoveMultiAxes[lCount].Checked){
                    //++ 지정한 축의 지령(Command)위치를 반환합니다.
                    CAXM.AxmStatusGetCmdPos(m_lMoveIntpAxes[lArrayIndex], ref dCmdPos);
                    if (m_dOldCmdPos[lCount] != dCmdPos){
                        DisplayCmdPos[lCount].Text = String.Format("{0:0.000}", dCmdPos);
                        m_dOldCmdPos[lCount] = dCmdPos;
                    }
                    //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                    CAXM.AxmStatusGetActPos(m_lMoveIntpAxes[lArrayIndex], ref dActPos);
                    if (m_dOldActPos[lCount] != dActPos){
                        DisplayActPos[lCount].Text = String.Format("{0:0.000}", dActPos);
                        m_dOldActPos[lCount] = dActPos;
                    }
                    //++ 지정한 축의 구동 속도를 반환합니다.
                    CAXM.AxmStatusReadVel(m_lMoveIntpAxes[lArrayIndex], ref dCmdVel);
                    if (m_dOldCmdVel[lCount] != dCmdVel){
                        DisplayCmdVel[lCount].Text = String.Format("{0:0.000}", dCmdVel);
                        m_dOldCmdVel[lCount] = dCmdVel;
                    }
                    ++lArrayIndex;
                }
            }
            //++ 지정한 좌표계에 연속보간 Queue가 비었는지 확인합니다.
            CAXM.AxmContiReadFree(0, ref duQueueFree);
            chkIntpQueueFree.Checked = Convert.ToBoolean(duQueueFree);
            //++ 지정한 좌표계가 연속보간 구동중인지 확인합니다.
            CAXM.AxmContiIsMotion(0, ref duIntpInMotion);
            chkIntpInMotion.Checked = Convert.ToBoolean(duIntpInMotion);

            //++ 지정한 좌표계가 연속보간 구동중 현재 실행중인 Node의 Index를 확인합니다.
            CAXM.AxmContiGetNodeNum(0, ref uExeNode);
            if (Convert.ToUInt32(edtIntpExeNode.Text) != uExeNode) edtIntpExeNode.Text = Convert.ToString(uExeNode);

            //++ 지정한 좌표계에 예약된 연속보간 데이타의 전체 갯수를 확인합니다.
            CAXM.AxmContiGetTotalNodeNum(0, ref uTotalNode);
            if (Convert.ToUInt32(edtIntpTotalNode.Text) != uTotalNode) edtIntpTotalNode.Text = Convert.ToString(uTotalNode);
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

        // ++ =========================================================================
        // >> chkAxis_Click(...) : 보간축 변경이 있을 때 호출되는 핸들러 함수. 
        //  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
        //    번호 배열값을 재할당합니다.
        //  - chkAxis00 ~ chkAxis03 버튼의 클릭이벤트 발생시 호출됩니다.
        // ----------------------------------------------------------------------------
        private void chkAxis_Click(object sender, EventArgs e)
        {
            // 변경된 모션축의 상태와 Control들의 상태를 일치시킵니다.
            UpdateState();
        }        

        // ++ =======================================================================
        // >> btnPosClear_Click() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들의 위치정보를 0.0으로 설정합니다.
        //  - AxmStatusSetPosMatch함수는 AxmStatusSetCmdPos, AxmStatusSetActPos 함수를 
        //    사용하는것과 동일한 효과를 냅니다.
        // --------------------------------------------------------------------------
        private void btnPosClear_Click(object sender, EventArgs e)
        {
            uint lCount;
            for (lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++)
                //CAXM.AxmStatusSetCmdPos(m_lMoveIntpAxes[lCount], 0);
                //CAXM.AxmStatusSetActPos(m_lMoveIntpAxes[lCount], 0);
                //++ Command위치와 Actual위치를 입력한 값으로 설정합니다.
                CAXM.AxmStatusSetPosMatch(m_lMoveIntpAxes[lCount], 0.0);
        }

        // ++ =======================================================================
        // >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint duOnOff;
            uint lCount;

            for (lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++)
            {
                //++ 지정 축의 Servo On/Off 신호를 출력합니다.
                duOnOff = Convert.ToUInt32(chkServoOn.Checked);
                CAXM.AxmSignalServoOn(m_lMoveIntpAxes[lCount], duOnOff);
            }
        }

        // ++ =======================================================================
        // >> btnIntpStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 연속보간을 정지하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpStop_Click(object sender, EventArgs e)
        {
            uint lCount;
            for (lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++)
                //++ 지정한 좌표계에 연속 보간 구동을 정지합니다.
                // [INFO] 좌표계에 포함된 한 축을 정지하면 연속보간은 정지됩니다.
                CAXM.AxmMoveSStop(m_lMoveIntpAxes[lCount]);
        }

        // ++ =======================================================================
        // >> btnIntpLine_Click() : "Line"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 2축을 이용해 단위 직선보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpLine_Click(object sender, EventArgs e)
        {
         	uint	 duRetCode;
            double[] dMovePos = { 100.0, 200.0 };       // 첫번째, 두번째 축의 이동할 위치값
	        double	 dVelocity, dAccel, dDecel;

        	dVelocity = Convert.ToDouble(edtMoveVel.Text);
            dAccel    = Convert.ToDouble(edtMoveAcc.Text);
            dDecel    = Convert.ToDouble(edtMoveDec.Text);

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.        	
	        CAXM.AxmContiSetAxisMap(0, 2, m_lMoveIntpAxes);
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
	        CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계의 축들을 이용해 직선보간구동을 수행합니다. 
            duRetCode = CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);

            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmLineMove return error[Code:{0:d}]", duRetCode));  
        }

        // ++ =======================================================================
        // >> btnIntpArc_Click() : "Arc"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 2축을 이용해 단위 Arc보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpArc_Click(object sender, EventArgs e)
        {
            double[] dEndPos ={100.0, 100.0};
            double   dRadius = 141.0; ;	
	        double 	 dVelocity, dAccel, dDecel;
	        uint	 duRetCode, duArcDir, duShortDis;

            dVelocity = Convert.ToDouble(edtMoveVel.Text);
            dAccel    = Convert.ToDouble(edtMoveAcc.Text);
            dDecel    = Convert.ToDouble(edtMoveDec.Text);
	
	        duArcDir  = 1;
	        duShortDis= 1;

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
            CAXM.AxmContiSetAxisMap(0, 2, m_lMoveIntpAxes);
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
            CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계의 축들 중 특정 2축에 반지름을 이용한 원호보간구동을 수행합니다.  
            duRetCode = CAXM.AxmCircleRadiusMove(0, m_lMoveIntpAxes, dRadius, dEndPos, dVelocity, dAccel, dDecel, duArcDir, duShortDis);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmCircleRadiusMove return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> btnIntpCircle_Click() : "Circle"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 2축을 이용해 단위 원호보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpCircle_Click(object sender, EventArgs e)
        {
            uint	 duRetCode, duArcDir;
            double[] dCenterPos = {200.0 , 200.0};
            double   dAngle = 360.0;	
	        double	 dVelocity, dAccel, dDecel;
        	
            dVelocity = Convert.ToDouble(edtMoveVel.Text);
            dAccel    = Convert.ToDouble(edtMoveAcc.Text);
            dDecel    = Convert.ToDouble(edtMoveDec.Text);
	        duArcDir  = 0;

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
            CAXM.AxmContiSetAxisMap(0, 2, m_lMoveIntpAxes);            
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
            CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계의 축들 중 특정 2축에, 회전중심과 회전각도를 이용한 원호보간 구동을 수행합니다.
            System.Threading.Thread.Sleep(1);
            duRetCode = CAXM.AxmCircleAngleMove(0, m_lMoveIntpAxes, dCenterPos, dAngle, dVelocity, dAccel, dDecel, duArcDir);
	        if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmCircleAngleMove return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> btnIntpLineArc_Click() : "Line & Arc"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 2축을 이용해 연속 직선/원호보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpLineArc_Click(object sender, EventArgs e)
        {
            double[]  dMovePos = new double[2];
	        double[]  dCenPos = new double[2];	
	        double[]  dEndPos = new double[2];
	        double	  dVelocity, dAccel, dDecel;
        	
            dVelocity = Convert.ToDouble(edtMoveVel.Text);
            dAccel    = Convert.ToDouble(edtMoveAcc.Text);
            dDecel    = Convert.ToDouble(edtMoveDec.Text);

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
	        CAXM.AxmContiSetAxisMap(0, 2, m_lMoveIntpAxes);
            //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
            CAXM.AxmContiWriteClear(0);
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
            CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
            // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
            CAXM.AxmContiBeginNode(0); 	

	        dMovePos[0] = 0.0; dMovePos[1] = 200.0;
            //++ 지정한 좌표계에 직선보간 구동을 예약합니다.
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);
        	
	        dMovePos[0] = 180.0; dMovePos[1] = 200.0;
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);	
        	
	        dCenPos[0] = 180.0; dCenPos[1] = 180.0; 
	        dEndPos[0] = 200.0; dEndPos[1] = 180.0;
            CAXM.AxmCircleCenterMove(0, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, 1);
        	
	        dMovePos[0] = 200.0; dMovePos[1] = -180.0;
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);	
        	
	        dCenPos[0] = 180.0; dCenPos[1] = -180.0; 
	        dEndPos[0] = 180.0; dEndPos[1] = -200.0;
            //++ 지정한 좌표계에 중심점과 종료점을 이용하는 원호보간 구동을 예약합니다.
            CAXM.AxmCircleCenterMove(0, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, 1);
        	
	        dMovePos[0] = -180.0; dMovePos[1] = -200.0;
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);	
        	
	        dCenPos[0] = -180.0; dCenPos[1] = -180.0; 
	        dEndPos[0] = -200.0; dEndPos[1] = -180.0;
            CAXM.AxmCircleCenterMove(0, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, 1);
        	
	        dMovePos[0] = -200.0; dMovePos[1] = 180.0;
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);	
        	
	        dCenPos[0] = -180.0; dCenPos[1] = 180.0; 
	        dEndPos[0] = -180.0; dEndPos[1] = 200.0;
            CAXM.AxmCircleCenterMove(0, m_lMoveIntpAxes, dCenPos, dEndPos, dVelocity, dAccel, dDecel, 1);

            dMovePos[0] = 0.0; dMovePos[1] = 200.0;
            CAXM.AxmLineMove(0, dMovePos, dVelocity, dAccel, dDecel);

            //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
            // ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
            //    연속보간 구동을 실행할 수 있습니다.
            CAXM.AxmContiEndNode(0);
        }

        // ++ =======================================================================
        // >> btnIntpHelical_Click() : "Helical"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 4축을 이용해 연속 헬리컬 보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpHelical_Click(object sender, EventArgs e)
        {
            uint   duArcDir;
            double dVelocity, dAccel, dDecel;
            double dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos;

            dVelocity   = Convert.ToDouble(edtMoveVel.Text);
            dAccel      = Convert.ToDouble(edtMoveAcc.Text);
            dDecel      = Convert.ToDouble(edtMoveDec.Text); 

            dCenterPosX = 100.0;
            dCenterPosY = 100.0;
            dEndPosX    = 0.0;
            dEndPosY    = 0.0;
            dZPos       = 10.0;
            duArcDir    = 1;

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.            
            CAXM.AxmContiSetAxisMap(0, 4, m_lMoveIntpAxes);
            //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
            CAXM.AxmContiWriteClear(0);
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
            CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
            // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
            CAXM.AxmContiBeginNode(0);
            //++ 지정한 좌표계에 중심점과 종료점을 이용하는 헬리컬 보간구동을 예약합니다.
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmHelixCenterMove(0, dCenterPosX, dCenterPosY, dEndPosX, dEndPosY, dZPos, dVelocity, dAccel, dAccel, duArcDir);
            CAXM.AxmContiEndNode(0);
        }

        // ++ =======================================================================
        // >> btnIntpSpline_Click() : "Spline"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들 중 3축을 이용해 스플라인 보간을 하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpSpline_Click(object sender, EventArgs e)
        {
        	int	     iPointFactor = 100;
            double	 dVelocity, dAccel, dDecel;
            double[] dPosX ={0, 45, 75, 108, 130};
            double[] dPosY ={0, 10, 45, 75, 70};
            double   dPosZ =1.0;

            dVelocity = Convert.ToDouble(edtMoveVel.Text);
            dAccel    = Convert.ToDouble(edtMoveAcc.Text);
            dDecel    = Convert.ToDouble(edtMoveDec.Text);

            //++ 지정한 좌표계에 연속보간 축들을 맵핑합니다.
            CAXM.AxmContiSetAxisMap(0, 3, m_lMoveIntpAxes);
            //++ 지정한 좌표계에 등록되어있는 보간데이타를 모두 지웁니다.
            CAXM.AxmContiWriteClear(0);
            //++ 지정한 좌표계에 구동모드을 설정합니다.(절대구동/상대구동)
            CAXM.AxmContiSetAbsRelMode(0, 1);

            //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 시작합니다.
            // ※ [CAUTION] 이 함수가 실행된 후 에는 보간함수들이 즉시 구동되지 않고 보간데이타 Queue에 예약됩니다.
            CAXM.AxmContiBeginNode(0);
            //++ 지정한 좌표계에 X좌표, Y좌표, Z좌표를 이용하는 스플라인 보간구동을 예약합니다.
            CAXM.AxmSplineWrite(0, 5, dPosX, dPosY, dVelocity, dAccel, dAccel, dPosZ, iPointFactor);

            //++ 지정한 좌표계에 연속보간을 수행할 작업 등록을 종료합니다.
            // ※ [CAUTION] AxmContiBeginNode 함수 실행후 연속보간 작업을 등록한 후 반드시 이 함수로 등록을 종료해야
            //              연속보간 구동을 실행할 수 있습니다.
            CAXM.AxmContiEndNode(0);
        }

        // ++ =======================================================================
        // >> btnIntpStart_Click() : "Start"버튼 클릭시 호출되는 핸들러 함수.
        //  - 예약된 연속보간 데이타들을 이용하여 연속보간을 시작하는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpStart_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            //++ 지정한 좌표계의 연속보간 구동을 시작합니다.
            duRetCode = CAXM.AxmContiStart(0, 0, 0);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmContiStart return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> btnIntpClear_Click() : "Clear"버튼 클릭시 호출되는 핸들러 함수.
        //  - 예약된 연속보간 데이타들을 지우는 함수입니다.
        // --------------------------------------------------------------------------
        private void btnIntpClear_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            //++ 지정한 좌표계에 연속 보간 구동을 위해 예약된 보간데이타를 모두 삭제합니다.
            duRetCode = CAXM.AxmContiWriteClear(0);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmContiWriteClear return error[Code:{0:d}]", duRetCode)); 
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

            // 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
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

            // Edit Control에 초기값 설정
            edtMoveVel.Text = "100.000";
            edtMoveAcc.Text = "400.000";
            edtMoveDec.Text = "200.000";
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
            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            bool    bSelectCheck, bEmptyCheck, bAllCheck;
            string  strData;
            uint    duOnOff = 0;
            uint    lCount;
            int     lFirstAxisNo = 0;

            m_lMoveIntpAxesCount = 0;
            bSelectCheck = false;
            bEmptyCheck  = false;

            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            //++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
            CAXM.AxmInfoGetFirstAxisNo(m_lBoardNo, m_lModulePos, ref lFirstAxisNo);

            for (lCount = 0; lCount < 4; lCount++){
                //++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
                if (CAXM.AxmInfoGetAxisStatus(lFirstAxisNo) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    strData = string.Format("Axis{0:d2}", lFirstAxisNo);
                    chkMoveMultiAxes[lCount].Enabled = true;

                    bSelectCheck = chkMoveMultiAxes[lCount].Checked;
                    bEmptyCheck |= bSelectCheck;

                    if (bSelectCheck == true){
                        m_lMoveIntpAxes[m_lMoveIntpAxesCount++] = lFirstAxisNo;
                    }
                }else{
                    m_lMoveIntpAxes[lCount] = -1;
                    strData = string.Format("Axis --");
                }
                lFirstAxisNo++;
                chkMoveMultiAxes[lCount].Text = strData;
            }
            chkServoOn.Enabled = bEmptyCheck;            
            bAllCheck = true;

            for (lCount = 0; lCount < m_lMoveIntpAxesCount; lCount++){
                //++ 지정한 축의 서보온 상태를 반환합니다.
                CAXM.AxmSignalIsServoOn(m_lMoveIntpAxes[lCount], ref duOnOff);
                // 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
                bAllCheck &= Convert.ToBoolean(duOnOff);
            }
            // 선택된 축이 없으면 Disable처리
            chkServoOn.Checked = bAllCheck;

            // 선택된 축수에 따라 사용가능한 보간버튼들을 활성화시킵니다.
            if (m_lMoveIntpAxesCount < 2){
                btnIntpLine.Enabled = false;    btnIntpArc.Enabled = false;
                btnIntpCircle.Enabled = false;  btnIntpLineArc.Enabled = false;
                btnIntpHelical.Enabled = false; btnIntpSpline.Enabled = false;
            }else{
                btnIntpLine.Enabled = true;     btnIntpArc.Enabled = true;
                btnIntpCircle.Enabled = true;   btnIntpLineArc.Enabled = true;
                btnIntpSpline.Enabled = true; 
            }

            if (m_lMoveIntpAxesCount >= 3)      btnIntpSpline.Enabled = true;
            else                                btnIntpSpline.Enabled = false;            

            if (m_lMoveIntpAxesCount >= 4)      btnIntpHelical.Enabled = true;
            else                                btnIntpHelical.Enabled = false;            
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