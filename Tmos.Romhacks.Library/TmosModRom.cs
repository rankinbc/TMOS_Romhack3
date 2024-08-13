using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Tmos.Romhacks.Library.Definitions;
using Tmos.Romhacks.Library.Enum;

using Tmos.Romhacks.Library.RomObjects.Tiles;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Library.Utility;
using Tmos.Romhacks.Rom;
using Tmos.Romhacks.Rom.Enum;
using Tmos.Romhacks.Rom.Observer;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles;
using Tmos.Romhacks.Rom.TmosRomDataObjects.WorldScreen;
using Tmos.Romhacks.Rom.TmosRomDataObjects.WorldScreen.Enum;
using Tmos.Romhacks.Rom.TmosRomInfo;

namespace Tmos.Romhacks.Library
{
    public class TmosModRom: TmosRom, IRomDataManager
	{
		// TmosRom base; //Underlying bytes 


		private Dictionary<RomDataChangeNotificationType, List<IRomDataObserver>> _observers = new Dictionary<RomDataChangeNotificationType, List<IRomDataObserver>>();
		public TmosModRomContent RomContent { get; private set; }
		byte[] IRomDataManager.RomData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public TmosModRom()
		{
			RomContent = new TmosModRomContent();
		}

		public override void LoadRom(string filePath)
		{
			base.LoadRom(filePath);
			LoadObjectsFromRom();
			NotifyObservers(RomDataChangeNotificationType.All, 0 );
		}

        public void RegisterObserver(RomDataChangeNotificationType changeType, IRomDataObserver observer)
        {
            if (!_observers.ContainsKey(changeType))
            {
                _observers[changeType] = new List<IRomDataObserver>();
            }
            _observers[changeType].Add(observer);
        }

        public void UnregisterObserver(RomDataChangeNotificationType changeType, IRomDataObserver observer)
        {
            if (_observers.ContainsKey(changeType))
            {
                _observers[changeType].Remove(observer);
            }
        }

        public void NotifyObservers(RomDataChangeNotificationType changeType, int index)
		{
			if (_observers.ContainsKey(changeType))
			{
				foreach (var observer in _observers[changeType])
				{
                    if (changeType == RomDataChangeNotificationType.WorldScreen)
                    {
                       // RomContent.WorldScreens[index] = RefreshWorldScreen(index);
                    }
					//observer.OnRomDataChanged(changeType, index);
				}
			}
		}


		public void NotifyObservers(RomDataChangeNotificationType changeType, int? selectedIndex)
		{
			if (_observers.ContainsKey(changeType))
			{
				foreach (var observer in _observers[changeType])
				{
					observer.OnRomDataChanged(changeType, selectedIndex);
				}
			}
		}



		public void LoadObjectsFromRom()
        {
            LoadWorldScreenTilesFromRom();
            LoadTileSectionsFromRom();
            LoadWorldScreensFromRom();
            LoadTileDataFromRom();
            LoadTilesFromRom();
            LoadMiniTilesFromRom();
            LoadRandomEncounterGroupsFromRom();
            LoadRandomEncounterLineupsFromRom();
            LoadGameVariables();
        }

        public void LoadTileDataFromRom()
        {
            RomContent.TileData = base.LoadTileData();
        }

		#region TmosModWorldScreens

		//public void LoadWorldScreensFromRom()
		//{
		//    var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.WorldScreen);
		//    RomContent.WorldScreens = new TmosModWorldScreen[def.Count];

		//    //Now we have data from the rom

		//    //Convert the TmosWorldScreens into RandomizerModWorldScreens (which will hopefully be less tied to the lower level details)
		//    for (int i = 0; i < RomContent.WorldScreens.Length; i++)
		//    {
		//        TmosWorldScreen tmosWorldScreen = base.LoadWorldScreen(i);
		//        TmosModWorldScreen tmosModWorldScreen = LoadWorldScreen(tmosWorldScreen.GetBytes());

		//        RomContent.WorldScreens[i] = tmosModWorldScreen;
		//    }
		//}

		private void LoadWorldScreensFromRom()
		{
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.WorldScreen);
			RomContent.WorldScreens = new TmosModWorldScreen[def.Count];

			for (int i = 0; i < RomContent.WorldScreens.Length; i++)
			{
                LoadWorldScreenFromRom(i);
			}
		}
		public void LoadWorldScreenFromRom(int absoluteWSIndex)
        {
			TmosWorldScreen tmosWorldScreen = base.LoadWorldScreen(absoluteWSIndex);
			InitializeTmosModWorldScreen(tmosWorldScreen.GetBytes(), absoluteWSIndex);
        }
     
            public void InitializeTmosModWorldScreen(byte[] bytes, int absoluteWSIndex)
        {
			RomContent.WorldScreens[absoluteWSIndex] = new TmosModWorldScreen(bytes)
            {
                 ParentWorld = bytes[(int)WSProperty.ParentWorld],
                AmbientSound = bytes[(int)WSProperty.AmbientSound],
                Content = bytes[(int)WSProperty.Content],
                ObjectSet = bytes[(int)WSProperty.ObjectSet],
                ScreenIndexRight = bytes[(int)WSProperty.ScreenIndexRight],
                ScreenIndexLeft = bytes[(int)WSProperty.ScreenIndexLeft],
                ScreenIndexDown = bytes[(int)WSProperty.ScreenIndexDown],
                ScreenIndexUp = bytes[(int)WSProperty.ScreenIndexUp],
                DataPointer = bytes[(int)WSProperty.DataPointer],
                ExitPosition = bytes[(int)WSProperty.ExitPosition],
                TopTiles = bytes[(int)WSProperty.TopTiles],
                BottomTiles = bytes[(int)WSProperty.BottomTiles],
                WorldScreenColor = bytes[(int)WSProperty.WorldScreenColor],
                SpritesColor = bytes[(int)WSProperty.SpritesColor],
                Unknown = bytes[(int)WSProperty.Unknown],
                Event = bytes[(int)WSProperty.Event],
            };

			int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWSIndex).ChapterNumber;
            //RomContent.WorldScreens[absoluteWSIndex].WSContent = WSContentDefinitions.GetWSContentDefinition(chapter, bytes[(int)WSProperty.Content]);
            LoadWorldScreenContent(RomContent.WorldScreens[absoluteWSIndex], chapter);
			LoadWorldScreenTileGrid(RomContent.WorldScreens[absoluteWSIndex]);
		}

		public void LoadWorldScreenContent(TmosModWorldScreen tmosWorldScreen, int chapter = 0)
        {
            tmosWorldScreen.WSContent = WSContentDefinitions.GetWSContentDefinition(chapter, tmosWorldScreen.Content);
		}
        public void LoadWorldScreenTileGrid(TmosModWorldScreen tmosWorldScreen)
        {
            int topTileDataOffset = TileDataUtility.GetTopTileSectionTileDataOffset(tmosWorldScreen.DataPointer);
            tmosWorldScreen.TileSectionTop = base.LoadTileSection(tmosWorldScreen.TopTiles, topTileDataOffset);

            int bottomTileDataOffset = TileDataUtility.GetBottomTileSectionTileDataOffset(tmosWorldScreen.DataPointer);
            tmosWorldScreen.TileSectionBottom = base.LoadTileSection(tmosWorldScreen.BottomTiles, bottomTileDataOffset);
        }

		public void UpdateTmosModWorldScreen(int absoluteWorldScreenIndex, TmosModWorldScreen tmosModWorldScreen)
		{
			//RefreshWorldScreen(tmosModWorldScreen);
			base.SaveWorldScreen(absoluteWorldScreenIndex, new TmosWorldScreen(tmosModWorldScreen.GetBytes()));
            RomContent.WorldScreens[absoluteWorldScreenIndex] = tmosModWorldScreen;
			NotifyObservers( RomDataChangeNotificationType.WorldScreen, absoluteWorldScreenIndex);
		}

		#region Retrieving WorldScreens

		public int GetTmosWorldScreenChapter(int absoluteWorldScreenIndex)
        {
            TmosModWorldScreen ws = RomContent.WorldScreens[absoluteWorldScreenIndex];
            int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
            return chapter;
        }

        public int GetTmosWorldScreenNeighborAbsoluteIndex(int absoluteWorldScreenIndex, Direction direction)
        {
            TmosModWorldScreen ws = RomContent.WorldScreens[absoluteWorldScreenIndex];
            int wsNeighborRelativeIndex = ws.GetNeighborWorldScreenRelativeIndex(direction);
            int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
            int neighborWsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, wsNeighborRelativeIndex);
            return neighborWsAbsoluteIndex;
        }

        public int GetTmosWorldScreenNeighborAbsoluteIndex(int chapterIndex, int chapterRelativeWorldScreenIndex, Direction direction)
        {
            int wsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapterIndex, chapterRelativeWorldScreenIndex);
            TmosModWorldScreen ws = RomContent.WorldScreens[wsAbsoluteIndex];
            int neighborWsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapterIndex, chapterRelativeWorldScreenIndex);
            return neighborWsAbsoluteIndex;
        }


        #endregion Retrieving WorldScreens

        #endregion TmosModWorldScreens

        public void LoadWorldScreenTilesFromRom()
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.WorldScreenTile);
            RomContent.WorldScreenTiles = new TmosModWorldScreenTile[def.Count];

            for (int i = 0; i < RomContent.WorldScreenTiles.Length; i++)
            {
                TmosWorldScreenTile tmosWorldScreenTile = base.LoadWorldScreenTile(i);
                RomContent.WorldScreenTiles[i] = new TmosModWorldScreenTile(tmosWorldScreenTile.GetBytes());
            }

        }

        #region TmosRomContent.TileSections

        public void LoadTileSectionsFromRom()
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.TileSection);
            RomContent.TileSections = new TmosTileSection[def.Count];

            for (int i = 0; i < RomContent.TileSections.Length; i++)
            {
                TmosTileSection tmosTileSection = base.LoadTileSection(i, 0);
                RomContent.TileSections[i] = tmosTileSection;
            }
        }

        public TmosTileSection GetTmosModTileSection(int absoluteIndex)
        {
            TmosTileSection tileSection = RomContent.TileSections[absoluteIndex];
            return tileSection;
        }
        //public TmosTileSection[] GetTmosModTileSections()
        //{
        //    TmosTileSection[] tileSections = RomContent.TileSections;
        //    return RomContent.TileSections;
        //}

        //public int GetWSTileSectionTopAbsoluteIndex(int worldScreenAbsoluteIndex)
        //{
        //    TmosModWorldScreen ws = RomContent.WorldScreens[worldScreenAbsoluteIndex];
        //    return TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.TopTiles, ws.DataPointer, true);
        //}
        //public int GetWSTileSectionBottomAbsoluteIndex(int worldScreenAbsoluteIndex)
        //{
        //    TmosModWorldScreen ws = RomContent.WorldScreens[worldScreenAbsoluteIndex];
        //    return TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.BottomTiles, ws.DataPointer, false);
        //}

        public void UpdateTmosModTileSection(int tileSectionIndex, byte[] tileSectionData)
        {
            RomContent.TileSections[tileSectionIndex].UpdateBytes(tileSectionData);
            //Calculate offset??
            base.SaveTileSection(tileSectionIndex, 0, tileSectionData);
			//WorldScreens that have this tile section need to reload their tile grids
			//For now reloading all

			//ReloadDataFromRom()?
			LoadTileDataFromRom();
            LoadTileSectionsFromRom();
            LoadWorldScreensFromRom();
            LoadTilesFromRom();
            LoadMiniTilesFromRom();
        }


        #endregion TmosRomContent.TileSections

        #region TmosTiles
        public void LoadTilesFromRom()
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.Tile);
			RomContent.Tiles = new TmosModTile[def.Count];

            for (int i = 0; i < RomContent.Tiles.Length; i++)
            {
                TmosTile tmosTile = base.LoadTile(i);

                TmosModTile tmodModTile = new TmosModTile(tmosTile.GetBytes());
				RomContent.Tiles[i] = tmodModTile;
            }
        }

		public TmosModTile GetTmosModTile(int absoluteIndex)
		{
			TmosModTile tmosModTile = RomContent.Tiles[absoluteIndex];
			return tmosModTile;
		}

		public void UpdateTmosModTile(int tileIndex, byte[] tileData)
		{
            byte wsTileIndex = (byte)tileIndex; //Not sure if this needs to be adjusted or not
			TmosModTile updatedTmosModTile  = new TmosModTile(wsTileIndex, tileData);
			TmosTile updatedTile = new TmosTile(updatedTmosModTile.GetBytes());

			RomContent.Tiles[tileIndex] = updatedTmosModTile;

			base.SaveTile(tileIndex, updatedTile);

			//WorldScreens that have this tile need to reload their tile grids
			//For now reloading all
			//ReloadDataFromRom()?
			LoadTileDataFromRom();
			LoadTileSectionsFromRom();
			LoadWorldScreensFromRom();
			LoadTilesFromRom();
			LoadMiniTilesFromRom();

			NotifyObservers(RomDataChangeNotificationType.Tile, wsTileIndex);
		}

		#endregion TmosTiles


		#region TmosRomContent.MiniTiles

		public void LoadMiniTilesFromRom()
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.MiniTile);
            RomContent.MiniTiles = new TmosMiniTile[def.Count];

            for (int i = 0; i < RomContent.MiniTiles.Length; i++)
            {
                TmosMiniTile tmosMiniTile = base.LoadMiniTile(i);
                RomContent.MiniTiles[i] = tmosMiniTile;
            }
        }

        public void UpdateMiniTile(int miniTileIndex, byte[] miniTileData)
        {
            TmosModMiniTile updatedTmosModMiniTile = new TmosModMiniTile(miniTileData);
            TmosMiniTile updatedMiniTile = new TmosMiniTile(updatedTmosModMiniTile.GetBytes());

            base.SaveMiniTile(miniTileIndex, updatedMiniTile);

            RomContent.MiniTiles[miniTileIndex] = updatedMiniTile; //might need to reload?

            //reloading needed?
            //ReloadDataFromRom()?

            LoadTileDataFromRom();
            LoadTileSectionsFromRom();
            LoadWorldScreensFromRom();
            LoadTilesFromRom();
            LoadMiniTilesFromRom();

            NotifyObservers(RomDataChangeNotificationType.MiniTile, miniTileIndex);
        }
			#endregion TmosRomContent.MiniTiles


			#region TmosRandomEncounterGroups

			public void LoadRandomEncounterGroupsFromRom()
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.RandomEncounterGroup);
			RomContent.RandomEncounterGroups = new TmosRandomEncounterGroup[def.Count];

            for (int i = 0; i < RomContent.RandomEncounterGroups.Length; i++)
            {
                TmosRandomEncounterGroup tmosRandomEncounterGroup = base.LoadRandomEncounterGroup(i);
				RomContent.RandomEncounterGroups[i] = tmosRandomEncounterGroup;
            }
        }

		public void LoadRandomEncounterGroupFromRom(int index)
		{
			TmosRandomEncounterGroup tmosRandomEncounterGroup = base.LoadRandomEncounterGroup(index);
			RomContent.RandomEncounterGroups[index] = tmosRandomEncounterGroup;
		}

		public void UpdateEncounterGroup(int encounterGroupIndex, TmosRandomEncounterGroup encounterGroup)
        {
            base.SaveRandomEncounterGroup(encounterGroupIndex, new TmosRandomEncounterGroup(encounterGroup.GetBytes()));
			//	TmosRandomEncounterGroup tmosRandomEncounterGroup = base.LoadRandomEncounterGroup(i);
			RomContent.RandomEncounterGroups[encounterGroupIndex] = base.LoadRandomEncounterGroup(encounterGroupIndex);

			//reloading needed?
			//LoadObjectsFromRom();

			NotifyObservers(RomDataChangeNotificationType.RandomEncounterGroup, encounterGroupIndex);
		}


		#endregion TmosRandomEncounterGroups

		#region TmosRandomEncounterLineups

		public void LoadRandomEncounterLineupsFromRom()
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectArrayType.RandomEncounterLineup);
			RomContent.RandomEncounterLineups = new TmosRandomEncounterLineup[def.Count];

            for (int i = 0; i < RomContent.RandomEncounterLineups.Length; i++)
            {
                TmosRandomEncounterLineup tmosRandomEncounterLineup = base.LoadRandomEncounterLineup(i);
				RomContent.RandomEncounterLineups[i] = tmosRandomEncounterLineup;
            }
        }

        public void LoadRandomEncounterLineupFromRom(int index)
		{
			TmosRandomEncounterLineup tmosRandomEncounterLineup = base.LoadRandomEncounterLineup(index);
			RomContent.RandomEncounterLineups[index] = tmosRandomEncounterLineup;
		}

		public void UpdateEncounterLineup(int encounterLineupIndex, TmosRandomEncounterLineup encounterLineup)
		{
			base.SaveRandomEncounterLineup(encounterLineupIndex, new TmosRandomEncounterLineup(encounterLineup.GetBytes()));
			//	TmosRandomEncounterGroup tmosRandomEncounterGroup = base.LoadRandomEncounterGroup(i);
			RomContent.RandomEncounterLineups[encounterLineupIndex] = base.LoadRandomEncounterLineup(encounterLineupIndex);

			//reloading needed?
			LoadObjectsFromRom();

			NotifyObservers(RomDataChangeNotificationType.RandomEncounterLineup, encounterLineupIndex);
			}
		#endregion TmosRandomEncounterLineups

		#region GameVariables

        public void LoadGameVariables()
        {
			RomContent.GameVariables = new Dictionary<GameVariableEnum, byte[]>(KnownGameVariableDefinitions.KnownGameVariableDictionary.Count);
			foreach (var gameVariableEntry in KnownGameVariableDefinitions.KnownGameVariableDictionary)
            {
                GameVariableEnum gv = gameVariableEntry.Key;
				KnownGameVariableDefinition def = gameVariableEntry.Value;
                int varAddress = def.Address;

				//Load appropriately (for now only working with byte values)
				byte[] gameVariableData = base.LoadGameVariable(varAddress,1);
				RomContent.GameVariables.Add(gv, gameVariableData);
			}
        }

		public void UpdateGameVariable(GameVariableEnum gameVariable, byte[] data)
		{
			KnownGameVariableDefinition def = KnownGameVariableDefinitions.KnownGameVariableDictionary[gameVariable];
			int varAddress = def.Address;

			base.SaveGameVariable(varAddress, data);

			RomContent.GameVariables[gameVariable] = data;

				NotifyObservers(RomDataChangeNotificationType.GameVariable, varAddress);
		}


		#endregion GameVariables

		#region Conversion to TmosRom

		public void SaveDataToRom(string filePath)
        {
            for (int i = 0; i < TmosRomDataObjectDefinitions.RomInfo_WorldScreen.Count; i++)
            {
                byte[] worldScreenData = RomContent.WorldScreens[i].GetBytes();
                base.SaveWorldScreen(i, new TmosWorldScreen(worldScreenData));
            }

            base.WriteRom(filePath);

        }





		#endregion Conversion to TmosRom


	}
}
