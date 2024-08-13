using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Library.Definitions;
using Tmos.Romhacks.Library.Enum;
using static Tmos.Romhacks.Library.Definitions.WSContentDefinitions;


namespace Tmos.Romhacks.Library.RomObjects.WorldScreen.Properties
{
    public class WSContent
    {
        public byte ContentByteValue { get; set; }
        public WSContentType ContentType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
