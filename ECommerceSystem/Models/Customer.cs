using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        // One-to-Many: Customer -> Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
