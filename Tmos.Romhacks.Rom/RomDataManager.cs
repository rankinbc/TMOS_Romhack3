using Tmos.Romhacks.Rom;

public class RomDataManager : IRomDataManager
{
	private byte[] _romData;
	private List<IRomDataObserver> _observers = new List<IRomDataObserver>();

	public byte[] RomData
	{
		get => _romData;
		set
		{
			_romData = value;
			//NotifyObservers();
		}
	}

	public void RegisterObserver(IRomDataObserver observer)
	{
		_observers.Add(observer);
	}

	public void UnregisterObserver(IRomDataObserver observer)
	{
		_observers.Remove(observer);
	}

	public void NotifyObservers(int? wsIndex)
	{
		foreach (var observer in _observers)
		{
			observer.OnRomDataChanged(wsIndex);
		}
	}

	public void UpdateRomData(int offset, byte[] newData)
	{
		Array.Copy(newData, 0, _romData, offset, newData.Length);
		//NotifyObservers();
	}

}