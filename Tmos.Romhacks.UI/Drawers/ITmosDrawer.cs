using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using static Tmos.Romhacks.Mods.TmosModWorldScreen;

namespace Tmos.Romhacks.UI.Drawers
{
	public interface ITmosDrawer
	{
		void DrawMap();

		void DrawWorldScreen();

		void DrawTileSection();

		void DrawTile();

		void DrawMiniTile();
	}
}
