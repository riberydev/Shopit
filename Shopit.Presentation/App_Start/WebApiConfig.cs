using ApplicationService;
using Microsoft.Practices.Unity;
using Shopit.Domain.Services;
using Shopit.Presentation.Helpers;
using System.Web.Http;

namespace Shopit.Presentation
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var container = new UnityContainer();
			container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
			config.DependencyResolver = new UnityResolver(container);

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
