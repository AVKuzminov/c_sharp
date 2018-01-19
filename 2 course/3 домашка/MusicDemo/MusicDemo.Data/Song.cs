namespace MusicDemo.Data
{
	public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

		public Album Album { get; set; }
	}
}
