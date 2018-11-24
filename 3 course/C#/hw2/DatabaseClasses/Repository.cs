using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClasses
{
    public class Repository
    {
        public void AddProduct(string name, double sellingPrice, double purchasePrice)
        {
            using (Context context = new Context())
            {
                int code = 1000;
                List<int> indexes = (from prod in context.Products
                                     select prod.Code).ToList();
                while (code < 10000)
                {
                    if (!indexes.Contains(code))
                        break;
                    code++;
                }
                context.Entry(new Product
                {
                    Name = name,
                    Code = code,
                    SellingPrice = sellingPrice,
                    PurchasePrice = purchasePrice
                }).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void AddTerminal(string location)
        {
            using (Context context = new Context())
            {
                context.Entry(new Terminal { Location = location }).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void EditProduct(int Id, string name, double sellingPrice, double purchasePrice)
        {
            using (Context context = new Context())
            {
                Product product = (from prod in context.Products
                                   where prod.Id == Id
                                   select prod).First();
                product.Name = name;
                product.SellingPrice = sellingPrice;
                product.PurchasePrice = purchasePrice;
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void EditTerminal(int Id, string location)
        {
            using (Context context = new Context())
            {
                Terminal terminal = (from term in context.Terminals
                                     where term.Id == Id
                                     select term).First();
                terminal.Location = location;
                context.Entry(terminal).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int Id)
        {
            using (Context context = new Context())
            {
                Product product = (from prod in context.Products
                                   where prod.Id == Id
                                   select prod).First();
                var foundProduct = (from term in context.Terminals
                                    select from tt in term.LinkedProducts
                                           where tt.Id == Id
                                           select tt).FirstOrDefault();
                if (foundProduct.Count() == 0)
                    context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Terminal> ReturnGridTerminals()
        {
            using (Context context = new Context())
                return context.Terminals.ToList();
        }

        public List<Product> ReturnGridProducts()
        {
            using (Context context = new Context())
                return context.Products.ToList();
        }

        /// <summary>
        /// List of terminals that have at least one product missing (quantity =0), sorted in increasing order of the total available products
        /// </summary>
        /// <returns></returns>
        public List<Terminal> FirstQuery()
        {
            List<Terminal> resultList = new List<Terminal>();
            using (Context context = new Context())
            {
                Dictionary<Terminal, int> resultDict = new Dictionary<Terminal, int>();
                foreach (Terminal tempTerm in context.Terminals)
                {
                    if (tempTerm.AvailableProducts != null)
                    {
                        Dictionary<int, int> tempDict = JsonConvert.DeserializeObject<Dictionary<int, int>>(tempTerm.AvailableProducts);
                        bool result = tempDict.Values.Any(b => b == 0);
                        if (result)
                            resultDict.Add(tempTerm, tempDict.Values.Sum());
                    }
                }
                resultList = (from pair in resultDict
                              orderby pair.Value ascending
                              select pair.Key).ToList();
            }
            return resultList;
        }

        public class TempDeserialization
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public Dictionary<int, int> Dict { get; set; }
        }

        public class Temp2Deserialization
        {
            public List<TempDeserialization> Td { get; set; }
        }

        /// <summary>
        /// List of terminals sorted in descending order of the total profit for a given month and year
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Terminal> SecondQuery(int month, int year)
        {
            Dictionary<Terminal, double> resultDictionary = new Dictionary<Terminal, double>();
            List<Terminal> resultList = new List<Terminal>();
            using (Context context = new Context())
            {
                foreach (Terminal tempTerminal in context.Terminals)
                {
                    double profit = 0;
                    if (tempTerminal.DailySellingStatistics != null)
                    {
                        Temp2Deserialization dateTimeDict2 =
                            JsonConvert.DeserializeObject<Temp2Deserialization>(tempTerminal.DailySellingStatistics);
                        foreach (var dateTimeDict in dateTimeDict2.Td)
                        {
                            foreach (KeyValuePair<int, int> deserialized in dateTimeDict.Dict)
                                if (dateTimeDict.Month == month && dateTimeDict.Year == year)
                                {
                                    profit += (from prod in context.Products
                                               where prod.Id == deserialized.Key
                                               select (prod.SellingPrice - prod.PurchasePrice) * deserialized.Value).Sum();
                                }
                        }
                    }
                    resultDictionary.Add(tempTerminal, profit);
                }
                resultList = (from pair in resultDictionary
                              orderby pair.Value descending
                              select pair.Key).ToList();
            }

            return resultList;
        }

        /// <summary>
        /// 5 least sold products for a given month and year
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Product> ThirdQuery(int month, int year)
        {
            Dictionary<Product, int> resultDictionary = new Dictionary<Product, int>(); //product and it's quantity22
            using (Context context = new Context())
            {
                foreach (Product tempProduct in context.Products)
                {
                    resultDictionary.Add(tempProduct, 0);
                    foreach (var tempTerminal in context.Terminals)
                    {
                        if (tempTerminal.DailySellingStatistics != null)
                        {
                            Temp2Deserialization dateTimeDict2 =
                                JsonConvert.DeserializeObject<Temp2Deserialization>(tempTerminal.DailySellingStatistics);
                            foreach (var dateTimeDict in dateTimeDict2.Td)
                            {
                                foreach (KeyValuePair<int, int> deserialized in dateTimeDict.Dict)
                                    if (dateTimeDict.Month == month && dateTimeDict.Year == year)
                                    {
                                        if (deserialized.Key == tempProduct.Id)
                                            resultDictionary[tempProduct] += deserialized.Value;
                                    }
                            }
                        }
                    }
                }
            }
            return (from prod in resultDictionary
                    orderby prod.Value descending
                    select prod.Key).ToList();
        }
    }
}
