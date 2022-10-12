using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Classes.Model
{
    public class Recepcionista : Pessoa
    {
        public Int32 numCracha { get; set; }
        public Recepcionista()
        {
                
        }
        public Recepcionista(String nome, String Sobrenome, String DataNascimento, Endereco endereco, int numCracha)
        {
            this.Nome = nome;
            this.Sobrenome = Sobrenome;
            this.DataNascimento = DataNascimento;
            this.Endereco = endereco;
            this.numCracha = numCracha;
        }
    }
}
