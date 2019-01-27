namespace Player
{
    public class Artist
    {
        public string Name;
        public string Genre;

        public Artist()
        {
            Name = "Default artist";
            Genre = "Default genre";
        }

        public Artist(string name)
        {
            Name = name;
            Genre = "Default genre";
        }

        public Artist(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
