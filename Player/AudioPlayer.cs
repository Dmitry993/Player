using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class AudioPlayer
    {
        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;

        private int volume;
        private bool locked;
        private bool playing;

        public int Volume
        {
            get { return volume; }
            set
            {
                if (value < MIN_VOLUME)
                {
                    volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    volume = MAX_VOLUME;
                }
                else
                {
                    volume = value;
                }


            }

        }

        public List<Songs> Songs = new List<Songs>();

        public void VolumeUp()
        {
            if (locked) return;
            Volume++;
            Console.WriteLine("Sound up");
        }

        public void VolumeDown()
        {
            if (locked) return;
            Volume--;
            Console.WriteLine("Sound down");
        }

        public void VolumeChange(int step)
        {
            if (locked) return;
            Volume += step;
            Console.WriteLine($"sound changed to {volume}");
        }

        public void Play(bool loop = false)
        {
            if (locked) return;
            int count = 1;
            if (loop) count = Songs.Count;
            playing = true;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                System.Threading.Thread.Sleep(1000);
            }

        }

        public void Stop()
        {
            if (locked) return;
            playing = false;
            Console.WriteLine("Player is stopped");

        }

        public void Lock()
        {
            locked = true;
            Console.WriteLine("Player locked");
        }
        public void Unlock()
        {
            locked = false;
            Console.WriteLine("Player unlocked");
        }

        public void Add(List<Songs> songsArray)
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
            var sort = from sortSongs in Songs
                         orderby sortSongs.Name, sortSongs.Duration, sortSongs.Name.Length
                         select sortSongs;
            foreach (Songs s in sort)
                Songs = new List<Songs> (sort);
        }
    }
}
