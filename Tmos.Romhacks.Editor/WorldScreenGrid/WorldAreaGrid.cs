using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Library.Utility;

namespace Tmos.Romhacks.Editor.WorldScreenGrid
{
    public class WorldAreaGrid
    {
		private TmosModRom _tmosModRom;
		public Dictionary<int, TmosModWorldScreen> WSDictionary { get; set; }
        private WSGridCell[,] WSGrid { get; set; }
        public WorldAreaGrid(int sizeX, int sizeY, TmosModRom tmosModRom)
        {
			_tmosModRom = tmosModRom;
			WSGrid = new WSGridCell[sizeX, sizeY];
			for (int x = 0; x < WSGrid.GetLength(0); x++)
			{
				for (int y = 0; y < WSGrid.GetLength(1); y++)
				{
					WSGrid[x,y] = WSGridCell.GetEmptyCell();
				}
			}
			WSDictionary = new Dictionary<int, TmosModWorldScreen>();
	//ReloadGrid(worldScreenIndexes, worldScreens);
		}

  //      public void ReloadGrid( int?[,] worldScreenIndexes, TmosModWorldScreen[] worldScreens)
  //      {
		//	WSDictionary = new Dictionary<int, TmosModWorldScreen>();
		//	WSGrid = new WSGridCell[worldScreenIndexes.GetLength(0), worldScreenIndexes.GetLength(1)];
		//	for (int x = 0; x < worldScreenIndexes.GetLength(0); x++)
		//	{
		//		for (int y = 0; y < worldScreenIndexes.GetLength(1); y++)
		//		{
		//			int? wsIndexAtPosition = worldScreenIndexes[x, y];
		//			if (wsIndexAtPosition != null)
		//			{
		//				TmosModWorldScreen ws = worldScreens[(int)wsIndexAtPosition];
		//				WSGrid[x, y] = new WSGridCell(worldScreenIndexes[x, y], ws);
		//				WSDictionary.Add(worldScreenIndexes[x, y].Value, ws);
		//			}
		//		}
		//	}
		//}

		public void SetGridCell(int x, int y, int wsIndex, bool updateNeighborPointers = false)
		{
			TmosModWorldScreen ws = _tmosModRom.RomContent.WorldScreens[wsIndex];
			if (WSDictionary.ContainsKey(wsIndex))
			{
				WSDictionary[wsIndex] = ws;
			}
			else
			{
				WSDictionary.Add(wsIndex, ws);
			}

			Point existingPositionOfScreenIndex = GetGridPositionOfWorldScreen(wsIndex);
			if (existingPositionOfScreenIndex.X == -1 && existingPositionOfScreenIndex.Y == -1)
			{
				WSGrid[x, y] = new WSGridCell(wsIndex, ws);
				UpdateScreenConnections(x, y);
			}
			//else
			//{
			//	WSGrid[existingPositionOfScreenIndex.X, existingPositionOfScreenIndex.Y] = WSGridCell.GetEmptyCell();
			//	UpdateScreenConnections(existingPositionOfScreenIndex.X, existingPositionOfScreenIndex.Y);
			//}
		}

		public int GetGridSizeX()
		{
			return WSGrid.GetLength(0);
		}
		public int GetGridSizeY()
		{
			return WSGrid.GetLength(1);
		}

		public WSGridCell[,] GetGrid()
        {
            return WSGrid;
        }
        public WSGridCell GetCell(int x, int y)
        {
            return WSGrid[x, y];
        }


		public int? GetWorldScreenIndexAtPosition(int gridPositionX, int gridPositionY)
		{
			if (!WSGrid[gridPositionX, gridPositionY].IsEmpty())
			{
				return WSGrid[gridPositionX, gridPositionY].WorldScreenIndex;
			}
			else
			{
				return null;
			}
		}
		public Point GetWorldScreenCoordsFromGrid(int tileX, int tileY)
		{
			return new Point(tileX, tileY);
		}

		public Point GetGridPositionOfWorldScreen(int absoluteWorldScreenIndex)
		{
			int height = WSGrid.GetLength(1);
			for (int i = 0; i < WSGrid.GetLength(0); i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (WSGrid[i, j].WorldScreenIndex == absoluteWorldScreenIndex)
					{
						return new Point(i, j);
					}
				}
			}
			return new Point(-1, -1);
		}

		public void MoveWorldScreen(int sourceX, int sourceY, int destinationX, int destinationY)
		{

			WSGridCell source = WSGrid[sourceX, sourceY];
			WSGridCell dest = WSGrid[destinationX, destinationY];
			//WSGridCell dest = WSGrid[destinationX, destinationY];

			if (!source.IsEmpty())
			{
				WSGrid[destinationX, destinationY] = source;
				UpdateScreenConnections(destinationX, destinationY);
			}

			WSGrid[sourceX, sourceY] = WSGridCell.GetEmptyCell();
			UpdateScreenConnections(sourceX, sourceY);
		}

		//public void SetWorldScreen(int destinationX, int destinationY, byte[] wsContent)
		//{
		//	WSGridCell dest = WSGrid[destinationX, destinationY];
		//	//WSGridCell dest = WSGrid[destinationX, destinationY];

		//	int? index = dest.WorldScreenIndex;

		//	if (index.HasValue)
		//	{
		//		WSGrid[destinationX, destinationY] = new WSGridCell((int)index, new TmosModWorldScreen(wsContent));
		//		UpdateScreenConnections(destinationX, destinationY);
		//	}
		//}

		public void UpdateScreenConnections(int x, int y)
		{
			WSGridCell cell = WSGrid[x, y];
			
			
			WSGridCell cell_left = WSGrid[x - 1, y];
			WSGridCell cell_up= WSGrid[x, y - 1];
			WSGridCell cell_right = WSGrid[x + 1, y];
			WSGridCell cell_down = WSGrid[x, y + 1];

			if (!cell.IsEmpty())
			{
				TmosModWorldScreen ws = _tmosModRom.RomContent.WorldScreens[(int)cell.WorldScreenIndex];
				int chapter = ChapterUtility.GetChapterOfWorldScreen((int)cell.WorldScreenIndex).ChapterNumber;

				byte wsRelativeIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex((int)cell.WorldScreenIndex);

				if (!cell_left.IsEmpty())
				{
					byte cell_left_wsRelativeIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex((int)cell_left.WorldScreenIndex);
					ws.ScreenIndexLeft = cell_left_wsRelativeIndex;
					_tmosModRom.RomContent.WorldScreens[(int)cell_left.WorldScreenIndex].ScreenIndexRight = wsRelativeIndex;
				}
				else
				{
					ws.ScreenIndexLeft = 0xFF;
				}
				if (!cell_right.IsEmpty())
				{
					byte cell_right_wsRelativeIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex((int)cell_right.WorldScreenIndex);
					ws.ScreenIndexRight = cell_right_wsRelativeIndex;
					_tmosModRom.RomContent.WorldScreens[(int)cell_right.WorldScreenIndex].ScreenIndexLeft = wsRelativeIndex;
				}

				else
				{
					ws.ScreenIndexRight = 0xFF;
				}
				if (!cell_up.IsEmpty())
				{
					byte cell_up_wsRelativeIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex((int)cell_up.WorldScreenIndex);
					ws.ScreenIndexUp = cell_up_wsRelativeIndex;
					_tmosModRom.RomContent.WorldScreens[(int)cell_up.WorldScreenIndex].ScreenIndexDown = wsRelativeIndex;
				}
				else
				{
					ws.ScreenIndexUp = 0xFF;
				}
				if (!cell_down.IsEmpty())
				{
					byte cell_down_wsRelativeIndex = WSIndexUtility.GetChapterRelativeWorldScreenIndex((int)cell_down.WorldScreenIndex);
					ws.ScreenIndexDown = cell_down_wsRelativeIndex;
					_tmosModRom.RomContent.WorldScreens[(int)cell_down.WorldScreenIndex].ScreenIndexUp = wsRelativeIndex;
				}
				else
				{
					ws.ScreenIndexDown = 0xFF;
				}
			}
			else
			{
				if (!cell_left.IsEmpty())
				{
					_tmosModRom.RomContent.WorldScreens[(int)cell_left.WorldScreenIndex].ScreenIndexRight = 0xFF;
				}
				if (!cell_right.IsEmpty())
				{
					_tmosModRom.RomContent.WorldScreens[(int)cell_right.WorldScreenIndex].ScreenIndexLeft = 0xFF;
				}
				if (!cell_up.IsEmpty())
				{
					_tmosModRom.RomContent.WorldScreens[(int)cell_up.WorldScreenIndex].ScreenIndexDown = 0xFF;
				}
				if (!cell_down.IsEmpty())
				{
					_tmosModRom.RomContent.WorldScreens[(int)cell_down.WorldScreenIndex].ScreenIndexUp = 0xFF;
				}
			}
		}




	}
}
