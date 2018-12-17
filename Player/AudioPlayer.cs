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
        }

        public void VolumeDown()
        {
            Volume--;
        }

        public void VolumeChange(int step)
        {
            Volume += step;
        }

        public void Play()
        {
            Console.WriteLine($"Player is playing: {Song[0].Name}");
        }

        public void Stop()
        {
            Console.WriteLine($"Player is stopped");
        }

    }
}
