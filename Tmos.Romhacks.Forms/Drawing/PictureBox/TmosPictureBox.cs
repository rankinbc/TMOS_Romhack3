using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tmos.Romhacks.Editor.WorldScreenGrid;
using Tmos.Romhacks.Forms.Drawers;
using Tmos.Romhacks.Forms.Forms;
using Tmos.Romhacks.Forms.Images;
using Tmos.Romhacks.Library.RomObjects.Tiles;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using static System.Windows.Forms.Design.AxImporter;

namespace Tmos.Romhacks.Forms.Controls
{
#pragma warning disable CA1416 // Validate platform compatibility
	public class TmosPictureBox : PictureBox
	{
		public TmosModWorldScreen WorldScreen { get; set; }
		public WorldAreaGrid WorldScreenGrid { get; set; }
		public TmosWorldScreenDrawOptions DrawOptions { get; set; }
		public FormUserControlState UserControlState { get; set; }

		private static Dictionary<byte, Image> TileImageCache = new Dictionary<byte, Image>();
		private Font BaseFont = new Font("Arial", 7);
		private Brush BaseBrush = new SolidBrush(Color.Black);

		public TmosPictureBox()
		{
			this.DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (WorldScreenGrid != null)
			{
				DrawMap(e.Graphics);
			}
			else if (WorldScreen != null)
			{
				DrawWorldScreen(e.Graphics);
			}
		}

		private void DrawMap(Graphics g)
		{

			if (WorldScreenGrid == null) { return; }


			Dictionary<Point, Rectangle> worldScreenRectangles = new Dictionary<Point, Rectangle>();
			Rectangle selectionRectangle = new Rectangle();

			int TILES_Y_COUNT = 6;
			int TILES_X_COUNT = 8;

			using (var graphics = Graphics.FromImage(Image))
			{
				//   worldScreenRectangles = DrawWorldMapGrid(worldScreenGrid, options.TileSize);

				for (int x = 0; x < WorldScreenGrid.GetGrid().GetLength(0); x++)
				{
					for (int y = 0; y < WorldScreenGrid.GetGrid().GetLength(1); y++)
					{
						WSGridCell gridCell = WorldScreenGrid.GetCell(x, y);
						TmosModWorldScreen ws = gridCell.GetWorldScreen();
						Point point = new Point(x, y);
						Rectangle rect = new Rectangle(x * DrawOptions.TileSize, y * DrawOptions.TileSize, DrawOptions.TileSize, DrawOptions.TileSize);
						Brush bgbrush = new SolidBrush(Color.FromArgb(255, 50, 50, 50));

						//if (gridCell != null && gridCell.WorldScreenIndex.HasValue && gridCell.WorldScreenIndex != -1)
						if (gridCell.IsEmpty())
						{
							//Empty cell
							graphics.FillRectangle(bgbrush, rect);
							graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
						}
						else
						{
							//Draw WS
							if (DrawOptions.TileDrawOptions.ShowImage)
							{
								DrawTilesOnMapWS(graphics, ws, rect, DrawOptions.TileSize, TILES_X_COUNT, TILES_Y_COUNT, DrawOptions.TileDrawOptions);
							}

							if (DrawOptions.TileDrawOptions.ShowBorders)
							{
								graphics.DrawRectangle(Pens.Black, rect.Left, rect.Top, rect.Width, rect.Height);
							}

							Brush contentTextBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
							if (ws.IsBattleScreen())
							{
								Brush encScreenBrush = new SolidBrush(Color.FromArgb(110, 255, 0, 210));
								graphics.FillRectangle(encScreenBrush, rect);
							}
							else if (ws.HasWSWarpContentEntrance())
							{
								Brush warpContentTextBrush = new SolidBrush(Color.FromArgb(255, 50, 200, 50));
								graphics.DrawString($"►({ws.WSContent.ContentByteValue.ToString("X2")})", BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
							}
							else if (ws.HasContentEntrance())
							{
								graphics.DrawString(ws.WSContent.ContentByteValue.ToString("X2"), BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
							}

							if (ws.IsWizardScreen())
							{
								Brush wizardScreenBrush = new SolidBrush(Color.FromArgb(40, 40, 40, 40));
								graphics.FillRectangle(wizardScreenBrush, rect);
							}

							if (DrawOptions.TileDrawOptions.ShowInfo)
							{
								Brush infoTextBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
								graphics.DrawString(((int)gridCell.WorldScreenIndex).ToString("X2"), BaseFont, infoTextBrush, rect.Left + 5, rect.Top + 5);
							}
						}

						//Draw selection
						if (UserControlState.SelectedWorldMapGridCell == point)
						{
							selectionRectangle = rect;
						}
					}
				}

				DrawSelections(graphics, selectionRectangle);
				
			}
		}



		private void DrawWorldScreen(Graphics g)
		{
			if (WorldScreen == null || DrawOptions == null) return;

			TmosModTile[,] grid = WorldScreen.GetTileGrid();
			Color groundColor = WorldScreen.GetGroundColor();

			for (int y = 0; y < 6; y++)
			{
				for (int x = 0; x < 8; x++)
				{
					TmosModTile tile = grid[x, y];
					Point location = new Point(DrawOptions.TileSize * x, DrawOptions.TileSize * y);

					DrawTile(g, tile, location, DrawOptions.TileSize, DrawOptions.TileSize, groundColor, DrawOptions.TileDrawOptions);
				}
			}
		}

		private void DrawTilesOnMapWS(Graphics g, TmosModWorldScreen ws, Rectangle rect, int tileSize, int tilesXCount, int tilesYCount, TileDrawOptions options)
		{
			Color groundColor = ws.GetGroundColor();

			float TILEVIEW_SIZE_X = (float)rect.Width / tilesXCount;
			float TILEVIEW_SIZE_Y = (float)rect.Height / tilesYCount;

			for (int y = 0; y < tilesYCount; y++)
			{
				for (int x = 0; x < tilesXCount; x++)
				{
					TmosModTile tile = ws.GetTileGrid()[x, y];
					RectangleF tileRect = new RectangleF(rect.Left + (x * TILEVIEW_SIZE_X), rect.Top + (y * TILEVIEW_SIZE_Y), TILEVIEW_SIZE_X, TILEVIEW_SIZE_Y);

					Brush brush = new SolidBrush(groundColor);
					g.FillRectangle(brush, tileRect);
					g.DrawRectangle(Pens.Black, tileRect.X, tileRect.Y, tileRect.Width, tileRect.Height);

					Image image = GetCachedTileImage(tile.WSTileValue);
					g.DrawImage(image, tileRect);
				}
			}
		}

		private void DrawTile(Graphics g, TmosModTile tmosTile, Point location, int drawSizeX, int drawSizeY, Color groundColor, TileDrawOptions options)
		{
			Rectangle rect = new Rectangle(location, new Size(drawSizeX, drawSizeY));

			g.FillRectangle(new SolidBrush(groundColor), rect);

			if (tmosTile.WSTileValue != null && options.ShowImage)
			{
				Image image = GetCachedTileImage(tmosTile.WSTileValue);
				g.DrawImage(image, rect);
			}

			if (options.ShowCollision && !tmosTile.IsWalkable())
			{

				g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Red)), rect);

			}

			if (options.ShowInfo)
			{
				g.DrawString(tmosTile.WSTileValue.ToString("X2"), BaseFont, BaseBrush, location.X, location.Y);
			}
		}

		private void DrawWorldScreenInfo(Graphics g, WSGridCell gridCell, Rectangle rect)
		{
			Brush contentTextBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
			TmosModWorldScreen ws = gridCell.GetWorldScreen();
			if (ws.IsBattleScreen())
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(110, 255, 0, 210)), rect);
			}
			else if (ws.HasWSWarpContentEntrance())
			{
				g.DrawString($"►({ws.WSContent.ContentByteValue.ToString("X2")})", BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
			}
			else if (ws.HasContentEntrance())
			{
				g.DrawString(ws.WSContent.ContentByteValue.ToString("X2"), BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
			}

			if (ws.IsWizardScreen())
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40, 40)), rect);
			}

			if (DrawOptions.TileDrawOptions.ShowInfo)
			{
				g.DrawString(((int)gridCell.WorldScreenIndex).ToString("X2"), BaseFont, new SolidBrush(Color.White), rect.Left + 5, rect.Top + 5);
			}
		}

		private void DrawSelections(Graphics g, Rectangle selectionRectangle)
		{
			Pen pen;
			Brush brush;

			if (UserControlState.CurrentUserAction == FormUserActionState.MovingWorldScreen)
			{
				pen = new Pen(Color.Yellow, 3);
				brush = new SolidBrush(Color.FromArgb(50, 200, 200, 200));
			}
			else
			{
				pen = new Pen(Color.Lime, 3);
				brush = new SolidBrush(Color.FromArgb(50, 50, 50, 50));
			}

			g.FillRectangle(brush, selectionRectangle);
			g.DrawRectangle(pen, selectionRectangle);

			pen.Dispose();
			brush.Dispose();
		}

		private static Image GetCachedTileImage(byte tileValue)
		{
			if (!TileImageCache.TryGetValue(tileValue, out Image image))
			{
				string imagePath = ImageFileManager.GetTileImagePath(tileValue);
				image = new Bitmap(imagePath);
				TileImageCache[tileValue] = image;
			}
			return image;
		}

		public void RefreshDisplay()
		{
			this.Invalidate();
		}
	}
}
#pragma warning restore CA1416 // Validate platform compatibility