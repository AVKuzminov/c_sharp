namespace ClassesLibrary.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassesLibrary.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private class TempTerminal
        {
            public Terminal Terminal { get; set; }
            public List<int> ProductIds { get; set; }
            public List<int> DailyStatisticIds { get; set; }
        }

        private class TempProduct
        {
            public Product Product { get; set; }
            public List<int> TerminalIds { get; set; }
        }
        private class TempDailyStatistic
        {
            public DailyStatistic DailyStatstic { get; set; }
            public int TerminalId { get; set; }
        }

        protected override void Seed(ClassesLibrary.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Configuration.AutoDetectChangesEnabled = false;

            List<TempProduct> tempProducts = new List<TempProduct>();
            List<TempTerminal> tempTerminals = new List<TempTerminal>();
            List<TempDailyStatistic> tempDailyStatistics = new List<TempDailyStatistic>();
            var dir = Directory.GetCurrentDirectory();
            string[] cells = File.ReadAllLines(dir + "\\Terminals.txt");
            foreach (var unsplittedRow in cells)
            {
                string[] row = unsplittedRow.Split('*');
                Terminal tempTerminal = new Terminal()
                {
                    TerminalID = int.Parse(row[0]), Address = row[1],
                    QuantitiesJSON = row[2], Rub1 = int.Parse(row[3]),
                    Rub2 = int.Parse(row[4]), Rub5 = int.Parse(row[5]),
                    Rub10 = int.Parse(row[6]), Rub50 = int.Parse(row[7]),
                    Rub100 = int.Parse(row[8]), Rub500 = int.Parse(row[9]),
                    Rub1000 = int.Parse(row[10]), DailyStatistics = new List<DailyStatistic>(), Products = new List<Product>()
                };
                string[] stats = row[11].Split('.');
                List<int> linkedDailyStats = new List<int>();
                foreach (string str in stats)
                    linkedDailyStats.Add(int.Parse(str));
                string[] prods = row[12].Split('.');
                List<int> linkedProducts = new List<int>();
                foreach (string str in prods)
                    linkedProducts.Add(int.Parse(str));
                tempTerminals.Add(new TempTerminal {Terminal = tempTerminal, ProductIds = linkedProducts, DailyStatisticIds = linkedDailyStats });
            }

            cells = File.ReadAllLines(dir + "\\Products.txt");
            foreach (var unsplittedRow in cells)
            {
                string[] row = unsplittedRow.Split(',');
                Product tempProduct = new Product()
                {
                    ProductId = int.Parse(row[0]), Name = row[1],
                    PurchasePrice = double.Parse(row[2]), SellingPrice = double.Parse(row[3]),
                    Terminals = new List<Terminal>() 
                };
                string[] terms = row[4].Split('.');
                List<int> linkedTerminals = new List<int>();
                foreach (string str in terms)
                    linkedTerminals.Add(int.Parse(str));
                tempProducts.Add(new TempProduct { Product = tempProduct, TerminalIds = linkedTerminals });
            }

            cells = File.ReadAllLines(dir + "\\DailyStatistics.txt");
            foreach (var unsplittedRow in cells)
            {
                string[] row = unsplittedRow.Split(';');
                DailyStatistic tempDailyStats = new DailyStatistic()
                {
                    DailyStatisticsID = int.Parse(row[0]), Date = new DateTime(int.Parse(row[2]),int.Parse(row[1]),1),
                    SoldProductsJSON = row[3], LinkedTerminal = new Terminal() 
                };
                int linkedTerminalId = int.Parse(row[4]);
                tempDailyStatistics.Add(new TempDailyStatistic {DailyStatstic = tempDailyStats, TerminalId = linkedTerminalId});
            }

            for (int i = 0; i < tempProducts.Count; i++)
            {
                for (int j = 0; j < tempProducts[i].TerminalIds.Count; j++)
                {
                    for (int k = 0; k < tempTerminals.Count; k++)
                    {
                        if (tempTerminals[k].ProductIds.Contains(tempProducts[i].TerminalIds[j]))
                        {
                            tempProducts[i].Product.Terminals.Add(tempTerminals[k].Terminal);
                            tempTerminals[k].Terminal.Products.Add(tempProducts[i].Product);
                        }
                    }
                }
            }

            for (int i = 0; i < tempDailyStatistics.Count; i++)
            {
                for (int j = 0; j < tempTerminals.Count; j++)
                {
                    if (tempDailyStatistics[i].TerminalId == tempTerminals[j].Terminal.TerminalID)
                    {
                        tempDailyStatistics[i].DailyStatstic.LinkedTerminal = tempTerminals[j].Terminal;
                        tempTerminals[j].Terminal.DailyStatistics.Add(tempDailyStatistics[i].DailyStatstic);
                        break;
                    }
                }
            }

            foreach (var item in tempTerminals)
            {
                if (!context.Terminals.ToList().Exists(a => a.TerminalID == item.Terminal.TerminalID))
                {
                    context.Terminals.AddOrUpdate(a => a.TerminalID, item.Terminal);
                    context.SaveChanges();
                }
            }

            foreach (var item in tempProducts)
                if (!context.Products.ToList().Exists(a => a.ProductId == item.Product.ProductId))
                {
                    context.Products.AddOrUpdate(a => a.ProductId, item.Product);
                    context.SaveChanges();
                }

            foreach (var item in tempDailyStatistics)
                if (!context.DailyStatistics.ToList().Exists(a => a.DailyStatisticsID == item.DailyStatstic.DailyStatisticsID))
                {
                    context.DailyStatistics.AddOrUpdate(a => a.DailyStatisticsID, item.DailyStatstic);
                    context.SaveChanges();
                }
        }
    }
}
