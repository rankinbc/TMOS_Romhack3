using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;

namespace Tmos.Romhacks.Mods
{
    public class TmosModWorldScreenTile
    {
        public byte TileIndex { get; set; } //Index of tile data objects
        public TmosModWorldScreenTile(byte[] data)
        {
            TileIndex = data[0];
        }
    }
}
