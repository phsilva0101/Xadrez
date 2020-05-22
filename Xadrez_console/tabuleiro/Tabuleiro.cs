using System;

using tabuleiro;
namespace tabuleiro
{
     class Tabuleiro
    {
        public int linhas { get; set; }
        public int coluna { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int coluna)
        {
            this.linhas = linhas;
            this.coluna = coluna;
            pecas = new Peca[linhas, coluna];
        }


      public Peca peca (int linhas , int colunas)
        {
            return pecas[linhas, colunas];
        }
        public void colocarPeca(Peca p , Posicao pos)
        {
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
    }
}
