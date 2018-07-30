using System.Collections.Generic;

namespace PG1Products.BLL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfProducts { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<int> ProductIds { get; set; } 
    }
}
