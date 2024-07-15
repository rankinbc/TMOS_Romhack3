using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomInfo;

namespace Tmos.Romhacks.Core.TmosRomInfo
{
	


	//Known types that exist in the ROM and the relevant data (don't include items that are best-effort defined in this project because the true structure in the ROM is unknown)
	public enum TmosRomObjectType
	{
		WorldScreenDataOffset,
		WorldScreen,
		WorldScreenTile,
		Tile,
		TileSection,
		MiniTile,
		RandomEncounterGroup,
		RandomEncounterLineup,
	}
	public class TmosRomObjectInfo
	{
		public TmosRomObjectType TmosDataObjectType { get; set; }
		public string Name { get; set; }
		public int Address { get; set; }//Location of the beginning of the array of objects
		public int ObjectSize { get; set; } //Size of each object (in bytes)
		public int Count { get; set; } //Number of object that exist
		public string Description { get; set; }
	}
	public static class TmosRomDataObjectDefinitions
	{
		public static TmosRomObjectInfo RomInfo_WorldScreenDataOffset = new TmosRomObjectInfo

		{
			TmosDataObjectType = TmosRomObjectType.WorldScreenDataOffset,
			Name = "WorldScreenDataOffset",
			Description = "Value the offset of world screen data for a chapter",
			Address = 0x03968b,
			ObjectSize = 2,
			Count = 5
		};
		public static TmosRomObjectInfo RomInfo_WorldScreen = new TmosRomObjectInfo
		{
			TmosDataObjectType = TmosRomObjectType.WorldScreen,
			Name = "WorldScreen",
            Description = "World screens in the game",
            Address = 0x039695, //address of the first item of this type in the array
			ObjectSize = 16, //number of bytes
			Count = 739 //number of objects in the array
		};
        public static TmosRomObjectInfo RomInfo_TileSection = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.TileSection,
            Name = "TileSection",
            Address = 0x03c4c7,
            ObjectSize = 32,
            Count = 940
        };

        //Actual Tile data starts at 0x3d187,
		//Lowest possible tile to load in world screen is 0x3c4c5 (DataPointer:0, TileSection0) - It loads world screen data as tiles
		//Lowest Data Pointer in a WS  is 0x0F
        public static TmosRomObjectInfo RomInfo_WorldScreenTile = new TmosRomObjectInfo
        {
            TmosDataObjectType = TmosRomObjectType.WorldScreenTile,
            Name = "WorldScreenTile",
            Description = "Tiles used by World Screen tile sections",
            Address = 0x03d187, // (DataPointer: 0F, 66)
            ObjectSize = 1,
            Count = 11777 //Guessing data ends at 0x3ff87
        };
        public static TmosRomObjectInfo RomInfo_Tile = new TmosRomObjectInfo //4 bytes about about each Tile 
		{
			TmosDataObjectType = TmosRomObjectType.Tile,
			Name = "Tile",
            Description = "Information about a tile",
            Address = 0x011b0b,
			ObjectSize = 4,
			Count = 5 //UNKNOWN - THIS IS A GUESS TODO:Find actual count
		};
	

		public static TmosRomObjectInfo RomInfo_MiniTile = new TmosRomObjectInfo
		{
			TmosDataObjectType = TmosRomObjectType.MiniTile,
			Name = "MiniTile",
            Description = "The mini tiles that make up a tile (2x2)",
            Address = 0x01160b,
			ObjectSize = 4,
			Count = 20 //UNKNOWN - THIS IS A GUESS TODO:Find actual count
		};
		public static TmosRomObjectInfo RomInfo_RandomEncounterGroup = new TmosRomObjectInfo
		{
			TmosDataObjectType = TmosRomObjectType.RandomEncounterGroup,
			Name = "RandomEncounterGroup",
			Address = 0x00C02A,
			ObjectSize = 32,
			Count = 58 //UNKNOWN - THIS IS A GUESS TODO:Find actual count
		};
		public static TmosRomObjectInfo RomInfo_RandomEncounterLineup = new TmosRomObjectInfo
		{
			TmosDataObjectType = TmosRomObjectType.RandomEncounterLineup,
			Name = "RandomEncounterLineup",
			Address = 0x00C211,
			ObjectSize = 8,
			Count = 6 //UNKNOWN - THIS IS A GUESS TODO:Find actual count
		};

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


		//	public static TmosRomDataObject AllTileData = new TmosRomDataObject(0x03C4C7, 0x3AC1); //The entire section of tile data for the rom

	}
}
