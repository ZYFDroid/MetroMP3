using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MP3模拟器
{
    

    static class Program
    {
        public static List<SongEntry> scanedResult = new List<SongEntry>();
        public static List<SongEntry> folders = new List<SongEntry>();
        public static Dictionary<SongEntry, List<SongEntry>> songsInFolder = new Dictionary<SongEntry, List<SongEntry>>();
        
        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Environment.CurrentDirectory =Path.GetDirectoryName(Application.ExecutablePath);
            doScan(Path.GetFullPath("."));
            foreach (SongEntry songEnt in scanedResult)
            {
                List<String> mp3s = Directory.EnumerateFiles(songEnt.Path, "*.mp3").ToList();
                if (mp3s.Count() > 0)
                {
                    folders.Add(songEnt);
                    songsInFolder.Add(songEnt, mp3s.OrderBy(m => m).Select(m => new SongEntry() { ParentPath = songEnt.Path, Path = m, Type = EntryType.File }).ToList());
                }
            }
            Application.Run(new Form1());
        }

        public static void doScan(String root) {
            foreach (String path in Directory.EnumerateDirectories(root).OrderBy(d => d)) {
                scanedResult.Add(new SongEntry() { Path = path, ParentPath = root, Type = EntryType.Folder });
                doScan(path);
            }
        }

        public static String toTimeStr(this TimeSpan ts) {
            return ts.ToString("hh\\:mm\\:ss");
        }
    }
}
