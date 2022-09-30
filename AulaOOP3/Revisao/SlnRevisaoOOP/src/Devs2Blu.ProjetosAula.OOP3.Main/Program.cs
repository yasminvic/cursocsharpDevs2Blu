using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Main.Cadastros;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Main.Interface;

namespace Devs2Blu.ProjetosAula.OOP3.Main
{
    class Program
    {
        public static Mocks Mock { get; set; }

        static void Main(string[] args)
        {
            Mock = new Mocks();
            Int32 opcao = (int)MenuEnum.SAIR, opcMenuCadastros = (int)MenuEnum.SAIR;
            IMenuCadastro menuCadastros; //criando objeto da classe

            do
            {
                if (opcMenuCadastros.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine(" ---------------MENU----------------");
                    Console.WriteLine("| 10 - Cadastro de Pacientes        |");
                    Console.WriteLine("| 20 - Cadastro de Médicos          |");
                    Console.WriteLine("| 30 - Cadastro Recepcionistas      |");
                    Console.WriteLine("| 40 - Cadastro de Fornecedores     |");
                    Console.WriteLine("| 50 - Agenda                       |");
                    Console.WriteLine("| 60 - Prontuário                   |");
                    Console.WriteLine("| 50 - Financeiro                   |");
                    Console.WriteLine("| 0 - Sair                          |");
                    Console.WriteLine(" -----------------------------------");

                    Console.WriteLine("Escolha uma opção do menu: ");
                    Int32.TryParse(Console.ReadLine(), out opcao);

                    Console.Clear();

                }

                switch (opcao)
                {
                    case (int)MenuEnum.CD_PACIENTE:
                        menuCadastros = new CadastroPaciente();
                        opcMenuCadastros = menuCadastros.MenuCadastro();
                        break;

                    case (int)MenuEnum.CD_MEDICO:
                        menuCadastros = new CadastroMedicos();
                        opcMenuCadastros = menuCadastros.MenuCadastro();
                        break;

                    default:
                        menuCadastros = new CadastroPadrao();
                        opcMenuCadastros = (int)MenuEnum.SAIR;
                        break;
                }

                switch (opcMenuCadastros)
                {
                    case (int)MenuEnum.LISTAR:
                        menuCadastros.Listar();
                        break;

                    case (int)MenuEnum.CADASTRO:
                        menuCadastros.Cadastrar();
                        break;

                    case (int)MenuEnum.EXCLUIR:
                        menuCadastros.Excluir();
                        break;

                    case (int)MenuEnum.ALTERAR:
                        menuCadastros.Alterar();
                        break;

                    default:
                        opcMenuCadastros = (int)MenuEnum.SAIR;
                        break;
                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));

        }

    }
}
