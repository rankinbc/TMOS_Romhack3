using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Mods.Enum.KnownValueLibrary
{
    //Gets the correct WSContent for the specified chapter
     public static class WSContentTypeChapterLookup
    {
        public static WSContentType GetWSContentType(byte content, int? chapter = null)
        {
            //0x80 - 0x8F are Chapter-specific content types
            if (content > 0x8A && content < 0x8F) //Content is different based on the chapter
            {
                if (chapter == 0) //Chapter 1
                {
                    switch (content)
                    {
                        case 0x80: return WSContentType.Jad;
                        case 0x81: return WSContentType.Faruk;
                        case 0x82: return WSContentType.Dogos;
						case 0x83: return WSContentType.Kebabu;
						case 0x84: return WSContentType.AquaPalace;
                        case 0x85: return WSContentType.WiseManMonecom;
                        case 0x86: return WSContentType.AchelatoPrincess;
                        case 0x87: return WSContentType.SabaronTalk;
                        default: return WSContentType.Nothing;
                    }
                }
                else if (chapter == 1) //Chapter 2
				{
                    switch (content)
                    {
                        case 0x80: return WSContentType.GunMeca;
                        case 0x81: return WSContentType.Lah;
                        case 0x82: return WSContentType.Supica;
                        case 0x83: return WSContentType.Epin;
                        case 0x84: return WSContentType.WisemanRaincome;
                        case 0x87: return WSContentType.Princess1;
                        case 0x8D: return WSContentType.RupiaSeedPlant;
                        default: return WSContentType.Nothing;
                    }
                }
                else if (chapter == 2) //Chapter 3
				{
                    switch (content)
                    {
                        case 0x80: return WSContentType.NewBornCimaronTree;
                        case 0x81: return WSContentType.CimaronTree;
                        case 0x82: return WSContentType.Supapa;

                        case 0x84: return WSContentType.Mustafa;
                        case 0x85: return WSContentType.FrozenPalace2;
                        case 0x87: return WSContentType.WiseManSpricom;
						default: return WSContentType.Nothing;
                    }
                }
                else if (chapter == 3) //Chapter 4
				{
                    switch (content)
                    {
                        case 0x80: return WSContentType.Gubibi;
                        case 0x81: return WSContentType.Rainy;
                        case 0x82: return WSContentType.YuflaPalace;
                        case 0x84: return WSContentType.Rostam;
                        case 0x85: return WSContentType.KingFiesal;
						case 0x87: return WSContentType.RupiasLady;
						default: return WSContentType.Nothing;
                    }
                }
                else//Chapter 5
				{
                    switch (content)
                    {
                        case 0x80: return WSContentType.WisemanMoscome;
                        case 0x81: return WSContentType.Hasan;
                        case 0x82: return WSContentType.Kaji;
                        case 0x83: return WSContentType.LegendSword;
                        case 0x84: return WSContentType.ArmorofLight;
                        case 0x86: return WSContentType.OnlyOneJarYouCanGoThrough;
                        default: return WSContentType.Nothing;
                    }
                }
            }
            else //Content is universal between chapters 
            {
                WSContentTypeByteValue wsContentTypeByteValue = (WSContentTypeByteValue)content;
                switch (wsContentTypeByteValue)
                {
                    case WSContentTypeByteValue.Nothing: return WSContentType.Nothing;
                    case WSContentTypeByteValue.WizardBattleOnEnter: return WSContentType.WizardBattleOnEnter;
                    case WSContentTypeByteValue.FrozenPalace: return WSContentType.FrozenPalace;
                    case WSContentTypeByteValue.FirstMosque: return WSContentType.FirstMosque;
                    case WSContentTypeByteValue.Gilga: return WSContentType.Gilga;
                    case WSContentTypeByteValue.Gilga2: return WSContentType.Gilga2;
                    case WSContentTypeByteValue.Curly: return WSContentType.Curly;
                    case WSContentTypeByteValue.Curly2: return WSContentType.Curly2;
                    case WSContentTypeByteValue.Troll: return WSContentType.Troll;
                    case WSContentTypeByteValue.Troll2: return WSContentType.Troll2;
                    case WSContentTypeByteValue.Salamander: return WSContentType.Salamander;
                    case WSContentTypeByteValue.Salamander2: return WSContentType.Salamander2;
                    case WSContentTypeByteValue.GoraGora: return WSContentType.GoraGora;
                    case WSContentTypeByteValue.GoraGora2: return WSContentType.GoraGora2;
                    case WSContentTypeByteValue.University_40: return WSContentType.University_40;
                    case WSContentTypeByteValue.University_41: return WSContentType.University_41;
                    case WSContentTypeByteValue.University_42: return WSContentType.University_42;
                    case WSContentTypeByteValue.University_43: return WSContentType.University_43;
                    case WSContentTypeByteValue.University_44: return WSContentType.University_44;
                    case WSContentTypeByteValue.University_50: return WSContentType.University_50;
                    case WSContentTypeByteValue.University_55: return WSContentType.University_55;
                    case WSContentTypeByteValue.Shop_60: return WSContentType.Shop_60;
                    case WSContentTypeByteValue.Shop_61: return WSContentType.Shop_61;
                    case WSContentTypeByteValue.Shop_62: return WSContentType.Shop_62;
                    case WSContentTypeByteValue.Shop_63: return WSContentType.Shop_63;
                    case WSContentTypeByteValue.Shop_64: return WSContentType.Shop_64;
                    case WSContentTypeByteValue.Shop_65: return WSContentType.Shop_65;
                    case WSContentTypeByteValue.Shop_66: return WSContentType.Shop_66;
                    case WSContentTypeByteValue.Shop_7B: return WSContentType.Shop_7B;
                    case WSContentTypeByteValue.Shop_7C: return WSContentType.Shop_7C;
                    case WSContentTypeByteValue.Shop_7D: return WSContentType.Shop_7D;
                    case WSContentTypeByteValue.Mosque: return WSContentType.Mosque;
                    case WSContentTypeByteValue.Troopers: return WSContentType.Troopers;
                    case WSContentTypeByteValue.ChapterContent_80: return WSContentType.Jad;
                    case WSContentTypeByteValue.ChapterContent_81: return WSContentType.Faruk;
                    case WSContentTypeByteValue.ChapterContent_82: return WSContentType.Dogos;
                    case WSContentTypeByteValue.ChapterContent_83: return WSContentType.Kebabu;
                    case WSContentTypeByteValue.ChapterContent_84: return WSContentType.AquaPalace;
                    case WSContentTypeByteValue.ChapterContent_85: return WSContentType.WiseManMonecom;
                    case WSContentTypeByteValue.ChapterContent_86: return WSContentType.AchelatoPrincess;
                    case WSContentTypeByteValue.RupiasLady: return WSContentType.RupiasLady;
                    case WSContentTypeByteValue.Rupias: return WSContentType.Rupias;
                    case WSContentTypeByteValue.ChapterContent_89: return WSContentType.GunMeca;
                    case WSContentTypeByteValue.Hotel_A0: return WSContentType.Hotel_A0;
                    case WSContentTypeByteValue.Hotel_A1: return WSContentType.Hotel_A1;
                    case WSContentTypeByteValue.Hotel_A2: return WSContentType.Hotel_A2;
                    case WSContentTypeByteValue.Hotel_A3: return WSContentType.Hotel_A3;
                    case WSContentTypeByteValue.Hotel_A4: return WSContentType.Hotel_A4;
                    case WSContentTypeByteValue.Hotel_A5: return WSContentType.Hotel_A5;
                    case WSContentTypeByteValue.Hotel_A6: return WSContentType.Hotel_A6;
                    case WSContentTypeByteValue.Hotel_A7: return WSContentType.Hotel_A7;
                    case WSContentTypeByteValue.Hotel_A8: return WSContentType.Hotel_A8;
                    case WSContentTypeByteValue.Hotel_A9: return WSContentType.Hotel_A9;
                    case WSContentTypeByteValue.Hotel_B0: return WSContentType.Hotel_B0;
                    case WSContentTypeByteValue.RupiaSeedPlant: return WSContentType.RupiaSeedPlant;
                    case WSContentTypeByteValue.RupiaTree_BD: return WSContentType.RupiaTree_BD;
                    case WSContentTypeByteValue.Casino_1_BE: return WSContentType.Casino_1_BE;
                    case WSContentTypeByteValue.TimeDoorEnter: return WSContentType.TimeDoorEnter;
                    case WSContentTypeByteValue.TimeDoorExit_C7: return WSContentType.TimeDoorExit_C7;
                    case WSContentTypeByteValue.TimeDoorExit: return WSContentType.TimeDoorExit;
                    case WSContentTypeByteValue.Battle: return WSContentType.Battle;
                    default: return WSContentType.Nothing;
                }

            }
        }



        public enum WSContentTypeByteValue  //The values that are used on world screens to represent the content
        {
            Nothing = 0x00,
            WizardBattleOnEnter = 0x01,
            Content_0x02 = 0x02,
            Content_0x03 = 0x03,
            Content_0x04 = 0x04,
            Content_0x05 = 0x05,
            Content_0x06 = 0x06,
            Content_0x07 = 0x07,
            Content_0x08 = 0x08,
            Content_0x09 = 0x09,
            Content_0x0A = 0x0A,
            Content_0x0B = 0x0B,
            Content_0x0C = 0x0C,
            Content_0x0D = 0x0D,
            Content_0x0E = 0x0E,
            Content_0x0F = 0x0F,
            Content_0x10 = 0x10,
            Content_0x11 = 0x11,
            Content_0x12 = 0x12,
            Content_0x13 = 0x13,
            Content_0x14 = 0x14,
            Content_0x15 = 0x15,
            Content_0x16 = 0x16,
            Content_0x17 = 0x17,
            Content_0x18 = 0x18,
            Content_0x19 = 0x19,
            Content_0x1A = 0x1A,
            Content_0x1B = 0x1B,
            Content_0x1C = 0x1C,
            FrozenPalace = 0x1D,
            Content_0x1E = 0x1E,
            Content_0x1F = 0x1F,
            FirstMosque = 0x20, //"You will defeat sabaron?" mosque
            Gilga = 0x21,
            Gilga2 = 0x22,
            Curly = 0x23,
            Curly2 = 0x24,
            Troll = 0x25,
            Troll2 = 0x26,
            Salamander = 0x27,
            Salamander2 = 0x28,
            GoraGora = 0x29,
            GoraGora2 = 0x2A,
            Content_0x2B = 0x2B,
            Content_0x2C = 0x2C,
            Content_0x2D = 0x2D,
            Content_0x2E = 0x2E,
            Content_0x2F = 0x2F,
            Content_0x30 = 0x30,
            Content_0x31 = 0x31,
            Content_0x32 = 0x32,
            Content_0x33 = 0x33,
            Content_0x34 = 0x34,
            Content_0x35 = 0x35,
            Content_0x36 = 0x36,
            Content_0x37 = 0x37,
            Content_0x38 = 0x38,
            Content_0x39 = 0x39,
            Content_0x3A = 0x3A,
            Content_0x3B = 0x3B,
            Content_0x3C = 0x3C,
            Content_0x3D = 0x3D,
            Content_0x3E = 0x3E,
            Content_0x3F = 0x3F,
            University_40 = 0x40,
            University_41 = 0x41,
            University_42 = 0x42,
            University_43 = 0x43,
            University_44 = 0x44,
            Content_0x45 = 0x45,
            Content_0x46 = 0x46,
            Content_0x47 = 0x47,
            Content_0x48 = 0x48,
            Content_0x49 = 0x49,
            Content_0x4A = 0x4A,
            Content_0x4B = 0x4B,
            Content_0x4C = 0x4C,
            Content_0x4D = 0x4D,
            Content_0x4E = 0x4E,
            Content_0x4F = 0x4F,
            University_50 = 0x50,
            Content_0x51 = 0x51,
            Content_0x52 = 0x52,
            Content_0x53 = 0x53,
            Content_0x54 = 0x54,
            University_55 = 0x55,
            Content_0x56 = 0x56,
            Content_0x57 = 0x57,
            Content_0x58 = 0x58,
            Content_0x59 = 0x59,
            Content_0x5A = 0x5A,
            Content_0x5B = 0x5B,
            Content_0x5C = 0x5C,
            Content_0x5D = 0x5D,
            Content_0x5E = 0x5E,
            Content_0x5F = 0x5F,
            Shop_60 = 0x60, // B20 M Key horn
            Shop_61 = 0x61,
            Shop_62 = 0x62, // B60 M60 C60 RSeed100
            Shop_63 = 0x63,
            Shop_64 = 0x64,
            Shop_65 = 0x65,
            Shop_66 = 0x66,
            Content_0x67 = 0x67,
            Content_0x68 = 0x68,
            Content_0x69 = 0x69,
            Content_0x6A = 0x6A,
            Content_0x6B = 0x6B,
            Content_0x6C = 0x6C,
            Content_0x6D = 0x6D,
            Content_0x6E = 0x6E,
            Content_0x6F = 0x6F,
            Content_0x70 = 0x70,
            Content_0x71 = 0x71,
            Content_0x72 = 0x72,
            Content_0x73 = 0x73,
            Content_0x74 = 0x74,
            Content_0x75 = 0x75,
            Content_0x76 = 0x76,
            Content_0x77 = 0x77, //Unused shop?
            Content_0x78 = 0x78, //Unused shop?
            Content_0x79 = 0x79, //Unused shop?
            Content_0x7A = 0x7A,
            Shop_7B = 0x7B, // Amulet Mashroob <blank> <blank>
            Shop_7C = 0x7C, // Fighter <blank> Raincom <blank>
            Shop_7D = 0x7D, // Holyrobe Raincom Spricom
            Mosque = 0x7E,
            Troopers = 0x7F,
            ChapterContent_80 = 0x80, // 1-Jad, 2-Gun Meca, 3-New born Cimaron Tree, 4-Gubibi, 5-Hasan
            ChapterContent_81 = 0x81, // 1-Faruk, 2-Lah, 3-Cimaron Tree, 4-Rainy, 5-Kaji
            ChapterContent_82 = 0x82, // 1-Dogos, 2-Supica, 3-Supapa, 4-Yufla Palace, 5-Armor of Light
            ChapterContent_83 = 0x83, // 1-Kebabu, 2-Epin, 3-Mustafa, 4-Rostam, 5-Armor of Light2?
            ChapterContent_84 = 0x84, // 1-Aqua Palace, 2-Wiseman, 3-Frozen Palace, 4-Hero Rostams Sword, 5-Palace Entrance
            ChapterContent_85 = 0x85, // 1-WiseMan Monecom, 2-Princess, 3-Wiseman Raincome, 4-King Fiesal, 5-Sabaron Final
            ChapterContent_86 = 0x86, // 1-Achelato Princess, 2-Princess, 3-Wiseman Raincome, 4-Wiseman Moscome, 5-Only One Jar You Can Go Through
            RupiasLady = 0x87, //50 Reupias
            Rupias = 0x88, // 50 rupias  ///?
            ChapterContent_89 = 0x89, // 2-Gun Meca
            ChapterContent_8A = 0x8A,
            ChapterContent_8B = 0x8B,
            ChapterContent_8C = 0x8C,
            ChapterContent_8D = 0x8D,
            ChapterContent_8E = 0x8E,
            ChapterContent_8F = 0x8F,
            Content_0x90 = 0x90,
            Content_0x91 = 0x91,
            Content_0x92 = 0x92,
            Content_0x93 = 0x93,
            Content_0x94 = 0x94,
            Content_0x95 = 0x95,
            Content_0x96 = 0x96,
            Content_0x97 = 0x97,
            Content_0x98 = 0x98,
            Content_0x99 = 0x99,
            Content_0x9A = 0x9A,
            Content_0x9B = 0x9B,
            Content_0x9C = 0x9C,
            Content_0x9D = 0x9D,
            Content_0x9E = 0x9E,
            Content_0x9F = 0x9F,
            Hotel_A0 = 0xA0, // 10r
            Hotel_A1 = 0xA1, // 20r
            Hotel_A2 = 0xA2,
            Hotel_A3 = 0xA3,
            Hotel_A4 = 0xA4,
            Hotel_A5 = 0xA5,
            Hotel_A6 = 0xA6,
            Hotel_A7 = 0xA7,
            Hotel_A8 = 0xA8,
            Hotel_A9 = 0xA9,
            Content_0xAA = 0xAA,
            Content_0xAB = 0xAB,
            Content_0xAC = 0xAC,
            Content_0xAD = 0xAD,
            Content_0xAE = 0xAE,
            Content_0xAF = 0xAF,
            Hotel_B0 = 0xB0, // 169r
            Content_0xB1 = 0xB1,
            Content_0xB2 = 0xB2,
            Content_0xB3 = 0xB3,
            Content_0xB4 = 0xB4,
            Content_0xB5 = 0xB5,
            Content_0xB6 = 0xB6,
            Content_0xB7 = 0xB7,
            Content_0xB8 = 0xB8,
            Content_0xB9 = 0xB9,
            Content_0xBA = 0xBA,
            Content_0xBB = 0xBB,
            RupiaSeedPlant = 0xBC,
            RupiaTree_BD = 0xBD,
            Casino_1_BE = 0xBE,
            Content_0xBF = 0xBF,
            TimeDoorEnter = 0xC0,
            Content_0xC1 = 0xC1,
            Content_0xC2 = 0xC2,
            Content_0xC3 = 0xC3,
            Content_0xC4 = 0xC4,
            Content_0xC5 = 0xC5,
            Content_0xC6 = 0xC6,
            TimeDoorExit_C7 = 0xC7,
            Content_0xC8 = 0xC8,
            Content_0xC9 = 0xC9,
            Content_0xCA = 0xCA,
            Content_0xCB = 0xCB,
            Content_0xCC = 0xCC,
            Content_0xCD = 0xCD,
            Content_0xCE = 0xCE,
            Content_0xCF = 0xCF,
            Content_0xD0 = 0xD0,
            Content_0xD1 = 0xD1,
            Content_0xD2 = 0xD2,
            Content_0xD3 = 0xD3,
            Content_0xD4 = 0xD4,
            Content_0xD5 = 0xD5,
            Content_0xD6 = 0xD6,
            TimeDoorExit = 0xD7,
            Content_0xD8 = 0xD8,
            Content_0xD9 = 0xD9,
            Content_0xDA = 0xDA,
            Content_0xDB = 0xDB,
            Content_0xDC = 0xDC,
            Content_0xDD = 0xDD,
            Content_0xDE = 0xDE,
            Content_0xDF = 0xDF,
            Content_0xE0 = 0xE0,
            Content_0xE1 = 0xE1,
            Content_0xE2 = 0xE2,
            Content_0xE3 = 0xE3,
            Content_0xE4 = 0xE4,
            Content_0xE5 = 0xE5,
            Content_0xE6 = 0xE6,
            Content_0xE7 = 0xE7,
            Content_0xE8 = 0xE8,
            Content_0xE9 = 0xE9,
            Content_0xEA = 0xEA,
            Content_0xEB = 0xEB,
            Content_0xEC = 0xEC,
            Content_0xED = 0xED,
            Content_0xEE = 0xEE,
            Content_0xEF = 0xEF,
            Content_0xF0 = 0xF0,
            Content_0xF1 = 0xF1,
            Content_0xF2 = 0xF2,
            Content_0xF3 = 0xF3,
            Content_0xF4 = 0xF4,
            Content_0xF5 = 0xF5,
            Content_0xF6 = 0xF6,
            Content_0xF7 = 0xF7,
            Content_0xF8 = 0xF8,
            Content_0xF9 = 0xF9,
            Content_0xFA = 0xFA,
            Content_0xFB = 0xFB,
            Content_0xFC = 0xFC,
            Content_0xFD = 0xFD,
            Content_0xFE = 0xFE,
            Battle = 0xFF
        }
    }
}
