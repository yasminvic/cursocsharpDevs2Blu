using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos
{
    public partial class Form3 : Form
    {
        public CompromissoRepository CompromissoRepository = new CompromissoRepository();
        public EstadosRepository EstadosRepository = new EstadosRepository();
        public EnderecoRepository EnderecoRepository = new EnderecoRepository();
        public ContatoRepository ContatoRepository = new ContatoRepository();
        public Endereco Endereco = new Endereco();
        public Contato Contato = new Contato();
        public Int32 IdContato { get; set; }
        public Int32 IdEndereco { get; set; }
        public Form3()
        {
            InitializeComponent();
            this.IdContato = IdContato;
            this.IdEndereco = IdEndereco; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            PopulaComboUF();
            if (this.IdContato > 0)
            {
                PopulaAlterarContato();
                PopulaAlterarEndereco();
            }
        }

        #region METHODS
        
        private void PopulaAlterarContato()
        {
            MySqlDataReader dataReader = ContatoRepository.GetContato(this.IdContato);
            
            try
            {
                using (dataReader)
                {
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            txtNome.Text = dataReader["nome"].ToString();
                            txtEmail.Text = dataReader["email"].ToString();
                            mskTel.Text = dataReader["telefone"].ToString();
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
        private bool ValidaFormContato()
        {

            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Campo Nome não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Campo E-mail não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Campo Telefone/Celular não foi preenchido", "Cadastro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private Contato CriaContato()
        {
            Contato contato = new Contato();
            string upper = char.ToUpper(txtNome.Text[0]) + txtNome.Text.Substring(1).ToLower();
            contato.Name = upper;
            contato.Email = txtEmail.Text;
            contato.Telefone = mskTel.Text;
            return contato;
        }

        #endregion

        #region EVENTS
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
                    MessageBox.Show("Informe um CEP válido !", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskCEP.Clear();
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        { 
            if (this.IdContato.Equals(0))
            {
                if (ValidaFormContato())
                {
                    //cria contato
                    Contato contato = CriaContato();
                    Endereco endereco = CriaEndereco();
                    

                    //Adiciona no banco de dados
                    var enderecoResult = EnderecoRepository.SalveEndereco(endereco);
                    int idEndereco = enderecoResult.Id;
                    contato.Endereco.Id = idEndereco;
                    ContatoRepository.SalveContato(contato);

                    if (enderecoResult.Id > 0)
                    {
                        MessageBox.Show($"Contato {contato.Endereco.Id} - {contato.Name} salvo com sucesso !", "Adicionar contato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                if (ValidaFormContato())
                {
                    //cria contato
                    Contato contato = CriaContato();
                    Endereco endereco = CriaEndereco();

                    ContatoRepository.UpdateContato(this.IdContato, contato);
                    EnderecoRepository.UpdateEndereco(this.IdEndereco, endereco);
                    MessageBox.Show("Alterações salvas com sucesso !", "Alterar contato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }  
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            mskTel.Clear();
            mskCEP.Clear();
            nmrNum.Value = 0;
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
        }
        #endregion
    }
}
