namespace MP3模拟器
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlBg = new System.Windows.Forms.PictureBox();
            this.szHand = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.szHand)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlBg
            // 
            this.pnlBg.BackgroundImage = global::MP3模拟器.Properties.Resources.back;
            this.pnlBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlBg.Location = new System.Drawing.Point(14, 17);
            this.pnlBg.Name = "pnlBg";
            this.pnlBg.Size = new System.Drawing.Size(329, 233);
            this.pnlBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pnlBg.TabIndex = 3;
            this.pnlBg.TabStop = false;
            this.pnlBg.Visible = false;
            // 
            // szHand
            // 
            this.szHand.Location = new System.Drawing.Point(156, 59);
            this.szHand.Name = "szHand";
            this.szHand.Size = new System.Drawing.Size(43, 306);
            this.szHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.szHand.TabIndex = 5;
            this.szHand.TabStop = false;
            this.szHand.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(14, 207);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(329, 55);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Music\r\nBy";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Visible = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubtitle.Location = new System.Drawing.Point(14, 127);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(329, 55);
            this.lblSubtitle.TabIndex = 6;
            this.lblSubtitle.Text = "Music\r\nBy";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::MP3模拟器.Properties.Resources.frame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(372, 288);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBg);
            this.Controls.Add(this.szHand);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.szHand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pnlBg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox szHand;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
    }
}