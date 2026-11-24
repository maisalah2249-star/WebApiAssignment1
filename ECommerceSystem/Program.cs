using ECommerceSystem;
using ECommerceSystem.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

if (!db.Categories.Any())
{
    var category = new Category { Name = "Electronics" };
    var product1 = new Product { Name = "Laptop", Price = 25000, Category = category };
    var product2 = new Product { Name = "Mouse", Price = 300, Category = category };
    var customer = new Customer { Name = "Ahmed", Email = "ahmed@test.com" };

    var order = new Order { OrderDate = DateTime.Now, Customer = customer };
    order.OrderDetails.Add(new OrderDetail { Product = product1, Quantity = 1 });
    order.OrderDetails.Add(new OrderDetail { Product = product2, Quantity = 2 });

    db.Orders.Add(order);
    db.SaveChanges();
}

var orders = db.Orders
    .Include(o => o.Customer)
    .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
    .ToList();

foreach (var o in orders)
{
    Console.WriteLine($"Order #{o.Id} - {o.Customer.Name} - {o.OrderDate:d}");
    foreach (var od in o.OrderDetails)
        Console.WriteLine($"   {od.Product.Name} ({od.Product.Category.Name}) x{od.Quantity}");
}