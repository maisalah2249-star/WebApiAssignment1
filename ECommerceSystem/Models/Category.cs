using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // One-to-Many: Category -> Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
