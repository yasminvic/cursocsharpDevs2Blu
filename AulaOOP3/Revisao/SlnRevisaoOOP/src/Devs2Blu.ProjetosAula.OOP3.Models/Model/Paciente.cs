using Devs2Blu.ProjetosAula.OOP3.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Models.Model
{
    public class Paciente : Pessoa //Classe filha : Classe mãe
    {
        public Int32 CodigoPaciente { get; set; } //declaração das propriedades, junto do getter e setter
        public String Convenio { get; set; }

        public Paciente()
        {
            //Construtor em branco
        }

        public Paciente(Int32 codigo, String nome, String cpf, String convenio)
        {
            Codigo = codigo;
            Nome = nome;
            CGCCPF = cpf;
            TipoPessoa = TipoPessoa.PF;
            Convenio = convenio;

            Random rd = new Random();
            CodigoPaciente = Int32.Parse($"{codigo}{rd.Next(100, 999)}");
        }
    }
}
