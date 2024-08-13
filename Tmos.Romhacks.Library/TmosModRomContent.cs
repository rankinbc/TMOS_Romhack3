using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Definitions;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Library.RomObjects.Tiles;
using Tmos.Romhacks.Library.RomObjects.WorldScreen;
using Tmos.Romhacks.Library.Utility;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Tiles;

namespace Tmos.Romhacks.Library
{
    public class TmosModRomContent
    {
        public TmosModWorldScreenTile[] WorldScreenTiles { get; set; }
        public TmosModWorldScreen[] WorldScreens { get; set; }
        public TmosTileSection[] TileSections { get; set; }
        public TmosModTile[] Tiles { get; set; }
        public TmosMiniTile[] MiniTiles { get; set; }
        public TmosRandomEncounterGroup[] RandomEncounterGroups { get; set; }
        public TmosRandomEncounterLineup[] RandomEncounterLineups { get; set; }
        public Dictionary<GameVariableEnum, byte[]> GameVariables { get; set; }


		public byte[] TileData { get; set; } //Entire tile data section from rom

        public TmosModRomContent()
        {

        }

    }
}
