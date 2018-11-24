using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class DailyStatistic
    {
        [Key]
        public int DailyStatisticsID { get; set; }

        //Связь с таблицей Terminal : "один-ко-многим"
        [Required]
        public Terminal LinkedTerminal { get; set; }

        public DateTime Date { get; set; }
        public string SoldProductsJSON { get; set; }
    }
}
