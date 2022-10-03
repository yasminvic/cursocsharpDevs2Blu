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

            Console.WriteLine("----LISTA DE PACIENTES----\n");

            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.WriteLine(" *******************************");
                Console.WriteLine($"  Paciente: {paciente.CodigoPaciente}");
                Console.WriteLine($"  Nome: {paciente.Nome}");
                Console.WriteLine($"  CPF: {paciente.CGCCPF}");
                Console.WriteLine($"  Convênio: {paciente.Convenio}");
                Console.WriteLine(" *******************************\n");
            }
        }
        private void CadastrarPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Add(paciente);
        }
        private void AlterarPaciente()
        {
            Console.WriteLine("----ALTERANDO PACIENTES----");
            Console.WriteLine(); //pular linha
            int opc;
            bool encontrou = false;
            Int32 cod;
            while (true)
            {               
                Console.WriteLine("Informe o código do paciente que deseja alterar: (0 - Sair)");
                ListarPacientesByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("----Encerrado alteração de pacientes----\n\n");
                    break;
                }

                Console.WriteLine("Informe que opção deseja alterar: ");
                Console.WriteLine("1 - Nome  ║ 2 - CPF  ║ 3 - Convênio");
                Int32.TryParse(Console.ReadLine(), out opc);

                foreach (Paciente paciente in Program.Mock.ListaPacientes)
                {
                    if (paciente.CodigoPaciente.Equals(cod))
                    {
                        encontrou = true;
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Digite o novo nome: ");
                                paciente.Nome = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 2:
                                Console.WriteLine("Digite o novo CPF: ");
                                paciente.CGCCPF = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");

                                break;

                            case 3:
                                Console.WriteLine("Digite o novo convênio: ");
                                paciente.Convenio = Console.ReadLine();
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
                    Console.WriteLine("Código do paciente não existe !\n\n");
                }         
            }
        }
        private void ListarPacientesByCodeAndName()
        {
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("  Código      Nome");
            foreach (Paciente paciente in Program.Mock.ListaPacientes)
            {
                Console.Write($"  {paciente.CodigoPaciente}   -   {paciente.Nome} \n");
            }
            Console.WriteLine("╚═══════════════════════╝");
        }
        private void ExcluirPaciente(Paciente paciente)
        {
            Program.Mock.ListaPacientes.Remove(paciente);
        }

        #region FACADE
        public Int32 MenuCadastro() 
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
            Console.Clear();
            return opcao;
        }
        public void Listar()
        {
            ListarPacientes(); //encapsulamos o metedo e agora estamos chamando
        }
        public void Cadastrar()
        {
            Console.WriteLine("----CADASTRO DE PACIENTES----");
            while (true)
            {
                Console.WriteLine("\nDigite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    Console.WriteLine("\n---Encerrado cadastro de pacientes---\n");
                    break;
                }

                Console.WriteLine("Digite seu CPF: ");
                string CPF = Console.ReadLine();

                Console.WriteLine("Digite seu convênio: ");
                string convenio = Console.ReadLine();

                Random rd = new Random();
                int codigo = rd.Next(1, 100) + DateTime.Now.Second;

                Paciente paciente = new Paciente(codigo, nome, CPF, convenio);
                paciente.CodigoPaciente = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
                CadastrarPaciente(paciente);

                Console.WriteLine();
            }
        }
        public void Alterar()
        {
            AlterarPaciente();
        }
        public void Excluir()
        {
            Console.WriteLine("----EXCLUSÃO DE PACIENTES----");
            int cod;
            while (true)
            {
                bool encontrou = false;

                Console.WriteLine("\nDigite o código do paciente que deseja excluir: (0 - Parar)");
                ListarPacientesByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("\n---Encerrado exclusão de pacientes---\n");
                    break;
                }

                foreach (Paciente paciente in Program.Mock.ListaPacientes)
                {
                    if (cod.Equals(paciente.CodigoPaciente))
                    {
                        encontrou = true;
                        ExcluirPaciente(paciente);
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

