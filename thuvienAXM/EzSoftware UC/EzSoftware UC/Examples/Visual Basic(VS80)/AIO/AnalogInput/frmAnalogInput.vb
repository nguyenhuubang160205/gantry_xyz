Option Strict Off
Option Explicit On 
Imports System.Runtime.InteropServices

Friend Class frmAnalogInput
	Inherits System.Windows.Forms.Form
#Region "Windows Form 디자이너에서 생성한 코드 "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'시작 폼의 경우 처음 만든 인스턴스가 기본 인스턴스가 됩니다.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'이 호출은 Windows Form 디자이너에 필요합니다.
		InitializeComponent()
	End Sub
	'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows Form 디자이너에 필요합니다.
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents CommonDialogFileSave As AxMSComDlg.AxCommonDialog
    Public WithEvents optionNormal As System.Windows.Forms.RadioButton
    Public WithEvents btnExit As System.Windows.Forms.Button
    Public WithEvents timerGatherValue As System.Windows.Forms.Timer
    Public WithEvents listAnalogInput As AxMSComctlLib.AxListView
    Public WithEvents chkStart As System.Windows.Forms.CheckBox
    Public WithEvents listAIChannelInfo As AxMSComctlLib.AxListView
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents textDataLength As System.Windows.Forms.TextBox
    Public WithEvents comboVRange As System.Windows.Forms.ComboBox
    Public WithEvents labelDataLength As System.Windows.Forms.Label
    Public WithEvents labelVRange As System.Windows.Forms.Label
    Public WithEvents frmSetting As System.Windows.Forms.GroupBox
    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    'Windows Form 디자이너를 사용하여 수정할 수 있습니다.
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalogInput))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CommonDialogFileSave = New AxMSComDlg.AxCommonDialog
        Me.optionNormal = New System.Windows.Forms.RadioButton
        Me.btnExit = New System.Windows.Forms.Button
        Me.timerGatherValue = New System.Windows.Forms.Timer(Me.components)
        Me.listAnalogInput = New AxMSComctlLib.AxListView
        Me.frmSetting = New System.Windows.Forms.GroupBox
        Me.listAIChannelInfo = New AxMSComctlLib.AxListView
        Me.btnSave = New System.Windows.Forms.Button
        Me.textDataLength = New System.Windows.Forms.TextBox
        Me.comboVRange = New System.Windows.Forms.ComboBox
        Me.labelDataLength = New System.Windows.Forms.Label
        Me.labelVRange = New System.Windows.Forms.Label
        Me.chkStart = New System.Windows.Forms.CheckBox
        CType(Me.CommonDialogFileSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listAnalogInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmSetting.SuspendLayout()
        CType(Me.listAIChannelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommonDialogFileSave
        '
        Me.CommonDialogFileSave.Enabled = True
        Me.CommonDialogFileSave.Location = New System.Drawing.Point(360, 72)
        Me.CommonDialogFileSave.Name = "CommonDialogFileSave"
        Me.CommonDialogFileSave.OcxState = CType(resources.GetObject("CommonDialogFileSave.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CommonDialogFileSave.Size = New System.Drawing.Size(32, 32)
        Me.CommonDialogFileSave.TabIndex = 0
        '
        'optionNormal
        '
        Me.optionNormal.Location = New System.Drawing.Point(0, 0)
        Me.optionNormal.Name = "optionNormal"
        Me.optionNormal.Size = New System.Drawing.Size(104, 24)
        Me.optionNormal.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(339, 28)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExit.Size = New System.Drawing.Size(95, 58)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'timerGatherValue
        '
        Me.timerGatherValue.Interval = 1
        '
        'listAnalogInput
        '
        Me.listAnalogInput.Location = New System.Drawing.Point(8, 204)
        Me.listAnalogInput.Name = "listAnalogInput"
        Me.listAnalogInput.OcxState = CType(resources.GetObject("listAnalogInput.OcxState"), System.Windows.Forms.AxHost.State)
        Me.listAnalogInput.Size = New System.Drawing.Size(428, 257)
        Me.listAnalogInput.TabIndex = 6
        '
        'frmSetting
        '
        Me.frmSetting.BackColor = System.Drawing.SystemColors.Control
        Me.frmSetting.Controls.Add(Me.listAIChannelInfo)
        Me.frmSetting.Controls.Add(Me.btnSave)
        Me.frmSetting.Controls.Add(Me.textDataLength)
        Me.frmSetting.Controls.Add(Me.comboVRange)
        Me.frmSetting.Controls.Add(Me.labelDataLength)
        Me.frmSetting.Controls.Add(Me.labelVRange)
        Me.frmSetting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmSetting.Location = New System.Drawing.Point(8, 8)
        Me.frmSetting.Name = "frmSetting"
        Me.frmSetting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmSetting.Size = New System.Drawing.Size(325, 190)
        Me.frmSetting.TabIndex = 0
        Me.frmSetting.TabStop = False
        Me.frmSetting.Text = "Setting"
        '
        'listAIChannelInfo
        '
        Me.listAIChannelInfo.Location = New System.Drawing.Point(8, 20)
        Me.listAIChannelInfo.Name = "listAIChannelInfo"
        Me.listAIChannelInfo.OcxState = CType(resources.GetObject("listAIChannelInfo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.listAIChannelInfo.Size = New System.Drawing.Size(305, 105)
        Me.listAIChannelInfo.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(216, 129)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(97, 50)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'textDataLength
        '
        Me.textDataLength.AcceptsReturn = True
        Me.textDataLength.BackColor = System.Drawing.SystemColors.Window
        Me.textDataLength.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textDataLength.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textDataLength.Location = New System.Drawing.Point(103, 158)
        Me.textDataLength.MaxLength = 0
        Me.textDataLength.Name = "textDataLength"
        Me.textDataLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.textDataLength.Size = New System.Drawing.Size(89, 21)
        Me.textDataLength.TabIndex = 5
        Me.textDataLength.Text = "1000"
        '
        'comboVRange
        '
        Me.comboVRange.BackColor = System.Drawing.SystemColors.Window
        Me.comboVRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.comboVRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboVRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.comboVRange.Items.AddRange(New Object() {"-10~10"})
        Me.comboVRange.Location = New System.Drawing.Point(103, 131)
        Me.comboVRange.Name = "comboVRange"
        Me.comboVRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comboVRange.Size = New System.Drawing.Size(89, 20)
        Me.comboVRange.TabIndex = 1
        '
        'labelDataLength
        '
        Me.labelDataLength.BackColor = System.Drawing.SystemColors.Control
        Me.labelDataLength.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelDataLength.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelDataLength.Location = New System.Drawing.Point(8, 162)
        Me.labelDataLength.Name = "labelDataLength"
        Me.labelDataLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelDataLength.Size = New System.Drawing.Size(89, 17)
        Me.labelDataLength.TabIndex = 3
        Me.labelDataLength.Text = "Data Length"
        '
        'labelVRange
        '
        Me.labelVRange.BackColor = System.Drawing.SystemColors.Control
        Me.labelVRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelVRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelVRange.Location = New System.Drawing.Point(8, 134)
        Me.labelVRange.Name = "labelVRange"
        Me.labelVRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelVRange.Size = New System.Drawing.Size(89, 17)
        Me.labelVRange.TabIndex = 2
        Me.labelVRange.Text = "Voltage Range"
        '
        'chkStart
        '
        Me.chkStart.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStart.BackColor = System.Drawing.SystemColors.Control
        Me.chkStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkStart.Location = New System.Drawing.Point(339, 90)
        Me.chkStart.Name = "chkStart"
        Me.chkStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkStart.Size = New System.Drawing.Size(95, 97)
        Me.chkStart.TabIndex = 9
        Me.chkStart.Text = "Start"
        Me.chkStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkStart.UseVisualStyleBackColor = False
        '
        'frmAnalogInput
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(444, 469)
        Me.Controls.Add(Me.CommonDialogFileSave)
        Me.Controls.Add(Me.chkStart)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.listAnalogInput)
        Me.Controls.Add(Me.frmSetting)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmAnalogInput"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "VB-AnalogInput"
        CType(Me.CommonDialogFileSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listAnalogInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmSetting.ResumeLayout(False)
        Me.frmSetting.PerformLayout()
        CType(Me.listAIChannelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "업그레이드 지원 "
    Private Shared m_vb6FormDefInstance As frmAnalogInput
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAnalogInput
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAnalogInput()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As frmAnalogInput)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region
    ' This Example maked for AnalogInput module uses at Visual Basic
    ' The comfile is needed to include  AXL.bas, AXHS.bas, AXA.bas Files
    ' AXL.dll, el_hard.dll, el_univ.dll, EzBasic.dll Files input folder of exist exe file

    Private Const MAXNUM_DATALENGTH As Integer = 10000
    Private Const MINNUM_DATALENGTH As Integer = 10
    Private Const MAXNUM_CHANNEL As Integer = 64

    Private Const MAXNUM_BUFFER As Integer = 32768

    Dim g_lLine As Integer
    Dim g_bChannelEvent(MAXNUM_CHANNEL - 1) As Boolean
    Dim g_lChannelNo(MAXNUM_CHANNEL - 1) As Integer
    Dim g_lCheckedChNum As Integer


    Private Sub Initialize_AI()
        ' Confirm Library initialized.
        If AxlIsOpened = False Then
            ' Library initialize.
            If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then

                MsgBox("Library initialized failed." & vbCrLf & "Please reset program", MsgBoxStyle.Critical)
            End If
        End If

    End Sub


    Public Sub EventProc(ByVal wParam As Integer, ByVal lParam As Integer)
        Dim lChannelNo As Integer
        Dim lFlag As Integer

        lChannelNo = wParam
        lFlag = lParam

        '    ViewSampleVoltageAdc lChannelNo, lFlag
    End Sub


    Private Sub ViewSampleVoltageAdc(ByVal lChannelNo As Integer, ByVal lFlag As Integer)
        Dim lStatus As Integer
        Dim i, j As Object
        Dim k As Integer
        Dim bIsDone As Boolean
        Dim lDataLength As Integer

        Dim arrdVolt(0, 0) As Double

        Dim arrdVolt1(2000) As Double

        Dim lSampleCount(128) As Integer


        lDataLength = CInt(textDataLength.Text)
        lStatus = lFlag
        bIsDone = True


        Select Case lStatus
            Case AIO_EVENT_DATA_UPPER
                AxaiEventSetChannelEnable(lChannelNo, DISABLE)

                g_bChannelEvent(lChannelNo) = True

                For i = 0 To g_lCheckedChNum - 1
                    'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    If listAIChannelInfo.ListItems(i + 1).Checked = True Then
                        'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If g_bChannelEvent(i) = False Then
                            bIsDone = False
                        End If
                    End If
                Next

                If bIsDone = True Then
                    AxaiHwStopMultiChannel(-1)
                    ReDim arrdVolt(128, lDataLength + 1)

                    For j = 0 To g_lCheckedChNum - 1
                        'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        AxaiHwReadDataLength(g_lChannelNo(j), lSampleCount(g_lChannelNo(j)))
                        'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        If lSampleCount(g_lChannelNo(j)) > lDataLength Then
                            'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            lSampleCount(g_lChannelNo(j)) = lDataLength
                        End If
                        'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        AxaiHwReadSampleVoltage(g_lChannelNo(j), lSampleCount(g_lChannelNo(j)), arrdVolt1(0))
                        'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        For k = 0 To lSampleCount(g_lChannelNo(j))
                            'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            arrdVolt(g_lChannelNo(j), k) = arrdVolt1(k)
                        Next
                    Next



                    ' Output list
                    For i = 0 To lDataLength - 1
                        ' Input line
                        'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                        listAnalogInput.ListItems.Add(i + 1, , CStr(g_lLine), , 0)
                        g_lLine = g_lLine + 1

                        ' As Channel length as... Add SubItem
                        For j = 0 To g_lCheckedChNum - 1
                            'UPGRADE_WARNING: j 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                            listAnalogInput.ListItems(i + 1).SubItems(j + 1) = VB6.Format(arrdVolt(g_lChannelNo(j), i), "###.0000000")
                        Next
                    Next


                    chkStart.CheckState = System.Windows.Forms.CheckState.Unchecked
                End If


            Case AIO_EVENT_DATA_LOWER

            Case AIO_EVENT_DATA_FULL

            Case AIO_EVENT_DATA_EMPTY
        End Select


    End Sub

    Private Sub btnExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSave.Click
        Dim InVal As String
        Dim strLine, strChNo As Object
        Dim strValue As String
        Dim i As Object
        Dim j As Short

        'UPGRADE_WARNING: strLine 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        strLine = ""

        g_lCheckedChNum = 0
        For i = 0 To listAIChannelInfo.ListItems.Count - 1
            'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If (listAIChannelInfo.ListItems(i + 1).Checked = True) Then
                g_lCheckedChNum = g_lCheckedChNum + 1
            End If
        Next


        CommonDialogFileSave.ShowSave()

        If CommonDialogFileSave.FileName <> "" Then

            FileOpen(1, CommonDialogFileSave.FileName, OpenMode.Output)
            PrintLine(1, "### AI DATA ###")
            PrintLine(1, "")

            '"Voltage range : -10 ~ 10 V"
            Select Case comboVRange.SelectedIndex
                Case 0
                    PrintLine(1, "Voltage range : -10 ~ 10 V")
            End Select

            'Data length   : 1000
            PrintLine(1, "Data length   : " & textDataLength.Text)

            'write "==========================================="
            For i = 0 To g_lCheckedChNum - 1
                'UPGRADE_WARNING: strLine 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                strLine = strLine + "=========="
            Next
            PrintLine(1, strLine)

            'ChNo
            'UPGRADE_WARNING: strChNo 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            strChNo = "ChNo"
            For i = 0 To g_lCheckedChNum - 1
                'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                'UPGRADE_WARNING: strChNo 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                strChNo = strChNo & vbTab & "Ch.#" & CStr(i)
            Next
            PrintLine(1, strChNo)

            'write "==========================================="
            'UPGRADE_WARNING: strLine 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            strLine = ""
            For i = 0 To g_lCheckedChNum - 1
                'UPGRADE_WARNING: strLine 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                strLine = strLine + "=========="
            Next
            PrintLine(1, strLine)

            ' write Value
            For i = 0 To listAnalogInput.ListItems.Count - 1
                'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                strValue = VB6.Format(i, "0000")
                For j = 0 To g_lCheckedChNum - 1
                    'UPGRADE_WARNING: i 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    strValue = strValue & vbTab & VB6.Format(CDbl(listAnalogInput.ListItems(i + 1).SubItems(j + 1)), "###0.0000")
                Next
                PrintLine(1, strValue)
            Next

            PrintLine(1, VB6.Format(Val(InVal) + 1, "0"))

            FileClose(1)
        End If

    End Sub

    Public Structure Buffer_Structure

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Dim data() As Byte

    End Structure

    'UPGRADE_WARNING: 폼이 초기화될 때 chkStart.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub chkStart_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkStart.CheckStateChanged
        Dim nCntAllChannel As Short
        Dim nCntChannelSelected As Short
        Dim i1 As Short
        Dim i2 As Short
        Dim strColumnHeader As String
        Dim lPVRange As Integer
        Dim lNVRange As Integer
        Dim lModuleNo As Integer

        Dim lDataLength As Integer
        Dim lTimeConst As Integer

        Dim arrCh(MAXNUM_CHANNEL) As Integer
        Dim arrSize(MAXNUM_CHANNEL) As Integer

        ' Buffer
        Dim arrCBuffer(MAXNUM_CHANNEL * MAXNUM_BUFFER) As Double
        Dim arrpCBufferCP(MAXNUM_CHANNEL) As Integer

        nCntAllChannel = listAIChannelInfo.ListItems.Count

        If (chkStart.CheckState = 1) Then
            ' Interrupt init
            'MessageHook((Me.Handle.ToInt32))

            If (nCntAllChannel > 0) Then

                ' Change text of button
                chkStart.Text = "READING"

                'Outputdata list init
                listAnalogInput.ListItems.Clear()
                listAnalogInput.ColumnHeaders.Clear()
                g_lLine = 1

                ' Control state appoint
                listAIChannelInfo.Enabled = False
                textDataLength.Enabled = False
                comboVRange.Enabled = False
                timerGatherValue.Enabled = False

                'Outputdata list put Column Header
                listAnalogInput.ColumnHeaders.Add(1, , "No.", 50, 0)
                i2 = 2
                For i1 = 1 To nCntAllChannel
                    If (listAIChannelInfo.ListItems(i1).Checked = True) Then
                        strColumnHeader = "CH " & listAIChannelInfo.ListItems(i1).SubItems(3)
                        listAnalogInput.ColumnHeaders.Add(i2, , strColumnHeader, 80, 0)
                        i2 = i2 + 1
                    End If
                Next

                lDataLength = CInt(textDataLength.Text)

                ' Selected channel length
                nCntChannelSelected = i2
                If (nCntChannelSelected > 0) Then
                    ' Set Volt range
                    Select Case comboVRange.SelectedIndex
                        Case 0
                            lNVRange = -10
                            lPVRange = 10
                      End Select

                    ' Set Before Ouput condition
                    For i1 = 0 To nCntAllChannel - 1
                        If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
                            AxaiHwSetLimit(arrCh(i1), 0, lDataLength) '// Set High limit
                            AxaiSetRange(arrCh(i1), lNVRange, lPVRange) ' Set Volt range

                            AxaiInfoGetModuleNoOfChannelNo(arrCh(i1), lModuleNo)
                            AxaiSetTriggerMode(lModuleNo, NORMAL_MODE)
                            AxaiHwSetSamplePeriod(lModuleNo, lTimeConst)
                        End If
                    Next

                    For i1 = 0 To MAXNUM_CHANNEL - 1
                        g_bChannelEvent(i1) = False
                    Next

                    timerGatherValue.Enabled = True

                    '  End If

                End If 'end of "If (nCntChannelSelected > 0) Then"

            End If ' end of "If (nCntAllChannel > 0) Then"

        Else

            AxaiHwStopMultiChannel(-1)

            ' Control state appoint
            timerGatherValue.Enabled = False
            listAIChannelInfo.Enabled = True
            textDataLength.Enabled = True
            comboVRange.Enabled = True


            chkStart.Text = "START"
        End If 'end of "If (chkStart.Value = 1) Then"

    End Sub

    Private Sub frmAnalogInput_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim lStatus As Integer

        comboVRange.SelectedIndex = 0
        timerGatherValue.Enabled = False

        g_lLine = 1

        ' Library initialize.
        Initialize_AI()

        ' Controls initialize.
        If AxlIsOpened() Then
            AxaInfoIsAIOModule(lStatus)

            Initialize_ListCtrl()
            comboVRange.SelectedIndex = 0
        End If


    End Sub

    'UPGRADE_WARNING: Form 이벤트 frmAnalogInput.Unload에 새 동작이 있습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmAnalogInput_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        If AxlIsOpened() Then
            AxlClose()
        End If

    End Sub

    Private Sub Initialize_ListCtrl()
        Dim lChannelCnt As Integer
        Dim i1 As Short
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleID As Integer
        Dim lModuleNo As Integer

        ' ListView Column Header Add
        With listAIChannelInfo
            .ColumnHeaders.Add(1, , "BoardNo", 70, 0)
            .ColumnHeaders.Add(2, , "ModuleNo", 70, 0)
            .ColumnHeaders.Add(3, , "ModuleID", 70, 0)
            .ColumnHeaders.Add(4, , "ChannelNo", 80, 0)
        End With

        ' Info collect for input channel
        AxaiInfoGetChannelCount(lChannelCnt)
        For i1 = 1 To lChannelCnt
            AxaiInfoGetModuleNoOfChannelNo(i1, lModuleNo)
            AxaInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)

            ' Channel info listview input data
            'BoardNo
            listAIChannelInfo.ListItems.Add(i1, , CStr(lBoardNo), , 0)
            'ModuleNo
            listAIChannelInfo.ListItems(i1).SubItems(1) = CStr(lModuleNo)
            'ModuleID
            listAIChannelInfo.ListItems(i1).SubItems(2) = CStr(lModuleID)
            'ChannelNo
            listAIChannelInfo.ListItems(i1).SubItems(3) = "#" & CStr(i1 - 1)

        Next

    End Sub

    'UPGRADE_WARNING: Label 이벤트 labelDataLength.Change이(가) 업그레이드되지 않았습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2050"'
    Private Sub labelDataLength_Change()

        ' Outputdata list init
        listAnalogInput.ListItems.Clear()

    End Sub


    'UPGRADE_WARNING: 폼이 초기화될 때 textDataLength.TextChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub textDataLength_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles textDataLength.TextChanged
        Dim lDLength As Integer

        ' if Data Length value over 50000 then set 50000
        If (IsNumeric(textDataLength.Text) = True) Then
            lDLength = CInt(textDataLength.Text)

            If (lDLength > MAXNUM_DATALENGTH) Then
                textDataLength.Text = CStr(MAXNUM_DATALENGTH)
            End If
        End If

    End Sub

    Private Sub textDataLength_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles textDataLength.Leave
        Dim lDLength As Integer

        ' if Data Length value over 50000 then set 50000
        If (IsNumeric(textDataLength.Text) = True) Then
            lDLength = CInt(textDataLength.Text)

            If (lDLength < MINNUM_DATALENGTH) Then
                textDataLength.Text = CStr(MINNUM_DATALENGTH)
            End If
        End If

    End Sub

    Private Sub timerGatherValue_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles timerGatherValue.Tick 'NORMAL_MODE
        Dim dVolt As Double
        Dim i1 As Object
        Dim i2 As Short
        Dim lDataLength As Integer

        Dim lChannelCnt As Integer
        Dim nCntChannelSelected As Short


        ' Input channel all number
        AxaiInfoGetChannelCount(lChannelCnt)

        ' Selected channel all number
        nCntChannelSelected = 0
        For i1 = 0 To lChannelCnt - 1
            'UPGRADE_WARNING: i1 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
                nCntChannelSelected = nCntChannelSelected + 1
            End If
        Next

        If nCntChannelSelected > 0 Then

            ' Init Variable
            lDataLength = CInt(textDataLength.Text)

            ' Line input
            If (g_lLine <= lDataLength) Then
                If (listAnalogInput.ListItems.Count < lDataLength) And (listAnalogInput.ListItems.Count = g_lLine - 1) Then
                    listAnalogInput.ListItems.Add(g_lLine, , CStr(g_lLine), , 0)
                End If
            End If

            ' Info collect for input channel
            i2 = 1
            For i1 = 0 To lChannelCnt - 1
                dVolt = 0
                'UPGRADE_WARNING: i1 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                If (listAIChannelInfo.ListItems(i1 + 1).Checked = True) Then
                    'UPGRADE_WARNING: i1 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    AxaiSwReadVoltage(i1, dVolt)

                    ' Read volt value input listview
                    If (g_lLine <= lDataLength) Then
                        If (listAnalogInput.ListItems.Count <= lDataLength) And (listAnalogInput.ListItems.Count >= g_lLine) Then
                            listAnalogInput.ListItems(g_lLine).SubItems(i2) = VB6.Format(dVolt, "###.0000000")
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
End Class