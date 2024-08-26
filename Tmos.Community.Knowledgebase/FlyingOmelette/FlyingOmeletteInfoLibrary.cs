using FlyingOmelette.MOS.Knowlegebase.FlyingOmeletteLibrary.FOTypes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Community.Knowledgebase.FlyingOmeletteLibrary.FOTypes;

namespace FlyingOmelette.MOS.Knowlegebase.FlyingOmeletteLibrary
{
    //Information from the useful site https://www.flyingomelette.com/ which has a lot of information about TMOS. 
    //All credit goes to FLying Omelette for the information in this class - I also used images from his site.
    //Useful for placeholder information or other data that has not yet been figured out how to get directly from ROM
    //Data from this library used throughout the project will hopefully be replaced with actual data loaded directly from the ROM file

    public static class FlyingOmeletteInfoLibrary
    {
        public static class FOCharacters
        {
            public static FOCharacter Hero = new FOCharacter
            {
                Name = "Hero",
                Description = "The descendant of Isufa and the hero of the game. This is one of those types of games in which the HERO IS YOU! (Even if that makes little sense for some, like me.) Anyway, he once tried to fight Sabaron, but the evil magician erased his memory and sent him spinning through time. After years of searching, Coronya the Time Spirit has finally found him and brought him back to Arabia to help save King Feisal and the missing princesses, and to defeat Sabaron once and for all.",
                Magics = new List<string>()
            };

            public static FOCharacter Coronya = new FOCharacter
            {
                Name = "Coronya",
                Description = "Coronya finds you at the start of the game and beckons you to return to Arabia through the Time Door. She is a cat-like being who is also known as the Time Spirit. She will be a helpful guide and ally for this journey. She will tell you when to use Oprin on the overworld to find secret doors and she'll give you clues for other things, too. In battle, she uses a Rod, which is very weak to begin with but increases in power when your Rod does.",
                Magics = new List<string> { "Defenee", "Mymy", "Gygatorn" }
            };

            public static FOCharacter Faruk = new FOCharacter
            {
                Name = "Faruk",
                Description = "Faruk is a powerful genie who helped Isufa defeat the great demon, Goragora many years ago. He disappeared when the town of Horen was swallowed up by the Moving Lake. You can find him in the town of Horen by traveling to the past before that happened. He is a strong fighter in battle, being able to attack two times per turn.",
                Magics = new List<string> { "Gilzade", "Gygatorn" }
            };

            public static FOCharacter Kebabu = new FOCharacter
            {
                Name = "Kebabu",
                Description = "I wish the artists had done a better job with Kebabu's sprite. It's almost impossible to tell what the heck she's supposed to be. In the game, she looks like a harpy. In the official artwork, she looks more like a valkyrie. Anyway, whatever she is, you'll need her help to get into the Aqua Palace. She also comes with a Ring that lets you escape from battles (even bosses) and a Mirror Shield that reflects bullets. In battle, she uses a Magic Arrow. Kebabu is square and reserved, so make sure you answer her questions politely.",
                Magics = new List<string> { "Bolttor", "Seal" }
            };

            public static FOCharacter GunMeca = new FOCharacter
            {
                Name = "Gun Meca",
                Description = "Gun Meca is a strange robot wearing a mortar board on his head and a Yen symbol on his chest. He lives in the town of Copanes in Chapter 2 and is busy learning to translate ancient Peke Peke language. I am half-tempted to think this guy is a C-3PO reference, but I can't really prove it. With a name like \"Gun Meca\", you'd expect him to be a battle robot, and maybe that was the purpose he was created for, but according to the manual, he doesn't even think of himself as a robot. So I guess he has a mind of his own. You will need his help to be able to understand the people in Alart 500 years in the past. In battle, Gun Meca can transform into a mirror to reflect enemy spells.",
                Magics = new List<string> { "Bolttor" }
            };

            public static FOCharacter Supica = new FOCharacter
            {
                Name = "Supica",
                Description = "Supica is a flying monkey who is the only living being who can guide you through the Maze Desert. He is loved by the townspeople of Alart, but his mischievous nature often gets him into trouble. He was locked up in an underground maze when he stole Lah's bread. Find him by traveling 500 years to the past, but you'll need Gun Meca's help to translate the Peke Peke language that Supica speaks. In battle, Supica shoots a Magic Arrow.",
                Magics = new List<string> { "Seal" }
            };

            public static FOCharacter Epin = new FOCharacter
            {
                Name = "Epin",
                Description = "Epin is the guardian of the town of Sudari and according to the manual, he is over 700 years old. The Demon Curly has taken him to the Dark Palace and is holding him prisoner. He carries a strange whistle that can reveal Curly's true form. Epin is not the greatest of fighters in battle.",
                Magics = new List<string> { "Defenee", "Tornador" }
            };

            public static FOCharacter Pukin = new FOCharacter
            {
                Name = "Pukin",
                Description = "A living doll made from the fruit of the Cimaron Tree. Pukin's name is most likely a shortened version of \"Pumpkin\", considering that he has a Jack-O-Lantern for a head. Pukin is hyper and sometimes gets a little too excited about things.",
                Magics = new List<string> { "Velver" }
            };

            public static FOCharacter Mustafa = new FOCharacter
            {
                Name = "Mustafa",
                Description = "Mustafa is a cantankerous old guy riding around on a floating crystal ball. He is stingy and loves money. You have to pay him 100 Rupias to join you, and he'll keep complaining that he wants more between chapters. The arguments between him and Kebabu about it are rather amusing. However, he does have a couple of important tricks up his sleeve - only he can reveal Troll's true form. He can also slows down the movement of enemies on the overworld.",
                Magics = new List<string> { "Bolttor2" }
            };

            public static FOCharacter Gubibi = new FOCharacter
            {
                Name = "Gubibi",
                Description = "As if the things that have joined your party up until this point weren't bizarre enough, Gubibi is literally a bottle with an eyeball, arms, and legs. He's also a magician, so I'm guessing that bottlecap serves as his top hat. He protected the town of Chigris from being destroyed by the Salamander. Because of this, Sabaron's followers have taken him prisoner to the Fire Palace. Rescue him to get the Holy Robe, which can protect you from the lava at the Lava Cape.",
                Magics = new List<string> { "Defenee", "Resealo" }
            };

            public static FOCharacter Rainy = new FOCharacter
            {
                Name = "Rainy",
                Description = "Just keeps getting weirder and weirder...Rainy is a Rain Shrimp who beats a drum to make it rain. (How do people come up with this stuff?) His rain is actually quite powerful and it can make Salamander show himself in the Yufla Palace, but the problem is that Rainy is a coward and doesn't like to leave his house. Only a strong Fighter is capable of convincing Rainy to join in the battle against Sabaron.",
                Magics = new List<string> { "Perius", "Matato" }
            };

            public static FOCharacter Hassan = new FOCharacter
            {
                Name = "Hassan",
                Description = "Hassan is another powerful genie and servant of Isufa like Faruk. He is the last ally to join you in the game's final chapter. He is also the only party member who does not have another out-of-battle purpose. But he's a strong fighter.",
                Magics = new List<string> { "Flamol3", "Caraba" }
            };

            public static FOCharacter Trooper = new FOCharacter
            {
                Name = "Trooper",
                Description = "If I'm not seeing this sprite wrong, these appear to be armored bulldogs, sort of like the Moblins from The Legend of Zelda series. You can hire up to 99 of these guys to join your party and help you fight the menu-driven battles. As many as four troopers will fight at once during a battle. They are very useful, especially in the early chapters. They don't have many hit points, although the stronger the Hero is, the stronger they'll be.",
                Magics = new List<string>()
            };
        }
        public static class FOCommandBattleEnemies
        {
            public static FOCommandBattleEnemy Meldo = new FOCommandBattleEnemy()
            {
                Name = "Meldo",
                Description = "I have no idea what this monster is supposed to be. Attacks in small groups and can call allies. Can use PAMPOO to restore their HP.",
                HP = 4
            };
            public static FOCommandBattleEnemy Samrima = new FOCommandBattleEnemy()
            {
                Name = "Samrima",
                Description = "Weak salamander-like enemy. Attacks in small groups and can call allies.",
                HP = 3
            };
            public static FOCommandBattleEnemy Amaries = new FOCommandBattleEnemy()
            {
                Name = "Amaries",
                Description = "A fish monster with four arms. It can sing a song that causes a wave to hit your entire party. Forms the Basido Squad with the Corsa enemy.",
                HP = 12
            };
            public static FOCommandBattleEnemy Corsa = new FOCommandBattleEnemy()
            {
                Name = "Corsa",
                Description = "A four-eyed, grinning blue ghoulish-looking creature. It usually appears alongside Amaries in the Basido Squad or Pandarm in the Air Squad. It can use a Magic Rod and the SEAL spell that blocks your magic.",
                HP = 16
            };
            public static FOCommandBattleEnemy Curgot = new FOCommandBattleEnemy()
            {
                Name = "Curgot",
                Description = "A robot that has a somewhat-strong attack, but no special abilities. Magic does not work on them.",
                HP = 10
            };
            public static FOCommandBattleEnemy Blimro = new FOCommandBattleEnemy()
            {
                Name = "Blimro",
                Description = "Very weak, but it can call allies, and you'll lose some MP if it shouts. Forms the Magic Squad with the Medusa enemy.",
                HP = 3
            };
            public static FOCommandBattleEnemy Medusa = new FOCommandBattleEnemy()
            {
                Name = "Medusa",
                Description = "The famous mythological Gorgon sister with the snakes for hair and the look that can turn a man to stone. She quite often appears in the underground mazes and uses a Magic Arrow. Forms the Magic Squad with the Blimro enemy.",
                HP = 24
            };
            public static FOCommandBattleEnemy Pandarm = new FOCommandBattleEnemy()
            {
                Name = "Pandarm",
                Description = "An eagle-like monster carrying a large club. This enemy can be quite a pain because of its ability to fly into the air. When they're in the air, they cannot be hurt by physical attacks, although magic will still work. They have a good ability to dodge physical attacks even when on the ground. They can also use the GILZADE spell. Forms the Air Squad with the Corsa enemy and the Gilas Squad with the Romsarb enemy.",
                HP = 16
            };
            public static FOCommandBattleEnemy Romsarb = new FOCommandBattleEnemy()
            {
                Name = "Romsarb",
                Description = "Looks like a lion with bullhorns (a Chimera, maybe?). It can use the SEAL spell, and it can also restore its HP with PAMPOO. Forms the Gilas Squad with the Pandarm enemy and the Magma Squad with the Gazeil enemy.",
                HP = 54
            };
            public static FOCommandBattleEnemy Cytron = new FOCommandBattleEnemy()
            {
                Name = "Cytron",
                Description = "Looks like a cross between a lizard and a walrus. Cytrons are capable of casting the FLAMOL1 spell, which can hit your entire party. They are very vulnerable to the TORNADOR magic. Forms the Fire Squad with the Megarl enemy.",
                HP = 24
            };
            public static FOCommandBattleEnemy Megarl = new FOCommandBattleEnemy()
            {
                Name = "Megarl",
                Description = "Stronger version of Corsa. It can use SEAL and MYMY to freeze your movement or magic, restore its HP with PAMPOO, and fire a Magic Rod. Forms the Fire Squad with the Cytron enemy.",
                HP = 42
            };
            public static FOCommandBattleEnemy Kakkara = new FOCommandBattleEnemy()
            {
                Name = "Kakkara",
                Description = "Stronger version of Samrima, but it's still pretty weak. Attacks in small groups and can call allies.",
                HP = 12
            };
            public static FOCommandBattleEnemy Dalzark = new FOCommandBattleEnemy()
            {
                Name = "Dalzark",
                Description = "Stronger version of Curgot, but still has no special attacks. Magic does not work on them.",
                HP = 32
            };
            public static FOCommandBattleEnemy Pharyad = new FOCommandBattleEnemy()
            {
                Name = "Pharyad",
                Description = "Stronger version of Pandarm. Along with all the other lovely capabilities Pandarm has, this one can use BOLTTOR3. Forms the Gilas Clan with the Miniyad enemy and the Air Division with the Zahhark enemy.",
                HP = 54
            };
            public static FOCommandBattleEnemy Miniyad = new FOCommandBattleEnemy()
            {
                Name = "Miniyad",
                Description = "A baby Pharyad, these things always appear in a Gilas clan with their Pharyad leader. They're very weak and easily dealt with, especially if you use STARDON magic on them.",
                HP = 12
            };
            public static FOCommandBattleEnemy Gazeil = new FOCommandBattleEnemy()
            {
                Name = "Gazeil",
                Description = "More powerful version of Cytron, these guys can cast FLAMOL3. Forms the Magma Squad with the Romsarb enemy. Watch out for their combined Firebolt magic!",
                HP = 36
            };
            public static FOCommandBattleEnemy Wazarn = new FOCommandBattleEnemy()
            {
                Name = "Wazarn",
                Description = "More powerful version of Amaries, they still use GILZADE and can sing a song, but they also summon the rain. Forms the Basido Division with the Zahhark enemy and the Zodor Division with the Razaleo enemy. Watch out for the Basido's combined Firebolt magic!",
                HP = 54
            };
            public static FOCommandBattleEnemy Zahhark = new FOCommandBattleEnemy()
            {
                Name = "Zahhark",
                Description = "More powerful version of Corsa/Megarl, and they're still using those SEAL and MYMY spells. Be careful about using magic on them because they can also use SILLEIT to turn themselves into mirrors that reflect it back! Forms the Basido Division with the Wazarn enemy and the Air Division with the Pharyad enemy.",
                HP = 76
            };
            public static FOCommandBattleEnemy Gangar = new FOCommandBattleEnemy()
            {
                Name = "Gangar",
                Description = "More powerful version of Cytron/Gazeil, but Thundern usually takes them out with one hit. Forms the Magma Division with the Razaleo enemy.",
                HP = 54
            };
            public static FOCommandBattleEnemy Razaleo = new FOCommandBattleEnemy()
            {
                Name = "Razaleo",
                Description = "More powerful version of Romsarb. These guys use SEAL to freeze your magic. Forms the Zodor Division with the Wazarn enemy and the Magma Division with the Gangar enemy.",
                HP = 111
            };
            public static FOCommandBattleEnemy Gigadan = new FOCommandBattleEnemy()
            {
                Name = "Gigadan",
                Description = "More powerful version of Amaries/Wazarn. These guys can use FLAMOL3, so be careful. Forms the Fire Party with the Derol enemy.",
                HP = 72
            };
            public static FOCommandBattleEnemy Derol = new FOCommandBattleEnemy()
            {
                Name = "Derol",
                Description = "Stronger version of Meldo, but still pathetically weak. Forms the Fire Party with the Gigadan enemy.",
                HP = 12
            };
            public static FOCommandBattleEnemy Gorla = new FOCommandBattleEnemy()
            {
                Name = "Gorla",
                Description = "The strongest robot enemy. Magic still does not work on them. They appear in the Light Palace in Chapter 5's past, but they seem to be rare.",
                HP = 62
            };
            public static FOCommandBattleEnemy Gorgon1 = new FOCommandBattleEnemy()
            {
                Name = "Gorgon",
                Description = "A more powerful version of Medusa. She can still use the glare attack that turns you to stone, freezing both your magic and movement. Other attacks include a Magic Arrow and BOLTTOR3.",
                HP = 88
            };
            public static FOCommandBattleEnemy Gorgon2 = new FOCommandBattleEnemy()
            {
                Name = "Gorgon",
                Description = "It pretty much has the same attacks as the other Gorgon enemy, but this one looks different, has more HP, and only ever appears alongside the Berlahs in the Magic Squad.",
                HP = 122
            };
            public static FOCommandBattleEnemy Berlah = new FOCommandBattleEnemy()
            {
                Name = "Berlah",
                Description = "Same as Blimro, only a little stronger, but it's still pretty darn weak. Forms the Magic Squad with the Gorgon enemy. The Magic Squad doesn't appear to have any form of combined magic.",
                HP = 12
            };
        }

        public static class FOOverworldEnemies
        {
            public static FOOverworldEnemy GiantWasp = new FOOverworldEnemy()
            {
                Name = "Giant wasp",
                Description = "These oversized bugs float about lazily on the overworld. Kill them with your Rod or Sword."
            };
            public static FOOverworldEnemy Fishman = new FOOverworldEnemy()
            {
                Name = "Fishman",
                Description = "Giant fish that leap out of the water and spit a small ball at you. Kill them with your Rod."
            };
            public static FOOverworldEnemy Pirahna = new FOOverworldEnemy()
            {
                Name = "Pirahna",
                Description = "Leaps out of the water over bridges. It's kind of hard to hit because it moves so fast, so be careful to avoid it."
            };
            public static FOOverworldEnemy Thief = new FOOverworldEnemy()
            {
                Name = "Thief",
                Description = "Bandits that jump out of the trees in the overworld to attack you. They look like they could easily be part of Ali Baba's gang of Forty Thieves. Some of them spit bullets and some don't. Kill them with your Rod or Sword.",

            };
            public static FOOverworldEnemy RedKibra = new FOOverworldEnemy()
            {
                Name = "Red kibra",
                Description = "I have no idea what these enemies are supposed to be. They have three eyes, big lips, and a horn on their heads. Could this be the legendary 'KIBRA' that the Horn comes from? That's what I'm guessing. They run around in the underground mazes, appearing and disappearing around the room.",

            };
            public static FOOverworldEnemy Centipede = new FOOverworldEnemy()
            {
                Name = "Centipede",
                Description = "Found in the Demon Palaces, these bugs come out of a little 'house'-like structure and follow each other in a chain. You have to destroy the house to stop them from regenerating. Both the bugs and the house can only be destroyed with the sword.",

            };
            public static FOOverworldEnemy Gargoyle = new FOOverworldEnemy()
            {
                Name = "Gargoyle",
                Description = "They appear to be stone statues guarding some locked doors in the palaces. If you touch them or try to open the door, they will come to life and start rolling around. They are tough to kill, so use the alternate method: Hit one of them with a Horn before it wakes up.",

            };
            public static FOOverworldEnemy AntlionTail = new FOOverworldEnemy()
            {
                Name = "Antlion tail",
                Description = "Giant insects that live in the desert and pop out of the sands to attack you. Sometimes, they only show their tails (which appear to actually function as the creatures' mouths.) When they do this, they'll often spit bullets, and you can only kill them with the sword.",

            };
            public static FOOverworldEnemy Antlion = new FOOverworldEnemy()
            {
                Name = "Antlion",
                Description = "Other times, the Antlions leap completely out of the dirt to attack you. When they do this, you can beat them with either the sword or the rod, but they can be rather tough, so be careful.",

            };
            public static FOOverworldEnemy VampireThief = new FOOverworldEnemy()
            {
                Name = "Vampire thief",
                Description = "There are some thieves that will turn into a small imp when hit with the sword or rod. They are faster and shoot bullets in this form.",

            };
            public static FOOverworldEnemy KillerFlower = new FOOverworldEnemy()
            {
                Name = "Killer flower",
                Description = "At first these look like normal harmless sunflowers, but they suddenly reveal their chomping mouths and come after you. If one of them touches you, it holds you in place, but usually one more hit kills it, no matter how much damage it originally took.",

            };
            public static FOOverworldEnemy Boulder = new FOOverworldEnemy()
            {
                Name = "Boulder",
                Description = "Giant rocks that fall in groups of three in the desert and other areas. You cannot destroy them so just try your best to avoid them.",

            };
            public static FOOverworldEnemy VampireWasp = new FOOverworldEnemy()
            {
                Name = "Vampire wasp",
                Description = "Starting in Chapter 3, some of the Giant Wasps you hit with your sword or rod will transform into a bat-like creature with a single eyeball. Grim Reapers often show up on screens with these monsters if you don't kill them fast enough.",

            };
            public static FOOverworldEnemy GrimReaper = new FOOverworldEnemy()
            {
                Name = "Grim reaper",
                Description = "If you stay on certain overworld screens for too long, the Reaper will show up and start chasing you around. The only way to get rid of him is to kill him because he will follow you from screen to screen. Even if you go into a town, he'll still be waiting for you when you leave. He's tough, but will often drop money bags when defeated.",

            };
            public static FOOverworldEnemy Log = new FOOverworldEnemy()
            {
                Name = "Log",
                Description = "Same as the boulder, they also fall in groups of three and cannot be destroyed. The only difference is that you find them in forested areas.",
            };
            public static FOOverworldEnemy EvilTree = new FOOverworldEnemy()
            {
                Name = "Evil tree",
                Description = "When Sabaron cut down the original Cimaron Tree, which served as the King of the Forest, the other trees became loyal to him. As such, you'll have to fight these bouncing botanical monsters in many of the deep parts of the woods.",
            };
            public static FOOverworldEnemy LargeTree = new FOOverworldEnemy()
            {
                Name = "Large tree",
                Description = "When hit with your rod or sword, this large tree splits into a bunch of smaller bouncing trees. But don't let him wander around for too long before you attack him because he can freeze your movement.",
            };
            public static FOOverworldEnemy Djinni = new FOOverworldEnemy()
            {
                Name = "Djinni",
                Description = "A genie-like creature that rides on a cloud and hangs out at the very edge of the screen. He shoots a blast of air and leaves out of his horn at you. The wind can prevent you from being able to move and the leaves do damage. Kill him with the rod. He'll drop money bags, but most of the times they'll land where you can't reach them.",
            };
            public static FOOverworldEnemy BlueKibra = new FOOverworldEnemy()
            {
                Name = "Blue kibra",
                Description = "These are a little stronger than the red type. They move faster and shoot bullets.",
            };
            public static FOOverworldEnemy Changarl = new FOOverworldEnemy()
            {
                Name = "Changarl",
                Description = "A wizard that appears in certain rooms of some palaces. He does a wild take and carries forks in his hands. Try not to get hit by more than two of the little bombs he spits about because they will change you into a cake (which probably explains the forks). If that happens, you could get killed instantly by Changarl's helpers.",
            };
            public static FOOverworldEnemy ChangarlHelper = new FOOverworldEnemy()
            {
                Name = "Changarl's helper",
                Description = "Another creature like Gilga that has an eyeball inside a toothy mouth. These things only appear alongside the wizard Changarl. If Changarl changes your form, you could get killed instantly by touching one of them.",
            };
            public static FOOverworldEnemy Mardul = new FOOverworldEnemy()
            {
                Name = "Mardul",
                Description = "A wizard that appears in certain rooms of some palaces. He spins around and turns into a tulip. Try not to get hit by more than two of the petals he shoots at you because they will change you into an inchworm. If that happens, you could get killed instantly by Mardul's helpers.",
            };
            public static FOOverworldEnemy MardulHelper = new FOOverworldEnemy()
            {
                Name = "Mardul's helper",
                Description = "Someone must have been a fan of Fantasia because the 'sorcerer's apprentices' in this case are dancing brooms. If they hit you while Mardul's magic has turned you into an inchworm, it spells instant death.",
            };
            public static FOOverworldEnemy BlueDragon = new FOOverworldEnemy()
            {
                Name = "Blue dragon",
                Description = "A segmented serpent that appears in some rooms of the palaces to guard certain doors. You have to kill it to open the door. Its body is made of eyeballs and it shoots bullets from its mouth. It bounces back and forth rapidly and can be hard to hit if you're not a Magician.",
            };
            public static FOOverworldEnemy Ifrit = new FOOverworldEnemy()
            {
                Name = "Ifrit",
                Description = "Dances about wildly while encircling itself with a ring of fire. It can expand the radius of the ring, so try to get inside of it to minimize damage. It will often drop money bags upon defeat.",
            };
            public static FOOverworldEnemy Sandbeast = new FOOverworldEnemy()
            {
                Name = "Sandbeast",
                Description = "These things are freaky-looking as hell. They camouflage themselves in the ash that's formed in the lava and magma that surrounds the Salamander's Palace. They don't move until you step into the ash and disturb their slumber."
            };
            public static FOOverworldEnemy Warhammer = new FOOverworldEnemy()
            {
                Name = "Warhammer",
                Description = "Another one of the palace wizards. This guy can turn you into a helpless skull if he hits you too many times (or if you just take too long beating him). Take him out quickly so that his hammer helpers don't smash you flat.",
            };
            public static FOOverworldEnemy WarhammerHelper = new FOOverworldEnemy()
            {
                Name = "Warhammer's helper",
                Description = "Warhammer's helpers are exactly what you'd expect - giant hammers.",
            };
            public static FOOverworldEnemy Barzil = new FOOverworldEnemy()
            {
                Name = "Barzil",
                Description = "Another one of the palace wizards. This one is the toughest of the bunch. He can turn you into a helpless bouncing ball and worse yet, a Moniburn Rocket! His helpers are tough to destroy, although they will fizzle out after awhile. Kill this guy as quickly as you possibly can."
            };
            public static FOOverworldEnemy BarzilHelper = new FOOverworldEnemy()
            {
                Name = "Barzil's helper",
                Description = "Barzil's helpers are giant living flames. They are tough to destroy. Ignore them and concentrate on Barzil himself."
            };
            public static FOOverworldEnemy SkullDemon = new FOOverworldEnemy()
            {
                Name = "Skull demon",
                Description = "Skeletal monsters that inhabit the palaces in the final chapter. They are pretty much the same as the Thieves in their manner of movement and attack patterns.",
            };
            public static FOOverworldEnemy RedDragon = new FOOverworldEnemy()
            {
                Name = "Red dragon",
                Description = "Not sure if there's any difference between this and the blue variety, but I don't think it's an issue with the NES's color limitations since I've seen both appear on identical backgrounds. I'm guessing the red is supposed to be stronger than the blue, but you're so powerful by the time you see one that they die in the same amount of hits.",
            };
        }

        public static class FOItems
        {
            public static FOItem Amulet = new FOItem()
            {
                Name = "Amulet",
                Description = "It looks like a small pill. If you get transformed by a Wizard's spell, the Amulet will automatically change you back. You usually find it randomly after winning battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Bread = new FOItem()
            {
                Name = "Bread",
                Description = "If you lose all of your HP, you will automatically eat the bread and gain some (but not all) back. Buy it in shops or win from battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Carpet = new FOItem()
            {
                Name = "Carpet",
                Description = "You can use the Magic Carpet to escape from the palaces and mazes, or use on the overworld to return to a town. Buy it in shops or win from battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Hammer = new FOItem()
            {
                Name = "Hammer",
                Description = "When you use the Hammer, stars fall from the sky and damage all enemies that are on-screen. You can sometimes win them from battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Horn = new FOItem()
            {
                Name = "Horn",
                Description = "This is the Horn of the Kibra. It can be used as a weapon, but has a more vital purpose. Some rooms in the Demon Palaces have locked doors guarded by statues that come to life if you touch them or try to open the door. If you use a Horn on one of the statues, they won't come to life and the door will open safely. You can buy them in shops.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem HPDrink = new FOItem()
            {
                Name = "HP drink",
                Description = "This thing is not named in the manual or the game. It looks like the Mashroob, except that it's orange instead of blue and it restores your HP instead of your MP. You only get this occasionally from defeated overworld enemies.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Key = new FOItem()
            {
                Name = "Key",
                Description = "You will need these to unlock doors in the Demon Palaces. You can buy them in shops.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Map = new FOItem()
            {
                Name = "Map",
                Description = "It is a map of the current chapter's Demon Palace. While inside the palace, enter the subscreen to view it. It will only work for that world. Buy it in shops.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Mashroob = new FOItem()
            {
                Name = "Mashroob",
                Description = "If you lose all of your MP and try to use another spell, you will automatically drink the Mashroob to restore some (but not all) of your MP. Buy it in shops or win from battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem MoneyBag = new FOItem()
            {
                Name = "Money bag",
                Description = "You sometimes win these from defeated enemies on the overworld. They are worth a lot of coins!",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem RSeed = new FOItem()
            {
                Name = "R. seed",
                Description = "This is the Rupia's Seed. Plant it in a Magic Field in the past during the Solar Eclipse, and then travel forward in time. Find the Magic Field and you'll discover that the Rupia Tree has grown, and you'll be rewarded with a ton of cash. Alternately, you can eat the Rupia's Seed to become invisible. Buy it in shops or win from battles.",
                ItemType = FOItem.FOItemType.Expendable
            };
            public static FOItem Rupia = new FOItem()
            {
                Name = "Rupia",
                Description = "Used as money in the world of TMoS. You'll often win single Rupia coins from defeated enemies on the overworld.",
                ItemType = FOItem.FOItemType.Expendable
            };

            // Permanent Items
            public static FOItem HolyRobe = new FOItem()
            {
                Name = "Holy robe",
                Description = "The Holy Robe is a treasure owned by the magician Gubibi. You can find him locked up in the Fire Palace in the present world of Chapter 4. The robe allows you to safely jump into the lava at the north cape in Celestern's past.",
                ItemType = FOItem.FOItemType.Permanent
            };
            public static FOItem LArmor = new FOItem()
            {
                Name = "L. armor",
                Description = "This is the Light Armor that belonged to the hero's ancestor, Isufa. Kaji is guarding it in the town of Pao in Chapter 5. You must bring him the Legend Sword before he'll let you have it. It's the strongest armor in the game, and it will give you access to Sabaron's Palace.",
                ItemType = FOItem.FOItemType.Permanent
            };
            public static FOItem MBoots = new FOItem()
            {
                Name = "M. boots",
                Description = "These are the Magic Boots you get for telling Lah in Chapter 2 that he isn't stingy. If you are the Saint Class, the boots will allow you to walk over damage zones without actually taking any damage. They aren't much, but if you don't get them from Lah, Supica won't join you.",
                ItemType = FOItem.FOItemType.Permanent
            };
            public static FOItem MShield = new FOItem()
            {
                Name = "M. shield",
                Description = "This is the Mirror Shield and you automatically get it when Kebabu joins your party. It will allow you to reflect bullets that hit you from the front. If you are the Saint class, you will reflect them automatically. If not, use the sword to reflect then. The Mirror Shield might also bounce back certain enemy spells.",
                ItemType = FOItem.FOItemType.Permanent
            };
            public static FOItem RArmor = new FOItem()
            {
                Name = "R. armor",
                Description = "The first special suit of armor you will receive, but I have no idea what the 'R' stands for. It will increase your defense against both physical and magic attacks. Get it by passing the SPRICOM course at the Magic University in Chapter 3.",
                ItemType = FOItem.FOItemType.Permanent
            };
            public static FOItem Ring = new FOItem()
            {
                Name = "Ring",
                Description = "She doesn't mention it, but you also get the Ring when Kebabu joins you. You can use it to escape from wizard battles and bosses. It might be necessary to do this if you find yourself fighting a boss before you're able to beat it.",
                ItemType = FOItem.FOItemType.Permanent
            };

            // Rods
            public static FOItem Rod = new FOItem()
            {
                Name = "Rod",
                Description = "This is the magic rod that fires a bolt of energy across the screen. It is more powerful if you are currently the Magician class. You begin the game with this basic rod. Some enemies, particularly the bosses, can only be defeated with the rod. Enemies hit by it explode into stars.",
                ItemType = FOItem.FOItemType.Rods
            };
            public static FOItem Flame = new FOItem()
            {
                Name = "Flame",
                Description = "The second magic rod you can get. Enemies struck by it are engulfed in flames. Earn it by passing the MONECOM course at the Magic University in Chapter 1.",
                ItemType = FOItem.FOItemType.Rods
            };
            public static FOItem Stardust = new FOItem()
            {
                Name = "Stardust",
                Description = "If you are the Magician class, this is the first rod that will allow you to fire two shots in rapid succession. Enemies hit by it explode into stars. Get it by passing the RAINCOM course at the Magic University in Chapter 2.",
                ItemType = FOItem.FOItemType.Rods
            };
            public static FOItem Cimaron = new FOItem()
            {
                Name = "Cimaron",
                Description = "If you are the Saint class, you will get this rod by talking to the Cimaron Tree 30 years in the future of Chapter 3. You must answer his question truthfully and tell him the password. Aside from being a more powerful rod, the Cimaron will also shine light to help you see your way through the Dark Maze.",
                ItemType = FOItem.FOItemType.Rods
            };
            public static FOItem Crystal = new FOItem()
            {
                Name = "Crystal",
                Description = "A powerful rod that shoots three stars in rapid succession. Get it by passing the MOSCOM course at the Magic University in Chapter 4.",
                ItemType = FOItem.FOItemType.Rods
            };
            public static FOItem Isfa = new FOItem()
            {
                Name = "Isfa",
                Description = "The most powerful rod in the game, it used to belong to the hero's ancestor, Isufa. It shoots a wide circle of light and you can fire up to four of them at once. You'll get it after you encounter Sabaron in his palace in Chapter 5.",
                ItemType = FOItem.FOItemType.Rods
            };

            // Swords
            public static FOItem Sword = new FOItem()
            {
                Name = "Sword",
                Description = "This is the most basic sword. You begin the game with it. The sword is best for use in hand-to-hand combat. It is more powerful and twice as long if you are currently the Fighter class. Some enemies can only be defeated with the sword.",
                ItemType = FOItem.FOItemType.Sword
            };
            public static FOItem Simitar = new FOItem()
            {
                Name = "Simitar",
                Description = "The second sword. It is a little bit more powerful than the one you start with and will be helpful in battles early on. Get it by passing the ALALART course at the Magic University in Chapter 1.",
                ItemType = FOItem.FOItemType.Sword
            };
            public static FOItem Dragoon = new FOItem()
            {
                Name = "Dragoon",
                Description = "The third sword. If you are the Fighter class, then this is the first sword that fires a smaller sword from its tip. (It will only work if your HP is full enough, though.) Get it by passing the LIBRA course at the Magic University in Chapter 2.",
                ItemType = FOItem.FOItemType.Sword
            };
            public static FOItem Kashim = new FOItem()
            {
                Name = "Kashim",
                Description = "The fourth sword. If you are the Fighter class, the sword it fires from its tip goes farther than the Dragoon's did, if your hit points are full enough. Find it in the Dark Underground Maze of Chapter 3.",
                ItemType = FOItem.FOItemType.Sword
            };
            public static FOItem Rostam = new FOItem()
            {
                Name = "Rostam",
                Description = "The fifth sword, it belonged to the hero Rostam who lived 3000 years ago. If you are the Fighter class, it will fire two swords from its tip simultaneously. Find it in the Yufla Palace in the past world of Chapter 4.",
                ItemType = FOItem.FOItemType.Sword
            };
            public static FOItem Legend = new FOItem()
            {
                Name = "Legend",
                Description = "The final and most powerful sword in the game. It shoots twin sword tips like the Rostam, but you can fire two sets of them at once. Get it in the Light Palace in the past of Chapter 5. Unfortunately, you won't get much use out of this weapon since you need to be a Magician to beat the game, but it is necessary to find it so that you can get the L. Armor from Kaji.",
                ItemType = FOItem.FOItemType.Sword
            };
        }

        public static class FONPCs
        {
            public static class FlyingOmeletteInfoLibrary
            {
                public static class FONPCs
                {
                    public static FONPC Imam = new FONPC()
                    {
                        Name = "Imam",
                        Description = "The Mosque Leader. Look for a building in the towns with a lot minarets on top. He will help you by reviving dead allies, changing your class, or giving you a new password. Sometimes, he will ask for a small donation in return for his services."
                    };
                    public static FONPC Shopkeeper = new FONPC()
                    {
                        Name = "Shopkeeper",
                        Description = "This guy sells all kinds of useful items that will help you on your quest. Look for a door with the letter 'S' outside of it. You can try bargaining with him to lower the prices. Sometimes, he'll comply and other times he'll get really mad and throw you out. If he does the latter, he'll also take some of your money, so be careful about haggling too much."
                    };
                    public static FONPC Innkeeper = new FONPC()
                    {
                        Name = "Innkeeper",
                        Description = "Looks the same as the Shopkeeper (when he isn't pissed off), but this guy runs the Hotels instead. Look for a door with the letter 'H' outside of it. By staying at a Hotel, you can restore all of your HP and MP, but you cannot revive dead allies."
                    };
                    public static FONPC Philanthropist = new FONPC()
                    {
                        Name = "Philanthropist",
                        Description = "Occasionally, you can find a hidden door with a woman inside who will give you 50 Rupias to help in your quest to defeat Sabaron. She will only do this once, though."
                    };
                    public static FONPC FieldCaretaker = new FONPC()
                    {
                        Name = "Field caretaker",
                        Description = "This woman is the caretaker of the Magic Field. Plant a Rupia's Seed here during the Solar Eclipse, then travel to the future to reap its harvest."
                    };
                    public static FONPC CasinoHost = new FONPC()
                    {
                        Name = "Casino host",
                        Description = "The host of the Casino, who else? He'll let you play a game for a chance to win some money. You'll have better luck during the Solar Eclipse, though. Look for a fancy building that actually says 'CASINO' on it."
                    };
                    public static FONPC Assistant = new FONPC()
                    {
                        Name = "Assistant",
                        Description = "This woman works at the Magic University and will help you select courses. The university is sometimes in plain view, but oftentimes it's hidden, and you'll either have to use OPRIN to find it or work your way through a maze."
                    };
                    public static FONPC Teacher = new FONPC()
                    {
                        Name = "Teacher",
                        Description = "This is the guy who actually teaches the courses at the Magic University. (Friendly-looking fellow, isn't he?) It's best to always take every class they offer. You'll not only learn valuable things about certain spells, but you might get an important item for passing the course."
                    };
                    public static FONPC WiseMan = new FONPC()
                    {
                        Name = "Wise man",
                        Description = "There is a Wise Man hidden in each chapter. If you find him, he will grant you use of one of the Great Magics. However, you will only be able to use the spell during the Alalart Solar Eclipse. Once the magic is used up, you can return to him and get the spell again if you'd like."
                    };
                    public static FONPC RupiaTree = new FONPC()
                    {
                        Name = "Rupia tree",
                        Description = "If you plant a Rupia's Seed in the past and go to the Magic Field years later, you will find the Rupia Tree has grown! You will get lots of money from the harvest. You can also make a special Rupia Tree grow by using the Great Magic MONECOM."
                    };
                    public static FONPC Jad = new FONPC()
                    {
                        Name = "Jad",
                        Description = "A strange fellow who lives in the town of Rudoria in Chapter 1 and talks in rhymes. The townspeople think he's a little crazy, but he swears his story is true. It is. He's actually giving you a clue to the location of Mooroon's Time Door."
                    };
                    public static FONPC Dogos = new FONPC()
                    {
                        Name = "Dogos",
                        Description = "Okay, the game says this is a woman, and indeed she's wearing a woman's headdress, but she has a mustache and beard! Anyway, Dogos is an old fortune teller who might seem a little off her rocker, but what she tells you about how to jump off the North Cape without dying is absolutely true. She lives in the town of Poponoll in Chapter 1."
                    };
                    public static FONPC Beckal = new FONPC()
                    {
                        Name = "Beckal",
                        Description = "To call Beckal an 'important character' is stretching the definition of 'important', but I just had to include him because of how funny he is! You'll meet this guy in Chapter 1 in Horen in the past. Despite the fact that the town is sinking into the Moving Lake, he declares that he will never leave his home, no matter what. Well, does he? Go visit the sunken Horen in the present to find out..."
                    };
                    public static FONPC Ashelato = new FONPC()
                    {
                        Name = "Ashelato",
                        Description = "Ashelato is the first of the four princesses you will rescue. She is being held by the demon Gilga in the Aqua Palace of Chapter 1. She is the oldest daughter of the King Feisal."
                    };
                    public static FONPC Sabaron = new FONPC()
                    {
                        Name = "Sabaron",
                        Description = "The evil mastermind of the game's story, Sabaron kidnapped the four princesses and the king, and unleashed the demons from the underworld. (He also apparently shares beauty secrets with the Emperor from Return of the Jedi.) The Hero attempted to fight Sabaron, but the evil magician erased his memory and sent him spinning through time. Sabaron will show up occassionally to taunt you. He is currently preparing to resurrect the great demon Goragora from the Dark World."
                    };
                    public static FONPC Zainab = new FONPC()
                    {
                        Name = "Zainab",
                        Description = "She lives in the town of Copanes in the present world of Chapter 2. She will give you some information about Supica, the flying monkey who can guide you through the Maze Desert. (It's odd that they bothered to name a character for this task since the old man sitting to her right will give you a much more direct and blatant clue about him.)"
                    };
                    public static FONPC Lah = new FONPC()
                    {
                        Name = "Lah",
                        Description = "You can find Lah in the town of Alart 500 years in the past of Chapter 2. The townspeople are upset because Lah has locked their beloved flying monkey Supica up in a dungeon for stealing his bread. You must get Gun Meca to join you before you can understand the Peke Peke language that Lah speaks. Once you can understand him, Lah will give you important information on finding Supica, as well as the Magic Boots...so long as you are nice to him."
                    };
                    public static FONPC Ishutal = new FONPC()
                    {
                        Name = "Ishutal",
                        Description = "Ishutal is the second of the four princesses you will rescue. She is being held by the demon Curly in the Dark Palace of Chapter 2. She is the second-oldest daughter of the King Feisal."
                    };
                    public static FONPC Mohammed = new FONPC()
                    {
                        Name = "Mohammed",
                        Description = "Mohammed lives in the town of Kasimeel in the present world of Chapter 3. When Sabaron cut down the tree that was the Forest King, all the trees became loyal to him. Mohammed buried a Cimaron seed that will grow up to be the new king, and he will tell you where he buried it."
                    };
                    public static FONPC CimaronTree = new FONPC()
                    {
                        Name = "Cimaron tree",
                        Description = "This is the tree that grew from the seed that Mohammed planted. He will become the new King of the Forest. He promises to give his first-born son to a Saint in the future. Change your class to Saint and find him in the future to get the Cimaron's Fruit."
                    };
                    public static FONPC Supapa = new FONPC()
                    {
                        Name = "Supapa",
                        Description = "Supapa is an old dollmaker who lives in the town of Nubia in the future world of Chapter 3. (He is like this game's version of Gepetto from Pinnochio.) He can turn the Cimaron's Fruit into a living doll. Bring it to him to get Pukin into your party."
                    };
                    public static FONPC Roxanne = new FONPC()
                    {
                        Name = "Roxanne",
                        Description = "Roxanne is the third of the four princesses you will rescue. She is being held by the demon Troll in the Frozen Palace of Chapter 3. She is the third-oldest daughter of the King Feisal."
                    };
                    public static FONPC Feisal = new FONPC()
                    {
                        Name = "Feisal",
                        Description = "King Feisal is the ruler of Arabia and father of the four princesses, including Scheherazade. He was taken prisoner by the evil magician Sabaraon and has been locked up in the Yufla Palace, 3000 years in the past. You will meet him when you beat the Salamander at the end of Chapter 4."
                    };
                    public static FONPC Kaji = new FONPC()
                    {
                        Name = "Kaji",
                        Description = "Kaji guards the Light Armor that belonged to Isufa many years ago. He lives in the town of Pao in the present world of Chapter 5. You will have to prove that you are Isufa's true heir by bringing him the Legend Sword before he will tell you how to find the armor."
                    };
                    public static FONPC Scheherazade = new FONPC()
                    {
                        Name = "Scheherazade",
                        Description = "The lady love of the main character and the youngest of King Feisal's daughters. She was kidnapped by the evil magician Sabaron and he is holding her prisoner in his palace. You will meet her after you encounter Sabaron in the final palace of Chapter 5."
                    };
                }
            }
        }
    }
}
