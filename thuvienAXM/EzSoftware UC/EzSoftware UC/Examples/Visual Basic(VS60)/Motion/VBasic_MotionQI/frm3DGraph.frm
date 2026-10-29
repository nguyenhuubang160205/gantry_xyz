VERSION 5.00
Object = "{0C9D2BC6-B659-450E-9720-D3A89198AE8B}#1.1#0"; "AxtGraph3D.ocx"
Begin VB.Form frm3DGraph 
   BorderStyle     =   1  '단일 고정
   Caption         =   "3DGraphView"
   ClientHeight    =   6660
   ClientLeft      =   2940
   ClientTop       =   2640
   ClientWidth     =   12060
   LinkTopic       =   "3DView"
   MaxButton       =   0   'False
   ScaleHeight     =   6660
   ScaleWidth      =   12060
   Begin VB.CommandButton btnClear 
      Caption         =   "Clear"
      Height          =   615
      Left            =   120
      TabIndex        =   25
      Top             =   5880
      Width           =   1815
   End
   Begin VB.CommandButton btnSpline 
      Caption         =   "Spline"
      Height          =   615
      Left            =   2040
      TabIndex        =   24
      Top             =   3390
      Width           =   1815
   End
   Begin VB.CommandButton btnSplinePlay 
      Caption         =   "Spline Play"
      Height          =   615
      Left            =   2040
      TabIndex        =   23
      Top             =   4080
      Width           =   1815
   End
   Begin VB.CommandButton btnHelical 
      Caption         =   "Helical"
      Height          =   615
      Left            =   120
      TabIndex        =   22
      Top             =   3360
      Width           =   1815
   End
   Begin VB.CommandButton btnHelicalPlay 
      Caption         =   "HelicalPlay"
      Height          =   615
      Left            =   120
      TabIndex        =   21
      Top             =   4080
      Width           =   1815
   End
   Begin VB.TextBox Text3 
      Alignment       =   1  '오른쪽 맞춤
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   300
      Left            =   3960
      TabIndex        =   20
      Text            =   "CMD Z:"
      Top             =   960
      Width           =   735
   End
   Begin VB.TextBox Text2 
      Alignment       =   1  '오른쪽 맞춤
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   300
      Left            =   3960
      TabIndex        =   19
      Text            =   "CMD Y:"
      Top             =   600
      Width           =   735
   End
   Begin VB.TextBox Text1 
      Alignment       =   1  '오른쪽 맞춤
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   300
      Left            =   3960
      TabIndex        =   18
      Text            =   "CMD X:"
      Top             =   240
      Width           =   735
   End
   Begin VB.TextBox edtCmdPosX 
      Alignment       =   1  '오른쪽 맞춤
      Appearance      =   0  '평면
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   300
      Left            =   4800
      Locked          =   -1  'True
      TabIndex        =   16
      TabStop         =   0   'False
      Text            =   "0.000"
      Top             =   240
      Width           =   1215
   End
   Begin VB.TextBox edtCmdPosY 
      Alignment       =   1  '오른쪽 맞춤
      Appearance      =   0  '평면
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   300
      Left            =   4800
      Locked          =   -1  'True
      TabIndex        =   15
      TabStop         =   0   'False
      Text            =   "0.000"
      Top             =   600
      Width           =   1215
   End
   Begin VB.TextBox edtCmdPosZ 
      Alignment       =   1  '오른쪽 맞춤
      Appearance      =   0  '평면
      BackColor       =   &H80000006&
      BorderStyle     =   0  '없음
      BeginProperty Font 
         Name            =   "굴림"
         Size            =   9.75
         Charset         =   129
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   300
      Left            =   4800
      Locked          =   -1  'True
      TabIndex        =   17
      TabStop         =   0   'False
      Text            =   "0.000"
      Top             =   960
      Width           =   1215
   End
   Begin VB.CommandButton btnSetRange 
      Caption         =   "Set Range"
      Height          =   495
      Left            =   300
      TabIndex        =   14
      Top             =   2505
      Width           =   3375
   End
   Begin VB.CheckBox chkBoxEnable 
      Caption         =   "Box Enable"
      Height          =   255
      Left            =   2280
      TabIndex        =   4
      Top             =   1440
      Width           =   1335
   End
   Begin VB.ComboBox cboDimension 
      Height          =   300
      ItemData        =   "frm3DGraph.frx":0000
      Left            =   1320
      List            =   "frm3DGraph.frx":0010
      Style           =   2  '드롭다운 목록
      TabIndex        =   2
      Top             =   960
      Width           =   2295
   End
   Begin VB.ComboBox cboAxisReset 
      Height          =   300
      ItemData        =   "frm3DGraph.frx":005C
      Left            =   1320
      List            =   "frm3DGraph.frx":006C
      Style           =   2  '드롭다운 목록
      TabIndex        =   1
      Top             =   480
      Width           =   2295
   End
   Begin VB.CommandButton btnClose 
      Caption         =   "Close"
      Height          =   615
      Left            =   2040
      TabIndex        =   0
      Top             =   5880
      Width           =   1815
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   240
      Top             =   4800
   End
   Begin AXTGRAPH3DLib.AxtGraph3D AxtGraph3D 
      Height          =   6375
      Left            =   3960
      TabIndex        =   3
      Top             =   120
      Width           =   7935
      _Version        =   65536
      _ExtentX        =   13996
      _ExtentY        =   11245
      _StockProps     =   0
      SymbolSize      =   5
      BackgroundColor =   0
      AllowMouseRotate=   -1  'True
      SetAutoScaleX   =   -1  'True
      SetAutoScaleY   =   -1  'True
      SetAutoScaleZ   =   -1  'True
      SetRangeX       =   5000
      SetRangeY       =   5000
      SetRangeZ       =   0
      SetAxisColorX   =   -2247
      SetAxisColorY   =   -563
      SetAxisColorZ   =   -2247
      SetAxisTextX    =   ""
      SetAxisTextY    =   ""
      SetAxisTextZ    =   ""
      SetGridColorX   =   -2247
      SetGridColorY   =   -563
      SetGridColorZ   =   -2247
      SetGridLineStyleX=   -563
      SetGridLineStyleY=   -1
      SetGridLineStyleZ=   0
      SetGridTypeX    =   0
      SetGridTypeY    =   0
      SetGridTypeZ    =   0
      SetAxisPatternX =   0
      SetAxisPatternY =   0
      SetAxisPatternZ =   0
      SetBoxColor     =   0
      SetBoxPattern   =   0
      SetBoxEnable    =   0   'False
      SetPlotColor    =   0
      SetRangeColorX  =   0
      SetRangeColorY  =   1
      SetRangeColorZ  =   0
   End
   Begin VB.Frame Frame13 
      Caption         =   "Graph Properties"
      Height          =   3135
      Left            =   120
      TabIndex        =   5
      Top             =   120
      Width           =   3735
      Begin VB.TextBox TextRangeZ 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   9.75
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   2490
         TabIndex        =   13
         Text            =   "2500"
         Top             =   1995
         Width           =   1065
      End
      Begin VB.TextBox TextRangeY 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   9.75
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   1350
         TabIndex        =   12
         Text            =   "2500"
         Top             =   1995
         Width           =   1065
      End
      Begin VB.TextBox TextRangeX 
         Alignment       =   1  '오른쪽 맞춤
         BackColor       =   &H80000006&
         BeginProperty Font 
            Name            =   "굴림"
            Size            =   9.75
            Charset         =   129
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0000FFFF&
         Height          =   300
         Left            =   195
         TabIndex        =   11
         Text            =   "2500"
         Top             =   1995
         Width           =   1065
      End
      Begin VB.Label RangeZ 
         Alignment       =   2  '가운데 맞춤
         AutoSize        =   -1  'True
         BorderStyle     =   1  '단일 고정
         Caption         =   "RANGEZ"
         Height          =   240
         Index           =   1
         Left            =   2490
         TabIndex        =   10
         Top             =   1665
         Width           =   1065
      End
      Begin VB.Label RangeY 
         Alignment       =   2  '가운데 맞춤
         AutoSize        =   -1  'True
         BorderStyle     =   1  '단일 고정
         Caption         =   "RANGEY"
         Height          =   240
         Index           =   0
         Left            =   1350
         TabIndex        =   9
         Top             =   1680
         Width           =   1065
      End
      Begin VB.Label RangeX 
         Alignment       =   2  '가운데 맞춤
         AutoSize        =   -1  'True
         BorderStyle     =   1  '단일 고정
         Caption         =   "RANGEX"
         Height          =   240
         Index           =   5
         Left            =   195
         TabIndex        =   8
         Top             =   1680
         Width           =   1065
      End
      Begin VB.Label Reset 
         Alignment       =   2  '가운데 맞춤
         Caption         =   "Reset Axis"
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   360
         Width           =   1095
      End
      Begin VB.Label Dimension 
         Alignment       =   2  '가운데 맞춤
         Caption         =   "Dimension"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   6
         Top             =   840
         Width           =   1095
      End
   End
End
Attribute VB_Name = "frm3DGraph"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim m_aAxis(3) As Long
Dim m_SliderRange As Long

Private Sub btnSetRange_Click()
    Dim dVRangeX As Double
    Dim dVRangeY As Double
    Dim dVRangeZ As Double
  
    dVRangeX = CDbl(TextRangeX.Text)
    dVRangeY = CDbl(TextRangeY.Text)
    dVRangeZ = CDbl(TextRangeZ.Text)

    AxtGraph3D.SetRangeX = dVRangeX
    AxtGraph3D.SetRangeY = dVRangeY
    AxtGraph3D.SetRangeZ = dVRangeZ

End Sub

Private Sub cboAxisReset_Click()
  Dim lIndex As Long
  lIndex = cboAxisReset.ListIndex
    Select Case lIndex
        Case 0
           AxtGraph3D.SetRangeX = 2500
           AxtGraph3D.SetRangeY = 2500
           
        Case 1
            AxtGraph3D.SetRangeY = 2500
            AxtGraph3D.SetRangeZ = 2500
            
        Case 2
           AxtGraph3D.SetRangeX = 2500
           AxtGraph3D.SetRangeZ = 2500
           
        Case 3
            AxtGraph3D.SetRange3Axis 2500, 2500, 2500
             
    End Select

End Sub

Private Sub cboDimension_Click()
  Dim lIndex As Long
  lIndex = cboDimension.ListIndex
    Select Case lIndex
        Case 0
            AxtGraph3D.SetDimensionXY
        Case 1
           AxtGraph3D.SetDimensionYZ
        Case 2
           AxtGraph3D.SetDimensionXZ
        Case 3
            AxtGraph3D.SetDimensionXYZ
    End Select
End Sub

Private Sub chkBoxEnable_Click()
    If (chkBoxEnable.Value = 1) Then
        AxtGraph3D.SetBoxEnable = True
    Else
        AxtGraph3D.SetBoxEnable = False
    End If
End Sub

Private Sub CMDX_Click(Index As Integer)

End Sub

Private Sub Form_Load()
    cboAxisReset.ListIndex = 3
    cboDimension.ListIndex = 3
    chkBoxEnable.Value = 1
    AxtGraph3D.SetRange3Axis 2500, 2500, 2500
    
End Sub

Private Sub btnclose_Click()
    OK = False
    Unload Me
End Sub
Public Sub UpdateAxis(lAxis As Long)
    m_aAxis(0) = AXIS_N04(lAxis, 0)
    m_aAxis(1) = AXIS_N04(lAxis, 1)
    m_aAxis(2) = AXIS_N04(lAxis, 2)
    m_aAxis(3) = AXIS_N04(lAxis, 3)
End Sub
Private Sub btnHelical_Click()
    Dim dVelocity As Double
    Dim dAccel As Double
    
    dVelocity = 2000
    dAccel = 4000
       
    AxmContiSetAxisMap COORDINATE, 4, m_aAxis(0)
    AxmContiWriteClear COORDINATE
    AxmContiSetAbsRelMode COORDINATE, POS_REL_MODE

    AxmContiBeginNode COORDINATE
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmHelixCenterMove COORDINATE, 500, 500, 0, 0, 100, dVelocity, dAccel, dAccel, DIR_CW
    AxmContiEndNode COORDINATE
End Sub
Private Sub btnHelicalPlay_Click()
    AxmContiStart COORDINATE, 0, 0
End Sub
Private Sub btnSpline_Click()
    Dim dVelocity As Double
    Dim dAccel As Double
    Dim dPosX(0 To 4) As Double
    Dim dPosY(0 To 4) As Double
    Dim dPosZ(0 To 4) As Double
    
    dVelocity = 2000
    dAccel = 4000
   
    AxmContiSetAxisMap COORDINATE, 3, m_aAxis(0)
    AxmContiWriteClear COORDINATE
    AxmContiSetAbsRelMode COORDINATE, POS_ABS_MODE
    
    dPosX(0) = 0:    dPosY(0) = 0
    dPosX(1) = 450:  dPosY(1) = 100
    dPosX(2) = 750:  dPosY(2) = 450
    dPosX(3) = 1080: dPosY(3) = 750
    dPosX(4) = 1300: dPosY(4) = 700

    AxmContiBeginNode COORDINATE
    AxmSplineWrite COORDINATE, 5, dPosX(0), dPosY(0), dVelocity, dAccel, dAccel, 1, 100
    AxmContiEndNode COORDINATE
End Sub
Private Sub btnSplinePlay_Click()
    AxmContiStart lCoodinate, 0, 0
End Sub

Private Sub btnClear_Click()
    AxmStatusSetCmdPos 0, 0#
    AxmStatusSetCmdPos 1, 0#
    AxmStatusSetCmdPos 2, 0#
    AxmStatusSetCmdPos 3, 0#

    AxmStatusSetActPos 0, 0#
    AxmStatusSetActPos 1, 0#
    AxmStatusSetActPos 2, 0#
    AxmStatusSetActPos 3, 0#

    AxmContiWriteClear COORDINATE
    AxtGraph3D.Clear
End Sub


Private Sub Timer1_Timer()
    Dim dCmdX, dCmdY, dCmdZ As Double
    Dim dVelX, dVelY, dVelZ As Double
    
    AxmStatusReadVel m_aAxis(0), dVelX
    AxmStatusReadVel m_aAxis(1), dVelY
    AxmStatusReadVel m_aAxis(2), dVelZ
    If (dVelX >= 0# Or dVelY >= 0# Or dVelZ >= 0#) Then
        AxmStatusGetCmdPos m_aAxis(0), dCmdX
        AxmStatusGetCmdPos m_aAxis(1), dCmdY
        AxmStatusGetCmdPos m_aAxis(2), dCmdZ
        
        edtCmdPosX.Text = Format(dCmdX, "0.000")
        edtCmdPosY.Text = Format(dCmdY, "0.000")
        edtCmdPosZ.Text = Format(dCmdZ, "0.000")
         
     AxtGraph3D.AddPoint dCmdX, dCmdY, dCmdZ
    End If
End Sub
