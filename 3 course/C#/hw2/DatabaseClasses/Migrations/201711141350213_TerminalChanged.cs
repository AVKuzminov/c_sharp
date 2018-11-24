namespace DatabaseClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerminalChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terminals", "DailySellingStatistics", c => c.String());
            AddColumn("dbo.Terminals", "AvailableProducts", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Terminals", "AvailableProducts");
            DropColumn("dbo.Terminals", "DailySellingStatistics");
        }
    }
}
