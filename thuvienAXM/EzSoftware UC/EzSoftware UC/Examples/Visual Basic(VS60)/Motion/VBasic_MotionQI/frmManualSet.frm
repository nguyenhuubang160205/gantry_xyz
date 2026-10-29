VERSION 5.00
Begin VB.Form frmManualSet 
   Caption         =   "Manual Set"
   ClientHeight    =   2520
   ClientLeft      =   3060
   ClientTop       =   3120
   ClientWidth     =   7695
   LinkTopic       =   "Form1"
   ScaleHeight     =   2520
   ScaleWidth      =   7695
   Begin VB.Timer tmDisplay 
      Interval        =   100
      Left            =   4200
      Top             =   720
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   5
      Left            =   6000
      TabIndex        =   25
      Top             =   1995
      Width           =   1580
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   4
      Left            =   6000
      TabIndex        =   24
      Top             =   1590
      Width           =   1580
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   3
      Left            =   6000
      TabIndex        =   23
      Top             =   1200
      Width           =   1580
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   5
      Left            =   4920
      TabIndex        =   22
      Top             =   1995
      Width           =   975
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   4
      Left            =   4920
      TabIndex        =   21
      Top             =   1590
      Width           =   975
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   3
      Left            =   4920
      TabIndex        =   20
      Top             =   1200
      Width           =   975
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   255
      Index           =   5
      Left            =   3960
      TabIndex        =   19
      Top             =   2040
      Width           =   855
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   180
      Index           =   4
      Left            =   3960
      TabIndex        =   18
      Top             =   1680
      Width           =   855
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   255
      Index           =   3
      Left            =   3960
      TabIndex        =   17
      Top             =   1260
      Width           =   855
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   2
      Left            =   2280
      TabIndex        =   16
      Top             =   1995
      Width           =   1580
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   1
      Left            =   2280
      TabIndex        =   15
      Top             =   1590
      Width           =   1580
   End
   Begin VB.TextBox edtRdData 
      Height          =   375
      Index           =   0
      Left            =   2280
      TabIndex        =   14
      Top             =   1200
      Width           =   1580
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   2
      Left            =   1200
      TabIndex        =   13
      Top             =   1995
      Width           =   975
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   1
      Left            =   1200
      TabIndex        =   12
      Top             =   1590
      Width           =   975
   End
   Begin VB.TextBox edtRdCmd 
      Height          =   375
      Index           =   0
      Left            =   1200
      TabIndex        =   11
      Top             =   1200
      Width           =   975
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   280
      Index           =   2
      Left            =   240
      TabIndex        =   10
      Top             =   2040
      Width           =   855
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   280
      Index           =   1
      Left            =   240
      TabIndex        =   9
      Top             =   1635
      Width           =   855
   End
   Begin VB.CheckBox chkOnOff 
      Caption         =   "On/Off"
      Height          =   280
      Index           =   0
      Left            =   240
      TabIndex        =   8
      Top             =   1260
      Width           =   855
   End
   Begin VB.ComboBox cboAxisSel 
      Height          =   300
      Left            =   5040
      Style           =   2  '드롭다운 목록
      TabIndex        =   7
      Top             =   300
      Width           =   2415
   End
   Begin VB.CheckBox chkHex 
      Caption         =   "Hex/Dec"
      Height          =   255
      Left            =   3960
      TabIndex        =   6
      Top             =   315
      Width           =   1095
   End
   Begin VB.ComboBox cboPort 
      Height          =   300
      ItemData        =   "frmManualSet.frx":0000
      Left            =   2280
      List            =   "frmManualSet.frx":001C
      TabIndex        =   5
      Text            =   "Combo1"
      Top             =   720
      Width           =   1575
   End
   Begin VB.TextBox edtData 
      Height          =   375
      Left            =   2280
      TabIndex        =   4
      Top             =   240
      Width           =   1580
   End
   Begin VB.TextBox edtCmd 
      Height          =   375
      Left            =   1200
      TabIndex        =   3
      Top             =   240
      Width           =   975
   End
   Begin VB.CommandButton btnWr 
      Caption         =   "WR"
      Height          =   375
      Left            =   1200
      TabIndex        =   2
      Top             =   720
      Width           =   855
   End
   Begin VB.CommandButton btnRd 
      Caption         =   "RD"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   720
      Width           =   855
   End
   Begin VB.CommandButton btnCmd 
      Caption         =   "CMD"
      Height          =   375
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   855
   End
End
Attribute VB_Name = "frmManualSet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim m_lAxisNo As Long
Public Sub UpdateAxis(lAxis As Long)
    m_lAxisNo = lAxis
    cboAxisSel.ListIndex = m_lAxisNo
End Sub
Private Sub btnCmd_Click()
    Dim strTemp As String
    Dim nCmd As Integer
    Dim dwData As Long
    Dim lTempData As Long
    
    strTemp = edtCmd.Text
    If (Len(strTemp) = 0) Then
        lTempData = 0
    ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then
        strTemp = (Val("&H" + Mid(strTemp, 3, 4)))
        lTempData = CLng(Format(strTemp))
    Else
        lTempData = CLng(strTemp)
    End If
    nCmd = &HFF And lTempData
    
    strTemp = edtData.Text
    If (Len(strTemp) = 0) Then
        lTempData = 0
    ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then
        strTemp = (Val("&H" + Mid(strTemp, 3, 10)))
        lTempData = CLng(Format(strTemp))
    Else
        lTempData = CLng(strTemp)
    End If
    dwData = &HFFFFFFFF And lTempData
    
    If (&H80 And nCmd) Then
        Call AxmSetCommandData32Qi(m_lAxisNo, nCmd, dwData)
    Else
        Call AxmGetCommandData32Qi(m_lAxisNo, nCmd, dwData)
    End If
    
    If (chkHex.Value = 1) Then
        edtData.Text = "0x" + Format(Hex(dwData), "00000000")
    Else
        edtData.Text = Format(dwData, "00000000")
    End If
End Sub

Private Sub btnRd_Click()
    Dim dwData, dwOffset As Long
    Dim lTempData As Long

    lTempData = cboPort.ListIndex
    dwOffset = &H200 Or ((&HFF And lTempData) * 4)
    Call AxmGetPortDataQi(m_lAxisNo, dwOffset, dwData)
    
    If (chkHex.Value = 1) Then
        edtData.Text = "0x" + Format(Hex(dwData), "00000000")
    Else
        edtData.Text = Format(dwData, "00000000")
    End If
End Sub
Private Sub btnWr_Click()
    Dim strTemp As String
    Dim dwData, dwOffset As Long
    Dim lTempData As Long

    lTempData = cboPort.ListIndex
    dwOffset = &H200 Or ((&HFF And lTempData) * 4)

    strTemp = edtData.Text

    If (Len(strTemp) = 0) Then
        lTempData = 0
    ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then
        strTemp = (Val("&H" + Mid(strTemp, 3, 10)))
        lTempData = CLng(Format(strTemp))
    Else
        lTempData = CLng(strTemp)
    End If
    
    dwData = lTempData

    Call AxmSetPortDataQi(m_lAxisNo, dwOffset, dwData)

    If (chkHex.Value = 1) Then
        edtData.Text = "0x" + Format(Hex(dwData), "00000000")
    Else
        edtData.Text = Format(dwData, "00000000")
    End If
End Sub

Private Sub cboAxisSel_Click()
    m_lAxisNo = cboAxisSel.ListIndex
End Sub

Private Sub Form_Load()
    AxmInfoGetAxisCount m_lAxisCount
    If (m_lAxisCount < 1) Then Exit Sub
    
    For i = 0 To m_lAxisCount - 1
        cboAxisSel.AddItem Format(i) + " Axis"
    Next i
    
    cboAxisSel.ListIndex = 0
    cboPort.ListIndex = 0
    chkHex.Value = 1
End Sub

Private Sub tmDisplay_Timer()
    Dim nCmd As Integer
    Dim dwData As Long
    Dim lTempData As Long
    Dim i As Integer
    Dim strTemp As String

    For i = 0 To 5
        If (chkOnOff(i).Value = 1) Then
            strTemp = edtRdCmd(i).Text
            If (Len(strTemp) = 0) Then
                lTempData = 0
            ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then
                strTemp = (Val("&H" + Mid(strTemp, 3, 4)))
                lTempData = CLng(Format(strTemp))
            Else
                lTempData = CLng(strTemp)
            End If

            nCmd = &H7F And lTempData
            Call AxmGetCommandData32Qi(m_lAxisNo, nCmd, dwData)
            
            If (chkHex.Value = 1) Then
                edtRdData(i).Text = "0x" + Format(Hex(dwData), "00000000")
            Else
                edtRdData(i).Text = Format(dwData, "00000000")
            End If
        End If
    Next i
End Sub
