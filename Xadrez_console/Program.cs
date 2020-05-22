using System;
using tabuleiro;
using Xadrez_console.tabuleiro;
namespace Xadrez_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.imprimirTela(tab);
        }
    }
}
