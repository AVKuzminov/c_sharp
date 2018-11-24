using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        //Связь с таблицей Terninal : "многие-ко-многим"
        public List<Terminal> Terminals { get; set; }

        public string Name { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
    }
}
