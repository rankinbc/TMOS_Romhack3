using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom;

namespace Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters
{
    //The enemy party of a random encounter, each slot is a monster (eg. Samrima, Meldo etc..) todo: Determine byte values for monsters
    public class TmosRandomEncounterLineup : TmosRomObject
    {
        
        public TmosRandomEncounterLineup(byte[] bytes)
            : base(bytes)
        {
        }

        public byte Startbyte
        {
            get { return _data[(int)DataContent.Startbyte]; }
            set { _data[(int)DataContent.Startbyte] = value; }
        }

        public byte Slot1
        {
            get { return _data[(int)DataContent.Slot1]; }
            set { _data[(int)DataContent.Slot1] = value; }
        }

        public byte Slot2
        {
            get { return _data[(int)DataContent.Slot2]; }
            set { _data[(int)DataContent.Slot2] = value; }
        }

        public byte Slot3
        {
            get { return _data[(int)DataContent.Slot3]; }
            set { _data[(int)DataContent.Slot3] = value; }
        }

        public byte Slot4
        {
            get { return _data[(int)DataContent.Slot4]; }
            set { _data[(int)DataContent.Slot4] = value; }
        }

        public byte Slot5
        {
            get { return _data[(int)DataContent.Slot5]; }
            set { _data[(int)DataContent.Slot5] = value; }
        }

        public byte Slot6
        {
            get { return _data[(int)DataContent.Slot6]; }
            set { _data[(int)DataContent.Slot6] = value; }
        }

        public byte Slot7
        {
            get { return _data[(int)DataContent.Slot7]; }
            set { _data[(int)DataContent.Slot7] = value; }
        }

        public enum DataContent
        {
            Startbyte = 0, // always 00 - probably just to seperate
            Slot1 = 1,
            Slot2 = 2,
            Slot3 = 3,
            Slot4 = 4,
            Slot5 = 5,
            Slot6 = 6,
            Slot7 = 7
        }
    }
}
