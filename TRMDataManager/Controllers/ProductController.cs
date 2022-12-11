using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize(Roles = "Cashier")]
    public class ProductController : ApiController
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        public List<ProductModel> Get()
        {
            ProductData data = new ProductData(_config);
            return data.GetProducts();
        }
    }
}
