namespace DatabaseClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SellingPrice = c.Double(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Rub1 = c.Int(nullable: false),
                        Rub2 = c.Int(nullable: false),
                        Rub5 = c.Int(nullable: false),
                        Rub10 = c.Int(nullable: false),
                        Rub50 = c.Int(nullable: false),
                        Rub100 = c.Int(nullable: false),
                        Rub500 = c.Int(nullable: false),
                        Rub1000 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TerminalProducts",
                c => new
                    {
                        Terminal_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Terminal_Id, t.Product_Id })
                .ForeignKey("dbo.Terminals", t => t.Terminal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Terminal_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TerminalProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.TerminalProducts", "Terminal_Id", "dbo.Terminals");
            DropIndex("dbo.TerminalProducts", new[] { "Product_Id" });
            DropIndex("dbo.TerminalProducts", new[] { "Terminal_Id" });
            DropTable("dbo.TerminalProducts");
            DropTable("dbo.Terminals");
            DropTable("dbo.Products");
        }
    }
}
