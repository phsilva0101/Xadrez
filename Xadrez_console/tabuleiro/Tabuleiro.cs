using System;
namespace Xadrez_console.tabuleiro
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
    }
}
