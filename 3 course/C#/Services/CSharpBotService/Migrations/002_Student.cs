namespace CROC.Education.CSharpBotService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                {
                    // ������� identity: true, ��� ��� ����� ��� ������-�� �� ������������
                    UserID = c.Int(nullable: false),
                    UserName = c.String(),
                    Name = c.String(),
                    FamilyName = c.String(),
                    EMail = c.String(),
                })
                .PrimaryKey(t => t.UserID);
        }

        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
