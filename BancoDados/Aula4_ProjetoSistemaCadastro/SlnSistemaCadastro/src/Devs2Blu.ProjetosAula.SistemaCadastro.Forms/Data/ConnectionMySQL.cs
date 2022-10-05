﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Forms.Data
{
    public class ConnectionMySQL
    {
        public static String ConectionString { get; set; }
        public static String Server { get; set; }
        public static String DataBase { get; set; }
        public static String User { get; set; }
        public static String Password { get; set; }
               
        public static MySqlConnection GetConnection() //esse metodo vai retornar um mysqlConnecton
        {
            //credenciais 
            Server = "localhost";
            DataBase = "sistemacadastro"; //nome do banco de dados
            User = "root";
            Password = "root";
            ConectionString = $"Persist Security Info=False;server={Server};database={DataBase};uid={User};server={Server};database={DataBase};uid={User};pwd='{Password}'";
            var conn = new MySqlConnection(ConectionString);//retorna tipo mysqlConnection

            //vai tentar conectar o mysql
            try
            {
                conn.Open();
            }
            //se não vai mostrar mensagem de erro
            catch (MySqlException myex)
            {
                MessageBox.Show(myex.Message, "Erro ao Conectar");
                throw;
            }

            return conn;
        }
    }
}
