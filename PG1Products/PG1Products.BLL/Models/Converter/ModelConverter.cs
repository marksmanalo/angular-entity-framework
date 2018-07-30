using System.Linq;
using PG1Products.DAL.Models;

namespace PG1Products.BLL.Models.Converter
{
    public static class ModelConverter
    {
        public static ProductModel Create(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }

        public static Product Create(ProductModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description 
            };
        }

        public static CustomerModel Create(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public static Customer Create(CustomerModel customer)
        {
            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Name,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public static OrderModel Create(Order order)
        {
            return new OrderModel
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                NumberOfProducts = order.Products.Count,
                Products = order.Products.Select(Create).ToList()
            };
        }
    }
}
