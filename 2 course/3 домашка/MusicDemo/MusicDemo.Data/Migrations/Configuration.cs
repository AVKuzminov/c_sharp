namespace MusicDemo.Data.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<MusicDemo.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

			// More advanced examples will come next time

            context.Artists.AddOrUpdate(a => a.Name,
                new Artist { Name = "The Beatles", Country = "UK" }
                );
        }
    }
}
