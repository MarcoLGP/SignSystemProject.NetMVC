using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignSystemProject.Models;

namespace SignSystemProject.Controllers
{
    public class SignUpController : Controller
    {
        private readonly string _apiEndPoint = "https://signsystemapi.bsite.net/user";
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
                StringContent httpContent = new(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_apiEndPoint}/addUser", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content($"Erro: {response.StatusCode}");
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