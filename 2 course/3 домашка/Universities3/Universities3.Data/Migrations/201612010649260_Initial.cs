namespace Universities3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorldRank = c.Int(nullable: false),
                        NationalRank = c.Int(nullable: false),
                        QualityOfEducation = c.Int(nullable: false),
                        AlumniEducation = c.Int(nullable: false),
                        QualityOfFacility = c.Int(nullable: false),
                        Publications = c.Int(nullable: false),
                        Influence = c.Int(nullable: false),
                        Citations = c.Int(nullable: false),
                        BroadImpact = c.Int(nullable: false),
                        Patents = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        Year = c.Int(nullable: false),
                        University_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.University_Id)
                .Index(t => t.University_Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institution = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "University_Id", "dbo.Universities");
            DropIndex("dbo.Ratings", new[] { "University_Id" });
            DropTable("dbo.Universities");
            DropTable("dbo.Ratings");
        }
    }
}
