using System;

namespace Player
{
    public class Song : PlayingItem, IComparable
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
        private bool? _isLike { get; set; }
        public string Path { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }

        public void Dislike()
        {
            _isLike = false;
        }

        public string GetName()
        {
            if (_isLike == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return Name;
            }

            if (_isLike == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return Name;
            }

            Console.ResetColor();
            return Name;
        }

        public void Likes()
        {
            _isLike = true;
        }

        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }
    }
}
