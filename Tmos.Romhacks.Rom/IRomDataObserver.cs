using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Rom
{
	public interface IRomDataObserver
	{
		void OnRomDataChanged(int? wsIndex);
	}
}
