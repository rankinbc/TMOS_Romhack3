using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomDataObjects;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.Map;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.Mods.Utility;

namespace Tmos.Romhacks.Mods
{
    public class TmosModRom
    {
        TmosRom _romData; //Underlying bytes 
        public TmosModWorldScreenTile[] WorldScreenTiles { get; set; }
        private TmosModWorldScreen[] _worldScreens { get; set; }
        public TmosTileSection[] TileSections { get; set; }
        public TmosModTile[] Tiles { get; set; }
        public TmosMiniTile[] MiniTiles { get; set; }
        public TmosRandomEncounterGroup[] RandomEncounterGroups { get; set; }
        public TmosRandomEncounterLineup[] RandomEncounterLineups { get; set; }
        public Dictionary<GameVariableEnum, byte[]> GameVariables { get; set; }



		private IWorldScreenGridGenerator _gridGenerator;
		private WorldAreaGrid _worldScreenGrid;

		public byte[] TileData { get; set; } //Entire tile data section from rom

        public TmosModRom()
        {

        }

        public void LoadDataFromRom(TmosRom rom)
        {
            _romData = rom;

            LoadWorldScreenTilesFromRom(_romData);
            LoadTileSectionsFromRom(_romData);
            LoadWorldScreensFromRom(_romData);
            LoadTileDataFromRom(_romData);
            LoadTilesFromRom(_romData);
            LoadMiniTilesFromRom(_romData);
            LoadRandomEncounterGroupsFromRom(_romData);
            LoadRandomEncounterLineupsFromRom(_romData);
            LoadGameVariables(_romData);
        }

        private void ReloadDataFromRom()
		{
			LoadWorldScreenTilesFromRom(_romData);
			LoadTileSectionsFromRom(_romData);
			LoadWorldScreensFromRom(_romData);
			LoadTileDataFromRom(_romData);
			LoadTilesFromRom(_romData);
			LoadMiniTilesFromRom(_romData);
			LoadRandomEncounterGroupsFromRom(_romData);
			LoadRandomEncounterLineupsFromRom(_romData);
			LoadGameVariables(_romData);
		}

        public void LoadTileDataFromRom(TmosRom tmosRom)
        {
            TileData = tmosRom.LoadTileData();
        }

      

        #region TmosModWorldScreens

        public void LoadWorldScreensFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
            _worldScreens = new TmosModWorldScreen[def.Count];

            //Now we have data from the rom

            //Convert the TmosWorldScreens into RandomizerModWorldScreens (which will hopefully be less tied to the lower level details)
            for (int i = 0; i < _worldScreens.Length; i++)
            {
                TmosWorldScreen tmosWorldScreen = tmosRom.LoadWorldScreen(i);
                TmosModWorldScreen tmosModWorldScreen = LoadWorldScreen(tmosWorldScreen.GetBytes());

                _worldScreens[i] = tmosModWorldScreen;
            }
        }

        public void LoadWorldScreenFromRom(int absoluteWSIndex)
        {

            TmosWorldScreen tmosWorldScreen = _romData.LoadWorldScreen(absoluteWSIndex);
            TmosModWorldScreen tmosModWorldScreen = LoadWorldScreen(tmosWorldScreen.GetBytes());

            _worldScreens[absoluteWSIndex] = tmosModWorldScreen;
        }
     
            public TmosModWorldScreen LoadWorldScreen(byte[] bytes)
        {
            TmosModWorldScreen ws = new TmosModWorldScreen(bytes)
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

            ws = RefreshWorldScreen(ws);

            return ws;

        }


        public TmosModWorldScreen RefreshWorldScreen(TmosModWorldScreen ws, bool reloadFromRomData = false)
        {
            LoadWorldScreenContent(ws);
            LoadWorldScreenTileGrid(ws);
            return ws;
        }
        public void LoadWorldScreenContent(TmosModWorldScreen tmosWorldScreen, int chapter = 0)
        {
            tmosWorldScreen.WSContent = WSContentDefinitions.GetWSContentDefinition(chapter, tmosWorldScreen.Content);			
        }
        public void LoadWorldScreenTileGrid(TmosModWorldScreen tmosWorldScreen)
        {
            int topTileDataOffset = TileDataUtility.GetTopTileSectionTileDataOffset(tmosWorldScreen.DataPointer);
            tmosWorldScreen.TileSectionTop = _romData.LoadTileSection(tmosWorldScreen.TopTiles, topTileDataOffset);

            int bottomTileDataOffset = TileDataUtility.GetBottomTileSectionTileDataOffset(tmosWorldScreen.DataPointer);
            tmosWorldScreen.TileSectionBottom = _romData.LoadTileSection(tmosWorldScreen.BottomTiles, bottomTileDataOffset);
        }

        public TmosModWorldScreen[] GetTmosModWorldScreens(bool reload = false)
        {
            if (reload)
            {
                foreach (var ws in _worldScreens)
                {
                    RefreshWorldScreen(ws);
                }
            }
            return _worldScreens;
        }

        public TmosModWorldScreen GetTmosModWorldScreen(int absoluteWorldScreenIndex, bool reload = false)
        {
            if (_worldScreens != null && _worldScreens.Length > 0 && absoluteWorldScreenIndex >= 0)
            {
                TmosModWorldScreen ws = _worldScreens[absoluteWorldScreenIndex];
                int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
                LoadWorldScreenContent(ws, chapter);
                LoadWorldScreenTileGrid(ws);
                return ws;
            }
            else
            {
                return null;
            }
        }

        public void UpdateTmosModWorldScreen(int absoluteWorldScreenIndex, TmosModWorldScreen tmosModWorldScreen)
        {
            
            LoadWorldScreenContent(tmosModWorldScreen);
            LoadWorldScreenTileGrid(tmosModWorldScreen);



            //Update _romData here or wait until Save?
            var ws = new TmosWorldScreen(tmosModWorldScreen.GetBytes());
            _romData.SaveWorldScreen(absoluteWorldScreenIndex, ws);

            LoadWorldScreenFromRom(absoluteWorldScreenIndex);
            _worldScreens[absoluteWorldScreenIndex] = GetTmosModWorldScreen(absoluteWorldScreenIndex, true);
        }

        #region Retrieving WorldScreens

        public int GetTmosWorldScreenChapter(int absoluteWorldScreenIndex)
        {
            TmosModWorldScreen ws = _worldScreens[absoluteWorldScreenIndex];
            int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
            return chapter;
        }

        public int GetTmosWorldScreenNeighborAbsoluteIndex(int absoluteWorldScreenIndex, Direction direction)
        {
            TmosModWorldScreen ws = _worldScreens[absoluteWorldScreenIndex];
            int wsNeighborRelativeIndex = ws.GetNeighborWorldScreenRelativeIndex(direction);
            int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
            int neighborWsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, wsNeighborRelativeIndex);
            return neighborWsAbsoluteIndex;
        }

        public int GetTmosWorldScreenNeighborAbsoluteIndex(int chapterIndex, int chapterRelativeWorldScreenIndex, Direction direction)
        {
            int wsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapterIndex, chapterRelativeWorldScreenIndex);
            TmosModWorldScreen ws = _worldScreens[wsAbsoluteIndex];
            int neighborWsAbsoluteIndex = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapterIndex, chapterRelativeWorldScreenIndex);
            return neighborWsAbsoluteIndex;
        }


        #endregion Retrieving WorldScreens

        #endregion TmosModWorldScreens

        public void LoadWorldScreenTilesFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreenTile);
            WorldScreenTiles = new TmosModWorldScreenTile[def.Count];

            for (int i = 0; i < WorldScreenTiles.Length; i++)
            {
                TmosWorldScreenTile tmosWorldScreenTile = tmosRom.LoadWorldScreenTile(i);
                WorldScreenTiles[i] = new TmosModWorldScreenTile(tmosWorldScreenTile.GetBytes());
            }

        }

        #region TmosTileSections

        public void LoadTileSectionsFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            TileSections = new TmosTileSection[def.Count];

            for (int i = 0; i < TileSections.Length; i++)
            {
                TmosTileSection tmosTileSection = tmosRom.LoadTileSection(i, 0);
                TileSections[i] = tmosTileSection;
            }
        }

        public TmosTileSection GetTmosModTileSection(int absoluteIndex)
        {
            TmosTileSection tileSection = TileSections[absoluteIndex];
            return tileSection;
        }
        public TmosTileSection[] GetTmosModTileSections()
        {
            TmosTileSection[] tileSections = TileSections;
            return tileSections;
        }

        public int GetWSTileSectionTopAbsoluteIndex(int worldScreenAbsoluteIndex)
        {
            TmosModWorldScreen ws = _worldScreens[worldScreenAbsoluteIndex];
            return TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.TopTiles, ws.DataPointer, true);
        }
        public int GetWSTileSectionBottomAbsoluteIndex(int worldScreenAbsoluteIndex)
        {
            TmosModWorldScreen ws = _worldScreens[worldScreenAbsoluteIndex];
            return TileDataUtility.GetTmosModTileSectionAbsoluteIndex(ws.BottomTiles, ws.DataPointer, false);
        }

        public void UpdateTmosModTileSection(int tileSectionIndex, byte[] tileSectionData)
        {
            TileSections[tileSectionIndex].UpdateBytes(tileSectionData);
            //Calculate offset??
            _romData.SaveTileSection(tileSectionIndex, 0, tileSectionData);
			//WorldScreens that have this tile section need to reload their tile grids
			//For now reloading all

			//ReloadDataFromRom()?
			LoadTileDataFromRom(_romData);
            LoadTileSectionsFromRom(_romData);
            LoadWorldScreensFromRom(_romData);
            LoadTilesFromRom(_romData);
            LoadMiniTilesFromRom(_romData);
        }


        #endregion TmosTileSections

        #region TmosTiles
        public void LoadTilesFromRom(TmosRom tmosRom)
        {
			var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.Tile);
            Tiles = new TmosModTile[def.Count];

            for (int i = 0; i < Tiles.Length; i++)
            {
                TmosTile tmosTile = tmosRom.LoadTile(i);

                TmosModTile tmodModTile = new TmosModTile(tmosTile.GetBytes());
				Tiles[i] = tmodModTile;
            }
        }

		public TmosModTile GetTmosModTile(int absoluteIndex)
		{
			TmosModTile tmosModTile = Tiles[absoluteIndex];
			return tmosModTile;
		}

		public void UpdateTmosModTile(int tileIndex, byte[] tileData)
		{
            byte wsTileIndex = (byte)tileIndex; //Not sure if this needs to be adjusted or not
			TmosModTile updatedTmosModTile  = new TmosModTile(wsTileIndex, tileData);
			TmosTile updatedTile = new TmosTile(updatedTmosModTile.GetBytes());

			Tiles[tileIndex] = updatedTmosModTile;

			_romData.SaveTile(tileIndex, updatedTile);

			//WorldScreens that have this tile need to reload their tile grids
			//For now reloading all
			//ReloadDataFromRom()?
			LoadTileDataFromRom(_romData);
			LoadTileSectionsFromRom(_romData);
			LoadWorldScreensFromRom(_romData);
			LoadTilesFromRom(_romData);
			LoadMiniTilesFromRom(_romData);
		}

		#endregion TmosTiles


		#region TmosMiniTiles

		public void LoadMiniTilesFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.MiniTile);
            MiniTiles = new TmosMiniTile[def.Count];

            for (int i = 0; i < MiniTiles.Length; i++)
            {
                TmosMiniTile tmosMiniTile = tmosRom.LoadMiniTile(i);
                MiniTiles[i] = tmosMiniTile;
            }
        }

        public void UpdateMiniTile(int miniTileIndex, byte[] miniTileData)
		{
			TmosModMiniTile updatedTmosModMiniTile = new TmosModMiniTile(miniTileData);
			TmosMiniTile updatedMiniTile = new TmosMiniTile(updatedTmosModMiniTile.GetBytes());

			_romData.SaveMiniTile(miniTileIndex, updatedMiniTile);

			MiniTiles[miniTileIndex] = updatedMiniTile; //might need to reload?

			//reloading needed?
			//ReloadDataFromRom()?

			LoadTileDataFromRom(_romData);
			LoadTileSectionsFromRom(_romData);
			LoadWorldScreensFromRom(_romData);
			LoadTilesFromRom(_romData);
			LoadMiniTilesFromRom(_romData);
		}

		#endregion TmosMiniTiles


		#region TmosRandomEncounterGroups

		public void LoadRandomEncounterGroupsFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.RandomEncounterGroup);
            RandomEncounterGroups = new TmosRandomEncounterGroup[def.Count];

            for (int i = 0; i < RandomEncounterGroups.Length; i++)
            {
                TmosRandomEncounterGroup tmosRandomEncounterGroup = tmosRom.LoadRandomEncounterGroup(i);
                RandomEncounterGroups[i] = tmosRandomEncounterGroup;
            }
        }

        public void UpdateEncounterGroup(int encounterGroupIndex, TmosRandomEncounterGroup encounterGroup)
        {
            _romData.SaveRandomEncounterGroup(encounterGroupIndex, new TmosRandomEncounterGroup(encounterGroup.GetBytes()));
            //	TmosRandomEncounterGroup tmosRandomEncounterGroup = tmosRom.LoadRandomEncounterGroup(i);
            RandomEncounterGroups[encounterGroupIndex] = _romData.LoadRandomEncounterGroup(encounterGroupIndex);

            //reloading needed?
            ReloadDataFromRom();
        }


		#endregion TmosRandomEncounterGroups

		#region TmosRandomEncounterLineups

		public void LoadRandomEncounterLineupsFromRom(TmosRom tmosRom)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.RandomEncounterLineup);
            RandomEncounterLineups = new TmosRandomEncounterLineup[def.Count];

            for (int i = 0; i < RandomEncounterLineups.Length; i++)
            {
                TmosRandomEncounterLineup tmosRandomEncounterLineup = tmosRom.LoadRandomEncounterLineup(i);
                RandomEncounterLineups[i] = tmosRandomEncounterLineup;
            }
        }

		public void UpdateEncounterLineup(int encounterLineupIndex, TmosRandomEncounterLineup encounterLineup)
		{
			_romData.SaveRandomEncounterLineup(encounterLineupIndex, new TmosRandomEncounterLineup(encounterLineup.GetBytes()));
			//	TmosRandomEncounterGroup tmosRandomEncounterGroup = tmosRom.LoadRandomEncounterGroup(i);
			RandomEncounterLineups[encounterLineupIndex] = _romData.LoadRandomEncounterLineup(encounterLineupIndex);

			//reloading needed?
			ReloadDataFromRom();
		}
		#endregion TmosRandomEncounterLineups

		#region GameVariables

        public void LoadGameVariables(TmosRom tmosRom)
        {
            GameVariables = new Dictionary<GameVariableEnum, byte[]>(KnownGameVariableDefinitions.KnownGameVariableDictionary.Count);
			foreach (var gameVariableEntry in KnownGameVariableDefinitions.KnownGameVariableDictionary)
            {
                GameVariableEnum gv = gameVariableEntry.Key;
				KnownGameVariableDefinition def = gameVariableEntry.Value;
                int varAddress = def.Address;

				//Load appropriately (for now only working with byte values)
				byte[] gameVariableData = tmosRom.LoadGameVariable(varAddress,1);
				GameVariables.Add(gv, gameVariableData);
			}
        }

		public void UpdateGameVariable(GameVariableEnum gameVariable, byte[] data)
		{
			KnownGameVariableDefinition def = KnownGameVariableDefinitions.KnownGameVariableDictionary[gameVariable];
			int varAddress = def.Address;

			_romData.SaveGameVariable(varAddress, data);

			GameVariables[gameVariable] = data;
		}


		#endregion GameVariables

		#region Conversion to TmosRom

		public void SaveDataToRom(string filePath)
        {
            for (int i = 0; i < TmosRomDataObjectDefinitions.RomInfo_WorldScreen.Count; i++)
            {
                byte[] worldScreenData = _worldScreens[i].GetBytes();
                _romData.SaveWorldScreen(i, new TmosWorldScreen(worldScreenData));
            }

            _romData.WriteRom(filePath);

            //SaveWorldScreenTilesToRom(_romData);
            //SaveTileSectionsToRom(_romData);
            //SaveWorldScreensToRom(_romData);
            //SaveTilesToRom(_romData);
            //SaveMiniTilesToRom(_romData);
            //SaveRandomEncounterGroupsToRom(_romData);
            //SaveRandomEncounterLineupsToRom(_romData);
        }

        #endregion Conversion to TmosRom


    }
}
