using Shopit.Domain.Entity;
using Shopit.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shopit.Presentation.Controllers
{
    public class ProductController : ApiController
    {
		private readonly IProductService service;

		public ProductController(IProductService service)
		{
			this.service = service;
		}

		[HttpGet]
		[Route("products")]
		public IEnumerable<Product> Get()
		{
			try
			{
				return this.service.Get();
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		[Route("product/{id:int}")]
		public Product Get(int id)
		{
			try
			{
				return  this.service.Get(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
    }
}
