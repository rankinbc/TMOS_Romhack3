using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;

namespace Tmos.Romhacks.Mods.Map
{
    public class WorldScreenGrid
    {
        public Dictionary<int, TmosModWorldScreen> WSDictionary { get; set; }
        private WSGridCell[,] WSGrid {  get; set; }
        public WorldScreenGrid(int?[,] worldScreenIndexes, TmosModWorldScreen[] worldScreens)
        {
            WSDictionary = new Dictionary<int, TmosModWorldScreen>();
            WSGrid = new WSGridCell[worldScreenIndexes.GetLength(0), worldScreenIndexes.GetLength(1)];
            for (int x = 0; x < worldScreenIndexes.GetLength(0); x++)
            {
                for (int y = 0; y < worldScreenIndexes.GetLength(1); y++)
                {
                    if (worldScreenIndexes[x, y] != null && worldScreenIndexes[x, y] > -1)
                    {

                        TmosModWorldScreen ws = worldScreens[(int)worldScreenIndexes[x, y]];
                        WSGrid[x, y] = new WSGridCell(worldScreenIndexes[x, y], ws);
                        WSDictionary.Add(worldScreenIndexes[x,y].Value, ws);
                    }
                    else
                    {
                        WSGrid[x, y] = new WSGridCell(null, null);
                        continue;
                      
                    }   

                }
            }
        }

        public void ReloadGrid( int?[,] worldScreenIndexes, TmosModWorldScreen[] worldScreens)
        {
            WSGrid = new WSGridCell[worldScreenIndexes.GetLength(0), worldScreenIndexes.GetLength(1)];
            for (int x = 0; x < worldScreenIndexes.GetLength(0); x++)
            {
                for (int y = 0; y < worldScreenIndexes.GetLength(1); y++)
                {
                    if (worldScreenIndexes[x, y] != null && worldScreenIndexes[x, y] > -1)
                    {
                        TmosModWorldScreen ws = worldScreens[(int)worldScreenIndexes[x, y]];
                        WSGrid[x, y] = new WSGridCell(worldScreenIndexes[x, y], ws);
                    }
                    else
                    {
                        WSGrid[x, y] = new WSGridCell(null, null);
                        continue;

                    }

                }
            }

        }

        public WSGridCell[,] GetGrid()
        {
            return WSGrid;
        }
        public WSGridCell GetCell(int x, int y)
        {
            return WSGrid[x, y];
        }
    }
}
