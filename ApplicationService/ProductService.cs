using Shopit.Domain.Contracts.Repository;
using Shopit.Domain.Entity;
using Shopit.Domain.Services;
using System;
using System.Collections.Generic;

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
				return this.repository.Get(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<Product> Get()
		{
			try
			{
				return this.repository.Get();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Create(Product product)
		{
			try
			{
				this.repository.Create(product);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
