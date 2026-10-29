// MoveMultiAxes.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 다축구동 함수들의 사용법을 읽히고 각 함수들의 인자값을 
//    변경하면서 구동해 보는 예제입니다.
// >> [중요]: 다축 구동함수들로 구동중 포함된 축중 한축만 정지해도 다른축들이
//    구동을 정지하게 됩니다.
// >> [중요]: 일정한 거리 비율을 유지하는 다축조그 구동방법
//     1) AxmMoveStartLineVel 함수의 dDis값에 각 축의 거리 비율을 설정합니다.
//     2) dDis[4] = {10.0, 20.0, 30.0, 40.0}으로 설정하였을 경우 0축이 10.0에
//        도달했을 때 1, 2, 3축은 20.0, 30.0, 40.0의 위치에 도달하게 됩니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoveMultiAxes
{
    public partial class MoveMultiAxes : Form
    {

        public  int  m_lAxisCounts = 0;                         // 제어 가능한 축갯수 선언 및 초기화
        private int  m_lAxisNo = 0;                             // 제어할 축 번호 선언 및 초기화
        public uint  m_uModuleID = 0;                           // 제어할 축의 모듈 I/O 선언 및 초기화 
        public uint  m_lMoveMultiAxesCount = 0;                 // 다축구동할 축 갯수 선언 및 초기화    
        public int[] m_lMoveMultiAxes = { -1, -1, -1, -1 };     // 다축구동할 축 배열 갯수 선언 및 초기화
        public int   m_lBoardNo = 0, m_lModulePos = 0;

        public double[] m_dOldCmdPos ={ 0.0, 0.0, 0.0, 0.0 };   // tmDisplay에서 사용할 이전 Command Position	
        public double[] m_dOldActPos ={ 0.0, 0.0, 0.0, 0.0 };   // tmDisplay에서 사용할 이전 Actual Position
        public double[] m_dOldCmdVel ={ 0.0, 0.0, 0.0, 0.0 };   // tmDisplay에서 사용할 이전 Command Velocity

        public MoveMultiAxes()
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
        private void MoveMultiAxes_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
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

            uint lCount, lArrayIndex = 0;
            uint duQueueFree = 0, duIntpInMotion = 0;
            double dCmdPos = 0.0, dActPos = 0.0, dCmdVel = 0.0;
            int uExeNode = 0, uTotalNode = 0;

            for (lCount = 0; lCount < 4; lCount++)
            {
                // 버튼 콘트롤의 체크 상태를 확인합니다.
                if (chkMoveMultiAxes[lCount].Checked)
                {
                    //++ 지정한 축의 지령(Command)위치를 반환합니다.
                    CAXM.AxmStatusGetCmdPos(m_lMoveMultiAxes[lArrayIndex], ref dCmdPos);
                    if (m_dOldCmdPos[lCount] != dCmdPos)
                    {
                        DisplayCmdPos[lCount].Text = String.Format("{0:0.000}", dCmdPos);
                        m_dOldCmdPos[lCount] = dCmdPos;
                    }
                    //++ 지정한 축의 실제(Feedback)위치를 반환합니다.
                    CAXM.AxmStatusGetActPos(m_lMoveMultiAxes[lArrayIndex], ref dActPos);
                    if (m_dOldActPos[lCount] != dActPos)
                    {
                        DisplayActPos[lCount].Text = String.Format("{0:0.000}", dActPos);
                        m_dOldActPos[lCount] = dActPos;
                    }
                    //++ 지정한 축의 구동 속도를 반환합니다.
                    CAXM.AxmStatusReadVel(m_lMoveMultiAxes[lArrayIndex], ref dCmdVel);
                    if (m_dOldCmdVel[lCount] != dCmdVel)
                    {
                        DisplayCmdVel[lCount].Text = String.Format("{0:0.000}", dCmdVel);
                        m_dOldCmdVel[lCount] = dCmdVel;
                    }
                    ++lArrayIndex;
                }
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

        // ++ =========================================================================
        // >> chkAxis_Click(...) : 보간축 변경이 있을 때 호출되는 핸들러 함수. 
        //  - 축 번호 선택 체크버튼의 체크상태에 변화가 있을 때 보간 사용축 갯수 및 축
        //    번호 배열값을 재할당합니다.
        //  - chkAxis00 ~ chkAxis03 버튼의 클릭이벤트 발생시 호출됩니다.
        // ----------------------------------------------------------------------------
        private void chkAxis_Click(object sender, EventArgs e)
        {
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

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //CAXM.AxmStatusSetCmdPos(m_lMoveIntpAxes[lCount], 0);
                //CAXM.AxmStatusSetActPos(m_lMoveIntpAxes[lCount], 0);
                //++ Command위치와 Actual위치를 입력한 값으로 설정합니다.
                CAXM.AxmStatusSetPosMatch(m_lMoveMultiAxes[lCount], 0.0);            
        }

        // ++ =======================================================================
        // >> chkServoOn_Click() : "Servo On"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택된 보간축들을 체크버튼의 상태에 따라 서보 On/Off 합니다.
        // --------------------------------------------------------------------------
        private void chkServoOn_Click(object sender, EventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정 축의 Servo On/Off 신호를 출력합니다.
                CAXM.AxmSignalServoOn(m_lMoveMultiAxes[lCount], (uint)Convert.ToInt32(chkServoOn.Checked));            
        }

        // ++ =======================================================================
        // >> btnPosMove_Click() : "Move"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 모션구동합니다.
        // --------------------------------------------------------------------------
        private void btnPosMove_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;

            TextBox[] MovePos = new TextBox[4];
            MovePos[0] = edtMovePos00; MovePos[1] = edtMovePos01; MovePos[2] = edtMovePos02; MovePos[3] = edtMovePos03;
            TextBox[] MoveVel = new TextBox[4];
            MoveVel[0] = edtMoveVel00; MoveVel[1] = edtMoveVel01; MoveVel[2] = edtMoveVel02; MoveVel[3] = edtMoveVel03;
            TextBox[] MoveAcc = new TextBox[4];
            MoveAcc[0] = edtMoveAcc00; MoveAcc[1] = edtMoveAcc01; MoveAcc[2] = edtMoveAcc02; MoveAcc[3] = edtMoveAcc03;
            TextBox[] MoveDec = new TextBox[4];
            MoveDec[0] = edtMoveDec00; MoveDec[1] = edtMoveDec01; MoveDec[2] = edtMoveDec02; MoveDec[3] = edtMoveDec03;
            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint	 lCount, lArrayIndex;
            double[] dMultiPos = { 0.0, 0.0, 0.0, 0.0 }, dMultiVel = { 0.0, 0.0, 0.0, 0.0 },
                     dMultiAcc = { 0.0, 0.0, 0.0, 0.0, },dMultiDec = { 0.0, 0.0, 0.0, 0.0 };
        	
	        lArrayIndex = 0;

	        for(lCount = 0; lCount < 4; lCount++){
                if (chkMoveMultiAxes[lCount].Checked){
			        dMultiPos[lArrayIndex] = Convert.ToDouble(MovePos[lCount].Text);
                    dMultiVel[lArrayIndex] = Convert.ToDouble(MoveVel[lCount].Text);
                    dMultiAcc[lArrayIndex] = Convert.ToDouble(MoveAcc[lCount].Text);
                    dMultiDec[lArrayIndex] = Convert.ToDouble(MoveDec[lCount].Text);
			        ++lArrayIndex;
		        }
	        }

	        if(chkMoveBlock.Checked){
                //++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션이 종료되면 함수를 빠져나옵니다.
                duRetCode = CAXM.AxmMoveMultiPos((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmMoveMultiPos return error[Code:{0:d}]", duRetCode));  
	        }else{
                //++ 지정한 축들을 지정한 거리(또는 위치)/속도/가속도/감속도로 각각 모션구동하고 모션 종료여부와 상관없이 함수를 빠져나옵니다.
                duRetCode = CAXM.AxmMoveStartMultiPos((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiPos, dMultiVel, dMultiAcc, dMultiDec);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    MessageBox.Show(String.Format("AxmMoveStartMultiPos return error[Code:{0:d}]", duRetCode));  
	        }
        }

        // ++ =======================================================================
        // >> btnPosStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 선택한 축들로 구동정지 함수를 호출하여 구동을 종료합니다.
        // ※ [CAUTION] 다축 구동함수들로 구동시 포함된 축중 한축만 정지해도 다른축들이 
        //    구동을 정지하게 됩니다.
        // --------------------------------------------------------------------------
        private void btnPosStop_Click(object sender, EventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정한 축의 구동을 감속정지합니다.
                CAXM.AxmMoveSStop(m_lMoveMultiAxes[lCount]);            
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // --------------------------------------------------------------------------
        private void btnJogP_MouseDown(object sender, MouseEventArgs e)
        {
            uint duRetCode = 0;

            TextBox[] JogVel = new TextBox[4];
            JogVel[0] = edtJogVel00; JogVel[1] = edtJogVel01; JogVel[2] = edtJogVel02; JogVel[3] = edtJogVel03;
            TextBox[] JogAcc = new TextBox[4];
            JogAcc[0] = edtJogAcc00; JogAcc[1] = edtJogAcc01; JogAcc[2] = edtJogAcc02; JogAcc[3] = edtJogAcc03;
            TextBox[] JogDec = new TextBox[4];
            JogDec[0] = edtJogDec00; JogDec[1] = edtJogDec01; JogDec[2] = edtJogDec02; JogDec[3] = edtJogDec03;
            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint     lCount, lArrayIndex;
            double[] dMultiJogVel = { 0.0, 0.0, 0.0, 0.0 }, dMultiJogAcc = { 0.0, 0.0, 0.0, 0.0, }, dMultiJogDec = { 0.0, 0.0, 0.0, 0.0 };

            lArrayIndex = 0;

            for (lCount = 0; lCount < 4; lCount++){
                if (chkMoveMultiAxes[lCount].Checked){
                    dMultiJogVel[lArrayIndex] = Convert.ToDouble(JogVel[lCount].Text);
                    dMultiJogAcc[lArrayIndex] = Convert.ToDouble(JogAcc[lCount].Text);
                    dMultiJogDec[lArrayIndex] = Convert.ToDouble(JogDec[lCount].Text);
                    ++lArrayIndex;
                }
            }
            //++ 지정한 축을 (+)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            duRetCode = CAXM.AxmMoveStartMultiVel((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiJogVel, dMultiJogAcc, dMultiJogDec);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartMultiPos return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> btnJogMoveP_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnJogP_MouseUp(object sender, MouseEventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정한 축의 Jog구동(모션구동)을 종료합니다.  
                CAXM.AxmMoveSStop(m_lMoveMultiAxes[lCount]);            
        }


        // ++ =======================================================================
        // >> btnJogN_MouseDown(...) : "Move Jog(+/-)"버튼 Down시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseDown 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Down시 연속구동 함수를 호출하여 Jog 구동을 시작합니다.
        // --------------------------------------------------------------------------
        private void btnJogN_MouseDown(object sender, MouseEventArgs e)
        {
            uint duRetCode = 0;

            TextBox[] JogVel = new TextBox[4];
            JogVel[0] = edtJogVel00; JogVel[1] = edtJogVel01; JogVel[2] = edtJogVel02; JogVel[3] = edtJogVel03;
            TextBox[] JogAcc = new TextBox[4];
            JogAcc[0] = edtJogAcc00; JogAcc[1] = edtJogAcc01; JogAcc[2] = edtJogAcc02; JogAcc[3] = edtJogAcc03;
            TextBox[] JogDec = new TextBox[4];
            JogDec[0] = edtJogDec00; JogDec[1] = edtJogDec01; JogDec[2] = edtJogDec02; JogDec[3] = edtJogDec03;
            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint     lCount, lArrayIndex;
            double[] dMultiJogVel = { 0.0, 0.0, 0.0, 0.0 }, dMultiJogAcc = { 0.0, 0.0, 0.0, 0.0 }, dMultiJogDec = { 0.0, 0.0, 0.0, 0.0 };

            lArrayIndex = 0;

            for (lCount = 0; lCount < 4; lCount++){
                if (chkMoveMultiAxes[lCount].Checked){
                    dMultiJogVel[lArrayIndex] = -(Convert.ToDouble(JogVel[lCount].Text));
                    dMultiJogAcc[lArrayIndex] = Convert.ToDouble(JogAcc[lCount].Text);
                    dMultiJogDec[lArrayIndex] = Convert.ToDouble(JogDec[lCount].Text);
                    ++lArrayIndex;
                }
            }
            //++ 지정한 축을 (-)방향으로 지정한 속도/가속도/감속도로 모션구동합니다.
            duRetCode = CAXM.AxmMoveStartMultiVel((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiJogVel, dMultiJogAcc, dMultiJogDec);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmMoveStartMultiPos return error[Code:{0:d}]", duRetCode)); 
        }

        // ++ =======================================================================
        // >> btnJogN_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnJogN_MouseUp(object sender, MouseEventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정한 축의 Jog구동(모션구동)을 종료합니다. 
                CAXM.AxmMoveSStop(m_lMoveMultiAxes[lCount]);
        }

        // ++ =======================================================================
        // >> btnLineP_MouseDown(...) : "Line Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnLineP_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox[] LinePos = new TextBox[4];
            LinePos[0] = edtLinePos00; LinePos[1] = edtLinePos01; LinePos[2] = edtLinePos02; LinePos[3] = edtLinePos03;

            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint lCount, lArrayIndex;
            double[] dMultiLinePos = { 0.0, 0.0, 0.0, 0.0 };
            double dMultiLineJogVel = 0.0, dMultiLineJogAcc = 0.0, dMultiLineJogDec = 0.0;

            lArrayIndex = 0;

            for (lCount = 0; lCount < 4; lCount++){
                if (chkMoveMultiAxes[lCount].Checked){
                    dMultiLinePos[lArrayIndex] = Convert.ToDouble(LinePos[lCount].Text);
                    ++lArrayIndex;
                }
            }

            dMultiLineJogVel = Convert.ToDouble(edtLineVel.Text);
            dMultiLineJogAcc = Convert.ToDouble(edtLineAcc.Text);
            dMultiLineJogDec = Convert.ToDouble(edtLineDec.Text);

            //++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveStartLineVel((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiLinePos, dMultiLineJogVel, dMultiLineJogAcc, dMultiLineJogDec);
        }

        // ++ =======================================================================
        // >> btnLineP_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnLineP_MouseUp(object sender, MouseEventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정한 축의 Jog구동(모션구동)을 종료합니다. 
                CAXM.AxmMoveSStop(m_lMoveMultiAxes[lCount]);            
        }

        // ++ =======================================================================
        // >> btnLineN_MouseDown(...) : "Line Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnLineN_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox[] LinePos = new TextBox[4];
            LinePos[0] = edtLinePos00; LinePos[1] = edtLinePos01; LinePos[2] = edtLinePos02; LinePos[3] = edtLinePos03;

            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            uint     lCount, lArrayIndex;
            double[] dMultiLinePos = { 0.0, 0.0, 0.0, 0.0 };
            double   dMultiLineJogVel = 0.0, dMultiLineJogAcc = 0.0, dMultiLineJogDec = 0.0;

            lArrayIndex = 0;

            for (lCount = 0; lCount < 4; lCount++){
                if (chkMoveMultiAxes[lCount].Checked){
                    dMultiLinePos[lArrayIndex] = -(Convert.ToDouble(LinePos[lCount].Text));
                    ++lArrayIndex;
                }
            }

            dMultiLineJogVel = Convert.ToDouble(edtLineVel.Text);
            dMultiLineJogAcc = Convert.ToDouble(edtLineAcc.Text);
            dMultiLineJogDec = Convert.ToDouble(edtLineDec.Text);

            //++ 선택한 축들을 (+/-)방향으로 지정한 위치 비율에따른 속도/가속도/감속도로 모션구동합니다.
            CAXM.AxmMoveStartLineVel((int)m_lMoveMultiAxesCount, m_lMoveMultiAxes, dMultiLinePos, dMultiLineJogVel, dMultiLineJogAcc, dMultiLineJogDec);
        }

        // ++ =======================================================================
        // >> btnLineP_MouseUp(...) : "Move Jog(+/-)"버튼 Up시 호출되는 핸들러 함수.
        //  - 버튼 이벤트인 MouseUp 함수를 이용하여 조그 버튼을 구현 합니다.
        //  - Jog버튼 Up시 구동정지 함수를 호출하여 Jog 구동을 종료합니다.
        // --------------------------------------------------------------------------
        private void btnLineN_MouseUp(object sender, MouseEventArgs e)
        {
            uint lCount;

            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++)
                //++ 지정한 축의 Jog구동(모션구동)을 종료합니다. 
                CAXM.AxmMoveSStop(m_lMoveMultiAxes[lCount]);
            
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
            uint lCount = 0;

            cboSelAxis.SelectedIndex = m_lAxisNo;

            TextBox[] MovePos = new TextBox[4];
            MovePos[0] = edtMovePos00;  MovePos[1] = edtMovePos01;  MovePos[2] = edtMovePos02;  MovePos[3] = edtMovePos03;
            TextBox[] MoveVel = new TextBox[4];
            MoveVel[0] = edtMoveVel00;  MoveVel[1] = edtMoveVel01;  MoveVel[2] = edtMoveVel02;  MoveVel[3] = edtMoveVel03;
            TextBox[] MoveAcc = new TextBox[4];
            MoveAcc[0] = edtMoveAcc00;  MoveAcc[1] = edtMoveAcc01;  MoveAcc[2] = edtMoveAcc02;  MoveAcc[3] = edtMoveAcc03;
            TextBox[] MoveDec = new TextBox[4];
            MoveDec[0] = edtMoveDec00;  MoveDec[1] = edtMoveDec01;  MoveDec[2] = edtMoveDec02;  MoveDec[3] = edtMoveDec03;
            TextBox[] JogVel = new TextBox[4];
            JogVel[0] = edtJogVel00;    JogVel[1]  = edtJogVel01;   JogVel[2]  = edtJogVel02;   JogVel[3]  = edtJogVel03;
            TextBox[] JogAcc = new TextBox[4];
            JogAcc[0] = edtJogAcc00;    JogAcc[1]  = edtJogAcc01;   JogAcc[2]  = edtJogAcc02;   JogAcc[3]  = edtJogAcc03;
            TextBox[] JogDec = new TextBox[4];
            JogDec[0] = edtJogDec00;    JogDec[1]  = edtJogDec01;   JogDec[2]  = edtJogDec02;   JogDec[3]  = edtJogDec03;
            TextBox[] LinePos = new TextBox[4];
            LinePos[0] = edtLinePos00;  LinePos[1] = edtLinePos01;  LinePos[2] = edtLinePos02;  LinePos[3] = edtLinePos03;

            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            // Edit Control에 초기값 설정
            for (lCount = 0; lCount < 4; lCount++){
                MovePos[lCount].Text = "100.000";
                MoveVel[lCount].Text = "100.000";
                MoveAcc[lCount].Text = "400.000";
                MoveDec[lCount].Text = "400.000";
                JogVel[lCount].Text  = "100.000";
                JogAcc[lCount].Text  = "400.000";
                JogDec[lCount].Text  = "400.000";
                LinePos[lCount].Text = "100.000";
            }

            edtLineVel.Text = "100.000";
            edtLineAcc.Text = "400.000";
            edtLineDec.Text = "200.000";
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
            TextBox[] MovePos = new TextBox[4];
            MovePos[0] = edtMovePos00; MovePos[1] = edtMovePos01; MovePos[2] = edtMovePos02; MovePos[3] = edtMovePos03;
            TextBox[] MoveVel = new TextBox[4];
            MoveVel[0] = edtMoveVel00; MoveVel[1] = edtMoveVel01; MoveVel[2] = edtMoveVel02; MoveVel[3] = edtMoveVel03;
            TextBox[] MoveAcc = new TextBox[4];
            MoveAcc[0] = edtMoveAcc00; MoveAcc[1] = edtMoveAcc01; MoveAcc[2] = edtMoveAcc02; MoveAcc[3] = edtMoveAcc03;
            TextBox[] MoveDec = new TextBox[4];
            MoveDec[0] = edtMoveDec00; MoveDec[1] = edtMoveDec01; MoveDec[2] = edtMoveDec02; MoveDec[3] = edtMoveDec03;
            TextBox[] JogVel = new TextBox[4];
            JogVel[0] = edtJogVel00; JogVel[1] = edtJogVel01; JogVel[2] = edtJogVel02; JogVel[3] = edtJogVel03;
            TextBox[] JogAcc = new TextBox[4];
            JogAcc[0] = edtJogAcc00; JogAcc[1] = edtJogAcc01; JogAcc[2] = edtJogAcc02; JogAcc[3] = edtJogAcc03;
            TextBox[] JogDec = new TextBox[4];
            JogDec[0] = edtJogDec00; JogDec[1] = edtJogDec01; JogDec[2] = edtJogDec02; JogDec[3] = edtJogDec03;
            TextBox[] LinePos = new TextBox[4];
            LinePos[0] = edtLinePos00; LinePos[1] = edtLinePos01; LinePos[2] = edtLinePos02; LinePos[3] = edtLinePos03;

            CheckBox[] chkMoveMultiAxes = new CheckBox[4];
            chkMoveMultiAxes[0] = chkAxis00; chkMoveMultiAxes[1] = chkAxis01;
            chkMoveMultiAxes[2] = chkAxis02; chkMoveMultiAxes[3] = chkAxis03;

            bool   bSelectCheck, bEmptyCheck, bAllCheck;
            String strData;
            uint   duOnOff = 0;
            uint   lCount;
            int    lFirstAxisNo = 0;

            m_lMoveMultiAxesCount = 0;
            bSelectCheck = false;
            bEmptyCheck  = false;

            //++ 지정한 축의 정보를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_uModuleID);
            //++ 지정한 보드/모듈의 첫번째 축 번호를 반환합니다.
            CAXM.AxmInfoGetFirstAxisNo(m_lBoardNo, m_lModulePos, ref lFirstAxisNo);            
            
            for(lCount = 0; lCount < 4 ; lCount++){
                //++ 지정한 축이 제어가 가능한 상태인지 반환합니다.
                if (CAXM.AxmInfoGetAxisStatus(lFirstAxisNo) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    strData = string.Format("Axis{0:d2}", lFirstAxisNo);
                    chkMoveMultiAxes[lCount].Enabled = true;

                    bSelectCheck = chkMoveMultiAxes[lCount].Checked;
                    bEmptyCheck |= bSelectCheck;

                    if (bSelectCheck == true)
                        m_lMoveMultiAxes[m_lMoveMultiAxesCount++] = lFirstAxisNo;                    

                    MovePos[lCount].Enabled = bSelectCheck;
                    MoveVel[lCount].Enabled = bSelectCheck;
                    MoveAcc[lCount].Enabled = bSelectCheck;
                    MoveDec[lCount].Enabled = bSelectCheck;

                    JogVel[lCount].Enabled  = bSelectCheck;
                    JogAcc[lCount].Enabled  = bSelectCheck;
                    JogDec[lCount].Enabled  = bSelectCheck;

                    LinePos[lCount].Enabled = bSelectCheck;
                }else{
                    m_lMoveMultiAxes[lCount] = -1;
                    strData = string.Format("Axis --");

                    MovePos[lCount].Enabled = false;
                    MoveVel[lCount].Enabled = false;
                    MoveAcc[lCount].Enabled = false;
                    MoveDec[lCount].Enabled = false;

                    JogVel[lCount].Enabled  = false;
                    JogAcc[lCount].Enabled  = false;
                    JogDec[lCount].Enabled  = false;

                    LinePos[lCount].Enabled = false;
                }
                lFirstAxisNo++;
                chkMoveMultiAxes[lCount].Text = strData;
            }

            edtLineVel.Enabled   = bEmptyCheck;
            edtLineAcc.Enabled   = bEmptyCheck;
            edtLineDec.Enabled   = bEmptyCheck;

            btnJogP.Enabled      = bEmptyCheck;
            btnJogN.Enabled      = bEmptyCheck;

            btnLineP.Enabled     = bEmptyCheck;
            btnLineN.Enabled     = bEmptyCheck;

            btnPosMove.Enabled   = bEmptyCheck;
            btnPosStop.Enabled   = bEmptyCheck;

            btnPosClear.Enabled  = bEmptyCheck;
            chkMoveBlock.Enabled = bEmptyCheck;
            chkServoOn.Enabled   = bEmptyCheck;

            bAllCheck = false;
            for (lCount = 0; lCount < m_lMoveMultiAxesCount; lCount++){
                //++ 지정한 축의 서보온 상태를 반환합니다.
                CAXM.AxmSignalIsServoOn(m_lMoveMultiAxes[lCount], ref duOnOff);
                // 선택된 보간축들이 모두 서보온 되어있을 때 TRUE 
                bAllCheck &= Convert.ToBoolean(duOnOff);
            }
            chkServoOn.Checked = bAllCheck;
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