using BooksStoreTask.Data;
using BooksStoreTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public interface IAccountServices
    {
        Task<IdentityResult> CreateUser(AccountModel accountModel);
        Task<SignInResult> CheckPassword(SignInModel signInModel);
        Task<IdentityResult> NewRole(RoleModel roleModel);
        List<IdentityRole> GetRole();
        Task Logout();
    }
}
