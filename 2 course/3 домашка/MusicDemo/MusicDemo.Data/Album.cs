using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDemo.Data
{
	public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public List<Song> Songs { get; set; }

        [Required]
        public Artist Artist { get; set; }
    }
}
