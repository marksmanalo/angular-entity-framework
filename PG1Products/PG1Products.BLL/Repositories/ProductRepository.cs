using System;
using System.Collections.Generic;
using System.Linq;
using PG1Products.BLL.Models;
using PG1Products.BLL.Models.Converter;
using PG1Products.DAL;
using PG1Products.DAL.Models;

namespace PG1Products.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SiteContext _context;

        public ProductRepository()
        {
            _context = new SiteContext();
        }

        public ProductModel GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product == null ? null : ModelConverter.Create(product);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _context.Products.Select(ModelConverter.Create).ToList();
        }

        public void Add(ProductModel model)
        {
            var product = ModelConverter.Create(model);

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return;
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(ProductModel model)
        {
            if (model.Id == 0)
            {
                Add(model);
                return;
            }
            var updatedProduct = ModelConverter.Create(model);
            var outdatedProduct = _context.Products.FirstOrDefault(x => x.Id == updatedProduct.Id);
            if (outdatedProduct == null) return;
            outdatedProduct.Description = updatedProduct.Description;
            outdatedProduct.Name = updatedProduct.Name;
            outdatedProduct.Price = updatedProduct.Price;
            _context.SaveChanges();
        }

        public void Save(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
