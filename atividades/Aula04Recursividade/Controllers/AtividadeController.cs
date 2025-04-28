using Microsoft.AspNetCore.Mvc;

namespace Aula04Recursividade.Controllers
{
    public class AtividadeController : Controller
    {
        public IActionResult Index()
        {
            return View("index");
        }


    }
}
