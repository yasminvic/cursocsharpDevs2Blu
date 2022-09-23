using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroPaciente // classe com menu de opções e seus respectivos metodos
    {
        public CadastroPaciente()
        {

        }

        public void MenuCadastro() // mock usado nos metodos
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
                        ListarPacientes();
                        break;

                    case (int)MenuEnum.CADASTRO:
                        CadastrarPaciente();
                        break;

                    case (int)MenuEnum.ALTERAR:
                        AlterarPaciente();
                        break;

                    case (int)MenuEnum.EXCLUIR:
                        ExcluirPaciente();
                        break;

                    case (int)MenuEnum.SAIR:
                        Console.Clear();
                        break;

                    default:
                        break;
                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));
        }


        public void ListarPacientes()
        {
            Console.Clear();

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine(" *******************************************");
                Console.WriteLine($"| Paciente: {paciente.CodigoPaciente}");
                Console.WriteLine($"| Nome: {paciente.Nome}");
                Console.WriteLine($"| CPF: {paciente.CGCCPF}");
                Console.WriteLine($"| Convênio: {paciente.Convenio}");
                Console.WriteLine(" *******************************************\n");
            }
        }

        public void CadastrarPaciente()
        {
            int cod;
            while (true)
            {
                Console.WriteLine("\nDigite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    break;
                }

                Console.WriteLine("Digite seu código: ");
                Int32.TryParse(Console.ReadLine(), out cod);

                Console.WriteLine("Digite seu CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite seu convênio: ");
                string conv = Console.ReadLine();

                Console.WriteLine();

                Paciente paciente = new Paciente(cod,nome,cpf, conv);
                Program.Mock.ListaPacientes.Add(paciente);
            }
        }

        public void AlterarPaciente()
        {

        }

        public void ExcluirPaciente()
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do paciente que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
                    break;
                }

                foreach (Paciente paciente in Program.Mock.ListaPacientes)
                {
                    if (cod.Equals(paciente.CodigoPaciente))
                    {
                        encontrou = true;
                        Program.Mock.ListaPacientes.Remove(paciente);
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

    }
}
