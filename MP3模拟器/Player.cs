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
using System.Threading;
using NAudio.Wave.SampleProviders;

namespace MP3模拟器
{
    [DesignTimeVisible(true)]
    public class Player : Component
    {
        public event EventHandler<EventArgs> onStop;
        public event EventHandler<EventArgs> onPlayPauseChanged;
        public event EventHandler<SongCallbackEventArgs> onInfoLoaded;
        public event EventHandler<EventArgs> onNewSong;

        WaveOut output;
        public AudioFileReader source;
        public MeteringSampleProvider meter;

        SongEntry entry;

        private float peak = 0;

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
                try
                {
                    createPlayer(entry);
                }
                catch { throw; }
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

        public float Peak
        {
            get
            {
                return peak;
            }

            set
            {
                peak = value;
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
                if (null != meter)
                {
                    meter = null;
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
            output = new WaveOut();
            source = new AudioFileReader(entry.Path);
            meter = new MeteringSampleProvider(source);
            meter.StreamVolume += Meter_StreamVolume;
            output.Init(meter);
            output.PlaybackStopped += Output_PlaybackStopped;
            totalPosition = source.TotalTime;
            output.Volume = volume / 100f;
            onPlayPauseChanged?.Invoke(this,EventArgs.Empty);
            clearSongInfo(entry);
            onInfoLoaded?.Invoke(null, new SongCallbackEventArgs(entry));
            Task getTask = new Task<SongEntry>(() =>readAsync(entry));
            getTask.Start();
            getTask.ContinueWith(t => {
                onInfoLoaded?.Invoke(null, new SongCallbackEventArgs(entry));
            });
            onNewSong?.Invoke(null, EventArgs.Empty);
        }

        private void Meter_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            peak = e.MaxSampleValues.Average();
        }

        SongEntry readAsync(SongEntry entry) {
            readSongInfo(entry);
            return entry;
        }

        

        private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (output.PlaybackState == PlaybackState.Stopped)
            {
                onStop?.Invoke(sender, e);
            }
        }

        void clearSongInfo(SongEntry entry) {
            album = "";
            artist = "";
            title = Path.GetFileNameWithoutExtension(entry.Path);
            cover?.Dispose();
            cover = null;
        }

        void readSongInfo(SongEntry entry) {
            if(!entry.Path.EndsWith("mp3"))return;
            Id3.Mp3 mp3 = new Id3.Mp3(entry.Path, Id3.Mp3Permissions.Read);
            IEnumerable<Id3.Id3Tag> tags = mp3.GetAllTags();


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

    public class SongCallbackEventArgs : EventArgs
    {
        private SongEntry entry;

        public SongCallbackEventArgs(SongEntry entry)
        {
            this.entry = entry;
        }

        public SongEntry Entry
        {
            get
            {
                return entry;
            }

            set
            {
                entry = value;
            }
        }
    }
}
