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
                count = .Count;
            }

            for (int i = 0; i < count; i++)
            {
                _skin.Clear();
                _skin.Render(
                    $"Player is playing: {Items[i].GetName()}, duration: {Items[i].Duration}");
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
            .Sort();
        }

        public void Substring()
        {
            Items.Substring();
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void SaveAsPlaylist(Song[] arr, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var Xml = new XmlSerializer(arr.GetType());
                Xml.Serialize(stream, arr);
            }
        }

        public void LoadPlaylist(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var Xml = new XmlSerializer(typeof(Song[]));
                PlayingItem[] items = (PlayingItem[])Xml.Deserialize(stream);
                Items.AddRange(items);
            }
        }

        public abstract void FilterByGenre(string genre);

        public abstract void Load(string path);

    }
}
