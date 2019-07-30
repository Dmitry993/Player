using System;

namespace Player
{
    public class PlayingItem : IComparable
    {
        public PlayingItem()
        {
            Name = "Default name";
        }

        public PlayingItem(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }

        public string Name { get; set; }
        public int Duration { get; set; }
        private bool? _isLike { get; set; }

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
