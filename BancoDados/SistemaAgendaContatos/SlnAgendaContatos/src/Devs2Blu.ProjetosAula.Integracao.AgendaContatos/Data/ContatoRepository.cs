using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data
{
    public class ContatoRepository
    {
        public Contato SalveContato(Contato contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_CONTATO, conn);
                cmd.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = contato.Endereco.Id;
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 45).Value = contato.Name;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 45).Value = contato.Telefone;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 45).Value = contato.Email;
                cmd.Parameters.Add("@flstatus", MySqlDbType.Enum).Value = contato.Status;
                cmd.ExecuteNonQuery();
                return contato;

            }catch (MySqlException myex)
            {
                MessageBox.Show(myex.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void DeleteContato(Int32 id_contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_CONTATO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_contato;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Delete todos os compromissos relacionados a esse contato para excluí-lo", "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void UpdateContato(Int32 id_contato, Contato contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_CONTATO, conn);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = contato.Name;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 15).Value = contato.Telefone;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 150).Value = contato.Email;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_contato;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public MySqlDataReader GetContato(Int32 id_contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_CONTATO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_contato;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public MySqlDataReader FetchAll()
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_ALL, conn);
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
        private const String SQL_INSERT_CONTATO = @"INSERT INTO contatos    
                                                                        (id_endereco,
                                                                        nome,
                                                                        telefone,
                                                                        email,
                                                                        flstatus)
                                                                        VALUES
                                                                        (@id_endereco,
                                                                        @nome,
                                                                        @telefone,
                                                                        @email,
                                                                        @flstatus);";
        private const String SQL_SELECT_CONTATO = @"SELECT  nome, 
                                                            email,
                                                            telefone
                                                    FROM contatos WHERE id=@id";
        private const String SQL_SELECT_ALL = @"SELECT  c.id AS ID,
                                                        c.id_endereco AS IDE,
                                                        c.nome AS Nome,
                                                        c.email AS Email,
                                                        c.telefone AS TelCel,
                                                        e.cep AS CEP,
                                                        e.rua AS Rua,
                                                        e.numero AS Num,
                                                        e.bairro AS Bairro,
                                                        e.cidade AS Cidade,
                                                        e.uf AS UF
                                                FROM endereco e
                                                INNER JOIN contatos c ON e.id = c.id_endereco";
        private const String SQL_DELETE_CONTATO = @"DELETE FROM contatos WHERE id=@id";
        private const String SQL_UPDATE_CONTATO = @"UPDATE contatos SET nome=@nome,
                                                                        email=@email,
                                                                        telefone=@telefone
                                                    WHERE id=@id";
        #endregion
    }
}
