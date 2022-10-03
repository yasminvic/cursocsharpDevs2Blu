using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System.Globalization;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using Devs2Blu.ProjetosAula.OOP3.Main.Interface;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroMedicos : IMenuCadastro
    {

        public CadastroMedicos()
        {

        }

        private void ListarMedicos()
        {
            Console.WriteLine("----LISTA DE MÉDICOS----\n");

            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine(" *******************************");
                Console.WriteLine($"  Médico: {medico.CodigoMedico}");
                Console.WriteLine($"  Nome: {medico.Nome}");
                Console.WriteLine($"  CPF: {medico.CGCCPF}");
                Console.WriteLine($"  CRM: {medico.CRM}");
                Console.WriteLine($"  Especialidade: {medico.Especialidade}");
                Console.WriteLine(" *******************************\n");
            }
        }
        private void CadastrarMedico(Medico medico)
        {
            Program.Mock.ListaMedicos.Add(medico);
        }
        private void AlterarMedico()
        {
            Console.WriteLine("----ALTERANDO MÉDICO----");
            Console.WriteLine(); //pular linha
            int opc;
            bool encontrou = false;
            Int32 cod;
            while (true)
            {
                Console.WriteLine("Informe o código do(a) médico(a) que deseja alterar: (0 - Sair)");
                ListarMedicosByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("----Encerrado alteração de médicos----\n\n");
                    break;
                }

                Console.WriteLine("Informe que opção deseja alterar: ");
                Console.WriteLine("1 - Nome  ║ 2 - CPF  ║ 3 - CRM ║ 4 - Especialidade");
                Int32.TryParse(Console.ReadLine(), out opc);

                foreach (Medico medico in Program.Mock.ListaMedicos)
                {
                    if (medico.CodigoMedico.Equals(cod))
                    {
                        encontrou = true;
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Digite o novo nome: ");
                                medico.Nome = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 2:
                                Console.WriteLine("Digite o novo CPF: ");
                                medico.CGCCPF = Console.ReadLine();
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 3:
                                Console.WriteLine("Digite o novo CRM: ");
                                Int32 crm;
                                Int32.TryParse(Console.ReadLine(), out crm);
                                medico.CRM = crm;
                                Console.WriteLine("Alteração realizada com sucesso !\n\n");
                                break;

                            case 4:
                                Console.WriteLine("Digite a nova especialidade: ");
                                medico.Especialidade = Console.ReadLine();
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
                    Console.WriteLine("Código do(a) medico(a) não existe !\n\n");
                }
            }
        }
        private void ListarMedicosByCodeAndName()
        {
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("  Código      Nome");
            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.Write($"  {medico.CodigoMedico}   -   {medico.Nome} \n");
            }
            Console.WriteLine("╚══════════════════════════╝");
        }
        private void ExcluirMedico(Medico medico)
        {
            Program.Mock.ListaMedicos.Remove(medico);
        }

        #region FACADE
        public Int32 MenuCadastro()
        {
            int opcao = 0;
            Console.WriteLine(" ------------MENU-------------");
            Console.WriteLine("| 1 - Lista de Médicos        |");
            Console.WriteLine("| 2 - Cadastro de Médicos     |");
            Console.WriteLine("| 3 - Alterar Médicos         |");
            Console.WriteLine("| 4 - Excluir Médicos         |");
            Console.WriteLine("| 0 - Sair                    |");
            Console.WriteLine(" -----------------------------");

            Console.WriteLine("Escolha uma opção do menu: ");
            Int32.TryParse(Console.ReadLine(), out opcao);
            Console.Clear();
            return opcao;
        }
        public void Listar()
        {
            ListarMedicos();
        }
        public void Cadastrar()
        {
            Console.WriteLine("----CADASTRO DE MÉDICOS----");
            while (true)
            {
                Console.WriteLine("\nDigite seu nome: (Enter - Parar)");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    Console.WriteLine("\n---Encerrado cadastro de médicos---\n");
                    break;
                }

                Console.WriteLine("Digite seu CPF: ");
                string CPF = Console.ReadLine();

                Console.WriteLine("Digite seu CRM: ");
                Int32 crm;
                Int32.TryParse(Console.ReadLine(), out crm);

                Console.WriteLine("Digite sua especialidade: ");
                string espc = Console.ReadLine();

                Random rd = new Random();
                int codigo = rd.Next(1, 100) + DateTime.Now.Second;

                Medico medico = new Medico(codigo, nome, CPF, crm, espc);
                medico.CodigoMedico = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
                CadastrarMedico(medico);

                Console.WriteLine();
            }
        }
        public void Alterar()
        {
            AlterarMedico();
        }
        public void Excluir()
        {
            Console.WriteLine("----EXCLUSÃO DE MÉDICOS----");
            int cod;
            
            while (true)
            {
                bool encontrou = false;

                Console.WriteLine("\nDigite o código do(a) médico(a) que deseja excluir: (0 - Parar)");
                ListarMedicosByCodeAndName();
                Int32.TryParse(Console.ReadLine(), out cod);

                if (cod.Equals((int)MenuEnum.SAIR))
                {
                    Console.WriteLine("\n---Encerrado exclusão de médicos---\n");
                    break;
                }

                foreach (Medico medico in Program.Mock.ListaMedicos)
                {
                    if (cod.Equals(medico.CodigoMedico))
                    {
                        encontrou = true;
                        ExcluirMedico(medico);
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
