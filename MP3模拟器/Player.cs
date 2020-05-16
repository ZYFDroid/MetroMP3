using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace MP3模拟器
{
    [DesignTimeVisible(true)]
    public class Player : Component
    {
        public event EventHandler<EventArgs> onStop;
        public event EventHandler<EventArgs> onPlayPauseChanged;
        public event EventHandler<EventArgs> onInfoLoaded;

        WaveOut output;
        AudioFileReader source;

        SongEntry entry;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false),EditorBrowsable(EditorBrowsableState.Never)]
        public SongEntry SongEntry
        {
            get
            {
                return entry;
            }

            set
            {
                entry = value;
                createPlayer(entry);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public Bitmap Cover
        {
            get
            {
                return cover;
            }
            
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public string Title
        {
            get
            {
                return title;
            }
            
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public string Album
        {
            get
            {
                return album;
            }
            
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public string Artist
        {
            get
            {
                return artist;
            }
            
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public bool IsPlaying
        {
            get
            {
                return output.PlaybackState==PlaybackState.Playing;
            }

            set
            {
                if (value)
                {
                    if (!IsPlaying)
                    {
                        output.Play();
                        onPlayPauseChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
                else {
                    if (IsPlaying)
                    {
                        output.Pause();

                        onPlayPauseChanged?.Invoke(this, EventArgs.Empty);
                    }
                }

            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public TimeSpan PlayingPosition
        {
            get
            {
                if (null == source) { return TimeSpan.Zero; }
                return source.CurrentTime;
            }

            set
            {
                source.CurrentTime = value > TotalPosition ? TotalPosition : value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public TimeSpan TotalPosition
        {
            get
            {
                return totalPosition;
            }
           
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]


        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                if (null != output)
                {
                    output.Volume = value / 100f;
                }
                volume = value;
            }
        }
        

        int volume=100;

        void tryStop() {
            try
            {
                if (null != output)
                {
                    output.Dispose();
                    output = null;
                }
            }
            catch { }
            try
            {
                if (null != source)
                {
                    source.Dispose();
                    source = null;
                }
            }
            catch { }
        }

        private Bitmap cover;
        private String title;
        private String album;
        private String artist;
        

        TimeSpan totalPosition;

        void createPlayer(SongEntry entry) {
            tryStop();
            readSongInfo(entry);
            output = new WaveOut();
            source = new AudioFileReader(entry.Path);
            output.Init(source);
            output.PlaybackStopped += Output_PlaybackStopped;
            totalPosition = source.TotalTime;
            output.Volume = volume / 100f;
            onInfoLoaded?.Invoke(this, EventArgs.Empty);
            onPlayPauseChanged?.Invoke(this,EventArgs.Empty);
        }

        private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (output.PlaybackState == PlaybackState.Stopped)
            {
                onStop?.Invoke(sender, e);
            }
        }

        void readSongInfo(SongEntry entry) {
            Id3.Mp3 mp3 = new Id3.Mp3(entry.Path, Id3.Mp3Permissions.Read);
            IEnumerable<Id3.Id3Tag> tags = mp3.GetAllTags();
            album = "未知专辑";
            artist = "未知艺术家";
            title = Path.GetFileNameWithoutExtension(entry.Path);
            cover?.Dispose();
            cover = null;

            artist = "";

            foreach (var item in tags)
            {
                if (item.Album.IsAssigned && item.Album.Value.Trim('\0', '\n', '\r', ' ') != "") {
                    album = item.Album.Value.Trim();
                }
                if (item.Title.IsAssigned && item.Title.Value.Trim('\0','\n','\r',' ') != "")
                {
                    title = item.Title.Value.Trim();
                }
                if (item.Artists.IsAssigned)
                {
                    foreach (var item2 in item.Artists.Value)
                    {
                        if (item2.Trim('\0', '\n', '\r', ' ') != "")
                        {
                            if (artist.Length > 0) { artist += ", "; }
                            artist += item2.Trim('\0', '\n', '\r', ' ');
                        }
                    }
                }
                if (item.Pictures.Count>0)
                {
                    foreach (var item2 in item.Pictures)
                    {
                        if (item2.IsAssigned) {
                            using (MemoryStream ms = new MemoryStream(item2.PictureData)) {
                                cover = new Bitmap(ms);
                                break;
                            }
                        }
                    }
                    
                }
            }
            mp3.Dispose();
            
        }

        public Player() {
            Disposed += Player_Disposed;
        }

        private void Player_Disposed(object sender, EventArgs e)
        {
            tryStop();
        }
    }
}
