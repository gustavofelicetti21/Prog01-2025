namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        //Podemos também atribuir referência
        //de caracteres unicode

        public char myChar4 = '\u2726';

        //Pomos ainda mesclar caracteres especiais
        //como, nova linha, tabulação e etc.
        public string textLine = "Esta é uma linha de texto.\n\n";

        /*
        \e - Caractere de escape
        \n - Nova linha
        \r - Retorno
        \t - Tabulação horizontal
        \" - Aspas duplas - usadas dentro da string
        \' - aspas simples dentro da string
        */

        //Interpolação de Strings
        //Combinando strings de diferentes maneiras no C#

        private int count = 10;
        public string message;
        
        public DataType()
        {
            message = $"O contador está em {count}";

            string username = "Gustavo";
            int inboxCount = 10;
            int maxCount = 100;
            message += $"\n o usuário {username} tem {inboxCount} mensagens.";
            message += $"\nEspaço restante em sua caixa{maxCount-inboxCount}.";
        }
    }
}
