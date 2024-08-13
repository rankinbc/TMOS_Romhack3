using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Definitions;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Rom;
using static Tmos.Romhacks.Library.TileDefinitions;


namespace Tmos.Romhacks.Library.RomObjects.Tiles
{
    [DebuggerDisplay("{WSTileValue}")]
    public class TmosModTile : TmosRomObject, ITile
    {
        public byte WSTileValue { get; set; } //The value of the tile on the WS
                                              //   public TileType TileType { get; set; }
                                              //public string Name { get; set; }

        //public TmosModMiniTile[] MiniTiles { get; set; }

        //FinalTileValue and TmosTileIndex shouldnt be on this object - they are related to how to find this tile object in data- this will cause problems so should refactor
        public int FinalTileValue { get; set; } //The final tile value using the offsets determined from the WS containing this tile
        public int TmosTileIndex { get; set; } //Address offset of this tile in WSTile memory


        public TmosModTile(byte[] bytes) : base(bytes)
        {


        }
        public TmosModTile(byte wsTileValue, byte[] tileData) : base(tileData)
        {
            WSTileValue = wsTileValue;
        }
        public TmosModTile(byte WSTileValue) : base(new byte[] { })
        {
            this.WSTileValue = WSTileValue;
            //Load minitiles?

        }

        public bool IsWalkable()        //TODO: Figure out how to actually calculate instead of using hard-coded definitions - actuall collision stuff is prob in microtiles
        {
            return TileIsWalkable(WSTileValue);
        }


        public byte MiniTile_TopLeft
        {
            get { return _data[0]; }
            set { _data[0] = value; }
        }

        public byte MiniTile2_TopRight
        {
            get { return _data[1]; }
            set { _data[1] = value; }
        }

        public byte MiniTile3_BottomLeft
        {
            get { return _data[2]; }
            set { _data[2] = value; }
        }

        public byte MiniTile4_BottomRight
        {
            get { return _data[3]; }
            set { _data[3] = value; }
        }



    }
}
