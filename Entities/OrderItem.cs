using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Order.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double Subtotal()
        {
            return (Quantity * Price);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Product.Name);
            sb.Append(", $");
            sb.Append(Price.ToString());
            sb.Append(", Quantity: ");
            sb.Append(Quantity.ToString());
            sb.Append(", Subtotal: $");
            sb.Append(Subtotal().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
