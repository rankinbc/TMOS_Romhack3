﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tmos.Romhacks.Core.TmosRomDataObjects.TmosRandomEncounterLineup;

namespace Tmos.Romhacks.Core.TmosRomDataObjects
{
    //I think this object is just a join between WorldScreens and the possible encounters that can happen on them
    public class TmosRandomEncounterGroup : TmosRomObject
    {
        public TmosRandomEncounterGroup() : base(null)
        {
        }
        public TmosRandomEncounterGroup(byte[] data): base(data)
        {
        }

        //Points to a worldscreen, indicating this monstegroup can appear on that worldscreen
        public byte WorldScreen { get { return _data[0]; } set { _data[0] = value; } }

        //Possibly a pointer to RandomEncounterLineup object?
        public byte MonsterGroup { get { return _data[1]; } set { _data[1] = value; } }
        public byte Unknown { get { return _data[2]; } set { _data[2] = value; } }

    }
}
