using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace atividade_decodificador.Models
{
    public class EncriptarDecriptar
    {
        public string? entradaUsuario { get; set; }
        public int shift { get; set; }
        public string? textoEncriptado { get; set; }
        public string? textoDecriptado { get; set; }

        public string Encriptar(string entradaUsuario, int shift)
        {
            string textoEncriptado = "";

            foreach (char c in entradaUsuario)
            {
                if (char.IsLetter(c))
                {
                    char minusculo = char.ToLower(c);
                    char shifted = (char)(((minusculo + shift - 'a') % 26) + 'a');
                    textoEncriptado += shifted;
                }

                else
                {
                    textoEncriptado += c;
                }
            }

            return textoEncriptado;
        }

        public string Decriptar(string textoEncriptado, int shift)
        {
            string entradaUsuario = "";

            foreach (char c in textoEncriptado)
            {
                if (char.IsLetter(c))
                {
                    char minusculo = char.ToLower(c);
                    char shifted = (char)(((minusculo - shift - 'a' + 26) % 26) + 'a');
                    textoEncriptado += shifted;
                }

                else
                {
                    entradaUsuario+= c;
                }
            }

            return entradaUsuario;
        }
    }
}