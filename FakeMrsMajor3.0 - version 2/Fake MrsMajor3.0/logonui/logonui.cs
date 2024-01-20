using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;
using System.Runtime;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Windows.Forms;
using System.Media;

namespace logonui
{
    public partial class logonui : Form
    {
        public logonui()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void logonui_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void logonui_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new Size(base.Size.Width - 100, base.Size.Height);
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer("C:\\0x000F.WAV");
                soundPlayer.PlayLooping();
            }
            catch
            {
            }
        }
    }
}
