using Shopit.Domain.Entity;
using Shopit.Domain.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Shopit.Presentation.Controllers
{
    public class ProductController : ApiController
    {
		private IProductService service;

		public ProductController(IProductService service) : base()
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
