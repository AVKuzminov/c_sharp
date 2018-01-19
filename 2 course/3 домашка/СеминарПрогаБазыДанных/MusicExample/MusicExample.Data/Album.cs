using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExample.Data
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        [Required]
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }
        
    }
}
