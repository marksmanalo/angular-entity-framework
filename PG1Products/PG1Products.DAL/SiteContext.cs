using System.Data.Entity;
using PG1Products.DAL.Models;

namespace PG1Products.DAL
{
    public class SiteContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
