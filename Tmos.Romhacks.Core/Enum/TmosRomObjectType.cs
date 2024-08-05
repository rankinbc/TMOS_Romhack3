﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomInfo
{
    public enum TmosRomObjectType
    {
        WorldScreenDataOffset,
        WorldScreen,
        WorldScreenTile,
        TileSection,
        Tile,
        MiniTile,
        // MicroTile, TODO
        RandomEncounterGroup,
        RandomEncounterLineup,
    }
}
