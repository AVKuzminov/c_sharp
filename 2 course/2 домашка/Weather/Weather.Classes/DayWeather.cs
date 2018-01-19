using System;
using Weather.Classes.Interfaces;

namespace Weather.Classes
{
	public class DayWeather : IEntity
	{
		public DateTime Date { get; set; }
		public double Temperature { get; set; }
		public int Humidity { get; set; }
		public int LocationId { get; set; }

		public bool IsValid()
		{	
			return true;
		}
	}
}
