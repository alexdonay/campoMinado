using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


using static campoMinado.Square;

namespace campoMinado
{
    public class Game

    {
        private Control parentControl;
        private GameTimer gameTimer;
        private Square[,] tabuleiro;
        private int quantLinhas;
        private int quantColunas;
        private int quantBombas;
        private int quantCelulasFlaged;
        private int quantCelulas;
        private int quantCelulasOpen;
        private Panel panelBoard;
        private GameBoard table;
        

        public Game(int quantLinha, int quantColunas, int quantBombas, Control parentControl) { 

            this.quantLinhas = quantLinha;
            this.quantColunas= quantColunas;
            this.quantBombas = quantBombas;
            this.parentControl = parentControl;

        }
        public void InitializeGame()
        {
            gameTimer = new GameTimer();
            gameTimer.TempoAtualizado += GameTimer_TempoAtualizado;
            gameTimer.Iniciar();
            CriarTabuleiro();


        }
        private void CriarTabuleiro()
        {
            if (panelBoard != null)
            {
                parentControl.Controls.Remove(panelBoard);
                panelBoard.Dispose();
            }
            panelBoard = new Panel();
            panelBoard.Location = new Point(100, 100);
            panelBoard.AutoSize = true;
            parentControl.Controls.Add(panelBoard);

            panelBoard.Size = new Size(quantColunas * 30, quantLinhas * 30);
            table = new GameBoard(quantLinhas, quantColunas, quantBombas);
            tabuleiro = table.table;

            for (int i = 0; i < quantLinhas; i++)
            {
                for (int j = 0; j < quantColunas; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(j * 30, i * 30);
                    button.Tag = tabuleiro[i, j];
                    button.MouseDown += MouseClick;
                    panelBoard.Controls.Add(button);
                    quantCelulas = quantColunas * quantColunas;
                }
            }
        }
        


        public void abrirCelula(Button button, Square cell)
        {
            button.Text = cell.quantBombs.ToString();
            button.Enabled = false;
            cell.status = SquareStatus.Revealed;
            quantCelulasOpen++;
            if (cell.quantBombs == 0)
            {
                AbrirCelulasVizinhas(cell, button);
            }
        }
        public Boolean lostGame(Square cell)
        {
            if (cell.bomb)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AbrirCelulasVizinhas(Square cell, Button button)
        {
            if (cell.quantBombs == 0 && !cell.bomb)
            {
                foreach (Square vizinho in cell.vizinhos)
                {
                    if (vizinho.status == SquareStatus.Hidden)
                    {
                        Button botaoVizinho = GetButtonByCell(vizinho);
                        abrirCelula(botaoVizinho, vizinho);
                    }
                }
            }
        }

        private Button GetButtonByCell(Square cell)
        {
            foreach (Button button in panelBoard.Controls.OfType<Button>())
            {
                if (button.Tag == cell)
                {
                    return button;
                }
            }
            return null;
        }
        private Boolean winGame()
        {

            if (((quantBombas == (quantCelulas - quantCelulasOpen))) && (quantCelulasOpen == ((quantCelulas - quantBombas))))
            {
                return true;

            }
            return false;
        }
        private void ShowAllBombs()
        {
            foreach (Button button in panelBoard.Controls.OfType<Button>())
            {
                Square cell = (Square)button.Tag;
                if (cell.bomb)
                {
                    button.Text = "B";
                    button.Enabled = false;
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.Text = cell.quantBombs.ToString();
                    button.Enabled = false;
                    cell.status = SquareStatus.Revealed;

                }

            }
        }
        private void MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            Square cell = (Square)button.Tag;

            if (e.Button == MouseButtons.Right)
            {
                if (cell.status == SquareStatus.Flagged)
                {
                    button.Text = "";
                    cell.status = SquareStatus.Hidden;
                    quantCelulasFlaged--;

                }
                else
                {
                    button.Text = "F";
                    cell.status = SquareStatus.Flagged;
                    quantCelulasFlaged++;
                }
                if (winGame())
                {
                    MessageBox.Show("Voce ganhou");
                }

            }
            else if (e.Button == MouseButtons.Left)
            {

                abrirCelula(button, cell);

                if (lostGame(cell))
                {
                    gameTimer.Parar();
                    
                    ShowAllBombs();
                    MessageBox.Show("Você perdeu!");
                    
                }
                else
                {

                    if (winGame())
                    {
                        gameTimer.Parar();
                        MessageBox.Show("Voce ganhou");
                        
                        
                    }


                }

            }


        }
        private void GameTimer_TempoAtualizado(object sender, int tempoDecorrido)
        {
            string tempoFormatado = TimeSpan.FromSeconds(tempoDecorrido).ToString(@"hh\:mm\:ss");
            parentControl.Invoke((MethodInvoker)delegate {
                ((TextBox)parentControl.Controls["txtTempo"]).Text = tempoFormatado;
            });
        }
        public void LimparTabuleiro()
        {
            if (panelBoard != null)
            {
                

                parentControl.Controls.Remove(panelBoard);
                panelBoard.Controls.Clear();
                panelBoard.Dispose();
                panelBoard = null;
            }
            gameTimer.Reset();
            quantCelulasFlaged = 0;
            quantCelulasOpen = 0;
            quantCelulas = 0;
        }


    }

}
