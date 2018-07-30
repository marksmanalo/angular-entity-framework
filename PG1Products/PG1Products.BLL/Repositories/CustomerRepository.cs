using System;
using System.Collections.Generic;
using System.Linq;
using PG1Products.BLL.Models;
using PG1Products.BLL.Models.Converter;
using PG1Products.DAL;
using PG1Products.DAL.Models;

namespace PG1Products.BLL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SiteContext _context;

        public CustomerRepository()
        {
            _context = new SiteContext();
        }
        public CustomerModel GetById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer == null ? null : ModelConverter.Create(customer);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _context.Customers.Select(ModelConverter.Create).ToList();
        }

        public void Add(CustomerModel model)
        {
            var customer = ModelConverter.Create(model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(CustomerModel model)
        {
            if (model.Id == 0)
            {
                Add(model);
                return;
            }
            var updatedCustomer = ModelConverter.Create(model);
            var outDatedCustomer = _context.Customers.FirstOrDefault(x => x.Id == updatedCustomer.Id);
            if (outDatedCustomer == null) return;
            outDatedCustomer.Name = updatedCustomer.Name;
            outDatedCustomer.Email = updatedCustomer.Email;
            outDatedCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            _context.SaveChanges();
        }

        public void Save(CustomerModel t)
        {
            throw new NotImplementedException();
        }
    }
}
