using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static campoMinado.Square;

namespace campoMinado
{
    public class GameBoard
    {
        private int linha;
        private int coluna;
        private int numBombs;
        public Square[,] table;

        public GameBoard(int linha, int coluna, int numBombs)
        {
            this.linha = linha;
            this.coluna = coluna;
            this.numBombs = numBombs;
            this.table = new Square[linha, coluna];
            InitializeTable();
            SetBombs();
            SetVizinhos();
            SetNumberBombs();
        }

        private void InitializeTable()
        {
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    table[i, j] = new Square(i, j);
                    table[i, j].status = SquareStatus.Hidden;
                }
            }
        }

        private void SetBombs()
        {
            Random random = new Random();

            for (int i = 0; i < numBombs; i++)
            {
                while (true)
                {
                    int linhaR = random.Next(linha);
                    int colunaR = random.Next(coluna);

                    if (!table[linhaR, colunaR].bomb)
                    {
                        table[linhaR, colunaR].bomb = true;
                        break;
                    }
                }
            }
        }

        private void SetVizinhos()
        {
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    Square currentSquare = table[i, j];
                    currentSquare.vizinhos = new List<Square>();

                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            if (di == 0 && dj == 0)
                                continue;

                            int vizinhoLinha = i + di;
                            int vizinhoColuna = j + dj;

                            if (vizinhoLinha >= 0 && vizinhoLinha < linha && vizinhoColuna >= 0 && vizinhoColuna < coluna)
                            {
                                Square neighborSquare = table[vizinhoLinha, vizinhoColuna];
                                currentSquare.vizinhos.Add(neighborSquare);
                            }
                        }
                    }
                }
            }
        }

        private void SetNumberBombs()
        {
            for (int i = 0; i < linha; i++)
            {
                for (int j = 0; j < coluna; j++)
                {
                    Square currentSquare = table[i, j];
                    if (!currentSquare.bomb)
                    {
                        int count = 0;
                        foreach (Square vizinho in currentSquare.vizinhos)
                        {
                            if (vizinho.bomb)
                            {
                                count++;
                            }
                        }
                        currentSquare.quantBombs = count;
                    }
                }
            }
        }
    }

}
