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



    }
}
