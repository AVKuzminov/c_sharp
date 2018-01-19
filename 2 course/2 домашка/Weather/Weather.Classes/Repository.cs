using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Weather.Classes.Interfaces;

namespace Weather.Classes
{
	public class Repository<T> : IRepository<T> where T : IEntity
	{
		protected List<T> _items;

		public event Action<T> ItemAdded;

		public IEnumerable<T> Items
		{
			get
			{
				return _items;
			}
		}

		public void AddItem(T item)
		{
			if (!item.IsValid())
				throw new ArgumentException();
			_items.Add(item);
			ItemAdded?.Invoke(item);
		}

		public T Find(Predicate<T> predicate)
		{
			return _items.Find(predicate);
		}

		public void RemoveItem(T item)
		{
			_items.Remove(item);
		}
	}

	public class LocationRepository : Repository<Location>
	{
		public LocationRepository()
		{
			string contents = File.ReadAllText("../../../locations.json");
			_items = JsonConvert.DeserializeObject<List<Location>>(contents);
		}
	}

	public class WeatherRepository : Repository<DayWeather>
	{
		public WeatherRepository()
		{
			string contents = File.ReadAllText("../../../weather.json");
			_items = JsonConvert.DeserializeObject<List<DayWeather>>(contents);
		}
	}
}
