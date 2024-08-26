using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Enum.Enemies.Encounters;
using Tmos.Romhacks.Library.RomObjects.Encounters;

namespace Tmos.Romhacks.Library.Definitions.Encounters
{
    //CREDIT: Names, descriptions, HP gathered from https://www.flyingomelette.com/mos/monsters.html
    public class EncounterEnemyDefinition
    {
        public string Name { get; set; }
        public int HP { get; set; } //Known from FlyingOmelette data - not actually calculated from rom currently

        public int  ExperiencePoints { get; set; }

        public string Description { get; set; }

        //public byte Value { get; set; }
    }

 

    public static class EncounterEnemyDefinitions
    {
        public static EncounterEnemy? GetEncounterEnemy(byte byteValue)
        {
            if (byteValue == 0x00 || byteValue == 0xFF)
            {
                return null;
            }
            else
            {
                EncounterEnemyType encounterType = EncounterEnemyValues[byteValue];
                var def = EncounterEnemyDictionary[encounterType];

                return new EncounterEnemy()
                {
                    Name = def.Name,
                    HP = def.HP,
                    Description = def.Description,
                    EncounterEnemyByteValue = byteValue,
                    EncounterEnemyType = encounterType
                };
            }
        }

        public static Dictionary<byte, EncounterEnemyType> EncounterEnemyValues = new Dictionary<byte, EncounterEnemyType>()
    {
            // { 0xFF, EncounterEnemyEnum.Berlah }, //???
             { 0x0B, EncounterEnemyType.Crash },
             { 0x0C, EncounterEnemyType.Crash },
             { 0x0D, EncounterEnemyType.Pandarm },
             { 0x0E, EncounterEnemyType.Pharyad },
             { 0x0F, EncounterEnemyType.Pharyad }, //Called miniyad for some reason
             { 0x10, EncounterEnemyType.Miniyad },
             { 0x11, EncounterEnemyType.Amaries },
             { 0x12, EncounterEnemyType.Wazarn },
             { 0x13, EncounterEnemyType.Gigadan },
             { 0x14, EncounterEnemyType.Cytron },
             { 0x15, EncounterEnemyType.Gazeil },
             { 0x16, EncounterEnemyType.Gangar },
             { 0x17, EncounterEnemyType.Gangar }, //?
             { 0x18, EncounterEnemyType.MedusaGlitch },
             { 0x19, EncounterEnemyType.Medusa },
             { 0x1A, EncounterEnemyType.Gorgon1 },
             { 0x1B, EncounterEnemyType.Gorgon2 },
             { 0x1C, EncounterEnemyType.Romsarb },
             { 0x1D, EncounterEnemyType.Razaleo },
             { 0x1E, EncounterEnemyType.Corsa },
             { 0x1F, EncounterEnemyType.Megarl },
             //{ 0x20, EncounterEnemyEnum.Gorgon2 }, //Different depending on which group?
             { 0x20, EncounterEnemyType.Zahhark },
             { 0x21, EncounterEnemyType.Curgot },
             { 0x22, EncounterEnemyType.Dalzark },
             { 0x23, EncounterEnemyType.Gorla },
             { 0x24, EncounterEnemyType.Blimro },
             { 0x25, EncounterEnemyType.Gigadan },
             { 0x26, EncounterEnemyType.Meldo },
             { 0x27, EncounterEnemyType.Derol },
             { 0x28, EncounterEnemyType.Samrima },
             { 0x29, EncounterEnemyType.Kakkara },
        };

        public static Dictionary<EncounterEnemyType, EncounterEnemyDefinition> EncounterEnemyDictionary = new Dictionary<EncounterEnemyType, EncounterEnemyDefinition>()
    {
        { EncounterEnemyType.Meldo, new EncounterEnemyDefinition() {
            Name = "MELDO",
            HP = 4,
            Description = "Attacks in small groups and can call allies. Can use PAMPOO to restore their HP.",
        }},
        { EncounterEnemyType.Samrima, new EncounterEnemyDefinition() {
            Name = "SAMRIMA",
            HP = 3,
            Description = "Weak salamander-like enemy. Attacks in small groups and can call allies."
        }},
        { EncounterEnemyType.Amaries, new EncounterEnemyDefinition() {
            Name = "AMARIES",
            HP = 12,
            Description = "A fish monster with four arms. It can sing a song that causes a wave to hit your entire party. Forms the Basido Squad with the Corsa enemy."
        }},
        { EncounterEnemyType.Corsa, new EncounterEnemyDefinition() {
            Name = "CORSA",
            HP = 16,
            Description = "A four-eyed, grinning blue ghoulish-looking creature. Can use a Magic Rod and the SEAL spell that blocks your magic."
        }},
        { EncounterEnemyType.Curgot, new EncounterEnemyDefinition() {
            Name = "CURGOT",
            HP = 10,
            Description = "A robot that has a somewhat-strong attack, but no special abilities. Magic does not work on them."
        }},
        { EncounterEnemyType.Blimro, new EncounterEnemyDefinition() {
            Name = "BLIMRO",
            HP = 3,
            Description = "Very weak, but it can call allies, and you'll lose some MP if it shouts. Forms the Magic Squad with the Medusa enemy."
        }},
        { EncounterEnemyType.Medusa, new EncounterEnemyDefinition() {
            Name = "MEDUSA",
            HP = 24,
            Description = "The famous mythological Gorgon sister. Uses a Magic Arrow. Forms the Magic Squad with the Blimro enemy."
        }},
        { EncounterEnemyType.Pandarm, new EncounterEnemyDefinition() {
            Name = "PANDARM",
            HP = 16,
            Description = "An eagle-like monster carrying a large club. Can fly into the air and use the GILZADE spell."
        }},
        { EncounterEnemyType.Romsarb, new EncounterEnemyDefinition() {
            Name = "ROMSARB",
            HP = 54,
            Description = "Looks like a lion with bullhorns. Can use the SEAL spell and restore its HP with PAMPOO."
        }},
        { EncounterEnemyType.Cytron, new EncounterEnemyDefinition() {
            Name = "CYTRON",
            HP = 24,
            Description = "Looks like a cross between a lizard and a walrus. Can cast the FLAMOL1 spell. Very vulnerable to TORNADOR magic."
        }},
        { EncounterEnemyType.Megarl, new EncounterEnemyDefinition() {
            Name = "MEGARL",
            HP = 42,
            Description = "Stronger version of Corsa. Can use SEAL, MYMY, restore HP with PAMPOO, and fire a Magic Rod."
        }},
        { EncounterEnemyType.Kakkara, new EncounterEnemyDefinition() {
            Name = "KAKKARA",
            HP = 12,
            Description = "Stronger version of Samrima, but still pretty weak. Attacks in small groups and can call allies."
        }},
        { EncounterEnemyType.Dalzark, new EncounterEnemyDefinition() {
            Name = "DALZARK",
            HP = 32,
            Description = "Stronger version of Curgot, but still has no special attacks. Magic does not work on them."
        }},
        { EncounterEnemyType.Pharyad, new EncounterEnemyDefinition() {
            Name = "PHARYAD",
            HP = 54,
            Description = "Stronger version of Pandarm. Can use BOLTTOR3. Forms the Gilas Clan with the Miniyad enemy."
        }},
        { EncounterEnemyType.Miniyad, new EncounterEnemyDefinition() {
            Name = "MINIYAD",
            HP = 12,
            Description = "A baby Pharyad, very weak and easily dealt with, especially with STARDON magic."
        }},
        { EncounterEnemyType.Gazeil, new EncounterEnemyDefinition() {
            Name = "GAZEIL",
            HP = 36,
            Description = "More powerful version of Cytron, can cast FLAMOL3. Forms the Magma Squad with the Romsarb enemy."
        }},
        { EncounterEnemyType.Wazarn, new EncounterEnemyDefinition() {
            Name = "WAZARN",
            HP = 54,
            Description = "More powerful version of Amaries, uses GILZADE and can sing a song, but also summons rain."
        }},
        { EncounterEnemyType.Zahhark, new EncounterEnemyDefinition() {
            Name = "ZAHHARK",
            HP = 76,
            Description = "More powerful version of Corsa/Megarl. Uses SEAL, MYMY, and SILLEIT spells."
        }},
        { EncounterEnemyType.Gangar, new EncounterEnemyDefinition() {
            Name = "GANGAR",
            HP = 54,
            Description = "More powerful version of Cytron/Gazeil, but vulnerable to Thundern. Forms the Magma Division with Razaleo."
        }},
        { EncounterEnemyType.Razaleo, new EncounterEnemyDefinition() {
            Name = "RAZALEO",
            HP = 111,
            Description = "More powerful version of Romsarb. Uses SEAL to freeze your magic."
        }},
        { EncounterEnemyType.Gigadan, new EncounterEnemyDefinition() {
            Name = "GIGADAN",
            HP = 72,
            Description = "More powerful version of Amaries/Wazarn. Can use FLAMOL3. Forms the Fire Party with Derol."
        }},
        { EncounterEnemyType.Derol, new EncounterEnemyDefinition() {
            Name = "DEROL",
            HP = 12,
            Description = "Stronger version of Meldo, but still pathetically weak. Forms the Fire Party with Gigadan."
        }},
        { EncounterEnemyType.Gorla, new EncounterEnemyDefinition() {
            Name = "GORLA",
            HP = 62,
            Description = "The strongest robot enemy. Magic does not work on them. Rare, appears in the Light Palace in Chapter 5's past."
        }},
        { EncounterEnemyType.Gorgon1, new EncounterEnemyDefinition() {
            Name = "GORGON",
            HP = 88,
            Description = "A more powerful version of Medusa. Can use glare attack, Magic Arrow, and BOLTTOR3."
        }},
         { EncounterEnemyType.Gorgon2, new EncounterEnemyDefinition() {
            Name = "GORGON",
            HP = 122,
            Description = "It pretty much has the same attacks as the other Gorgon enemy, but this one looks different, has more HP, and only ever appears alongside the Berlahs in the Magic Squad."
        }},
        { EncounterEnemyType.Berlah, new EncounterEnemyDefinition() {
            Name = "BERLAH",
            HP = 12,
            Description = "Same as Blimro, only a little stronger, but still pretty weak. Forms the Magic Squad with Gorgon."
        }},
        { EncounterEnemyType.None, new EncounterEnemyDefinition() {
            Name = "Empty",
            HP = 0,
            Description = "Empty slot"
        }}
    };
    }
}
