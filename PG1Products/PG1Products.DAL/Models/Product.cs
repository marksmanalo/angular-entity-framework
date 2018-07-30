using System.Collections.Generic;

namespace PG1Products.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; } 
    }
}
