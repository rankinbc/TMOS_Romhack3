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
using Tmos.Romhacks.Mods.Utility;
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

        public byte[] GetBytes() { return _data; }
        public byte ParentWorld { get { return _data[(int)WSProperty.ParentWorld]; } set { _data[(int)WSProperty.ParentWorld] = value; } }
        public byte AmbientSound { get { return _data[(int)WSProperty.AmbientSound]; } set { _data[(int)WSProperty.AmbientSound] = value; } }
        public byte Content { get { return _data[(int)WSProperty.Content]; } set { _data[(int)WSProperty.Content] = value; } }
        public byte ObjectSet { get { return _data[(int)WSProperty.ObjectSet]; } set { _data[(int)WSProperty.ObjectSet] = value; } }
        public byte ScreenIndexRight { get { return _data[(int)WSProperty.ScreenIndexRight]; } set { _data[(int)WSProperty.ScreenIndexRight] = value; } }
        public byte ScreenIndexLeft { get { return _data[(int)WSProperty.ScreenIndexLeft]; } set { _data[(int)WSProperty.ScreenIndexLeft] = value; } }
        public byte ScreenIndexDown { get { return _data[(int)WSProperty.ScreenIndexDown]; } set { _data[(int)WSProperty.ScreenIndexDown] = value; } }
        public byte ScreenIndexUp { get { return _data[(int)WSProperty.ScreenIndexUp]; } set { _data[(int)WSProperty.ScreenIndexUp] = value; } }
        public byte DataPointer { get { return _data[(int)WSProperty.DataPointer]; } set { _data[(int)WSProperty.DataPointer] = value; } }
        public byte ExitPosition { get { return _data[(int)WSProperty.ExitPosition]; } set { _data[(int)WSProperty.ExitPosition] = value; } }
        public byte TopTiles { get { return _data[(int)WSProperty.TopTiles]; } set { _data[(int)WSProperty.TopTiles] = value; } }
        public byte BottomTiles { get { return _data[(int)WSProperty.BottomTiles]; } set { _data[(int)WSProperty.BottomTiles] = value; } }
        public byte WorldScreenColor { get { return _data[(int)WSProperty.WorldScreenColor]; } set { _data[(int)WSProperty.WorldScreenColor] = value; } }
        public byte SpritesColor { get { return _data[(int)WSProperty.SpritesColor]; } set { _data[(int)WSProperty.SpritesColor] = value; } }
        public byte Unknown { get { return _data[(int)WSProperty.Unknown]; } set { _data[(int)WSProperty.Unknown] = value; } }
        public byte Event { get { return _data[(int)WSProperty.Event]; } set { _data[(int)WSProperty.Event] = value; } }


        public TmosModWorldScreen(byte[] data)
        {
            _data = data;
            //WSContent = WSContentDefinitions.GetWSContentDefinition(data.Content.);
            //TileSectionTop = new TmosTileSection(TopTiles);
            //TileSectionBottom = new TmosTileSection(BottomTiles);

            ParentWorld = data[(int)WSProperty.ParentWorld];
            AmbientSound = data[(int)WSProperty.AmbientSound];
            Content = data[(int)WSProperty.Content];
            ObjectSet = data[(int)WSProperty.ObjectSet];
            ScreenIndexRight = data[(int)WSProperty.ScreenIndexRight];
            ScreenIndexLeft = data[(int)WSProperty.ScreenIndexLeft];
            ScreenIndexDown = data[(int)WSProperty.ScreenIndexDown];
            ScreenIndexUp = data[(int)WSProperty.ScreenIndexUp];
            DataPointer = data[(int)WSProperty.DataPointer];
            ExitPosition = data[(int)WSProperty.ExitPosition];
            TopTiles = data[(int)WSProperty.TopTiles];
            BottomTiles = data[(int)WSProperty.BottomTiles];
            WorldScreenColor = data[(int)WSProperty.WorldScreenColor];
            SpritesColor = data[(int)WSProperty.SpritesColor];
            Unknown = data[(int)WSProperty.Unknown];
            Event = data[(int)WSProperty.Event];

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
            return wsContent.ContentByteValue;
        }
		public string GetContentName()
		{
			if (HasWSWarpContentEntrance())
			{
				return "Warp";
			}
			else
			{
				return WSContent.Name;
			}

		}
		public string GetContentDescription()
		{
            if (HasWSWarpContentEntrance()) 
            {
				return "Warps to WS " + Content.ToString("X2");
			}
            else
            {
                return WSContent.Description;
			}

		}


		public bool IsWizardScreen()
        {
            return WSContent.ContentType == WSContentType.WizardBattleOnEnter;
        }
        public bool IsBattleScreen()
        {
            return WSContent.ContentType == WSContentType.Battle;
        }
		public bool HasContentEntrance()
		{
			return (WSContent.ContentType != WSContentType.Nothing &&
				WSContent.ContentType != WSContentType.WizardBattleOnEnter &&
				WSContent.ContentType != WSContentType.Battle);
		}
		public bool HasWSWarpContentEntrance()
		{
            return (Event >= 0x40 && Event <= 0x4F &&
                (WSContent.ContentType != WSContentType.Nothing &&
                WSContent.ContentType != WSContentType.WizardBattleOnEnter &&
                WSContent.ContentType != WSContentType.Battle));
		}



        public byte GetNeighborScreenRelativeIndex(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right: return ScreenIndexRight;
				case Direction.Left: return ScreenIndexLeft;
				case Direction.Up: return ScreenIndexUp;
				case Direction.Down: return ScreenIndexDown;
                default : return ScreenIndexDown;
			}
        }

		#region Directional Tests

		public bool CollisionTest_Right_IsCompatable(TmosModWorldScreen destinationWS)
        {

            TmosModTile[,] tileGrid = GetTileGrid();
            TmosModTile[] tileGrid_RightEdge = new TmosModTile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                tileGrid_RightEdge[y] = tileGrid[7, y];
            }
            if (ScreenIndexRight == 0xFF)
            {
                if (tileGrid_RightEdge.All(t => !t.IsWalkable()))
                {
                    return true;
                }
                else
                {
                    //Console.WriteLine("fail right");
                    return false;
                }
            }
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            TmosModTile[,] destinationTileGrid = destinationWS.GetTileGrid();

            TmosModTile[] destinationTileGrid_LeftEdge = new TmosModTile[6];
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
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            TmosModTile[,] tileGrid = GetTileGrid();
            TmosModTile[,] destinationTileGrid = destinationWS.GetTileGrid();

            TmosModTile[] tileGrid_LeftEdge = new TmosModTile[6];
            for (int y = 0; y < tileGrid.GetLength(1); y++)
            {
                tileGrid_LeftEdge[y] = tileGrid[0, y];
            }
            if (ScreenIndexLeft == 0xFF)
            {
                if (tileGrid_LeftEdge.All(t => !t.IsWalkable()))
                {
                    return true;
                }
                else
                {
                  //  Console.WriteLine("fail left");
                    return false;
                }
            }

            TmosModTile[] destinationTileGrid_RightEdge = new TmosModTile[6];
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
          //  if (ScreenIndexUp == 0xFF) return true;
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            TmosModTile[,] tileGrid = GetTileGrid();
            TmosModTile[,] destinationTileGrid = destinationWS.GetTileGrid();

            TmosModTile[] tileGrid_TopEdge = new TmosModTile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                tileGrid_TopEdge[x] = tileGrid[x, 0];
              
            }
            if (ScreenIndexUp == 0xFF)
            {
                if (tileGrid_TopEdge.All(t => !t.IsWalkable()))
                {
                    return true;
                }
                else
                {
                  //  Console.WriteLine("fail up");
                    return false;
                }
            }

            TmosModTile[] destinationTileGrid_BottomEdge = new TmosModTile[8];
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
           // if (ScreenIndexDown == 0xFF) return true;
            //take the edge of this screen's grid, and compare it to the opposite edge of the destinationWS 

            TmosModTile[,] tileGrid = GetTileGrid();
            TmosModTile[,] destinationTileGrid = destinationWS.GetTileGrid();

            TmosModTile[] tileGrid_BottomEdge = new TmosModTile[8];
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                tileGrid_BottomEdge[x] = tileGrid[x, 5]; 
            }

            if (ScreenIndexDown == 0xFF)
            {
                if (tileGrid_BottomEdge.All(t => !t.IsWalkable()))
                {
                    return true;
                }
                else
                {
                   // Console.WriteLine("fail down");
                    return false;
                }
            }


            TmosModTile[] destinationTileGrid_TopEdge = new TmosModTile[8];
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

        public TmosModTile[,] GetTileGrid()
        {
            byte[,] topTileGrid = TileSectionTop.GetTileSectionGrid();
            byte[,] bottomTileGrid = TileSectionBottom.GetTileSectionGrid();

            TmosModTile[,] fullGrid = new TmosModTile[8, 6];   //only 2 rows used from bottom grid

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (y < 4)
                    {

                        byte tileValue = topTileGrid[x, y];
                        TmosModTile tile = new TmosModTile(tileValue);
                        fullGrid[x, y] = tile;
                    }
                    else
                    {
                        byte tileValue = bottomTileGrid[x, y - 4];
                        TmosModTile tile = new TmosModTile(tileValue);
						fullGrid[x, y] = tile;
                    }

                }
            }
            return fullGrid;
        }

    }




	#endregion Tiles

}


    





