using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroFornecedor
    {
        public CadastroFornecedor()
        {

        }

        public void MenuFornecedor()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine(" ------------MENU---------------");
                Console.WriteLine("| 1 - Lista de Pacientes        |");
                Console.WriteLine("| 2 - Cadastro de Pacientes     |");
                Console.WriteLine("| 3 - Alterar Pacientes         |");
                Console.WriteLine("| 4 - Excluir Pacientes         |");
                Console.WriteLine("| 0 - Sair                      |");
                Console.WriteLine(" -------------------------------");

                Console.WriteLine("Escolha uma opção do menu: ");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuEnum.LISTAR:
                        ListarFornecedores();
                        break;

                    case (int)MenuEnum.CADASTRO:
                        CadastrarFornecedor();
                        break;

                    case (int)MenuEnum.ALTERAR:
                        AlterarFornecedor();
                        break;

                    case (int)MenuEnum.EXCLUIR:
                        ExcluirFornecedor();
                        break;

                    case (int)MenuEnum.SAIR:
                        Console.Clear();
                        break;

                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));
        }

        private void ListarFornecedores()
        {
            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor)
            {
                Console.WriteLine(" *******************************************");
                Console.WriteLine($" Medico: {fornecedor.CodigoFornecedor}");
                Console.WriteLine($" Nome: {fornecedor.Nome}");
                Console.WriteLine($" CPF: {fornecedor.CGCCPF}");
                Console.WriteLine($" Especialidade: {fornecedor.TipoFornecedor}");
                Console.WriteLine(" *******************************************\n");
            }
        }

        private void CadastrarFornecedor()
        {
            int cod;
            while (true)
            {
                Console.WriteLine("");

                Console.WriteLine("Digite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome == "")
                {
                    Console.WriteLine("\n---Encerrado cadastro de fornecedores---\n");
                    break;
                }

                Console.WriteLine("Digite seu código: ");
                Int32.TryParse(Console.ReadLine(), out cod);

                Console.WriteLine("Digite seu CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite sua área: ");
                string tipo = Console.ReadLine();

                Fornecedor fornecedor = new Fornecedor(cod, nome, cpf, tipo);

                Program.Mock.ListaFornecedor.Add(fornecedor);
            }
        }

        private void AlterarFornecedor()
        {

        }

        private void ExcluirFornecedor()
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do fornecedor que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
                    Console.WriteLine("\n---Encerrado exclusão de fornecedores---\n");
                    break;
                }

                foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor) 
                { 
                    if (cod.Equals(fornecedor.CodigoFornecedor))
                    {
                        encontrou = true;
                        Program.Mock.ListaFornecedor.Remove(fornecedor);
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
