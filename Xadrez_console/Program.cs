using System;
using Tabuleiro;
namespace Xadrez_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Posicao p = new Posicao(3,4);

            Console.WriteLine("Posição: " + p);
        }
    }
}
