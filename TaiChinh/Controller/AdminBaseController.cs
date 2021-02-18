using AccountModule.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaiChinh
{
    public abstract class AdminBaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminBaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected async Task<ApplicationUser> GetUser()
        {
            return await _userManager.GetUserAsync(User);
        }
    }
}
