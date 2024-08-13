using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Enum.Tiles;
using static Tmos.Romhacks.Library.Definitions.MiniTileDefinitions;

namespace Tmos.Romhacks.Library.Definitions
{
	/// <summary>
	/// We can set properties on miniTiles like IsWalkable for mini tiles for more accurate collisions but probably not worth the work for now
	/// </summary>
	public class MiniTileDefinition
	{
		public MiniTileType ContentType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsWalkable { get; set; }
	}

	public static class MiniTileDefinitions
	{
		

		public static MiniTileDefinition GetMiniTiletDefinition(MiniTileType contentType)
		{
			return GetMiniTileDefinitions().FirstOrDefault(x => x.ContentType == contentType);
		}
		public static List<MiniTileDefinition> GetMiniTileDefinitions()
		{
			return new List<MiniTileDefinition>()
			{
				new MiniTileDefinition() { ContentType = MiniTileType.TreeTopRight, Name = "tree top rightcorner" }, //Not actual values, just placeholders
                new MiniTileDefinition() { ContentType = MiniTileType.TreeTopLeft, Name = "tree top leftcorner" },
			};
		}
	
	}
}
