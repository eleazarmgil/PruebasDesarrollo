using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using UCABPagaloTodoWeb.Models;
using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Controllers
{
    public class RecuperarClaveController : Controller
    {
        private readonly ILogger<RecuperarClaveController> _logger;
        private readonly HttpClient _httpClient;

        public RecuperarClaveController(ILogger<RecuperarClaveController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult RecuperarClave()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarRespuestas(ConsultarRespuestasDeSeguridadModel datos)
        {
            var api = "https://localhost:44339/crudusuarios/preguntasdeseguridad?password=";
            api += datos.usuario;
            var response = await _httpClient.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<PreguntasDeSeguridadResponse>(responseContent);
                var preguntas = new PreguntasDeSeguridadModel();
                preguntas.pregunta_de_seguridad = jsonResponse.data[0].pregunta_de_seguridad;
                preguntas.pregunta_de_seguridad2 = jsonResponse.data[0].pregunta_de_seguridad2;
                if (preguntas != null)
                {
                    return RedirectToAction("ConsultarRespuestas", preguntas);
                }
                return RedirectToAction("Privacy", "Home", preguntas);

            }
            return RedirectToAction("Privacy", "Home");
        }


        public IActionResult ConsultarRespuestas(PreguntasDeSeguridadModel preguntas)
        {
            ViewData["pregunta_de_seguridad"] = preguntas.pregunta_de_seguridad;
            ViewData["pregunta_de_seguridad2"] = preguntas.pregunta_de_seguridad2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarRespuestas(RecuperarClaveModel datos)
        {
            var api = "https://localhost:44339/crudusuarios/preguntasdeseguridad?usuario=";
            api += datos.usuario;
            var response = await _httpClient.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<PreguntasDeSeguridadResponse>(responseContent);
                var preguntas = new PreguntasDeSeguridadModel();
                preguntas.pregunta_de_seguridad = jsonResponse.data[0].pregunta_de_seguridad;
                preguntas.pregunta_de_seguridad2 = jsonResponse.data[0].pregunta_de_seguridad2;
                if (preguntas != null)
                {
                    return RedirectToAction("ConsultarRespuestas", preguntas);
                }
                return RedirectToAction("Privacy", "Home", preguntas);
            
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