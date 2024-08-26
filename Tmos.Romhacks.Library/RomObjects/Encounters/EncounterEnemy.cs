using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Enum;
using Tmos.Romhacks.Library.Enum.Enemies.Encounters;

namespace Tmos.Romhacks.Library.RomObjects.Encounters
{
    public class EncounterEnemy
    {
        public byte EncounterEnemyByteValue { get; set; }
        public EncounterEnemyType EncounterEnemyType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
    }
}
