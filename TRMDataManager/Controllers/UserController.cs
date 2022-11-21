using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        // GET: User/Details/5
        [HttpGet]
        public UserModel GetById()
        {
            // we get user ID from logged in user, and not any userID
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }
    }
}
