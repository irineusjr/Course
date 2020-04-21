using System;
using Order.Entities;
using Order.Entities.Enums;
using System.Globalization;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data:");
            Console.Write("Name: ");
            string nome = Console.ReadLine();
            Console.Write("email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(nome, email, birthDate);
            Console.WriteLine();
            Console.WriteLine("Enter Order Data:");
            Console.Write("Status: ");
            OrderStatus statusPedido = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order?: ");
            int quantity = int.Parse(Console.ReadLine());
            OrderHeader order = new OrderHeader(DateTime.Now, statusPedido, client);

            for (int i=1; i <= quantity; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string nameprod = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodqty = int.Parse(Console.ReadLine());
                Product prod = new Product(nameprod, price);
                OrderItem orderItem = new OrderItem(prodqty, price, prod);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY");
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
