using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core
{
   public class TmosRomObject
    {
        protected byte[] _data;
        public TmosRomObject(byte[] data)
        {
            _data = data;
        }

        public byte[] GetBytes()
        {
            return _data;
        }
    }
}
