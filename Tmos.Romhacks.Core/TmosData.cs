using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomDataObjects;
using Tmos.Romhacks.Core.TmosRomInfo;

namespace Tmos.Romhacks.Core
{
    public static class TmosData//: ITmosData
	{

        public static TmosRomObjectMemoryDataOffset GetWorldScreenDataOffset(byte[] rom, int index)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreenDataOffset);
			byte[] selectedData = GetDataStructure(rom, def, index,0);
            TmosRomObjectMemoryDataOffset worldScreenDataOffset = new TmosRomObjectMemoryDataOffset(selectedData);
            return worldScreenDataOffset;
        }


        #region GetDataObjects
        public static TmosWorldScreen GetWorldScreen(byte[] rom, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
            byte[] selectedData = GetDataStructure(rom, def, index,0);
            TmosWorldScreen worldScreen = new TmosWorldScreen(selectedData);
            return worldScreen;
        }

        public static TmosWorldScreenTile GetWorldScreenTile(byte[] rom, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreenTile);
            byte[] selectedData = GetDataStructure(rom, def, index, 0);
            TmosWorldScreenTile worldScreenTile = new TmosWorldScreenTile(selectedData);
            return worldScreenTile;
        }

        public static TmosTileSection GetTileSection(byte[] rom, int index, int offset)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            byte[] selectedData = GetDataStructure(rom, def, index, offset);
            TmosTileSection tileSection = new TmosTileSection(selectedData);

            return tileSection;
        }

        public static TmosTile GetTile(byte[] rom, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
            byte[] selectedData = GetDataStructure(rom, def, index, 0);
            TmosTile tile = new TmosTile(selectedData);
            return tile;
        }

        public static byte[] GetTileData(byte[] rom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
            byte[] selectedData = GetDataStructure(rom, def.Address, def.ObjectSize * def.Count, 0, 0);
            return selectedData;
        }

        public static TmosMiniTile GetMiniTile(byte[] rom, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.MiniTile);
            byte[] selectedData = GetDataStructure(rom, def, index, 0);
            TmosMiniTile tile = new TmosMiniTile(selectedData);
            return tile;
        }




        //public static TmosTileSection GetTileSectionStartAddress(byte[] rom, int index, int offset)
        //{
        //    var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
        //    byte[] selectedData = GetDataStructure(rom, def, index, offset);
        //    TmosTileSection tileSection = new TmosTileSection(selectedData);

        //    return tileSection;
        //}

        #endregion GetDataObjects

        public static void SaveWorldScreen(byte[] rom, int index, byte[] data)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
			SaveDataStructure(rom, def, index, data);
        }

        public static void SaveWorldScreenTile(byte[] rom, int index, byte[] data)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreenTile);
            SaveDataStructure(rom, def, index, data);
        }

        public static void SaveTileSection(byte[] rom, int index, int offset, byte[] data)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            SaveDataStructure(rom, def, index, offset, data);
        }

        public static void SaveTile(byte[] rom, int index, byte[] data)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
            SaveDataStructure(rom, def, index, data);
        }

        public static void SaveMiniTile(byte[] rom, int index, byte[] data)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.MiniTile);
            SaveDataStructure(rom, def, index, data);
        }

  
        #region DataStructure
        private static byte[] GetDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int index, int additionalOffset)
        {
            byte[] structure = new byte[dataStructure.ObjectSize];
            int objectOffsetFromBeginningOfArray = (dataStructure.ObjectSize * index) + additionalOffset;
            int sourceOffset = dataStructure.Address + objectOffsetFromBeginningOfArray;
            Array.Copy(bytes, sourceOffset, structure, 0, dataStructure.ObjectSize);
            return structure;
        }

        private static byte[] GetDataStructure(byte[] bytes, int address, int length, int index, int additionalOffset)
        {
            byte[] structure = new byte[length];
            int objectOffsetFromBeginningOfArray = (length * index) + additionalOffset;
            int sourceOffset = address + objectOffsetFromBeginningOfArray;
            Array.Copy(bytes, sourceOffset, structure, 0, length);
            return structure;
        }

        private static void SaveDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int index, int offset, byte[] structureByteContent)
        {
            int objectOffsetFromBeginningOfArray = (dataStructure.ObjectSize * index) + offset;
            int addressWithOffset = dataStructure.Address + objectOffsetFromBeginningOfArray;
            SaveDataStructure(bytes, dataStructure, addressWithOffset, structureByteContent);
        }
        private static void SaveDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int absoluteAddress, byte[] structureByteContent)
        {
            Array.Copy(structureByteContent, 0, bytes, absoluteAddress, dataStructure.ObjectSize);
        }
        #endregion DataStructure
    }


}

