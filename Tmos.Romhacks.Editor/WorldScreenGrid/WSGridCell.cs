using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;

namespace Tmos.Romhacks.Editor.WorldScreenGrid
{
    //A simplified class that represents a WorldScreen in a grid. To be used for laying out arrangement of worldscreens
    public class WSGridCell
    {
        public int? WorldScreenIndex { get; set; }//Hide true WorldScreenIndex until grid is converted back to worldscreen array

       // public TmosModTile[,] Tiles { get; set; }

        private TmosModWorldScreen _worldScreen { get; set; }

        public WSGridCell(int? worldScreenIndex, TmosModWorldScreen worldScreen)
        {
            WorldScreenIndex = worldScreenIndex;
           _worldScreen = worldScreen;
        }
        public TmosModWorldScreen GetWorldScreen()
        {
            return _worldScreen;
        }

		public bool IsEmpty()
        {
            return WorldScreenIndex == null || WorldScreenIndex < 0;

		}
        public static WSGridCell GetEmptyCell()
        {
            return new WSGridCell(null, null);
		}
	}
}
