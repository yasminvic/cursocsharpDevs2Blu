using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //comentário de linha control k + control c

            /* comentário em bloco, control + shift + ;*/


            //declaração de variável
            string nomeUsuario, cidadeUsuario;
            string  formatacaoDados = "Inicialização de variável...\n"; // variavel do tipo primitivo string


            //aspas simples = char
            //aspas duplas = string

            //nomeUsuario = "Yasmin Victória Alves de Souza";

            /* formatacaoDados = nomeUsuario + ", sua cidade é " + cidadeUsuario;
             Console.WriteLine(formatacaoDados);*/


            //Console.WriteLine("Seja bem-vida, " + nomeUsuario + "!");


            //Entrada de dados

            //nome do usuário
            Console.Write("Digite seu nome: "); // printar o "input"
            nomeUsuario = Console.ReadLine(); // input


                //cidade do usuário
            Console.Write("Digite sua cidade: ");
            cidadeUsuario = Console.ReadLine();


            //Processamento
                // Boas vindas (nome)
            formatacaoDados += "Seja bem-vinda, " + nomeUsuario + "!"; //concatenar é com +

            // Cidade do usuário
            formatacaoDados += $"{nomeUsuario}, sua cidade é {cidadeUsuario}"; 
            // $ e @ é o f do python


            //Apresentação dos dados
            Console.WriteLine(formatacaoDados);

            //Console é uma classe
            Console.WriteLine("Hello, World!"); // printa e pula linha
            var input = Console.ReadLine(); 


        }
    }
}
