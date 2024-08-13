using System;
using System.Collections.Generic;
using System.Linq;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Library.Enum.KnownValueLibrary;
using Tmos.Romhacks.Library.RomObjects.WorldScreen.Properties;

namespace Tmos.Romhacks.Library.Definitions
{
    public static class WSContentDefinitions
    {
        public static WSContent GetWSContentDefinition(int chapter, byte value)
        {
            WSContentType contentType = WSContentTypeChapterLookup.GetWSContentType(value, chapter);
            return GetWSContentDefinition(contentType, value);
        }

        public static WSContent GetWSContentDefinition(WSContentType contentType, byte? value = null)
        {
			//         if (!ContentDefinitions.TryGetValue(contentType, out WSContent wsContent))
			//         {
			//             wsContent = new WSContent { ContentType = WSContentType.Unknown, Name = "Not defined"  };
			//         }

			//         if (wsContent.Value == -1 && value != wsContent.Value)
			//         {
			//             wsContent.Value = value;
			//}


			if (!ContentDefinitions.TryGetValue(contentType, out WSContent wsContent))
			{
				wsContent = new WSContent { Name = "Other", ContentType = WSContentType.Other };
			}

			if (value.HasValue)
			{
				wsContent.ContentByteValue = value.Value;
			}




			return wsContent;
        }

        public static List<WSContent> GetWSContentDefinitions()
        {
            return ContentDefinitions.Values.ToList();
        }

        private static readonly Dictionary<WSContentType, WSContent> ContentDefinitions = new Dictionary<WSContentType, WSContent>
        {
            { WSContentType.Nothing, new WSContent { ContentType = WSContentType.Nothing, Name = "Nothing", Description = "Nothing" } },
            { WSContentType.WizardBattleOnEnter, new WSContent { ContentType = WSContentType.WizardBattleOnEnter, Name = "Wizard Battle On Enter", Description = "Wizard Battle On Enter" } },
            { WSContentType.FrozenPalace, new WSContent { ContentType = WSContentType.FrozenPalace, Name = "Frozen Palace", Description = "Frozen Palace" } },
            { WSContentType.FirstMosque, new WSContent { ContentType = WSContentType.FirstMosque, Name = "First Mosque", Description = "You will defeat sabaron?" } },
            { WSContentType.Gilga, new WSContent { ContentType = WSContentType.Gilga, Name = "Gilga", Description = "Gilga" } },
            { WSContentType.Gilga2, new WSContent { ContentType = WSContentType.Gilga2, Name = "Gilga 2", Description = "Gilga 2" } },
            { WSContentType.Curly, new WSContent { ContentType = WSContentType.Curly, Name = "Curly", Description = "Curly" } },
            { WSContentType.Curly2, new WSContent { ContentType = WSContentType.Curly2, Name = "Curly 2", Description = "Curly 2" } },
            { WSContentType.Troll, new WSContent { ContentType = WSContentType.Troll, Name = "Troll", Description = "Troll" } },
            { WSContentType.Troll2, new WSContent { ContentType = WSContentType.Troll2, Name = "Troll 2", Description = "Troll 2" } },
            { WSContentType.Salamander, new WSContent { ContentType = WSContentType.Salamander, Name = "Salamander", Description = "Salamander" } },
            { WSContentType.Salamander2, new WSContent { ContentType = WSContentType.Salamander2, Name = "Salamander 2", Description = "Salamander 2" } },
            { WSContentType.GoraGora, new WSContent { ContentType = WSContentType.GoraGora, Name = "Gora Gora", Description = "Gora Gora" } },
            { WSContentType.GoraGora2, new WSContent { ContentType = WSContentType.GoraGora2, Name = "Gora Gora 2", Description = "Gora Gora 2" } },
            { WSContentType.University_40, new WSContent { ContentType = WSContentType.University_40, Name = "University 40", Description = "University 40" } },
            { WSContentType.University_41, new WSContent { ContentType = WSContentType.University_41, Name = "University 41", Description = "University 41" } },
            { WSContentType.University_42, new WSContent { ContentType = WSContentType.University_42, Name = "University 42", Description = "University 42" } },
            { WSContentType.University_43, new WSContent { ContentType = WSContentType.University_43, Name = "University 43", Description = "University 43" } },
            { WSContentType.University_44, new WSContent { ContentType = WSContentType.University_44, Name = "University 44", Description = "University 44" } },
            { WSContentType.University_50, new WSContent { ContentType = WSContentType.University_50, Name = "University 50", Description = "University 50" } },
            { WSContentType.University_55, new WSContent { ContentType = WSContentType.University_55, Name = "University 55", Description = "University 55" } },
            { WSContentType.Shop_60, new WSContent { ContentType = WSContentType.Shop_60, Name = "Shop 60", Description = "B20 M Key horn" } },
            { WSContentType.Shop_61, new WSContent { ContentType = WSContentType.Shop_61, Name = "Shop 61", Description = "Shop 61" } },
            { WSContentType.Shop_62, new WSContent { ContentType = WSContentType.Shop_62, Name = "Shop 62", Description = "B60 M60 C60 RSeed100" } },
            { WSContentType.Shop_63, new WSContent { ContentType = WSContentType.Shop_63, Name = "Shop 63", Description = "Shop 63" } },
            { WSContentType.Shop_64, new WSContent { ContentType = WSContentType.Shop_64, Name = "Shop 64", Description = "Shop 64" } },
            { WSContentType.Shop_65, new WSContent { ContentType = WSContentType.Shop_65, Name = "Shop 65", Description = "Shop 65" } },
            { WSContentType.Shop_66, new WSContent { ContentType = WSContentType.Shop_66, Name = "Shop 66", Description = "Shop 66" } },
            { WSContentType.Shop_7B, new WSContent { ContentType = WSContentType.Shop_7B, Name = "Shop 7B", Description =  "Amulet Mashroob <blank> <blank>" } },
            { WSContentType.Shop_7C, new WSContent { ContentType = WSContentType.Shop_7C, Name = "Fighter <blank> Raincom <blank>" } },
            { WSContentType.Shop_7D, new WSContent { ContentType = WSContentType.Shop_7D, Name = "Holyrobe Raincom Spricom" } },
            { WSContentType.Mosque, new WSContent { ContentType = WSContentType.Mosque, Name = "Mosque", Description = "Mosque" } },
            { WSContentType.Troopers, new WSContent { ContentType = WSContentType.Troopers, Name = "Troopers", Description = "Troopers" } },
            { WSContentType.Jad, new WSContent { ContentType = WSContentType.Jad, Name = "Jad" } },
            { WSContentType.Faruk, new WSContent { ContentType = WSContentType.Faruk, Name = "Faruk" } },
            { WSContentType.Dogos, new WSContent { ContentType = WSContentType.Dogos, Name = "Dogos" } },
            { WSContentType.Kebabu, new WSContent { ContentType = WSContentType.Kebabu, Name = "Kebabu" } },
            { WSContentType.AquaPalace, new WSContent { ContentType = WSContentType.AquaPalace, Name = "Aqua Palace" } },
            { WSContentType.WiseManMonecom, new WSContent { ContentType = WSContentType.WiseManMonecom, Name = "WiseMan Monecom" } },
            { WSContentType.AchelatoPrincess, new WSContent { ContentType = WSContentType.AchelatoPrincess, Name = "Achelato Princess" } },
            { WSContentType.SabaronTalk, new WSContent { ContentType = WSContentType.SabaronTalk, Name = "Sabaron Talk" } },
            { WSContentType.GunMeca, new WSContent { ContentType = WSContentType.GunMeca, Name = "Gun Meca" } },
            { WSContentType.Lah, new WSContent { ContentType = WSContentType.Lah, Name = "Lah" } },
            { WSContentType.Supica, new WSContent { ContentType = WSContentType.Supica, Name = "Supica" } },
            { WSContentType.Epin, new WSContent { ContentType = WSContentType.Epin, Name = "Epin" } },
            { WSContentType.WisemanRaincome, new WSContent { ContentType = WSContentType.WisemanRaincome, Name = "Wiseman Raincome" } },
            { WSContentType.Princess1, new WSContent { ContentType = WSContentType.Princess1, Name = "Princess 1" } },
            { WSContentType.Princess2, new WSContent { ContentType = WSContentType.Princess2, Name = "Princess 2" } },
            { WSContentType.NewBornCimaronTree, new WSContent { ContentType = WSContentType.NewBornCimaronTree, Name = "New Born Cimaron Tree" } },
            { WSContentType.CimaronTree, new WSContent { ContentType = WSContentType.CimaronTree, Name = "Cimaron Tree" } },
			{ WSContentType.WiseManSpricom, new WSContent { ContentType = WSContentType.WiseManSpricom, Name = "Wiseman Spricome" } },
			{ WSContentType.Supapa, new WSContent { ContentType = WSContentType.Supapa, Name = "Supapa" } },
            { WSContentType.Mustafa, new WSContent { ContentType = WSContentType.Mustafa, Name = "Mustafa" } },
            { WSContentType.FrozenPalace2, new WSContent { ContentType = WSContentType.FrozenPalace2, Name = "Frozen Palace 2" } },
            { WSContentType.Gubibi, new WSContent { ContentType = WSContentType.Gubibi, Name = "Gubibi" } },
            { WSContentType.Rainy, new WSContent { ContentType = WSContentType.Rainy, Name = "Rainy" } },
            { WSContentType.YuflaPalace, new WSContent { ContentType = WSContentType.YuflaPalace, Name = "Yufla Palace" } },
            { WSContentType.Rostam, new WSContent { ContentType = WSContentType.Rostam, Name = "Rostam" } },
            { WSContentType.KingFiesal, new WSContent { ContentType = WSContentType.KingFiesal, Name = "King Fiesal" } },
            { WSContentType.WisemanMoscome, new WSContent { ContentType = WSContentType.WisemanMoscome, Name = "Wiseman Moscome" } },
            { WSContentType.Hasan, new WSContent { ContentType = WSContentType.Hasan, Name = "Hasan" } },
            { WSContentType.Kaji, new WSContent { ContentType = WSContentType.Kaji, Name = "Kaji" } },
            { WSContentType.LegendSword, new WSContent { ContentType = WSContentType.LegendSword, Name = "Legend Sword" } },
            { WSContentType.ArmorofLight, new WSContent { ContentType = WSContentType.ArmorofLight, Name = "Armor of Light" } },
            { WSContentType.PalaceEntrance, new WSContent { ContentType = WSContentType.PalaceEntrance, Name = "Palace Entrance" } },
            { WSContentType.SabaronFinal, new WSContent { ContentType = WSContentType.SabaronFinal, Name = "Sabaron Final" } },
            { WSContentType.OnlyOneJarYouCanGoThrough, new WSContent { ContentType = WSContentType.OnlyOneJarYouCanGoThrough, Name = "Only One Jar You Can Go Through" } },
            { WSContentType.RupiasLady, new WSContent { ContentType = WSContentType.RupiasLady, Name = "50 Rupias" } },
            { WSContentType.Rupias, new WSContent { ContentType = WSContentType.Rupias, Name = "50 rupias" } },
            { WSContentType.Hotel_A0, new WSContent { ContentType = WSContentType.Hotel_A0, Name = "Hotel A0", Description = "10r" } },
            { WSContentType.Hotel_A1, new WSContent { ContentType = WSContentType.Hotel_A1, Name = "Hotel A1", Description = "20r" } },
            { WSContentType.Hotel_A2, new WSContent { ContentType = WSContentType.Hotel_A2, Name = "Hotel A2" } },
            { WSContentType.Hotel_A3, new WSContent { ContentType = WSContentType.Hotel_A3, Name = "Hotel A3" } },
            { WSContentType.Hotel_A4, new WSContent { ContentType = WSContentType.Hotel_A4, Name = "Hotel A4" } },
            { WSContentType.Hotel_A5, new WSContent { ContentType = WSContentType.Hotel_A5, Name = "Hotel A5" } },
            { WSContentType.Hotel_A6, new WSContent { ContentType = WSContentType.Hotel_A6, Name = "Hotel A6" } },
            { WSContentType.Hotel_A7, new WSContent { ContentType = WSContentType.Hotel_A7, Name = "Hotel A7" } },
            { WSContentType.Hotel_A8, new WSContent { ContentType = WSContentType.Hotel_A8, Name = "Hotel A8" } },
            { WSContentType.Hotel_A9, new WSContent { ContentType = WSContentType.Hotel_A9, Name = "Hotel A9" } },
            { WSContentType.Hotel_B0, new WSContent { ContentType = WSContentType.Hotel_B0, Name = "Hotel B0", Description = "169r" } },
            { WSContentType.RupiaSeedPlant, new WSContent { ContentType = WSContentType.RupiaSeedPlant, Name = "Rupia Seed Plant" } },
            { WSContentType.RupiaTree_BD, new WSContent { ContentType = WSContentType.RupiaTree_BD, Name = "Rupia Tree BD" } },
            { WSContentType.Casino_1_BE, new WSContent { ContentType = WSContentType.Casino_1_BE, Name = "Casino 1 BE" } },
            { WSContentType.TimeDoorEnter, new WSContent { ContentType = WSContentType.TimeDoorEnter, Name = "Time Door Enter" } },
            { WSContentType.TimeDoorExit_C7, new WSContent { ContentType = WSContentType.TimeDoorExit_C7, Name = "Time Door Exit C7" } },
            { WSContentType.TimeDoorExit, new WSContent { ContentType = WSContentType.TimeDoorExit, Name = "Time Door Exit" } },
            { WSContentType.Battle, new WSContent { ContentType = WSContentType.Battle, Name = "Battle" } }
		};

       
    }
}