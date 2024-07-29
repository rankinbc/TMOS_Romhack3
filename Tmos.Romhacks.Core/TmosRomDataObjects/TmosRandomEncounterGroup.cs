using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomDataObjects
{
    public class TmosRandomEncounterGroup : TmosRomObject
    {
        public TmosRandomEncounterGroup() : base(null)
        {
        }
        public TmosRandomEncounterGroup(byte[] data): base(data)
        {
        }
    }
}
