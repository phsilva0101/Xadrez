﻿using System;
using tabuleiro;
using System.Collections.Generic;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executarMovimentos(Posicao origem , Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void desfazMovimento (Posicao origem , Posicao destino , Peca pecaCapturadas)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdeMovimentos();
            if(pecaCapturadas != null)
            {
                tab.colocarPeca(pecaCapturadas , destino);
                capturadas.Remove(pecaCapturadas);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executarMovimentos(origem, destino);
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException(" Você não pode se colocar em xeque! ");
            }
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequeMate(adversaria(jogadorAtual)))
            {

                terminada = true;
            }
            else
            {
                turno++;
                mudancaJogador();
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if(!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem selecionada!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem , Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public void mudancaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
            }

        private Cor adversaria (Cor cor) {
            if (cor == Cor.Branca ){
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor)
        {
            foreach ( Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if(mat[R.posicao.Linha , R.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor)){
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor)) 
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++)
                {
                    for(int j = 0; j < tab.coluna; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimentos(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void colocarNovasPecas(char coluna, int linhas, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linhas).toPosicao());
            pecas.Add(peca); 
        }
        private void colocarPecas() {

           
            colocarNovasPecas('a', 1, new Torre(tab, Cor.Branca));
            colocarNovasPecas('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovasPecas('c', 1, new Bispo (tab, Cor.Branca));
            colocarNovasPecas('d', 1, new Dama(tab, Cor.Branca));
            colocarNovasPecas('e', 1, new Rei(tab, Cor.Branca));
            colocarNovasPecas('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovasPecas('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovasPecas('h', 1, new Torre(tab, Cor.Branca));
            colocarNovasPecas('a', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('b', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('c', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('d', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('e', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('f', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('g', 2, new Peao(tab, Cor.Branca));
            colocarNovasPecas('h', 2, new Peao(tab, Cor.Branca));

            colocarNovasPecas('a', 8, new Torre(tab, Cor.Preta));
            colocarNovasPecas('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovasPecas('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovasPecas('d', 8, new Dama(tab, Cor.Preta));
            colocarNovasPecas('e', 8, new Rei(tab, Cor.Preta));
            colocarNovasPecas('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovasPecas('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovasPecas('h',8, new Torre(tab, Cor.Preta));
            colocarNovasPecas('a', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('b', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('c', 7 , new Peao(tab, Cor.Preta));
            colocarNovasPecas('d', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('e', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('f', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('g', 7, new Peao(tab, Cor.Preta));
            colocarNovasPecas('h', 7, new Peao(tab, Cor.Preta));


        }

    }
}
