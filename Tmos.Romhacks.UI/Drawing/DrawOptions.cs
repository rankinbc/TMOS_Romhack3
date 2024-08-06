using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tmos.Romhacks.UI.Drawers.TmosDrawer;

namespace Tmos.Romhacks.UI.Drawers
{
    public class MapDrawOptions
    {
        public int TileSize { get; set; }
        public TmosWorldScreenDrawOptions WorldScreenDrawOptions { get; set; }
        public TileDrawOptions TileDrawOptions { get; set; }
    }

    public class TmosWorldScreenDrawOptions
    {
        public bool ShowInfo { get; set; }
        public bool ShowBorders { get; set; }
        public int TileSize { get; set; }

        public TileDrawOptions TileDrawOptions { get; set; }
    }

    public class TileDrawOptions
    {
        public bool ShowCollision { get; set; }

        public bool ShowBorders { get; set; }
        public bool ShowImage { get; set; }
        public int ImageOpacity { get; set; }
        public bool ShowInfo { get; set; }

    }
}
