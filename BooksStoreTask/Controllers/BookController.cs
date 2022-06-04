using BooksStoreTask.Data;
using BooksStoreTask.Models;
using BooksStoreTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Controllers
{
    [Authorize]

    public class BookController : Controller
    {
        IBookServices bServices;
        IAuthorServices aServices;
        ICategoryServices cServices;
        IConfiguration config;
        public BookController(IBookServices _bServices,IAuthorServices _aServices,ICategoryServices _cServices,IConfiguration _config)
        {
            bServices = _bServices;
            aServices = _aServices;
            cServices = _cServices;
            config = _config;
        }
        public IActionResult Index()
        {
            vmBook vm = new vmBook();
            vm.LiB = bServices.LoudAll();
            vm.LiA = aServices.LoudAll();
            vm.LiC = cServices.LoudAll();
            return View("NewBook",vm);
        }

        public IActionResult Save(vmBook v)
        {
            vmBook vm = new vmBook();
            vm.LiB = bServices.LoudAll();
            vm.LiA = aServices.LoudAll();
            vm.LiC = cServices.LoudAll();

            //1-first i should read the pic.  2- i shoulld save it on data base"server" 
            string name = Guid.NewGuid().ToString() + "." + v.book.Photo.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(),config["UpLoudFoldarName"], name);
            string virtialPath = "http://localhost/BooksStoreTask/StaticPath/" + name;
            v.book.Photo.CopyTo(new FileStream(path, FileMode.Create)); //this statment meaning take the photo and copy it to done file's name: x111.png
            v.book.PhotoPath= virtialPath;

            bServices.Insert(v.book);
            return View("NewBook",vm);
        }
        public IActionResult Delete(int Id)
        {
            vmBook vm = new vmBook();
            vm.LiA = aServices.LoudAll();
            vm.LiC = cServices.LoudAll();

            bServices.Delete(Id);
            vm.LiB = bServices.LoudAll();


            return View("NewBook", vm);
        }
        public IActionResult UpDate(vmBook v)
        {
            vmBook vm = new vmBook();

            vm.LiB = bServices.LoudAll();
            vm.LiA = aServices.LoudAll();
            vm.LiC = cServices.LoudAll();

            bServices.UpDate(v.book);
            return View("NewBook",vm);
        }
        public IActionResult GetById(int id)
        {
            Book b = new Book();
            b = bServices.LoudEmpById(id);
            return Json(b);
                
        }
        public IActionResult test()
        {
            return View("test");
        }
    }
}
