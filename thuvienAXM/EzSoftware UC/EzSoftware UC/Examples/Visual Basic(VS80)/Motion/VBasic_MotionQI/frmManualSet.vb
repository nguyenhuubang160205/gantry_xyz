Option Strict Off
Option Explicit On
Friend Class frmManualSet
	Inherits System.Windows.Forms.Form
	Dim m_lAxisNo As Integer
	Public Sub UpdateAxis(ByRef lAxis As Integer)
		m_lAxisNo = lAxis
		cboAxisSel.SelectedIndex = m_lAxisNo
	End Sub
	Private Sub btnCmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCmd.Click
		Dim strTemp As String
		Dim nCmd As Short
		Dim dwData As Integer
		Dim lTempData As Integer
		
		strTemp = edtCmd.Text
		If (Len(strTemp) = 0) Then
			lTempData = 0
		ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then 
			strTemp = CStr(Val("&H" & Mid(strTemp, 3, 4)))
			lTempData = CInt(VB6.Format(strTemp))
		Else
			lTempData = CInt(strTemp)
		End If
		nCmd = &HFFs And lTempData
		
		strTemp = edtData.Text
		If (Len(strTemp) = 0) Then
			lTempData = 0
		ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then 
			strTemp = CStr(Val("&H" & Mid(strTemp, 3, 10)))
			lTempData = CInt(VB6.Format(strTemp))
		Else
			lTempData = CInt(strTemp)
		End If
		dwData = &HFFFFFFFF And lTempData
		
		If (&H80s And nCmd) Then
			Call AxmSetCommandData32Qi(m_lAxisNo, nCmd, dwData)
		Else
			Call AxmGetCommandData32Qi(m_lAxisNo, nCmd, dwData)
		End If
		
		If (chkHex.CheckState = 1) Then
			edtData.Text = "0x" & VB6.Format(Hex(dwData), "00000000")
		Else
			edtData.Text = VB6.Format(dwData, "00000000")
		End If
	End Sub
	
	Private Sub btnRd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRd.Click
        Dim dwData As Integer
		Dim dwOffset As Integer
        Dim lTempData As Integer
		
		lTempData = cboPort.SelectedIndex
		dwOffset = &H200s Or (CShort(&HFFs And lTempData) * 4)
        Call AxmGetPortDataQi(m_lAxisNo, dwOffset, dwData)
		
		If (chkHex.CheckState = 1) Then
            edtData.Text = "0x" & VB6.Format(Hex(dwData), "00000000")
		Else
            edtData.Text = VB6.Format(dwData, "00000000")
		End If
	End Sub
	Private Sub btnWr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnWr.Click
		Dim strTemp As String
		Dim dwData As Object
		Dim dwOffset As Integer
		Dim lTempData As Integer
		
		lTempData = cboPort.SelectedIndex
		dwOffset = &H200s Or (CShort(&HFFs And lTempData) * 4)
		
		strTemp = edtData.Text
		
		If (Len(strTemp) = 0) Then
			lTempData = 0
		ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then 
			strTemp = CStr(Val("&H" & Mid(strTemp, 3, 10)))
			lTempData = CInt(VB6.Format(strTemp))
		Else
			lTempData = CInt(strTemp)
		End If
		
        dwData = lTempData
        Call AxmSetPortDataQi(m_lAxisNo, dwOffset, dwData)
		
		If (chkHex.CheckState = 1) Then
            edtData.Text = "0x" & VB6.Format(Hex(dwData), "00000000")
		Else
            edtData.Text = VB6.Format(dwData, "00000000")
		End If
	End Sub
    Private Sub cboAxisSel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboAxisSel.SelectedIndexChanged
        m_lAxisNo = cboAxisSel.SelectedIndex
    End Sub
	
	Private Sub frmManualSet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim m_lAxisCount As Integer

		AxmInfoGetAxisCount(m_lAxisCount)
        If (m_lAxisCount < 1) Then Exit Sub
		
        For i = 0 To m_lAxisCount - 1
            cboAxisSel.Items.Add(VB6.Format(i) & " Axis")
        Next i
		
		cboAxisSel.SelectedIndex = 0
		cboPort.SelectedIndex = 0
		chkHex.CheckState = System.Windows.Forms.CheckState.Checked
	End Sub
    Private Sub tmDisplay_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmDisplay.Tick
        Dim nCmd As Short
        Dim dwData As Integer
        Dim lTempData As Integer
        Dim i As Short
        Dim strTemp As String

        For i = 0 To 5
            If (chkOnOff(i).CheckState = 1) Then
                strTemp = edtRdCmd(i).Text
                If (Len(strTemp) = 0) Then
                    lTempData = 0
                ElseIf (Mid(strTemp, 1, 2) = "0x" Or Mid(strTemp, 1, 2) = "0X") Then
                    strTemp = CStr(Val("&H" & Mid(strTemp, 3, 4)))
                    lTempData = CInt(VB6.Format(strTemp))
                Else
                    lTempData = CInt(strTemp)
                End If

                nCmd = &H7FS And lTempData
                Call AxmGetCommandData32Qi(m_lAxisNo, nCmd, dwData)

                If (chkHex.CheckState = 1) Then
                    edtRdData(i).Text = "0x" & VB6.Format(Hex(dwData), "00000000")
                Else
                    edtRdData(i).Text = VB6.Format(dwData, "00000000")
                End If
            End If
        Next i
    End Sub
End Class