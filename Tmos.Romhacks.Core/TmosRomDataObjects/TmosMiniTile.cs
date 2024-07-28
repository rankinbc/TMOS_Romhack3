using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core
{
    public class TmosMiniTile : TmosRomObject
    {
        //Contains a 2x2 grid of bytes representing smaller tiles (micro-tiles) //From PPU?
        public TmosMiniTile(byte[] bytes)
            : base(bytes)
		{
        }

        public byte MicroTile1Value  //0-Top left

        {
            get { return _data[0]; }
            set { _data[0] = value; }
        }

        public byte MicroTile2Value  //1-Top right

        {
            get { return _data[1]; }
            set { _data[1] = value; }
        }

        public byte MicroTile3Value //2-Bottom left

        {
            get { return _data[2]; }
            set { _data[2] = value; }
        }

        public byte MicroTile4Value  //3-Bottom right
        {
            get { return _data[3]; }
            set { _data[3] = value; }
        }



    }
}
