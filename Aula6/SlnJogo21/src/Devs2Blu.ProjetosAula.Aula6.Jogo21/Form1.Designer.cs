namespace Devs2Blu.ProjetosAula.Aula6.Jogo21
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTabuleiro = new System.Windows.Forms.TextBox();
            this.gbPlayer1 = new System.Windows.Forms.GroupBox();
            this.btnPlayer1 = new System.Windows.Forms.Button();
            this.nmrPlayer1 = new System.Windows.Forms.NumericUpDown();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.gbPlayer2 = new System.Windows.Forms.GroupBox();
            this.btnPlayer2 = new System.Windows.Forms.Button();
            this.nmrPlayer2 = new System.Windows.Forms.NumericUpDown();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.btnJogar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRodada = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlayer1)).BeginInit();
            this.gbPlayer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.txtTabuleiro);
            this.groupBox1.Location = new System.Drawing.Point(188, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jogo do 21 - Tabuleiro";
            // 
            // txtTabuleiro
            // 
            this.txtTabuleiro.BackColor = System.Drawing.Color.Crimson;
            this.txtTabuleiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTabuleiro.ForeColor = System.Drawing.SystemColors.Info;
            this.txtTabuleiro.Location = new System.Drawing.Point(28, 32);
            this.txtTabuleiro.Multiline = true;
            this.txtTabuleiro.Name = "txtTabuleiro";
            this.txtTabuleiro.ReadOnly = true;
            this.txtTabuleiro.Size = new System.Drawing.Size(346, 122);
            this.txtTabuleiro.TabIndex = 0;
            this.txtTabuleiro.Text = "Seja bem vindo (a) ao Jogo do 21 !\r\nClique no botão Jogar para começar.";
            // 
            // gbPlayer1
            // 
            this.gbPlayer1.BackColor = System.Drawing.Color.Silver;
            this.gbPlayer1.Controls.Add(this.btnPlayer1);
            this.gbPlayer1.Controls.Add(this.nmrPlayer1);
            this.gbPlayer1.Controls.Add(this.txtPlayer1);
            this.gbPlayer1.Location = new System.Drawing.Point(31, 220);
            this.gbPlayer1.Name = "gbPlayer1";
            this.gbPlayer1.Size = new System.Drawing.Size(232, 209);
            this.gbPlayer1.TabIndex = 1;
            this.gbPlayer1.TabStop = false;
            this.gbPlayer1.Text = "Player1";
            this.gbPlayer1.Visible = false;
            // 
            // btnPlayer1
            // 
            this.btnPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer1.Location = new System.Drawing.Point(125, 175);
            this.btnPlayer1.Name = "btnPlayer1";
            this.btnPlayer1.Size = new System.Drawing.Size(91, 23);
            this.btnPlayer1.TabIndex = 2;
            this.btnPlayer1.Text = "Enviar";
            this.btnPlayer1.UseVisualStyleBackColor = false;
            this.btnPlayer1.Click += new System.EventHandler(this.btnPlayer1_Click);
            // 
            // nmrPlayer1
            // 
            this.nmrPlayer1.Location = new System.Drawing.Point(16, 178);
            this.nmrPlayer1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmrPlayer1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPlayer1.Name = "nmrPlayer1";
            this.nmrPlayer1.Size = new System.Drawing.Size(67, 20);
            this.nmrPlayer1.TabIndex = 1;
            this.nmrPlayer1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.BackColor = System.Drawing.Color.Crimson;
            this.txtPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer1.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPlayer1.Location = new System.Drawing.Point(16, 31);
            this.txtPlayer1.Multiline = true;
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.ReadOnly = true;
            this.txtPlayer1.Size = new System.Drawing.Size(200, 126);
            this.txtPlayer1.TabIndex = 0;
            // 
            // gbPlayer2
            // 
            this.gbPlayer2.BackColor = System.Drawing.Color.Silver;
            this.gbPlayer2.Controls.Add(this.btnPlayer2);
            this.gbPlayer2.Controls.Add(this.nmrPlayer2);
            this.gbPlayer2.Controls.Add(this.txtPlayer2);
            this.gbPlayer2.Location = new System.Drawing.Point(500, 220);
            this.gbPlayer2.Name = "gbPlayer2";
            this.gbPlayer2.Size = new System.Drawing.Size(232, 209);
            this.gbPlayer2.TabIndex = 2;
            this.gbPlayer2.TabStop = false;
            this.gbPlayer2.Text = "Player 2";
            this.gbPlayer2.Visible = false;
            // 
            // btnPlayer2
            // 
            this.btnPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer2.Location = new System.Drawing.Point(127, 175);
            this.btnPlayer2.Name = "btnPlayer2";
            this.btnPlayer2.Size = new System.Drawing.Size(91, 23);
            this.btnPlayer2.TabIndex = 2;
            this.btnPlayer2.Text = "Enviar";
            this.btnPlayer2.UseVisualStyleBackColor = false;
            this.btnPlayer2.Click += new System.EventHandler(this.btnPlayer2_Click);
            // 
            // nmrPlayer2
            // 
            this.nmrPlayer2.Location = new System.Drawing.Point(21, 178);
            this.nmrPlayer2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmrPlayer2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPlayer2.Name = "nmrPlayer2";
            this.nmrPlayer2.Size = new System.Drawing.Size(67, 20);
            this.nmrPlayer2.TabIndex = 1;
            this.nmrPlayer2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.BackColor = System.Drawing.Color.Crimson;
            this.txtPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer2.ForeColor = System.Drawing.Color.White;
            this.txtPlayer2.Location = new System.Drawing.Point(18, 31);
            this.txtPlayer2.Multiline = true;
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.ReadOnly = true;
            this.txtPlayer2.Size = new System.Drawing.Size(200, 126);
            this.txtPlayer2.TabIndex = 0;
            // 
            // btnJogar
            // 
            this.btnJogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnJogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogar.Location = new System.Drawing.Point(342, 230);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(75, 23);
            this.btnJogar.TabIndex = 3;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(342, 285);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "Novo Jogo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnRodada
            // 
            this.btnRodada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRodada.Enabled = false;
            this.btnRodada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRodada.Location = new System.Drawing.Point(342, 341);
            this.btnRodada.Name = "btnRodada";
            this.btnRodada.Size = new System.Drawing.Size(75, 36);
            this.btnRodada.TabIndex = 5;
            this.btnRodada.Text = "Próxima rodada";
            this.btnRodada.UseVisualStyleBackColor = false;
            this.btnRodada.Visible = false;
            this.btnRodada.Click += new System.EventHandler(this.btnRodada_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
            this.Controls.Add(this.btnRodada);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.gbPlayer2);
            this.Controls.Add(this.gbPlayer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPlayer1.ResumeLayout(false);
            this.gbPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlayer1)).EndInit();
            this.gbPlayer2.ResumeLayout(false);
            this.gbPlayer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTabuleiro;
        private System.Windows.Forms.GroupBox gbPlayer1;
        private System.Windows.Forms.Button btnPlayer1;
        private System.Windows.Forms.NumericUpDown nmrPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.GroupBox gbPlayer2;
        private System.Windows.Forms.Button btnPlayer2;
        private System.Windows.Forms.NumericUpDown nmrPlayer2;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnRodada;
    }
}

