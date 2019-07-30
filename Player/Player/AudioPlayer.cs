using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Player.Extensions;

namespace Player
{
    public class AudioPlayer : GenericPlayer, IDisposable
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;

        private int _volume;
        private bool _locked;
        private bool _playing;

        public AudioPlayer()
        {

        }

        public AudioPlayer(ISkin skin)
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

        public List<Song> Songs { get; private set; } = new List<Song>();
        public Song PlayingSong { get; private set; }

        public event Action<List<Song>, Song, bool, int> SongsListChangedEvent;
        public event Action<List<Song>, Song, bool, int> SongStartedEvent;

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
            if (!_locked && Songs.Count > 0)
            {
                _playing = true;
            }

            if (_playing)
            {
                foreach (var song in Songs)
                {
                    PlayingSong = song;
                    SongStartedEvent?.Invoke(Songs, song, _locked, _volume);

                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer())
                    {
                        player.SoundLocation = PlayingSong.Path;
                        player.PlaySync();
                    }
                }
            }
        }

        public bool Stop()
        {
            if (!_locked)
            {
                _playing = false;
            }

            return _playing;
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
                Song[] songs = (Song[])Xml.Deserialize(stream);
                Songs.AddRange(songs);
            }
        }

        public override void FilterByGenre(string genre)
        {
            var genreSongs = Songs.Where(song => song.Artist.Genre.Contains(genre)).ToList();
            Songs = genreSongs;
        }

        public override void Load(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                var files = dirInfo.GetFiles();
                foreach (var file in files)
                {
                    var song = new Song
                    {
                        Path = file.FullName,
                        Name = file.Name
                    };

                    Songs.Add(song);
                }
            }

            SongsListChangedEvent?.Invoke(Songs, null, _locked, _volume);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
