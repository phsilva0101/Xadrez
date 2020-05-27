using System;
using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.coluna];
            Posicao pos = new Posicao(0, 0);



            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 2);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha - 2, posicao.Coluna - 1);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha - 2, posicao.Coluna + 1);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 2);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 2);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha + 2, posicao.Coluna + 1);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha + 2, posicao.Coluna - 1);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 2);
            if (tab.peca(pos) != null || tab.peca(pos).cor != cor)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}