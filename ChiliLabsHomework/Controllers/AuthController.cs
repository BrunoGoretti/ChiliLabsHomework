﻿using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}