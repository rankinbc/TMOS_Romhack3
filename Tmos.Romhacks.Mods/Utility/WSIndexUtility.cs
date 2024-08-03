using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.Definitions;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;

namespace Tmos.Romhacks.Mods.Utility
{
    public static class WSIndexUtility
    {
        //Chapter relative: 0x00 is WorldScreen 0 in chapter WorldScreens
        //Absolute: 0x00 is the first WorldScreen in all WorldScreens

        //Gets the WS index relative to the first absoluteWorldScreen in the chapter
        public static byte GetChapterRelativeWorldScreenIndex(int absoluteWorldScreenIndex)
        {
            TmosChapter wsChapter = ChapterUtility.GetChapterOfWorldScreen(absoluteWorldScreenIndex);
            return (byte)(absoluteWorldScreenIndex - wsChapter.GetWorldScreenIndexOffset());
        }

        //Gets the absolute WS index based on the relative WS index in the chapter
        public static int GetAbsoluteWorldScreenIndex(int chapterIndex, int chapterRelativeWorldScreenIndex)
        {
            TmosChapter wsChapter = TmosChapterDefinitions.GetTmosChapters()[chapterIndex];
            int worldScreenIndexOffset = wsChapter.GetWorldScreenIndexOffset();
            int absoluteWorldScreenIndex = chapterRelativeWorldScreenIndex + worldScreenIndexOffset;
            return absoluteWorldScreenIndex;
        }

        #region WSDirectionalNeighbors

     
        public static int GetNeighborWorldScreenAbsoluteIndex(int chapter, TmosModWorldScreen ws,  Direction direction)
        {
            byte relativeIndex = GetNeighborWorldScreenRelativeIndex(ws, direction);
            return (byte)GetAbsoluteWorldScreenIndex(chapter, relativeIndex);
        }

        public static byte GetNeighborWorldScreenRelativeIndex(TmosModWorldScreen ws, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right: return ws.ScreenIndexRight;
                case Direction.Left: return ws.ScreenIndexLeft;
                case Direction.Up: return ws.ScreenIndexUp;
                case Direction.Down: return ws.ScreenIndexDown;
                default: return ws.ScreenIndexUp;
            }
        }

        #endregion WSDirectionalNeighbors
    }
}
