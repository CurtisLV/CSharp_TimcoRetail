using Microsoft.AspNetCore.Mvc;

namespace TRMApi.Controllers
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
