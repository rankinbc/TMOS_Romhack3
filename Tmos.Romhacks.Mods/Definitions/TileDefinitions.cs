using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;
using static Tmos.Romhacks.Mods.TileDefinitions;

namespace Tmos.Romhacks.Mods
{

    public class TileDefinition
    {
        //public (byte dataPointer, byte value) TileKey; //Ideally this object could work without having to include the dataPointer of the parent WorldScreen
        public TileType TileType { get; set; }
        public string Name { get; set; }
        public bool IsWalkable { get; set; } //FUTURE TODO: Figure out how to actually calculate instead of using hard-coded definitions'
    }

    public class TileDefinitions
    {
        private static readonly TileType[] baseTileTypes = new TileType[9999];
        static TileDefinitions()
        {
            InitializeBaseTileTypes();
        }

      
        private static void InitializeBaseTileTypes()//fix and remove
        {

            baseTileTypes[0x46] = TileType.Grass;
            baseTileTypes[0x47] = TileType.Tree;
            baseTileTypes[0x43] = TileType.GrassBushes;
            baseTileTypes[0x3f] = TileType.Water;
            baseTileTypes[0x43] = TileType.WaterTopEdge;
            baseTileTypes[0x23] = TileType.Desert;
            baseTileTypes[0x6f] = TileType.DesertTrees;
            baseTileTypes[0x42] = TileType.Lava;
        }

        public static Tile GetTile(int dataPointer, byte value, bool topTileSet = true)
        {
            int offset = CalculateOffset(dataPointer, topTileSet);
            int offsetCount = offset / 4;
            int adjusteIndexValue = (value + offsetCount);

            int tileIndex = adjusteIndexValue;
            TileType tileType = baseTileTypes[tileIndex];


            if (baseTileTypes.Contains((TileType)tileIndex))
            {
                tileType = baseTileTypes[tileIndex];
            }
            else
            {
                tileType = TileType.UNKNOWN;
            }

            Tile tile;
            TileDefinition tileDefinition = GetTileDefinition(tileType);
            if (tileDefinition == null)
            {
                tile = new Tile(true) { TileType = tileType, Name = $"Tile 0x{value}", Value = value  };
            }
            else
            {
                tile = new Tile(tileDefinition.IsWalkable) { Name = tileDefinition.Name, TileType = tileDefinition.TileType };
                if (value != null)
                {
                    byte val = (byte)value;
                    tile.Value = val;
                }
            }
            return tile;
        }



        private static int CalculateOffset(int dataPointer, bool topTileSet)
        {
            int bottomTileDataOffset = 0;
            int topTileDataOffset = 0;
            if (dataPointer >= 0x40 && dataPointer < 0x8f)
            {
                bottomTileDataOffset = 0x2000;
                topTileDataOffset = 0x0000;
            }

            else if (dataPointer >= 0x8f && dataPointer < 0xA0)
            {
                bottomTileDataOffset = 0x0000;
                topTileDataOffset = 0x2000;
            }
            else if (dataPointer >= 0xC0)
            {
                topTileDataOffset = 0x2000;
                bottomTileDataOffset = 0x2000;
            }

            return topTileSet ? topTileDataOffset : bottomTileDataOffset;
        }

        public static TileDefinition GetTileDefinition(byte tileValue)
        {
            return TileDefinitionsDictionary[(TileType)tileValue];       
        }
        public static TileDefinition GetTileDefinition(TileType tileType)
        {
            return TileDefinitionsDictionary[tileType];
        }


        private static readonly Dictionary<TileType, TileDefinition> TileDefinitionsDictionary = new Dictionary<TileType, TileDefinition>
        {
    { TileType.Grass, new TileDefinition { TileType = TileType.Grass, Name = "Grass", IsWalkable = true } },
    { TileType.Tree, new TileDefinition { TileType = TileType.Tree, Name = "Tree", IsWalkable = false } },
    { TileType.GrassBushes, new TileDefinition { TileType = TileType.GrassBushes, Name = "Grass Bushes", IsWalkable = false } },
    { TileType.Water, new TileDefinition { TileType = TileType.Water, Name = "Water", IsWalkable = false } },
    { TileType.Desert, new TileDefinition { TileType = TileType.Desert, Name = "Desert", IsWalkable = true } },
    { TileType.DesertTrees, new TileDefinition { TileType = TileType.DesertTrees, Name = "Desert Trees", IsWalkable = false } },
    { TileType.Lava, new TileDefinition { TileType = TileType.Lava, Name = "Lava", IsWalkable = false } },
    { TileType.UNKNOWN, new TileDefinition { TileType = TileType.UNKNOWN, Name = "UNKNOWN", IsWalkable = true } }
};













    }

}



