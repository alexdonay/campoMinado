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
        Game game;
        public FrmCampoMinado()
        {
            InitializeComponent();
           
        }
       

        private void FrmCampoMinado_Load(object sender, EventArgs e)
        {
            
        
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.LimparTabuleiro();
                game = null;
            }
            game = new Game(int.Parse(txtLinhas.Text), int.Parse(txtColunas.Text), int.Parse(txtBombas.Text),this);
            
            game.InitializeGame();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                game.LimparTabuleiro();
            }
            
        }

        private void txtColunas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLinhas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBombas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}