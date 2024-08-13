using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Editor.Interfaces;
using Tmos.Romhacks.Editor.WorldScreenGrid;
using Tmos.Romhacks.Library;
using Tmos.Romhacks.Library.Definitions;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Library.LibraryObjects;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Library.Utility;

namespace TMOS_Romhack.Romhacks.Editor.WorldScreenGrid
{
    //This class is responsible for generating 2D grid of WorldScreens from the linked Worldscreens
    public class WSGridGenerator_RecursiveCrawler : IWorldScreenGridGenerator
    {
        const int MAX_MAP_SIZE_X = 60;
        const int MAX_MAP_SIZE_Y = 60;

        private TmosModRom _tmosModRom;
		//TmosModWorldScreen[] _tmosWorldScreens;
        bool[] _mapIndexUsed;
        private int?[,] _fullGrid_WorldScreenIds { get; set; }
        private int?[,] _trimmedGrid_WorldScreenIds { get; set; }

        int currentFarthestLeftTilePosition;
        int currentFarthestRightTilePosition;
        int currentFarthestTopTilePosition;
        int currentFarthestBottomTilePosition;

        public WSGridGenerator_RecursiveCrawler(TmosModRom tmosModRom)
        {
			_tmosModRom= tmosModRom;
            InitializeGrid();
		}

	
		//  _tmosWorldScreens = worldScreens;
		//InitializeGrid();
       // }

        private void InitializeGrid()
        {
			_fullGrid_WorldScreenIds = new int?[MAX_MAP_SIZE_X, MAX_MAP_SIZE_Y];
			for (int x = 0; x < _fullGrid_WorldScreenIds.GetLength(0); x++)
			{
				for (int y = 0; y < _fullGrid_WorldScreenIds.GetLength(1); y++)
				{
					_fullGrid_WorldScreenIds[x, y] = null;
				}
			}

			//_mapIndexUsed = new bool[_tmosWorldScreens.Length];

			currentFarthestLeftTilePosition = MAX_MAP_SIZE_X / 2;
			currentFarthestRightTilePosition = MAX_MAP_SIZE_X / 2;
			currentFarthestTopTilePosition = MAX_MAP_SIZE_Y / 2;
			currentFarthestBottomTilePosition = MAX_MAP_SIZE_Y / 2;
		}

        public int?[,] GenerateWorldScreenGrid(int baseWSIndex)
        {
            InitializeGrid();
			//_tmosWorldScreens = worldScreens;
			_mapIndexUsed = new bool[_tmosModRom.RomContent.WorldScreens.Length];

			TmosChapter chapter = ChapterUtility.GetChapterOfWorldScreen(baseWSIndex);
            _mapIndexUsed[baseWSIndex] = true;

            CrawlWorldMap(baseWSIndex, 30, 30, chapter.ChapterNumber);

            _trimmedGrid_WorldScreenIds = Utility.TrimArray(_fullGrid_WorldScreenIds, 2);
            return _trimmedGrid_WorldScreenIds;
        }

		public WorldAreaGrid LoadWorldScreenGrid(int startWSAbsoluteIndexm)
		{
			int?[,] wsIdGrid = GenerateWorldScreenGrid(startWSAbsoluteIndexm);
            int gridSizeX = wsIdGrid.GetLength(0);
            int gridSizeY = wsIdGrid.GetLength(1);

			WorldAreaGrid worldScreenGrid = new WorldAreaGrid(gridSizeX, gridSizeY, _tmosModRom);
			
			for (int x = 0; x < gridSizeX; x++)
			{
				for (int y = 0; y < gridSizeY; y++)
				{
                    int? wsId = wsIdGrid[x, y];
                    if (wsId != null)
                    {
						TmosModWorldScreen ws = _tmosModRom.RomContent.WorldScreens[(int)wsId];
                        worldScreenGrid.SetGridCell(x, y, (int)wsId);

					}
				}
			}
            return worldScreenGrid;
		}

		//Only reason chapter is passed is to avoid loading chapter from ws every time
		private void CrawlWorldMap(int absoluteWorldScreenIndex, int x, int y, int chapter)
        {
			//TODO determine how to solve wizard screen issue
			//HandleWizardScreen();

			TmosModWorldScreen worldScreenAtCurrentPosition = _tmosModRom.RomContent.WorldScreens[absoluteWorldScreenIndex];

			_mapIndexUsed[absoluteWorldScreenIndex] = true;
            _fullGrid_WorldScreenIds[x, y] = absoluteWorldScreenIndex;

            int worldScreenNeighborAbsoluteIndex_Right = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreenAtCurrentPosition.ScreenIndexRight);
            int worldScreenNeighborAbsoluteIndex_Left = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreenAtCurrentPosition.ScreenIndexLeft);
            int worldScreenNeighborAbsoluteIndex_Up = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreenAtCurrentPosition.ScreenIndexUp);
            int worldScreenNeighborAbsoluteIndex_Down = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreenAtCurrentPosition.ScreenIndexDown);

            bool isolateAreaByParentWorld = true;
            if (!_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Right] && WSNeighborIsSameArea(worldScreenAtCurrentPosition, Direction.Right, worldScreenNeighborAbsoluteIndex_Right, isolateAreaByParentWorld))
            {
                int xRight = x + 1;
                if (currentFarthestRightTilePosition < xRight) currentFarthestRightTilePosition = xRight;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Right, xRight, y, chapter);

            }
            if (!_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Left] && WSNeighborIsSameArea(worldScreenAtCurrentPosition, Direction.Left, worldScreenNeighborAbsoluteIndex_Left, isolateAreaByParentWorld))
            {
                int xLeft = x - 1;
                if (currentFarthestLeftTilePosition > xLeft) currentFarthestLeftTilePosition = xLeft;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Left, xLeft, y, chapter);

            }
            if ( !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Down] && WSNeighborIsSameArea(worldScreenAtCurrentPosition, Direction.Down, worldScreenNeighborAbsoluteIndex_Down, isolateAreaByParentWorld))
            {
                int yDown = y + 1;
                if (currentFarthestBottomTilePosition < yDown) currentFarthestBottomTilePosition = yDown;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Down, x, yDown, chapter);

            }
            if ( !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Up] && WSNeighborIsSameArea(worldScreenAtCurrentPosition, Direction.Up, worldScreenNeighborAbsoluteIndex_Up, isolateAreaByParentWorld))
            {
                int yUp = y - 1;
                if (currentFarthestTopTilePosition > yUp) currentFarthestTopTilePosition = yUp;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Up, x, yUp, chapter);
            }
        }

        private bool WSNeighborIsSameArea(TmosModWorldScreen currentWS, Direction direction, int neighborAbsoluteWSIndex, bool isolateAreaByParentWorld)
        {
			TmosModWorldScreen neighborScreen = _tmosModRom.RomContent.WorldScreens[neighborAbsoluteWSIndex];
            bool includeNeighborInArea =  true;
            if (currentWS.GetNeighborScreenRelativeIndex(direction) >= 0xF0) includeNeighborInArea = false;

            if (isolateAreaByParentWorld)
            {
                if (currentWS.ParentWorld != neighborScreen.ParentWorld) includeNeighborInArea = false;
			}
            return includeNeighborInArea;
		}

        private void HandleWizardScreen()
        {
            throw new NotImplementedException("Wizard Screens have not been handled yet");
			/*  if (worldScreen.IsWizardScreen())
	   {
		   _mapIndexUsed[currentScreenIndex] = true;
		   WorldScreen wizardExitScreen;
		   if (worldScreen.ScreenIndexRight != 0xFF)
		   {
			   wizardExitScreen = _worldScreenCollection.OriginalWorldScreens[worldScreen.ScreenIndexRight];
			   LoadWorldMap(worldScreen.ScreenIndexRight, x , y);
		   }
		   else if(worldScreen.ScreenIndexLeft != 0xFF)
		   {
			   wizardExitScreen = _worldScreenCollection.OriginalWorldScreens[worldScreen.ScreenIndexRight];
			   LoadWorldMap(worldScreen.ScreenIndexLeft, x, y);
		   }
		   else if (worldScreen.ScreenIndexDown != 0xFF)
		   {
			   LoadWorldMap(worldScreen.ScreenIndexDown, x, y);
		   }
		   else if (worldScreen.ScreenIndexUp != 0xFF)
		   {
			   LoadWorldMap(worldScreen.ScreenIndexUp, x, y);
		   }
		   return;
	   }*/
		}


	}
}
