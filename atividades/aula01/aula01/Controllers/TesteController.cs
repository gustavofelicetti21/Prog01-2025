using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace aula01.Controllers
{
    public class Result
    {
        public string Texto = string.Empty;
    }
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(
            ILogger<TesteController> logger
            )
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new Result());
        }
        
        [HttpPost]
        public IActionResult Index(string texto)
        {
            Result resultado = new Result();

            int criptografia = Convert.ToInt32(texto) + 5;
            int letra
            if (int letra > 122) { letra = letra - 26; }
            //converte ascii para char 
            criptografia += Convert.ToChar(letra);
        }

            return View("Index", resultado);
        }
    }
}
