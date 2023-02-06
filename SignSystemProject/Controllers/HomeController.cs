using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignSystemProject.Models;
using SignSystemProject.Models.View;

namespace SignSystemProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiEndPoint = "https://signsystemapi.bsite.net/user";
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
                if (response.IsSuccessStatusCode)
                {
                    List<UserViewModel>? usuarios = null;
                    string content = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
                    return View("Users", usuarios);
                }
                else
                {
                    ViewBag.Error = true;
                    switch ((int)response.StatusCode)
                    {
                        case 404:
                            ViewBag.ErrorLog = "Usuário não registrado";
                            return View();
                        case 401:
                            ViewBag.ErrorLog = "Credenciais inválidas";
                            return View();
                        default:
                            ViewBag.ErrorLog = "Erro interno";
                            return View();
                    }
                }
                
            } 
            else
            {
                ViewBag.Error = true;
                return View();
            }
        }
    }
}