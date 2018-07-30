using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using PG1Products.BLL.Models;
using PG1Products.BLL.Repositories;

namespace PG1Products.WebAPI.Controllers
{
    [EnableCors("http://localhost:58336", "*", "*")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET api/customers
        public CustomerModel[] Get()
        {
            return _repository.GetAll().ToArray();
        }

        public CustomerModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/customers
        public void Post([FromBody] CustomerModel model)
        {
            _repository.Update(model);
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
