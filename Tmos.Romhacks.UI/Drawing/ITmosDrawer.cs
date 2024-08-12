using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Map;
using Tmos.Romhacks.UI.Forms;
using static Tmos.Romhacks.Mods.TmosModWorldScreen;

namespace Tmos.Romhacks.UI.Drawers
{
	public interface ITmosDrawer
	{
        void DrawMap(PictureBox pictureBox, WorldAreaGrid worldScreenGrid, MapDrawOptions drawOptions, FormUserControlState userControlState);

        void DrawWorldScreen(PictureBox pictureBox, TmosModWorldScreen worldScreen, TmosWorldScreenDrawOptions drawOptions);

        void DrawTileSection();

		void DrawTile();

		void DrawMiniTile();
	}
}
