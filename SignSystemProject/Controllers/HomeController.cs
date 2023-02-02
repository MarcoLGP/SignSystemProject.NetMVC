using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignSystemProject.Models;
using SignSystemProject.Models.View;

namespace SignSystemProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiEndPoint = "https://localhost:7112/user";
        private readonly HttpClient _httpClient = null;

        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiEndPoint);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(SignInResponse form)
        {
            if (ModelState.IsValid)
            {
                List<UserViewModel>? usuarios = null;
                var response = await _httpClient.GetAsync($"{_apiEndPoint}/getAll");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
                }
                return View("Users", usuarios);
            } else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}