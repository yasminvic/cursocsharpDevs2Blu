using Correios;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        
        public EstadosRepository EstadosRepository = new EstadosRepository();
        public EnderecoRepository EnderecoRepository = new EnderecoRepository();
        public CompromissoRepository CompromissoRepository = new CompromissoRepository();
        public Int32 IdContato { get; set; }
        public Int32 IdCompromisso { get; set; }
        public Int32 IdEndereco { get; set; }
        public Form2()
        {    
            InitializeComponent();
            this.IdCompromisso = IdCompromisso;
            this.IdEndereco = IdEndereco;
            this.IdContato = IdContato;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            PopulaAlterarEndereco();
            PopulaAlterarCompromisso();
        }

        #region METHODS 
        private void PopulaAlterarCompromisso()
        {
            MySqlDataReader dataReaderCompromisso = CompromissoRepository.GetCompromisso(this.IdCompromisso);
            try
            {
                using (dataReaderCompromisso)
                { 
                    if (dataReaderCompromisso.HasRows)
                    {
                        if (dataReaderCompromisso.Read())
                        {
                            txtTitulo.Text = dataReaderCompromisso["titulo"].ToString();
                            txtDescricao.Text = dataReaderCompromisso["descricao"].ToString();
                            timeInicio.Text = dataReaderCompromisso["data_inicio"].ToString();
                            timeFim.Text = dataReaderCompromisso["data_fim"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void PopulaAlterarEndereco()
        {
            MySqlDataReader dataReaderEndereco = EnderecoRepository.GetEndereco(this.IdEndereco);
            try
            {
                using (dataReaderEndereco)
                {
                    if (dataReaderEndereco.HasRows)
                    {
                        if (dataReaderEndereco.Read())
                        {
                            mskCEP.Text = dataReaderEndereco["cep"].ToString();
                            nmrNum.Value = Int32.Parse(dataReaderEndereco["numero"].ToString());
                            txtRua.Text = dataReaderEndereco["rua"].ToString();
                            txtBairro.Text = dataReaderEndereco["bairro"].ToString();
                            txtCidade.Text = dataReaderEndereco["cidade"].ToString();
                            cboUF.Text = dataReaderEndereco["uf"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private bool ValidaFormCompromisso()
            {

                if (txtTitulo.Text.Equals(""))
                {
                    MessageBox.Show("Campo Título não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtDescricao.Text.Equals(""))
                {
                    MessageBox.Show("Campo Descrição não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (timeInicio.Text.Equals(""))
                {
                    MessageBox.Show("Campo Data Início não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (timeFim.Text.Equals(""))
                {
                    MessageBox.Show("Campo Data Fim não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (mskCEP.Text.Equals(""))
                {
                    MessageBox.Show("Campo CEP não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (nmrNum.Text.Equals(""))
                {
                    MessageBox.Show("Campo Numéro não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtRua.Text.Equals(""))
                {
                    MessageBox.Show("Campo Rua não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtBairro.Text.Equals(""))
                {
                    MessageBox.Show("Campo Bairro não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtCidade.Text.Equals(""))
                {
                    MessageBox.Show("Campo Cidade não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cboUF.SelectedIndex == -1)
                {
                    MessageBox.Show("Campo UF não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }

        private void PopulaComboUF()
        {
            var listConvenios = EstadosRepository.FetchAll();
            cboUF.DataSource = new BindingSource(listConvenios, null);
            cboUF.DisplayMember = "uf";
            cboUF.ValueMember = "id";
        }
        private Compromisso CriaCompromisso()
        {
            Compromisso compromisso = new Compromisso();
            compromisso.Contato.Id = this.IdContato;
            compromisso.Titulo = txtTitulo.Text;
            compromisso.Descricao = txtDescricao.Text;
            compromisso.DataInicio = timeInicio.Value;
            compromisso.DataFim = timeFim.Value;
            return compromisso;
        }
        private Endereco CriaEndereco()
        {
            Endereco endereco = new Endereco();
            endereco.CEP = mskCEP.Text.Replace(',', '.');
            endereco.Rua = txtRua.Text;
            endereco.Numero = Convert.ToInt32(nmrNum.Value);
            endereco.Bairro = txtBairro.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.UF = cboUF.Text;
            return endereco;
        }
        #endregion

        #region EVENTS
        private void btnSalvarComp_Click(object sender, EventArgs e)
        {
            if (this.IdCompromisso.Equals(0))
            {
                if (ValidaFormCompromisso())
                {
                    //cria compromisso
                    Endereco endereco = CriaEndereco();
                    Compromisso compromisso = CriaCompromisso();

                    //Adiciona no banco de dados
                    var enderecoResult = EnderecoRepository.SalveEndereco(endereco);
                    int idEndereco = enderecoResult.Id;
                    compromisso.Endereco.Id = idEndereco;
                    CompromissoRepository.SalveCompromisso(compromisso);

                    if (enderecoResult.Id > 0)
                    {
                        MessageBox.Show($"Compromisso {compromisso.Titulo} salvo com sucesso !", "Adicionar compromisso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                if (ValidaFormCompromisso())
                {
                    //cria compromisso
                    Endereco endereco = CriaEndereco();
                    Compromisso compromisso = CriaCompromisso();

                    CompromissoRepository.UpdateCompromisso(this.IdCompromisso, compromisso);
                    EnderecoRepository.UpdateEndereco(this.IdEndereco, endereco);
                    MessageBox.Show("Alterações salvas com sucesso !", "Alterar compromisso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            PopulaComboUF();
        }

        private void mskCEP_TextChanged(object sender, EventArgs e)
        {
            //Preencher endereço
            if (mskCEP.Text.Length.Equals(10))
            {
                try
                {
                    CorreiosApi correiosApi = new CorreiosApi();
                    var retornar = correiosApi.consultaCEP(mskCEP.Text);
                    txtRua.Text = retornar.end;
                    txtBairro.Text = retornar.bairro;
                    txtCidade.Text = retornar.cidade;
                    cboUF.Text = retornar.uf;
                    nmrNum.Value = 0;
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe um CEP válido", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskCEP.Clear();
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            txtDescricao.Clear();
            mskCEP.Clear();
            nmrNum.Value = 0;
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
        }
        #endregion
    }
}

