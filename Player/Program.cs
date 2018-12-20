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
            int theShortestSong = 100000;
            int theLongestSong = 100000;
            
            var audioPlayer = new AudioPlayer();
            //audioPlayer.Volume = 20;
            audioPlayer.Song = GetSongsData();

            CreatSong();

            CreatSong("AC/DC");

            var album = new Album();
            album.Name = "The Wall";
            album.Year = 1979;

            var artist = new Artist();
            artist.Name = "Pink Floyd";
            artist.Genre = "Rock";

            CreatSong(278, "Hey you", album, artist);

            //audioPlayer.Lock();
            audioPlayer.Play();
            audioPlayer.VolumeUp();
            Console.WriteLine(audioPlayer.Volume);

            audioPlayer.VolumeChange(-300);
            audioPlayer.VolumeChange(300);

            audioPlayer.Unlock();
            audioPlayer.Stop();
            
            Songs[] songArray = new Songs[5];
            Artist[] artistArray = new Artist[5];
            Album[] albumArray = new Album[5];
            SumDuration(songArray, artistArray, albumArray);

            Console.WriteLine(AddArtist().Name);
            Console.WriteLine(AddArtist("ABBA").Name);

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

        public static int SumDuration(Songs[] song, Artist[] artist, Album[] album)
        {
            return 0;
        }

        public static Songs[] GetSongsData()
        {
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

            var songs = new Songs()
            {
                Duration = 50,
                Name = "Yesterday",
                Album = album,
                Artist = artist
            };

            return new Songs[] { songs };
        }

        public static Songs[] CreatSong()
        {
            var album = new Album();
            var artist = new Artist();
            
            var song1 = new Songs()
            {
                Duration = 50,
                Name = "Default song",
                Album = album,
                Artist = artist
            };
            return new Songs[] { song1 };
        }

        public static Songs[] CreatSong(string name)
        {
            var album = new Album();
            var artist = new Artist();
            
            var song2 = new Songs()
            {
                Duration = 50,
                Name = name,
                Album = album,
                Artist = artist
            };
            return new Songs[] { song2 };
        }

        public static Songs[] CreatSong(int duration, string name, Album album, Artist artist)
        {
            var song3 = new Songs()
            {
                Duration = duration,
                Name = name,
                Album = album,
                Artist = artist
            };
            
            return new Songs[] { song3 };
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
