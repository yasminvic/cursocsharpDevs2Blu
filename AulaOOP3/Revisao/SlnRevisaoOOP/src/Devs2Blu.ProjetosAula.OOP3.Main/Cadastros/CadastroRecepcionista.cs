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
    public class CadastroRecepcionista : IMenuCadastro
    {
        public CadastroRecepcionista()
        {

        }

        private void ListarRecepcionistas()
        {
            Console.WriteLine("----LISTA DE  RECEPCIONISTAS----\n");

            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.WriteLine(" *******************************");
                Console.WriteLine($"  Recepcionista: {recepcionista.CodigoRecepcionista}");
                Console.WriteLine($"  Nome: {recepcionista.Nome}");
                Console.WriteLine($"  CPF: {recepcionista.CGCCPF}");
                Console.WriteLine($"  Setor: {recepcionista.Setor}");
                Console.WriteLine(" *******************************\n");
            }
        }
        private void CadastrarRecepcionista(Recepcionista recepcionista)
        {
            Program.Mock.ListaRecepcionistas.Add(recepcionista);
        }
        private void AlterarRecepcionista()
        {
            Console.WriteLine("----ALTERANDO RECEPCIONISTA----");
            Console.WriteLine(); //pular linha
            int opc;
            bool encontrou = false;
            Int32 cod;
            while (true)
            {
                Console.WriteLine("Informe o código do(a) recepcionista que deseja alterar: (0 - Sair)");
                ListarRecepcionistasByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("----Encerrado alteração de recepcionistas----\n\n");
                    break;
                }

                Console.WriteLine("Informe que opção deseja alterar: ");
                Console.WriteLine("1 - Nome  ║ 2 - CPF  ║ 3 - Setor");
                Int32.TryParse(Console.ReadLine(), out opc);

                foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
                {
                    if (recepcionista.CodigoRecepcionista.Equals(cod))
                    {
                        encontrou = true;
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Digite o novo nome: ");
                                recepcionista.Nome = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 2:
                                Console.WriteLine("Digite o novo CPF: ");
                                recepcionista.CGCCPF = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");

                                break;

                            case 3:
                                Console.WriteLine("Digite o novo setor: ");
                                recepcionista.Setor = Console.ReadLine();
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
                    Console.WriteLine("Código do(a) recepcionista não existe !\n\n");
                }
            }
        }
        private void ListarRecepcionistasByCodeAndName()
        {
            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("  Código      Nome");
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.Write($"  {recepcionista.CodigoRecepcionista}   -   {recepcionista.Nome} \n");
            }
            Console.WriteLine("╚═════════════════════════════╝");
        }
        private void ExcluirRecepcionista(Recepcionista recepcionista)
        {
            Program.Mock.ListaRecepcionistas.Remove(recepcionista);
        }

        #region FACADE
        public Int32 MenuCadastro()
        {
            int opcao = 0;
            Console.WriteLine(" ------------MENU--------------------");
            Console.WriteLine("| 1 - Lista de Recepcionistas        |");
            Console.WriteLine("| 2 - Cadastro de Recepcionistas     |");
            Console.WriteLine("| 3 - Alterar Recepcionistas         |");
            Console.WriteLine("| 4 - Excluir Recepcionistas         |");
            Console.WriteLine("| 0 - Sair                           |");
            Console.WriteLine(" ------------------------------------");

            Console.WriteLine("Escolha uma opção do menu: ");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }
        public void Listar()
        {
            ListarRecepcionistas(); 
        }
        public void Cadastrar()
        {
            Console.WriteLine("----CADASTRO DE RECEPCIONISTAS----");
            while (true)
            {
                Console.WriteLine("\nDigite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    Console.WriteLine("\n---Encerrado cadastro de recepcionistas ---\n");
                    break;
                }

                Console.WriteLine("Digite seu CPF: ");
                string CPF = Console.ReadLine();

                Console.WriteLine("Digite seu setor: ");
                string setor = Console.ReadLine();

                Random rd = new Random();
                int codigo = rd.Next(1, 100) + DateTime.Now.Second;

                Recepcionista recepcionista= new Recepcionista(codigo, nome, CPF, setor);
                recepcionista.CodigoRecepcionista = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
                CadastrarRecepcionista(recepcionista);

                Console.WriteLine();
            }
        }
        public void Alterar()
        {
            AlterarRecepcionista();
        }
        public void Excluir()
        {
            Console.WriteLine("----EXCLUSÃO DE RECEPCIONISTAS----");
            int cod;
            while (true)
            {
                bool encontrou = false;

                Console.WriteLine("\nDigite o código do(a) recepcionista que deseja excluir: (0 - Parar)");
                ListarRecepcionistasByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("\n---Encerrado exclusão de recepcionistas---\n");
                    break;
                }

                foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
                {
                    if (cod.Equals(recepcionista.CodigoRecepcionista))
                    {
                        encontrou = true;
                        ExcluirRecepcionista(recepcionista);
                        Console.WriteLine("Remoção realizada com sucesso!");
                        break;
                    }
                }
                if (encontrou == false)
                {
                    Console.WriteLine("O código informado não existe ! Tente novamente");
                }
            }
        }
        #endregion
    }
}
