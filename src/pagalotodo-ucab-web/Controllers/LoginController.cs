using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using UCABPagaloTodoWeb.Models;
using System.Text;
using UCABPagaloTodoWeb.Models.Responses;
using UCABPagaloTodoWeb.Models.Views;
using UCABPagaloTodoWeb.Models.Requests;

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

        public IActionResult Login(LoginRequestModel credenciales)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarCredenciales(LoginRequestModel requestBody)
        {
            var api = "https://localhost:44339/crudusuarios/loginusuario";
            var jsonBody=JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var response = await _httpClient.PostAsync(api, new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
               
                var responseContent=await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                if (loginResponse.data[0].id!=Guid.Empty)
                {
                    return RedirectToAction("loginAdministrador", loginResponse.data[0]);
                    
                }
                return RedirectToAction("Privacy", "Home");
                
            }
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult loginAdministrador(LoginDataModel loginDataModel)
        {
            if (loginDataModel.discriminator == "Administrador")
            {
                return RedirectToAction("MenuAdministrador", "MenuAdministrador", loginDataModel);
            }
            else
            {
                return RedirectToAction("loginConsumidor", loginDataModel);
            }
        }

        public IActionResult loginConsumidor(LoginDataModel loginDataModel)
        {
            if (loginDataModel.discriminator == "Consumidor")
            {
                return RedirectToAction("MenuAdministrador", "MenuAdministrador", loginDataModel);
            }
            else
            {
                return RedirectToAction("loginPrestador", loginDataModel);
            }
        }

        public IActionResult loginPrestador(LoginDataModel loginDataModel)
        {
            if (loginDataModel.discriminator == "Prestador")
            {
                return RedirectToAction("MenuAdministrador", "MenuAdministrador", loginDataModel);
            }
            else
            {
                return RedirectToAction("loginPrestador", loginDataModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}