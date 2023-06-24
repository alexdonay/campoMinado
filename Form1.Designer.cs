namespace campoMinado
{
    partial class FrmCampoMinado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtColunas = new System.Windows.Forms.TextBox();
            this.txtLinhas = new System.Windows.Forms.TextBox();
            this.txtBombas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtColunas
            // 
            this.txtColunas.Location = new System.Drawing.Point(92, 26);
            this.txtColunas.Name = "txtColunas";
            this.txtColunas.Size = new System.Drawing.Size(60, 20);
            this.txtColunas.TabIndex = 0;
            this.txtColunas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColunas_KeyPress);
            // 
            // txtLinhas
            // 
            this.txtLinhas.Location = new System.Drawing.Point(229, 26);
            this.txtLinhas.Name = "txtLinhas";
            this.txtLinhas.Size = new System.Drawing.Size(60, 20);
            this.txtLinhas.TabIndex = 1;
            this.txtLinhas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLinhas_KeyPress);
            // 
            // txtBombas
            // 
            this.txtBombas.Location = new System.Drawing.Point(373, 26);
            this.txtBombas.Name = "txtBombas";
            this.txtBombas.Size = new System.Drawing.Size(60, 20);
            this.txtBombas.TabIndex = 2;
            this.txtBombas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBombas_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Colunas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Linhas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bombas";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(539, 26);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(45, 23);
            this.btnIniciar.TabIndex = 6;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(710, 26);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(100, 20);
            this.txtTempo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tempo:";
            // 
            // FrmCampoMinado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBombas);
            this.Controls.Add(this.txtLinhas);
            this.Controls.Add(this.txtColunas);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FrmCampoMinado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Campo Minado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtColunas;
        private System.Windows.Forms.TextBox txtLinhas;
        private System.Windows.Forms.TextBox txtBombas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Label label4;
    }
}
