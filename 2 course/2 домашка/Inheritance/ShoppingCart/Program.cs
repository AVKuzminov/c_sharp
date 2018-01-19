using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CartItem> cart = new List<CartItem>();

            cart.Add(new CartItem("Milk", 50, 4));
            cart.Add(new OneOfNFreeCartItem("Chocolate bar", 30, 5, 3));

            decimal totalCost = 0;
            foreach (var item in cart)
                totalCost += item.Cost;

            Console.WriteLine("Total: {0}", totalCost);
        }
    }
}
