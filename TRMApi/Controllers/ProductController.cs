using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRMDataManager.Library.Models;
using TRMDataManager.Library.DataAccess;
using Microsoft.Extensions.Configuration;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        private readonly IProductData _data;

        public ProductController(IConfiguration config, IProductData data)
        {
            _data = data;
        }

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _data.GetProducts();
        }
    }
}
