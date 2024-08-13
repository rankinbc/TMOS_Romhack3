using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom.Enum;

namespace Tmos.Romhacks.Rom.Observer
{
    public interface IRomDataObserver
    {
        void OnRomDataChanged(RomDataChangeNotificationType changeType, int? index);
    }
}
