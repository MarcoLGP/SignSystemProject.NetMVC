using Microsoft.AspNetCore.Mvc;
using SignSystemProject.Models;
using System.Diagnostics;

namespace SignSystemProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignInResponse form)
        {
            return Content($"Recebido seu form, {form.Email}");
        }
    }
}