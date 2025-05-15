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
            bool retorno = false;
            int tamanho = stringRecursion(palavra, 0);
            retorno = PalindromoRecurion(palavra, tamanho, "", false);

            return retorno;
        }
        public bool PalindromoRecurion(string palavra, int tamanho, string reverso, bool retorno)
        {
            bool ret = retorno;

            if (tamanho != 0)
            {
                tamanho--;
                reverso += palavra.ToArray()[tamanho];
            }

            if ((tamanho==0) && (palavra == reverso))
            {
                retorno = true;
            }

            ret = PalindromoRecurion(palavra, tamanho, reverso, retorno);

            return ret;
        }
    }
}