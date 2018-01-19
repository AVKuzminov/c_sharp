using System.Collections.Generic;

namespace MusicDemo.Data
{
	public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
