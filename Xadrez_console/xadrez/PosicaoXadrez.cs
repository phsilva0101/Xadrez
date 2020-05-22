using System;
using tabuleiro;
namespace xadrez
{
    public class PosicaoXadrez
    {

        public char coluna { get; set; }
        public int linhas { get; set; }
         
        public PosicaoXadrez(char coluna , int linhas)
        {
            this.coluna = coluna;
            this.linhas = linhas;

        }
        public Posicao toPosicao()
        {
            return new Posicao(8 - linhas, coluna - 'a'); 
        }

        public override string ToString()
        {
            return "" + coluna + linhas;
        }
    }
}
