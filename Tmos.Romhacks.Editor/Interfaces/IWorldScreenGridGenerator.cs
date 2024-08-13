using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Editor.WorldScreenGrid;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;

namespace Tmos.Romhacks.Editor.Interfaces
{
    //An IWorldScreenGridGenerator is responsible for generating 2D grid of WorldScreens from the linked Worldscreens
    public interface IWorldScreenGridGenerator
    {
        int?[,] GenerateWorldScreenGrid(int startWSAbsoluteIndex);

        WorldAreaGrid LoadWorldScreenGrid(int startWSAbsoluteIndexm);
    }
}
