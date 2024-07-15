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
			DesertWorldAlalart = 1,
			Chapter3 = 2,
			Chapter4 = 3,
			Chapter5 = 4
		}
		public static List<TmosChapter> GetTmosChapters() {
			return new List<TmosChapter>()
			{
				 //TODO: load these addresses from rom pointers rather than hardcode
				new TmosChapter() { ChapterNumber = 0, Name = "Chapter 1", WorldScreenDataStartAddress=0x39695 },
				new TmosChapter() { ChapterNumber = 1, Name = "Desert World Alalart", WorldScreenDataStartAddress=0x39EC5 },
				new TmosChapter() { ChapterNumber = 2, Name = "Chapter 3" , WorldScreenDataStartAddress=0x3A755},
				new TmosChapter() { ChapterNumber = 3, Name = "Chapter 4" , WorldScreenDataStartAddress=0x3B0E5},
				new TmosChapter() { ChapterNumber = 4, Name = "Chapter 5", WorldScreenDataStartAddress = 0x3BB25 },
			};
        }

		//_WorldScreenCollections[0] = new WorldScreenCollection(0x39695, 131, 0xC02A, 15, 0xC211, 6, 0);
        //_WorldScreenCollections[1] = new WorldScreenCollection(0x39EC5, 137, 0xC058, 16, 0xC241, 6, 1);
        //_WorldScreenCollections[2] = new WorldScreenCollection(0x3A755, 153, 0xC089, 17, 0xC271, 6, 2); //w3
        //_WorldScreenCollections[3] = new WorldScreenCollection(0x3B0E5, 164, 0xC0BD, 22, 0xC2C1, 6, 3); //w3
        //_WorldScreenCollections[4] = new WorldScreenCollection(0x3BB25, 154, 0xC100, 19, 0xC301, 8, 4);

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
        public static WSContent GetContentDefinition(int chapter, byte contentValue)
		{

			//TODO: Calculate what the content is based on the chapter instead of hardcoding it
			if (chapter == 0)
			{
				switch (contentValue)
				{
					/*
					 FF Battle
00 Nothing
1D Frozen Palace
20 First Mosque-You will defeat sabaron?
7B Shop (Unused) Amulet Mashroob <blank> <blank>
7C Shop(Unused) Fighter <blank> Raincom <blank>
7D Shop(Unused) Holyrobe Raincom Spricom ?
7E Mosque
7F Troopers
A0 Hotel 10r
B0 Hotel 169r
BE Casino 1
C0 TimeDoor enter
D7 TimeDoor exit
C7 TimeDoor exit
60 Shop B20 Mashroom Key horn
61 Shop1
62 Shop (Horen Past) b60 m60 c60 rseed100
64 Shop2
75 Shop Amaries Kaitos Fighter <blank>
76 Shop Raincom <blank> Holyrobe Raincom
77 Shop Spricom ? BasidoSquad ?
78 Shop Pukin Pukin Pukin Kebabu
79 Shop mashroom key raincom holyrobe
80 Jad
81 Faruk
82 Dogos
83 Kebabu
84 Aqua Palace
85 WiseMan Monecom										
86 Achelato Princess
87 Sabaron
88 50 rupias
89 gun meca
90,1d Newborn cimaron tree
40 University
50 University
55 University
BC RupiaTree-Plant
BD RupiaTree-Tell about rupia seed
					 * */

					case 0x00: return GetWSContentDefinition(WSContentType.Nothing);
					case 0x1D: return GetWSContentDefinition(WSContentType.FrozenPalace);
					case 0x20: return GetWSContentDefinition(WSContentType.FirstMosque);
					case 0x7B: return GetWSContentDefinition(WSContentType.Shop1);
					case 0x7C: return GetWSContentDefinition(WSContentType.Shop2);
					case 0x7D: return GetWSContentDefinition(WSContentType.Shop3);
					case 0x7E: return GetWSContentDefinition(WSContentType.Mosque);
					case 0x7F: return GetWSContentDefinition(WSContentType.Troopers);
					case 0xA0: return GetWSContentDefinition(WSContentType.Hotel10r);
					case 0xB0: return GetWSContentDefinition(WSContentType.Hotel169r);
					case 0xBE: return GetWSContentDefinition(WSContentType.Casino1);
					case 0xC0: return GetWSContentDefinition(WSContentType.TimeDoorEnter);
					case 0xD7: return GetWSContentDefinition(WSContentType.TimeDoorExit);
					case 0xC7: return GetWSContentDefinition(WSContentType.TimeDoorExit2);
					case 0x60: return GetWSContentDefinition(WSContentType.ShopB20);
					case 0x61: return GetWSContentDefinition(WSContentType.Shop1);
					case 0x62: return GetWSContentDefinition(WSContentType.ShopHorenPast);
					case 0x64: return GetWSContentDefinition(WSContentType.Shop2);
					//case 0x75: return GetWSContentDefinition(WSContentType.ShopAmaries);
					//case 0x76: return GetWSContentDefinition(WSContentType.ShopRaincom);
					//case 0x77: return GetWSContentDefinition(WSContentType.ShopSpricom);
					//case 0x78: return GetWSContentDefinition(WSContentType.ShopPukin);
					//case 0x79: return GetWSContentDefinition(WSContentType.ShopMashroom);
					//case 0x80: return GetWSContentDefinition(WSContentType.Jad);
					case 0x81: return GetWSContentDefinition(WSContentType.Faruk);

					case 0x82: return GetWSContentDefinition(WSContentType.Dogos);
					case 0x83: return GetWSContentDefinition(WSContentType.Kebabu);
					case 0x84: return GetWSContentDefinition(WSContentType.AquaPalace);
					case 0x85: return GetWSContentDefinition(WSContentType.WiseManMonecom);
					case 0x86: return GetWSContentDefinition(WSContentType.AchelatoPrincess);
					case 0x87: return GetWSContentDefinition(WSContentType.Sabaron);
					//case 0x88: return WSContentDefinitions.GetWSContentDefinition(WSContentType.Rupias50);
					case 0x89: return GetWSContentDefinition(WSContentType.GunMeca);
					case 0x90: return GetWSContentDefinition(WSContentType.NewBornCimaronTree);
					//case 0x1D: return GetWSContentDefinition(WSContentType.NewBornCimaronTree);
					case 0x40: return GetWSContentDefinition(WSContentType.University);
					case 0x50: return GetWSContentDefinition(WSContentType.University);
					case 0x55: return GetWSContentDefinition(WSContentType.University);
					//case 0xBC: return WSContentDefinitions.GetWSContentDefinition(WSContentType.RupiaTreePlant);
					//case 0xBD: return WSContentDefinitions.GetWSContentDefinition(WSContentType);
					default: return GetWSContentDefinition(WSContentType.UNKNOWN);



				}
			}
			else
			{
				return new WSContent() { Value=contentValue, Name = "UNKNOWN", ContentType = WSContentType.UNKNOWN };
			}
			//else if (chapter == 1)
			//{
			//}
			//else if (chapter == 2)
			//{
			//}
			//else if (chapter == 3)
			//{
			//}
			//else if (chapter == 4)
			//{
			//}
			

		}
	}

}
