using System;

namespace Player
{
    public class Song : IComparable
    {
        public Song()
        {
            Name = "Default name";
        }

        public Song(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }

        public Song(string name, int duration, Artist artist, Album album)
        {
            Name = name;
            Duration = duration;
            Artist = artist;
            Album = album;
        }

        public string Name { get; set; }
        public int Duration { get; set; }
        public bool? Like { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }

        public void Dislike()
        {
            Like = false;
        }

        public string GetName()
        {
            if (Like == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return Name;
            }

            if (Like == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return Name;
            }

            Console.ResetColor();
            return Name;
        }

        public void Likes()
        {
            Like = true;
        }

        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }
    }
}
