using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Core.TmosWorldScreen;
using static Tmos.Romhacks.Mods.TileDefinitions;

namespace Tmos.Romhacks.Mods
{
    public class TmosModWorldScreen
    {
        //    private TmosWorldScreen _tmosWorldScreen;

        public WSContent WSContent { get; set; }
        public TmosTileSection TileSectionTop { get; set; }   //Have to be kept up to date with loaded rom data
        public TmosTileSection TileSectionBottom { get; set; }  //Have to be kept up to date with loaded rom data

        private byte[] _data;
        //public byte[] GetBytes()
        //{
        //    return _data;
        //}
        public byte[] GetBytes() { return _data; }
        public byte ParentWorld { get { return _data[(int)DataContent.ParentWorld]; } set { _data[(int)DataContent.ParentWorld] = value; } }
        public byte AmbientSound { get { return _data[(int)DataContent.AmbientSound]; } set { _data[(int)DataContent.AmbientSound] = value; } }
        public byte Content { get { return _data[(int)DataContent.Content]; } set { _data[(int)DataContent.Content] = value; } }
        public byte ObjectSet { get { return _data[(int)DataContent.ObjectSet]; } set { _data[(int)DataContent.ObjectSet] = value; } }
        public byte ScreenIndexRight { get { return _data[(int)DataContent.ScreenIndexRight]; } set { _data[(int)DataContent.ScreenIndexRight] = value; } }
        public byte ScreenIndexLeft { get { return _data[(int)DataContent.ScreenIndexLeft]; } set { _data[(int)DataContent.ScreenIndexLeft] = value; } }
        public byte ScreenIndexDown { get { return _data[(int)DataContent.ScreenIndexDown]; } set { _data[(int)DataContent.ScreenIndexDown] = value; } }
        public byte ScreenIndexUp { get { return _data[(int)DataContent.ScreenIndexUp]; } set { _data[(int)DataContent.ScreenIndexUp] = value; } }
        public byte DataPointer { get { return _data[(int)DataContent.DataPointer]; } set { _data[(int)DataContent.DataPointer] = value; } }
        public byte ExitPosition { get { return _data[(int)DataContent.ExitPosition]; } set { _data[(int)DataContent.ExitPosition] = value; } }
        public byte TopTiles { get { return _data[(int)DataContent.TopTiles]; } set { _data[(int)DataContent.TopTiles] = value; } }
        public byte BottomTiles { get { return _data[(int)DataContent.BottomTiles]; } set { _data[(int)DataContent.BottomTiles] = value; } }
        public byte WorldScreenColor { get { return _data[(int)DataContent.WorldScreenColor]; } set { _data[(int)DataContent.WorldScreenColor] = value; } }
        public byte SpritesColor { get { return _data[(int)DataContent.SpritesColor]; } set { _data[(int)DataContent.SpritesColor] = value; } }
        public byte Unknown { get { return _data[(int)DataContent.Unknown]; } set { _data[(int)DataContent.Unknown] = value; } }
        public byte Event { get { return _data[(int)DataContent.Event]; } set { _data[(int)DataContent.Event] = value; } }



        //These will hopefully be made into usable objects like the ones above, instead of a byte value, but for now just loading up the byte value straight from the ROM data
        //public byte ParentWorld { get; set; }
        //public byte AmbientSound { get; set; }
        //  public byte Content { get; set; } 
        //public byte ObjectSet { get; set; }
        //public byte ScreenIndexRight { get; set; }
        //public byte ScreenIndexLeft { get; set; }
        //public byte ScreenIndexDown { get; set; }
        //public byte ScreenIndexUp { get; set; }
        //public byte DataPointer { get; set; }
        //public byte ExitPosition { get; set; }
        //public byte TopTiles { get; set; }
        //public byte BottomTiles { get; set; }
        //public byte WorldScreenColor { get; set; }
        //public byte SpritesColor { get; set; }
        //public byte Unknown { get; set; }
        //public byte Event { get; set; }




        public TmosModWorldScreen(byte[] data)
        {
            _data = data;
            //WSContent = WSContentDefinitions.GetWSContentDefinition(data.Content.);
            //TileSectionTop = new TmosTileSection(TopTiles);
            //TileSectionBottom = new TmosTileSection(BottomTiles);

            ParentWorld = data[(int)DataContent.ParentWorld];
            AmbientSound = data[(int)DataContent.AmbientSound];
            Content = data[(int)DataContent.Content];
            ObjectSet = data[(int)DataContent.ObjectSet];
            ScreenIndexRight = data[(int)DataContent.ScreenIndexRight];
            ScreenIndexLeft = data[(int)DataContent.ScreenIndexLeft];
            ScreenIndexDown = data[(int)DataContent.ScreenIndexDown];
            ScreenIndexUp = data[(int)DataContent.ScreenIndexUp];
            DataPointer = data[(int)DataContent.DataPointer];
            ExitPosition = data[(int)DataContent.ExitPosition];
            TopTiles = data[(int)DataContent.TopTiles];
            BottomTiles = data[(int)DataContent.BottomTiles];
            WorldScreenColor = data[(int)DataContent.WorldScreenColor];
            SpritesColor = data[(int)DataContent.SpritesColor];
            Unknown = data[(int)DataContent.Unknown];
            Event = data[(int)DataContent.Event];

        }

        public byte GetNeighborWorldScreenRelativeIndex(Direction direction)
        {
            switch(direction)
            {
                case Direction.Right: return ScreenIndexRight;
                case Direction.Left: return ScreenIndexLeft;
                case Direction.Up: return ScreenIndexUp;
                case Direction.Down: return ScreenIndexDown;
                default: return ScreenIndexUp;
            }
        }

        public static byte GetContentValue(WSContent wsContent)
        {
            return wsContent.Value;
        }



        #region Directional Tests

        public bool CollisionTest_Right_IsCompatable(TmosModWorldScreen destinationWS)
        {
            if (ScreenIndexRight == 0xFF) return true;


            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            Tile[,] tileGrid = GetTileGrid();
            Tile[,] destinationTileGrid = destinationWS.GetTileGrid();

            Tile[] tileGrid_RightEdge = new Tile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                tileGrid_RightEdge[y] = tileGrid[7, y];
            }

            Tile[] destinationTileGrid_LeftEdge = new Tile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                destinationTileGrid_LeftEdge[y] = destinationTileGrid[0, y];
            }

            bool[] compatableCollisionTiles = new bool[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                if (tileGrid_RightEdge[y].IsWalkable() == destinationTileGrid_LeftEdge[y].IsWalkable())
                {
                    compatableCollisionTiles[y] = true;
                }
            }

            //Now we have a bool array indicating which squares are compatable with the other screen. Use this to decide if the screens are compatable

            return AllBoolsAreTrue(compatableCollisionTiles);

        }

        public bool CollisionTest_Left_IsCompatable(TmosModWorldScreen destinationWS)
        {
            if (ScreenIndexLeft == 0xFF) return true;
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            Tile[,] tileGrid = GetTileGrid();
            Tile[,] destinationTileGrid = destinationWS.GetTileGrid();

            Tile[] tileGrid_LeftEdge = new Tile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                tileGrid_LeftEdge[y] = tileGrid[0, y];
            }

            Tile[] destinationTileGrid_RightEdge = new Tile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                destinationTileGrid_RightEdge[y] = destinationTileGrid[7, y];
            }

            bool[] compatableCollisionTiles = new bool[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                if (tileGrid_LeftEdge[y].IsWalkable() == destinationTileGrid_RightEdge[y].IsWalkable())
                {
                    compatableCollisionTiles[y] = true;
                }
            }

            //Now we have a bool array indicating which squares are compatable with the other screen. Use this to decide if the screens are compatable

            return AllBoolsAreTrue(compatableCollisionTiles);

        }

        public bool CollisionTest_Up_IsCompatable(TmosModWorldScreen destinationWS)
        {
            if (ScreenIndexUp == 0xFF) return true;
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            Tile[,] tileGrid = GetTileGrid();
            Tile[,] destinationTileGrid = destinationWS.GetTileGrid();

            Tile[] tileGrid_TopEdge = new Tile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                tileGrid_TopEdge[x] = tileGrid[x, 0];
            }

            Tile[] destinationTileGrid_BottomEdge = new Tile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                destinationTileGrid_BottomEdge[x] = destinationTileGrid[x, 5];
            }

            bool[] compatableCollisionTiles = new bool[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                if (tileGrid_TopEdge[x].IsWalkable() == destinationTileGrid_BottomEdge[x].IsWalkable())
                {
                    compatableCollisionTiles[x] = true;
                }
            }

            //Now we have a bool array indicating which squares are compatable with the other screen. Use this to decide if the screens are compatable

            return AllBoolsAreTrue(compatableCollisionTiles);

        }

        public bool CollisionTest_Down_IsCompatable(TmosModWorldScreen destinationWS)
        {
            if (ScreenIndexDown == 0xFF) return true;
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            Tile[,] tileGrid = GetTileGrid();
            Tile[,] destinationTileGrid = destinationWS.GetTileGrid();

            Tile[] tileGrid_BottomEdge = new Tile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                tileGrid_BottomEdge[x] = tileGrid[x, 5];
            }

            Tile[] destinationTileGrid_TopEdge = new Tile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                destinationTileGrid_TopEdge[x] = destinationTileGrid[x, 0];
            }

            bool[] compatableCollisionTiles = new bool[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                if (tileGrid_BottomEdge[x].IsWalkable() == destinationTileGrid_TopEdge[x].IsWalkable())
                {
                    compatableCollisionTiles[x] = true;
                }
            }

            //Now we have a bool array indicating which squares are compatable with the other screen. Use this to decide if the screens are compatable

            return AllBoolsAreTrue(compatableCollisionTiles);

        }

        private static bool AllBoolsAreTrue(bool[] boolArray)
        {
            foreach (bool b in boolArray)
            {
                if (!b)
                {
                    return false;
                }
            }
            return true;
        }


        #endregion Directional Tests




        #region Tiles

        //public void UpdateTopTileSection(int tileSectionIndex, TmosTileSection tileSection)
        //{
        //    TopTiles =ti
        //}

        //public void UpdateBottomTileSection(int tileSectionIndex, TmosTileSection tileSection)
        //{

        //}

        public Tile[,] GetTileGrid()
        {
            byte[,] topTileGrid = TileSectionTop.GetTileSectionGrid();
            byte[,] bottomTileGrid = TileSectionBottom.GetTileSectionGrid();

            Tile[,] fullGrid = new Tile[8, 6];   //only 2 rows used from bottom grid

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (y < 4)
                    {

                        byte tileValue = topTileGrid[x, y];
                        Tile tile = GetTile(DataPointer, tileValue, true);
                        fullGrid[x, y] = tile;
                    }
                    else
                    {
                        byte tileValue = bottomTileGrid[x, y - 4];
                        Tile tile = GetTile(DataPointer, tileValue, false);
                        fullGrid[x, y] = tile;
                    }

                }
            }
            return fullGrid;

        }

    }




	#endregion Tiles

}


    





