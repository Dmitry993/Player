using System;

namespace Player
{
    [Flags]
    public enum Genres
    {
        Default = 0,
        Blues = 0b00000001,
        Classical = 0b00000010,
        Dance = 0b00000100,
        Electronic = 0b00001000,
        Jazz = 0b00010000,
        Pop = 0b00100000,
        Rock = 0b01000000,
        Rap = 0b10000000
    };
}
