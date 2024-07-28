using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.Definitions;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;
using static Tmos.Romhacks.Mods.Enum.KnownValueLibrary.WSContentTypeKVLibrary;

namespace Tmos.Romhacks.Mods.TypedTmosObjects
{
	public class WSContent
	{
		public byte Value { get; set; }
		//public (byte dataPointer, byte value) ContentKey; //Ideally this object could work without having to include the dataPointer of the parent WorldScreen
		public WSContentType ContentType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

	}
}
