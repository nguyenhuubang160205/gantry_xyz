// NormalTriggerMulti.cs : implementation file
//
// **************************************************************************
// >> [일자]: 2016.01.21
// >> [개요]: 이 예제는 AIO모듈의 Normal Trigger 관련 함수들의 사용법을 익히고
//    다중 채널의 아날로그 입력 값을 전압 혹은 Digit 값으로 반환하는 방법을 
//    학습하는 예제입니다.
// >> [중요]: Normal Trigger 관련 함수들
//     1) AxaiSetMultiRange 함수는 지정 다중 입력 채널에 입력 전압 범위를 설정합니다.
//     2) AxaiSetTriggerMode 함수는 지정 입력 모듈에 A/D변환 방식을 설정합니다.
//     3) AxaiSwReadMultiVoltage 함수는 지정 다중 입력 채널의 아날로그 입력 값을 
//        전압으로 반환합니다.
//     4) AxaiSwReadMultiVoltage 함수는 지정 다중 입력 채널의 아날로그 입력 값을 
//        Digit 값으로 반환합니다.
//     ※ AxaiSwReadMultiVoltage 함수를 사용하기 전에 AxaiSetTriggerMode 함수를 사용하여
//        Normal Trigger Mode로 설정해야 합니다.
// **************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NormalTriggerMulti
{
    public partial class NormalTriggerMulti : Form
    {
        uint        m_dwModuleID;			// 모델ID
        int         m_nModuleNo;			// 제어할 모듈 번호
        int         m_nModuleCount;			// 유효한 전체 모듈 수
        int         m_nChannelCount;		// 유효한 전체 채널 수
        bool        m_bIsReadVoltage;		// 입력받을 데이터의 종류(TRUE:Volt, FALSE:DIGIT)
        double[]    m_dOldVoltArr = { 0.0, 0.0, 0.0, 0.0 };		// Timer에서 사용할 이전 Volt
        uint[]      m_dwOldDigitArr = { 0, 0, 0, 0 };			// Timer에서 사용할 이전 Digit

        public NormalTriggerMulti()
        {
            InitializeComponent();
        }

        private void NormalTriggerMulti_Load(object sender, EventArgs e)
        {
            //++
            InitLibrary();					// 라이브러리 초기화 작업을 수행합니다.
            AddModuleChannelInfo();			// 검색된 모듈과 채널 정보를 ComboBox에 등록/Control들을 초기화합니다.
            UpdateState();					// AIO모듈의 상태와 Control들의 상태를 일치시킵니다.
        }

        private void NormalTriggerMulti_FormClosed(object sender, FormClosedEventArgs e)
        {
            //++ AXL 사용을 종료합니다.
            CAXL.AxlClose();
        }

        // **************************************************************************
        // >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음 
        // **************************************************************************

        // ++ =======================================================================
        // >> m_cboModule_SelectedIndexChanged() : 모듈 변경시 호출되는 핸들러 함수.
        //  - 모듈이 변경되었을 때 변경된 모듈의 ID와 Control들을 갱신합니다.
        // --------------------------------------------------------------------------
        private void m_cboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            //uint dwRetCode = 0;
            int nBoardNo = 0, nModulePos = 0;
            //String strChNum;

            m_nModuleNo = m_cboModule.SelectedIndex;
            // 변경된 모듈의 ID를 가져옵니다.
            CAXA.AxaInfoGetModule(m_nModuleNo, ref nBoardNo, ref nModulePos, ref m_dwModuleID);

            // 변경된 모듈의 채널 수를 가져옵니다.
            CAXA.AxaInfoGetInputCount(m_nModuleNo, ref m_nChannelCount);

            // 전압 범위 업데이트
            //++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
            UpdateState();

            // Normal 트리거 설정
            // 현재 SIO_AI8AO4F 모듈이 등록되어있지 않아서 지원하지 않는 하드웨어라고 뜨는 것으로 보임.
            /*
            uint a = 0;
            dwRetCode = CAXA.AxaiGetTriggerMode(m_nModuleNo, ref a);
            dwRetCode = CAXA.AxaiSetTriggerMode(m_nModuleNo, (uint)AXT_AIO_TRIGGER_MODE.NORMAL_MODE);
            if(dwRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                String strData;
                strData = String.Format("AxaiSetTriggerMode return error[Code:{0:0000}]", dwRetCode);
                MessageBox.Show(strData);
            }
            */
        }

        // ++ =======================================================================
        // >> m_cboVoltageRange_SelectedIndexChanged() : 입력 전압 범위 변경시 호출되는 핸들러 함수.
        //  - 해당 채널의 입력 전압 범위를 갱신합니다.
        //  - 입력 전압 범위는 A/D변환 성능과 관련이 있으므로 측정 범위 확인 후 설정하시기 바랍니다.
        //  - 모듈별로 허용 입력 전압이 정해져 있습니다. 
        //  - 사용자가 입력 전압 설정범위 이외 전압을 입력하면 자동으로 그 값을 포함하는 근삿값으로 자동 설정됩니다.
        // --------------------------------------------------------------------------
        private void m_cboVoltageRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint    dwRetCode = 0;
            double  dMinVolt = 0.0, dMaxVolt = 0.0;
            int[]	nChannelArr = {0, 1, 2, 3};

            switch (m_cboVoltageRange.SelectedIndex)
            {
                case 0:
                    dMinVolt = -10.0;
                    dMaxVolt = 10.0;
                    break;

                case 1:
                    dMinVolt = -5.0;
                    dMaxVolt = 5.0;
                    break;

                case 2:
                    dMinVolt = 0.0;
                    dMaxVolt = 10.0;
                    break;

                case 3:
                    dMinVolt = 0.0;
                    dMaxVolt = 5.0;
                    break;

                default:
                    break;
            }

            // 입력 전압 범위를 설정합니다.
            //dwRetCode = CAXA.AxaiSetRange(, dMinVolt, dMaxVolt);
            dwRetCode = CAXA.AxaiSetMultiRange(4, nChannelArr, dMinVolt, dMaxVolt);
            if (dwRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                String strData;
                strData = String.Format("AxaiSetMultiRange return error[Code:{0:0000}]", dwRetCode);
                MessageBox.Show(strData);
            }
        }

        // ++ =======================================================================
        // >> m_cboValueType_SelectedIndexChanged() : 입력 정보 종류를 변경시 호출되는 핸들러 함수.
        //  - 입력값을 전압 또는 10진수로 출력할 때 설정합니다.
        // --------------------------------------------------------------------------
        private void m_cboValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nValueType = 0;

            nValueType = (int)ConvertComboToAxa(ref m_cboValueType);
            if (nValueType == 0)
            {
                m_bIsReadVoltage = true;
            }
            else
            {
                m_bIsReadVoltage = false;
            }
        }

        // ++ =======================================================================
        // >> m_btnStart_Click() : "Start"버튼 클릭시 호출되는 핸들러 함수.
        //  - 단일 채널에 들어오는 값을 Normal Trigger로 읽기 시작합니다.
        // --------------------------------------------------------------------------
        private void m_btnStart_Click(object sender, EventArgs e)
        {
            m_cboModule.Enabled = false;
            m_cboVoltageRange.Enabled = false;
            m_cboValueType.Enabled = false;
            m_btnStart.Enabled = false;
            m_btnStop.Enabled = true;

            // Normal Trigger 시작
            m_timer.Enabled = true;
        }

        // ++ =======================================================================
        // >> m_btnStop_Click() : "Stop"버튼 클릭시 호출되는 핸들러 함수.
        //  - 작업을 중지합니다.
        // --------------------------------------------------------------------------
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            m_cboModule.Enabled = true;
            m_cboVoltageRange.Enabled = true;
            m_cboValueType.Enabled = true;
            m_btnStart.Enabled = true;
            m_btnStop.Enabled = false;

            // Normal Trigger 종료
            m_timer.Enabled = false;
        }

        // ++ =======================================================================
        // >> m_timer_Tick(...) : 타이머 이벤트 핸들러 함수.
        //  - Normal Trigger로 입력 값을 주기적으로 갱신합니다.
        // --------------------------------------------------------------------------
        private void m_timer_Tick(object sender, EventArgs e)
        {
            String strValue = "";
            int[] nChannelArr = { 0, 1, 2, 3 };
            TextBox[] stcChArr = { m_stcCh00, m_stcCh01, m_stcCh02, m_stcCh03 };

            if (m_bIsReadVoltage)
            {
                double[] dVoltArr = { 0.0, 0.0, 0.0, 0.0 };
                // 지정 채널로 들어오는 값을 전압 단위로 읽어옵니다.
                CAXA.AxaiSwReadMultiVoltage(4, nChannelArr, dVoltArr);
                for (int i = 0; i < 4; i++)
                {
                    if (m_dOldVoltArr[i] != dVoltArr[i])
                    {
                        strValue = String.Format("{0:0.0000}", dVoltArr[i]);
                        stcChArr[i].Text = strValue;
                        m_dOldVoltArr[i] = dVoltArr[i];
                    }
                }
            }
            else
            {
                uint[] dwDigitArr = { 0, 0, 0, 0 };
                // 지정 채널로 들어오는 값을 10진수 단위로 읽어옵니다.
                CAXA.AxaiSwReadMultiDigit(4, nChannelArr, dwDigitArr);
                for (int i = 0; i < 4; i++)
                {
                    if (m_dwOldDigitArr[i] != dwDigitArr[i])
                    {
                        strValue = String.Format("{0:0}", dwDigitArr[i]);
                        stcChArr[i].Text = strValue;
                        m_dwOldDigitArr[i] = dwDigitArr[i];
                    }
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
        public bool InitLibrary()
        {
            uint dwStatus = 0, dwRetCode = 0;

            //++ AXL(AjineXtek Library)을 사용가능하게 하고 장착된 보드들을 초기화합니다.
            dwRetCode = CAXL.AxlOpenNoReset(7);
            if (dwRetCode != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                MessageBox.Show("Intialize Fail..!!");
                return false;
            }

            //++ AIO모듈 존재여부를 확인합니다
            dwRetCode = CAXA.AxaInfoIsAIOModule(ref dwStatus);
            if (dwStatus != (uint)AXT_EXISTENCE.STATUS_EXIST)
            {
                MessageBox.Show("The Module does not exist...");
                return false;
            }

            return true;
        }

        // ++ =======================================================================
        // >> InitControl() : Control들에 초기값을 설정하는 함수.
        //  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
        // --------------------------------------------------------------------------
        public bool InitControl()
        {
            int nBoardNo = 0, nModulePos = 0;

            m_nModuleNo = 0;
            m_bIsReadVoltage = true;

            m_cboModule.SelectedIndex = 0;
            m_cboValueType.SelectedIndex = 0;
            
            m_btnStop.Enabled = false;

            // 첫번째 모듈의 ID를 가져옵니다.
            CAXA.AxaInfoGetModule(m_nModuleNo, ref nBoardNo, ref nModulePos, ref m_dwModuleID);

            return true;
        }

        // ++ =======================================================================
        // >> AddModuleChannelInfo() : 시스템에 장착된 AIO모듈들을 ComboBox에 등록하는 함수.
        //  - AIO모듈 정보를 읽어 ComboBox에 등록하여 사용자가 선택
        //    제어할 수 있도록 합니다.
        //  - 유효한 모듈이 검색되었을 때 Control들을 초기화 합니다.
        // --------------------------------------------------------------------------
        public bool AddModuleChannelInfo()
        {
            string strData = "";
            int nInputCount = 0, nBoardNo = 0, nModulePos = 0;
            uint dwModuleID = 0;
            // 시스템에 장착된 모든AIO 모듈의 개수를 확인합니다.
            uint dwRetCode = CAXA.AxaInfoGetModuleCount(ref m_nModuleCount);

            for (int iModuleNo = 0; iModuleNo < m_nModuleCount; iModuleNo++)
            {
                // 각 모듈의 입력 채널 수를 확인합니다.
                CAXA.AxaInfoGetInputCount(iModuleNo, ref nInputCount);
                if (nInputCount > 0)
                {
                    // 해당 모듈의 정보를 가져옵니다.
                    dwRetCode = CAXA.AxaInfoGetModule(iModuleNo, ref nBoardNo, ref nModulePos, ref dwModuleID);
                    if (dwRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        switch (dwModuleID)
                        {
                            case (uint)AXT_MODULE.AXT_SIO_AI4RB:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_AI4RB [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_AI16H:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_AI16H [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_AI16HB:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_AI16HB [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RAI8RB:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RAI8RB [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RAI4MLII:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RAI4MLII [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RAI16RB:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RAI16RB [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RAVCI4MLII:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RAVCI4MLII [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RATI4MLII:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RATI4MLII [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RARTDI4MLII:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RARTDI4MLII [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_RAO08RTEX:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_RAO08RTEX [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_AI8F:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_AI8F [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_SIO_AI8AO4F:
                                strData = String.Format("[BD No:{0:00} - MD No:{1:00}] SIO_AI8A04F [Input : {2:00}]", nBoardNo, iModuleNo, nInputCount);
                                break;
                            case (uint)AXT_MODULE.AXT_ECAT_AIO:
                                if (nInputCount > 0)
                                {
                                    // EtherCAT AIO 전용 모듈 정보 추출
                                    uint upModuleSubID = 0;
                                    var szModuleName = new System.Text.StringBuilder(50);
                                    var szModuleDescription = new System.Text.StringBuilder(80);
                                    CAXA.AxaInfoGetModuleEx(iModuleNo, ref upModuleSubID, szModuleName, szModuleDescription);
                                    strData = String.Format("[BD No:{0:00} - MD No:{1:00}] {2} [Input : {3:00}]", nBoardNo, iModuleNo, szModuleName, nInputCount);
                                }
                                break;
                        }
                        m_cboModule.Items.Add(strData);
                    }
                }
            }

            InitControl();

            return true;

        }

        // ++ =======================================================================
        // >> UpdateState() : 지정한 모듈의 설정값들을 읽어 Control과 일치시키는 함수.
        //  - 모듈이 변경되었을 때 변경한 모듈의 설정값들과 Control들과 일치시키는 
        //    역할을하는 함수입니다.
        //  - 지정한 모듈의 모델별 제약들을 Control에 반영하는 역할을 합니다.
        //  - 프로그램 초기 실행시, 모듈 번호 바뀔 때 사용됩니다.
        // --------------------------------------------------------------------------
        public bool UpdateState()
        {
            if (m_nModuleCount < 1) return false;

            //++ 각 모듈별 지원여부에 따라 콘트롤 값들을 변경합니다.
            m_cboVoltageRange.Items.Clear();
            m_cboVoltageRange.Enabled = true;
            switch (m_dwModuleID)
            {
                case (uint)AXT_MODULE.AXT_SIO_AI4RB:
                case (uint)AXT_MODULE.AXT_SIO_AO4RB:
                case (uint)AXT_MODULE.AXT_SIO_AI8AO4F:
                    m_cboVoltageRange.Items.Add("00: -10V ~ +10V");
                    m_cboVoltageRange.Items.Add("01: -5V ~ +5V");
                    m_cboVoltageRange.Items.Add("02: 0V ~ +10V");
                    m_cboVoltageRange.Items.Add("03: 0V ~ +5V");
                    break;

                case (uint)AXT_MODULE.AXT_SIO_AI8F:
                case (uint)AXT_MODULE.AXT_SIO_AO4F:
                    m_cboVoltageRange.Items.Add("00: -10V ~ +10V");
                    m_cboVoltageRange.Items.Add("01: -5V ~ +5V");
                    break;

                default:
                    break;
            }

            //++ 지정 입력 채널에 설정한 입력 전압 범위를 확인합니다.
            UpdateVoltageRange();

            return true;
        }

        // ++ =======================================================================
        // >> ConvertComboToAxa(...) : ComboBox콘트롤에 현재 선택된 Item Index를 모션
        //    보드에 설정할 값으로 변경하는 함수.
        //  - ComboBox에 선택된 Item Index와 실제 모듈에 설정되는 값이 다르므로 
        //    선택된 문자열에서 모듈에 설정할 값을 추출해서 반환하는 함수입니다.
        //  - 변환 할 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
        //  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
        //    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
        //    Ex) "00: Volt", "01: Digit"
        // --------------------------------------------------------------------------
        public uint ConvertComboToAxa(ref ComboBox pCboItem)
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
        // >> ConvertAxaToCombo(...) : 지정한 모듈의 설정값과 ComboBox콘트롤의  
        //    Item과 일치하는 Item을 찾아 선택하는 함수.
        //  - 실제 모듈값과 ComboBox의 Item Index가  다르므로 지정한
        //    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
        //  - 변경하고자하는 ComboBox 콘트롤의 포인터를 인자로 전달합니다.
        //  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
        //    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
        //    Ex) "00: Volt", "01: Digit"
        // --------------------------------------------------------------------------
        public uint ConvertAxmToCombo(ref ComboBox pCboItem, uint diCurData)
        {
            if (pCboItem == null) return 0;

            uint lCount, lSeldata;
            String strText;

            lCount = (uint)pCboItem.Items.Count;

            if (lCount == 0) return 0;

            for (int i = 0; i < lCount; i++)
            {
                strText = pCboItem.Items[i].ToString();
                lSeldata = Convert.ToUInt32(strText.Substring(0, 2));
                if (lSeldata == (uint)diCurData)
                {
                    pCboItem.SelectedIndex = i;
                    return (uint)i;
                }
            }
            pCboItem.SelectedIndex = 0;
            return 0;
        }

        // ++ =======================================================================
        // >> UpdateVoltageRange(...) : 전압 범위를 갱신하는 함수.
        //  - 모듈 변경 시 0번 채널의 입력 전압 범위로
        //    Control값을 변경합니다.
        // --------------------------------------------------------------------------
        public void UpdateVoltageRange()
        {
            uint dwRetCode = 0;
            double dMinVolt = 0.0, dMaxVolt = 0.0;

            //++ 0번 입력 채널을 대표로 입력 전압 범위를 확인합니다.
            dwRetCode = CAXA.AxaiGetRange(0, ref dMinVolt, ref dMaxVolt);
            if (dwRetCode == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                if (dMinVolt == -10.0 && dMaxVolt == 10.0)
                    m_cboVoltageRange.SelectedIndex = 0;
                else if (dMinVolt == -5.0 && dMaxVolt == 5.0)
                    m_cboVoltageRange.SelectedIndex = 1;
                else if (dMinVolt == 0.0 && dMaxVolt == 10.0)
                    m_cboVoltageRange.SelectedIndex = 2;
                else if (dMinVolt == 0.0 && dMaxVolt == 5.0)
                    m_cboVoltageRange.SelectedIndex = 3;
            }
            else
            {
                m_cboVoltageRange.SelectedIndex = 0;
            }
        }
    }
}