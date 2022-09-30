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
                Console.WriteLine(" *******************************************");
                Console.WriteLine($"| Paciente: {paciente.CodigoPaciente}");
                Console.WriteLine($"| Nome: {paciente.Nome}");
                Console.WriteLine($"| CPF: {paciente.CGCCPF}");
                Console.WriteLine($"| Convênio: {paciente.Convenio}");
                Console.WriteLine(" *******************************************\n");
            }
        }

        private void CadastrarPaciente()
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
                int codigoPaciente = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
                Program.Mock.ListaPacientes.Add(paciente);

                Console.WriteLine();             
            }
            
        }

        private void AlterarPaciente(Paciente paciente)
        {
            while (true)
            {
                Console.WriteLine("Informe o código do paciente que deseja alterar: ");
                string cod = Console.ReadLine();

                Console.WriteLine("Informe que opção deseja alterar: ");
                Console.WriteLine("1 - Nome  ║ 2 - CPF  ║ 3 - Convênio");
                string opc = Console.ReadLine();

                //criar um for

                switch (opc)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Digite o novo nome: ");
                        paciente
                }
            }
        }

        private void ExcluirPaciente()
        {
            Console.WriteLine("----EXCLUIR PACIENTES----");

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

            Console.Clear();

            return opcao;
            
        }

        #region FACADE
        public void Listar()
        {
            ListarPacientes(); //encapsulamos o metedo e agora estamos chamando
        }

        public void Cadastrar()
        {
            //Paciente novopaciente = new Paciente();
            CadastrarPaciente();

        }

        public void Alterar()
        {
            Paciente paciente = new Paciente();
            AlterarPaciente(paciente);
        }

        public void Excluir()
        {
            ExcluirPaciente();
        }

        #endregion

    }
}
