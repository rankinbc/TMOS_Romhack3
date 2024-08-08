using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;


namespace Tmos.Romhacks.Mods.TypedTmosObjects
{
	public class WSContent
	{
		public byte ContentByteValue { get; set; }
		public WSContentType ContentType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

	}
}
