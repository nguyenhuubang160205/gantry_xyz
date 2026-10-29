VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form frmAnalogInput 
   Caption         =   "VB-AnalogInput"
   ClientHeight    =   7065
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6600
   LinkTopic       =   "Form1"
   ScaleHeight     =   7065
   ScaleWidth      =   6600
   StartUpPosition =   3  'Windows 기본값
   Begin MSComDlg.CommonDialog CommonDialogFileSave 
      Left            =   5760
      Top             =   1080
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton btnExit 
      Caption         =   "EXIT"
      Height          =   615
      Left            =   5400
      TabIndex        =   9
      Top             =   240
      Width           =   1095
   End
   Begin VB.Timer timerGatherValue 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   6000
      Top             =   0
   End
   Begin MSComctlLib.ListView listAnalogInput 
      Height          =   3855
      Left            =   120
      TabIndex        =   5
      Top             =   3000
      Width           =   6615
      _ExtentX        =   11668
      _ExtentY        =   6800
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Frame frmSetting 
      Caption         =   "Setting"
      Height          =   2775
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   5175
      Begin VB.CheckBox chkStart 
         Caption         =   "Start"
         Height          =   615
         Left            =   3960
         Style           =   1  '그래픽
         TabIndex        =   8
         Top             =   2040
         Width           =   1095
      End
      Begin MSComctlLib.ListView listAIChannelInfo 
         Height          =   1575
         Left            =   0
         TabIndex        =   7
         Top             =   360
         Width           =   5055
         _ExtentX        =   8916
         _ExtentY        =   2778
         View            =   3
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         Checkboxes      =   -1  'True
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   0
      End
      Begin VB.CommandButton btnSave 
         Caption         =   "Save"
         Height          =   615
         Left            =   2880
         TabIndex        =   6
         Top             =   2040
         Width           =   975
      End
      Begin VB.TextBox textDataLength 
         Height          =   270
         Left            =   1440
         TabIndex        =   4
         Text            =   "1000"
         Top             =   2400
         Width           =   1335
      End
      Begin VB.ComboBox comboVRange 
         Height          =   300
         ItemData        =   "frmAnalogInput.frx":0000
         Left            =   1440
         List            =   "frmAnalogInput.frx":0007
         Style           =   2  '드롭다운 목록
         TabIndex        =   1
         Top             =   2040
         Width           =   1335
      End
      Begin VB.Label labelDataLength 
         Caption         =   "Data Length"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   2400
         Width           =   1335
      End
      Begin VB.Label labelVRange 
         Caption         =   "Voltage Range"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   2040
         Width           =   1335
      End
   End
End
Attribute VB_Name = "frmAnalogInput"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' This Example maked for AnalogInput module uses at Visual Basic
' The comfile is needed to include  AXL.bas, AXHS.bas, AXA.bas Files
' AXL.dll, el_hard.dll, el_univ.dll, EzBasic.dll Files input folder of exist exe file

Option Explicit
Private Const MAXNUM_DATALENGTH As Long = 10000
Private Const MINNUM_DATALENGTH As Long = 10
Private Const MAXNUM_CHANNEL As Long = 64

Private Const MAXNUM_BUFFER As Long = 32768

Dim g_lLine As Long
Dim g_bChannelEvent(0 To MAXNUM_CHANNEL - 1) As Boolean
Dim g_lChannelNo(0 To MAXNUM_CHANNEL - 1) As Long
Dim g_lCheckedChNum As Long


Private Sub Initialize_AI()
Dim lStatus As Long
Dim lInputChCnt As Long
Dim i1 As Integer
   
    ' Confirm Library initialized.
    If AxlIsOpened = False Then
        ' Library initialize.
        If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then
            
            MsgBox "Library initialized failed." + vbCrLf + _
                   "Please reset program", vbCritical
        End If
    End If
    
    
End Sub


Public Sub EventProc(ByVal wParam As Long, ByVal lParam As Long)
    Dim lChannelNo As Long
    Dim lFlag As Long
    
    lChannelNo = wParam
    lFlag = lParam
    
'    ViewSampleVoltageAdc lChannelNo, lFlag
End Sub




Private Sub ViewSampleVoltageAdc(ByVal lChannelNo As Long, ByVal lFlag As Long)
    Dim lStatus As Long
    Dim i, j, k As Long
    Dim bIsDone As Boolean
    Dim lDataLength As Long
    
    Dim arrdVolt() As Double
    
    Dim arrdVolt1(0 To 2000) As Double
    
    Dim lSampleCount(0 To 128) As Long
        
   
    lDataLength = CLng(textDataLength.Text)
    lStatus = lFlag
    bIsDone = True

    
    Select Case lStatus
        Case AIO_EVENT_DATA_UPPER
            AxaiEventSetChannelEnable lChannelNo, DISABLE
            
            g_bChannelEvent(lChannelNo) = True
            
            For i = 0 To g_lCheckedChNum - 1
                If listAIChannelInfo.ListItems(i + 1).Checked = True Then
                    If g_bChannelEvent(i) = False Then
                        bIsDone = False
                    End If
                End If
            Next
            
            If bIsDone = True Then
                AxaiHwStopMultiChannel -1
                ReDim arrdVolt(0 To 128, 0 To lDataLength + 1)
               
                For j = 0 To g_lCheckedChNum - 1
                    AxaiHwReadDataLength g_lChannelNo(j), lSampleCount(g_lChannelNo(j))
                    If lSampleCount(g_lChannelNo(j)) > lDataLength Then
                        lSampleCount(g_lChannelNo(j)) = lDataLength
                    End If
                    AxaiHwReadSampleVoltage g_lChannelNo(j), lSampleCount(g_lChannelNo(j)), arrdVolt1(0)
                    For k = 0 To lSampleCount(g_lChannelNo(j))
                        arrdVolt(g_lChannelNo(j), k) = arrdVolt1(k)
                    Next
                Next
                
                ' Output list
                For i = 0 To lDataLength - 1
                    ' Input line
                    listAnalogInput.ListItems.Add i + 1, , CStr(g_lLine), , 0
                    g_lLine = g_lLine + 1
                    
                    ' As Channel length as... Add SubItem
                    For j = 0 To g_lCheckedChNum - 1
                        listAnalogInput.ListItems(i + 1).SubItems(j + 1) = Format(arrdVolt(g_lChannelNo(j), i), "###.0000000")
                    Next
                Next
              
                
                chkStart.Value = 0
            End If
            
        
        Case AIO_EVENT_DATA_LOWER
        
        Case AIO_EVENT_DATA_FULL
        
        Case AIO_EVENT_DATA_EMPTY
    End Select
    

End Sub

Private Sub btnExit_Click()
    Unload Me
End Sub

Private Sub btnSave_Click()
    Dim InVal    As String
    Dim strLine, strChNo, strValue As String
    Dim i, j As Integer
    
    strLine = ""
    
    g_lCheckedChNum = 0
    For i = 0 To listAIChannelInfo.ListItems.Count - 1
        If (listAIChannelInfo.ListItems(i + 1).Checked = True) Then
            g_lCheckedChNum = g_lCheckedChNum + 1
        End If
    Next
    

    CommonDialogFileSave.ShowSave
    
    If CommonDialogFileSave.FileName <> "" Then
        
        Open CommonDialogFileSave.FileName For Output As #1
            Print #1, "### AI DATA ###"
            Print #1, ""
            
            '"Voltage range : -10 ~ 10 V"
            Select Case comboVRange.ListIndex
            Case 0
                Print #1, "Voltage range : -10 ~ 10 V"
            End Select
            
            Print #1, "Data length   : " + textDataLength.Text
            
            'write "==========================================="
            For i = 0 To g_lCheckedChNum - 1
                strLine = strLine + "=========="
            Next
            Print #1, strLine
            
            'ChNo
            strChNo = "ChNo"
            For i = 0 To g_lCheckedChNum - 1
                strChNo = strChNo & vbTab & "Ch.#" + CStr(i)
            Next
            Print #1, strChNo
            
            'write "==========================================="
            strLine = ""
            For i = 0 To g_lCheckedChNum - 1
                strLine = strLine + "=========="
            Next
            Print #1, strLine
            
            ' write Value
            For i = 0 To listAnalogInput.ListItems.Count - 1
                strValue = Format(i, "0000")
                For j = 0 To g_lCheckedChNum - 1
                    strValue = strValue & vbTab & Format(CDbl(listAnalogInput.ListItems(i + 1).SubItems(j + 1)), "###0.0000")
                Next
            Print #1, strValue
            Next
            
            Print #1, Format(Val(InVal) + 1, "0")
            
        Close #1
    End If
    
End Sub


Private Sub chkStart_Click()
    Dim nCntAllChannel As Integer
    Dim nCntChannelSelected As Integer
    Dim i1 As Integer
    Dim i2 As Integer
    Dim strColumnHeader As String
    Dim lPVRange As Long
    Dim lNVRange As Long
    Dim lModuleNo As Long
            
    Dim lDataLength As Long
    Dim lTimeConst As Long
    Dim lSampleRate As Long
        
    Dim arrCh(MAXNUM_CHANNEL) As Long
    Dim arrSize(MAXNUM_CHANNEL) As Long
    
    ' Buffer
    Dim arrCBuffer(0 To MAXNUM_CHANNEL * MAXNUM_BUFFER) As Double
    Dim arrpCBuffer(0 To MAXNUM_CHANNEL) As Long


    nCntAllChannel = listAIChannelInfo.ListItems.Count
    
    If (chkStart.Value = 1) Then
        ' Interrupt init
'        MessageHook (Me.hWnd)
        
        If (nCntAllChannel > 0) Then
        
            ' Change text of button
            chkStart.Caption = "READING"
                        
            ' Outputdata list init
            listAnalogInput.ListItems.Clear
            listAnalogInput.ColumnHeaders.Clear
            g_lLine = 1
            
            ' Control state appoint
            listAIChannelInfo.Enabled = False
            textDataLength.Enabled = False
            comboVRange.Enabled = False
            timerGatherValue.Enabled = False
            
            ' Outputdata list put Column Header
            listAnalogInput.ColumnHeaders.Add 1, , "No.", 800, 0
            i2 = 2
            For i1 = 1 To nCntAllChannel
                If (listAIChannelInfo.ListItems(i1).Checked = True) Then
                    strColumnHeader = "CH " + listAIChannelInfo.ListItems(i1).SubItems(3)
                    listAnalogInput.ColumnHeaders.Add i2, , strColumnHeader, 1100, 0
                    i2 = i2 + 1
                End If
            Next
            
            lDataLength = CLng(textDataLength.Text)

            g_lCheckedChNum = i2
            
'            ' Selected channel length
            nCntChannelSelected = i2
            If (nCntChannelSelected > 0) Then
                ' Set Volt range
                Select Case comboVRange.ListIndex
                    Case 0
                        lNVRange = -10
                        lPVRange = 10
                    End Select

                ' Set Before Ouput condition
                For i1 = 0 To nCntAllChannel - 1
                    If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
                        AxaiHwSetLimit arrCh(i1), 0, lDataLength            '// Set High limit
                        AxaiSetRange arrCh(i1), lNVRange, lPVRange    ' Set Volt range
                        
                        AxaiInfoGetModuleNoOfChannelNo arrCh(i1), lModuleNo
                        AxaiSetTriggerMode lModuleNo, NORMAL_MODE
                        AxaiHwSetSamplePeriod lModuleNo, lTimeConst
                    End If
                Next
                
                For i1 = 0 To MAXNUM_CHANNEL - 1
                    g_bChannelEvent(i1) = False
                Next
                                
                    timerGatherValue.Enabled = True
                              
            End If  'end of "If (nCntChannelSelected > 0) Then"
                       
        End If  ' end of "If (nCntAllChannel > 0) Then"
   
    Else
        ' Interrupt cancel
'        EndMessageHook (Me.hWnd)
        
        AxaiHwStopMultiChannel -1
    
        ' Control state appoint
        timerGatherValue.Enabled = False
        listAIChannelInfo.Enabled = True
        textDataLength.Enabled = True
        comboVRange.Enabled = True
        
        
        chkStart.Caption = "START"
    End If  'end of "If (chkStart.Value = 1) Then"

End Sub

Private Sub Form_Load()
    Dim lStatus As Long
    Dim lChannelCount As Long
    Dim i As Integer
    Dim lEvent As Long
        
    comboVRange.ListIndex = 0
    timerGatherValue.Enabled = False

        
    g_lLine = 1
    
    ' Library initialize.
    Initialize_AI
   
    
    ' Controls initialize.
    If AxlIsOpened() Then
        AxaInfoIsAIOModule lStatus
     
        Initialize_ListCtrl
        comboVRange.ListIndex = 0
    End If
        
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If AxlIsOpened() Then
        AxlClose
    End If

End Sub

Private Sub Initialize_ListCtrl()
    Dim lChannelCnt As Long
    Dim i1 As Integer
    Dim i2 As Integer
    Dim lBoardID As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lModuleNo As Long
        
    ' ListView Column Header Add
    With listAIChannelInfo
        .ColumnHeaders.Add 1, , "BoardNo", 1200, 0
        .ColumnHeaders.Add 2, , "ModuleNo", 1200, 0
        .ColumnHeaders.Add 3, , "ModuleID", 1200, 0
        .ColumnHeaders.Add 4, , "ChannelNo", 1120, 0
    End With
    
    ' Info collect for input channel
    AxaiInfoGetChannelCount lChannelCnt
    For i1 = 1 To lChannelCnt
        AxaiInfoGetModuleNoOfChannelNo i1, lModuleNo
        AxaInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        
        ' Channel info listview input data
        'BoardNo
        listAIChannelInfo.ListItems.Add i1, , CStr(lBoardNo), , 0
        'ModuleNo
        listAIChannelInfo.ListItems(i1).SubItems(1) = CStr(lModuleNo)
        'ModuleID
        listAIChannelInfo.ListItems(i1).SubItems(2) = CStr(lModuleID)
        'ChannelNo
        listAIChannelInfo.ListItems(i1).SubItems(3) = "#" + CStr(i1 - 1)
    
    Next
    
End Sub

Private Sub labelDataLength_Change()

    ' Outputdata list init
    listAnalogInput.ListItems.Clear

End Sub



Private Sub textDataLength_Change()
    Dim lDLength As Long
        
    ' if Data Length value over 50000 then set 50000
    If (IsNumeric(textDataLength.Text) = True) Then
        lDLength = CLng(textDataLength.Text)
        
        If (lDLength > MAXNUM_DATALENGTH) Then
            textDataLength.Text = CStr(MAXNUM_DATALENGTH)
        End If
    End If
    
End Sub

Private Sub textDataLength_LostFocus()
    Dim lDLength As Long
        
    ' if Data Length value over 50000 then set 50000
    If (IsNumeric(textDataLength.Text) = True) Then
        lDLength = CLng(textDataLength.Text)
        
        If (lDLength < MINNUM_DATALENGTH) Then
            textDataLength.Text = CStr(MINNUM_DATALENGTH)
        End If
    End If

End Sub

Private Sub timerGatherValue_Timer()    'NORMAL_MODE
    Dim dVolt As Double
    Dim i1, i2 As Integer
    Dim lDataLength As Long
    
    Dim lChannelCnt As Long
    Dim nCntChannelSelected As Integer
    
    
    ' Input channel all number
    AxaiInfoGetChannelCount lChannelCnt
    
    ' Selected channel all number
    nCntChannelSelected = 0
    For i1 = 0 To lChannelCnt - 1
        If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
            nCntChannelSelected = nCntChannelSelected + 1
        End If
    Next
    
    If nCntChannelSelected > 0 Then
    
        ' Init Variable
        lDataLength = CLng(textDataLength.Text)
        
        ' Line input
        If (g_lLine <= lDataLength) Then
            If (listAnalogInput.ListItems.Count < lDataLength) And _
               (listAnalogInput.ListItems.Count = g_lLine - 1) Then
                listAnalogInput.ListItems.Add g_lLine, , CStr(g_lLine), , 0
            End If
        End If

        ' Info collect for input channel
        i2 = 1
        For i1 = 0 To lChannelCnt - 1
            dVolt = 0
            If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
                AxaiSwReadVoltage i1, dVolt
                
                ' Read volt value input listview
                If (g_lLine <= lDataLength) Then
                    If (listAnalogInput.ListItems.Count <= lDataLength) And _
                    (listAnalogInput.ListItems.Count >= g_lLine) Then
                        listAnalogInput.ListItems(g_lLine).SubItems(i2) = Format(dVolt, "###.0000000")
                        i2 = i2 + 1
                    End If
                End If
            End If
        Next
        
        If (g_lLine = lDataLength) Then
            g_lLine = 1
        Else
            g_lLine = g_lLine + 1
        End If
        
    End If
   
End Sub
