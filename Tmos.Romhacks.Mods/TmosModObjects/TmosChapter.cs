using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.Definitions;


namespace Tmos.Romhacks.Mods.TypedTmosObjects
{
	//Object that represents a chapter - add things specific to chapters here
	
	public class TmosChapter
	{
		public int ChapterNumber { get; set; }

		public string Name { get; set; }

		//TmosRomObjectMemoryDataOffset WorldScreenDataOffset { get; set; } //Should be the offset of the world screen data where the WorldScreens begin for this chapter

        //public TmosRomObjectMemoryDataOffset WSContentOffset{get;set;} //TODO: Figure out how to calculate what a WSContent value is based on the chapter number, value (and anything else that is needed)

        public int GetWorldScreenIndexOffset()
		{
            var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
			int beginningOfData = def.Address;

			int totalWSMemory = WorldScreenDataStartAddress - beginningOfData;
			return totalWSMemory / def.ObjectSize;
        }
		//Future TODO: Make the properties below be determined by the ROM, instead of them being hardcoded 
		public int WorldScreenDataStartAddress { get; set; }
		//public int WorldScreenCount { get; set; }
		public int RandomEncounterGroupDataOffset { get; set; }
		public int RandomEncounterGroupDataCount{ get; set; } 
		public int RandomEncounterLineupDataOffset { get; set; }
		public int RandomEncounterLineupCount { get; set; }


	}
}
