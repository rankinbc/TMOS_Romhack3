using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Mods.Map
{
	//An IWorldScreenGridGenerator is responsible for generating 2D grid of WorldScreens from the linked Worldscreens
	public interface IWorldScreenGridGenerator
	{
		int?[,] GenerateWorldScreenGrid(int startWSAbsoluteIndex, TmosModWorldScreen[] worldScreenData);

		WorldAreaGrid LoadWorldScreenGrid(int startWSAbsoluteIndexm, TmosModWorldScreen[] worldScreenData);
	}
}
