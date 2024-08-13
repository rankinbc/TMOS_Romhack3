using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom;

namespace Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles
{
    public class TmosTileSection : TmosRomObject
    {
        public TmosTileSection() : base(null)
        {
        }
        public TmosTileSection(byte[] data) : base(data)
        {
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
                    tileGrid[x, y] = _data[byteIndex];
                    byteIndex++;
                }
            }
            return tileGrid;
        }








    }
}
