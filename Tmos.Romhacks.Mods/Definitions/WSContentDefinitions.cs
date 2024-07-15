using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Mods.TypedTmosObjects;
using static Tmos.Romhacks.Mods.Definitions.WSContentDefinitions;

namespace Tmos.Romhacks.Mods.Definitions
{


	public static class WSContentDefinitions
	{
		//All normal enter contents are > 0x34
		public enum WSContentType //TODO: Implement correct ordering
		{
			Battle,
			Nothing,
			EnterTown,
			DemonScreen, //Content >= 0x21 && Content <= 0x2A
			WizardBattleOnEnter, //0x01
			TimeDoor, //0xC0
			Mosque,
			FirstPriest,
			Troopers,
			Casino,

			University,
			RSeedPlant,
			RSeedInfo,
			
			DialogScreenEntranceOnScreen,
			EncounterPossibleOnExitFlag,
			Shop1,
			Shop2,
			Shop3,

			Gilga,
			Gilga2,
			Curly,
			Curly2,
			Troll,
			Troll2,
			Salamander,
			Salamander2,
			GoraGora,
			GoraGora2,

			//Ch1
			Faruk,
			Kebabu,
			AquaPalace,
			WiseManMonecom,
			AchelatoPrincess,
			Sabaron,

			//Ch2
			GunMeca,
			Lah,
			Supica,
			Epin,
			WisemanRaincome,
			Princess,

			//Ch3
			NewBornCimaronTree,
			CimaronTree,
			Supapa,
			Mustafa,
			FrozenPalace,

			//Ch4
			Gubibi,
			Rainy,

			YuflaPalace,
			Rostam,
			RostamInfo,
			KingFiesal,
			WisemanMoscome,

			//Ch5
			Hasan,

			Kaji,
			LegendSword,
			ArmorofLight,
			PalaceEntrance,
			SabaronFinal,
			JarHint,
			Libcom,
			Rupias,

			UNKNOWN,
			FirstMosque,
			Dogos,
			Hotel10r,
			Hotel169r,
			Casino1,
			TimeDoorEnter,
			TimeDoorExit,
			TimeDoorExit2,
			ShopB20,
			ShopHorenPast,

			// Added missing items
			HeroRostamsSword,
			RupiaTree,
			RupiaLady,
			ShopUnused1,
			ShopUnused2,
			ShopUnused3,
			Hotel2,
			Hotel3,
			ShopB60M60C60RSeed100,
			Hotel20r,
			Hotel4,	
			RupiaSeedPlant,
			ArmorOfLight2,
			OnlyOneJarYouCanGoThrough
		
	}
		
			private static readonly WSContentType[] baseContentTypes = new WSContentType[256];
			private static readonly HashSet<int> commonValues = new HashSet<int> { 0xFF, 0x00 };
			private const int ChapterOffset = 0x20; // Adjust this value based on the actual offset between chapters

			static WSContentDefinitions()
			{
				InitializeBaseContentTypes();
			}

			private static void InitializeBaseContentTypes()
			{
				// Common values for all chapters
				baseContentTypes[0xFF] = WSContentType.Battle;
				baseContentTypes[0x00] = WSContentType.Nothing;

				// Base content types (using Chapter 0 as reference)
				baseContentTypes[0x1D] = WSContentType.FrozenPalace;
				baseContentTypes[0x20] = WSContentType.FirstMosque;
				baseContentTypes[0x7B] = WSContentType.ShopUnused1;
				baseContentTypes[0x7C] = WSContentType.ShopUnused2;
				baseContentTypes[0x7D] = WSContentType.ShopUnused3;
				baseContentTypes[0x60] = WSContentType.Shop1;
				baseContentTypes[0x61] = WSContentType.Shop1;
				baseContentTypes[0x62] = WSContentType.ShopB60M60C60RSeed100;
				baseContentTypes[0x64] = WSContentType.Shop2;
				baseContentTypes[0x66] = WSContentType.Shop3;
				baseContentTypes[0xA0] = WSContentType.Hotel10r;
				baseContentTypes[0xA2] = WSContentType.Hotel2;
				baseContentTypes[0xA3] = WSContentType.Hotel3;
				baseContentTypes[0xB0] = WSContentType.Hotel169r;
				baseContentTypes[0x7E] = WSContentType.Mosque;
				baseContentTypes[0x7F] = WSContentType.Troopers;
				baseContentTypes[0xBE] = WSContentType.Casino1;
				baseContentTypes[0x40] = WSContentType.University;
				baseContentTypes[0x43] = WSContentType.University;
				baseContentTypes[0x50] = WSContentType.University;
				baseContentTypes[0x55] = WSContentType.University;
				baseContentTypes[0x87] = WSContentType.RupiaLady;
				baseContentTypes[0xBD] = WSContentType.RupiaTree;
				baseContentTypes[0x86] = WSContentType.WisemanMoscome;
				baseContentTypes[0xBC] = WSContentType.RSeedPlant;
				baseContentTypes[0x80] = WSContentType.Gubibi;
				baseContentTypes[0x81] = WSContentType.Rainy;
				baseContentTypes[0x82] = WSContentType.YuflaPalace;
				baseContentTypes[0x84] = WSContentType.HeroRostamsSword;
				baseContentTypes[0x85] = WSContentType.KingFiesal;
				baseContentTypes[0x83] = WSContentType.Rostam;

				// Add more base content types as needed
			}



		public static WSContent GetWSContentDefinition(int chapter, int value)
		{
			WSContentType contentType;
			// Handle common values that don't use offset
			if (value <= 0x7F || value == 0xFF)
			{
				contentType = baseContentTypes[value];
			}
			else
			{

				int offset = CalculateOffset(chapter);
				int adjustedValue = (value - offset) & 0xFF;



				// Get content type from base array
				contentType = baseContentTypes[adjustedValue];

				// Handle special cases for each chapter
				switch (chapter)
				{
					case 1:
						if (value == 0x23) contentType = WSContentType.Curly;
						if (value == 0x90 || value == 0x91) contentType = WSContentType.NewBornCimaronTree;
						break;
					case 2:
						// No special cases needed for Chapter 2
						break;
					case 3:
						if (value == 0x89) contentType = WSContentType.Hotel2;
						break;
					case 4:
						// No special cases needed for Chapter 4
						break;
					case 5:
						// Handle all Chapter 5 elements without offset
						contentType = baseContentTypes[value];
						break;
				}

				
			}
			WSContent wsContent = GetWSContentDefinitions().FirstOrDefault(x => x.ContentType == contentType);
			if (wsContent == null)
			{
				wsContent = new WSContent() { Name = "UNKNOWN", ContentType = WSContentType.UNKNOWN };
			}
			if (value != null)
			{
				byte val = (byte)value;
				wsContent.Value = val;
			}
			return wsContent;
		}

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
				wsContent = new WSContent() { Name = "UNKNOWN", ContentType = WSContentType.UNKNOWN };
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
		new WSContent() { ContentType = WSContentType.Battle, Name = "Battle" },
		new WSContent() { ContentType = WSContentType.Nothing, Name = "Nothing" },
		new WSContent() { ContentType = WSContentType.Mosque, Name = "Mosque" },
		new WSContent() { ContentType = WSContentType.FirstPriest, Name = "First Priest" },
		new WSContent() { ContentType = WSContentType.Troopers, Name = "Troopers" },
		new WSContent() { ContentType = WSContentType.Casino, Name = "Casino" },
		new WSContent() { ContentType = WSContentType.TimeDoorEnter, Name = "Time Door Enter" },
		new WSContent() { ContentType = WSContentType.TimeDoorExit, Name = "Time Door Exit" },
		new WSContent() { ContentType = WSContentType.TimeDoorExit2, Name = "Time Door Exit 2" },
		new WSContent() { ContentType = WSContentType.University, Name = "University" },
		new WSContent() { ContentType = WSContentType.RSeedPlant, Name = "RSeed Plant" },
		new WSContent() { ContentType = WSContentType.RSeedInfo, Name = "RSeed Info" },
		new WSContent() { ContentType = WSContentType.WizardBattleOnEnter, Name = "Wizard Battle On Enter" },
		new WSContent() { ContentType = WSContentType.DialogScreenEntranceOnScreen, Name = "Dialog Screen Entrance On Screen" },
		new WSContent() { ContentType = WSContentType.EncounterPossibleOnExitFlag, Name = "Encounter Possible On Exit Flag" },
		new WSContent() { ContentType = WSContentType.Shop1, Name = "Shop 1" },
		new WSContent() { ContentType = WSContentType.Shop2, Name = "Shop 2" },
		new WSContent() { ContentType = WSContentType.Shop3, Name = "Shop 3" },
		new WSContent() { ContentType = WSContentType.ShopB20, Name = "Shop B20", Description = "Mashroom Key horn" },
		new WSContent() { ContentType = WSContentType.ShopHorenPast, Name = "Shop Horen Past", Description = "b60 m60 c60 rseed100" },
		new WSContent() { ContentType = WSContentType.ShopUnused1, Name = "Shop (Unused 1)", Description = "Amulet Mashroob <blank> <blank>" },
		new WSContent() { ContentType = WSContentType.ShopUnused2, Name = "Shop (Unused 2)", Description = "Fighter <blank> Raincom <blank>" },
		new WSContent() { ContentType = WSContentType.ShopUnused3, Name = "Shop (Unused 3)", Description = "Holyrobe Raincom Spricom ?" },
		new WSContent() { ContentType = WSContentType.Gilga, Name = "Gilga" },
		new WSContent() { ContentType = WSContentType.Gilga2, Name = "Gilga 2" },
		new WSContent() { ContentType = WSContentType.Curly, Name = "Curly" },
		new WSContent() { ContentType = WSContentType.Curly2, Name = "Curly 2" },
		new WSContent() { ContentType = WSContentType.Troll, Name = "Troll" },
		new WSContent() { ContentType = WSContentType.Troll2, Name = "Troll 2" },
		new WSContent() { ContentType = WSContentType.Salamander, Name = "Salamander" },
		new WSContent() { ContentType = WSContentType.Salamander2, Name = "Salamander 2" },
		new WSContent() { ContentType = WSContentType.GoraGora, Name = "Gora Gora" },
		new WSContent() { ContentType = WSContentType.GoraGora2, Name = "Gora Gora 2" },
		new WSContent() { ContentType = WSContentType.Faruk, Name = "Faruk" },
		new WSContent() { ContentType = WSContentType.Kebabu, Name = "Kebabu" },
		new WSContent() { ContentType = WSContentType.AquaPalace, Name = "Aqua Palace" },
		new WSContent() { ContentType = WSContentType.WiseManMonecom, Name = "WiseMan Monecom" },
		new WSContent() { ContentType = WSContentType.WisemanMoscome, Name = "Wiseman Moscome" },
		new WSContent() { ContentType = WSContentType.WisemanRaincome, Name = "Wiseman Raincome" },
		new WSContent() { ContentType = WSContentType.AchelatoPrincess, Name = "Achelato Princess" },
		new WSContent() { ContentType = WSContentType.Princess, Name = "Princess" },
		new WSContent() { ContentType = WSContentType.Supica, Name = "Supica" },
		new WSContent() { ContentType = WSContentType.Epin, Name = "Epin" },
		new WSContent() { ContentType = WSContentType.GunMeca, Name = "Gun Meca" },
		new WSContent() { ContentType = WSContentType.Lah, Name = "Lah" },
		new WSContent() { ContentType = WSContentType.Sabaron, Name = "Sabaron" },
		new WSContent() { ContentType = WSContentType.SabaronFinal, Name = "Sabaron Final" },
		new WSContent() { ContentType = WSContentType.YuflaPalace, Name = "Yufla Palace" },
		new WSContent() { ContentType = WSContentType.Rostam, Name = "Rostam" },
		new WSContent() { ContentType = WSContentType.RostamInfo, Name = "Rostam Info" },
		new WSContent() { ContentType = WSContentType.KingFiesal, Name = "King Fiesal" },
		new WSContent() { ContentType = WSContentType.Hasan, Name = "Hasan" },
		new WSContent() { ContentType = WSContentType.Kaji, Name = "Kaji" },
		new WSContent() { ContentType = WSContentType.LegendSword, Name = "Legend Sword" },
		new WSContent() { ContentType = WSContentType.ArmorofLight, Name = "Armor of Light" },
		new WSContent() { ContentType = WSContentType.ArmorOfLight2, Name = "Armor of Light 2" },
		new WSContent() { ContentType = WSContentType.PalaceEntrance, Name = "Palace Entrance" },
		new WSContent() { ContentType = WSContentType.JarHint, Name = "Jar Hint", Description = "Only 1 jar you can go through" },
		new WSContent() { ContentType = WSContentType.Libcom, Name = "Libcom" },
		new WSContent() { ContentType = WSContentType.Rupias, Name = "Rupias" },
		new WSContent() { ContentType = WSContentType.NewBornCimaronTree, Name = "New Born Cimaron Tree" },
		new WSContent() { ContentType = WSContentType.CimaronTree, Name = "Cimaron Tree" },
		new WSContent() { ContentType = WSContentType.Supapa, Name = "Supapa" },
		new WSContent() { ContentType = WSContentType.Mustafa, Name = "Mustafa" },
		new WSContent() { ContentType = WSContentType.FrozenPalace, Name = "Frozen Palace" },
		new WSContent() { ContentType = WSContentType.Gubibi, Name = "Gubibi" },
		new WSContent() { ContentType = WSContentType.Rainy, Name = "Rainy" },
		new WSContent() { ContentType = WSContentType.UNKNOWN, Name = "Unknown" },
		new WSContent() { ContentType = WSContentType.FirstMosque, Name = "First Mosque", Description = "You will defeat sabaron?" },
		new WSContent() { ContentType = WSContentType.Dogos, Name = "Dogos" },
		new WSContent() { ContentType = WSContentType.Hotel10r, Name = "Hotel 10r" },
		new WSContent() { ContentType = WSContentType.Hotel20r, Name = "Hotel 20r" },
		new WSContent() { ContentType = WSContentType.Hotel169r, Name = "Hotel 169r" },
		new WSContent() { ContentType = WSContentType.Casino1, Name = "Casino 1" },
		new WSContent() { ContentType = WSContentType.HeroRostamsSword, Name = "Hero Rostam's Sword" },
		new WSContent() { ContentType = WSContentType.RupiaTree, Name = "Rupia Tree", Description = "Person who planted a seed a long time ago" },
		new WSContent() { ContentType = WSContentType.RupiaLady, Name = "50 Rupias Lady" },
	};
		}

	}
}
