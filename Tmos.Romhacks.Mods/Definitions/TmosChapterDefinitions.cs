using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Core.TmosRomInfo.TmosRomKnownAddresses;
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

       

        public static List<TmosChapter> GetTmosChapters()
        {
            return new List<TmosChapter>()
            {
				 //TODO: load these addresses from rom pointers rather than hardcode
				new TmosChapter()
                {
                    ChapterNumber = 0,
                    Name = "Water World Maroon",
                    WorldScreenDataStartAddress= ChapterDataOffsets.Chapter1.WorldScreenDataStartAddress,
                    RandomEncounterGroupDataOffset = ChapterDataOffsets.Chapter1.RandomEncounterGroupDataOffset,
                    RandomEncounterGroupDataCount = 15,
                    RandomEncounterLineupDataOffset = ChapterDataOffsets.Chapter1.RandomEncounterLineupDataOffset,
                    RandomEncounterLineupCount = 6
                },
                new TmosChapter()
                {
                    ChapterNumber = 1,
                    Name = "Desert World Alalart",
                    WorldScreenDataStartAddress= ChapterDataOffsets.Chapter2.WorldScreenDataStartAddress,
                    RandomEncounterGroupDataOffset = ChapterDataOffsets.Chapter2.RandomEncounterGroupDataOffset,
                    RandomEncounterGroupDataCount = 16,
                    RandomEncounterLineupDataOffset =ChapterDataOffsets.Chapter2.RandomEncounterLineupDataOffset,
                    RandomEncounterLineupCount = 6
},
                new TmosChapter()
                {
                    ChapterNumber = 2,
                    Name = "Forest World Samalkand",
                    WorldScreenDataStartAddress= ChapterDataOffsets.Chapter3.WorldScreenDataStartAddress,
                    RandomEncounterGroupDataOffset = ChapterDataOffsets.Chapter3.RandomEncounterGroupDataOffset,
                    RandomEncounterGroupDataCount = 17,
                    RandomEncounterLineupDataOffset =ChapterDataOffsets.Chapter3.RandomEncounterLineupDataOffset,
                    RandomEncounterLineupCount = 6
},
                new TmosChapter()
                {
                    ChapterNumber = 3,
                    Name = "Flower World Celestern",
                    WorldScreenDataStartAddress= ChapterDataOffsets.Chapter4.WorldScreenDataStartAddress,
                    RandomEncounterGroupDataOffset = ChapterDataOffsets.Chapter4.RandomEncounterGroupDataOffset,
                    RandomEncounterGroupDataCount = 22,
                    RandomEncounterLineupDataOffset = ChapterDataOffsets.Chapter4.RandomEncounterLineupDataOffset,
                    RandomEncounterLineupCount = 6
                },
                new TmosChapter()
                {
                    ChapterNumber = 4,
                    Name = "Evil Magician Sabaron",
                    WorldScreenDataStartAddress= ChapterDataOffsets.Chapter5.WorldScreenDataStartAddress,
                    RandomEncounterGroupDataOffset = ChapterDataOffsets.Chapter5.RandomEncounterGroupDataOffset,
                    RandomEncounterGroupDataCount = 19,
                    RandomEncounterLineupDataOffset = ChapterDataOffsets.Chapter5.RandomEncounterLineupDataOffset,
                    RandomEncounterLineupCount = 8
                }
            };
        }
    }

}
