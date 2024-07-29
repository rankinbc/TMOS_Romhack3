using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomInfo
{
    public static class TmosRomKnownAddresses
    {
        public static class TmoRomObjectArrays
        {
            public const int WorldScreenDataStartAddress = 0x03968b;
            public const int WorldScreenStartAddress = 0x039695;
            public const int TileSectionStartAddress = 0x03c4c7;
            public const int WorldScreenTileDataStartAddress = 0x3D187;
            public const int TileStartAddress = 0x011b0b;
            public const int MiniTileStartAddress = 0x01160b;
            public const int RandomEncounterGroupStartAddress = 0x00C02A;
            public const int RandomEncounterLineupStartAddress = 0x00C211;
        }

        public static class ChapterDataOffsets
        {
            public static class Chapter1
            {
                public const int WorldScreenDataStartAddress = 0x039695;
                public const int RandomEncounterGroupDataOffset = 0xC02A;
                public const int RandomEncounterLineupDataOffset = 0xC211;
            }
            public static class Chapter2
            {
                public const int WorldScreenDataStartAddress = 0x039EC5;
                public const int RandomEncounterGroupDataOffset = 0xC058;
                public const int RandomEncounterLineupDataOffset = 0xC241;
            }

            public static class Chapter3
            {
                public const int WorldScreenDataStartAddress = 0x03A755;
                public const int RandomEncounterGroupDataOffset = 0xC089;
                public const int RandomEncounterLineupDataOffset = 0xC271;
            }

             public static class Chapter4
            {
                public const int WorldScreenDataStartAddress = 0x03B0E5;
                public const int RandomEncounterGroupDataOffset = 0xC0BD;
                public const int RandomEncounterLineupDataOffset = 0xC2C1;
            }

            public static class Chapter5
            {
                public const int WorldScreenDataStartAddress = 0x03BB25;
                public const int RandomEncounterGroupDataOffset = 0xC100;
                public const int RandomEncounterLineupDataOffset = 0xC301;
            }
        }
    }
}
