using Weather.Classes;
using Weather.Classes.Interfaces;
using static System.Console;

namespace Weather.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			IRepository<Location> locationRepo = Factory.Default.GetRepository<Location>();
			IRepository<DayWeather> weatherRepo = Factory.Default.GetRepository<DayWeather>();

			// Assign a handler to the repo ItemAdded event
			weatherRepo.ItemAdded += item => WriteLine("New item added to weather repo");

			// Event handler will be called inside the AddItem
			weatherRepo.AddItem(new DayWeather { Date = new System.DateTime(2016, 10, 06), Temperature = 7, Humidity = 35, LocationId = 2 });
			
			WriteLine("Available locations:");
			foreach (var location in locationRepo.Items)
				WriteLine(location.Name);

			Write("Enter location: ");
			string locationName = ReadLine();

			Location loc = locationRepo.Find(l => l.Name.ToLower() == locationName.ToLower());
			if (loc != null)
			{
				foreach (var w in weatherRepo.Items)
					if (w.LocationId == loc.Id)
						WriteLine("{0} {1}°C {2}%", w.Date.ToShortDateString(), w.Temperature, w.Humidity);
			}
			else
			{
				WriteLine("Location not found");
			}
			ReadKey();
		}
	}
}
