using Microsoft.AspNetCore.Mvc;
using SignSystemProject.Models;

namespace SignSystemProject.Controllers
{
    public class SignUpController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Index(SignUpResponse form) 
        {
            if (ModelState.IsValid)
            {
                return Content($"Usuário registrado: Nome: {form.Name}, Email: {form.Email}, Senha: **************");
            } else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}