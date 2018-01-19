using Weather.Classes.Interfaces;

namespace Weather.Classes
{
	public class Location : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public bool IsValid()
		{
			return !string.IsNullOrWhiteSpace(Name);
		}
	}
}
