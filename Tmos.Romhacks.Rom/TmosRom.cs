using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles;
using Tmos.Romhacks.Rom.TmosRomDataObjects.WorldScreen;

namespace Tmos.Romhacks.Rom
{
    public class TmosRom : IRomDataObserver
	{
		protected byte[] RomData { get; private set; }
        bool HasUnsavedChanges;
		private List<IRomDataObserver> _observers = new List<IRomDataObserver>();

		public TmosRom() { }
		public void RegisterObserver(IRomDataObserver observer)
		{
			_observers.Add(observer);
		}

		public void UnregisterObserver(IRomDataObserver observer)
		{
			_observers.Remove(observer);
		}

		protected void NotifyObservers(int? wsIndex)
		{
			foreach (var observer in _observers)
			{
				observer.OnRomDataChanged(wsIndex);
			}
		}

		public virtual void LoadRom(string filePath)
		{
			RomData = File.ReadAllBytes(filePath);
			HasUnsavedChanges = false;
			NotifyObservers(0);
		}

		public virtual void WriteRom(string filePath)
		{
			File.WriteAllBytes(filePath, RomData);
			HasUnsavedChanges = false;
		}

		public void OnRomDataChanged(int? wsIndex)
		{
            int a = 0;
		}


		#region Load Data

		protected virtual TmosWorldScreen LoadWorldScreen(int index)
        {
            return TmosRomDataAccess.GetWorldScreen(RomData, index);
        }
        protected virtual TmosWorldScreenTile LoadWorldScreenTile(int index)
        {
            return TmosRomDataAccess.GetWorldScreenTile(RomData, index);
        }
        protected virtual TmosTileSection LoadTileSection(int index, int tileDataOffset)
        {
            return TmosRomDataAccess.GetTileSection(RomData, index, tileDataOffset);
        }
        protected virtual TmosTile LoadTile(int index)
        {
            return TmosRomDataAccess.GetTile(RomData, index);
        }
        protected virtual byte[] LoadTileData()
        {
            return TmosRomDataAccess.GetTileData(RomData);
        }
        protected virtual TmosMiniTile LoadMiniTile(int index)
        {
            return TmosRomDataAccess.GetMiniTile(RomData, index);
        }
        protected virtual TmosRandomEncounterLineup LoadRandomEncounterLineup(int index)
        {
            return TmosRomDataAccess.GetRandomEncounterLineup(RomData, index);
        }
        protected virtual TmosRandomEncounterGroup LoadRandomEncounterGroup(int index)
        {
            return TmosRomDataAccess.GetRandomEncounterGroup(RomData, index);
        }
        
        protected virtual byte[] LoadGameVariable(int address, int length)
		{
			return TmosRomDataAccess.GetDataVariable(RomData, address, length);
		}
		#endregion Load Data

		#region SaveData
		protected virtual void SaveWorldScreen(int index, TmosWorldScreen worldScreen)
        {
            TmosRomDataAccess.SaveWorldScreen(RomData,index, worldScreen.GetBytes());
            
        }

        protected virtual void SaveWorldScreenTile(int index, TmosWorldScreenTile worldScreenTile)
        {
            TmosRomDataAccess.SaveWorldScreenTile(RomData, index, worldScreenTile.GetBytes());
        }

        protected void SaveTileSection(int index, int tileDataOffset, byte[] data)
        {
            TmosRomDataAccess.SaveTileSection(RomData, index, tileDataOffset, data);
        }

        protected void SaveTile(int index, TmosTile tile)
        {
            TmosRomDataAccess.SaveTile(RomData, index, tile.GetBytes());
        }

        protected void SaveMiniTile(int index, TmosMiniTile miniTile)
        {
            TmosRomDataAccess.SaveMiniTile(RomData, index, miniTile.GetBytes());
        }

        protected void SaveRandomEncounterLineup(int index, TmosRandomEncounterLineup randomEncounterLineup)
        {
            TmosRomDataAccess.SaveRandomEncounterLineup(RomData, index, randomEncounterLineup.GetBytes());
        }

        protected void SaveRandomEncounterGroup(int index, TmosRandomEncounterGroup randomEncounterGroup)
        {
            TmosRomDataAccess.SaveRandomEncounterGroup(RomData, index, randomEncounterGroup.GetBytes());
        }

		protected void SaveGameVariable(int address, byte[] data)
		{
			TmosRomDataAccess.SaveDataVariable(RomData, address, data);
		}



		#endregion SaveData

		public void UpdateRomData(int offset, byte[] newData)
		{
			Array.Copy(newData, 0, RomData, offset, newData.Length);
			HasUnsavedChanges = true;
			NotifyObservers(null);
		}

		// Add methods to get ROM data
		public byte[] GetRomData(int offset, int length)
		{
			byte[] data = new byte[length];
			Array.Copy(RomData, offset, data, 0, length);
			return data;
		}




	}
}
