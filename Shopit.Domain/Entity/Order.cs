using Shopit.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopit.Domain.Entity
{
	public class Order
	{
		#region [PROPERTIES]
		public int Id { get; private set; }
		public EOrderStatus Status { get; private set; }
		public Customer Customer { get; private set; }
		public ICollection<OrderItem> OrderItems { get; set; }
		public Address BillingAddress { get; private set; }
		public Address ShippingAddress { get; private set; }
		public Shipping Shipping { get; set; }
		public decimal Total { get; private set; }
		public decimal TotalShipping { get; private set; }
		public decimal Discount { get; private set; }
		public DateTime PurchaseDate { get; private set; }
		public DateTime? ConclusionDate { get; private set; }
		#endregion

		public Order(EOrderStatus status, Customer customer, Address billingAddress, Address shippingAddress, decimal total, decimal totalShipping, decimal discount)
		{
			this.Status = status;
			this.Customer = customer;
			this.BillingAddress = billingAddress;
			this.ShippingAddress = shippingAddress;
			this.Total = total;
			this.TotalShipping = totalShipping;
			this.Discount = discount;
			this.PurchaseDate = DateTime.Now;

			this.Validate();
		}

		public void Validate()
		{
			//TODO: Basic rules for order validation
		}

		public void AddItem(OrderItem item)
		{
			if (item.Validate())
				this.OrderItems.Add(item);
		}

		public void MarkAsPaid()
		{
			this.Status = EOrderStatus.Paid;
		}

		public void Cancel()
		{
			this.Status = EOrderStatus.Canceled;
		}
	}
}
