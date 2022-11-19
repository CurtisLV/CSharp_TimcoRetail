using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public string Get(int id)
        {
            return "value";
        }

        // GET: User/Details/5
        public List<UserModel> GetById(string id)
        {
            UserData data = new UserData();

            return data.GetUserById(id);
        }
    }
}
