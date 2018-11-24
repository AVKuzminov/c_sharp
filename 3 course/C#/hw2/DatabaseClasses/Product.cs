using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClasses
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int Code { get; set; }
        public List<Terminal> LinkedTerminals { get; set; }

        public string Name { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
    }
}
