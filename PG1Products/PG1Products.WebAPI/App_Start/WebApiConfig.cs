using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using PG1Products.BLL.Repositories;
using PG1Products.WebAPI.DependencyResolver;

namespace PG1Products.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.EnableCors();

            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "PGApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}
