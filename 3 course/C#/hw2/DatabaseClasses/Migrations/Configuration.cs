namespace DatabaseClasses.Migrations
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseClasses.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseClasses.Context context)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            string directory = Directory.GetCurrentDirectory();
            List<string> allLinesTerminals = File.ReadAllLines(directory + "\\AllTerminals.txt").ToList();
            Dictionary<Terminal, List<int>> dictTerminals = new Dictionary<Terminal, List<int>>();
            foreach (string line in allLinesTerminals)
            {
                List<string> objects = line.Split(';').ToList();
                Terminal terminal = new Terminal()
                {
                    Id = int.Parse(objects[0]),
                    AvailableProducts = objects[1],
                    DailySellingStatistics = objects[2],
                    Location = objects[3],
                    Rub1 = int.Parse(objects[4]),
                    Rub2 = int.Parse(objects[5]),
                    Rub5 = int.Parse(objects[6]),
                    Rub10 = int.Parse(objects[7]),
                    Rub50 = int.Parse(objects[8]),
                    Rub100 = int.Parse(objects[9]),
                    Rub500 = int.Parse(objects[10]),
                    Rub1000 = int.Parse(objects[11]),
                    LinkedProducts = new List<Product>()
                };
                dictTerminals.Add(terminal,objects[12].Split('-').ToList().ConvertAll(new Converter<string, int>(Convert)));
            }

            List<string> allLinesProducts = File.ReadAllLines(directory + "\\AllProducts.txt").ToList(); //~ - наше приложение!!!
            Dictionary<Product, List<int>> dictProducts = new Dictionary<Product, List<int>>();
            foreach (string line in allLinesProducts)
            {
                List<string> items = line.Split(',').ToList();
                Product product = new Product()
                {
                    Id = int.Parse(items[0]),
                    Code = int.Parse(items[1]),
                    Name = items[2],
                    PurchasePrice = double.Parse(items[3]),
                    SellingPrice = double.Parse(items[4]),
                    LinkedTerminals = new List<Terminal>()
                };
                dictProducts.Add(product, items[5].Split('-').ToList().ConvertAll(new Converter<string, int>(Convert)));
            }

            foreach (KeyValuePair<Terminal,List<int>> machine in dictTerminals)
                foreach (KeyValuePair<Product,List<int>> product in dictProducts)
                    for (int i = 0; i < machine.Value.Count; i++)
                        if (product.Value.Contains(machine.Key.Id) && machine.Value.Contains(product.Key.Id))
                        {
                            product.Key.LinkedTerminals.Add(machine.Key);
                            machine.Key.LinkedProducts.Add(product.Key);
                        }

            foreach (KeyValuePair<Terminal,List<int>> machine in dictTerminals)
                if (!context.Terminals.ToList().Exists(term => term.Id == machine.Key.Id))
                {
                    context.Terminals.AddOrUpdate(a => a.Id, machine.Key);
                    context.SaveChanges();
                }

            foreach (KeyValuePair<Product, List<int>> product in dictProducts)
                if (!context.Products.ToList().Exists(prod => prod.Id == product.Key.Id))
                {
                    context.Products.AddOrUpdate(a => a.Id, product.Key);
                    context.SaveChanges();
                }

        }

        private static int Convert(string str)
        {
            return int.Parse(str);
        }
    }
}
