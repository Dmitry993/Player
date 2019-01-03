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
            int totalDuration = 0;
            int minDuration, maxDuration;
            audioPlayer.Add(GetSongsData(ref totalDuration, out minDuration, out maxDuration));
            Console.WriteLine($"Total {totalDuration}, min {minDuration}, max {maxDuration}");

            //audioPlayer.Lock();
            //audioPlayer.Play();
            audioPlayer.VolumeUp();
            Console.WriteLine(audioPlayer.Volume);

            audioPlayer.VolumeChange(-300);
            audioPlayer.VolumeChange(300);

            audioPlayer.Unlock();
            audioPlayer.Stop();

            var songs = new List<Songs>();
            songs.Add(CreatSong());
            songs.Add(CreatSong("Hey you"));
            songs.Add(CreatSong(270, "Let It Be"));
            audioPlayer.Add(songs);

            audioPlayer.Shuffle();
            audioPlayer.SortByTitle();

            for (int i = 0; i < audioPlayer.Songs.Count; i++)
            {
                Console.WriteLine(audioPlayer.Songs[i].Name);
            }

            audioPlayer.Play(true);

            Console.ReadLine();
        }

        public static Artist AddArtist(string name = "Unknown artist")
        {
            var artist = new Artist();
            artist.Name = name;
            artist.Genre = "Unknown genre";
            return artist;
        }

        public static Album AddAlbum(string name = "Unknown album")
        {
            var album = new Album();
            album.Name = name;
            album.Year = 2018;
            return album;
        }

        public static List<Songs> GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
            minDuration = 0;
            maxDuration = 1000;

            var album = new Album();
            album.Name = "Let It Be";
            album.Year = 1970;

            var artist = new Artist();
            artist.Name = "The Beatles";
            artist.Genre = "Rock";

            var artist2 = new Artist("Metallica");
            Console.WriteLine(artist2.Name);
            Console.WriteLine(artist2.Genre);

            var artist3 = new Artist("Radiohead", "alternative");
            Console.WriteLine(artist3.Name);
            Console.WriteLine(artist3.Genre);

            var songs = new List<Songs>(10);
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                songs.Add(new Songs()
                {
                    Duration = random.Next(1000),
                    Name = $"New song {i}",
                    Album = album,
                    Artist = artist
                });
                if (songs[i].Duration < minDuration) minDuration = songs[i].Duration;
                maxDuration = Math.Max(maxDuration, songs[i].Duration);
            }

            return songs;
        }

        public static Songs CreatSong()
        {

            return new Songs() { Name = "Unknown", Duration = 80 };
        }

        public static Songs CreatSong(string name)
        {
            return new Songs() { Name = name, Duration = 120 };
        }

        public static Songs CreatSong(int duration, string name)
        {

            return new Songs() { Name = name, Duration = duration };
        }

        public static void TraceInfo(AudioPlayer audioPlayer)
        {
            Console.WriteLine(audioPlayer.Songs[0].Artist.Name);
            Console.WriteLine(audioPlayer.Songs[0].Duration);
            Console.WriteLine(audioPlayer.Songs.Count);
            Console.WriteLine(audioPlayer.Volume);

        }
    }
}
