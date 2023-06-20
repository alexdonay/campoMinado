using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace campoMinado
{
    public partial class FrmCampoMinado : Form
    {
        public FrmCampoMinado()
        {
            InitializeComponent();
            Square sq;

            //i é coluna
            //y é lina

            List<Square> squares = new List<Square>();
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    sq = new Square(i, y);
                    sq.cimaEsquerda = new Square(i - 1, y - 1);
                    sq.cima = new Square(i, y - 1);
                    sq.cimaDireita = new Square(i - 1, y);
                    sq.baixo = new Square(i, y + 1);
                    sq.baixoDireita = new Square(i + 1, y + 1);
                    sq.baixoEsquerda = new Square(i - 1, y + 1);
                    sq.esquarda = new Square(i - 1, y);
                    sq.baixoDireita = new Square(i + 1, y);

                    if (i == 0)
                    {
                        sq.cimaEsquerda = null;
                        sq.cima = null;
                        sq.cimaDireita = null;
                    }
                    if (i == 9)
                    {
                        sq.baixo = null;
                        sq.baixoDireita = null;
                        sq.baixoEsquerda = null;
                    }
                    if (y == 0)
                    {
                        sq.cimaDireita = null;
                        sq.cima = null;
                        sq.cimaEsquerda = null;
                    }
                    if (y == 9)
                    {
                        sq.baixo = null;
                        sq.baixoDireita = null;
                        sq.baixoEsquerda = null;
                    }

                    squares.Add(sq);
                }
            }
        }

        public List<Square> generateBombs(List<Square> listSquare, int qtdBombas)
        {

            for (int i = 0; i < qtdBombas; i++)
            {

            }
            return listSquare;
        }
        private void FrmCampoMinado_Load(object sender, EventArgs e)
        {

        }
    }
}
