namespace NumToWords.Models
{
    public class Numbers
    {
        public int userInput { get; set; }
        public string? numInText { get; set; }
        public string[] unidades = {"Zero", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove"};
        public string[] dezenas = { "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Deszsseis", "Dezessete", "Dezoito", "Dezenove", "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa"};
        public string[] centenas = { "Cem", "Duzentos", "Trezentos", "Quatrocentos", "Quinentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };
        public string[] milhar = { "Mil", "Dois Mil", "Três Mil", "Quatro Mil", "Cinco Mil", "Seis Mil", "Sete Mil", "Oito Mil", "Nove Mil"};

        public string NumberConvert(int userInput)
        {
            string num = "";
            if (userInput < 10) { num = unidades[userInput]; }
            else if ((userInput >= 10)&&(userInput <= 99)) 
            {
                if ((userInput < 20) && (userInput > 10)) { num = dezenas[userInput-10]; }
                else if (userInput == 10) 
                { 
                    num = dezenas[0];
                }
                else
                {
                    float descobreDezena = (float) userInput/10;
                    int dezena = (int)descobreDezena;
                    int dezenaInt = dezena+8;
                    int unidadeInt = userInput - (dezena * 10);
                    if (unidadeInt==0) { num = dezenas[dezenaInt]; }
                    else
                    {
                        num = $"{dezenas[dezenaInt]} E {unidades[unidadeInt]}";
                    }
                }
            }
            return num;
        }
    }
}
