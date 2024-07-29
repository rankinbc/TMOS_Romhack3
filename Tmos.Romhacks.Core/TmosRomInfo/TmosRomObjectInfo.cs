using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomInfo
{
    public class TmosRomObjectInfo
    {
        public TmosRomObjectType TmosDataObjectType { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }//Location of the beginning of the array of objects
        public int ObjectSize { get; set; } //Size of each object (in bytes)
        public int Count { get; set; } //Number of objects that exist
        public string Description { get; set; }
    }
}
