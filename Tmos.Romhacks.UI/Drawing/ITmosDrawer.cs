using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Map;
using static Tmos.Romhacks.Mods.TmosModWorldScreen;

namespace Tmos.Romhacks.UI.Drawers
{
	public interface ITmosDrawer
	{
        void DrawMap(PictureBox pictureBox, WorldScreenGrid worldScreenGrid, MapDrawOptions drawOptions, int selectedWorldScreenIndex);

        void DrawWorldScreen(PictureBox pictureBox, TmosModWorldScreen worldScreen, TmosWorldScreenDrawOptions drawOptions);

        void DrawTileSection();

		void DrawTile();

		void DrawMiniTile();
	}
}
