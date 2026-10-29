Option Strict Off
Option Explicit On
Module AXTInterrupt
	
    Public lpPrevWndProc As Integer
    Public Const GWL_WNDPROC As Short = (-4) ' WinProc Á¤º¸

    Delegate Function WindowProcDelegate(ByVal hwnd As Integer, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Declare Function SetWindowLongOld Lib "USER32.DLL" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal attr As Integer, ByVal lVal As Integer) As Integer
    Declare Function SetWindowLong Lib "USER32.DLL" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal attr As Integer, ByVal lVal As WindowProcDelegate) As Integer
    Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Integer, ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public Sub MessageHook(ByRef hWnd As Integer)
        lpPrevWndProc = SetWindowLong(hWnd, GWL_WNDPROC, AddressOf WindowProc)
    End Sub

    Public Sub EndMessageHook(ByRef hWnd As Integer)
        SetWindowLongOld(hWnd, GWL_WNDPROC, lpPrevWndProc)
    End Sub

    Function WindowProc(ByVal hw As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        Select Case uMsg
            Case WM_AXL_INTERRUPT
                frmAnalogInput.DefInstance.EventProc(CInt(wParam), CInt(lParam))
            Case Else
                WindowProc = CallWindowProc(lpPrevWndProc, hw, uMsg, wParam, lParam)
        End Select
    End Function
End Module