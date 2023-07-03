using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using UCABPagaloTodoWeb.Models;
using UCABPagaloTodoWeb.Models.Requests;
using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Controllers
{
    public class RegistrarUsuarioController : Controller
    {
        private readonly ILogger<RegistrarUsuarioController> _logger;
        private readonly HttpClient _httpClient;

        public RegistrarUsuarioController(ILogger<RegistrarUsuarioController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult RegistrarUsuario()
        {
            //envie datos con el servicio
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> RegistrarConsumidor(AgregarConsumidorRequestModel requestBody)
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
                var loginResponse = JsonConvert.DeserializeObject<RegistrarUsuarioResponse>(responseContent);
                if (loginResponse.data != Guid.Empty)
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