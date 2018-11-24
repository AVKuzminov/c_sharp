using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClasses
{
    public class Terminal
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Product> LinkedProducts { get; set; }
        public string DailySellingStatistics { get; set; } //Dictionary<DateTime, string>
        public string AvailableProducts { get; set; } // Dictionary<int, int>
        public int Rub1 { get; set; }
        public int Rub2 { get; set; }
        public int Rub5 { get; set; }
        public int Rub10 { get; set; }
        public int Rub50 { get; set; }
        public int Rub100 { get; set; }
        public int Rub500 { get; set; }
        public int Rub1000 { get; set; }
    }
}
