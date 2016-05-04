using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopit.Domain.Entity
{
	public class OrderItem
	{
		#region [PROPERTIES]
		public int Id { get; private set; }
		public int OrderId { get; set; }
		public int ProductId { get; private set; }
		public int Quantity { get; private set; }
		public decimal Price { get; private set; }

		#endregion
		public bool Validate()
		{
			return true;
		}

		public void AddProduct(Product product, int quantity, decimal price)
		{
			this.ProductId = product.Id;
			this.Quantity = quantity;
			this.Price = price;
		}
	}
}
