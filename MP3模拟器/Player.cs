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
using NAudio.Dsp;
using System.Diagnostics;

namespace MP3模拟器
{
    [DesignTimeVisible(true)]
    public class Player : Component
    {
        public event EventHandler<EventArgs> onStop;
        public event EventHandler<EventArgs> onPlayPauseChanged;
        public event EventHandler<SongCallbackEventArgs> onInfoLoaded;
        public event EventHandler<EventArgs> onNewSong;

        IWavePlayer output;
        public AudioFileReader source;
        public BetterMeteringSampleProvider meter;

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

        public float PeakL
        {
            get
            {
                if (meter != null) {
                    return meter.Volumes[0];
                }
                return 0;
            }

        }

        public float PeakR
        {
            get
            {
                if (meter != null)
                {
                    if (meter.Volumes.Length == 1) {
                        return meter.Volumes[0];
                    }
                    return meter.Volumes[1];
                }
                return 0;
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

        public SampleAggregator SpectrumSampler;

        public float[] Spectrum { get { return SpectrumSampler.Spectrum; } }

        void createPlayer(SongEntry entry) {
            tryStop();
            source = new AudioFileReader(entry.Path);
            SpectrumSampler = new SampleAggregator(source, 512);
            meter = new BetterMeteringSampleProvider(SpectrumSampler);
            meter.StreamVolume += Meter_StreamVolume;
            SpectrumSampler.FftCalculated += ((sender, earg) => { });
            SpectrumSampler.PerformFFT = true;

            output = new WaveOut() { DesiredLatency = 1,NumberOfBuffers = meter.WaveFormat.SampleRate / 256 };

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

    public class BetterMeteringSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider source;

        private readonly float[] maxSamples;
        private int sampleCount;
        private readonly int channels;
        private readonly StreamVolumeEventArgs args;

        private float downspeed = 0.01f;

        /// <summary>
        /// Number of Samples per notification
        /// </summary>
        public int SamplesPerNotification { get; set; }

        /// <summary>
        /// Raised periodically to inform the user of the max volume
        /// </summary>
        public event EventHandler<StreamVolumeEventArgs> StreamVolume;

        public float[] Volumes { get { return maxSamples; } }

        /// <summary>
        /// Initialises a new instance of MeteringSampleProvider that raises 10 stream volume
        /// events per second
        /// </summary>
        /// <param name="source">Source sample provider</param>
        public BetterMeteringSampleProvider(ISampleProvider source)
        {
            this.source = source;
            channels = source.WaveFormat.Channels;
            maxSamples = new float[channels];
            SamplesPerNotification = 100;
            args = new StreamVolumeEventArgs() { MaxSampleValues = maxSamples }; // create objects up front giving GC little to do
            downspeed = 1f / source.WaveFormat.SampleRate ;
        }

        /// <summary>
        /// Initialises a new instance of MeteringSampleProvider 
        /// </summary>
        /// <param name="source">source sampler provider</param>
        /// <param name="samplesPerNotification">Number of samples between notifications</param>
        

        /// <summary>
        /// The WaveFormat of this sample provider
        /// </summary>
        public WaveFormat WaveFormat => source.WaveFormat;

        /// <summary>
        /// Reads samples from this Sample Provider
        /// </summary>
        /// <param name="buffer">Sample buffer</param>
        /// <param name="offset">Offset into sample buffer</param>
        /// <param name="count">Number of samples required</param>
        /// <returns>Number of samples read</returns>
        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);
            // only bother if there is an event listener
            if (StreamVolume != null)
            {
                for (int index = 0; index < samplesRead; index += channels)
                {
                    for (int channel = 0; channel < channels; channel++)
                    {
                        float sampleValue = Math.Abs(buffer[offset + index + channel]);
                        maxSamples[channel] = Math.Max(maxSamples[channel]-downspeed, sampleValue);
                    }
                    sampleCount++;
                    if (sampleCount >= SamplesPerNotification)
                    {
                        StreamVolume(this, args);
                        sampleCount = 0;
                    }
                }
            }
            return samplesRead;
        }
    }

    /// <summary>
    /// Event args for aggregated stream volume
    /// </summary>
    public class StreamVolumeEventArgs : EventArgs
    {
        /// <summary>
        /// Max sample values array (one for each channel)
        /// </summary>
        public float[] MaxSampleValues { get; set; }
    }



    public class SampleAggregator : ISampleProvider
    {
        // volume
        public event EventHandler<MaxSampleEventArgs> MaximumCalculated;
        private float maxValue;
        private float minValue;
        public int NotificationCount { get; set; }
        int count;

        // FFT
        public event EventHandler<FftEventArgs> FftCalculated;
        public bool PerformFFT { get; set; }
        private readonly Complex[] fftBuffer;

        private readonly float[] _spectrum;

        private readonly FftEventArgs fftArgs;
        private int fftPos;
        private readonly int fftLength;
        private readonly int m;
        private readonly ISampleProvider source;

        private readonly int channels;

        public SampleAggregator(ISampleProvider source, int fftLength = 1024)
        {
            channels = source.WaveFormat.Channels;
            if (!IsPowerOfTwo(fftLength))
            {
                throw new ArgumentException("FFT Length must be a power of two");
            }
            m = (int)Math.Log(fftLength, 2.0);
            this.fftLength = fftLength;
            fftBuffer = new Complex[fftLength];
            _spectrum = new float[fftLength];
            fftArgs = new FftEventArgs(fftBuffer);
            downspeed = (1f / source.WaveFormat.SampleRate) * (1f / 0.4f) * fftLength;
            this.source = source;
        }

        static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }


        public void Reset()
        {
            count = 0;
            maxValue = minValue = 0;
        }

        float downspeed=0.01f;

        private void Add(float value)
        {
            if (PerformFFT && FftCalculated != null)
            {
                fftBuffer[fftPos].X = (float)(value * FastFourierTransform.HammingWindow(fftPos, fftLength));
                fftBuffer[fftPos].Y = 0;
                fftPos++;
                if (fftPos >= fftBuffer.Length)
                {
                    fftPos = 0;
                    // 1024 = 2^10
                    FastFourierTransform.FFT(true, m, fftBuffer);
                    for (int i = 0; i < fftBuffer.Length; i++)
                    {
                        Complex c = fftBuffer[i];
                        double intensityDB = 10 * Math.Log10(Math.Sqrt(c.X * c.X + c.Y * c.Y));
                        double minDB = -50;
                        if (intensityDB < minDB) intensityDB = minDB;
                        double percent =- (intensityDB - minDB) / minDB;
                        _spectrum[i] = (float)Math.Max(_spectrum[i] - downspeed, percent);
                    }
                    FftCalculated(this, fftArgs);
                }
            }

            maxValue = Math.Max(maxValue, value);
            minValue = Math.Min(minValue, value);
            count++;
            if (count >= NotificationCount && NotificationCount > 0)
            {
                MaximumCalculated?.Invoke(this, new MaxSampleEventArgs(minValue, maxValue));
                Reset();
            }
        }

        public WaveFormat WaveFormat => source.WaveFormat;

        public float[] Spectrum { get => _spectrum;  }

        public int Read(float[] buffer, int offset, int count)
        {
            var samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n += channels)
            {
                Add(buffer[n + offset]);
            }
            return samplesRead;
        }
    }

    public class MaxSampleEventArgs : EventArgs
    {
        [DebuggerStepThrough]
        public MaxSampleEventArgs(float minValue, float maxValue)
        {
            MaxSample = maxValue;
            MinSample = minValue;
        }
        public float MaxSample { get; private set; }
        public float MinSample { get; private set; }
    }

    public class FftEventArgs : EventArgs
    {
        [DebuggerStepThrough]
        public FftEventArgs(Complex[] result)
        {
            Result = result;
        }
        public Complex[] Result { get; private set; }
    }
}
