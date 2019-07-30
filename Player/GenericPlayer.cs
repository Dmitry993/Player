using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Player.Extensions;

namespace Player
{
    public abstract class GenericPlayer
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;

        private int _volume;
        private bool _locked;
        private bool _playing;

        public GenericPlayer()
        {

        }

        public GenericPlayer(ISkin skin)
        {
            _skin = skin;
        }

        private ISkin _skin { get; }

        private protected List<Song> Songs { get; set; } = new List<Song>();

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value < MinVolume)
                {
                    _volume = MinVolume;
                }
                else if (value > MaxVolume)
                {
                    _volume = MaxVolume;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public void VolumeUp()
        {
            if (_locked == false) 
            {
                Volume++;
            }
        }

        public void VolumeDown()
        {
            if (_locked == false)
            {
                Volume--;
            }
        }

        public void VolumeChange(int step)
        {
            if (_locked == false)
            {
                Volume += step;
            }
        }

        public void Play(bool loop = false)
        {
            if (_locked)
            {
                return;
            }

            int count = 1;
            _playing = true;

            if (loop)
            {
                count = Songs.Count;
            }

            for (int i = 0; i < count; i++)
            {
                _skin.Clear();
                _skin.Render(
                    $"Player is playing: {Songs[i].GetName()}, duration: {Songs[i].Duration}");
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            if (_locked == false)
            {
                _playing = false;
            }
        }

        public void Lock()
        {
            _locked = true;
        }

        public void Unlock()
        {
            _locked = false;
        }

       public void Shuffle()
        {
            Songs.Shuffle();
        }

        public void SortByTitle()
        {
            Songs.Sort();
        }

        public void Substring()
        {
            Songs.Substring();
        }

        public void Clear()
        {
            Songs.Clear();
        }

        public abstract void SaveAsPlaylist(Song[] arr, string fileName);
      
        public abstract void LoadPlaylist(string fileName);
       
        public abstract void FilterByGenre(string genre);

        public abstract void Load(string path);

    }
}
