namespace Player
{
    public class Album
    {
        public byte[] Thumbnail;
        public string Name;
        public int Year;

        public Album()
        {
            Name = "Default artist";
        }

        public Album(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
