using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Map;
using Tmos.Romhacks.UI.Drawers;
using Tmos.Romhacks.UI.Images;
using Tmos.Romhacks.UI.Interfaces;
using TMOS_Romhack.Romhacks.Mods.Map;

namespace Tmos.Romhacks.UI.Drawing
{
	public class DrawingManager
	{
		private ITmosDrawer _drawer;
		//private IMapper _mapper;
		//private GridMapper1 _mapper;

		//private TmosModRom _tmosMod;


      
        public DrawingManager(ITmosDrawer drawer)
		{
			_drawer = drawer;
			//_mapper = new GridMapper1();
			//_tmosMod = tmosMod;
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

       

        public void DrawMap(PictureBox pictureBox, WorldScreenGrid wsGrid, int tileSize, TmosWorldScreenDrawOptions wsDrawOptions, int selectedWorldScreenIndex)
		{



            var mapDrawOptions = new MapDrawOptions()
			{
				WorldScreenDrawOptions = wsDrawOptions,
				TileSize = tileSize,
				TileDrawOptions = wsDrawOptions.TileDrawOptions
			};

            //Map = new GridMapper1(worldScreens);

            //Map.LoadWorldScreenGrid(selectedWSAbsoluteIndex, 30, 30);

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);


			_drawer.DrawMap(pictureBox,wsGrid, mapDrawOptions, selectedWorldScreenIndex);
			pictureBox.Refresh();
		}

		public void DrawWorldScreen(PictureBox pictureBox,TmosModWorldScreen ws, TmosWorldScreenDrawOptions drawOptions)
		{
			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			_drawer.DrawWorldScreen(pictureBox, ws, drawOptions);
			pictureBox.Refresh();
		}
	}
}
