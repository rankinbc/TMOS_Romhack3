using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core
{
    public  class TmosTileSection : TmosRomObject
	{
  
        public TmosTileSection(byte[] data) : base(data)
		{
        }

        //public byte GetTileValue(int x, int y)
        //{
        //	return GetTileSectionGrid()[x, y]; //TODO make more efficient
        //}
        public byte[] GetBytes()
        {
            return _data;
        }

        public void UpdateBytes(byte[] newData)
        {
             _data = newData;
        }
        public byte[,] GetTileSectionGrid()
        {
            byte[,] tileGrid = new byte[8, 4]; //(0,0) top left
            int byteIndex = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    tileGrid[x, y] = _data[byteIndex ];
                    byteIndex++;
                }
            }
            return tileGrid;
        }


        





    }
}
