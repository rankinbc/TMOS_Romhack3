using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Rom.Enum;

namespace Tmos.Romhacks.Rom.Observer
{
    public interface IRomDataManager
    {
        byte[] RomData { get; set; }


        void RegisterObserver(RomDataChangeNotificationType changeType, IRomDataObserver observer);

        void UnregisterObserver(RomDataChangeNotificationType changeType, IRomDataObserver observer);

        void NotifyObservers(RomDataChangeNotificationType changeType, int? selectedIndex);

        void UpdateRomData(int offset, byte[] newData);
    }
}
