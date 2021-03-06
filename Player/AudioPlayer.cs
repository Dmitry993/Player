﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
        private bool _disposed = false;

        public AudioPlayer()
        {
            SoundPlayer = new SoundPlayer();
        }

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

        public Song PlayingSong { get; private set; }

        private SoundPlayer SoundPlayer { get; set; }

        private protected List<Song> Songs { get; set; } = new List<Song>();
        public event Action<List<Song>, Song, bool, int> SongsListChangedEvent;
        public event Action<List<Song>, Song, bool, int> SongStartedEvent;
        public event Action<List<Song>, Song, bool, int> VolumeChangedEvent;
        public event Action<List<Song>, Song, bool, int> PlayerLockToggled;

        public void VolumeUp()
        {
            if (_locked == false)
            {
                Volume++;
                VolumeChangedEvent?.Invoke(Songs, PlayingSong, false, Volume);
            }
        }

        public void VolumeDown()
        {
            if (_locked == false)
            {
                Volume--;
                VolumeChangedEvent?.Invoke(Songs, PlayingSong, false, Volume);

            }
        }

        public void VolumeChange(int step)
        {
            if (_locked == false)
            {
                Volume += step;
                VolumeChangedEvent?.Invoke(Songs, PlayingSong, false, Volume);
            }
        }

        public void Play()
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

            _playing = false;
        }

        public bool Stop()
        {
            if (!_locked)
            {
                _playing = false;
                SoundPlayer.Stop();
            }

            return _playing;
        }

        public void Lock()
        {
            _locked = true;
            PlayerLockToggled?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public void Unlock()
        {
            _locked = false;
            PlayerLockToggled?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public void Shuffle()
        {
            Songs.Shuffle();
            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public void SortByTitle()
        {
            Songs.Sort();
            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public void Substring()
        {
            Songs.Substring();
            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public void Clear()
        {
            Songs.Clear();
            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

        }

        public override void SaveAsPlaylist(Song[] arr, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var Xml = new XmlSerializer(arr.GetType());
                Xml.Serialize(stream, arr);
            }
        }

        public override void LoadPlaylist(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var Xml = new XmlSerializer(typeof(Song[]));
                Song[] songs = (Song[])Xml.Deserialize(stream);
                Songs.AddRange(songs);

                SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

            }
        }

        public override void FilterByGenre(string genre)
        {
            var genreSongs = Songs.Where(song => song.Artist.Genre.Contains(genre)).ToList();
            Songs = genreSongs;

            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _locked, _volume);

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    PlayingSong = null;
                    SoundPlayer = null;
                }

                _disposed = true;
            }
        }

        ~AudioPlayer() { Dispose(false); }
    }
}
