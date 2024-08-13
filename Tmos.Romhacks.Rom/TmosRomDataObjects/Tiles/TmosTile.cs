using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom;

namespace Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles
{
    public class TmosTile : TmosRomObject
    {
        public TmosTile() : base(null)
        {
        }
        public TmosTile(byte[] bytes = null) : base(bytes)
        {
        }

        public byte MiniTile1Value  //0-Top left

        {
            get { return _data[0]; }
            set { _data[0] = value; }
        }

        public byte MiniTile2Value  //1-Top right

        {
            get { return _data[1]; }
            set { _data[1] = value; }
        }

        public byte MiniTile3Value //2-Bottom left

        {
            get { return _data[2]; }
            set { _data[2] = value; }
        }

        public byte MiniTile4Value  //3-Bottom right
        {
            get { return _data[3]; }
            set { _data[3] = value; }
        }

    }
}
