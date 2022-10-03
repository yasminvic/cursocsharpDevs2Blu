using Devs2Blu.ProjetosAula.OOP3.Main.Interface;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroFornecedor : IMenuCadastro
    {
        public CadastroFornecedor()
        {

        }

        private void ListarFornecedores()
        {
            Console.WriteLine("----LISTA DE FORNECEDORES----\n");
            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor)
            {
                Console.WriteLine(" *******************************");
                Console.WriteLine($" Fornecedor: {fornecedor.CodigoFornecedor}");
                Console.WriteLine($" Nome: {fornecedor.Nome}");
                Console.WriteLine($" CPF: {fornecedor.CGCCPF}");
                Console.WriteLine($" Tipo: {fornecedor.TipoFornecedor}");
                Console.WriteLine(" *******************************\n");
            }
        }
        private void CadastrarFornecedor(Fornecedor fornecedor)
        {
            Program.Mock.ListaFornecedor.Add(fornecedor);
        }
        private void AlterarFornecedor()
        {
            Console.WriteLine("----ALTERANDO FORNECEDORES----");
            Console.WriteLine(); //pular linha
            int opc;
            bool encontrou = false;
            Int32 cod;
            while (true)
            {
                Console.WriteLine("Informe o código do paciente que deseja alterar: (0 - Sair)");
                ListarFornecedoresByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("----Encerrado alteração de fornecedores----\n\n");
                    break;
                }

                Console.WriteLine("Informe que opção deseja alterar: ");
                Console.WriteLine("1 - Nome  ║ 2 - CPF  ║ 3 - Tipo");
                Int32.TryParse(Console.ReadLine(), out opc);

                foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor)
                {
                    if (fornecedor.CodigoFornecedor.Equals(cod))
                    {
                        encontrou = true;
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Digite o novo nome: ");
                                fornecedor.Nome = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 2:
                                Console.WriteLine("Digite o novo CPF: ");
                                fornecedor.CGCCPF = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 3:
                                Console.WriteLine("Digite o novo tipo: ");
                                fornecedor.TipoFornecedor = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            default:
                                Console.WriteLine("Código inválido ! Tente novamente\n\n");
                                break;
                        }
                    }
                }
                if (encontrou == false)
                {
                    Console.WriteLine("Código do fornecedor não existe !\n\n");
                }
            }    
        }
        private void ListarFornecedoresByCodeAndName()
        {
            Console.WriteLine("╔═════════════════════════╗");
            Console.WriteLine("  Código      Nome");
            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor)
            {
                Console.Write($"  {fornecedor.CodigoFornecedor}   -   {fornecedor.Nome} \n");
            }
            Console.WriteLine("╚═════════════════════════╝");
        }
        private void ExcluirFornecedor(Fornecedor fornecedor)
        {
            Program.Mock.ListaFornecedor.Remove(fornecedor);
        }

        #region FACADE
        public Int32 MenuCadastro()
        {
            int opcao = 0;

            Console.WriteLine(" ------------MENU-----------------");
            Console.WriteLine("| 1 - Lista de Fornecedores       |");
            Console.WriteLine("| 2 - Cadastro de Fornecedores    |");
            Console.WriteLine("| 3 - Alterar Fornecedores        |");
            Console.WriteLine("| 4 - Excluir Fornecedores        |");
            Console.WriteLine("| 0 - Sair                        |");
            Console.WriteLine(" ---------------------------------");

            Console.WriteLine("Escolha uma opção do menu: ");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }
        public void Listar()
        {
            ListarFornecedores();
        }
        public void Cadastrar()
        {
            Console.WriteLine("----CADASTRO DE FORNECEDORES----\n");
            while (true)
            {
                Console.WriteLine("Digite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    Console.WriteLine("\n---Encerrado cadastro de fornecedores---\n");
                    break;
                }

                Console.WriteLine("Digite seu CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite sua área: ");
                string tipo = Console.ReadLine();

                Random rd = new Random();
                int codigo = rd.Next(1, 100) + DateTime.Now.Second;

                Fornecedor fornecedor = new Fornecedor(codigo, nome, cpf, tipo);
                fornecedor.CodigoFornecedor = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
                CadastrarFornecedor(fornecedor);

                Console.WriteLine();                
            }
        }
        public void Alterar()
        {
            AlterarFornecedor();
        }
        public void Excluir()
        {
            Console.WriteLine("----EXCLUSÃO DE FORNECEDORES----");
            int cod;
            while (true)
            {
                bool encontrou = false;

                Console.WriteLine("\nDigite o código do fornecedor que deseja excluir: (0 - Parar)");
                ListarFornecedoresByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("\n---Encerrado exclusão de fornecedores---\n");
                    break;
                }

                foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedor)
                {
                    if (cod.Equals(fornecedor.CodigoFornecedor))
                    {
                        encontrou = true;
                        ExcluirFornecedor(fornecedor);
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
        #endregion
    }
}
