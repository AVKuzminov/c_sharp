namespace CROC.Education.CSharpBotService.Storage
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class DB : DbContext
    {
        // Your context has been configured to use a 'DB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CROC.Education.CSharpBotService.Storage.DB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DB' 
        // connection string in the application configuration file.
        public DB()
            : base("name=DB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// ������ �����������
        /// </summary>
        public virtual DbSet<BotLog> BotLogs { get; set; }

        /// <summary>
        /// ������ ���������
        /// </summary>
        public virtual DbSet<Student> Students { get; set; }

        /// <summary>
        /// ������� �� � ����������� �������������� ��������
        /// </summary>
        /// <returns></returns>
        public static DB Open()
        {
            // ������������� � ���������� �������� ��
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, Migrations.Configuration>());

            var db = new DB();
            bool doMiration = false;
            try
            {
                doMiration = !db.Database.CompatibleWithModel(true);
            }
            catch (Exception)
            {
                doMiration = true;
            }
            if (doMiration)
            {
                var cfg = new Migrations.Configuration();
                var mgr = new DbMigrator(cfg);
                mgr.Update();
            }
            return db;
        }
    }
}