using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Rom;

namespace Tmos.Romhacks.Library.Definitions
{
	public enum GameVariableType { Byte, Int16, Int32, Float, String }
	public class KnownGameVariableDefinition
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public GameVariableEnum GameVariable { get; set; }

		public GameVariableType VariableType { get; set; }

		public int Address { get; set; }

		public string AdditionalDetails { get; set; } //Known possible/Suggested values
	}

	public class KnownGameVariableDefinitions
	{
		public static Dictionary<GameVariableEnum, KnownGameVariableDefinition> KnownGameVariableDictionary = new Dictionary<GameVariableEnum, KnownGameVariableDefinition>
			{
				{GameVariableEnum.MaxBreads, new KnownGameVariableDefinition{Name = GameVariableEnum.MaxBreads.ToString(), VariableType=GameVariableType.Byte, Description = "Max bread capacity", GameVariable = GameVariableEnum.MaxBreads, Address = TmosRomKnownAddresses.GameVariables.MaxBreadsAddress, AdditionalDetails = "" } },
				{GameVariableEnum.MaxMashroobs, new KnownGameVariableDefinition{Name = GameVariableEnum.MaxMashroobs.ToString(), VariableType=GameVariableType.Byte, Description = "Max mashroob capacity", GameVariable = GameVariableEnum.MaxMashroobs, Address = TmosRomKnownAddresses.GameVariables.MaxMashroobsAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrooperPrice, new KnownGameVariableDefinition{Name = GameVariableEnum.TrooperPrice.ToString(), VariableType=GameVariableType.Byte, Description = "Trooper price", GameVariable = GameVariableEnum.TrooperPrice, Address = TmosRomKnownAddresses.GameVariables.TrooperPriceAddress, AdditionalDetails = "" } },
				{GameVariableEnum.HeroColorNormal, new KnownGameVariableDefinition{Name = GameVariableEnum.HeroColorNormal.ToString(), VariableType=GameVariableType.Byte, Description = "Hero color normal", GameVariable = GameVariableEnum.HeroColorNormal, Address = TmosRomKnownAddresses.GameVariables.HeroColorNormalAddress, AdditionalDetails = "" } },
				{GameVariableEnum.HeroColorBattle, new KnownGameVariableDefinition{Name = GameVariableEnum.HeroColorBattle.ToString(), VariableType=GameVariableType.Byte, Description = "Hero color battle", GameVariable = GameVariableEnum.HeroColorBattle, Address = TmosRomKnownAddresses.GameVariables.HeroColorBattleAddress, AdditionalDetails = "" } },
				{GameVariableEnum.HeroColorRArmor, new KnownGameVariableDefinition{Name = GameVariableEnum.HeroColorRArmor.ToString(), VariableType=GameVariableType.Byte, Description = "Hero color right armor", GameVariable = GameVariableEnum.HeroColorRArmor, Address = TmosRomKnownAddresses.GameVariables.HeroColorRArmorAddress, AdditionalDetails = "" } },
				{GameVariableEnum.HeroColorRArmorBattle, new KnownGameVariableDefinition{Name = GameVariableEnum.HeroColorRArmorBattle.ToString(), VariableType=GameVariableType.Byte, Description = "Hero color right armor battle", GameVariable = GameVariableEnum.HeroColorRArmorBattle, Address = TmosRomKnownAddresses.GameVariables.HeroColorRArmorBattleAddress, AdditionalDetails = "" } },
				{GameVariableEnum.StartScreenTitleColor, new KnownGameVariableDefinition{Name = GameVariableEnum.StartScreenTitleColor.ToString(), VariableType=GameVariableType.Byte, Description = "Start screen title color", GameVariable = GameVariableEnum.StartScreenTitleColor, Address = TmosRomKnownAddresses.GameVariables.TitleScreenVariables.StartScreenTitleColorAddress, AdditionalDetails = "" } },
				{GameVariableEnum.StartScreenTitleColor2, new KnownGameVariableDefinition{Name = GameVariableEnum.StartScreenTitleColor2.ToString(), VariableType=GameVariableType.Byte, Description = "Start screen title color 2", GameVariable = GameVariableEnum.StartScreenTitleColor2, Address = TmosRomKnownAddresses.GameVariables.TitleScreenVariables.StartScreenTitleColor2Address, AdditionalDetails = "" } },
				{GameVariableEnum.StartScreenTitleColor3, new KnownGameVariableDefinition{Name = GameVariableEnum.StartScreenTitleColor3.ToString(), VariableType=GameVariableType.Byte, Description = "Start screen title color 3", GameVariable = GameVariableEnum.StartScreenTitleColor3, Address = TmosRomKnownAddresses.GameVariables.TitleScreenVariables.StartScreenTitleColor3Address, AdditionalDetails = "" } },
				{GameVariableEnum.GilgaEyeHp, new KnownGameVariableDefinition{Name = GameVariableEnum.GilgaEyeHp.ToString(), VariableType=GameVariableType.Byte, Description = "Gilga eye hp", GameVariable = GameVariableEnum.GilgaEyeHp, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.GilgaEyeHpAddress, AdditionalDetails = "" } },
				{GameVariableEnum.GilgaStage2HpDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.GilgaStage2HpDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Gilga stage 2 hp damage", GameVariable = GameVariableEnum.GilgaStage2HpDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.GilgaStage2HpDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.GilgaThunderDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.GilgaThunderDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Gilga thunder damage", GameVariable = GameVariableEnum.GilgaThunderDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.GilgaThunderDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.GilgaProjectileDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.GilgaProjectileDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Gilga projectile damage", GameVariable = GameVariableEnum.GilgaProjectileDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.GilgaProjectileDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.GilgaProjectileSpeed, new KnownGameVariableDefinition{Name = GameVariableEnum.GilgaProjectileSpeed.ToString(), VariableType=GameVariableType.Byte, Description = "Gilga projectile speed", GameVariable = GameVariableEnum.GilgaProjectileSpeed, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.GilgaProjectileSpeedAddress, AdditionalDetails = "" } },
				{GameVariableEnum.CurlyArmHp, new KnownGameVariableDefinition{Name = GameVariableEnum.CurlyArmHp.ToString(), VariableType=GameVariableType.Byte, Description = "Curly arm hp", GameVariable = GameVariableEnum.CurlyArmHp, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.CurlyArmHpAddress, AdditionalDetails = "" } },
				{GameVariableEnum.CurlyProjectileDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.CurlyProjectileDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Curly projectile damage", GameVariable = GameVariableEnum.CurlyProjectileDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.CurlyProjectileDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.CurlyProjectileCooldown, new KnownGameVariableDefinition{Name = GameVariableEnum.CurlyProjectileCooldown.ToString(), VariableType=GameVariableType.Byte, Description = "Curly projectile cooldown", GameVariable = GameVariableEnum.CurlyProjectileCooldown, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.CurlyProjectileCooldownAddress, AdditionalDetails = "" } },
				{GameVariableEnum.CurlyColor, new KnownGameVariableDefinition{Name = GameVariableEnum.CurlyColor.ToString(), VariableType=GameVariableType.Byte, Description = "Curly color", GameVariable = GameVariableEnum.CurlyColor, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.CurlyColorAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollSwitchPositionDelayTime, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollSwitchPositionDelayTime.ToString(), VariableType=GameVariableType.Byte, Description = "Troll switch position delay time", GameVariable = GameVariableEnum.TrollSwitchPositionDelayTime, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollSwitchPositionDelayTimeAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollHp, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollHp.ToString(), VariableType=GameVariableType.Byte, Description = "Troll hp", GameVariable = GameVariableEnum.TrollHp, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollHpAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollThunderDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollThunderDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Troll thunder damage", GameVariable = GameVariableEnum.TrollThunderDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollThunderDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollProjectileDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollProjectileDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Troll projectile damage", GameVariable = GameVariableEnum.TrollProjectileDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollProjectileDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollProjectileBehavior, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollProjectileBehavior.ToString(), VariableType=GameVariableType.Byte, Description = "Troll projectile behavior", GameVariable = GameVariableEnum.TrollProjectileBehavior, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollProjectileBehaviorAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollProjectileCooldown, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollProjectileCooldown.ToString(), VariableType=GameVariableType.Byte, Description = "Troll projectile cooldown", GameVariable = GameVariableEnum.TrollProjectileCooldown, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollProjectileCooldownAddress, AdditionalDetails = "" } },
				{GameVariableEnum.TrollCollisionDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.TrollCollisionDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Troll collision damage", GameVariable = GameVariableEnum.TrollCollisionDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.TrollCollisionDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.SalamanderHp, new KnownGameVariableDefinition{Name = GameVariableEnum.SalamanderHp.ToString(), VariableType=GameVariableType.Byte, Description = "Salamander hp", GameVariable = GameVariableEnum.SalamanderHp, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.SalamanderHpAddress, AdditionalDetails = "" } },
				{GameVariableEnum.SalamanderProjectileCooldown, new KnownGameVariableDefinition{Name = GameVariableEnum.SalamanderProjectileCooldown.ToString(), VariableType=GameVariableType.Byte, Description = "Salamander projectile cooldown", GameVariable = GameVariableEnum.SalamanderProjectileCooldown, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.SalamanderProjectileCooldownAddress, AdditionalDetails = "" } },
				{GameVariableEnum.SalamanderProjectileSpeed, new KnownGameVariableDefinition{Name = GameVariableEnum.SalamanderProjectileSpeed.ToString(), VariableType=GameVariableType.Byte, Description = "Salamander projectile speed", GameVariable = GameVariableEnum.SalamanderProjectileSpeed, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.SalamanderProjectileSpeedAddress, AdditionalDetails = "" } },
				{GameVariableEnum.SalamanderFireMagicDamage, new KnownGameVariableDefinition{Name = GameVariableEnum.SalamanderFireMagicDamage.ToString(), VariableType=GameVariableType.Byte, Description = "Salamander fire magic damage", GameVariable = GameVariableEnum.SalamanderFireMagicDamage, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.SalamanderFireMagicDamageAddress, AdditionalDetails = "" } },
				{GameVariableEnum.SalamanderFireFieldAnimation, new KnownGameVariableDefinition{Name = GameVariableEnum.SalamanderFireFieldAnimation.ToString(), VariableType=GameVariableType.Byte, Description = "Salamander fire field animation", GameVariable = GameVariableEnum.SalamanderFireFieldAnimation, Address = TmosRomKnownAddresses.GameVariables.EnemyVariables.SalamanderFireFieldAnimationAddress, AdditionalDetails = "" } }
			};

	}
	
}
