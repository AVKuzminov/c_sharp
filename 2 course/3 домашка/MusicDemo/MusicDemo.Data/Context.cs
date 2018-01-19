using System.Data.Entity;

namespace MusicDemo.Data
{
	public class Context : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Song>()
				.HasRequired<Album>(s => s.Album);
		}

		public Context() : base("localsql")
        {
        }
    }
}
