using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Entity
{
	public class Product
	{
		#region [CONSTANTS]
		private const int MIN_LENGTH_NAME = 5;
		#endregion

		#region [PROPERTIES]
		public int Id { get; private set; }
		public Category Category { get; private set; }
		public string Name { get; private set; }
		public int Stock { get; private set; }
		public decimal Price { get; private set; }
		public decimal SpecialPrice { get; private set; }
		public string Description { get; private set; }
		#endregion

		#region Ctor
		public Product(Category category, string name, int stock, decimal price, string description)
		{
			this.Category = category;
			this.Name = name;
			this.Stock = stock;
			this.Price = price;
			this.Description = description;

			this.Validate();
		}
		#endregion

		public void Validate()
		{
			if (String.IsNullOrWhiteSpace(this.Name) || this.Name.Length < MIN_LENGTH_NAME)
				throw new Exception(Errors.InvalidProductName);
		}
	}
}
