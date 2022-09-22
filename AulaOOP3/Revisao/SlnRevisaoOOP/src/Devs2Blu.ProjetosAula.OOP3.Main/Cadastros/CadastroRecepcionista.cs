using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroRecepcionista
    {
        public CadastroRecepcionista()
        {

        }

        public void MenuRecepcionista()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine(" ----------------MENU----------------");
                Console.WriteLine("| 1 - Lista de Recepcionistas        |");
                Console.WriteLine("| 2 - Cadastro de Recepcionista      |");
                Console.WriteLine("| 3 - Alterar Recepcionista          |");
                Console.WriteLine("| 4 - Excluir Recepcionistas         |");
                Console.WriteLine("| 0 - Sair                           |");
                Console.WriteLine(" ------------------------------------");

                Console.WriteLine("Escolha uma das opções do menu: ");
                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case (int)MenuEnum.LISTAR:
                        ListarRecepcionistas();
                        break;

                    case (int)MenuEnum.CADASTRO:
                        CadastrarRecepcionistas();
                        break;

                    case (int)MenuEnum.ALTERAR:
                        AlterarRecepcionistas();
                        break;

                    case (int)MenuEnum.EXCLUIR:
                        ExcluirRecepcionistas();
                        break;

                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));
            
        }

        private void ListarRecepcionistas()
        {
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.WriteLine(" *******************************************");
                Console.WriteLine($" Recepcionista: {recepcionista.CodigoRecepcionista}");
                Console.WriteLine($" Nome: {recepcionista.Nome}");
                Console.WriteLine($" CPF: {recepcionista.CGCCPF}");
                Console.WriteLine($" Setor: {recepcionista.Setor}");
                Console.WriteLine(" *******************************************\n");
            }
        }

        private void CadastrarRecepcionistas()
        {
            int cod;
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

                Console.WriteLine("Digite sue setor: ");
                string setor = Console.ReadLine();

                Recepcionista recepcionista = new Recepcionista(cod, nome, cpf, setor);

                Program.Mock.ListaRecepcionistas.Add(recepcionista);
            }
        }

        private void AlterarRecepcionistas()
        {

        }

        private void ExcluirRecepcionistas()
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do(a) recepcionista que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
                    break;
                }

                foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
                {
                    if (cod == recepcionista.CodigoRecepcionista)
                    {
                        encontrou = true;
                        Program.Mock.ListaRecepcionistas.Remove(recepcionista);
                        Console.WriteLine("Remoção concluída com sucesso !\n");
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
