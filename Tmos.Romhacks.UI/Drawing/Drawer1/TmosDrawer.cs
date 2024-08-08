using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.Map;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using Tmos.Romhacks.Mods.Utility;
using Tmos.Romhacks.UI.Images;
using TMOS_Romhack.Romhacks.Mods.Map;


namespace Tmos.Romhacks.UI.Drawers
{

   

    public class TmosDrawer : ITmosDrawer
    {

        public Font BaseFont { get; set; } = new Font("Arial", 7);
        public Brush BaseBrush { set; get; } = new SolidBrush(Color.Black);

        private static Dictionary<byte, Image> TileImageCache = new Dictionary<byte, Image>();

        public TmosDrawer()
        {
        }

        //public void DrawMap(PictureBox pictureBox, TmosModWorldScreen[] worldScreens, MapDrawOptions drawOptions, int selectedWorldScreenIndex)
        //{
        //    throw new NotImplementedException();
        //}

        public void DrawMap(PictureBox pbSurface, WorldScreenGrid worldScreenGrid, MapDrawOptions options, int selectedWSAbsoluteIndex)
        {

            if (worldScreenGrid == null) { return; }


            Dictionary<int, Rectangle> worldScreenRectangles = new Dictionary<int, Rectangle>();
            Rectangle selectionRectangle = new Rectangle();

            int TILES_Y_COUNT = 6;
            int TILES_X_COUNT = 8;

            using (var g = Graphics.FromImage(pbSurface.Image))
            {
                worldScreenRectangles = DrawWorldMapGrid(worldScreenGrid, options.TileSize);
                foreach (KeyValuePair<int, Rectangle> item in worldScreenRectangles)
                {

                    int wsIndex = item.Key;
                    TmosModWorldScreen ws = worldScreenGrid.WSDictionary[wsIndex];
                    Rectangle rect = item.Value;
                    Brush bgbrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

                    g.FillRectangle(bgbrush, rect);
                    g.DrawRectangle(Pens.LightGreen, rect.X, rect.Y, rect.Width, rect.Height);

                    if (options.TileDrawOptions.ShowImage)
                    {
                       DrawTilesOnMapWS(g, ws, rect, options.TileSize, TILES_X_COUNT, TILES_Y_COUNT, options.TileDrawOptions);
                    }

                    if (options.TileDrawOptions.ShowBorders)
                    {
                        g.DrawRectangle(Pens.Black, rect.Left, rect.Top, rect.Width, rect.Height);
                    }

					Brush contentTextBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
					if (ws.IsBattleScreen())
                    {
                        Brush encScreenBrush = new SolidBrush(Color.FromArgb(110, 255, 0, 210));
                        g.FillRectangle(encScreenBrush, rect);
                    }
                    else if (ws.HasWSWarpContentEntrance())
                    {
						Brush warpContentTextBrush = new SolidBrush(Color.FromArgb(255, 50, 200, 50));
						g.DrawString($"►({ws.WSContent.ContentByteValue.ToString("X2")})", BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
					}
                    else if (ws.HasContentEntrance())
                    {
						g.DrawString(ws.WSContent.ContentByteValue.ToString("X2"), BaseFont, contentTextBrush, rect.Left + 5, rect.Top + 15);
					}

                    if (ws.IsWizardScreen())
                    {
                        Brush wizardScreenBrush = new SolidBrush(Color.FromArgb(40, 40, 40, 40));
                        g.FillRectangle(wizardScreenBrush, rect);
                    }

                    if (options.TileDrawOptions.ShowInfo)
                    {
                        Brush infoTextBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
                        g.DrawString(wsIndex.ToString("X2"), BaseFont, infoTextBrush, rect.Left + 5, rect.Top + 5);


                    }



                    if (selectedWSAbsoluteIndex == wsIndex)
                    {
                        selectionRectangle = rect;
                    }

                }

                if (selectedWSAbsoluteIndex > 0)
                {
                    Brush selectedTileBrush = new SolidBrush(Color.FromArgb(50, 50, 50, 50));
                    g.FillRectangle(selectedTileBrush, selectionRectangle);

                    using (Pen borderPen = new Pen(Color.Lime, 2))
                    {
                        g.DrawRectangle(borderPen, selectionRectangle.X, selectionRectangle.Y, selectionRectangle.Width, selectionRectangle.Height);
                    }
                }
                g.Dispose();
            }
        }



            //}
            // public void DrawMap(PictureBox pbSurface, WorldScreenGrid worldScreenGrid, MapDrawOptions options, int selectedWSAbsoluteIndex)
            //{


                    //            int wsGridIndex = item.Key;

                    //            if (wsGridIndex == -1)
                    //            {
                    //                continue;
                    //            }
                    //            TmosModWorldScreen ws = worldScreenGrid.WSDictionary[wsGridIndex];
                    //            Rectangle rect = item.Value;
                    //            Brush bgbrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

                    //            g.FillRectangle(bgbrush, rect);
                    //            g.DrawRectangle(Pens.LightGreen, rect.X, rect.Y, rect.Width, rect.Height);

                    //            if (options.TileDrawOptions.ShowImage)
                    //            {
                    //                DrawTilesOnMapWS(g, ws, rect, options.TileSize, TILES_X_COUNT, TILES_Y_COUNT, options.TileDrawOptions);
                    //            }

                    //            if (options.TileDrawOptions.ShowBorders)
                    //            {
                    //                g.DrawRectangle(Pens.Black, rect.Left, rect.Top, rect.Width, rect.Height);
                    //            }

                    //            if (ws.IsBattleScreen())
                    //            {
                    //                Brush encScreenBrush = new SolidBrush(Color.FromArgb(110, 255, 0, 210));
                    //                g.FillRectangle(encScreenBrush, rect);
                    //            }
                    //            if (ws.IsWizardScreen())
                    //            {
                    //                Brush wizardScreenBrush = new SolidBrush(Color.FromArgb(40, 40, 40, 40));
                    //                g.FillRectangle(wizardScreenBrush, rect);
                    //            }

                    //            if (options.TileDrawOptions.ShowInfo)
                    //            {
                    //                Brush infoTextBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
                    //                g.DrawString(((int)ws).ToString("X2"), BaseFont, infoTextBrush, rect.Left + 5, rect.Top + 5);
                    //            }

                    //            if (selectedWSAbsoluteIndex == worldScreenGrid.WSDictionary[wsGridIndex])
                    //            {
                    //                selectionRectangle = rect;
                    //            }
                    //        }

                    //        if (selectedWSAbsoluteIndex > 0)
                    //        {
                    //            Brush selectedTileBrush = new SolidBrush(Color.FromArgb(50, 50, 50, 50));
                    //            g.FillRectangle(selectedTileBrush, selectionRectangle);

                    //            using (Pen borderPen = new Pen(Color.Lime, 2))
                    //            {
                    //                g.DrawRectangle(borderPen, selectionRectangle.X, selectionRectangle.Y, selectionRectangle.Width, selectionRectangle.Height);
                    //            }
                    //        }
                    //    }
                    //}

                    private void DrawTilesOnMapWS(Graphics g, TmosModWorldScreen ws, Rectangle rect, int tileSize, int tilesXCount, int tilesYCount, TileDrawOptions options)
        {
            Color groundColor = getWSGroundColor(ws.WorldScreenColor);

            float TILEVIEW_SIZE_X = (float)rect.Width / tilesXCount;
            float TILEVIEW_SIZE_Y = (float)rect.Height / tilesYCount;
    
            for (int y = 0; y < tilesYCount; y++)
            {
                for (int x = 0; x < tilesXCount; x++)
                {
                    TmosModTile tile = ws.GetTileGrid()[x, y];

                    // DrawTile(g, tile, location, tileSize / 20, groundColor, options);

                    //DrawTile
                    Point location = new Point(tileSize * x, tileSize * y);
                    RectangleF tileRect = new RectangleF(rect.Left + (x * TILEVIEW_SIZE_X), rect.Top + (y * TILEVIEW_SIZE_Y), TILEVIEW_SIZE_X, TILEVIEW_SIZE_Y);

                    Brush brush = new SolidBrush(groundColor);
                    g.FillRectangle(brush, tileRect);
                    g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);

                    Image image = GetCachedTileImage(tile.WSTileValue);
                    g.DrawImage(image, tileRect);
                }
            }
        }

        public Dictionary<int, Rectangle> DrawWorldMapGrid(WorldScreenGrid worldScreenGrid, int cellSize)
        {
            Dictionary<int, Rectangle> rects = new Dictionary<int, Rectangle>();

            for (int x = 0; x < worldScreenGrid.GetGrid().GetLength(0); x++)
            {
                for (int y = 0; y < worldScreenGrid.GetGrid().GetLength(1); y++)
                {
					// Flip the y-coordinate
					//  int flippedY = worldScreenGrid.GetGrid().GetLength(1) - 1 - y;
					//int flippedY = worldScreenGrid.GetGrid().GetLength(1) - 1 - y;
					WSGridCell cell = worldScreenGrid.GetCell(x, y);
                    if (cell != null && cell.WorldScreenIndex.HasValue && cell.WorldScreenIndex != -1)
                    {
                        rects.Add(cell.WorldScreenIndex.Value, new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize));
                    }
                }
            }
            return rects;
        }

        //public Dictionary<int, Rectangle> DrawWorldMapGrid(WorldScreenGrid worldScreenGrid, int cellSize)
        //{
        //    Dictionary<int, Rectangle> rects = new Dictionary<int, Rectangle>();

        //    for (int x = 0; x < worldScreenGrid.GetGrid().GetLength(0); x++)
        //    {
        //        for (int y = 0; y < worldScreenGrid.GetGrid().GetLength(1); y++)
        //        {

        //                // Flip the y-coordinate
        //                int flippedY = worldScreenGrid.GetGrid().GetLength(1) - 1 - y; 
        //                if (worldScreenGrid.GetGrid()[x, y].WorldScreenIndex != null)
        //                {
        //                    rects.Add((int)worldScreenGrid.GetCell(x, y).WorldScreenIndex, new Rectangle(x * cellSize, flippedY * cellSize, cellSize, cellSize));
        //                }


        //        }
        //    }
        //    return rects;
        //}



        public void DrawWorldScreen(PictureBox pictureBox, TmosModWorldScreen worldScreen, TmosWorldScreenDrawOptions drawOptions)
        {
            if (worldScreen == null) { return; }
            TmosModTile[,] grid = worldScreen.GetTileGrid();

            Color groundColor = getWSGroundColor(worldScreen.WorldScreenColor);
            using (var g = Graphics.FromImage(pictureBox.Image))
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        byte gridTileValue = grid[x, y].WSTileValue;
                        bool tileIsTopSection = y < 4; //else isBottomSection

                        TmosModTile tile = new TmosModTile(gridTileValue);
                        int relativeDrawPositionX = drawOptions.TileSize * x;
                        int relativeDrawPositionY = drawOptions.TileSize * y;

                        Point location = new Point(relativeDrawPositionX, relativeDrawPositionY);

                        DrawTile(g, tile, location, drawOptions.TileSize, drawOptions.TileSize, groundColor, drawOptions.TileDrawOptions);  
                    }
                }
            }
        }

        public void DrawTile(Graphics g, TmosModTile tmosTile, Point location, int drawSizeX, int drawSizeY, Color groundColor, TileDrawOptions options)
        {
            Size size = new Size(drawSizeX, drawSizeY);
            Rectangle rect = new Rectangle(location, size);

            Brush groundBrush = new SolidBrush(groundColor);
            g.FillRectangle(groundBrush, rect);

            if (tmosTile.WSTileValue != null)
            {
                if (options.ShowImage)
                {
                    Image image = GetCachedTileImage(tmosTile.WSTileValue);
                    g.DrawImage(image, rect);
                }
            }

            if (options.ShowCollision && !tmosTile.IsWalkable())
            {
                Color collisionShadeColor = Color.FromArgb(128, Color.Red);
                SolidBrush collisionShadeBrush = new SolidBrush(collisionShadeColor);
                g.FillRectangle(collisionShadeBrush, rect);
            }

            if (options.ShowInfo)
            {
                g.DrawString(tmosTile.WSTileValue.ToString("X2"), BaseFont, BaseBrush, location.X , location.Y );
            }
        }


        public static Color getWSGroundColor(byte worldScreenColorByteValue)
        {
            Color gr;
            switch (worldScreenColorByteValue.ToString("X2"))
            {
                case "21":
                case "2A":
                case "32":
                case "45":
                    gr = Color.FromArgb(255, 0, 60, 20);        //past
                    break;
                case "30":
                //  case "38":
                case "3B":
                    // gr = Color.FromArgb(255, 36, 24, 140);
                    gr = Color.FromArgb(255, 0, 112, 236);      //water
                    break;
                case "25":
                case "41":
                case "47":
                    gr = Color.FromArgb(255, 252, 228, 160);    //desert
                    break;
                case "1A":
                    gr = Color.FromArgb(255, 0, 80, 0);         //Dark palace
                    break;
                case "3C":
                case "31":
                    //case "34":
                    gr = Color.FromArgb(255, 164, 0, 0);        //red
                    break;
                case "23":
                case "2B":
                case "39":
                    gr = Color.FromArgb(255, 188, 188, 188);    //winter
                    break;
                /*  case "1B":
                      gr = Color.FromArgb(255, 60, 188, 252);     //ice
                      break;*/
                case "11":
                case "27":
                case "43":
                case "44":
                case "4A":
                case "34":
                case "1F":
                case "20":
                    gr = Color.FromArgb(255, 0, 0, 0);          //black
                    break;
                case "1C":
                //case "27":
                //case "31":
                //case "34":
                //case "44":
                case "46":
                case "48":
                    gr = Color.FromArgb(255, 216, 40, 0);       //lava
                    break;
                /* case "1D":
                     gr = Color.FromArgb(255, 68, 0, 156);       //Sabaron's palace
                     break;*/
                default:
                    gr = Color.FromArgb(255, 0, 148, 0);
                    // Console.WriteLine(ws.WorldScreenColor);
                    break;
            }
            return gr;
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

        public void DrawWorldScreen(PictureBox pictureBox, TmosModWorldScreen worldScreen, MapDrawOptions drawOptions, int selectedWorldScreenIndex)
        {
            throw new NotImplementedException();
        }

        public void DrawTileSection()
        {
            throw new NotImplementedException();
        }

        public void DrawTile()
        {
            throw new NotImplementedException();
        }

        public void DrawMiniTile()
        {
            throw new NotImplementedException();
        }

       
    }

    }