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
using Tmos.Romhacks.Mods.TypedTmosObjects;
using TMOS_Romhack.DataViewer;

namespace Tmos.Romhacks.UI.Drawers
{
    public class TmosDrawer
    {
        public class MapDrawOptions
        {
           public int TileSize { get; set; }
            public TmosWorldScreenDrawOptions WorldScreenDrawOptions { get; set; }
            public TileDrawOptions TileDrawOptions { get; set; }
        }
        public class TmosWorldScreenDrawOptions 
        {
            public bool ShowInfo { get; set; }

            public bool ShowBorders { get; set; }
            public bool ShowTileImages { get; set; }
            public int TileSize { get; set; }
            public Font BaseFont { get; set; }
            public Brush BaseBrush { get; set; }
            public TileDrawOptions TileDrawOptions { get; set; }

        }
        public class TileDrawOptions
        {
            public bool ShowCollision { get; set; }
            public bool ShowImage { get; set; }
            public int ImageOpacity { get; set; }
            public bool ShowInfo { get; set; }
            public Font BaseFont { get; set; }
            public Brush BaseBrush { get; set; }
        }

        public static TmosWorldScreenDrawOptions GetDefaultDrawOptions()
        {
            Font font = new Font("Arial", 7);
            Brush brush = Pens.Black.Brush;
            return new TmosWorldScreenDrawOptions()
            {
                ShowBorders = true,
                ShowTileImages = true,
                TileSize = 100,
                ShowInfo = true,
                BaseFont = font,
                BaseBrush = brush,

                TileDrawOptions = new TileDrawOptions()
                {
                    ShowInfo = true,
                    ShowCollision = true,
                    ShowImage = true,
                    ImageOpacity = 100,
                    BaseBrush = brush,
                    BaseFont = font
                }
            };
        }

        //Copied from TMOS RomHack 1
        public void DrawMap(PictureBox pbSurface, TmosModWorldScreen[] worldScreens, TmosRomhack1DrawerWorldMap map, MapDrawOptions options, int selectedWSIndex)
        {
            map.InitalizeData();
            map.LoadWorldMap(selectedWSIndex, 16, 16);

            Dictionary<int, Rectangle> rectangles = new Dictionary<int, Rectangle>();
          
              int TILES_Y_COUNT = 6;
         int TILES_X_COUNT = 8;

            using (var g = Graphics.FromImage(pbSurface.Image))
            {
                g.Clear(Color.LightGray);

                rectangles =map.DrawWorldMap(options.TileSize, options.TileSize);

                foreach (KeyValuePair<int, Rectangle> item in rectangles)
                {
                    int wsIndex = item.Key;
                    TmosModWorldScreen ws = worldScreens[item.Key];
                    Rectangle rect = item.Value;
                    Brush bgbrush;
                    //if (ws.IsWizardScreen())
                    //{
                    //    bgbrush = new SolidBrush(Color.FromArgb(40, 40, 40, 40));
                    //}
                     bgbrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

                    // g.FillRectangle(bgbrush, rect);
                    // g.DrawRectangle(Pens.LightGreen, rect);


                    //Draw Tiles on map
                    //  if (cb_fill_map_tiles.Checked)
                    if (true)
                    {
                        RectangleF tileRect;

                        Color groundColor = getWSGroundColor(ws.WorldScreenColor);

                        float TILEVIEW_SIZE_X = (float)rect.Width / TILES_X_COUNT;
                        float TILEVIEW_SIZE_Y = (float)rect.Height / TILES_Y_COUNT;
                        for (int y = 0; y < TILES_Y_COUNT; y++)
                        {
                            for (int x = 0; x < TILES_X_COUNT; x++)
                            {
                                Point location = new Point(options.TileSize * x, options.TileSize * y);

                                tileRect = new RectangleF(rect.Left + (x * TILEVIEW_SIZE_X), rect.Top + (y * TILEVIEW_SIZE_Y), TILEVIEW_SIZE_X, TILEVIEW_SIZE_Y);
                                Tile tile = ws.GetTileGrid()[x, y];

                                DrawTile(g, tile, location, options.TileSize / 20, groundColor, options.TileDrawOptions);



                                //  Rectangle tileRect = new Rectangle(rect.Left + (x * TILEVIEW_SIZE_X), rect.Top + (y * TILEVIEW_SIZE_Y), TILEVIEW_SIZE_X, TILEVIEW_SIZE_Y);

                                //Brush brush = new SolidBrush(groundColor);   //here
                                // g.FillRectangle(brush, tileRect);

                                //grid
                                //  g.DrawRectangle(Pens.Black, rect);

                                //if (TileImagePaths.ContainsKey(tileValue.ToString("X2")))
                                //{
                                //    Image image = new Bitmap(@"Images/TileImages/" + TileImagePaths[tileValue.ToString("X2")]);
                                //    g.DrawImage(image, tileRect);
                                //}

                            }
                        }
                    }


                    /*if (selectedIndex == wsIndex)
                    {
                        Brush brush = new SolidBrush(Color.FromArgb(40, 50, 50, 50));
                        g.FillRectangle(brush, rect);
                    }*/

                    Font drawFont = new Font("Arial", 7);



                    PointF drawIdPoint = new PointF(rect.X + 2, rect.Y + 2);
                    //g.DrawString(item.Key.ToString("X2"), drawFont, Pens.Black.Brush, drawIdPoint);

                    PointF drawContentPoint = new PointF(rect.X + rect.Width - 14, rect.Y + 2);
                    if (ws.Content != 0x00 && ws.Content != 0xFF)
                    {
                        // if (ws.Content == 0xFE) g.DrawString(ws.Content.ToString("X2"), drawFont, Pens.Orange.Brush, drawContentPoint);
                        //g.DrawString(ws.WorldScreenColor.ToString("X2"), drawFont, Pens.Blue.Brush, drawContentPoint);
                    }
                    if (ws.Content == 0xFF)
                    {
                        Brush encScreen = new SolidBrush(Color.FromArgb(110, 255, 0, 210));
                        g.FillRectangle(encScreen, rect);
                        //g.FillRectangle(Pens.WhiteSmoke.Brush, rect.Left, rect.Top, MAP_TILE_SIZE_X, MAP_TILE_SIZE_Y);
                    }




                    PointF drawDataPointerPoint = new PointF(rect.X + rect.Width - 14, rect.Y + rect.Height - 24);
                    PointF drawObjectSetPoint = new PointF(rect.X + rect.Width - 14, rect.Y + rect.Height - 14);
                    /*if (ws.ObjectSet != 0x00)
                    {
                       
                        g.DrawString(ws.DataPointer.ToString("X2"), drawFont, Pens.Purple.Brush, drawDataPointerPoint);
                        g.DrawString(ws.ObjectSet.ToString("X2"), drawFont, Pens.Red.Brush, drawObjectSetPoint);
                    }*/

                    DrawWorldScreen(pbSurface, ws, options.WorldScreenDrawOptions);
                 
                    g.DrawRectangle(Pens.Black, rect.Left, rect.Top, rect.Width, rect.Height);
                }

                pbSurface.Refresh();
               
                //DrawTileGrid(selectedIndex);
            }


        }


            public void DrawWorldScreen(PictureBox pbSurface, TmosModWorldScreen tmosWorldScreen, TmosWorldScreenDrawOptions options = null, int? WSIndex = null)
        {

          //  pbSurface.Image = new Bitmap(pbSurface.Width, pbSurface.Height);


            Tile[,] grid = tmosWorldScreen.GetTileGrid();

            Font font = new Font("Arial", 7);
            Brush brush = Pens.Black.Brush;
            Color groundColor = getWSGroundColor(tmosWorldScreen.WorldScreenColor);
            using (var g = Graphics.FromImage(pbSurface.Image))
            {
                g.Clear(Color.LightGray);
                for (int y = 0; y < 6; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        byte gridTileValue = grid[x, y].Value;
                        bool tileIsTopSection = y < 4; //else isBottomSection

                        Tile tile = TileDefinitions.GetTile(tmosWorldScreen.DataPointer, gridTileValue, tileIsTopSection);
                        Point location = new Point(options.TileSize * x, options.TileSize * y);

                        DrawTile(g, tile, location, options.TileSize, groundColor, options.TileDrawOptions);

                        if (options.ShowInfo)
                        {
                            //if (WSIndex != null)
                            //{
                            //    g.DrawString(WSIndex.ToString(), options.BaseFont, options.BaseBrush, location.X + 20, location.Y + 20);
                            //}         
                        }

                    }
                }
                pbSurface.Refresh();
            }
        }

        public void DrawTile(Graphics g, Tile tmosTile, Point location, int drawSize, Color groundColor, TileDrawOptions options)
        {
            Size size = new Size(drawSize, drawSize);
            Rectangle rect = new Rectangle(location, size);

            Brush groundBrush = new SolidBrush(groundColor);
            g.FillRectangle(groundBrush, rect);
            //g.DrawRectangle(Pens.Black, rect);



          

            if (tmosTile.Value != null)
            {
                try //needed?
                {
                    groundBrush = new SolidBrush(groundColor);
                    g.FillRectangle(groundBrush, rect);

                    if (options.ShowImage)
                    {
                        //TOOD: Add opacity
                        string imagePath = $"TileImages/{GetTileImage(tmosTile.Value)}";
                        Image image = new Bitmap(imagePath);
                        g.DrawImage(image, rect);
                    }
                }
                catch { }
            }

            if (options.ShowCollision && !tmosTile.IsWalkable())
            {
                Color collisionShadeColor = Color.FromArgb(128, Color.Red);
                SolidBrush collisionShadeBrush = new SolidBrush(collisionShadeColor);
                g.FillRectangle(collisionShadeBrush, rect);
            }

            if (options.ShowInfo)
            {
                g.DrawString(tmosTile.Value.ToString("X2"), options.BaseFont, options.BaseBrush, location.X + 20, location.Y + 20);
                g.DrawString(tmosTile.Name, options.BaseFont, options.BaseBrush, location.X + 20, location.Y + 40);
            }
        }
        public void DrawTile(PictureBox pbSurface, Tile tmosTile, Point location, int drawSize, Color groundColor, TileDrawOptions options)
        {
            using (var g = Graphics.FromImage(pbSurface.Image))
            {
                DrawTile(g, tmosTile, location, drawSize, groundColor, options);
            }
        }

        public static string GetTileImage(byte tileValue)
        {
            //Need to account for datapointer/chapter?
            switch (tileValue)
            {
                case 0x00: return "00.png";
                case 0x01: return "01.png";
                case 0x02: return "02.png";
                case 0x03: return "03.png";
                case 0x04: return "04.png";
                case 0x05: return "05.png";
                case 0x06: return "0D.png";
                case 0x07: return "08.png";
                case 0x08: return "08.png";
                case 0x09: return "08.png";
                case 0x0A: return "08.png";
                case 0x0B: return "20.png";
                case 0x0C: return "0C.png";
                case 0x0D: return "0D.png";
                case 0x0E: return "0D.png";
                case 0x0F: return "0D.png";
                case 0x10: return "0D.png";
                case 0x11: return "08.png";
                case 0x12: return "12.png";
                case 0x14: return "0D.png";
                case 0x15: return "0D.png";
                case 0x16: return "0D.png";
                case 0x17: return "0D.png";
                case 0x18: return "0D.png";
                case 0x19: return "0D.png";
                case 0x1A: return "0D.png";
                case 0x1B: return "1B.png";
                case 0x1E: return "1E.png";
                case 0x1F: return "1F.png";
                case 0x20: return "20.png";
                case 0x22: return "22.png";
                case 0x24: return "25.png";
                case 0x25: return "25.png";
                case 0x26: return "26.png";
                case 0x2B: return "43.png";
                case 0x2C: return "43.png";
                case 0x2D: return "43.png";
                case 0x2E: return "43.png";
                case 0x2F: return "3F.png";
                case 0x21: return "21.png";
                case 0x23: return "23.png";
                case 0x32: return "41.png";
                case 0x33: return "40.png";
                case 0x34: return "40.png";
                case 0x3A: return "43.png";
                case 0x3B: return "43.png";
                case 0x3C: return "43.png";
                case 0x3D: return "43.png";
                case 0x3E: return "43.png";
                case 0x37: return "43.png";
                case 0x38: return "43.png";
                case 0x39: return "43.png";
                case 0x30: return "3F.png";
                case 0x3F: return "3F.png";
                case 0x40: return "40.png";
                case 0x41: return "41.png";
                case 0x42: return "42.png";
                case 0x43: return "43.png";
                case 0x44: return "44.png";
                case 0x4C: return "4C.png";
                case 0x4D: return "4D.png";
                case 0x4E: return "4E.png";
                case 0x48: return "48.png";
                case 0x4A: return "4A.png";
                case 0x47: return "47.png";
                case 0x53: return "53.png";
                case 0x54: return "54.png";
                case 0x55: return "55.png";
                case 0x56: return "56.png";
                case 0x57: return "57.png";
                case 0x58: return "58.png";
                case 0x59: return "59.png";
                case 0x5A: return "5A.png";
                case 0x5B: return "5B.png";
                case 0x5D: return "5D.png";
                case 0x5C: return "5C.png";
                case 0x5E: return "5E.png";
                case 0x5F: return "5F.png";
                case 0x60: return "60.png";
                case 0x61: return "61.png";
                case 0x62: return "62.png";
                case 0x63: return "63.png";
                case 0x64: return "64.png";
                case 0x65: return "65.png";
                case 0x68: return "68.png";
                case 0x67: return "67.png";
                case 0x6B: return "6B.png";
                case 0x6F: return "6F.png";
                case 0x70: return "70.png";
                case 0x71: return "71.png";
                case 0x72: return "72.png";
                case 0x73: return "03.png";
                case 0x76: return "76.png";
                case 0x77: return "77.png";
                case 0x78: return "78.png";
                case 0x7A: return "7A.png";
                case 0x7B: return "7B.png";
                case 0x7C: return "7C.png";
                case 0x7D: return "7D.png";
                case 0x7F: return "7F.png";
                case 0x79: return "26.png";
                case 0x80: return "80.png";
                case 0x81: return "81.png";
                case 0x82: return "82.png";
                case 0x83: return "83.png";
                case 0x84: return "84.png";
                case 0x87: return "87.png";
                case 0x86: return "86.png";
                case 0x88: return "88.png";
                case 0x89: return "89.png";
                case 0x8A: return "8A.png";
                case 0x8C: return "8C.png";
                case 0x8D: return "8D.png";
                case 0x8E: return "8E.png";
                case 0x8F: return "8F.png";
                case 0x92: return "92.png";
                case 0x93: return "93.png";
                case 0x94: return "94.png";
                case 0x95: return "95.png";
                case 0x98: return "98.png";
                case 0x99: return "99.png";
                case 0x9A: return "9A.png";
                case 0x9B: return "9B.png";
                case 0x9C: return "9C.png";
                case 0x9D: return "9D.png";
                case 0x9E: return "9E.png";
                case 0x9F: return "9F.png";
                case 0x96: return "96.png";
                case 0x97: return "97.png";
                case 0xA1: return "A1.png";
                case 0xA2: return "A2.png";
                case 0xA3: return "A3.png";
                case 0xA4: return "A4.png";
                case 0xA5: return "A5.png";
                case 0xA6: return "A6.png";
                case 0xA8: return "A8.png";
                case 0xA9: return "A9.png";
                case 0xAA: return "AA.png";
                case 0xE2: return "A9.png";
                case 0xAB: return "AA.png";
                case 0xAC: return "AC.png";
                case 0xAD: return "AD.png";
                case 0xAF: return "AA.png";
                case 0xB0: return "B0.png";
                case 0xB2: return "B2.png";
                case 0xB3: return "B3.png";
                case 0xB1: return "B1.png";
                case 0xB9: return "B9.png";
                case 0xB5: return "B5.png";
                case 0xBC: return "BC.png";
                case 0xBD: return "BD.png";
                case 0xBE: return "BE.png";
                case 0xBF: return "BF.png";
                case 0xB8: return "B8.png";
                case 0xC0: return "C0.png";
                case 0xC1: return "C1.png";
                case 0xC2: return "C2.png";
                case 0xC3: return "C3.png";
                case 0xC4: return "C4.png";
                case 0xC6: return "C6.png";
                case 0xC5: return "C5.png";
                case 0xC7: return "C7.png";
                case 0xCF: return "CF.png";
                case 0xD5: return "D6.png";
                case 0xD6: return "D6.png";
                case 0xD0: return "D0.png";
                case 0xDA: return "DA.png";
                case 0xDC: return "DC.png";
                case 0xDD: return "DD.png";
                case 0xDE: return "DE.png";
                case 0xE0: return "E0.png";
                case 0xE1: return "E1.png";
                case 0xE6: return "E6.png";
                case 0xE7: return "E7.png";
                case 0xE9: return "E9.png";
                case 0xEA: return "EA.png";
                case 0xEB: return "EB.png";
                case 0xEC: return "EC.png";
                case 0xED: return "03.png";
                case 0xEE: return "EE.png";
                case 0xEF: return "EF.png";
                case 0xFA: return "FA.png";
                case 0xF0: return "F0.png";
                case 0xF1: return "F1.png";
                case 0xF2: return "F2.png";
                case 0xF3: return "03.png";
                case 0xF5: return "F5.png";
                case 0xF6: return "F6.png";
                case 0xF7: return "F7.png";
                case 0xF8: return "F8.png";
                case 0xF9: return "F9.png";
                case 0xFD: return "FD.png";
                case 0xFE: return "FE.png";
                case 0xFB: return "FB.png";
                case 0xF4: return "F4.png";
                case 0xFC: return "FC.png";
                case 0xFF: return "FF.png";
                default: return "unknown.png";
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
    }
}
