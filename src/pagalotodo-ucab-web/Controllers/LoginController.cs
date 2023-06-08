using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using UCABPagaloTodoWeb.Models;
using System.Text;
using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly HttpClient _httpClient;
            public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult Login(LoginModel credenciales)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarCredenciales(string usuario, string password)
        {

            var api = "https://localhost:44339/crudusuarios/loginusuario";
            var requestBody= new {usuario=usuario, password= password};
            var jsonBody=JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var response = await _httpClient.PostAsync(api, new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
               
                var responseContent=await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                if(loginResponse!=null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Privacy", "Home");
                
            }
            return RedirectToAction("Privacy", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}