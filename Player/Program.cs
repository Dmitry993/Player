using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var audioPlayer = new AudioPlayer(new ColorSkin1(ConsoleColor.DarkMagenta));

            //audioPlayer.Add(Load().ToList());
            //audioPlayer.SetSongs(Clear());
            //audioPlayer.SaveAsPlaylist(Load(), "playlist.xml");
            audioPlayer.LoadPlaylist("playlist.xml");

            audioPlayer.Shuffle();
            audioPlayer.SortByTitle();
            audioPlayer.Substring();
            //audioPlayer.SetSongs(FilterByGenre(Load().ToList(), "Rock"));

            audioPlayer.Play(true);

            Console.ReadLine();
        }

        public static Song[] Load()
        {
            var dirInfo = new DirectoryInfo("D:/Music/");
            var files = dirInfo.GetFiles("*.mp3");

            Song[] songs = new Song[files.Length];

            for (var i = 0; i < songs.Length; i++)
            {
                TagLib.File file = TagLib.File.Create(files[i].FullName);
                var song = new Song(file.Tag.Title,
                    (int)file.Properties.Duration.TotalSeconds,
                    new Artist(file.Tag.AlbumArtists.FirstOrDefault(), file.Tag.Genres.FirstOrDefault()),
                    new Album(file.Tag.Album,(int)file.Tag.Year));

                songs[i] = song;
            }

            return songs;
        }

        public static List<Song> Clear()
        {
           return new List<Song>();
        }
        
        public static List<Song> FilterByGenre(List<Song> songs, string genre)
        {
            var genreSongs = songs.Where(song => song.Artist.Genre.Contains(genre)).ToList();
            return genreSongs;
        }

    }
}
