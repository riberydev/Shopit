using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Entity
{
	public class Category
	{
		#region [PROPERTIES]
		public int Id { get; private set; }
		public string Name { get; private set; }
		#endregion

		public Category(string name)
		{
			this.Name = name;
		}
	}
}
