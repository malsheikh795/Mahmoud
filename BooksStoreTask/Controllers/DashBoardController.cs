﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View("DashBoard");
        }
    }
}
