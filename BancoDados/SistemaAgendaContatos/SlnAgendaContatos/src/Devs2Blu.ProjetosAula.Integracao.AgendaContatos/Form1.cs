using Correios;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos
{
    public partial class Form1 : Form
    {
        public CompromissoRepository CompromissoRepository = new CompromissoRepository();
        public EstadosRepository EstadosRepository = new EstadosRepository();
        public EnderecoRepository EnderecoRepository = new EnderecoRepository();
        public ContatoRepository ContatoRepository = new ContatoRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region METHODS
        private void PopulaGridContato()
        {
            var listContato = ContatoRepository.FetchAll();
            gridContato.DataSource = new BindingSource(listContato, null);
            gridContato.Columns[4].Visible = false;
        }
        private void PopulaGridCompromisso()
        {
            var listCompromisso = CompromissoRepository.FetchAll();
            gridCompromisso.DataSource = new BindingSource(listCompromisso, null);
            gridCompromisso.Columns[2].Visible = false;
            gridCompromisso.Columns[4].Visible = false;
        }
        #endregion

        #region EVENTS
        private void Form1_Activated(object sender, EventArgs e)
        {
            PopulaGridContato();
            PopulaGridCompromisso();
        }

        private void gridContato_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id do usuário
            var idContato = Convert.ToInt32(gridContato.Rows[gridContato.CurrentCell.RowIndex].Cells[3].Value);
            //id do endereco
            var idEndereco = Convert.ToInt32(gridContato.Rows[gridContato.CurrentCell.RowIndex].Cells[4].Value);

            if (gridContato.Columns[e.ColumnIndex].Name == "btnAdd")
            {
                Form2 form2 = new Form2();
                form2.IdContato = idContato;
                form2.Show();
            }

            if ((gridContato.Columns[e.ColumnIndex].Name == "btnDelete"))
            {  
                //Excluir Contato;
                ContatoRepository.DeleteContato(idContato);

                //Excluir Endereco;
                EnderecoRepository.DeleteEndereco(idEndereco);
                MessageBox.Show("Exclusão realizada com sucesso !", "Deletar Contato", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if ((gridContato.Columns[e.ColumnIndex].Name == "btnAlterar"))
            {
                Form3 form3 = new Form3();
                form3.IdContato = idContato;
                form3.IdEndereco = idEndereco;
                form3.Show();
            }
        }
        private void gridCompromisso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id do usuário
            var idCompromisso = Convert.ToInt32(gridCompromisso.Rows[gridCompromisso.CurrentCell.RowIndex].Cells[2].Value);
            //id do endereco
            var idEndereco = Convert.ToInt32(gridCompromisso.Rows[gridCompromisso.CurrentCell.RowIndex].Cells[4].Value);

            if (gridCompromisso.Columns[e.ColumnIndex].Name == "btnExcluir")
            {
                //Excluir Compromisso;
                CompromissoRepository.DeleteCompromisso(idCompromisso, 0);

                //Excluir Endereco;
                EnderecoRepository.DeleteEndereco(idEndereco);
                MessageBox.Show("Exclusão realizada com sucesso !", "Deletar Compromisso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if ((gridCompromisso.Columns[e.ColumnIndex].Name == "btnUpdate"))
            {
                Form2 form2 = new Form2();
                form2.IdCompromisso = idCompromisso;
                form2.IdEndereco = idEndereco;
                form2.Show();
            }
        }

        private void btnAddContato_Click(object sender, EventArgs e)
        { 
            Form3 form3 = new Form3();
            form3.Show();
        }
        #endregion
    }
}
