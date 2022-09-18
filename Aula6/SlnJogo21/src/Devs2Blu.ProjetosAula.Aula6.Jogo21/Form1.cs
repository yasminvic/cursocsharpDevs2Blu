using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Aula6.Jogo21
{
    public partial class Form1 : Form
    {
        decimal numPlayer1;
        decimal numPlayer2;
        decimal pontosP1 = 0;
        decimal pontosP2 = 0;
        short rodada = 1;
        public Form1()
        {
            InitializeComponent();
            //decimal numPlayer1;
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            //habilitando e desabilitando botões
            gbPlayer1.Visible = true;
            gbPlayer2.Visible = true;
            btnRodada.Visible = true;
            btnJogar.Visible = false;
            btnNovo.Enabled = true;
            btnPlayer1.Enabled = true;

            //atualizando o tabuleiro
            txtTabuleiro.Text = $"Rodada {rodada}\r\n";
            txtTabuleiro.Text += @"            Escolha um número entre 1 e 20      ";
        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            //numero do player 1
            numPlayer1 = nmrPlayer1.Value;

            txtPlayer1.Text = $"O jogador 1 escolheu o número {numPlayer1}";
            txtTabuleiro.Text += @"

Aguardando o jogador 2...";

            //desabilitando botões
            btnPlayer1.Enabled = false;
            btnRodada.Enabled = false;
            btnPlayer2.Enabled = true;
        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            //atualizando o txt do player 2
            numPlayer2 = nmrPlayer2.Value;
            txtPlayer2.Text = $"O jogador 2 escolheu o número {numPlayer2}";

            //gerando numero aleatorio
            Random rd = new Random();
            int numAle = rd.Next(1, 20);
            txtTabuleiro.Text = $"O número sorteado foi: {numAle}";


            //somando números
            numPlayer1 += numAle;
            numPlayer2 += numAle;

            //calculando pontos
            txtTabuleiro.Text += "\r\nCalculando os pontos...";           
            pontosP1 += CalcularPontos(numPlayer1);
            pontosP2 += CalcularPontos(numPlayer2);
            Thread.Sleep(2000);
            txtPlayer1.Text += $"\r\n\r\nSua pontuação foi {CalcularPontos(numPlayer1)}";
            txtPlayer1.Text += $"\r\n\r\nPontuação atual: {pontosP1}";
            txtPlayer2.Text += $"\r\n\r\nSua pontuação foi {CalcularPontos(numPlayer2)}";
            txtPlayer2.Text += $"\r\n\r\nPontuação atual: {pontosP2}";

            btnPlayer2.Enabled = false;
            btnRodada.Enabled = true;
        }

        private void btnRodada_Click(object sender, EventArgs e)
        {
            //contador
            rodada++;

            //habilitando botões
            btnPlayer1.Enabled = true;
            btnPlayer2.Enabled = true;

            //limpar telas
            txtTabuleiro.Text = $"Rodada {rodada}";
            txtTabuleiro.Text += "\r\n           Escolha um número entre 1 e 20";
            txtPlayer1.Text = "";
            txtPlayer2.Text = "";
            
            if (rodada == 4)
            {
                btnRodada.Enabled = false;
                btnPlayer1.Enabled = false;
                btnPlayer2.Enabled = false;
                VerificaGanhador();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            pontosP1 = 0;
            pontosP2 = 0;
            rodada = 1;
            txtPlayer1.Text = "";
            txtPlayer2.Text = "";
            txtTabuleiro.Text = "Seja bem vindo (a) ao jogo";
            txtTabuleiro.Text += "\r\nClique no botão jogar para Iniciar o jogo.";
            btnJogar.Visible = true;
            btnRodada.Visible = false;
            btnNovo.Enabled = false;
        }

        private void VerificaGanhador()
        {
            if (pontosP1 > pontosP2)
            {
                txtTabuleiro.Text = $"              PLAYER 1 VENCEU !!! \r\n\r\nO jogador 1 venceu com {pontosP1} pontos";
                txtTabuleiro.Text += $"\r\nO jogador 2 perdeu com {pontosP2}";
            }else if(pontosP1 < pontosP2)
            {
                txtTabuleiro.Text = $"              PLAYER 2 VENCEU !!! \r\n\r\nO jogador 2 venceu com {pontosP2} pontos";
                txtTabuleiro.Text += $"\r\nO jogador 1 perdeu com {pontosP1}";
            }
            else
            {
                txtTabuleiro.Text = $"              EMPATE !!! \r\n\r\nAmbos fizeram {pontosP1} pontos";
            }
        }

        private decimal CalcularPontos(decimal num)
        {
            decimal pontos = 0, numero = num;

            switch (numero)
            {
                case 7:
                    pontos = 10;
                    break;

                case 14:
                    pontos = 20;
                    break;

                case 21:
                    pontos = 30;
                    break;

                case decimal i when (i >= 1 && i <= 6):
                    pontos = 1;
                    break;

                case decimal i when (i >= 8 && i <= 13):
                    pontos = 5;
                    break;

                case decimal i when (i >= 15 && i <= 20):
                    pontos = 6;
                    break;

                default:
                    break;
            }

            return pontos;
        }
    }
}
