using BooksStoreTask.Data;
using BooksStoreTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public class AccountServices:IAccountServices
    { 

        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountServices(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }


        public async Task<IdentityResult> CreateUser(AccountModel accountModel)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = accountModel.Name;
            user.Email = accountModel.Email;
            user.UserName = accountModel.Email;

            var result=await userManager.CreateAsync(user,accountModel.Password);

            if(result.Succeeded)
            {
                var role=await roleManager.FindByIdAsync(accountModel.RoleId);
                result=await userManager.AddToRoleAsync(user, role.Name);

            }


            return result;
        }
        public async Task<SignInResult> CheckPassword(SignInModel signInModel)
        {
            var result=await signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }
        public async Task<IdentityResult> NewRole(RoleModel roleModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.Name;
            var result=await roleManager.CreateAsync(role);
            return result;
        }
        public List<IdentityRole> GetRole()
        {
            List<IdentityRole> LiRole = roleManager.Roles.ToList();
            return LiRole;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}
