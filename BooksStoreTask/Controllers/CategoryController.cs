using BooksStoreTask.Data;
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

    public class CategoryController : Controller
    {
        ICategoryServices cServices;
        public CategoryController(ICategoryServices _cServices)
        {
            cServices = _cServices;
        }
        public IActionResult Index()
        {
            vmCategory vm = new vmCategory();
            vm.LiC = cServices.LoudAll();
            return View("NewCategory",vm);
        }

        public IActionResult Save(vmCategory v)
        {
            vmCategory vm = new vmCategory();
            vm.LiC = cServices.LoudAll();

            cServices.Insert(v.category);
            return View("NewCategory", vm);
        }

        public IActionResult Delete(int Id)
        {
            vmCategory vm = new vmCategory();

            cServices.Delete(Id);

            vm.LiC = cServices.LoudAll();
            return View("NewCategory", vm);
        }

        public IActionResult UpDate(vmCategory v)
        {
            vmCategory vm = new vmCategory();
            vm.LiC = cServices.LoudAll();

            cServices.UpDate(v.category);
            return View("NewBook",vm);
        }
        public IActionResult GetById(int id)
        {
            Category b = new Category();
            b = cServices.LoudEmpById(id);
            return Json(b);

        }
    }
}
