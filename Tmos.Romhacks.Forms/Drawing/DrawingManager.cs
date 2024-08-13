using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Forms.Drawers;
using Tmos.Romhacks.Forms.Forms;
using Tmos.Romhacks.Forms.Images;
using Tmos.Romhacks.Editor.WorldScreenGrid;
using Tmos.Romhacks.Forms.Controls;

namespace Tmos.Romhacks.Forms.Drawing
{
	public class DrawingManager
	{
		private ITmosDrawer _drawer;
 
        public DrawingManager(ITmosDrawer drawer)
		{
			_drawer = drawer;
		}

		public void SetDrawOptions()
		{
			
		}

		public TmosWorldScreenDrawOptions GetDrawOptions(bool showBorders, bool showInfo, int tileSize, bool showTileInfo, bool showTileCollision, bool showTileImage)
		{
			return new TmosWorldScreenDrawOptions()
			{
				ShowBorders = showBorders,
				ShowInfo = showInfo,
				TileSize = tileSize,
				TileDrawOptions = new TileDrawOptions()
				{
					ShowInfo = showTileInfo,
					ShowCollision = showTileCollision,
					ShowImage = showTileImage,
					ImageOpacity = 100,
				}
			};
		}

        public void DrawMap(TmosPictureBox pictureBox, WorldAreaGrid wsGrid, int tileSize, TmosWorldScreenDrawOptions wsDrawOptions, FormUserControlState formUserActionState )
		{
			var mapDrawOptions = new MapDrawOptions()
			{
				WorldScreenDrawOptions = wsDrawOptions,
				TileSize = tileSize,
				TileDrawOptions = wsDrawOptions.TileDrawOptions
			};

			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);


			_drawer.DrawMap(pictureBox, wsGrid, mapDrawOptions, formUserActionState);


			pictureBox.Refresh();
			//pictureBox.WorldScreenGrid = wsGrid;
			//pictureBox.DrawOptions = wsDrawOptions;
			//pictureBox.UserControlState = formUserActionState;
			//pictureBox.RefreshDisplay();
		}

		public void DrawWorldScreen(TmosPictureBox pictureBox,TmosModWorldScreen ws, TmosWorldScreenDrawOptions drawOptions)
		{

		//	_drawer.DrawMap(pictureBox, wsGrid, mapDrawOptions, formUserActionState);
			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			_drawer.DrawWorldScreen(pictureBox, ws, drawOptions);
			pictureBox.Refresh();
			//pictureBox.WorldScreen = ws;
			//pictureBox.DrawOptions = drawOptions;
			//pictureBox.RefreshDisplay();
		}
	}
}
