using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopit.Domain.Entity
{
	public class Address
	{
		public string Name { get; private set; }
		public string StreetAddress { get; private set; }
		public string ZipCode { get; private set; }
		public string Neighborhood { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }
		public string Country { get; private set; }

		public Address(string name, string address, string zipCode, string neighbohood, string city, string state, string country)
		{
			this.Name = name;
			this.StreetAddress = address;
			this.ZipCode = zipCode;
			this.Neighborhood = neighbohood;
			this.City = city;
			this.State = state;
			this.Country = country;
		}
	}
}
