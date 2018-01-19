using System;

namespace ShoppingCart
{
	class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }        
        public int Quantity { get; set; }

		public event Action OnDataChanged;

        public CartItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public virtual decimal Cost
        {
            get
            {
                return Quantity * Price;
            }
        }
    }

    class OneOfNFreeCartItem : CartItem
    {
        int _n;

        public OneOfNFreeCartItem(string name, decimal price, int quantity, int n) : base(name, price, quantity)
        {
            _n = n;
        }

        public override decimal Cost
        {
            get
            {
                return (Quantity - Quantity / _n) * Price;
            }
        }
    }
}
