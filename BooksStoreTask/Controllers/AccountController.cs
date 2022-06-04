using BooksStoreTask.Models;
using BooksStoreTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Controllers
{
    public class AccountController : Controller
    {
        IAccountServices aServices;
        public AccountController(IAccountServices _aServices)
        {
            aServices = _aServices;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            AccountVM vm = new AccountVM();
            List<IdentityRole> liRole = aServices.GetRole();
            vm.LiRole = liRole;
            return View("CreateAccount",vm);
        } 

        public async Task<IActionResult> CreateAccount(AccountVM v)
        {
            AccountVM vm = new AccountVM();
            List<IdentityRole> liRole = aServices.GetRole();
            vm.LiRole = liRole;

            var result = await aServices.CreateUser(v.accountModel);
            return View("CreateAccount",vm);
        }
         
        public IActionResult Login()
        {
            return View("Login");
        }
        public async Task<IActionResult> CheckPassword(SignInModel signInModel)
        {
            var result=await aServices.CheckPassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid Username or Password";
                return View("Login");
            }
        }
        [Authorize(Roles ="Admin")]
        public IActionResult NewRole()
        {
            return View();
        }
        public async Task<IActionResult> SaveRole(RoleModel roleModel)
        {
            var result=await aServices.NewRole(roleModel);
            return View("NewRole");
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await aServices.Logout();
            return View("Login");
        }
    }
}
