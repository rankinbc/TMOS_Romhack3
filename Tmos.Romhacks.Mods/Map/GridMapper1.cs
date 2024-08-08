using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Map;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.Mods.Utility;
using Tmos.Romhacks.UI.Interfaces;

namespace TMOS_Romhack.Romhacks.Mods.Map
{
    //This class is responsible for generating 2D grid of WorldScreens from the linked Worldscreens
    public class GridMapper1 //: IMapper
    {
        const int MAX_MAP_SIZE_X = 60;
        const int MAX_MAP_SIZE_Y = 60;

        TmosModWorldScreen[] _tmosWorldScreens;
        bool[] _mapIndexUsed;
        private int?[,] _worldScreenIds { get; set; }

        private int?[,] _trimmedWorldScreenIds { get; set; }

        int currentFarthestLeftTilePosition;
        int currentFarthestRightTilePosition;
        int currentFarthestTopTilePosition;
        int currentFarthestBottomTilePosition;

        public GridMapper1(TmosModWorldScreen[] worldScreens)
        {
            _tmosWorldScreens = worldScreens;
            _worldScreenIds = new int?[MAX_MAP_SIZE_X, MAX_MAP_SIZE_Y];

            for (int i = 0; i < _worldScreenIds.GetLength(0); i++)
            {
                for (int j = 0; j < _worldScreenIds.GetLength(1); j++)
                {
                    _worldScreenIds[i, j] = null;
                }
            }

            _mapIndexUsed = new bool[_tmosWorldScreens.Length];



            currentFarthestLeftTilePosition = MAX_MAP_SIZE_X / 2;
            currentFarthestRightTilePosition = MAX_MAP_SIZE_X / 2;
            currentFarthestTopTilePosition = MAX_MAP_SIZE_Y / 2;
            currentFarthestBottomTilePosition = MAX_MAP_SIZE_Y / 2;
        }

        public int?[,] LoadWorldScreenGrid(int absoluteWorldScreenIndex)
        {
            
  
            TmosChapter chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex);

            _mapIndexUsed[absoluteWorldScreenIndex] = true;

            CrawlWorldMap(absoluteWorldScreenIndex, 30, 30, chapter.ChapterNumber);

            _trimmedWorldScreenIds = Utility.TrimArray(_worldScreenIds);
           // _trimmedWorldScreens = Utility.TrimArray(_worldScreens);

            return _trimmedWorldScreenIds;
        }

        //Only reason chapter is passed is to avoid loading chapter from ws every time
        public void CrawlWorldMap(int absoluteWorldScreenIndex, int x, int y, int chapter)
        {

            TmosModWorldScreen worldScreen = _tmosWorldScreens[absoluteWorldScreenIndex];

            //TODO determine how to solve wizard screen issue
          //  TmosChapter chapter = TmosChapterDefinitions.GetChapterOfWorldScreen(absoluteWorldScreenIndex);
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


            _mapIndexUsed[absoluteWorldScreenIndex] = true;
          //  _worldScreens[x, y] = worldScreen;
            _worldScreenIds[x, y] = absoluteWorldScreenIndex;

            int worldScreenNeighborAbsoluteIndex_Right = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexRight);
            int worldScreenNeighborAbsoluteIndex_Left = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexLeft);
            int worldScreenNeighborAbsoluteIndex_Up = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexUp);
            int worldScreenNeighborAbsoluteIndex_Down = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexDown);


            if (worldScreen.ScreenIndexRight < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Right] &&
				_tmosWorldScreens[worldScreenNeighborAbsoluteIndex_Right].ParentWorld == worldScreen.ParentWorld)
            {
                int xRight = x + 1;
                if (currentFarthestRightTilePosition < xRight) currentFarthestRightTilePosition = xRight;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Right, xRight, y, chapter);

            }
            if (worldScreen.ScreenIndexLeft < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Left] &&
				_tmosWorldScreens[worldScreenNeighborAbsoluteIndex_Left].ParentWorld == worldScreen.ParentWorld)
            {
                int xLeft = x - 1;
                if (currentFarthestLeftTilePosition > xLeft) currentFarthestLeftTilePosition = xLeft;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Left, xLeft, y, chapter);

            }
            if (worldScreen.ScreenIndexDown < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Down] &&
				_tmosWorldScreens[worldScreenNeighborAbsoluteIndex_Down].ParentWorld == worldScreen.ParentWorld)
            {
                int yDown = y + 1;
                if (currentFarthestBottomTilePosition < yDown) currentFarthestBottomTilePosition = yDown;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Down, x, yDown, chapter);

            }
            if (worldScreen.ScreenIndexUp < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Up] &&
				_tmosWorldScreens[worldScreenNeighborAbsoluteIndex_Up].ParentWorld == worldScreen.ParentWorld)
            {
                int yUp = y - 1;
                if (currentFarthestTopTilePosition > yUp) currentFarthestTopTilePosition = yUp;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Up, x, yUp, chapter);
            }

        }

       
        public Point GetWorldScreenCoordsFromGrid(int tileX, int tileY)
        {
			// return new Point(tileX, _trimmedWorldScreenIds.GetLength(1) - 1 - tileY);
			return new Point(tileX, tileY);
		}

        //public int? GetWorldScreenRelativeIndexAtPosition(int x, int y)
        //{
        //    if (x >= 0 && x < _trimmedWorldScreenIds.GetLength(0) &&
        //        y >= 0 && y < _trimmedWorldScreenIds.GetLength(1))
        //    {
        //        return _trimmedWorldScreenIds[x, y];
        //    }
        //    return null; // Or any other value to indicate an invalid position
        //}


        public Point GetWorldScreenGridPosition(int absoluteWorldScreenIndex)
        {
            int height = _trimmedWorldScreenIds.GetLength(1);
            for (int i = 0; i < _trimmedWorldScreenIds.GetLength(0); i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (_trimmedWorldScreenIds[i, j] == absoluteWorldScreenIndex)
                    {
						// Return the coordinates with y-flipped
						return new Point(i, j);
						//  return new Point(i, height - 1 - j);
					}
                }
            }
            return new Point(-1, -1);
        }
      
    }
}
