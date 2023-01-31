using Microsoft.AspNetCore.Mvc;
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
            return Content($"Login efetuado: Email: {form.Email}, Senha: ************");
        }
    }
}