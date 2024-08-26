using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Definitions.Encounters;
using Tmos.Romhacks.Rom.Enum;
using Tmos.Romhacks.Rom.Observer;
using Tmos.Romhacks.Rom.TmosRomDataObjects.Encounters;

namespace Tmos.Romhacks.Library.RomObjects.Encounters
{
    public class TmosModRandomEncounterLineup
    {

        public byte Startbyte { get; set; }
        public EncounterEnemy?[] EncounterEnemies { get; set; } = new EncounterEnemy?[6];
        public EncounterEnemy? EncounterEnemySlot1 { get { return EncounterEnemies[0]; } set { EncounterEnemies[0] = value; } }
        public EncounterEnemy? EncounterEnemySlot2 { get { return EncounterEnemies[1]; } set { EncounterEnemies[1] = value; } }
        public EncounterEnemy? EncounterEnemySlot3 { get { return EncounterEnemies[2]; } set { EncounterEnemies[2] = value; } }
        public EncounterEnemy? EncounterEnemySlot4 { get { return EncounterEnemies[3]; } set { EncounterEnemies[3] = value; } }
        public EncounterEnemy? EncounterEnemySlot5 { get { return EncounterEnemies[4]; } set { EncounterEnemies[4] = value; } }
        public EncounterEnemy? EncounterEnemySlot6 { get { return EncounterEnemies[5]; } set { EncounterEnemies[5] = value; } }


        public TmosModRandomEncounterLineup()
        {
            EncounterEnemies = new EncounterEnemy?[6];
        }
        public TmosModRandomEncounterLineup(byte[] bytes)
        {

            Startbyte = bytes[0];
            EncounterEnemies= new EncounterEnemy?[6] {
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[1]),
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[2]),
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[3]),
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[4]),
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[5]),
            EncounterEnemyDefinitions.GetEncounterEnemy(bytes[6]),
            };
        }

        public byte[] GetBytes()
        {
            return new byte[] { 
                Startbyte, 
                EncounterEnemySlot1?.EncounterEnemyByteValue ?? 0xFF,
                EncounterEnemySlot2?.EncounterEnemyByteValue ?? 0xFF,
                EncounterEnemySlot3?.EncounterEnemyByteValue ?? 0xFF,
                EncounterEnemySlot4?.EncounterEnemyByteValue ?? 0xFF,
                EncounterEnemySlot5?.EncounterEnemyByteValue ?? 0xFF,
                EncounterEnemySlot6?.EncounterEnemyByteValue ?? 0xFF,
            };
        }

        public string GetEncounterEnemyText(int slot)
        {
            if (EncounterEnemies[slot] == null)
            {
                return "-";
            }   
            else
                return EncounterEnemies[slot].Name;
        }


        public void OnRomDataChanged(RomDataChangeNotificationType changeType, int? index)
        {
            var a = 0;
        }
    }
}
