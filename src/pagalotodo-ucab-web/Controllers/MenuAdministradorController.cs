using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using UCABPagaloTodoWeb.Models;
using UCABPagaloTodoWeb.Models.Responses;
using UCABPagaloTodoWeb.Models.Views;

namespace UCABPagaloTodoWeb.Controllers
{
    public class MenuAdministradorController : Controller
    {
        private readonly ILogger<MenuAdministradorController> _logger;
        private readonly HttpClient _httpClient;

        public MenuAdministradorController(ILogger<MenuAdministradorController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult MenuAdministrador(LoginDataModel loginDataModel)
        {
            MenuAdministradorViewModel menuAdministradorViewModel = new MenuAdministradorViewModel();
            menuAdministradorViewModel.loginDataModel = loginDataModel;
            return View(menuAdministradorViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> VerUsuarios(LoginDataModel loginDataModel)
        {
            var api = "https://localhost:44339/crudusuarios/consultarusuarios";
            var response = await _httpClient.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var consultarUsuariosResponse = JsonConvert.DeserializeObject<ConsultarUsuarioResponse>(responseContent);
                if (consultarUsuariosResponse.data.Length > 0)
                {
                    ConsultarUsuariosViewModel consultarUsuariosViewModel=new ConsultarUsuariosViewModel();
                    consultarUsuariosViewModel.consultarUsuarioResponse = consultarUsuariosResponse;
                    consultarUsuariosViewModel.loginDataModel = loginDataModel;

                    return View(consultarUsuariosViewModel);
                }
                return RedirectToAction("Privacy", "Home");

            }
            return RedirectToAction("Privacy", "Home");
            
        }



        [HttpPost]
        public async Task<IActionResult> RegistrarConsumidor(AgregarConsumidorModel requestBody)
        {
            //enviar preguntas al backend para mostrarlas

            var api = "https://localhost:44339/crudusuarios/agregarconsumidor";
            var jsonBody = JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var response = await _httpClient.PostAsync(api, new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                if (loginResponse.data[0].id != Guid.Empty)
                {
                    //Si es correcto
                    return RedirectToAction("MensajeExitoAgregarConsumidor", "Mensajes");
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