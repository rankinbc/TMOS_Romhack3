using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Rom
{
    public static class TmosRomKnownAddresses
    {
        public static class TmosRomObjectArrays
        {
            public const int WorldScreenDataStartAddress = 0x03968b;
            public const int WorldScreenStartAddress = 0x039695;
            public const int TileSectionStartAddress = 0x03c4c7;
            public const int WorldScreenTileDataStartAddress = 0x03c4c7;
            //  public const int WorldScreenTileDataStartAddress = 0x3D187;
            public const int TileStartAddress = 0x011b0b;
            public const int MiniTileStartAddress = 0x01160b;
            public const int RandomEncounterGroupStartAddress = 0x00C02A;
            public const int RandomEncounterLineupStartAddress = 0x00C211;
        }

        public static class GameVariables
        {
            public const int MaxBreadsAddress = 0x42e5;
            public const int MaxMashroobsAddress = 0x4729;

            public const int TrooperPriceAddress = 0x4577;

            //change university costs
            //WriteByte(fs, 0x52b2, 0x05);
            //WriteByte(fs, 0x52b4, 0x14);
            //WriteByte(fs, 0x52b6, 0x14);
            //WriteByte(fs, 0x51b8, 0x14);

            //WriteByte(fs, 0x52c1, 0x16);
            //WriteByte(fs, 0x52c3, 0x28);
            //WriteByte(fs, 0x52c5, 0x28);

            //WriteByte(fs, 0x52d0, 0x25);
            //WriteByte(fs, 0x52d2, 0x3c);
            //WriteByte(fs, 0x52d4, 0x3c);
            //WriteByte(fs, 0x51d6, 0x3c);

            //WriteByte(fs, 0x52df, 0x32);
            //WriteByte(fs, 0x52e1, 0x50);
            //WriteByte(fs, 0x52e3, 0x50);

            //WriteByte(fs, 0x52ee, 0x40);
            //WriteByte(fs, 0x52f0, 0x64);
            //WriteByte(fs, 0x52f2, 0x64);


            public const int HeroColorNormalAddress = 0x1ed07;
            public const int HeroColorBattleAddress = 0xca72;
            public const int HeroColorRArmorAddress = 0x1ed0a;
            public const int HeroColorRArmorBattleAddress = 0xca75;


            public class TitleScreenVariables
            {
                public const int StartScreenTitleColorAddress = 0x38890;
                public const int StartScreenTitleColor2Address = 0x38892;
                public const int StartScreenTitleColor3Address = 0x38894;

                public const int StartScreenCreditTextAddress = 0x038473;
                public const int StartScreenCreditText2Address = 0x038431;
                public const int StartScreenSeedTextAddress = 0x038493;

                //StartScreen Title Color
                //            fs.Seek(0x38890, SeekOrigin.Begin);
                //        fs.Write(new byte[] { 0x72 }, 0, 1);
                //        fs.Seek(0x38892, SeekOrigin.Begin);
                //        fs.Write(new byte[] { 0x02 }, 0, 1);
                //        fs.Seek(0x38894, SeekOrigin.Begin);
                //        fs.Write(new byte[] { 0x12 }, 0, 1);

                //        //StartScreen Text mod
                //        byte[] modText = new byte[] { 0x41, 0x30, 0x3D, 0x33, 0x3E, 0x3C, 0x38, 0x49, 0x34, 0x33, 0x2C, 0x23, 0x64, 0x18, 0x3C, 0x3E, 0x33, 0x2C, 0x31, 0x48, 0x2C, 0x32, 0x43, 0x01, 0x08, 0x07, 0x2C, 0x42, 0x34, 0x34, 0x33, 0x2C };
                //fs.Seek(0x038473, SeekOrigin.Begin);
                //        fs.Write(modText, 0, modText.Length);

                //        byte[] modText2 = new byte[] { 0x41, 0x30, 0x3D, 0x33, 0x3E, 0x3C, 0x38, 0x49, 0x34, 0x33, 0x2C, 0x41, 0x03 };
                //fs.Seek(0x038431, SeekOrigin.Begin);
                //        fs.Write(modText2, 0, modText2.Length);

                //        //Seed text
                //        fs.Seek(0x038493, SeekOrigin.Begin);
                //        fs.Write(GetSeedTextBytes(tb_seed.Text), 0, 6);
            }

            public static class EnemyVariables
            {
                //Gilga
                public const int GilgaEyeHpAddress = 0x1743f;
                public const int GilgaStage2HpDamageAddress = 0x17447;
                public const int GilgaThunderDamageAddress = 0x18751;
                public const int GilgaProjectileDamageAddress = 0x17248;
                public const int GilgaProjectileSpeedAddress = 0x174c6;

                //Curly
                public const int CurlyArmHpAddress = 0x17450;
                public const int CurlyProjectileDamageAddress = 0x1724c;
                public const int CurlyProjectileCooldownAddress = 0x1724f;
                public const int CurlyColorAddress = 0x1156e;

                //Troll
                public const int TrollSwitchPositionDelayTimeAddress = 0x17A24;
                public const int TrollHpAddress = 0x17459; //Parts 1 and 2 of battle
                public const int TrollThunderDamageAddress = 0x18759;
                public const int TrollProjectileDamageAddress = 0x17250;
                public const int TrollProjectileBehaviorAddress = 0x17251;
                public const int TrollProjectileCooldownAddress = 0x17253;
                public const int TrollCollisionDamageAddress = 0x17455;

                //Salamander
                public const int SalamanderHpAddress = 0x17462;
                public const int SalamanderProjectileCooldownAddress = 0x17257;
                public const int SalamanderProjectileSpeedAddress = 0x17255;
                public const int SalamanderFireMagicDamageAddress = 0x1875d;
                public const int SalamanderFireFieldAnimationAddress = 0x18a46; //Risky to change

            }

        }

        public static class ChapterDataOffsets
        {
            public static class Chapter1
            {
                public const int WorldScreenDataStartAddress = 0x039695;
                public const int RandomEncounterGroupDataOffset = 0xC02A;
                public const int RandomEncounterLineupDataOffset = 0xC211;
            }
            public static class Chapter2
            {
                public const int WorldScreenDataStartAddress = 0x039EC5;
                public const int RandomEncounterGroupDataOffset = 0xC058;
                public const int RandomEncounterLineupDataOffset = 0xC241;
            }

            public static class Chapter3
            {
                public const int WorldScreenDataStartAddress = 0x03A755;
                public const int RandomEncounterGroupDataOffset = 0xC089;
                public const int RandomEncounterLineupDataOffset = 0xC271;
            }

            public static class Chapter4
            {
                public const int WorldScreenDataStartAddress = 0x03B0E5;
                public const int RandomEncounterGroupDataOffset = 0xC0BD;
                public const int RandomEncounterLineupDataOffset = 0xC2C1;
            }

            public static class Chapter5
            {
                public const int WorldScreenDataStartAddress = 0x03BB25;
                public const int RandomEncounterGroupDataOffset = 0xC100;
                public const int RandomEncounterLineupDataOffset = 0xC301;
            }
        }
    }
}
