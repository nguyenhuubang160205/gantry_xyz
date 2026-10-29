VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form SignalMonitor 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "SignalMonitor"
   ClientHeight    =   7185
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7185
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7185
   ScaleWidth      =   7185
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame5 
      Caption         =   "< Software Limit >"
      Height          =   1770
      Left            =   90
      TabIndex        =   33
      Top             =   5325
      Width           =   7005
      Begin VB.CheckBox chkSWEnable 
         Caption         =   "Enable"
         Height          =   330
         Left            =   225
         Style           =   1  'Graphical
         TabIndex        =   44
         Top             =   1335
         Width           =   6480
      End
      Begin VB.TextBox edtSWPosP 
         Alignment       =   1  'Right Justify
         Height          =   330
         Left            =   4995
         TabIndex        =   43
         Top             =   945
         Width           =   1785
      End
      Begin VB.ComboBox cboSWRef 
         Height          =   315
         Left            =   4995
         TabIndex        =   41
         Top             =   585
         Width           =   1815
      End
      Begin VB.TextBox edtSWPosN 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1620
         TabIndex        =   39
         Top             =   960
         Width           =   1755
      End
      Begin VB.ComboBox cboSWStop 
         Height          =   315
         Left            =   1620
         TabIndex        =   37
         Top             =   585
         Width           =   1755
      End
      Begin VB.CheckBox chkSWLimitP 
         Caption         =   "(+) Software End Limit"
         Enabled         =   0   'False
         Height          =   360
         Left            =   3660
         TabIndex        =   35
         Top             =   240
         Width           =   2910
      End
      Begin VB.CheckBox chkSWLimitN 
         Caption         =   "(-) Software End Limit"
         Enabled         =   0   'False
         Height          =   315
         Left            =   180
         TabIndex        =   34
         Top             =   240
         Width           =   2880
      End
      Begin VB.Label Label7 
         Caption         =   "(+) Soft EndPos  :"
         Height          =   270
         Left            =   3675
         TabIndex        =   42
         Top             =   975
         Width           =   1335
      End
      Begin VB.Label Label6 
         Caption         =   "Reference Pos   :"
         Height          =   270
         Left            =   3675
         TabIndex        =   40
         Top             =   615
         Width           =   1470
      End
      Begin VB.Label Label5 
         Caption         =   "(-) Soft EndPos     :"
         Height          =   255
         Left            =   180
         TabIndex        =   38
         Top             =   990
         Width           =   1350
      End
      Begin VB.Label Label4 
         Caption         =   "Stop Mode           :"
         Height          =   255
         Left            =   195
         TabIndex        =   36
         Top             =   630
         Width           =   1335
      End
      Begin VB.Line Line4 
         X1              =   3450
         X2              =   3450
         Y1              =   225
         Y2              =   1335
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "< Input Signal Monitor >"
      Height          =   2040
      Left            =   120
      TabIndex        =   14
      Top             =   3225
      Width           =   6990
      Begin MSComDlg.CommonDialog CommonDialog1Open 
         Left            =   2715
         Top             =   840
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Timer m_timer 
         Interval        =   100
         Left            =   2745
         Top             =   390
      End
      Begin VB.CheckBox chkOut 
         Caption         =   "Output Bit 04                                    "
         Height          =   315
         Index           =   4
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   24
         Top             =   1635
         Width           =   3135
      End
      Begin VB.CheckBox chkOut 
         Caption         =   "Output Bit 03                                    "
         Height          =   315
         Index           =   3
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   23
         Top             =   1290
         Width           =   3135
      End
      Begin VB.CheckBox chkOut 
         Caption         =   "Output Bit 02                                    "
         Height          =   315
         Index           =   2
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   22
         Top             =   930
         Width           =   3135
      End
      Begin VB.CheckBox chkOut 
         Caption         =   "Output Bit 01 (Alarm Clear)               "
         Height          =   315
         Index           =   1
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   21
         Top             =   585
         Value           =   2  'Grayed
         Width           =   3135
      End
      Begin VB.CheckBox chkOut 
         Caption         =   "Output Bit 00 (Servo On)                 "
         Height          =   315
         Index           =   0
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   20
         Top             =   240
         Width           =   3135
      End
      Begin VB.CheckBox chkIn 
         Caption         =   "Input Bit 04"
         Enabled         =   0   'False
         Height          =   225
         Index           =   4
         Left            =   195
         TabIndex        =   19
         Top             =   1650
         Width           =   1800
      End
      Begin VB.CheckBox chkIn 
         Caption         =   "Input Bit 03"
         Enabled         =   0   'False
         Height          =   195
         Index           =   3
         Left            =   195
         TabIndex        =   18
         Top             =   1350
         Width           =   1725
      End
      Begin VB.CheckBox chkIn 
         Caption         =   "Input Bit 02"
         Enabled         =   0   'False
         Height          =   330
         Index           =   2
         Left            =   195
         TabIndex        =   17
         Top             =   975
         Width           =   1830
      End
      Begin VB.CheckBox chkIn 
         Caption         =   "Input Bit 01 (Z-Phase)"
         Enabled         =   0   'False
         Height          =   195
         Index           =   1
         Left            =   195
         TabIndex        =   16
         Top             =   690
         Width           =   2655
      End
      Begin VB.CheckBox chkIn 
         Caption         =   "Input Bit 00 (Origin Sensor)"
         Enabled         =   0   'False
         Height          =   315
         Index           =   0
         Left            =   195
         TabIndex        =   15
         Top             =   315
         Width           =   2310
      End
      Begin VB.Line Line3 
         X1              =   3465
         X2              =   3465
         Y1              =   270
         Y2              =   1905
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "< Output Signal Monitor >"
      Height          =   795
      Left            =   120
      TabIndex        =   11
      Top             =   2340
      Width           =   6990
      Begin VB.ComboBox cboAlarmReset 
         Height          =   315
         Left            =   4920
         TabIndex        =   32
         Top             =   300
         Width           =   1785
      End
      Begin VB.ComboBox cboServoOn 
         Height          =   315
         Left            =   1605
         TabIndex        =   31
         Top             =   285
         Width           =   1785
      End
      Begin VB.Label Label3 
         Caption         =   "Alm Reset Level :"
         Height          =   255
         Left            =   3645
         TabIndex        =   13
         Top             =   360
         Width           =   1335
      End
      Begin VB.Line Line2 
         X1              =   3465
         X2              =   3465
         Y1              =   225
         Y2              =   675
      End
      Begin VB.Label Label2 
         Caption         =   "Servo On Level     :"
         Height          =   375
         Left            =   120
         TabIndex        =   12
         Top             =   360
         Width           =   1455
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "< Input Signal Monitor >"
      Height          =   1500
      Left            =   105
      TabIndex        =   4
      Top             =   735
      Width           =   6990
      Begin VB.ComboBox cboELimitP 
         Height          =   315
         Left            =   4935
         TabIndex        =   30
         Top             =   1065
         Width           =   1785
      End
      Begin VB.ComboBox cboEmg 
         Height          =   315
         Left            =   4935
         TabIndex        =   29
         Top             =   705
         Width           =   1785
      End
      Begin VB.ComboBox cboInp 
         Height          =   315
         Left            =   4935
         TabIndex        =   28
         Top             =   360
         Width           =   1785
      End
      Begin VB.ComboBox cboELimitN 
         Height          =   315
         Left            =   1605
         TabIndex        =   27
         Top             =   1095
         Width           =   1785
      End
      Begin VB.ComboBox cboAlarm 
         Height          =   315
         Left            =   1605
         TabIndex        =   26
         Top             =   750
         Width           =   1785
      End
      Begin VB.ComboBox cboZPhase 
         Height          =   315
         Left            =   1605
         TabIndex        =   25
         Top             =   375
         Width           =   1785
      End
      Begin VB.CheckBox chkELimitP 
         Caption         =   "(+) End Limit :"
         Enabled         =   0   'False
         Height          =   270
         Left            =   3630
         TabIndex        =   10
         Top             =   1065
         Width           =   1470
      End
      Begin VB.CheckBox chkEmg 
         Caption         =   "Emergency  : "
         Enabled         =   0   'False
         Height          =   360
         Left            =   3630
         TabIndex        =   9
         Top             =   645
         Width           =   1425
      End
      Begin VB.CheckBox chkInp 
         Caption         =   "Inposition     :"
         Enabled         =   0   'False
         Height          =   300
         Left            =   3630
         TabIndex        =   8
         Top             =   330
         Width           =   1290
      End
      Begin VB.CheckBox chkELimitN 
         Caption         =   "(-) End Limit    :"
         Enabled         =   0   'False
         Height          =   240
         Left            =   180
         TabIndex        =   7
         Top             =   1110
         Width           =   1410
      End
      Begin VB.CheckBox chkAlarm 
         Caption         =   "Servo Alarm   :"
         Enabled         =   0   'False
         Height          =   255
         Left            =   180
         TabIndex        =   6
         Top             =   735
         Width           =   1440
      End
      Begin VB.CheckBox chkZPhase 
         Caption         =   "Z Phase         :"
         Enabled         =   0   'False
         Height          =   240
         Left            =   180
         TabIndex        =   5
         Top             =   375
         Width           =   1440
      End
      Begin VB.Line Line1 
         X1              =   3465
         X2              =   3465
         Y1              =   270
         Y2              =   1380
      End
   End
   Begin VB.Frame Frame1 
      Height          =   525
      Left            =   90
      TabIndex        =   0
      Top             =   120
      Width           =   7005
      Begin VB.CommandButton btnLoadFile 
         Caption         =   "Load File"
         Height          =   315
         Left            =   5130
         TabIndex        =   3
         Top             =   150
         Width           =   1680
      End
      Begin VB.ComboBox cboSelAxis 
         Height          =   315
         Left            =   1350
         TabIndex        =   2
         Top             =   165
         Width           =   3690
      End
      Begin VB.Label Label1 
         Caption         =   "Select Axis No :"
         Height          =   180
         Left            =   135
         TabIndex        =   1
         Top             =   210
         Width           =   1260
      End
   End
End
Attribute VB_Name = "SignalMonitor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' SignalMonitor.vb : implementation file

' **************************************************************************
' >> [일자]: 2011.11.26
' >> [개요]: 이 예제는 신호 관련 함수들의 사용법을 익히고 제품별 지원되는
'    기능들을 파악할 수 있도록 작성된 예제입니다.
' >> [중요]: 신호설정 함수 사용시 주의사항
'     1) 제품의 종류에 따라서 신호설정에 사용되는 인자가 달라질 수 있습니다.
'     2) 네트웍 제품의 리미트 신호나 원점신호의 레벨 변경은 서보팩 파라메타를
'        변경해서 바꿀수 있습니다.
' **************************************************************************
    
    Const TM_DISPLAY As Integer = 100
    Const Z_PHASE_BIT As Integer = 1

    Private m_lAxisNo As Long
    Private m_lAxisCount As Long
    Private m_dwModuleId As Long


    Private Sub Form_Load()
        m_lAxisNo = -1
        m_lAxisCount = 0
        m_dwModuleId = 0
    
        InitLibrary               ' 라이브러리 초기화 및 Mot파일을 불러옵니다.
        AddAxisInfo               ' 검색된 축 정보를 ComboBox에 등록/Control들을 초기화합니다.
        UpdateState               ' 모션보드의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' **************************************************************************
    ' >> [구분]: Control에 이벤트가 발생했을 때 처리하는 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> cboSelAxis_Click() : 축 번호 변경시 호출되는 핸들러 함수.
    '  - 축 번호가 변경되었을 때 변경된 축의 모듈 ID와 Control들을 갱신합니다.
    ' --------------------------------------------------------------------------
    Private Sub cboSelAxis_Click()
        Dim lpBoardNo As Long
        Dim lpModulePos As Long
        m_lAxisNo = cboSelAxis.ListIndex

        ' ++ 지정한 축번호의 모듈ID를 반환합니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, lpBoardNo, lpModulePos, m_dwModuleId)

        UpdateState       ' 변경한 축의 상태와 Control들의 상태를 일치시킵니다.
    End Sub

    ' ++ =======================================================================
    ' >> btnLoadFile_Click() : "Load File"버튼 클릭시 호출되는 핸들러 함수.
    '   - 임의 위치에 있는 Mot(AXM에서 사용하는 설정파일 형식) 파일을 불러옵니다.
    '   - 이 함수를 통해 임의의 Mot파일을 불러오면 모션축의 설정값들이 Mot파일의
    '       설정값들로 일괄 변경됩니다.
    ' --------------------------------------------------------------------------
    Private Sub btnLoadFile_Click()
        Dim szFileName As String
        CommonDialog1Open.Filter = "All Files (*.*)|*.*|Data File (*.mot)|*.mot||"
        CommonDialog1Open.FileName = "*.mot"
        CommonDialog1Open.FilterIndex = 2

        CommonDialog1Open.Action = 1
        szFileName = CommonDialog1Open.FileName
        If szFileName <> "" Then
            If AxmMotLoadParaAll(szFileName) <> AXT_RT_SUCCESS Then
                MsgBox ("File load fail!")
            End If
        End If

        UpdateState
    End Sub

    ' ++ =======================================================================
    ' >> chkOutXX_CheckedChanged(...) : "Output Bit" 버튼들 클릭 시 호출되는 핸들러 함수.
    '  - IDC_CHK_OUT_00 ~ IDC_CHK_OUT_04 버튼의 클릭이벤트 발생시 호출됩니다.
    ' --------------------------------------------------------------------------
    Private Sub chkOut00_Click()
        res = chkOut_Changed(0, chkInp00, chkOut00)
    End Sub

    Private Sub chkOut01_Click()
        res = chkOut_Changed(1, chkInp01, chkOut01)
    End Sub

    Private Sub chkOut02_Click()
        res = chkOut_Changed(2, chkInp02, chkOut02)
    End Sub

    Private Sub chkOut03_Click()
        res = chkOut_Changed(3, chkInp03, chkOut03)
    End Sub

    Private Sub chkOut04_Click()
        res = chkOut_Changed(4, chkInp04, chkOut04)
    End Sub

    ' ++ =======================================================================
    ' >> cboZPhase_Click() : "Z Phase"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Z상 신호 Active Level을 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Z상 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboZPhase_Click()
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetZphaseLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboZPhase)
            ' ++ 선택한 축의 Z상 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetZphaseLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetZphaseLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboAlarm_Click() : "Servo Alarm"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
    '  - Servo Alarm 신호를 사용안함으로 설정하면 구동중  Alarm신호가 Active되어도
    '    계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Servo Alarm 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboAlarm_Click()
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoAlarm을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboAlarm)
            ' ++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetServoAlarm(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoAlarm return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboInp_Click() : "Inposition"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Inposition 신호 Active Level/사용유무를 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Inposition 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboInp_Click()
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        dwLevel = ConvertComboToAxm(cboInp)
        ' ++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 설정합니다.
        ' - Inposition 신호를 사용안함으로 설정하면 모션제어 칩에서 펄스출력이 완료될 때 즉시구동 종료됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용함으로 설정하면 모션제어 칩에서 펄스출력이 완료된 후 서보팩으로 부터
        '              Inposition(위치결정완료) 신호가 Active될 때 까지 모션 구동중으로 됩니다.
        ' ※ [CAUTION] Inposition 신호를 사용할 때 Active Level이 맞지않으면 최초 한번 구동 후 모션구동이 종료되지않아
        '              다음 구동을 할 수 없게 됩니다.
        dwRetCode = AxmSignalSetInpos(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            strData = "AxmSignalSetInpos return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboEmg_Click() : "Emergency"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
    '  - Emergency 신호를 사용안함으로 설정하면 구동중  EMG신호가 Active되어도
    '    계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Emergency 신호를 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboEmg_Click()
        Dim strData As String
        Dim dwLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetStop(m_lAxisNo, dwStopMode, dwLevel)
        ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwLevel = ConvertComboToAxm(cboEmg)
            ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetStop(m_lAxisNo, dwStopMode, dwLevel)
        Else
            strData = "AxmSignalGetStop return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboELimitN_Click() : "(-) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
    '  - (-) End Limit 신호를 사용안함으로 설정하면 (-)방향으로 구동중  (-) End Limit신호가
    '    Active되어도 계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 (-) End Limit 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboELimitN_Click()
        Dim strData As String
        Dim dwpLevel, dwNLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetLimit(m_lAxisNo, dwStopMode, dwpLevel, dwNLevel)
        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwNLevel = ConvertComboToAxm(cboELimitN)
            ' ++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwpLevel, dwNLevel)
        Else
            strData = "AxmSignalSetLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboELimitP_Click() : "(+) End Limit"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 (+) End Limit 신호 Active Level/사용유무를 설정합니다.
    '  - (+) End Limit 신호를 사용안함으로 설정하면 (+)방향으로 구동중  (+) End Limit신호가
    '    Active되어도 계속해서 목표지점까지 구동하게됩니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 (+) End Limit 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboELimitP_Click()
        Dim strData As String
        Dim dwpLevel, dwNLevel, dwStopMode, dwRetCode As Long

        dwRetCode = AxmSignalGetLimit(m_lAxisNo, dwStopMode, dwpLevel, dwNLevel)
        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        If dwRetCode = AXT_RT_SUCCESS Then
            dwpLevel = ConvertComboToAxm(cboELimitP)
            ' ++ 선택한 축의 (-) End Limit 신호 Active Level/사용유무를 설정합니다.
            dwRetCode = AxmSignalSetLimit(m_lAxisNo, dwStopMode, dwpLevel, dwNLevel)
        Else
            strData = "AxmSignalSetLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    '// >> cboServoOn_Click() : "Servo On Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '//  - 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
    '// ※ [INFO] 특정 네트웍 제품의 경우 Servo On/Off 신호레벨 변경을 지원하지않습니다.
    '// --------------------------------------------------------------------------
    Private Sub cboServoOn_Click()
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoOnLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboServoOn)
            ' ++ 선택된 축의 Servo On/Off 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoOnLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoOnLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> cboAlarmReset_Click() : "Alm Reset Level"콤보박스 Item변경시 호출되는 핸들러 함수.
    '  - 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
    ' ※ [INFO] 특정 네트웍 제품의 경우 Alarm Reset 신호레벨 변경을 지원하지않습니다.
    ' --------------------------------------------------------------------------
    Private Sub cboAlarmReset_Click()
        Dim strData As String
        Dim dwLevel, dwRetCode As Long

        ' 이더켓은 AxmSignalSetServoAlarmResetLevel을 지원하지 않음.
        If m_dwModuleId <> AXT_ECAT_MOTION Then
            dwLevel = ConvertComboToAxm(cboAlarmReset)
            ' ++ 선택된 축의 Alarm Reset 신호 Active Level을 설정합니다.
            dwRetCode = AxmSignalSetServoAlarmResetLevel(m_lAxisNo, dwLevel)
            If dwRetCode <> AXT_RT_SUCCESS Then
                strData = "AxmSignalSetServoAlarmResetLevel return error[Code:" + Format(dwRetCode, "0000") + "]"
                MsgBox (strData)
            End If
        End If
    End Sub

    ' ++ =======================================================================
    ' >> chkSWEnable_Click() : "Enable"버튼 클릭시 호출되는 핸들러 함수.
    '  - 선택된 축에 Software Limit기능을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkSWEnable_Click()
        Dim strData As String
        Dim dSWLimitP, dSWLimitN As Double
        Dim dwSWEnable, dwSWStopMode, dwSWRef, dwRetCode As Long

        dwSWEnable = chkSWEnable.Checked
        dwSWStopMode = ConvertComboToAxm(cboSWStop)
        dwSWRef = ConvertComboToAxm(cboSWRef)
        dSWLimitP = edtSWPosP.Text
        dSWLimitN = edtSWPosN.Text

        ' ++ 지정한 축에 Software Limit기능을 설정합니다.
        '  ※ [INFO] Software Limit 기능은 원점검색시 무시됩니다. 원점검색이 완료되면 자동으로 이전 상태가 됩니다.
        dwRetCode = AxmSignalSetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            chkSWEnable.Checked = False
            strData = "AxmSignalSetSoftLimit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub

    ' ++ =======================================================================
    ' >> m_timer_Timer(...) : 타이머 이벤트 핸들러 함수.
    '  - 일정한 주기로 변경되는 위치/속도/정보등을 Control에 반영합니다.
    ' --------------------------------------------------------------------------
    Private Sub m_timer_Timer()
        Dim dwState1 As Long
        Dim dwState2 As Long
        Dim dwRetCode As Long
        
        dwState1 = 0
        dwState2 = 0
        dwRetCode = 0
        
        Dim lBitNo As Integer
        
        'Dim chkGroupInp(UIO_OUT5 - 1) As CheckBox
        'chkGroupInp(0) = chkInp00
        'chkGroupInp(1) = chkInp01
        'chkGroupInp(2) = chkInp02
        'chkGroupInp(3) = chkInp03
        'chkGroupInp(4) = chkInp04
        
        
        'Dim chkGroupOut(UIO_OUT5 - 1) As CheckBox
        'chkGroupOut(0) = chkOut00.Value
        'chkGroupOut(1) = chkOut01.Value
        'chkGroupOut(2) = chkOut02.Value
        'chkGroupOut(3) = chkOut03.Value
        'chkGroupOut(4) = chkOut04.Value
        

        ' ++ Z상 신호의 상태를 확인합니다.
        dwRetCode = AxmStatusReadMechanical(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            dwState1 = IIf(((dwState1 & QIMECHANICAL_ZPHASE_LEVEL) = 0), 0, 1)
            chkZPhase.Value = dwState1
        End If

        ' ++ Servo Alarm 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadServoAlarm(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkAlarm.Value = dwState1
        End If

        ' ++ Inposition(위치결정완료) 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadInpos(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkInp.Value = dwState1
        End If

        ' ++ Emergency 신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadStop(m_lAxisNo, dwState1)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkEmg.Value = dwState1
        End If

        ' ++ (+/-)End Limit신호의 상태를 확인합니다.
        dwRetCode = AxmSignalReadLimit(m_lAxisNo, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkELimitP.Value = dwState1
            chkELimitN.Value = dwState2
        End If

        For lBitNo = 0 To (UIO_OUT5 - 1)
            ' ++ 범용입력 신호의(Bit00-Bit04) 상태를 확인합니다.
            dwRetCode = AxmSignalReadInputBit(m_lAxisNo, lBitNo, dwState1)
            If dwRetCode = AXT_RT_SUCCESS Then
                chkIn(lBitNo).Value = dwState1
            End If

            ' ++ 범용출력 신호의(Bit00-Bit04) 상태를 확인합니다.
            dwRetCode = AxmSignalReadOutputBit(m_lAxisNo, lBitNo, dwState2)
            If dwRetCode = AXT_RT_SUCCESS Then
                chkOut(lBitNo).Value = dwState2
            End If
        Next

        ' ++ (+/-)Software Limit의 Active 상태를 확인합니다.
        dwRetCode = AxmSignalReadSoftLimit(m_lAxisNo, dwState1, dwState2)
        If dwRetCode = AXT_RT_SUCCESS Then
            chkSWLimitP.Value = dwState1
            chkSWLimitN.Value = dwState2
        End If
    End Sub

    ' **************************************************************************
    ' >> [구분]: 별도의 기능을 구현하기위해 만든 사용자 정의 함수들 모음
    ' **************************************************************************

    ' ++ =======================================================================
    ' >> InitLibrary() : 라이브러리 초기화 및 Mot파일을 불러오는 함수.
    '  - AXL(AjineXtek Library)을 사용가능하게 합니다.
    '  - EzConfig 프로그램이 설치되어있는 폴더에서 기본 Mot파일(모션 설정파일)을
    '    지정해 모션관련 기본설정을 자동으로 합니다.
    ' --------------------------------------------------------------------------
    Private Function InitLibrary() As Boolean
        If AxlOpen(7) <> AXT_RT_SUCCESS Then
            MsgBox ("AxlOpen Fail...")
            InitLibrary = False
            Exit Function
        End If

        Dim szFilePath As String
        szFilePath = "..\..\..\..\EzSoftware\MotionDefault.mot"
        
        If AxmMotLoadParaAll(szFilePath) <> AXT_RT_SUCCESS Then
            Dim res As Integer
            res = MsgBox("Mot File Not Found.", 1)
        End If

        InitLibrary = True
    End Function

    ' ++ =======================================================================
    ' >> AddAxisInfo() : 시스템에 장착된 모션축들을 ComboBox에 등록하는 함수.
    '  - AXL Open시 검색된 축들의 정보를 읽어 ComboBox에 등록하여 사용자가 선택
    '    제어할 수 있도록 합니다.
    '  - 유효한 축이 검색되었을 때 Control들을 초기화 하고, 정보 갱신용 타이머를
    '    100msec 주기로 동작시킵니다.
    ' --------------------------------------------------------------------------
    Private Function AddAxisInfo() As Boolean
        Dim strData As String
        Dim dwModuleID, dwBoardNo, dwModulePos As Long
        Dim szModuleName As String
        Dim strModuleName As String
        Dim lpBoardNo As Long
        Dim lpModulePosAs As Long
        Dim upModuleSubID As Long
        Dim szModuleDescription As String

        ' ++ 유효한 전체 모션축수를 반환합니다.
        dwRetCode = AxmInfoGetAxisCount(m_lAxisCount)
        If m_lAxisCount < 1 Then
            AddAxisInfo = False
            Exit Function
        End If

        szModuleName = Space(50)
        szModuleDescription = Space(80)
        m_lAxisNo = 0
        ' ++ 지정한 축의 정보를 반환합니다.
        ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
        dwRetCode = AxmInfoGetAxis(m_lAxisNo, dwBoardNo, dwModulePos, m_dwModuleId)

        ' 유효한 전체 모션축수의 정보를 읽어 ComboBox에 등록합니다.
        For i = 0 To (m_lAxisCount - 1)
            ' ++ 지정한 축의 정보를 반환합니다.
            ' [INFO] 여러개의 정보를 읽는 함수 사용시 불필요한 정보는 Nothing을 입력하면 됩니다.
            dwRetCode = AxmInfoGetAxis(i, lpBoardNo, lpModulePosAs, dwModuleID)
            Select Case dwModuleID
                Case AXT_SMC_4V04
                    strData = Format(i, "00") + "-[4V04]"
                Case AXT_SMC_R1V04
                    strData = Format(i, "00") + "-[R1V04]"
                Case AXT_SMC_2V04
                    strData = Format(i, "00") + "-[2V04]"
                Case AXT_SMC_R1V04MLIIPM
                    strData = Format(i, "00") + "-[R1V04MLIIPM]"
                Case AXT_SMC_R1V04PM2Q
                    strData = Format(i, "00") + "-[R1V04PM2Q]"
                Case AXT_SMC_R1V04PM2QE
                    strData = Format(i, "00") + "-[R1V04PM2QE]"
                Case AXT_SMC_R1V04MLIIIPM
                    strData = Format(i, "00") + "-[R1V04MLIIIPM]"
                Case AXT_SMC_R1V04MLIISV
                    strData = Format(i, "00") + "-[R1V04MLIISV]"
                Case AXT_SMC_R1V04A5
                    strData = Format(i, "00") + "-[R1V04A5]"
                Case AXT_SMC_R1V04A4
                    strData = Format(i, "00") + "-[R1V04A4]"
                Case AXT_SMC_R1V04SIIIHMIV
                    strData = Format(i, "00") + "-[R1V04SIIIHMIV]"
                Case AXT_SMC_R1V04SIIIHMIV_R
                    strData = Format(i, "00") + "-[R1V04SIIIHMIV_R]"
                Case AXT_SMC_R1V04MLIIISV
                    strData = Format(i, "00") + "-[R1V04MLIIISV]"
                Case AXT_SMC_R1V04MLIIISV_MD
                    strData = Format(i, "00") + "-[R1V04MLIIISV_MD]"
                Case AXT_SMC_R1V04MLIIIS7S
                    strData = Format(i, "00") + "-[R1V04MLIIIS7S]"
                Case AXT_SMC_R1V04MLIIIS7W
                    strData = Format(i, "00") + "-[R1V04MLIIIS7W]"
                Case AXT_ECAT_MOTION
                    dwRetCode = AxmInfoGetAxisEx(i, upModuleSubID, szModuleName, szModuleDescription)
                    strModuleName = Replace(szModuleName, Chr(0), "")
                    strData = Format(i, "00") + "-[ECAT-" + strModuleName + "]"
                Case Else
                    strData = Format(i, "00") + "-[Unknown]"
            End Select

            cboSelAxis.AddItem (strData)

        Next

        InitControl
        AddAxisInfo = True
    End Function

    ' ++ =======================================================================
    ' >> InitControl() : Control들에 초기값을 설정하는 함수.
    '  - Control 변수들을 등록하고, 초기 설정값들을 설정합니다.
    ' --------------------------------------------------------------------------
    Private Function InitControl()
        cboSelAxis.ListIndex = m_lAxisNo

        InitControl = True
    End Function

    ' ++ =======================================================================
    ' >> UpdateState() : 지정한 축의 설정값들을 읽어 Control과 일치시키는 함수.
    '  - 축번호가 변경되었을 때 변경한 축의 설정값들과 Control들과 일치시키는
    '    역할을하는 함수입니다.
    '  - 지정한 축의 모델별 제약들을 Control에 반영하는 역할을 합니다.
    '  - 프로그램 초기 실행시, Mot파일 불러올 때, 축 번호 바뀔 때 사용됩니다.
    ' --------------------------------------------------------------------------
    Private Sub UpdateState()

        Dim dwPulse As Long
        Dim dUnit As Double
        Dim dMinVel As Double
        Dim dMaxVel As Double
        Dim dSWLimitP As Double
        Dim dSWLimitN As Double
        Dim dwMethod As Long
        Dim dwStopMode As Long
        Dim dwUse As Long
        Dim dwPositiveLevel As Long
        Dim dwNegativeLevel As Long
        Dim dwSWEnable As Long
        Dim dwSWStopMode As Long
        Dim dwSWRef As Long
        Dim dwLevel As Long
        Dim dwAbsRelMode As Long
        Dim dwProfileMode As Long
        Dim dwRetCode As Long
        Dim dwEncoderType As Long
        Dim dwHmDir As Long
        Dim dwHomeSignal As Long
        Dim dwZPhas As Long
        Dim dHomeClrTime As Double
        Dim dHomeOffset As Long
        Dim dInitPos As Double
        Dim dInitVel As Double
        Dim dInitAccel As Double
        Dim dInitDecel As Double
        Dim dVelFirst As Double
        Dim dVelSecond As Double
        Dim dVelThird As Double
        Dim dVelLast As Double
        Dim dAccFirst As Double
        Dim dAccSecond As Double

        dwPulse = 1
        dUnit = 1#
        dMinVel = 1#
        dMaxVel = 100#
        dSWLimitP = 0#
        dSWLimitN = 0#
        dwMethod = 0
        dwStopMode = 0
        dwUse = 0
        dwPositiveLevel = 0
        dwNegativeLevel = 0
        dwSWEnable = 0
        dwSWStopMode = 0
        dwSWRef = 0
        dwLevel = 0
        dwAbsRelMode = 0
        dwProfileMode = 0
        dwRetCode = 0
        dwEncoderType = 0
        dwHmDir = 0
        dwHomeSignal = 0
        dwZPhas = 0
        dHomeClrTime = 1000#
        dHomeOffset = 0#
        dInitPos = 100#
        dInitVel = 100#
        dInitAccel = 400#
        dInitDecel = 400#
        dVelFirst = 100#
        dVelSecond = 10#
        dVelThird = 5#
        dVelLast = 1#
        dAccFirst = 400#
        dAccSecond = 40#

        ' 각 제품별 지원여부에 따라 콘트롤 값들을 변경합니다.
        Select Case m_dwModuleId
            Case AXT_SMC_4V04, AXT_SMC_4V04, AXT_SMC_R1V04, AXT_SMC_2V04, AXT_SMC_R1V04PM2Q, AXT_SMC_R1V04PM2QE, AXT_SMC_R1V04MLIIIPM
                cboZPhase.Clear
                cboZPhase.Enabled = True
                cboZPhase.AddItem ("00:LOW")
                cboZPhase.AddItem ("01:HIGH")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("00:LOW")
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("00:LOW")
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboEmg.Clear
                cboEmg.Enabled = True
                cboEmg.AddItem ("00:LOW")
                cboEmg.AddItem ("01:HIGH")
                cboEmg.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = True
                cboServoOn.AddItem ("00:LOW")
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = True
                cboAlarmReset.AddItem ("00:LOW")
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = True
                cboSWRef.AddItem ("00:COMMAND")
                cboSWRef.AddItem ("01:ACTUAL")

                cboSWStop.Clear
                cboSWStop.Enabled = True
                cboSWStop.AddItem ("00:E_STOP")
                cboSWStop.AddItem ("01:S_STOP")

                edtSWPosN.Enabled = True
                edtSWPosP.Enabled = True
                chkSWEnable.Enabled = True

            Case AXT_SMC_R1V04A4
                cboZPhase.Clear
                cboZPhase.Enabled = False
                cboZPhase.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboEmg.Clear
                cboEmg.Enabled = True
                cboEmg.AddItem ("00:LOW")
                cboEmg.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = False
                cboSWRef.AddItem ("02:UNUSED")

                cboSWStop.Clear
                cboSWStop.Enabled = False
                cboSWStop.AddItem ("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIIPM
                cboZPhase.Clear
                cboZPhase.Enabled = False
                cboZPhase.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = False
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = False
                cboInp.AddItem ("02:UNUSED")

                cboEmg.Clear
                cboEmg.Enabled = False
                cboEmg.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = False
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = False
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = False
                cboSWRef.AddItem ("02:UNUSED")

                cboSWStop.Clear
                cboSWStop.Enabled = False
                cboSWStop.AddItem ("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIISV, AXT_SMC_R1V04A5, AXT_SMC_R1V04MLIICL, AXT_SMC_R1V04MLIICR, AXT_SMC_R1V04MLIIORI, AXT_SMC_R1V04SIIIHMIV, AXT_SMC_R1V04SIIIHMIV_R
                cboZPhase.Clear
                cboZPhase.Enabled = False
                cboZPhase.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboEmg.Clear
                cboEmg.Enabled = False
                cboEmg.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = False
                cboSWRef.AddItem ("02:UNUSED")

                cboSWStop.Clear
                cboSWStop.Enabled = False
                cboSWStop.AddItem ("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_SMC_R1V04MLIIISV, AXT_SMC_R1V04MLIIISV_MD, AXT_SMC_R1V04MLIIIS7S, AXT_SMC_R1V04MLIIIS7W

                cboZPhase.Clear
                cboZPhase.Enabled = False
                cboZPhase.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("00:LOW")
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")

                cboEmg.Clear
                cboEmg.Enabled = False
                cboEmg.AddItem ("02:UNUSED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")

                cboServoOn.Clear
                cboServoOn.Enabled = True
                cboServoOn.AddItem ("00:LOW")
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = False
                cboSWRef.AddItem ("02:UNUSED")

                cboSWStop.Clear
                cboSWStop.Enabled = False
                cboSWStop.AddItem ("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case AXT_ECAT_MOTION
                cboZPhase.Clear
                cboZPhase.Enabled = False
                cboZPhase.AddItem ("02:UNUSED")

                cboAlarm.Clear
                cboAlarm.Enabled = True
                cboAlarm.AddItem ("01:HIGH")
                cboAlarm.AddItem ("02:UNUSED")

                cboInp.Clear
                cboInp.Enabled = True
                cboInp.AddItem ("00:LOW")
                cboInp.AddItem ("01:HIGH")
                cboInp.AddItem ("02:UNUSED")
                cboInp.AddItem ("03:USED")

                cboEmg.Clear
                cboEmg.Enabled = True
                cboEmg.AddItem ("00:LOW")
                cboEmg.AddItem ("01:HIGH")
                cboEmg.AddItem ("02:UNUSED")
                cboEmg.AddItem ("03:USED")

                cboELimitN.Clear
                cboELimitN.Enabled = True
                cboELimitN.AddItem ("00:LOW")
                cboELimitN.AddItem ("01:HIGH")
                cboELimitN.AddItem ("02:UNUSED")
                cboELimitN.AddItem ("03:USED")

                cboELimitP.Clear
                cboELimitP.Enabled = True
                cboELimitP.AddItem ("00:LOW")
                cboELimitP.AddItem ("01:HIGH")
                cboELimitP.AddItem ("02:UNUSED")
                cboELimitP.AddItem ("03:USED")

                cboServoOn.Clear
                cboServoOn.Enabled = False
                cboServoOn.AddItem ("01:HIGH")

                cboAlarmReset.Clear
                cboAlarmReset.Enabled = False
                cboAlarmReset.AddItem ("01:HIGH")

                cboSWRef.Clear
                cboSWRef.Enabled = False
                cboSWRef.AddItem ("02:UNUSED")

                cboSWStop.Clear
                cboSWStop.Enabled = False
                cboSWStop.AddItem ("02:UNUSED")

                edtSWPosN.Enabled = False
                edtSWPosP.Enabled = False
                chkSWEnable.Enabled = False

            Case Else

        End Select

        ' ++ 선택한 축의 Z상 신호 Active Level 설정값을 확인합니다.
        dwRetCode = AxmSignalGetZphaseLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboZPhase, dwLevel)

        ' ++ 선택한 축의 Servo Alarm 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetServoAlarm(m_lAxisNo, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboAlarm, dwUse)

        ' ++ 선택한 축의 Inposition(위치결정완료) 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetInpos(m_lAxisNo, dwUse)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwUse = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboInp, dwUse)



        ' ++ 선택한 축의 Emergency 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetStop(m_lAxisNo, dwStopMode, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboEmg, dwLevel)

        ' ++ 선택한 축의 (+/-) End Limit 신호 Active Level/사용유무를 확인합니다.
        dwRetCode = AxmSignalGetLimit(m_lAxisNo, dwStopMode, dwPositiveLevel, dwNegativeLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwPositiveLevel = dwNegativeLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboELimitP, dwPositiveLevel)
        dwRetCode = ConvertAxmToCombo(cboELimitN, dwNegativeLevel)

        ' ++ 선택한 축의 Servo On/Off 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoOnLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboServoOn, dwLevel)

        ' ++ 선택한 축의 Alarm Reset 신호 Active Level을 확인합니다.
        dwRetCode = AxmSignalGetServoAlarmResetLevel(m_lAxisNo, dwLevel)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwLevel = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboAlarmReset, dwLevel)

        ' ++ 선택한 축의 Software Limit기능을 확인합니다.
        dwRetCode = AxmSignalGetSoftLimit(m_lAxisNo, dwSWEnable, dwSWStopMode, dwSWRef, dSWLimitP, dSWLimitN)
        If dwRetCode <> AXT_RT_SUCCESS Then
            dwSWStopMode = EMERGENCY_STOP
            dwSWRef = UNUSED
        End If
        dwRetCode = ConvertAxmToCombo(cboSWStop, dwSWStopMode)
        dwRetCode = ConvertAxmToCombo(cboSWRef, dwSWRef)

        edtSWPosP.Text = Format(dSWLimitP, "0.000")
        edtSWPosN.Text = Format(dSWLimitN, "0.000")
    End Sub

    ' ++ =======================================================================
    ' >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
    '    Item과 일치하는 Item을 찾아 선택하는 함수.
    '  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
    '    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
    '  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
    ' --------------------------------------------------------------------------
    Private Function ConvertAxmToCombo(ByRef pCboItem As ComboBox, ByVal dwCurData As Long) As Long
        Dim i As Integer

        If pCboItem Is Nothing Then
            ConvertAxmToCombo = 0
            Exit Function
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.ListCount
        If dwCount = 0 Then
            ConvertAxmToCombo = 0
            Exit Function
        End If

        For i = 0 To (dwCount - 1)
            strText = pCboItem.List(i)
            dwSelData = Val(strText)
            If dwSelData = dwCurData Then
                pCboItem.ListIndex = i
                ConvertAxmToCombo = i
                Exit Function
            End If
        Next

        pCboItem.ListIndex = 0
        ConvertAxmToCombo = 0
    End Function

    ' ++ =======================================================================
    ' >> ConvertComboToAxm(...) : 지정한 모션보드에 설정값과 ComboBox콘트롤의
    '    Item과 일치하는 Item을 찾아 선택하는 함수.
    '  - 실제 모션보드에 설정되는 값과 ComboBox의 Item Index와  다르므로 지정한
    '    값과 일치하는 Item을 찾아 선택하고 선택된 Item의 Index를 반환합니다.
    '  - 변경하고자하는 ComboBox 콘트롤의 포인트를 인자로 전달합니다.
    '  - 이 함수를 사용하고자 할 때 데이타 등록을 지정된 양식으로 설정해야됩니다.
    '    Format) XX: String, XX=라이브러리로 전달될 값, String=인자 설명
    '    Ex) "01: HIGH", "00: COMMAND", "04: HomeSensor"
    ' --------------------------------------------------------------------------
    Private Function ConvertComboToAxm(ByRef pCboItem As ComboBox) As Long
        If pCboItem Is Nothing Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        Dim dwCount, dwSelData As Long
        Dim strText As String

        dwCount = pCboItem.ListCount
        If dwCount = 0 Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        dwSelData = pCboItem.ListIndex
        If dwSelData < 0 Then
            ConvertComboToAxm = 0
            Exit Function
        End If

        strText = pCboItem.List(dwSelData)
        ConvertComboToAxm = Val(strText)
    End Function

    ' ++ =======================================================================
    ' >> chkOut_Changed(...) : chkOutXX_CheckedChanged 핸들러 함수에서 호출하는 함수.
    '    각 Output bit의 출력접점을 변경합니다.
    ' --------------------------------------------------------------------------
    Private Sub chkOut_Changed(ByVal lBitNo As Long, ByRef chkInpx As CheckBox, ByRef chkOutx As CheckBox)
        Dim strData As String
        Dim dwRetCode, dwOnOff As Long

        dwOnOff = IIf(chkInpx.Checked, 1, 0)
        ' ++ 선택한 축에 지정한 Bit의 출력접점을 변경합니다.
        dwRetCode = AxmSignalWriteOutputBit(m_lAxisNo, lBitNo, dwOnOff)
        If dwRetCode <> AXT_RT_SUCCESS Then
            chkOutx.Checked = False
            strData = Format(lBitNo, "00") + "bit AxmSignalWriteOutputBit return error[Code:" + Format(dwRetCode, "0000") + "]"
            MsgBox (strData)
        End If
    End Sub
