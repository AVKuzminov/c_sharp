using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class TempQuery1Result
    {
        public int Id { get; set; }
        public Dictionary<int, int> Quantities { get; set; }
    }

    public class TempForOrderQuery1
    {
        public Terminal Terminal { get; set; }
        public int Quantity { get; set; }
    }

    public class DeserializedQuantities
    {
        public int? ProdictId { get; set; }
        public int? Quantity { get; set; }
    }

    public class TempQuery2
    {
        public Terminal Terminal { get; set; }
        public string DataAboutSoldProducts { get; set; }
        public double Profit { get; set; }
    }



    public class Repository
    {
        public List<Terminal> Terminals { get; set; }
        public List<DailyStatistic> DailyStatistics { get; set; }
        public List<Product> Products { get; set; }


        public List<Terminal> Query1()
        {
            using (Context context = new Context())
            {
                List<TempQuery1Result> deserialierList = new List<TempQuery1Result>();
                foreach (var item in context.Terminals)
                {
                    var quantities = JsonConvert.DeserializeObject<Dictionary<int,int>>(item.QuantitiesJSON);
                    deserialierList.Add(new TempQuery1Result { Id = item.TerminalID, Quantities = quantities });
                }
                var zeros = from t in deserialierList
                            where t.Quantities.Any(value => value.Value == 0)
                            select t.Id;
                var result = (context.Terminals.Where(terminal => zeros.Any(zeroId => zeroId == terminal.TerminalID))).ToList();
                List<TempForOrderQuery1> tempList = new List<TempForOrderQuery1>();
                foreach (var res in result)
                {
                    var unserialzedQuantitites = (from ds in context.DailyStatistics
                                                  where res.TerminalID == ds.LinkedTerminal.TerminalID
                                                  select ds.SoldProductsJSON).ToList();
                    int soldQuantity = 0;
                    foreach (var quan in unserialzedQuantitites)
                    {
                        Dictionary<int, int> itemQuantitites = JsonConvert.DeserializeObject<Dictionary<int,int>>(quan);
                        foreach (int quantity in itemQuantitites.Values.ToList())
                            soldQuantity += quantity;
                    }
                    tempList.Add(new TempForOrderQuery1() { Terminal = res, Quantity = soldQuantity });
                }
                List<Terminal> finalresult = (from ress in tempList
                                              orderby ress.Quantity ascending
                                              select ress.Terminal).ToList();
                return finalresult;
            }
        }

        public List<Terminal> Query2(DateTime date)
        {
            //List of terminals sorted in descending order of the total profit for a
            //given month and year(for a single item its profit is the difference
            //between the selling price and the purchase price multiplied by the
            //quantity sold, for simplicity taxes won't be considered).
            using (Context context = new Context())
            {
                var year = date.Year;
                var month = date.Month;
                var dateTimeTerminals = (from ds in context.DailyStatistics
                                         where ds.Date.Month == month && ds.Date.Year == year
                                         select new TempQuery2 { Terminal = ds.LinkedTerminal, DataAboutSoldProducts = ds.SoldProductsJSON }).ToList();
                foreach (var item in dateTimeTerminals)
                {
                    var TerminalProducts = (from product in context.Products
                                            where product.Terminals.Any(a => a.TerminalID == item.Terminal.TerminalID)
                                            select product).ToList(); //list of products for item terminal
                    Dictionary<int, int> itemQuantitites =
                        JsonConvert.DeserializeObject<Dictionary<int, int>>(item.DataAboutSoldProducts);
                    foreach (var termprod in TerminalProducts)
                    {
                        termprod.ProductId += 999;
                        var profitForProduct = (from quanprod in itemQuantitites
                                                where quanprod.Key == termprod.ProductId
                                                select quanprod.Value * (termprod.SellingPrice - termprod.PurchasePrice)).ToList().FirstOrDefault();
                        item.Profit += profitForProduct;
                    }

                }
                List<Terminal> returnQuery2 = (from item in dateTimeTerminals
                                               orderby item.Profit descending
                                               select item.Terminal).ToList();
                return returnQuery2;
            }
        }

        public List<Product> Query3(DateTime date)
        {
            int month = date.Month;
            int year = date.Year;
            List<DeserializedQuantities> allProducts = new List<DeserializedQuantities>();
            //5 least sold products for a giving month and year
            using (Context context = new Context())
            {
                var dateTimeTerminals = (from ds in context.DailyStatistics //for giving month and year
                                         where ds.Date.Month == month && ds.Date.Year == year
                                         select new TempQuery2 { Terminal = ds.LinkedTerminal, DataAboutSoldProducts = ds.SoldProductsJSON }).ToList();
                foreach (var item in dateTimeTerminals)
                {
                    var TerminalProducts = (from product in context.Products
                                            where product.Terminals.Any(a => a.TerminalID == item.Terminal.TerminalID)
                                            select product).ToList(); //list of products for item terminal
                    Dictionary<int, int> itemQuantitites =
                        JsonConvert.DeserializeObject<Dictionary<int, int>>(item.DataAboutSoldProducts); //список всех количеств для терминала

                    foreach (var termprod in TerminalProducts)
                    {
                        var c = itemQuantitites;
                        termprod.ProductId += 999;
                        List<DeserializedQuantities> lst = new List<DeserializedQuantities>();
                        bool r = false;
                        foreach (var quanprod in itemQuantitites)
                        {
                            if (quanprod.Key == termprod.ProductId)
                            {
                                lst.Add(new DeserializedQuantities() { ProdictId = termprod.ProductId, Quantity = quanprod.Value });
                                r = true;
                            }
                        }
                        /*
                        var products = (from quanprod in itemQuantitites
                                        where quanprod.Key == termprod.ProductId
                                        orderby quanprod.Value ascending
                                        select new DeserializedQuantities { ProdictId = termprod.ProductId, Quantity = quanprod.Value }); */
                        if (!(r))
                            foreach (DeserializedQuantities product in lst)
                            {
                                if (!allProducts.Exists(a => a.ProdictId == product.ProdictId))
                                    allProducts.Add(product);
                                else
                                    allProducts.Find(a => a.ProdictId == product.ProdictId).Quantity += product.Quantity;
                            }
                        } 
                    }
                allProducts = (from ap in allProducts
                              orderby ap.Quantity ascending
                              select ap).ToList();
                List<Product> returnList = new List<Product>();
                foreach (var item in allProducts)
                    returnList.Add((from prod1 in context.Products
                                    where prod1.ProductId == item.ProdictId
                                    select prod1).ToList().FirstOrDefault());
                return returnList;
            }
        }

        public void AddProduct(Product product)
        {
            using (Context context = new Context())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

        }

        public void EditProduct(int Id, string name, double sellingprice, double purchaseprice)
        {
            using (Context context = new Context())
            {
                var product = (from t in Products
                               where t.ProductId == Id
                               select t).ToList().First();
                product.Name = name;
                product.SellingPrice = sellingprice;
                product.PurchasePrice = purchaseprice;
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RemoveProduct(int Id)
        {
            bool IsConnected = false;

            using (Context context = new Context())
            {
                Product removingProduct = context.Products.First(a => a.ProductId == Id);
                foreach (var item in context.Terminals)
                {
                    var products = (from pro in context.Products
                                    where pro.Terminals.Any(a => a.TerminalID == item.TerminalID)
                                    select pro).ToList(); //list of all products for terminal "item"
                    foreach (var pro in products)
                        if (pro.ProductId == Id) // will be deleted if not in connected
                            IsConnected = true;
                }
                if (!IsConnected)
                {
                    context.Entry(removingProduct).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
                return;
                /*
                var product = (from t in Products
                               where t.ProductId == Id
                               select t).ToList().First();
                context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();*/
            }
        }

        public void AddTerminal(string address)
        {
            using (Context context = new Context())
            {
                context.Terminals.Add(new Terminal { Address = address });
                context.SaveChanges();
            }

        }

        public void EditTerminal(int Id, string address)
        {
            using (Context context = new Context())
            {
                foreach (var tempTerminal in context.Terminals.ToList())
                {
                    if (tempTerminal.TerminalID == Id)
                    {
                        tempTerminal.Address = address;
                        context.Entry(tempTerminal).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                context.SaveChanges();
            }
        }

        public void RemoveTerminal(int Id)
        {
            using (Context context = new Context())
            {
                Terminal tempTerminal = new Terminal();
                foreach (var item in context.Terminals)
                {
                    if (item.TerminalID == Id)
                    {
                        context.Terminals.Remove(item);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        public List<Terminal> UpdateTerminalGrid()
        {
            using (Context context = new Context())
            {
                return context.Terminals.ToList();
            }
        }
    }
}
