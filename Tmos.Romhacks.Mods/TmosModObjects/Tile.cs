using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.Interfaces;
using static Tmos.Romhacks.Mods.TileDefinitions;


namespace Tmos.Romhacks.Mods.TypedTmosObjects
{
    [DebuggerDisplay("{WSTileValue}")]
    public class Tile : TmosRomObject, ITile
	{
		public byte WSTileValue { get; set; } //The value of the tile on the WS
        public TileType TileType { get; set; }
		public string Name { get; set; }

		//public MiniTile[] MiniTiles { get; set; }

        //FinalTileValue and TmosTileIndex shouldnt be on this object - they are related to how to find this tile object in data- this will cause problems so should refactor
        public int FinalTileValue { get; set; } //The final tile value using the offsets determined from the WS containing this tile
        public int TmosTileIndex { get; set; } //Address offset of this tile in WSTile memory



        public Tile(): base(new byte[] { })
		{
        
		
        }
		public Tile(byte WSTileValue) : base(new byte[] { })
		{
			this.WSTileValue = this.WSTileValue;
			//Load minitiles?

		}


		//public void Reload()
		//{
		//	MiniTiles[0] = MiniTileDefinitions.GetMiniTileDefinitions(byte[0]);
		//}

		//public void Reload(MiniTileDefinition  )
		//{//TODO:  //Need a way to get MiniTile from byte[]
		//MiniTileDefinition miniTiletDefinition = MiniTileDefinitions.GetMiniTileDefinition(Mini);
		//MiniTiles[0] =  new MiniTile()
		//}

		//TODO: Figure out how to actually calculate instead of using hard-coded definitions

		public bool IsWalkable()
		{
			return TileDefinitions.TileIsWalkable(WSTileValue);
		}


    //public MiniTile MiniTile_TopLeft
    //      {
    //	get { return MiniTiles[0]; }
    //	set { MiniTiles[0] = value; }
    //}

    //public MiniTile MiniTile2_TopRight
    //      {
    //	get { return MiniTiles[1]; }
    //	set { MiniTiles[1] = value; }
    //}

    //public MiniTile MiniTile3_BottomLeft
    //      {
    //	get { return MiniTiles[2]; }
    //	set { MiniTiles[2] = value; }
    //}

    //public MiniTile MiniTile4_BottomRight
    //      {
    //	get { return MiniTiles[3]; }
    //	set { MiniTiles[3] = value; }
    //}



}
}
