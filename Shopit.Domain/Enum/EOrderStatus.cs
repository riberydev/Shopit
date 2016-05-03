using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Enum
{
	public enum EOrderStatus
	{
		Created = 1,
		Paid = 2,
		Delivered = 3,
		Canceled = 4,
		Pending = 5,
		PaymentReproved = 6
	}
}
