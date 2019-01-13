using System;

namespace Player
{
    public class Song:IComparable
    {
        private string _name;
        private bool? _like;

        public Song()
        {
            _name = "Default name";
        }

        public Song(string name, int duration)
        {
            _name = name;
            Duration = duration;
        }

        public Song(string name, int duration, Artist artist, Album album)
        {
            _name = name;
            Duration = duration;
            Artist = artist;
            Album = album;
        }

        public string SetName { set { _name = value; } }
        public int Duration { get; }
        public Artist Artist { get; }
        public Album Album { get; }

        public void Dislike()
        {
            _like = false;
        }

        public string GetName()
        {
            if (_like == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return _name;

            }

            if (_like == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return _name;
            }

            Console.ResetColor();
            return _name;

        }

        public void Like()
        {
            _like = true;
        }

        public int CompareTo(object obj)
        {
            return this._name?.CompareTo((obj as Song)?._name) ?? 0;
        }
    }
}
