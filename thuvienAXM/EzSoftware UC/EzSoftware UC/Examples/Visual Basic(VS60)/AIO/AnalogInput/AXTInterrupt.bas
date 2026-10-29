Attribute VB_Name = "AXTInterrupt"
Option Explicit

Public lpPrevWndProc As Long
Public Const GWL_WNDPROC = (-4)   ' WinProc Á¤º¸

Public Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long
Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Long, ByVal hWnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

Public Sub MessageHook(hWnd As Long)
    lpPrevWndProc = SetWindowLong(hWnd, GWL_WNDPROC, AddressOf WindowProc)
End Sub

Public Sub EndMessageHook(hWnd As Long)
    SetWindowLong hWnd, GWL_WNDPROC, 0
End Sub

Function WindowProc(ByVal hw As Long, ByVal uMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Select Case uMsg
    Case WM_AXL_INTERRUPT
        frmAnalogInput.EventProc CLng(wParam), CLng(lParam)
    Case Else
        WindowProc = CallWindowProc(lpPrevWndProc, hw, uMsg, wParam, lParam)
    End Select
End Function

