namespace MusicExample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duratioon = c.Int(nullable: false),
                        Album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
