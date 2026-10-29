VERSION 5.00
Object = "{3EACF94A-AC86-4C57-B5C8-470911DAC903}#1.1#0"; "AxtMessenger.ocx"
Begin VB.Form frmDigitalIO 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "DigitalIO"
   ClientHeight    =   7020
   ClientLeft      =   -15
   ClientTop       =   270
   ClientWidth     =   7215
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7020
   ScaleWidth      =   7215
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin AXTMESSENGERLib.AxtMessenger AxtMsg 
      Height          =   390
      Left            =   3660
      TabIndex        =   42
      Top             =   6390
      Visible         =   0   'False
      Width           =   375
      _Version        =   65536
      _ExtentX        =   661
      _ExtentY        =   688
      _StockProps     =   0
      Message1        =   0
      Message2        =   0
      Message3        =   0
   End
   Begin VB.Timer Timer1 
      Interval        =   50
      Left            =   3120
      Top             =   6375
   End
   Begin VB.CheckBox chkInterrupt 
      Caption         =   "Enable Interrupt"
      Enabled         =   0   'False
      Height          =   375
      Left            =   240
      Style           =   1  'Graphical
      TabIndex        =   41
      Top             =   600
      Width           =   2775
   End
   Begin VB.CheckBox chkFalling 
      Caption         =   "Falling"
      Enabled         =   0   'False
      Height          =   375
      Left            =   5100
      Style           =   1  'Graphical
      TabIndex        =   40
      Top             =   600
      Width           =   1335
   End
   Begin VB.CheckBox chkRising 
      Caption         =   "Rising"
      Enabled         =   0   'False
      Height          =   375
      Left            =   3420
      Style           =   1  'Graphical
      TabIndex        =   39
      Top             =   600
      Width           =   1335
   End
   Begin VB.ListBox List1 
      ForeColor       =   &H00800000&
      Height          =   2595
      Left            =   225
      TabIndex        =   38
      Top             =   3630
      Width           =   6750
   End
   Begin VB.CommandButton cmdListClear 
      Caption         =   "List Clear"
      Height          =   495
      Left            =   240
      TabIndex        =   37
      Top             =   6360
      Width           =   2775
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "Close"
      Height          =   495
      Left            =   4200
      TabIndex        =   36
      Top             =   6360
      Width           =   2775
   End
   Begin VB.Frame Fra2ndWord 
      Caption         =   "Frame2"
      Height          =   1095
      Left            =   240
      TabIndex        =   19
      Top             =   2400
      Width           =   6735
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "16"
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   35
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "17"
         Height          =   255
         Index           =   1
         Left            =   1080
         TabIndex        =   34
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "18"
         Height          =   255
         Index           =   2
         Left            =   1920
         TabIndex        =   33
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "19"
         Height          =   255
         Index           =   3
         Left            =   2640
         TabIndex        =   32
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "20"
         Height          =   255
         Index           =   4
         Left            =   3480
         TabIndex        =   31
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "21"
         Height          =   255
         Index           =   5
         Left            =   4320
         TabIndex        =   30
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "22"
         Height          =   255
         Index           =   6
         Left            =   5160
         TabIndex        =   29
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "23"
         Height          =   255
         Index           =   7
         Left            =   6000
         TabIndex        =   28
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "24"
         Height          =   255
         Index           =   8
         Left            =   240
         TabIndex        =   27
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "25"
         Height          =   255
         Index           =   9
         Left            =   1080
         TabIndex        =   26
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "26"
         Height          =   255
         Index           =   10
         Left            =   1920
         TabIndex        =   25
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "27"
         Height          =   255
         Index           =   11
         Left            =   2640
         TabIndex        =   24
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "28"
         Height          =   255
         Index           =   12
         Left            =   3480
         TabIndex        =   23
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "29"
         Height          =   255
         Index           =   13
         Left            =   4320
         TabIndex        =   22
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "30"
         Height          =   255
         Index           =   14
         Left            =   5160
         TabIndex        =   21
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk2ndWord 
         Caption         =   "31"
         Height          =   255
         Index           =   15
         Left            =   6000
         TabIndex        =   20
         Top             =   720
         Width           =   615
      End
   End
   Begin VB.Frame Fra1stWord 
      Caption         =   "Frame1"
      Height          =   1095
      Left            =   240
      TabIndex        =   2
      Top             =   1200
      Width           =   6735
      Begin VB.CheckBox chk1stWord 
         Caption         =   "00"
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   18
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "01"
         Height          =   255
         Index           =   1
         Left            =   1080
         TabIndex        =   17
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "02"
         Height          =   255
         Index           =   2
         Left            =   1920
         TabIndex        =   16
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "03"
         Height          =   255
         Index           =   3
         Left            =   2640
         TabIndex        =   15
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "04"
         Height          =   255
         Index           =   4
         Left            =   3480
         TabIndex        =   14
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "05"
         Height          =   255
         Index           =   5
         Left            =   4320
         TabIndex        =   13
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "06"
         Height          =   255
         Index           =   6
         Left            =   5160
         TabIndex        =   12
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "07"
         Height          =   255
         Index           =   7
         Left            =   6000
         TabIndex        =   11
         Top             =   360
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "08"
         Height          =   255
         Index           =   8
         Left            =   240
         TabIndex        =   10
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "09"
         Height          =   255
         Index           =   9
         Left            =   1080
         TabIndex        =   9
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "10"
         Height          =   255
         Index           =   10
         Left            =   1920
         TabIndex        =   8
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "11"
         Height          =   255
         Index           =   11
         Left            =   2640
         TabIndex        =   7
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "12"
         Height          =   255
         Index           =   12
         Left            =   3480
         TabIndex        =   6
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "13"
         Height          =   255
         Index           =   13
         Left            =   4320
         TabIndex        =   5
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "14"
         Height          =   255
         Index           =   14
         Left            =   5160
         TabIndex        =   4
         Top             =   720
         Width           =   615
      End
      Begin VB.CheckBox chk1stWord 
         Caption         =   "15"
         Height          =   255
         Index           =   15
         Left            =   6000
         TabIndex        =   3
         Top             =   720
         Width           =   615
      End
   End
   Begin VB.ComboBox cboModule 
      Height          =   300
      Left            =   3240
      Style           =   2  'Dropdown List
      TabIndex        =   1
      Top             =   120
      Width           =   3735
   End
   Begin VB.Label Label1 
      Caption         =   "[Bo.No.:Mo.No.] Mo.ID"
      Height          =   255
      Left            =   255
      TabIndex        =   0
      Top             =   165
      Width           =   2415
   End
End
Attribute VB_Name = "frmDigitalIO"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'The module of the downside must be added to use DIO
'AXL.bas, AXHS.bas, AXD.bas

Option Explicit
Private Sub AxtMsg_OnMessage1(ByVal wParam As Long, ByVal lParam As Long)
    Dim nBoardNo As Long
    Dim nModuleNo As Long
    Dim nModulePos As Long
    Dim lValue, lChkBit As Long
    Dim i1 As Integer
    
    nBoardNo = Int(wParam / &H100)
    nModulePos = wParam - (Int(wParam / &H100) * &H100)
    AxdInfoGetModuleNo nBoardNo, nModulePos, nModuleNo
    
    AxdoReadOutportDword nModuleNo, 0, lValue
    For i1 = 0 To 31
        If Int(lParam / 2 ^ i1) And &H1 Then
            ' 해당모듈의 해당 오프셋의 비트값을 읽어온다.
            lChkBit = Int(lValue / (2 ^ i1)) And &H1
            
            If lChkBit Then
                List1.AddItem "Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▲Rising]"
            Else
                List1.AddItem "Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▼Falling]"
            End If

            List1.ListIndex = List1.ListCount - 1
        End If
    Next
End Sub

Private Sub Form_Load()
    Initialize_DIO
    SubOpenDevice
End Sub

Private Sub Initialize_DIO()
        If AxlOpen(7) <> AXT_RT_SUCCESS Then
            MsgBox "Library initialized failed." + vbCrLf, vbCritical
            End
        End If
End Sub

Private Sub SubOpenDevice()
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleCnt As Long
    Dim lModuleID As Long
    Dim i1 As Integer
    Dim strModuleName As String
    Dim szModuleDescription As String
    Dim szModuleName As String
    Dim nModuleSubID As Long
    Dim dwRetCode As Long
    
    szModuleName = Space(50)
    szModuleDescription = Space(80)
    dwRetCode = 0
    
        cboModule.Clear
        
        dwRetCode = AxdInfoGetModuleCount(lModuleCnt)
        If lModuleCnt > 0 Then
            For i1 = 0 To lModuleCnt - 1
        
                ' Get information(Board No, Module Pos, Module ID) of that module.
                AxdInfoGetModule i1, lBoardNo, lModulePos, lModuleID
            
                Select Case lModuleID
                    Case AXT_SIO_DI32
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DI32")
                    Case AXT_SIO_DO32P
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DO32P")
                    Case AXT_SIO_DO32T
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DO32T")
                    Case AXT_SIO_DB32P
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DB32P")
                    Case AXT_SIO_DB32T
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DB32T")
                    Case AXT_SIO_RDI32
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDI32")
                    Case AXT_SIO_RDO32
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDO32")
                    Case AXT_SIO_RSIMPLEIOMLII
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RSIMPLEIOMLII")
                    Case AXT_SIO_RDO16AMLII
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDO16AMLII")
                    Case AXT_SIO_RDO16BMLII
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "RDO16BMLII")
                    Case AXT_SIO_DI32_P
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DI32_P")
                    Case AXT_SIO_RDI32RTEX
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDI32RTEX")
                    Case AXT_SIO_DO32T_P
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-DO32T_P")
                    Case AXT_SIO_RDO32RTEX
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDO32RTEX")
                    Case AXT_SIO_RDB32T
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDB32T")
                    Case AXT_SIO_RDB32RTEX
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDB32RTEX")
                    Case AXT_SIO_RDB96MLII
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDB96MLII")
                    Case AXT_SIO_RDB128MLII
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "]" & "SIO-RDB128MLII")
                    Case AXT_ECAT_DIO
                        dwRetCode = AxdInfoGetModuleEx(i1, nModuleSubID, szModuleName, szModuleDescription)
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "] " & szModuleName)
                    Case Else
                        cboModule.AddItem ("[BD No:" & Format(lBoardNo, "00") & " - MD No:" & Format(i1, "00") & "] Unknown")
                End Select
            Next
            
            cboModule.ListIndex = 0
        End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    If AxlIsOpened Then
        AxlClose
    End If
    
End Sub

Private Function SubHiByte(wParam As Long) As Byte
    SubHiByte = Int(wParam / &H100):

End Function

Private Function SubLoByte(wParam As Long) As Byte
    Dim nHiByte As Integer
    
    nHiByte = Int(wParam / &H100):
    SubLoByte = wParam - (nHiByte * &H100)
    
    If SubLoByte > &H7FF Then SubLoByte = SubLoByte - &H100
    
End Function

Private Sub cmdClose_Click()
    
    Unload Me
End Sub

Private Sub cmdListClear_Click()
    
    List1.Clear
End Sub



Private Sub cboModule_Click()
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lModuleNo As Long
    Dim i1 As Long
    Dim lUse As Long
    Dim lEdge As Long
    Dim lValue As Long
    Dim lInCount, lOutCount As Long
    
    lInCount = 0
    lOutCount = 0
        
        ' Get information(Board No, Module Pos, Module ID) of that module.
        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        
        Select Case lModuleID
            Case AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_DI32_P, AXT_SIO_RDI32RTEX
                ' Structure to INPUT 32Bit
                Fra1stWord.Caption = " INPUT  0bit ~ 15Bit"
                Fra2ndWord.Caption = " INPUT 16bit ~ 31Bit"
                
                ' Used in digital Input.
                If (lModuleID = AXT_SIO_RDI32) Then
                    chkInterrupt.Enabled = False
                    chkRising.Enabled = False
                    chkFalling.Enabled = False
                Else
                    chkInterrupt.Enabled = True
                    chkRising.Enabled = True
                    chkFalling.Enabled = True
                
                    ' The module to specify confirmes an interrupt permission situation recognition.
                    AxdiInterruptGetModuleEnable lModuleNo, lUse
                    If lUse Then
                        chkInterrupt.Value = 1
                    Else
                        chkInterrupt.Value = 0
                    End If
                    
                    ' Confirmes whether the module to specify is UpEdge situation.
                    AxdiInterruptEdgeGetWord lModuleNo, 0, UP_EDGE, lEdge
                    If (lEdge = "&HFFFF") Then
                         chkRising.Value = 1
                    Else
                        chkRising.Value = 0
                    End If
                    
                    ' Confirmes whether the module to specify is DownEdge situation.
                    AxdiInterruptEdgeGetWord lModuleNo, 0, DOWN_EDGE, lEdge
                    If (lEdge = "&HFFFF") Then
                        chkFalling.Value = 1
                    Else
                        chkFalling.Value = 0
                    End If
                End If
                
                For i1 = 0 To 15
                    chk1stWord(i1).Caption = Format(i1, "00")
                    chk2ndWord(i1).Caption = Format(16 + i1, "00")
                Next
                
            Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32, AXT_SIO_DO32T_P, AXT_SIO_RDO32RTEX, AXT_SIO_RDO16AMLII, AXT_SIO_RDO16BMLII
            
                ' Structure to OUTPUT 32Bit
                Fra1stWord.Caption = "OUTPUT  0bit ~ 15Bit"
                Fra2ndWord.Caption = "OUTPUT 16bit ~ 31Bit"
                
                ' Only Digital Input was used
                chkInterrupt.Enabled = False
                chkRising.Enabled = False
                chkFalling.Enabled = False
                
                ' Display current OUTPUT(00bit~32bit) on state screen
                For i1 = 0 To 15
                    ' OUTPUT(00bit ~ 15bit) Verify output state
                    AxdoReadOutportBit lModuleNo, i1, lValue
                    If lValue Then
                        chk1stWord(i1).Value = 1
                    Else
                        chk1stWord(i1).Value = 0
                    End If

                    ' OUTPUT(16bit ~ 31bit) Verify output state
                    AxdoReadOutportBit lModuleNo, i1 + 16, lValue
                    If lValue Then
                        chk2ndWord(i1).Value = 1
                    Else
                        chk2ndWord(i1).Value = 0
                    End If
                    
                    chk1stWord(i1).Caption = Format(i1, "00")
                    chk2ndWord(i1).Caption = Format(16 + i1, "00")
                Next
                
            Case AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB32T, AXT_SIO_RDB32RTEX, AXT_SIO_RDB96MLII, AXT_SIO_RDB128MLII, AXT_SIO_RSIMPLEIOMLII
                ' Configure with INPUT 16 Bit and INPUT 32Bit
                Fra1stWord.Caption = " INPUT  0bit ~ 15Bit"
                Fra2ndWord.Caption = "OUTPUT  0bit ~ 15Bit"
                
                ' Only Digital Input was used
                chkInterrupt.Enabled = True
                chkRising.Enabled = True
                chkFalling.Enabled = True
                                
                ' Verify if the specific moudle is allowable state of interrupt
                AxdiInterruptGetModuleEnable lModuleNo, lUse
                If lUse Then
                    chkInterrupt.Value = 1
                Else
                    chkInterrupt.Value = 0
                End If
               
                ' Verify if the specific moudle is state of UpEdge
                AxdiInterruptEdgeGetWord lModuleNo, 0, UP_EDGE, lEdge
                If (lEdge = "&HFFFF") Then
                    chkRising.Value = 1
                Else
                    chkRising.Value = 0
                End If
                
                ' Verify if the specific moudle is state of DownEdge
                AxdiInterruptEdgeGetWord lModuleNo, 0, DOWN_EDGE, lEdge
                If (lEdge = "&HFFFF") Then
                    chkFalling.Value = 1
                Else
                    chkFalling.Value = 0
                End If
               
                'Display current OUTPUT(00bit~15bit) on state screen
                For i1 = 0 To 15
                    AxdoReadOutportBit lModuleNo, i1, lValue
                    If lValue Then
                        chk2ndWord(i1).Value = 1
                    Else
                        chk2ndWord(i1).Value = 0
                    End If
                    chk1stWord(i1).Caption = Format(i1, "00")
                    chk2ndWord(i1).Caption = Format(i1, "00")
                Next
                
            Case AXT_ECAT_DIO
                    AxdInfoGetInputCount lModuleNo, lInCount
                    AxdInfoGetOutputCount lModuleNo, lOutCount

                    If (lInCount > 16) Then
                        Fra1stWord.Caption = "INPUT  0bit ~ 15Bit"
                        Fra2ndWord.Caption = "INPUT 16bit ~ 31Bit"

                        For i1 = 0 To 15
                            chk2ndWord(i1).Enabled = 0
                            chk2ndWord(i1).Caption = Format(i1 + 16, "00")
                        Next

                        For i1 = 0 To 15
                            chk1stWord(i1).Enabled = 0
                        Next

                    ElseIf (lInCount > 0) Then
                        Fra1stWord.Caption = "INPUT  0bit ~ 15Bit"

                        For i1 = 0 To 15
                            chk1stWord(i1).Enabled = 0
                        Next

                        If (lOutCount > 0) Then
                            Fra2ndWord.Caption = "OUTPUT  0bit ~ 15Bit"
                            AxdoReadOutportWord lModuleNo, 0, lValue

                            For i1 = 0 To 15
                                chk2ndWord(i1).Enabled = 1
                                chk2ndWord(i1).Caption = Format(i1, "00")
                            Next
                        Else
                            Fra2ndWord.Caption = " "
                        End If
                    Else
                        If (lOutCount > 16) Then
                            Fra1stWord.Caption = "INPUT  0bit ~ 15Bit"
                            Fra2ndWord.Caption = "INPUT 16bit ~ 31Bit"

                            AxdoReadOutportWord lModuleNo, 0, lEdge
                            AxdoReadOutportWord lModuleNo, 1, lValue

                            For i1 = 0 To 15
                                chk1stWord(i1).Enabled = 1
                            Next

                            For i1 = 0 To 15
                                chk2ndWord(i1).Enabled = 1
                                chk2ndWord(i1).Caption = Format(i1 + 16, "00")
                            Next

                        ElseIf (lOutCount > 0) Then
                            Fra1stWord.Caption = "INPUT  0bit ~ 15Bit"
                            Fra2ndWord.Caption = " "

                            AxdoReadOutportWord lModuleNo, 0, lEdge

                            For i1 = 0 To 15
                                chk1stWord(i1).Enabled = 1
                            Next
                        End If
                    End If

                    chkInterrupt.Enabled = False
                    chkRising.Enabled = False
                    chkFalling.Enabled = False

                    For i1 = 0 To 15
                        AxdoReadOutportBit lModuleNo, i1, lValue
                        If lValue Then
                            chk2ndWord(i1).Value = 1
                        Else
                            chk2ndWord(i1).Value = 0
                        End If

                        If (lOutCount > 16) Then
                            chk1stWord(i1).Value = 1
                        Else
                            chk1stWord(i1).Value = 0
                        End If
                    Next
                
        End Select
End Sub

Private Sub chk1stWord_Click(Index As Integer)
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lOutCount As Long
  
        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID
            
            Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32
                ' OUTPUT(00bit ~ 15bit) output
                If chk1stWord(Index).Value Then
                    AxdoWriteOutportBit lModuleNo, Index, 1
                Else
                    AxdoWriteOutportBit lModuleNo, Index, 0
                End If
                
           Case AXT_ECAT_DIO
                    AxdInfoGetOutputCount lModuleNo, lOutCount
                    If (lOutCount > 16) Then
                        If chk1stWord(Index).Value Then
                            AxdoWriteOutportBit lModuleNo, Index, 1
                        Else
                            AxdoWriteOutportBit lModuleNo, Index, 0
                        End If
                    End If
                
        End Select
End Sub

Private Sub chk2ndWord_Click(Index As Integer)
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lOutCount As Long
    

        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID
           Case AXT_SIO_DB32P, AXT_SIO_DB32T
                ' OUTPUT(00bit ~ 15bit) output
                If chk2ndWord(Index).Value Then
                    AxdoWriteOutportBit lModuleNo, Index, 1
                Else
                    AxdoWriteOutportBit lModuleNo, Index, 0
                End If
           Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32
                ' OUTPUT(150bit ~ 31bit) output
                If chk2ndWord(Index).Value Then
                    AxdoWriteOutportBit lModuleNo, Index + 16, 1
                Else
                    AxdoWriteOutportBit lModuleNo, Index + 16, 0
                End If
            Case AXT_ECAT_DIO
                    AxdInfoGetOutputCount lModuleNo, lOutCount
                    If (lOutCount > 16) Then
                        If chk2ndWord(Index).Value Then
                            AxdoWriteOutportBit lModuleNo, Index + 16, 1
                        Else
                            AxdoWriteOutportBit lModuleNo, Index + 16, 0
                        End If
                    ElseIf (lOutCount > 0) Then
                        If chk2ndWord(Index).Value Then
                            AxdoWriteOutportBit lModuleNo, Index, 1
                        Else
                            AxdoWriteOutportBit lModuleNo, Index, 0
                        End If
                    End If
        End Select

End Sub


Private Sub Timer1_Timer()
    Dim nIndex As Integer
    Dim i1 As Long
    
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lValue As Long
    Dim lInCount As Long
    
        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID

            Case AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_DI32_P, AXT_SIO_RDI32RTEX
                For i1 = 0 To 15
                    ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                    AxdiReadInportBit lModuleNo, i1, lValue
                    If lValue Then
                        chk1stWord(i1).Value = 1
                    Else
                        chk1stWord(i1).Value = 0
                    End If
                    
                    ' INPUTOUTPUT (150bit ~ 31bit) Verify input
                    AxdiReadInportBit lModuleNo, i1 + 16, lValue
                    If lValue Then
                        chk2ndWord(i1).Value = 1
                    Else
                        chk2ndWord(i1).Value = 0
                    End If
                Next
                
            Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32, AXT_SIO_DO32T_P, AXT_SIO_RDO32RTEX, AXT_SIO_RDO16AMLII, AXT_SIO_RDO16BMLII
                For i1 = 0 To 15
                    ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                    AxdiReadInportBit lModuleNo, i1, lValue
                    If lValue Then
                        chk1stWord(i1).Value = 1
                    Else
                        chk1stWord(i1).Value = 0
                    End If
                Next
                
            Case AXT_ECAT_DIO
                    AxdInfoGetInputCount lModuleNo, lInCount
                    If (lInCount > 0) Then
                        For i1 = 0 To 1
                            AxdiReadInportBit lModuleNo, i1, lValue
                            If lValue Then
                                chk1stWord(i1).Value = 1
                            Else
                                chk1stWord(i1).Value = 0
                            End If
                            If (lInCount > 16) Then
                                AxdiReadInportBit lModuleNo, i1 + 16, lValue
                                If lValue Then
                                    chk2ndWord(i1).Value = 1
                                Else
                                    chk2ndWord(i1).Value = 0
                                End If
                            End If
                        Next
                    End If
        End Select
End Sub

Private Sub chkInterrupt_Click()
    Dim nIndex As Integer
    Dim i1 As Integer
    
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lValue As Long
    
    Dim szInterruptSelect As String
    Dim sInterruptEnable As String
    Dim sInterruptDisable As String
    Dim sInterruptFail As String
    
    szInterruptSelect = "※Please set edge"
    sInterruptEnable = "Enable Interrupt button is 'activated' "
    sInterruptDisable = "Enable Interrupt button is 'deactivated' "
    sInterruptFail = "Enable Interrupt button can not be used "
   
        lModuleNo = cboModule.ListIndex
      ' Retun base board number and module position of specific module number
        AxtMsg.Message1 = WM_AXL_INTERRUPT
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID
       
            Case AXT_SIO_DI32, _
                 AXT_SIO_DB32P, AXT_SIO_DB32T
                
                If chkInterrupt.Value Then
                    AxlInterruptEnable
                    AxdiInterruptSetModule lModuleNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0
                   
                   ' Allow interrupt of specific module
                    AxdiInterruptSetModuleEnable lModuleNo, 1
                   
                    List1.AddItem sInterruptEnable
                    List1.AddItem szInterruptSelect
                    List1.ListIndex = List1.ListCount - 1
                Else
                   ' Prohibit interrupt of specific module
                    AxdiInterruptSetModuleEnable lModuleNo, 0
                    AxlInterruptDisable
                   
                    chkRising.Value = 0
                    chkFalling.Value = 0
                   
                    List1.AddItem sInterruptDisable
                    List1.ListIndex = List1.ListCount - 1
                End If
               
            Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                List1.AddItem sInterruptFail
                List1.ListIndex = List1.ListCount - 1
        End Select

End Sub

Private Sub chkRising_Click()
    Dim nIndex As Integer
    Dim i1 As Integer
    
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lValue As Long
    
    Dim sStartMsg As String
    Dim sEndMsg As String
    Dim sErrMsg As String
    Dim sinterruptErrMsg As String
    
    sStartMsg = "'Start' Rising Edge detection"
    sEndMsg = "'Exit' Rising Edge detection"
    sErrMsg = "Can not use Rising Edge detection"
    sinterruptErrMsg = "Please enable interrupt button first."
    
        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID

            Case AXT_SIO_DI32
                
                If chkRising.Value Then
                    If chkInterrupt.Value Then
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetDword lModuleNo, 0, UP_EDGE, &HFFFFFFFF
                        
                        List1.AddItem sStartMsg
                        List1.ListIndex = List1.ListCount - 1
                    Else
                        List1.AddItem sErrMsg
                        
                        chkRising.Value = 0
                        
                        List1.AddItem sinterruptErrMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                Else
                    ' Set Interrupt Edge
                     AxdiInterruptEdgeSetWord lModuleNo, 0, UP_EDGE, &H0
                     AxdiInterruptEdgeSetWord lModuleNo, 1, UP_EDGE, &H0
                    
                    If List1.List(List1.ListCount - 1) <> sErrMsg Then
                        List1.AddItem sEndMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                End If
            
            Case AXT_SIO_DB32P, AXT_SIO_DB32T
                
                If chkRising.Value Then
                    If chkInterrupt.Value Then
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetDword lModuleNo, 0, UP_EDGE, &HFFFFFFFF
                        List1.AddItem sStartMsg
                        List1.ListIndex = List1.ListCount - 1
                    Else
                        List1.AddItem sErrMsg
                        chkRising.Value = 0
                        List1.AddItem sinterruptErrMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                Else
                    ' Set Interrupt Edge
                    AxdiInterruptEdgeSetWord lModuleNo, 0, UP_EDGE, &H0
                    
                    If List1.List(List1.ListCount - 1) <> sErrMsg Then
                        List1.AddItem sEndMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                End If
                
            Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                List1.AddItem sinterruptErrMsg
                List1.ListIndex = List1.ListCount - 1
            
        End Select

End Sub

Private Sub chkFalling_Click()
    Dim nIndex As Integer
    Dim i1 As Integer
    
    Dim lModuleNo As Long
    Dim lBoardNo As Long
    Dim lModulePos As Long
    Dim lModuleID As Long
    Dim lValue As Long
    
    Dim sStartMsg As String
    Dim sEndMsg As String
    Dim sErrMsg As String
    Dim sinterruptErrMsg As String
    
    sStartMsg = "'Start' Falling Edge detection"
    sEndMsg = "'Exit' Falling Edge detection"
    sErrMsg = "Can not use Falling Edge detection"
    sinterruptErrMsg = "Please enable interrupt button first."

        lModuleNo = cboModule.ListIndex
        AxdInfoGetModule lModuleNo, lBoardNo, lModulePos, lModuleID
        Select Case lModuleID
            Case AXT_SIO_DI32
                
                If chkFalling.Value Then
                    If chkInterrupt.Value Then
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetDword lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF
                        
                        List1.AddItem sStartMsg
                        List1.ListIndex = List1.ListCount - 1
                    Else
                        List1.AddItem sErrMsg
                        
                        chkFalling.Value = 0
                        
                        List1.AddItem sinterruptErrMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                Else
                    ' Set Interrupt Edge
                     AxdiInterruptEdgeSetWord lModuleNo, 0, DOWN_EDGE, &H0
                     AxdiInterruptEdgeSetWord lModuleNo, 1, DOWN_EDGE, &H0
                    
                    If List1.List(List1.ListCount - 1) <> sErrMsg Then
                        List1.AddItem sEndMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                End If
            
            Case AXT_SIO_DB32P, AXT_SIO_DB32T
                
                If chkFalling.Value Then
                    If chkInterrupt.Value Then
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetDword lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF
                        
                        List1.AddItem sStartMsg
                        List1.ListIndex = List1.ListCount - 1
                    Else
                                                                       
                        List1.AddItem sErrMsg
                        
                        chkFalling.Value = 0
                        
                        List1.AddItem sinterruptErrMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                Else
                    ' Set Interrupt Edge
                    AxdiInterruptEdgeSetWord lModuleNo, 0, DOWN_EDGE, &H0
                    
                    If List1.List(List1.ListCount - 1) <> sErrMsg Then
                        List1.AddItem sEndMsg
                        List1.ListIndex = List1.ListCount - 1
                    End If
                End If
            Case AXT_SIO_DO32P, AXT_SIO_DO32T
                List1.AddItem sinterruptErrMsg
                List1.ListIndex = List1.ListCount - 1
        End Select

End Sub
