﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;
using Tmos.Romhacks.Mods.Enum;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;
using static Tmos.Romhacks.Mods.TileDefinitions;

namespace Tmos.Romhacks.Mods
{

    public class TileDefinition
    {
        //public (byte dataPointer, byte value) TileKey; //Ideally this object could work without having to include the dataPointer of the parent WorldScreen
        public TileType TileType { get; set; }
        public string Name { get; set; }
        public bool IsWalkable { get; set; } //FUTURE TODO: Figure out how to actually calculate instead of using hard-coded definitions'
    }

    public class TileDefinitions
    {
        private static byte[] KnownCollidableTiles = { 0x22, 0x47, 0x87, 0x89, 0x86, 0x88, 0x8F, 0x94, 0x92, 0x95, 0x41, 0x3F, 0x2F, 0x30, 0xB2, 0xB3,
                                                0xA9, 0xE2,0xA9,0xAF, 0xAD, 0xAA,0xAB, 0xF4, 0xFB, 0xCF,0xFB, 0xFE, 0xFC,0xFB,0xAC, 0xBC, 0xBC, 0xBD, 0xBE, 0xB5, 0xBF,0xB9, 0xB8, 0xC0,//Town building walls
                                                0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x93, 0x8A, 0x93, 0x8A,//Town/dungeon entrance walls
                                                0xF6, 0xF7, 0xF9, 0xF8, 0xDE, 0xDE, //Underwater walls
                                                0x6B, 0x62,0x55, 0x53,0x54, 0x57, 0x58, 0x59, 0x5D, 0x56,0x5A, 0x5B, 0x5C,0x5E, 0x5F, 0x60, 0x61, 0x63,0x64,0x67,0x68, 0x77,0x78,0xD5,0xD6,0xA1,0xA2,//Dungeon walls
												0x23,
                                                0x4C,
                                                0x80, 0x81, 0x82, 0x83, 0x84, 0xC1, 0x7A, 0x7B, 0x7C, 0x7F, 0x7D, 0x96, 0x97, //distant view (when walking on higher elevation)
                                                0x00, 0x01, 0x02,0x07, 0x08, 0x09, 0x10, 0x15, 0x19, 0x11, 0x14, 0x0F, 0x16, 0x0D,0x17,0x18,0x0A, 0x0E, //maze walls
                                                0x50, 0x4F, 0x51, 0x52, 0xCB, 0xCC //dark world
                                                //0x20 - special tile? mosque tower things & also walkable jar value
		};

        private static byte[] KnownWaterTiles = { 0x41, 0x3F, 0x2F, 0x30, 0xEC, 0x6F };

        private static byte[] KnownLavaTiles = { 0x40, 0x42};

        public static bool TileIsWalkable(byte tileValue)
        {
           if (KnownCollidableTiles.Contains(tileValue) ||
               KnownWaterTiles.Contains(tileValue) ||
               KnownLavaTiles.Contains(tileValue))
            {
                return false;
            }
            else
            {
                return true;
            }   

        }













    }

}



