using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using PG1Products.BLL.Models;
using PG1Products.BLL.Repositories;

namespace PG1Products.WebAPI.Controllers
{
    [EnableCors("http://localhost:58336", "*", "*")]
    public class OrdersController : ApiController
    {
        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository)
        {
            _repository = repository;
        }

        public OrderModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // GET api/orders
        public OrderModel[] Get()
        {
            return _repository.GetAll().ToArray();
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        // POST api/products
        public void Post([FromBody] OrderModel model)
        {
            _repository.Add(model);
        }
    }
}
