VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmAnalogOutput 
   AutoRedraw      =   -1  'True
   Caption         =   "AnalogOutput"
   ClientHeight    =   3150
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9255
   LinkTopic       =   "Form1"
   ScaleHeight     =   3150
   ScaleWidth      =   9255
   StartUpPosition =   3  'Windows 기본값
   Begin VB.Timer TimerControlWave 
      Interval        =   1
      Left            =   8760
      Top             =   0
   End
   Begin VB.Frame Frame1 
      Caption         =   "Setting"
      Height          =   2895
      Left            =   6720
      TabIndex        =   1
      Top             =   120
      Width           =   2415
      Begin VB.CheckBox chkStart 
         Caption         =   "START"
         Height          =   615
         Left            =   240
         Style           =   1  '그래픽
         TabIndex        =   12
         Top             =   2160
         Width           =   1935
      End
      Begin VB.ComboBox comboRange 
         Height          =   300
         ItemData        =   "frmAnalogOutput.frx":0000
         Left            =   1080
         List            =   "frmAnalogOutput.frx":0007
         Style           =   2  '드롭다운 목록
         TabIndex        =   11
         Top             =   1080
         Width           =   1215
      End
      Begin VB.TextBox textPeriod 
         Height          =   270
         Left            =   1080
         TabIndex        =   10
         Text            =   "100"
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox textVoltage 
         Height          =   270
         Left            =   1080
         MaxLength       =   10
         TabIndex        =   9
         Text            =   "0"
         Top             =   1800
         Width           =   1215
      End
      Begin VB.ComboBox comboInterval 
         Height          =   300
         ItemData        =   "frmAnalogOutput.frx":0013
         Left            =   1080
         List            =   "frmAnalogOutput.frx":0020
         Style           =   2  '드롭다운 목록
         TabIndex        =   8
         Top             =   1440
         Width           =   1215
      End
      Begin VB.ComboBox comboWave 
         Height          =   300
         ItemData        =   "frmAnalogOutput.frx":0036
         Left            =   1080
         List            =   "frmAnalogOutput.frx":0046
         Style           =   2  '드롭다운 목록
         TabIndex        =   7
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label5 
         Caption         =   "Voltage"
         Height          =   375
         Left            =   240
         TabIndex        =   6
         Top             =   1800
         Width           =   615
      End
      Begin VB.Label Label4 
         Caption         =   "Interval"
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   1440
         Width           =   615
      End
      Begin VB.Label Label3 
         Caption         =   "V Range"
         Height          =   255
         Left            =   120
         TabIndex        =   4
         Top             =   1080
         Width           =   735
      End
      Begin VB.Label Label2 
         Caption         =   "Period"
         Height          =   255
         Left            =   240
         TabIndex        =   3
         Top             =   720
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "WaveType"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   360
         Width           =   975
      End
   End
   Begin MSComctlLib.ListView listAnalogOutput 
      Height          =   2895
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   6495
      _ExtentX        =   11456
      _ExtentY        =   5106
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      AllowReorder    =   -1  'True
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
End
Attribute VB_Name = "frmAnalogOutput"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' The module of the downside must be added to use Analog Input/Output
' AXL.bas , AXHS.bas , AXA.bas

Option Explicit
Private Const MAXNUM_WAVETYPE As Integer = 4        'Wave all number
Private Const MAXNUM_RANGETYPE As Integer = 4       'Range type all number
Private Const MAXNUM_PERIODTYPE As Integer = 3      'Period type all number
Private Const MAXVAL_PERIOD As Integer = 500        'Period max number
Private Const MINVAL_PERIOD As Integer = 50         'Period min number
Private Const MAXNUM_LISTSUBITEM As Integer = 8
Private Const PI As Double = 3.141592

Private Type SAOChannel
    bUse As Boolean         'utility yes or no
    lModuleNo As Long       'Module number
    lModuleID As Long       'Module ID
    lChannelNo As Long      'Channel number
    nWave As Integer        'Wave set index
    lPeriod As Long         'Period value
    nVRange As Integer      'Period set index
    dVoltage As Double      'Voltage
    lIndex As Long
End Type

Dim g_stChannelInfo() As SAOChannel         'The arrangement to be made the channel information
Dim g_nIndexOfItemSelected As Integer       'An item index of listview to be selected.
Dim g_bIsStartMode As Boolean

Private Sub chkStart_Click()
    If (chkStart.Value = 1) Then
        chkStart.Caption = "WRITING"
    Else
        chkStart.Caption = "START"
    End If
    
End Sub

Private Sub comboInterval_Click()
    Select Case comboInterval.ListIndex
        Case 0
            TimerControlWave.Interval = 1
        Case 1
            TimerControlWave.Interval = 5
        Case 2
            TimerControlWave.Interval = 10
    End Select

End Sub

Private Sub comboRange_Click()
    Dim nRange As Integer
    Dim nIndexSel As Integer
    
    ' bring a wavetype index to be selected.
    nRange = comboRange.ListIndex
    
    ' Data input at the listview    // wavetype
    nIndexSel = g_nIndexOfItemSelected - 1
    If nIndexSel > -1 Then
        g_stChannelInfo(nIndexSel).nVRange = comboRange.ListIndex
        listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(6) = comboRange.Text
        
        ' Volt range setting up
        Select Case comboRange.ListIndex
            Case 0  '-10 ~ 10
                AxaoSetRange nIndexSel, -10, 10
        End Select
        
    End If

End Sub

Private Sub comboWave_Click()
    Dim nWave As Integer
    Dim nIndexSel As Integer
    
    ' bring a wavetype index to be selected.
    nWave = comboWave.ListIndex
    
    ' Data input at the listview    // wavetype
    nIndexSel = g_nIndexOfItemSelected - 1
    If nIndexSel > -1 Then
        g_stChannelInfo(nIndexSel).nWave = comboWave.ListIndex
        listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(4) = comboWave.Text

    End If
    
    If (nWave < 3) Then     'Sin, Triangle, Rectangle
        textPeriod.Enabled = True
        textPeriod.BackColor = &H80000005
        textVoltage.Enabled = False
        textVoltage.BackColor = &H8000000B
    ElseIf (nWave = 3) Then   'Volt
        textPeriod.Enabled = False
        textPeriod.BackColor = &H8000000B
        textVoltage.Enabled = True
        textVoltage.BackColor = &H80000005
    End If
 
End Sub

Private Sub Form_Activate()
    g_nIndexOfItemSelected = 1

End Sub

Private Sub Form_Load()
    
    'Init variable
    g_nIndexOfItemSelected = -1

    comboWave.ListIndex = 0
    comboRange.ListIndex = 0
    comboInterval.ListIndex = 0
    
    'Control and Library initialize
    Initialize_AIO
    Initialize_ListCtrl
    
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    If AxlIsOpened Then
        ' Library close
        AxlClose
    End If
    
End Sub

Private Sub Initialize_AIO()
Dim lState As Long
   
    ' Confirm Library initialized.
    If AxlIsOpened = False Then
        ' Library initialize
        If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then
            
            MsgBox "Library initialized failed." + vbCrLf + _
                   "Please reset program", vbCritical
            End
        End If
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
    
    ' ListView의 Column Header Add
    With listAnalogOutput
        .ColumnHeaders.Add 1, , "Channel", 800, 0
        .ColumnHeaders.Add 2, , "Module No", 800, 0
        .ColumnHeaders.Add 3, , "Module ID", 800, 0
        .ColumnHeaders.Add 4, , "Channel No", 800, 0
        .ColumnHeaders.Add 5, , "WaveType", 800, 0
        .ColumnHeaders.Add 6, , "Period", 800, 0
        .ColumnHeaders.Add 7, , "Volt Range", 800, 0
        .ColumnHeaders.Add 8, , "Voltage", 840, 0
    End With
    
    ' Get Output Channel number
    AxaoInfoGetChannelCount lChannelCnt
    ' Suitable to the number of channels arrangement finance's
    ReDim g_stChannelInfo(lChannelCnt) As SAOChannel
    
    For i1 = 0 To lChannelCnt - 1
        AxaoWriteVoltage i1, 0
        AxaoInfoGetModuleNoOfChannelNo i1, lModuleNo
        AxaInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        
        ' Channel information collection
        g_stChannelInfo(i1).bUse = False
        g_stChannelInfo(i1).lModuleNo = lModuleNo
        g_stChannelInfo(i1).lModuleID = lModuleID
        g_stChannelInfo(i1).lChannelNo = i1
        g_stChannelInfo(i1).nWave = comboWave.ListIndex
        g_stChannelInfo(i1).lPeriod = CLng(textPeriod.Text)
        g_stChannelInfo(i1).nVRange = comboRange.ListIndex
        g_stChannelInfo(i1).dVoltage = CLng(textVoltage.Text)
        
        ' express the information at listview
        refreshListAnalogOutput i1
    Next
   
End Sub

Private Sub refreshListAnalogOutput(ByVal nIndex As Integer)
    Dim i1 As Integer
    i1 = nIndex
    
    ' Data input at listview
    ' Channel
    listAnalogOutput.ListItems.Add i1 + 1, , CStr(i1 + 1), , 0
    ' use/not use setting up
    listAnalogOutput.ListItems.Item(i1 + 1).Checked = g_stChannelInfo(i1).bUse
    ' Module No
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(1) = CStr(g_stChannelInfo(i1).lModuleNo)
    ' Module ID
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(2) = CStr(g_stChannelInfo(i1).lModuleID)
    ' Channel No
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(3) = CStr(g_stChannelInfo(i1).lChannelNo)
    ' WaveType
    comboWave.ListIndex = g_stChannelInfo(i1).nWave
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(4) = comboWave.Text
    ' Period
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(5) = CStr(g_stChannelInfo(i1).lPeriod)
    ' Volt range
    comboRange.ListIndex = g_stChannelInfo(i1).nVRange
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(6) = comboRange.Text
    ' Voltage
    listAnalogOutput.ListItems.Item(i1 + 1).SubItems(7) = CStr(g_stChannelInfo(i1).dVoltage)
    
End Sub

Private Sub RefreshCtrlAboutSetting()
    Dim nIndexSel As Integer
    
    nIndexSel = g_nIndexOfItemSelected - 1
    If nIndexSel > -1 Then
        comboWave.ListIndex = g_stChannelInfo(nIndexSel).nWave          ' WaveType
        textPeriod.Text = CStr(g_stChannelInfo(nIndexSel).lPeriod)      ' Period
        comboRange.ListIndex = g_stChannelInfo(nIndexSel).nVRange       ' Volt range
        textVoltage.Text = CStr(g_stChannelInfo(nIndexSel).dVoltage)    ' Voltage
    End If
End Sub
        
Private Sub listAnalogOutput_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    Dim nIndexSel As Integer
    
    nIndexSel = Item - 1
    If nIndexSel > -1 Then
        g_stChannelInfo(nIndexSel).bUse = Item.Checked
    End If

End Sub

Private Sub listAnalogOutput_ItemClick(ByVal Item As MSComctlLib.ListItem)
    g_nIndexOfItemSelected = Item
    
    ' Input value of setting control
    RefreshCtrlAboutSetting
End Sub

Private Sub textPeriod_Change()
    Dim nIndexSel As Integer
    Dim nPeriod As Integer
    
    If IsNumeric(textPeriod.Text) = True Then
        nPeriod = CInt(textPeriod.Text)
        ' A validity inspection of a cycle price to be input
        If (nPeriod < 0) Then
            textPeriod.Text = CStr(0)
        ElseIf (nPeriod > MAXVAL_PERIOD) Then
            textPeriod.Text = CStr(MAXVAL_PERIOD)
        End If
    
        ' Data input at listview    // Period
        nIndexSel = g_nIndexOfItemSelected - 1
        If nIndexSel > -1 Then
            g_stChannelInfo(nIndexSel).lPeriod = CLng(textPeriod.Text)
            listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(5) = textPeriod.Text
        End If
    End If

End Sub

Private Sub textPeriod_LostFocus()
    Dim nIndexSel As Integer
    Dim nPeriod As Integer
            
    nIndexSel = g_nIndexOfItemSelected - 1
    
    ' Period value setting up to rather small a minimum price 50.
    If IsNumeric(textPeriod.Text) = True Then
        nPeriod = CInt(textPeriod.Text)
        If nPeriod < 50 Then
            If nIndexSel > -1 Then
                g_stChannelInfo(nIndexSel).lPeriod = 50
                textPeriod.Text = "50"
            End If
        End If
    Else
        If nIndexSel > -1 Then
            g_stChannelInfo(nIndexSel).lPeriod = 50
            textPeriod.Text = "50"
        End If
    End If

End Sub

Private Sub TimerControlWave_Timer()
    Dim i1 As Integer
    Dim lChannelCnt As Long
    Dim dVRange As Double
    Dim dPeriod As Double
    Dim dValue As Double
    
    Dim nIndexSel As Integer
    nIndexSel = g_nIndexOfItemSelected - 1
           
    If (chkStart.Value = 1) Then
        ' cardinality of a total output channel
        AxaoInfoGetChannelCount lChannelCnt
        For i1 = 0 To lChannelCnt - 1
            If (g_stChannelInfo(i1).bUse = True) Then
                ' To do the change of wavetype according to Volt range
                Select Case g_stChannelInfo(i1).nVRange
                    Case 0
                        dVRange = 10
                    Case 1
                        dVRange = 5
                    Case 2
                        dVRange = 10
                    Case 3
                        dVRange = 5
                End Select
                
                ' setting up to increase
                If (g_stChannelInfo(i1).lIndex >= g_stChannelInfo(i1).lPeriod) Then
                    g_stChannelInfo(i1).lIndex = 0
                Else
                    g_stChannelInfo(i1).lIndex = g_stChannelInfo(i1).lIndex + TimerControlWave.Interval
                End If
                
                Select Case g_stChannelInfo(i1).nWave
                    Case 0  ' Sin wave
                        dPeriod = g_stChannelInfo(i1).lPeriod / 2#
                        If (g_stChannelInfo(i1).lIndex = 0) Then
                            dValue = 0
                        Else
                            dValue = Sin(g_stChannelInfo(i1).lIndex * PI / dPeriod) * dVRange
                        End If
                        
                        ' Output
                        AxaoWriteVoltage i1, dValue
                    Case 1  ' Triangle wave
                        ' under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
                        If (g_stChannelInfo(i1).lIndex < g_stChannelInfo(i1).lPeriod / 4#) Then
                            dValue = dVRange / (g_stChannelInfo(i1).lPeriod / 4) * g_stChannelInfo(i1).lIndex
                        ' under the falling which the interval (case which the interval is 100 25 ~ 74)
                        ElseIf (g_stChannelInfo(i1).lIndex < ((g_stChannelInfo(i1).lPeriod / 4#) * 3)) Then
                            dValue = -((dVRange / (g_stChannelInfo(i1).lPeriod / 4)) * g_stChannelInfo(i1).lIndex) + dVRange * 2#
                        ' under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
                        Else
                            dValue = ((dVRange / (g_stChannelInfo(i1).lPeriod / 4)) * g_stChannelInfo(i1).lIndex) - dVRange * 4#
                        End If
                        
                        ' Output
                        AxaoWriteVoltage i1, dValue
                        
                    Case 2  ' Rectangle wave
                        ' under the rise which the interval (case which the interval is 100 0 ~ 49)
                        If (g_stChannelInfo(i1).lIndex < g_stChannelInfo(i1).lPeriod / 2#) Then
                            dValue = dVRange
                        Else
                            dValue = -dVRange
                        End If
                        
                        ' Output
                        AxaoWriteVoltage i1, dValue
                End Select
            End If
        Next
    End If  'If (chkStart.Value = True) Then

End Sub

Private Sub textVoltage_Change()
    Dim nIndexSel As Integer
    Dim nRange As Integer
    Dim dVoltage As Double
      
    nIndexSel = g_nIndexOfItemSelected - 1
  
    If IsNumeric(textVoltage.Text) = True Then
        
        dVoltage = CDbl(textVoltage.Text)
        ' validity inspection of Volt value to be input
    '    Select Case comboRange.ListIndex
    '        Case 0  ' -10 ~ 10
                If (dVoltage < -10) Then
                    dVoltage = -10
                    textVoltage = CStr(dVoltage)
                ElseIf (dVoltage > 10) Then
                    dVoltage = 10
                    textVoltage = CStr(dVoltage)
                End If
     '       Case 3  ' -5 ~ 5
     '           If (dVoltage < -5) Then
     '               dVoltage = -5
     '               textVoltage = CStr(dVoltage)
     '           ElseIf (dVoltage > 5) Then
     '               dVoltage = 5
     '               textVoltage = CStr(dVoltage)
     '           End If
     '   End Select
        
        ' Data input at listview    // Voltage
        
        If (nIndexSel > -1) Then
            g_stChannelInfo(nIndexSel).dVoltage = CDbl(textVoltage.Text)
            listAnalogOutput.ListItems.Item(nIndexSel + 1).SubItems(7) = textVoltage.Text
            
            ' output
            AxaoWriteVoltage nIndexSel, g_stChannelInfo(nIndexSel).dVoltage
        End If
    End If

End Sub
