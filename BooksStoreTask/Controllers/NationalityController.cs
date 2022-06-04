using BooksStoreTask.Models;
using BooksStoreTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Controllers
{
    [Authorize]

    public class NationalityController : Controller
    {
        INationalityServices nServices;
        vmNationality vm;
        public NationalityController(INationalityServices _nServices)
        {
            nServices = _nServices;
            vm = new vmNationality();
        }
        public IActionResult Index()
        {
            vm.LiN= nServices.LoudAll();
            return View("NewNationality",vm);
        }

        public IActionResult Save(vmNationality v)
        {
            vm.LiN = nServices.LoudAll();
            nServices.Insert(v.nationality);
            return View("NewNationality", vm);
        }
        public IActionResult Delete(int Id)
        {
            vm.LiN = nServices.LoudAll();

            nServices.Delete(Id);

            return View("NewNationality", vm);
        }
    }
}
