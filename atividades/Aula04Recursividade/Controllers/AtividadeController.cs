using Microsoft.AspNetCore.Mvc;

namespace Aula04Recursividade.Controllers
{
    public class AtividadeController : Controller
    {
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        public string Decrement(int n)
        {
            string retorno = "";

            retorno = DecrementRecursion(n);

            return retorno;
        }

        public string DecrementRecursion(int n)
        {
            string ret = string.Empty;

            if (n <= 1)
                return $" {n} ";

            ret += $" {n} ";
            n--;

            // Chamada recursiva: Inrementa n e Decrementa count
            // Para imprimir o número
            ret += DecrementRecursion(n);


            return ret;
        }

        [HttpGet]
        public string Somador(int n=10)
        {
            string retorno = "";

            retorno = $"{somadorRecursion(1, n)}";

            return retorno;
        }

        public int somadorRecursion(int n, int count)
        {
            int ret = 0;

            if (count <= 1)
                return n;

            ret += count;
            count--;
            ret += somadorRecursion(n, count);


            return ret;
        }

        [HttpGet]
        public string tamanhoString(string palavra)
        {
            string retorno = "";
            
            
            retorno = $"{stringRecursion(palavra, 1)}";

            return retorno;
        }

        public int stringRecursion(string palavra, int count)
        {
            int ret = 0;

            if (palavra[count] != null)
            {
                ret = count;    
            }


            return ret; 
        }
    }
}