using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Classes.Model
{
    public class Diretor : Pessoa
    {
        public double Prolabore { get; set; }
        public Diretor()
        {

        }

        public Diretor(String nome, String Sobrenome, String DataNascimento, Endereco endereco, double Prolabore)
        {
            this.Nome = nome;
            this.Sobrenome = Sobrenome;
            this.DataNascimento = DataNascimento;
            this.Endereco = endereco;
            this.Prolabore = Prolabore;
        }
    }
}
