using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public abstract class OrderItem
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public abstract decimal TotalCost();
    }

    public class NormalItem : OrderItem
    {
        public override decimal TotalCost()
        {
            return Price * Count;
        }
    }

    public class ThreeForTwoItem : OrderItem
    {
        public override decimal TotalCost()
        {
            return Price * (Count - Count / 3);
        }
    }
}
