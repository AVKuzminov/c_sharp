namespace DatabaseClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductIdChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Code");
        }
    }
}
