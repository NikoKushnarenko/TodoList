﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("~/wwwroot/Site/Index.html");
        }
    }
}
