using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MusicExample.Data
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duratioon { get; set; }
    }
}
