using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignSystemProject.Models;
using SignSystemProject.Models.View;

namespace SignSystemProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiEndPoint = "http://localhost:5051/user";
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
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
                string json = JsonConvert.SerializeObject(form);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_apiEndPoint}/signIn", httpContent);
                List<UserViewModel>? usuarios = null;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
                }
                Console.WriteLine(usuarios);
                return View("Users", usuarios);
            } else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}