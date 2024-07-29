using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.Enum;

namespace Tmos.Romhacks.Core
{
    public class TmosWorldScreen : TmosRomObject
	{
        public TmosWorldScreen() : base(null)
        {
        }
        public TmosWorldScreen(byte[] data) : base(data)
		{
		}

		public byte ParentWorld { get { return _data[(int)WSProperty.ParentWorld]; } set { _data[(int)WSProperty.ParentWorld] = value; } }
        public byte AmbientSound { get { return _data[(int)WSProperty.AmbientSound]; } set { _data[(int)WSProperty.AmbientSound] = value; } }
        public byte Content { get { return _data[(int)WSProperty.Content]; } set { _data[(int)WSProperty.Content] = value; } }
        public byte ObjectSet { get { return _data[(int)WSProperty.ObjectSet]; } set { _data[(int)WSProperty.ObjectSet] = value; } }
        public byte ScreenIndexRight { get { return _data[(int)WSProperty.ScreenIndexRight]; } set { _data[(int)WSProperty.ScreenIndexRight] = value; } }
        public byte ScreenIndexLeft { get { return _data[(int)WSProperty.ScreenIndexLeft]; } set { _data[(int)WSProperty.ScreenIndexLeft] = value; } }
        public byte ScreenIndexDown { get { return _data[(int)WSProperty.ScreenIndexDown]; } set { _data[(int)WSProperty.ScreenIndexDown] = value; } }
        public byte ScreenIndexUp { get { return _data[(int)WSProperty.ScreenIndexUp]; } set { _data[(int)WSProperty.ScreenIndexUp] = value; } }
        public byte DataPointer { get { return _data[(int)WSProperty.DataPointer]; } set { _data[(int)WSProperty.DataPointer] = value; } }
        public byte ExitPosition { get { return _data[(int)WSProperty.ExitPosition]; } set { _data[(int)WSProperty.ExitPosition] = value; } }
        public byte TopTiles { get { return _data[(int)WSProperty.TopTiles]; } set { _data[(int)WSProperty.TopTiles] = value; } }
        public byte BottomTiles { get { return _data[(int)WSProperty.BottomTiles]; } set { _data[(int)WSProperty.BottomTiles] = value; } }
        public byte WorldScreenColor { get { return _data[(int)WSProperty.WorldScreenColor]; } set { _data[(int)WSProperty.WorldScreenColor] = value; } }
        public byte SpritesColor { get { return _data[(int)WSProperty.SpritesColor]; } set { _data[(int)WSProperty.SpritesColor] = value; } }
        public byte Unknown { get { return _data[(int)WSProperty.Unknown]; } set { _data[(int)WSProperty.Unknown] = value; } }
        public byte Event { get { return _data[(int)WSProperty.Event]; } set { _data[(int)WSProperty.Event] = value; } }

    }
}
