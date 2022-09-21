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

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {

        }

        private void PegarValor()
        {
            Contato.Nome = txtNome.Text;
            Contato.TelCel = txtTel.Text;
            Contato.Email = txtEmail.Text;
            Contato.CEP = txtCEP.Text;
        }
    }
}
