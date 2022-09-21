using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main
{
    class Program
    {
        public static Mocks Mock { get; set; }
        static void Main(string[] args)
        {
            Mock = new Mocks();
            ViewListPaciente();
        }

        public static void ViewListPaciente()
        {
            Console.Clear();

            foreach(Paciente paciente in Mock.ListaPacientes)
            {
                Console.WriteLine(" --------------------");
                Console.WriteLine($"| Paciente: {paciente.CodigoPaciente}    |");
                Console.WriteLine($"| Nome: {paciente.Nome}  |");
                Console.WriteLine($"| CPF: {paciente.CGCCPF} |");
                Console.WriteLine($"| Convênio: {paciente.Convenio}  |");
                Console.WriteLine(" --------------------\n");
            }
        }
    }
}
