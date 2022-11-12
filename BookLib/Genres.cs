using System;

namespace BookLib
{
    [Flags]
    public enum Genres
    {
        Horror =        0x00000001,
        Fantasy =       0x00000010,
        Tragedy =       0x00000100,
        Detective =     0x00001000,
        Comedy =        0x00010000,
        Informative =   0x00100000,
        Science =       0x01000000,
        Adventure =     0x10000000,
    }
}
