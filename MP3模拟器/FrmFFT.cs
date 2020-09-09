using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        Pen p = new Pen(Color.FromArgb(192,Color.White), 1);

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

        float offset = 0;

        Point p0 = Point.Empty;

        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= GdiSystem.Win32.WS_EX_LAYERED;
                return cp;
            }
            
        }

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
            gdi.UpdateWindow();
        }
    }
}
