using ApplicationService;
using Shopit.Domain.Entity;
using Shopit.Domain.Services;
using Shopit.Infrastructure.Persistence;
using Shopit.Infrastructure.Repository.AdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shopit.API.Controllers
{
	public class ProductController : ApiController
    {
		private IProductService service;

		public ProductController() : base()
		{
			var uow = new AdoNetUnitOfWork("Shopit.MySQl", true);
			this.service = new ProductService(new ProductRepository(uow));
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
