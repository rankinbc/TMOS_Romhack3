using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core.TmosRomInfo;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;

namespace Tmos.Romhacks.Mods.Utility
{
    public static  class TileDataUtility
    {
    

		//private static byte GetTileRelativeByte(int WSDataPointer, bool IsFromTopTileSet, byte WSTileByteValue)
		//{
		//	int offset = CalculateOffset(WSDataPointer, IsFromTopTileSet);
		//	int offsetCount = offset / 4;
		//	int relativeTileByte = (WSTileByteValue + offsetCount);

		//	return (byte)relativeTileByte;
		//}

		//private static int CalculateOffset(int dataPointer, bool IsFromTopTileSet)
		//{
		//	int bottomTileDataOffset = 0;
		//	int topTileDataOffset = 0;
		//	if (dataPointer >= 0x40 && dataPointer < 0x8f)
		//	{
		//		bottomTileDataOffset = 0x2000;
		//		topTileDataOffset = 0x0000;
		//	}

		//	else if (dataPointer >= 0x8f && dataPointer < 0xA0)
		//	{
		//		bottomTileDataOffset = 0x0000;
		//		topTileDataOffset = 0x2000;
		//	}
		//	else if (dataPointer >= 0xC0)
		//	{
		//		topTileDataOffset = 0x2000;
		//		bottomTileDataOffset = 0x2000;
		//	}

		//	return IsFromTopTileSet ? topTileDataOffset : bottomTileDataOffset;
		//}

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

        //private static (int topTileDataOffset, int bottomTileDataOffset) GetTileDataOffsets(byte dataPointer)
        //{
        //    int bottomTileDataOffset = 0;
        //    int topTileDataOffset = 0;
        //    if (dataPointer >= 0x40 && dataPointer < 0x8f)
        //    {
        //        bottomTileDataOffset = 0x2000; //0x2000 = 8192     8192 / 32 = 256  Maybe this dataoffset just increases index 0 by 256 TileSections?
        //        topTileDataOffset = 0x0000;
        //    }

        //    else if (dataPointer >= 0x8f && dataPointer < 0xA0)
        //    {
        //        bottomTileDataOffset = 0x0000;
        //        topTileDataOffset = 0x2000;
        //    }
        //    else if (dataPointer >= 0xC0)
        //    {
        //        topTileDataOffset = 0x2000;
        //        bottomTileDataOffset = 0x2000;
        //    }
        //    return (topTileDataOffset, bottomTileDataOffset);
        //}

    }
}
