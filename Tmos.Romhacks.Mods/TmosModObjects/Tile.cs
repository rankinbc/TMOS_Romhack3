using System;
using System.Collections.Generic;
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

	public class Tile : TmosRomObject, ITile
	{
		public byte Value { get; set; }
		public TileType TileType { get; set; }
		public string Name { get; set; }

		public MiniTile[] MiniTiles { get; set; }
		
		public bool _isWalkable { get; set; }

		
		public Tile(byte[] bytes) : base(bytes)
		{
			//Load minitiles?
			_isWalkable = Convert.ToBoolean(bytes[1]); //TODO: Determine which byte is the walkable byte
		}
		public Tile(bool isWalkable) : base(new byte[4])
		{
			_isWalkable = isWalkable;
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
			return _isWalkable;
		}

		public MiniTile MiniTile_TopLeft
        {
			get { return MiniTiles[0]; }
			set { MiniTiles[0] = value; }
		}

		public MiniTile MiniTile2_TopRight
        {
			get { return MiniTiles[1]; }
			set { MiniTiles[1] = value; }
		}

		public MiniTile MiniTile3_BottomLeft
        {
			get { return MiniTiles[2]; }
			set { MiniTiles[2] = value; }
		}

		public MiniTile MiniTile4_BottomRight
        {
			get { return MiniTiles[3]; }
			set { MiniTiles[3] = value; }
		}

        

    }
}
