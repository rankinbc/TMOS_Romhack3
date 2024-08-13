using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Rom
{
	public interface IRomDataManager
	{
		byte[] RomData { get; set; }


		void RegisterObserver(IRomDataObserver observer);


		void UnregisterObserver(IRomDataObserver observer);

		void NotifyObservers(int? wsIndex);

		void UpdateRomData(int offset, byte[] newData);
	}
}
