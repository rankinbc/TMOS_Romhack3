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
        public TmosTile[] Tiles { get; set; }
        public TmosMiniTile[] MiniTiles { get; set; }
        public TmosRandomEncounterGroup[] RandomEncounterGroups { get; set; }
        public TmosRandomEncounterLineup[] RandomEncounterLineups { get; set; }

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


        public TmosModWorldScreen RefreshWorldScreen(TmosModWorldScreen ws )
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
            (int topTileDataOffset, int bottomTileDataOffset) = GetTileDataOffsets(tmosWorldScreen.DataPointer);
            tmosWorldScreen.TileSectionTop = _romData.LoadTileSection(tmosWorldScreen.TopTiles, topTileDataOffset);
            tmosWorldScreen.TileSectionBottom = _romData.LoadTileSection(tmosWorldScreen.BottomTiles, bottomTileDataOffset);
        }

    
        public static (int topTileDataOffset, int bottomTileDataOffset) GetTileDataOffsets(byte dataPointer)
        {
            int bottomTileDataOffset = 0;
            int topTileDataOffset = 0;
            if (dataPointer >= 0x40 && dataPointer < 0x8f)
            {
                bottomTileDataOffset = 0x2000; //0x2000 = 8192     8192 / 32 = 256  Maybe this dataoffset just increases index 0 by 256 TileSections?
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
            return (topTileDataOffset, bottomTileDataOffset);
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

        public TmosModWorldScreen GetTmosModWorldScreen(int absoluteWorldScreenIndex)
        {
            TmosModWorldScreen ws = _worldScreens[absoluteWorldScreenIndex];
            int chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex).ChapterNumber;
            LoadWorldScreenContent(ws, chapter);
            LoadWorldScreenTileGrid(ws);

            return ws;
        }

        public void UpdateTmosModWorldScreen(int worldScreenIndex, TmosModWorldScreen tmosModWorldScreen)
        {
            LoadWorldScreenContent(tmosModWorldScreen);
            LoadWorldScreenTileGrid(tmosModWorldScreen);

            _worldScreens[worldScreenIndex] = tmosModWorldScreen;
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

        public static int GetTmosWorldScreenChapterIndex(int absoluteWorldScreenIndex)
        {
            TmosChapter chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex);
            List<TmosChapter> chapters = TmosChapterDefinitions.GetTmosChapters();


            int adjustedWorldScreenIndex = absoluteWorldScreenIndex;
            for (int i = 0; i < chapter.ChapterNumber; i++)
            {
                adjustedWorldScreenIndex -= ChapterUtility.CalculateWorldScreenCount(chapters[i], chapters);
            }
            int chapterRelativeWorldScreenIndex = absoluteWorldScreenIndex - adjustedWorldScreenIndex;
            return chapterRelativeWorldScreenIndex;
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
            return GetTmosModTileSectionAbsoluteIndex(ws.TopTiles, ws.DataPointer, true);
        }
        public int GetWSTileSectionBottomAbsoluteIndex(int worldScreenAbsoluteIndex)
        {
            TmosModWorldScreen ws = _worldScreens[worldScreenAbsoluteIndex];
            return GetTmosModTileSectionAbsoluteIndex(ws.BottomTiles, ws.DataPointer, false);
        }

        public int GetTmosModTileSectionAbsoluteIndex(int tileSectionRelativeIndex, byte dataPointer, bool isTopTileSection)
        {
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.TileSection);
            (int topTileDataOffset, int bottomTileDataOffset) = GetTileDataOffsets(dataPointer);

            int startAbsoluteIndex = 0;
            if (isTopTileSection)
            {
                int objectOffsetFromBeginningOfArray = (def.ObjectSize * tileSectionRelativeIndex) + topTileDataOffset;
                startAbsoluteIndex = objectOffsetFromBeginningOfArray / def.ObjectSize;
            }
            else
            {
                int objectOffsetFromBeginningOfArray = (def.ObjectSize * tileSectionRelativeIndex) + bottomTileDataOffset;
                startAbsoluteIndex = objectOffsetFromBeginningOfArray / def.ObjectSize;
            }
            return startAbsoluteIndex;
        }
        public void UpdateTmosModTileSection(int tileSectionIndex, byte[] tileSectionData)
        {
            TileSections[tileSectionIndex].UpdateBytes(tileSectionData);
            //Calculate offset??
            _romData.SaveTileSection(tileSectionIndex, 0, tileSectionData);
            //WorldScreens that have this tile section need to reload their tile grids
            //For now reloading all

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
            Tiles = new TmosTile[def.Count];

            for (int i = 0; i < Tiles.Length; i++)
            {
                TmosTile tmosTile = tmosRom.LoadTile(i);
                Tiles[i] = tmosTile;
            }
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

        #endregion TmosRandomEncounterLineups



    
    }
}
