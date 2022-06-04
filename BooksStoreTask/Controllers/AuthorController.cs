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
    public class AuthorController : Controller
    {
        IAuthorServices aServices;
        INationalityServices nServices;
        IConfiguration config;
        public AuthorController(IAuthorServices _aServices,INationalityServices _nServices,IConfiguration _config)
        {
            aServices = _aServices;
            nServices = _nServices;
            config = _config;
        }
        public IActionResult Index()
        {

            vmAuthor vm = new vmAuthor();
            vm.LiN = nServices.LoudAll();
            vm.LiA = aServices.LoudAll();
            return View("NewAuthor",vm);
        }
        public IActionResult Save(vmAuthor v)
        {
            vmAuthor vm = new vmAuthor();
            vm.LiN = nServices.LoudAll();
            vm.LiA = aServices.LoudAll();

            string name = Guid.NewGuid().ToString() + "." + v.author.AuthorPic.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), config["UpLoudFoldarName"], name);
            string virtialPath = "http://localhost/BooksStoreTask/StaticPath/" + name;
            v.author.AuthorPic.CopyTo(new FileStream(path, FileMode.Create)); //this statment meaning take the photo and copy it to done file's name: x111.png
            v.author.PicPath = virtialPath;

            aServices.Insert(v.author);

            return View("NewAuthor", vm);
        }
        public IActionResult Delete(int Id)
        {

            vmAuthor vm = new vmAuthor();
            vm.LiN = nServices.LoudAll();

            aServices.Delete(Id);

            vm.LiA = aServices.LoudAll();

            return View("NewAuthor", vm);
        }
        public IActionResult UpDate(vmAuthor v)
        {
            vmAuthor vm = new vmAuthor();
            vm.LiN = nServices.LoudAll();
            vm.LiA = aServices.LoudAll();

            aServices.UpDate(v.author);
            return View("NewBook",vm);
        }
        public IActionResult GetById(int id)
        {
            Author b = new Author();
            b = aServices.LoudEmpById(id);
            return Json(b);

        }
    }
}
