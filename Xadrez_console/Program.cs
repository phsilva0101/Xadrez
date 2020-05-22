using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {

                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 4));


                Tela.imprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Error!" + e.Message);
            }
        }
    }
}
