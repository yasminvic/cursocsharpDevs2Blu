using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Main.Interface;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroPaciente : IMenuCadastro // classe com menu de opções e seus respectivos metodos
    {
        //implementamos uma interface depois dos dois pontos
        public CadastroPaciente()
        {

        }
        private void ListarPacientes()
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

        private void CadastrarPaciente(Paciente paciente)
        {
            int cod;
            while (true)
            {
                Console.WriteLine("\nDigite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    Console.WriteLine("\n---Encerrado cadastro de pacientes---\n");
                    break;
                }

                Console.WriteLine("Digite seu código: ");
                Int32.TryParse(Console.ReadLine(), out cod);

                Console.WriteLine("Digite seu CPF: ");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite seu convênio: ");
                string conv = Console.ReadLine();

                Console.WriteLine();

                Paciente pacient = new Paciente(cod, nome, cpf, conv);
                Program.Mock.ListaPacientes.Add(pacient);
            }
        }

        private void AlterarPaciente(Paciente paciente)
        {

        }

        private void ExcluirPaciente(Paciente paciente)
        {
            int cod;
            bool encontrou = false;
            while (true)
            {
                Console.WriteLine("\nDigite o código do paciente que deseja excluir: (0 - Parar)");
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod == (int)MenuEnum.SAIR)
                {
                    Console.WriteLine("\n---Encerrado exclusão de pacientes---\n");
                    break;
                }

                foreach (Paciente pacient in Program.Mock.ListaPacientes)
                {
                    if (cod.Equals(pacient.CodigoPaciente))
                    {
                        encontrou = true;
                        Program.Mock.ListaPacientes.Remove(pacient);
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

        public Int32 MenuCadastro() // mock usado nos metodos
        {
           int opcao = 0;

            Console.WriteLine(" ------------MENU---------------");
            Console.WriteLine("| 1 - Lista de Pacientes        |");
            Console.WriteLine("| 2 - Cadastro de Pacientes     |");
            Console.WriteLine("| 3 - Alterar Pacientes         |");
            Console.WriteLine("| 4 - Excluir Pacientes         |");
            Console.WriteLine("| 0 - Sair                      |");
            Console.WriteLine(" -------------------------------");

            Console.WriteLine("Escolha uma opção do menu: ");
            Int32.TryParse(Console.ReadLine(), out opcao);

            return opcao;
        }

        #region FACADE
        public void Listar()
        {
            ListarPacientes(); //encapsulamos o metedo e agora estamos chamando
        }

        public void Cadastrar()
        {
            Paciente paciente = new Paciente();
            CadastrarPaciente(paciente);
        }

        public void Alterar()
        {
            Paciente paciente = new Paciente();
            AlterarPaciente(paciente);
        }

        public void Excluir()
        {
            Paciente paciente = new Paciente();
            ExcluirPaciente(paciente);
        }


        

        
        #endregion

    }
}
