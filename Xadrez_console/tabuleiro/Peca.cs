using System;

using tabuleiro;
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdemovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca( Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qtdemovimentos = 0;
       }
        public void decrementarQtdeMovimentos()
        {
            qtdemovimentos--;
        }

        public void incrementarQtdeMovimentos()
        {
            qtdemovimentos++;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentoPossivel();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j< tab.coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool podeMoverPara(Posicao pos)
        {
            return movimentoPossivel()[pos.Linha, pos.Coluna];
        }

        public abstract bool [,] movimentoPossivel();
    }
}