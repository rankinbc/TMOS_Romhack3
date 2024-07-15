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

        public static void SaveWorldScreen(byte[] rom, int index, byte[] data)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
			SaveDataStructure(rom, def, index, data);
        }

        public static TmosTileSection GetTileSectionStartAddress(byte[] rom, int index, int offset)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            byte[] selectedData = GetDataStructure(rom, def, index, offset);
            TmosTileSection tileSection = new TmosTileSection(selectedData);

            return tileSection;
        }
        public static TmosTileSection GetTileSection(byte[] rom, int index, int offset)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
			byte[] selectedData = GetDataStructure(rom, def, index ,offset);
            TmosTileSection tileSection = new TmosTileSection(selectedData);
    
            return tileSection;
        }
        public static void SaveTileSection(byte[] rom, int index, int offset, byte[] data)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            SaveDataStructure(rom, def, index, offset, data);
        }

        public static TmosTile GetTile(byte[] rom, int index)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
			byte[] selectedData = GetDataStructure(rom, def, index,0);
            TmosTile tile = new TmosTile(selectedData);
            return tile;
        }

        public static TmosMiniTile GetMiniTile(byte[] rom, int index)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.MiniTile);
			byte[] selectedData = GetDataStructure(rom, def, index,0);
            TmosMiniTile tile = new TmosMiniTile(selectedData);
            return tile;
        }

        public static byte[] GetTileData(byte[] rom)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
			byte[] selectedData = GetDataStructure(rom, def.Address, def.ObjectSize * def.Count, 0, 0);
            return selectedData;
        }


        //     public static TmosWorldScreenTileGrid GetWorldScreenTiles(byte[] rom, TmosWorldScreen ws)
        //     {
        //var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
        //int bottomTileDataStartIndex = 0;
        //         int topTileDataStartIndex = 0;


        //         if (ws.DataPointer >= 0x40 && ws.DataPointer < 0x8f)
        //         {
        //             bottomTileDataStartIndex = 0x2000 / def.ObjectSize;
        //             topTileDataStartIndex = 0;
        //         }

        //         else if (ws.DataPointer >= 0x8f && ws.DataPointer < 0xA0)
        //         {
        //             bottomTileDataStartIndex = 0;
        //             topTileDataStartIndex = 0x2000 / def.ObjectSize;
        //         }
        //         else if (ws.DataPointer >= 0xC0)
        //         {
        //             topTileDataStartIndex = 0x2000 / def.ObjectSize;
        //             bottomTileDataStartIndex = 0x2000 / def.ObjectSize;
        //         }

        //         TmosWorldScreenTileGrid wsTiles = new TmosWorldScreenTileGrid();
        //         wsTiles.TopTiles = GetTileSection(rom, ws.TopTiles, topTileDataStartIndex);
        //         wsTiles.BottomTiles = GetTileSection(rom, ws.BottomTiles, bottomTileDataStartIndex);




        //         return wsTiles;

        //     }


        //private static byte[] GetDataStructureMemory(byte[] bytes, TmosRomObjectInfo dataStructure)
        //{
        //          return GetDataStructure(bytes, dataStructure.Address, dataStructure.ObjectSize * dataStructure.Count,0,0);
        //}



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


        //WORKING
        //private static byte[] GetDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int index, int byteOffset)
        //{
        //    byte[] structure = new byte[dataStructure.ObjectSize];
        //    int sourceOffset = dataStructure.Address + (dataStructure.ObjectSize * index) + byteOffset;
        //    Array.Copy(bytes, sourceOffset, structure, 0, dataStructure.ObjectSize);
        //    return structure;
        //}

        //private static byte[] GetDataStructure(byte[] bytes, int address, int length, int index, int byteOffset)
        //{
        //    byte[] structure = new byte[length];
        //    int sourceOffset = address + (length * index) + byteOffset;
        //    Array.Copy(bytes, sourceOffset, structure, 0, length);
        //    return structure;
        //}

        //private static void SaveDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int index, int offset, byte[] structureByteContent)
        //{
        //    int addressWithOffset = dataStructure.Address + (dataStructure.ObjectSize * index) + offset;
        //    SaveDataStructure(bytes, dataStructure, addressWithOffset, structureByteContent);
        //}
        //private static void SaveDataStructure(byte[] bytes, TmosRomObjectInfo dataStructure, int address, byte[] structureByteContent)
        //{

        //    byte[] structure = new byte[dataStructure.ObjectSize];
        //    int sourceOffset = dataStructure.Address + (dataStructure.ObjectSize * index);

        //    Array.Copy(structureByteContent, 0, bytes, sourceOffset, dataStructure.ObjectSize);
        //}
    }


}

