namespace MusicDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumRequiredForSong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            AlterColumn("dbo.Songs", "Album_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "Album_Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            AlterColumn("dbo.Songs", "Album_Id", c => c.Int());
            CreateIndex("dbo.Songs", "Album_Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
        }
    }
}
