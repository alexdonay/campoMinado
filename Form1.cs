using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static campoMinado.Square;

namespace campoMinado
{
    public partial class FrmCampoMinado : Form
    {
        private Square[,] tabuleiro;
        private int quantLinhas;
        private int quantColunas;
        private int quantBombas;
        private Panel panelBoard;
        private int tempoDecorrido;
        private Timer timerTempo;
        public FrmCampoMinado()
        {
            InitializeComponent();
            timerTempo = new Timer();
            timerTempo.Interval = 1000;
        }


        private void FrmCampoMinado_Load(object sender, EventArgs e)
        {
            panelBoard = new Panel();
            panelBoard.Location = new Point(10, 100);
            panelBoard.AutoSize = true;
            Controls.Add(panelBoard);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            quantLinhas = int.Parse(txtLinhas.Text);
            quantColunas = int.Parse(txtColunas.Text);
            quantBombas = int.Parse(txtBombas.Text);
            tempoDecorrido = 0;
            timerTempo.Start();
            timerTempo.Tick += TimerTempo_Tick;
            InitializeGame();

        }

        private void TimerTempo_Tick(object sender, EventArgs e)
        {
            tempoDecorrido++;
            txtTempo.Text = TimeSpan.FromSeconds(tempoDecorrido).ToString(@"hh\:mm\:ss");
            timerTempo.Start();
           
        }
        private void InitializeGame()
        {
            Square square = new Square();
            tabuleiro = square.initGame(quantLinhas, quantColunas, quantBombas);
            CreateBoardUI();
        }
        private void CreateBoardUI()
        {
            panelBoard.Controls.Clear();
            panelBoard.Size = new Size(quantColunas * 30, quantLinhas * 30);
            for (int i = 0; i < quantLinhas; i++)
            {
                for (int j = 0; j < quantColunas; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(j * 30, i * 30);
                    button.Tag = tabuleiro[i, j];
                    button.Click += Cell_Click;
                    button.MouseDown += cell_RightClick;
                    panelBoard.Controls.Add(button);
                }
            }

        }
        private void cell_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = (Button)sender;
                Square cell = (Square)button.Tag;
                button.Text = "F";
                
                cell.status = SquareStatus.Flagged;
            }
                
        }

        private void formLoad()
        {

        }
        private void Cell_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Square cell = (Square)button.Tag;
            if (cell.bomb)
            {
                ShowAllBombs();
                MessageBox.Show("Você perdeu!");
                
                InitializeGame();
            }
            else
            {
                button.Text = cell.quantBombs.ToString();
                button.Enabled = false;
                cell.status = SquareStatus.Revealed;
                
                if (cell.quantBombs == 0)
                {
                    OpenNeighborCells(cell, button);
                }
            }
            if (winGame(tabuleiro))
            {
                MessageBox.Show("Voce ganhou");
            }
        }

        private void OpenNeighborCells(Square cell, Button button)
        {
            if (cell.quantBombs == 0 && cell.bomb == false)
            {
                cell.status = SquareStatus.Revealed;
                button.Enabled = false;

                foreach (Square vizinho in cell.vizinhos)
                {
                    if (vizinho.status == SquareStatus.Hidden)
                    {
                        Button neighborButton = GetButtonByCell(vizinho);
                        Cell_Click(neighborButton, EventArgs.Empty);
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
        private Boolean winGame(Square[,] board)
        {
            int quantBombas = 0;
            int quantHidden = 0;
            for(int i = 0; i< board.GetLength(0); i++)
            {
                for(int y = 0; y< board.GetLength(1); y++)
                {
                    if (board[i,y].bomb == true)
                    {
                        quantBombas= quantBombas + 1;
                    }
                    if (board[i,y].status == SquareStatus.Hidden)
                    {
                        quantHidden = quantHidden + 1;
                    }
                    
                }
            }
            
            if(quantHidden == quantBombas)
            {
                return true;
            }
            else
            {
                return false;
            }
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
       
    }
}