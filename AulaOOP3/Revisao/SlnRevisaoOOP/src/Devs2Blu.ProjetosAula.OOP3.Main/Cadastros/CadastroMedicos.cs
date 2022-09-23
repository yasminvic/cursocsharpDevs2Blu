using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System.Globalization;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroMedicos 
    {
        public CadastroMedicos()
        {

        }

        public void MenuMedicos()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine(" ------------MENU---------------");
                Console.WriteLine("| 1 - Lista de Médico           |");
                Console.WriteLine("| 2 - Cadastro de Médicos       |");
                Console.WriteLine("| 3 - Alterar Médicos           |");
                Console.WriteLine("| 4 - Excluir Médicos           |");
                Console.WriteLine("| 0 - Sair                      |");
                Console.WriteLine(" -------------------------------");

                Console.WriteLine("Escolha uma das opções do menu: ");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuEnum.LISTAR:
                        ListarMedicos();
                        break;

                    case (int)MenuEnum.CADASTRO:
                        CadastrarMedico();
                        break;

                    case (int)MenuEnum.EXCLUIR:
                        ExcluirMedicos();
                        break;

                    default:
                        break;

                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));
        }

        public void ListarMedicos()
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

        public void CadastrarMedico()
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

        public void AlterarMedicos()
        {

        }

        public void ExcluirMedicos()
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do médico que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
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
    }
}
