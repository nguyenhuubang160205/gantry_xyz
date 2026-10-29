Option Strict Off
Option Explicit On
Friend Class frmStatus
	Inherits System.Windows.Forms.Form
	Dim m_aAxis(2) As Integer
	
	Public Sub UpdateAxis(ByRef lAxis As Integer)
		m_aAxis(0) = AXIS_EVN(lAxis)
		m_aAxis(1) = AXIS_ODD(lAxis)
		
		LampUpdate()
	End Sub
	Public Sub LampUpdate()
		Dim lAxisCount As Integer
		Dim EndStatus As Integer
		
		Call AxmStatusReadStop(m_aAxis(0), EndStatus)
		
		LedXENS31.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H80000000) = &H80000000))
		LedXENS30.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H40000000) = &H40000000))
		LedXENS16.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H10000) = &H10000))
		LedXENS15.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H8000s) = &H8000s))
		LedXENS14.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H4000s) = &H4000s))
		LedXENS13.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H2000s) = &H2000s))
		LedXENS12.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H1000s) = &H1000s))
		LedXENS11.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H800s) = &H800s))
		LedXENS10.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H400s) = &H400s))
		LedXENS09.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H200s) = &H200s))
		LedXENS08.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H100s) = &H100s))
		LedXENS07.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H80s) = &H80s))
		LedXENS06.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H40s) = &H40s))
		LedXENS05.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H20s) = &H20s))
		LedXENS04.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H10s) = &H10s))
		LedXENS03.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H8s) = &H8s))
		LedXENS02.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H4s) = &H4s))
		LedXENS01.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H2s) = &H2s))
		LedXENS00.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H1s) = &H1s))
		
		Call AxmStatusReadStop(m_aAxis(1), EndStatus)
		
		LedYENS31.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H80000000) = &H80000000))
		LedYENS30.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H40000000) = &H40000000))
		LedYENS16.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H10000) = &H10000))
		LedYENS15.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H8000s) = &H8000s))
		LedYENS14.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H4000s) = &H4000s))
		LedYENS13.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H2000s) = &H2000s))
		LedYENS12.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H1000s) = &H1000s))
		LedYENS11.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H800s) = &H800s))
		LedYENS10.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H400s) = &H400s))
		LedYENS09.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H200s) = &H200s))
		LedYENS08.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H100s) = &H100s))
		LedYENS07.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H80s) = &H80s))
		LedYENS06.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H40s) = &H40s))
		LedYENS05.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H20s) = &H20s))
		LedYENS04.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H10s) = &H10s))
		LedYENS03.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H8s) = &H8s))
		LedYENS02.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H4s) = &H4s))
		LedYENS01.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H2s) = &H2s))
		LedYENS00.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((EndStatus And &H1s) = &H1s))
		
		frmAxisX.Text = "X Axis: " & VB6.Format(m_aAxis(0), "00")
		frmAxisY.Text = "Y Axis: " & VB6.Format(m_aAxis(1), "00")
		
		Call AxmInfoGetAxisCount(lAxisCount)
		If (m_aAxis(0) = 0) Then
			btnPrev.Enabled = DISABLE
		Else
			btnPrev.Enabled = ENABLE
		End If
		
		If (m_aAxis(1) = (lAxisCount - 1)) Then
			btnNext.Enabled = DISABLE
		Else
			btnNext.Enabled = ENABLE
		End If
	End Sub
	
	Private Sub btnCur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCur.Click
		LampUpdate()
	End Sub
	
	Private Sub btnNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnNext.Click
		Dim lAxisCount As Integer
		Call AxmInfoGetAxisCount(lAxisCount)
		If (m_aAxis(1) < lAxisCount - 1) Then
			m_aAxis(0) = m_aAxis(0) + 2
			m_aAxis(1) = m_aAxis(1) + 2
			LampUpdate()
		End If
	End Sub
	
	Private Sub btnPrev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPrev.Click
		If (m_aAxis(0) >= 2) Then
			m_aAxis(0) = m_aAxis(0) - 2
			m_aAxis(1) = m_aAxis(1) - 2
			LampUpdate()
		End If
	End Sub
	
	Private Sub tmStatusView_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmStatusView.Tick
		Dim DrvStatus As Integer
		
		Call AxmStatusReadMotion(m_aAxis(0), DrvStatus)
		
		LedXDRS10.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H400s) = &H400s))
		LedXDRS09.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H200s) = &H200s))
		LedXDRS07.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H80s) = &H80s))
		LedXDRS06.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H40s) = &H40s))
		LedXDRS05.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H20s) = &H20s))
		LedXDRS04.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H10s) = &H10s))
		LedXDRS03.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H8s) = &H8s))
		LedXDRS02.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H4s) = &H4s))
		LedXDRS01.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H2s) = &H2s))
		LedXDRS00.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H1s) = &H1s))
		
		Call AxmStatusReadMotion(m_aAxis(1), DrvStatus)
		
		LedYDRS10.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H400s) = &H400s))
		LedYDRS09.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H200s) = &H200s))
		LedYDRS07.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H80s) = &H80s))
		LedYDRS06.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H40s) = &H40s))
		LedYDRS05.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H20s) = &H20s))
		LedYDRS04.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H10s) = &H10s))
		LedYDRS03.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H8s) = &H8s))
		LedYDRS02.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H4s) = &H4s))
		LedYDRS01.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H2s) = &H2s))
		LedYDRS00.BackColor = System.Drawing.ColorTranslator.FromOle(LED_RED((DrvStatus And &H1s) = &H1s))
	End Sub
End Class