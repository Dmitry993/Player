﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class AudioPlayer
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;

        private int _volume;
        private bool _locked;
        private bool _playing;

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

        public List<Song> Songs = new List<Song>();

        public void VolumeUp()
        {
            if (_locked)
            {
                return;
            }

            Volume++;
            Console.WriteLine("Sound up");
        }

        public void VolumeDown()
        {
            if (_locked)
            {
                return;
            }

            Volume--;
            Console.WriteLine("Sound down");
        }

        public void VolumeChange(int step)
        {
            if (_locked)
            {
                return;
            }

            Volume += step;
            Console.WriteLine($"sound changed to {_volume}");
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
                Console.WriteLine($"Player is playing: {Songs[i].GetName()}, duration: {Songs[i].Duration}");
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            if (_locked)
            {
                return;
            }

            _playing = false;
            Console.WriteLine("Player is stopped");
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine("Player locked");
        }
        public void Unlock()
        {
            _locked = false;
            Console.WriteLine("Player unlocked");
        }

        public void Add(List<Song> songsArray)
        {
            Songs.AddRange(songsArray);
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = Songs.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = Songs[j];
                Songs[j] = Songs[i];
                Songs[i] = temp;
            }
        }

        public void SortByTitle()
        {
            var sortedSongs = from sortSongs in Songs
                              orderby sortSongs.GetName()
                              select sortSongs;

            Songs = sortedSongs.ToList();
        }
    }
}
