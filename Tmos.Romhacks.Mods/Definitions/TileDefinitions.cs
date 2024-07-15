using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
		public string Description { get; set; }

		public bool IsWalkable { get; set; } //TODO: Figure out how to actually calculate instead of using hard-coded definitions

		public string ImagePath { get; set; }


		public byte? Value { get; set; }

	}

	public class TileDefinitions
	{
		public enum TileType
		{
			UNKNOWN,
			Grass,
			Tree,
			GrassBushes,
			Water,
			WaterTopEdge,
			Desert,
			DesertTrees,
			Lava,

			//todo: remove unidentified instance for known values
			
		}

		private static readonly TileType[] baseTileTypes = new TileType[9999];

		static TileDefinitions()
		{
			InitializeBaseTileTypes();
		}

		
		
		private static void InitializeBaseTileTypes()
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
			TileType tileType;
			if (baseTileTypes[tileIndex] != null)
			{
				tileType = baseTileTypes[tileIndex];
			}
			else
			{
				tileType = TileType.UNKNOWN;
			}

			Tile tile;
			TileDefinition tileDefinition =  GetTileDefinition(tileType);
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

		public static TileDefinition GetTileDefinition(TileType tileType)
		{
			return GetTileDefinitions().FirstOrDefault(x => x.TileType == tileType);
		}
		public static List<TileDefinition> GetTileDefinitions()
		{
			return new List<TileDefinition>()
			{
				new TileDefinition() { TileType=TileType.Grass, Name = "Grass", IsWalkable=true,                ImagePath="46.png" },
				new TileDefinition() { TileType=TileType.Tree, Name = "Tree" , IsWalkable=false,                ImagePath="47.png"},
				new TileDefinition() { TileType=TileType.GrassBushes, Name = "Grass Bushes" , IsWalkable=false, ImagePath="43.png"},
				new TileDefinition() { TileType=TileType.Water, Name = "Water", IsWalkable=false,               ImagePath="3f.png" },
				//new TileDefinition() { TileType=TileType.WaterTopEdge, Name = "Water Top Edge" , IsWalkable=false, ImagePath="43.png"},
				new TileDefinition() { TileType=TileType.Desert, Name = "Desert", IsWalkable=true,              ImagePath="23.png" },
				new TileDefinition() { TileType=TileType.DesertTrees, Name = "Desert Trees", IsWalkable=false,  ImagePath="6f.png" },
				new TileDefinition() { TileType=TileType.Lava, Name = "Lava", IsWalkable=false,         ImagePath="42.png" },
				new TileDefinition() { TileType=TileType.UNKNOWN, Name = "UNKNOWN", IsWalkable=true }
			};

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
	}
}



