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

        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p , Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= coluna)
            {
                return false;
            }
            return true;
        }

            public void validarPosicao(Posicao pos)
            {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida: ");
            }
        }
        }
    }

