using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Terminal
    {
        [Key]
        public int TerminalID { get; set; }

        //Связь с таблицей Products : "многие-ко-многим"
        public List<Product> Products { get; set; }

        //Связь с таблицей DailyStatistics: "один-ко-многим"
        public List<DailyStatistic> DailyStatistics { get; set; }

        public string Address { get; set; }
        public string QuantitiesJSON { get; set; }
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
