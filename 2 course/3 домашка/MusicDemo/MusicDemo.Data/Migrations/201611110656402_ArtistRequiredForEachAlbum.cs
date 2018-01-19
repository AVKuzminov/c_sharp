namespace MusicDemo.Data.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class ArtistRequiredForEachAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            AlterColumn("dbo.Albums", "Artist_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            AlterColumn("dbo.Albums", "Artist_Id", c => c.Int());
            CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
