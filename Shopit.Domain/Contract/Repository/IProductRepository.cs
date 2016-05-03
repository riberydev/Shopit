using Shopit.Domain.Entity;
using System.Collections.Generic;

namespace Shopit.Domain.Contracts.Repository
{
	public interface IProductRepository
	{
		Product Get(int id);
		IEnumerable<Product> Get();
		IEnumerable<Product> GetProductsOutOfStock();
		IEnumerable<Product> GetProductsInStock();
		void Create(Product product);
		void Update(Product product);
		void Delete(Product product);
	}
}
