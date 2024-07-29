using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomInfo
{
    /// <summary>
    /// Known types that exist in the ROM and the relevant data (don't include items that are best-effort defined in this project because the true structure in the ROM is unknown)
    /// </summary>
    public static class TmosRomDataObjectDefinitions
    {
        public static TmosRomObjectInfo GetTmosRomObjectInfoDefinition(TmosRomObjectType tmosRomObjectType)
        {
            return GetTmosRomObjectInfoDefinitions().FirstOrDefault(o => o.TmosDataObjectType == tmosRomObjectType);
        }
        public static List<TmosRomObjectInfo> GetTmosRomObjectInfoDefinitions()
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
            TmosDataObjectType = TmosRomObjectType.WorldScreenDataOffset,
            Name = "WorldScreenDataOffset",
            Description = "Value the offset of world screen data for a chapter",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.WorldScreenDataStartAddress,
            ObjectSize = 2,
            Count = 5
        };

        public static TmosRomObjectInfo RomInfo_WorldScreen = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.WorldScreen,
            Name = "WorldScreen",
            Description = "World screens in the game",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.WorldScreenStartAddress,
            ObjectSize = 16, // number of bytes
            Count = 739 // number of objects in the array
        };

        public static TmosRomObjectInfo RomInfo_TileSection = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.TileSection,
            Name = "TileSection",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.TileSectionStartAddress,
            ObjectSize = 32,
            Count = 940
        };

        public static TmosRomObjectInfo RomInfo_WorldScreenTile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.WorldScreenTile,
            Name = "WorldScreenTile",
            Description = "Tiles used by World Screen tile sections",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.WorldScreenTileDataStartAddress,
            ObjectSize = 1,
            Count = 11777 // Guessing data ends at 0x3ff87
        };

        public static TmosRomObjectInfo RomInfo_Tile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.Tile,
            Name = "Tile",
            Description = "Information about a tile",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.TileStartAddress,
            ObjectSize = 4,
            Count = 5 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_MiniTile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.MiniTile,
            Name = "MiniTile",
            Description = "The mini tiles that make up a tile (2x2)",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.MiniTileStartAddress,
            ObjectSize = 4,
            Count = 20 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_RandomEncounterGroup = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.RandomEncounterGroup,
            Name = "RandomEncounterGroup",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.RandomEncounterGroupStartAddress,
            ObjectSize = 32,
            Count = 58 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

        public static TmosRomObjectInfo RomInfo_RandomEncounterLineup = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.RandomEncounterLineup,
            Name = "RandomEncounterLineup",
            Address = TmosRomKnownAddresses.TmoRomObjectArrays.RandomEncounterLineupStartAddress,
            ObjectSize = 8,
            Count = 6 // UNKNOWN - THIS IS A GUESS TODO: Find actual count
        };

    }
}
