using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;
using static Tmos.Romhacks.Mods.Enum.KnownValueLibrary.WSContentTypeKVLibrary;

namespace Tmos.Romhacks.Mods.Definitions
{


    public static class WSContentDefinitions
    {
        //All normal enter contents are > 0x34


        private static readonly WSContentTypeByteValue[] baseContentTypes = new WSContentTypeByteValue[256];
        private static readonly HashSet<int> commonValues = new HashSet<int> { 0xFF, 0x00 };
        private const int ChapterOffset = 0x20; // Adjust this value based on the actual offset between chapters

        static WSContentDefinitions()
        {
            //InitializeBaseContentTypes();
        }

        //private static void InitializeBaseContentTypes()
        //{
        //	baseContentTypes[0xFF] = WSContentTypeByteValue.Battle;
        //	baseContentTypes[0x00] = WSContentTypeByteValue.Nothing;

        //	baseContentTypes[0x1D] = WSContentTypeByteValue.FrozenPalace;
        //	baseContentTypes[0x20] = WSContentTypeByteValue.FirstMosque;
        //	baseContentTypes[0x7B] = WSContentTypeByteValue.Shop_7B;

        //	baseContentTypes[0x7C] = WSContentTypeByteValue.ShopUnused2;
        //	baseContentTypes[0x7D] = WSContentTypeByteValue.ShopUnused3;
        //	baseContentTypes[0x60] = WSContentTypeByteValue.Shop1;
        //	baseContentTypes[0x61] = WSContentTypeByteValue.Shop1;
        //	baseContentTypes[0x62] = WSContentTypeByteValue.ShopB60M60C60RSeed100;
        //	baseContentTypes[0x64] = WSContentTypeByteValue.Shop2;
        //	baseContentTypes[0x66] = WSContentTypeByteValue.Shop3;
        //	baseContentTypes[0xA0] = WSContentTypeByteValue.Hotel10r;
        //	baseContentTypes[0xA2] = WSContentTypeByteValue.Hotel2;
        //	baseContentTypes[0xA3] = WSContentTypeByteValue.Hotel3;
        //	baseContentTypes[0xB0] = WSContentTypeByteValue.Hotel169r;
        //	baseContentTypes[0x7E] = WSContentTypeByteValue.Mosque;
        //	baseContentTypes[0x7F] = WSContentTypeByteValue.Troopers;
        //	baseContentTypes[0xBE] = WSContentTypeByteValue.Casino1;
        //	baseContentTypes[0x40] = WSContentTypeByteValue.University;
        //	baseContentTypes[0x43] = WSContentTypeByteValue.University;
        //	baseContentTypes[0x50] = WSContentTypeByteValue.University;
        //	baseContentTypes[0x55] = WSContentTypeByteValue.University;
        //	baseContentTypes[0x87] = WSContentTypeByteValue.RupiaLady;
        //	baseContentTypes[0xBD] = WSContentTypeByteValue.RupiaTree;
        //	baseContentTypes[0x86] = WSContentTypeByteValue.WisemanMoscome;
        //	baseContentTypes[0xBC] = WSContentTypeByteValue.RSeedPlant;
        //	baseContentTypes[0x80] = WSContentTypeByteValue.Gubibi;
        //	baseContentTypes[0x81] = WSContentTypeByteValue.Rainy;
        //	baseContentTypes[0x82] = WSContentTypeByteValue.YuflaPalace;
        //	baseContentTypes[0x84] = WSContentTypeByteValue.HeroRostamsSword;
        //	baseContentTypes[0x85] = WSContentTypeByteValue.KingFiesal;
        //	baseContentTypes[0x83] = WSContentTypeByteValue.Rostam;

        //}


        public static WSContent GetWSContentDefinition(int chapter, byte value)
        {
            WSContentType contentType = GetWSContentType(value, chapter);
            return GetWSContentDefinition(contentType, value);
        }

        //      public static WSContent GetWSContentDefinition(int chapter, byte value)
        //{
        //	WSContentType contentType;
        //	// Handle common values that don't use offset
        //	if (value <= 0x7F || value == 0xFF)
        //	{

        //		contentType = baseContentTypes[value];
        //	}
        //	else
        //	{

        //		int offset = CalculateOffset(chapter);
        //		int adjustedValue = (value - offset) & 0xFF;



        //		// Get content type from base array
        //		contentType = baseContentTypes[adjustedValue];

        //		// Handle special cases for each chapter
        //		switch (chapter)
        //		{
        //			case 1:
        //				if (value == 0x23) contentType = WSContentType.Curly;
        //				if (value == 0x90 || value == 0x91) contentType = WSContentType.NewBornCimaronTree;
        //				break;
        //			case 2:
        //				// No special cases needed for Chapter 2
        //				break;
        //			case 3:
        //				if (value == 0x89) contentType = WSContentType.Hotel2;
        //				break;
        //			case 4:
        //				// No special cases needed for Chapter 4
        //				break;
        //			case 5:
        //				// Handle all Chapter 5 elements without offset
        //				contentType = baseContentTypes[value];
        //				break;
        //		}


        //	}
        //	WSContent wsContent = GetWSContentDefinitions().FirstOrDefault(x => x.ContentType == contentType);
        //	if (wsContent == null)
        //	{
        //		wsContent = new WSContent() { Name = "UNKNOWN", ContentType = WSContentType.UNKNOWN };
        //	}
        //	if (value != null)
        //	{
        //		byte val = (byte)value;
        //		wsContent.Value = val;
        //	}
        //	return wsContent;
        //}

        private static int CalculateOffset(int chapter)
        {
            switch (chapter)
            {
                case 0: return 0x80;
                case 1: return 0x80;
                case 2: return 0x80;
                case 3: return 0x80;
                case 4: return 0x80;
                default: return 0;
            }
        }

        public static WSContent GetWSContentDefinition(WSContentType contentType, byte? value = null)
        {
            WSContent wsContent = GetWSContentDefinitions().FirstOrDefault(x => x.ContentType == contentType);
            if (wsContent == null)
            {
                wsContent = new WSContent() { Name = "UNKNOWN", ContentType = WSContentType.Nothing };
            }
            if (value != null)
            {
                byte val = (byte)value;
                wsContent.Value = val;
            }
            return wsContent;
        }
        public static List<WSContent> GetWSContentDefinitions()
        {
            return new List<WSContent>()
    {
        new WSContent() { ContentType = WSContentType.Nothing, Name = "Nothing", Description = "Nothing" },
        new WSContent() { ContentType = WSContentType.WizardBattleOnEnter, Name = "Wizard Battle On Enter", Description = "Wizard Battle On Enter" },
        new WSContent() { ContentType = WSContentType.FrozenPalace, Name = "Frozen Palace", Description = "Frozen Palace" },
        new WSContent() { ContentType = WSContentType.FirstMosque, Name = "First Mosque", Description = "You will defeat sabaron?" },
        new WSContent() { ContentType = WSContentType.Gilga, Name = "Gilga", Description = "Gilga" },
        new WSContent() { ContentType = WSContentType.Gilga2, Name = "Gilga 2", Description = "Gilga 2" },
        new WSContent() { ContentType = WSContentType.Curly, Name = "Curly", Description = "Curly" },
        new WSContent() { ContentType = WSContentType.Curly2, Name = "Curly 2", Description = "Curly 2" },
        new WSContent() { ContentType = WSContentType.Troll, Name = "Troll", Description = "Troll" },
        new WSContent() { ContentType = WSContentType.Troll2, Name = "Troll 2", Description = "Troll 2" },
        new WSContent() { ContentType = WSContentType.Salamander, Name = "Salamander", Description = "Salamander" },
        new WSContent() { ContentType = WSContentType.Salamander2, Name = "Salamander 2", Description = "Salamander 2" },
        new WSContent() { ContentType = WSContentType.GoraGora, Name = "Gora Gora", Description = "Gora Gora" },
        new WSContent() { ContentType = WSContentType.GoraGora2, Name = "Gora Gora 2", Description = "Gora Gora 2" },
        new WSContent() { ContentType = WSContentType.University_40, Name = "University 40", Description = "University 40" },
        new WSContent() { ContentType = WSContentType.University_41, Name = "University 41", Description = "University 41" },
        new WSContent() { ContentType = WSContentType.University_42, Name = "University 42", Description = "University 42" },
        new WSContent() { ContentType = WSContentType.University_43, Name = "University 43", Description = "University 43" },
        new WSContent() { ContentType = WSContentType.University_44, Name = "University 44", Description = "University 44" },
        new WSContent() { ContentType = WSContentType.University_50, Name = "University 50", Description = "University 50" },
        new WSContent() { ContentType = WSContentType.University_55, Name = "University 55", Description = "University 55" },
        new WSContent() { ContentType = WSContentType.Shop_60, Name = "Shop 60", Description = "B20 M Key horn" },
        new WSContent() { ContentType = WSContentType.Shop_61, Name = "Shop 61", Description = "Shop 61" },
        new WSContent() { ContentType = WSContentType.Shop_62, Name = "Shop 62", Description = "B60 M60 C60 RSeed100" },
        new WSContent() { ContentType = WSContentType.Shop_63, Name = "Shop 63", Description = "Shop 63" },
        new WSContent() { ContentType = WSContentType.Shop_64, Name = "Shop 64", Description = "Shop 64" },
        new WSContent() { ContentType = WSContentType.Shop_65, Name = "Shop 65", Description = "Shop 65" },
        new WSContent() { ContentType = WSContentType.Shop_66, Name = "Shop 66", Description = "Shop 66" },
        new WSContent() { ContentType = WSContentType.Shop_7B, Name = "Shop 7B", Description = "Amulet Mashroob <blank> <blank>" },
        new WSContent() { ContentType = WSContentType.Shop_7C, Name = "Shop 7C", Description = "Fighter <blank> Raincom <blank>" },
        new WSContent() { ContentType = WSContentType.Shop_7D, Name = "Shop 7D", Description = "Holyrobe Raincom Spricom" },
        new WSContent() { ContentType = WSContentType.Mosque, Name = "Mosque", Description = "Mosque" },
        new WSContent() { ContentType = WSContentType.Troopers, Name = "Troopers", Description = "Troopers" },
        new WSContent() { ContentType = WSContentType.Jad, Name = "Jad", Description = "Jad" },
        new WSContent() { ContentType = WSContentType.Faruk, Name = "Faruk", Description = "Faruk" },
        new WSContent() { ContentType = WSContentType.Dogos, Name = "Dogos", Description = "Dogos" },
        new WSContent() { ContentType = WSContentType.Kebabu, Name = "Kebabu", Description = "Kebabu" },
        new WSContent() { ContentType = WSContentType.AquaPalace, Name = "Aqua Palace", Description = "Aqua Palace" },
        new WSContent() { ContentType = WSContentType.WiseManMonecom, Name = "WiseMan Monecom", Description = "WiseMan Monecom" },
        new WSContent() { ContentType = WSContentType.AchelatoPrincess, Name = "Achelato Princess", Description = "Achelato Princess" },
        new WSContent() { ContentType = WSContentType.SabaronTalk, Name = "Sabaron Talk", Description = "Sabaron Talk" },
        new WSContent() { ContentType = WSContentType.GunMeca, Name = "Gun Meca", Description = "Gun Meca" },
        new WSContent() { ContentType = WSContentType.Lah, Name = "Lah", Description = "Lah" },
        new WSContent() { ContentType = WSContentType.Supica, Name = "Supica", Description = "Supica" },
        new WSContent() { ContentType = WSContentType.Epin, Name = "Epin", Description = "Epin" },
        new WSContent() { ContentType = WSContentType.WisemanRaincome, Name = "Wiseman Raincome", Description = "Wiseman Raincome" },
        new WSContent() { ContentType = WSContentType.Princess1, Name = "Princess 1", Description = "Princess 1" },
        new WSContent() { ContentType = WSContentType.Princess2, Name = "Princess 2", Description = "Princess 2" },
        new WSContent() { ContentType = WSContentType.NewBornCimaronTree, Name = "New Born Cimaron Tree", Description = "New Born Cimaron Tree" },
        new WSContent() { ContentType = WSContentType.CimaronTree, Name = "Cimaron Tree", Description = "Cimaron Tree" },
        new WSContent() { ContentType = WSContentType.Supapa, Name = "Supapa", Description = "Supapa" },
        new WSContent() { ContentType = WSContentType.Mustafa, Name = "Mustafa", Description = "Mustafa" },
        new WSContent() { ContentType = WSContentType.FrozenPalace2, Name = "Frozen Palace 2", Description = "Frozen Palace 2" },
        new WSContent() { ContentType = WSContentType.Gubibi, Name = "Gubibi", Description = "Gubibi" },
        new WSContent() { ContentType = WSContentType.Rainy, Name = "Rainy", Description = "Rainy" },
        new WSContent() { ContentType = WSContentType.YuflaPalace, Name = "Yufla Palace", Description = "Yufla Palace" },
        new WSContent() { ContentType = WSContentType.Rostam, Name = "Rostam", Description = "Rostam" },
        new WSContent() { ContentType = WSContentType.KingFiesal, Name = "King Fiesal", Description = "King Fiesal" },
        new WSContent() { ContentType = WSContentType.WisemanMoscome, Name = "Wiseman Moscome", Description = "Wiseman Moscome" },
        new WSContent() { ContentType = WSContentType.Hasan, Name = "Hasan", Description = "Hasan" },
        new WSContent() { ContentType = WSContentType.Kaji, Name = "Kaji", Description = "Kaji" },
        new WSContent() { ContentType = WSContentType.LegendSword, Name = "Legend Sword", Description = "Legend Sword" },
        new WSContent() { ContentType = WSContentType.ArmorofLight, Name = "Armor of Light", Description = "Armor of Light" },
        new WSContent() { ContentType = WSContentType.PalaceEntrance, Name = "Palace Entrance", Description = "Palace Entrance" },
        new WSContent() { ContentType = WSContentType.SabaronFinal, Name = "Sabaron Final", Description = "Sabaron Final" },
        new WSContent() { ContentType = WSContentType.OnlyOneJarYouCanGoThrough, Name = "Only One Jar You Can Go Through", Description = "Only One Jar You Can Go Through" },
        new WSContent() { ContentType = WSContentType.RupiasLady, Name = "Rupias Lady", Description = "50 Rupias" },
        new WSContent() { ContentType = WSContentType.Rupias, Name = "Rupias", Description = "50 rupias" },
        new WSContent() { ContentType = WSContentType.Hotel_A0, Name = "Hotel A0", Description = "10r" },
        new WSContent() { ContentType = WSContentType.Hotel_A1, Name = "Hotel A1", Description = "20r" },
        new WSContent() { ContentType = WSContentType.Hotel_A2, Name = "Hotel A2", Description = "Hotel A2" },
        new WSContent() { ContentType = WSContentType.Hotel_A3, Name = "Hotel A3", Description = "Hotel A3" },
        new WSContent() { ContentType = WSContentType.Hotel_A4, Name = "Hotel A4", Description = "Hotel A4" },
        new WSContent() { ContentType = WSContentType.Hotel_A5, Name = "Hotel A5", Description = "Hotel A5" },
        new WSContent() { ContentType = WSContentType.Hotel_A6, Name = "Hotel A6", Description = "Hotel A6" },
        new WSContent() { ContentType = WSContentType.Hotel_A7, Name = "Hotel A7", Description = "Hotel A7" },
        new WSContent() { ContentType = WSContentType.Hotel_A8, Name = "Hotel A8", Description = "Hotel A8" },
        new WSContent() { ContentType = WSContentType.Hotel_A9, Name = "Hotel A9", Description = "Hotel A9" },
        new WSContent() { ContentType = WSContentType.Hotel_B0, Name = "Hotel B0", Description = "169r" },
        new WSContent() { ContentType = WSContentType.RupiaSeedPlant, Name = "Rupia Seed Plant", Description = "Rupia Seed Plant" },
        new WSContent() { ContentType = WSContentType.RupiaTree_BD, Name = "Rupia Tree BD", Description = "Rupia Tree BD" },
        new WSContent() { ContentType = WSContentType.Casino_1_BE, Name = "Casino 1 BE", Description = "Casino 1 BE" },
        new WSContent() { ContentType = WSContentType.TimeDoorEnter, Name = "Time Door Enter", Description = "Time Door Enter" },
        new WSContent() { ContentType = WSContentType.TimeDoorExit_C7, Name = "Time Door Exit C7", Description = "Time Door Exit C7" },
        new WSContent() { ContentType = WSContentType.TimeDoorExit, Name = "Time Door Exit", Description = "Time Door Exit" },
        new WSContent() { ContentType = WSContentType.Battle, Name = "Battle", Description = "Battle" }
    };
        }
    }


}
