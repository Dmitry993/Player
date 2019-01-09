namespace Player
{
    public class Artist
    {
        public string Name { get; }
        public Genres Genre { get; }

        public Artist()
        {
            Name = "Default artist";
            Genre = Genres.Default;
        }

        public Artist(string name)
        {
            Name = name;
            Genre = Genres.Default;
        }

        public Artist(string name, Genres genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
