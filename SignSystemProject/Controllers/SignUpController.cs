using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignSystemProject.Models;

namespace SignSystemProject.Controllers
{
    public class SignUpController : Controller
    {
        private readonly string _apiEndPoint = "http://localhost:5051/user";
        private readonly HttpClient _httpClient;

        public SignUpController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        
        [HttpPost]
        public async Task<ActionResult> Index(SignUpResponse form) 
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(form);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_apiEndPoint}/addUser", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return Content($"Usuário registrado: Nome: {form.Name}, Email: {form.Email}, Senha: **************, StatusCode: {response.StatusCode}");
                }
                else
                {
                    return Content($"Error: {response.StatusCode}");
                }
            } else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}