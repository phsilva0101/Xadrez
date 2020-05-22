using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PosicaoXadrez pos  = new PosicaoXadrez('a', 5);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
        }
    }
}
