using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Library.Enum
{
    public enum TileType //Not sure if this is a good idea. Should probably just stick to identifying by the byte value
    {
        NotDefined = 0x00, //Handles all other values
        Desert = 0x23,
        Water = 0x3F,
        Lava = 0x42,
        GrassBushes = 0x43,
        WaterTopEdge = 0x44,
        Grass = 0x46,
        Tree = 0x47,
        DesertTrees = 0x6F,

    }
}
