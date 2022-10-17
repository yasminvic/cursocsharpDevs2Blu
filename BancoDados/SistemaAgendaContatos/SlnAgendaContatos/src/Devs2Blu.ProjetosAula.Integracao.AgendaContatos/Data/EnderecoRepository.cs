using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data
{
    
    public class EnderecoRepository
    {

        public Endereco SalveEndereco(Endereco endereco)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_ENDERECO, conn);
                cmd.Parameters.Add("@cep", MySqlDbType.VarChar, 10).Value = endereco.CEP;
                cmd.Parameters.Add("@rua", MySqlDbType.VarChar, 45).Value = endereco.Rua;
                cmd.Parameters.Add("@numero", MySqlDbType.VarChar, 45).Value = endereco.Numero;
                cmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 45).Value = endereco.Bairro;
                cmd.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = endereco.UF;
                cmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 45).Value = endereco.Cidade;
                cmd.ExecuteNonQuery();
                endereco.Id = (Int32)cmd.LastInsertedId;
                return endereco;
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }        
        }
        public void DeleteEndereco(Int32 id_endereco)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_ENDERECO, conn);
                cmd.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = id_endereco;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void UpdateEndereco(Int32 id, Endereco endereco)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_ENDERECO, conn);
                cmd.Parameters.Add("@cep", MySqlDbType.VarChar, 10).Value = endereco.CEP;
                cmd.Parameters.Add("@numero", MySqlDbType.Int32).Value = endereco.Numero;
                cmd.Parameters.Add("@rua", MySqlDbType.VarChar, 150).Value = endereco.Rua;
                cmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 45).Value = endereco.Bairro;
                cmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 45).Value = endereco.Cidade;
                cmd.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = endereco.UF;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public MySqlDataReader GetEndereco(Int32 id_contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_ENDERECO, conn);
                cmd.Parameters.Add("@id_contato", MySqlDbType.Int32).Value = id_contato;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_INSERT_ENDERECO = @"INSERT INTO endereco    
                                                                        (cep,
                                                                        rua,
                                                                        numero,
                                                                        bairro,
                                                                        uf,
                                                                        cidade)
                                                                        VALUES
                                                                        (@cep,
                                                                        @rua,
                                                                        @numero,
                                                                        @bairro,
                                                                        @uf,
                                                                        @cidade);";
        private const String SQL_DELETE_ENDERECO = @"DELETE FROM endereco WHERE id=@id_endereco";
        private const String SQL_SELECT_ENDERECO = @"SELECT  cep, 
                                                            rua,
                                                            numero,
                                                            bairro,
                                                            cidade,
                                                            uf
                                                    FROM endereco WHERE id=@id_contato";
        private const String SQL_UPDATE_ENDERECO = @"UPDATE endereco SET cep=@cep,
                                                                        numero=@numero,
                                                                        rua=@rua,
                                                                        bairro=@bairro,
                                                                        cidade=@cidade,
                                                                        uf=@uf
                                                    WHERE id=@id";
        #endregion
    }
}
