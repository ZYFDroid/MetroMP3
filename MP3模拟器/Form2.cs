using RetroCPUMeter;
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
    public partial class Form2 : Form
    {

        public Form2(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        Form1 parent;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80000;
                return cp;
            }
        }

        Image bg, fg, hand, handshadow;

        int cd = 1;

        


        int lx, ly;
        bool isMoving = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lx = e.X; ly = e.Y; isMoving = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;

            if (e.Button == MouseButtons.Right) { Close(); }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                this.Left += e.X - lx;
                this.Top += e.Y - ly;
            }
        }

        Point zero = Point.Empty;

        int cd2 = 0;

        float smoothfactor = 0.13f;

        float targetAngel = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            float value = 0;
            float cpuload = parent.meter * 100;
            value = cpuload * 1.1307f - 56.4f;

            cd2--;
            if (cd2 < 0)
            {
                cd2 = 640;
                GC.Collect();
            }

            targetAngel = targetAngel + (value - targetAngel) * smoothfactor;

            float angel = targetAngel;

            Graphics g = gdi.Graphics;
            g.Clear(Color.Transparent);
            g.DrawImage(fg, pnlBg.Location);

            g.DrawString((parent.mPlayer.Title+"\r\n"+parent.mPlayer.Artist).Trim(), lblSubtitle.Font, black, new Rectangle(lblSubtitle.Location, lblSubtitle.Size), sf);
            DrawUtils.drawRotateImg(g, handshadow, angel, label1.Left + 3, label1.Top + 3);
            DrawUtils.drawRotateImg(g, hand, angel, label1.Left, label1.Top);

            g.DrawImage(bg, zero);

            g.DrawString(parent.mPlayer.Album, lblTitle.Font, white, new Rectangle(lblTitle.Location,lblTitle.Size),sf);

            gdi.UpdateWindow();
        }
        GdiSystem gdi;

        Brush white = Brushes.White;
        Brush black = Brushes.Black;
        StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

        private void Form2_Load(object sender, EventArgs e)
        {
            gdi = new GdiSystem(this);
            fg = new Bitmap(Properties.Resources.back, pnlBg.Size);
            bg = new Bitmap(Properties.Resources.frame, this.Size);

            hand = new Bitmap(Properties.Resources.hand, szHand.Size);
            handshadow = new Bitmap(Properties.Resources.shadow, szHand.Size);

            timer1.Interval = 1;
            timer1.Enabled = true;
        }
    }
}
