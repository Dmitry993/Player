using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var audioPlayer = new AudioPlayer(new ColorSkin1(ConsoleColor.DarkMagenta));
            int totalDuration = 0;
            int minDuration, maxDuration;
            //Console.WriteLine($"Total {totalDuration}, min {minDuration}, max {maxDuration}");

            //audioPlayer.Lock();
            //audioPlayer.Play();
            audioPlayer.VolumeUp();
            //Console.WriteLine(audioPlayer.Volume);

            audioPlayer.VolumeChange(-300);
            audioPlayer.VolumeChange(300);

            audioPlayer.Unlock();
            audioPlayer.Stop();

            var songs = new List<Song>();
            var song1 = CreatSong();
            song1.Like();
            songs.Add(song1);
            var song2 = CreatSong(160, "Hey you", AddArtist(Genres.Rock), AddAlbum());
            song2.Dislike();
            songs.Add(song2);
            var song3 = CreatSong(270, "Let It Be", AddArtist(Genres.Rock | Genres.Pop), AddAlbum());
            song3.Dislike();
            songs.Add(song3);
            songs.AddRange(GetSongsData(ref totalDuration, out minDuration, out maxDuration));

            audioPlayer.Add(songs);
            
            audioPlayer.Shuffle();
            audioPlayer.SortByTitle();
            audioPlayer.Substring();
            //audioPlayer.SetSongs(FilterByGenre(songs, Genres.Rock));
            

            for (int i = 0; i < audioPlayer.Songs.Count; i++)
            {
                //Console.WriteLine(audioPlayer.Songs[i].GetName());
            }

            audioPlayer.Play(true);

            Console.ReadLine();
        }

        public static List<Song> FilterByGenre(List<Song> songs, Genres genre)
        {
           var genreSongs = songs.Where(song => song.Artist.Genre.HasFlag(genre)).ToList();
            return genreSongs;
        }

        public static Artist AddArtist(Genres genres, string name = "Unknown artist")
        {
            var artist = new Artist(name, genres);

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

            var artist = new Artist("Unknown", Genres.Default);
            
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
            return new Song("Unknown name", 80, AddArtist(Genres.Classical), AddAlbum());
        }

        public static Song CreatSong(string name)
        {
            return new Song(name, 120);
        }

        public static Song CreatSong(int duration, string name, Artist artist, Album album)
        {

            return new Song(name, duration, artist, album);
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
