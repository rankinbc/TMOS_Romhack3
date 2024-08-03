using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tmos.Romhacks.Core.TmosRomDataObjects.TmosRandomEncounterLineup;

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

        public byte WorldScreen { get { return _data[0]; } set { _data[0] = value; } }
        public byte MonsterGroup { get { return _data[1]; } set { _data[1] = value; } }
        public byte Unknown { get { return _data[2]; } set { _data[2] = value; } }

    }
}
