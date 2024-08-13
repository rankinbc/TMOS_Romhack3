using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Forms.Forms;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Editor.WorldScreenGrid;

namespace Tmos.Romhacks.Forms.Drawers
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
