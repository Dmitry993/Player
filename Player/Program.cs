using System;
using System.Collections.Generic;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var audioPlayer = new AudioPlayer())
            {
                audioPlayer.Load(@"D:/Music/");

                audioPlayer.SongStartedEvent += DrawInterface;
                audioPlayer.VolumeChangedEvent += DrawInterface;
                audioPlayer.PlayerLockToggled += DrawInterface;
                audioPlayer.SongsListChangedEvent += DrawInterface;

                audioPlayer.Shuffle();
                audioPlayer.VolumeUp();
                audioPlayer.Play();

               Console.ReadLine();
            }
        }

        private static void DrawInterface(List<Song> songs, Song playingSong, bool locked, int volume)
        {
            Console.Clear();

            foreach (var song in songs)
            {
                if (playingSong == song)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(song.Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(song.Name);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Volume is: {volume}. Locked: {locked}");
            Console.ResetColor();


        }
    }
}
