using Devs2Blu.ProjetosAula.SistemaCadastro.Forms.Data;
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

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Forms
{
    public partial class Form1 : Form
    {
        public MySqlConnection Conn { get; set; }
        public ConvenioRepository ConvenioRepository = new ConvenioRepository();    //declarando uma proprienda e já instanciando ela
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region TesteConexao
            /*Conn = ConnectionMySQL.GetConnection();

            if (Conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Conexão efetuada com sucesso !", "Conexão ao MySQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Conn.Close();
            }  */
            #endregion
            PopulaComboConvenio();
        }

        #region Metodos

        private void PopulaComboConvenio()
        {
            var listConvenios = ConvenioRepository.FetchAll();// chamando metodo da classe ConvenioRepository

            while (listConvenios.Read())//enquanto tiver conteudo ele vai ler
            {
                //insert insere um indice e um objeto
                cboConvenio.Items.Add(listConvenios.GetString("nome"));//vai add um item no combo, pegando o nome do convenio(dentro do parenteses)

            }
        }

        #endregion

        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFisica.Checked)
            {
                lblCGCCPF.Text = "CPF";
                lblCGCCPF.Visible = true;
            }
        }

        private void rbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJuridica.Checked)
            {
                lblCGCCPF.Text = "CNPJ";
                lblCGCCPF.Visible = true;
            }          
        }
    }
}
