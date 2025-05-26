using System.Security.AccessControl;
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
            ret += DecrementRecursion(n);


            return ret;
        }

        [HttpGet]
        public string Somador(int n = 10)
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


            retorno = $"{stringRecursion(palavra, 0)} Letras";

            return retorno;
        }

        public int stringRecursion(string palavra, int count)
        {
            int ret = count;
            string restante = palavra;


            if ((restante == "") || (restante == null))
            {
                return ret;
            }
            else
            {
                restante = palavra.Substring(1);
                count++;
                ret = stringRecursion(restante, count);
            }

            return ret;
        }

        public bool getPalindromo(string palavra)
        {
            if (string.IsNullOrWhiteSpace(palavra))
                return false;
            int tamanho = stringRecursion(palavra, 0);
            palavra = palavra.ToLower();
            return  PalindromoRecurion(palavra, 0, tamanho-1);
        }
        public bool PalindromoRecurion(string palavra, int esquerda, int direita)
        {
            // Caso base: se os índices se cruzaram, é palíndromo
            if (esquerda >= direita)
                return true;

            // Se os caracteres não são iguais, não é palíndromo
            if (palavra[esquerda] != palavra[direita])
                return false;

            // Continua recursivamente com os próximos caracteres
            return PalindromoRecurion(palavra, esquerda + 1, direita - 1);
        }
    }
}