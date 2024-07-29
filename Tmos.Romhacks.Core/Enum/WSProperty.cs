using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Mods.Enum
{
    public enum WSProperty
    {
        ParentWorld, //music and some other things
        AmbientSound,
        Content,
        ObjectSet, //includes doors
        ScreenIndexRight,
        ScreenIndexLeft,
        ScreenIndexDown,
        ScreenIndexUp,
        DataPointer,
        ExitPosition,
        TopTiles,
        BottomTiles,
        WorldScreenColor,
        SpritesColor,
        Unknown,
        Event //dialog
    }
}
