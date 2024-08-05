using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum.Tiles;
using Tmos.Romhacks.Mods.Interfaces;

namespace Tmos.Romhacks.Mods.TypedTmosObjects
{
	public class TmosModMiniTile : TmosRomObject, IMiniTile
	{
		bool _isWalkable;
		public TmosModMiniTile(byte[] bytes) : base(bytes)
		{
			//TODO: Determine what the 4 byters are and update local properties - I think "microtiles" 2x2 divided the same way
		}
		public TmosModMiniTile(MiniTileDefinition miniTiletDefinition) : base(new byte[] { 0x00, Convert.ToByte(miniTiletDefinition.IsWalkable), 0x00 })
		{
			_isWalkable = miniTiletDefinition.IsWalkable;
		}

		public bool IsWalkable()
		{
			return _isWalkable;
		}

        //public bool IsWalkable()
        //{
        //	//TODO: Determine how to retrieve information on whether a tile is walkable
        //	throw new NotImplementedException("It is still unknown how to determine whether a MiniTile is walkable");
        //}

        //public MicroTile MicroTile_TopLeft
        //{
        //    get { return MicroTiles[0]; }
        //    set { MicroTiles[0] = value; }
        //}

        //public MicroTile MicroTile2_TopRight
        //{
        //    get { return MicroTiles[1]; }
        //    set { MicroTiles[1] = value; }
        //}

        //public MicroTile MicroTile3_BottomLeft
        //{
        //    get { return MicroTiles[2]; }
        //    set { MicroTiles[2] = value; }
        //}

        //public MicroTile MicroTile4_BottomRight
        //{
        //    get { return MicroTiles[3]; }
        //    set { MicroTiles[3] = value; }
        //}
    }
}
