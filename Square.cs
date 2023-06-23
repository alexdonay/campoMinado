using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campoMinado
{
    public class Square
    {
        
        public enum SquareStatus
        {
            Hidden,
            Revealed,
            Flagged
        }
        public  int i {get; set;}
        public  int y {get; set;}
        public  Boolean bomb { get; set; }
        public int quantBombs { get; set; }
        public List<Square> vizinhos { get; set; }
        public SquareStatus status { get; set; }
        public Square(int i, int y)
        {
            this.i = i;
            this.y = y;
        }

        public Square()
        {
        }

        public Square[,] genTable(int linha, int coluna)
        {
            Square[,] table = new Square[linha, coluna];
            for(int i = 0; i< linha; i++)
            {
                for(int y = 0; y < coluna; y++)
                {
                    table[i,y] = new Square(i, y);
                    table[i,y].status = SquareStatus.Hidden;

                }
            }
            return table;
        }

        public Square[,] setBombs(Square[,] table, int numBombs)
        {
            int linhas = table.GetLength(0);
            int colunas = table.GetLength(1);
            Random random= new Random();

            for(int i = 0;i<numBombs; i++)
            {
                while(true)
                {

                    int linhaR = random.Next(linhas);
                    int colunaR = random.Next(colunas);
                    if (table[linhaR, colunaR].bomb == false)
                    {
                        table[linhaR, colunaR].bomb = true; 
                        break;

                    }
                }
               
            }
            return table;

        }
        public Square[,] setVizinhos(Square[,] tabuleiro)
        {
            int linhas = tabuleiro.GetLength(0);
            int colunas = tabuleiro.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    Square currentSquare = tabuleiro[i, j];
                    currentSquare.vizinhos = new List<Square>();

                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            if (di == 0 && dj == 0)
                                continue;

                            int vizinhoLinha = i + di;
                            int vizinhoColuna = j + dj;

                            if (vizinhoLinha >= 0 && vizinhoLinha < linhas && vizinhoColuna >= 0 && vizinhoColuna < colunas)
                            {
                                Square neighborSquare = tabuleiro[vizinhoLinha, vizinhoColuna];
                                currentSquare.vizinhos.Add(neighborSquare);
                            }
                        }
                    }
                }
            }

            return tabuleiro;
        }

        public Square[,] SetNumberBombs(Square[,] tabuleiro)
        {
            int linhas = tabuleiro.GetLength(0);
            int colunas = tabuleiro.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    Square currentSquare = tabuleiro[i, j];
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

            return tabuleiro;
        }
        public Square[,] initGame(int linhas, int colunas, int Qtbombas)


        {
            
            var tabuleiro = genTable(linhas, colunas);
            tabuleiro = setVizinhos(tabuleiro);
            tabuleiro = setBombs(tabuleiro, Qtbombas);
            tabuleiro = SetNumberBombs(tabuleiro);
            
            return tabuleiro;

        }



        public override string ToString()
        {
            return $"i:  {i}  y: {y}" ;
        }
    }
}
