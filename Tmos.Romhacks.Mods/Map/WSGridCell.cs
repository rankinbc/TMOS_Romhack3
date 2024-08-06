using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.TypedTmosObjects;

namespace Tmos.Romhacks.Mods.Map
{
    //A simplified class that represents a WorldScreen in a grid. To be used for laying out arrangement of worldscreens
    public class WSGridCell
    {
        public int? WorldScreenIndex { get; set; }//Hide true WorldScreenIndex until grid is converted back to worldscreen array

        public TmosModTile[,] Tiles { get; set; }

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

    }
}
