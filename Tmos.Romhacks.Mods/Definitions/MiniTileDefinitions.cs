using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tmos.Romhacks.Mods.Definitions.MiniTileDefinitions;

namespace Tmos.Romhacks.Mods.Definitions
{
	public class MiniTileDefinition
	{
		//public (byte dataPointer, byte value) ContentKey; //Ideally this object could work without having to include the dataPointer of the parent WorldScreen
		public MiniTiletType ContentType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public bool IsWalkable { get; set; } //TODO: Figure out how to actually calculate instead of using hard-coded definitions

	}

	public static class MiniTileDefinitions
	{
		public enum MiniTiletType //TODO: Implement correct ordering
		{
			Battle,
			Nothing, 
			Mosque,
			FirstPriest,
			Troopers,
			Casino,
			TimeDoor,
			University,
			RSeedPlant,
			RSeedInfo,
			WizardBattleOnEnter,
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
		}

		public static MiniTileDefinition GetMiniTiletDefinition(MiniTiletType contentType)
		{
			return GetMiniTileDefinitions().FirstOrDefault(x => x.ContentType == contentType);
		}
		public static List<MiniTileDefinition> GetMiniTileDefinitions()
		{
			return new List<MiniTileDefinition>()
			{
				new MiniTileDefinition() { ContentType = MiniTiletType.Battle, Name = "Battle" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Nothing, Name = "Nothing" },
				new MiniTileDefinition() { ContentType = MiniTiletType.FirstPriest, Name = "First Priest" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Troopers, Name = "Troopers" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Casino, Name = "Casino" },
				new MiniTileDefinition() { ContentType = MiniTiletType.TimeDoor, Name = "Time Door" },
				new MiniTileDefinition() { ContentType = MiniTiletType.University, Name = "University" },
				new MiniTileDefinition() { ContentType = MiniTiletType.RSeedPlant, Name = "RSeed Plant" },
				new MiniTileDefinition() { ContentType = MiniTiletType.RSeedInfo, Name = "RSeed Info" },
				new MiniTileDefinition() { ContentType = MiniTiletType.WizardBattleOnEnter, Name = "Wizard Battle On Enter" },
				new MiniTileDefinition() { ContentType = MiniTiletType.DialogScreenEntranceOnScreen, Name = "Dialog Screen Entrance On Screen" },
				new MiniTileDefinition() { ContentType = MiniTiletType.EncounterPossibleOnExitFlag, Name = "Encounter Possible On Exit Flag" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Shop1, Name = "Shop 1", Description="" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Shop2, Name = "Shop 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Shop3, Name = "Shop 3" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Gilga, Name = "Gilga" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Gilga2, Name = "Gilga 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Curly, Name = "Curly" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Curly2, Name = "Curly 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Troll, Name = "Troll" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Troll2, Name = "Troll 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Salamander, Name = "Salamander" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Salamander2, Name = "Salamander 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.GoraGora, Name = "Gora Gora" },
				new MiniTileDefinition() { ContentType = MiniTiletType.GoraGora2, Name = "Gora Gora 2" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Faruk, Name = "Faruk" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Kebabu, Name = "Kebabu" },
				new MiniTileDefinition() { ContentType = MiniTiletType.AquaPalace, Name = "Aqua Palace" },
				new MiniTileDefinition() { ContentType = MiniTiletType.WiseManMonecom, Name = "WiseManMonecome"},
				new MiniTileDefinition() { ContentType = MiniTiletType.WisemanMoscome, Name = "WisemanMoscome" },
				new MiniTileDefinition() { ContentType = MiniTiletType.WisemanRaincome, Name = "WisemanRaincome" },
				new MiniTileDefinition() { ContentType = MiniTiletType.AchelatoPrincess, Name = "Achelato Princess" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Princess, Name = "Princess" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Supica, Name = "Supica" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Epin, Name = "Epin" },
				new MiniTileDefinition() { ContentType = MiniTiletType.GunMeca, Name = "GunMeca" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Lah, Name = "Lah" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Sabaron, Name = "Sabaron" },
				new MiniTileDefinition() { ContentType = MiniTiletType.SabaronFinal, Name = "Sabaron Final" },
				new MiniTileDefinition() { ContentType = MiniTiletType.YuflaPalace, Name = "Yufla Palace" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Rostam, Name = "Rostam" },
				new MiniTileDefinition() { ContentType = MiniTiletType.RostamInfo, Name = "Rostam Info" },
				new MiniTileDefinition() { ContentType = MiniTiletType.KingFiesal, Name = "King Fiesal" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Hasan, Name = "Hasan" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Kaji, Name = "Kaji" },
				new MiniTileDefinition() { ContentType = MiniTiletType.LegendSword, Name = "Legend Sword" },
				new MiniTileDefinition() { ContentType = MiniTiletType.ArmorofLight, Name = "Armor of Light" },
				new MiniTileDefinition() { ContentType = MiniTiletType.PalaceEntrance, Name = "Palace Entrance" },
				new MiniTileDefinition() { ContentType = MiniTiletType.JarHint, Name = "Jar Hint" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Libcom, Name = "Libcom" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Rupias, Name = "Rupias" },
				new MiniTileDefinition() { ContentType = MiniTiletType.NewBornCimaronTree, Name = "New Born Cimaron Tree" },
				new MiniTileDefinition() { ContentType = MiniTiletType.CimaronTree, Name = "Cimaron Tree" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Supapa, Name = "Supapa" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Mustafa, Name = "Mustafa" },
				new MiniTileDefinition() { ContentType = MiniTiletType.FrozenPalace, Name = "Frozen Palace" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Gubibi, Name = "Gubibi" },
				new MiniTileDefinition() { ContentType = MiniTiletType.Rainy, Name = "Rainy" },

			};
		}
	
	}
}
