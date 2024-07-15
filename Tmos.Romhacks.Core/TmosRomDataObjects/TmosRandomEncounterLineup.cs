using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Core.TmosRomDataObjects
{
	public class TmosRandomEncounterLineup : TmosRomObject
	{
		public TmosRandomEncounterLineup(byte[] bytes)
			: base(bytes)
		{
		}

		public byte Startbyte
		{
			get { return base._data[Startbyte]; }
			set { _data[Startbyte] = value; }
		}

		public byte Slot1
		{
			get { return _data[Slot1]; }
			set { _data[Slot1] = value; }
		}

		public byte Slot2
		{
			get { return _data[Slot2]; }
			set { _data[Slot2] = value; }
		}

		public byte Slot3
		{
			get { return _data[Slot3]; }
			set { _data[Slot3] = value; }
		}

		public byte Slot4
		{
			get { return _data[Slot4]; }
			set { _data[Slot4] = value; }
		}

		public byte Slot5
		{
			get { return _data[Slot5]; }
			set { _data[Slot5] = value; }
		}

		public byte Slot6
		{
			get { return _data[Slot6]; }
			set { _data[Slot6] = value; }
		}

		public byte Slot7
		{
			get { return _data[Slot7]; }
			set { _data[Slot7] = value; }
		}

	
	public enum DataContent
		{
			Startbyte, // always 00 - probably just to seperate
			Slot1,
			Slot2,
			Slot3,
			Slot4,
			Slot5,
			Slot6,
			Slot7
		}
	}
}
