using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universities3.Data
{
    public class Context:DbContext
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public Context()
            : base("localsql")
        {

        }
    }
}
