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
    public class CompromissoRepository
    {
        public Compromisso SalveCompromisso(Compromisso compromisso)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_COMPROMISSO, conn);
                cmd.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = compromisso.Endereco.Id;
                cmd.Parameters.Add("@id_contatos", MySqlDbType.Int32).Value = compromisso.Contato.Id;
                cmd.Parameters.Add("@titulo", MySqlDbType.VarChar, 45).Value = compromisso.Titulo;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 255).Value = compromisso.Descricao;
                cmd.Parameters.Add("@data_inicio", MySqlDbType.DateTime).Value = compromisso.DataInicio;
                cmd.Parameters.Add("@data_fim", MySqlDbType.DateTime).Value = compromisso.DataFim;
                cmd.Parameters.Add("@flstatus", MySqlDbType.Enum).Value = compromisso.Status;
                cmd.ExecuteNonQuery();
                return compromisso;
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void DeleteCompromisso(Int32 id, Int32 id_contato)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_COMPROMISSO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@id_contato", MySqlDbType.Int32).Value = id_contato;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public MySqlDataReader GetCompromisso(Int32 id_compromisso)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_COMPROMISSO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_compromisso;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            catch (MySqlException myexc)
            {
                MessageBox.Show(myexc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void UpdateCompromisso(Int32 id_compromisso, Compromisso compromisso)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_COMPROMISSO, conn);
                cmd.Parameters.Add("@titulo", MySqlDbType.VarChar, 45).Value = compromisso.Titulo;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 255).Value = compromisso.Descricao;
                cmd.Parameters.Add("@data_inicio", MySqlDbType.DateTime).Value = compromisso.DataInicio;
                cmd.Parameters.Add("@data_fim", MySqlDbType.DateTime).Value = compromisso.DataFim;
                cmd.Parameters.Add("@id_compromisso", MySqlDbType.Int32).Value = id_compromisso;

                cmd.ExecuteNonQuery();
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
        private const String SQL_INSERT_COMPROMISSO = @"INSERT INTO compromissos   
                                                                        (id_endereco,
                                                                        id_contatos,
                                                                        titulo,
                                                                        descricao,
                                                                        data_inicio,
                                                                        data_fim,
                                                                        flstatus)
                                                                        VALUES
                                                                        (@id_endereco,
                                                                        @id_contatos,
                                                                        @titulo,
                                                                        @descricao,
                                                                        @data_inicio,
                                                                        @data_fim,
                                                                        @flstatus);";

        private const String SQL_SELECT_ALL = @"SELECT  comp.id AS IDCOMP,
                                                                comp.id_contatos AS ID,
                                                                comp.id_endereco AS IDE,
                                                                comp.titulo AS Titulo,
                                                                comp.descricao AS Descricao,
                                                                comp.data_inicio as Inicio,
                                                                comp.data_fim as Fim,
                                                                e.cep AS CEP,
                                                                e.rua AS Rua,
                                                                e.numero AS Num,
                                                                e.bairro AS Bairro,
                                                                e.cidade AS Cidade,
                                                                e.uf AS UF
                                                        FROM endereco e
                                                        INNER JOIN compromissos comp ON e.id = comp.id_endereco";
        private const String SQL_DELETE_COMPROMISSO = @"DELETE FROM compromissos WHERE id = @id or id_contatos = @id_contato";
        private const String SQL_SELECT_COMPROMISSO = @"SELECT  titulo, 
                                                                descricao,
                                                                data_inicio,
                                                                data_fim
                                                        FROM compromissos WHERE id=@id";
        private const String SQL_UPDATE_COMPROMISSO = @"UPDATE compromissos SET titulo=@titulo,
                                                                        descricao=@descricao,
                                                                        data_inicio = @data_inicio,
                                                                        data_fim=@data_fim
                                                    WHERE id=@id_compromisso";
        #endregion
    }
}
