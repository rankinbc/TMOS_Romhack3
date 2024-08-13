using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Library.RomObjects.Tiles
{
    public class TmosModWorldScreenTile
    {
        public byte TileIndexValue { get; set; } //Index of tile data objects
        public TmosModWorldScreenTile(byte[] data)
        {
            TileIndexValue = data[0];
        }
    }
}
