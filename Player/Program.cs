using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var audioPlayer = new AudioPlayer();
            //audioPlayer.Volume = 20;
            audioPlayer.Song = GetSongsData();

            audioPlayer.Play();
            audioPlayer.VolumeUp();
            Console.WriteLine(audioPlayer.Volume);

            audioPlayer.VolumeChange(-300);
            Console.WriteLine(audioPlayer.Volume);

            audioPlayer.VolumeChange(300);
            Console.WriteLine(audioPlayer.Volume);

            audioPlayer.Stop();

            Console.ReadLine();

        }

        public static Songs[] GetSongsData()
        {
            var album = new Album();
            album.Name = "Let It Be";
            album.Year = 1970;

            var artist = new Artist();
            artist.Name = "The Beatles";
            artist.Genre = "Rock";

            var atr2 = new Artist("Metallica");
            Console.WriteLine(atr2.Name);
            Console.WriteLine(atr2.Genre);

            var atr3 = new Artist("Radiohead", "alternative");
            Console.WriteLine(atr3.Name);
            Console.WriteLine(atr3.Genre);

            var songs = new Songs()
            {
                Duration = 50,
                Name = "Yesterday",
                Album = album,
                Artist = artist
            };

            return new Songs[] { songs };
        }

        public static void TraceInfo(AudioPlayer audioPlayer)
        {
            Console.WriteLine(audioPlayer.Song[0].Artist.Name);
            Console.WriteLine(audioPlayer.Song[0].Duration);
            Console.WriteLine(audioPlayer.Song.Length);
            Console.WriteLine(audioPlayer.Volume);
        }


    }
}
