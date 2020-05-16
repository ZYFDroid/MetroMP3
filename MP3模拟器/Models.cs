using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3模拟器
{
    public class SettingModel
    {
        private int folderPos = 0;
        private int songPos = 0;
        private long playPos = 0;

        private bool shuffe = false;
        private LoopMode loopMode = LoopMode.All;
        private int volume = 100;

        public int FolderPos
        {
            get
            {
                return folderPos;
            }

            set
            {
                folderPos = value;
            }
        }

        public int SongPos
        {
            get
            {
                return songPos;
            }

            set
            {
                songPos = value;
            }
        }

        public long PlayPos
        {
            get
            {
                return playPos;
            }

            set
            {
                playPos = value;
            }
        }

        public bool Shuffe
        {
            get
            {
                return shuffe;
            }

            set
            {
                shuffe = value;
            }
        }

        public LoopMode LoopMode
        {
            get
            {
                return loopMode;
            }

            set
            {
                loopMode = value;
            }
        }

        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }
    }

    public enum LoopMode {
        One=1,
        Folder=2,
        All=3
    }

    public class SongEntry {
        String path;
        EntryType type;
        String parentPath;

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public EntryType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string ParentPath
        {
            get
            {
                return parentPath;
            }

            set
            {
                parentPath = value;
            }
        }
    }

    public enum EntryType {
        Folder=1,
        File=0
    }
}
