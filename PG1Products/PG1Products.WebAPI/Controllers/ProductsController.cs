using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using PG1Products.BLL.Models;
using PG1Products.BLL.Repositories;

namespace PG1Products.WebAPI.Controllers
{
    // Enable CORS: first argument is the valid origins (comma separated) only
    // allow access to our angular application
    // second argument allows all headers
    // third argument allows all methods to be used (GET, PUT, ...)
    [EnableCorsAttribute("http://localhost:58336", "*", "*")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET api/products
        public ProductModel[] Get()
        {
            return _repository.GetAll().ToArray();
        }

        // GET api/products/5
        public ProductModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/products
        public void Post([FromBody] ProductModel model)
        {
            _repository.Update(model);
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
