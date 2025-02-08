using Microsoft.AspNetCore.Mvc;
using SM_ProyectoWeb.Models;

namespace SM_ProyectoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public LoginController(IHttpClientFactory httpClient)
        {

            _httpClient = httpClient;

        }

        #region RegistrarCuenta
        [HttpGet]
        public IActionResult RegistrarCuenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCuenta(UsuarioModel model)
        {
            using (var api = _httpClient.CreateClient()) //Using es un delimirador se acceso
            {
               var url = "https://localhost:44357/api/Login/RegistrarCuenta";
               var resul = api.PostAsJsonAsync(url, model).Result;

                if (resul.IsSuccessStatusCode)
                {
                    return RedirectToAction("IniciarSesion", "Login");
                }
            }

            return View();
        }
        #endregion

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Principal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RecuperarContrasenia()
        {
            return View();
        }
    }
}
