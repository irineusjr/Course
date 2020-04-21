using System;
using System.Collections.Generic;
using System.Text;
using Order.Entities.Enums;
using System.Globalization;

namespace Order.Entities
{
    class OrderHeader
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public OrderHeader()
        {
        }

        public OrderHeader(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            Status = orderStatus;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }
        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem obj in Items)
            {
                sum += obj.Subtotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append("(");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items");
            
            foreach(OrderItem obj in Items)
            {
                sb.AppendLine(obj.ToString());
            }
            sb.Append("Total Price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
