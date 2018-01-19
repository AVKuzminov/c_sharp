using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        List<OrderItem> _orderItems = new List<OrderItem>();
    
        public decimal TotalCost()
        {
            decimal total = 0;
            foreach (var item in _orderItems)
                total += item.TotalCost();
            return total;    
        }

        public void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
        }
    }
}
