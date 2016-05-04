using Shopit.Domain.Contracts.Repository;
using Shopit.Domain.Entity;
using Shopit.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shopit.Infrastructure.Repository.AdoNet
{
	public class ProductRepository : IProductRepository
	{
		private AdoNetUnitOfWork database;
		private readonly string sqlGetProduct = @"
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

		public ProductRepository(IUnitOfWork database)
		{
			this.database = database as AdoNetUnitOfWork;
		}

		public Product Get(int id)
		{
			Product _product = null;

			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = String.Concat(this.sqlGetProduct, " AND p.id = @ProductId ");
					command.AddParameter("ProductId", id);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							_product = new Product(
								reader.GetInt32(reader.GetOrdinal("id")),
								new Category(reader.GetString(reader.GetOrdinal("category_name"))),
								reader.GetString(reader.GetOrdinal("name")),
								reader.GetInt32(reader.GetOrdinal("stock")),
								reader.GetDecimal(reader.GetOrdinal("price")),
								reader.GetString(reader.GetOrdinal("description"))
							);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return _product;
		}

		public IEnumerable<Product> Get()
		{
			List<Product> _products = new List<Product>();

			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = this.sqlGetProduct;

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
			List<Product> _products = new List<Product>();

			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = String.Concat(this.sqlGetProduct, " AND p.stock = 0 ");

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

		public IEnumerable<Product> GetProductsInStock()
		{
			List<Product> _products = new List<Product>();

			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = String.Concat(this.sqlGetProduct, " AND p.stock > 0 ");

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

		public void Create(Product product)
		{
			try
			{
				using (var command = this.database.CreateCommand())
				{
					command.CommandText = @"
					INSERT INTO products
						(id, name, category_id, stock, description, price, special_price)
					VALUES
						(@id, @name, @category_id, @stock, @description, @price, @special_price)";

					command.AddParameter("id", product.Id);
					command.AddParameter("name", product.Name);
					command.AddParameter("category_id", product.Category.Id);
					command.AddParameter("stock", product.Stock);
					command.AddParameter("description", product.Description);
					command.AddParameter("price", product.Price);
					command.AddParameter("special_price", product.SpecialPrice);

					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
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
