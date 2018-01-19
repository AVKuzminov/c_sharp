using System;
using System.Collections.Generic;
using Weather.Classes.Interfaces;

namespace Weather.Classes
{
	public class Factory
	{
		private Factory() { }

		static Factory _default;

		public static Factory Default
		{
			get
			{
				if (_default == null)
					_default = new Factory();
				return _default;
			}
		}

		IRepository<Location> _locationRepo = new LocationRepository();
		IRepository<DayWeather> _weatherRepo = new WeatherRepository();
		
		public IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Location))
				return (IRepository<T>)_locationRepo;
			return (IRepository<T>)_weatherRepo;
		}
	}
}
