using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;

namespace Tmos.Romhacks.Mods.Definitions
{
	//The main purpose of this class is to be able to take relative indexes
	//(Example: Chapter 2 WS Direction byte values are the *CH2* WS indexes. (Where 0 is the first WS in Ch2)
	//A lot of attempts to calulate stuff here, but mostly giving up and hardcoding the existing offsets
	//Calculating offsets will need to be done if Chapter offsets are ever to be modified
	//WorldScreens use Chapter offsets - What else?
	//WSContents?
	//ObjectSets?
	public static class TmosChapterDefinitions
	{
		public enum TmosChapterNumber
		{
			Chapter1 = 0,
			Chapter2 = 1,
			Chapter3 = 2,
			Chapter4 = 3,
			Chapter5 = 4
		}
		public static List<TmosChapter> GetTmosChapters() {
			return new List<TmosChapter>()
			{
				 //TODO: load these addresses from rom pointers rather than hardcode
				new TmosChapter()
				{
					ChapterNumber = 0,
					Name = "Water World Maroon",
					WorldScreenDataStartAddress=0x39695,
					RandomEncounterGroupDataOffset = 0xC02A,
					RandomEncounterGroupDataCount = 15,
					RandomEncounterLineupDataOffset = 0xC211,
					RandomEncounterLineupCount = 6
				},
				new TmosChapter()
				{
					ChapterNumber = 1,
					Name = "Desert World Alalart",
					WorldScreenDataStartAddress=0x39EC5,
					RandomEncounterGroupDataOffset = 0xC058,
					RandomEncounterGroupDataCount = 16,
					RandomEncounterLineupDataOffset = 0xC241,
					RandomEncounterLineupCount = 6
},
				new TmosChapter()
				{
					ChapterNumber = 2,
					Name = "Forest World Samalkand",
					WorldScreenDataStartAddress=0x3A755,
						RandomEncounterGroupDataOffset = 0xC089,
						RandomEncounterGroupDataCount = 17,
						RandomEncounterLineupDataOffset = 0xC271,
						RandomEncounterLineupCount = 6
},
				new TmosChapter()
				{
					ChapterNumber = 3,
					Name = "Flower World Celestern",
					WorldScreenDataStartAddress=0x3B0E5,
					RandomEncounterGroupDataOffset = 0xC0BD,
					RandomEncounterGroupDataCount = 22,
					RandomEncounterLineupDataOffset = 0xC2C1,
					RandomEncounterLineupCount = 6
				},
				new TmosChapter()
				{
					ChapterNumber = 4,
					Name = "Evil Magician Sabaron",
					WorldScreenDataStartAddress = 0x3BB25,
					RandomEncounterGroupDataOffset = 0xC100,
					RandomEncounterGroupDataCount = 19,
					RandomEncounterLineupDataOffset = 0xC301,
					RandomEncounterLineupCount = 8
				}
			};
        }

        public static TmosChapter GetChapterOfWorldScreen(int absoluteWorldScreenIndex)
		{
			List<TmosChapter> chapters = GetTmosChapters();
			int currentIndex = 0;

			for (int i = 0; i < chapters.Count; i++)
			{
				int chapterScreenCount = CalculateWorldScreenCount(chapters[i], chapters);
				if (absoluteWorldScreenIndex >= currentIndex && absoluteWorldScreenIndex < currentIndex + chapterScreenCount)
				{
					return chapters[i];
				}
				currentIndex += chapterScreenCount;
			}
			return null;
		}

		//Chapter relative: 0x00 is WorldScreen 0 in chapter WorldScreens
		//Absolute: 0x00 is the first WorldScreen in all WorldScreens
        public static int GetChapterRelativeWorldScreenIndex(int chapterIndex, int absoluteWorldScreenIndex)
        {
            TmosChapter wsChapter = TmosChapterDefinitions.GetChapterOfWorldScreen(absoluteWorldScreenIndex);
            return absoluteWorldScreenIndex - wsChapter.GetWorldScreenIndexOffset();
        }

        public static int GetAbsoluteWorldScreenIndex(int chapterIndex,  int chapterRelativeWorldScreenIndex)
		{
            TmosChapter wsChapter = GetTmosChapters()[chapterIndex];
			int worldScreenIndexOffset = wsChapter.GetWorldScreenIndexOffset();
            int absoluteWorldScreenIndex = chapterRelativeWorldScreenIndex + worldScreenIndexOffset;
            return absoluteWorldScreenIndex;
        }

		public static int CalculateWorldScreenCount(TmosChapter chapter, List<TmosChapter> allChapters)
		{
			int nextChapterIndex = allChapters.IndexOf(chapter) + 1;
			if (nextChapterIndex < allChapters.Count)
			{
				return (allChapters[nextChapterIndex].WorldScreenDataStartAddress - chapter.WorldScreenDataStartAddress) / 16;
			}
			else
			{
				// For the last chapter,  might need to know the end of the data

				var def = TmosRomDataObjectDefinitions.GetTmosRomObjectInfoDefinition(TmosRomObjectType.WorldScreen);
                int beginningOfData = def.Address;

				int chapterFirstWSIndex = chapter.WorldScreenDataStartAddress - beginningOfData;
				return chapterFirstWSIndex / def.ObjectSize;

               // int endOfData = def.Address + (def.Count * def.ObjectSize);
				//return (endOfData - chapter.WorldScreenDataStartAddress) / def.ObjectSize;
			}
		}

        //public int GetWorldScreenChapterIndex(int absoluteWorldScreenIndex)
        //{
        //    TmosChapter chapter = TmosChapterDefinitions.GetWorldScreenChapter(absoluteWorldScreenIndex);

        //    int adjustedWorldScreenIndex = worldScreenIndex;


        //    for (int i = 0; i < chapter.ChapterNumber; i++)
        //    {
        //        adjustedWorldScreenIndex -= TmosChapterDefinitions.CalculateWorldScreenCount(chapters[i], chapters);
        //    }
        //    int worldScreenChapter = TmosChapter
        //}


        //_WorldScreenCollections[0] = new WorldScreenCollection(0x39695, 131, 0xC02A, 15, 0xC211, 6, 0);
        //_WorldScreenCollections[1] = new WorldScreenCollection(0x39EC5, 137, 0xC058, 16, 0xC241, 6, 1);
        //_WorldScreenCollections[2] = new WorldScreenCollection(0x3A755, 153, 0xC089, 17, 0xC271, 6, 2); //w3
        //_WorldScreenCollections[3] = new WorldScreenCollection(0x3B0E5, 164, 0xC0BD, 22, 0xC2C1, 6, 3); //w3
        //_WorldScreenCollections[4] = new WorldScreenCollection(0x3BB25, 154, 0xC100, 19, 0xC301, 8, 4);

        //TODO: Figure out how to actually determine the correct content based on the contentValue
       
		
	}

}
