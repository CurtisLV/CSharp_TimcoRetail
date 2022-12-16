﻿using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TRMApi.Models;
using TRMDataManager.Library.DataAccess;
using TRMApi.Data;
using System.Security.Claims;
using TRMDataManager.Library.Internal.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserData _data;
        private readonly ILogger<UserController> _logger;

        public UserController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IUserData data,
            ILogger<UserController> logger
        )
        {
            _context = context;
            _userManager = userManager;
            _data = data;
            _logger = logger;
        }

        [HttpGet]
        public UserModel GetById()
        {
            // we get user ID from logged in user, and not any userID
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _data.GetUserById(userId).First();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();

            var users = _context.Users.ToList();

            var userRoles =
                from ur in _context.UserRoles
                join r in _context.Roles on ur.RoleId equals r.Id
                select new { ur.UserId, ur.RoleId, r.Name };

            foreach (var user in users)
            {
                ApplicationUserModel u = new ApplicationUserModel()
                {
                    Id = user.Id,
                    Email = user.Email
                };

                u.Roles = userRoles
                    .Where(x => x.UserId == u.Id)
                    .ToDictionary(key => key.RoleId, val => val.Name);

                output.Add(u);
            }

            return output;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllRoles")]
        public Dictionary<string, string> GetAllRoles()
        {
            var roles = _context.Roles.ToDictionary(x => x.Id, x => x.Name);
            return roles;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/AddRole")]
        public async Task AddRole(UserRolePairModel pairing)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = _data.GetUserById(loggedInUserId).First();

            var user = await _userManager.FindByIdAsync(pairing.UserId);

            _logger.LogInformation(
                "Admin {Admin} added user {User} to role {Role}.",
                loggedInUserId,
                user.Id,
                pairing.RoleName
            );

            await _userManager.AddToRoleAsync(user, pairing.RoleName);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/RemoveRole")]
        public async Task RemoveRole(UserRolePairModel pairing)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(pairing.UserId);

            _logger.LogInformation(
                "Admin {Admin} removed user {User} from role {Role}.",
                loggedInUserId,
                user.Id,
                pairing.RoleName
            );

            await _userManager.RemoveFromRoleAsync(user, pairing.RoleName);
        }
    }
}
