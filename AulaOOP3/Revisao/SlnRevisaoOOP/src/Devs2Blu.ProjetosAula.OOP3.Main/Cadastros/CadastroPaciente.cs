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

        }

        public void AlterarPaciente()
        {

        }

        public void ExcluirPaciente()
        {

        }

    }
}
