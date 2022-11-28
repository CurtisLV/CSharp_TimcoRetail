using System;
using System.Web.Http;
using TRMDataManager.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel sale)
        {
            Console.WriteLine();
        }
    }
}
