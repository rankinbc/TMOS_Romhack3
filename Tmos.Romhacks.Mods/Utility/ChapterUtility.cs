using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.TypedTmosObjects;

namespace Tmos.Romhacks.Mods.Utility
{
    public static class ChapterUtility
    {
        public static TmosChapter GetChapterOfWorldScreen(int absoluteWorldScreenIndex)
        {
            List<TmosChapter> chapters = TmosChapterDefinitions.GetTmosChapters();
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

            }
        }
    }
}
