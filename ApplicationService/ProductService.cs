using Shopit.Domain.Contracts.Repository;
using Shopit.Domain.Entity;
using Shopit.Domain.Services;
using Shopit.Infrastructure.Persistence;
using Shopit.Infrastructure.Repository;
using System;

namespace ApplicationService
{
	public class ProductService : IProductService
	{
		private IProductRepository repository;

		public ProductService(IProductRepository repository)
		{
			this.repository = repository;
		}

		public Product Get(int id)
		{
			try
			{
				using (var database = new AdoNetUnitOfWork("shopit_catalog", true))
				{
					var _repository = new ProductRepositoryAdoNet(database);
					return _repository.Get(id);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public System.Collections.Generic.IEnumerable<Product> Get()
		{
			throw new NotImplementedException();
		}
	}
}
