﻿using Microsoft.AspNetCore.Mvc;
using SignSystemProject.Models;

namespace SignSystemProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(SignInResponse form)
        {
            if (ModelState.IsValid)
            {
                return Content($"Login efetuado: Email: {form.Email}, Senha: ************");
            } else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}