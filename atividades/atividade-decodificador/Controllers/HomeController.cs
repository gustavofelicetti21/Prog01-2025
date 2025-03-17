using atividade_decodificador.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace atividade_decodificador.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult EncriptarDecriptar()
        {
            var model = new EncriptarDecriptar();
            return View(model);
        }

        [HttpPost]
        public IActionResult EncryptionDecryption(EncriptarDecriptar model, string action)
        {
            if (!string.IsNullOrEmpty(model.entradaUsuario) || !string.IsNullOrEmpty(model.textoEncriptado))
            {
                if (action == "Encrypt" && !string.IsNullOrEmpty(model.entradaUsuario))
                {
                    model.textoEncriptado= model.Encriptar(model.entradaUsuario, model.shift);
                    model.textoDecriptado= null;
                    model.entradaUsuario= null;
                }
                else if (action == "Decrypt" && !string.IsNullOrEmpty(model.textoEncriptado))
                {
                    model.textoDecriptado= model.Decriptar(model.textoEncriptado, model.shift);
                    model.textoEncriptado= null; // Correct reset.
                }
                else
                {
                    ModelState.AddModelError("", "Please, enter text to Encrypt or Decrypt!");
                }
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}