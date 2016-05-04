using ApplicationService;
using Microsoft.Practices.Unity;
using Shopit.Domain.Services;
using Shopit.Infrastructure.Repository.AdoNet;

namespace Shopit.CrossCutting
{
	public static class DependencyResolver
	{
		public static void Register(UnityContainer container)
		{
			container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
		}
	}
}
