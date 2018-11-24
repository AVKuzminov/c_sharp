namespace ClassesLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyStatistics",
                c => new
                    {
                        DailyStatisticsID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SoldProductsJSON = c.String(),
                        LinkedTerminal_TerminalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DailyStatisticsID)
                .ForeignKey("dbo.Terminals", t => t.LinkedTerminal_TerminalID, cascadeDelete: true)
                .Index(t => t.LinkedTerminal_TerminalID);
            
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        TerminalID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        QuantitiesJSON = c.String(),
                        Rub1 = c.Int(nullable: false),
                        Rub2 = c.Int(nullable: false),
                        Rub5 = c.Int(nullable: false),
                        Rub10 = c.Int(nullable: false),
                        Rub50 = c.Int(nullable: false),
                        Rub100 = c.Int(nullable: false),
                        Rub500 = c.Int(nullable: false),
                        Rub1000 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerminalID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SellingPrice = c.Double(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTerminals",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Terminal_TerminalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Terminal_TerminalID })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Terminals", t => t.Terminal_TerminalID, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Terminal_TerminalID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyStatistics", "LinkedTerminal_TerminalID", "dbo.Terminals");
            DropForeignKey("dbo.ProductTerminals", "Terminal_TerminalID", "dbo.Terminals");
            DropForeignKey("dbo.ProductTerminals", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductTerminals", new[] { "Terminal_TerminalID" });
            DropIndex("dbo.ProductTerminals", new[] { "Product_ProductId" });
            DropIndex("dbo.DailyStatistics", new[] { "LinkedTerminal_TerminalID" });
            DropTable("dbo.ProductTerminals");
            DropTable("dbo.Products");
            DropTable("dbo.Terminals");
            DropTable("dbo.DailyStatistics");
        }
    }
}
