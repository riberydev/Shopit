using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopit.API.Models
{
	public class ProductModel
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public decimal SpecialPrice { get; set; }
		public string Description { get; set; }
	}
}