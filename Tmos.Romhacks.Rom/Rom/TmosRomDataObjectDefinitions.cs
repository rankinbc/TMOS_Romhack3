using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom.TmosRomInfo;

namespace Tmos.Romhacks.Rom
{
    /// <summary>
    /// Known types that exist in the ROM and the relevant data (don't include items that are best-effort defined in this project because the true structure in the ROM is unknown)
    /// </summary>
    public static class TmosRomDataObjectDefinitions
    {
        public static TmosRomObjectInfo GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType tmosRomObjectType)
        {
            return GetTmosRomObjectInfoDefinitions().FirstOrDefault(o => o.TmosDataObjectType == tmosRomObjectType);
        }
        public static List<TmosRomObjectInfo> GetTmosRomObjectInfoDefinitions() //Arrays
        {
            return new List<TmosRomObjectInfo>
            {
                RomInfo_WorldScreenDataOffset,
                RomInfo_WorldScreen,
                RomInfo_WorldScreenTile,
                RomInfo_Tile,
                RomInfo_TileSection,
                RomInfo_MiniTile,
                RomInfo_RandomEncounterGroup,
                RomInfo_RandomEncounterLineup
            };
        }

        public static TmosRomObjectInfo RomInfo_WorldScreenDataOffset = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.WorldScreenDataOffset,
            Name = "WorldScreenDataOffset",
            Description = "Value the offset of world screen data for a chapter",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.WorldScreenDataStartAddress,
            ObjectSize = 2,
            Count = 5
        };

        public static TmosRomObjectInfo RomInfo_WorldScreen = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.WorldScreen,
            Name = "WorldScreen",
            Description = "World screens in the game",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.WorldScreenStartAddress,
            ObjectSize = 16, // number of bytes
            Count = 739 // number of objects in the array
        };

        public static TmosRomObjectInfo RomInfo_TileSection = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.TileSection,
            Name = "TileSection",
            Description = "Groups of bytes that represent tiles. The WorldScreen TopTiles and BottomTiles bytes point to TileSection objects",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.TileSectionStartAddress,
            ObjectSize = 32,
            //Count = 940
            Count = 471
            //Count = 728
        };

        public static TmosRomObjectInfo RomInfo_WorldScreenTile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.WorldScreenTile,
            Name = "WorldScreenTile",
            Description = "Tile layout data used by WorldScreen TileSections",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.WorldScreenTileDataStartAddress,
            ObjectSize = 1,
            Count = 11912
        };

        public static TmosRomObjectInfo RomInfo_Tile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.Tile,
            Name = "Tile",
            Description = "Information about a tile",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.TileStartAddress,
            ObjectSize = 4,
            Count = 255 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_MiniTile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.MiniTile,
            Name = "MiniTile",
            Description = "The mini tiles that make up a tile (2x2)",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.MiniTileStartAddress,
            ObjectSize = 4,
            Count = 255 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_RandomEncounterGroup = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.RandomEncounterGroup,
            Name = "RandomEncounterGroup",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.RandomEncounterGroupStartAddress,
            ObjectSize = 32,
            Count = 255 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_RandomEncounterLineup = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectArrayType.RandomEncounterLineup,
            Name = "RandomEncounterLineup",
            Address = TmosRomKnownAddresses.TmosRomObjectArrays.RandomEncounterLineupStartAddress,
            ObjectSize = 8,
            Count = 255 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

    }
}
