using System;
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
            //audioPlayer.SaveAsPlaylist(Load(), "playlist.xml");
            //audioPlayer.LoadPlaylist("playlist.xml");

            audioPlayer.Load("D:/Music/");
            //audioPlayer.FilterByGenre("Rock");

            audioPlayer.Play(true);

            Console.ReadLine();
        }
        
    }
}
