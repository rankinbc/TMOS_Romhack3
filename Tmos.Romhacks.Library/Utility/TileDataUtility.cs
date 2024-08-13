using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Rom;

namespace Tmos.Romhacks.Library.Utility
{
    public static  class TileDataUtility
    {
		public static int GetTmosModTileSectionAbsoluteIndex(int tileSectionRelativeIndex, byte dataPointer, bool isTopTileSection)
        {
            int offsetBytes = isTopTileSection ? GetTopTileSectionTileDataOffset(dataPointer) : GetBottomTileSectionTileDataOffset(dataPointer);
            int offsetIndex = 0;
            if (offsetBytes > 0)
            {
                offsetIndex = offsetBytes / TmosRomDataObjectDefinitions.RomInfo_TileSection.ObjectSize;
            }
            return tileSectionRelativeIndex + offsetIndex;
        }

        public static int GetTopTileSectionTileDataOffset(byte dataPointer)
        {
            //  return GetTileDataOffsets(dataPointer).topTileDataOffset;
            int topTileDataOffset = 0;

            if (dataPointer >= 0x8f && dataPointer < 0xA0 || dataPointer >= 0xC0)
            {
                topTileDataOffset = 0x2000; //8192 
            }
            return topTileDataOffset;
        }


        public static int GetBottomTileSectionTileDataOffset(byte dataPointer)
        {
            //return GetTileDataOffsets(dataPointer).bottomTileDataOffset;
            int bottomTileDataOffset = 0;

            if (dataPointer >= 0x40 && dataPointer < 0x8f || dataPointer >= 0xC0)
            {
                bottomTileDataOffset = 0x2000;
            }
            return bottomTileDataOffset;
        }


    }
}
