using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExample.Data
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Album> Albums { get; set; }
    }
}
