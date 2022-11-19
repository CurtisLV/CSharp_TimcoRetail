using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : Controller
    {
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
