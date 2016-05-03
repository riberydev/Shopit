using Shopit.Domain.Contracts.Repository;
using Shopit.Domain.Entity;
using Shopit.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Shopit.Infrastructure.Repository
{
	public class ProductRepositoryAdoNet : IProductRepository
	{
		private AdoNetUnitOfWork database;

		public ProductRepositoryAdoNet(IUnitOfWork database)
		{
			this.database = database as AdoNetUnitOfWork;
		}

		public Product Get(int id)
		{
			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = @"
					SELECT
						id, name, category_id, stock, description, price, special_price
					FROM
						products
					WHERE
						id = @productId
						AND active = 1";

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
							return new Product(
								new Category(reader.GetString(reader.GetOrdinal("category_name"))),
								reader.GetString(reader.GetOrdinal("name")),
								reader.GetInt32(reader.GetOrdinal("stock")),
								reader.GetDecimal(reader.GetOrdinal("price")),
								reader.GetString(reader.GetOrdinal("description"))
							);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return null;
		}

		public IEnumerable<Product> Get()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProductsOutOfStock()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProductsInStock()
		{
			throw new NotImplementedException();
		}

		public void Create(Product product)
		{
			throw new NotImplementedException();
		}

		public void Update(Product product)
		{
			throw new NotImplementedException();
		}

		public void Delete(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
