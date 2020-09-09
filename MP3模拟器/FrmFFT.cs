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

        Pen p = new Pen(Color.White, 1);

        GdiSystem gdi;

        private void FrmFFT_Load(object sender, EventArgs e)
        {
            gdi = new GdiSystem(this);
            timer1.Enabled = true;
        }

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
            g.Clear(Color.Black);
            Complex[] result = parent.mPlayer.Spectrum;
            for (int i = 0; i < result.Length; i++)
            {
                int yval = (int)(Math.Sqrt(result[i].X * result[i].X + result[i].Y * result[i].Y) * 1024);
                g.DrawLine(p, i, 256, i, 256 - yval);
            }
            gdi.UpdateWindow();
        }
    }
}
