using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomDataObjects;
using Tmos.Romhacks.Core.TmosRomInfo;

namespace Tmos.Romhacks.Core
{
    public static class TmosData
    {
        public static T GetDataObject<T>(byte[] rom, int index, TmosRomObjectType objectType, int offset = 0)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(objectType);
            byte[] selectedData = GetDataStructure(rom, def, index, offset);

            // Use reflection to find a constructor that matches the byte[] parameter
            var constructor = typeof(T).GetConstructor(new[] { typeof(byte[]) });
            if (constructor != null)
            {
                return (T)constructor.Invoke(new object[] { selectedData });
            }

            throw new InvalidOperationException($"Type {typeof(T).Name} does not have a suitable constructor.");
        }


        public static void SaveDataObject(byte[] rom, int index, byte[] data, TmosRomObjectType objectType, int offset = 0)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(objectType);
            SaveDataStructure(rom, def, index, offset, data);
        }

        #region WorldScreen
        public static TmosWorldScreen GetWorldScreen(byte[] rom, int index)
        {
            return GetDataObject<TmosWorldScreen>(rom, index, TmosRomObjectType.WorldScreen);
        }

        public static void SaveWorldScreen(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.WorldScreen);
        }
        #endregion WorldScreen

        #region WorldScreenTile
        public static TmosWorldScreenTile GetWorldScreenTile(byte[] rom, int index)
        {
            return GetDataObject<TmosWorldScreenTile>(rom, index, TmosRomObjectType.WorldScreenTile);
        }

        public static void SaveWorldScreenTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.WorldScreenTile);
        }
        #endregion WorldScreenTile

        #region TileSection
        public static TmosTileSection GetTileSection(byte[] rom, int index, int offset)
        {
            return GetDataObject<TmosTileSection>(rom, index, TmosRomObjectType.TileSection, offset);
        }

        public static void SaveTileSection(byte[] rom, int index, int offset, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.TileSection, offset);
        }
        #endregion TileSection

        #region Tile
        public static TmosTile GetTile(byte[] rom, int index)
        {
            return GetDataObject<TmosTile>(rom, index, TmosRomObjectType.Tile);
        }

        public static void SaveTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.Tile);
        }

        public static byte[] GetTileData(byte[] rom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
            return GetDataStructure(rom, def.Address, def.ObjectSize * def.Count, 0, 0);
        }
        #endregion Tile

        #region MiniTile
        public static TmosMiniTile GetMiniTile(byte[] rom, int index)
        {
            return GetDataObject<TmosMiniTile>(rom, index, TmosRomObjectType.MiniTile);
        }

        public static void SaveMiniTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.MiniTile);
        }
        #endregion MiniTile

        #region RandomEncounterGroup
        public static TmosRandomEncounterGroup GetRandomEncounterGroup(byte[] rom, int index)
        {
            return GetDataObject<TmosRandomEncounterGroup>(rom, index, TmosRomObjectType.RandomEncounterGroup);
        }

        public static void SaveRandomEncounterGroup(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.RandomEncounterGroup);
        }
        #endregion RandomEncounterGroup

        #region RandomEncounterLineup
        public static TmosRandomEncounterLineup GetRandomEncounterLineup(byte[] rom, int index)
        {
            return GetDataObject<TmosRandomEncounterLineup>(rom, index, TmosRomObjectType.RandomEncounterLineup);
        }

        public static void SaveRandomEncounterLineup(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectType.RandomEncounterLineup);
        }
        #endregion RandomEncounterLineup



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
            SaveDataStructure(bytes, addressWithOffset, structureByteContent, dataStructure.ObjectSize);
        }

        private static void SaveDataStructure(byte[] bytes, int address, byte[] structureByteContent, int objectSize)
        {
            Array.Copy(structureByteContent, 0, bytes, address, objectSize);
        }
        #endregion DataStructure

        #region Info

        public static int GetTmosRomObjectOffset(TmosRomObjectType tmosRomObjectType, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(tmosRomObjectType);
            int objectOffsetFromBeginningOfArray = (def.ObjectSize * index);
            return objectOffsetFromBeginningOfArray;
        }
        public static int GetTmosRomObjectAddress(TmosRomObjectType tmosRomObjectType, int index, int additionalOffset = 0)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(tmosRomObjectType);
            int beginningOfArrayAddress = def.Address;
            int objectOffsetFromBeginningOfArray = GetTmosRomObjectOffset(tmosRomObjectType, index) + additionalOffset;

            int addressOfObject = beginningOfArrayAddress + objectOffsetFromBeginningOfArray;
            return addressOfObject;
        }

        #endregion Info
    }
}