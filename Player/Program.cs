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

            var songs = new List<Song>();
            var song1 = CreatSong();
            song1.Like();
            songs.Add(song1);
            var song2 = CreatSong("Hey you");
            song2.Dislike();
            songs.Add(song2);
            var song3 = CreatSong(270, "Let It Be");
            song3.Dislike();
            songs.Add(song3);

            audioPlayer.Add(songs);

            audioPlayer.Shuffle();
            audioPlayer.SortByTitle();
            audioPlayer.Substring();

            for (int i = 0; i < audioPlayer.Songs.Count; i++)
            {
                Console.WriteLine(audioPlayer.Songs[i].GetName());
            }

            audioPlayer.Play(true);

            Console.ReadLine();
        }

        public static Artist AddArtist(string name = "Unknown artist")
        {
            var artist = new Artist(name);

            return artist;
        }

        public static Album AddAlbum(string name = "Unknown album")
        {
            var album = new Album();
            album.Name = name;
            album.Year = 2018;

            return album;
        }

        public static List<Song> GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
            minDuration = 0;
            maxDuration = 1000;

            var album = new Album();
            album.Name = "Let It Be";
            album.Year = 1970;

            var artist = new Artist("The Beatles");
            Console.WriteLine(artist.Genre);

            var artist2 = new Artist(name: "Metallica");
            Console.WriteLine(artist2.Name);
            Console.WriteLine(artist2.Genre);

            var artist3 = new Artist("Radiohead", Genres.Rock | Genres.Classical);
            Console.WriteLine(artist3.Name);
            Console.WriteLine(artist3.Genre);

            var songs = new List<Song>(10);
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                songs.Add(new Song($"New song {i}", random.Next(1000), artist, album));

                if (songs[i].Duration < minDuration)
                {
                    minDuration = songs[i].Duration;
                }

                maxDuration = Math.Max(maxDuration, songs[i].Duration);
            }

            return songs;
        }

        public static Song CreatSong()
        {
            return new Song("Unknown name", 80);
        }

        public static Song CreatSong(string name)
        {
            return new Song(name, 120);
        }

        public static Song CreatSong(int duration, string name)
        {

            return new Song(name, duration);
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
