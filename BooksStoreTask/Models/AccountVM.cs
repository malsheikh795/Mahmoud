using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Models
{
    public class AccountVM
    {
        public AccountModel accountModel { get; set; }
        public List<IdentityRole> LiRole { get; set; }
    }
}
