using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingOmelette.MOS.Knowlegebase.FlyingOmeletteLibrary.FOTypes
{
    public class FOItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public FOItemType ItemType { get; set; }

        public enum FOItemType
        {
            Expendable,
            Permanent,
            Rods,
            Sword
        }
    }
}
