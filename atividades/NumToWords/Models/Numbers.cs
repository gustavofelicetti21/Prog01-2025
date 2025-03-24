using System;

namespace NumToWords.Models
{
    public class Numbers
    {
        public int userInput { get; set; }
        public string? numInText { get; set; }
        public string[] unidadeS = {"Zero", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove"};
        public string[] dezenaS = { "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Deszsseis", "Dezessete", "Dezoito", "Dezenove", "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa"};
        public string[] centenaS = { "Cem", "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };
        public string[] milharS = {"", "Mil", "Dois Mil", "Três Mil", "Quatro Mil", "Cinco Mil", "Seis Mil", "Sete Mil", "Oito Mil", "Nove Mil"};


        public string NumberConvert(int userInput)
        {
            string num = "";
            if ((userInput < 10)&&(userInput >= 0)) { num = unidadeS[userInput]; }
            else if ((userInput >= 10) && (userInput <= 99))
            {
                num = msgDezenaUnidade(userInput);
            }
            else if ((userInput >= 100) && (userInput <= 999))
            {
                num = centenaS[indiceCentena(userInput)];

                int centena = indiceCentena(userInput);
                if (centena == 0) { centena = (centena + 1) * 100; }
                else { centena *= 100; }

                int baseCalculo = userInput - centena;
                if (baseCalculo != 0)
                {
                    num += $" E {msgDezenaUnidade(baseCalculo)}";
                }
            }
            else if ((userInput >= 1000) && (userInput <= 9999))
            {
                num = milharS[indiceMilhar(userInput)];
                int milhar = indiceMilhar(userInput) * 1000;
                
                int baseCalculo = userInput - milhar;

                if (baseCalculo != 0)
                {
                    num += $" E {centenaS[indiceCentena(baseCalculo)]}";
                    int centena = indiceCentena(baseCalculo);
                    if (centena == 0) { centena = (centena + 1) * 100; }
                    else { centena *= 100; }

                    baseCalculo -= centena;

                    if (baseCalculo != 0)
                    {
                        num += $" E {msgDezenaUnidade(baseCalculo)}";
                    }
                }
            }
            else if ((userInput >= 10000) && (userInput <= 99999))
            {
                float descobreMilha = (float)userInput / 10000;
                float milhaDezena = descobreMilha * 10;
                int milhaDezenaInt = ( int)milhaDezena;
                num = $"{msgDezenaUnidade(milhaDezenaInt)} Mil";

                int baseCalculo = userInput - (milhaDezenaInt * 1000);

                if (baseCalculo != 0)
                {
                    num += $" E {centenaS[indiceCentena(baseCalculo)]}";
                    int centena = indiceCentena(baseCalculo);
                    if (centena == 0) { centena = (centena + 1) * 100; }
                    else { centena *= 100; }

                    baseCalculo -= centena;

                    if (baseCalculo != 0)
                    {
                        num += $" E {msgDezenaUnidade(baseCalculo)}";
                    }
                }
            }
            else {
                num = "Digite um valor entre 0 e 99999";
            }
            return num;
        }

        private String msgDezenaUnidade(int numero)
        {
            string msg = "";

            if ((numero < 20) && (numero > 10)) { msg = dezenaS[numero - 10]; }
            else if (numero == 10)
            {
                msg = dezenaS[0];
            }
            else
            {
                float descobreDezena = (float)numero / 10;
                int dezena = (int)descobreDezena;
                int dezenaInt = dezena + 8;
                int unidadeInt = numero - (dezena * 10);
                if (unidadeInt == 0) { msg = dezenaS[dezenaInt]; }
                else
                {
                    msg = $"{dezenaS[dezenaInt]} E {unidadeS[unidadeInt]}";
                }
            }

            return msg;
        }

        private int indiceCentena(int numero)
        {
            int centenaInt = 0;
            if (numero == 100)
            {
                centenaInt = 0;
            }
            else
            {
                float descobreCentena = (float)numero / 100;
                centenaInt = (int)descobreCentena;
            }

            return centenaInt;
        }

        private int indiceMilhar(int numero) 
        {
            float descobreMilhar = (float)numero / 1000;
            int milharInt = (int)descobreMilhar;

            return milharInt;
        }
    }
}
