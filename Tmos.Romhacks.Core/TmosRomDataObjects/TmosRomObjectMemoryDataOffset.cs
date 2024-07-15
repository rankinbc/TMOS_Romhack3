using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core
{
    public class TmosRomObjectMemoryDataOffset : TmosRomObject
	{
        public TmosRomObjectMemoryDataOffset(byte[] data) : base(data)
		{
        }
		public TmosRomObjectMemoryDataOffset(short offSetValue) : base(BitConverter.GetBytes(offSetValue))
		{         
		}

		//Get as int (convert byte[2] to int to get true value)
		public short GetAsInt16()
        {
			return BitConverter.ToInt16(_data, 0);
		}
    }
}
