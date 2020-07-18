namespace MP3模拟器
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numProgress = new MetroFramework.Controls.MetroTrackBar();
            this.lblSongName = new MetroFramework.Controls.MetroLabel();
            this.lblArtist = new MetroFramework.Controls.MetroLabel();
            this.lblAlbum = new MetroFramework.Controls.MetroLabel();
            this.lblTime = new MetroFramework.Controls.MetroLabel();
            this.lblTimeTotal = new MetroFramework.Controls.MetroLabel();
            this.numVolume = new System.Windows.Forms.TrackBar();
            this.tblFolders = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSongs = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.imgAlbum = new System.Windows.Forms.PictureBox();
            this.btnVolume = new System.Windows.Forms.PictureBox();
            this.btnLoop = new System.Windows.Forms.PictureBox();
            this.btnShuffe = new System.Windows.Forms.PictureBox();
            this.btnNextFolder = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnPrevFolder = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.imgEasterEgg = new System.Windows.Forms.PictureBox();
            this.mPlayer = new MP3模拟器.Player();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShuffe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNextFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEasterEgg)).BeginInit();
            this.SuspendLayout();
            // 
            // numProgress
            // 
            this.numProgress.BackColor = System.Drawing.Color.Transparent;
            this.numProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numProgress.Location = new System.Drawing.Point(23, 197);
            this.numProgress.Name = "numProgress";
            this.numProgress.Size = new System.Drawing.Size(397, 16);
            this.numProgress.TabIndex = 1;
            this.numProgress.Text = "metroTrackBar1";
            this.numProgress.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.numProgress.Value = 0;
            this.numProgress.Scroll += new System.Windows.Forms.ScrollEventHandler(this.numProgress_Scroll);
            // 
            // lblSongName
            // 
            this.lblSongName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSongName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSongName.Location = new System.Drawing.Point(169, 68);
            this.lblSongName.Name = "lblSongName";
            this.lblSongName.Size = new System.Drawing.Size(221, 27);
            this.lblSongName.TabIndex = 2;
            this.lblSongName.Text = "Song Name";
            this.lblSongName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblArtist
            // 
            this.lblArtist.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblArtist.Location = new System.Drawing.Point(169, 98);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(221, 19);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Artist";
            this.lblArtist.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblAlbum
            // 
            this.lblAlbum.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblAlbum.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAlbum.Location = new System.Drawing.Point(169, 123);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(221, 19);
            this.lblAlbum.TabIndex = 2;
            this.lblAlbum.Text = "Album";
            this.lblAlbum.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblTime
            // 
            this.lblTime.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTime.Location = new System.Drawing.Point(23, 179);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 19);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblTimeTotal
            // 
            this.lblTimeTotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTimeTotal.Location = new System.Drawing.Point(344, 179);
            this.lblTimeTotal.Name = "lblTimeTotal";
            this.lblTimeTotal.Size = new System.Drawing.Size(76, 19);
            this.lblTimeTotal.TabIndex = 2;
            this.lblTimeTotal.Text = "00:00:00";
            this.lblTimeTotal.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblTimeTotal.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // numVolume
            // 
            this.numVolume.AutoSize = false;
            this.numVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numVolume.Location = new System.Drawing.Point(396, 68);
            this.numVolume.Maximum = 100;
            this.numVolume.Name = "numVolume";
            this.numVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.numVolume.Size = new System.Drawing.Size(24, 77);
            this.numVolume.TabIndex = 6;
            this.numVolume.TickFrequency = 10;
            this.numVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.numVolume.Value = 100;
            this.numVolume.Visible = false;
            this.numVolume.Scroll += new System.EventHandler(this.numVolume_Scroll);
            // 
            // tblFolders
            // 
            this.tblFolders.AllowUserToAddRows = false;
            this.tblFolders.AllowUserToDeleteRows = false;
            this.tblFolders.AllowUserToResizeColumns = false;
            this.tblFolders.AllowUserToResizeRows = false;
            this.tblFolders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblFolders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblFolders.ColumnHeadersVisible = false;
            this.tblFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblFolders.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblFolders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblFolders.Location = new System.Drawing.Point(23, 219);
            this.tblFolders.MultiSelect = false;
            this.tblFolders.Name = "tblFolders";
            this.tblFolders.ReadOnly = true;
            this.tblFolders.RowHeadersVisible = false;
            this.tblFolders.Size = new System.Drawing.Size(110, 216);
            this.tblFolders.TabIndex = 7;
            this.tblFolders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblFolders_CellContentDoubleClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Column1";
            this.Column1.Image = global::MP3模拟器.Properties.Resources.img_folder;
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 24;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // tblSongs
            // 
            this.tblSongs.AllowUserToAddRows = false;
            this.tblSongs.AllowUserToDeleteRows = false;
            this.tblSongs.AllowUserToResizeColumns = false;
            this.tblSongs.AllowUserToResizeRows = false;
            this.tblSongs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblSongs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSongs.ColumnHeadersVisible = false;
            this.tblSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblSongs.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblSongs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblSongs.Location = new System.Drawing.Point(139, 219);
            this.tblSongs.MultiSelect = false;
            this.tblSongs.Name = "tblSongs";
            this.tblSongs.ReadOnly = true;
            this.tblSongs.RowHeadersVisible = false;
            this.tblSongs.Size = new System.Drawing.Size(281, 216);
            this.tblSongs.TabIndex = 7;
            this.tblSongs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSongs_CellDoubleClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImageColumn1.HeaderText = "Column1";
            this.dataGridViewImageColumn1.Image = global::MP3模拟器.Properties.Resources.img_songlist;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Column1";
            this.dataGridViewImageColumn2.Image = global::MP3模拟器.Properties.Resources.img_folder;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 24;
            // 
            // imgAlbum
            // 
            this.imgAlbum.BackColor = System.Drawing.Color.Black;
            this.imgAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgAlbum.Image = ((System.Drawing.Image)(resources.GetObject("imgAlbum.Image")));
            this.imgAlbum.Location = new System.Drawing.Point(23, 66);
            this.imgAlbum.Name = "imgAlbum";
            this.imgAlbum.Size = new System.Drawing.Size(110, 110);
            this.imgAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgAlbum.TabIndex = 0;
            this.imgAlbum.TabStop = false;
            this.imgAlbum.Click += new System.EventHandler(this.imgAlbum_Click);
            this.imgAlbum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgAlbum_MouseDown);
            // 
            // btnVolume
            // 
            this.btnVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolume.Image = global::MP3模拟器.Properties.Resources.ic_volume;
            this.btnVolume.Location = new System.Drawing.Point(396, 151);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(24, 24);
            this.btnVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnVolume.TabIndex = 5;
            this.btnVolume.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnVolume, "音量");
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoop.Image = global::MP3模拟器.Properties.Resources.ic_loop_all;
            this.btnLoop.Location = new System.Drawing.Point(366, 151);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(24, 24);
            this.btnLoop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLoop.TabIndex = 5;
            this.btnLoop.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnLoop, "单曲/目录/全部循环");
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // btnShuffe
            // 
            this.btnShuffe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShuffe.Image = global::MP3模拟器.Properties.Resources.ic_shuffe_off;
            this.btnShuffe.Location = new System.Drawing.Point(336, 151);
            this.btnShuffe.Name = "btnShuffe";
            this.btnShuffe.Size = new System.Drawing.Size(24, 24);
            this.btnShuffe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShuffe.TabIndex = 5;
            this.btnShuffe.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnShuffe, "顺序/随机播放");
            this.btnShuffe.Click += new System.EventHandler(this.btnShuffe_Click);
            // 
            // btnNextFolder
            // 
            this.btnNextFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextFolder.Image = global::MP3模拟器.Properties.Resources.ic_folder_next;
            this.btnNextFolder.Location = new System.Drawing.Point(288, 151);
            this.btnNextFolder.Name = "btnNextFolder";
            this.btnNextFolder.Size = new System.Drawing.Size(24, 24);
            this.btnNextFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNextFolder.TabIndex = 5;
            this.btnNextFolder.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnNextFolder, "下一个目录");
            this.btnNextFolder.Click += new System.EventHandler(this.btnNextFolder_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = global::MP3模拟器.Properties.Resources.ic_next;
            this.btnNext.Location = new System.Drawing.Point(250, 145);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 32);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext.TabIndex = 5;
            this.btnNext.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnNext, "下一曲");
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::MP3模拟器.Properties.Resources.img_song;
            this.pictureBox9.Location = new System.Drawing.Point(139, 66);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 5;
            this.pictureBox9.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.Image = global::MP3模拟器.Properties.Resources.ic_pause;
            this.btnPlay.Location = new System.Drawing.Point(212, 145);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(32, 32);
            this.btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPlay.TabIndex = 5;
            this.btnPlay.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnPlay, "播放/暂停");
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Image = global::MP3模拟器.Properties.Resources.ic_prev;
            this.btnPrev.Location = new System.Drawing.Point(174, 145);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 32);
            this.btnPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrev.TabIndex = 5;
            this.btnPrev.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnPrev, "上一曲");
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::MP3模拟器.Properties.Resources.img_artist;
            this.pictureBox10.Location = new System.Drawing.Point(144, 95);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(24, 24);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 5;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::MP3模拟器.Properties.Resources.img_album;
            this.pictureBox11.Location = new System.Drawing.Point(144, 118);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(24, 24);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 5;
            this.pictureBox11.TabStop = false;
            // 
            // btnPrevFolder
            // 
            this.btnPrevFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevFolder.Image = global::MP3模拟器.Properties.Resources.ic_folder_prev;
            this.btnPrevFolder.Location = new System.Drawing.Point(144, 151);
            this.btnPrevFolder.Name = "btnPrevFolder";
            this.btnPrevFolder.Size = new System.Drawing.Size(24, 24);
            this.btnPrevFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrevFolder.TabIndex = 5;
            this.btnPrevFolder.TabStop = false;
            this.metroToolTip1.SetToolTip(this.btnPrevFolder, "上一个目录");
            this.btnPrevFolder.Click += new System.EventHandler(this.btnPrevFolder_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // imgEasterEgg
            // 
            this.imgEasterEgg.Cursor = System.Windows.Forms.Cursors.No;
            this.imgEasterEgg.Image = global::MP3模拟器.Properties.Resources.hiresaudio;
            this.imgEasterEgg.Location = new System.Drawing.Point(23, 17);
            this.imgEasterEgg.Name = "imgEasterEgg";
            this.imgEasterEgg.Size = new System.Drawing.Size(42, 42);
            this.imgEasterEgg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEasterEgg.TabIndex = 8;
            this.imgEasterEgg.TabStop = false;
            this.metroToolTip1.SetToolTip(this.imgEasterEgg, "究极脑放已开启");
            this.imgEasterEgg.Visible = false;
            this.imgEasterEgg.Click += new System.EventHandler(this.imgEasterEgg_Click);
            // 
            // mPlayer
            // 
            this.mPlayer.Peak = 0F;
            this.mPlayer.onStop += new System.EventHandler<System.EventArgs>(this.mPlayer_onStop);
            this.mPlayer.onPlayPauseChanged += new System.EventHandler<System.EventArgs>(this.mPlayer_onPlayPauseChanged);
            this.mPlayer.onInfoLoaded += new System.EventHandler<MP3模拟器.SongCallbackEventArgs>(this.mPlayer_onInfoLoaded);
            this.mPlayer.onNewSong += new System.EventHandler<System.EventArgs>(this.mPlayer_onNewSong);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(443, 458);
            this.Controls.Add(this.imgEasterEgg);
            this.Controls.Add(this.tblSongs);
            this.Controls.Add(this.tblFolders);
            this.Controls.Add(this.imgAlbum);
            this.Controls.Add(this.numVolume);
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.btnShuffe);
            this.Controls.Add(this.btnNextFolder);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.btnPrevFolder);
            this.Controls.Add(this.lblTimeTotal);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblSongName);
            this.Controls.Add(this.numProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "MP3 Player";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShuffe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNextFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEasterEgg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTrackBar numProgress;
        private MetroFramework.Controls.MetroLabel lblSongName;
        private MetroFramework.Controls.MetroLabel lblArtist;
        private MetroFramework.Controls.MetroLabel lblAlbum;
        private MetroFramework.Controls.MetroLabel lblTime;
        private MetroFramework.Controls.MetroLabel lblTimeTotal;
        private System.Windows.Forms.PictureBox btnPrevFolder;
        private System.Windows.Forms.PictureBox btnPrev;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox btnNextFolder;
        private System.Windows.Forms.PictureBox btnShuffe;
        private System.Windows.Forms.PictureBox btnLoop;
        private System.Windows.Forms.PictureBox btnVolume;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox imgAlbum;
        private System.Windows.Forms.TrackBar numVolume;
        private System.Windows.Forms.DataGridView tblFolders;
        private System.Windows.Forms.DataGridView tblSongs;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.PictureBox imgEasterEgg;
        public Player mPlayer;
    }
}

