using Shopit.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Contracts.Repository
{
	public interface ICategoryRepository
	{
		Category Get(int id);
		IEnumerable<Category> Get();
		void Create(Category category);
		void Update(Category category);
		void Delete(Category category);
	}
}
