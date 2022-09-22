using Devs2Blu.ProjetosAula.AulaOOP2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.AulaOOP2
{
    public partial class Form1 : Form
    {
        public Contato Contato { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Contato = new Contato();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (ValidaForm() == false)
            {
                MessageBox.Show(this, "Preencha todos os campo!", "Erro - Formulário incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PegarValor();
            MessageBox.Show(this, "Formulário enviado com sucesso !", "Envio de dados");
            Limpar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            //89055 550

            if (txtCEP.Text.Length == 8)
            {
                txtRua.Text = "Roseli Rosani Burkartdh";
                txtBairro.Text = "Fortaleza";
                txtCid.Text = "Blumenau";
                txtEst.Text = "Santa Catarina";
            }
        }

        private void PegarValor()
        {
            Contato.Nome = txtNome.Text;
            Contato.TelCel = txtTel.Text;
            Contato.Email = txtEmail.Text;
            Contato.CEP = txtCEP.Text;
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtCEP.Clear();
            txtEst.Clear();
            txtRua.Clear();
            txtNum.Clear();
            txtCid.Clear();
            txtBairro.Clear();
            txtEst.Clear();

        }

       private bool ValidaForm()
        {
            if (txtNome.Text.Equals(""))
            {
                return false;
            }if (txtTel.Text.Equals(""))
            {
                return false;
            }
            if (txtEmail.Text.Equals(""))
            {
                return false;
            }
            if (txtCEP.Text.Equals(""))
            {
                return false;
            }if (txtNum.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        
    }
}
