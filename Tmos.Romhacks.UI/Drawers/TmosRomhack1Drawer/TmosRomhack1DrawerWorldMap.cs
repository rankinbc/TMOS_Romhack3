using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.Mods.Utility;

namespace TMOS_Romhack.DataViewer
{
    public class TmosRomhack1DrawerWorldMap
    {
        const int MAX_MAP_SIZE_X = 60;
        const int MAX_MAP_SIZE_Y = 60;

        TmosModWorldScreen[] _worldScreenCollection;
        bool[] _mapIndexUsed;
        public TmosModWorldScreen[,] _worldScreens { get; set; }
        public int[,] _worldScreenIds { get; set; }


        public TmosModWorldScreen[,] _trimmedWorldScreens { get; private set; }
        public int[,] _trimmedWorldScreenIds { get; private set; }

        int currentFarthestLeftTilePosition;
        int currentFarthestRightTilePosition;
        int currentFarthestTopTilePosition;
        int currentFarthestBottomTilePosition;

        public TmosRomhack1DrawerWorldMap(TmosModWorldScreen[] worldScreens )
        {
            _worldScreenCollection = worldScreens;

            InitalizeData();
        }

        public void InitalizeData()
        {
            _worldScreens = new TmosModWorldScreen[MAX_MAP_SIZE_X, MAX_MAP_SIZE_Y];
            _worldScreenIds = new int[MAX_MAP_SIZE_X, MAX_MAP_SIZE_Y];
            _mapIndexUsed = new bool[_worldScreenCollection.Length];

            currentFarthestLeftTilePosition = MAX_MAP_SIZE_X / 2;
            currentFarthestRightTilePosition = MAX_MAP_SIZE_X / 2;
            currentFarthestTopTilePosition = MAX_MAP_SIZE_Y / 2;
            currentFarthestBottomTilePosition = MAX_MAP_SIZE_Y / 2;
        }

        public void LoadWorldMap(int absoluteWorldScreenIndex, int x, int y)
        {
            TmosModWorldScreen rootWorldScreen = _worldScreenCollection?[absoluteWorldScreenIndex];
            TmosChapter chapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex);

            _mapIndexUsed[absoluteWorldScreenIndex] = true;

            CrawlWorldMap(absoluteWorldScreenIndex, x, y, chapter.ChapterNumber);

            TrimArrays();
        }

        //Only reason chapter is passed is to avoid loading chapter from ws every time
        public void CrawlWorldMap(int absoluteWorldScreenIndex, int x, int y, int chapter)
        {

            TmosModWorldScreen worldScreen = _worldScreenCollection?[absoluteWorldScreenIndex];
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
           // _parentForm.lv_worldScreens.Items[currentScreenIndex].ForeColor = Color.Green;
            _worldScreens[x, y] = worldScreen;
            _worldScreenIds[x, y] = absoluteWorldScreenIndex;

            int worldScreenNeighborAbsoluteIndex_Right = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexRight);
            int worldScreenNeighborAbsoluteIndex_Left = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexLeft);
            int worldScreenNeighborAbsoluteIndex_Up = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexUp);
            int worldScreenNeighborAbsoluteIndex_Down = WSIndexUtility.GetAbsoluteWorldScreenIndex(chapter, worldScreen.ScreenIndexDown);


            if (worldScreen.ScreenIndexRight < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Right] &&
                _worldScreenCollection[worldScreenNeighborAbsoluteIndex_Right].ParentWorld == worldScreen.ParentWorld)
            {
                int xRight = x + 1;
                if (currentFarthestRightTilePosition < xRight) currentFarthestRightTilePosition = xRight;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Right, xRight, y, chapter);

            }
            if (worldScreen.ScreenIndexLeft < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Left] &&
                _worldScreenCollection[worldScreenNeighborAbsoluteIndex_Left].ParentWorld == worldScreen.ParentWorld)
            {
                int xLeft = x - 1;
                if (currentFarthestLeftTilePosition > xLeft) currentFarthestLeftTilePosition = xLeft;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Left, xLeft, y, chapter);

            }
            if (worldScreen.ScreenIndexDown < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Down] &&
                _worldScreenCollection[worldScreenNeighborAbsoluteIndex_Down].ParentWorld == worldScreen.ParentWorld)
            {
                int yDown = y - 1;
                if (currentFarthestBottomTilePosition > yDown) currentFarthestBottomTilePosition = yDown;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Down, x, yDown, chapter);

            }
            if (worldScreen.ScreenIndexUp < 0xF0 && !_mapIndexUsed[worldScreenNeighborAbsoluteIndex_Up] &&
                _worldScreenCollection[worldScreenNeighborAbsoluteIndex_Up].ParentWorld == worldScreen.ParentWorld)
            {
                int yUp = y + 1;
                if (currentFarthestTopTilePosition < yUp) currentFarthestTopTilePosition = yUp;
                CrawlWorldMap(worldScreenNeighborAbsoluteIndex_Up, x, yUp, chapter);

            }

        }

        private void TrimArrays()
        {
            _trimmedWorldScreenIds = TrimArray(_worldScreenIds);
            _trimmedWorldScreens = TrimArray(_worldScreens);
        }

        public Dictionary<int, Rectangle> DrawWorldMapGrid(int tileSizeX, int tileSizeY)
        {
            Dictionary<int, Rectangle> rects = new Dictionary<int, Rectangle>();
            int height = _trimmedWorldScreens.GetLength(1);

            for (int x = 0; x < _trimmedWorldScreens.GetLength(0); x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (_trimmedWorldScreens[x, y] != null)
                    {
                        // Flip the y-coordinate
                        int flippedY = height - 1 - y;
                        rects.Add(_trimmedWorldScreenIds[x, y], new Rectangle(x * tileSizeX, flippedY * tileSizeY, tileSizeX, tileSizeY));
                    }
                }
            }
            return rects;
        }
        public Point GetWorldScreenCoordsFromGrid(int tileX, int tileY)
        {
            return new Point(tileX, _trimmedWorldScreens.GetLength(1) - 1 - tileY);
        }

        public int GetWorldScreenRelativeIndexAtPosition(int x, int y)
        {
            if (x >= 0 && x < _trimmedWorldScreenIds.GetLength(0) &&
                y >= 0 && y < _trimmedWorldScreenIds.GetLength(1))
            {
                return _trimmedWorldScreenIds[x, y];
            }
            return -1; // Or any other value to indicate an invalid position
        }


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
                        return new Point(i, height - 1 - j);
                    }
                }
            }
            return new Point(-1, -1);
        }
        public static T[,] TrimArray<T>(T[,] originalArray)
        {
            int rows = originalArray.GetLength(0);
            int cols = originalArray.GetLength(1);

            int minRow = rows, maxRow = 0, minCol = cols, maxCol = 0;
            bool found = false;

            // Find the bounds of the non-null data
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!Equals(originalArray[i, j], default(T)))
                    {
                        if (i < minRow) minRow = i;
                        if (i > maxRow) maxRow = i;
                        if (j < minCol) minCol = j;
                        if (j > maxCol) maxCol = j;
                        found = true;
                    }
                }
            }

            // If no non-null elements were found, return an empty array
            if (!found)
            {
                return new T[0, 0];
            }

            // Determine the size of the new array
            int newRows = maxRow - minRow + 1;
            int newCols = maxCol - minCol + 1;

            // Create the new trimmed array
            T[,] trimmedArray = new T[newRows, newCols];

            // Copy the data to the new array
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newCols; j++)
                {
                    trimmedArray[i, j] = originalArray[minRow + i, minCol + j];
                }
            }

            return trimmedArray;
        }
    }
}
