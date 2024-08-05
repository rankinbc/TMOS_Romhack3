using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomDataObjects;
using static Tmos.Romhacks.Core.TmosData;

namespace Tmos.Romhacks.Core
{
     public class TmosRom
    {
        public static byte[] Bytes;
        bool HasUnsavedChanges;

        public TmosRom() { }

        public void LoadRom(string filePath)
        {
            Bytes = File.ReadAllBytes(filePath);
            HasUnsavedChanges = false;
        }

        public void WriteRom(string filePath)
        {
            File.WriteAllBytes(filePath, Bytes);
        }

        #region Load Data

        public TmosWorldScreen LoadWorldScreen(int index)
        {
            return TmosData.GetWorldScreen(Bytes, index);
        }
        public TmosWorldScreenTile LoadWorldScreenTile(int index)
        {
            return TmosData.GetWorldScreenTile(Bytes, index);
        }
        public TmosTileSection LoadTileSection(int index, int tileDataOffset)
        {
            return TmosData.GetTileSection(Bytes, index, tileDataOffset);
        }
        public TmosTile LoadTile(int index)
        {
            return TmosData.GetTile(Bytes, index);
        }
        public byte[] LoadTileData()
        {
            return GetTileData(Bytes);
        }
        public TmosMiniTile LoadMiniTile(int index)
        {
            return TmosData.GetMiniTile(Bytes, index);
        }
        public TmosRandomEncounterLineup LoadRandomEncounterLineup(int index)
        {
            return TmosData.GetRandomEncounterLineup(Bytes, index);
        }
        public TmosRandomEncounterGroup LoadRandomEncounterGroup(int index)
        {
            return TmosData.GetRandomEncounterGroup(Bytes, index);
        }

        #endregion Load Data

        #region SaveData
        public void SaveWorldScreen(int index, TmosWorldScreen worldScreen)
        {
            TmosData.SaveWorldScreen(Bytes,index, worldScreen.GetBytes());
        }

        public void SaveWorldScreenTile(int index, TmosWorldScreenTile worldScreenTile)
        {
            TmosData.SaveWorldScreenTile(Bytes, index, worldScreenTile.GetBytes());
        }

        public void SaveTileSection(int index, int tileDataOffset, byte[] data)
        {
            TmosData.SaveTileSection(Bytes, index, tileDataOffset, data);
        }

        public void SaveTile(int index, TmosTile tile)
        {
            TmosData.SaveTile(Bytes, index, tile.GetBytes());
        }

        public void SaveMiniTile(int index, TmosMiniTile miniTile)
        {
            TmosData.SaveMiniTile(Bytes, index, miniTile.GetBytes());
        }

        public void SaveRandomEncounterLineup(int index, TmosRandomEncounterLineup randomEncounterLineup)
        {
            TmosData.SaveRandomEncounterLineup(Bytes, index, randomEncounterLineup.GetBytes());
        }

        public void SaveRandomEncounterGroup(int index, TmosRandomEncounterGroup randomEncounterGroup)
        {
            TmosData.SaveRandomEncounterGroup(Bytes, index, randomEncounterGroup.GetBytes());
        }

       
        #endregion SaveData






    }
}
