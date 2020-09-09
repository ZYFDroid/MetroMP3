using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace MP3模拟器
{
    public partial class Form1 : MetroForm
    {
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, int id, int fsModifiers,Keys vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY) 
            {
                if (m.WParam.ToInt32() == 2) {
                    btnPrev_Click(null, null);
                }
                if (m.WParam.ToInt32() == 3)
                {
                    btnPlay_Click(null, null);
                }
                if (m.WParam.ToInt32() == 4)
                {
                    btnNext_Click(null, null);
                }
            }

            base.WndProc(ref m);
        }

        SettingModel mSettingModel = new SettingModel();
        public Form1()
        {
            InitializeComponent();
        }

        public int FolderPos
        {
            get
            {
                return mSettingModel.FolderPos;
            }

            set
            {
                mSettingModel.FolderPos = value;
                SongPos = 0;
            }
        }

        public int SongPos
        {
            get
            {
                return mSettingModel.SongPos;
            }

            set
            {
                mSettingModel.SongPos = value;
            }
        }

        public long PlayPos
        {
            get
            {
                return mSettingModel.PlayPos;
            }

            set
            {
                mSettingModel.PlayPos = value;
            }
        }

        public bool Shuffe
        {
            get
            {
                return mSettingModel.Shuffe;
            }

            set
            {
                mSettingModel.Shuffe = value;
                btnShuffe.Image = value ? Properties.Resources.ic_shuffe : Properties.Resources.ic_shuffe_off;
            }
        }

        public LoopMode LoopMode
        {
            get
            {
                return mSettingModel.LoopMode;
            }

            set
            {
                mSettingModel.LoopMode = value;
                if (value == LoopMode.One) {
                    btnLoop.Image = Properties.Resources.ic_loop_one;
                }
                if (value == LoopMode.Folder)
                {
                    btnLoop.Image = Properties.Resources.img_folder;
                }
                if (value == LoopMode.All)
                {
                    btnLoop.Image = Properties.Resources.ic_loop_all;
                }
            }
        }

        public int Volume
        {
            get
            {
                return mSettingModel.Volume;
            }

            set
            {
                mSettingModel.Volume = value;
                mPlayer.Volume = value;
            }
        }

   

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 2, 0, Keys.MediaPreviousTrack);
            RegisterHotKey(this.Handle, 3, 0, Keys.MediaPlayPause);
            RegisterHotKey(this.Handle, 4, 0, Keys.MediaNextTrack);


            if (File.Exists("config.json")) {
                mSettingModel = JsonConvert.DeserializeObject<SettingModel>(File.ReadAllText("config.json"));
            }

            if (Program.folders.Count > 0)
            {
                Program.folders.ForEach(f => tblFolders.Rows.Add(f, null, Path.GetFileName(f.Path)));
                tblFolders[2, Math.Min(mSettingModel.FolderPos, Program.folders.Count)].Selected = true;
                loadList(Program.folders[Math.Min(mSettingModel.FolderPos, Program.folders.Count-1)]);
                FolderPos = Math.Min(mSettingModel.FolderPos, Program.folders.Count - 1);
                List<SongEntry> subSongs = Program.songsInFolder[Program.folders[Math.Min(mSettingModel.FolderPos, Program.folders.Count)]];
                SongPos = Math.Min(mSettingModel.SongPos, subSongs.Count - 1);
                tblSongs[2, Math.Min(mSettingModel.SongPos, subSongs.Count-1)].Selected = true;

                mPlayer.SongEntry = subSongs[Math.Min(mSettingModel.SongPos, subSongs.Count-1)];
                mPlayer.PlayingPosition = TimeSpan.FromMilliseconds(Math.Min(mPlayer.TotalPosition.TotalMilliseconds, mSettingModel.PlayPos));
                
                
            }

            numVolume.Value = Volume;
            mPlayer.Volume = Volume;
            potVolume.Value = Volume / 100f;
            LoopMode = LoopMode;
            Shuffe = Shuffe;

        }

        public void save() {
            mSettingModel.PlayPos = (long)mPlayer.PlayingPosition.TotalMilliseconds;

            File.WriteAllText("config.json", JsonConvert.SerializeObject(mSettingModel));
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            numVolume.Visible = !numVolume.Visible;
        }

        private void tblFolders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) {
                SongEntry se = tblFolders[0, e.RowIndex].Value as SongEntry;
                loadList(se);
            }
        }

        private void loadList(SongEntry parent) {
            tblSongs.Rows.Clear();
            Program.songsInFolder[parent].ForEach(f => tblSongs.Rows.Add(f, null, Path.GetFileName(f.Path),parent));
        }

        private void tblSongs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                int folderPos = Program.folders.IndexOf(tblSongs[3, e.RowIndex].Value as SongEntry);
                int songPos = e.RowIndex;
                FolderPos = folderPos;
                SongPos = songPos;
                replay();
                mPlayer.IsPlaying = true;
            }
        }

        private void btnShuffe_Click(object sender, EventArgs e)
        {
            Shuffe = !Shuffe;
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (LoopMode == LoopMode.All)
            {
                LoopMode = LoopMode.One;
            }
            else if (LoopMode == LoopMode.One)
            {
                LoopMode = LoopMode.Folder;
            }
            else {
                LoopMode = LoopMode.All;
            }
        }

        private void mPlayer_onInfoLoaded(object sender, SongCallbackEventArgs e)
        {
            if (InvokeRequired) {
                BeginInvoke(new Action(() => { loadInfo(e); }));
                return;
            }
            loadInfo(e);
        }

        void loadInfo(SongCallbackEventArgs e)
        {
            SongEntry current = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
            Console.WriteLine("Load");
            if (e.Entry != current) { return; }
            lblAlbum.Text = mPlayer.Album;
            lblArtist.Text = mPlayer.Artist;
            lblSongName.Text = mPlayer.Title;
            imgAlbum.Image = mPlayer.Cover == null ? Properties.Resources.default_cover : mPlayer.Cover;
            lblTimeTotal.Text = mPlayer.TotalPosition.toTimeStr();

            

        }

        Bitmap imgPlay = Properties.Resources.ic_play;
        Bitmap imgPause = Properties.Resources.ic_pause;

        private void mPlayer_onPlayPauseChanged(object sender, EventArgs e)
        {
            btnPlay.Image = mPlayer.IsPlaying ? imgPause : imgPlay;
        }

        private void mPlayer_onStop(object sender, EventArgs e)
        {
            if (LoopMode != LoopMode.One)
            {
                next();
                mPlayer.IsPlaying = true;
            }
            else {
                replay();
                mPlayer.IsPlaying = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count() <= 0) { return; }
            mPlayer.IsPlaying = !mPlayer.IsPlaying;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (easterCountdown > 0)
            {
                easterCountdown--;
            }
            if (Program.folders.Count <= 0) { return; }
            lblTime.Text = mPlayer.PlayingPosition.toTimeStr();
            numProgress.Maximum = ((int)mPlayer.TotalPosition.TotalMilliseconds)+1;
            numProgress.Value = Math.Min((int)mPlayer.PlayingPosition.TotalMilliseconds,numProgress.Maximum);
        }

        private void numProgress_Scroll(object sender, ScrollEventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            mPlayer.PlayingPosition = TimeSpan.FromMilliseconds(numProgress.Value);
        }

        private void numVolume_Scroll(object sender, EventArgs e)
        {
            Volume = numVolume.Value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
            UnregisterHotKey(this.Handle, 4);
        }

        public void next() {
            if (Program.folders.Count <= 0) { return; }
            if (Shuffe)
            {
                SongPos = rnd.Next() % Program.songsInFolder[Program.folders[FolderPos]].Count;
                mPlayer.SongEntry = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
                return;
            }
            SongPos++;
            if (SongPos >= Program.songsInFolder[Program.folders[FolderPos]].Count) {
                SongPos = 0;
                if (LoopMode != LoopMode.Folder)
                {
                    FolderPos++;
                    if (FolderPos >= Program.folders.Count)
                    {
                        FolderPos = 0;
                    }
                }
            }
            mPlayer.SongEntry = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
        }
        Random rnd = new Random();
        public void prev() {
            if (Program.folders.Count < 0) { return; }
            if (Shuffe) {
                SongPos =rnd.Next() % Program.songsInFolder[Program.folders[FolderPos]].Count;
                mPlayer.SongEntry = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
                return;
            }
            SongPos--;
            if (SongPos <0)
            {
                if (LoopMode != LoopMode.Folder)
                {
                    FolderPos--;
                    if (FolderPos < 0)
                    {
                        FolderPos = Program.folders.Count - 1;
                    }
                }
                SongPos = Program.songsInFolder[Program.folders[FolderPos]].Count - 1;
               
            }
            mPlayer.SongEntry = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
        }

        public void replay() {
            mPlayer.SongEntry = Program.songsInFolder[Program.folders[FolderPos]][SongPos];
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            bool p = mPlayer.IsPlaying;
            prev();
            mPlayer.IsPlaying = p;
            locate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            bool p = mPlayer.IsPlaying;
            next();
            mPlayer.IsPlaying = p;
            locate();
        }

        public void locate() {
            if (Program.folders.Count <= 0) { return; }
            tblFolders[2, FolderPos].Selected = true;
            loadList(Program.folders[FolderPos]);
            tblSongs[2, SongPos].Selected = true;
        }

        private void btnPrevFolder_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            bool p = mPlayer.IsPlaying;
            FolderPos--;
            if (FolderPos <= 0)
            {
                FolderPos = Program.folders.Count - 1;
            }
            SongPos = 0;
            replay();
            locate();
            mPlayer.IsPlaying = p;
        }

        private void btnNextFolder_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            bool p = mPlayer.IsPlaying;
            FolderPos++;
            if (FolderPos >= Program.folders.Count)
            {
                FolderPos = 0;
            }
            SongPos = 0;
            replay();
            locate();
            mPlayer.IsPlaying = p;
        }

        private void imgAlbum_Click(object sender, EventArgs e)
        {
            if (Program.folders.Count <= 0) { return; }
            locate();
        }

        int easterCountdown = 0;

        private void imgAlbum_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                easterCountdown++;
                if (easterCountdown > 4) {
                    imgEasterEgg.Visible = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void mPlayer_onNewSong(object sender, EventArgs e)
        {
            
        }

        private void imgEasterEgg_Click(object sender, EventArgs e)
        {
            new FrmFFT(this).Show();
        }

        private void animTimer_Tick(object sender, EventArgs e)
        {
            ctlBarMeter1.Value = mPlayer.PeakL;
            ctlBarMeter2.Value = mPlayer.PeakR;
        }

        private void potVolume_ValueChanged(object sender, EventArgs e)
        {
            numVolume.Value = (int)(potVolume.Value * 100f);
            mPlayer.Volume = numVolume.Value;
        }

        private void potVolume_Load(object sender, EventArgs e)
        {

        }
    }

}
