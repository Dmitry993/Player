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

        public Songs[] Song;

        public void VolumeUp()
        {
            Volume++;
            Console.WriteLine("Sound up");
        }

        public void VolumeDown()
        {
            Volume--;
            Console.WriteLine("Sound down");
        }

        public void VolumeChange(int step)
        {
            Volume += step;
            Console.WriteLine($"sound changed to {volume}");
        }

        public void Play()
        {
            if (!locked)
            {
                playing = true;
                Console.WriteLine($"Player is playing: {Song[0].Name}");
            }
        }

        public void Stop()
        {
            if (!locked)
            {
                playing = false;
                Console.WriteLine("Player is stopped");
            }
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

    }
}
