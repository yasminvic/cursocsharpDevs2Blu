using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System.Globalization;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Interface;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroMedicos : IMenuCadastro
    {

        public CadastroMedicos()
        {

        }

        private void ListarMedicos()
        {
            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine(" *******************************************");
                Console.WriteLine($" Medico: {medico.CodigoMedico}");
                Console.WriteLine($" Nome: {medico.Nome}");
                Console.WriteLine($" CPF: {medico.CGCCPF}");
                Console.WriteLine($" CRM: {medico.CRM}");
                Console.WriteLine($" Especialidade: {medico.Especialidade}");
                Console.WriteLine(" *******************************************\n");
            }
        }

        private void CadastrarMedico()
        {
            //Medico(Int32 codigo, String nome, String cpf, Int32 crm, String especialidade)
            int cod, crm;
            while (true)
            {
                Console.WriteLine("");

                Console.WriteLine("Digite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome == "")
                {
                    Console.WriteLine("\n---Encerrado cadastro de médicos---\n");
                    break;
                }

                Console.WriteLine("Digite seu código: ");
                Int32.TryParse(Console.ReadLine(), out cod);

                Console.WriteLine("Digite seu CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite seu CRM: ");
                Int32.TryParse(Console.ReadLine(), out crm);

                Console.WriteLine("Digite sua especialidade: ");
                string espc = Console.ReadLine();

                Medico medico = new Medico(cod, nome, cpf, crm, espc);

                Program.Mock.ListaMedicos.Add(medico);
            }
        }

        private void AlterarMedicos()
        {

        }

        private void ExcluirMedicos()
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do médico que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
                    Console.WriteLine("\n---Encerrado exclusão de médicos---\n");
                    break;
                }

                foreach (Medico medico in Program.Mock.ListaMedicos)
                {
                    if (cod.Equals(medico.CodigoMedico))
                    {
                        encontrou = true;
                        Program.Mock.ListaMedicos.Remove(medico);
                        Console.WriteLine("Remoção concluída com sucesso !\n");
                        break;
                    }
                }
                if (encontrou == false)
                {
                    Console.WriteLine("Código não encontrado\n");
                }
            }
        }




        public void Cadastrar()
        {
            CadastrarMedico();
        }

        public void Alterar()
        {
            AlterarMedicos();
        }

        public void Excluir()
        {
            ExcluirMedicos();
        }

        public Int32 MenuCadastro()
        {
            Int32 opcao;
            Console.WriteLine(" ------------MENU---------------");
            Console.WriteLine("| 1 - Lista de Médico           |");
            Console.WriteLine("| 2 - Cadastro de Médicos       |");
            Console.WriteLine("| 3 - Alterar Médicos           |");
            Console.WriteLine("| 4 - Excluir Médicos           |");
            Console.WriteLine("| 0 - Sair                      |");
            Console.WriteLine(" -------------------------------");

            Console.WriteLine("Escolha uma das opções do menu: ");
            Int32.TryParse(Console.ReadLine(), out opcao);
            return opcao;
        }

        public void Listar()
        {
            ListarMedicos();
        }

    }
}
