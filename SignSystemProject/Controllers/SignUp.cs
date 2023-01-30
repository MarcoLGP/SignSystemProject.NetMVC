using Microsoft.AspNetCore.Mvc;
using SignSystemProject.Models;

namespace SignSystemProject.Controllers
{
    [Route("[controller]")]
    public class SignUp : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Index(SignUpResponse  form) 
        {
            return Content("Usuário cadastrado, faça login");
        }
    }
}