using System;
using System.Collections.Generic;

namespace Player.Extensions
{
    static class SongsExtensions
    {
        static public List<Song> Shuffle(this List<Song> songs)
        {
            Random random = new Random();

            for (int i = songs.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = songs[j];
                songs[j] = songs[i];
                songs[i] = temp;
            }

            return songs;
        }

        static public List<Song> Substring(this List<Song> songs)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].GetName().Length > 10)
                {
                    songs[i].Name = songs[i].GetName().Substring(0, 10) + "...";
                }
            }

            return songs;
        }
    }
}
