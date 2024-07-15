using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Interfaces;
using static Tmos.Romhacks.Mods.TileDefinitions;


namespace Tmos.Romhacks.Mods.TypedTmosObjects
{

	public class Tile : TmosRomObject, ITile
	{
		public byte Value { get; set; }
		public TileType TileType { get; set; }
		public string Name { get; set; }

		public string GetImagePath() { return $"TileImages/{Value.ToString("X2")}.png"; }


		public MiniTile[] MiniTiles { get; set; }
		//0-Top left
		//1-Top right
		//2-Bottom left
		//3-Bottom right

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

		public void Update(byte[] bytes) 
		{
			_data = bytes;
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




		//public MiniTile MiniTile1
		//{
		//	get { return _data[0]; }
		////	set { _data[0] = value; }
		//}

		//public MiniTile MiniTile2
		//{
		//	get { return _data[1]; }
		////	set { _data[1] = value; }
		//}

		//public MiniTile MiniTile3
		//{
		//	get { return _data[Slot3]; }
		////	set { _data[Slot3] = value; }
		//}

		//public MiniTile MiniTile4
		//{
		//	get { return _data[Slot4]; }
		////	set { _data[Slot4] = value; }
		//}

	}
}
