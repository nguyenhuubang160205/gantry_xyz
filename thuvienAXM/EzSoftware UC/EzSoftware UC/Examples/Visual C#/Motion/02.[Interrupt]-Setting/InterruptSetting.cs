// InterruptSetting.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2011.03.25
// >> [개요]: 이 예제는 인터럽트 함수들의 사용법을 읽히고 윈도우 응용프로그램에서
//     여러가지 인터럽트 처리 방법에 대해 학습하는 예제입니다.
// >> [중요]: 인터럽트 사용방법 
//     1) AxlInterruptEnable함수를 이용해서 AXL라이브러리에 인터럽트를 허용합니다.
//     2) AxmInterruptSetAxis함수를 이용해 각 축에 인터럽트 처리 방식을 설정합니다.
//     3) AxmInterruptSetUserEnable함수를 이용해 지정한 축에 사용할 인터럽트 
//        종류들을 설정합니다. Ex) AxmInterruptSetUserEnable(0, INT_BANK_1, 0x6)
//     4) AxmInterruptSetAxisEnable 함수를 이용해 지정한 축에 인터럽트를 허용합니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

public enum AXT_INTERRUPT_CLASS : uint
{
    KIND_MESSAGE,
    KIND_CALLBACK,
    KIND_EVENT
}

namespace InterruptSetting
{
    public partial class InterruptSetting : Form
    {
        public InterruptSetting()
        {
            InitializeComponent();
        }
        delegate void SetTextCallBack(string strLog);

        public  int m_lAxisCounts = 0;                            // 제어 가능한 축갯수 선언 및 초기화
        private int m_lAxisNo     = 0;                            // 제어할 축 번호 선언 및 초기화
        public uint m_duModuleID  = 0;                            // 제어할 축의 모듈 I/O 선언 및 초기화
        public  int  m_lBoardNo   = 0, m_lModulePos = 0;

        //Interrupt Count
        public int   m_nInterruptCnt = 0;                         // 인터럽트 카운트

        //thread
        private static InterruptSetting    m_InterruptSetting = null;

        //event
        uint[]           m_uEventInterrupt = new uint[64];
        bool[]           m_bEventThread    = new bool[64];
        private Thread[] m_EventThread     = new Thread[64];

        public readonly static uint INFINITE      = 0xFFFFFFFF;
        public readonly static uint STATUS_WAIT_0 = 0x00000000;
        public readonly static uint WAIT_OBJECT_0 = ((STATUS_WAIT_0) + 0);

        [DllImport("kernel32", EntryPoint = "WaitForSingleObject", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint WaitForSingleObject(uint hHandle, uint dwMilliseconds);

        // **************************************************************************
        // >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
        // **************************************************************************

        // ++ =======================================================================
        // >> Project Name_Load(...) : 프로젝트 Form 초기화 함수.
        //  - Form을 Load시 불러내는 함수, 초기화에 사용합니다.
        // --------------------------------------------------------------------------
        private void FormInterrupt_Load(object sender, EventArgs e)
        {
            initLibrary();                                        // 라이브러리 초기화 및 Mot파일을 불러옵니다.
            AddAxisInfo();                                        // 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();                                        // 모션보드의 상태와 Control들의 상태를 일치시킵니다.;
            CheckForIllegalCrossThreadCalls = false;              // 쓰레드 예외 처리 무시하기
            m_InterruptSetting  = this;
        }

        // ++ =======================================================================
        // >> cboAxisSet_SelectedIndexChanged() : 축 번호 변경시 호출되는 핸들러 함수.
        //  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
        // --------------------------------------------------------------------------
        private void cboAxisSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_lAxisNo = cboSelAxis.SelectedIndex;                  // 축 선택 ComboBox에서 선택된 축번호를 제어할 축 번호 변수에 설정합니다.

            //++ 지정한 축번호의 모듈ID를 반환합니다.
            // [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 NULL(0)을 입력하면 됩니다.
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_duModuleID);

            UpdateState();                                         // 변경한 축의 상태와 Control들의 상태를 일치시킵니다.	
        }

        // ++ =======================================================================
        // >> btnSetBank1_Click() : "Set Bank 1"버튼 클릭시 호출되는 핸들러 함수.
        //  - 인터럽트 Bank1에 설정가능한 인터럽트를 설정합니다.
        // --------------------------------------------------------------------------
        private void btnSetBank1_Click(object sender, EventArgs e)
        {	
            uint   duRetCode = 0;
	        uint   dwIntMask = 0;
            uint[] dwBitMask = { (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_0, (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_1, 
                                 (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_2, (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_31 };

            if (chkBank1Bit00.Checked) dwIntMask |= dwBitMask[0];
            if (chkBank1Bit01.Checked) dwIntMask |= dwBitMask[1];
            if (chkBank1Bit02.Checked) dwIntMask |= dwBitMask[2];
            if (chkBank1Bit31.Checked) dwIntMask |= dwBitMask[3];

            //++ 지정한 축에 모션구동 시작시, 모셔구동 종료시 등의 인터럽트를 설정합니다.
            duRetCode = CAXM.AxmInterruptSetUserEnable(m_lAxisNo, 0, dwIntMask);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)            
                MessageBox.Show(String.Format("AxmInterruptSetUserEnable return error[Code:{0:d}]", duRetCode));  
                       
            UpdateState();
        }

        // ++ =======================================================================
        // >> btnSetBank2_Click() : "Set Bank 2"버튼 클릭시 호출되는 핸들러 함수.
        //  - 인터럽트 Bank2에 설정가능한 인터럽트를 설정합니다.
        // --------------------------------------------------------------------------
        private void btnSetBank2_Click(object sender, EventArgs e)
        {
            uint duRetCode = 0;
            uint dwIntMask = 0;
            uint[] dwBitMask = { (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_14, (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_15, 
                                 (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_16, (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_20, 
                                 (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_21, (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_22 };

            if (chkBank2Bit14.Checked) dwIntMask |= dwBitMask[0];
            if (chkBank2Bit15.Checked) dwIntMask |= dwBitMask[1];
            if (chkBank2Bit16.Checked) dwIntMask |= dwBitMask[2];
            if (chkBank2Bit20.Checked) dwIntMask |= dwBitMask[3];
            if (chkBank2Bit21.Checked) dwIntMask |= dwBitMask[4];
            if (chkBank2Bit22.Checked) dwIntMask |= dwBitMask[5];

            //++ 지정한 축에 범용입력 변화시, 범용출력 변화시 등의 인터럽트를 설정합니다.
            duRetCode = CAXM.AxmInterruptSetUserEnable(m_lAxisNo, 1, dwIntMask);
            if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                MessageBox.Show(String.Format("AxmInterruptSetUserEnable return error[Code:{0:d}]", duRetCode));  
            UpdateState();
        }

        // ++ =======================================================================
        // >> chkInterruptEnable_CheckedChanged() : "Interrupt Enable"버튼 클릭시 호출되는 핸들러 함수.
        //  - 인터럽트 처리 방식에 따라 인터럽트를 설정합니다.
        // ※ [CAUTION] 인터럽트 사용시 사용자가 구현하는 인터럽트 처리함수는 되도록이면
        //    간결하게 작성하는게 좋습니다(콘트롤 업데이트등은 옳지 않음). 왜냐하면 
        //    인터럽트가 발생하는 시간보다 함수처리 시간이 길어지게되면 놓치는 경우가 
        //    빈번하게 발생할 수 있기 때문입니다.
        // --------------------------------------------------------------------------
        private void chkInterruptEnable_CheckedChanged(object sender, EventArgs e)
        {
            uint duRetCode = 0;

            UpdateState();
            if (chkIntEnable.Checked)
            {
                //++ 인터럽트 처리방식을 윈도우메세지 방식으로 지정함
                if (rdoMessage.Checked == true){
                    uint uEvent = 0;
                    CAXM.AxmInterruptSetAxis(m_lAxisNo, (uint)this.Handle, (uint)AXT_EVENT.WM_AXL_INTERRUPT, null, ref uEvent);            
                }
                //++ 인터럽트 처리방식을 콜벡함수 방식으로 지정함
                else if (rdoCallback.Checked == true){
                    uint uEvent = 0;

                    if (m_EventThread[m_lAxisNo] != null){
                        m_EventThread[m_lAxisNo].Abort();
                        m_EventThread[m_lAxisNo] = null;
                        m_bEventThread[m_lAxisNo] = false;
                    }
                    CAXM.AxmInterruptSetAxis(m_lAxisNo, 0, 0, new CAXHS.AXT_INTERRUPT_PROC(InterruptCallback), ref uEvent);
                }
                //++ 인터럽트 처리방식을 이벤트 방식으로 지정함
                else{
                    CAXM.AxmInterruptSetAxis(m_lAxisNo, 0, 0, null, ref m_uEventInterrupt[m_lAxisNo]);

                    if (m_EventThread[m_lAxisNo] != null){
                        m_EventThread[m_lAxisNo].Abort();
                        m_EventThread[m_lAxisNo] = null;
                        m_bEventThread[m_lAxisNo] = false;
                    }

                    if (m_bEventThread[m_lAxisNo] == false){
                        int lAxisNo = new int();
                        lAxisNo = m_lAxisNo;
                        m_bEventThread[m_lAxisNo] = true;
                        // 해당축의 인터럽트 이벤트를 대기할 쓰레드 생성
                        m_EventThread[m_lAxisNo] = new Thread(new ParameterizedThreadStart(EventThreadProc));
                        m_EventThread[m_lAxisNo].Start(lAxisNo);
                        m_EventThread[m_lAxisNo].IsBackground = true;
                    }
                }
                //++ AXL라이브러리의 인터럽트 발생을 허용합니다.
                CAXL.AxlInterruptEnable();
                //++ 지정한 축에 인터럽트 발생을 허용합니다.
                duRetCode = CAXM.AxmInterruptSetAxisEnable(m_lAxisNo, (uint)AXT_USE.ENABLE);
                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    MessageBox.Show(String.Format("AxmInterruptSetAxisEnable return error[Code:{0:d}]", duRetCode));
                    chkIntEnable.Checked = false;
                }
            }else{
                //++ AXL라이브러리의 인터럽트 발생을 금지합니다.
                CAXL.AxlInterruptDisable();
                //++ 지정한 축에 인터럽트 발생을 금지합니다.
                duRetCode = CAXM.AxmInterruptSetAxisEnable(m_lAxisNo, (uint)AXT_USE.DISABLE);

                if (duRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS){
                    MessageBox.Show(String.Format("AxmInterruptSetAxisEnable return error[Code:{0:d}]", duRetCode));
                    chkIntEnable.Checked = false;
                }
            }
        }

        // ++ =======================================================================
        // >> lstIntLog_DoubleClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
        //  - 등록된 인터럽트 로그를 지울때 호출됩니다.
        // --------------------------------------------------------------------------
        private void lstIntLog_DoubleClick(object sender, EventArgs e)
        {
            m_nInterruptCnt = 0;
            lstIntLog.Items.Clear();
        }

        // ++ =======================================================================
        // >> lstIntLog_MouseDoubleClick() : ListBox 콘트롤 마우스 더블클릭시 호출되는 핸들러 함수.
        //  - 등록된 인터럽트 로그를 지울때 호출됩니다.
        //  - List Box 콘트롤에서 마우스 오르쪽 버튼을 더블클릭하면 이 함수가 호출됩니다.
        // --------------------------------------------------------------------------
        private void lstIntLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstIntLog.Items.Clear();
        }

        // ++ =======================================================================
        // >> Project Name_FormClosed(...) : 프로젝트 Form 종료 함수.
        //  - Form을 Close시 불러내는 함수, Form 종료시 사용됩니다.
        // --------------------------------------------------------------------------
        private void InterruptSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
            if (CAXL.AxlOpen(7) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS) MessageBox.Show("Intialize Fail..!!");
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
            CAXM.AxmInfoGetAxis(m_lAxisNo, ref m_lBoardNo, ref m_lModulePos, ref m_duModuleID);

            // 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
            for (int i = 0; i < m_lAxisCounts; i++)
            {
                switch (m_duModuleID){
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
                    default: strAxis = String.Format("{0:00}-[Unknown] : Not support", i); break;
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

            rdoMessage.Checked = true;
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
            cboSelAxis.SelectedIndex = m_lAxisNo;

            uint dwIntMask = 0;
            string strIntMask = "";

            //++ 지정한 축의 인터럽트 Bank1의 설정값을 확인합니다.
            CAXM.AxmInterruptGetUserEnable(m_lAxisNo, 0, ref dwIntMask);
            strIntMask = string.Format("Interrupt Event Bank 1 [0x{0:X8}]", dwIntMask);
            GrpBank1.Text = strIntMask;

            // 인터럽트 설정값 해당 콘트롤에 적용
            chkBank1Bit00.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_0);
            chkBank1Bit01.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_1);
            chkBank1Bit02.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_2);
            chkBank1Bit31.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK1.QIINTBANK1_31);

            //++ 지정한 축의 인터럽트 Bank2의 설정값을 확인합니다.
            CAXM.AxmInterruptGetUserEnable(m_lAxisNo, 1, ref dwIntMask);
            strIntMask = string.Format("Interrupt Event Bank 2 [0x{0:X8}]", dwIntMask);
            GrpBank2.Text = strIntMask;

            // 인터럽트 설정값 해당 콘트롤에 적용
            chkBank2Bit14.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_14);
            chkBank2Bit15.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_15);
            chkBank2Bit16.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_16);
            chkBank2Bit20.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_20);
            chkBank2Bit21.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_21);
            chkBank2Bit22.Checked = Convert.ToBoolean(dwIntMask & (uint)AXT_MOTION_QIINTERRUPT_BANK2.QIINTBANK2_22);
        }

        // ++ =======================================================================
        // >> InterruptProc(...) : Message, Callback, Event 메세지를 ListBox에 입력 하는 함수
        //  - 인터럽트 정보를 List Box에 등록합니다.
        // --------------------------------------------------------------------------
        private bool InterruptProc(AXT_INTERRUPT_CLASS uClass, int nAxisNo, uint nIntrFlag)
        {
            uint IntBank0 = 0;
            uint IntBank1 = 0;
            int nInterFlag = (int)nIntrFlag;

            String strLog = "";

            switch (uClass){
                case AXT_INTERRUPT_CLASS.KIND_MESSAGE:
                    ++m_nInterruptCnt;
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 0, ref IntBank0);
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 1, ref IntBank1);
                    strLog = String.Format("{0:000}[M] AxisNo : {1:00}, Flag : {2:0}[{3:X}H], Bank0: {4:0}[{5:X}H], Bank1: {6:0}[{7:X}H]",
                        m_nInterruptCnt, m_lAxisNo, nInterFlag, nInterFlag, IntBank0, IntBank0, IntBank1, IntBank1);
                    break;

                case AXT_INTERRUPT_CLASS.KIND_CALLBACK:
                    ++m_nInterruptCnt;
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 0, ref IntBank0);
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 1, ref IntBank1);
                    strLog = String.Format("{0:000}[C] AxisNo : {1:00}, Flag : {2:0}[{3:X}H], Bank0: {4:0}[{5:X}H], Bank1: {6:0}[{7:X}H]",
                        m_nInterruptCnt, m_lAxisNo, nInterFlag, nInterFlag, IntBank0, IntBank0, IntBank1, IntBank1);
                    break;

                case AXT_INTERRUPT_CLASS.KIND_EVENT:
                    ++m_nInterruptCnt;
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 0, ref IntBank0);
                    CAXM.AxmInterruptReadAxisFlag(nAxisNo, 1, ref IntBank1);
                    strLog = String.Format("{0:000}[E] AxisNo : {1:00}, Flag : {2:0}[{3:X}H], Bank0: {4:0}[{5:X}H], Bank1: {6:0}[{7:X}H]",
                        m_nInterruptCnt, m_lAxisNo, nInterFlag, nInterFlag, IntBank0, IntBank0, IntBank1, IntBank1);
                    break;
            }
            AddLogMessage(strLog);
            return true;
        }


        // ++ =======================================================================
        // >> AddLogMessage(...) : 인터럽트 정보를 List Box에 등록하는 함수.
        //  - 인터럽트 정보를 List Box에 등록하고 항상 최신데이타가 List Box에 보여지도록 
        //    자동 스크롤을 해 줍니다.
        // --------------------------------------------------------------------------
        private void AddLogMessage(string strLog)
        {
                this.lstIntLog.Items.Add(strLog);
                this.lstIntLog.SelectedIndex = this.lstIntLog.Items.Count - 1;
        }

        // ++ =======================================================================
        // >> WndProc(...) : 인터럽트 메시지 핸들러 함수.
        //  - 인터럽트 방식중 윈도 메세지 방식으로 인터럽트를 사용할 경우 라이브러리에서
        //    인터럽트 발생시 자동으로 호출되는 인터럽트 메세지 처리 함수입니다.
        // --------------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg){
                case (int)AXT_EVENT.WM_AXL_INTERRUPT:
                    InterruptProc(AXT_INTERRUPT_CLASS.KIND_MESSAGE, (int)m.WParam, (uint)m.LParam);
                    break;
            }
            base.WndProc(ref m);
        }

        // ++ =======================================================================
        // >> MotionIntCallback(...) : 인터럽트 처리 콜벡함수.
        //  - 인터럽트 방식중 콜벡함수 방식으로 인터럽트를 사용할 경우 라이브러리에서
        //    인터럽트 발생시 자동으로 호출되는 인터럽트 콜벡함수입니다.
        //  - nAxisNo에는 인터럽트 발생 축 정보가 전달됩니다.
        //  - dwFlag에는 인터럽트가 발생된 Bank정보가 전달 됩니다.
        // --------------------------------------------------------------------------
        public static void InterruptCallback(int nAxisNo, uint uFlag)
        {
            m_InterruptSetting.InterruptProc(AXT_INTERRUPT_CLASS.KIND_CALLBACK, nAxisNo, uFlag);
        }

        // ++ =======================================================================
        // >> ThreadEventProc(...) : 인터럽트 이벤트 처리 쓰레드.
        //  - 인터럽트 방식중 이벤트 방식으로 인터럽트를 사용할 경우 라이브러리에서
        //    인터럽트 발생시 자동으로 발생되는 인터럽트 이벤트 처리용 쓰레드입니다.
        // --------------------------------------------------------------------------
        public void EventThreadProc(Object objData)
        {
            int nAxisNo = (int)objData;
            while (m_bEventThread[nAxisNo] == true){
                if (WaitForSingleObject(m_uEventInterrupt[nAxisNo], INFINITE) == WAIT_OBJECT_0){
                    InterruptProc(AXT_INTERRUPT_CLASS.KIND_EVENT, nAxisNo, 0);
                }
            }
        }
    }
}