// StatusMonitorDlg.cpp : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 모션구동과 관련된 상태들을 모니터링하는 예제입니다.
// >> [중요]: 상태함수들 응용범위
//     1) AxmStatusReadMechanical함수는 신호 상태값들을 한번에 읽어 확인할 수
//        있어 각각의 개별 함수들을 이용하는것 보다 효율적입니다.
//     2) AxmStatusReadStop 함수는 구동이 정지된 후 정상구동여부를 확인할 수 
//        있습니다. 모션 구동시 목표위치까지 도달하지 않고 정지하였다면 이 함수의
//        반환값을 분석해 정지원인을 파악할 수 있습니다.   
//     3) AxmStatusReadMotion 함수는 현재 모션 구동중인지, 어떤 구동중인지등의
//        구동상태를 확인할 수 있습니다. 
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatusMonitor
{
    public partial class StatusMonitor : Form
    {
        public  int m_lAxisCounts = 0;                            // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                            // 제어할 축 번호 선언 및 초기화
        public uint m_uModuleID   = 0;                            // 제어할 축의 모듈 I/O 선언 및 초기화 
        public  int m_lBoardNo    = 0, m_lModulePos = 0;

        public StatusMonitor()
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
        private void StatusMotion_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.
        }

        // ++ =======================================================================
        // >> tmDisplay_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
        // --------------------------------------------------------------------------
        private void tmTimer_Load(object sender, EventArgs e)
        {
            int[] iDigitEnd   = { 0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 15, 28, 30, 31 };
            int[] iDigitMech  = { 0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17 };
            int[] iDigitDrive = { 0, 1, 2, 3, 4, 5, 6, 7, 10, 11 };
            
            CheckBox[] MechSig = new CheckBox[14];
            MechSig[0] = chkMechBit00;          MechSig[1] = chkMechBit01;          MechSig[2] = chkMechBit04; 
            MechSig[3] = chkMechBit05;          MechSig[4] = chkMechBit06;          MechSig[5] = chkMechBit07;
            MechSig[6] = chkMechBit08;          MechSig[7] = chkMechBit09;          MechSig[8] = chkMechBit10;
            MechSig[9] = chkMechBit11;          MechSig[10] = chkMechBit12;         MechSig[11] = chkMechBit13;
            MechSig[12] = chkMechBit14;         MechSig[13] = chkMechBit17;

            CheckBox[] EndSig = new CheckBox[14];
            EndSig[0] = chkEndBit00;            EndSig[1] = chkEndBit01;            EndSig[2] = chkEndBit04;
            EndSig[3] = chkEndBit05;            EndSig[4] = chkEndBit06;            EndSig[5] = chkEndBit07;
            EndSig[6] = chkEndBit08;            EndSig[7] = chkEndBit09;            EndSig[8] = chkEndBit10;
            EndSig[9] = chkEndBit11;            EndSig[10] = chkEndBit15;           EndSig[11] = chkEndBit28;
            EndSig[12] = chkEndBit30;           EndSig[13] = chkEndBit31;

            CheckBox[] DriveSig = new CheckBox[10];
            DriveSig[0] = chkDriveBit00;        DriveSig[1] = chkDriveBit01;        DriveSig[2] = chkDriveBit02;
            DriveSig[3] = chkDriveBit03;        DriveSig[4] = chkDriveBit04;        DriveSig[5] = chkDriveBit05;
            DriveSig[6] = chkDriveBit06;        DriveSig[7] = chkDriveBit07;        DriveSig[8] = chkDriveBit10;
            DriveSig[9] = chkDriveBit11;

            int iIndex = 0, iCheck = 0;
            uint duRetCode, duStatus = 0;

            //++ 지정 축의 Mechanical Signal Data(현재 기계적인 신호상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 하드웨어적인 신호가 다르기 때문에 매뉴얼 및 AXHS.xxx파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadMechanical(m_lAxisNo, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                for (iIndex = 0; iIndex < 14; iIndex++){
                    iCheck = ((int)duStatus >> iDigitMech[iIndex] & 0x1);
                    MechSig[iIndex].Checked = Convert.ToBoolean(iCheck);
                }
            }
            //++ 지정 축의 End Status(정지 상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 정지 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadStop(m_lAxisNo, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                for (iIndex = 0; iIndex < 14; iIndex++){
                    iCheck = ((int)duStatus >> iDigitEnd[iIndex] & 0x1);
                    EndSig[iIndex].Checked = Convert.ToBoolean(iCheck);
                }
            }
            //++ 지정 축의 Drive Status(모션중 상태)를 확인합니다.
            // ※ [CAUTION] 각 제품별로 모션중 상태가 다르기 때문에 매뉴얼 및 AXHS.xxx 파일을 참고하십시요.
            duRetCode = CAXM.AxmStatusReadMotion(m_lAxisNo, ref duStatus);
            if (duRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                for (iIndex = 0; iIndex < 10; iIndex++){
                    iCheck = ((int)duStatus >> iDigitDrive[iIndex] & 0x1);
                    DriveSig[iIndex].Checked = Convert.ToBoolean(iCheck);
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
            // Axis Update States
        }
    }
}