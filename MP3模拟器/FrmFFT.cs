using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3模拟器
{
    public partial class FrmFFT : Form
    {
        Form1 parent;
        public FrmFFT(Form1 frm)
        {
            parent = frm;
            InitializeComponent();
        }
        private const int LWA_ALPHA = 0;
        Pen p = new Pen(Color.FromArgb(192,Color.White), 1);
        private const int WS_EX_TRANSPARENT = 0x20;
        GdiSystem gdi;

        private void FrmFFT_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            Screen curScreen = Screen.FromControl(this);
            this.Width = curScreen.WorkingArea.Width;
            this.Left = curScreen.WorkingArea.Left;
            this.Top = curScreen.WorkingArea.Height - this.Height;

            gdi = new GdiSystem(this);
            p = new Pen(Color.FromArgb(127, Color.White), this.Width / 256 -1);
            offset = (this.Width / 256 - 1) / 2;
            timer1.Enabled = true;
        }

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );
        float offset = 0;

        Brush fpscolor = Brushes.Lime;

        Point p0 = Point.Empty;

        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= GdiSystem.Win32.WS_EX_LAYERED | WS_EX_TRANSPARENT;
                return cp;
            }
            
        }

        int frames = 0;
        int lastsec = 0;
        int fps = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = gdi.Graphics;
            if (null == g) { return; }
            g.Clear(Color.Transparent);
            float[] result = parent.mPlayer.Spectrum;
            for (int i = 0; i < result.Length / 2; i++)
            {
                int yval = (int)(result[i] * 192);
                g.DrawLine(p, i * Width / 256 + offset, 192, i * Width / 256 + offset, 192 - yval);
            }
            frames++;
            int sec = DateTime.Now.Second;
            if (lastsec != sec) {
                lastsec = sec;
                fps = frames;
                frames = 0;
            }

            g.DrawString("FPS: " + fps, Font, fpscolor, p0);


            gdi.UpdateWindow();
        }
    }
}
