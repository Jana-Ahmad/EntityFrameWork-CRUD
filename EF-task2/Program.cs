using EF_task2.Data;
using EF_task2.Models;

namespace EF_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            //Add data on Tables:

            Product product = new Product() { Name = "Smartphone", Price = 499.99 };
            Order order = new Order() { Address = "Jenin" };

            dbContext.Products.Add(product);
            dbContext.Orders.Add(order);
           
            // Get data from Tables:

            var products = dbContext.Products.ToList();
            var orders = dbContext.Orders.ToList();

            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }

            foreach (var item in orders)
            {
                Console.WriteLine(item.Address);
            }

            // Update data in product's table:

            var editedproduct = dbContext.Products.First(products => products.Name == "Smartphone");
            editedproduct.Name = "SmartTv";

            // Delete data from  product's table:

            var deletedproduct = dbContext.Products.First(products=>products.Id == 2);
            dbContext.Products.Remove(deletedproduct);

            // Update data in orders's table:

            var editedOrder = dbContext.Orders.First(orders => orders.Id == 1);
            editedOrder.CreateAt= DateTime.Now;

            // Delete data from orders's table:
            var deletedorder = dbContext.Orders.First(orders => orders.Id == 3);
            dbContext.Orders.Remove(deletedorder);


            dbContext.SaveChanges();


            Console.WriteLine("done");
        }
    }
}
