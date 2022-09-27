using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Main.Cadastros;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;

namespace Devs2Blu.ProjetosAula.OOP3.Main
{
    class Program
    {
        public static Mocks Mock { get; set; }
        public static CadastroPaciente ModuloCadastroPacientes { get; set; }
        public static CadastroMedicos ModuloCadastroMedicos { get; set; }
        public static CadastroRecepcionista ModuloCadastroRecepcionista { get; set; }

        public static CadastroFornecedor ModuloCadastroFornecedor { get; set; }
        static void Main(string[] args)
        {
            Mock = new Mocks();

            int opcao = 0;

            do
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

                switch (opcao)
                {
                    case (int)MenuEnum.CD_PACIENTE:
                        CadastroPaciente ModuloCadastroPacientes = new CadastroPaciente();
                        ModuloCadastroPacientes.MenuCadastro();
                        break;

                    case (int)MenuEnum.CD_MEDICO:
                        CadastroMedicos ModuloCadastroMedicos = new CadastroMedicos();
                        ModuloCadastroMedicos.MenuMedicos();
                        break;

                    case (int)MenuEnum.CD_RECEPCIONISTA:
                        CadastroRecepcionista ModuloCadastroRecepcionista = new CadastroRecepcionista();
                        ModuloCadastroRecepcionista.MenuRecepcionista();
                        break;

                    case (int)MenuEnum.CD_FORNCEDOR:
                        CadastroFornecedor ModuloCadastroFornecedor = new CadastroFornecedor();
                        ModuloCadastroFornecedor.MenuFornecedor();
                        break;

                    case (int)MenuEnum.SAIR:
                        Console.WriteLine("Saindo do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inváilida\n");
                        break;
                }

            } while (!opcao.Equals((int)MenuEnum.SAIR));

        }

    }
}
