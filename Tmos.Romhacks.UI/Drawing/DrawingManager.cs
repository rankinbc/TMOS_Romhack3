using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.UI.Drawers;

namespace Tmos.Romhacks.UI.Drawing
{
	public class DrawingManager
	{
		private TmosDrawer _drawer;
		private TmosModRom _tmosMod;

		public DrawingManager(TmosDrawer drawer, TmosModRom tmosMod)
		{
			_drawer = drawer;
			_tmosMod = tmosMod;
		}

		public void SetDrawOptions()
		{
			_drawer.BaseBrush = Pens.Black.Brush;
			_drawer.BaseFont = new Font("Arial", 7);
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

		public void DrawMap(PictureBox pictureBox, int tileSize, TmosWorldScreenDrawOptions wsDrawOptions, int selectedWorldScreenIndex)
		{
			var mapDrawOptions = new MapDrawOptions()
			{
				WorldScreenDrawOptions = wsDrawOptions,
				TileSize = tileSize,
				TileDrawOptions = wsDrawOptions.TileDrawOptions
			};

			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			_drawer.DrawMap(pictureBox, _tmosMod.GetTmosModWorldScreens(false), mapDrawOptions, selectedWorldScreenIndex);
			pictureBox.Refresh();
		}

		public void DrawWorldScreen(PictureBox pictureBox, int selectedWorldScreenIndex, TmosWorldScreenDrawOptions drawOptions)
		{
			TmosModWorldScreen currentWS = _tmosMod.GetTmosModWorldScreen(selectedWorldScreenIndex);
			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			_drawer.DrawWorldScreen(pictureBox, currentWS, drawOptions, selectedWorldScreenIndex);
			pictureBox.Refresh();
		}
	}
}
