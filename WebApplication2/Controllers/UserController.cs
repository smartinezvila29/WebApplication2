﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
    }
}
