using Shopit.Domain.Contracts.Repository;
using Shopit.Domain.Entity;
using Shopit.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Shopit.Infrastructure.Repository.AdoNet
{
	public class ProductRepository : IProductRepository
	{
		private AdoNetUnitOfWork database;

		public ProductRepository(IUnitOfWork database)
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
						p.id, p.name, p.category_id, p.stock, p.description, p.price, p.special_price,
						c.name AS category_name
					FROM
						products AS p
					INNER JOIN 
						categories AS c
						ON c.id = p.category_id
					WHERE
						p.id = @productId
						AND p.active = 1
						AND c.active = 1";

					command.AddParameter("productId", id);

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
							return new Product(
								0,
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
			List<Product> _products = new List<Product>();

			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = @"
					SELECT
						p.id, p.name, p.category_id, p.stock, p.description, p.price, p.special_price,
						c.name AS category_name
					FROM
						products AS p
					INNER JOIN 
						categories AS c
						ON c.id = p.category_id
					WHERE
						p.active = 1
						AND c.active = 1";

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							_products.Add(new Product(
								reader.GetInt32(reader.GetOrdinal("id")),
								new Category(reader.GetString(reader.GetOrdinal("category_name"))),
								reader.GetString(reader.GetOrdinal("name")),
								reader.GetInt32(reader.GetOrdinal("stock")),
								reader.GetDecimal(reader.GetOrdinal("price")),
								reader.GetString(reader.GetOrdinal("description"))
							));
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return _products;
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
