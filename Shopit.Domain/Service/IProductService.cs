using Shopit.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Services
{
	public interface IProductService
	{
		IEnumerable<Product> Get();
		Product Get(int id);
	}
}
