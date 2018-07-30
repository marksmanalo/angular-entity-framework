using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PG1Products.BLL.Models;
using PG1Products.BLL.Models.Converter;
using PG1Products.DAL;
using PG1Products.DAL.Models;

namespace PG1Products.BLL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SiteContext _context;

        public OrderRepository()
        {
            _context = new SiteContext();
        }

        public OrderModel GetById(int id)
        {
            var order = _context.Orders.Include(x => x.Customer)
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == id);
            return order == null ? null : ModelConverter.Create(order);
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return
                _context.Orders.Include(x => x.Customer).Include(x => x.Products).Select(ModelConverter.Create).ToList();
        }

        public void Add(OrderModel model)
        {
            if (model.ProductIds == null || model.ProductIds.Count <= 0) return;
            if (model.CustomerId == 0) return;

            var products =
                model.ProductIds.Select(productId => _context.Products.FirstOrDefault(x => x.Id == productId))
                    .Where(product => product != null)
                    .ToList();

            var order = new Order
            {
                CustomerId = model.CustomerId,
                Products = products
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return;
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Update(OrderModel t)
        {
            throw new System.NotImplementedException();
        }

        public void Save(OrderModel t)
        {
            throw new System.NotImplementedException();
        }
    }
}
