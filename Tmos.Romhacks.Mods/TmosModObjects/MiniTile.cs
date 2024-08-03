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
	public class MiniTile : TmosRomObject, IMiniTile
	{
		bool _isWalkable;
		public MiniTile(byte[] bytes) : base(bytes)
		{
			//TODO: Determine what the 4 byters are and update local properties - I think "microtiles" 2x2 divided the same way
		}
		public MiniTile(MiniTileDefinition miniTiletDefinition) : base(new byte[] { 0x00, Convert.ToByte(miniTiletDefinition.IsWalkable), 0x00 })
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
	}
}
