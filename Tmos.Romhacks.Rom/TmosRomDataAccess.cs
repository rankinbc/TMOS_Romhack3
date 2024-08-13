using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles;
using Tmos.Romhacks.Rom.TmosRomDataObjects.WorldScreen;
using Tmos.Romhacks.Rom.TmosRomInfo;

namespace Tmos.Romhacks.Rom
{
    public static class TmosRomDataAccess
    {
        public static T GetDataObject<T>(byte[] rom, int index, TmosRomObjectArrayType objectType, int offset = 0)
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


        public static void SaveDataObject(byte[] rom, int index, byte[] data, TmosRomObjectArrayType objectType, int offset = 0)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(objectType);
            SaveDataStructure(rom, def, index, offset, data);
        }

        #region WorldScreen
        public static TmosWorldScreen GetWorldScreen(byte[] rom, int index)
        {
            return GetDataObject<TmosWorldScreen>(rom, index, TmosRomObjectArrayType.WorldScreen);
        }

        public static void SaveWorldScreen(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.WorldScreen);
        }


        #endregion WorldScreen

        #region WorldScreenTile
        public static TmosWorldScreenTile GetWorldScreenTile(byte[] rom, int index)
        {
            return GetDataObject<TmosWorldScreenTile>(rom, index, TmosRomObjectArrayType.WorldScreenTile);
        }

        public static void SaveWorldScreenTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.WorldScreenTile);
        }
        #endregion WorldScreenTile

        #region TileSection
        public static TmosTileSection GetTileSection(byte[] rom, int index, int offset)
        {
            return GetDataObject<TmosTileSection>(rom, index, TmosRomObjectArrayType.TileSection, offset);
        }

        public static void SaveTileSection(byte[] rom, int index, int offset, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.TileSection, offset);
        }
        #endregion TileSection

        #region Tile
        public static TmosTile GetTile(byte[] rom, int index)
        {
            return GetDataObject<TmosTile>(rom, index, TmosRomObjectArrayType.Tile);
        }

        public static void SaveTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.Tile);
        }

        public static byte[] GetTileData(byte[] rom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.Tile);
            return GetDataStructure(rom, def.Address, def.ObjectSize * def.Count, 0, 0);
        }
        #endregion Tile

        #region MiniTile
        public static TmosMiniTile GetMiniTile(byte[] rom, int index)
        {
            return GetDataObject<TmosMiniTile>(rom, index, TmosRomObjectArrayType.MiniTile);
        }

        public static void SaveMiniTile(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.MiniTile);
        }
        #endregion MiniTile

        #region RandomEncounterGroup
        public static TmosRandomEncounterGroup GetRandomEncounterGroup(byte[] rom, int index)
        {
            return GetDataObject<TmosRandomEncounterGroup>(rom, index, TmosRomObjectArrayType.RandomEncounterGroup);
        }

        public static void SaveRandomEncounterGroup(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.RandomEncounterGroup);
        }
        #endregion RandomEncounterGroup

        #region RandomEncounterLineup
        public static TmosRandomEncounterLineup GetRandomEncounterLineup(byte[] rom, int index)
        {
            return GetDataObject<TmosRandomEncounterLineup>(rom, index, TmosRomObjectArrayType.RandomEncounterLineup);
        }

        public static void SaveRandomEncounterLineup(byte[] rom, int index, byte[] data)
        {
            SaveDataObject(rom, index, data, TmosRomObjectArrayType.RandomEncounterLineup);
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

		#region DataVariables

		public static byte[] GetDataVariable(byte[] rom, int address, int length)
		{
			byte[] variableValue = new byte[length];
			Array.Copy(rom, address, variableValue, 0, length);
			return variableValue;
		}

        public static void SaveDataVariable(byte[] bytes, int address, byte[] data)
		{
			Array.Copy(data, 0, bytes, address, data.Length);
		}

		#endregion DataVariables

		#region Info

		public static int GetTmosRomObjectOffset(TmosRomObjectArrayType tmosRomObjectType, int index)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(tmosRomObjectType);
            int objectOffsetFromBeginningOfArray = (def.ObjectSize * index);
            return objectOffsetFromBeginningOfArray;
        }
        public static int GetTmosRomObjectAddress(TmosRomObjectArrayType tmosRomObjectType, int index, int additionalOffset = 0)
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