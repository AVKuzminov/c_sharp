using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Context : DbContext
    {
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DailyStatistic> DailyStatistics { get; set; }
        public Context() : base("localsql")
        {
        }
    }
}
